using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using System.Text;
using BussinessObject;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using Newtonsoft.Json;
using System.IO;
using System.Web.Hosting;
using Aspose.Foundation.UriResolver.RequestResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;




//https://stackoverflow.com/questions/41240722/xml-request-using-post-methodssss
public class API_Post_Data
{
   
    public string Folder_path;
    Global_variables ObjUBO = new Global_variables();

    public string Ebms_Url_Link = "https://ebmsngdev1-ngdevtesting.azurewebsites.net/";
    public string Sws_Url_Link = "https://sws.ebmsapps.com/";
    public string Cooper_Api_Link = "https://apieroyal.copperhawk.tech/CHA/AddNewJobWebhook";
    public string Sora_Url_Link = "https://sora.ebmsapps.com/";
    public string Mez_Kps_Imp_Url = "https://kpssl.m.frappe.cloud/api/method/kps_app.api.job_creation.create_import_job";
    public string Mez_Kps_Exp_Url = "https://kpssl.m.frappe.cloud/api/method/kps_app.api.job_creation.create_export_job";
    public string Groupname = "";
    public string respStr_Hll,trans_mode;
    private static string Royal_HHL_Api_Link = "https://b1.gocargonet.com/Royal_HHL/api/shipments/eDocsUploadserver";
    private static string Royal_HHL_Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySUQiOiI1NjYzIiwiVXNlck5hbWUiOiJJQ1RRUkFkbWluIiwibmJmIjoxNzcyNzcwNzgwLCJleHAiOjI1MzQwMjI4MTAwMCwiaWF0IjoxNzcyNzcwNzgwfQ.t-N3XZNZ8-9OtkDILFQUkRGQ9LFxcgaVvUZIMfK_APw"; // your full token here
    private static string Royal_HHL_Exp_Sea = "https://b1.gocargonet.com/Royal_HHL/api/shipments/SEUploadserver";
    private static string Royal_HHL_Exp_Air = "https://b1.gocargonet.com/Royal_HHL/api/shipments/AEUploadserver";
    private static string Royal_HHL_Imp_Sea = "https://b1.gocargonet.com/Royal_HHL/api/shipments/SIUploadserver";
    private static string Royal_HHL_Imp_Air = "https://b1.gocargonet.com/Royal_HHL/api/shipments/AIUploadserver";
    public string General_Details_API_Post(string job_no, string WKPD, string Imp_exp, string filetype, string Branch_code)
    {
        StringBuilder xmlContent = new StringBuilder();
        DataSet Gen_dss = new DataSet();
        
        ObjUBO.A1 = job_no;
        ObjUBO.A3 = WKPD;
        ObjUBO.A4 = "GetImport_Export_General_Details";
        ObjUBO.A5 = Imp_exp;
        ObjUBO.A6 = Branch_code;
        Gen_dss = Select_Imp_Exp_Job_Details(ObjUBO);
        if (Gen_dss.Tables.Count > 0)
        {
               if (Imp_exp.ToString() == "I" && filetype.ToString() == "JSON")
               {
                   return Imp_JSON_General(Gen_dss, job_no, Imp_exp, filetype);   
               
                }
               else if (Imp_exp.ToString() == "E" && filetype.ToString() == "JSON")
                {
                    return Exp_JSON_General(Gen_dss, job_no, Imp_exp, filetype);
                }
        }
        return "No Data Found";
    }
     
   public string CheckList_API_Post(string job_no,string WKPD, string Imp_exp, string filetype, string Branch_code)
   {
       StringBuilder xmlContent = new StringBuilder();
       DataSet dss = new DataSet();

       ObjUBO.A1 = job_no;
       ObjUBO.A3 = WKPD;
       ObjUBO.A4 = "GetImport_ExportDataset";
       ObjUBO.A5 = Imp_exp;
       ObjUBO.A6 = Branch_code;
       dss = Select_Imp_Exp_Job_Details(ObjUBO);
       CleanJsonSpecialCharacters(dss);

       if (dss.Tables.Count > 0)
       {
           if (Imp_exp.ToString() == "I")
           {
               if (filetype.ToString() == "XML")
               {
                   return Imp_XML_Generate(dss, job_no);
               }
               else
               {
                   return  Imp_JSON_Generate(dss, job_no, Imp_exp, filetype);
               }
           }
           else
           {
               if (filetype.ToString() == "XML")
               {
                   return Exp_XML_Generate(dss, job_no);

               }
               else
               {
                   return Exp_JSON_Generate(dss, job_no, Imp_exp, filetype);
               }

           }
            
       }
       return "No Data Found";

   }
   private void CleanJsonSpecialCharacters(DataSet ds)
   {
       if (ds == null || ds.Tables.Count == 0)
           return;

       foreach (DataTable dt in ds.Tables)
       {
           // Only string columns
           var stringColumns = dt.Columns.Cast<DataColumn>()
                                         .Where(c => c.DataType == typeof(string));

           foreach (DataRow dr in dt.Rows)
           {
               foreach (DataColumn dc in stringColumns)
               {
                   if (dr[dc] != DBNull.Value)
                   {
                       string value = dr[dc].ToString();

                       if (!string.IsNullOrEmpty(value))
                       {
                           // Check first before replace for better performance
                           if (value.Contains("\"") ||
                               value.Contains("'") ||
                               value.Contains("\\") ||
                               value.Contains("\n") ||
                               value.Contains("\r") ||
                               value.Contains("\t"))
                           {
                               value = value.Replace("\"", "")
                                            .Replace("'", "")
                                            .Replace("\\", "")
                                            .Replace("\n", "")
                                            .Replace("\r", "")
                                            .Replace("\t", "")
                                            .Trim();

                               dr[dc] = value;
                           }
                       }
                   }
               }
           }
       }
   }
   public string Imp_JSON_General(DataSet dss, string job_no, string Imp_exp, string filetype)
   {
       StreamWriter sw;
       string errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + Connection.Company_License() + "/" + Imp_exp + "/" + filetype);

       if (!Directory.Exists(errorFolder))
       {
           Directory.CreateDirectory(errorFolder);
       }
       string filePath = Path.Combine(errorFolder, Imp_exp + "_" + job_no + ".JSON");

       if (File.Exists(filePath))
       {
           File.Delete(filePath);
       }
       sw = new StreamWriter(filePath, true);
      
       
       #region Json
      
           if (dss.Tables[0].Rows.Count > 0)
           {
               sw.WriteLine("{");
               sw.WriteLine("      \"Company_Id\": \"" + Connection.Company_License() + "\",");
               sw.WriteLine("      \"Group_name\": \"" + Connection.Current_Group() + "\",");
               sw.WriteLine("      \"Wrk_prd\": \"" + Connection.WorkingPeriod() + "\",");
               sw.WriteLine("  \"JobDetails\": {");

               sw.WriteLine("      \"Job_No\": \"" + job_no + "\",");
               sw.WriteLine("      \"Job_Date\": \"" + (dss.Tables[0].Rows[0]["JOBDATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[0].Rows[0]["JOBDATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");

               sw.WriteLine("      \"Transport_Mode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["TRANSPORT_MODENEW"].ToString()) ? " " : dss.Tables[0].Rows[0]["TRANSPORT_MODENEW"].ToString()) + "\",");
               sw.WriteLine("      \"BE_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["BE_TYPE_New"].ToString()) ? " " : dss.Tables[0].Rows[0]["BE_TYPE_New"].ToString()) + "\",");
               sw.WriteLine("      \"CustomsHouse\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()) ? " " : dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()) + "\",");
               sw.WriteLine("      \"ImporterName\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address1\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS1"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS1"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address2\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS2"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS2"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address3\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS3"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS3"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address4\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address5\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS5"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS5"].ToString()) + "\",");
               sw.WriteLine("      \"IEC_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["IEC_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["IEC_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Branch_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()) + "\",");
               sw.WriteLine("      \"CountryOfOrigin\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString()) ? " " : dss.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString()) + "\",");
               sw.WriteLine("      \"PortOfShipment\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString()) ? " " : dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString()) + "\",");
               sw.WriteLine("      \"CountryOfShipment\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString()) ? " " : dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString()) + "\",");
               sw.WriteLine("      \"PortOfOrgin\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString()) ? " " : dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString()) + "\",");
               sw.WriteLine("      \"FilingStatus\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FILING_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["FILING_STATUS"].ToString()) + "\",");
               sw.WriteLine("      \"UnderSec46\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION46"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION46"].ToString()) + "\",");
               sw.WriteLine("      \"UnderSec46Remarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION46_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION46_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"FirstCheck\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FIRSTCHECK"].ToString()) ? " " : dss.Tables[0].Rows[0]["FIRSTCHECK"].ToString()) + "\",");
               sw.WriteLine("      \"FirstCheckRemarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"GreenChannel\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString()) ? " " : dss.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString()) + "\",");
               sw.WriteLine("      \"GreenChannelRemarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"KachhaBE\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["KACHHA_BE"].ToString()) ? " " : dss.Tables[0].Rows[0]["KACHHA_BE"].ToString()) + "\",");
               sw.WriteLine("      \"KachhaBERemarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"UnderSec48\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION48"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION48"].ToString()) + "\",");
               sw.WriteLine("      \"UnderSec48Remarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION48_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION48_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSale\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSeleName\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerIEC\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerBranchSNo\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerAddress\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD1"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD1"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerAddress2\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD2"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD2"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerCity\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD3"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD3"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerState\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD4"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD4"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerPinCode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD5"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD5"].ToString()) + "\",");
               sw.WriteLine("      \"WareHouseCode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString()) + "\",");
               sw.WriteLine("      \"WareHouseName\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Details_Status\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Tax_Statename\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Tax_Statecode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Tax_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Tax_Registration_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Inbond_Be_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Inbond_Be_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Bond_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Bond_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Warehouse_Customs\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Warehouse_Customs_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Noofpackage\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Noofpackage_Unitcode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Gross_Weight\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Gross_Weight_Unitcode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Direct_Exbonding\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString()) + "\",");
               sw.WriteLine("      \"Remarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["REMARKS"].ToString()) ? " " : dss.Tables[0].Rows[0]["REMARKS"].ToString()) + "\",");
               sw.WriteLine("      \"File_Ref_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Container_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString()) + "\",");
               sw.WriteLine("      \"Job_Status\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["JOB_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["JOB_STATUS"].ToString()) + "\",");
               sw.WriteLine("      \"Job_Filed_Status\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["JOB_FILED_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["JOB_FILED_STATUS"].ToString()) + "\",");
               sw.WriteLine("      \"Jobno_Ps\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["JOBNO_PS"].ToString()) ? " " : dss.Tables[0].Rows[0]["JOBNO_PS"].ToString()) + "\",");
               sw.WriteLine("      \"Completed_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMPLETED_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMPLETED_DATE"].ToString()) + "\",");
               sw.WriteLine("      \"Adcode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADCODE"].ToString()) + "\",");
               sw.WriteLine("      \"Ucr_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["UCR_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["UCR_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Ucr_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["UCR_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["UCR_TYPE"].ToString()) + "\",");
               sw.WriteLine("      \"Payment_Method_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString()) + "\",");
               sw.WriteLine("      \"Preceding_Level\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString()) ? " " : dss.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString()) + "\",");
               sw.WriteLine("      \"Doc_Received_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["DOC_RECEIVED_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["DOC_RECEIVED_DATE"].ToString()) + "\",");
               sw.WriteLine("      \"Agent_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["AGENT_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["AGENT_NAME"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Addl_Load_Hss\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Misc_Load_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString()) + "\",");
               sw.WriteLine("      \"Gstn_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) + "\",");
               sw.WriteLine("      \"Gstn_Id\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GSTN_ID"].ToString()) ? " " : dss.Tables[0].Rows[0]["GSTN_ID"].ToString()) + "\",");
               sw.WriteLine("      \"Party_Ref_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PARTY_REF_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["PARTY_REF_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Eta\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ETA"].ToString()) ? " " : dss.Tables[0].Rows[0]["ETA"].ToString()) + "\",");
               sw.WriteLine("      \"Hss_Adcode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADCODE"].ToString()) + "\",");
               sw.WriteLine("      \"Ice_Id\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ICE_ID"].ToString()) ? " " : dss.Tables[0].Rows[0]["ICE_ID"].ToString()) + "\",");
               sw.WriteLine("      \"Cha_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CHA_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["CHA_NO"].ToString()) + "\"");
               sw.WriteLine("      }");
               sw.WriteLine("}");

               #endregion Json

           }

           System.Web.HttpContext.Current.Response.Write(sw.ToString());
           System.Web.HttpContext.Current.Response.Flush();
           //Response.Write(sw.ToString());
           //Response.Flush();
           // Response.End();
           HttpContext.Current.ApplicationInstance.CompleteRequest();

           //ViewState["JSON_filename"] = "Imp_" + txtInvoiceNo.Text + ".JSON";
           string folrder_path = errorFolder + "_" + Imp_exp + job_no + ".JSON";

           sw.Close();
           return Post_API_General_Details(Imp_exp, job_no, filePath);
       
   }
   public string Exp_JSON_General(DataSet dss, string job_no, string Imp_exp, string filetype)
   {
       StreamWriter sw;
       string errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + Connection.Company_License() + "/" + Imp_exp + "/" + filetype);

       if (!Directory.Exists(errorFolder))
       {
           Directory.CreateDirectory(errorFolder);
       }
       string filePath = Path.Combine(errorFolder, Imp_exp + "_" + job_no + ".JSON");

       if (File.Exists(filePath))
       {
           File.Delete(filePath);
       }
       sw = new StreamWriter(filePath, true);
       #region E_Json
       if (dss.Tables[0].Rows.Count > 0)
       {
           DataRow row = dss.Tables[0].Rows[0];
           sw.WriteLine("{");
           sw.WriteLine("  \"Company_Id\": \"" + Connection.Company_License() + "\",");
           sw.WriteLine("      \"Group_name\": \"" + Connection.Current_Group() + "\",");
           sw.WriteLine("      \"Wrk_prd\": \"" + Connection.WorkingPeriod() + "\",");
           sw.WriteLine("  \"JobDetails\": {");
           sw.WriteLine("    \"Job_No\": \"" + row["JOBNO"] + "\",");
           sw.WriteLine("    \"Job_Date\": \"" + (row["JOBDATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(row["JOBDATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
           sw.WriteLine("    \"Transport_Mode\": \"" + (string.IsNullOrEmpty(row["TRANSPORT_MODE"].ToString()) ? " " : row["TRANSPORT_MODE"].ToString()) + "\",");
           sw.WriteLine("    \"Customs_House\": \"" + (string.IsNullOrEmpty(row["CUSTOMS_HOUSE"].ToString()) ? " " : row["CUSTOMS_HOUSE"].ToString()) + "\",");
           sw.WriteLine("    \"Customs_House_Name\": \"" + (string.IsNullOrEmpty(row["CUSTOMS_HOUSE_NAME"].ToString()) ? " " : row["CUSTOMS_HOUSE_NAME"].ToString()) + "\",");
           sw.WriteLine("    \"Sb_Type\": \"" + (string.IsNullOrEmpty(row["SB_TYPE"].ToString()) ? " " : row["SB_TYPE"].ToString()) + "\",");
           sw.WriteLine("    \"Exporter_Name\": \"" + (string.IsNullOrEmpty(row["EXPORTER_NAME"].ToString()) ? " " : row["EXPORTER_NAME"].ToString()) + "\",");
           sw.WriteLine("    \"Branch_No\": \"" + (string.IsNullOrEmpty(row["BRANCH_NO"].ToString()) ? " " : row["BRANCH_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Iec_No\": \"" + (string.IsNullOrEmpty(row["IEC_NO"].ToString()) ? " " : row["IEC_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Address1\": \"" + (string.IsNullOrEmpty(row["ADDRESS1"].ToString()) ? " " : row["ADDRESS1"].ToString()) + "\",");
           sw.WriteLine("    \"Address2\": \"" + (string.IsNullOrEmpty(row["ADDRESS2"].ToString()) ? " " : row["ADDRESS2"].ToString()) + "\",");
           sw.WriteLine("    \"Address3\": \"" + (string.IsNullOrEmpty(row["ADDRESS3"].ToString()) ? " " : row["ADDRESS3"].ToString()) + "\",");
           sw.WriteLine("    \"Address4\": \"" + (string.IsNullOrEmpty(row["ADDRESS4"].ToString()) ? " " : row["ADDRESS4"].ToString()) + "\",");
           sw.WriteLine("    \"Address5\": \"" + (string.IsNullOrEmpty(row["ADDRESS5"].ToString()) ? " " : row["ADDRESS5"].ToString()) + "\",");
           sw.WriteLine("    \"Adcode\": \"" + (string.IsNullOrEmpty(row["ADCODE"].ToString()) ? " " : row["ADCODE"].ToString()) + "\",");
           sw.WriteLine("    \"Bank_Account\": \"" + (string.IsNullOrEmpty(row["BANK_ACCOUNT"].ToString()) ? " " : row["BANK_ACCOUNT"].ToString()) + "\",");
           sw.WriteLine("    \"Drawback_Account\": \"" + (string.IsNullOrEmpty(row["DRAWBACK_ACCOUNT"].ToString()) ? " " : row["DRAWBACK_ACCOUNT"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Name\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_NAME"].ToString()) ? " " : row["CONSIGNEE_NAME"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add1\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD1"].ToString()) ? " " : row["CONSIGNEE_ADD1"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add2\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD2"].ToString()) ? " " : row["CONSIGNEE_ADD2"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add3\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD3"].ToString()) ? " " : row["CONSIGNEE_ADD3"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add4\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD4"].ToString()) ? " " : row["CONSIGNEE_ADD4"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add5\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD5"].ToString()) ? " " : row["CONSIGNEE_ADD5"].ToString()) + "\",");
           sw.WriteLine("    \"Country_Discharge\": \"" + (string.IsNullOrEmpty(row["COUNTRY_DISCHARGE"].ToString()) ? " " : row["COUNTRY_DISCHARGE"].ToString()) + "\",");
           sw.WriteLine("    \"Port_Discharge\": \"" + (string.IsNullOrEmpty(row["PORT_DISCHARGE"].ToString()) ? " " : row["PORT_DISCHARGE"].ToString()) + "\",");
           sw.WriteLine("    \"Country_Final_Dest\": \"" + (string.IsNullOrEmpty(row["COUNTRY_FINAL_DEST"].ToString()) ? " " : row["COUNTRY_FINAL_DEST"].ToString()) + "\",");
           sw.WriteLine("    \"Port_Final_Dest\": \"" + (string.IsNullOrEmpty(row["PORT_FINAL_DEST"].ToString()) ? " " : row["PORT_FINAL_DEST"].ToString()) + "\",");
           sw.WriteLine("    \"State_Of_Export\": \"" + (string.IsNullOrEmpty(row["STATE_OF_EXPORT"].ToString()) ? " " : row["STATE_OF_EXPORT"].ToString()) + "\",");
           sw.WriteLine("    \"Nfei\": \"" + (string.IsNullOrEmpty(row["NFEI"].ToString()) ? " " : row["NFEI"].ToString()) + "\",");
           sw.WriteLine("    \"Nfei_Type\": \"" + (string.IsNullOrEmpty(row["NFEI_TYPE"].ToString()) ? " " : row["NFEI_TYPE"].ToString()) + "\",");
           sw.WriteLine("    \"Rbi_Waiver_No\": \"" + (string.IsNullOrEmpty(row["RBI_WAIVER_NO"].ToString()) ? " " : row["RBI_WAIVER_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Rbi_Waiver_Date\": \"" + (string.IsNullOrEmpty(row["RBI_WAIVER_DATE"].ToString()) ? " " : row["RBI_WAIVER_DATE"].ToString()) + "\",");
           sw.WriteLine("    \"Marks_No\": \"" + (string.IsNullOrEmpty(row["MARKS_NO"].ToString()) ? " " : row["MARKS_NO"].ToString()) + "\",");
           sw.WriteLine("    \"File_Ref_No\": \"" + (string.IsNullOrEmpty(row["FILE_REF_NO"].ToString()) ? " " : row["FILE_REF_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Type_Of_Exporter\": \"" + (string.IsNullOrEmpty(row["TYPE_OF_EXPORTER"].ToString()) ? " " : row["TYPE_OF_EXPORTER"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Branchslno\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_BRANCHSLNO"].ToString()) ? " " : row["CONSIGNEE_BRANCHSLNO"].ToString()) + "\",");
           sw.WriteLine("    \"Gstn_Type\": \"" + (string.IsNullOrEmpty(row["GSTN_TYPE"].ToString()) ? " " : row["GSTN_TYPE"].ToString()) + "\",");
           sw.WriteLine("    \"Gstn_Id\": \"" + (string.IsNullOrEmpty(row["GSTN_ID"].ToString()) ? " " : row["GSTN_ID"].ToString()) + "\",");
           sw.WriteLine("    \"Party_Ref_No\": \"" + (string.IsNullOrEmpty(row["PARTY_REF_NO"].ToString()) ? " " : row["PARTY_REF_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Ifsc_Code\": \"" + (string.IsNullOrEmpty(row["IFSC_CODE"].ToString()) ? " " : row["IFSC_CODE"].ToString()) + "\",");
           sw.WriteLine("    \"Port_Of_Loading\": \"" + (string.IsNullOrEmpty(row["PORT_OF_LOADING"].ToString()) ? " " : row["PORT_OF_LOADING"].ToString()) + "\"");
           sw.WriteLine("		 }");
           sw.WriteLine("}");
       }
       #endregion E_Json
       System.Web.HttpContext.Current.Response.Write(sw.ToString());
       System.Web.HttpContext.Current.Response.Flush();
       //Response.Write(sw.ToString());
       //Response.Flush();
       // Response.End();
       HttpContext.Current.ApplicationInstance.CompleteRequest();

       //ViewState["JSON_filename"] = "Imp_" + txtInvoiceNo.Text + ".JSON";
       string folrder_path = errorFolder + "_" + Imp_exp + job_no + ".JSON";

       sw.Close();
       return Post_API_General_Details(Imp_exp, job_no, filePath);
   }
   public string Exp_XML_Generate(DataSet dss, string job_no)
   {
       StringBuilder xmlContent = new StringBuilder();
       #region E_XML
       if (dss.Tables.Count > 0)
       {
           if (dss.Tables[0].Rows.Count > 0)
           {
               xmlContent.AppendLine("<JobDetails>");
               xmlContent.AppendLine("<Job_No>" + job_no + "</Job_No>");
               xmlContent.AppendLine("<Job_Date>" + (dss.Tables[0].Rows[0]["JOBDATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[0].Rows[0]["JOBDATE"].ToString()).ToString("dd-MMM-yyyy")) + "</Job_Date>");
               xmlContent.AppendLine("<Transport_Mode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString()) + "</Transport_Mode>");
               xmlContent.AppendLine("<Customs_House>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()) ? " " : dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()) + "</Customs_House>");
               xmlContent.AppendLine("<Customs_House_Name>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString()) + "</Customs_House_Name>");
               xmlContent.AppendLine("<Sb_Type>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SB_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["SB_TYPE"].ToString()) + "</Sb_Type>");
               xmlContent.AppendLine("<Exporter_Name>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()) + "</Exporter_Name>");
               xmlContent.AppendLine("<Branch_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()) + "</Branch_No>");
               xmlContent.AppendLine("<Iec_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["IEC_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["IEC_NO"].ToString()) + "</Iec_No>");
               xmlContent.AppendLine("<Address1>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS1"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS1"].ToString()) + "</Address1>");
               xmlContent.AppendLine("<Address2>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS2"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS2"].ToString()) + "</Address2>");
               xmlContent.AppendLine("<Address3>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS3"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS3"].ToString()) + "</Address3>");
               xmlContent.AppendLine("<Address4>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) + "</Address4>");
               xmlContent.AppendLine("<Address5>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS5"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS5"].ToString()) + "</Address5>");
               xmlContent.AppendLine("<Adcode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADCODE"].ToString()) + "</Adcode>");
               xmlContent.AppendLine("<Bank_Account>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString()) ? " " : dss.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString()) + "</Bank_Account>");
               xmlContent.AppendLine("<Drawback_Account>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString()) ? " " : dss.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString()) + "</Drawback_Account>");
               xmlContent.AppendLine("<Consignee_Name>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString()) + "</Consignee_Name>");
               xmlContent.AppendLine("<Consignee_Add1>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString()) + "</Consignee_Add1>");
               xmlContent.AppendLine("<Consignee_Add2>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString()) + "</Consignee_Add2>");
               xmlContent.AppendLine("<Consignee_Add3>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString()) + "</Consignee_Add3>");
               xmlContent.AppendLine("<Consignee_Add4>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString()) + "</Consignee_Add4>");
               xmlContent.AppendLine("<Consignee_Add5>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString()) + "</Consignee_Add5>");
               xmlContent.AppendLine("<Country_Discharge>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString()) + "</Country_Discharge>");
               xmlContent.AppendLine("<Port_Discharge>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString()) ? " " : dss.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString()) + "</Port_Discharge>");
               xmlContent.AppendLine("<Country_Final_Dest>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString()) ? " " : dss.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString()) + "</Country_Final_Dest>");
               xmlContent.AppendLine("<Port_Final_Dest>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString()) ? " " : dss.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString()) + "</Port_Final_Dest>");
               xmlContent.AppendLine("<State_Of_Export>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString()) ? " " : dss.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString()) + "</State_Of_Export>");
               xmlContent.AppendLine("<Nfei>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["NFEI"].ToString()) ? " " : dss.Tables[0].Rows[0]["NFEI"].ToString()) + "</Nfei>");
               xmlContent.AppendLine("<Nfei_Type>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["NFEI_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["NFEI_TYPE"].ToString()) + "</Nfei_Type>");
               xmlContent.AppendLine("<Rbi_Waiver_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString()) + "</Rbi_Waiver_No>");
               xmlContent.AppendLine("<Rbi_Waiver_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString()) + "</Rbi_Waiver_Date>");
               xmlContent.AppendLine("<Marks_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["MARKS_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["MARKS_NO"].ToString()) + "</Marks_No>");
               xmlContent.AppendLine("<File_Ref_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) + "</File_Ref_No>");
               xmlContent.AppendLine("<Type_Of_Exporter>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString()) ? " " : dss.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString()) + "</Type_Of_Exporter>");
               xmlContent.AppendLine("<Consignee_Branchslno>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString()) + "</Consignee_Branchslno>");
               xmlContent.AppendLine("<Gstn_Type>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) + "</Gstn_Type>");
               xmlContent.AppendLine("<Gstn_Id>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GSTN_ID"].ToString()) ? " " : dss.Tables[0].Rows[0]["GSTN_ID"].ToString()) + "</Gstn_Id>");
               xmlContent.AppendLine("<Party_Ref_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PARTY_REF_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["PARTY_REF_NO"].ToString()) + "</Party_Ref_No>");
               xmlContent.AppendLine("<Ifsc_Code>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["IFSC_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["IFSC_CODE"].ToString()) + "</Ifsc_Code>");
               xmlContent.AppendLine("<Port_Of_Loading>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString()) ? " " : dss.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString()) + "</Port_Of_Loading>");
           }

           if (dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() == "Air")
           {
               if (dss.Tables[1].Rows.Count > 0)
               {
                   xmlContent.AppendLine("<Annexur_Air_Details>");
                   xmlContent.AppendLine("<Annex_Air_Sealno>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_SEALNO"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_SEALNO"].ToString()) + "</Annex_Air_Sealno>");
                   xmlContent.AppendLine("<Annex_Air_Seal_Agency>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_SEAL_AGENCY"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_SEAL_AGENCY"].ToString()) + "</Annex_Air_Seal_Agency>");
                   xmlContent.AppendLine("<Annex_Air_Nature_Of_Cargo>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString()) ? " " : dss.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString()) + "</Annex_Air_Nature_Of_Cargo>");
                   xmlContent.AppendLine("<Annex_Air_Marks_Nos>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString()) + "</Annex_Air_Marks_Nos>");
                   xmlContent.AppendLine("<Annex_Air_Total_Packages>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString()) + "</Annex_Air_Total_Packages>");
                   xmlContent.AppendLine("<Annex_Air_Unit_Code>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString()) + "</Annex_Air_Unit_Code>");
                   xmlContent.AppendLine("<Annex_Air_Freight_Amt>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_FREIGHT_AMT"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_FREIGHT_AMT"].ToString()) + "</Annex_Air_Freight_Amt>");
                   xmlContent.AppendLine("<Annex_Air_Insurance_Amt>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_INSURANCE_AMT"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_INSURANCE_AMT"].ToString()) + "</Annex_Air_Insurance_Amt>");
                   xmlContent.AppendLine("<Annex_Air_Gross_Weight>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString()) + "</Annex_Air_Gross_Weight>");
                   xmlContent.AppendLine("<Annex_Air_Gr_Unit_Code>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString()) + "</Annex_Air_Gr_Unit_Code>");
                   xmlContent.AppendLine("<Annex_Air_Net_Weight>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString()) + "</Annex_Air_Net_Weight>");
                   xmlContent.AppendLine("<Annex_Air_Mawb_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString()) + "</Annex_Air_Mawb_No>");
                   xmlContent.AppendLine("<Annex_Air_Hawb_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString()) + "</Annex_Air_Hawb_No>");
                   xmlContent.AppendLine("<Annex_Air_Mawb_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) + "</Annex_Air_Mawb_Date>");
                   xmlContent.AppendLine("<Annex_Air_Hawb_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_HAWB_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_HAWB_DATE"].ToString()) + "</Annex_Air_Hawb_Date>");
                   xmlContent.AppendLine("<Annex_Air_Total_Packages_Mawb>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES_MAWB"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES_MAWB"].ToString()) + "</Annex_Air_Total_Packages_Mawb>");
                   xmlContent.AppendLine("<Annex_Air_Rotation_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString()) + "</Annex_Air_Rotation_No>");
                   xmlContent.AppendLine("<Annex_Air_Rotation_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString()) + "</Annex_Air_Rotation_Date>");
                   xmlContent.AppendLine("<Annex_Air_Fob_Value>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_AIR_FOB_VALUE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_AIR_FOB_VALUE"].ToString()) + "</Annex_Air_Fob_Value>");
                   xmlContent.AppendLine("</Annexur_Air_Details>");

               }
               else
               {
                   xmlContent.AppendLine("<Annexur_Air_Details>");
                   xmlContent.AppendLine("<Annex_Air_Sealno>" + " " + "</Annex_Air_Sealno>");
                   xmlContent.AppendLine("<Annex_Air_Seal_Agency>" + " " + "</Annex_Air_Seal_Agency>");
                   xmlContent.AppendLine("<Annex_Air_Nature_Of_Cargo>" + " " + "</Annex_Air_Nature_Of_Cargo>");
                   xmlContent.AppendLine("<Annex_Air_Marks_Nos>" + " " + "</Annex_Air_Marks_Nos>");
                   xmlContent.AppendLine("<Annex_Air_Total_Packages>" + " " + "</Annex_Air_Total_Packages>");
                   xmlContent.AppendLine("<Annex_Air_Unit_Code>" + " " + "</Annex_Air_Unit_Code>");
                   xmlContent.AppendLine("<Annex_Air_Freight_Amt>" + " " + "</Annex_Air_Freight_Amt>");
                   xmlContent.AppendLine("<Annex_Air_Insurance_Amt>" + " " + "</Annex_Air_Insurance_Amt>");
                   xmlContent.AppendLine("<Annex_Air_Gross_Weight>" + " " + "</Annex_Air_Gross_Weight>");
                   xmlContent.AppendLine("<Annex_Air_Gr_Unit_Code>" + " " + "</Annex_Air_Gr_Unit_Code>");
                   xmlContent.AppendLine("<Annex_Air_Net_Weight>" + " " + "</Annex_Air_Net_Weight>");
                   xmlContent.AppendLine("<Annex_Air_Mawb_No>" + " " + "</Annex_Air_Mawb_No>");
                   xmlContent.AppendLine("<Annex_Air_Hawb_No>" + " " + "</Annex_Air_Hawb_No>");
                   xmlContent.AppendLine("<Annex_Air_Mawb_Date>" + " " + "</Annex_Air_Mawb_Date>");
                   xmlContent.AppendLine("<Annex_Air_Hawb_Date>" + " " + "</Annex_Air_Hawb_Date>");
                   xmlContent.AppendLine("<Annex_Air_Total_Packages_Mawb>" + " " + "</Annex_Air_Total_Packages_Mawb>");
                   xmlContent.AppendLine("<Annex_Air_Rotation_No>" + " " + "</Annex_Air_Rotation_No>");
                   xmlContent.AppendLine("<Annex_Air_Rotation_Date>" + " " + "</Annex_Air_Rotation_Date>");
                   xmlContent.AppendLine("<Annex_Air_Fob_Value>" + " " + "</Annex_Air_Fob_Value>");
                   xmlContent.AppendLine("</Annexur_Air_Details>");


               }
           }
           else
           {
               if (dss.Tables[1].Rows.Count > 0)
               {
                   xmlContent.AppendLine("<Annexure_Sea_Details>");
                   xmlContent.AppendLine("<Annex_Sea_Fac_Stuffed>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString()) + "</Annex_Sea_Fac_Stuffed>");
                   xmlContent.AppendLine("<Annex_Sea_Sample_Accom>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString()) + "</Annex_Sea_Sample_Accom>");
                   xmlContent.AppendLine("<Annex_Sea_Nature_Of_Cargo>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString()) ? " " : dss.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString()) + "</Annex_Sea_Nature_Of_Cargo>");
                   xmlContent.AppendLine("<Annex_Sea_Marks_Nos>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString()) + "</Annex_Sea_Marks_Nos>");
                   xmlContent.AppendLine("<Annex_Sea_Total_Packages>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString()) + "</Annex_Sea_Total_Packages>");
                   xmlContent.AppendLine("<Annex_Sea_Loose_Packets>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString()) + "</Annex_Sea_Loose_Packets>");
                   xmlContent.AppendLine("<Annex_Sea_No_Containers>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString()) + "</Annex_Sea_No_Containers>");
                   xmlContent.AppendLine("<Annex_Sea_Gross_Weight>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString()) + "</Annex_Sea_Gross_Weight>");
                   xmlContent.AppendLine("<Annex_Sea_Net_Weight>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString()) + "</Annex_Sea_Net_Weight>");
                   xmlContent.AppendLine("<Annex_Sea_Unit_Measurement>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString()) + "</Annex_Sea_Unit_Measurement>");
                   xmlContent.AppendLine("<Annex_Sea_Rotation_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString()) + "</Annex_Sea_Rotation_No>");
                   xmlContent.AppendLine("<Annex_Sea_Rotation_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString()) + "</Annex_Sea_Rotation_Date>");
                   xmlContent.AppendLine("<Annex_Sea_Fob_Value>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_FOB_VALUE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_FOB_VALUE"].ToString()) + "</Annex_Sea_Fob_Value>");
                   xmlContent.AppendLine("<Annex_Sea_Seal_Type>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString()) + "</Annex_Sea_Seal_Type>");
                   xmlContent.AppendLine("<Annex_Sea_Factory_Add>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_FACTORY_ADD"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_FACTORY_ADD"].ToString()) + "</Annex_Sea_Factory_Add>");
                   xmlContent.AppendLine("<Annex_Sea_Voyageno>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_VOYAGENO"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_VOYAGENO"].ToString()) + "</Annex_Sea_Voyageno>");
                   xmlContent.AppendLine("<Annex_Sea_Vesselno>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_VESSELNO"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_VESSELNO"].ToString()) + "</Annex_Sea_Vesselno>");
                   xmlContent.AppendLine("<Annex_Sea_Vessel_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_VESSEL_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_VESSEL_DATE"].ToString()) + "</Annex_Sea_Vessel_Date>");
                   xmlContent.AppendLine("<Annex_Sea_Pkg_Unit_Code>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ANNEX_SEA_PKG_UNIT_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ANNEX_SEA_PKG_UNIT_CODE"].ToString()) + "</Annex_Sea_Pkg_Unit_Code>");
                   xmlContent.AppendLine("</Annexure_Sea_Details>");

               }
               else
               {

                   xmlContent.AppendLine("<Annexure_Sea_Details>");
                   xmlContent.AppendLine("<Annex_Sea_Fac_Stuffed>" + " " + "</Annex_Sea_Fac_Stuffed>");
                   xmlContent.AppendLine("<Annex_Sea_Sample_Accom>" + " " + "</Annex_Sea_Sample_Accom>");
                   xmlContent.AppendLine("<Annex_Sea_Nature_Of_Cargo>" + " " + "</Annex_Sea_Nature_Of_Cargo>");
                   xmlContent.AppendLine("<Annex_Sea_Marks_Nos>" + " " + "</Annex_Sea_Marks_Nos>");
                   xmlContent.AppendLine("<Annex_Sea_Total_Packages>" + " " + "</Annex_Sea_Total_Packages>");
                   xmlContent.AppendLine("<Annex_Sea_Loose_Packets>" + " " + "</Annex_Sea_Loose_Packets>");
                   xmlContent.AppendLine("<Annex_Sea_No_Containers>" + " " + "</Annex_Sea_No_Containers>");
                   xmlContent.AppendLine("<Annex_Sea_Gross_Weight>" + " " + "</Annex_Sea_Gross_Weight>");
                   xmlContent.AppendLine("<Annex_Sea_Net_Weight>" + " " + "</Annex_Sea_Net_Weight>");
                   xmlContent.AppendLine("<Annex_Sea_Unit_Measurement>" + " " + "</Annex_Sea_Unit_Measurement>");
                   xmlContent.AppendLine("<Annex_Sea_Rotation_No>" + " " + "</Annex_Sea_Rotation_No>");
                   xmlContent.AppendLine("<Annex_Sea_Rotation_Date>" + " " + "</Annex_Sea_Rotation_Date>");
                   xmlContent.AppendLine("<Annex_Sea_Fob_Value>" + " " + "</Annex_Sea_Fob_Value>");
                   xmlContent.AppendLine("<Annex_Sea_Seal_Type>" + " " + "</Annex_Sea_Seal_Type>");
                   xmlContent.AppendLine("<Annex_Sea_Factory_Add>" + " " + "</Annex_Sea_Factory_Add>");
                   xmlContent.AppendLine("<Annex_Sea_Voyageno>" + " " + "</Annex_Sea_Voyageno>");
                   xmlContent.AppendLine("<Annex_Sea_Vesselno>" + " " + "</Annex_Sea_Vesselno>");
                   xmlContent.AppendLine("<Annex_Sea_Vessel_Date>" + " " + "</Annex_Sea_Vessel_Date>");
                   xmlContent.AppendLine("<Annex_Sea_Pkg_Unit_Code>" + " " + "</Annex_Sea_Pkg_Unit_Code>");
                   xmlContent.AppendLine("</Annexure_Sea_Details>");

               }
           }

           if (dss.Tables[2].Rows.Count > 0)
           {
               xmlContent.AppendLine("<Annexure_Container_Details>");
               for (int con = 0; con < dss.Tables[2].Rows.Count; con++)
               {
                   xmlContent.AppendLine("<Annex_Sea_Con_Containerno>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_CONTAINERNO"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_CONTAINERNO"].ToString()) + "</Annex_Sea_Con_Containerno>");
                   xmlContent.AppendLine("<Annex_Sea_Con_Size>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SIZE"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SIZE"].ToString()) + "</Annex_Sea_Con_Size>");
                   xmlContent.AppendLine("<Annex_Sea_Con_Type>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_TYPE"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_TYPE"].ToString()) + "</Annex_Sea_Con_Type>");
                   xmlContent.AppendLine("<Annex_Sea_Con_Excise_Sealno>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString()) + "</Annex_Sea_Con_Excise_Sealno>");
                   xmlContent.AppendLine("<Annex_Sea_Con_Seal_Date>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEAL_DATE"].ToString()) ? " " : DateTime.Parse(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEAL_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "</Annex_Sea_Con_Seal_Date>");
                   xmlContent.AppendLine("<Annex_Sea_Con_Sealtype_Indicator>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString()) + "</Annex_Sea_Con_Sealtype_Indicator>");
                   xmlContent.AppendLine("<Annex_Sea_Con_Seal_Deviceid>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEAL_DEVICEID"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEAL_DEVICEID"].ToString()) + "</Annex_Sea_Con_Seal_Deviceid>");
                   xmlContent.AppendLine("<Annex_Sea_Con_Doc_Type>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_DOC_TYPE"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_DOC_TYPE"].ToString()) + "</Annex_Sea_Con_Doc_Type>");
                   xmlContent.AppendLine("<Annex_Sea_Con_Doc_Number>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_DOC_NUMBER"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_DOC_NUMBER"].ToString()) + "</Annex_Sea_Con_Doc_Number>");

               }

               xmlContent.AppendLine("</Annexure_Container_Details>");
           }
           else
           {
               xmlContent.AppendLine("<Annexure_Container_Detail>");
               xmlContent.AppendLine("<Annex_Sea_Con_Containerno>" + " " + "</Annex_Sea_Con_Containerno>");
               xmlContent.AppendLine("<Annex_Sea_Con_Size>" + " " + "</Annex_Sea_Con_Size>");
               xmlContent.AppendLine("<Annex_Sea_Con_Type>" + " " + "</Annex_Sea_Con_Type>");
               xmlContent.AppendLine("<Annex_Sea_Con_Excise_Sealno>" + " " + "</Annex_Sea_Con_Excise_Sealno>");
               xmlContent.AppendLine("<Annex_Sea_Con_Seal_Date>" + " " + "</Annex_Sea_Con_Seal_Date>");
               xmlContent.AppendLine("<Annex_Sea_Con_Sealtype_Indicator>" + " " + "</Annex_Sea_Con_Sealtype_Indicator>");
               xmlContent.AppendLine("<Annex_Sea_Con_Seal_Deviceid>" + " " + "</Annex_Sea_Con_Seal_Deviceid>");
               xmlContent.AppendLine("<Annex_Sea_Con_Doc_Type>" + " " + "</Annex_Sea_Con_Doc_Type>");
               xmlContent.AppendLine("<Annex_Sea_Con_Doc_Number>" + " " + "</Annex_Sea_Con_Doc_Number>");
               xmlContent.AppendLine("</Annexure_Container_Detail>");

           }

           if (dss.Tables[3].Rows.Count > 0)
           {
               xmlContent.AppendLine("<Annexure_Package_Details>");
               for (int pck = 0; pck < dss.Tables[3].Rows.Count; pck++)
               {
                   xmlContent.AppendLine("<Annex_Sea_Pack_Group>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_GROUP"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_GROUP"].ToString()) + "</Annex_Sea_Pack_Group>");
                   xmlContent.AppendLine("<Annex_Sea_Pack_From>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_FROM"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_FROM"].ToString()) + "</Annex_Sea_Pack_From>");
                   xmlContent.AppendLine("<Annex_Sea_Pack_To>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_TO"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_TO"].ToString()) + "</Annex_Sea_Pack_To>");
                   xmlContent.AppendLine("<Annex_Sea_Pack_Packagetype>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString()) + "</Annex_Sea_Pack_Packagetype>");
                   xmlContent.AppendLine("<Annex_Sea_Pack_Fromdesc>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_FROMDESC"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_FROMDESC"].ToString()) + "</Annex_Sea_Pack_Fromdesc>");
                   xmlContent.AppendLine("<Annex_Sea_Pack_Todesc>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_TODESC"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_TODESC"].ToString()) + "</Annex_Sea_Pack_Todesc>");
               }
               xmlContent.AppendLine("</Annexure_Package_Details>");
           }
           else
           {
               xmlContent.AppendLine("<Annexure_Package_Detail>");
               xmlContent.AppendLine("<Annex_Sea_Pack_Group>" + " " + "</Annex_Sea_Pack_Group>");
               xmlContent.AppendLine("<Annex_Sea_Pack_From>" + " " + "</Annex_Sea_Pack_From>");
               xmlContent.AppendLine("<Annex_Sea_Pack_To>" + " " + "</Annex_Sea_Pack_To>");
               xmlContent.AppendLine("<Annex_Sea_Pack_Packagetype>" + " " + "</Annex_Sea_Pack_Packagetype>");
               xmlContent.AppendLine("<Annex_Sea_Pack_Fromdesc>" + " " + "</Annex_Sea_Pack_Fromdesc>");
               xmlContent.AppendLine("<Annex_Sea_Pack_Todesc>" + " " + "</Annex_Sea_Pack_Todesc>");
               xmlContent.AppendLine("</Annexure_Package_Detail>");
           }

           if (dss.Tables[4].Rows.Count > 0)
           {
               xmlContent.AppendLine("<Invoice_Details>");

               for (int inv = 0; inv < dss.Tables[4].Rows.Count; inv++)
               {
                   xmlContent.AppendLine("<Invoice_Detail>");
                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_SLNO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                   xmlContent.AppendLine("<Invoice_No>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_NO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INVOICE_NO"].ToString()) + "</Invoice_No>");
                   xmlContent.AppendLine("<Invoice_Date>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_DATE"].ToString()) ? " " : (DateTime.Parse(dss.Tables[4].Rows[inv]["INVOICE_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Invoice_Date>");
                   xmlContent.AppendLine("<Payment_Method>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PAYMENT_METHOD"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PAYMENT_METHOD"].ToString()) + "</Payment_Method>");
                   xmlContent.AppendLine("<Period_Payment>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PERIOD_PAYMENT"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PERIOD_PAYMENT"].ToString()) + "</Period_Payment>");
                   xmlContent.AppendLine("<Invoice_Value>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_VALUE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INVOICE_VALUE"].ToString()) + "</Invoice_Value>");
                   xmlContent.AppendLine("<Invoice_Currency>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INVOICE_CURRENCY"].ToString()) + "</Invoice_Currency>");
                   xmlContent.AppendLine("<Exchange_Rate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["EXCHANGE_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["EXCHANGE_RATE"].ToString()) + "</Exchange_Rate>");
                   xmlContent.AppendLine("<Contract_No>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["CONTRACT_NO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["CONTRACT_NO"].ToString()) + "</Contract_No>");
                   xmlContent.AppendLine("<Terms>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["TERMS"].ToString()) ? " " : dss.Tables[4].Rows[inv]["TERMS"].ToString()) + "</Terms>");
                   xmlContent.AppendLine("<Buyer>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER"].ToString()) + "</Buyer>");
                   xmlContent.AppendLine("<Buyer_Name>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_NAME"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_NAME"].ToString()) + "</Buyer_Name>");
                   xmlContent.AppendLine("<Buyer_Address>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS"].ToString()) + "</Buyer_Address>");
                   xmlContent.AppendLine("<Buyer_Address1>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS1"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS1"].ToString()) + "</Buyer_Address1>");
                   xmlContent.AppendLine("<Buyer_Address2>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS2"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS2"].ToString()) + "</Buyer_Address2>");
                   xmlContent.AppendLine("<Buyer_Address3>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS3"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS3"].ToString()) + "</Buyer_Address3>");
                   xmlContent.AppendLine("<Buyer_Address4>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS4"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS4"].ToString()) + "</Buyer_Address4>");
                   xmlContent.AppendLine("<Commission_Rate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["COMMISSION_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["COMMISSION_RATE"].ToString()) + "</Commission_Rate>");
                   xmlContent.AppendLine("<Commission_Charges>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["COMMISSION_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["COMMISSION_CHARGES"].ToString()) + "</Commission_Charges>");
                   xmlContent.AppendLine("<Commission_Currency>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["COMMISSION_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["COMMISSION_CURRENCY"].ToString()) + "</Commission_Currency>");
                   xmlContent.AppendLine("<Fob_Rate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FOB_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FOB_RATE"].ToString()) + "</Fob_Rate>");
                   xmlContent.AppendLine("<Fob_Charges>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FOB_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FOB_CHARGES"].ToString()) + "</Fob_Charges>");
                   xmlContent.AppendLine("<Fob_Currency>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FOB_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FOB_CURRENCY"].ToString()) + "</Fob_Currency>");
                   xmlContent.AppendLine("<Packmisc_Rate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PACKMISC_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PACKMISC_RATE"].ToString()) + "</Packmisc_Rate>");
                   xmlContent.AppendLine("<Packmisc_Charges>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PACKMISC_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PACKMISC_CHARGES"].ToString()) + "</Packmisc_Charges>");
                   xmlContent.AppendLine("<Packmisc_Currency>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PACKMISC_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PACKMISC_CURRENCY"].ToString()) + "</Packmisc_Currency>");
                   xmlContent.AppendLine("<Other_Deduction_Rate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_RATE"].ToString()) + "</Other_Deduction_Rate>");
                   xmlContent.AppendLine("<Other_Deduction_Charges>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_CHARGES"].ToString()) + "</Other_Deduction_Charges>");
                   xmlContent.AppendLine("<Other_Deduction_Currency>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_CURRENCY"].ToString()) + "</Other_Deduction_Currency>");
                   xmlContent.AppendLine("<Freight_Rate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FREIGHT_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FREIGHT_RATE"].ToString()) + "</Freight_Rate>");
                   xmlContent.AppendLine("<Freight_Charges>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FREIGHT_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FREIGHT_CHARGES"].ToString()) + "</Freight_Charges>");
                   xmlContent.AppendLine("<Freight_Currency>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FREIGHT_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FREIGHT_CURRENCY"].ToString()) + "</Freight_Currency>");
                   xmlContent.AppendLine("<Freight_Exrate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FREIGHT_EXRATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FREIGHT_EXRATE"].ToString()) + "</Freight_Exrate>");
                   xmlContent.AppendLine("<Insurance_Rate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INSURANCE_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INSURANCE_RATE"].ToString()) + "</Insurance_Rate>");
                   xmlContent.AppendLine("<Insurance_Charges>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INSURANCE_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INSURANCE_CHARGES"].ToString()) + "</Insurance_Charges>");
                   xmlContent.AppendLine("<Insurance_Currency>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INSURANCE_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INSURANCE_CURRENCY"].ToString()) + "</Insurance_Currency>");
                   xmlContent.AppendLine("<Insurance_Exrate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INSURANCE_EXRATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INSURANCE_EXRATE"].ToString()) + "</Insurance_Exrate>");
                   xmlContent.AppendLine("<Wheather_Unit_Price>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["WHEATHER_UNIT_PRICE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["WHEATHER_UNIT_PRICE"].ToString()) + "</Wheather_Unit_Price>");
                   xmlContent.AppendLine("<Non_Std_Effect_Dt_Exp>" + (dss.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString()).ToString("dd-MMM-yyyy")) + "</Non_Std_Effect_Dt_Exp>");
                   xmlContent.AppendLine("<Non_Std_Bankname>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["NON_STD_BANKNAME"].ToString()) ? " " : dss.Tables[4].Rows[inv]["NON_STD_BANKNAME"].ToString()) + "</Non_Std_Bankname>");
                   xmlContent.AppendLine("<Non_Std_Certificate_No>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) + "</Non_Std_Certificate_No>");
                   xmlContent.AppendLine("<Non_Std_Certificate_Date>" + (dss.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "</Non_Std_Certificate_Date>");
                   xmlContent.AppendLine("<Terms_Place>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["TERMS_PLACE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["TERMS_PLACE"].ToString()) + "</Terms_Place>");
                   xmlContent.AppendLine("<Thirdparty_Name>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["THIRDPARTY_NAME"].ToString()) ? " " : dss.Tables[4].Rows[inv]["THIRDPARTY_NAME"].ToString()) + "</Thirdparty_Name>");
                   xmlContent.AppendLine("<Thirdparty_Add1>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["THIRDPARTY_ADD1"].ToString()) ? " " : dss.Tables[4].Rows[inv]["THIRDPARTY_ADD1"].ToString()) + "</Thirdparty_Add1>");
                   xmlContent.AppendLine("<Thirdparty_Add2>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["THIRDPARTY_ADD2"].ToString()) ? " " : dss.Tables[4].Rows[inv]["THIRDPARTY_ADD2"].ToString()) + "</Thirdparty_Add2>");
                   xmlContent.AppendLine("<Thirdparty_City>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["THIRDPARTY_CITY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["THIRDPARTY_CITY"].ToString()) + "</Thirdparty_City>");
                   xmlContent.AppendLine("<T_Party_Country_Sub_Div>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) ? " " : dss.Tables[4].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) + "</T_Party_Country_Sub_Div>");
                   xmlContent.AppendLine("<T_Party_Country_Code>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) + "</T_Party_Country_Code>");
                   xmlContent.AppendLine("<T_Party_Pin>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["T_PARTY_PIN"].ToString()) ? " " : dss.Tables[4].Rows[inv]["T_PARTY_PIN"].ToString()) + "</T_Party_Pin>");
                   xmlContent.AppendLine("<Authorized_Economic_Operator_Code>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) + "</Authorized_Economic_Operator_Code>");
                   xmlContent.AppendLine("<A_E_O_Country>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["A_E_O_COUNTRY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["A_E_O_COUNTRY"].ToString()) + "</A_E_O_Country>");
                   xmlContent.AppendLine("<Authorized_Economic_Operator>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) + "</Authorized_Economic_Operator>");
                   xmlContent.AppendLine("<Doc_Recd_Date>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["DOC_RECD_DATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["DOC_RECD_DATE"].ToString()) + "</Doc_Recd_Date>");
                   xmlContent.AppendLine("<Inv_Created_Date>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["DATE_TIME"].ToString()) ? " " : (DateTime.Parse(dss.Tables[4].Rows[inv]["DATE_TIME"].ToString()).ToString("dd-MMM-yyyy"))) + "</Inv_Created_Date>");
            
                   if (dss.Tables[5].Rows.Count > 0)
                   {
                       xmlContent.AppendLine("<AR4_Details>");
                       for (int Ar4 = 0; Ar4 < dss.Tables[5].Rows.Count; Ar4++)  // loop start 
                       {
                           xmlContent.AppendLine("<Ar4_No>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_NO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_NO"].ToString()) + "</Ar4_No>");
                           xmlContent.AppendLine("<Ar4_Date>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_DATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_DATE"].ToString()) + "</Ar4_Date>");
                           xmlContent.AppendLine("<Ar4_Commission_Rate>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_COMMISSION_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_COMMISSION_RATE"].ToString()) + "</Ar4_Commission_Rate>");
                           xmlContent.AppendLine("<Ar4_Division>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_DIVISION"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_DIVISION"].ToString()) + "</Ar4_Division>");
                           xmlContent.AppendLine("<Ar4_Range>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_RANGE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_RANGE"].ToString()) + "</Ar4_Range>");
                           xmlContent.AppendLine("<Ar4_Remarks>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_REMARKS"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_REMARKS"].ToString()) + "</Ar4_Remarks>");
                           xmlContent.AppendLine("<Ar4_Invoice_No>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_INVOICE_NO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_INVOICE_NO"].ToString()) + "</Ar4_Invoice_No>");
                           xmlContent.AppendLine("<Ar4_Invoice_Slno>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_INVOICE_SLNO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_INVOICE_SLNO"].ToString()) + "</Ar4_Invoice_Slno>");
                           xmlContent.AppendLine("<Ar4_Run_Id>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_RUN_ID"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_RUN_ID"].ToString()) + "</Ar4_Run_Id>");
                           xmlContent.AppendLine("<Ar4_Item_No>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AR4_ITEM_NO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AR4_ITEM_NO"].ToString()) + "</Ar4_Item_No>");

                       }
                       xmlContent.AppendLine("</AR4_Details>");
                   }
                   else
                   {
                       xmlContent.AppendLine("<AR4_Detail>");
                       xmlContent.AppendLine("<Ar4_No>" + " " + "</Ar4_No>");
                       xmlContent.AppendLine("<Ar4_Date>" + " " + "</Ar4_Date>");
                       xmlContent.AppendLine("<Ar4_Commission_Rate>" + " " + "</Ar4_Commission_Rate>");
                       xmlContent.AppendLine("<Ar4_Division>" + " " + "</Ar4_Division>");
                       xmlContent.AppendLine("<Ar4_Range>" + " " + "</Ar4_Range>");
                       xmlContent.AppendLine("<Ar4_Remarks>" + " " + "</Ar4_Remarks>");
                       xmlContent.AppendLine("<Ar4_Invoice_No>" + " " + "</Ar4_Invoice_No>");
                       xmlContent.AppendLine("<Ar4_Invoice_Slno>" + " " + "</Ar4_Invoice_Slno>");
                       xmlContent.AppendLine("<Ar4_Run_Id>" + " " + "</Ar4_Run_Id>");
                       xmlContent.AppendLine("<Ar4_Item_No>" + " " + "</Ar4_Item_No>");
                       xmlContent.AppendLine("</AR4_Detail>");
                   }

                   DataTable Ex_item_tbl = new DataTable();
                   Ex_item_tbl = dss.Tables[6];
                   DataView Ex_Item_view = Ex_item_tbl.DefaultView;
                   string a = dss.Tables[4].Rows[inv]["INVOICE_SLNO"].ToString();
                   Ex_Item_view.RowFilter = "INVOICE_SLNO = '" + a + "'";
                   DataTable Ex_items = Ex_Item_view.ToTable();

                   if (Ex_items.Rows.Count > 0)
                   {

                       xmlContent.AppendLine("<Item_details>");

                       for (int itm = 0; itm < Ex_items.Rows.Count; itm++)  // loop start 
                       {

                           xmlContent.AppendLine("<Item_detail>");
                           xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["INVOICE_SLNO"].ToString()) ? " " : Ex_items.Rows[itm]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                           xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_SLNO"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                           xmlContent.AppendLine("<Item_Description>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_DESCRIPTION"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_DESCRIPTION"].ToString()) + "</Item_Description>");
                           xmlContent.AppendLine("<Ritcno>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["RITCNO"].ToString()) ? " " : Ex_items.Rows[itm]["RITCNO"].ToString()) + "</Ritcno>");
                           xmlContent.AppendLine("<Item_Qty>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_QTY"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_QTY"].ToString()) + "</Item_Qty>");
                           xmlContent.AppendLine("<Item_Qty_Code>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_QTY_CODE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_QTY_CODE"].ToString()) + "</Item_Qty_Code>");
                           xmlContent.AppendLine("<Item_Unit_Price>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_UNIT_PRICE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_UNIT_PRICE"].ToString()) + "</Item_Unit_Price>");
                           xmlContent.AppendLine("<Item_Per>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_PER"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_PER"].ToString()) + "</Item_Per>");
                           xmlContent.AppendLine("<Item_Amount>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_AMOUNT"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_AMOUNT"].ToString()) + "</Item_Amount>");
                           xmlContent.AppendLine("<Item_Pmvvalue>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_PMVVALUE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_PMVVALUE"].ToString()) + "</Item_Pmvvalue>");
                           xmlContent.AppendLine("<Item_Scheme_Code>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_SCHEME_CODE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_SCHEME_CODE"].ToString()) + "</Item_Scheme_Code>");
                           xmlContent.AppendLine("<Item_Accessories_Desc>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_ACCESSORIES_DESC"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_ACCESSORIES_DESC"].ToString()) + "</Item_Accessories_Desc>");
                           xmlContent.AppendLine("<Item_Ar4_No>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_AR4_NO"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_AR4_NO"].ToString()) + "</Item_Ar4_No>");
                           xmlContent.AppendLine("<Item_Ar4_Date>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_AR4_DATE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_AR4_DATE"].ToString()) + "</Item_Ar4_Date>");
                           xmlContent.AppendLine("<Item_Commission_Rate>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_COMMISSION_RATE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_COMMISSION_RATE"].ToString()) + "</Item_Commission_Rate>");
                           xmlContent.AppendLine("<Item_Division>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_DIVISION"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_DIVISION"].ToString()) + "</Item_Division>");
                           xmlContent.AppendLine("<Item_Range>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_RANGE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_RANGE"].ToString()) + "</Item_Range>");
                           xmlContent.AppendLine("<Item_Remarks>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_REMARKS"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_REMARKS"].ToString()) + "</Item_Remarks>");
                           xmlContent.AppendLine("<Item_Ieccode>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_IECCODE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_IECCODE"].ToString()) + "</Item_Ieccode>");
                           xmlContent.AppendLine("<Item_Exporter_Name>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_EXPORTER_NAME"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_EXPORTER_NAME"].ToString()) + "</Item_Exporter_Name>");
                           xmlContent.AppendLine("<Br_Slno>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["BR_SLNO"].ToString()) ? " " : Ex_items.Rows[itm]["BR_SLNO"].ToString()) + "</Br_Slno>");
                           xmlContent.AppendLine("<Address1>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS1"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS1"].ToString()) + "</Address1>");
                           xmlContent.AppendLine("<Address2>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS2"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS2"].ToString()) + "</Address2>");
                           xmlContent.AppendLine("<Address3>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS3"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS3"].ToString()) + "</Address3>");
                           xmlContent.AppendLine("<Address4>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS4"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS4"].ToString()) + "</Address4>");
                           xmlContent.AppendLine("<Address5>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS5"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS5"].ToString()) + "</Address5>");
                           xmlContent.AppendLine("<Item_Str_Code>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_STR_CODE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_STR_CODE"].ToString()) + "</Item_Str_Code>");
                           xmlContent.AppendLine("<Reward_Points>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["REWARD_POINTS"].ToString()) ? " " : Ex_items.Rows[itm]["REWARD_POINTS"].ToString()) + "</Reward_Points>");
                           xmlContent.AppendLine("<Pmv_Value>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["PMV_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["PMV_VALUE"].ToString()) + "</Pmv_Value>");
                           xmlContent.AppendLine("<Fob_Value>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["FOB_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["FOB_VALUE"].ToString()) + "</Fob_Value>");
                           xmlContent.AppendLine("<Drawback_Value>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["DRAWBACK_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["DRAWBACK_VALUE"].ToString()) + "</Drawback_Value>");
                           xmlContent.AppendLine("<Cess_Yn>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["CESS_YN"].ToString()) ? " " : Ex_items.Rows[itm]["CESS_YN"].ToString()) + "</Cess_Yn>");
                           xmlContent.AppendLine("<Str_Rate>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["STR_RATE"].ToString()) ? " " : Ex_items.Rows[itm]["STR_RATE"].ToString()) + "</Str_Rate>");
                           xmlContent.AppendLine("<Str_Amount>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["STR_AMOUNT"].ToString()) ? " " : Ex_items.Rows[itm]["STR_AMOUNT"].ToString()) + "</Str_Amount>");
                           xmlContent.AppendLine("<Manufacturer_Producer>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) ? " " : Ex_items.Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) + "</Manufacturer_Producer>");
                           xmlContent.AppendLine("<M_P_Grower_Code>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_CODE"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_CODE"].ToString()) + "</M_P_Grower_Code>");
                           xmlContent.AppendLine("<M_P_Grower_Add1>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_ADD1"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_ADD1"].ToString()) + "</M_P_Grower_Add1>");
                           xmlContent.AppendLine("<M_P_Grower_Add2>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_ADD2"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_ADD2"].ToString()) + "</M_P_Grower_Add2>");
                           xmlContent.AppendLine("<M_P_Grower_City>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_CITY"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_CITY"].ToString()) + "</M_P_Grower_City>");
                           xmlContent.AppendLine("<M_P_Grower_Country_Subdiv>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) + "</M_P_Grower_Country_Subdiv>");
                           xmlContent.AppendLine("<M_P_Grower_Pin>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_PIN"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_PIN"].ToString()) + "</M_P_Grower_Pin>");
                           xmlContent.AppendLine("<M_P_Grower_Country>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_COUNTRY"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_COUNTRY"].ToString()) + "</M_P_Grower_Country>");
                           xmlContent.AppendLine("<Source_State>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["SOURCE_STATE"].ToString()) ? " " : Ex_items.Rows[itm]["SOURCE_STATE"].ToString()) + "</Source_State>");
                           xmlContent.AppendLine("<Transit_Country>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["TRANSIT_COUNTRY"].ToString()) ? " " : Ex_items.Rows[itm]["TRANSIT_COUNTRY"].ToString()) + "</Transit_Country>");
                           xmlContent.AppendLine("<Accessory_Status>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ACCESSORY_STATUS"].ToString()) ? " " : Ex_items.Rows[itm]["ACCESSORY_STATUS"].ToString()) + "</Accessory_Status>");
                           xmlContent.AppendLine("<Hawb_No>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["HAWB_NO"].ToString()) ? " " : Ex_items.Rows[itm]["HAWB_NO"].ToString()) + "</Hawb_No>");
                           xmlContent.AppendLine("<Total_Pkgs>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["TOTAL_PKGS"].ToString()) ? " " : Ex_items.Rows[itm]["TOTAL_PKGS"].ToString()) + "</Total_Pkgs>");
                           xmlContent.AppendLine("<Enduse_Item>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ENDUSE_ITEM"].ToString()) ? " " : Ex_items.Rows[itm]["ENDUSE_ITEM"].ToString()) + "</Enduse_Item>");
                           xmlContent.AppendLine("<Igst_Payment>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["IGST_PAYMENT"].ToString()) ? " " : Ex_items.Rows[itm]["IGST_PAYMENT"].ToString()) + "</Igst_Payment>");
                           xmlContent.AppendLine("<Taxable_Value>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["TAXABLE_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["TAXABLE_VALUE"].ToString()) + "</Taxable_Value>");
                           xmlContent.AppendLine("<Igst_Amt>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["IGST_AMT"].ToString()) ? " " : Ex_items.Rows[itm]["IGST_AMT"].ToString()) + "</Igst_Amt>");
                           xmlContent.AppendLine("<Gstn_Type>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["GSTN_TYPE"].ToString()) ? " " : Ex_items.Rows[itm]["GSTN_TYPE"].ToString()) + "</Gstn_Type>");
                           xmlContent.AppendLine("<Gstn_Id>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["GSTN_ID"].ToString()) ? " " : Ex_items.Rows[itm]["GSTN_ID"].ToString()) + "</Gstn_Id>");
                           xmlContent.AppendLine("<Igst_Rate>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["IGST_RATE"].ToString()) ? " " : Ex_items.Rows[itm]["IGST_RATE"].ToString()) + "</Igst_Rate>");
                           xmlContent.AppendLine("<Pmv_Method>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["PMV_METHOD"].ToString()) ? " " : Ex_items.Rows[itm]["PMV_METHOD"].ToString()) + "</Pmv_Method>");
                           xmlContent.AppendLine("<Pmv_Rate>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["PMV_RATE"].ToString()) ? " " : Ex_items.Rows[itm]["PMV_RATE"].ToString()) + "</Pmv_Rate>");
                           xmlContent.AppendLine("<Pmv_Per_Unit>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["PMV_PER_UNIT"].ToString()) ? " " : Ex_items.Rows[itm]["PMV_PER_UNIT"].ToString()) + "</Pmv_Per_Unit>");
                           xmlContent.AppendLine("<Rodtep>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["RODTEP"].ToString()) ? " " : Ex_items.Rows[itm]["RODTEP"].ToString()) + "</Rodtep>");
                           xmlContent.AppendLine("<Rodtep_Value>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["RODTEP_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["RODTEP_VALUE"].ToString()) + "</Rodtep_Value>");
                           xmlContent.AppendLine("<Itm_Created_Date>" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["DATE_TIME"].ToString()) ? " " : (DateTime.Parse(Ex_items.Rows[itm]["DATE_TIME"].ToString()).ToString("dd-MMM-yyyy"))) + "</Itm_Created_Date>");
            
                           DataTable Draw_tbl = new DataTable();
                           Draw_tbl = dss.Tables[7];
                           DataView Draw_view = Draw_tbl.DefaultView;
                           string item_slno = Ex_items.Rows[itm]["ITEM_SLNO"].ToString();
                           Draw_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Draw_Tbl = Draw_view.ToTable();

                           if (Draw_Tbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Drawback_Details>"); // Loop start 
                               for (int draw = 0; draw < Draw_Tbl.Rows.Count; draw++)
                               {
                                   xmlContent.AppendLine("<Drawback_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["INVOICE_SLNO"].ToString()) ? " " : Draw_Tbl.Rows[draw]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["ITEM_SLNO"].ToString()) ? " " : Draw_Tbl.Rows[draw]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Scheme_Code>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["SCHEME_CODE"].ToString()) ? " " : Draw_Tbl.Rows[draw]["SCHEME_CODE"].ToString()) + "</Scheme_Code>");
                                   xmlContent.AppendLine("<Drawback_Slno>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_SLNO"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_SLNO"].ToString()) + "</Drawback_Slno>");
                                   xmlContent.AppendLine("<Drawback_Qty>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_QTY"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_QTY"].ToString()) + "</Drawback_Qty>");
                                   xmlContent.AppendLine("<Drawback_Unit>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_UNIT"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_UNIT"].ToString()) + "</Drawback_Unit>");
                                   xmlContent.AppendLine("<Drawback_Noofunits>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_NOOFUNITS"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_NOOFUNITS"].ToString()) + "</Drawback_Noofunits>");
                                   xmlContent.AppendLine("<Drawback_Rate>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_RATE"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_RATE"].ToString()) + "</Drawback_Rate>");
                                   xmlContent.AppendLine("<Drawback_Caps>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_CAPS"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_CAPS"].ToString()) + "</Drawback_Caps>");
                                   xmlContent.AppendLine("<Drawback_Desc>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_DESC"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_DESC"].ToString()) + "</Drawback_Desc>");
                                   xmlContent.AppendLine("<State_Level_Adv_Rate>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["STATE_LEVEL_ADV_RATE"].ToString()) ? " " : Draw_Tbl.Rows[draw]["STATE_LEVEL_ADV_RATE"].ToString()) + "</State_Level_Adv_Rate>");
                                   xmlContent.AppendLine("<State_Level_Adv_Amt>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["STATE_LEVEL_ADV_AMT"].ToString()) ? " " : Draw_Tbl.Rows[draw]["STATE_LEVEL_ADV_AMT"].ToString()) + "</State_Level_Adv_Amt>");
                                   xmlContent.AppendLine("<Central_Level_Adv_Rate>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["CENTRAL_LEVEL_ADV_RATE"].ToString()) ? " " : Draw_Tbl.Rows[draw]["CENTRAL_LEVEL_ADV_RATE"].ToString()) + "</Central_Level_Adv_Rate>");
                                   xmlContent.AppendLine("<Central_Level_Adv_Amt>" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["CENTRAL_LEVEL_ADV_AMT"].ToString()) ? " " : Draw_Tbl.Rows[draw]["CENTRAL_LEVEL_ADV_AMT"].ToString()) + "</Central_Level_Adv_Amt>");
                                   xmlContent.AppendLine("</Drawback_Detail>");
                               }
                               xmlContent.AppendLine("</Drawback_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<Drawback_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Scheme_Code>" + " " + "</Scheme_Code>");
                               xmlContent.AppendLine("<Drawback_Slno>" + " " + "</Drawback_Slno>");
                               xmlContent.AppendLine("<Drawback_Qty>" + " " + "</Drawback_Qty>");
                               xmlContent.AppendLine("<Drawback_Unit>" + " " + "</Drawback_Unit>");
                               xmlContent.AppendLine("<Drawback_Noofunits>" + " " + "</Drawback_Noofunits>");
                               xmlContent.AppendLine("<Drawback_Rate>" + " " + "</Drawback_Rate>");
                               xmlContent.AppendLine("<Drawback_Caps>" + " " + "</Drawback_Caps>");
                               xmlContent.AppendLine("<Drawback_Desc>" + " " + "</Drawback_Desc>");
                               xmlContent.AppendLine("<State_Level_Adv_Rate>" + " " + "</State_Level_Adv_Rate>");
                               xmlContent.AppendLine("<State_Level_Adv_Amt>" + " " + "</State_Level_Adv_Amt>");
                               xmlContent.AppendLine("<Central_Level_Adv_Rate>" + " " + "</Central_Level_Adv_Rate>");
                               xmlContent.AppendLine("<Central_Level_Adv_Amt>" + " " + "</Central_Level_Adv_Amt>");
                               xmlContent.AppendLine("</Drawback_Detail>");
                           }

                           if (dss.Tables[8].Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Annexure_C1_Details>");
                               xmlContent.AppendLine("<Annex_Exportername>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_EXPORTERNAME"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_EXPORTERNAME"].ToString()) + "</Annex_Exportername>");
                               xmlContent.AppendLine("<Annex_Ieccode>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_IECCODE"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_IECCODE"].ToString()) + "</Annex_Ieccode>");
                               xmlContent.AppendLine("<Annex_Br_Slno>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_BR_SLNO"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_BR_SLNO"].ToString()) + "</Annex_Br_Slno>");
                               xmlContent.AppendLine("<Annex_Exam_Date>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_EXAM_DATE"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_EXAM_DATE"].ToString()) + "</Annex_Exam_Date>");
                               xmlContent.AppendLine("<Annex_Exam_Officer>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_EXAM_OFFICER"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_EXAM_OFFICER"].ToString()) + "</Annex_Exam_Officer>");
                               xmlContent.AppendLine("<Annex_Exam_Design>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_EXAM_DESIGN"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_EXAM_DESIGN"].ToString()) + "</Annex_Exam_Design>");
                               xmlContent.AppendLine("<Annex_Super_Name>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_SUPER_NAME"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_SUPER_NAME"].ToString()) + "</Annex_Super_Name>");
                               xmlContent.AppendLine("<Annex_Super_Design>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_SUPER_DESIGN"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_SUPER_DESIGN"].ToString()) + "</Annex_Super_Design>");
                               xmlContent.AppendLine("<Annex_Commission_Rate>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_COMMISSION_RATE"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_COMMISSION_RATE"].ToString()) + "</Annex_Commission_Rate>");
                               xmlContent.AppendLine("<Annex_Division>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_DIVISION"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_DIVISION"].ToString()) + "</Annex_Division>");
                               xmlContent.AppendLine("<Annex_Range>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_RANGE"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_RANGE"].ToString()) + "</Annex_Range>");
                               xmlContent.AppendLine("<Annex_Verified_Exam_Officer>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString()) + "</Annex_Verified_Exam_Officer>");
                               xmlContent.AppendLine("<Annex_Sample_Drawn>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString()) + "</Annex_Sample_Drawn>");
                               xmlContent.AppendLine("<Annex_Seal_No>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_SEAL_NO"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_SEAL_NO"].ToString()) + "</Annex_Seal_No>");
                               xmlContent.AppendLine("<Annex_Address1>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_ADDRESS1"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_ADDRESS1"].ToString()) + "</Annex_Address1>");
                               xmlContent.AppendLine("<Annex_Address2>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_ADDRESS2"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_ADDRESS2"].ToString()) + "</Annex_Address2>");
                               xmlContent.AppendLine("<Annex_Address3>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_ADDRESS3"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_ADDRESS3"].ToString()) + "</Annex_Address3>");
                               xmlContent.AppendLine("<Annex_Address4>" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_ADDRESS4"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_ADDRESS4"].ToString()) + "</Annex_Address4>");
                               xmlContent.AppendLine("</Annexure_C1_Details>");
                           }

                           else
                           {
                               xmlContent.AppendLine("<Annexure_C1_Details>");
                               xmlContent.AppendLine("<Annex_Exportername>" + " " + "</Annex_Exportername>");
                               xmlContent.AppendLine("<Annex_Ieccode>" + " " + "</Annex_Ieccode>");
                               xmlContent.AppendLine("<Annex_Br_Slno>" + " " + "</Annex_Br_Slno>");
                               xmlContent.AppendLine("<Annex_Exam_Date>" + " " + "</Annex_Exam_Date>");
                               xmlContent.AppendLine("<Annex_Exam_Officer>" + " " + "</Annex_Exam_Officer>");
                               xmlContent.AppendLine("<Annex_Exam_Design>" + " " + "</Annex_Exam_Design>");
                               xmlContent.AppendLine("<Annex_Super_Name>" + " " + "</Annex_Super_Name>");
                               xmlContent.AppendLine("<Annex_Super_Design>" + " " + "</Annex_Super_Design>");
                               xmlContent.AppendLine("<Annex_Commission_Rate>" + " " + "</Annex_Commission_Rate>");
                               xmlContent.AppendLine("<Annex_Division>" + " " + "</Annex_Division>");
                               xmlContent.AppendLine("<Annex_Range>" + " " + "</Annex_Range>");
                               xmlContent.AppendLine("<Annex_Verified_Exam_Officer>" + " " + "</Annex_Verified_Exam_Officer>");
                               xmlContent.AppendLine("<Annex_Sample_Drawn>" + " " + "</Annex_Sample_Drawn>");
                               xmlContent.AppendLine("<Annex_Seal_No>" + " " + "</Annex_Seal_No>");
                               xmlContent.AppendLine("<Annex_Address1>" + " " + "</Annex_Address1>");
                               xmlContent.AppendLine("<Annex_Address2>" + " " + "</Annex_Address2>");
                               xmlContent.AppendLine("<Annex_Address3>" + " " + "</Annex_Address3>");
                               xmlContent.AppendLine("<Annex_Address4>" + " " + "</Annex_Address4>");
                               xmlContent.AppendLine("</Annexure_C1_Details>");
                           }

                           DataTable Re_Exp_tbl = new DataTable();
                           Re_Exp_tbl = dss.Tables[9];
                           DataView Re_Exp_view = Re_Exp_tbl.DefaultView;
                           Re_Exp_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Re_Exp_Tb = Re_Exp_view.ToTable();

                           if (Re_Exp_Tb.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Re_Export_Details>");
                               for (int ReExp = 0; ReExp < Re_Exp_Tb.Rows.Count; ReExp++)
                               {
                                   xmlContent.AppendLine("<Re_Export_Detail>");
                                   xmlContent.AppendLine("<Sb_No>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["SB_NO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["SB_NO"].ToString()) + "</Sb_No>");
                                   xmlContent.AppendLine("<Sb_Date>" + (Re_Exp_Tb.Rows[ReExp]["SB_DATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(Re_Exp_Tb.Rows[ReExp]["SB_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "</Sb_Date>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["INVOICE_SLNO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["ITEM_SLNO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Slno>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["SLNO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["SLNO"].ToString()) + "</Slno>");
                                   xmlContent.AppendLine("<Be_Site>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_SITE"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_SITE"].ToString()) + "</Be_Site>");
                                   xmlContent.AppendLine("<Be_No>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_NO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_NO"].ToString()) + "</Be_No>");
                                   xmlContent.AppendLine("<Be_Date>" + (Re_Exp_Tb.Rows[ReExp]["BE_DATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(Re_Exp_Tb.Rows[ReExp]["BE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "</Be_Date>");
                                   xmlContent.AppendLine("<Be_Invoice_No>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_INVOICE_NO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_INVOICE_NO"].ToString()) + "</Be_Invoice_No>");
                                   xmlContent.AppendLine("<Be_Invoice_Item_No>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_INVOICE_ITEM_NO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_INVOICE_ITEM_NO"].ToString()) + "</Be_Invoice_Item_No>");
                                   xmlContent.AppendLine("<Manual_Be_Y_N>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["MANUAL_BE_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["MANUAL_BE_Y_N"].ToString()) + "</Manual_Be_Y_N>");
                                   xmlContent.AppendLine("<Be_Qty_Utilised>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_QTY_UTILISED"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_QTY_UTILISED"].ToString()) + "</Be_Qty_Utilised>");
                                   xmlContent.AppendLine("<Be_Item_Desc>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_ITEM_DESC"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_ITEM_DESC"].ToString()) + "</Be_Item_Desc>");
                                   xmlContent.AppendLine("<Be_Qty>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_QTY"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_QTY"].ToString()) + "</Be_Qty>");
                                   xmlContent.AppendLine("<Be_Uqc>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_UQC"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_UQC"].ToString()) + "</Be_Uqc>");
                                   xmlContent.AppendLine("<Be_Ass_Value>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_ASS_VALUE"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_ASS_VALUE"].ToString()) + "</Be_Ass_Value>");
                                   xmlContent.AppendLine("<Be_Duty_Paid>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_DUTY_PAID"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_DUTY_PAID"].ToString()) + "</Be_Duty_Paid>");
                                   xmlContent.AppendLine("<Be_Duty_Payment_Date>" + (Re_Exp_Tb.Rows[ReExp]["BE_DUTY_PAYMENT_DATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(Re_Exp_Tb.Rows[ReExp]["BE_DUTY_PAYMENT_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "</Be_Duty_Payment_Date>");
                                   xmlContent.AppendLine("<Be_Oth_Identifiable_Parameter>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_OTH_IDENTIFIABLE_PARAMETER"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_OTH_IDENTIFIABLE_PARAMETER"].ToString()) + "</Be_Oth_Identifiable_Parameter>");
                                   xmlContent.AppendLine("<Be_Ass_Value_Claim>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_ASS_VALUE_CLAIM"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_ASS_VALUE_CLAIM"].ToString()) + "</Be_Ass_Value_Claim>");
                                   xmlContent.AppendLine("<Be_Item_Used_Y_N>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_ITEM_USED_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_ITEM_USED_Y_N"].ToString()) + "</Be_Item_Used_Y_N>");
                                   xmlContent.AppendLine("<Commisioner_Permission_Y_N>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["COMMISIONER_PERMISSION_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["COMMISIONER_PERMISSION_Y_N"].ToString()) + "</Commisioner_Permission_Y_N>");
                                   xmlContent.AppendLine("<Input_Credit_Y_N>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["INPUT_CREDIT_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["INPUT_CREDIT_Y_N"].ToString()) + "</Input_Credit_Y_N>");
                                   xmlContent.AppendLine("<Personal_Used_Y_N>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["PERSONAL_USED_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["PERSONAL_USED_Y_N"].ToString()) + "</Personal_Used_Y_N>");
                                   xmlContent.AppendLine("<Modvat_Availed_Y_N>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["MODVAT_AVAILED_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["MODVAT_AVAILED_Y_N"].ToString()) + "</Modvat_Availed_Y_N>");
                                   xmlContent.AppendLine("<Modvat_Repaid_Y_N>" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["MODVAT_REPAID_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["MODVAT_REPAID_Y_N"].ToString()) + "</Modvat_Repaid_Y_N>");
                                   xmlContent.AppendLine("</Re_Export_Detail>");
                               }
                               xmlContent.AppendLine("<Re_Export_Details>");
                           }

                           else
                           {
                               xmlContent.AppendLine("<Re_Export_Detail>");
                               xmlContent.AppendLine("<Sb_No>" + " " + "</Sb_No>");
                               xmlContent.AppendLine("<Sb_Date>" + " " + "</Sb_Date>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Slno>" + " " + "</Slno>");
                               xmlContent.AppendLine("<Be_Site>" + " " + "</Be_Site>");
                               xmlContent.AppendLine("<Be_No>" + " " + "</Be_No>");
                               xmlContent.AppendLine("<Be_Date>" + " " + "</Be_Date>");
                               xmlContent.AppendLine("<Be_Invoice_No>" + " " + "</Be_Invoice_No>");
                               xmlContent.AppendLine("<Be_Invoice_Item_No>" + " " + "</Be_Invoice_Item_No>");
                               xmlContent.AppendLine("<Manual_Be_Y_N>" + " " + "</Manual_Be_Y_N>");
                               xmlContent.AppendLine("<Be_Qty_Utilised>" + " " + "</Be_Qty_Utilised>");
                               xmlContent.AppendLine("<Be_Item_Desc>" + " " + "</Be_Item_Desc>");
                               xmlContent.AppendLine("<Be_Qty>" + " " + "</Be_Qty>");
                               xmlContent.AppendLine("<Be_Uqc>" + " " + "</Be_Uqc>");
                               xmlContent.AppendLine("<Be_Ass_Value>" + " " + "</Be_Ass_Value>");
                               xmlContent.AppendLine("<Be_Duty_Paid>" + " " + "</Be_Duty_Paid>");
                               xmlContent.AppendLine("<Be_Duty_Payment_Date>" + " " + "</Be_Duty_Payment_Date>");
                               xmlContent.AppendLine("<Be_Oth_Identifiable_Parameter>" + " " + "</Be_Oth_Identifiable_Parameter>");
                               xmlContent.AppendLine("<Be_Ass_Value_Claim>" + " " + "</Be_Ass_Value_Claim>");
                               xmlContent.AppendLine("<Be_Item_Used_Y_N>" + " " + "</Be_Item_Used_Y_N>");
                               xmlContent.AppendLine("<Commisioner_Permission_Y_N>" + " " + "</Commisioner_Permission_Y_N>");
                               xmlContent.AppendLine("<Input_Credit_Y_N>" + " " + "</Input_Credit_Y_N>");
                               xmlContent.AppendLine("<Personal_Used_Y_N>" + " " + "</Personal_Used_Y_N>");
                               xmlContent.AppendLine("<Modvat_Availed_Y_N>" + " " + "</Modvat_Availed_Y_N>");
                               xmlContent.AppendLine("<Modvat_Repaid_Y_N>" + " " + "</Modvat_Repaid_Y_N>");
                               xmlContent.AppendLine("</Re_Export_Detail>");
                           }

                           DataTable Quo_tbl = new DataTable();
                           Quo_tbl = dss.Tables[10];
                           DataView Quo_view = Quo_tbl.DefaultView;
                           Quo_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Quotbl = Quo_view.ToTable();

                           if (Quotbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Quota_Details>");
                               for (int Quo = 0; Quo < Quotbl.Rows.Count; Quo++)
                               {
                                   xmlContent.AppendLine("<Quota_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["INVOICE_SLNO"].ToString()) ? " " : Quotbl.Rows[Quo]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Sl_No>" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["ITEM_SLNO"].ToString()) ? " " : Quotbl.Rows[Quo]["ITEM_SLNO"].ToString()) + "</Item_Sl_No>");
                                   xmlContent.AppendLine("<Agency_Code>" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["AGENCY_CODE"].ToString()) ? " " : Quotbl.Rows[Quo]["AGENCY_CODE"].ToString()) + "</Agency_Code>");
                                   xmlContent.AppendLine("<Agency_Name>" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["AGENCY_NAME"].ToString()) ? " " : Quotbl.Rows[Quo]["AGENCY_NAME"].ToString()) + "</Agency_Name>");
                                   xmlContent.AppendLine("<Allocation_No>" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["ALLOCATION_NO"].ToString()) ? " " : Quotbl.Rows[Quo]["ALLOCATION_NO"].ToString()) + "</Allocation_No>");
                                   xmlContent.AppendLine("<Expiry_Date>" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["EXPIRY_DATE"].ToString()) ? " " : Quotbl.Rows[Quo]["EXPIRY_DATE"].ToString()) + "</Expiry_Date>");
                                   xmlContent.AppendLine("</Quota_Detail>");
                               }
                               xmlContent.AppendLine("<Quota_Details>");
                           }

                           else
                           {
                               xmlContent.AppendLine("<Quota_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Sl_No>" + " " + "</Item_Sl_No>");
                               xmlContent.AppendLine("<Agency_Code>" + " " + "</Agency_Code>");
                               xmlContent.AppendLine("<Agency_Name>" + " " + "</Agency_Name>");
                               xmlContent.AppendLine("<Allocation_No>" + " " + "</Allocation_No>");
                               xmlContent.AppendLine("<Expiry_Date>" + " " + "</Expiry_Date>");
                               xmlContent.AppendLine("</Quota_Detail>");

                           }

                           DataTable Cess_tbl = new DataTable();
                           Cess_tbl = dss.Tables[11];
                           DataView Cess_view = Cess_tbl.DefaultView;
                           Cess_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable CessTbl = Cess_view.ToTable();

                           if (CessTbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Cess_Details>");
                               for (int Cess = 0; Cess < CessTbl.Rows.Count; Cess++)
                               {
                                   xmlContent.AppendLine("<Cess_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["INVOICE_SLNO"].ToString()) ? " " : CessTbl.Rows[Cess]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["ITEM_SLNO"].ToString()) ? " " : CessTbl.Rows[Cess]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Cess_Slno>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_SLNO"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_SLNO"].ToString()) + "</Cess_Slno>");
                                   xmlContent.AppendLine("<Cess_Value>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_VALUE"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_VALUE"].ToString()) + "</Cess_Value>");
                                   xmlContent.AppendLine("<Cess_Unit>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_UNIT"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_UNIT"].ToString()) + "</Cess_Unit>");
                                   xmlContent.AppendLine("<Cess_Flag>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_FLAG"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_FLAG"].ToString()) + "</Cess_Flag>");
                                   xmlContent.AppendLine("<Cess_Rate>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_RATE"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_RATE"].ToString()) + "</Cess_Rate>");
                                   xmlContent.AppendLine("<Cess_Item_Qty>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_ITEM_QTY"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_ITEM_QTY"].ToString()) + "</Cess_Item_Qty>");
                                   xmlContent.AppendLine("<Cess_Item_Qty_Code>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_ITEM_QTY_CODE"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_ITEM_QTY_CODE"].ToString()) + "</Cess_Item_Qty_Code>");
                                   xmlContent.AppendLine("<Cess_Tariff_Value>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_TARIFF_VALUE"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_TARIFF_VALUE"].ToString()) + "</Cess_Tariff_Value>");
                                   xmlContent.AppendLine("<Cess_Tariff_Unit>" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_TARIFF_UNIT"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_TARIFF_UNIT"].ToString()) + "</Cess_Tariff_Unit>");
                                   xmlContent.AppendLine("</Cess_Detail>");
                               }
                               xmlContent.AppendLine("</Cess_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<Cess_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Cess_Slno>" + " " + "</Cess_Slno>");
                               xmlContent.AppendLine("<Cess_Value>" + " " + "</Cess_Value>");
                               xmlContent.AppendLine("<Cess_Unit>" + " " + "</Cess_Unit>");
                               xmlContent.AppendLine("<Cess_Flag>" + " " + "</Cess_Flag>");
                               xmlContent.AppendLine("<Cess_Rate>" + " " + "</Cess_Rate>");
                               xmlContent.AppendLine("<Cess_Item_Qty>" + " " + "</Cess_Item_Qty>");
                               xmlContent.AppendLine("<Cess_Item_Qty_Code>" + " " + "</Cess_Item_Qty_Code>");
                               xmlContent.AppendLine("<Cess_Tariff_Value>" + " " + "</Cess_Tariff_Value>");
                               xmlContent.AppendLine("<Cess_Tariff_Unit>" + " " + "</Cess_Tariff_Unit>");
                               xmlContent.AppendLine("</Cess_Detail>");
                           }

                           DataTable Jobbing_tbl = new DataTable();
                           Jobbing_tbl = dss.Tables[12];
                           DataView Jobbing_view = Jobbing_tbl.DefaultView;

                           Jobbing_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Jobbingtbl = Jobbing_view.ToTable();

                           if (Jobbingtbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Jobbing_Details>");
                               for (int Jobbing = 0; Jobbing < Jobbingtbl.Rows.Count; Jobbing++)
                               {
                                   xmlContent.AppendLine("<Jobbing_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["INVOICE_SLNO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["ITEM_SLNO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Scheme_Code>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["SCHEME_CODE"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["SCHEME_CODE"].ToString()) + "</Scheme_Code>");
                                   xmlContent.AppendLine("<Notification_No>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["NOTIFICATION_NO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["NOTIFICATION_NO"].ToString()) + "</Notification_No>");
                                   xmlContent.AppendLine("<Be_No>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_NO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_NO"].ToString()) + "</Be_No>");
                                   xmlContent.AppendLine("<Be_Date>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_DATE"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_DATE"].ToString()) + "</Be_Date>");
                                   xmlContent.AppendLine("<Be_Inv_Slno>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_INV_SLNO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_INV_SLNO"].ToString()) + "</Be_Inv_Slno>");
                                   xmlContent.AppendLine("<Be_Inv_No>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_INV_NO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_INV_NO"].ToString()) + "</Be_Inv_No>");
                                   xmlContent.AppendLine("<Be_Item_No>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_ITEM_NO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_ITEM_NO"].ToString()) + "</Be_Item_No>");
                                   xmlContent.AppendLine("<Be_Port_Code>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_PORT_CODE"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_PORT_CODE"].ToString()) + "</Be_Port_Code>");
                                   xmlContent.AppendLine("<Qty>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["QTY"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["QTY"].ToString()) + "</Qty>");
                                   xmlContent.AppendLine("<Unit>" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["UNIT"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["UNIT"].ToString()) + "</Unit>");
                                   xmlContent.AppendLine("</Jobbing_Detail>");
                               }
                               xmlContent.AppendLine("</Jobbing_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<Jobbing_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Scheme_Code>" + " " + "</Scheme_Code>");
                               xmlContent.AppendLine("<Notification_No>" + " " + "</Notification_No>");
                               xmlContent.AppendLine("<Be_No>" + " " + "</Be_No>");
                               xmlContent.AppendLine("<Be_Date>" + " " + "</Be_Date>");
                               xmlContent.AppendLine("<Be_Inv_Slno>" + " " + "</Be_Inv_Slno>");
                               xmlContent.AppendLine("<Be_Inv_No>" + " " + "</Be_Inv_No>");
                               xmlContent.AppendLine("<Be_Item_No>" + " " + "</Be_Item_No>");
                               xmlContent.AppendLine("<Be_Port_Code>" + " " + "</Be_Port_Code>");
                               xmlContent.AppendLine("<Qty>" + " " + "</Qty>");
                               xmlContent.AppendLine("<Unit>" + " " + "</Unit>");
                               xmlContent.AppendLine("</Jobbing_Detail>");
                           }

                           DataTable Lic_tbl = new DataTable();
                           Lic_tbl = dss.Tables[13];
                           DataView Lic_view = Lic_tbl.DefaultView;
                           Lic_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable LicTbl = Lic_view.ToTable();

                           if (LicTbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<License_Details>");
                               for (int Lic = 0; Lic < LicTbl.Rows.Count; Lic++)
                               {
                                   xmlContent.AppendLine("<License_Detail>");
                                   xmlContent.AppendLine("<Inv_Sl_No>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["INVOICE_SLNO"].ToString()) ? " " : LicTbl.Rows[Lic]["INVOICE_SLNO"].ToString()) + "</Inv_Sl_No>");
                                   xmlContent.AppendLine("<Item_Sl_No>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["ITEM_SLNO"].ToString()) ? " " : LicTbl.Rows[Lic]["ITEM_SLNO"].ToString()) + "</Item_Sl_No>");
                                   xmlContent.AppendLine("<Scheme>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["SCHEME"].ToString()) ? " " : LicTbl.Rows[Lic]["SCHEME"].ToString()) + "</Scheme>");
                                   xmlContent.AppendLine("<License_Reg_Slno>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_REG_SLNO"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_REG_SLNO"].ToString()) + "</License_Reg_Slno>");
                                   xmlContent.AppendLine("<License_No>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_NO"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_NO"].ToString()) + "</License_No>");
                                   xmlContent.AppendLine("<License_Date>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_DATE"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_DATE"].ToString()) + "</License_Date>");
                                   xmlContent.AppendLine("<License_E_Sl_No>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_E_SL_NO"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_E_SL_NO"].ToString()) + "</License_E_Sl_No>");
                                   xmlContent.AppendLine("<License_Exp_Qty>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_EXP_QTY"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_EXP_QTY"].ToString()) + "</License_Exp_Qty>");
                                   xmlContent.AppendLine("<License_Exp_Unit>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_EXP_UNIT"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_EXP_UNIT"].ToString()) + "</License_Exp_Unit>");
                                   xmlContent.AppendLine("<License_Imp_Item_Sl_No>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_ITEM_SL_NO"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_ITEM_SL_NO"].ToString()) + "</License_Imp_Item_Sl_No>");
                                   xmlContent.AppendLine("<License_Imp_Desc>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_DESC"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_DESC"].ToString()) + "</License_Imp_Desc>");
                                   xmlContent.AppendLine("<License_Imp_Qty>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_QTY"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_QTY"].ToString()) + "</License_Imp_Qty>");
                                   xmlContent.AppendLine("<License_Imp_Unit>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_UNIT"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_UNIT"].ToString()) + "</License_Imp_Unit>");
                                   xmlContent.AppendLine("<License_Imp_Type>" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_TYPE"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_TYPE"].ToString()) + "</License_Imp_Type>");
                                   xmlContent.AppendLine("</License_Detail>");
                               }
                               xmlContent.AppendLine("</License_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<License_Detail>");
                               xmlContent.AppendLine("<Inv_Sl_No>" + " " + "</Inv_Sl_No>");
                               xmlContent.AppendLine("<Item_Sl_No>" + " " + "</Item_Sl_No>");
                               xmlContent.AppendLine("<Scheme>" + " " + "</Scheme>");
                               xmlContent.AppendLine("<License_Reg_Slno>" + " " + "</License_Reg_Slno>");
                               xmlContent.AppendLine("<License_No>" + " " + "</License_No>");
                               xmlContent.AppendLine("<License_Date>" + " " + "</License_Date>");
                               xmlContent.AppendLine("<License_E_Sl_No>" + " " + "</License_E_Sl_No>");
                               xmlContent.AppendLine("<License_Exp_Qty>" + " " + "</License_Exp_Qty>");
                               xmlContent.AppendLine("<License_Exp_Unit>" + " " + "</License_Exp_Unit>");
                               xmlContent.AppendLine("<License_Imp_Item_Sl_No>" + " " + "</License_Imp_Item_Sl_No>");
                               xmlContent.AppendLine("<License_Imp_Desc>" + " " + "</License_Imp_Desc>");
                               xmlContent.AppendLine("<License_Imp_Qty>" + " " + "</License_Imp_Qty>");
                               xmlContent.AppendLine("<License_Imp_Unit>" + " " + "</License_Imp_Unit>");
                               xmlContent.AppendLine("<License_Imp_Type>" + " " + "</License_Imp_Type>");
                               xmlContent.AppendLine("</License_Detail>");
                           }

                           DataTable SWinfo_tbl = new DataTable();
                           SWinfo_tbl = dss.Tables[14];
                           DataView SWinfo_view = SWinfo_tbl.DefaultView;
                           SWinfo_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Sw_Info_Tbl = SWinfo_view.ToTable();

                           if (Sw_Info_Tbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Sw_Info_Type_Details>");
                               for (int Sw_Info = 0; Sw_Info < Sw_Info_Tbl.Rows.Count; Sw_Info++)
                               {
                                   xmlContent.AppendLine("<Sw_Info_Type_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INVOICE_SLNO"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["ITEM_SLNO"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Slno>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["SLNO"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["SLNO"].ToString()) + "</Slno>");
                                   xmlContent.AppendLine("<Info_Type>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_TYPE"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_TYPE"].ToString()) + "</Info_Type>");
                                   xmlContent.AppendLine("<Info_Qualifier>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_QUALIFIER"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_QUALIFIER"].ToString()) + "</Info_Qualifier>");
                                   xmlContent.AppendLine("<Info_Code>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_CODE"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_CODE"].ToString()) + "</Info_Code>");
                                   xmlContent.AppendLine("<Info_Text>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_TEXT"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_TEXT"].ToString()) + "</Info_Text>");
                                   xmlContent.AppendLine("<Info_Msr>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_MSR"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_MSR"].ToString()) + "</Info_Msr>");
                                   xmlContent.AppendLine("<Info_Uqc>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_UQC"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_UQC"].ToString()) + "</Info_Uqc>");
                                   xmlContent.AppendLine("<Department>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["DEPARTMENT"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["DEPARTMENT"].ToString()) + "</Department>");
                                   xmlContent.AppendLine("<I_U_Type>" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["I_U_TYPE"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["I_U_TYPE"].ToString()) + "</I_U_Type>");
                                   xmlContent.AppendLine("</Sw_Info_Type_Detail>");

                               }
                               xmlContent.AppendLine("</Sw_Info_Type_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<Sw_Info_Type_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Slno>" + " " + "</Slno>");
                               xmlContent.AppendLine("<Info_Type>" + " " + "</Info_Type>");
                               xmlContent.AppendLine("<Info_Qualifier>" + " " + "</Info_Qualifier>");
                               xmlContent.AppendLine("<Info_Code>" + " " + "</Info_Code>");
                               xmlContent.AppendLine("<Info_Text>" + " " + "</Info_Text>");
                               xmlContent.AppendLine("<Info_Msr>" + " " + "</Info_Msr>");
                               xmlContent.AppendLine("<Info_Uqc>" + " " + "</Info_Uqc>");
                               xmlContent.AppendLine("<Department>" + " " + "</Department>");
                               xmlContent.AppendLine("<I_U_Type>" + " " + "</I_U_Type>");
                               xmlContent.AppendLine("</Sw_Info_Type_Detail>");
                           }


                           DataTable SwConst_tbl = new DataTable();
                           SwConst_tbl = dss.Tables[15];
                           DataView SwConst_view = SwConst_tbl.DefaultView;
                           SwConst_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Sw_Const_Tbl = SwConst_view.ToTable();

                           if (Sw_Const_Tbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Sw_Const_Details>");
                               for (int Sw_Const = 0; Sw_Const < Sw_Const_Tbl.Rows.Count; Sw_Const++)
                               {
                                   xmlContent.AppendLine("<Sw_Const_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["INVOICE_SLNO"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["ITEM_SLNO"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Constituent_Srno>" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_SRNO"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_SRNO"].ToString()) + "</Constituent_Srno>");
                                   xmlContent.AppendLine("<Constituent_Element_Name>" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_ELEMENT_NAME"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_ELEMENT_NAME"].ToString()) + "</Constituent_Element_Name>");
                                   xmlContent.AppendLine("<Constituent_Element_Code>" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_ELEMENT_CODE"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_ELEMENT_CODE"].ToString()) + "</Constituent_Element_Code>");
                                   xmlContent.AppendLine("<Constituent_Percentage>" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_PERCENTAGE"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_PERCENTAGE"].ToString()) + "</Constituent_Percentage>");
                                   xmlContent.AppendLine("<Constituent_Yield_Percentage>" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString()) + "</Constituent_Yield_Percentage>");
                                   xmlContent.AppendLine("<Active_Ingredient>" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["ACTIVE_INGREDIENT"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["ACTIVE_INGREDIENT"].ToString()) + "</Active_Ingredient>");
                                   xmlContent.AppendLine("</Sw_Const_Detail>");

                               }
                               xmlContent.AppendLine("</Sw_Const_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<Sw_Const_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Constituent_Srno>" + " " + "</Constituent_Srno>");
                               xmlContent.AppendLine("<Constituent_Element_Name>" + " " + "</Constituent_Element_Name>");
                               xmlContent.AppendLine("<Constituent_Element_Code>" + " " + "</Constituent_Element_Code>");
                               xmlContent.AppendLine("<Constituent_Percentage>" + " " + "</Constituent_Percentage>");
                               xmlContent.AppendLine("<Constituent_Yield_Percentage>" + " " + "</Constituent_Yield_Percentage>");
                               xmlContent.AppendLine("<Active_Ingredient>" + " " + "</Active_Ingredient>");
                               xmlContent.AppendLine("</Sw_Const_Detail>");
                           }


                           DataTable SwProd_tbl = new DataTable();
                           SwProd_tbl = dss.Tables[16];
                           DataView SwProd_view = SwProd_tbl.DefaultView;
                           SwProd_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable SwProdTbl = SwProd_view.ToTable();

                           if (SwProdTbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Sw_Prod_Details>");
                               for (int Sw_Prod = 0; Sw_Prod < SwProdTbl.Rows.Count; Sw_Prod++)
                               {
                                   xmlContent.AppendLine("<Sw_Prod_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["INVOICE_SLNO"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["ITEM_SLNO"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Slno>" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["SLNO"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["SLNO"].ToString()) + "</Slno>");
                                   xmlContent.AppendLine("<Production_Batch_Identifier>" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString()) + "</Production_Batch_Identifier>");
                                   xmlContent.AppendLine("<Production_Batch_Quantity>" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["PRODUCTION_BATCH_QUANTITY"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["PRODUCTION_BATCH_QUANTITY"].ToString()) + "</Production_Batch_Quantity>");
                                   xmlContent.AppendLine("<Unit_Qty_Code>" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["UNIT_QTY_CODE"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["UNIT_QTY_CODE"].ToString()) + "</Unit_Qty_Code>");
                                   xmlContent.AppendLine("<Date_Of_Manufacturing>" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["DATE_OF_MANUFACTURING"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["DATE_OF_MANUFACTURING"].ToString()) + "</Date_Of_Manufacturing>");
                                   xmlContent.AppendLine("<Date_Of_Expiry>" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["DATE_OF_EXPIRY"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["DATE_OF_EXPIRY"].ToString()) + "</Date_Of_Expiry>");
                                   xmlContent.AppendLine("<Best_Before>" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["BEST_BEFORE"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["BEST_BEFORE"].ToString()) + "</Best_Before>");
                                   xmlContent.AppendLine("</Sw_Prod_Detail>");

                               }
                               xmlContent.AppendLine("</Sw_Prod_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<Sw_Prod_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Slno>" + " " + "</Slno>");
                               xmlContent.AppendLine("<Production_Batch_Identifier>" + " " + "</Production_Batch_Identifier>");
                               xmlContent.AppendLine("<Production_Batch_Quantity>" + " " + "</Production_Batch_Quantity>");
                               xmlContent.AppendLine("<Unit_Qty_Code>" + " " + "</Unit_Qty_Code>");
                               xmlContent.AppendLine("<Date_Of_Manufacturing>" + " " + "</Date_Of_Manufacturing>");
                               xmlContent.AppendLine("<Date_Of_Expiry>" + " " + "</Date_Of_Expiry>");
                               xmlContent.AppendLine("<Best_Before>" + " " + "</Best_Before>");
                               xmlContent.AppendLine("</Sw_Prod_Detail>");
                           }

                           DataTable SwCont_tbl = new DataTable();
                           SwCont_tbl = dss.Tables[17];
                           DataView SwCont_view = SwCont_tbl.DefaultView;
                           SwCont_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable SwContTbl = SwCont_view.ToTable();

                           if (SwContTbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Sw_Control_Details>");
                               for (int Sw_Cont = 0; Sw_Cont < SwContTbl.Rows.Count; Sw_Cont++)
                               {
                                   xmlContent.AppendLine("<Sw_Control_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["INVOICE_SLNO"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["ITEM_SLNO"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Slno>" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["SLNO"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["SLNO"].ToString()) + "</Slno>");
                                   xmlContent.AppendLine("<Control_Type_Code>" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_TYPE_CODE"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_TYPE_CODE"].ToString()) + "</Control_Type_Code>");
                                   xmlContent.AppendLine("<Control_Location>" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_LOCATION"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_LOCATION"].ToString()) + "</Control_Location>");
                                   xmlContent.AppendLine("<Control_Start_Date>" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_START_DATE"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_START_DATE"].ToString()) + "</Control_Start_Date>");
                                   xmlContent.AppendLine("<Control_End_Date>" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_END_DATE"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_END_DATE"].ToString()) + "</Control_End_Date>");
                                   xmlContent.AppendLine("<Control_Result_Code>" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_RESULT_CODE"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_RESULT_CODE"].ToString()) + "</Control_Result_Code>");
                                   xmlContent.AppendLine("<Control_Result_Text>" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_RESULT_TEXT"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_RESULT_TEXT"].ToString()) + "</Control_Result_Text>");
                                   xmlContent.AppendLine("</Sw_Control_Detail>");

                               }
                               xmlContent.AppendLine("</Sw_Control_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<Sw_Control_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Slno>" + " " + "</Slno>");
                               xmlContent.AppendLine("<Control_Type_Code>" + " " + "</Control_Type_Code>");
                               xmlContent.AppendLine("<Control_Location>" + " " + "</Control_Location>");
                               xmlContent.AppendLine("<Control_Start_Date>" + " " + "</Control_Start_Date>");
                               xmlContent.AppendLine("<Control_End_Date>" + " " + "</Control_End_Date>");
                               xmlContent.AppendLine("<Control_Result_Code>" + " " + "</Control_Result_Code>");
                               xmlContent.AppendLine("<Control_Result_Text>" + " " + "</Control_Result_Text>");
                               xmlContent.AppendLine("</Sw_Control_Detail>");
                           }


                           DataTable SwState_tbl = new DataTable();
                           SwState_tbl = dss.Tables[18];
                           DataView SwState_view = SwState_tbl.DefaultView;
                           SwState_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable SwStateTbl = SwState_view.ToTable();

                           if (SwStateTbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Sw_Stmt_Details>");
                               for (int Sw_Sate = 0; Sw_Sate < SwStateTbl.Rows.Count; Sw_Sate++)
                               {
                                   xmlContent.AppendLine("<Sw_Stmt_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["INVOICE_SLNO"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["ITEM_SLNO"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Slno>" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["SLNO"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["SLNO"].ToString()) + "</Slno>");
                                   xmlContent.AppendLine("<Stmt_Type>" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["STMT_TYPE"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["STMT_TYPE"].ToString()) + "</Stmt_Type>");
                                   xmlContent.AppendLine("<Stmt_Code>" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["STMT_CODE"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["STMT_CODE"].ToString()) + "</Stmt_Code>");
                                   xmlContent.AppendLine("<Stmt_Text>" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["STMT_TEXT"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["STMT_TEXT"].ToString()) + "</Stmt_Text>");
                                   xmlContent.AppendLine("</Sw_Stmt_Detail>");
                               }
                               xmlContent.AppendLine("</Sw_Stmt_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<Sw_Stmt_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Slno>" + " " + "</Slno>");
                               xmlContent.AppendLine("<Stmt_Type>" + " " + "</Stmt_Type>");
                               xmlContent.AppendLine("<Stmt_Code>" + " " + "</Stmt_Code>");
                               xmlContent.AppendLine("<Stmt_Text>" + " " + "</Stmt_Text>");
                               xmlContent.AppendLine("</Sw_Stmt_Detail>");
                           }

                           DataTable Sw_Sup_tbl = new DataTable();
                           Sw_Sup_tbl = dss.Tables[19];
                           DataView Sw_Sup_view = Sw_Sup_tbl.DefaultView;
                           Sw_Sup_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Sw_SupTbl = Sw_Sup_view.ToTable();

                           if (Sw_SupTbl.Rows.Count > 0)
                           {
                               xmlContent.AppendLine("<Sw_Sup_Doc_Details>");
                               for (int Sw_Sup = 0; Sw_Sup < Sw_SupTbl.Rows.Count; Sw_Sup++)
                               {
                                   xmlContent.AppendLine("<Sw_Sup_Doc_Detail>");
                                   xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["INVOICE_SLNO"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                                   xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["ITEM_SLNO"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                                   xmlContent.AppendLine("<Slno>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["SLNO"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["SLNO"].ToString()) + "</Slno>");
                                   xmlContent.AppendLine("<Unique_Doc_Number>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["UNIQUE_DOC_NUMBER"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["UNIQUE_DOC_NUMBER"].ToString()) + "</Unique_Doc_Number>");
                                   xmlContent.AppendLine("<Doc_Type_Code>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_TYPE_CODE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_TYPE_CODE"].ToString()) + "</Doc_Type_Code>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Code>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_CODE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_CODE"].ToString()) + "</Doc_Issuing_Party_Code>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Name_Add1>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString()) + "</Doc_Issuing_Party_Name_Add1>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Name_Add2>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString()) + "</Doc_Issuing_Party_Name_Add2>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_City>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_CITY"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_CITY"].ToString()) + "</Doc_Issuing_Party_City>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Pin>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_PIN"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_PIN"].ToString()) + "</Doc_Issuing_Party_Pin>");
                                   xmlContent.AppendLine("<Doc_Ref_Number>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_REF_NUMBER"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_REF_NUMBER"].ToString()) + "</Doc_Ref_Number>");
                                   xmlContent.AppendLine("<Place_Of_Issue>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["PLACE_OF_ISSUE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["PLACE_OF_ISSUE"].ToString()) + "</Place_Of_Issue>");
                                   xmlContent.AppendLine("<Doc_Issue_Date>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUE_DATE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUE_DATE"].ToString()) + "</Doc_Issue_Date>");
                                   xmlContent.AppendLine("<Doc_Expiry_Date>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_EXPIRY_DATE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_EXPIRY_DATE"].ToString()) + "</Doc_Expiry_Date>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Code>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_CODE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_CODE"].ToString()) + "</Beneficiary_Party_Code>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Address1>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_ADDRESS1"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_ADDRESS1"].ToString()) + "</Beneficiary_Party_Address1>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Address2>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_ADDRESS2"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_ADDRESS2"].ToString()) + "</Beneficiary_Party_Address2>");
                                   xmlContent.AppendLine("<Beneficiary_Party_City>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_CITY"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_CITY"].ToString()) + "</Beneficiary_Party_City>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Pin>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_PIN"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_PIN"].ToString()) + "</Beneficiary_Party_Pin>");
                                   xmlContent.AppendLine("<File_Type>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["FILE_TYPE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["FILE_TYPE"].ToString()) + "</File_Type>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Name>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME"].ToString()) + "</Doc_Issuing_Party_Name>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Name>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_NAME"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_NAME"].ToString()) + "</Beneficiary_Party_Name>");
                                   xmlContent.AppendLine("<Icegate_Id>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["ICEGATE_ID"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["ICEGATE_ID"].ToString()) + "</Icegate_Id>");
                                   xmlContent.AppendLine("<Icegate_Doc_File_Name>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["ICEGATE_DOC_FILE_NAME"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["ICEGATE_DOC_FILE_NAME"].ToString()) + "</Icegate_Doc_File_Name>");
                                   xmlContent.AppendLine("<Select_Type>" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["SELECT_TYPE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["SELECT_TYPE"].ToString()) + "</Select_Type>");
                                   xmlContent.AppendLine("</Sw_Sup_Doc_Detail>");
                               }
                               xmlContent.AppendLine("</Sw_Sup_Doc_Details>");
                           }
                           else
                           {
                               xmlContent.AppendLine("<Sw_Sup_Doc_Detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + " " + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + " " + "</Item_Slno>");
                               xmlContent.AppendLine("<Slno>" + " " + "</Slno>");
                               xmlContent.AppendLine("<Unique_Doc_Number>" + " " + "</Unique_Doc_Number>");
                               xmlContent.AppendLine("<Doc_Type_Code>" + " " + "</Doc_Type_Code>");
                               xmlContent.AppendLine("<Doc_Issuing_Party_Code>" + " " + "</Doc_Issuing_Party_Code>");
                               xmlContent.AppendLine("<Doc_Issuing_Party_Name_Add1>" + " " + "</Doc_Issuing_Party_Name_Add1>");
                               xmlContent.AppendLine("<Doc_Issuing_Party_Name_Add2>" + " " + "</Doc_Issuing_Party_Name_Add2>");
                               xmlContent.AppendLine("<Doc_Issuing_Party_City>" + " " + "</Doc_Issuing_Party_City>");
                               xmlContent.AppendLine("<Doc_Issuing_Party_Pin>" + " " + "</Doc_Issuing_Party_Pin>");
                               xmlContent.AppendLine("<Doc_Ref_Number>" + " " + "</Doc_Ref_Number>");
                               xmlContent.AppendLine("<Place_Of_Issue>" + " " + "</Place_Of_Issue>");
                               xmlContent.AppendLine("<Doc_Issue_Date>" + " " + "</Doc_Issue_Date>");
                               xmlContent.AppendLine("<Doc_Expiry_Date>" + " " + "</Doc_Expiry_Date>");
                               xmlContent.AppendLine("<Beneficiary_Party_Code>" + " " + "</Beneficiary_Party_Code>");
                               xmlContent.AppendLine("<Beneficiary_Party_Address1>" + " " + "</Beneficiary_Party_Address1>");
                               xmlContent.AppendLine("<Beneficiary_Party_Address2>" + " " + "</Beneficiary_Party_Address2>");
                               xmlContent.AppendLine("<Beneficiary_Party_City>" + " " + "</Beneficiary_Party_City>");
                               xmlContent.AppendLine("<Beneficiary_Party_Pin>" + " " + "</Beneficiary_Party_Pin>");
                               xmlContent.AppendLine("<File_Type>" + " " + "</File_Type>");
                               xmlContent.AppendLine("<Doc_Issuing_Party_Name>" + " " + "</Doc_Issuing_Party_Name>");
                               xmlContent.AppendLine("<Beneficiary_Party_Name>" + " " + "</Beneficiary_Party_Name>");
                               xmlContent.AppendLine("<Icegate_Id>" + " " + "</Icegate_Id>");
                               xmlContent.AppendLine("<Icegate_Doc_File_Name>" + " " + "</Icegate_Doc_File_Name>");
                               xmlContent.AppendLine("<Select_Type>" + " " + "</Select_Type>");
                               xmlContent.AppendLine("</Sw_Sup_Doc_Detail>");
                           }

                           xmlContent.AppendLine("</Item_detail>");

                       }
                       xmlContent.AppendLine("</Item_details>");

                   }

                   xmlContent.AppendLine("</Invoice_Detail>");
               }

               xmlContent.AppendLine("</Invoice_Details>");

           }
           xmlContent.AppendLine("</JobDetails>");
       }


       #endregion E_XML
       //return data = xmlContent.ToString();
       return "";
   }
   public string Imp_XML_Generate(DataSet dss, string job_no)
   {
       StringBuilder xmlContent = new StringBuilder();
       #region XML
       if (dss.Tables.Count > 0)
       {
           if (dss.Tables[0].Rows.Count > 0)
           {
               xmlContent.AppendLine("<JobDetails>");
               xmlContent.AppendLine("<Job_No>" + job_no + "</Job_No>");
               xmlContent.AppendLine("<Job_Date>" + (dss.Tables[0].Rows[0]["JOBDATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[0].Rows[0]["JOBDATE"].ToString()).ToString("dd-MMM-yyyy")) + "</Job_Date>");
               xmlContent.AppendLine("<Transport_Mode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["TRANSPORT_MODENEW"].ToString()) ? " " : dss.Tables[0].Rows[0]["TRANSPORT_MODENEW"].ToString()) + "</Transport_Mode>");
               xmlContent.AppendLine("<BE_Type>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["BE_TYPE_New"].ToString()) ? " " : dss.Tables[0].Rows[0]["BE_TYPE_New"].ToString()) + "</BE_Type>");
               xmlContent.AppendLine("<CustomsHouse>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()) ? " " : dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()) + "</CustomsHouse>");
               xmlContent.AppendLine("<ImporterName>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString()) + "</ImporterName>");
               xmlContent.AppendLine("<Importer_Address1>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS1"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS1"].ToString()) + "</Importer_Address1>");
               xmlContent.AppendLine("<Importer_Address2>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS2"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS2"].ToString()) + "</Importer_Address2>");
               xmlContent.AppendLine("<Importer_Address3>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS3"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS3"].ToString()) + "</Importer_Address3>");
               xmlContent.AppendLine("<Importer_Address4>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) + "</Importer_Address4>");
               xmlContent.AppendLine("<Importer_Address5>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) + "</Importer_Address5>");
               xmlContent.AppendLine("<IEC_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["IEC_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["IEC_NO"].ToString()) + "</IEC_No>");
               xmlContent.AppendLine("<Branch_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()) + "</Branch_No>");
               xmlContent.AppendLine("<CountryOfOrigin>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString()) ? " " : dss.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString()) + "</CountryOfOrigin>");
               xmlContent.AppendLine("<PortOfShipment>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString()) ? " " : dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString()) + "</PortOfShipment>");
               xmlContent.AppendLine("<PortOfOrgin>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString()) ? " " : dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString()) + "</PortOfOrgin>");
               xmlContent.AppendLine("<CountryOfShipment>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString()) ? " " : dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString()) + "</CountryOfShipment>");
               xmlContent.AppendLine("<FilingStatus>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FILING_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["FILING_STATUS"].ToString()) + "</FilingStatus>");
               xmlContent.AppendLine("<UnderSec46>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION46"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION46"].ToString()) + "</UnderSec46>");
               xmlContent.AppendLine("<UnderSec46Remarks>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION46_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION46_DESC"].ToString()) + "</UnderSec46Remarks>");
               xmlContent.AppendLine("<FirstCheck>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FIRSTCHECK"].ToString()) ? " " : dss.Tables[0].Rows[0]["FIRSTCHECK"].ToString()) + "</FirstCheck>");
               xmlContent.AppendLine("<FirstCheckRemarks>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString()) + "</FirstCheckRemarks>");
               xmlContent.AppendLine("<GreenChannel>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString()) ? " " : dss.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString()) + "</GreenChannel>");
               xmlContent.AppendLine("<GreenChannelRemarks>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString()) + "</GreenChannelRemarks>");
               xmlContent.AppendLine("<KachhaBE>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["KACHHA_BE"].ToString()) ? " " : dss.Tables[0].Rows[0]["KACHHA_BE"].ToString()) + "</KachhaBE>");
               xmlContent.AppendLine("<KachhaBERemarks>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString()) + "</KachhaBERemarks>");
               xmlContent.AppendLine("<UnderSec48>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION48"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION48"].ToString()) + "</UnderSec48>");
               xmlContent.AppendLine("<UnderSec48Remarks>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION48_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION48_DESC"].ToString()) + "</UnderSec48Remarks>");
               xmlContent.AppendLine("<HighSeaSale>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString()) + "</HighSeaSale>");
               xmlContent.AppendLine("<HighSeaSeleName>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString()) + "</HighSeaSeleName>");
               xmlContent.AppendLine("<HighSeaSellerIEC>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString()) + "</HighSeaSellerIEC>");
               xmlContent.AppendLine("<HighSeaSellerBranchSNo>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString()) + "</HighSeaSellerBranchSNo>");
               xmlContent.AppendLine("<HighSeaSellerAddress>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD1"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD1"].ToString()) + "</HighSeaSellerAddress>");
               xmlContent.AppendLine("<HighSeaSellerAddress2>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD2"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD2"].ToString()) + "</HighSeaSellerAddress2>");
               xmlContent.AppendLine("<HighSeaSellerCity>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD3"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD3"].ToString()) + "</HighSeaSellerCity>");
               xmlContent.AppendLine("<HighSeaSellerState>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD4"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD4"].ToString()) + "</HighSeaSellerState>");
               xmlContent.AppendLine("<HighSeaSellerPinCode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD5"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD5"].ToString()) + "</HighSeaSellerPinCode>");
               xmlContent.AppendLine("<WareHouseCode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString()) + "</WareHouseCode>");
               xmlContent.AppendLine("<WareHouseName>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString()) + "</WareHouseName>");
               xmlContent.AppendLine("<Commercial_Details_Status>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString()) + "</Commercial_Details_Status>");
               xmlContent.AppendLine("<Commercial_Tax_Statename>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString()) + "</Commercial_Tax_Statename>");
               xmlContent.AppendLine("<Commercial_Tax_Statecode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString()) + "</Commercial_Tax_Statecode>");
               xmlContent.AppendLine("<Commercial_Tax_Type>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString()) + "</Commercial_Tax_Type>");
               xmlContent.AppendLine("<Commercial_Tax_Registration_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString()) + "</Commercial_Tax_Registration_No>");
               xmlContent.AppendLine("<Exbond_Inbond_Be_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString()) + "</Exbond_Inbond_Be_No>");
               xmlContent.AppendLine("<Exbond_Inbond_Be_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString()) + "</Exbond_Inbond_Be_Date>");
               xmlContent.AppendLine("<Exbond_Bond_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString()) + "</Exbond_Bond_No>");
               xmlContent.AppendLine("<Exbond_Bond_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString()) + "</Exbond_Bond_Date>");
               xmlContent.AppendLine("<Exbond_Warehouse_Customs>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString()) + "</Exbond_Warehouse_Customs>");
               xmlContent.AppendLine("<Exbond_Warehouse_Customs_Code>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString()) + "</Exbond_Warehouse_Customs_Code>");
               xmlContent.AppendLine("<Exbond_Noofpackage>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString()) + "</Exbond_Noofpackage>");
               xmlContent.AppendLine("<Exbond_Noofpackage_Unitcode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString()) + "</Exbond_Noofpackage_Unitcode>");
               xmlContent.AppendLine("<Exbond_Gross_Weight>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString()) + "</Exbond_Gross_Weight>");
               xmlContent.AppendLine("<Exbond_Gross_Weight_Unitcode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString()) + "</Exbond_Gross_Weight_Unitcode>");
               xmlContent.AppendLine("<Exbond_Direct_Exbonding>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString()) + "</Exbond_Direct_Exbonding>");
               xmlContent.AppendLine("<Remarks>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["REMARKS"].ToString()) ? " " : dss.Tables[0].Rows[0]["REMARKS"].ToString()) + "</Remarks>");
               xmlContent.AppendLine("<File_Ref_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) + "</File_Ref_No>");
               xmlContent.AppendLine("<Container_Type>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString()) + "</Container_Type>");
               xmlContent.AppendLine("<Job_Status>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["JOB_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["JOB_STATUS"].ToString()) + "</Job_Status>");
               xmlContent.AppendLine("<Job_Filed_Status>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["JOB_FILED_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["JOB_FILED_STATUS"].ToString()) + "</Job_Filed_Status>");
               xmlContent.AppendLine("<Jobno_Ps>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["JOBNO_PS"].ToString()) ? " " : dss.Tables[0].Rows[0]["JOBNO_PS"].ToString()) + "</Jobno_Ps>");
               xmlContent.AppendLine("<Completed_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMPLETED_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMPLETED_DATE"].ToString()) + "</Completed_Date>");
               xmlContent.AppendLine("<Adcode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADCODE"].ToString()) + "</Adcode>");
               xmlContent.AppendLine("<Ucr_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["UCR_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["UCR_NO"].ToString()) + "</Ucr_No>");
               xmlContent.AppendLine("<Ucr_Type>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["UCR_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["UCR_TYPE"].ToString()) + "</Ucr_Type>");
               xmlContent.AppendLine("<Payment_Method_Code>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString()) + "</Payment_Method_Code>");
               xmlContent.AppendLine("<Preceding_Level>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString()) ? " " : dss.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString()) + "</Preceding_Level>");
               xmlContent.AppendLine("<Doc_Received_Date>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["DOC_RECEIVED_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["DOC_RECEIVED_DATE"].ToString()) + "</Doc_Received_Date>");
               xmlContent.AppendLine("<Agent_Name>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["AGENT_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["AGENT_NAME"].ToString()) + "</Agent_Name>");
               xmlContent.AppendLine("<Exbond_Addl_Load_Hss>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString()) + "</Exbond_Addl_Load_Hss>");
               xmlContent.AppendLine("<Exbond_Misc_Load_Rate>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString()) + "</Exbond_Misc_Load_Rate>");
               xmlContent.AppendLine("<Gstn_Type>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) + "</Gstn_Type>");
               xmlContent.AppendLine("<Gstn_Id>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GSTN_ID"].ToString()) ? " " : dss.Tables[0].Rows[0]["GSTN_ID"].ToString()) + "</Gstn_Id>");
               xmlContent.AppendLine("<Party_Ref_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PARTY_REF_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["PARTY_REF_NO"].ToString()) + "</Party_Ref_No>");
               xmlContent.AppendLine("<Eta>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ETA"].ToString()) ? " " : dss.Tables[0].Rows[0]["ETA"].ToString()) + "</Eta>");
               xmlContent.AppendLine("<Hss_Adcode>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADCODE"].ToString()) + "</Hss_Adcode>");
               xmlContent.AppendLine("<Ice_Id>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ICE_ID"].ToString()) ? " " : dss.Tables[0].Rows[0]["ICE_ID"].ToString()) + "</Ice_Id>");
               xmlContent.AppendLine("<Cha_No>" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CHA_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["CHA_NO"].ToString()) + "</Cha_No>");

               if (dss.Tables[2].Rows.Count > 0)
               {
                   xmlContent.AppendLine("<Igm_Details>");
                   for (int rsp = 0; rsp < dss.Tables[2].Rows.Count; rsp++)
                   {
                       xmlContent.AppendLine("<Igm_Detail>");
                       xmlContent.AppendLine("<Igm_Slno>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_SLNO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_SLNO"].ToString()) + "</Igm_Slno>");
                       xmlContent.AppendLine("<Igm_Airlinecode>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_AIRLINECODE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_AIRLINECODE"].ToString()) + "</Igm_Airlinecode>");
                       xmlContent.AppendLine("<Igm_Airlinename>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_AIRLINENAME"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_AIRLINENAME"].ToString()) + "</Igm_Airlinename>");
                       xmlContent.AppendLine("<Igm_Flightno_Vesselno>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_FLIGHTNO_VESSELNO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_FLIGHTNO_VESSELNO"].ToString()) + "</Igm_Flightno_Vesselno>");
                       xmlContent.AppendLine("<Igm_Flight_Vesseldate>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"].ToString()) + "</Igm_Flight_Vesseldate>");
                       xmlContent.AppendLine("<Igm_No>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_NO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_NO"].ToString()) + "</Igm_No>");
                       xmlContent.AppendLine("<Igm_Date>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_DATE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_DATE"].ToString()) + "</Igm_Date>");
                       xmlContent.AppendLine("<Igm_Hawb_Hblno>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLNO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLNO"].ToString()) + "</Igm_Hawb_Hblno>");
                       xmlContent.AppendLine("<Igm_Hawb_Hbldate>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLDATE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLDATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLDATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Igm_Hawb_Hbldate>");
                       xmlContent.AppendLine("<Igm_Mawb_Mbl>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_MAWB_MBL"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_MAWB_MBL"].ToString()) + "</Igm_Mawb_Mbl>");
                       xmlContent.AppendLine("<Igm_Mawb_Mbldate>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_MAWB_MBLDATE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_MAWB_MBLDATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(dss.Tables[2].Rows[rsp]["IGM_MAWB_MBLDATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Igm_Mawb_Mbldate>");
                       xmlContent.AppendLine("<Igm_Noofpackage>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_NOOFPACKAGE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_NOOFPACKAGE"].ToString()) + "</Igm_Noofpackage>");
                       xmlContent.AppendLine("<Igm_Packagetype>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_PACKAGETYPE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_PACKAGETYPE"].ToString()) + "</Igm_Packagetype>");
                       xmlContent.AppendLine("<Igm_Grossweight>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_GROSSWEIGHT"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_GROSSWEIGHT"].ToString()) + "</Igm_Grossweight>");
                       xmlContent.AppendLine("<Igm_Typeofweight>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_TYPEOFWEIGHT"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_TYPEOFWEIGHT"].ToString()) + "</Igm_Typeofweight>");
                       xmlContent.AppendLine("<Igm_Netweight>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_NETWEIGHT"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_NETWEIGHT"].ToString()) + "</Igm_Netweight>");
                       xmlContent.AppendLine("<Igm_Netweighttype>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_NETWEIGHTTYPE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_NETWEIGHTTYPE"].ToString()) + "</Igm_Netweighttype>");
                       xmlContent.AppendLine("<Igm_Transportmode>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_TRANSPORTMODE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_TRANSPORTMODE"].ToString()) + "</Igm_Transportmode>");
                       xmlContent.AppendLine("<Igm_Marksnos>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_MARKSNOS"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_MARKSNOS"].ToString()) + "</Igm_Marksnos>");
                       xmlContent.AppendLine("<Igm_Gateway_Igm_No>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_GATEWAY_IGM_NO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_GATEWAY_IGM_NO"].ToString()) + "</Igm_Gateway_Igm_No>");
                       xmlContent.AppendLine("<Igm_Gateway_Igm_Date>" + (dss.Tables[2].Rows[rsp]["IGM_GATEWAY_IGM_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(dss.Tables[2].Rows[rsp]["IGM_GATEWAY_IGM_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Igm_Gateway_Igm_Date>");
                       xmlContent.AppendLine("<Igm_Gateway_Port_Code>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_TRANSPORTMODE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_TRANSPORTMODE"].ToString()) + "</Igm_Gateway_Port_Code>");
                       xmlContent.AppendLine("<Igm_Line_Number>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_LINE_NUMBER"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_LINE_NUMBER"].ToString()) + "</Igm_Line_Number>");
                       xmlContent.AppendLine("<Igm_Shipping_Line_Number>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_SHIPPING_LINE_NUMBER"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_SHIPPING_LINE_NUMBER"].ToString()) + "</Igm_Shipping_Line_Number>");
                       xmlContent.AppendLine("<Igm_Voyage>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_VOYAGE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_VOYAGE"].ToString()) + "</Igm_Voyage>");
                       xmlContent.AppendLine("<Igm_Chargeable_Wgt>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_CHARGEABLE_WGT"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_CHARGEABLE_WGT"].ToString()) + "</Igm_Chargeable_Wgt>");
                       xmlContent.AppendLine("<Rotation_No>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["ROTATION_NO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["ROTATION_NO"].ToString()) + "</Rotation_No>");
                       xmlContent.AppendLine("<Rotation_Date>" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["ROTATION_DATE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["ROTATION_DATE"].ToString()) + "</Rotation_Date>");
                       xmlContent.AppendLine("</Igm_Detail>");
                   }
                   xmlContent.AppendLine("</Igm_Details>");
               }
               else
               {
                   xmlContent.AppendLine("<Igm_Details>");
                   xmlContent.AppendLine("<Igm_Detail>");
                   xmlContent.AppendLine("<Igm_Slno>" + " " + "</Vessel>");
                   xmlContent.AppendLine("<Igm_Airlinecode>" + " " + "</Igm_Airlinecode>");
                   xmlContent.AppendLine("<Igm_Airlinename>" + " " + "</Igm_Airlinename>");
                   xmlContent.AppendLine("<Igm_Flightno_Vesselno>" + " " + "</Igm_Flightno_Vesselno>");
                   xmlContent.AppendLine("<Igm_Flight_Vesseldate>" + " " + "</Igm_Flight_Vesseldate>");
                   xmlContent.AppendLine("<Igm_No>" + " " + "</Igm_No>");
                   xmlContent.AppendLine("<Igm_Date>" + " " + "</Igm_Date>");
                   xmlContent.AppendLine("<Igm_Hawb_Hblno>" + " " + "</Igm_Hawb_Hblno>");
                   xmlContent.AppendLine("<Igm_Hawb_Hbldate>" + " " + "</Igm_Hawb_Hbldate>");
                   xmlContent.AppendLine("<Igm_Mawb_Mbl>" + " " + "</Igm_Mawb_Mbl>");
                   xmlContent.AppendLine("<Igm_Mawb_Mbldate>" + " " + "</Igm_Mawb_Mbldate>");
                   xmlContent.AppendLine("<Igm_Noofpackage>" + " " + "</Igm_Noofpackage>");
                   xmlContent.AppendLine("<Igm_Packagetype>" + " " + "</Igm_Packagetype>");
                   xmlContent.AppendLine("<Igm_Grossweight>" + " " + "</Igm_Grossweight>");
                   xmlContent.AppendLine("<Igm_Typeofweight>" + " " + "</Igm_Typeofweight>");
                   xmlContent.AppendLine("<Igm_Netweight>" + " " + "</Igm_Netweight>");
                   xmlContent.AppendLine("<Igm_Netweighttype>" + " " + "</Igm_Netweighttype>");
                   xmlContent.AppendLine("<Igm_Transportmode>" + " " + "</Igm_Transportmode>");
                   xmlContent.AppendLine("<Igm_Marksnos>" + " " + "</Igm_Marksnos>");
                   xmlContent.AppendLine("<Igm_Gateway_Igm_No>" + " " + "</Igm_Gateway_Igm_No>");
                   xmlContent.AppendLine("<Igm_Gateway_Igm_Date>" + " " + "</Igm_Gateway_Igm_Date>");
                   xmlContent.AppendLine("<Igm_Gateway_Port_Code>" + " " + "</Igm_Gateway_Port_Code>");
                   xmlContent.AppendLine("<Igm_Line_Number>" + " " + "</Igm_Line_Number>");
                   xmlContent.AppendLine("<Igm_Shipping_Line_Number>" + " " + "</Igm_Shipping_Line_Number>");
                   xmlContent.AppendLine("<Igm_Voyage>" + " " + "</Igm_Voyage>");
                   xmlContent.AppendLine("<Igm_Chargeable_Wgt>" + " " + "</Igm_Chargeable_Wgt>");
                   xmlContent.AppendLine("<Rotation_No>" + " " + "</Rotation_No>");
                   xmlContent.AppendLine("<Rotation_Date>" + " " + "</Rotation_Date>");
                   xmlContent.AppendLine("</Igm_Detail>");
                   xmlContent.AppendLine("</Igm_Details>");
               }

               if (dss.Tables[3].Rows.Count > 0)  // Loop start
               {
                   xmlContent.AppendLine("<Container_Details>");
                   for (int rsp = 0; rsp < dss.Tables[3].Rows.Count; rsp++)
                   {
                       xmlContent.AppendLine("<Container_Detail>");
                       xmlContent.AppendLine("<Container_No>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["CONTAINER_NO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["CONTAINER_NO"].ToString()) + "</Container_No>");
                       xmlContent.AppendLine("<Container_Igm_Slno>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["CONTAINER_IGM_SLNO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["CONTAINER_IGM_SLNO"].ToString()) + "</Container_Igm_Slno>");
                       xmlContent.AppendLine("<Container_Igm_No>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["CONTAINER_IGM_NO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["CONTAINER_IGM_NO"].ToString()) + "</Container_Igm_No>");
                       xmlContent.AppendLine("<Container_Igm_Date>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["CONTAINER_IGM_DATE"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["CONTAINER_IGM_DATE"].ToString()) + "</Container_Igm_Date>");
                       xmlContent.AppendLine("<Seal_No>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["SEAL_NO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["SEAL_NO"].ToString()) + "</Seal_No>");
                       xmlContent.AppendLine("<Fcl_Or_Lcl>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["FCL_OR_LCL"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["FCL_OR_LCL"].ToString()) + "</Fcl_Or_Lcl>");
                       xmlContent.AppendLine("<Type>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["TYPE"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["TYPE"].ToString()) + "</Type>");
                       xmlContent.AppendLine("<Truck_No>" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["TRUCK_NO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["TRUCK_NO"].ToString()) + "</Truck_No>");
                       xmlContent.AppendLine("</Container_Detail>");
                   }
                   xmlContent.AppendLine("</Container_Details>");
               }
               else
               {
                   xmlContent.AppendLine("<Container_Detail>");
                   xmlContent.AppendLine("<Container_No>" + " " + "</Container_No>");
                   xmlContent.AppendLine("<Container_Igm_Slno>" + " " + "</Container_Igm_Slno>");
                   xmlContent.AppendLine("<Container_Igm_No>" + " " + "</Container_Igm_No>");
                   xmlContent.AppendLine("<Container_Igm_Date>" + " " + "</Container_Igm_Date>");
                   xmlContent.AppendLine("<Seal_No>" + " " + "</Seal_No>");
                   xmlContent.AppendLine("<Fcl_Or_Lcl>" + " " + "</Fcl_Or_Lcl>");
                   xmlContent.AppendLine("<Type>" + " " + "</Type>");
                   xmlContent.AppendLine("<Truck_No>" + " " + "</Truck_No>");
                   xmlContent.AppendLine("</Container_Detail>");
               }

               if (dss.Tables[4].Rows.Count > 0)
               {
                   xmlContent.AppendLine("<Bond_Details>");

                   for (int rsp = 0; rsp < dss.Tables[4].Rows.Count; rsp++)
                   {
                       xmlContent.AppendLine("<Bond_Detail>");
                       xmlContent.AppendLine("<Bond_No>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[rsp]["BOND_NO"].ToString()) ? " " : dss.Tables[4].Rows[rsp]["BOND_NO"].ToString()) + "</Bond_No>");
                       xmlContent.AppendLine("<Bond_Type>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[rsp]["BOND_TYPE"].ToString()) ? " " : dss.Tables[4].Rows[rsp]["BOND_TYPE"].ToString()) + "</Bond_Type>");
                       xmlContent.AppendLine("<Bond_Location>" + (string.IsNullOrEmpty(dss.Tables[4].Rows[rsp]["BOND_LOCATION"].ToString()) ? " " : dss.Tables[4].Rows[rsp]["BOND_LOCATION"].ToString()) + "</Bond_Location>");
                       xmlContent.AppendLine("</Bond_Detail>");
                   }
                   xmlContent.AppendLine("</Bond_Details>");
               }
               else
               {
                   xmlContent.AppendLine("<Bond_Detail>");
                   xmlContent.AppendLine("<Bond_No>" + " " + "</Bond_No>");
                   xmlContent.AppendLine("<Bond_Type>" + " " + "</Bond_Type>");
                   xmlContent.AppendLine("<Bond_Location>" + " " + "</Bond_Location>");
                   xmlContent.AppendLine("</Bond_Detail>");
               }

               if (dss.Tables[5].Rows.Count > 0)
               {
                   xmlContent.AppendLine("<Certificate_Details>");

                   for (int rsp = 0; rsp < dss.Tables[5].Rows.Count; rsp++)
                   {
                       xmlContent.AppendLine("<Certificate_No>" + (string.IsNullOrEmpty(dss.Tables[5].Rows[rsp]["CERTIFICATE_NO"].ToString()) ? " " : dss.Tables[5].Rows[rsp]["CERTIFICATE_NO"].ToString()) + "</Certificate_No>");
                       xmlContent.AppendLine("<Certificate_Date>" + (dss.Tables[5].Rows[rsp]["CERTIFICATE_DATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[5].Rows[rsp]["CERTIFICATE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "</Certificate_Date>");
                       xmlContent.AppendLine("<Certificate_Type>" + (string.IsNullOrEmpty(dss.Tables[5].Rows[rsp]["CERTIFICATE_TYPE"].ToString()) ? " " : dss.Tables[5].Rows[rsp]["CERTIFICATE_TYPE"].ToString()) + "</Certificate_Type>");
                   }
                   xmlContent.AppendLine("</Certificate_Details>");
               }
               else
               {
                   xmlContent.AppendLine("<Certificate_Detail>");
                   xmlContent.AppendLine("<Certificate_No>" + " " + "</Certificate_No>");
                   xmlContent.AppendLine("<Certificate_Date>" + " " + "</Certificate_Date>");
                   xmlContent.AppendLine("<Certificate_Type>" + " " + "</Certificate_Type>");
                   xmlContent.AppendLine("</Certificate_Detail>");
               }

               if (dss.Tables[6].Rows.Count > 0)
               {
                   xmlContent.AppendLine("<Invoice_Details>");

                   for (int inv = 0; inv < dss.Tables[6].Rows.Count; inv++)
                   {
                       xmlContent.AppendLine("<Invoice_Detail>");

                       xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_SLNO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                       xmlContent.AppendLine("<Invoice_No>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_NO"].ToString()) + "</Invoice_No>");
                       xmlContent.AppendLine("<Invoice_Date>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_DATE"].ToString()) ? " " : (DateTime.Parse(dss.Tables[6].Rows[inv]["INVOICE_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Invoice_Date>");
                       xmlContent.AppendLine("<Terms>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["TERMS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["TERMS"].ToString()) + "</Terms>");
                       xmlContent.AppendLine("<Invoice_Currency>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_CURRENCY"].ToString()) + "</Invoice_Currency>");
                       xmlContent.AppendLine("<Invoice_Exrate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_EXRATE"].ToString()) + "</Invoice_Exrate>");
                       xmlContent.AppendLine("<Invoice_Value>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_VALUE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_VALUE"].ToString()) + "</Invoice_Value>");
                       xmlContent.AppendLine("<Supplier_Name>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_NAME"].ToString()) + "</Supplier_Name>");
                       xmlContent.AppendLine("<Supplier_Address>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS"].ToString()) + "</Supplier_Address>");
                       xmlContent.AppendLine("<Supplier_Address1>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS1"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS1"].ToString()) + "</Supplier_Address1>");
                       xmlContent.AppendLine("<Supplier_Address2>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS2"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS2"].ToString()) + "</Supplier_Address2>");
                       xmlContent.AppendLine("<Supplier_Country_Name>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_NAME"].ToString()) + "</Supplier_Country_Name>");
                       xmlContent.AppendLine("<Supplier_Country_Code>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_CODE"].ToString()) + "</Supplier_Country_Code>");
                       xmlContent.AppendLine("<Supplier_Country_Pincode>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_PINCODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_PINCODE"].ToString()) + "</Supplier_Country_Pincode>");
                       xmlContent.AppendLine("<Seller_Name>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_NAME"].ToString()) + "</Seller_Name>");
                       xmlContent.AppendLine("<Seller_Address>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_ADDRESS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_ADDRESS"].ToString()) + "</Seller_Address>");
                       xmlContent.AppendLine("<Seller_Address1>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_ADDRESS1"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_ADDRESS1"].ToString()) + "</Seller_Address1>");
                       xmlContent.AppendLine("<Seller_Address2>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_ADDRESS2"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_ADDRESS2"].ToString()) + "</Seller_Address2>");
                       xmlContent.AppendLine("<Seller_Country_Name>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_COUNTRY_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_COUNTRY_NAME"].ToString()) + "</Seller_Country_Name>");
                       xmlContent.AppendLine("<Seller_Country_Code>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_COUNTRY_CODE"].ToString()) + "</Seller_Country_Code>");
                       xmlContent.AppendLine("<Sellercountry_Pincode>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLERCOUNTRY_PINCODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLERCOUNTRY_PINCODE"].ToString()) + "</Sellercountry_Pincode>");
                       xmlContent.AppendLine("<Broker_Name>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_NAME"].ToString()) + "</Broker_Name>");
                       xmlContent.AppendLine("<Broker_Address>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_ADDRESS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_ADDRESS"].ToString()) + "</Broker_Address>");
                       xmlContent.AppendLine("<Broker_Address1>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_ADDRESS1"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_ADDRESS1"].ToString()) + "</Broker_Address1>");
                       xmlContent.AppendLine("<Broker_Address2>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_ADDRESS2"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_ADDRESS2"].ToString()) + "</Broker_Address2>");
                       xmlContent.AppendLine("<Broker_Country_Name>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_COUNTRY_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_COUNTRY_NAME"].ToString()) + "</Broker_Country_Name>");
                       xmlContent.AppendLine("<Broker_Country_Code>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_COUNTRY_CODE"].ToString()) + "</Broker_Country_Code>");
                       xmlContent.AppendLine("<Broker_Country_Pincode>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_COUNTRY_PINCODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_COUNTRY_PINCODE"].ToString()) + "</Broker_Country_Pincode>");
                       xmlContent.AppendLine("<Mis_Charges>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_CHARGES"].ToString()) + "</Mis_Charges>");
                       xmlContent.AppendLine("<Mis_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_RATE"].ToString()) + "</Mis_Rate>");
                       xmlContent.AppendLine("<Mis_Currency>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_CURRENCY"].ToString()) + "</Mis_Currency>");
                       xmlContent.AppendLine("<Mis_Exrate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_EXRATE"].ToString()) + "</Mis_Exrate>");
                       xmlContent.AppendLine("<Mis_Agency_Charges>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_AGENCY_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_AGENCY_CHARGES"].ToString()) + "</Mis_Agency_Charges>");
                       xmlContent.AppendLine("<Mis_Agency_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_AGENCY_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_AGENCY_RATE"].ToString()) + "</Mis_Agency_Rate>");
                       xmlContent.AppendLine("<Mis_Agency_Currency>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_AGENCY_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_AGENCY_CURRENCY"].ToString()) + "</Mis_Agency_Currency>");
                       xmlContent.AppendLine("<Mis_Agency_Exrate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_AGENCY_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_AGENCY_EXRATE"].ToString()) + "</Mis_Agency_Exrate>");
                       xmlContent.AppendLine("<Mis_Discount_Charges>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_CHARGES"].ToString()) + "</Mis_Discount_Charges>");
                       xmlContent.AppendLine("<Mis_Discount_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_RATE"].ToString()) + "</Mis_Discount_Rate>");
                       xmlContent.AppendLine("<Mis_Discount_Currency>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_CURRENCY"].ToString()) + "</Mis_Discount_Currency>");
                       xmlContent.AppendLine("<Mis_Discount_Exrate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_EXRATE"].ToString()) + "</Mis_Discount_Exrate>");
                       xmlContent.AppendLine("<Mis_Discount_Reason>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_REASON"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_REASON"].ToString()) + "</Mis_Discount_Reason>");
                       xmlContent.AppendLine("<Mis_Loading_Charges>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_LOADING_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_LOADING_CHARGES"].ToString()) + "</Mis_Loading_Charges>");
                       xmlContent.AppendLine("<Mis_Loading_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_LOADING_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_LOADING_RATE"].ToString()) + "</Mis_Loading_Rate>");
                       xmlContent.AppendLine("<Mis_Loading_Currency>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_LOADING_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_LOADING_CURRENCY"].ToString()) + "</Mis_Loading_Currency>");
                       xmlContent.AppendLine("<Mis_Loading_Exrate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_LOADING_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_LOADING_EXRATE"].ToString()) + "</Mis_Loading_Exrate>");
                       xmlContent.AppendLine("<Mis_Freight_Charges>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_FREIGHT_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_FREIGHT_CHARGES"].ToString()) + "</Mis_Freight_Charges>");
                       xmlContent.AppendLine("<Mis_Freight_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_FREIGHT_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_FREIGHT_RATE"].ToString()) + "</Mis_Freight_Rate>");
                       xmlContent.AppendLine("<Mis_Freight_Currency>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_FREIGHT_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_FREIGHT_CURRENCY"].ToString()) + "</Mis_Freight_Currency>");
                       xmlContent.AppendLine("<Mis_Freight_Exrate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_FREIGHT_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_FREIGHT_EXRATE"].ToString()) + "</Mis_Freight_Exrate>");
                       xmlContent.AppendLine("<Mis_Insurance_Charges>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_INSURANCE_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_INSURANCE_CHARGES"].ToString()) + "</Mis_Insurance_Charges>");
                       xmlContent.AppendLine("<Mis_Insurance_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_INSURANCE_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_INSURANCE_RATE"].ToString()) + "</Mis_Insurance_Rate>");
                       xmlContent.AppendLine("<Mis_Insurance_Currency>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_INSURANCE_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_INSURANCE_CURRENCY"].ToString()) + "</Mis_Insurance_Currency>");
                       xmlContent.AppendLine("<Mis_Insurance_Exrate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_INSURANCE_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_INSURANCE_EXRATE"].ToString()) + "</Mis_Insurance_Exrate>");
                       xmlContent.AppendLine("<Mis_Highseasale_Charges>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_CHARGES"].ToString()) + "</Mis_Highseasale_Charges>");
                       xmlContent.AppendLine("<Mis_Highseasale_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_RATE"].ToString()) + "</Mis_Highseasale_Rate>");
                       xmlContent.AppendLine("<Mis_Highseasale_Currency>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_CURRENCY"].ToString()) + "</Mis_Highseasale_Currency>");
                       xmlContent.AppendLine("<Mis_Highseasale_Exrate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_EXRATE"].ToString()) + "</Mis_Highseasale_Exrate>");
                       xmlContent.AppendLine("<Mis_Single_Or_Mulitiple>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_SINGLE_OR_MULITIPLE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_SINGLE_OR_MULITIPLE"].ToString()) + "</Mis_Single_Or_Mulitiple>");
                       xmlContent.AppendLine("<Svb_Relation>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_RELATION"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_RELATION"].ToString()) + "</Svb_Relation>");
                       xmlContent.AppendLine("<Svb_Ref_No>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_REF_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_REF_NO"].ToString()) + "</Svb_Ref_No>");
                       xmlContent.AppendLine("<Svb_Ref_Date>" + (dss.Tables[6].Rows[inv]["SVB_REF_DATE"].ToString() == "01/01/1900" ? " " : (DateTime.Parse(dss.Tables[6].Rows[inv]["SVB_REF_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Svb_Ref_Date>");
                       xmlContent.AppendLine("<Svb_Custom_House>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_CUSTOM_HOUSE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_CUSTOM_HOUSE"].ToString()) + "</Svb_Custom_House>");
                       xmlContent.AppendLine("<Svb_Loading_On>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_LOADING_ON"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_LOADING_ON"].ToString()) + "</Svb_Loading_On>");
                       xmlContent.AppendLine("<Svb_Assesable_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_ASSESABLE_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_ASSESABLE_RATE"].ToString()) + "</Svb_Assesable_Rate>");
                       xmlContent.AppendLine("<Svb_Duty_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_DUTY_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_DUTY_RATE"].ToString()) + "</Svb_Duty_Rate>");
                       xmlContent.AppendLine("<Svb_Assesable_Status>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_ASSESABLE_STATUS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_ASSESABLE_STATUS"].ToString()) + "</Svb_Assesable_Status>");
                       xmlContent.AppendLine("<Svb_Duty_Status>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_DUTY_STATUS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_DUTY_STATUS"].ToString()) + "</Svb_Duty_Status>");
                       xmlContent.AppendLine("<Other_Purchase_Order>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_PURCHASE_ORDER"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_PURCHASE_ORDER"].ToString()) + "</Other_Purchase_Order>");
                       xmlContent.AppendLine("<Other_Purchase_Order_Date>" + (dss.Tables[6].Rows[inv]["OTHER_PURCHASE_ORDER_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : (DateTime.Parse(dss.Tables[6].Rows[inv]["OTHER_PURCHASE_ORDER_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Other_Purchase_Order_Date>");
                       xmlContent.AppendLine("<Other_Contract_No>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_CONTRACT_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_CONTRACT_NO"].ToString()) + "</Other_Contract_No>");
                       xmlContent.AppendLine("<Other_Contract_Date>" + (dss.Tables[6].Rows[inv]["OTHER_CONTRACT_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : (DateTime.Parse(dss.Tables[6].Rows[inv]["OTHER_CONTRACT_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Other_Contract_Date>");
                       xmlContent.AppendLine("<Other_Loc_No>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_LOC_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_LOC_NO"].ToString()) + "</Other_Loc_No>");
                       xmlContent.AppendLine("<Other_Loc_Date>" + (dss.Tables[6].Rows[inv]["OTHER_LOC_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : (DateTime.Parse(dss.Tables[6].Rows[inv]["OTHER_LOC_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Other_Loc_Date>");
                       xmlContent.AppendLine("<Other_Nature_Of_Transaction>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_NATURE_OF_TRANSACTION"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_NATURE_OF_TRANSACTION"].ToString()) + "</Other_Nature_Of_Transaction>");
                       xmlContent.AppendLine("<Other_Terms_Of_Payment>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_TERMS_OF_PAYMENT"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_TERMS_OF_PAYMENT"].ToString()) + "</Other_Terms_Of_Payment>");
                       xmlContent.AppendLine("<Other_Conditions>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_CONDITIONS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_CONDITIONS"].ToString()) + "</Other_Conditions>");
                       xmlContent.AppendLine("<Other_Valuation_Method>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_VALUATION_METHOD"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_VALUATION_METHOD"].ToString()) + "</Other_Valuation_Method>");
                       xmlContent.AppendLine("<Branch_Code>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BRANCH_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BRANCH_CODE"].ToString()) + "</Branch_Code>");
                       xmlContent.AppendLine("<Non_Std_Effect_Dt_Imp>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["NON_STD_EFFECT_DT_IMP"].ToString()) ? " " : dss.Tables[6].Rows[inv]["NON_STD_EFFECT_DT_IMP"].ToString()) + "</Non_Std_Effect_Dt_Imp>");
                       xmlContent.AppendLine("<Non_Std_Bankname>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["NON_STD_BANKNAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["NON_STD_BANKNAME"].ToString()) + "</Non_Std_Bankname>");
                       xmlContent.AppendLine("<Non_Std_Certificate_No>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) + "</Non_Std_Certificate_No>");
                       xmlContent.AppendLine("<Non_Std_Certificate_Date>" + (dss.Tables[6].Rows[inv]["NON_STD_CERTIFICATE_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : (DateTime.Parse(dss.Tables[6].Rows[inv]["NON_STD_CERTIFICATE_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Non_Std_Certificate_Date>");
                       xmlContent.AppendLine("<Sap_Delievery_Id>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SAP_DELIEVERY_ID"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SAP_DELIEVERY_ID"].ToString()) + "</Sap_Delievery_Id>");
                       xmlContent.AppendLine("<Ship_Date>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SHIP_DATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SHIP_DATE"].ToString()) + "</Ship_Date>");
                       xmlContent.AppendLine("<Invoice_Level>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_LEVEL"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_LEVEL"].ToString()) + "</Invoice_Level>");
                       xmlContent.AppendLine("<Country_Of_Departure>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["COUNTRY_OF_DEPARTURE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["COUNTRY_OF_DEPARTURE"].ToString()) + "</Country_Of_Departure>");
                       xmlContent.AppendLine("<Revenuedeposit_Rate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["REVENUEDEPOSIT_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["REVENUEDEPOSIT_RATE"].ToString()) + "</Revenuedeposit_Rate>");
                       xmlContent.AppendLine("<Revenuedeposit_On>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["REVENUEDEPOSIT_ON"].ToString()) ? " " : dss.Tables[6].Rows[inv]["REVENUEDEPOSIT_ON"].ToString()) + "</Revenuedeposit_On>");
                       xmlContent.AppendLine("<Mi_Freight>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MI_FREIGHT"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MI_FREIGHT"].ToString()) + "</Mi_Freight>");
                       xmlContent.AppendLine("<Mi_Insurance>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MI_INSURANCE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MI_INSURANCE"].ToString()) + "</Mi_Insurance>");
                       xmlContent.AppendLine("<Mi_Misc>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MI_MISC"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MI_MISC"].ToString()) + "</Mi_Misc>");
                       xmlContent.AppendLine("<Mi_Hss>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MI_HSS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MI_HSS"].ToString()) + "</Mi_Hss>");
                       xmlContent.AppendLine("<Indev_Inv_Type>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INDEV_INV_TYPE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INDEV_INV_TYPE"].ToString()) + "</Indev_Inv_Type>");
                       xmlContent.AppendLine("<Terms_Place>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["TERMS_PLACE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["TERMS_PLACE"].ToString()) + "</Terms_Place>");
                       xmlContent.AppendLine("<Thirdparty_Name>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["THIRDPARTY_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["THIRDPARTY_NAME"].ToString()) + "</Thirdparty_Name>");
                       xmlContent.AppendLine("<Thirdparty_Add1>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["THIRDPARTY_ADD1"].ToString()) ? " " : dss.Tables[6].Rows[inv]["THIRDPARTY_ADD1"].ToString()) + "</Thirdparty_Add1>");
                       xmlContent.AppendLine("<Thirdparty_Add2>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["THIRDPARTY_ADD2"].ToString()) ? " " : dss.Tables[6].Rows[inv]["THIRDPARTY_ADD2"].ToString()) + "</Thirdparty_Add2>");
                       xmlContent.AppendLine("<Thirdparty_City>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["THIRDPARTY_CITY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["THIRDPARTY_CITY"].ToString()) + "</Thirdparty_City>");
                       xmlContent.AppendLine("<T_Party_Country_Sub_Div>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) ? " " : dss.Tables[6].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) + "</T_Party_Country_Sub_Div>");
                       xmlContent.AppendLine("<T_Party_Country_Code>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) + "</T_Party_Country_Code>");
                       xmlContent.AppendLine("<T_Party_Pin>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["T_PARTY_PIN"].ToString()) ? " " : dss.Tables[6].Rows[inv]["T_PARTY_PIN"].ToString()) + "</T_Party_Pin>");
                       xmlContent.AppendLine("<Authorized_Economic_Operator_Code>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) + "</Authorized_Economic_Operator_Code>");
                       xmlContent.AppendLine("<A_E_O_Country>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["A_E_O_COUNTRY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["A_E_O_COUNTRY"].ToString()) + "</A_E_O_Country>");
                       xmlContent.AppendLine("<Authorized_Economic_Operator>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) ? " " : dss.Tables[6].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) + "</Authorized_Economic_Operator>");
                       xmlContent.AppendLine("<Whether_Buyer_Seller_Related>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["WHETHER_BUYER_SELLER_RELATED"].ToString()) ? " " : dss.Tables[6].Rows[inv]["WHETHER_BUYER_SELLER_RELATED"].ToString()) + "</Whether_Buyer_Seller_Related>");
                       xmlContent.AppendLine("<Total_Other_Amount>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["TOTAL_OTHER_AMOUNT"].ToString()) ? " " : dss.Tables[6].Rows[inv]["TOTAL_OTHER_AMOUNT"].ToString()) + "</Total_Other_Amount>");
                       xmlContent.AppendLine("<Doc_Recd_Date>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["DOC_RECD_DATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["DOC_RECD_DATE"].ToString()) + "</Doc_Recd_Date>");
                       xmlContent.AppendLine("<Inv_Misc_T_F>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_T_F"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_T_F"].ToString()) + "</Inv_Misc_T_F>");
                       xmlContent.AppendLine("<Inv_Misc_Currency>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_CURRENCY"].ToString()) + "</Inv_Misc_Currency>");
                       xmlContent.AppendLine("<Inv_Misc_Exrate>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_EXRATE"].ToString()) + "</Inv_Misc_Exrate>");
                       xmlContent.AppendLine("<Inv_Misc_Charges>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_CHARGES"].ToString()) + "</Inv_Misc_Charges>");
                       xmlContent.AppendLine("<Inv_Misc_Total_Charges>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_TOTAL_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_TOTAL_CHARGES"].ToString()) + "</Inv_Misc_Total_Charges>");
                       xmlContent.AppendLine("<Inv_Misc_Add_Frt_Ins_Yn>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_ADD_FRT_INS_YN"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_ADD_FRT_INS_YN"].ToString()) + "</Inv_Misc_Add_Frt_Ins_Yn>");
                       xmlContent.AppendLine("<Supplier_Branch_Slno>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_BRANCH_SLNO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_BRANCH_SLNO"].ToString()) + "</Supplier_Branch_Slno>");
                       xmlContent.AppendLine("<Inv_Created_Date>" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["DATE_TIME"].ToString()) ? " " : (DateTime.Parse(dss.Tables[6].Rows[inv]["DATE_TIME"].ToString()).ToString("dd-MMM-yyyy"))) + "</Inv_Created_Date>");
                     
                       DataTable item_tbl = new DataTable();
                       item_tbl = dss.Tables[7];
                       DataView Item_view = item_tbl.DefaultView;
                       string a = dss.Tables[6].Rows[inv]["INVOICE_SLNO"].ToString();
                       Item_view.RowFilter = "INVOICE_SLNO = '" + a + "'";
                       DataTable items = Item_view.ToTable();

                       if (items.Rows.Count > 0)
                       {

                           xmlContent.AppendLine("<Item_details>");

                           for (int itm = 0; itm < items.Rows.Count; itm++)  // loop start 
                           {

                               xmlContent.AppendLine("<Item_detail>");
                               xmlContent.AppendLine("<Invoice_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["INVOICE_SLNO"].ToString()) ? " " : items.Rows[itm]["INVOICE_SLNO"].ToString()) + "</Invoice_Slno>");
                               xmlContent.AppendLine("<Item_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_SLNO"].ToString()) ? " " : items.Rows[itm]["ITEM_SLNO"].ToString()) + "</Item_Slno>");
                               xmlContent.AppendLine("<Item_Description>" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_DESCRIPTION"].ToString()) ? " " : items.Rows[itm]["ITEM_DESCRIPTION"].ToString()) + "</Item_Description>");
                               xmlContent.AppendLine("<Item_Qty>" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_QTY"].ToString()) ? " " : items.Rows[itm]["ITEM_QTY"].ToString()) + "</Item_Qty>");
                               xmlContent.AppendLine("<Item_Qty_Code>" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_QTY_CODE"].ToString()) ? " " : items.Rows[itm]["ITEM_QTY_CODE"].ToString()) + "</Item_Qty_Code>");
                               xmlContent.AppendLine("<Item_Unit_Price>" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_UNIT_PRICE"].ToString()) ? " " : items.Rows[itm]["ITEM_UNIT_PRICE"].ToString()) + "</Item_Unit_Price>");
                               xmlContent.AppendLine("<Item_Unit_Code>" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_UNIT_CODE"].ToString()) ? " " : items.Rows[itm]["ITEM_UNIT_CODE"].ToString()) + "</Item_Unit_Code>");
                               xmlContent.AppendLine("<Item_Total_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_TOTAL_AMOUNT"].ToString()) ? " " : items.Rows[itm]["ITEM_TOTAL_AMOUNT"].ToString()) + "</Item_Total_Amount>");
                               xmlContent.AppendLine("<Item_Amount_Code>" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_AMOUNT_CODE"].ToString()) ? " " : items.Rows[itm]["ITEM_AMOUNT_CODE"].ToString()) + "</Item_Amount_Code>");
                               xmlContent.AppendLine("<Cth_No>" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_NO"].ToString()) ? " " : items.Rows[itm]["CTH_NO"].ToString()) + "</Cth_No>");
                               xmlContent.AppendLine("<Scheme_Code>" + (string.IsNullOrEmpty(items.Rows[itm]["SCHEME_CODE"].ToString()) ? " " : items.Rows[itm]["SCHEME_CODE"].ToString()) + "</Scheme_Code>");
                               xmlContent.AppendLine("<Scheme_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["SCHEME_NOTN"].ToString()) ? " " : items.Rows[itm]["SCHEME_NOTN"].ToString()) + "</Scheme_Notn>");
                               xmlContent.AppendLine("<Scheme_Notn_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["SCHEME_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["SCHEME_NOTN_SLNO"].ToString()) + "</Scheme_Notn_Slno>");
                               xmlContent.AppendLine("<Cth_Qty1>" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY1"].ToString()) ? " " : items.Rows[itm]["CTH_QTY1"].ToString()) + "</Cth_Qty1>");
                               xmlContent.AppendLine("<Cth_Qty1_Code>" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY1_CODE"].ToString()) ? " " : items.Rows[itm]["CTH_QTY1_CODE"].ToString()) + "</Cth_Qty1_Code>");
                               xmlContent.AppendLine("<Cth_Qty2>" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY2"].ToString()) ? " " : items.Rows[itm]["CTH_QTY2"].ToString()) + "</Cth_Qty2>");
                               xmlContent.AppendLine("<Cth_Qty2_Code>" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY2_CODE"].ToString()) ? " " : items.Rows[itm]["CTH_QTY2_CODE"].ToString()) + "</Cth_Qty2_Code>");
                               xmlContent.AppendLine("<Genearl_Description>" + (string.IsNullOrEmpty(items.Rows[itm]["GENEARL_DESCRIPTION"].ToString()) ? " " : items.Rows[itm]["GENEARL_DESCRIPTION"].ToString()) + "</Genearl_Description>");
                               xmlContent.AppendLine("<Manufacturer>" + (string.IsNullOrEmpty(items.Rows[itm]["MANUFACTURER"].ToString()) ? " " : items.Rows[itm]["MANUFACTURER"].ToString()) + "</Manufacturer>");
                               xmlContent.AppendLine("<Brand>" + (string.IsNullOrEmpty(items.Rows[itm]["BRAND"].ToString()) ? " " : items.Rows[itm]["BRAND"].ToString()) + "</Brand>");
                               xmlContent.AppendLine("<Model>" + (string.IsNullOrEmpty(items.Rows[itm]["MODEL"].ToString()) ? " " : items.Rows[itm]["MODEL"].ToString()) + "</Model>");
                               xmlContent.AppendLine("<End_Use_Of_Item>" + (string.IsNullOrEmpty(items.Rows[itm]["END_USE_OF_ITEM"].ToString()) ? " " : items.Rows[itm]["END_USE_OF_ITEM"].ToString()) + "</End_Use_Of_Item>");
                               xmlContent.AppendLine("<Country_Of_Origin>" + (string.IsNullOrEmpty(items.Rows[itm]["COUNTRY_OF_ORIGIN"].ToString()) ? " " : items.Rows[itm]["COUNTRY_OF_ORIGIN"].ToString()) + "</Country_Of_Origin>");
                               xmlContent.AppendLine("<Accessories>" + (string.IsNullOrEmpty(items.Rows[itm]["ACCESSORIES"].ToString()) ? " " : items.Rows[itm]["ACCESSORIES"].ToString()) + "</Accessories>");
                               xmlContent.AppendLine("<Previous_Be_No>" + (string.IsNullOrEmpty(items.Rows[itm]["PREVIOUS_BE_NO"].ToString()) ? " " : items.Rows[itm]["PREVIOUS_BE_NO"].ToString()) + "</Previous_Be_No>");
                               xmlContent.AppendLine("<Previous_Be_Date>" + (items.Rows[itm]["PREVIOUS_BE_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : (DateTime.Parse(items.Rows[itm]["PREVIOUS_BE_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Previous_Be_Date>");
                               xmlContent.AppendLine("<Unit_Price>" + (string.IsNullOrEmpty(items.Rows[itm]["UNIT_PRICE"].ToString()) ? " " : items.Rows[itm]["UNIT_PRICE"].ToString()) + "</Unit_Price>");
                               xmlContent.AppendLine("<Unit_Code>" + (string.IsNullOrEmpty(items.Rows[itm]["UNIT_CODE"].ToString()) ? " " : items.Rows[itm]["UNIT_CODE"].ToString()) + "</Unit_Code>");
                               xmlContent.AppendLine("<Product_Ritc>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_RITC"].ToString()) ? " " : items.Rows[itm]["PRODUCT_RITC"].ToString()) + "</Product_Ritc>");
                               xmlContent.AppendLine("<Product_Cth>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CTH"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CTH"].ToString()) + "</Product_Cth>");
                               xmlContent.AppendLine("<Product_Bcd_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_NOTN"].ToString()) + "</Product_Bcd_Notn>");
                               xmlContent.AppendLine("<Product_Bcd_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_SLNO"].ToString()) + "</Product_Bcd_Slno>");
                               xmlContent.AppendLine("<Product_Bcd_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_RATE"].ToString()) + "</Product_Bcd_Rate>");
                               xmlContent.AppendLine("<Product_Bcd_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_SPL"].ToString()) + "</Product_Bcd_Spl>");
                               xmlContent.AppendLine("<Product_Bcd_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_UNIT"].ToString()) + "</Product_Bcd_Unit>");
                               xmlContent.AppendLine("<Product_Bcd_Spl_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_SPL_TYPE"].ToString()) + "</Product_Bcd_Spl_Type>");
                               xmlContent.AppendLine("<Product_Addl_Duty_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_DUTY_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_DUTY_NOTN"].ToString()) + "</Product_Addl_Duty_Notn>");
                               xmlContent.AppendLine("<Product_Addl_Duty_Notn_Sl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString()) + "</Product_Addl_Duty_Notn_Sl>");
                               xmlContent.AppendLine("<Product_Addl_Duty_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_DUTY_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_DUTY_RATE"].ToString()) + "</Product_Addl_Duty_Rate>");
                               xmlContent.AppendLine("<Product_Edu_Cess_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_EDU_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_EDU_CESS_NOTN"].ToString()) + "</Product_Edu_Cess_Notn>");
                               xmlContent.AppendLine("<Product_Edu_Cess_Notn_Sl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_EDU_CESS_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_EDU_CESS_NOTN_SL"].ToString()) + "</Product_Edu_Cess_Notn_Sl>");
                               xmlContent.AppendLine("<Product_Edu_Cess_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_EDU_CESS_RATE"].ToString()) + "</Product_Edu_Cess_Rate>");
                               xmlContent.AppendLine("<Product_Sec_Edu_Cess_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString()) + "</Product_Sec_Edu_Cess_Notn>");
                               xmlContent.AppendLine("<Product_Sec_Edu_Cess_Notn_Sl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString()) + "</Product_Sec_Edu_Cess_Notn_Sl>");
                               xmlContent.AppendLine("<Product_Sec_Edu_Cess_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SEC_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SEC_EDU_CESS_RATE"].ToString()) + "</Product_Sec_Edu_Cess_Rate>");
                               xmlContent.AppendLine("<Product_Ncd_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_NOTN"].ToString()) + "</Product_Ncd_Notn>");
                               xmlContent.AppendLine("<Product_Ncd_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_SLNO"].ToString()) + "</Product_Ncd_Slno>");
                               xmlContent.AppendLine("<Product_Ncd_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_RATE"].ToString()) + "</Product_Ncd_Rate>");
                               xmlContent.AppendLine("<Product_Ncd_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_SPL"].ToString()) + "</Product_Ncd_Spl>");
                               xmlContent.AppendLine("<Product_Ncd_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_UNIT"].ToString()) + "</Product_Ncd_Unit>");
                               xmlContent.AppendLine("<Product_Ncd_Spl_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_SPL_TYPE"].ToString()) + "</Product_Ncd_Spl_Type>");
                               xmlContent.AppendLine("<Product_Aggregate_Duty_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString()) + "</Product_Aggregate_Duty_Notn>");
                               xmlContent.AppendLine("<Product_Aggregate_Duty_Notn_Sl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString()) + "</Product_Aggregate_Duty_Notn_Sl>");
                               xmlContent.AppendLine("<Product_Aggregate_Duty_Notn_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString()) + "</Product_Aggregate_Duty_Notn_Rate>");
                               xmlContent.AppendLine("<Product_Safeguard_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_NOTN"].ToString()) + "</Product_Safeguard_Notn>");
                               xmlContent.AppendLine("<Product_Safeguard_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_SLNO"].ToString()) + "</Product_Safeguard_Slno>");
                               xmlContent.AppendLine("<Product_Safeguard_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_RATE"].ToString()) + "</Product_Safeguard_Rate>");
                               xmlContent.AppendLine("<Product_Safeguard_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_SPL"].ToString()) + "</Product_Safeguard_Spl>");
                               xmlContent.AppendLine("<Product_Safeguard_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_UNIT"].ToString()) + "</Product_Safeguard_Unit>");
                               xmlContent.AppendLine("<Product_Safeguard_Spl_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString()) + "</Product_Safeguard_Spl_Type>");
                               xmlContent.AppendLine("<Product_Sapta_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAPTA_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAPTA_NOTN"].ToString()) + "</Product_Sapta_Notn>");
                               xmlContent.AppendLine("<Product_Sapta_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAPTA_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAPTA_SLNO"].ToString()) + "</Product_Sapta_Slno>");
                               xmlContent.AppendLine("<Product_Sapta_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAPTA_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAPTA_RATE"].ToString()) + "</Product_Sapta_Rate>");
                               xmlContent.AppendLine("<Product_Tariff_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_NOTN"].ToString()) + "</Product_Tariff_Notn>");
                               xmlContent.AppendLine("<Product_Tariff_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_SLNO"].ToString()) + "</Product_Tariff_Slno>");
                               xmlContent.AppendLine("<Product_Tariff_Qty>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_QTY"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_QTY"].ToString()) + "</Product_Tariff_Qty>");
                               xmlContent.AppendLine("<Product_Tariff_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_AMOUNT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_AMOUNT"].ToString()) + "</Product_Tariff_Amount>");
                               xmlContent.AppendLine("<Product_Tariff_Amount_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString()) + "</Product_Tariff_Amount_Unit>");
                               xmlContent.AppendLine("<Product_Ceth>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CETH"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CETH"].ToString()) + "</Product_Ceth>");
                               xmlContent.AppendLine("<Product_Mrp_Yn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_MRP_YN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_MRP_YN"].ToString()) + "</Product_Mrp_Yn>");
                               xmlContent.AppendLine("<Product_Mrp_Sl_No>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_MRP_SL_NO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_MRP_SL_NO"].ToString()) + "</Product_Mrp_Sl_No>");
                               xmlContent.AppendLine("<Product_Mrp_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_MRP_AMOUNT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_MRP_AMOUNT"].ToString()) + "</Product_Mrp_Amount>");
                               xmlContent.AppendLine("<Product_Mrp_Abt_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_MRP_ABT_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_MRP_ABT_RATE"].ToString()) + "</Product_Mrp_Abt_Rate>");
                               xmlContent.AppendLine("<Product_Cvd_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_NOTN"].ToString()) + "</Product_Cvd_Notn>");
                               xmlContent.AppendLine("<Product_Cvd_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_SLNO"].ToString()) + "</Product_Cvd_Slno>");
                               xmlContent.AppendLine("<Product_Cvd_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_RATE"].ToString()) + "</Product_Cvd_Rate>");
                               xmlContent.AppendLine("<Product_Cvd_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_SPL"].ToString()) + "</Product_Cvd_Spl>");
                               xmlContent.AppendLine("<Product_Cvd_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_UNIT"].ToString()) + "</Product_Cvd_Unit>");
                               xmlContent.AppendLine("<Product_Cvd_Spl_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_SPL_TYPE"].ToString()) + "</Product_Cvd_Spl_Type>");
                               xmlContent.AppendLine("<Product_Cvd_Edu_Cess_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_EDU_CESS_RATE"].ToString()) + "</Product_Cvd_Edu_Cess_Rate>");
                               xmlContent.AppendLine("<Product_Cvd_Sec_Edu_Cess_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString()) + "</Product_Cvd_Sec_Edu_Cess_Rate>");
                               xmlContent.AppendLine("<Product_Addl5_Sia_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL5_SIA_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL5_SIA_NOTN"].ToString()) + "</Product_Addl5_Sia_Notn>");
                               xmlContent.AppendLine("<Product_Addl5_Sia_Notn_Sl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString()) + "</Product_Addl5_Sia_Notn_Sl>");
                               xmlContent.AppendLine("<Product_Addl5_Sia_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL5_SIA_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL5_SIA_RATE"].ToString()) + "</Product_Addl5_Sia_Rate>");
                               xmlContent.AppendLine("<Product_Addl_Gsi_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_NOTN"].ToString()) + "</Product_Addl_Gsi_Notn>");
                               xmlContent.AppendLine("<Product_Addl_Gsi_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_SLNO"].ToString()) + "</Product_Addl_Gsi_Slno>");
                               xmlContent.AppendLine("<Product_Addl_Gsi_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_RATE"].ToString()) + "</Product_Addl_Gsi_Rate>");
                               xmlContent.AppendLine("<Product_Addl_Gsi_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_SPL"].ToString()) + "</Product_Addl_Gsi_Spl>");
                               xmlContent.AppendLine("<Product_Addl_Gsi_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_UNIT"].ToString()) + "</Product_Addl_Gsi_Unit>");
                               xmlContent.AppendLine("<Product_Addl_Gsi_Spl_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString()) + "</Product_Addl_Gsi_Spl_Type>");
                               xmlContent.AppendLine("<Product_Addl_Sheii_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_NOTN"].ToString()) + "</Product_Addl_Sheii_Notn>");
                               xmlContent.AppendLine("<Product_Addl_Sheii_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_SLNO"].ToString()) + "</Product_Addl_Sheii_Slno>");
                               xmlContent.AppendLine("<Product_Addl_Sheii_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_RATE"].ToString()) + "</Product_Addl_Sheii_Rate>");
                               xmlContent.AppendLine("<Product_Addl_Sheii_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_SPL"].ToString()) + "</Product_Addl_Sheii_Spl>");
                               xmlContent.AppendLine("<Product_Addl_Sheii_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_UNIT"].ToString()) + "</Product_Addl_Sheii_Unit>");
                               xmlContent.AppendLine("<Product_Addl_Sheii_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_TYPE"].ToString()) + "</Product_Addl_Sheii_Type>");
                               xmlContent.AppendLine("<Product_Addl_Tta_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_NOTN"].ToString()) + "</Product_Addl_Tta_Notn>");
                               xmlContent.AppendLine("<Product_Addl_Tta_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_SLNO"].ToString()) + "</Product_Addl_Tta_Slno>");
                               xmlContent.AppendLine("<Product_Addl_Tta_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_RATE"].ToString()) + "</Product_Addl_Tta_Rate>");
                               xmlContent.AppendLine("<Product_Addl_Tta_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_SPL"].ToString()) + "</Product_Addl_Tta_Spl>");
                               xmlContent.AppendLine("<Product_Addl_Tta_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_UNIT"].ToString()) + "</Product_Addl_Tta_Unit>");
                               xmlContent.AppendLine("<Product_Addl_Tta_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_TYPE"].ToString()) + "</Product_Addl_Tta_Type>");
                               xmlContent.AppendLine("<Product_Addl_Health_Cess_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString()) + "</Product_Addl_Health_Cess_Notn>");
                               xmlContent.AppendLine("<Product_Addl_Health_Cess_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString()) + "</Product_Addl_Health_Cess_Slno>");
                               xmlContent.AppendLine("<Product_Addl_Health_Cess_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString()) + "</Product_Addl_Health_Cess_Rate>");
                               xmlContent.AppendLine("<Product_Addl_Health_Cess_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString()) + "</Product_Addl_Health_Cess_Spl>");
                               xmlContent.AppendLine("<Product_Addl_Health_Cess_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString()) + "</Product_Addl_Health_Cess_Unit>");
                               xmlContent.AppendLine("<Product_Addl_Health_Cess_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString()) + "</Product_Addl_Health_Cess_Type>");
                               xmlContent.AppendLine("<Product_Cess_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_NOTN"].ToString()) + "</Product_Cess_Notn>");
                               xmlContent.AppendLine("<Product_Cess_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_SLNO"].ToString()) + "</Product_Cess_Slno>");
                               xmlContent.AppendLine("<Product_Cess_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_RATE"].ToString()) + "</Product_Cess_Rate>");
                               xmlContent.AppendLine("<Product_Cess_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_SPL"].ToString()) + "</Product_Cess_Spl>");
                               xmlContent.AppendLine("<Product_Cess_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_UNIT"].ToString()) + "</Product_Cess_Unit>");
                               xmlContent.AppendLine("<Product_Cess_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_TYPE"].ToString()) + "</Product_Cess_Type>");
                               xmlContent.AppendLine("<Anti_Dumping_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["ANTI_DUMPING_NOTN"].ToString()) ? " " : items.Rows[itm]["ANTI_DUMPING_NOTN"].ToString()) + "</Anti_Dumping_Notn>");
                               xmlContent.AppendLine("<Anti_Dumping_Notn_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["ANTI_DUMPING_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["ANTI_DUMPING_NOTN_SLNO"].ToString()) + "</Anti_Dumping_Notn_Slno>");
                               xmlContent.AppendLine("<Cth_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_SLNO"].ToString()) ? " " : items.Rows[itm]["CTH_SLNO"].ToString()) + "</Cth_Slno>");
                               xmlContent.AppendLine("<Cth_Supplier_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_SUPPLIER_SLNO"].ToString()) ? " " : items.Rows[itm]["CTH_SUPPLIER_SLNO"].ToString()) + "</Cth_Supplier_Slno>");
                               xmlContent.AppendLine("<Cth_Qty>" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY"].ToString()) ? " " : items.Rows[itm]["CTH_QTY"].ToString()) + "</Cth_Qty>");
                               xmlContent.AppendLine("<Rsp_Duty_Status>" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_DUTY_STATUS"].ToString()) ? " " : items.Rows[itm]["RSP_DUTY_STATUS"].ToString()) + "</Rsp_Duty_Status>");
                               xmlContent.AppendLine("<Rsp_Sl_No>" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_SL_NO"].ToString()) ? " " : items.Rows[itm]["RSP_SL_NO"].ToString()) + "</Rsp_Sl_No>");
                               xmlContent.AppendLine("<Rsp_Desc>" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_DESC"].ToString()) ? " " : items.Rows[itm]["RSP_DESC"].ToString()) + "</Rsp_Desc>");
                               xmlContent.AppendLine("<Rsp_Qty>" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_QTY"].ToString()) ? " " : items.Rows[itm]["RSP_QTY"].ToString()) + "</Rsp_Qty>");
                               xmlContent.AppendLine("<Rsp_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_AMOUNT"].ToString()) ? " " : items.Rows[itm]["RSP_AMOUNT"].ToString()) + "</Rsp_Amount>");
                               xmlContent.AppendLine("<Rsp_Notn_No>" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_NOTN_NO"].ToString()) ? " " : items.Rows[itm]["RSP_NOTN_NO"].ToString()) + "</Rsp_Notn_No>");
                               xmlContent.AppendLine("<Rsp_Notn_Sl_No>" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_NOTN_SL_NO"].ToString()) ? " " : items.Rows[itm]["RSP_NOTN_SL_NO"].ToString()) + "</Rsp_Notn_Sl_No>");
                               xmlContent.AppendLine("<Rsp_Abt_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_ABT_RATE"].ToString()) ? " " : items.Rows[itm]["RSP_ABT_RATE"].ToString()) + "</Rsp_Abt_Rate>");
                               xmlContent.AppendLine("<Warehouse_Jobno>" + (string.IsNullOrEmpty(items.Rows[itm]["WAREHOUSE_JOBNO"].ToString()) ? " " : items.Rows[itm]["WAREHOUSE_JOBNO"].ToString()) + "</Warehouse_Jobno>");
                               xmlContent.AppendLine("<Warehouse_Invoice_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["WAREHOUSE_INVOICE_SLNO"].ToString()) ? " " : items.Rows[itm]["WAREHOUSE_INVOICE_SLNO"].ToString()) + "</Warehouse_Invoice_Slno>");
                               xmlContent.AppendLine("<Warehouse_Item_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["WAREHOUSE_ITEM_SLNO"].ToString()) ? " " : items.Rows[itm]["WAREHOUSE_ITEM_SLNO"].ToString()) + "</Warehouse_Item_Slno>");
                               xmlContent.AppendLine("<Assessable_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["ASSESSABLE_VALUE"].ToString()) ? " " : items.Rows[itm]["ASSESSABLE_VALUE"].ToString()) + "</Assessable_Value>");
                               xmlContent.AppendLine("<Duty_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["DUTY_VALUE"].ToString()) + "</Duty_Value>");
                               xmlContent.AppendLine("<Cif_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["CIF_VALUE"].ToString()) ? " " : items.Rows[itm]["CIF_VALUE"].ToString()) + "</Cif_Value>");
                               xmlContent.AppendLine("<Cvd_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["CVD_VALUE"].ToString()) ? " " : items.Rows[itm]["CVD_VALUE"].ToString()) + "</Cvd_Value>");
                               xmlContent.AppendLine("<Basic_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["BASIC_VALUE"].ToString()) ? " " : items.Rows[itm]["BASIC_VALUE"].ToString()) + "</Basic_Value>");
                               xmlContent.AppendLine("<Cec_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["CEC_VALUE"].ToString()) ? " " : items.Rows[itm]["CEC_VALUE"].ToString()) + "</Cec_Value>");
                               xmlContent.AppendLine("<Chec_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["CHEC_VALUE"].ToString()) ? " " : items.Rows[itm]["CHEC_VALUE"].ToString()) + "</Chec_Value>");
                               xmlContent.AppendLine("<Add_Duty_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["ADD_DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["ADD_DUTY_VALUE"].ToString()) + "</Add_Duty_Value>");
                               xmlContent.AppendLine("<Ceth_Cvd_Edu_Cess_Sl>" + (string.IsNullOrEmpty(items.Rows[itm]["CETH_CVD_EDU_CESS_SL"].ToString()) ? " " : items.Rows[itm]["CETH_CVD_EDU_CESS_SL"].ToString()) + "</Ceth_Cvd_Edu_Cess_Sl>");
                               xmlContent.AppendLine("<Ceth_Cvd_Edu_Cess_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["CETH_CVD_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["CETH_CVD_EDU_CESS_RATE"].ToString()) + "</Ceth_Cvd_Edu_Cess_Rate>");
                               xmlContent.AppendLine("<Ceth_Cvd_Sec_Edu_Cess_Sl>" + (string.IsNullOrEmpty(items.Rows[itm]["CETH_CVD_SEC_EDU_CESS_SL"].ToString()) ? " " : items.Rows[itm]["CETH_CVD_SEC_EDU_CESS_SL"].ToString()) + "</Ceth_Cvd_Sec_Edu_Cess_Sl>");
                               xmlContent.AppendLine("<Ceth_Cvd_Sec_Edu_Cess_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString()) + "</Ceth_Cvd_Sec_Edu_Cess_Rate>");
                               xmlContent.AppendLine("<Product_Other_Duty_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_NOTN"].ToString()) + "</Product_Other_Duty_Notn>");
                               xmlContent.AppendLine("<Product_Other_Duty_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_SLNO"].ToString()) + "</Product_Other_Duty_Slno>");
                               xmlContent.AppendLine("<Product_Other_Duty_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_RATE"].ToString()) + "</Product_Other_Duty_Rate>");
                               xmlContent.AppendLine("<Product_Other_Duty_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_SPL"].ToString()) + "</Product_Other_Duty_Spl>");
                               xmlContent.AppendLine("<Product_Other_Duty_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_UNIT"].ToString()) + "</Product_Other_Duty_Unit>");
                               xmlContent.AppendLine("<Product_Other_Duty_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_TYPE"].ToString()) + "</Product_Other_Duty_Type>");
                               xmlContent.AppendLine("<Indivitual_Freight_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_FREIGHT_AMOUNT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_FREIGHT_AMOUNT"].ToString()) + "</Indivitual_Freight_Amount>");
                               xmlContent.AppendLine("<Indivitual_Insurance_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_INSURANCE_AMOUNT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_INSURANCE_AMOUNT"].ToString()) + "</Indivitual_Insurance_Amount>");
                               xmlContent.AppendLine("<Indivitual_Misc_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_MISC_AMOUNT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_MISC_AMOUNT"].ToString()) + "</Indivitual_Misc_Amount>");
                               xmlContent.AppendLine("<Svb_Relation>" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_RELATION"].ToString()) ? " " : items.Rows[itm]["SVB_RELATION"].ToString()) + "</Svb_Relation>");
                               xmlContent.AppendLine("<Svb_Ref_No>" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_REF_NO"].ToString()) ? " " : items.Rows[itm]["SVB_REF_NO"].ToString()) + "</Svb_Ref_No>");
                               xmlContent.AppendLine("<Svb_Ref_Date>" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_REF_NO"].ToString()) ? " " : items.Rows[inv]["SVB_REF_DATE"].ToString() == "01/01/1900" ? " " : (DateTime.Parse(items.Rows[itm]["SVB_REF_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</Svb_Ref_Date>");
                               xmlContent.AppendLine("<Svb_Custom_House>" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_CUSTOM_HOUSE"].ToString()) ? " " : items.Rows[itm]["SVB_CUSTOM_HOUSE"].ToString()) + "</Svb_Custom_House>");
                               xmlContent.AppendLine("<Svb_Loading_On>" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_LOADING_ON"].ToString()) ? " " : items.Rows[itm]["SVB_LOADING_ON"].ToString()) + "</Svb_Loading_On>");
                               xmlContent.AppendLine("<Svb_Assesable_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_ASSESABLE_RATE"].ToString()) ? " " : items.Rows[itm]["SVB_ASSESABLE_RATE"].ToString()) + "</Svb_Assesable_Rate>");
                               xmlContent.AppendLine("<Svb_Duty_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_DUTY_RATE"].ToString()) ? " " : items.Rows[itm]["SVB_DUTY_RATE"].ToString()) + "</Svb_Duty_Rate>");
                               xmlContent.AppendLine("<Svb_Assesable_Status>" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_ASSESABLE_STATUS"].ToString()) ? " " : items.Rows[itm]["SVB_ASSESABLE_STATUS"].ToString()) + "</Svb_Assesable_Status>");
                               xmlContent.AppendLine("<Svb_Duty_Status>" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_DUTY_STATUS"].ToString()) ? " " : items.Rows[itm]["SVB_DUTY_STATUS"].ToString()) + "</Svb_Duty_Status>");
                               xmlContent.AppendLine("<Indivitual_Edu_Cess_Amt>" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_EDU_CESS_AMT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_EDU_CESS_AMT"].ToString()) + "</Indivitual_Edu_Cess_Amt>");
                               xmlContent.AppendLine("<Indivitual_Sec_Higher_Cess_Amt>" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_SEC_HIGHER_CESS_AMT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_SEC_HIGHER_CESS_AMT"].ToString()) + "</Indivitual_Sec_Higher_Cess_Amt>");
                               xmlContent.AppendLine("<Indivitual_Landing_Charge>" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_LANDING_CHARGE"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_LANDING_CHARGE"].ToString()) + "</Indivitual_Landing_Charge>");
                               xmlContent.AppendLine("<Checklist_Bcd_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_BCD_RATE"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_BCD_RATE"].ToString()) + "</Checklist_Bcd_Rate>");
                               xmlContent.AppendLine("<Checklist_Cvd_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_CVD_RATE"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_CVD_RATE"].ToString()) + "</Checklist_Cvd_Rate>");
                               xmlContent.AppendLine("<Checklist_Addl_Duty_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_ADDL_DUTY_RATE"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_ADDL_DUTY_RATE"].ToString()) + "</Checklist_Addl_Duty_Rate>");
                               xmlContent.AppendLine("<Indev_Rack_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["INDEV_RACK_TYPE"].ToString()) ? " " : items.Rows[itm]["INDEV_RACK_TYPE"].ToString()) + "</Indev_Rack_Type>");
                               xmlContent.AppendLine("<Merit_Duty_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_DUTY_VALUE"].ToString()) + "</Merit_Duty_Value>");
                               xmlContent.AppendLine("<Rsp_Applicable>" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_APPLICABLE"].ToString()) ? " " : items.Rows[itm]["RSP_APPLICABLE"].ToString()) + "</Rsp_Applicable>");
                               xmlContent.AppendLine("<Central_Excise_Flag>" + (string.IsNullOrEmpty(items.Rows[itm]["CENTRAL_EXCISE_FLAG"].ToString()) ? " " : items.Rows[itm]["CENTRAL_EXCISE_FLAG"].ToString()) + "</Central_Excise_Flag>");
                               xmlContent.AppendLine("<Manufacturer_Producer>" + (string.IsNullOrEmpty(items.Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) ? " " : items.Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) + "</Manufacturer_Producer>");
                               xmlContent.AppendLine("<M_P_Grower_Code>" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_CODE"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_CODE"].ToString()) + "</M_P_Grower_Code>");
                               xmlContent.AppendLine("<M_P_Grower_Add1>" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_ADD1"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_ADD1"].ToString()) + "</M_P_Grower_Add1>");
                               xmlContent.AppendLine("<M_P_Grower_Add2>" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_ADD2"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_ADD2"].ToString()) + "</M_P_Grower_Add2>");
                               xmlContent.AppendLine("<M_P_Grower_City>" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_CITY"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_CITY"].ToString()) + "</M_P_Grower_City>");
                               xmlContent.AppendLine("<M_P_Grower_Country_Subdiv>" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) + "</M_P_Grower_Country_Subdiv>");
                               xmlContent.AppendLine("<M_P_Grower_Pin>" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_PIN"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_PIN"].ToString()) + "</M_P_Grower_Pin>");
                               xmlContent.AppendLine("<M_P_Grower_Country>" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_COUNTRY"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_COUNTRY"].ToString()) + "</M_P_Grower_Country>");
                               xmlContent.AppendLine("<Source_Country>" + (string.IsNullOrEmpty(items.Rows[itm]["SOURCE_COUNTRY"].ToString()) ? " " : items.Rows[itm]["SOURCE_COUNTRY"].ToString()) + "</Source_Country>");
                               xmlContent.AppendLine("<Transit_Country>" + (string.IsNullOrEmpty(items.Rows[itm]["TRANSIT_COUNTRY"].ToString()) ? " " : items.Rows[itm]["TRANSIT_COUNTRY"].ToString()) + "</Transit_Country>");
                               xmlContent.AppendLine("<Accessory_Status>" + (string.IsNullOrEmpty(items.Rows[itm]["ACCESSORY_STATUS"].ToString()) ? " " : items.Rows[itm]["ACCESSORY_STATUS"].ToString()) + "</Accessory_Status>");
                               xmlContent.AppendLine("<Infra_Cess_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["INFRA_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["INFRA_CESS_NOTN"].ToString()) + "</Infra_Cess_Notn>");
                               xmlContent.AppendLine("<Infra_Cess_Notn_Sl>" + (string.IsNullOrEmpty(items.Rows[itm]["INFRA_CESS_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["INFRA_CESS_NOTN_SL"].ToString()) + "</Infra_Cess_Notn_Sl>");
                               xmlContent.AppendLine("<Infra_Cess_Notn_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["INFRA_CESS_NOTN_RATE"].ToString()) ? " " : items.Rows[itm]["INFRA_CESS_NOTN_RATE"].ToString()) + "</Infra_Cess_Notn_Rate>");
                               xmlContent.AppendLine("<Merit_Basic_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_BASIC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_BASIC_VALUE"].ToString()) + "</Merit_Basic_Value>");
                               xmlContent.AppendLine("<Merit_Cvd_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_CVD_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_CVD_VALUE"].ToString()) + "</Merit_Cvd_Value>");
                               xmlContent.AppendLine("<Merit_Cec_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_CEC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_CEC_VALUE"].ToString()) + "</Merit_Cec_Value>");
                               xmlContent.AppendLine("<Merit_Chec_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_CHEC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_CHEC_VALUE"].ToString()) + "</Merit_Chec_Value>");
                               xmlContent.AppendLine("<Merit_Add_Duty_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_ADD_DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_ADD_DUTY_VALUE"].ToString()) + "</Merit_Add_Duty_Value>");
                               xmlContent.AppendLine("<Merit_Notn_Basic_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_BASIC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_BASIC_VALUE"].ToString()) + "</Merit_Notn_Basic_Value>");
                               xmlContent.AppendLine("<Merit_Notn_Cvd_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_CVD_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_CVD_VALUE"].ToString()) + "</Merit_Notn_Cvd_Value>");
                               xmlContent.AppendLine("<Merit_Notn_Cec_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_CEC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_CEC_VALUE"].ToString()) + "</Merit_Notn_Cec_Value>");
                               xmlContent.AppendLine("<Merit_Notn_Chec_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_CHEC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_CHEC_VALUE"].ToString()) + "</Merit_Notn_Chec_Value>");
                               xmlContent.AppendLine("<Merit_Notn_Add_Duty_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_ADD_DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_ADD_DUTY_VALUE"].ToString()) + "</Merit_Notn_Add_Duty_Value>");
                               xmlContent.AppendLine("<Merit_Notn_Cess_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_CESS_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_CESS_VALUE"].ToString()) + "</Merit_Notn_Cess_Value>");
                               xmlContent.AppendLine("<Merit_Notn_Ncd_Value>" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_NCD_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_NCD_VALUE"].ToString()) + "</Merit_Notn_Ncd_Value>");
                               xmlContent.AppendLine("<Indivitual_Hss_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_HSS_AMOUNT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_HSS_AMOUNT"].ToString()) + "</Indivitual_Hss_Amount>");
                               xmlContent.AppendLine("<Igst_Levy_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_NOTN"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_NOTN"].ToString()) + "</Igst_Levy_Notn>");
                               xmlContent.AppendLine("<Igst_Levy_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_SLNO"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_SLNO"].ToString()) + "</Igst_Levy_Slno>");
                               xmlContent.AppendLine("<Igst_Levy_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_RATE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_RATE"].ToString()) + "</Igst_Levy_Rate>");
                               xmlContent.AppendLine("<Igst_Levy_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_SPL"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_SPL"].ToString()) + "</Igst_Levy_Spl>");
                               xmlContent.AppendLine("<Igst_Levy_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_UNIT"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_UNIT"].ToString()) + "</Igst_Levy_Unit>");
                               xmlContent.AppendLine("<Igst_Levy_Spl_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_SPL_TYPE"].ToString()) + "</Igst_Levy_Spl_Type>");
                               xmlContent.AppendLine("<Igst_Levy_Exception_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_NOTN"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_NOTN"].ToString()) + "</Igst_Levy_Exception_Notn>");
                               xmlContent.AppendLine("<Igst_Levy_Exception_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_SLNO"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_SLNO"].ToString()) + "</Igst_Levy_Exception_Slno>");
                               xmlContent.AppendLine("<Igst_Levy_Exception_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_RATE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_RATE"].ToString()) + "</Igst_Levy_Exception_Rate>");
                               xmlContent.AppendLine("<Igst_Levy_Compensation_Cess_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString()) + "</Igst_Levy_Compensation_Cess_Notn>");
                               xmlContent.AppendLine("<Igst_Levy_Compensation_Cess_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString()) + "</Igst_Levy_Compensation_Cess_Slno>");
                               xmlContent.AppendLine("<Igst_Levy_Compensation_Cess_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString()) + "</Igst_Levy_Compensation_Cess_Rate>");
                               xmlContent.AppendLine("<Igst_Levy_Compensation_Cess_Spl>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString()) + "</Igst_Levy_Compensation_Cess_Spl>");
                               xmlContent.AppendLine("<Igst_Levy_Compensation_Cess_Unit>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString()) + "</Igst_Levy_Compensation_Cess_Unit>");
                               xmlContent.AppendLine("<Igst_Levy_Compensation_Cess_Spl_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"].ToString()) + "</Igst_Levy_Compensation_Cess_Spl_Type>");
                               xmlContent.AppendLine("<Igst_Levy_Exception_Cc_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString()) + "</Igst_Levy_Exception_Cc_Notn>");
                               xmlContent.AppendLine("<Igst_Levy_Exception_Cc_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString()) + "</Igst_Levy_Exception_Cc_Slno>");
                               xmlContent.AppendLine("<Igst_Levy_Exception_Cc_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString()) + "</Igst_Levy_Exception_Cc_Rate>");
                               xmlContent.AppendLine("<Levy_Excemption_Notn_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString()) ? " " : items.Rows[itm]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString()) + "</Levy_Excemption_Notn_Type>");
                               xmlContent.AppendLine("<Levy_Exception_Cc_Notn_Type>" + (string.IsNullOrEmpty(items.Rows[itm]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString()) ? " " : items.Rows[itm]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString()) + "</Levy_Exception_Cc_Notn_Type>");
                               xmlContent.AppendLine("<Checklist_Igst_Levy_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_IGST_LEVY_AMOUNT"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_IGST_LEVY_AMOUNT"].ToString()) + "</Checklist_Igst_Levy_Amount>");
                               xmlContent.AppendLine("<Checklist_Compensation_Cc_Amount>" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_COMPENSATION_CC_AMOUNT"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_COMPENSATION_CC_AMOUNT"].ToString()) + "</Checklist_Compensation_Cc_Amount>");
                               xmlContent.AppendLine("<Social_Welfare_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["SOCIAL_WELFARE_NOTN"].ToString()) ? " " : items.Rows[itm]["SOCIAL_WELFARE_NOTN"].ToString()) + "</Social_Welfare_Notn>");
                               xmlContent.AppendLine("<Social_Welfare_Notn_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["SOCIAL_WELFARE_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["SOCIAL_WELFARE_NOTN_SLNO"].ToString()) + "</Social_Welfare_Notn_Slno>");
                               xmlContent.AppendLine("<Social_Welfare_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["SOCIAL_WELFARE_RATE"].ToString()) ? " " : items.Rows[itm]["SOCIAL_WELFARE_RATE"].ToString()) + "</Social_Welfare_Rate>");
                               xmlContent.AppendLine("<Checklist_Social_Welfare_Amt>" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_SOCIAL_WELFARE_AMT"].ToString()) ? " " : items.Rows[inv]["CHECKLIST_SOCIAL_WELFARE_AMT"].ToString()) + "</Checklist_Social_Welfare_Amt>");
                               xmlContent.AppendLine("<Checklist_Health_Cess_Amt>" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_HEALTH_CESS_AMT"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_HEALTH_CESS_AMT"].ToString()) + "</Checklist_Health_Cess_Amt>");
                               xmlContent.AppendLine("<Checklist_Anti_Dumping_Amt>" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_ANTI_DUMPING_AMT"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_ANTI_DUMPING_AMT"].ToString()) + "</Checklist_Anti_Dumping_Amt>");
                               xmlContent.AppendLine("<Aidc_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["AIDC_NOTN"].ToString()) ? " " : items.Rows[itm]["AIDC_NOTN"].ToString()) + "</Aidc_Notn>");
                               xmlContent.AppendLine("<Aidc_Notn_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["AIDC_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["AIDC_NOTN_SLNO"].ToString()) + "</Aidc_Notn_Slno>");
                               xmlContent.AppendLine("<Aidc_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["AIDC_RATE"].ToString()) ? " " : items.Rows[itm]["AIDC_RATE"].ToString()) + "</Aidc_Rate>");
                               xmlContent.AppendLine("<Aidc_Checklist_Amt>" + (string.IsNullOrEmpty(items.Rows[itm]["AIDC_CHECKLIST_AMT"].ToString()) ? " " : items.Rows[itm]["AIDC_CHECKLIST_AMT"].ToString()) + "</Aidc_Checklist_Amt>");
                               xmlContent.AppendLine("<Add_Ex_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["ADD_EX_RATE"].ToString()) ? " " : items.Rows[itm]["ADD_EX_RATE"].ToString()) + "</Add_Ex_Rate>");
                               xmlContent.AppendLine("<Exc_Aidc_Notn>" + (string.IsNullOrEmpty(items.Rows[itm]["EXC_AIDC_NOTN"].ToString()) ? " " : items.Rows[itm]["EXC_AIDC_NOTN"].ToString()) + "</Exc_Aidc_Notn>");
                               xmlContent.AppendLine("<Exc_Aidc_Notn_Slno>" + (string.IsNullOrEmpty(items.Rows[itm]["EXC_AIDC_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["EXC_AIDC_NOTN_SLNO"].ToString()) + "</Exc_Aidc_Notn_Slno>");
                               xmlContent.AppendLine("<Exc_Aidc_Rate>" + (string.IsNullOrEmpty(items.Rows[itm]["EXC_AIDC_RATE"].ToString()) ? " " : items.Rows[itm]["EXC_AIDC_RATE"].ToString()) + "</Exc_Aidc_Rate>");
                               xmlContent.AppendLine("<Exc_Aidc_Checklist_Amt>" + (string.IsNullOrEmpty(items.Rows[itm]["EXC_AIDC_CHECKLIST_AMT"].ToString()) ? " " : items.Rows[itm]["EXC_AIDC_CHECKLIST_AMT"].ToString()) + "</Exc_Aidc_Checklist_Amt>");
                               xmlContent.AppendLine("<Chk_Igst_Assbl_Val>" + (string.IsNullOrEmpty(items.Rows[itm]["CHK_IGST_ASSBL_VAL"].ToString()) ? " " : items.Rows[itm]["CHK_IGST_ASSBL_VAL"].ToString()) + "</Chk_Igst_Assbl_Val>");
                               xmlContent.AppendLine("<Bcd_Foregone_Amt>" + (string.IsNullOrEmpty(items.Rows[itm]["BCD_FOREGONE_AMT"].ToString()) ? " " : items.Rows[itm]["BCD_FOREGONE_AMT"].ToString()) + "</Bcd_Foregone_Amt>");
                               xmlContent.AppendLine("<Total_Duty_Foregone_Amt>" + (string.IsNullOrEmpty(items.Rows[itm]["TOTAL_DUTY_FOREGONE_AMT"].ToString()) ? " " : items.Rows[itm]["TOTAL_DUTY_FOREGONE_AMT"].ToString()) + "</Total_Duty_Foregone_Amt>");
                               xmlContent.AppendLine("<Itm_Created_Date>" + (string.IsNullOrEmpty(items.Rows[itm]["DATE_TIME"].ToString()) ? " " : (DateTime.Parse(items.Rows[itm]["DATE_TIME"].ToString()).ToString("dd-MMM-yyyy"))) + "</Itm_Created_Date>");
                     
                               DataTable lic_tbl = new DataTable();
                               lic_tbl = dss.Tables[8];
                               DataView Lic_view = lic_tbl.DefaultView;
                               //string inv_slno = dss.Tables[7].Rows[itm]["INVOICE_SLNO"].ToString();
                               string item_slno = items.Rows[itm]["ITEM_SLNO"].ToString();

                               Lic_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable License = Lic_view.ToTable();

                               if (License.Rows.Count > 0)
                               {
                                   xmlContent.AppendLine("<License_details>"); // Loop start 
                                   for (int lic = 0; lic < License.Rows.Count; lic++)
                                   {
                                       xmlContent.AppendLine("<License_detail>");
                                       xmlContent.AppendLine("<License_Slno>" + (string.IsNullOrEmpty(License.Rows[lic]["LICENSE_SLNO"].ToString()) ? " " : License.Rows[lic]["LICENSE_SLNO"].ToString()) + "</License_Slno>");
                                       xmlContent.AppendLine("<Scheme_Code>" + (string.IsNullOrEmpty(License.Rows[lic]["SCHEME_CODE"].ToString()) ? " " : License.Rows[lic]["SCHEME_CODE"].ToString()) + "</Scheme_Code>");
                                       xmlContent.AppendLine("<Registration_No>" + (string.IsNullOrEmpty(License.Rows[lic]["REGISTRATION_NO"].ToString()) ? " " : License.Rows[lic]["REGISTRATION_NO"].ToString()) + "</Registration_No>");
                                       xmlContent.AppendLine("<Registration_Date>" + (string.IsNullOrEmpty(License.Rows[lic]["REGISTRATION_DATE"].ToString()) ? " " : License.Rows[lic]["REGISTRATION_DATE"].ToString()) + "</Registration_Date>");
                                       xmlContent.AppendLine("<Excemption>" + (string.IsNullOrEmpty(License.Rows[lic]["EXCEMPTION"].ToString()) ? " " : License.Rows[lic]["EXCEMPTION"].ToString()) + "</Excemption>");
                                       xmlContent.AppendLine("<Debit_Amt>" + (string.IsNullOrEmpty(License.Rows[lic]["DEBIT_AMT"].ToString()) ? " " : License.Rows[lic]["DEBIT_AMT"].ToString()) + "</Debit_Amt>");
                                       xmlContent.AppendLine("<Debit_Qty>" + (string.IsNullOrEmpty(License.Rows[lic]["DEBIT_QTY"].ToString()) ? " " : License.Rows[lic]["DEBIT_QTY"].ToString()) + "</Debit_Qty>");
                                       xmlContent.AppendLine("<Unit_Qty>" + (string.IsNullOrEmpty(License.Rows[lic]["UNIT_QTY"].ToString()) ? " " : License.Rows[lic]["UNIT_QTY"].ToString()) + "</Unit_Qty>");
                                       xmlContent.AppendLine("<Port_Of_License>" + (string.IsNullOrEmpty(License.Rows[lic]["PORT_OF_LICENSE"].ToString()) ? " " : License.Rows[lic]["PORT_OF_LICENSE"].ToString()) + "</Port_Of_License>");
                                       xmlContent.AppendLine("<Debit_Duty>" + (string.IsNullOrEmpty(License.Rows[lic]["DEBIT_DUTY"].ToString()) ? " " : License.Rows[lic]["DEBIT_DUTY"].ToString()) + "</Debit_Duty>");
                                       xmlContent.AppendLine("<License_No>" + (string.IsNullOrEmpty(License.Rows[lic]["LICENSE_NO"].ToString()) ? " " : License.Rows[lic]["LICENSE_NO"].ToString()) + "</License_No>");
                                       xmlContent.AppendLine("<License_Date>" + (string.IsNullOrEmpty(License.Rows[lic]["LICENSE_DATE"].ToString()) ? " " : License.Rows[lic]["LICENSE_DATE"].ToString()) + "</License_Date>");
                                       xmlContent.AppendLine("<Total_Cif_Value>" + (string.IsNullOrEmpty(License.Rows[lic]["TOTAL_CIF_VALUE"].ToString()) ? " " : License.Rows[lic]["TOTAL_CIF_VALUE"].ToString()) + "</Total_Cif_Value>");
                                       xmlContent.AppendLine("<Total_Debit_Duty>" + (string.IsNullOrEmpty(License.Rows[lic]["TOTAL_DEBIT_DUTY"].ToString()) ? " " : License.Rows[lic]["TOTAL_DEBIT_DUTY"].ToString()) + "</Total_Debit_Duty>");
                                       xmlContent.AppendLine("<Entry_Debit_Duty>" + (string.IsNullOrEmpty(License.Rows[lic]["ENTRY_DEBIT_DUTY"].ToString()) ? " " : License.Rows[lic]["ENTRY_DEBIT_DUTY"].ToString()) + "</Entry_Debit_Duty>");
                                       xmlContent.AppendLine("<Lic_Desc>" + (string.IsNullOrEmpty(License.Rows[lic]["LIC_DESC"].ToString()) ? " " : License.Rows[lic]["LIC_DESC"].ToString()) + "</Lic_Desc>");
                                       xmlContent.AppendLine("<License_Currency>" + (string.IsNullOrEmpty(License.Rows[lic]["LICENSE_CURRENCY"].ToString()) ? " " : License.Rows[lic]["LICENSE_CURRENCY"].ToString()) + "</License_Currency>");
                                       xmlContent.AppendLine("<Ex_Rate>" + (string.IsNullOrEmpty(License.Rows[lic]["EX_RATE"].ToString()) ? " " : License.Rows[lic]["EX_RATE"].ToString()) + "</Ex_Rate>");
                                       xmlContent.AppendLine("<Jobno_Ps>" + (string.IsNullOrEmpty(License.Rows[lic]["JOBNO_PS"].ToString()) ? " " : License.Rows[lic]["JOBNO_PS"].ToString()) + "</Jobno_Ps>");
                                       xmlContent.AppendLine("</License_detail>");
                                   }
                                   xmlContent.AppendLine("</License_details>");
                               }
                               else
                               {
                                   xmlContent.AppendLine("<License_detail>");
                                   xmlContent.AppendLine("<License_Slno>" + " " + "</License_Slno>");
                                   xmlContent.AppendLine("<Scheme_Code>" + " " + "</Scheme_Code>");
                                   xmlContent.AppendLine("<Registration_No>" + " " + "</Registration_No>");
                                   xmlContent.AppendLine("<Registration_Date>" + " " + "</Registration_Date>");
                                   xmlContent.AppendLine("<Excemption>" + " " + "</Excemption>");
                                   xmlContent.AppendLine("<Debit_Amt>" + " " + "</Debit_Amt>");
                                   xmlContent.AppendLine("<Debit_Qty>" + " " + "</Debit_Qty>");
                                   xmlContent.AppendLine("<Unit_Qty>" + " " + "</Unit_Qty>");
                                   xmlContent.AppendLine("<Port_Of_License>" + " " + "</Port_Of_License>");
                                   xmlContent.AppendLine("<Debit_Duty>" + " " + "</Debit_Duty>");
                                   xmlContent.AppendLine("<License_No>" + " " + "</License_No>");
                                   xmlContent.AppendLine("<License_Date>" + " " + "</License_Date>");
                                   xmlContent.AppendLine("<Total_Cif_Value>" + " " + "</Total_Cif_Value>");
                                   xmlContent.AppendLine("<Total_Debit_Duty>" + " " + "</Total_Debit_Duty>");
                                   xmlContent.AppendLine("<Entry_Debit_Duty>" + " " + "</Entry_Debit_Duty>");
                                   xmlContent.AppendLine("<Lic_Desc>" + " " + "</Lic_Desc>");
                                   xmlContent.AppendLine("<License_Currency>" + " " + "</License_Currency>");
                                   xmlContent.AppendLine("<Ex_Rate>" + " " + "</Ex_Rate>");
                                   xmlContent.AppendLine("<Jobno_Ps>" + " " + "</Jobno_Ps>");
                                   xmlContent.AppendLine("</License_detail>");
                               }

                               DataTable Sw_const_tbl = new DataTable();
                               Sw_const_tbl = dss.Tables[9];
                               DataView Sw_const_view = Sw_const_tbl.DefaultView;
                               Sw_const_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_Const = Sw_const_view.ToTable();

                               if (Sw_Const.Rows.Count > 0)
                               {
                                   xmlContent.AppendLine("<SW_details>"); // Loop start 
                                   for (int sw_const = 0; sw_const < Sw_Const.Rows.Count; sw_const++)
                                   {
                                       xmlContent.AppendLine("<SW_Const>");
                                       xmlContent.AppendLine("<Constituent_Srno>" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_SRNO"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_SRNO"].ToString()) + "</Constituent_Srno>");
                                       xmlContent.AppendLine("<Constituent_Element_Name>" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_ELEMENT_NAME"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_ELEMENT_NAME"].ToString()) + "</Constituent_Element_Name>");
                                       xmlContent.AppendLine("<Constituent_Element_Code>" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_ELEMENT_CODE"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_ELEMENT_CODE"].ToString()) + "</Constituent_Element_Code>");
                                       xmlContent.AppendLine("<Constituent_Percentage>" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_PERCENTAGE"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_PERCENTAGE"].ToString()) + "</Constituent_Percentage>");
                                       xmlContent.AppendLine("<Constituent_Yield_Percentage>" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString()) + "</Constituent_Yield_Percentage>");
                                       xmlContent.AppendLine("<Active_Ingredient>" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["ACTIVE_INGREDIENT"].ToString()) ? " " : Sw_Const.Rows[sw_const]["ACTIVE_INGREDIENT"].ToString()) + "</Active_Ingredient>");
                                       xmlContent.AppendLine("</SW_Const>");
                                   }
                               }

                               else
                               {
                                   xmlContent.AppendLine("<SW_details>"); // Loop start 
                                   xmlContent.AppendLine("<SW_Const>");
                                   xmlContent.AppendLine("<Constituent_Srno>" + " " + "</Constituent_Srno>");
                                   xmlContent.AppendLine("<Constituent_Element_Name>" + " " + "</Constituent_Element_Name>");
                                   xmlContent.AppendLine("<Constituent_Element_Code>" + " " + "</Constituent_Element_Code>");
                                   xmlContent.AppendLine("<Constituent_Percentage>" + " " + "</Constituent_Percentage>");
                                   xmlContent.AppendLine("<Constituent_Yield_Percentage>" + " " + "</Constituent_Yield_Percentage>");
                                   xmlContent.AppendLine("<Active_Ingredient>" + " " + "</Active_Ingredient>");
                                   xmlContent.AppendLine("</SW_Const>");
                               }

                               DataTable Sw_cont_tbl = new DataTable();
                               Sw_cont_tbl = dss.Tables[10];
                               DataView Sw_cont_view = Sw_cont_tbl.DefaultView;
                               Sw_cont_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_Contrl = Sw_cont_view.ToTable();

                               if (Sw_Contrl.Rows.Count > 0)
                               {
                                   for (int sw_control = 0; sw_control < Sw_Contrl.Rows.Count; sw_control++)
                                   {
                                       xmlContent.AppendLine("<SW_Control_Detail>");
                                       xmlContent.AppendLine("<Control_Type_Code>" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_TYPE_CODE"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_TYPE_CODE"].ToString()) + "</Control_Type_Code>");
                                       xmlContent.AppendLine("<Control_Location>" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_LOCATION"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_LOCATION"].ToString()) + "</Control_Location>");
                                       xmlContent.AppendLine("<Control_Start_Date>" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_START_DATE"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_START_DATE"].ToString()) + "</Control_Start_Date>");
                                       xmlContent.AppendLine("<Control_End_Date>" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_END_DATE"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_END_DATE"].ToString()) + "</Control_End_Date>");
                                       xmlContent.AppendLine("<Control_Result_Code>" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_RESULT_CODE"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_RESULT_CODE"].ToString()) + "</Control_Result_Code>");
                                       xmlContent.AppendLine("<Control_Result_Text>" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_RESULT_TEXT"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_RESULT_TEXT"].ToString()) + "</Control_Result_Text>");
                                       xmlContent.AppendLine("<Control_Msr>" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_MSR"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_MSR"].ToString()) + "</Control_Msr>");
                                       xmlContent.AppendLine("<Control_Uqc>" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_UQC"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_UQC"].ToString()) + "</Control_Uqc>");
                                       xmlContent.AppendLine("<Control_Slno>" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_SLNO"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_SLNO"].ToString()) + "</Control_Slno>");
                                       xmlContent.AppendLine("</SW_Control_Detail>");
                                   }
                               }

                               else
                               {
                                   xmlContent.AppendLine("<SW_Control_Detail>");
                                   xmlContent.AppendLine("<Control_Type_Code>" + " " + "</Control_Type_Code>");
                                   xmlContent.AppendLine("<Control_Location>" + " " + "</Control_Location>");
                                   xmlContent.AppendLine("<Control_Start_Date>" + " " + "</Control_Start_Date>");
                                   xmlContent.AppendLine("<Control_End_Date>" + " " + "</Control_End_Date>");
                                   xmlContent.AppendLine("<Control_Result_Code>" + " " + "</Control_Result_Code>");
                                   xmlContent.AppendLine("<Control_Result_Text>" + " " + "</Control_Result_Text>");
                                   xmlContent.AppendLine("<Control_Msr>" + " " + "</Control_Msr>");
                                   xmlContent.AppendLine("<Control_Uqc>" + " " + "</Control_Uqc>");
                                   xmlContent.AppendLine("<Control_Slno>" + " " + "</Control_Slno>");
                                   xmlContent.AppendLine("</SW_Control_Detail>");
                               }

                               DataTable Sw_info_tbl = new DataTable();
                               Sw_info_tbl = dss.Tables[11];
                               DataView Sw_info_view = Sw_info_tbl.DefaultView;
                               Sw_info_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_Infotbl = Sw_info_view.ToTable();

                               if (Sw_Infotbl.Rows.Count > 0)
                               {
                                   for (int sw_info = 0; sw_info < Sw_Infotbl.Rows.Count; sw_info++)
                                   {
                                       xmlContent.AppendLine("<SW_Info_Detail>");
                                       xmlContent.AppendLine("<Info_Type>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_TYPE"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_TYPE"].ToString()) + "</Info_Type>");
                                       xmlContent.AppendLine("<Info_Qualifier>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_QUALIFIER"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_QUALIFIER"].ToString()) + "</Info_Qualifier>");
                                       xmlContent.AppendLine("<Info_Code>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_CODE"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_CODE"].ToString()) + "</Info_Code>");
                                       xmlContent.AppendLine("<Info_Text>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_TEXT"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_TEXT"].ToString()) + "</Info_Text>");
                                       xmlContent.AppendLine("<Info_Msr>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_MSR"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_MSR"].ToString()) + "</Info_Msr>");
                                       xmlContent.AppendLine("<Info_Uqc>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_UQC"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_UQC"].ToString()) + "</Info_Uqc>");
                                       xmlContent.AppendLine("<Department>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["DEPARTMENT"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["DEPARTMENT"].ToString()) + "</Department>");
                                       xmlContent.AppendLine("<I_U_Type>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["I_U_TYPE"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["I_U_TYPE"].ToString()) + "</I_U_Type>");
                                       xmlContent.AppendLine("<Regn_Date>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["REGN_DATE"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["REGN_DATE"].ToString()) + "</Regn_Date>");
                                       xmlContent.AppendLine("<Regn_Validity>" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["REGN_VALIDITY"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["REGN_VALIDITY"].ToString()) + "</Regn_Validity>");
                                       xmlContent.AppendLine("</SW_Info_Detail>");
                                   }
                               }

                               else
                               {
                                   xmlContent.AppendLine("<SW_Info_Detail>");
                                   xmlContent.AppendLine("<Info_Type>" + " " + "</Info_Type>");
                                   xmlContent.AppendLine("<Info_Qualifier>" + " " + "</Info_Qualifier>");
                                   xmlContent.AppendLine("<Info_Code>" + " " + "</Info_Code>");
                                   xmlContent.AppendLine("<Info_Text>" + " " + "</Info_Text>");
                                   xmlContent.AppendLine("<Info_Msr>" + " " + "</Info_Msr>");
                                   xmlContent.AppendLine("<Info_Uqc>" + " " + "</Info_Uqc>");
                                   xmlContent.AppendLine("<Department>" + " " + "</Department>");
                                   xmlContent.AppendLine("<I_U_Type>" + " " + "</I_U_Type>");
                                   xmlContent.AppendLine("<Regn_Date>" + " " + "</Regn_Date>");
                                   xmlContent.AppendLine("<Regn_Validity>" + " " + "</Regn_Validity>");
                                   xmlContent.AppendLine("</SW_Info_Detail>");

                               }

                               DataTable Sw_prod_tbl = new DataTable();
                               Sw_prod_tbl = dss.Tables[12];
                               DataView Sw_prod_view = Sw_prod_tbl.DefaultView;
                               Sw_prod_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_prodtbl = Sw_prod_view.ToTable();

                               if (Sw_prodtbl.Rows.Count > 0)
                               {
                                   for (int sw_prod = 0; sw_prod < Sw_prodtbl.Rows.Count; sw_prod++)
                                   {
                                       xmlContent.AppendLine("<SW_Prod_Detail>");
                                       xmlContent.AppendLine("<Production_Batch_Identifier>" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString()) + "</Production_Batch_Identifier>");
                                       xmlContent.AppendLine("<Production_Batch_Quantity>" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["PRODUCTION_BATCH_QUANTITY"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["PRODUCTION_BATCH_QUANTITY"].ToString()) + "</Production_Batch_Quantity>");
                                       xmlContent.AppendLine("<Date_Of_Manufacturing>" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["DATE_OF_MANUFACTURING"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["DATE_OF_MANUFACTURING"].ToString()) + "</Date_Of_Manufacturing>");
                                       xmlContent.AppendLine("<Date_Of_Expiry>" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["DATE_OF_EXPIRY"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["DATE_OF_EXPIRY"].ToString()) + "</Date_Of_Expiry>");
                                       xmlContent.AppendLine("<Best_Before>" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["BEST_BEFORE"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["BEST_BEFORE"].ToString()) + "</Best_Before>");
                                       xmlContent.AppendLine("<Residual_Shelf_Life_Days>" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["RESIDUAL_SHELF_LIFE_DAYS"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["RESIDUAL_SHELF_LIFE_DAYS"].ToString()) + "</Residual_Shelf_Life_Days>");
                                       xmlContent.AppendLine("<Total_Shelf_Life_Days>" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["TOTAL_SHELF_LIFE_DAYS"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["TOTAL_SHELF_LIFE_DAYS"].ToString()) + "</Total_Shelf_Life_Days>");
                                       xmlContent.AppendLine("<Residual_Shelf_Percent>" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["RESIDUAL_SHELF_PERCENT"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["RESIDUAL_SHELF_PERCENT"].ToString()) + "</Residual_Shelf_Percent>");
                                       xmlContent.AppendLine("</SW_Prod_Detail>");
                                   }
                                   xmlContent.AppendLine("<SW_details>");
                               }
                               else
                               {
                                   xmlContent.AppendLine("<SW_Prod_Detail>");
                                   xmlContent.AppendLine("<Production_Batch_Identifier>" + " " + "</Production_Batch_Identifier>");
                                   xmlContent.AppendLine("<Production_Batch_Quantity>" + " " + "</Production_Batch_Quantity>");
                                   xmlContent.AppendLine("<Date_Of_Manufacturing>" + " " + "</Date_Of_Manufacturing>");
                                   xmlContent.AppendLine("<Date_Of_Expiry>" + " " + "</Date_Of_Expiry>");
                                   xmlContent.AppendLine("<Best_Before>" + " " + "</Best_Before>");
                                   xmlContent.AppendLine("<Residual_Shelf_Life_Days>" + " " + "</Residual_Shelf_Life_Days>");
                                   xmlContent.AppendLine("<Total_Shelf_Life_Days>" + " " + "</Total_Shelf_Life_Days>");
                                   xmlContent.AppendLine("<Residual_Shelf_Percent>" + " " + "</Residual_Shelf_Percent>");
                                   xmlContent.AppendLine("</SW_Prod_Detail>");
                                   xmlContent.AppendLine("</SW_details>");
                               }

                               DataTable Sw_sup_tbl = new DataTable();
                               Sw_sup_tbl = dss.Tables[13];
                               DataView Sw_sup_view = Sw_sup_tbl.DefaultView;
                               Sw_sup_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_suptbl = Sw_sup_view.ToTable();

                               if (Sw_suptbl.Rows.Count > 0)
                               {
                                   xmlContent.AppendLine("<SW_SupDoc_Details>");
                                   for (int sw_sup = 0; sw_sup < Sw_suptbl.Rows.Count; sw_sup++)
                                   {
                                       xmlContent.AppendLine("<SW_SupDoc_Detail>");
                                       xmlContent.AppendLine("<Declaration_Type>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DECLARATION_TYPE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DECLARATION_TYPE"].ToString()) + "</Declaration_Type>");
                                       xmlContent.AppendLine("<Image_Ref_Number>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["IMAGE_REF_NUMBER"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["IMAGE_REF_NUMBER"].ToString()) + "</Image_Ref_Number>");
                                       xmlContent.AppendLine("<Doc_Type_Code>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_TYPE_CODE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_TYPE_CODE"].ToString()) + "</Doc_Type_Code>");
                                       xmlContent.AppendLine("<Doc_Issuing_Party_Code>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_CODE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_CODE"].ToString()) + "</Doc_Issuing_Party_Code>");
                                       xmlContent.AppendLine("<Doc_Issuing_Party_Name>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME"].ToString()) + "</Doc_Issuing_Party_Name>");
                                       xmlContent.AppendLine("<Doc_Issuing_Party_Name_Add1>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString()) + "</Doc_Issuing_Party_Name_Add1>");
                                       xmlContent.AppendLine("<Doc_Issuing_Party_Name_Add2>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString()) + "</Doc_Issuing_Party_Name_Add2>");
                                       xmlContent.AppendLine("<Doc_Issuing_Party_City>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_CITY"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_CITY"].ToString()) + "</Doc_Issuing_Party_City>");
                                       xmlContent.AppendLine("<Doc_Issuing_Party_Pin>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_PIN"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_PIN"].ToString()) + "</Doc_Issuing_Party_Pin>");
                                       xmlContent.AppendLine("<Doc_Ref_Number>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_REF_NUMBER"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_REF_NUMBER"].ToString()) + "</Doc_Ref_Number>");
                                       xmlContent.AppendLine("<Place_Of_Issue>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["PLACE_OF_ISSUE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["PLACE_OF_ISSUE"].ToString()) + "</Place_Of_Issue>");
                                       xmlContent.AppendLine("<Doc_Issue_Date>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUE_DATE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUE_DATE"].ToString()) + "</Doc_Issue_Date>");
                                       xmlContent.AppendLine("<Doc_Expiry_Date>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_EXPIRY_DATE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_EXPIRY_DATE"].ToString()) + "</Doc_Expiry_Date>");
                                       xmlContent.AppendLine("<Beneficiary_Party_Code>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_CODE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_CODE"].ToString()) + "</Beneficiary_Party_Code>");
                                       xmlContent.AppendLine("<Beneficiary_Party_Name>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_NAME"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_NAME"].ToString()) + "</Beneficiary_Party_Name>");
                                       xmlContent.AppendLine("<Beneficiary_Party_Address1>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_ADDRESS1"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_ADDRESS1"].ToString()) + "</Beneficiary_Party_Address1>");
                                       xmlContent.AppendLine("<Beneficiary_Party_Address2>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_ADDRESS2"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_ADDRESS2"].ToString()) + "</Beneficiary_Party_Address2>");
                                       xmlContent.AppendLine("<Beneficiary_Party_City>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_CITY"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_CITY"].ToString()) + "</Beneficiary_Party_City>");
                                       xmlContent.AppendLine("<Beneficiary_Party_Pin>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_PIN"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_PIN"].ToString()) + "</Beneficiary_Party_Pin>");
                                       xmlContent.AppendLine("<File_Type>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["FILE_TYPE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["FILE_TYPE"].ToString()) + "</File_Type>");
                                       xmlContent.AppendLine("<Select_Type>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["SELECT_TYPE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["SELECT_TYPE"].ToString()) + "</Select_Type>");
                                       xmlContent.AppendLine("<Icegate_Id>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["ICEGATE_ID"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["ICEGATE_ID"].ToString()) + "</Icegate_Id>");
                                       xmlContent.AppendLine("<Icegate_Doc_File_Name>" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["ICEGATE_DOC_FILE_NAME"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["ICEGATE_DOC_FILE_NAME"].ToString()) + "</Icegate_Doc_File_Name>");
                                       xmlContent.AppendLine("</SW_SupDoc_Detail>");
                                   }
                                   xmlContent.AppendLine("</SW_SupDoc_Details>");
                               }
                               else
                               {
                                   xmlContent.AppendLine("<SW_SupDoc_Details>");
                                   xmlContent.AppendLine("<SW_SupDoc_Detail>");
                                   xmlContent.AppendLine("<Declaration_Type>" + " " + "</Declaration_Type>");
                                   xmlContent.AppendLine("<Image_Ref_Number>" + " " + "</Image_Ref_Number>");
                                   xmlContent.AppendLine("<Doc_Type_Code>" + " " + "</Doc_Type_Code>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Code>" + " " + "</Doc_Issuing_Party_Code>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Name>" + " " + "</Doc_Issuing_Party_Name>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Name_Add1>" + " " + "</Doc_Issuing_Party_Name_Add1>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Name_Add2>" + " " + "</Doc_Issuing_Party_Name_Add2>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_City>" + " " + "</Doc_Issuing_Party_City>");
                                   xmlContent.AppendLine("<Doc_Issuing_Party_Pin>" + " " + "</Doc_Issuing_Party_Pin>");
                                   xmlContent.AppendLine("<Doc_Ref_Number>" + " " + "</Doc_Ref_Number>");
                                   xmlContent.AppendLine("<Place_Of_Issue>" + " " + "</Place_Of_Issue>");
                                   xmlContent.AppendLine("<Doc_Issue_Date>" + " " + "</Doc_Issue_Date>");
                                   xmlContent.AppendLine("<Doc_Expiry_Date>" + " " + "</Doc_Expiry_Date>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Code>" + " " + "</Beneficiary_Party_Code>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Name>" + " " + "</Beneficiary_Party_Name>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Address1>" + " " + "</Beneficiary_Party_Address1>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Address2>" + " " + "</Beneficiary_Party_Address2>");
                                   xmlContent.AppendLine("<Beneficiary_Party_City>" + " " + "</Beneficiary_Party_City>");
                                   xmlContent.AppendLine("<Beneficiary_Party_Pin>" + " " + "</Beneficiary_Party_Pin>");
                                   xmlContent.AppendLine("<File_Type>" + " " + "</File_Type>");
                                   xmlContent.AppendLine("<Select_Type>" + " " + "</Select_Type>");
                                   xmlContent.AppendLine("<Icegate_Id>" + " " + "</Icegate_Id>");
                                   xmlContent.AppendLine("<Icegate_Doc_File_Name>" + " " + "</Icegate_Doc_File_Name>");
                                   xmlContent.AppendLine("</SW_SupDoc_Detail>");
                                   xmlContent.AppendLine("</SW_SupDoc_Details>");
                               }

                               DataTable Sw_state_tbl = new DataTable();
                               Sw_state_tbl = dss.Tables[14];
                               DataView Sw_state_view = Sw_state_tbl.DefaultView;
                               Sw_state_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_statetbl = Sw_state_view.ToTable();

                               if (Sw_statetbl.Rows.Count > 0)
                               {
                                   xmlContent.AppendLine("<SW_Statement_Details>");
                                   for (int sw_state = 0; sw_state < Sw_statetbl.Rows.Count; sw_state++)
                                   {
                                       xmlContent.AppendLine("<SW_Statement_Detail>");
                                       xmlContent.AppendLine("<Stmt_Declaration_Type>" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_TYPE"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_TYPE"].ToString()) + "</Stmt_Declaration_Type>");
                                       xmlContent.AppendLine("<Stmt_Declaration_Number>" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_NUMBER"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_NUMBER"].ToString()) + "</Stmt_Declaration_Number>");
                                       xmlContent.AppendLine("<Stmt_Declaration_Date>" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_DATE"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_DATE"].ToString()) + "</Stmt_Declaration_Date>");
                                       xmlContent.AppendLine("<Stmt_Type>" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_TYPE"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_TYPE"].ToString()) + "</Stmt_Type>");
                                       xmlContent.AppendLine("<Stmt_Code>" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_CODE"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_CODE"].ToString()) + "</Stmt_Code>");
                                       xmlContent.AppendLine("<Stmt_Text>" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_TEXT"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_TEXT"].ToString()) + "</Stmt_Text>");
                                       xmlContent.AppendLine("</SW_Statement_Detail>");
                                   }
                                   xmlContent.AppendLine("</SW_Statement_Details>");
                               }
                               else
                               {
                                   xmlContent.AppendLine("<SW_Statement_Detail>");
                                   xmlContent.AppendLine("<Stmt_Declaration_Type>" + " " + "</Stmt_Declaration_Type>");
                                   xmlContent.AppendLine("<Stmt_Declaration_Number>" + " " + "</Stmt_Declaration_Number>");
                                   xmlContent.AppendLine("<Stmt_Declaration_Date>" + " " + "</Stmt_Declaration_Date>");
                                   xmlContent.AppendLine("<Stmt_Type>" + " " + "</Stmt_Type>");
                                   xmlContent.AppendLine("<Stmt_Code>" + " " + "</Stmt_Code>");
                                   xmlContent.AppendLine("<Stmt_Text>" + " " + "</Stmt_Text>");
                                   xmlContent.AppendLine("</SW_Statement_Detail>");
                               }

                               DataTable Sw_reimp_tbl = new DataTable();
                               Sw_reimp_tbl = dss.Tables[15];
                               DataView Sw_reimp_view = Sw_reimp_tbl.DefaultView;
                               Sw_reimp_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_reimptbl = Sw_reimp_view.ToTable();

                               if (Sw_reimptbl.Rows.Count > 0)
                               {
                                   xmlContent.AppendLine("<Re_import_Details>");
                                   for (int re_imp = 0; re_imp < Sw_reimptbl.Rows.Count; re_imp++)
                                   {
                                       xmlContent.AppendLine("<Re_import_Detail>");
                                       xmlContent.AppendLine("<Re_Import_Slno>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["RE_IMPORT_SLNO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["RE_IMPORT_SLNO"].ToString()) + "</Re_Import_Slno>");
                                       xmlContent.AppendLine("<Sb_No>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["SB_NO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["SB_NO"].ToString()) + "</Sb_No>");
                                       xmlContent.AppendLine("<Sb_Date>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["SB_DATE"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["SB_DATE"].ToString()) + "</Sb_Date>");
                                       xmlContent.AppendLine("<Port_Export>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["PORT_EXPORT"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["PORT_EXPORT"].ToString()) + "</Port_Export>");
                                       xmlContent.AppendLine("<Sb_Invoice_No>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["SB_INVOICE_NO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["SB_INVOICE_NO"].ToString()) + "</Sb_Invoice_No>");
                                       xmlContent.AppendLine("<Sb_Invoice_Item_No>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["SB_INVOICE__ITEM_NO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["SB_INVOICE__ITEM_NO"].ToString()) + "</Sb_Invoice_Item_No>");
                                       xmlContent.AppendLine("<Notn_No>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["NOTN_NO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["NOTN_NO"].ToString()) + "</Notn_No>");
                                       xmlContent.AppendLine("<Notn_Slno>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["NOTN_SLNO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["NOTN_SLNO"].ToString()) + "</Notn_Slno>");
                                       xmlContent.AppendLine("<Export_Freight>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["EXPORT_FREIGHT"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["EXPORT_FREIGHT"].ToString()) + "</Export_Freight>");
                                       xmlContent.AppendLine("<Export_Insurance>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["EXPORT_INSURANCE"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["EXPORT_INSURANCE"].ToString()) + "</Export_Insurance>");
                                       xmlContent.AppendLine("<Customs_Duty>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["CUSTOMS_DUTY"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["CUSTOMS_DUTY"].ToString()) + "</Customs_Duty>");
                                       xmlContent.AppendLine("<Excise_Duty>" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["EXCISE_DUTY"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["EXCISE_DUTY"].ToString()) + "</Excise_Duty>");
                                       xmlContent.AppendLine("</Re_import_Detail>");

                                   }
                                   xmlContent.AppendLine("</Re_import_Details>");
                               }
                               else
                               {
                                   xmlContent.AppendLine("<Re_import_Detail>");
                                   xmlContent.AppendLine("<Re_Import_Slno>" + " " + "</Re_Import_Slno>");
                                   xmlContent.AppendLine("<Sb_No>" + " " + "</Sb_No>");
                                   xmlContent.AppendLine("<Sb_Date>" + " " + "</Sb_Date>");
                                   xmlContent.AppendLine("<Port_Export>" + " " + "</Port_Export>");
                                   xmlContent.AppendLine("<Sb_Invoice_No>" + " " + "</Sb_Invoice_No>");
                                   xmlContent.AppendLine("<Sb_Invoice_Item_No>" + " " + "</Sb_Invoice_Item_No>");
                                   xmlContent.AppendLine("<Notn_No>" + " " + "</Notn_No>");
                                   xmlContent.AppendLine("<Notn_Slno>" + " " + "</Notn_Slno>");
                                   xmlContent.AppendLine("<Export_Freight>" + " " + "</Export_Freight>");
                                   xmlContent.AppendLine("<Export_Insurance>" + " " + "</Export_Insurance>");
                                   xmlContent.AppendLine("<Customs_Duty>" + " " + "</Customs_Duty>");
                                   xmlContent.AppendLine("<Excise_Duty>" + " " + "</Excise_Duty>");
                                   xmlContent.AppendLine("</Re_import_Detail>");
                               }

                               xmlContent.AppendLine("</Item_detail>");

                           }
                           xmlContent.AppendLine("</Item_details>");

                       }

                       xmlContent.AppendLine("</Invoice_Detail>");
                   }

                   xmlContent.AppendLine("</Invoice_Details>");

               }

               xmlContent.AppendLine("</JobDetails>");
           }

       }
       #endregion  XML

       //return data = xmlContent.ToString();
       return "";
   }
   public string Imp_JSON_Generate(DataSet dss, string job_no, string Imp_exp, string filetype)
   {
       StreamWriter sw;
       string errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + Connection.Company_License() + "/" + Imp_exp + "/" + filetype);

       if (!Directory.Exists(errorFolder))
       {
           Directory.CreateDirectory(errorFolder);
       }
       string filePath = Path.Combine(errorFolder, Imp_exp + "_" + job_no + ".JSON");

       if (File.Exists(filePath))
       {
           File.Delete(filePath);
       }
       sw = new StreamWriter(filePath, true);
       string Com_Id = Connection.COMPANYID();
       trans_mode = dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString().ToUpper();

       #region Json
       if (dss.Tables.Count > 0)
       {
           if (dss.Tables[0].Rows.Count > 0)
           {
               sw.WriteLine("{");
               sw.WriteLine("      \"Company_Id\": \"" + Connection.Company_License() + "\",");
               if (Connection.COMPANYID() == "3288" || Connection.COMPANYID() == "115" || Connection.COMPANYID() == "1033")
               {
                   sw.WriteLine("      \"Group_name\": \"" + Connection.Current_Group() + "\",");
                   sw.WriteLine("      \"Wrk_prd\": \"" + Connection.WorkingPeriod() + "\",");
               }
               if (dss.Tables[16].Rows.Count > 0 && (Com_Id != "2814" || Com_Id != "3082" || Com_Id != "3253"))
               {

                   sw.WriteLine("      \"Be_No\": \"" + (string.IsNullOrEmpty(dss.Tables[16].Rows[0]["BE_NO"].ToString()) ? " " : dss.Tables[16].Rows[0]["BE_NO"].ToString()) + "\",");
                   sw.WriteLine("      \"Be_Date\": \"" + (dss.Tables[16].Rows[0]["BE_DATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[16].Rows[0]["BE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                   if (Com_Id == "3267")
                   {
                       sw.WriteLine("      \"Maintenance_Status\": \"" + "BE Updated" + "\",");
                   }
               }
               else if (Com_Id == "3267")
               {
                   sw.WriteLine("      \"Maintenance_Status\": \"" + "Open" + "\",");
               }
               sw.WriteLine("  \"JobDetails\": {");
               sw.WriteLine("      \"Job_No\": \"" + job_no + "\",");
               sw.WriteLine("      \"Job_Date\": \"" + (dss.Tables[0].Rows[0]["JOBDATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[0].Rows[0]["JOBDATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
               sw.WriteLine("      \"Transport_Mode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString()) + "\",");
               sw.WriteLine("      \"BE_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["BE_TYPE_New"].ToString()) ? " " : dss.Tables[0].Rows[0]["BE_TYPE_New"].ToString()) + "\",");
               sw.WriteLine("      \"CustomsHouse\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()) ? " " : dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()) + "\",");
               sw.WriteLine("      \"ImporterName\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address1\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS1"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS1"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address2\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS2"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS2"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address3\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS3"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS3"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address4\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS4"].ToString()) + "\",");
               sw.WriteLine("      \"Importer_Address5\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADDRESS5"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADDRESS5"].ToString()) + "\",");
               sw.WriteLine("      \"IEC_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["IEC_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["IEC_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Branch_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()) + "\",");
               sw.WriteLine("      \"CountryOfOrigin\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString()) ? " " : dss.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString()) + "\",");
               sw.WriteLine("      \"PortOfShipment\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString()) ? " " : dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString()) + "\",");
               sw.WriteLine("      \"CountryOfShipment\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString()) ? " " : dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString()) + "\",");
               sw.WriteLine("      \"PortOfOrgin\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString()) ? " " : dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString()) + "\",");            
               sw.WriteLine("      \"FilingStatus\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FILING_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["FILING_STATUS"].ToString()) + "\",");
               sw.WriteLine("      \"UnderSec46\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION46"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION46"].ToString()) + "\",");
               sw.WriteLine("      \"UnderSec46Remarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION46_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION46_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"FirstCheck\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FIRSTCHECK"].ToString()) ? " " : dss.Tables[0].Rows[0]["FIRSTCHECK"].ToString()) + "\",");
               sw.WriteLine("      \"FirstCheckRemarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["FIRSTCHECK_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"GreenChannel\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString()) ? " " : dss.Tables[0].Rows[0]["GREEN_CHANNEL"].ToString()) + "\",");
               sw.WriteLine("      \"GreenChannelRemarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["GREEN_CHANNEL_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"KachhaBE\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["KACHHA_BE"].ToString()) ? " " : dss.Tables[0].Rows[0]["KACHHA_BE"].ToString()) + "\",");
               sw.WriteLine("      \"KachhaBERemarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["KACHHA_BE_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"UnderSec48\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION48"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION48"].ToString()) + "\",");
               sw.WriteLine("      \"UnderSec48Remarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["SECTION48_DESC"].ToString()) ? " " : dss.Tables[0].Rows[0]["SECTION48_DESC"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSale\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_SALE"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSeleName\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_SALE_NAME"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerIEC\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_IEC"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerBranchSNo\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerAddress\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD1"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD1"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerAddress2\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD2"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD2"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerCity\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD3"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD3"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerState\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD4"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD4"].ToString()) + "\",");
               sw.WriteLine("      \"HighSeaSellerPinCode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADD5"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADD5"].ToString()) + "\",");
               sw.WriteLine("      \"WareHouseCode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["WAREHOUSE_CODE"].ToString()) + "\",");
               sw.WriteLine("      \"WareHouseName\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["WAREHOUSE_NAME"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Details_Status\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Tax_Statename\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Tax_Statecode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Tax_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_TYPE"].ToString()) + "\",");
               sw.WriteLine("      \"Commercial_Tax_Registration_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Inbond_Be_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Inbond_Be_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_INBOND_BE_DATE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Bond_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_BOND_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Bond_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_BOND_DATE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Warehouse_Customs\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Warehouse_Customs_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Noofpackage\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Noofpackage_Unitcode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Gross_Weight\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Gross_Weight_Unitcode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Direct_Exbonding\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_DIRECT_EXBONDING"].ToString()) + "\",");
               sw.WriteLine("      \"Remarks\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["REMARKS"].ToString()) ? " " : dss.Tables[0].Rows[0]["REMARKS"].ToString()) + "\",");
               sw.WriteLine("      \"File_Ref_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Container_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString()) + "\",");
               sw.WriteLine("      \"Job_Status\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["JOB_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["JOB_STATUS"].ToString()) + "\",");
               sw.WriteLine("      \"Job_Filed_Status\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["JOB_FILED_STATUS"].ToString()) ? " " : dss.Tables[0].Rows[0]["JOB_FILED_STATUS"].ToString()) + "\",");
               sw.WriteLine("      \"Jobno_Ps\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["JOBNO_PS"].ToString()) ? " " : dss.Tables[0].Rows[0]["JOBNO_PS"].ToString()) + "\",");
               sw.WriteLine("      \"Completed_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["COMPLETED_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["COMPLETED_DATE"].ToString()) + "\",");
               sw.WriteLine("      \"Adcode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ADCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["ADCODE"].ToString()) + "\",");
               sw.WriteLine("      \"Ucr_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["UCR_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["UCR_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Ucr_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["UCR_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["UCR_TYPE"].ToString()) + "\",");
               sw.WriteLine("      \"Payment_Method_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["PAYMENT_METHOD_CODE"].ToString()) + "\",");
               sw.WriteLine("      \"Preceding_Level\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString()) ? " " : dss.Tables[0].Rows[0]["PRECEDING_LEVEL"].ToString()) + "\",");
               sw.WriteLine("      \"Doc_Received_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["DOC_RECEIVED_DATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["DOC_RECEIVED_DATE"].ToString()) + "\",");
               sw.WriteLine("      \"Agent_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["AGENT_NAME"].ToString()) ? " " : dss.Tables[0].Rows[0]["AGENT_NAME"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Addl_Load_Hss\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString()) + "\",");
               sw.WriteLine("      \"Exbond_Misc_Load_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString()) ? " " : dss.Tables[0].Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString()) + "\",");
               sw.WriteLine("      \"Gstn_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) ? " " : dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) + "\",");
               sw.WriteLine("      \"Gstn_Id\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["GSTN_ID"].ToString()) ? " " : dss.Tables[0].Rows[0]["GSTN_ID"].ToString()) + "\",");
               sw.WriteLine("      \"Party_Ref_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["PARTY_REF_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["PARTY_REF_NO"].ToString()) + "\",");
               sw.WriteLine("      \"Eta\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ETA"].ToString()) ? " " : dss.Tables[0].Rows[0]["ETA"].ToString()) + "\",");
               sw.WriteLine("      \"Hss_Adcode\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["HSS_ADCODE"].ToString()) ? " " : dss.Tables[0].Rows[0]["HSS_ADCODE"].ToString()) + "\",");
               sw.WriteLine("      \"Ice_Id\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["ICE_ID"].ToString()) ? " " : dss.Tables[0].Rows[0]["ICE_ID"].ToString()) + "\",");
               sw.WriteLine("      \"Cha_No\": \"" + (string.IsNullOrEmpty(dss.Tables[0].Rows[0]["CHA_NO"].ToString()) ? " " : dss.Tables[0].Rows[0]["CHA_NO"].ToString()) + "\"");
               sw.WriteLine("}");

               if (dss.Tables[2].Rows.Count > 0)
               {
                   sw.WriteLine(",");
                   sw.WriteLine("  \"Igm_Details\": [");

                   for (int rsp = 0; rsp < dss.Tables[2].Rows.Count; rsp++)
                   {
                       sw.WriteLine("    {");
                       sw.WriteLine("      \"Igm_Slno\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_SLNO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_SLNO"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Airlinecode\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_AIRLINECODE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_AIRLINECODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Airlinename\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_AIRLINENAME"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_AIRLINENAME"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Flightno_Vesselno\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_FLIGHTNO_VESSELNO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_FLIGHTNO_VESSELNO"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Flight_Vesseldate\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_FLIGHT_VESSELDATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_No\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_NO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_DATE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_DATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Hawb_Hblno\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLNO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLNO"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Hawb_Hbldate\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLDATE"].ToString()) || dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLDATE"].ToString() == "01-01-1900" ? " " : DateTime.Parse(dss.Tables[2].Rows[rsp]["IGM_HAWB_HBLDATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Igm_Mawb_Mbl\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_MAWB_MBL"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_MAWB_MBL"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Mawb_Mbldate\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_MAWB_MBLDATE"].ToString()) || dss.Tables[2].Rows[rsp]["IGM_MAWB_MBLDATE"].ToString() == "01-01-1900" ? " " : DateTime.Parse(dss.Tables[2].Rows[rsp]["IGM_MAWB_MBLDATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Igm_Noofpackage\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_NOOFPACKAGE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_NOOFPACKAGE"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Packagetype\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_PACKAGETYPE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_PACKAGETYPE"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Grossweight\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_GROSSWEIGHT"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_GROSSWEIGHT"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Typeofweight\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_TYPEOFWEIGHT"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_TYPEOFWEIGHT"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Netweight\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_NETWEIGHT"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_NETWEIGHT"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Netweighttype\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_NETWEIGHTTYPE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_NETWEIGHTTYPE"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Transportmode\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_TRANSPORTMODE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_TRANSPORTMODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Marksnos\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_MARKSNOS"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_MARKSNOS"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Gateway_Igm_No\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_GATEWAY_IGM_NO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_GATEWAY_IGM_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Gateway_Igm_Date\": \"" + (dss.Tables[2].Rows[rsp]["IGM_GATEWAY_IGM_DATE"].ToString() == "01-01-1900" ? " " : DateTime.Parse(dss.Tables[2].Rows[rsp]["IGM_GATEWAY_IGM_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Igm_Gateway_Port_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_GATEWAY_PORT_CODE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_GATEWAY_PORT_CODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Line_Number\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_LINE_NUMBER"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_LINE_NUMBER"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Shipping_Line_Number\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_SHIPPING_LINE_NUMBER"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_SHIPPING_LINE_NUMBER"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Voyage\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_VOYAGE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_VOYAGE"].ToString()) + "\",");
                       sw.WriteLine("      \"Igm_Chargeable_Wgt\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["IGM_CHARGEABLE_WGT"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["IGM_CHARGEABLE_WGT"].ToString()) + "\",");
                       sw.WriteLine("      \"Rotation_No\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["ROTATION_NO"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["ROTATION_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Rotation_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[rsp]["ROTATION_DATE"].ToString()) ? " " : dss.Tables[2].Rows[rsp]["ROTATION_DATE"].ToString()) + "\"");

                       if (rsp == dss.Tables[2].Rows.Count - 1)
                           sw.WriteLine("    }");
                       else
                           sw.WriteLine("    },");
                   }
                   sw.WriteLine("  ]");
               }

               if (dss.Tables[3].Rows.Count > 0)
               {
                   sw.WriteLine(",");
                   sw.WriteLine("  \"Container_Details\": [");

                   for (int rsp = 0; rsp < dss.Tables[3].Rows.Count; rsp++)
                   {
                       sw.WriteLine("    {");
                       sw.WriteLine("      \"Container_No\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["CONTAINER_NO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["CONTAINER_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Container_Igm_Slno\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["CONTAINER_IGM_SLNO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["CONTAINER_IGM_SLNO"].ToString()) + "\",");
                       sw.WriteLine("      \"Container_Igm_No\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["CONTAINER_IGM_NO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["CONTAINER_IGM_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Container_Igm_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["CONTAINER_IGM_DATE"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["CONTAINER_IGM_DATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Seal_No\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["SEAL_NO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["SEAL_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Fcl_Or_Lcl\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["FCL_OR_LCL"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["FCL_OR_LCL"].ToString()) + "\",");
                       sw.WriteLine("      \"Type\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["TYPE"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["TYPE"].ToString()) + "\",");
                       sw.WriteLine("      \"Truck_No\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[rsp]["TRUCK_NO"].ToString()) ? " " : dss.Tables[3].Rows[rsp]["TRUCK_NO"].ToString()) + "\"");

                       if (rsp == dss.Tables[3].Rows.Count - 1)
                           sw.WriteLine("    }");
                       else
                           sw.WriteLine("    },");
                   }
                   sw.WriteLine("  ]");
               }

               if (dss.Tables[4].Rows.Count > 0)
               {
                   sw.WriteLine(",");
                   sw.WriteLine("  \"Bond_Details\": [");

                   for (int rsp = 0; rsp < dss.Tables[4].Rows.Count; rsp++)
                   {
                       sw.WriteLine("    {");
                       sw.WriteLine("      \"Bond_No\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[rsp]["BOND_NO"].ToString()) ? " " : dss.Tables[4].Rows[rsp]["BOND_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Bond_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[rsp]["BOND_TYPE"].ToString()) ? " " : dss.Tables[4].Rows[rsp]["BOND_TYPE"].ToString()) + "\",");
                       sw.WriteLine("      \"Bond_Location\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[rsp]["BOND_LOCATION"].ToString()) ? " " : dss.Tables[4].Rows[rsp]["BOND_LOCATION"].ToString()) + "\"");

                       if (rsp == dss.Tables[4].Rows.Count - 1)
                           sw.WriteLine("    }");
                       else
                           sw.WriteLine("    },");
                   }
                   sw.WriteLine("  ]");
               }

               if (dss.Tables[5].Rows.Count > 0)
               {
                   sw.WriteLine(",");
                   sw.WriteLine("  \"Certificate_Details\": [");

                   for (int rsp = 0; rsp < dss.Tables[5].Rows.Count; rsp++)
                   {
                       sw.WriteLine("    {");
                       sw.WriteLine("      \"Certificate_No\": \"" + (string.IsNullOrEmpty(dss.Tables[5].Rows[rsp]["CERTIFICATE_NO"].ToString()) ? " " : dss.Tables[5].Rows[rsp]["CERTIFICATE_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Certificate_Date\": \"" + (dss.Tables[5].Rows[rsp]["CERTIFICATE_DATE"].ToString() == "1900-01-01 00:00:00.000" ? " " : DateTime.Parse(dss.Tables[5].Rows[rsp]["CERTIFICATE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Certificate_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[5].Rows[rsp]["CERTIFICATE_TYPE"].ToString()) ? " " : dss.Tables[5].Rows[rsp]["CERTIFICATE_TYPE"].ToString()) + "\"");

                       if (rsp == dss.Tables[5].Rows.Count - 1)
                           sw.WriteLine("    }");
                       else
                           sw.WriteLine("    },");
                   }

                   sw.WriteLine("  ]");

               }

               if (dss.Tables[6].Rows.Count > 0)
               {
                   sw.WriteLine(",");
                   sw.WriteLine("  \"Invoice_Details\": [");

                   for (int inv = 0; inv < dss.Tables[6].Rows.Count; inv++)
                   {
                       sw.WriteLine("    {");
                       sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_SLNO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_SLNO"].ToString()) + "\",");
                       sw.WriteLine("      \"Invoice_No\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Invoice_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_DATE"].ToString()) ? " " : DateTime.Parse(dss.Tables[6].Rows[inv]["INVOICE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Terms\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["TERMS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["TERMS"].ToString()) + "\",");
                       sw.WriteLine("      \"Invoice_Currency\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_CURRENCY"].ToString()) + "\",");
                       sw.WriteLine("      \"Invoice_Exrate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_EXRATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Invoice_Value\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_VALUE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_VALUE"].ToString()) + "\",");
                       sw.WriteLine("      \"Supplier_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_NAME"].ToString()) + "\",");
                       sw.WriteLine("      \"Supplier_Address\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS"].ToString()) + "\",");
                       sw.WriteLine("      \"Supplier_Address1\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS1"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS1"].ToString()) + "\",");
                       sw.WriteLine("      \"Supplier_Address2\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS2"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_ADDRESS2"].ToString()) + "\",");
                       sw.WriteLine("      \"Supplier_Country_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_NAME"].ToString()) + "\",");
                       sw.WriteLine("      \"Supplier_Country_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_CODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Supplier_Country_Pincode\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_PINCODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_COUNTRY_PINCODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Seller_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_NAME"].ToString()) + "\",");
                       sw.WriteLine("      \"Seller_Address\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_ADDRESS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_ADDRESS"].ToString()) + "\",");
                       sw.WriteLine("      \"Seller_Address1\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_ADDRESS1"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_ADDRESS1"].ToString()) + "\",");
                       sw.WriteLine("      \"Seller_Address2\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_ADDRESS2"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_ADDRESS2"].ToString()) + "\",");
                       sw.WriteLine("      \"Seller_Country_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_COUNTRY_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_COUNTRY_NAME"].ToString()) + "\",");
                       sw.WriteLine("      \"Seller_Country_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLER_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLER_COUNTRY_CODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Sellercountry_Pincode\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SELLERCOUNTRY_PINCODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SELLERCOUNTRY_PINCODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Broker_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_NAME"].ToString()) + "\",");
                       sw.WriteLine("      \"Broker_Address\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_ADDRESS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_ADDRESS"].ToString()) + "\",");
                       sw.WriteLine("      \"Broker_Address1\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_ADDRESS1"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_ADDRESS1"].ToString()) + "\",");
                       sw.WriteLine("      \"Broker_Address2\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_ADDRESS2"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_ADDRESS2"].ToString()) + "\",");
                       sw.WriteLine("      \"Broker_Country_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_COUNTRY_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_COUNTRY_NAME"].ToString()) + "\",");
                       sw.WriteLine("      \"Broker_Country_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_COUNTRY_CODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Broker_Country_Pincode\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BROKER_COUNTRY_PINCODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BROKER_COUNTRY_PINCODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Charges\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_CHARGES"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Currency\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_CURRENCY"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Exrate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_EXRATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Agency_Charges\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_AGENCY_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_AGENCY_CHARGES"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Agency_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_AGENCY_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_AGENCY_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Agency_Currency\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_AGENCY_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_AGENCY_CURRENCY"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Agency_Exrate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_AGENCY_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_AGENCY_EXRATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Discount_Charges\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_CHARGES"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Discount_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Discount_Currency\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_CURRENCY"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Discount_Exrate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_EXRATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Discount_Reason\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_DISCOUNT_REASON"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_DISCOUNT_REASON"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Loading_Charges\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_LOADING_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_LOADING_CHARGES"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Loading_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_LOADING_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_LOADING_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Loading_Currency\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_LOADING_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_LOADING_CURRENCY"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Loading_Exrate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_LOADING_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_LOADING_EXRATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Freight_Charges\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_FREIGHT_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_FREIGHT_CHARGES"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Freight_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_FREIGHT_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_FREIGHT_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Freight_Currency\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_FREIGHT_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_FREIGHT_CURRENCY"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Freight_Exrate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_FREIGHT_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_FREIGHT_EXRATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Insurance_Charges\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_INSURANCE_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_INSURANCE_CHARGES"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Insurance_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_INSURANCE_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_INSURANCE_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Insurance_Currency\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_INSURANCE_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_INSURANCE_CURRENCY"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Insurance_Exrate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_INSURANCE_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_INSURANCE_EXRATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Highseasale_Charges\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_CHARGES"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Highseasale_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Highseasale_Currency\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_CURRENCY"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Highseasale_Exrate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_HIGHSEASALE_EXRATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mis_Single_Or_Mulitiple\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MIS_SINGLE_OR_MULITIPLE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MIS_SINGLE_OR_MULITIPLE"].ToString()) + "\",");
                       sw.WriteLine("      \"Svb_Relation\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_RELATION"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_RELATION"].ToString()) + "\",");
                       sw.WriteLine("      \"Svb_Ref_No\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_REF_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_REF_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Svb_Ref_Date\": \"" + (dss.Tables[6].Rows[inv]["SVB_REF_DATE"].ToString() == "01/01/1900" ? " " : DateTime.Parse(dss.Tables[6].Rows[inv]["SVB_REF_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Svb_Custom_House\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_CUSTOM_HOUSE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_CUSTOM_HOUSE"].ToString()) + "\",");
                       sw.WriteLine("      \"Svb_Loading_On\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_LOADING_ON"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_LOADING_ON"].ToString()) + "\",");
                       sw.WriteLine("      \"Svb_Assesable_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_ASSESABLE_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_ASSESABLE_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Svb_Duty_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_DUTY_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_DUTY_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Svb_Assesable_Status\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_ASSESABLE_STATUS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_ASSESABLE_STATUS"].ToString()) + "\",");
                       sw.WriteLine("      \"Svb_Duty_Status\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SVB_DUTY_STATUS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SVB_DUTY_STATUS"].ToString()) + "\",");
                       sw.WriteLine("      \"Other_Purchase_Order\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_PURCHASE_ORDER"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_PURCHASE_ORDER"].ToString()) + "\",");
                       sw.WriteLine("      \"Other_Purchase_Order_Date\": \"" + (dss.Tables[6].Rows[inv]["OTHER_PURCHASE_ORDER_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : DateTime.Parse(dss.Tables[6].Rows[inv]["OTHER_PURCHASE_ORDER_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Other_Contract_No\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_CONTRACT_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_CONTRACT_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Other_Contract_Date\": \"" + (dss.Tables[6].Rows[inv]["OTHER_CONTRACT_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : DateTime.Parse(dss.Tables[6].Rows[inv]["OTHER_CONTRACT_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Other_Loc_No\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_LOC_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_LOC_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Other_Loc_Date\": \"" + (dss.Tables[6].Rows[inv]["OTHER_LOC_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : DateTime.Parse(dss.Tables[6].Rows[inv]["OTHER_LOC_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Other_Nature_Of_Transaction\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_NATURE_OF_TRANSACTION"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_NATURE_OF_TRANSACTION"].ToString()) + "\",");
                       sw.WriteLine("      \"Other_Terms_Of_Payment\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_TERMS_OF_PAYMENT"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_TERMS_OF_PAYMENT"].ToString()) + "\",");
                       sw.WriteLine("      \"Other_Conditions\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_CONDITIONS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_CONDITIONS"].ToString()) + "\",");
                       sw.WriteLine("      \"Other_Valuation_Method\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["OTHER_VALUATION_METHOD"].ToString()) ? " " : dss.Tables[6].Rows[inv]["OTHER_VALUATION_METHOD"].ToString()) + "\",");
                       sw.WriteLine("      \"Branch_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["BRANCH_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["BRANCH_CODE"].ToString()) + "\",");
                       sw.WriteLine("      \"Non_Std_Effect_Dt_Imp\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["NON_STD_EFFECT_DT_IMP"].ToString()) ? " " : dss.Tables[6].Rows[inv]["NON_STD_EFFECT_DT_IMP"].ToString()) + "\",");
                       sw.WriteLine("      \"Non_Std_Bankname\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["NON_STD_BANKNAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["NON_STD_BANKNAME"].ToString()) + "\",");
                       sw.WriteLine("      \"Non_Std_Certificate_No\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) + "\",");
                       sw.WriteLine("      \"Non_Std_Certificate_Date\": \"" + (dss.Tables[6].Rows[inv]["NON_STD_CERTIFICATE_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : DateTime.Parse(dss.Tables[6].Rows[inv]["NON_STD_CERTIFICATE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                       sw.WriteLine("      \"Sap_Delievery_Id\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SAP_DELIEVERY_ID"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SAP_DELIEVERY_ID"].ToString()) + "\",");
                       sw.WriteLine("      \"Ship_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SHIP_DATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SHIP_DATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Invoice_Level\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INVOICE_LEVEL"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INVOICE_LEVEL"].ToString()) + "\",");
                       sw.WriteLine("      \"Country_Of_Departure\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["COUNTRY_OF_DEPARTURE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["COUNTRY_OF_DEPARTURE"].ToString()) + "\",");
                       sw.WriteLine("      \"Revenuedeposit_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["REVENUEDEPOSIT_RATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["REVENUEDEPOSIT_RATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Revenuedeposit_On\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["REVENUEDEPOSIT_ON"].ToString()) ? " " : dss.Tables[6].Rows[inv]["REVENUEDEPOSIT_ON"].ToString()) + "\",");
                       sw.WriteLine("      \"Mi_Freight\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MI_FREIGHT"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MI_FREIGHT"].ToString()) + "\",");
                       sw.WriteLine("      \"Mi_Insurance\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MI_INSURANCE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MI_INSURANCE"].ToString()) + "\",");
                       sw.WriteLine("      \"Mi_Misc\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MI_MISC"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MI_MISC"].ToString()) + "\",");
                       sw.WriteLine("      \"Mi_Hss\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["MI_HSS"].ToString()) ? " " : dss.Tables[6].Rows[inv]["MI_HSS"].ToString()) + "\",");
                       sw.WriteLine("      \"Indev_Inv_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INDEV_INV_TYPE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INDEV_INV_TYPE"].ToString()) + "\",");
                       sw.WriteLine("      \"Terms_Place\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["TERMS_PLACE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["TERMS_PLACE"].ToString()) + "\",");
                       sw.WriteLine("      \"Thirdparty_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["THIRDPARTY_NAME"].ToString()) ? " " : dss.Tables[6].Rows[inv]["THIRDPARTY_NAME"].ToString()) + "\",");
                       sw.WriteLine("      \"Thirdparty_Add1\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["THIRDPARTY_ADD1"].ToString()) ? " " : dss.Tables[6].Rows[inv]["THIRDPARTY_ADD1"].ToString()) + "\",");
                       sw.WriteLine("      \"Thirdparty_Add2\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["THIRDPARTY_ADD2"].ToString()) ? " " : dss.Tables[6].Rows[inv]["THIRDPARTY_ADD2"].ToString()) + "\",");
                       sw.WriteLine("      \"Thirdparty_City\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["THIRDPARTY_CITY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["THIRDPARTY_CITY"].ToString()) + "\",");
                       sw.WriteLine("      \"T_Party_Country_Sub_Div\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) ? " " : dss.Tables[6].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) + "\",");
                       sw.WriteLine("      \"T_Party_Country_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) + "\",");
                       sw.WriteLine("      \"T_Party_Pin\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["T_PARTY_PIN"].ToString()) ? " " : dss.Tables[6].Rows[inv]["T_PARTY_PIN"].ToString()) + "\",");
                       sw.WriteLine("      \"Authorized_Economic_Operator_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) + "\",");
                       sw.WriteLine("      \"A_E_O_Country\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["A_E_O_COUNTRY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["A_E_O_COUNTRY"].ToString()) + "\",");
                       sw.WriteLine("      \"Authorized_Economic_Operator\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) ? " " : dss.Tables[6].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) + "\",");
                       sw.WriteLine("      \"Whether_Buyer_Seller_Related\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["WHETHER_BUYER_SELLER_RELATED"].ToString()) ? " " : dss.Tables[6].Rows[inv]["WHETHER_BUYER_SELLER_RELATED"].ToString()) + "\",");
                       sw.WriteLine("      \"Total_Other_Amount\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["TOTAL_OTHER_AMOUNT"].ToString()) ? " " : dss.Tables[6].Rows[inv]["TOTAL_OTHER_AMOUNT"].ToString()) + "\",");
                       sw.WriteLine("      \"Doc_Recd_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["DOC_RECD_DATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["DOC_RECD_DATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Inv_Misc_T_F\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_T_F"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_T_F"].ToString()) + "\",");
                       sw.WriteLine("      \"Inv_Misc_Currency\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_CURRENCY"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_CURRENCY"].ToString()) + "\",");
                       sw.WriteLine("      \"Inv_Misc_Exrate\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_EXRATE"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_EXRATE"].ToString()) + "\",");
                       sw.WriteLine("      \"Inv_Misc_Charges\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_CHARGES"].ToString()) + "\",");
                       sw.WriteLine("      \"Inv_Misc_Total_Charges\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_TOTAL_CHARGES"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_TOTAL_CHARGES"].ToString()) + "\",");
                       sw.WriteLine("      \"Inv_Misc_Add_Frt_Ins_Yn\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["INV_MISC_ADD_FRT_INS_YN"].ToString()) ? " " : dss.Tables[6].Rows[inv]["INV_MISC_ADD_FRT_INS_YN"].ToString()) + "\",");
                       sw.WriteLine("      \"Supplier_Branch_Slno\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["SUPPLIER_BRANCH_SLNO"].ToString()) ? " " : dss.Tables[6].Rows[inv]["SUPPLIER_BRANCH_SLNO"].ToString()) + "\",");
                       sw.WriteLine("      \"Inv_Ctreated_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[6].Rows[inv]["DATE_TIME"].ToString()) ? " " : DateTime.Parse(dss.Tables[6].Rows[inv]["DATE_TIME"].ToString()).ToString("dd-MMM-yyyy")) + "\"");
                       //sw.WriteLine("      \"Inv_Ctreated_Date\": \"" + (dss.Tables[6].Rows[inv]["DATE_TIME"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[6].Rows[inv]["DATE_TIME"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
              
                       DataTable item_tbl = new DataTable();
                       item_tbl = dss.Tables[7];
                       DataView Item_view = item_tbl.DefaultView;
                       string a = dss.Tables[6].Rows[inv]["INVOICE_SLNO"].ToString();
                       Item_view.RowFilter = "INVOICE_SLNO = '" + a + "'";
                       DataTable items = Item_view.ToTable();

                       if (items.Rows.Count > 0)
                       {
                           sw.WriteLine(",");
                           sw.WriteLine("  \"Item_details\": [");

                           for (int itm = 0; itm < items.Rows.Count; itm++)
                           {
                               sw.WriteLine("    {");
                               sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INVOICE_SLNO"].ToString()) ? " " : items.Rows[itm]["INVOICE_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_SLNO"].ToString()) ? " " : items.Rows[itm]["ITEM_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Item_Description\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_DESCRIPTION"].ToString()) ? " " : items.Rows[itm]["ITEM_DESCRIPTION"].ToString()) + "\",");
                               sw.WriteLine("      \"Item_Qty\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_QTY"].ToString()) ? " " : items.Rows[itm]["ITEM_QTY"].ToString()) + "\",");
                               sw.WriteLine("      \"Item_Qty_Code\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_QTY_CODE"].ToString()) ? " " : items.Rows[itm]["ITEM_QTY_CODE"].ToString()) + "\",");
                               sw.WriteLine("      \"Item_Unit_Price\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_UNIT_PRICE"].ToString()) ? " " : items.Rows[itm]["ITEM_UNIT_PRICE"].ToString()) + "\",");
                               sw.WriteLine("      \"Item_Unit_Code\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_UNIT_CODE"].ToString()) ? " " : items.Rows[itm]["ITEM_UNIT_CODE"].ToString()) + "\",");
                               sw.WriteLine("      \"Item_Total_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_TOTAL_AMOUNT"].ToString()) ? " " : items.Rows[itm]["ITEM_TOTAL_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Item_Amount_Code\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ITEM_AMOUNT_CODE"].ToString()) ? " " : items.Rows[itm]["ITEM_AMOUNT_CODE"].ToString()) + "\",");
                               sw.WriteLine("      \"Cth_No\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_NO"].ToString()) ? " " : items.Rows[itm]["CTH_NO"].ToString()) + "\",");
                               sw.WriteLine("      \"Scheme_Code\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SCHEME_CODE"].ToString()) ? " " : items.Rows[itm]["SCHEME_CODE"].ToString()) + "\",");
                               sw.WriteLine("      \"Scheme_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SCHEME_NOTN"].ToString()) ? " " : items.Rows[itm]["SCHEME_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Scheme_Notn_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SCHEME_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["SCHEME_NOTN_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Cth_Qty1\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY1"].ToString()) ? " " : items.Rows[itm]["CTH_QTY1"].ToString()) + "\",");
                               sw.WriteLine("      \"Cth_Qty1_Code\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY1_CODE"].ToString()) ? " " : items.Rows[itm]["CTH_QTY1_CODE"].ToString()) + "\",");
                               sw.WriteLine("      \"Cth_Qty2\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY2"].ToString()) ? " " : items.Rows[itm]["CTH_QTY2"].ToString()) + "\",");
                               sw.WriteLine("      \"Cth_Qty2_Code\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY2_CODE"].ToString()) ? " " : items.Rows[itm]["CTH_QTY2_CODE"].ToString()) + "\",");
                               sw.WriteLine("      \"Genearl_Description\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["GENEARL_DESCRIPTION"].ToString()) ? " " : items.Rows[itm]["GENEARL_DESCRIPTION"].ToString()) + "\",");
                               sw.WriteLine("      \"Manufacturer\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MANUFACTURER"].ToString()) ? " " : items.Rows[itm]["MANUFACTURER"].ToString()) + "\",");
                               sw.WriteLine("      \"Brand\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["BRAND"].ToString()) ? " " : items.Rows[itm]["BRAND"].ToString()) + "\",");
                               sw.WriteLine("      \"Model\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MODEL"].ToString()) ? " " : items.Rows[itm]["MODEL"].ToString()) + "\",");
                               sw.WriteLine("      \"End_Use_Of_Item\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["END_USE_OF_ITEM"].ToString()) ? " " : items.Rows[itm]["END_USE_OF_ITEM"].ToString()) + "\",");
                               sw.WriteLine("      \"Country_Of_Origin\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["COUNTRY_OF_ORIGIN"].ToString()) ? " " : items.Rows[itm]["COUNTRY_OF_ORIGIN"].ToString()) + "\",");
                               sw.WriteLine("      \"Accessories\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ACCESSORIES"].ToString()) ? " " : items.Rows[itm]["ACCESSORIES"].ToString()) + "\",");
                               sw.WriteLine("      \"Previous_Be_No\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PREVIOUS_BE_NO"].ToString()) ? " " : items.Rows[itm]["PREVIOUS_BE_NO"].ToString()) + "\",");
                               sw.WriteLine("      \"Previous_Be_Date\": \"" + (items.Rows[itm]["PREVIOUS_BE_DATE"].ToString() == "01/01/1900 00:00:00" ? " " : (DateTime.Parse(items.Rows[itm]["PREVIOUS_BE_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "\",");
                               sw.WriteLine("      \"Unit_Price\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["UNIT_PRICE"].ToString()) ? " " : items.Rows[itm]["UNIT_PRICE"].ToString()) + "\",");
                               sw.WriteLine("      \"Unit_Code\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["UNIT_CODE"].ToString()) ? " " : items.Rows[itm]["UNIT_CODE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Ritc\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_RITC"].ToString()) ? " " : items.Rows[itm]["PRODUCT_RITC"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cth\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CTH"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CTH"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Bcd_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Bcd_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Bcd_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Bcd_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Bcd_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Bcd_Spl_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_BCD_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_BCD_SPL_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Duty_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_DUTY_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_DUTY_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Duty_Notn_Sl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Duty_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_DUTY_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_DUTY_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Edu_Cess_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_EDU_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_EDU_CESS_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Edu_Cess_Notn_Sl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_EDU_CESS_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_EDU_CESS_NOTN_SL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Edu_Cess_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_EDU_CESS_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Sec_Edu_Cess_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Sec_Edu_Cess_Notn_Sl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Sec_Edu_Cess_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SEC_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SEC_EDU_CESS_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Ncd_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Ncd_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Ncd_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Ncd_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Ncd_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Ncd_Spl_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_NCD_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_NCD_SPL_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Aggregate_Duty_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Aggregate_Duty_Notn_Sl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Aggregate_Duty_Notn_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Safeguard_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Safeguard_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Safeguard_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Safeguard_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Safeguard_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Safeguard_Spl_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Sapta_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAPTA_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAPTA_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Sapta_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAPTA_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAPTA_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Sapta_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_SAPTA_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_SAPTA_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Tariff_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Tariff_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Tariff_Qty\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_QTY"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_QTY"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Tariff_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_AMOUNT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Tariff_Amount_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Ceth\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CETH"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CETH"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Mrp_Yn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_MRP_YN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_MRP_YN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Mrp_Sl_No\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_MRP_SL_NO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_MRP_SL_NO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Mrp_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_MRP_AMOUNT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_MRP_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Mrp_Abt_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_MRP_ABT_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_MRP_ABT_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cvd_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cvd_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cvd_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cvd_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cvd_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cvd_Spl_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_SPL_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cvd_Edu_Cess_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_EDU_CESS_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cvd_Sec_Edu_Cess_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl5_Sia_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL5_SIA_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL5_SIA_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl5_Sia_Notn_Sl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl5_Sia_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL5_SIA_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL5_SIA_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Gsi_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Gsi_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Gsi_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Gsi_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Gsi_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Gsi_Spl_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Sheii_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Sheii_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Sheii_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Sheii_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Sheii_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Sheii_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_SHEII_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_SHEII_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Tta_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Tta_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Tta_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Tta_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Tta_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Tta_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_TTA_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_TTA_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Health_Cess_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Health_Cess_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Health_Cess_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Health_Cess_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Health_Cess_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Addl_Health_Cess_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cess_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cess_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cess_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cess_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cess_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Cess_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_CESS_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_CESS_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Anti_Dumping_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ANTI_DUMPING_NOTN"].ToString()) ? " " : items.Rows[itm]["ANTI_DUMPING_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Anti_Dumping_Notn_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ANTI_DUMPING_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["ANTI_DUMPING_NOTN_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Cth_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_SLNO"].ToString()) ? " " : items.Rows[itm]["CTH_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Cth_Supplier_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_SUPPLIER_SLNO"].ToString()) ? " " : items.Rows[itm]["CTH_SUPPLIER_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Cth_Qty\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CTH_QTY"].ToString()) ? " " : items.Rows[itm]["CTH_QTY"].ToString()) + "\",");
                               sw.WriteLine("      \"Rsp_Duty_Status\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_DUTY_STATUS"].ToString()) ? " " : items.Rows[itm]["RSP_DUTY_STATUS"].ToString()) + "\",");
                               sw.WriteLine("      \"Rsp_Sl_No\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_SL_NO"].ToString()) ? " " : items.Rows[itm]["RSP_SL_NO"].ToString()) + "\",");
                               sw.WriteLine("      \"Rsp_Desc\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_DESC"].ToString()) ? " " : items.Rows[itm]["RSP_DESC"].ToString()) + "\",");
                               sw.WriteLine("      \"Rsp_Qty\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_QTY"].ToString()) ? " " : items.Rows[itm]["RSP_QTY"].ToString()) + "\",");
                               sw.WriteLine("      \"Rsp_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_AMOUNT"].ToString()) ? " " : items.Rows[itm]["RSP_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Rsp_Notn_No\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_NOTN_NO"].ToString()) ? " " : items.Rows[itm]["RSP_NOTN_NO"].ToString()) + "\",");
                               sw.WriteLine("      \"Rsp_Notn_Sl_No\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_NOTN_SL_NO"].ToString()) ? " " : items.Rows[itm]["RSP_NOTN_SL_NO"].ToString()) + "\",");
                               sw.WriteLine("      \"Rsp_Abt_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_ABT_RATE"].ToString()) ? " " : items.Rows[itm]["RSP_ABT_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Warehouse_Jobno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["WAREHOUSE_JOBNO"].ToString()) ? " " : items.Rows[itm]["WAREHOUSE_JOBNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Warehouse_Invoice_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["WAREHOUSE_INVOICE_SLNO"].ToString()) ? " " : items.Rows[itm]["WAREHOUSE_INVOICE_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Warehouse_Item_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["WAREHOUSE_ITEM_SLNO"].ToString()) ? " " : items.Rows[itm]["WAREHOUSE_ITEM_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Assessable_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ASSESSABLE_VALUE"].ToString()) ? " " : items.Rows[itm]["ASSESSABLE_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Duty_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["DUTY_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Cif_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CIF_VALUE"].ToString()) ? " " : items.Rows[itm]["CIF_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Cvd_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CVD_VALUE"].ToString()) ? " " : items.Rows[itm]["CVD_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Basic_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["BASIC_VALUE"].ToString()) ? " " : items.Rows[itm]["BASIC_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Cec_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CEC_VALUE"].ToString()) ? " " : items.Rows[itm]["CEC_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Chec_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHEC_VALUE"].ToString()) ? " " : items.Rows[itm]["CHEC_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Add_Duty_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ADD_DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["ADD_DUTY_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Ceth_Cvd_Edu_Cess_Sl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CETH_CVD_EDU_CESS_SL"].ToString()) ? " " : items.Rows[itm]["CETH_CVD_EDU_CESS_SL"].ToString()) + "\",");
                               sw.WriteLine("      \"Ceth_Cvd_Edu_Cess_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CETH_CVD_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["CETH_CVD_EDU_CESS_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Ceth_Cvd_Sec_Edu_Cess_Sl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CETH_CVD_SEC_EDU_CESS_SL"].ToString()) ? " " : items.Rows[itm]["CETH_CVD_SEC_EDU_CESS_SL"].ToString()) + "\",");
                               sw.WriteLine("      \"Ceth_Cvd_Sec_Edu_Cess_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Other_Duty_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_NOTN"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Other_Duty_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_SLNO"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Other_Duty_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_RATE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Other_Duty_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_SPL"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Other_Duty_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_UNIT"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Product_Other_Duty_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["PRODUCT_OTHER_DUTY_TYPE"].ToString()) ? " " : items.Rows[itm]["PRODUCT_OTHER_DUTY_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Indivitual_Freight_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_FREIGHT_AMOUNT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_FREIGHT_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Indivitual_Insurance_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_INSURANCE_AMOUNT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_INSURANCE_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Indivitual_Misc_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_MISC_AMOUNT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_MISC_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Svb_Relation\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_RELATION"].ToString()) ? " " : items.Rows[itm]["SVB_RELATION"].ToString()) + "\",");
                               sw.WriteLine("      \"Svb_Ref_No\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_REF_NO"].ToString()) ? " " : items.Rows[itm]["SVB_REF_NO"].ToString()) + "\",");
                               sw.WriteLine("      \"Svb_Ref_Date\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_REF_DATE"].ToString()) ? " " : items.Rows[itm]["SVB_REF_DATE"].ToString() == "01/01/1900" ? " " : (DateTime.Parse(items.Rows[itm]["SVB_REF_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "\",");
                               sw.WriteLine("      \"Svb_Custom_House\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_CUSTOM_HOUSE"].ToString()) ? " " : items.Rows[itm]["SVB_CUSTOM_HOUSE"].ToString()) + "\",");
                               sw.WriteLine("      \"Svb_Loading_On\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_LOADING_ON"].ToString()) ? " " : items.Rows[itm]["SVB_LOADING_ON"].ToString()) + "\",");
                               sw.WriteLine("      \"Svb_Assesable_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_ASSESABLE_RATE"].ToString()) ? " " : items.Rows[itm]["SVB_ASSESABLE_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Svb_Duty_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_DUTY_RATE"].ToString()) ? " " : items.Rows[itm]["SVB_DUTY_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Svb_Assesable_Status\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_ASSESABLE_STATUS"].ToString()) ? " " : items.Rows[itm]["SVB_ASSESABLE_STATUS"].ToString()) + "\",");
                               sw.WriteLine("      \"Svb_Duty_Status\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SVB_DUTY_STATUS"].ToString()) ? " " : items.Rows[itm]["SVB_DUTY_STATUS"].ToString()) + "\",");
                               sw.WriteLine("      \"Indivitual_Edu_Cess_Amt\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_EDU_CESS_AMT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_EDU_CESS_AMT"].ToString()) + "\",");
                               sw.WriteLine("      \"Indivitual_Sec_Higher_Cess_Amt\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_SEC_HIGHER_CESS_AMT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_SEC_HIGHER_CESS_AMT"].ToString()) + "\",");
                               sw.WriteLine("      \"Indivitual_Landing_Charge\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_LANDING_CHARGE"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_LANDING_CHARGE"].ToString()) + "\",");
                               sw.WriteLine("      \"Checklist_Bcd_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_BCD_RATE"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_BCD_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Checklist_Cvd_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_CVD_RATE"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_CVD_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Checklist_Addl_Duty_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_ADDL_DUTY_RATE"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_ADDL_DUTY_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Indev_Rack_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INDEV_RACK_TYPE"].ToString()) ? " " : items.Rows[itm]["INDEV_RACK_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Duty_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_DUTY_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Rsp_Applicable\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["RSP_APPLICABLE"].ToString()) ? " " : items.Rows[itm]["RSP_APPLICABLE"].ToString()) + "\",");
                               sw.WriteLine("      \"Central_Excise_Flag\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CENTRAL_EXCISE_FLAG"].ToString()) ? " " : items.Rows[itm]["CENTRAL_EXCISE_FLAG"].ToString()) + "\",");
                               sw.WriteLine("      \"Manufacturer_Producer\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) ? " " : items.Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) + "\",");
                               sw.WriteLine("      \"M_P_Grower_Code\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_CODE"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_CODE"].ToString()) + "\",");
                               sw.WriteLine("      \"M_P_Grower_Add1\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_ADD1"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_ADD1"].ToString()) + "\",");
                               sw.WriteLine("      \"M_P_Grower_Add2\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_ADD2"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_ADD2"].ToString()) + "\",");
                               sw.WriteLine("      \"M_P_Grower_City\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_CITY"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_CITY"].ToString()) + "\",");
                               sw.WriteLine("      \"M_P_Grower_Country_Subdiv\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) + "\",");
                               sw.WriteLine("      \"M_P_Grower_Pin\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_PIN"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_PIN"].ToString()) + "\",");
                               sw.WriteLine("      \"M_P_Grower_Country\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["M_P_GROWER_COUNTRY"].ToString()) ? " " : items.Rows[itm]["M_P_GROWER_COUNTRY"].ToString()) + "\",");
                               sw.WriteLine("      \"Source_Country\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SOURCE_COUNTRY"].ToString()) ? " " : items.Rows[itm]["SOURCE_COUNTRY"].ToString()) + "\",");
                               sw.WriteLine("      \"Transit_Country\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["TRANSIT_COUNTRY"].ToString()) ? " " : items.Rows[itm]["TRANSIT_COUNTRY"].ToString()) + "\",");
                               sw.WriteLine("      \"Accessory_Status\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ACCESSORY_STATUS"].ToString()) ? " " : items.Rows[itm]["ACCESSORY_STATUS"].ToString()) + "\",");
                               sw.WriteLine("      \"Infra_Cess_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INFRA_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["INFRA_CESS_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Infra_Cess_Notn_Sl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INFRA_CESS_NOTN_SL"].ToString()) ? " " : items.Rows[itm]["INFRA_CESS_NOTN_SL"].ToString()) + "\",");
                               sw.WriteLine("      \"Infra_Cess_Notn_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INFRA_CESS_NOTN_RATE"].ToString()) ? " " : items.Rows[itm]["INFRA_CESS_NOTN_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Basic_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_BASIC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_BASIC_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Cvd_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_CVD_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_CVD_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Cec_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_CEC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_CEC_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Chec_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_CHEC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_CHEC_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Add_Duty_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_ADD_DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_ADD_DUTY_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Notn_Basic_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_BASIC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_BASIC_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Notn_Cvd_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_CVD_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_CVD_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Notn_Cec_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_CEC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_CEC_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Notn_Chec_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_CHEC_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_CHEC_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Notn_Add_Duty_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_ADD_DUTY_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_ADD_DUTY_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Notn_Cess_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_CESS_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_CESS_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Merit_Notn_Ncd_Value\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["MERIT_NOTN_NCD_VALUE"].ToString()) ? " " : items.Rows[itm]["MERIT_NOTN_NCD_VALUE"].ToString()) + "\",");
                               sw.WriteLine("      \"Indivitual_Hss_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["INDIVITUAL_HSS_AMOUNT"].ToString()) ? " " : items.Rows[itm]["INDIVITUAL_HSS_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_NOTN"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_SLNO"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_RATE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_SPL"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_UNIT"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Spl_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_SPL_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Exception_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_NOTN"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Exception_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_SLNO"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Exception_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_RATE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Compensation_Cess_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Compensation_Cess_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Compensation_Cess_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Compensation_Cess_Spl\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Compensation_Cess_Unit\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Compensation_Cess_Spl_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Exception_Cc_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Exception_Cc_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Igst_Levy_Exception_Cc_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString()) ? " " : items.Rows[itm]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Levy_Excemption_Notn_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString()) ? " " : items.Rows[itm]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Levy_Exception_Cc_Notn_Type\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString()) ? " " : items.Rows[itm]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString()) + "\",");
                               sw.WriteLine("      \"Checklist_Igst_Levy_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_IGST_LEVY_AMOUNT"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_IGST_LEVY_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Checklist_Compensation_Cc_Amount\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_COMPENSATION_CC_AMOUNT"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_COMPENSATION_CC_AMOUNT"].ToString()) + "\",");
                               sw.WriteLine("      \"Social_Welfare_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SOCIAL_WELFARE_NOTN"].ToString()) ? " " : items.Rows[itm]["SOCIAL_WELFARE_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Social_Welfare_Notn_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SOCIAL_WELFARE_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["SOCIAL_WELFARE_NOTN_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Social_Welfare_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["SOCIAL_WELFARE_RATE"].ToString()) ? " " : items.Rows[itm]["SOCIAL_WELFARE_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Checklist_Social_Welfare_Amt\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_SOCIAL_WELFARE_AMT"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_SOCIAL_WELFARE_AMT"].ToString()) + "\",");
                               sw.WriteLine("      \"Checklist_Health_Cess_Amt\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_HEALTH_CESS_AMT"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_HEALTH_CESS_AMT"].ToString()) + "\",");
                               sw.WriteLine("      \"Checklist_Anti_Dumping_Amt\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHECKLIST_ANTI_DUMPING_AMT"].ToString()) ? " " : items.Rows[itm]["CHECKLIST_ANTI_DUMPING_AMT"].ToString()) + "\",");
                               sw.WriteLine("      \"Aidc_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["AIDC_NOTN"].ToString()) ? " " : items.Rows[itm]["AIDC_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Aidc_Notn_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["AIDC_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["AIDC_NOTN_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Aidc_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["AIDC_RATE"].ToString()) ? " " : items.Rows[itm]["AIDC_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Aidc_Checklist_Amt\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["AIDC_CHECKLIST_AMT"].ToString()) ? " " : items.Rows[itm]["AIDC_CHECKLIST_AMT"].ToString()) + "\",");
                               sw.WriteLine("      \"Add_Ex_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["ADD_EX_RATE"].ToString()) ? " " : items.Rows[itm]["ADD_EX_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Exc_Aidc_Notn\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["EXC_AIDC_NOTN"].ToString()) ? " " : items.Rows[itm]["EXC_AIDC_NOTN"].ToString()) + "\",");
                               sw.WriteLine("      \"Exc_Aidc_Notn_Slno\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["EXC_AIDC_NOTN_SLNO"].ToString()) ? " " : items.Rows[itm]["EXC_AIDC_NOTN_SLNO"].ToString()) + "\",");
                               sw.WriteLine("      \"Exc_Aidc_Rate\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["EXC_AIDC_RATE"].ToString()) ? " " : items.Rows[itm]["EXC_AIDC_RATE"].ToString()) + "\",");
                               sw.WriteLine("      \"Exc_Aidc_Checklist_Amt\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["EXC_AIDC_CHECKLIST_AMT"].ToString()) ? " " : items.Rows[itm]["EXC_AIDC_CHECKLIST_AMT"].ToString()) + "\",");
                               sw.WriteLine("      \"Chk_Igst_Assbl_Val\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["CHK_IGST_ASSBL_VAL"].ToString()) ? " " : items.Rows[itm]["CHK_IGST_ASSBL_VAL"].ToString()) + "\",");
                               sw.WriteLine("      \"Bcd_Foregone_Amt\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["BCD_FOREGONE_AMT"].ToString()) ? " " : items.Rows[itm]["BCD_FOREGONE_AMT"].ToString()) + "\",");
                               sw.WriteLine("      \"Total_Duty_Foregone_Amt\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["TOTAL_DUTY_FOREGONE_AMT"].ToString()) ? " " : items.Rows[itm]["TOTAL_DUTY_FOREGONE_AMT"].ToString()) + "\",");
                               sw.WriteLine("      \"Itm_Ctreated_Date\": \"" + (string.IsNullOrEmpty(items.Rows[itm]["DATE_TIME"].ToString()) ? " " : DateTime.Parse(items.Rows[itm]["DATE_TIME"].ToString()).ToString("dd-MMM-yyyy")) + "\"");
              
                               DataTable lic_tbl = new DataTable();
                               lic_tbl = dss.Tables[8];
                               DataView Lic_view = lic_tbl.DefaultView;
                               //string inv_slno = dss.Tables[7].Rows[itm]["INVOICE_SLNO"].ToString();
                               string item_slno = items.Rows[itm]["ITEM_SLNO"].ToString();  //items.Rows[itm]["ITEM_SLNO"].ToString();
                               Lic_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable License = Lic_view.ToTable();

                               if (License.Rows.Count > 0)
                               {
                                   sw.WriteLine(",");
                                   sw.WriteLine("  \"License_details\": [");
                                   for (int lic = 0; lic < License.Rows.Count; lic++)
                                   {
                                       sw.WriteLine("{");
                                       sw.WriteLine("     \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["INVOICE_SLNO"].ToString()) ? " " : License.Rows[lic]["INVOICE_SLNO"].ToString()) + "\",");
                                       sw.WriteLine("     \"Item_Slno\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["ITEM_SLNO"].ToString()) ? " " : License.Rows[lic]["ITEM_SLNO"].ToString()) + "\",");
                                       sw.WriteLine("     \"License_Slno\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["LICENSE_SLNO"].ToString()) ? " " : License.Rows[lic]["LICENSE_SLNO"].ToString()) + "\",");
                                       sw.WriteLine("     \"Scheme_Code\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["SCHEME_CODE"].ToString()) ? " " : License.Rows[lic]["SCHEME_CODE"].ToString()) + "\",");
                                       sw.WriteLine("     \"Registration_No\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["REGISTRATION_NO"].ToString()) ? " " : License.Rows[lic]["REGISTRATION_NO"].ToString()) + "\",");
                                       sw.WriteLine("     \"Registration_Date\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["REGISTRATION_DATE"].ToString()) ? " " : License.Rows[lic]["REGISTRATION_DATE"].ToString()) + "\",");
                                       sw.WriteLine("     \"Excemption\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["EXCEMPTION"].ToString()) ? " " : License.Rows[lic]["EXCEMPTION"].ToString()) + "\",");
                                       sw.WriteLine("     \"Debit_Amt\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["DEBIT_AMT"].ToString()) ? " " : License.Rows[lic]["DEBIT_AMT"].ToString()) + "\",");
                                       sw.WriteLine("     \"Debit_Qty\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["DEBIT_QTY"].ToString()) ? " " : License.Rows[lic]["DEBIT_QTY"].ToString()) + "\",");
                                       sw.WriteLine("     \"Unit_Qty\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["UNIT_QTY"].ToString()) ? " " : License.Rows[lic]["UNIT_QTY"].ToString()) + "\",");
                                       sw.WriteLine("     \"Port_Of_License\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["PORT_OF_LICENSE"].ToString()) ? " " : License.Rows[lic]["PORT_OF_LICENSE"].ToString()) + "\",");
                                       sw.WriteLine("     \"Debit_Duty\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["DEBIT_DUTY"].ToString()) ? " " : License.Rows[lic]["DEBIT_DUTY"].ToString()) + "\",");
                                       sw.WriteLine("     \"License_No\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["LICENSE_NO"].ToString()) ? " " : License.Rows[lic]["LICENSE_NO"].ToString()) + "\",");
                                       sw.WriteLine("     \"License_Date\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["LICENSE_DATE"].ToString()) ? " " : License.Rows[lic]["LICENSE_DATE"].ToString()) + "\",");
                                       sw.WriteLine("     \"Total_Cif_Value\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["TOTAL_CIF_VALUE"].ToString()) ? " " : License.Rows[lic]["TOTAL_CIF_VALUE"].ToString()) + "\",");
                                       sw.WriteLine("     \"Total_Debit_Duty\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["TOTAL_DEBIT_DUTY"].ToString()) ? " " : License.Rows[lic]["TOTAL_DEBIT_DUTY"].ToString()) + "\",");
                                       sw.WriteLine("     \"Entry_Debit_Duty\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["ENTRY_DEBIT_DUTY"].ToString()) ? " " : License.Rows[lic]["ENTRY_DEBIT_DUTY"].ToString()) + "\",");
                                       sw.WriteLine("     \"Lic_Desc\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["LIC_DESC"].ToString()) ? " " : License.Rows[lic]["LIC_DESC"].ToString()) + "\",");
                                       sw.WriteLine("     \"License_Currency\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["LICENSE_CURRENCY"].ToString()) ? " " : License.Rows[lic]["LICENSE_CURRENCY"].ToString()) + "\",");
                                       sw.WriteLine("     \"Ex_Rate\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["EX_RATE"].ToString()) ? " " : License.Rows[lic]["EX_RATE"].ToString()) + "\",");
                                       sw.WriteLine("     \"Jobno_Ps\": \"" + (string.IsNullOrEmpty(License.Rows[lic]["JOBNO_PS"].ToString()) ? " " : License.Rows[lic]["JOBNO_PS"].ToString()) + "\"");

                                       if (lic == License.Rows.Count - 1)
                                           sw.WriteLine("    }");
                                       else
                                           sw.WriteLine("    },");
                                   }
                                   sw.WriteLine("      ]"); // End of License details 
                               }

                               DataTable Sw_const_tbl = new DataTable();
                               Sw_const_tbl = dss.Tables[9];
                               DataView Sw_const_view = Sw_const_tbl.DefaultView;
                               Sw_const_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_Const = Sw_const_view.ToTable();

                               if (Sw_Const.Rows.Count > 0)
                               {
                                   sw.WriteLine(",");
                                   sw.WriteLine("      \"SW_details\": [");
                                   for (int sw_const = 0; sw_const < Sw_Const.Rows.Count; sw_const++)
                                   {
                                       sw.WriteLine("        {");
                                       sw.WriteLine("          \"Constituent_Srno\": \"" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_SRNO"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_SRNO"].ToString()) + "\",");
                                       sw.WriteLine("          \"Constituent_Element_Name\": \"" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_ELEMENT_NAME"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_ELEMENT_NAME"].ToString()) + "\",");
                                       sw.WriteLine("          \"Constituent_Element_Code\": \"" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_ELEMENT_CODE"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_ELEMENT_CODE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Constituent_Percentage\": \"" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_PERCENTAGE"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_PERCENTAGE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Constituent_Yield_Percentage\": \"" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString()) ? " " : Sw_Const.Rows[sw_const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Active_Ingredient\": \"" + (string.IsNullOrEmpty(Sw_Const.Rows[sw_const]["ACTIVE_INGREDIENT"].ToString()) ? " " : Sw_Const.Rows[sw_const]["ACTIVE_INGREDIENT"].ToString()) + "\"");

                                       if (sw_const == Sw_Const.Rows.Count - 1)
                                           sw.WriteLine("    }");
                                       else
                                           sw.WriteLine("    },");
                                   }
                                   sw.WriteLine("      ]");
                               }

                               DataTable Sw_cont_tbl = new DataTable();
                               Sw_cont_tbl = dss.Tables[10];
                               DataView Sw_cont_view = Sw_cont_tbl.DefaultView;
                               Sw_cont_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_Contrl = Sw_cont_view.ToTable();

                               if (Sw_Contrl.Rows.Count > 0)
                               {
                                   sw.WriteLine(",");
                                   sw.WriteLine("      \"SW_Control_Details\": [");
                                   for (int sw_control = 0; sw_control < Sw_Contrl.Rows.Count; sw_control++)
                                   {
                                       sw.WriteLine("        {");
                                       sw.WriteLine("          \"Control_Type_Code\": \"" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_TYPE_CODE"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_TYPE_CODE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Control_Location\": \"" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_LOCATION"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_LOCATION"].ToString()) + "\",");
                                       sw.WriteLine("          \"Control_Start_Date\": \"" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_START_DATE"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_START_DATE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Control_End_Date\": \"" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_END_DATE"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_END_DATE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Control_Result_Code\": \"" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_RESULT_CODE"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_RESULT_CODE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Control_Result_Text\": \"" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_RESULT_TEXT"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_RESULT_TEXT"].ToString()) + "\",");
                                       sw.WriteLine("          \"Control_Msr\": \"" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_MSR"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_MSR"].ToString()) + "\",");
                                       sw.WriteLine("          \"Control_Uqc\": \"" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_UQC"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_UQC"].ToString()) + "\",");
                                       sw.WriteLine("          \"Control_Slno\": \"" + (string.IsNullOrEmpty(Sw_Contrl.Rows[sw_control]["CONTROL_SLNO"].ToString()) ? " " : Sw_Contrl.Rows[sw_control]["CONTROL_SLNO"].ToString()) + "\"");

                                       if (sw_control == Sw_Contrl.Rows.Count - 1)
                                           sw.WriteLine("    }");
                                       else
                                           sw.WriteLine("    },");
                                   }
                                   sw.WriteLine("      ]");
                               }

                               DataTable Sw_info_tbl = new DataTable();
                               Sw_info_tbl = dss.Tables[11];
                               DataView Sw_info_view = Sw_info_tbl.DefaultView;
                               Sw_info_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_Infotbl = Sw_info_view.ToTable();

                               if (Sw_Infotbl.Rows.Count > 0)
                               {
                                   sw.WriteLine(",");
                                   sw.WriteLine("      \"SW_Info_Details\": [");
                                   for (int sw_info = 0; sw_info < Sw_Infotbl.Rows.Count; sw_info++)
                                   {
                                       sw.WriteLine("        {");
                                       sw.WriteLine("          \"Info_Type\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_TYPE"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_TYPE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Info_Qualifier\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_QUALIFIER"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_QUALIFIER"].ToString()) + "\",");
                                       sw.WriteLine("          \"Info_Code\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_CODE"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_CODE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Info_Text\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_TEXT"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_TEXT"].ToString()) + "\",");
                                       sw.WriteLine("          \"Info_Msr\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_MSR"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_MSR"].ToString()) + "\",");
                                       sw.WriteLine("          \"Info_Uqc\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["INFO_UQC"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["INFO_UQC"].ToString()) + "\",");
                                       sw.WriteLine("          \"Department\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["DEPARTMENT"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["DEPARTMENT"].ToString()) + "\",");
                                       sw.WriteLine("          \"I_U_Type\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["I_U_TYPE"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["I_U_TYPE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Regn_Date\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["REGN_DATE"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["REGN_DATE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Regn_Validity\": \"" + (string.IsNullOrEmpty(Sw_Infotbl.Rows[sw_info]["REGN_VALIDITY"].ToString()) ? " " : Sw_Infotbl.Rows[sw_info]["REGN_VALIDITY"].ToString()) + "\"");

                                       if (sw_info == Sw_Infotbl.Rows.Count - 1)
                                           sw.WriteLine("    }");
                                       else
                                           sw.WriteLine("    },");
                                   }
                                   sw.WriteLine("      ]");
                               }

                               DataTable Sw_prod_tbl = new DataTable();
                               Sw_prod_tbl = dss.Tables[12];
                               DataView Sw_prod_view = Sw_prod_tbl.DefaultView;
                               Sw_prod_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_prodtbl = Sw_prod_view.ToTable();
                               if (Sw_prodtbl.Rows.Count > 0)
                               {
                                   sw.WriteLine(",");
                                   sw.WriteLine("      \"SW_Prod_Details\": [");
                                   for (int sw_prod = 0; sw_prod < Sw_prodtbl.Rows.Count; sw_prod++)
                                   {
                                       sw.WriteLine("   {");
                                       sw.WriteLine("   \"Production_Batch_Identifier\": \"" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString()) + "\",");
                                       sw.WriteLine("   \"Production_Batch_Quantity\": \"" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["PRODUCTION_BATCH_QUANTITY"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["PRODUCTION_BATCH_QUANTITY"].ToString()) + "\",");
                                       sw.WriteLine("   \"Date_Of_Manufacturing\": \"" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["DATE_OF_MANUFACTURING"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["DATE_OF_MANUFACTURING"].ToString()) + "\",");
                                       sw.WriteLine("   \"Date_Of_Expiry\": \"" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["DATE_OF_EXPIRY"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["DATE_OF_EXPIRY"].ToString()) + "\",");
                                       sw.WriteLine("   \"Best_Before\": \"" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["BEST_BEFORE"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["BEST_BEFORE"].ToString()) + "\",");
                                       sw.WriteLine("   \"Residual_Shelf_Life_Days\": \"" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["RESIDUAL_SHELF_LIFE_DAYS"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["RESIDUAL_SHELF_LIFE_DAYS"].ToString()) + "\",");
                                       sw.WriteLine("   \"Total_Shelf_Life_Days\": \"" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["TOTAL_SHELF_LIFE_DAYS"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["TOTAL_SHELF_LIFE_DAYS"].ToString()) + "\",");
                                       sw.WriteLine("   \"Residual_Shelf_Percent\": \"" + (string.IsNullOrEmpty(Sw_prodtbl.Rows[sw_prod]["RESIDUAL_SHELF_PERCENT"].ToString()) ? " " : Sw_prodtbl.Rows[sw_prod]["RESIDUAL_SHELF_PERCENT"].ToString()) + "\"");

                                       if (sw_prod == Sw_prodtbl.Rows.Count - 1)
                                           sw.WriteLine("    }");
                                       else
                                           sw.WriteLine("    },");

                                   }
                                   sw.WriteLine("      ]");
                               }

                               DataTable Sw_sup_tbl = new DataTable();
                               Sw_sup_tbl = dss.Tables[13];
                               DataView Sw_sup_view = Sw_sup_tbl.DefaultView;
                               Sw_sup_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_suptbl = Sw_sup_view.ToTable();

                               if (Sw_suptbl.Rows.Count > 0)
                               {
                                   sw.WriteLine("  ,");
                                   sw.WriteLine("  \"SW_SupDoc_Details\": [");
                                   for (int sw_sup = 0; sw_sup < Sw_suptbl.Rows.Count; sw_sup++)
                                   {
                                       sw.WriteLine("        {");
                                       sw.WriteLine("          \"Declaration_Type\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DECLARATION_TYPE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DECLARATION_TYPE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Image_Ref_Number\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["IMAGE_REF_NUMBER"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["IMAGE_REF_NUMBER"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Type_Code\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_TYPE_CODE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_TYPE_CODE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Issuing_Party_Code\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_CODE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_CODE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Issuing_Party_Name\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Issuing_Party_Name_Add1\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Issuing_Party_Name_Add2\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Issuing_Party_City\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_CITY"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_CITY"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Issuing_Party_Pin\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_PIN"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUING_PARTY_PIN"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Ref_Number\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_REF_NUMBER"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_REF_NUMBER"].ToString()) + "\",");
                                       sw.WriteLine("          \"Place_Of_Issue\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["PLACE_OF_ISSUE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["PLACE_OF_ISSUE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Issue_Date\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_ISSUE_DATE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_ISSUE_DATE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Doc_Expiry_Date\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["DOC_EXPIRY_DATE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["DOC_EXPIRY_DATE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Beneficiary_Party_Code\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_CODE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_CODE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Beneficiary_Party_Name\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_NAME"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_NAME"].ToString()) + "\",");
                                       sw.WriteLine("          \"Beneficiary_Party_Address1\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_ADDRESS1"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_ADDRESS1"].ToString()) + "\",");
                                       sw.WriteLine("          \"Beneficiary_Party_Address2\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_ADDRESS2"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_ADDRESS2"].ToString()) + "\",");
                                       sw.WriteLine("          \"Beneficiary_Party_City\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_CITY"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_CITY"].ToString()) + "\",");
                                       sw.WriteLine("          \"Beneficiary_Party_Pin\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_PIN"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["BENEFICIARY_PARTY_PIN"].ToString()) + "\",");
                                       sw.WriteLine("          \"File_Type\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["FILE_TYPE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["FILE_TYPE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Select_Type\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["SELECT_TYPE"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["SELECT_TYPE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Icegate_Id\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["ICEGATE_ID"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["ICEGATE_ID"].ToString()) + "\",");
                                       sw.WriteLine("          \"Icegate_Doc_File_Name\": \"" + (string.IsNullOrEmpty(Sw_suptbl.Rows[sw_sup]["ICEGATE_DOC_FILE_NAME"].ToString()) ? " " : Sw_suptbl.Rows[sw_sup]["ICEGATE_DOC_FILE_NAME"].ToString()) + "\"");

                                       if (sw_sup == Sw_suptbl.Rows.Count - 1)
                                           sw.WriteLine("    }");
                                       else
                                           sw.WriteLine("    },");
                                   }
                                   sw.WriteLine("      ]"); // End of SW SupDoc details array
                               }

                               DataTable Sw_state_tbl = new DataTable();
                               Sw_state_tbl = dss.Tables[14];
                               DataView Sw_state_view = Sw_state_tbl.DefaultView;
                               Sw_state_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_statetbl = Sw_state_view.ToTable();

                               if (Sw_statetbl.Rows.Count > 0)
                               {
                                   sw.WriteLine(",");
                                   sw.WriteLine("      \"SW_Statement_Details\": [");
                                   for (int sw_state = 0; sw_state < Sw_statetbl.Rows.Count; sw_state++)
                                   {
                                       sw.WriteLine("   {");
                                       sw.WriteLine("   \"Stmt_Declaration_Type\": \"" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_TYPE"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_TYPE"].ToString()) + "\",");
                                       sw.WriteLine("   \"Stmt_Declaration_Number\": \"" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_NUMBER"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_NUMBER"].ToString()) + "\",");
                                       sw.WriteLine("   \"Stmt_Declaration_Date\": \"" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_DATE"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_DECLARATION_DATE"].ToString()) + "\",");
                                       sw.WriteLine("   \"Stmt_Type\": \"" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_TYPE"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_TYPE"].ToString()) + "\",");
                                       sw.WriteLine("   \"Stmt_Code\": \"" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_CODE"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_CODE"].ToString()) + "\",");
                                       sw.WriteLine("   \"Stmt_Text\": \"" + (string.IsNullOrEmpty(Sw_statetbl.Rows[sw_state]["STMT_TEXT"].ToString()) ? " " : Sw_statetbl.Rows[sw_state]["STMT_TEXT"].ToString()) + "\"");

                                       if (sw_state == Sw_statetbl.Rows.Count - 1)
                                           sw.WriteLine("    }");
                                       else
                                           sw.WriteLine("    },");
                                   }
                                   sw.WriteLine("      ]");
                               }

                               DataTable Sw_reimp_tbl = new DataTable();
                               Sw_reimp_tbl = dss.Tables[15];
                               DataView Sw_reimp_view = Sw_reimp_tbl.DefaultView;
                               Sw_reimp_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                               DataTable Sw_reimptbl = Sw_reimp_view.ToTable();

                               if (Sw_reimptbl.Rows.Count > 0)
                               {
                                   sw.WriteLine(",");
                                   sw.WriteLine("      \"Re_import_Details\": [");
                                   for (int re_imp = 0; re_imp < Sw_reimptbl.Rows.Count; re_imp++)
                                   {
                                       sw.WriteLine("        {");
                                       sw.WriteLine("          \"Re_Import_Slno\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["RE_IMPORT_SLNO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["RE_IMPORT_SLNO"].ToString()) + "\",");
                                       sw.WriteLine("          \"Sb_No\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["SB_NO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["SB_NO"].ToString()) + "\",");
                                       sw.WriteLine("          \"Sb_Date\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["SB_DATE"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["SB_DATE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Port_Export\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["PORT_EXPORT"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["PORT_EXPORT"].ToString()) + "\",");
                                       sw.WriteLine("          \"Sb_Invoice_No\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["SB_INVOICE_NO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["SB_INVOICE_NO"].ToString()) + "\",");
                                       sw.WriteLine("          \"Sb_Invoice_Item_No\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["SB_INVOICE__ITEM_NO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["SB_INVOICE__ITEM_NO"].ToString()) + "\",");
                                       sw.WriteLine("          \"Notn_No\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["NOTN_NO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["NOTN_NO"].ToString()) + "\",");
                                       sw.WriteLine("          \"Notn_Slno\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["NOTN_SLNO"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["NOTN_SLNO"].ToString()) + "\",");
                                       sw.WriteLine("          \"Export_Freight\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["EXPORT_FREIGHT"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["EXPORT_FREIGHT"].ToString()) + "\",");
                                       sw.WriteLine("          \"Export_Insurance\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["EXPORT_INSURANCE"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["EXPORT_INSURANCE"].ToString()) + "\",");
                                       sw.WriteLine("          \"Customs_Duty\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["CUSTOMS_DUTY"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["CUSTOMS_DUTY"].ToString()) + "\",");
                                       sw.WriteLine("          \"Excise_Duty\": \"" + (string.IsNullOrEmpty(Sw_reimptbl.Rows[re_imp]["EXCISE_DUTY"].ToString()) ? " " : Sw_reimptbl.Rows[re_imp]["EXCISE_DUTY"].ToString()) + "\"");

                                       if (re_imp == Sw_reimptbl.Rows.Count - 1)
                                           sw.WriteLine("    }");
                                       else
                                           sw.WriteLine("    },");
                                   }
                                   sw.WriteLine("      ]");
                               }
                               //---
                               if (itm == items.Rows.Count - 1)
                                   sw.WriteLine("    }");
                               else
                                   sw.WriteLine("    },");// ---- end item------
                           }
                           sw.WriteLine("  ]");
                       }
                       if (inv == dss.Tables[6].Rows.Count - 1)
                           sw.WriteLine("    }");
                       else
                           sw.WriteLine("    },");
                       // ----- end inv -------
                   }
                   sw.WriteLine("  ]");
               }
               //-------

               if (Connection.COMPANYID() == "3267")
               {
                   if (dss.Tables.Count > 17 && dss.Tables[17].Rows.Count > 0)
                   {
                       sw.WriteLine(",");
                       sw.WriteLine("      \"Other_Details\": [");

                       for (int other = 0; other < dss.Tables[17].Rows.Count; other++)
                       {
                           var row = dss.Tables[17].Rows[other];

                           sw.WriteLine("        {");

                           sw.WriteLine("          \"Bill_To\": \"" + (string.IsNullOrEmpty(row["BILL_TO"].ToString()) ? " " : row["BILL_TO"].ToString()) + "\",");
                           sw.WriteLine("          \"Free_Days\": \"" + (string.IsNullOrEmpty(row["FREE_DAYS"].ToString()) ? " " : row["FREE_DAYS"].ToString()) + "\",");
                           sw.WriteLine("          \"Cfs_Movement_Status\": \"" + (string.IsNullOrEmpty(row["CFS_MOVEMENT_STATUS"].ToString()) ? " " : row["CFS_MOVEMENT_STATUS"].ToString()) + "\",");
                           sw.WriteLine("          \"CFS_Port_In_Date\": \"" + (string.IsNullOrEmpty(row["CFS_Port_In_Date"].ToString()) ? " " : row["CFS_Port_In_Date"].ToString()) + "\",");
                           sw.WriteLine("          \"Port_Out\": \"" + (string.IsNullOrEmpty(row["PORT_OUT"].ToString()) ? " " : row["PORT_OUT"].ToString()) + "\",");
                           sw.WriteLine("          \"Mines_No_Dt\": \"" + (string.IsNullOrEmpty(row["MINES_NO_DT"].ToString()) ? " " : row["MINES_NO_DT"].ToString()) + "\",");
                           sw.WriteLine("          \"Assessed_Dt\": \"" + (string.IsNullOrEmpty(row["ASSESSED_DT"].ToString()) ? " " : row["ASSESSED_DT"].ToString()) + "\",");
                           sw.WriteLine("          \"Ooc_Dt\": \"" + (string.IsNullOrEmpty(row["OOC_DT"].ToString()) ? " " : row["OOC_DT"].ToString()) + "\",");
                           sw.WriteLine("          \"Obl_Fta\": \"" + (string.IsNullOrEmpty(row["OBL_FTA"].ToString()) ? " " : row["OBL_FTA"].ToString()) + "\",");
                           sw.WriteLine("          \"Remarks\": \"" + (string.IsNullOrEmpty(row["REMARKS"].ToString()) ? " " : row["REMARKS"].ToString()) + "\",");
                           sw.WriteLine("          \"Name_of_the_CFS\": \"" + (string.IsNullOrEmpty(row["Name_of_the_CFS"].ToString()) ? " " : row["Name_of_the_CFS"].ToString()) + "\",");

                           // ✅ last field (NO comma)
                           sw.WriteLine("          \"No_of_Containers\": \"" + (string.IsNullOrEmpty(row["NO_OF_CONTAINERS"].ToString()) ? " " : row["NO_OF_CONTAINERS"].ToString()) + "\"");

                           if (other == dss.Tables[17].Rows.Count - 1)
                               sw.WriteLine("        }");
                           else
                               sw.WriteLine("        },");
                       }

                       sw.WriteLine("      ]");
                   }
               } 
               //-------NO_OF_CONTAINERS


               //------end-----   
           }
           sw.WriteLine("}");
       }

       //System.Web.HttpContext.Current.Response.Write(sw.ToString());
       //System.Web.HttpContext.Current.Response.Flush();
       //Response.Write(sw.ToString());
       //Response.Flush();
       // Response.End();
       HttpContext.Current.ApplicationInstance.CompleteRequest();

       //ViewState["JSON_filename"] = "Imp_" + txtInvoiceNo.Text + ".JSON";
       string folrder_path = errorFolder + "_" + Imp_exp + job_no + ".JSON";

       sw.Close();
       #endregion Json

       return Post_API_Fulljob(Imp_exp, job_no, filePath);
   }
   public string Exp_JSON_Generate(DataSet dss, string job_no, string Imp_exp, string filetype)
   {
       StreamWriter sw;
       string errorFolder = HttpContext.Current.Server.MapPath("~/Submission/" + Connection.Company_License() + "/" + Imp_exp + "/" + filetype);
       if (!Directory.Exists(errorFolder))
       {
           Directory.CreateDirectory(errorFolder);
       }

       string filePath = Path.Combine(errorFolder, Imp_exp + "_" + job_no + ".JSON");

       if (File.Exists(filePath))
       {
           File.Delete(filePath);
       }
       sw = new StreamWriter(filePath, true);
       string Com_Id = Connection.COMPANYID();
       trans_mode = dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString().ToUpper();
       #region E_Json
       if (dss.Tables[0].Rows.Count > 0)
       {
           DataRow row = dss.Tables[0].Rows[0];
           sw.WriteLine("{");
           sw.WriteLine("      \"Company_Id\": \"" + Connection.Company_License() + "\",");
           if (Connection.COMPANYID() == "3288" || Connection.COMPANYID() == "115" || Connection.COMPANYID() == "1033")
           {
               sw.WriteLine("      \"Group_name\": \"" + Connection.Current_Group() + "\",");
               sw.WriteLine("      \"Wrk_prd\": \"" + Connection.WorkingPeriod() + "\",");
           }
           if (dss.Tables[20].Rows.Count > 0 && (Com_Id != "2814" || Com_Id != "3082" || Com_Id != "3253"))
           {
               sw.WriteLine("      \"SB_NO\": \"" + (string.IsNullOrEmpty(dss.Tables[20].Rows[0]["SB_NO"].ToString()) ? " " : dss.Tables[20].Rows[0]["SB_NO"].ToString()) + "\",");
               sw.WriteLine("      \"SB_DATE\": \"" + (dss.Tables[20].Rows[0]["SB_DATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(dss.Tables[20].Rows[0]["SB_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
               if (Com_Id == "3267")
               {
                   sw.WriteLine("      \"Maintenance_Status\": \"" + "SB Updated" + "\",");
               }
           }
           else if (Com_Id == "3267")
           {
               sw.WriteLine("      \"Maintenance_Status\": \"" + "Open" + "\",");
           }
           sw.WriteLine("  \"JobDetails\": {");
           sw.WriteLine("    \"Job_No\": \"" + row["JOBNO"] + "\",");
           sw.WriteLine("    \"Job_Date\": \"" + (row["JOBDATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(row["JOBDATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
           sw.WriteLine("    \"Transport_Mode\": \"" + (string.IsNullOrEmpty(row["TRANSPORT_MODE"].ToString()) ? " " : row["TRANSPORT_MODE"].ToString()) + "\",");
           sw.WriteLine("    \"Customs_House\": \"" + (string.IsNullOrEmpty(row["CUSTOMS_HOUSE"].ToString()) ? " " : row["CUSTOMS_HOUSE"].ToString()) + "\",");
           sw.WriteLine("    \"Customs_House_Name\": \"" + (string.IsNullOrEmpty(row["CUSTOMS_HOUSE_NAME"].ToString()) ? " " : row["CUSTOMS_HOUSE_NAME"].ToString()) + "\",");
           sw.WriteLine("    \"Sb_Type\": \"" + (string.IsNullOrEmpty(row["SB_TYPE"].ToString()) ? " " : row["SB_TYPE"].ToString()) + "\",");
           sw.WriteLine("    \"Exporter_Name\": \"" + (string.IsNullOrEmpty(row["EXPORTER_NAME"].ToString()) ? " " : row["EXPORTER_NAME"].ToString()) + "\",");
           sw.WriteLine("    \"Branch_No\": \"" + (string.IsNullOrEmpty(row["BRANCH_NO"].ToString()) ? " " : row["BRANCH_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Iec_No\": \"" + (string.IsNullOrEmpty(row["IEC_NO"].ToString()) ? " " : row["IEC_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Address1\": \"" + (string.IsNullOrEmpty(row["ADDRESS1"].ToString()) ? " " : row["ADDRESS1"].ToString()) + "\",");
           sw.WriteLine("    \"Address2\": \"" + (string.IsNullOrEmpty(row["ADDRESS2"].ToString()) ? " " : row["ADDRESS2"].ToString()) + "\",");
           sw.WriteLine("    \"Address3\": \"" + (string.IsNullOrEmpty(row["ADDRESS3"].ToString()) ? " " : row["ADDRESS3"].ToString()) + "\",");
           sw.WriteLine("    \"Address4\": \"" + (string.IsNullOrEmpty(row["ADDRESS4"].ToString()) ? " " : row["ADDRESS4"].ToString()) + "\",");
           sw.WriteLine("    \"Address5\": \"" + (string.IsNullOrEmpty(row["ADDRESS5"].ToString()) ? " " : row["ADDRESS5"].ToString()) + "\",");
           sw.WriteLine("    \"Adcode\": \"" + (string.IsNullOrEmpty(row["ADCODE"].ToString()) ? " " : row["ADCODE"].ToString()) + "\",");
           sw.WriteLine("    \"Bank_Account\": \"" + (string.IsNullOrEmpty(row["BANK_ACCOUNT"].ToString()) ? " " : row["BANK_ACCOUNT"].ToString()) + "\",");
           sw.WriteLine("    \"Drawback_Account\": \"" + (string.IsNullOrEmpty(row["DRAWBACK_ACCOUNT"].ToString()) ? " " : row["DRAWBACK_ACCOUNT"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Name\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_NAME"].ToString()) ? " " : row["CONSIGNEE_NAME"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add1\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD1"].ToString()) ? " " : row["CONSIGNEE_ADD1"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add2\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD2"].ToString()) ? " " : row["CONSIGNEE_ADD2"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add3\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD3"].ToString()) ? " " : row["CONSIGNEE_ADD3"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add4\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD4"].ToString()) ? " " : row["CONSIGNEE_ADD4"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Add5\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_ADD5"].ToString()) ? " " : row["CONSIGNEE_ADD5"].ToString()) + "\",");
           sw.WriteLine("    \"Country_Discharge\": \"" + (string.IsNullOrEmpty(row["COUNTRY_DISCHARGE"].ToString()) ? " " : row["COUNTRY_DISCHARGE"].ToString()) + "\",");
           sw.WriteLine("    \"Port_Discharge\": \"" + (string.IsNullOrEmpty(row["PORT_DISCHARGE"].ToString()) ? " " : row["PORT_DISCHARGE"].ToString()) + "\",");
           sw.WriteLine("    \"Country_Final_Dest\": \"" + (string.IsNullOrEmpty(row["COUNTRY_FINAL_DEST"].ToString()) ? " " : row["COUNTRY_FINAL_DEST"].ToString()) + "\",");
           sw.WriteLine("    \"Port_Final_Dest\": \"" + (string.IsNullOrEmpty(row["PORT_FINAL_DEST"].ToString()) ? " " : row["PORT_FINAL_DEST"].ToString()) + "\",");
           sw.WriteLine("    \"State_Of_Export\": \"" + (string.IsNullOrEmpty(row["STATE_OF_EXPORT"].ToString()) ? " " : row["STATE_OF_EXPORT"].ToString()) + "\",");
           sw.WriteLine("    \"Nfei\": \"" + (string.IsNullOrEmpty(row["NFEI"].ToString()) ? " " : row["NFEI"].ToString()) + "\",");
           sw.WriteLine("    \"Nfei_Type\": \"" + (string.IsNullOrEmpty(row["NFEI_TYPE"].ToString()) ? " " : row["NFEI_TYPE"].ToString()) + "\",");
           sw.WriteLine("    \"Rbi_Waiver_No\": \"" + (string.IsNullOrEmpty(row["RBI_WAIVER_NO"].ToString()) ? " " : row["RBI_WAIVER_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Rbi_Waiver_Date\": \"" + (string.IsNullOrEmpty(row["RBI_WAIVER_DATE"].ToString()) ? " " : row["RBI_WAIVER_DATE"].ToString()) + "\",");
           sw.WriteLine("    \"Marks_No\": \"" + (string.IsNullOrEmpty(row["MARKS_NO"].ToString()) ? " " : row["MARKS_NO"].ToString()) + "\",");
           sw.WriteLine("    \"File_Ref_No\": \"" + (string.IsNullOrEmpty(row["FILE_REF_NO"].ToString()) ? " " : row["FILE_REF_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Type_Of_Exporter\": \"" + (string.IsNullOrEmpty(row["TYPE_OF_EXPORTER"].ToString()) ? " " : row["TYPE_OF_EXPORTER"].ToString()) + "\",");
           sw.WriteLine("    \"Consignee_Branchslno\": \"" + (string.IsNullOrEmpty(row["CONSIGNEE_BRANCHSLNO"].ToString()) ? " " : row["CONSIGNEE_BRANCHSLNO"].ToString()) + "\",");
           sw.WriteLine("    \"Gstn_Type\": \"" + (string.IsNullOrEmpty(row["GSTN_TYPE"].ToString()) ? " " : row["GSTN_TYPE"].ToString()) + "\",");
           sw.WriteLine("    \"Gstn_Id\": \"" + (string.IsNullOrEmpty(row["GSTN_ID"].ToString()) ? " " : row["GSTN_ID"].ToString()) + "\",");
           sw.WriteLine("    \"Party_Ref_No\": \"" + (string.IsNullOrEmpty(row["PARTY_REF_NO"].ToString()) ? " " : row["PARTY_REF_NO"].ToString()) + "\",");
           sw.WriteLine("    \"Ifsc_Code\": \"" + (string.IsNullOrEmpty(row["IFSC_CODE"].ToString()) ? " " : row["IFSC_CODE"].ToString()) + "\",");
           sw.WriteLine("    \"Jobno_Ps\": \"" + (string.IsNullOrEmpty(row["JOBNO_PS"].ToString()) ? " " : row["JOBNO_PS"].ToString()) + "\",");
           sw.WriteLine("    \"Port_Of_Loading\": \"" + (string.IsNullOrEmpty(row["PORT_OF_LOADING"].ToString()) ? " " : row["PORT_OF_LOADING"].ToString()) + "\"");
           sw.WriteLine("		 }");

           if (dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() == "Air")
           {
               if (dss.Tables[1].Rows.Count > 0)
               {
                   sw.WriteLine("  ,");
                   sw.WriteLine("     \"Annexure_Air_Details\"" + ":" + "{");
                   sw.WriteLine("    \"Annex_Air_Sealno\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_SEALNO"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_SEALNO"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Seal_Agency\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_SEAL_AGENCY"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_SEAL_AGENCY"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Nature_Of_Cargo\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["NATURE_OF_CARGO"].ToString()) ? " " : dss.Tables[1].Rows[0]["NATURE_OF_CARGO"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Marks_Nos\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Total_Packages\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Unit_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Freight_Amt\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_FREIGHT_AMT"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_FREIGHT_AMT"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Insurance_Amt\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_INSURANCE_AMT"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_INSURANCE_AMT"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Gross_Weight\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Gr_Unit_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Net_Weight\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Mawb_No\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Hawb_No\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Mawb_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Hawb_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_HAWB_DATE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_HAWB_DATE"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Total_Packages_Mawb\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES_MAWB"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES_MAWB"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Rotation_No\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Rotation_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Air_Fob_Value\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_AIR_FOB_VALUE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_AIR_FOB_VALUE"].ToString()) + "\"");
                   sw.WriteLine("		 }");
               }
           }
           else
           {
               if (dss.Tables[1].Rows.Count > 0)
               {
                   sw.WriteLine("  ,");
                   sw.WriteLine("     \"Annexure_Sea_Details\"" + ":" + "{");
                   sw.WriteLine("    \"Annex_Sea_Fac_Stuffed\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Sample_Accom\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Nature_Of_Cargo\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["NATURE_OF_CARGO"].ToString()) ? " " : dss.Tables[1].Rows[0]["NATURE_OF_CARGO"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Marks_Nos\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Total_Packages\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Loose_Packets\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_No_Containers\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Gross_Weight\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Net_Weight\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Unit_Measurement\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Rotation_No\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Rotation_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Fob_Value\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_FOB_VALUE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_FOB_VALUE"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Seal_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Factory_Add\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_FACTORY_ADD"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_FACTORY_ADD"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Voyageno\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_VOYAGENO"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_VOYAGENO"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Vesselno\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_VESSELNO"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_VESSELNO"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Vessel_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_VESSEL_DATE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_VESSEL_DATE"].ToString()) + "\",");
                   sw.WriteLine("    \"Annex_Sea_Pkg_Unit_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[1].Rows[0]["ANNEX_SEA_PKG_UNIT_CODE"].ToString()) ? " " : dss.Tables[1].Rows[0]["ANNEX_SEA_PKG_UNIT_CODE"].ToString()) + "\"");
                   sw.WriteLine("		 }");
               }
           }

           if (dss.Tables[2].Rows.Count > 0)
           {
               sw.WriteLine("  ,");
               sw.WriteLine("      \"Annexure_Container_Details\"" + ": [");

               for (int con = 0; con < dss.Tables[2].Rows.Count; con++)
               {
                   sw.WriteLine("    {");
                   sw.WriteLine("      \"Annex_Sea_Con_Containerno\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_CONTAINERNO"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_CONTAINERNO"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Con_Size\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SIZE"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SIZE"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Con_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_TYPE"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_TYPE"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Con_Excise_Sealno\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Con_Seal_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEAL_DATE"].ToString()) ? " " : DateTime.Parse(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEAL_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Con_Sealtype_Indicator\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Con_Seal_Deviceid\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEAL_DEVICEID"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_SEAL_DEVICEID"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Con_Doc_Type\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_DOC_TYPE"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_DOC_TYPE"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Con_Doc_Number\": \"" + (string.IsNullOrEmpty(dss.Tables[2].Rows[con]["ANNEX_SEA_CON_DOC_NUMBER"].ToString()) ? " " : dss.Tables[2].Rows[con]["ANNEX_SEA_CON_DOC_NUMBER"].ToString()) + "\"");

                   if (con == dss.Tables[2].Rows.Count - 1)
                       sw.WriteLine("    }");
                   else
                       sw.WriteLine("},");
               }
               sw.WriteLine("  ]");
           }
           


           if (dss.Tables[3].Rows.Count > 0)
           {
               sw.WriteLine("  ,");
               sw.WriteLine("      \"Annexure_Package_Details\"" + ": [");

               for (int pck = 0; pck < dss.Tables[3].Rows.Count; pck++)
               {
                   sw.WriteLine("    {");
                   sw.WriteLine("      \"Annex_Sea_Pack_Group\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_GROUP"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_GROUP"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Pack_From\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_FROM"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_FROM"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Pack_To\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_TO"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_TO"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Pack_Packagetype\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Pack_Fromdesc\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_FROMDESC"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_FROMDESC"].ToString()) + "\",");
                   sw.WriteLine("      \"Annex_Sea_Pack_Todesc\": \"" + (string.IsNullOrEmpty(dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_TODESC"].ToString()) ? " " : dss.Tables[3].Rows[pck]["ANNEX_SEA_PACK_TODESC"].ToString()) + "\"");

                   if (pck == dss.Tables[3].Rows.Count - 1)
                       sw.WriteLine("    }");
                   else
                       sw.WriteLine("},");
               }

               sw.WriteLine("  ]");
           }
           
           if (dss.Tables[8].Rows.Count > 0)
           {
               sw.WriteLine(" ,");
               sw.WriteLine("     \"Annexure_C1_Details\"" + ":" + "{");
               sw.WriteLine("  \"Annex_Exportername\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_EXPORTERNAME"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_EXPORTERNAME"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Ieccode\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_IECCODE"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_IECCODE"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Br_Slno\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_BR_SLNO"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_BR_SLNO"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Exam_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_EXAM_DATE"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_EXAM_DATE"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Exam_Officer\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_EXAM_OFFICER"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_EXAM_OFFICER"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Exam_Design\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_EXAM_DESIGN"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_EXAM_DESIGN"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Super_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_SUPER_NAME"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_SUPER_NAME"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Super_Design\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_SUPER_DESIGN"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_SUPER_DESIGN"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Commission_Rate\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_COMMISSION_RATE"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_COMMISSION_RATE"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Division\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_DIVISION"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_DIVISION"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Range\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_RANGE"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_RANGE"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Verified_Exam_Officer\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Sample_Drawn\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Seal_No\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_SEAL_NO"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_SEAL_NO"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Address1\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_ADDRESS1"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_ADDRESS1"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Address2\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_ADDRESS2"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_ADDRESS2"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Address3\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_ADDRESS3"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_ADDRESS3"].ToString()) + "\",");
               sw.WriteLine("  \"Annex_Address4\": \"" + (string.IsNullOrEmpty(dss.Tables[8].Rows[0]["ANNEX_ADDRESS4"].ToString()) ? " " : dss.Tables[8].Rows[0]["ANNEX_ADDRESS4"].ToString()) + "\"");
               sw.WriteLine("}");

           }

           if (dss.Tables[4].Rows.Count > 0)
           {
               sw.WriteLine("    ,");
               sw.WriteLine("      \"Invoice_Details\"" + ": [");

               for (int inv = 0; inv < dss.Tables[4].Rows.Count; inv++)
               {
                   sw.WriteLine("{");
                   sw.WriteLine("          \"Invoice_Slno\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_SLNO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INVOICE_SLNO"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Invoice_No\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_NO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INVOICE_NO"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Invoice_Date\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_DATE"].ToString()) ? " " : DateTime.Parse(dss.Tables[4].Rows[inv]["INVOICE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\"" + ",");
                   sw.WriteLine("          \"Payment_Method\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PAYMENT_METHOD"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PAYMENT_METHOD"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Period_Payment\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PERIOD_PAYMENT"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PERIOD_PAYMENT"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Invoice_Value\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_VALUE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INVOICE_VALUE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Invoice_Currency\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INVOICE_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INVOICE_CURRENCY"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Exchange_Rate\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["EXCHANGE_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["EXCHANGE_RATE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Contract_No\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["CONTRACT_NO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["CONTRACT_NO"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Terms\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["TERMS"].ToString()) ? " " : dss.Tables[4].Rows[inv]["TERMS"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Buyer\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Buyer_Name\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_NAME"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_NAME"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Buyer_Address\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Buyer_Address1\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS1"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS1"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Buyer_Address2\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS2"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS2"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Buyer_Address3\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS3"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS3"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Buyer_Address4\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["BUYER_ADDRESS4"].ToString()) ? " " : dss.Tables[4].Rows[inv]["BUYER_ADDRESS4"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Commission_Rate\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["COMMISSION_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["COMMISSION_RATE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Commission_Charges\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["COMMISSION_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["COMMISSION_CHARGES"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Commission_Currency\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["COMMISSION_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["COMMISSION_CURRENCY"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Fob_Rate\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FOB_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FOB_RATE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Fob_Charges\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FOB_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FOB_CHARGES"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Fob_Currency\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FOB_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FOB_CURRENCY"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Packmisc_Rate\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PACKMISC_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PACKMISC_RATE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Packmisc_Charges\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PACKMISC_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PACKMISC_CHARGES"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Packmisc_Currency\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["PACKMISC_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["PACKMISC_CURRENCY"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Other_Deduction_Rate\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_RATE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Other_Deduction_Charges\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_CHARGES"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Other_Deduction_Currency\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["OTHER_DEDUCTION_CURRENCY"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Freight_Rate\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FREIGHT_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FREIGHT_RATE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Freight_Charges\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FREIGHT_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FREIGHT_CHARGES"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Freight_Currency\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FREIGHT_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FREIGHT_CURRENCY"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Freight_Exrate\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["FREIGHT_EXRATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["FREIGHT_EXRATE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Insurance_Rate\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INSURANCE_RATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INSURANCE_RATE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Insurance_Charges\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INSURANCE_CHARGES"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INSURANCE_CHARGES"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Insurance_Currency\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INSURANCE_CURRENCY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INSURANCE_CURRENCY"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Insurance_Exrate\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["INSURANCE_EXRATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["INSURANCE_EXRATE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Wheather_Unit_Price\"" + ":" + "\"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["WHEATHER_UNIT_PRICE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["WHEATHER_UNIT_PRICE"].ToString()) + "\"" + ",");
                   sw.WriteLine("          \"Non_Std_Effect_Dt_Exp\": \"" + (dss.Tables[4].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString() == "1900-01-01 00:00:00.000" ? "" : DateTime.Parse(dss.Tables[4].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                   sw.WriteLine("          \"Non_Std_Bankname\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["NON_STD_BANKNAME"].ToString()) ? " " : dss.Tables[4].Rows[inv]["NON_STD_BANKNAME"].ToString()) + "\",");
                   sw.WriteLine("          \"Non_Std_Certificate_No\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) ? " " : dss.Tables[4].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) + "\",");
                   sw.WriteLine("          \"Non_Std_Certificate_Date\": \"" + (dss.Tables[4].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString() == "1900-01-01 00:00:00.000" ? "" : DateTime.Parse(dss.Tables[4].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                   sw.WriteLine("          \"Terms_Place\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["TERMS_PLACE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["TERMS_PLACE"].ToString()) + "\",");
                   sw.WriteLine("          \"Thirdparty_Name\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["THIRDPARTY_NAME"].ToString()) ? " " : dss.Tables[4].Rows[inv]["THIRDPARTY_NAME"].ToString()) + "\",");
                   sw.WriteLine("          \"Thirdparty_Add1\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["THIRDPARTY_ADD1"].ToString()) ? " " : dss.Tables[4].Rows[inv]["THIRDPARTY_ADD1"].ToString()) + "\",");
                   sw.WriteLine("          \"Thirdparty_Add2\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["THIRDPARTY_ADD2"].ToString()) ? " " : dss.Tables[4].Rows[inv]["THIRDPARTY_ADD2"].ToString()) + "\",");
                   sw.WriteLine("          \"Thirdparty_City\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["THIRDPARTY_CITY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["THIRDPARTY_CITY"].ToString()) + "\",");
                   sw.WriteLine("          \"T_Party_Country_Sub_Div\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) ? " " : dss.Tables[4].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) + "\",");
                   sw.WriteLine("          \"T_Party_Country_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) + "\",");
                   sw.WriteLine("          \"T_Party_Pin\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["T_PARTY_PIN"].ToString()) ? " " : dss.Tables[4].Rows[inv]["T_PARTY_PIN"].ToString()) + "\",");
                   sw.WriteLine("          \"Authorized_Economic_Operator_Code\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) + "\",");
                   sw.WriteLine("          \"A_E_O_Country\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["A_E_O_COUNTRY"].ToString()) ? " " : dss.Tables[4].Rows[inv]["A_E_O_COUNTRY"].ToString()) + "\",");
                   sw.WriteLine("          \"Authorized_Economic_Operator\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) ? " " : dss.Tables[4].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) + "\",");
                   sw.WriteLine("          \"Doc_Recd_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["DOC_RECD_DATE"].ToString()) ? " " : dss.Tables[4].Rows[inv]["DOC_RECD_DATE"].ToString()) + "\",");
                   sw.WriteLine("          \"Inv_Created_Date\": \"" + (string.IsNullOrEmpty(dss.Tables[4].Rows[inv]["DATE_TIME"].ToString()) ? " " : DateTime.Parse(dss.Tables[4].Rows[inv]["DATE_TIME"].ToString()).ToString("dd-MMM-yyyy")) + "\"");
                  

                   DataTable Ex_item_tbl = new DataTable();
                   Ex_item_tbl = dss.Tables[6];
                   DataView Ex_Item_view = Ex_item_tbl.DefaultView;
                   string a = dss.Tables[4].Rows[inv]["INVOICE_SLNO"].ToString();
                   Ex_Item_view.RowFilter = "INVOICE_SLNO = '" + a + "'";
                   DataTable Ex_items = Ex_Item_view.ToTable();

                   if (Ex_items.Rows.Count > 0)
                   {
                       sw.WriteLine("  ,");
                       sw.WriteLine("          \"Item_details\"" + ":[");

                       for (int itm = 0; itm < Ex_items.Rows.Count; itm++)
                       {
                           sw.WriteLine("{");
                           sw.WriteLine("  \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["INVOICE_SLNO"].ToString()) ? " " : Ex_items.Rows[itm]["INVOICE_SLNO"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Slno\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_SLNO"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_SLNO"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Description\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_DESCRIPTION"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_DESCRIPTION"].ToString()) + "\",");
                           sw.WriteLine("  \"Ritcno\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["RITCNO"].ToString()) ? " " : Ex_items.Rows[itm]["RITCNO"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Qty\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_QTY"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_QTY"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Qty_Code\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_QTY_CODE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_QTY_CODE"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Unit_Price\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_UNIT_PRICE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_UNIT_PRICE"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Per\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_PER"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_PER"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Amount\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_AMOUNT"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_AMOUNT"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Pmvvalue\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_PMVVALUE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_PMVVALUE"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Scheme_Code\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_SCHEME_CODE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_SCHEME_CODE"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Accessories_Desc\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_ACCESSORIES_DESC"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_ACCESSORIES_DESC"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Ar4_No\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_AR4_NO"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_AR4_NO"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Ar4_Date\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_AR4_DATE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_AR4_DATE"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Commission_Rate\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_COMMISSION_RATE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_COMMISSION_RATE"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Division\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_DIVISION"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_DIVISION"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Range\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_RANGE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_RANGE"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Remarks\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_REMARKS"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_REMARKS"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Ieccode\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_IECCODE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_IECCODE"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Exporter_Name\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_EXPORTER_NAME"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_EXPORTER_NAME"].ToString()) + "\",");
                           sw.WriteLine("  \"Br_Slno\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["BR_SLNO"].ToString()) ? " " : Ex_items.Rows[itm]["BR_SLNO"].ToString()) + "\",");
                           sw.WriteLine("  \"Address1\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS1"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS1"].ToString()) + "\",");
                           sw.WriteLine("  \"Address2\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS2"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS2"].ToString()) + "\",");
                           sw.WriteLine("  \"Address3\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS3"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS3"].ToString()) + "\",");
                           sw.WriteLine("  \"Address4\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS4"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS4"].ToString()) + "\",");
                           sw.WriteLine("  \"Address5\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ADDRESS5"].ToString()) ? " " : Ex_items.Rows[itm]["ADDRESS5"].ToString()) + "\",");
                           sw.WriteLine("  \"Item_Str_Code\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ITEM_STR_CODE"].ToString()) ? " " : Ex_items.Rows[itm]["ITEM_STR_CODE"].ToString()) + "\",");
                           sw.WriteLine("  \"Reward_Points\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["REWARD_POINTS"].ToString()) ? " " : Ex_items.Rows[itm]["REWARD_POINTS"].ToString()) + "\",");
                           sw.WriteLine("  \"Pmv_Value\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["PMV_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["PMV_VALUE"].ToString()) + "\",");
                           sw.WriteLine("  \"Fob_Value\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["FOB_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["FOB_VALUE"].ToString()) + "\",");
                           sw.WriteLine("  \"Drawback_Value\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["DRAWBACK_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["DRAWBACK_VALUE"].ToString()) + "\",");
                           sw.WriteLine("  \"Cess_Yn\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["CESS_YN"].ToString()) ? " " : Ex_items.Rows[itm]["CESS_YN"].ToString()) + "\",");
                           sw.WriteLine("  \"Str_Rate\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["STR_RATE"].ToString()) ? " " : Ex_items.Rows[itm]["STR_RATE"].ToString()) + "\",");
                           sw.WriteLine("  \"Str_Amount\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["STR_AMOUNT"].ToString()) ? " " : Ex_items.Rows[itm]["STR_AMOUNT"].ToString()) + "\",");
                           sw.WriteLine("  \"Manufacturer_Producer\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) ? " " : Ex_items.Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) + "\",");
                           sw.WriteLine("  \"M_P_Grower_Code\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_CODE"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_CODE"].ToString()) + "\",");
                           sw.WriteLine("  \"M_P_Grower_Add1\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_ADD1"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_ADD1"].ToString()) + "\",");
                           sw.WriteLine("  \"M_P_Grower_Add2\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_ADD2"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_ADD2"].ToString()) + "\",");
                           sw.WriteLine("  \"M_P_Grower_City\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_CITY"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_CITY"].ToString()) + "\",");
                           sw.WriteLine("  \"M_P_Grower_Country_Subdiv\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) + "\",");
                           sw.WriteLine("  \"M_P_Grower_Pin\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_PIN"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_PIN"].ToString()) + "\",");
                           sw.WriteLine("  \"M_P_Grower_Country\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["M_P_GROWER_COUNTRY"].ToString()) ? " " : Ex_items.Rows[itm]["M_P_GROWER_COUNTRY"].ToString()) + "\",");
                           sw.WriteLine("  \"Source_State\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["SOURCE_STATE"].ToString()) ? " " : Ex_items.Rows[itm]["SOURCE_STATE"].ToString()) + "\",");
                           sw.WriteLine("  \"Transit_Country\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["TRANSIT_COUNTRY"].ToString()) ? " " : Ex_items.Rows[itm]["TRANSIT_COUNTRY"].ToString()) + "\",");
                           sw.WriteLine("  \"Accessory_Status\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ACCESSORY_STATUS"].ToString()) ? " " : Ex_items.Rows[itm]["ACCESSORY_STATUS"].ToString()) + "\",");
                           sw.WriteLine("  \"Hawb_No\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["HAWB_NO"].ToString()) ? " " : Ex_items.Rows[itm]["HAWB_NO"].ToString()) + "\",");
                           sw.WriteLine("  \"Total_Pkgs\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["TOTAL_PKGS"].ToString()) ? " " : Ex_items.Rows[itm]["TOTAL_PKGS"].ToString()) + "\",");
                           sw.WriteLine("  \"Enduse_Item\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["ENDUSE_ITEM"].ToString()) ? " " : Ex_items.Rows[itm]["ENDUSE_ITEM"].ToString()) + "\",");
                           sw.WriteLine("  \"Igst_Payment\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["IGST_PAYMENT"].ToString()) ? " " : Ex_items.Rows[itm]["IGST_PAYMENT"].ToString()) + "\",");
                           sw.WriteLine("  \"Taxable_Value\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["TAXABLE_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["TAXABLE_VALUE"].ToString()) + "\",");
                           sw.WriteLine("  \"Igst_Amt\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["IGST_AMT"].ToString()) ? " " : Ex_items.Rows[itm]["IGST_AMT"].ToString()) + "\",");
                           sw.WriteLine("  \"Gstn_Type\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["GSTN_TYPE"].ToString()) ? " " : Ex_items.Rows[itm]["GSTN_TYPE"].ToString()) + "\",");
                           sw.WriteLine("  \"Gstn_Id\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["GSTN_ID"].ToString()) ? " " : Ex_items.Rows[itm]["GSTN_ID"].ToString()) + "\",");
                           sw.WriteLine("  \"Igst_Rate\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["IGST_RATE"].ToString()) ? " " : Ex_items.Rows[itm]["IGST_RATE"].ToString()) + "\",");
                           sw.WriteLine("  \"Pmv_Method\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["PMV_METHOD"].ToString()) ? " " : Ex_items.Rows[itm]["PMV_METHOD"].ToString()) + "\",");
                           sw.WriteLine("  \"Pmv_Rate\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["PMV_RATE"].ToString()) ? " " : Ex_items.Rows[itm]["PMV_RATE"].ToString()) + "\",");
                           sw.WriteLine("  \"Pmv_Per_Unit\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["PMV_PER_UNIT"].ToString()) ? " " : Ex_items.Rows[itm]["PMV_PER_UNIT"].ToString()) + "\",");
                           sw.WriteLine("  \"Rodtep\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["RODTEP"].ToString()) ? " " : Ex_items.Rows[itm]["RODTEP"].ToString()) + "\",");
                           sw.WriteLine("  \"Rodtep_Value\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["RODTEP_VALUE"].ToString()) ? " " : Ex_items.Rows[itm]["RODTEP_VALUE"].ToString()) + "\",");
                           sw.WriteLine("  \"Itm_Created_Date\": \"" + (string.IsNullOrEmpty(Ex_items.Rows[itm]["DATE_TIME"].ToString()) ? " " : DateTime.Parse(Ex_items.Rows[itm]["DATE_TIME"].ToString()).ToString("dd-MMM-yyyy")) + "\"");

                           DataTable Draw_tbl = new DataTable();
                           Draw_tbl = dss.Tables[7];
                           DataView Draw_view = Draw_tbl.DefaultView;
                           string item_slno = Ex_items.Rows[itm]["ITEM_SLNO"].ToString();
                           Draw_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";

                           DataTable Draw_Tbl = Draw_view.ToTable();

                           if (Draw_Tbl.Rows.Count > 0)
                           {
                               sw.WriteLine(",");
                               sw.WriteLine("          \"Drawback_Details\"" + ":[");
                               for (int draw = 0; draw < Draw_Tbl.Rows.Count; draw++)
                               {
                                   sw.WriteLine("{");
                                   sw.WriteLine("  \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["INVOICE_SLNO"].ToString()) ? " " : Draw_Tbl.Rows[draw]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("  \"Item_Slno\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["ITEM_SLNO"].ToString()) ? " " : Draw_Tbl.Rows[draw]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("  \"Scheme_Code\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["SCHEME_CODE"].ToString()) ? " " : Draw_Tbl.Rows[draw]["SCHEME_CODE"].ToString()) + "\",");
                                   sw.WriteLine("  \"Drawback_Slno\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_SLNO"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("  \"Drawback_Qty\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_QTY"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_QTY"].ToString()) + "\",");
                                   sw.WriteLine("  \"Drawback_Unit\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_UNIT"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_UNIT"].ToString()) + "\",");
                                   sw.WriteLine("  \"Drawback_Noofunits\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_NOOFUNITS"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_NOOFUNITS"].ToString()) + "\",");
                                   sw.WriteLine("  \"Drawback_Rate\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_RATE"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_RATE"].ToString()) + "\",");
                                   sw.WriteLine("  \"Drawback_Caps\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_CAPS"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_CAPS"].ToString()) + "\",");
                                   sw.WriteLine("  \"Drawback_Desc\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["DRAWBACK_DESC"].ToString()) ? " " : Draw_Tbl.Rows[draw]["DRAWBACK_DESC"].ToString()) + "\",");
                                   sw.WriteLine("  \"State_Level_Adv_Rate\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["STATE_LEVEL_ADV_RATE"].ToString()) ? " " : Draw_Tbl.Rows[draw]["STATE_LEVEL_ADV_RATE"].ToString()) + "\",");
                                   sw.WriteLine("  \"State_Level_Adv_Amt\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["STATE_LEVEL_ADV_AMT"].ToString()) ? " " : Draw_Tbl.Rows[draw]["STATE_LEVEL_ADV_AMT"].ToString()) + "\",");
                                   sw.WriteLine("  \"Central_Level_Adv_Rate\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["CENTRAL_LEVEL_ADV_RATE"].ToString()) ? " " : Draw_Tbl.Rows[draw]["CENTRAL_LEVEL_ADV_RATE"].ToString()) + "\",");
                                   sw.WriteLine("  \"Central_Level_Adv_Amt\": \"" + (string.IsNullOrEmpty(Draw_Tbl.Rows[draw]["CENTRAL_LEVEL_ADV_AMT"].ToString()) ? " " : Draw_Tbl.Rows[draw]["CENTRAL_LEVEL_ADV_AMT"].ToString()) + "\"");

                                   if (draw == Draw_Tbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }
                               sw.WriteLine("  ]");
                           }

                           DataTable Re_Exp_tbl = new DataTable();
                           Re_Exp_tbl = dss.Tables[9];
                           DataView Re_Exp_view = Re_Exp_tbl.DefaultView;
                           Re_Exp_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Re_Exp_Tb = Re_Exp_view.ToTable();

                           if (Re_Exp_Tb.Rows.Count > 0)
                           {
                               sw.WriteLine(", ");
                               sw.WriteLine("  \"Re_Export_Details\": [");

                               for (int ReExp = 0; ReExp < Re_Exp_Tb.Rows.Count; ReExp++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Sb_No\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["SB_NO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["SB_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Sb_Date\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["SB_DATE"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["SB_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(Re_Exp_Tb.Rows[ReExp]["SB_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "\",");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["INVOICE_SLNO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["ITEM_SLNO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Slno\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["SLNO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Site\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_SITE"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_SITE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_No\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_NO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Date\": \"" + (Re_Exp_Tb.Rows[ReExp]["BE_DATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(Re_Exp_Tb.Rows[ReExp]["BE_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                                   sw.WriteLine("      \"Be_Invoice_No\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_INVOICE_NO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_INVOICE_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Invoice_Item_No\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_INVOICE_ITEM_NO"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_INVOICE_ITEM_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Manual_Be_Y_N\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["MANUAL_BE_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["MANUAL_BE_Y_N"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Qty_Utilised\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_QTY_UTILISED"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_QTY_UTILISED"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Item_Desc\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_ITEM_DESC"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_ITEM_DESC"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Qty\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_QTY"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_QTY"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Uqc\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_UQC"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_UQC"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Ass_Value\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_ASS_VALUE"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_ASS_VALUE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Duty_Paid\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_DUTY_PAID"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_DUTY_PAID"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Duty_Payment_Date\": \"" + (Re_Exp_Tb.Rows[ReExp]["BE_DUTY_PAYMENT_DATE"].ToString() == "1900-01-01 00:00:00.000" ? string.Empty : DateTime.Parse(Re_Exp_Tb.Rows[ReExp]["BE_DUTY_PAYMENT_DATE"].ToString()).ToString("dd-MMM-yyyy")) + "\",");
                                   sw.WriteLine("      \"Be_Oth_Identifiable_Parameter\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_OTH_IDENTIFIABLE_PARAMETER"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_OTH_IDENTIFIABLE_PARAMETER"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Ass_Value_Claim\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_ASS_VALUE_CLAIM"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_ASS_VALUE_CLAIM"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Item_Used_Y_N\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["BE_ITEM_USED_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["BE_ITEM_USED_Y_N"].ToString()) + "\",");
                                   sw.WriteLine("      \"Commisioner_Permission_Y_N\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["COMMISIONER_PERMISSION_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["COMMISIONER_PERMISSION_Y_N"].ToString()) + "\",");
                                   sw.WriteLine("      \"Input_Credit_Y_N\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["INPUT_CREDIT_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["INPUT_CREDIT_Y_N"].ToString()) + "\",");
                                   sw.WriteLine("      \"Personal_Used_Y_N\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["PERSONAL_USED_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["PERSONAL_USED_Y_N"].ToString()) + "\",");
                                   sw.WriteLine("      \"Modvat_Availed_Y_N\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["MODVAT_AVAILED_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["MODVAT_AVAILED_Y_N"].ToString()) + "\",");
                                   sw.WriteLine("      \"Modvat_Repaid_Y_N\": \"" + (string.IsNullOrEmpty(Re_Exp_Tb.Rows[ReExp]["MODVAT_REPAID_Y_N"].ToString()) ? " " : Re_Exp_Tb.Rows[ReExp]["MODVAT_REPAID_Y_N"].ToString()) + "\"");

                                   if (ReExp == Re_Exp_Tb.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }

                           DataTable Quo_tbl = new DataTable();
                           Quo_tbl = dss.Tables[10];
                           DataView Quo_view = Quo_tbl.DefaultView;
                           Quo_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Quotbl = Quo_view.ToTable();

                           if (Quotbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"Quota_Details\": [");

                               for (int Quo = 0; Quo < Quotbl.Rows.Count; Quo++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["INVOICE_SLNO"].ToString()) ? " " : Quotbl.Rows[Quo]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Sl_No\": \"" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["ITEM_SLNO"].ToString()) ? " " : Quotbl.Rows[Quo]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Agency_Code\": \"" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["AGENCY_CODE"].ToString()) ? " " : Quotbl.Rows[Quo]["AGENCY_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Agency_Name\": \"" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["AGENCY_NAME"].ToString()) ? " " : Quotbl.Rows[Quo]["AGENCY_NAME"].ToString()) + "\",");
                                   sw.WriteLine("      \"Allocation_No\": \"" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["ALLOCATION_NO"].ToString()) ? " " : Quotbl.Rows[Quo]["ALLOCATION_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Expiry_Date\": \"" + (string.IsNullOrEmpty(Quotbl.Rows[Quo]["EXPIRY_DATE"].ToString()) ? " " : Quotbl.Rows[Quo]["EXPIRY_DATE"].ToString()) + "\"");

                                   if (Quo == Quotbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");


                           }



                           DataTable Cess_tbl = new DataTable();
                           Cess_tbl = dss.Tables[11];
                           DataView Cess_view = Cess_tbl.DefaultView;
                           Cess_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable CessTbl = Cess_view.ToTable();

                           if (CessTbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"Cess_Details\": [");

                               for (int Cess = 0; Cess < CessTbl.Rows.Count; Cess++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["INVOICE_SLNO"].ToString()) ? " " : CessTbl.Rows[Cess]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["ITEM_SLNO"].ToString()) ? " " : CessTbl.Rows[Cess]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Cess_Slno\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_SLNO"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Cess_Value\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_VALUE"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_VALUE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Cess_Unit\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_UNIT"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_UNIT"].ToString()) + "\",");
                                   sw.WriteLine("      \"Cess_Flag\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_FLAG"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_FLAG"].ToString()) + "\",");
                                   sw.WriteLine("      \"Cess_Rate\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_RATE"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_RATE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Cess_Item_Qty\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_ITEM_QTY"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_ITEM_QTY"].ToString()) + "\",");
                                   sw.WriteLine("      \"Cess_Item_Qty_Code\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_ITEM_QTY_CODE"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_ITEM_QTY_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Cess_Tariff_Value\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_TARIFF_VALUE"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_TARIFF_VALUE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Cess_Tariff_Unit\": \"" + (string.IsNullOrEmpty(CessTbl.Rows[Cess]["CESS_TARIFF_UNIT"].ToString()) ? " " : CessTbl.Rows[Cess]["CESS_TARIFF_UNIT"].ToString()) + "\"");

                                   if (Cess == CessTbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }


                           DataTable Jobbing_tbl = new DataTable();
                           Jobbing_tbl = dss.Tables[12];
                           DataView Jobbing_view = Jobbing_tbl.DefaultView;
                           Jobbing_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Jobbingtbl = Jobbing_view.ToTable();

                           if (Jobbingtbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"Jobbing_Details\": [");

                               for (int Jobbing = 0; Jobbing < Jobbingtbl.Rows.Count; Jobbing++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["INVOICE_SLNO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["ITEM_SLNO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Scheme_Code\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["SCHEME_CODE"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["SCHEME_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Notification_No\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["NOTIFICATION_NO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["NOTIFICATION_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_No\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_NO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Date\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_DATE"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_DATE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Inv_Slno\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_INV_SLNO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_INV_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Inv_No\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_INV_NO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_INV_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Item_No\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_ITEM_NO"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_ITEM_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Be_Port_Code\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["BE_PORT_CODE"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["BE_PORT_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Qty\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["QTY"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["QTY"].ToString()) + "\",");
                                   sw.WriteLine("      \"Unit\": \"" + (string.IsNullOrEmpty(Jobbingtbl.Rows[Jobbing]["UNIT"].ToString()) ? " " : Jobbingtbl.Rows[Jobbing]["UNIT"].ToString()) + "\"");

                                   if (Jobbing == Jobbingtbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }


                           DataTable Lic_tbl = new DataTable();
                           Lic_tbl = dss.Tables[13];
                           DataView Lic_view = Lic_tbl.DefaultView;
                           Lic_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable LicTbl = Lic_view.ToTable();


                           if (LicTbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"License_Details\": [");

                               for (int Lic = 0; Lic < LicTbl.Rows.Count; Lic++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Inv_Sl_No\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["INVOICE_SLNO"].ToString()) ? " " : LicTbl.Rows[Lic]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Sl_No\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["ITEM_SLNO"].ToString()) ? " " : LicTbl.Rows[Lic]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Scheme\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["SCHEME"].ToString()) ? " " : LicTbl.Rows[Lic]["SCHEME"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_Reg_Slno\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_REG_SLNO"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_REG_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_No\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_NO"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_Date\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_DATE"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_DATE"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_E_Sl_No\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_E_SL_NO"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_E_SL_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_Exp_Qty\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_EXP_QTY"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_EXP_QTY"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_Exp_Unit\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_EXP_UNIT"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_EXP_UNIT"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_Imp_Item_Sl_No\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_ITEM_SL_NO"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_ITEM_SL_NO"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_Imp_Desc\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_DESC"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_DESC"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_Imp_Qty\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_QTY"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_QTY"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_Imp_Unit\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_UNIT"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_UNIT"].ToString()) + "\",");
                                   sw.WriteLine("      \"License_Imp_Type\": \"" + (string.IsNullOrEmpty(LicTbl.Rows[Lic]["LICENSE_IMP_TYPE"].ToString()) ? " " : LicTbl.Rows[Lic]["LICENSE_IMP_TYPE"].ToString()) + "\"");

                                   if (Lic == LicTbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }


                           DataTable SWinfo_tbl = new DataTable();
                           SWinfo_tbl = dss.Tables[14];
                           DataView SWinfo_view = SWinfo_tbl.DefaultView;
                           SWinfo_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Sw_Info_Tbl = SWinfo_view.ToTable();

                           if (Sw_Info_Tbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"Sw_Info_Type_Details\": [");

                               for (int Sw_Info = 0; Sw_Info < Sw_Info_Tbl.Rows.Count; Sw_Info++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INVOICE_SLNO"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["ITEM_SLNO"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Slno\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["SLNO"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Info_Type\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_TYPE"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_TYPE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Info_Qualifier\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_QUALIFIER"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_QUALIFIER"].ToString()) + "\",");
                                   sw.WriteLine("      \"Info_Code\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_CODE"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Info_Text\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_TEXT"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_TEXT"].ToString()) + "\",");
                                   sw.WriteLine("      \"Info_Msr\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_MSR"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_MSR"].ToString()) + "\",");
                                   sw.WriteLine("      \"Info_Uqc\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["INFO_UQC"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["INFO_UQC"].ToString()) + "\",");
                                   sw.WriteLine("      \"Department\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["DEPARTMENT"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["DEPARTMENT"].ToString()) + "\",");
                                   sw.WriteLine("      \"I_U_Type\": \"" + (string.IsNullOrEmpty(Sw_Info_Tbl.Rows[Sw_Info]["I_U_TYPE"].ToString()) ? " " : Sw_Info_Tbl.Rows[Sw_Info]["I_U_TYPE"].ToString()) + "\"");

                                   if (Sw_Info == Sw_Info_Tbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }

                           DataTable SwConst_tbl = new DataTable();
                           SwConst_tbl = dss.Tables[15];
                           DataView SwConst_view = SwConst_tbl.DefaultView;
                           SwConst_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Sw_Const_Tbl = SwConst_view.ToTable();

                           if (Sw_Const_Tbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"Sw_Const_Details\": [");

                               for (int Sw_Const = 0; Sw_Const < Sw_Const_Tbl.Rows.Count; Sw_Const++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["INVOICE_SLNO"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["ITEM_SLNO"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Constituent_Srno\": \"" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_SRNO"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_SRNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Constituent_Element_Name\": \"" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_ELEMENT_NAME"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_ELEMENT_NAME"].ToString()) + "\",");
                                   sw.WriteLine("      \"Constituent_Element_Code\": \"" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_ELEMENT_CODE"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_ELEMENT_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Constituent_Percentage\": \"" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_PERCENTAGE"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_PERCENTAGE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Constituent_Yield_Percentage\": \"" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["CONSTITUENT_YIELD_PERCENTAGE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Active_Ingredient\": \"" + (string.IsNullOrEmpty(Sw_Const_Tbl.Rows[Sw_Const]["ACTIVE_INGREDIENT"].ToString()) ? " " : Sw_Const_Tbl.Rows[Sw_Const]["ACTIVE_INGREDIENT"].ToString()) + "\"");

                                   if (Sw_Const == Sw_Const_Tbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }

                           DataTable SwProd_tbl = new DataTable();
                           SwProd_tbl = dss.Tables[16];
                           DataView SwProd_view = SwProd_tbl.DefaultView;
                           SwProd_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable SwProdTbl = SwProd_view.ToTable();


                           if (SwProdTbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"Sw_Prod_Details\": [");

                               for (int Sw_Prod = 0; Sw_Prod < SwProdTbl.Rows.Count; Sw_Prod++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["INVOICE_SLNO"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["ITEM_SLNO"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Slno\": \"" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["SLNO"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Production_Batch_Identifier\": \"" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["PRODUCTION_BATCH_IDENTIFIER"].ToString()) + "\",");
                                   sw.WriteLine("      \"Production_Batch_Quantity\": \"" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["PRODUCTION_BATCH_QUANTITY"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["PRODUCTION_BATCH_QUANTITY"].ToString()) + "\",");
                                   sw.WriteLine("      \"Unit_Qty_Code\": \"" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["UNIT_QTY_CODE"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["UNIT_QTY_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Date_Of_Manufacturing\": \"" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["DATE_OF_MANUFACTURING"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["DATE_OF_MANUFACTURING"].ToString()) + "\",");
                                   sw.WriteLine("      \"Date_Of_Expiry\": \"" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["DATE_OF_EXPIRY"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["DATE_OF_EXPIRY"].ToString()) + "\",");
                                   sw.WriteLine("      \"Best_Before\": \"" + (string.IsNullOrEmpty(SwProdTbl.Rows[Sw_Prod]["BEST_BEFORE"].ToString()) ? " " : SwProdTbl.Rows[Sw_Prod]["BEST_BEFORE"].ToString()) + "\"");

                                   if (Sw_Prod == SwProdTbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }


                           DataTable SwCont_tbl = new DataTable();
                           SwCont_tbl = dss.Tables[17];
                           DataView SwCont_view = SwCont_tbl.DefaultView;
                           SwCont_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable SwContTbl = SwCont_view.ToTable();

                           if (SwContTbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"Sw_Control_Details\": [");

                               for (int Sw_Cont = 0; Sw_Cont < SwContTbl.Rows.Count; Sw_Cont++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["INVOICE_SLNO"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["ITEM_SLNO"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Slno\": \"" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["SLNO"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Control_Type_Code\": \"" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_TYPE_CODE"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_TYPE_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Control_Location\": \"" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_LOCATION"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_LOCATION"].ToString()) + "\",");
                                   sw.WriteLine("      \"Control_Start_Date\": \"" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_START_DATE"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_START_DATE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Control_End_Date\": \"" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_END_DATE"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_END_DATE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Control_Result_Code\": \"" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_RESULT_CODE"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_RESULT_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Control_Result_Text\": \"" + (string.IsNullOrEmpty(SwContTbl.Rows[Sw_Cont]["CONTROL_RESULT_TEXT"].ToString()) ? " " : SwContTbl.Rows[Sw_Cont]["CONTROL_RESULT_TEXT"].ToString()) + "\"");

                                   if (Sw_Cont == SwContTbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }


                           DataTable SwState_tbl = new DataTable();
                           SwState_tbl = dss.Tables[18];
                           DataView SwState_view = SwState_tbl.DefaultView;
                           SwState_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable SwStateTbl = SwState_view.ToTable();

                           if (SwStateTbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"Sw_Stmt_Details\": [");

                               for (int Sw_Sate = 0; Sw_Sate < SwStateTbl.Rows.Count; Sw_Sate++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["INVOICE_SLNO"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["ITEM_SLNO"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Slno\": \"" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["SLNO"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Stmt_Type\": \"" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["STMT_TYPE"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["STMT_TYPE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Stmt_Code\": \"" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["STMT_CODE"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["STMT_CODE"].ToString()) + "\",");
                                   //sw.WriteLine("      \"Stmt_Text\": \"" + (string.IsNullOrEmpty(SwStateTbl.Rows[Sw_Sate]["STMT_TEXT"].ToString()) ? " " : SwStateTbl.Rows[Sw_Sate]["STMT_TEXT"].ToString()) + "\"");
                                   sw.WriteLine("      \"Stmt_Text\": \"" + " " + "\"");
                                   if (Sw_Sate == SwStateTbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }

                           DataTable Sw_Sup_tbl = new DataTable();
                           Sw_Sup_tbl = dss.Tables[19];
                           DataView Sw_Sup_view = Sw_Sup_tbl.DefaultView;
                           Sw_Sup_view.RowFilter = "INVOICE_SLNO = '" + a + "' AND ITEM_SLNO = '" + item_slno + "'";
                           DataTable Sw_SupTbl = Sw_Sup_view.ToTable();

                           if (Sw_SupTbl.Rows.Count > 0)
                           {
                               sw.WriteLine("  ,");

                               sw.WriteLine("  \"Sw_Sup_Doc_Details\": [");

                               for (int Sw_Sup = 0; Sw_Sup < Sw_SupTbl.Rows.Count; Sw_Sup++)
                               {
                                   sw.WriteLine("    {");
                                   sw.WriteLine("      \"Invoice_Slno\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["INVOICE_SLNO"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["INVOICE_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Item_Slno\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["ITEM_SLNO"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["ITEM_SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Slno\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["SLNO"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["SLNO"].ToString()) + "\",");
                                   sw.WriteLine("      \"Unique_Doc_Number\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["UNIQUE_DOC_NUMBER"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["UNIQUE_DOC_NUMBER"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Type_Code\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_TYPE_CODE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_TYPE_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Issuing_Party_Code\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_CODE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Issuing_Party_Name_Add1\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Issuing_Party_Name_Add2\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Issuing_Party_City\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_CITY"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_CITY"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Issuing_Party_Pin\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_PIN"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_PIN"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Ref_Number\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_REF_NUMBER"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_REF_NUMBER"].ToString()) + "\",");
                                   sw.WriteLine("      \"Place_Of_Issue\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["PLACE_OF_ISSUE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["PLACE_OF_ISSUE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Issue_Date\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUE_DATE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUE_DATE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Expiry_Date\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_EXPIRY_DATE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_EXPIRY_DATE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Beneficiary_Party_Code\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_CODE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_CODE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Beneficiary_Party_Address1\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_ADDRESS1"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_ADDRESS1"].ToString()) + "\",");
                                   sw.WriteLine("      \"Beneficiary_Party_Address2\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_ADDRESS2"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_ADDRESS2"].ToString()) + "\",");
                                   sw.WriteLine("      \"Beneficiary_Party_City\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_CITY"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_CITY"].ToString()) + "\",");
                                   sw.WriteLine("      \"Beneficiary_Party_Pin\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_PIN"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_PIN"].ToString()) + "\",");
                                   sw.WriteLine("      \"File_Type\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["FILE_TYPE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["FILE_TYPE"].ToString()) + "\",");
                                   sw.WriteLine("      \"Doc_Issuing_Party_Name\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["DOC_ISSUING_PARTY_NAME"].ToString()) + "\",");
                                   sw.WriteLine("      \"Beneficiary_Party_Name\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_NAME"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["BENEFICIARY_PARTY_NAME"].ToString()) + "\",");
                                   sw.WriteLine("      \"Icegate_Id\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["ICEGATE_ID"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["ICEGATE_ID"].ToString()) + "\",");
                                   sw.WriteLine("      \"Icegate_Doc_File_Name\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["ICEGATE_DOC_FILE_NAME"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["ICEGATE_DOC_FILE_NAME"].ToString()) + "\",");
                                   sw.WriteLine("      \"Select_Type\": \"" + (string.IsNullOrEmpty(Sw_SupTbl.Rows[Sw_Sup]["SELECT_TYPE"].ToString()) ? " " : Sw_SupTbl.Rows[Sw_Sup]["SELECT_TYPE"].ToString()) + "\"");

                                   if (Sw_Sup == Sw_SupTbl.Rows.Count - 1)
                                       sw.WriteLine("    }");
                                   else
                                       sw.WriteLine("    },");
                               }

                               sw.WriteLine("  ]");

                           }


                           if (itm == Ex_items.Rows.Count - 1)
                               sw.WriteLine("    }");
                           else
                               sw.WriteLine("    },");
                       }

                       sw.WriteLine("  ]");
                   }

                   if (inv == dss.Tables[4].Rows.Count - 1)
                       sw.WriteLine(" }");
                   else
                       sw.WriteLine("},");

               }
               sw.WriteLine("  ]");

           }
           /////
           if (Connection.COMPANYID() == "3267")
           {
               if (dss.Tables.Count > 21 && dss.Tables[21].Rows.Count > 0)
               {
                   sw.WriteLine(",");
                   sw.WriteLine("      \"Other_Details\": [");

                   for (int other = 0; other < dss.Tables[21].Rows.Count; other++)
                   {
                       var rows = dss.Tables[21].Rows[other];

                       sw.WriteLine("        {");

                       sw.WriteLine("          \"Bill_To\": \"" + (string.IsNullOrEmpty(rows["BILL_TO"].ToString()) ? " " : rows["BILL_TO"].ToString()) + "\",");
                       sw.WriteLine("          \"Ctns\": \"" + (string.IsNullOrEmpty(rows["CTNS"].ToString()) ? " " : rows["CTNS"].ToString()) + "\",");
                       sw.WriteLine("          \"Cfs\": \"" + (string.IsNullOrEmpty(rows["CFS"].ToString()) ? " " : rows["CFS"].ToString()) + "\",");
                       sw.WriteLine("          \"Consol\": \"" + (string.IsNullOrEmpty(rows["CONSOL"].ToString()) ? " " : rows["CONSOL"].ToString()) + "\",");
                       sw.WriteLine("          \"Egm_No\": \"" + (string.IsNullOrEmpty(rows["EGM_NO"].ToString()) ? " " : rows["EGM_NO"].ToString()) + "\",");
                       sw.WriteLine("          \"Egm_Dt\": \"" + (string.IsNullOrEmpty(rows["EGM_DT"].ToString()) ? " " : rows["EGM_DT"].ToString()) + "\",");
                       sw.WriteLine("          \"Pod\": \"" + (string.IsNullOrEmpty(rows["POD"].ToString()) ? " " : rows["POD"].ToString()) + "\",");
                       sw.WriteLine("          \"Seal_No\": \"" + (string.IsNullOrEmpty(rows["SEAL_NO"].ToString()) ? " " : rows["SEAL_NO"].ToString()) + "\",");
                       sw.WriteLine("          \"Gateway_Port\": \"" + (string.IsNullOrEmpty(rows["GATEWAY_PORT"].ToString()) ? " " : rows["GATEWAY_PORT"].ToString()) + "\"");
                      
                      
                       if (other == dss.Tables[21].Rows.Count - 1)
                           sw.WriteLine("        }");
                       else
                           sw.WriteLine("        },");
                   }

                   sw.WriteLine("      ]");
               }
           } 
           /////

       }
       sw.WriteLine("}");

       //System.Web.HttpContext.Current.Response.Write(sw.ToString());
       //System.Web.HttpContext.Current.Response.Flush();
       string folrder_path = errorFolder + "_" + Imp_exp + job_no + ".JSON";
       sw.Close();
       sw.Dispose();

       #endregion E_Json

       return Post_API_Fulljob(Imp_exp, job_no, filePath);
   }
   public class CustomClearance
    {
        public int CustomClearanceAutoId { get; set; }
        public string CompanyId { get; set; }
        public string EbmsJobNo { get; set; }
        public string ClearanceJobNo { get; set; }
        public string ImpExFlag { get; set; }
       
    }
    public class Be_Se_Post
    {
        public string CompanyId { get; set; }
        public string EbmsJobNo { get; set; }
        public string RoyalJobNo { get; set; }
        public string sbno { get; set; }
        public string sbdate { get; set; }
        public string beno { get; set; }
        public string bedate { get; set; }
    }
    public class ApiResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }

 
    public string Post_API_General_Details(string Imp_exp, string JobNo, string filePath)
    {
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2                                                             

        string path = filePath;
        var xmldoc = File.ReadAllText(path);
        string data = xmldoc.ToString();
        byte[] requestData = Encoding.UTF8.GetBytes(data);
        try
        {
            using (WebClient client = new WebClient())
            {
                 client.Headers.Add("X-TENANT-ID", "D45E74B5-16B3-452D-82BB-0CD635FADBCE");              
                 byte[] response = client.UploadData(Cooper_Api_Link + "?JobType=" + Imp_exp,"POST", requestData);                 
                 string respStr = Encoding.UTF8.GetString(response);               
                 return "Response: " + respStr;
            }
        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string errorResponse = reader.ReadToEnd();
                    return "Error: " + errorResponse;
                }
            }
            return "WebException: " + ex.Message;
        }
        catch (Exception ex)
        {
            return "An error occurred: " + ex.Message;
        }
    }
   
    public string Post_API_Fulljob(string Imp_exp, string JobNo, string filePath)
    {
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2                                                             
        //string path = HttpContext.Current.Server.MapPath("~/Submission/ERI00001/I/JSON/I_10020.Json");
        string path = filePath;//HttpContext.Current.Server.MapPath(filePath);
        var xmldoc = File.ReadAllText(path);
        string data = xmldoc.ToString();
        byte[] requestData = Encoding.UTF8.GetBytes(data);
        string postURL = "";
        //tring uploadFolder = Path.GetDirectoryName(path);

        string companyId = Connection.COMPANYID();
        if (companyId == "2814")
            postURL = Ebms_Url_Link + "Common/RoyalImpexExternal/" + (Imp_exp == "I" ? "CreateImpJob" : "CreateExpJob");

        else if (companyId == "3082")
            postURL = Sws_Url_Link + "Common/RoyalImpexExternal/" + (Imp_exp == "I" ? "CreateImpJob" : "CreateExpJob");

        else if (companyId == "3253")
            postURL = Sora_Url_Link + "Common/RoyalImpexExternal/" + (Imp_exp == "I" ? "CreateImpJob" : "CreateExpJob");

        else if (companyId == "3288" || companyId == "115" || companyId == "1033")
            postURL = Cooper_Api_Link;

        else if (companyId == "3267")
            postURL = (Imp_exp == "I") ? Mez_Kps_Imp_Url : Mez_Kps_Exp_Url;
        
        try
        {
            using (WebClient client = new WebClient())
            {
                if (companyId == "3288" || companyId == "115" || companyId == "1033")
                {
                    client.Headers.Add("X-TENANT-ID", "D45E74B5-16B3-452D-82BB-0CD635FADBCE");
                    byte[] response = client.UploadData(Cooper_Api_Link + "?JobType=" + Imp_exp, "POST", requestData);
                    string respStr = Encoding.UTF8.GetString(response);
                    return "Response: " + respStr;
                }
                else if (companyId == "3267")
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";

                        byte[] requestBytes = Encoding.UTF8.GetBytes(data);

                        byte[] response = client.UploadData(postURL, "POST", requestBytes);

                        string respStr = Encoding.UTF8.GetString(response);

                        return "Response: " + respStr;                    
                }
                else if(companyId == "861" || companyId == "3149" || companyId == "3266")
                {
                    
                     
                    client.Headers.Add("Authorization", "Bearer " + Royal_HHL_Token);                    
                    string folder = Path.GetDirectoryName(path);
                    string[] parts = folder.Split('\\');
                    string uploadFolder = parts[parts.Length - 2] + "/" + parts[parts.Length - 1];
                    string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                    client.Headers[HttpRequestHeader.ContentType] = "multipart/form-data; boundary=" + boundary;

                    byte[] fileBytes = File.ReadAllBytes(path);
                    string fileName = Path.GetFileName(path);

                    MemoryStream ms = new MemoryStream();
                    StreamWriter writer = new StreamWriter(ms);
                    writer.AutoFlush = true;
                    writer.Write("--" + boundary + "\r\n");
                    writer.Write("Content-Disposition: form-data; name=\"uploadFolder\"\r\n\r\n");
                    writer.Write(uploadFolder + "\r\n");
                    
                    writer.Write("--" + boundary + "\r\n");
                    writer.Write("Content-Disposition: form-data; name=\"file\"; filename=\"" + fileName + "\"\r\n");
                    writer.Write("Content-Type: application/json\r\n\r\n");
                    writer.Flush(); 
                                        
                    ms.Write(fileBytes, 0, fileBytes.Length);
                                       
                    writer.Write("\r\n--" + boundary + "--\r\n");
                    writer.Flush();

                    byte[] requestDataHHL = ms.ToArray();
                    if (Imp_exp == "E")
                    {
                        if (trans_mode == "SEA" || trans_mode == "LAND")
                            postURL = Royal_HHL_Exp_Sea;
                        else if (trans_mode == "AIR")
                            postURL = Royal_HHL_Exp_Air;
                    }
                    else if (Imp_exp == "I")
                    {
                        if (trans_mode == "SEA" || trans_mode == "LAND")
                            postURL = Royal_HHL_Imp_Sea;
                        else if (trans_mode == "AIR")
                            postURL = Royal_HHL_Imp_Air;
                    }

                    if (!string.IsNullOrEmpty(postURL))
                        {
                            byte[] response = client.UploadData(postURL + "?JobType=" + Imp_exp, "POST", requestDataHHL);
                             respStr_Hll = Encoding.UTF8.GetString(response);
                            return "Response: " + respStr_Hll;
                        }
                        else
                        {
                            return "Invalid Transport Mode or URL not found";
                        }
                       }

                else
                { 
                    var response_New = client.UploadFile(postURL, "POST", path);
                    string respStr_New = Encoding.UTF8.GetString(response_New);
                    return "Message: {result.Message}, StatusCode: {result.StatusCode}";
                }
            }
        }
        catch (WebException ex)
        {
            if (ex.Response != null) 
            {
                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string errorResponse = reader.ReadToEnd();
                    return "Error: " + errorResponse;
                }
            }
            return "WebException: " + ex.Message;
        }
        catch (Exception ex)
        {
            return "An error occurred: " + ex.Message;
        }
    }
   
    public string PostJobReferenceNo_Ebms(int is_live, string Ebms_job_no, string Royal_impex_jobno, string Jobtype)
    {
       
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2
        CustomClearance clearanceObj = new CustomClearance()
        {
            ClearanceJobNo = Royal_impex_jobno,
            CompanyId = Connection.COMPANYID(),           
            EbmsJobNo = Ebms_job_no,
            ImpExFlag = Jobtype
        };
        string Post_Url = "";
        if (Connection.COMPANYID() == "2814")
        {
            Post_Url = Ebms_Url_Link + "Common/RoyalImpexExternal/CustomClearance";
        }
        else if (Connection.COMPANYID() == "3082")
        {
            Post_Url = Sws_Url_Link + "Common/RoyalImpexExternal/CustomClearance";
        }
        else if (Connection.COMPANYID() == "3253")
        {
            Post_Url = Sora_Url_Link + "Common/RoyalImpexExternal/CustomClearance";
        }


        try
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                string data = JsonConvert.SerializeObject(clearanceObj);
                string response = client.UploadString(Post_Url, "POST", data);
                ApiResponse result = JsonConvert.DeserializeObject<ApiResponse>(response);
                return "Message: {result.Message}, StatusCode: {result.StatusCode}";
            }
        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string errorResponse = reader.ReadToEnd();
                    return "Error: " + errorResponse;
                }
            }
            return "WebException: " + ex.Message;
        }
        catch (Exception ex)
        {
            return "An error occurred: " + ex.Message;
        }
    }

    public string Ebms_Beno_Sbno_Post(string Ebms_job_no, string Royal_impex_jobno, string be_no, string be_date)
    {
        ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2
        Be_Se_Post Be_Sb = new Be_Se_Post()
        {
            CompanyId = Connection.COMPANYID(), 
            RoyalJobNo = Royal_impex_jobno,
            EbmsJobNo = Ebms_job_no,
            sbno = be_no,
            sbdate = be_date
        };
        string Ebms_Be_Sb_Url = "";
        if (Connection.COMPANYID() == "2814")
        {
            Ebms_Be_Sb_Url = Ebms_Url_Link + "Common/RoyalImpexExternal/RoyalImpexReqSB";
        }
        else if (Connection.COMPANYID() == "3082")
        {
            Ebms_Be_Sb_Url = Sws_Url_Link + "Common/RoyalImpexExternal/RoyalImpexReqSB";
        }
        else if (Connection.COMPANYID() == "3253")
        {
            Ebms_Be_Sb_Url = Sora_Url_Link + "Common/RoyalImpexExternal/RoyalImpexReqSB";
        }
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";

                    string data = JsonConvert.SerializeObject(Be_Sb);
                    string response = client.UploadString(Ebms_Be_Sb_Url, "POST", data);
                    ApiResponse result = JsonConvert.DeserializeObject<ApiResponse>(response);
                    return "Message: {result.Message}, StatusCode: {result.StatusCode}";
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string errorResponse = reader.ReadToEnd();
                        return "Error: " + errorResponse;
                    }
                }
                return "WebException: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
            }
    }
    public DataSet Select_Imp_Exp_Job_Details(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@BRANCH_COMMON", objUserBL.A6);
            param[3] = new SqlParameter("@Company_Lic", Connection.COMPANYID());
            param[4] = new SqlParameter("@Flag", objUserBL.A4);
            param[5] = new SqlParameter("@WORKINGPERIOD", objUserBL.A3);
            param[6] = new SqlParameter("@Imp_Exp", objUserBL.A5);
            

            //ds = Connection.Get_Dataset("IMP_EXP_CHECKLIST_DETAILS_POSTING", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_CHECKLIST_DETAILS_POSTING", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public class BE_Request
    {
        public string JOB_Number { get; set; }
        public string BE_Number { get; set; }
        public string BE_Date { get; set; }
        public string Transport_Mode { get; set; }
        public string Custom_House { get; set; }
        public string Currency { get; set; }
        public string Port_Code { get; set; }
        public string Arrival_Date { get; set; }
        public string Clearance_Date { get; set; }
        public string Clearance_Time { get; set; }
        public string Exchange_Rate { get; set; }
        public string BE_Type { get; set; }
        public string House_No { get; set; }
        public string Master_No { get; set; }
        public string Importer_Name { get; set; }
        public string Importer_IEC { get; set; }
        public string Packages { get; set; }
        public string Package_UOM { get; set; }
        public string Gross_Weight { get; set; }
        public List<Details> details { get; set; }
    }

    public class Details
    {
        public string Invoice_Number { get; set; }
        public string Invoice_Date { get; set; }
        public string Terms { get; set; }
        public string Part_Number { get; set; }
        public string Part_Description { get; set; }
        public string Product_Quantity { get; set; }
        public string Product_UOM { get; set; }
        public string Unit_Price { get; set; }
        public string Product_Amount { get; set; }
        public string CTH { get; set; }
        public string COO { get; set; }
        public string Assessable_Value { get; set; }
        public string Total_Duty { get; set; }
        public string BCD_Rate { get; set; }
        public string BCD_Amount { get; set; }
        public string SWS_Rate { get; set; }
        public string SWS_Amount { get; set; }
        public string GST_Rate { get; set; }
        public string GST_Amount { get; set; }
        public string AIDC_Rate { get; set; }
        public string AIDC_Amount { get; set; }
        public string Other_Duty_Rate { get; set; }
        public string Other_Duty_Amount { get; set; }
        public string Freight { get; set; }
        public string Insurance { get; set; }
        public string Misc_Amount { get; set; }
        public string Line_Number { get; set; }
    }

    public class AcknowledgementResponse
    {
        public string Table_ID { get; set; }
        public string Message { get; set; }
        public string StatusCode { get; set; }  
    }

    public string Sudarshan_Imp_API_Post(DataSet dss, string JobNo)
    {
        try
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2

            BE_Request clearanceObj = new BE_Request()
            {
                JOB_Number = "JOB" + JobNo,
                BE_Number = dss.Tables[0].Rows[0]["BE_NO"].ToString(),
                BE_Date = dss.Tables[0].Rows[0]["BE_DATE"].ToString(),
                Transport_Mode = dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString(),
                Custom_House = dss.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString(),
                Currency = dss.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString(),
                Port_Code = dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString(),
                Arrival_Date = dss.Tables[0].Rows[0]["IGM_FLIGHT_VESSELDATE"].ToString(),
                Clearance_Date = dss.Tables[0].Rows[0]["BE_DATE"].ToString(),
                Clearance_Time = dss.Tables[0].Rows[0]["CLEARANCE_TIME"].ToString(),
                Exchange_Rate = dss.Tables[0].Rows[0]["INVOICE_EXRATE"].ToString(),
                BE_Type = dss.Tables[0].Rows[0]["BE_TYPE"].ToString(),
                House_No = dss.Tables[0].Rows[0]["IGM_HAWB_HBLNO"].ToString(),
                Master_No = dss.Tables[0].Rows[0]["IGM_MAWB_MBL"].ToString(),
                Importer_Name = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(),
                Importer_IEC = dss.Tables[0].Rows[0]["IEC_NO"].ToString(),
                Packages = dss.Tables[0].Rows[0]["IGM_NOOFPACKAGE"].ToString(),
                Package_UOM = dss.Tables[0].Rows[0]["IGM_PACKAGETYPE"].ToString(),
                Gross_Weight = dss.Tables[0].Rows[0]["IGM_GROSSWEIGHT"].ToString(),
                details = new List<Details>()
            };

            int lineNumber = 1;
            for (int i = 0; i < dss.Tables[2].Rows.Count; i++)
            {
                DataRow item = dss.Tables[2].Rows[i];
                DataRow invoice = dss.Tables[1].Select("INVOICE_SLNO = '" + item["INVOICE_SLNO"] + "'").FirstOrDefault();
                DataRow additional = dss.Tables[3].Select(
                    "INVOICE_SLNO = '" + item["INVOICE_SLNO"] + "' AND ITEM_SLNO = '" + item["ITEM_SLNO"] + "'"
                ).FirstOrDefault();

                if (invoice == null || additional == null)
                {
                    continue;
                }

                Details detail = new Details
                {
                    Invoice_Number = invoice["INVOICE_NO"].ToString(),
                    Invoice_Date = invoice["INVOICE_DATE"].ToString(),
                    Terms = invoice["TERMS"].ToString(),
                    Part_Number = item["PART_NO"].ToString(),
                    Part_Description = item["ITEM_DESCRIPTION"].ToString(),
                    Product_Quantity = item["ITEM_QTY"].ToString(),
                    Product_UOM = item["ITEM_QTY_CODE"].ToString(),
                    Unit_Price = item["ITEM_UNIT_PRICE"].ToString(),
                    Product_Amount = item["ITEM_TOTAL_AMOUNT"].ToString(),
                    CTH = item["CTH_NO"].ToString(),
                    COO = item["COUNTRY_OF_ORIGIN"].ToString(),
                    Assessable_Value = additional["ASSESSABLE_VALUE"].ToString(),
                    Total_Duty = additional["DUTY_VALUE"].ToString(),
                    BCD_Rate = additional["CHECKLIST_BCD_RATE"].ToString(),
                    BCD_Amount = additional["BASIC_VALUE"].ToString(),
                    SWS_Rate = additional["SOCIAL_WELFARE_RATE"].ToString(),
                    SWS_Amount = additional["CHECKLIST_SOCIAL_WELFARE_AMT"].ToString(),
                    GST_Rate = additional["IGST_LEVY_RATE"].ToString(),
                    GST_Amount = additional["CHECKLIST_IGST_LEVY_AMOUNT"].ToString(),
                    AIDC_Rate = additional["AIDC_RATE"].ToString(),
                    AIDC_Amount = additional["AIDC_CHECKLIST_AMT"].ToString(),
                    Other_Duty_Rate = "0",
                    Other_Duty_Amount = "0",
                    Freight = additional["INDIVITUAL_FREIGHT_AMOUNT"].ToString(),
                    Insurance = additional["INDIVITUAL_INSURANCE_AMOUNT"].ToString(),
                    Misc_Amount = additional["INDIVITUAL_MISC_AMOUNT"].ToString(),
                    Line_Number = lineNumber.ToString()
                };

                clearanceObj.details.Add(detail);
                lineNumber++;
            }

            string apiUrl = "http://integrationlive.rvscommerce.com:3000/api/be";
            string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MSwiaWF0IjoxNzUwNjg3MDkwfQ.QpayMNPzu-LPpNst175pUCZYuIRmMPTi6cTKES-mMjk"; 

            string jsonPayload = JsonConvert.SerializeObject(clearanceObj);

            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers[HttpRequestHeader.Authorization] = "Bearer " + bearerToken;

                string response = client.UploadString(apiUrl, "POST", jsonPayload);

                AcknowledgementResponse result = JsonConvert.DeserializeObject<AcknowledgementResponse>(response);

                return "Posted Successfully. Table_ID: " + result.Table_ID;
            }
        }
        catch (WebException ex)
        {
            if (ex.Response != null)
            {
                using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    string errorResponse = reader.ReadToEnd();
                    return "Error: " + errorResponse;
                }
            }
            return "WebException: " + ex.Message;
        }
        catch (Exception ex)
        {
            return "General Error: " + ex.Message;
        }
    }  
}


