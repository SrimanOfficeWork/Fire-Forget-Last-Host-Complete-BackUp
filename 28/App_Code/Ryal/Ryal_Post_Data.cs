using System;
using System.IO;
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
using Newtonsoft.Json;



//https://stackoverflow.com/questions/41240722/xml-request-using-post-methodssss
public class Ryal_Post_Data
{
    // new AUG_10
    public string Folder_path;
    Global_variables ObjUBO = new Global_variables();


    //private readonly string stagingURL = "http://ec2-13-127-53-159.ap-south-1.compute.amazonaws.com/RyalErp2/RoyalWebhook/";  // OLd 

    private readonly string stagingURL = "http://ec2-13-233-140-191.ap-south-1.compute.amazonaws.com/RyalErp2/RoyalWebhook/"; //Ryal give the updated staging URL on 4-dec2020
    private readonly string liveURL = "https://erp.ryal.in/RoyalWebhook/";
    
    public void Get_Ryal(string Jobno, string Imp_Exp, string is_live)
    {
        //is_live: 1 = Live, 0 = Testing
        //job_no: this is the Ryal Job No e.g. SJ000104/20-21
        //job_type: 0 = Export, 1 = Import
        //shipping_type: 0 = Air, 1 = SEA

        DataSet dss = new DataSet();
        ObjUBO.A1 = Jobno;
        ObjUBO.A4 = Imp_Exp;
        ObjUBO.A5 = "FF_DATA";
        dss = Select_IMP_EXP_Ryal(ObjUBO);
        if (dss.Tables.Count > 0)
        {
            // PostDssata(int is_live, string job_no, int job_type, int shipping_type, string data);
            int shipping_type;
            if (dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() == "Air")
            {
                shipping_type = 0;
            }
            else
            {
                shipping_type = 1;
            }
            if (Imp_Exp == "I")
            {
                //PostData(0, dss.Tables[0].Rows[0]["JOBNO_PS"].ToString(), 1, shipping_type, SOAP_XML(dss));
               // PostData(0, dss.Tables[0].Rows[0]["Ryal_Jobno"].ToString(), 1, shipping_type, SOAP_XML(dss));
                PostData(1, dss.Tables[0].Rows[0]["Ryal_Jobno"].ToString(), 1, shipping_type, SOAP_XML(dss));
            }
            else if (Imp_Exp == "E")
            {
                
               // PostData(0, dss.Tables[0].Rows[0]["JOBNO_PS"].ToString(), 0, shipping_type, SOAP_XML_EXP(dss));
                //PostData(0, dss.Tables[0].Rows[0]["Ryal_Jobno"].ToString(), 0, shipping_type, SOAP_XML_EXP(dss));
                PostData(1, dss.Tables[0].Rows[0]["Ryal_Jobno"].ToString(), 0, shipping_type, SOAP_XML_EXP(dss));

               
            }
        }
    }
    private string SOAP_XML_EXP(DataSet ds)
    {
        string
              EXPORT_ANNEXURE_C_SEA_ = string.Empty
            , EXPORT_ANNEXURE_C_AIR_ = string.Empty
            , EXPORT_ANNEXURE_C_SEA_CONTAINER_ = string.Empty
            , EXPORT_ANNEXURE_C_SEA_PACKAGE_ = string.Empty
            , EXPORT_INVOICE_DETAILS_ = string.Empty
            , EXPORT_ITEM_DETAILS_ = string.Empty
            , EXPORT_SB_ENTRY_ = string.Empty;

        EXPORT_ANNEXURE_C_AIR_ = EXPORT_ANNEXURE_C_AIR(ds);
        EXPORT_ANNEXURE_C_SEA_ = EXPORT_ANNEXURE_C_SEA(ds);
        EXPORT_ANNEXURE_C_SEA_CONTAINER_ = EXPORT_ANNEXURE_C_SEA_CONTAINER(ds);
        EXPORT_ANNEXURE_C_SEA_PACKAGE_ = EXPORT_ANNEXURE_C_SEA_PACKAGE(ds);
        EXPORT_INVOICE_DETAILS_=EXPORT_INVOICE_DETAILS(ds);
        EXPORT_ITEM_DETAILS_ = EXPORT_ITEM_DETAILS(ds);
        EXPORT_SB_ENTRY_ = EXPORT_SB_ENTRY(ds);

        var requestStr = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body>" +
            "<Ryal_Imp_Data xmlns=\"http://tempuri.org/\">" +
            "<xmldoc><![CDATA[" +
           "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
           "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body>" +
           "<Ryal_Imp_Data xmlns=\"http://tempuri.org/\">" +
           
           "<EXPORT_GENERAL_DETAILS>" +
           "<JOBNO>" + ds.Tables[0].Rows[0]["JOBNO"].ToString() + "</JOBNO>" +
           "<JOBNO_PS>" + ds.Tables[0].Rows[0]["JOBNO_PS"].ToString() + "</JOBNO_PS>" +
           "<FILE_REF_NO>" + ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString() + "</FILE_REF_NO>" +
           "<JOBDATE>" + ds.Tables[0].Rows[0]["JOBDATE"].ToString() + "</JOBDATE>" +
           "<TRANSPORT_MODE>" + ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() + "</TRANSPORT_MODE>" +
           "<CUSTOMS_HOUSE>" + ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString() + "</CUSTOMS_HOUSE>" +
           "<CUSTOMS_HOUSE_NAME>" + ds.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString() + "</CUSTOMS_HOUSE_NAME>" +
           "<SB_TYPE>" + ds.Tables[0].Rows[0]["SB_TYPE"].ToString() + "</SB_TYPE>" +
           "<EXPORTER_NAME>" + ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString() + "</EXPORTER_NAME>" +
           "<BRANCH_NO>" + ds.Tables[0].Rows[0]["BRANCH_NO"].ToString() + "</BRANCH_NO>" +
           "<IEC_NO>" + ds.Tables[0].Rows[0]["IEC_NO"].ToString() + "</IEC_NO>" +
           "<ADDRESS1>" + ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + "</ADDRESS1>" +
           "<ADDRESS2>" + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + "</ADDRESS2>" +
           "<ADDRESS3>" + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + "</ADDRESS3>" +
           "<ADDRESS4>" + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + "</ADDRESS4>" +
           "<ADDRESS5>" + ds.Tables[0].Rows[0]["ADDRESS5"].ToString() + "</ADDRESS5>" +
           "<ADCODE>" + ds.Tables[0].Rows[0]["ADCODE"].ToString() + "</ADCODE>" +
           "<BANK_ACCOUNT>" + ds.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString() + "</BANK_ACCOUNT>" +
           "<DRAWBACK_ACCOUNT>" + ds.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString() + "</DRAWBACK_ACCOUNT>" +
           "<CONSIGNEE_NAME>" + ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString() + "</CONSIGNEE_NAME>" +
           "<CONSIGNEE_ADD1>" + ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString() + "</CONSIGNEE_ADD1>" +
           "<CONSIGNEE_ADD2>" + ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString() + "</CONSIGNEE_ADD2>" +
           "<CONSIGNEE_ADD3>" + ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString() + "</CONSIGNEE_ADD3>" +
           "<CONSIGNEE_ADD4>" + ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString() + "</CONSIGNEE_ADD4>" +
           "<CONSIGNEE_ADD5>" + ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString() + "</CONSIGNEE_ADD5>" +
           "<COUNTRY_DISCHARGE>" + ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString() + "</COUNTRY_DISCHARGE>" +
           "<PORT_DISCHARGE>" + ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString() + "</PORT_DISCHARGE>" +
           "<COUNTRY_FINAL_DEST>" + ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString() + "</COUNTRY_FINAL_DEST>" +
           "<PORT_FINAL_DEST>" + ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString() + "</PORT_FINAL_DEST>" +
           "<STATE_OF_EXPORT>" + ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString() + "</STATE_OF_EXPORT>" +
           "<USERID>" + ds.Tables[0].Rows[0]["USERID"].ToString() + "</USERID>" +
           "<LoginDate>" + ds.Tables[0].Rows[0]["LoginDate"].ToString() + "</LoginDate>" +
           "<BRANCHCODE>" + ds.Tables[0].Rows[0]["BRANCHCODE"].ToString() + "</BRANCHCODE>" +
           "<WORKINGPERIOD>" + ds.Tables[0].Rows[0]["WORKINGPERIOD"].ToString() + "</WORKINGPERIOD>" +
           "<CONSIGNEE_BRANCHSLNO>" + ds.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString() + "</CONSIGNEE_BRANCHSLNO>" +
           "<Ryal_Jobno>" + ds.Tables[0].Rows[0]["Ryal_Jobno"].ToString() + "</Ryal_Jobno>" +
           "</EXPORT_GENERAL_DETAILS> " +

           "<EXPORT_ANNEXURE_C_AIR>" + EXPORT_ANNEXURE_C_AIR_ + "</EXPORT_ANNEXURE_C_AIR>" +
           "<EXPORT_ANNEXURE_C_SEA>" + EXPORT_ANNEXURE_C_SEA_ + "</EXPORT_ANNEXURE_C_SEA>" +

           "<EXPORT_ANNEXURE_C_SEA_CONTAINER>" + EXPORT_ANNEXURE_C_SEA_CONTAINER_ + "</EXPORT_ANNEXURE_C_SEA_CONTAINER>" +
           "<EXPORT_ANNEXURE_C_SEA_PACKAGE>" + EXPORT_ANNEXURE_C_SEA_PACKAGE_ + "</EXPORT_ANNEXURE_C_SEA_PACKAGE>" +
           "<EXPORT_INVOICE_DETAILS>" + EXPORT_INVOICE_DETAILS_ + "</EXPORT_INVOICE_DETAILS>" +
           "<EXPORT_INVOICE_DETAILS>" + EXPORT_ITEM_DETAILS_ + "</EXPORT_INVOICE_DETAILS>" +
           "<EXPORT_INVOICE_DETAILS>" + EXPORT_SB_ENTRY_ + "</EXPORT_INVOICE_DETAILS>" +
           "<EXPORT_SB_ENTRY>" + EXPORT_SB_ENTRY_ + "</EXPORT_SB_ENTRY>" +
         
           "</Ryal_Imp_Data></soap:Body></soap:Envelope>"
            +
            "]]></xmldoc>" +
            "</Ryal_Imp_Data></soap:Body></soap:Envelope>";
        return requestStr;
    }
    private string EXPORT_ANNEXURE_C_AIR(DataSet ds)
    {
        string Con = string.Empty, Data = string.Empty;
        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        {
            Data = "<ANNEX_AIR_SEALNO>" + ds.Tables[1].Rows[i]["ANNEX_AIR_SEALNO"].ToString() + "</ANNEX_AIR_SEALNO>" +
                      "<ANNEX_AIR_SEAL_AGENCY>" + ds.Tables[1].Rows[i]["ANNEX_AIR_SEAL_AGENCY"].ToString() + "</ANNEX_AIR_SEAL_AGENCY>" +
                      "<ANNEX_AIR_NATURE_OF_CARGO>" + ds.Tables[1].Rows[i]["ANNEX_AIR_NATURE_OF_CARGO"].ToString() + "</ANNEX_AIR_NATURE_OF_CARGO>" +
                      "<ANNEX_AIR_MARKS_NOS>" + ds.Tables[1].Rows[i]["ANNEX_AIR_MARKS_NOS"].ToString() + "</ANNEX_AIR_MARKS_NOS>" +
                      "<ANNEX_AIR_TOTAL_PACKAGES>" + ds.Tables[1].Rows[i]["ANNEX_AIR_TOTAL_PACKAGES"].ToString() + "</ANNEX_AIR_TOTAL_PACKAGES>" +

                      "<ANNEX_AIR_UNIT_CODE>" + ds.Tables[1].Rows[i]["ANNEX_AIR_UNIT_CODE"].ToString() + "</ANNEX_AIR_UNIT_CODE>" +
                      "<ANNEX_AIR_FREIGHT_AMT>" + ds.Tables[1].Rows[i]["ANNEX_AIR_FREIGHT_AMT"].ToString() + "</ANNEX_AIR_FREIGHT_AMT>" +
                      "<ANNEX_AIR_INSURANCE_AMT>" + ds.Tables[1].Rows[i]["ANNEX_AIR_INSURANCE_AMT"].ToString() + "</ANNEX_AIR_INSURANCE_AMT>" +
                      "<ANNEX_AIR_GROSS_WEIGHT>" + ds.Tables[1].Rows[i]["ANNEX_AIR_GROSS_WEIGHT"].ToString() + "</ANNEX_AIR_GROSS_WEIGHT>" +
                      "<ANNEX_AIR_GR_UNIT_CODE>" + ds.Tables[1].Rows[i]["ANNEX_AIR_GR_UNIT_CODE"].ToString() + "</ANNEX_AIR_GR_UNIT_CODE>" +

                      "<ANNEX_AIR_NET_WEIGHT>" + ds.Tables[1].Rows[i]["ANNEX_AIR_NET_WEIGHT"].ToString() + "</ANNEX_AIR_NET_WEIGHT>" +
                      "<ANNEX_AIR_MAWB_NO>" + ds.Tables[1].Rows[i]["ANNEX_AIR_MAWB_NO"].ToString() + "</ANNEX_AIR_MAWB_NO>" +
                      "<ANNEX_AIR_HAWB_NO>" + ds.Tables[1].Rows[i]["ANNEX_AIR_HAWB_NO"].ToString() + "</ANNEX_AIR_HAWB_NO>" +
                      "<ANNEX_AIR_TOTAL_PACKAGES_MAWB>" + ds.Tables[1].Rows[i]["ANNEX_AIR_TOTAL_PACKAGES_MAWB"].ToString() + "</ANNEX_AIR_TOTAL_PACKAGES_MAWB>" +
                      "<ANNEX_AIR_ROTATION_NO>" + ds.Tables[1].Rows[i]["ANNEX_AIR_ROTATION_NO"].ToString() + "</ANNEX_AIR_ROTATION_NO>" +
                      "<ANNEX_AIR_ROTATION_DATE>" + ds.Tables[1].Rows[i]["ANNEX_AIR_ROTATION_DATE"].ToString() + "</ANNEX_AIR_ROTATION_DATE>" +
                      "<ANNEX_AIR_FOB_VALUE>" + ds.Tables[1].Rows[i]["ANNEX_AIR_FOB_VALUE"].ToString() + "</ANNEX_AIR_FOB_VALUE>";
            Con += Data;
            Data = "";
        }
        return Con;
    }
    private string EXPORT_ANNEXURE_C_SEA(DataSet ds)
    {
        string Con = string.Empty, Data = string.Empty;
        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
        {
            Data = "<ANNEX_SEA_FAC_STUFFED>" + ds.Tables[2].Rows[i]["ANNEX_SEA_FAC_STUFFED"].ToString() + "</ANNEX_SEA_FAC_STUFFED>" +
                      "<ANNEX_SEA_SAMPLE_ACCOM>" + ds.Tables[2].Rows[i]["ANNEX_SEA_SAMPLE_ACCOM"].ToString() + "</ANNEX_SEA_SAMPLE_ACCOM>" +
                      "<ANNEX_SEA_NATURE_OF_CARGO>" + ds.Tables[2].Rows[i]["ANNEX_SEA_NATURE_OF_CARGO"].ToString() + "</ANNEX_SEA_NATURE_OF_CARGO>" +
                      "<ANNEX_SEA_MARKS_NOS>" + ds.Tables[2].Rows[i]["ANNEX_SEA_MARKS_NOS"].ToString() + "</ANNEX_SEA_MARKS_NOS>" +

                      "<ANNEX_SEA_TOTAL_PACKAGES>" + ds.Tables[2].Rows[i]["ANNEX_SEA_TOTAL_PACKAGES"].ToString() + "</ANNEX_SEA_TOTAL_PACKAGES>" +
                      "<ANNEX_SEA_LOOSE_PACKETS>" + ds.Tables[2].Rows[i]["ANNEX_SEA_LOOSE_PACKETS"].ToString() + "</ANNEX_SEA_LOOSE_PACKETS>" +
                      "<ANNEX_SEA_NO_CONTAINERS>" + ds.Tables[2].Rows[i]["ANNEX_SEA_NO_CONTAINERS"].ToString() + "</ANNEX_SEA_NO_CONTAINERS>" +
                      "<ANNEX_SEA_GROSS_WEIGHT>" + ds.Tables[2].Rows[i]["ANNEX_SEA_GROSS_WEIGHT"].ToString() + "</ANNEX_SEA_GROSS_WEIGHT>" +
                      "<ANNEX_SEA_NET_WEIGHT>" + ds.Tables[2].Rows[i]["ANNEX_SEA_NET_WEIGHT"].ToString() + "</ANNEX_SEA_NET_WEIGHT>" +
                      "<ANNEX_SEA_UNIT_MEASUREMENT>" + ds.Tables[2].Rows[i]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString() + "</ANNEX_SEA_UNIT_MEASUREMENT>" +
                      "<ANNEX_SEA_ROTATION_NO>" + ds.Tables[2].Rows[i]["ANNEX_SEA_ROTATION_NO"].ToString() + "</ANNEX_SEA_ROTATION_NO>" +
                      "<ANNEX_SEA_ROTATION_DATE>" + ds.Tables[2].Rows[i]["ANNEX_SEA_ROTATION_DATE"].ToString() + "</ANNEX_SEA_ROTATION_DATE>" +
                      "<ANNEX_SEA_FOB_VALUE>" + ds.Tables[2].Rows[i]["ANNEX_SEA_FOB_VALUE"].ToString() + "</ANNEX_SEA_FOB_VALUE>" +
                      "<ANNEX_SEA_SEAL_TYPE>" + ds.Tables[2].Rows[i]["ANNEX_SEA_SEAL_TYPE"].ToString() + "</ANNEX_SEA_SEAL_TYPE>";
            Con += Data;
            Data = "";
        }
        return Con;
    }

    private string EXPORT_ANNEXURE_C_SEA_CONTAINER(DataSet ds)
    {
        string Con = string.Empty, Data = string.Empty;
        for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
        {
            Data = "<ANNEX_SEA_CON_CONTAINERNO>" + ds.Tables[3].Rows[i]["ANNEX_SEA_CON_CONTAINERNO"].ToString() + "</ANNEX_SEA_CON_CONTAINERNO>" +
                      "<ANNEX_SEA_CON_SIZE>" + ds.Tables[3].Rows[i]["ANNEX_SEA_CON_SIZE"].ToString() + "</ANNEX_SEA_CON_SIZE>" +
                      "<ANNEX_SEA_CON_TYPE>" + ds.Tables[3].Rows[i]["ANNEX_SEA_CON_TYPE"].ToString() + "</ANNEX_SEA_CON_TYPE>" +
                      "<ANNEX_SEA_CON_EXCISE_SEALNO>" + ds.Tables[3].Rows[i]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString() + "</ANNEX_SEA_CON_EXCISE_SEALNO>" +
                      "<ANNEX_SEA_CON_SEAL_DATE>" + ds.Tables[3].Rows[i]["ANNEX_SEA_CON_SEAL_DATE"].ToString() + "</ANNEX_SEA_CON_SEAL_DATE>" +
                      "<ANNEX_SEA_CON_SEALTYPE_INDICATOR>" + ds.Tables[3].Rows[i]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString() + "</ANNEX_SEA_CON_SEALTYPE_INDICATOR>" +
                      "<ANNEX_SEA_CON_SEAL_DEVICEID>" + ds.Tables[3].Rows[i]["ANNEX_SEA_CON_SEAL_DEVICEID"].ToString() + "</ANNEX_SEA_CON_SEAL_DEVICEID>" +
                      "<ANNEX_SEA_CON_DOC_TYPE>" + ds.Tables[3].Rows[i]["ANNEX_SEA_CON_DOC_TYPE"].ToString() + "</ANNEX_SEA_CON_DOC_TYPE>" +
                      "<ANNEX_SEA_CON_DOC_NUMBER>" + ds.Tables[3].Rows[i]["ANNEX_SEA_CON_DOC_NUMBER"].ToString() + "</ANNEX_SEA_CON_DOC_NUMBER>";
            Con += Data;
            Data = "";
        }
        return Con;
    }

    private string EXPORT_ANNEXURE_C_SEA_PACKAGE(DataSet ds)
    {
        string Con = string.Empty, Data = string.Empty;
        for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
        {
            Data = "<ANNEX_SEA_PACK_GROUP>" + ds.Tables[4].Rows[i]["ANNEX_SEA_PACK_GROUP"].ToString() + "</ANNEX_SEA_PACK_GROUP>" +
                      "<ANNEX_SEA_PACK_FROM>" + ds.Tables[4].Rows[i]["ANNEX_SEA_PACK_FROM"].ToString() + "</ANNEX_SEA_PACK_FROM>" +
                      "<ANNEX_SEA_PACK_TO>" + ds.Tables[4].Rows[i]["ANNEX_SEA_PACK_TO"].ToString() + "</ANNEX_SEA_PACK_TO>" +
                      "<ANNEX_SEA_PACK_PACKAGETYPE>" + ds.Tables[4].Rows[i]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString() + "</ANNEX_SEA_PACK_PACKAGETYPE>" +
                      "<ANNEX_SEA_PACK_FROMDESC>" + ds.Tables[4].Rows[i]["ANNEX_SEA_PACK_FROMDESC"].ToString() + "</ANNEX_SEA_PACK_FROMDESC>" +
                      "<ANNEX_SEA_PACK_TODESC>" + ds.Tables[4].Rows[i]["ANNEX_SEA_PACK_TODESC"].ToString() + "</ANNEX_SEA_PACK_TODESC>";
            Con += Data;
            Data = "";
        }
        return Con;
    }
    private string EXPORT_INVOICE_DETAILS(DataSet ds)
    {
        string Con = string.Empty, Data = string.Empty;
        for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
        {
            Data = "<INVOICE_SLNO>" + ds.Tables[5].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                      "<INVOICE_NO>" + ds.Tables[5].Rows[i]["INVOICE_NO"].ToString() + "</INVOICE_NO>" +
                      "<INVOICE_DATE>" + ds.Tables[5].Rows[i]["INVOICE_DATE"].ToString() + "</INVOICE_DATE>" +
                      "<PAYMENT_METHOD>" + ds.Tables[5].Rows[i]["PAYMENT_METHOD"].ToString() + "</PAYMENT_METHOD>" +
                      "<PERIOD_PAYMENT>" + ds.Tables[5].Rows[i]["PERIOD_PAYMENT"].ToString() + "</PERIOD_PAYMENT>" +

                      "<INVOICE_VALUE>" + ds.Tables[5].Rows[i]["INVOICE_VALUE"].ToString() + "</INVOICE_VALUE>" +
                      "<INVOICE_CURRENCY>" + ds.Tables[5].Rows[i]["INVOICE_CURRENCY"].ToString() + "</INVOICE_CURRENCY>" +
                      "<EXCHANGE_RATE>" + ds.Tables[5].Rows[i]["EXCHANGE_RATE"].ToString() + "</EXCHANGE_RATE>" +
                      "<CONTRACT_NO>" + ds.Tables[5].Rows[i]["CONTRACT_NO"].ToString() + "</CONTRACT_NO>" +
                      "<TERMS>" + ds.Tables[5].Rows[i]["TERMS"].ToString() + "</TERMS>" +
                      "<BUYER>" + ds.Tables[5].Rows[i]["BUYER"].ToString() + "</BUYER>" +
                      "<BUYER_NAME>" + ds.Tables[5].Rows[i]["BUYER_NAME"].ToString() + "</BUYER_NAME>" +
                      "<BUYER_ADDRESS>" + ds.Tables[5].Rows[i]["BUYER_ADDRESS"].ToString() + "</BUYER_ADDRESS>" +
                      "<BUYER_ADDRESS1>" + ds.Tables[5].Rows[i]["BUYER_ADDRESS1"].ToString() + "</BUYER_ADDRESS1>" +
                      "<BUYER_ADDRESS2>" + ds.Tables[5].Rows[i]["BUYER_ADDRESS2"].ToString() + "</BUYER_ADDRESS2>" +
                      "<BUYER_ADDRESS3>" + ds.Tables[5].Rows[i]["BUYER_ADDRESS3"].ToString() + "</BUYER_ADDRESS3>" +
                      "<BUYER_ADDRESS4>" + ds.Tables[5].Rows[i]["BUYER_ADDRESS4"].ToString() + "</BUYER_ADDRESS4>" +
                      "<COMMISSION_RATE>" + ds.Tables[5].Rows[i]["COMMISSION_RATE"].ToString() + "</COMMISSION_RATE>" +
                      "<COMMISSION_CHARGES>" + ds.Tables[5].Rows[i]["COMMISSION_CHARGES"].ToString() + "</COMMISSION_CHARGES>" +
                      "<COMMISSION_CURRENCY>" + ds.Tables[5].Rows[i]["COMMISSION_CURRENCY"].ToString() + "</COMMISSION_CURRENCY>" +

                      "<FOB_RATE>" + ds.Tables[5].Rows[i]["FOB_RATE"].ToString() + "</FOB_RATE>" +
                      "<FOB_CHARGES>" + ds.Tables[5].Rows[i]["FOB_CHARGES"].ToString() + "</FOB_CHARGES>" +
                      "<FOB_CURRENCY>" + ds.Tables[5].Rows[i]["FOB_CURRENCY"].ToString() + "</FOB_CURRENCY>" +
                      "<PACKMISC_RATE>" + ds.Tables[5].Rows[i]["PACKMISC_RATE"].ToString() + "</PACKMISC_RATE>" +
                      "<PACKMISC_CHARGES>" + ds.Tables[5].Rows[i]["PACKMISC_CHARGES"].ToString() + "</PACKMISC_CHARGES>" +
                      "<PACKMISC_CURRENCY>" + ds.Tables[5].Rows[i]["PACKMISC_CURRENCY"].ToString() + "</PACKMISC_CURRENCY>" +
                      "<OTHER_DEDUCTION_RATE>" + ds.Tables[5].Rows[i]["OTHER_DEDUCTION_RATE"].ToString() + "</OTHER_DEDUCTION_RATE>" +
                      "<OTHER_DEDUCTION_CHARGES>" + ds.Tables[5].Rows[i]["OTHER_DEDUCTION_CHARGES"].ToString() + "</OTHER_DEDUCTION_CHARGES>" +
                      "<OTHER_DEDUCTION_CURRENCY>" + ds.Tables[5].Rows[i]["OTHER_DEDUCTION_CURRENCY"].ToString() + "</OTHER_DEDUCTION_CURRENCY>" +
                      "<FREIGHT_RATE>" + ds.Tables[5].Rows[i]["FREIGHT_RATE"].ToString() + "</FREIGHT_RATE>" +
                      "<FREIGHT_CHARGES>" + ds.Tables[5].Rows[i]["FREIGHT_CHARGES"].ToString() + "</FREIGHT_CHARGES>" +

                      "<FREIGHT_EXRATE>" + ds.Tables[5].Rows[i]["FREIGHT_EXRATE"].ToString() + "</FREIGHT_EXRATE>" +
                      "<INSURANCE_RATE>" + ds.Tables[5].Rows[i]["INSURANCE_RATE"].ToString() + "</INSURANCE_RATE>" +
                      "<INSURANCE_CHARGES>" + ds.Tables[5].Rows[i]["INSURANCE_CHARGES"].ToString() + "</INSURANCE_CHARGES>" +
                      "<INSURANCE_CURRENCY>" + ds.Tables[5].Rows[i]["INSURANCE_CURRENCY"].ToString() + "</INSURANCE_CURRENCY>" +
                      "<INSURANCE_EXRATE>" + ds.Tables[5].Rows[i]["INSURANCE_EXRATE"].ToString() + "</INSURANCE_EXRATE>" +
                      "<WHEATHER_UNIT_PRICE>" + ds.Tables[5].Rows[i]["WHEATHER_UNIT_PRICE"].ToString() + "</WHEATHER_UNIT_PRICE>" +
                      "<NON_STD_EFFECT_DT_EXP>" + ds.Tables[5].Rows[i]["NON_STD_EFFECT_DT_EXP"].ToString() + "</NON_STD_EFFECT_DT_EXP>" +
                      "<NON_STD_BANKNAME>" + ds.Tables[5].Rows[i]["NON_STD_BANKNAME"].ToString() + "</NON_STD_BANKNAME>" +
                      "<NON_STD_CERTIFICATE_NO>" + ds.Tables[5].Rows[i]["NON_STD_CERTIFICATE_NO"].ToString() + "</NON_STD_CERTIFICATE_NO>" +
                      "<NON_STD_CERTIFICATE_DATE>" + ds.Tables[5].Rows[i]["NON_STD_CERTIFICATE_DATE"].ToString() + "</NON_STD_CERTIFICATE_DATE>" +
                      
                      "<TERMS_PLACE>" + ds.Tables[5].Rows[i]["TERMS_PLACE"].ToString() + "</TERMS_PLACE>" +
                      "<THIRDPARTY_NAME>" + ds.Tables[5].Rows[i]["THIRDPARTY_NAME"].ToString() + "</THIRDPARTY_NAME>" +
                      "<THIRDPARTY_ADD1>" + ds.Tables[5].Rows[i]["THIRDPARTY_ADD1"].ToString() + "</THIRDPARTY_ADD1>" +
                      "<THIRDPARTY_ADD2>" + ds.Tables[5].Rows[i]["THIRDPARTY_ADD2"].ToString() + "</THIRDPARTY_ADD2>" +
                      "<THIRDPARTY_CITY>" + ds.Tables[5].Rows[i]["THIRDPARTY_CITY"].ToString() + "</THIRDPARTY_CITY>" +
                      "<T_PARTY_COUNTRY_SUB_DIV>" + ds.Tables[5].Rows[i]["T_PARTY_COUNTRY_SUB_DIV"].ToString() + "</T_PARTY_COUNTRY_SUB_DIV>" +
                      "<T_PARTY_COUNTRY_CODE>" + ds.Tables[5].Rows[i]["T_PARTY_COUNTRY_CODE"].ToString() + "</T_PARTY_COUNTRY_CODE>" +
                      "<T_PARTY_PIN>" + ds.Tables[5].Rows[i]["T_PARTY_PIN"].ToString() + "</T_PARTY_PIN>" +
                      "<AUTHORIZED_ECONOMIC_OPERATOR_CODE>" + ds.Tables[5].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString() + "</AUTHORIZED_ECONOMIC_OPERATOR_CODE>" +
                      "<A_E_O_COUNTRY>" + ds.Tables[5].Rows[i]["A_E_O_COUNTRY"].ToString() + "</A_E_O_COUNTRY>" +
                      "<AUTHORIZED_ECONOMIC_OPERATOR>" + ds.Tables[5].Rows[i]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString() + "</AUTHORIZED_ECONOMIC_OPERATOR>" +
                      "<DOC_RECD_DATE>" + ds.Tables[5].Rows[i]["DOC_RECD_DATE"].ToString() + "</DOC_RECD_DATE>";
            Con += Data;
            Data = "";
        }
        return Con;
    }
    private string EXPORT_ITEM_DETAILS(DataSet ds)
    {
        string Con = string.Empty, Data = string.Empty;
        for (int i = 0; i < ds.Tables[6].Rows.Count; i++)
        {
            Data = "<INVOICE_SLNO>" + ds.Tables[6].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                      "<INVOICE_NO>" + ds.Tables[6].Rows[i]["INVOICE_NO"].ToString() + "</INVOICE_NO>" +
                      "<ITEM_SLNO>" + ds.Tables[6].Rows[i]["ITEM_SLNO"].ToString() + "</ITEM_SLNO>" +
                      "<ITEM_DESCRIPTION>" + ds.Tables[6].Rows[i]["ITEM_DESCRIPTION"].ToString() + "</ITEM_DESCRIPTION>" +
                      "<RITCNO>" + ds.Tables[6].Rows[i]["RITCNO"].ToString() + "</RITCNO>" +
                      "<ITEM_QTY>" + ds.Tables[6].Rows[i]["ITEM_QTY"].ToString() + "</ITEM_QTY>" +
                      "<ITEM_QTY_CODE>" + ds.Tables[6].Rows[i]["ITEM_QTY_CODE"].ToString() + "</ITEM_QTY_CODE>" +
                      "<ITEM_UNIT_PRICE>" + ds.Tables[6].Rows[i]["ITEM_UNIT_PRICE"].ToString() + "</ITEM_UNIT_PRICE>" +
                      "<ITEM_PER>" + ds.Tables[6].Rows[i]["ITEM_PER"].ToString() + "</ITEM_PER>" +
                      "<ITEM_AMOUNT>" + ds.Tables[6].Rows[i]["ITEM_AMOUNT"].ToString() + "</ITEM_AMOUNT>" +
                      "<ITEM_PMVVALUE>" + ds.Tables[6].Rows[i]["ITEM_PMVVALUE"].ToString() + "</ITEM_PMVVALUE>" +
                      "<ITEM_SCHEME_CODE>" + ds.Tables[6].Rows[i]["ITEM_SCHEME_CODE"].ToString() + "</ITEM_SCHEME_CODE>" +
                      "<ITEM_ACCESSORIES_DESC>" + ds.Tables[6].Rows[i]["ITEM_ACCESSORIES_DESC"].ToString() + "</ITEM_ACCESSORIES_DESC>" +
                      "<ITEM_AR4_NO>" + ds.Tables[6].Rows[i]["ITEM_AR4_NO"].ToString() + "</ITEM_AR4_NO>" +
                      "<ITEM_AR4_DATE>" + ds.Tables[6].Rows[i]["ITEM_AR4_DATE"].ToString() + "</ITEM_AR4_DATE>" +
                      "<ITEM_COMMISSION_RATE>" + ds.Tables[6].Rows[i]["ITEM_COMMISSION_RATE"].ToString() + "</ITEM_COMMISSION_RATE>" +
                      "<ITEM_DIVISION>" + ds.Tables[6].Rows[i]["ITEM_DIVISION"].ToString() + "</ITEM_DIVISION>" +
                      "<ITEM_RANGE>" + ds.Tables[6].Rows[i]["ITEM_RANGE"].ToString() + "</ITEM_RANGE>" +
                      "<ITEM_REMARKS>" + ds.Tables[6].Rows[i]["ITEM_REMARKS"].ToString() + "</ITEM_REMARKS>" +
                      "<ITEM_IECCODE>" + ds.Tables[6].Rows[i]["ITEM_IECCODE"].ToString() + "</ITEM_IECCODE>" +
                      "<ITEM_EXPORTER_NAME>" + ds.Tables[6].Rows[i]["ITEM_EXPORTER_NAME"].ToString() + "</ITEM_EXPORTER_NAME>" +
                      "<BR_SLNO>" + ds.Tables[6].Rows[i]["BR_SLNO"].ToString() + "</BR_SLNO>" +
                      "<ADDRESS1>" + ds.Tables[6].Rows[i]["ADDRESS1"].ToString() + "</ADDRESS1>" +
                      "<ADDRESS2>" + ds.Tables[6].Rows[i]["ADDRESS2"].ToString() + "</ADDRESS2>" +
                      "<ADDRESS3>" + ds.Tables[6].Rows[i]["ADDRESS3"].ToString() + "</ADDRESS3>" +
                      "<ADDRESS4>" + ds.Tables[6].Rows[i]["ADDRESS4"].ToString() + "</ADDRESS4>" +
                      "<ADDRESS5>" + ds.Tables[6].Rows[i]["ADDRESS5"].ToString() + "</ADDRESS5>" +
                      "<ITEM_STR_CODE>" + ds.Tables[6].Rows[i]["ITEM_STR_CODE"].ToString() + "</ITEM_STR_CODE>" +
                      "<REWARD_POINTS>" + ds.Tables[6].Rows[i]["REWARD_POINTS"].ToString() + "</REWARD_POINTS>" +
                   
                      "<PMV_VALUE>" + ds.Tables[6].Rows[i]["PMV_VALUE"].ToString() + "</PMV_VALUE>" +
                      "<FOB_VALUE>" + ds.Tables[6].Rows[i]["FOB_VALUE"].ToString() + "</FOB_VALUE>" +
                      "<DRAWBACK_VALUE>" + ds.Tables[6].Rows[i]["DRAWBACK_VALUE"].ToString() + "</DRAWBACK_VALUE>" +
                      "<CESS_YN>" + ds.Tables[6].Rows[i]["CESS_YN"].ToString() + "</CESS_YN>" +
                      "<STR_RATE>" + ds.Tables[6].Rows[i]["STR_RATE"].ToString() + "</STR_RATE>" +
                      "<STR_AMOUNT>" + ds.Tables[6].Rows[i]["STR_AMOUNT"].ToString() + "</STR_AMOUNT>" +
                      "<MANUFACTURER_PRODUCER>" + ds.Tables[6].Rows[i]["MANUFACTURER_PRODUCER"].ToString() + "</MANUFACTURER_PRODUCER>" +
                      "<M_P_GROWER_CODE>" + ds.Tables[6].Rows[i]["M_P_GROWER_CODE"].ToString() + "</M_P_GROWER_CODE>" +
                      "<M_P_GROWER_ADD1>" + ds.Tables[6].Rows[i]["M_P_GROWER_ADD1"].ToString() + "</M_P_GROWER_ADD1>" +
                      "<M_P_GROWER_ADD2>" + ds.Tables[6].Rows[i]["M_P_GROWER_ADD2"].ToString() + "</M_P_GROWER_ADD2>" +
                      "<M_P_GROWER_CITY>" + ds.Tables[6].Rows[i]["M_P_GROWER_CITY"].ToString() + "</M_P_GROWER_CITY>" +
                      "<M_P_GROWER_COUNTRY_SUBDIV>" + ds.Tables[6].Rows[i]["M_P_GROWER_COUNTRY_SUBDIV"].ToString() + "</M_P_GROWER_COUNTRY_SUBDIV>" +
                      "<M_P_GROWER_PIN>" + ds.Tables[6].Rows[i]["M_P_GROWER_PIN"].ToString() + "</M_P_GROWER_PIN>" +
                      "<M_P_GROWER_COUNTRY>" + ds.Tables[6].Rows[i]["M_P_GROWER_COUNTRY"].ToString() + "</M_P_GROWER_COUNTRY>" +
                      "<SOURCE_STATE>" + ds.Tables[6].Rows[i]["SOURCE_STATE"].ToString() + "</SOURCE_STATE>" +
                      "<TRANSIT_COUNTRY>" + ds.Tables[6].Rows[i]["TRANSIT_COUNTRY"].ToString() + "</TRANSIT_COUNTRY>" +
                      "<ACCESSORY_STATUS>" + ds.Tables[6].Rows[i]["ACCESSORY_STATUS"].ToString() + "</ACCESSORY_STATUS>" +
                      "<HAWB_NO>" + ds.Tables[6].Rows[i]["HAWB_NO"].ToString() + "</HAWB_NO>" +
                      "<TOTAL_PKGS>" + ds.Tables[6].Rows[i]["TOTAL_PKGS"].ToString() + "</TOTAL_PKGS>" +
                      "<ENDUSE_ITEM>" + ds.Tables[6].Rows[i]["ENDUSE_ITEM"].ToString() + "</ENDUSE_ITEM>" +
                      "<IGST_PAYMENT>" + ds.Tables[6].Rows[i]["IGST_PAYMENT"].ToString() + "</IGST_PAYMENT>" +
                      "<TAXABLE_VALUE>" + ds.Tables[6].Rows[i]["TAXABLE_VALUE"].ToString() + "</TAXABLE_VALUE>" +
                      "<IGST_AMT>" + ds.Tables[6].Rows[i]["IGST_AMT"].ToString() + "</IGST_AMT>" +
                      "<GSTN_TYPE>" + ds.Tables[6].Rows[i]["GSTN_TYPE"].ToString() + "</GSTN_TYPE>" +
                      "<GSTN_ID>" + ds.Tables[6].Rows[i]["GSTN_ID"].ToString() + "</GSTN_ID>" +
                      "<IGST_RATE>" + ds.Tables[6].Rows[i]["IGST_RATE"].ToString() + "</IGST_RATE>" +
                      "<PMV_METHOD>" + ds.Tables[6].Rows[i]["PMV_METHOD"].ToString() + "</PMV_METHOD>" +
                      "<PMV_RATE>" + ds.Tables[6].Rows[i]["PMV_RATE"].ToString() + "</PMV_RATE>" +
                      "<PMV_PER_UNIT>" + ds.Tables[6].Rows[i]["PMV_PER_UNIT"].ToString() + "</PMV_PER_UNIT>";
            Con += Data;
            Data = "";
        }
        return Con;
    }
    private string EXPORT_SB_ENTRY(DataSet ds)
    {
        string Con = string.Empty, Data = string.Empty;
        for (int i = 0; i < ds.Tables[7].Rows.Count; i++)
        {
            Data = "<SB_NO>" + ds.Tables[7].Rows[i]["SB_NO"].ToString() + "</SB_NO>" +
                   "<SB_DATE>" + ds.Tables[7].Rows[i]["SB_DATE"].ToString() + "</SB_DATE>";
            Con += Data;
            Data = "";
        }
        return Con;
    }
    
    private string SOAP_XML( DataSet ds)
    {
        string data = string.Empty,IGM_data = string.Empty,Con_Data = string.Empty,Inv_Data_ = string.Empty,Item_Data_ = string.Empty,SW_Info_Type_ = string.Empty
               , SW_Const_ = string.Empty, SW_Prod_ = string.Empty, SW_Control_ = string.Empty, SW_Stmt_ = string.Empty, SW_Sup_doc_ = string.Empty, BE_Details_ = string.Empty;

        IGM_data=IGM(ds);
        Con_Data = CONTAINER_DETAILS(ds);
        Inv_Data_ = Inv_Data(ds);
        Item_Data_ = Item_Data(ds);
        SW_Info_Type_ = SW_Info_Type(ds);
        SW_Const_ = SW_Const(ds);
        SW_Prod_ = SW_Prod(ds);
        SW_Control_ = SW_Control(ds);
        SW_Stmt_ = SW_Stmt(ds);
        SW_Sup_doc_ = SW_Sup_doc(ds);
        BE_Details_ = BE_Details(ds);

        var requestStr = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body>" +
            "<Ryal_Imp_Data xmlns=\"http://tempuri.org/\">" +
            "<xmldoc><![CDATA[" +
           "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
           "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body>" +
           "<Ryal_Imp_Data xmlns=\"http://tempuri.org/\">" +

           "<GENERAL_DETAILS>" +
           "<JOBNO>" + ds.Tables[0].Rows[0]["JOBNO"].ToString() + "</JOBNO>" +
           "<JOBNO_PS>" + ds.Tables[0].Rows[0]["JOBNO_PS"].ToString() + "</JOBNO_PS>" +
           "<JOBDATE>" + ds.Tables[0].Rows[0]["JOBDATE"].ToString() + "</JOBDATE>" +
           "<TRANSPORT_MODE>" + ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() + "</TRANSPORT_MODE>" +
           "<BE_TYPE>" + ds.Tables[0].Rows[0]["BE_TYPE"].ToString() + "</BE_TYPE>" +
           "<CUSTOMS_HOUSE>" + ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString() + "</CUSTOMS_HOUSE>" +
           "<CONTAINER_TYPE>" + ds.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString() + "</CONTAINER_TYPE>" +
           "<FILE_REF_NO>" + ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString() + "</FILE_REF_NO>" +
           "<FILING_STATUS>" + ds.Tables[0].Rows[0]["FILING_STATUS"].ToString() + "</FILING_STATUS>" +
           "<IMPORTER_NAME>" + ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString() + "</IMPORTER_NAME>" +
           "<ADDRESS1>" + ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + "</ADDRESS1>" +
           "<ADDRESS2>" + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + "</ADDRESS2>" +
           "<ADDRESS3>" + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + "</ADDRESS3>" +
           "<ADDRESS4>" + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + "</ADDRESS4>" +
           "<ADDRESS5>" + ds.Tables[0].Rows[0]["ADDRESS5"].ToString() + "</ADDRESS5>" +
           "<IEC_NO>" + ds.Tables[0].Rows[0]["IEC_NO"].ToString() + "</IEC_NO>" +
           "<BRANCH_NO>" + ds.Tables[0].Rows[0]["BRANCH_NO"].ToString() + "</BRANCH_NO>" +
           "<COUNTRY_ORIGIN>" + ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString() + "</COUNTRY_ORIGIN>" +
           "<PORT_ORIGIN>" + ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString() + "</PORT_ORIGIN>" +
           "<PORT_SHIPMENT>" + ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString() + "</PORT_SHIPMENT>" +
           "<COUNTRY_SHIPMENT>" + ds.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString() + "</COUNTRY_SHIPMENT>" +
           "<COMMERCIAL_TAX_STATENAME>" + ds.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString() + "</COMMERCIAL_TAX_STATENAME>" +
           "<COMMERCIAL_TAX_STATECODE>" + ds.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString() + "</COMMERCIAL_TAX_STATECODE>" +
           "<Ryal_Jobno>" + ds.Tables[0].Rows[0]["Ryal_Jobno"].ToString() + "</Ryal_Jobno>" +
           "</GENERAL_DETAILS> " +

           "<IGM_DETAILS>" + IGM_data + "</IGM_DETAILS>" +
           "<CONTAINER_DETAILS>" + Con_Data + "</CONTAINER_DETAILS>" +
           "<INVOICE_DETAILS>" + Inv_Data_ + "</INVOICE_DETAILS>" +
           "<ITEM_PRODUCT_DETAILS>" + Item_Data_ + "</ITEM_PRODUCT_DETAILS>" +
           "<BE_ITEM_SW_INFO_TYPE>" + SW_Info_Type_ + "</BE_ITEM_SW_INFO_TYPE>" +
           "<BE_ITEM_SW_CONST>" + SW_Const_ + "</BE_ITEM_SW_CONST>" +
           "<BE_ITEM_SW_PROD>" + SW_Prod_ + "</BE_ITEM_SW_PROD>" +
           "<BE_ITEM_SW_CONTROL>" + SW_Control_ + "</BE_ITEM_SW_CONTROL>" +
           "<IMP_SINGLE_WINDOW_STMT>" + SW_Stmt_ + "</IMP_SINGLE_WINDOW_STMT>" +
           "<BE_ITEM_SW_SUP_DOC>" + SW_Sup_doc_ + "</BE_ITEM_SW_SUP_DOC>" +
           "<BE_DETAILS>" + BE_Details_ + "</BE_DETAILS>" +
           "</Ryal_Imp_Data></soap:Body></soap:Envelope>"
            +
            "]]></xmldoc>" +
            "</Ryal_Imp_Data></soap:Body></soap:Envelope>";
        return requestStr;
    }

    private string IGM( DataSet ds)
    {
        string IGM_XML = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[1].Rows.Count; i++)
         {
             Data = "<IGM_SLNO>" + ds.Tables[1].Rows[i]["IGM_SLNO"].ToString() + "</IGM_SLNO>" +
                       "<IGM_JOBDATE>" + ds.Tables[1].Rows[i]["IGM_JOBDATE"].ToString() + "</IGM_JOBDATE>" +
                       "<IGM_AIRLINECODE>" + ds.Tables[1].Rows[i]["IGM_AIRLINECODE"].ToString() + "</IGM_AIRLINECODE>" +
                       "<IGM_AIRLINENAME>" + ds.Tables[1].Rows[i]["IGM_AIRLINENAME"].ToString() + "</IGM_AIRLINENAME>" +
                       "<IGM_FLIGHTNO_VESSELNO>" + ds.Tables[1].Rows[i]["IGM_FLIGHTNO_VESSELNO"].ToString() + "</IGM_FLIGHTNO_VESSELNO>" +
                       "<IGM_FLIGHT_VESSELDATE>" + ds.Tables[1].Rows[i]["IGM_FLIGHT_VESSELDATE"].ToString() + "</IGM_FLIGHT_VESSELDATE>" +
                       "<IGM_NO>" + ds.Tables[1].Rows[i]["IGM_NO"].ToString() + "</IGM_NO>" +
                       "<IGM_DATE>" + ds.Tables[1].Rows[i]["IGM_DATE"].ToString() + "</IGM_DATE>" +
                       "<IGM_MAWB_MBL>" + ds.Tables[1].Rows[i]["IGM_MAWB_MBL"].ToString() + "</IGM_MAWB_MBL>" +
                       "<IGM_MAWB_MBLDATE>" + ds.Tables[1].Rows[i]["IGM_MAWB_MBLDATE"].ToString() + "</IGM_MAWB_MBLDATE>" +
                       "<IGM_HAWB_HBLNO>" + ds.Tables[1].Rows[i]["IGM_HAWB_HBLNO"].ToString() + "</IGM_HAWB_HBLNO>" +
                       "<IGM_HAWB_HBLDATE>" + ds.Tables[1].Rows[i]["IGM_HAWB_HBLDATE"].ToString() + "</IGM_HAWB_HBLDATE>" +
                       "<IGM_NOOFPACKAGE>" + ds.Tables[1].Rows[i]["IGM_NOOFPACKAGE"].ToString() + "</IGM_NOOFPACKAGE>" +
                       "<IGM_PACKAGETYPE>" + ds.Tables[1].Rows[i]["IGM_PACKAGETYPE"].ToString() + "</IGM_PACKAGETYPE>" +
                       "<IGM_GROSSWEIGHT>" + ds.Tables[1].Rows[i]["IGM_GROSSWEIGHT"].ToString() + "</IGM_GROSSWEIGHT>" +
                       "<IGM_TYPEOFWEIGHT>" + ds.Tables[1].Rows[i]["IGM_TYPEOFWEIGHT"].ToString() + "</IGM_TYPEOFWEIGHT>" +
                       "<IGM_NETWEIGHT>" + ds.Tables[1].Rows[i]["IGM_NETWEIGHT"].ToString() + "</IGM_NETWEIGHT>" +
                       "<IGM_NETWEIGHTTYPE>" + ds.Tables[1].Rows[i]["IGM_NETWEIGHTTYPE"].ToString() + "</IGM_NETWEIGHTTYPE>" +
                       "<IGM_TRANSPORTMODE>" + ds.Tables[1].Rows[i]["IGM_TRANSPORTMODE"].ToString() + "</IGM_TRANSPORTMODE>" +
                       "<IGM_MARKSNOS>" + ds.Tables[1].Rows[i]["IGM_MARKSNOS"].ToString() + "</IGM_MARKSNOS>" +
                       "<IGM_GATEWAY_IGM_NO>" + ds.Tables[1].Rows[i]["IGM_GATEWAY_IGM_NO"].ToString() + "</IGM_GATEWAY_IGM_NO>" +
                       "<IGM_GATEWAY_IGM_DATE>" + ds.Tables[1].Rows[i]["IGM_GATEWAY_IGM_DATE"].ToString() + "</IGM_GATEWAY_IGM_DATE>" +
                       "<IGM_GATEWAY_PORT_CODE>" + ds.Tables[1].Rows[i]["IGM_GATEWAY_PORT_CODE"].ToString() + "</IGM_GATEWAY_PORT_CODE>" +
                       "<IGM_LINE_NUMBER>" + ds.Tables[1].Rows[i]["IGM_LINE_NUMBER"].ToString() + "</IGM_LINE_NUMBER>" +
                       "<IGM_SHIPPING_LINE_NUMBER>" + ds.Tables[1].Rows[i]["IGM_SHIPPING_LINE_NUMBER"].ToString() + "</IGM_SHIPPING_LINE_NUMBER>" +
                       "<IGM_CHARGEABLE_WGT>" + ds.Tables[1].Rows[i]["IGM_CHARGEABLE_WGT"].ToString() + "</IGM_CHARGEABLE_WGT>" +
                       "<ROTATION_NO>" + ds.Tables[1].Rows[i]["ROTATION_NO"].ToString() + "</ROTATION_NO>" +
                       "<ROTATION_DATE>" + ds.Tables[1].Rows[i]["ROTATION_DATE"].ToString() + "</ROTATION_DATE>";

             IGM_XML += Data;
             Data = "";
         }
         return IGM_XML; 
    }
    private string CONTAINER_DETAILS(DataSet ds)
    {
        string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[2].Rows.Count; i++)
         {
             Data = "<CONTAINER_IGM_SLNO>" + ds.Tables[2].Rows[i]["CONTAINER_IGM_SLNO"].ToString() + "</CONTAINER_IGM_SLNO>" +
                       "<CONTAINER_IGM_NO>" + ds.Tables[2].Rows[i]["CONTAINER_IGM_NO"].ToString() + "</CONTAINER_IGM_NO>" +
                       "<CONTAINER_IGM_DATE>" + ds.Tables[2].Rows[i]["CONTAINER_IGM_DATE"].ToString() + "</CONTAINER_IGM_DATE>" +
                       "<CONTAINER_NO>" + ds.Tables[2].Rows[i]["CONTAINER_NO"].ToString() + "</CONTAINER_NO>" +
                       "<SEAL_NO>" + ds.Tables[2].Rows[i]["SEAL_NO"].ToString() + "</SEAL_NO>" +
                       "<TYPE>" + ds.Tables[2].Rows[i]["TYPE"].ToString() + "</TYPE>";
             Con += Data;
             Data = "";
         }
         return Con; 
    }
    private string Inv_Data(DataSet ds)
     {
         string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[3].Rows.Count; i++)
         {
             Data = "<INVOICE_SLNO>" + ds.Tables[3].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                   "<INVOICE_SLNO>" + ds.Tables[3].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_NO>" +
                   "<INVOICE_DATE>" + ds.Tables[3].Rows[i]["INVOICE_DATE"].ToString() + "</INVOICE_DATE>" +
                   "<TERMS>" + ds.Tables[3].Rows[i]["TERMS"].ToString() + "</TERMS>" +
                   "<INVOICE_CURRENCY>" + ds.Tables[3].Rows[i]["INVOICE_CURRENCY"].ToString() + "</INVOICE_CURRENCY>" +
                   "<INVOICE_EXRATE>" + ds.Tables[3].Rows[i]["INVOICE_EXRATE"].ToString() + "</INVOICE_EXRATE>" +
                   "<INVOICE_VALUE>" + ds.Tables[3].Rows[i]["INVOICE_VALUE"].ToString() + "</INVOICE_VALUE>" +
                   "<SUPPLIER_NAME>" + ds.Tables[3].Rows[i]["SUPPLIER_NAME"].ToString() + "</SUPPLIER_NAME>" +
                   "<SUPPLIER_ADDRESS>" + ds.Tables[3].Rows[i]["SUPPLIER_ADDRESS"].ToString() + "</SUPPLIER_ADDRESS>" +
                   "<SUPPLIER_ADDRESS1>" + ds.Tables[3].Rows[i]["SUPPLIER_ADDRESS1"].ToString() + "</SUPPLIER_ADDRESS1>" +

                   "<SUPPLIER_ADDRESS2>" + ds.Tables[3].Rows[i]["SUPPLIER_ADDRESS2"].ToString() + "</SUPPLIER_ADDRESS2>" +
                   "<SUPPLIER_COUNTRY_NAME>" + ds.Tables[3].Rows[i]["SUPPLIER_COUNTRY_NAME"].ToString() + "</SUPPLIER_COUNTRY_NAME>" +
                   "<SUPPLIER_COUNTRY_CODE>" + ds.Tables[3].Rows[i]["SUPPLIER_COUNTRY_CODE"].ToString() + "</SUPPLIER_COUNTRY_CODE>" +
                   "<SUPPLIER_COUNTRY_PINCODE>" + ds.Tables[3].Rows[i]["SUPPLIER_COUNTRY_PINCODE"].ToString() + "</SUPPLIER_COUNTRY_PINCODE>" +
                   "<SELLER_NAME>" + ds.Tables[3].Rows[i]["SELLER_NAME"].ToString() + "</SELLER_NAME>" +
                   "<SELLER_ADDRESS>" + ds.Tables[3].Rows[i]["SELLER_ADDRESS"].ToString() + "</SELLER_ADDRESS>" +
                   "<SELLER_ADDRESS1>" + ds.Tables[3].Rows[i]["SELLER_ADDRESS1"].ToString() + "</SELLER_ADDRESS1>" +
                   "<SELLER_ADDRESS2>" + ds.Tables[3].Rows[i]["SELLER_ADDRESS2"].ToString() + "</SELLER_ADDRESS2>" +
                   "<SELLER_COUNTRY_NAME>" + ds.Tables[3].Rows[i]["SELLER_COUNTRY_NAME"].ToString() + "</SELLER_COUNTRY_NAME>" +
                   "<SELLER_COUNTRY_CODE>" + ds.Tables[3].Rows[i]["SELLER_COUNTRY_CODE"].ToString() + "</SELLER_COUNTRY_CODE>" +
                   "<SELLERCOUNTRY_PINCODE>" + ds.Tables[3].Rows[i]["SELLERCOUNTRY_PINCODE"].ToString() + "</SELLERCOUNTRY_PINCODE>";
             Con += Data;
             Data = "";
         }
         return Con; 
     }
     private string Item_Data(DataSet ds)
     {
         string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[4].Rows.Count; i++)
         {
             Data = "<INVOICE_SLNO>" + ds.Tables[4].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                       "<INVOICE_NO>" + ds.Tables[4].Rows[i]["INVOICE_NO"].ToString() + "</INVOICE_NO>" +
                       "<ITEM_SLNO>" + ds.Tables[4].Rows[i]["ITEM_SLNO"].ToString() + "</ITEM_SLNO>" +
                       "<ITEM_DESCRIPTION>" + ds.Tables[4].Rows[i]["ITEM_DESCRIPTION"].ToString() + "</ITEM_DESCRIPTION>" +
                       "<ITEM_QTY>" + ds.Tables[4].Rows[i]["ITEM_QTY"].ToString() + "</ITEM_QTY>" +
                       "<ITEM_QTY_CODE>" + ds.Tables[4].Rows[i]["ITEM_QTY_CODE"].ToString() + "</ITEM_QTY_CODE>" +
                       "<ITEM_UNIT_PRICE>" + ds.Tables[4].Rows[i]["ITEM_UNIT_PRICE"].ToString() + "</ITEM_UNIT_PRICE>" +
                       "<ITEM_UNIT_CODE>" + ds.Tables[4].Rows[i]["ITEM_UNIT_CODE"].ToString() + "</ITEM_UNIT_CODE>" +
                       "<ITEM_TOTAL_AMOUNT>" + ds.Tables[4].Rows[i]["ITEM_TOTAL_AMOUNT"].ToString() + "</ITEM_TOTAL_AMOUNT>" +
                       "<ITEM_AMOUNT_CODE>" + ds.Tables[4].Rows[i]["ITEM_AMOUNT_CODE"].ToString() + "</ITEM_AMOUNT_CODE>" +
                       "<CTH_NO>" + ds.Tables[4].Rows[i]["CTH_NO"].ToString() + "</CTH_NO>" +
                       "<SCHEME_CODE>" + ds.Tables[4].Rows[i]["SCHEME_CODE"].ToString() + "</SCHEME_CODE>" +
                       "<SCHEME_NOTN>" + ds.Tables[4].Rows[i]["SCHEME_NOTN"].ToString() + "</SCHEME_NOTN>" +
                       "<SCHEME_NOTN_SLNO>" + ds.Tables[4].Rows[i]["SCHEME_NOTN_SLNO"].ToString() + "</SCHEME_NOTN_SLNO>" +
                       "<CTH_QTY1>" + ds.Tables[4].Rows[i]["CTH_QTY1"].ToString() + "</CTH_QTY1>" +
                       "<CTH_QTY1_CODE>" + ds.Tables[4].Rows[i]["CTH_QTY1_CODE"].ToString() + "</CTH_QTY1_CODE>" +
                       "<CTH_QTY2>" + ds.Tables[4].Rows[i]["CTH_QTY2"].ToString() + "</CTH_QTY2>" +
                       "<CTH_QTY2_CODE>" + ds.Tables[4].Rows[i]["CTH_QTY2_CODE"].ToString() + "</CTH_QTY2_CODE>" +
                       "<GENEARL_DESCRIPTION>" + ds.Tables[4].Rows[i]["GENEARL_DESCRIPTION"].ToString() + "</GENEARL_DESCRIPTION>" +
                       "<MANUFACTURER>" + ds.Tables[4].Rows[i]["MANUFACTURER"].ToString() + "</MANUFACTURER>" +
                       "<BRAND>" + ds.Tables[4].Rows[i]["BRAND"].ToString() + "</BRAND>" +
                       "<MODEL>" + ds.Tables[4].Rows[i]["MODEL"].ToString() + "</MODEL>" +
                       "<END_USE_OF_ITEM>" + ds.Tables[4].Rows[i]["END_USE_OF_ITEM"].ToString() + "</END_USE_OF_ITEM>" +
                       "<COUNTRY_OF_ORIGIN>" + ds.Tables[4].Rows[i]["COUNTRY_OF_ORIGIN"].ToString() + "</COUNTRY_OF_ORIGIN>" +
                       "<ACCESSORIES>" + ds.Tables[4].Rows[i]["ACCESSORIES"].ToString() + "</ACCESSORIES>" +
                       "<PREVIOUS_BE_NO>" + ds.Tables[4].Rows[i]["PREVIOUS_BE_NO"].ToString() + "</PREVIOUS_BE_NO>" +
                       "<PREVIOUS_BE_DATE>" + ds.Tables[4].Rows[i]["PREVIOUS_BE_DATE"].ToString() + "</PREVIOUS_BE_DATE>" +
                       "<UNIT_PRICE>" + ds.Tables[4].Rows[i]["UNIT_PRICE"].ToString() + "</UNIT_PRICE>" +
                       "<UNIT_CODE>" + ds.Tables[4].Rows[i]["UNIT_CODE"].ToString() + "</UNIT_CODE>" +
                       "<CUSTOMS_HOUSE>" + ds.Tables[4].Rows[i]["CUSTOMS_HOUSE"].ToString() + "</CUSTOMS_HOUSE>" +
                       "<PRODUCT_RITC>" + ds.Tables[4].Rows[i]["PRODUCT_RITC"].ToString() + "</PRODUCT_RITC>" +
                       "<PRODUCT_CTH>" + ds.Tables[4].Rows[i]["PRODUCT_CTH"].ToString() + "</PRODUCT_CTH>" +
                       "<PRODUCT_BCD_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_BCD_NOTN"].ToString() + "</PRODUCT_BCD_NOTN>" +
                       "<PRODUCT_BCD_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_BCD_SLNO"].ToString() + "</PRODUCT_BCD_SLNO>" +
                       "<PRODUCT_BCD_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_BCD_RATE"].ToString() + "</PRODUCT_BCD_RATE>" +
                       "<PRODUCT_BCD_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_BCD_SPL"].ToString() + "</PRODUCT_BCD_SPL>" +
                       "<PRODUCT_BCD_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_BCD_UNIT"].ToString() + "</PRODUCT_BCD_UNIT>" +
                       "<PRODUCT_BCD_SPL_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_BCD_SPL_TYPE"].ToString() + "</PRODUCT_BCD_SPL_TYPE>" +
                       "<PRODUCT_ADDL_DUTY_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_DUTY_NOTN"].ToString() + "</PRODUCT_ADDL_DUTY_NOTN>" +
                       "<PRODUCT_ADDL_DUTY_NOTN_SL>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString() + "</PRODUCT_ADDL_DUTY_NOTN_SL>" +
                       "<PRODUCT_ADDL_DUTY_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_DUTY_RATE"].ToString() + "</PRODUCT_ADDL_DUTY_RATE>" +
                       "<PRODUCT_EDU_CESS_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_EDU_CESS_NOTN"].ToString() + "</PRODUCT_EDU_CESS_NOTN>" +
                       "<PRODUCT_EDU_CESS_NOTN_SL>" + ds.Tables[4].Rows[i]["PRODUCT_EDU_CESS_NOTN_SL"].ToString() + "</PRODUCT_EDU_CESS_NOTN_SL>" +
                       "<PRODUCT_EDU_CESS_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_EDU_CESS_RATE"].ToString() + "</PRODUCT_EDU_CESS_RATE>" +
                       "<PRODUCT_SEC_EDU_CESS_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString() + "</PRODUCT_SEC_EDU_CESS_NOTN>" +
                       "<PRODUCT_SEC_EDU_CESS_NOTN_SL>" + ds.Tables[4].Rows[i]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString() + "</PRODUCT_SEC_EDU_CESS_NOTN_SL>" +
                       "<PRODUCT_SEC_EDU_CESS_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_SEC_EDU_CESS_RATE"].ToString() + "</PRODUCT_SEC_EDU_CESS_RATE>" +
                       "<PRODUCT_NCD_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_NCD_NOTN"].ToString() + "</PRODUCT_NCD_NOTN>" +
                       "<PRODUCT_NCD_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_NCD_SLNO"].ToString() + "</PRODUCT_NCD_SLNO>" +
                       "<PRODUCT_NCD_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_NCD_RATE"].ToString() + "</PRODUCT_NCD_RATE>" +
                       "<PRODUCT_NCD_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_NCD_SPL"].ToString() + "</PRODUCT_NCD_SPL>" +
                       "<PRODUCT_NCD_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_NCD_UNIT"].ToString() + "</PRODUCT_NCD_UNIT>" +
                       "<PRODUCT_NCD_SPL_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_NCD_SPL_TYPE"].ToString() + "</PRODUCT_NCD_SPL_TYPE>" +
                       "<PRODUCT_AGGREGATE_DUTY_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString() + "</PRODUCT_AGGREGATE_DUTY_NOTN>" +
                       "<PRODUCT_AGGREGATE_DUTY_NOTN_SL>" + ds.Tables[4].Rows[i]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString() + "</PRODUCT_AGGREGATE_DUTY_NOTN_SL>" +
                       "<PRODUCT_AGGREGATE_DUTY_NOTN_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString() + "</PRODUCT_AGGREGATE_DUTY_NOTN_RATE>" +
                       "<PRODUCT_SAFEGUARD_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_SAFEGUARD_NOTN"].ToString() + "</PRODUCT_SAFEGUARD_NOTN>" +
                       "<PRODUCT_SAFEGUARD_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_SAFEGUARD_SLNO"].ToString() + "</PRODUCT_SAFEGUARD_SLNO>" +
                       "<PRODUCT_SAFEGUARD_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_SAFEGUARD_RATE"].ToString() + "</PRODUCT_SAFEGUARD_RATE>" +
                       "<PRODUCT_SAFEGUARD_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_SAFEGUARD_SPL"].ToString() + "</PRODUCT_SAFEGUARD_SPL>" +
                       "<PRODUCT_SAFEGUARD_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_SAFEGUARD_UNIT"].ToString() + "</PRODUCT_SAFEGUARD_UNIT>" +
                       "<PRODUCT_SAFEGUARD_SPL_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString() + "</PRODUCT_SAFEGUARD_SPL_TYPE>" +
                       "<PRODUCT_SAPTA_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_SAPTA_NOTN"].ToString() + "</PRODUCT_SAPTA_NOTN>" +
                       "<PRODUCT_SAPTA_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_SAPTA_SLNO"].ToString() + "</PRODUCT_SAPTA_SLNO>" +
                       "<PRODUCT_SAPTA_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_SAPTA_RATE"].ToString() + "</PRODUCT_SAPTA_RATE>" +
                       "<PRODUCT_TARIFF_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_TARIFF_NOTN"].ToString() + "</PRODUCT_TARIFF_NOTN>" +
                       "<PRODUCT_TARIFF_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_TARIFF_SLNO"].ToString() + "</PRODUCT_TARIFF_SLNO>" +
                       "<PRODUCT_TARIFF_QTY>" + ds.Tables[4].Rows[i]["PRODUCT_TARIFF_QTY"].ToString() + "</PRODUCT_TARIFF_QTY>" +
                       "<PRODUCT_TARIFF_AMOUNT>" + ds.Tables[4].Rows[i]["PRODUCT_TARIFF_AMOUNT"].ToString() + "</PRODUCT_TARIFF_AMOUNT>" +
                       "<PRODUCT_TARIFF_AMOUNT_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString() + "</PRODUCT_TARIFF_AMOUNT_UNIT>" +
                       "<PRODUCT_CETH>" + ds.Tables[4].Rows[i]["PRODUCT_CETH"].ToString() + "</PRODUCT_CETH>" +
                       "<PRODUCT_MRP_YN>" + ds.Tables[4].Rows[i]["PRODUCT_MRP_YN"].ToString() + "</PRODUCT_MRP_YN>" +
                       "<PRODUCT_MRP_SL_NO>" + ds.Tables[4].Rows[i]["PRODUCT_MRP_SL_NO"].ToString() + "</PRODUCT_MRP_SL_NO>" +
                       "<PRODUCT_MRP_AMOUNT>" + ds.Tables[4].Rows[i]["PRODUCT_MRP_AMOUNT"].ToString() + "</PRODUCT_MRP_AMOUNT>" +
                       "<PRODUCT_MRP_ABT_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_MRP_ABT_RATE"].ToString() + "</PRODUCT_MRP_ABT_RATE>" +
                       "<PRODUCT_CVD_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_CVD_NOTN"].ToString() + "</PRODUCT_CVD_NOTN>" +
                       "<PRODUCT_CVD_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_CVD_SLNO"].ToString() + "</PRODUCT_CVD_SLNO>" +
                       "<PRODUCT_CVD_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_CVD_RATE"].ToString() + "</PRODUCT_CVD_RATE>" +
                       "<PRODUCT_CVD_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_CVD_SPL"].ToString() + "</PRODUCT_CVD_SPL>" +
                       "<PRODUCT_CVD_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_CVD_UNIT"].ToString() + "</PRODUCT_CVD_UNIT>" +
                       "<PRODUCT_CVD_SPL_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_CVD_SPL_TYPE"].ToString() + "</PRODUCT_CVD_SPL_TYPE>" +
                       "<PRODUCT_CVD_EDU_CESS_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_CVD_EDU_CESS_RATE"].ToString() + "</PRODUCT_CVD_EDU_CESS_RATE>" +
                       "<PRODUCT_CVD_SEC_EDU_CESS_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString() + "</PRODUCT_CVD_SEC_EDU_CESS_RATE>" +
                       "<PRODUCT_ADDL5_SIA_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL5_SIA_NOTN"].ToString() + "</PRODUCT_ADDL5_SIA_NOTN>" +
                       "<PRODUCT_ADDL5_SIA_NOTN_SL>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString() + "</PRODUCT_ADDL5_SIA_NOTN_SL>" +
                       "<PRODUCT_ADDL5_SIA_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL5_SIA_RATE"].ToString() + "</PRODUCT_ADDL5_SIA_RATE>" +
                       "<PRODUCT_ADDL_GSI_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_GSI_NOTN"].ToString() + "</PRODUCT_ADDL_GSI_NOTN>" +
                       "<PRODUCT_ADDL_GSI_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_GSI_SLNO"].ToString() + "</PRODUCT_ADDL_GSI_SLNO>" +
                       "<PRODUCT_ADDL_GSI_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_GSI_RATE"].ToString() + "</PRODUCT_ADDL_GSI_RATE>" +
                       "<PRODUCT_ADDL_GSI_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_GSI_SPL"].ToString() + "</PRODUCT_ADDL_GSI_SPL>" +
                       "<PRODUCT_ADDL_GSI_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_GSI_UNIT"].ToString() + "</PRODUCT_ADDL_GSI_UNIT>" +
                       "<PRODUCT_ADDL_GSI_SPL_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString() + "</PRODUCT_ADDL_GSI_SPL_TYPE>" +
                       "<PRODUCT_ADDL_SHEII_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_SHEII_NOTN"].ToString() + "</PRODUCT_ADDL_SHEII_NOTN>" +
                       "<PRODUCT_ADDL_SHEII_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_SHEII_SLNO"].ToString() + "</PRODUCT_ADDL_SHEII_SLNO>" +
                       "<PRODUCT_ADDL_SHEII_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_SHEII_RATE"].ToString() + "</PRODUCT_ADDL_SHEII_RATE>" +
                       "<PRODUCT_ADDL_SHEII_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_SHEII_SPL"].ToString() + "</PRODUCT_ADDL_SHEII_SPL>" +
                       "<PRODUCT_ADDL_SHEII_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_SHEII_UNIT"].ToString() + "</PRODUCT_ADDL_SHEII_UNIT>" +
                       "<PRODUCT_ADDL_SHEII_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_SHEII_TYPE"].ToString() + "</PRODUCT_ADDL_SHEII_TYPE>" +
                       "<PRODUCT_ADDL_TTA_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_TTA_NOTN"].ToString() + "</PRODUCT_ADDL_TTA_NOTN>" +
                       "<PRODUCT_ADDL_TTA_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_TTA_SLNO"].ToString() + "</PRODUCT_ADDL_TTA_SLNO>" +
                       "<PRODUCT_ADDL_TTA_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_TTA_RATE"].ToString() + "</PRODUCT_ADDL_TTA_RATE>" +
                       "<PRODUCT_ADDL_TTA_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_TTA_SPL"].ToString() + "</PRODUCT_ADDL_TTA_SPL>" +
                       "<PRODUCT_ADDL_TTA_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_TTA_UNIT"].ToString() + "</PRODUCT_ADDL_TTA_UNIT>" +
                       "<PRODUCT_ADDL_TTA_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_TTA_TYPE"].ToString() + "</PRODUCT_ADDL_TTA_TYPE>" +
                       "<PRODUCT_ADDL_HEALTH_CESS_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString() + "</PRODUCT_ADDL_HEALTH_CESS_NOTN>" +
                       "<PRODUCT_ADDL_HEALTH_CESS_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString() + "</PRODUCT_ADDL_HEALTH_CESS_RATE>" +
                       "<PRODUCT_ADDL_HEALTH_CESS_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString() + "</PRODUCT_ADDL_HEALTH_CESS_SPL>" +
                       "<PRODUCT_ADDL_HEALTH_CESS_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString() + "</PRODUCT_ADDL_HEALTH_CESS_UNIT>" +
                       "<PRODUCT_ADDL_HEALTH_CESS_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString() + "</PRODUCT_ADDL_HEALTH_CESS_TYPE>" +
                       "<PRODUCT_CESS_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_CESS_NOTN"].ToString() + "</PRODUCT_CESS_NOTN>" +
                       "<PRODUCT_CESS_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_CESS_SLNO"].ToString() + "</PRODUCT_CESS_SLNO>" +
                       "<PRODUCT_CESS_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_CESS_RATE"].ToString() + "</PRODUCT_CESS_RATE>" +
                       "<PRODUCT_CESS_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_CESS_SPL"].ToString() + "</PRODUCT_CESS_SPL>" +
                       "<PRODUCT_CESS_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_CESS_UNIT"].ToString() + "</PRODUCT_CESS_UNIT>" +
                       "<PRODUCT_CESS_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_CESS_TYPE"].ToString() + "</PRODUCT_CESS_TYPE>" +
                       "<ANTI_DUMPING_NOTN>" + ds.Tables[4].Rows[i]["ANTI_DUMPING_NOTN"].ToString() + "</ANTI_DUMPING_NOTN>" +
                       "<ANTI_DUMPING_NOTN_SLNO>" + ds.Tables[4].Rows[i]["ANTI_DUMPING_NOTN_SLNO"].ToString() + "</ANTI_DUMPING_NOTN_SLNO>" +
                       "<CTH_SLNO>" + ds.Tables[4].Rows[i]["CTH_SLNO"].ToString() + "</CTH_SLNO>" +
                       "<CTH_SUPPLIER_SLNO>" + ds.Tables[4].Rows[i]["CTH_SUPPLIER_SLNO"].ToString() + "</CTH_SUPPLIER_SLNO>" +
                       "<CTH_QTY>" + ds.Tables[4].Rows[i]["CTH_QTY"].ToString() + "</CTH_QTY>" +
                       "<RSP_DUTY_STATUS>" + ds.Tables[4].Rows[i]["RSP_DUTY_STATUS"].ToString() + "</RSP_DUTY_STATUS>" +
                       "<RSP_SL_NO>" + ds.Tables[4].Rows[i]["RSP_SL_NO"].ToString() + "</RSP_SL_NO>" +
                       "<RSP_DESC>" + ds.Tables[4].Rows[i]["RSP_DESC"].ToString() + "</RSP_DESC>" +
                       "<RSP_QTY>" + ds.Tables[4].Rows[i]["RSP_QTY"].ToString() + "</RSP_QTY>" +
                       "<RSP_AMOUNT>" + ds.Tables[4].Rows[i]["RSP_AMOUNT"].ToString() + "</RSP_AMOUNT>" +
                       "<RSP_NOTN_NO>" + ds.Tables[4].Rows[i]["RSP_NOTN_NO"].ToString() + "</RSP_NOTN_NO>" +
                       "<RSP_NOTN_SL_NO>" + ds.Tables[4].Rows[i]["RSP_NOTN_SL_NO"].ToString() + "</RSP_NOTN_SL_NO>" +
                       "<RSP_ABT_RATE>" + ds.Tables[4].Rows[i]["RSP_ABT_RATE"].ToString() + "</RSP_ABT_RATE>" +
                       "<WAREHOUSE_JOBNO>" + ds.Tables[4].Rows[i]["WAREHOUSE_JOBNO"].ToString() + "</WAREHOUSE_JOBNO>" +
                       "<WAREHOUSE_INVOICE_SLNO>" + ds.Tables[4].Rows[i]["WAREHOUSE_INVOICE_SLNO"].ToString() + "</WAREHOUSE_INVOICE_SLNO>" +
                       "<WAREHOUSE_ITEM_SLNO>" + ds.Tables[4].Rows[i]["WAREHOUSE_ITEM_SLNO"].ToString() + "</WAREHOUSE_ITEM_SLNO>" +
                       "<ASSESSABLE_VALUE>" + ds.Tables[4].Rows[i]["ASSESSABLE_VALUE"].ToString() + "</ASSESSABLE_VALUE>" +
                       "<DUTY_VALUE>" + ds.Tables[4].Rows[i]["DUTY_VALUE"].ToString() + "</DUTY_VALUE>" +
                       "<CIF_VALUE>" + ds.Tables[4].Rows[i]["CIF_VALUE"].ToString() + "</CIF_VALUE>" +
                       "<CVD_VALUE>" + ds.Tables[4].Rows[i]["CVD_VALUE"].ToString() + "</CVD_VALUE>" +
                       "<BASIC_VALUE>" + ds.Tables[4].Rows[i]["BASIC_VALUE"].ToString() + "</BASIC_VALUE>" +
                       "<CEC_VALUE>" + ds.Tables[4].Rows[i]["CEC_VALUE"].ToString() + "</CEC_VALUE>" +
                       "<CHEC_VALUE>" + ds.Tables[4].Rows[i]["CHEC_VALUE"].ToString() + "</CHEC_VALUE>" +
                       "<ADD_DUTY_VALUE>" + ds.Tables[4].Rows[i]["ADD_DUTY_VALUE"].ToString() + "</ADD_DUTY_VALUE>" +
                       "<CETH_CVD_EDU_CESS_SL>" + ds.Tables[4].Rows[i]["CETH_CVD_EDU_CESS_SL"].ToString() + "</CETH_CVD_EDU_CESS_SL>" +
                       "<CETH_CVD_EDU_CESS_RATE>" + ds.Tables[4].Rows[i]["CETH_CVD_EDU_CESS_RATE"].ToString() + "</CETH_CVD_EDU_CESS_RATE>" +
                       "<CETH_CVD_SEC_EDU_CESS_SL>" + ds.Tables[4].Rows[i]["CETH_CVD_SEC_EDU_CESS_SL"].ToString() + "</CETH_CVD_SEC_EDU_CESS_SL>" +
                       "<CETH_CVD_SEC_EDU_CESS_RATE>" + ds.Tables[4].Rows[i]["CETH_CVD_SEC_EDU_CESS_RATE"].ToString() + "</CETH_CVD_SEC_EDU_CESS_RATE>" +
                       "<PRODUCT_OTHER_DUTY_NOTN>" + ds.Tables[4].Rows[i]["PRODUCT_OTHER_DUTY_NOTN"].ToString() + "</PRODUCT_OTHER_DUTY_NOTN>" +
                       "<PRODUCT_OTHER_DUTY_SLNO>" + ds.Tables[4].Rows[i]["PRODUCT_OTHER_DUTY_SLNO"].ToString() + "</PRODUCT_OTHER_DUTY_SLNO>" +
                       "<PRODUCT_OTHER_DUTY_RATE>" + ds.Tables[4].Rows[i]["PRODUCT_OTHER_DUTY_RATE"].ToString() + "</PRODUCT_OTHER_DUTY_RATE>" +
                       "<PRODUCT_OTHER_DUTY_SPL>" + ds.Tables[4].Rows[i]["PRODUCT_OTHER_DUTY_SPL"].ToString() + "</PRODUCT_OTHER_DUTY_SPL>" +
                       "<PRODUCT_OTHER_DUTY_UNIT>" + ds.Tables[4].Rows[i]["PRODUCT_OTHER_DUTY_UNIT"].ToString() + "</PRODUCT_OTHER_DUTY_UNIT>" +
                       "<PRODUCT_OTHER_DUTY_TYPE>" + ds.Tables[4].Rows[i]["PRODUCT_OTHER_DUTY_TYPE"].ToString() + "</PRODUCT_OTHER_DUTY_TYPE>" +
                       "<INDIVITUAL_FREIGHT_AMOUNT>" + ds.Tables[4].Rows[i]["INDIVITUAL_FREIGHT_AMOUNT"].ToString() + "</INDIVITUAL_FREIGHT_AMOUNT>" +
                       "<INDIVITUAL_INSURANCE_AMOUNT>" + ds.Tables[4].Rows[i]["INDIVITUAL_INSURANCE_AMOUNT"].ToString() + "</INDIVITUAL_INSURANCE_AMOUNT>" +
                       "<INDIVITUAL_MISC_AMOUNT>" + ds.Tables[4].Rows[i]["INDIVITUAL_MISC_AMOUNT"].ToString() + "</INDIVITUAL_MISC_AMOUNT>" +
                       "<SVB_RELATION>" + ds.Tables[4].Rows[i]["SVB_RELATION"].ToString() + "</SVB_RELATION>" +
                       "<SVB_REF_NO>" + ds.Tables[4].Rows[i]["SVB_REF_NO"].ToString() + "</SVB_REF_NO>" +
                       "<SVB_REF_DATE>" + ds.Tables[4].Rows[i]["SVB_REF_DATE"].ToString() + "</SVB_REF_DATE>" +
                       "<SVB_CUSTOM_HOUSE>" + ds.Tables[4].Rows[i]["SVB_CUSTOM_HOUSE"].ToString() + "</SVB_CUSTOM_HOUSE>" +
                       "<SVB_LOADING_ON>" + ds.Tables[4].Rows[i]["SVB_LOADING_ON"].ToString() + "</SVB_LOADING_ON>" +
                       "<SVB_ASSESABLE_RATE>" + ds.Tables[4].Rows[i]["SVB_ASSESABLE_RATE"].ToString() + "</SVB_ASSESABLE_RATE>" +
                       "<SVB_DUTY_RATE>" + ds.Tables[4].Rows[i]["SVB_DUTY_RATE"].ToString() + "</SVB_DUTY_RATE>" +
                       "<SVB_ASSESABLE_STATUS>" + ds.Tables[4].Rows[i]["SVB_ASSESABLE_STATUS"].ToString() + "</SVB_ASSESABLE_STATUS>" +
                       "<SVB_DUTY_STATUS>" + ds.Tables[4].Rows[i]["SVB_DUTY_STATUS"].ToString() + "</SVB_DUTY_STATUS>" +
                       "<INDIVITUAL_EDU_CESS_AMT>" + ds.Tables[4].Rows[i]["INDIVITUAL_EDU_CESS_AMT"].ToString() + "</INDIVITUAL_EDU_CESS_AMT>" +
                       "<INDIVITUAL_SEC_HIGHER_CESS_AMT>" + ds.Tables[4].Rows[i]["INDIVITUAL_SEC_HIGHER_CESS_AMT"].ToString() + "</INDIVITUAL_SEC_HIGHER_CESS_AMT>" +
                       "<INDIVITUAL_LANDING_CHARGE>" + ds.Tables[4].Rows[i]["INDIVITUAL_LANDING_CHARGE"].ToString() + "</INDIVITUAL_LANDING_CHARGE>" +
                       "<CHECKLIST_BCD_RATE>" + ds.Tables[4].Rows[i]["CHECKLIST_BCD_RATE"].ToString() + "</CHECKLIST_BCD_RATE>" +
                       "<CHECKLIST_CVD_RATE>" + ds.Tables[4].Rows[i]["CHECKLIST_CVD_RATE"].ToString() + "</CHECKLIST_CVD_RATE>" +
                       "<CHECKLIST_ADDL_DUTY_RATE>" + ds.Tables[4].Rows[i]["CHECKLIST_ADDL_DUTY_RATE"].ToString() + "</CHECKLIST_ADDL_DUTY_RATE>" +
                       "<INDEV_RACK_TYPE>" + ds.Tables[4].Rows[i]["INDEV_RACK_TYPE"].ToString() + "</INDEV_RACK_TYPE>" +
                       "<MERIT_DUTY_VALUE>" + ds.Tables[4].Rows[i]["MERIT_DUTY_VALUE"].ToString() + "</MERIT_DUTY_VALUE>" +
                       "<RSP_APPLICABLE>" + ds.Tables[4].Rows[i]["RSP_APPLICABLE"].ToString() + "</RSP_APPLICABLE>" +
                       "<CENTRAL_EXCISE_FLAG>" + ds.Tables[4].Rows[i]["CENTRAL_EXCISE_FLAG"].ToString() + "</CENTRAL_EXCISE_FLAG>" +
                       "<MANUFACTURER_PRODUCER>" + ds.Tables[4].Rows[i]["MANUFACTURER_PRODUCER"].ToString() + "</MANUFACTURER_PRODUCER>" +
                       "<M_P_GROWER_CODE>" + ds.Tables[4].Rows[i]["M_P_GROWER_CODE"].ToString() + "</M_P_GROWER_CODE>" +
                       "<M_P_GROWER_ADD1>" + ds.Tables[4].Rows[i]["M_P_GROWER_ADD1"].ToString() + "</M_P_GROWER_ADD1>" +
                       "<M_P_GROWER_ADD2>" + ds.Tables[4].Rows[i]["M_P_GROWER_ADD2"].ToString() + "</M_P_GROWER_ADD2>" +
                       "<M_P_GROWER_CITY>" + ds.Tables[4].Rows[i]["M_P_GROWER_CITY"].ToString() + "</M_P_GROWER_CITY>" +
                       "<M_P_GROWER_COUNTRY_SUBDIV>" + ds.Tables[4].Rows[i]["M_P_GROWER_COUNTRY_SUBDIV"].ToString() + "</M_P_GROWER_COUNTRY_SUBDIV>" +
                       "<M_P_GROWER_PIN>" + ds.Tables[4].Rows[i]["M_P_GROWER_PIN"].ToString() + "</M_P_GROWER_PIN>" +
                       "<M_P_GROWER_COUNTRY>" + ds.Tables[4].Rows[i]["M_P_GROWER_COUNTRY"].ToString() + "</M_P_GROWER_COUNTRY>" +
                       "<SOURCE_COUNTRY>" + ds.Tables[4].Rows[i]["SOURCE_COUNTRY"].ToString() + "</SOURCE_COUNTRY>" +
                       "<TRANSIT_COUNTRY>" + ds.Tables[4].Rows[i]["TRANSIT_COUNTRY"].ToString() + "</TRANSIT_COUNTRY>" +
                       "<ACCESSORY_STATUS>" + ds.Tables[4].Rows[i]["ACCESSORY_STATUS"].ToString() + "</ACCESSORY_STATUS>" +
                       "<INFRA_CESS_NOTN>" + ds.Tables[4].Rows[i]["INFRA_CESS_NOTN"].ToString() + "</INFRA_CESS_NOTN>" +
                       "<INFRA_CESS_NOTN_SL>" + ds.Tables[4].Rows[i]["INFRA_CESS_NOTN_SL"].ToString() + "</INFRA_CESS_NOTN_SL>" +
                       "<INFRA_CESS_NOTN_RATE>" + ds.Tables[4].Rows[i]["INFRA_CESS_NOTN_RATE"].ToString() + "</INFRA_CESS_NOTN_RATE>" +
                       "<MERIT_BASIC_VALUE>" + ds.Tables[4].Rows[i]["MERIT_BASIC_VALUE"].ToString() + "</MERIT_BASIC_VALUE>" +
                       "<MERIT_CVD_VALUE>" + ds.Tables[4].Rows[i]["MERIT_CVD_VALUE"].ToString() + "</MERIT_CVD_VALUE>" +
                       "<MERIT_CEC_VALUE>" + ds.Tables[4].Rows[i]["MERIT_CEC_VALUE"].ToString() + "</MERIT_CEC_VALUE>" +
                       "<MERIT_CHEC_VALUE>" + ds.Tables[4].Rows[i]["MERIT_CHEC_VALUE"].ToString() + "</MERIT_CHEC_VALUE>" +
                       "<MERIT_ADD_DUTY_VALUE>" + ds.Tables[4].Rows[i]["MERIT_ADD_DUTY_VALUE"].ToString() + "</MERIT_ADD_DUTY_VALUE>" +
                       "<MERIT_NOTN_BASIC_VALUE>" + ds.Tables[4].Rows[i]["MERIT_NOTN_BASIC_VALUE"].ToString() + "</MERIT_NOTN_BASIC_VALUE>" +
                       "<MERIT_NOTN_CVD_VALUE>" + ds.Tables[4].Rows[i]["MERIT_NOTN_CVD_VALUE"].ToString() + "</MERIT_NOTN_CVD_VALUE>" +
                       "<MERIT_NOTN_CEC_VALUE>" + ds.Tables[4].Rows[i]["MERIT_NOTN_CEC_VALUE"].ToString() + "</MERIT_NOTN_CEC_VALUE>" +
                       "<MERIT_NOTN_CHEC_VALUE>" + ds.Tables[4].Rows[i]["MERIT_NOTN_CHEC_VALUE"].ToString() + "</MERIT_NOTN_CHEC_VALUE>" +
                       "<MERIT_NOTN_ADD_DUTY_VALUE>" + ds.Tables[4].Rows[i]["MERIT_NOTN_ADD_DUTY_VALUE"].ToString() + "</MERIT_NOTN_ADD_DUTY_VALUE>" +
                       "<MERIT_NOTN_CESS_VALUE>" + ds.Tables[4].Rows[i]["MERIT_NOTN_CESS_VALUE"].ToString() + "</MERIT_NOTN_CESS_VALUE>" +
                       "<MERIT_NOTN_NCD_VALUE>" + ds.Tables[4].Rows[i]["MERIT_NOTN_NCD_VALUE"].ToString() + "</MERIT_NOTN_NCD_VALUE>" +
                       "<INDIVITUAL_HSS_AMOUNT>" + ds.Tables[4].Rows[i]["INDIVITUAL_HSS_AMOUNT"].ToString() + "</INDIVITUAL_HSS_AMOUNT>" +
                       "<IGST_LEVY_NOTN>" + ds.Tables[4].Rows[i]["IGST_LEVY_NOTN"].ToString() + "</IGST_LEVY_NOTN>" +
                       "<IGST_LEVY_EXCEPTION_NOTN>" + ds.Tables[4].Rows[i]["IGST_LEVY_EXCEPTION_NOTN"].ToString() + "</IGST_LEVY_EXCEPTION_NOTN>" +
                       "<IGST_LEVY_EXCEPTION_SLNO>" + ds.Tables[4].Rows[i]["IGST_LEVY_EXCEPTION_SLNO"].ToString() + "</IGST_LEVY_EXCEPTION_SLNO>" +
                       "<IGST_LEVY_EXCEPTION_RATE>" + ds.Tables[4].Rows[i]["IGST_LEVY_EXCEPTION_RATE"].ToString() + "</IGST_LEVY_EXCEPTION_RATE>" +
                       "<IGST_LEVY_COMPENSATION_CESS_NOTN>" + ds.Tables[4].Rows[i]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString() + "</IGST_LEVY_COMPENSATION_CESS_NOTN>" +
                       "<IGST_LEVY_COMPENSATION_CESS_SLNO>" + ds.Tables[4].Rows[i]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString() + "</IGST_LEVY_COMPENSATION_CESS_SLNO>" +
                       "<IGST_LEVY_COMPENSATION_CESS_RATE>" + ds.Tables[4].Rows[i]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString() + "</IGST_LEVY_COMPENSATION_CESS_RATE>" +
                       "<IGST_LEVY_COMPENSATION_CESS_SPL>" + ds.Tables[4].Rows[i]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString() + "</IGST_LEVY_COMPENSATION_CESS_SPL>" +
                       "<IGST_LEVY_COMPENSATION_CESS_UNIT>" + ds.Tables[4].Rows[i]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString() + "</IGST_LEVY_COMPENSATION_CESS_UNIT>" +
                       "<IGST_LEVY_COMPENSATION_CESS_SPL_TYPE>" + ds.Tables[4].Rows[i]["IGST_LEVY_COMPENSATION_CESS_SPL_TYPE"].ToString() + "</IGST_LEVY_COMPENSATION_CESS_SPL_TYPE>" +
                       "<IGST_LEVY_EXCEPTION_CC_NOTN>" + ds.Tables[4].Rows[i]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString() + "</IGST_LEVY_EXCEPTION_CC_NOTN>" +
                       "<IGST_LEVY_EXCEPTION_CC_SLNO>" + ds.Tables[4].Rows[i]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString() + "</IGST_LEVY_EXCEPTION_CC_SLNO>" +
                       "<IGST_LEVY_EXCEPTION_CC_RATE>" + ds.Tables[4].Rows[i]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString() + "</IGST_LEVY_EXCEPTION_CC_RATE>" +
                       "<LEVY_EXCEMPTION_NOTN_TYPE>" + ds.Tables[4].Rows[i]["LEVY_EXCEMPTION_NOTN_TYPE"].ToString() + "</LEVY_EXCEMPTION_NOTN_TYPE>" +
                       "<LEVY_EXCEPTION_CC_NOTN_TYPE>" + ds.Tables[4].Rows[i]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString() + "</LEVY_EXCEPTION_CC_NOTN_TYPE>" +
                       "<CHECKLIST_IGST_LEVY_AMOUNT>" + ds.Tables[4].Rows[i]["CHECKLIST_IGST_LEVY_AMOUNT"].ToString() + "</CHECKLIST_IGST_LEVY_AMOUNT>" +
                       "<CHECKLIST_COMPENSATION_CC_AMOUNT>" + ds.Tables[4].Rows[i]["CHECKLIST_COMPENSATION_CC_AMOUNT"].ToString() + "</CHECKLIST_COMPENSATION_CC_AMOUNT>" +
                       "<SOCIAL_WELFARE_NOTN>" + ds.Tables[4].Rows[i]["SOCIAL_WELFARE_NOTN"].ToString() + "</SOCIAL_WELFARE_NOTN>" +
                       "<SOCIAL_WELFARE_NOTN_SLNO>" + ds.Tables[4].Rows[i]["SOCIAL_WELFARE_NOTN_SLNO"].ToString() + "</SOCIAL_WELFARE_NOTN_SLNO>" +
                       "<SOCIAL_WELFARE_RATE>" + ds.Tables[4].Rows[i]["SOCIAL_WELFARE_RATE"].ToString() + "</SOCIAL_WELFARE_RATE>" +
                       "<CHECKLIST_SOCIAL_WELFARE_AMT>" + ds.Tables[4].Rows[i]["CHECKLIST_SOCIAL_WELFARE_AMT"].ToString() + "</CHECKLIST_SOCIAL_WELFARE_AMT>" +
                       "<CHECKLIST_HEALTH_CESS_AMT>" + ds.Tables[4].Rows[i]["CHECKLIST_HEALTH_CESS_AMT"].ToString() + "</CHECKLIST_HEALTH_CESS_AMT>" +
                       "<CHECKLIST_ANTI_DUMPING_AMT>" + ds.Tables[4].Rows[i]["CHECKLIST_ANTI_DUMPING_AMT"].ToString() + "</CHECKLIST_ANTI_DUMPING_AMT>" +
                       "<AMENDMENT_TYPE>" + ds.Tables[4].Rows[i]["AMENDMENT_TYPE"].ToString() + "</AMENDMENT_TYPE>" +
                       "<AMENDMENT_STATUS>" + ds.Tables[4].Rows[i]["AMENDMENT_STATUS"].ToString() + "</AMENDMENT_STATUS>";
             Con += Data;
             Data = "";
         }
         return Con; 
    }
     private string SW_Info_Type(DataSet ds)
     {
         string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[5].Rows.Count; i++)
         {
             Data = "<INVOICE_SLNO>" + ds.Tables[5].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                       "<ITEM_SLNO>" + ds.Tables[5].Rows[i]["ITEM_SLNO"].ToString() + "</ITEM_SLNO>" +
                       "<INFO_TYPE>" + ds.Tables[5].Rows[i]["INFO_TYPE"].ToString() + "</INFO_TYPE>" +
                       "<INFO_QUALIFIER>" + ds.Tables[5].Rows[i]["INFO_QUALIFIER"].ToString() + "</INFO_QUALIFIER>" +
                       "<INFO_CODE>" + ds.Tables[5].Rows[i]["INFO_CODE"].ToString() + "</INFO_CODE>" +
                        "<INFO_TEXT>" + ds.Tables[5].Rows[i]["INFO_TEXT"].ToString() + "</INFO_TEXT>" +
                         "<INFO_MSR>" + ds.Tables[5].Rows[i]["INFO_MSR"].ToString() + "</INFO_MSR>" +
                          "<INFO_UQC>" + ds.Tables[5].Rows[i]["INFO_UQC"].ToString() + "</INFO_UQC>" +
                           "<DEPARTMENT>" + ds.Tables[5].Rows[i]["DEPARTMENT"].ToString() + "</DEPARTMENT>" +
                           "<I_U_TYPE>" + ds.Tables[5].Rows[i]["I_U_TYPE"].ToString() + "</I_U_TYPE>" +
                           "<REGN_DATE>" + ds.Tables[5].Rows[i]["REGN_DATE"].ToString() + "</REGN_DATE>" +
                           "<REGN_VALIDITY>" + ds.Tables[5].Rows[i]["REGN_VALIDITY"].ToString() + "</REGN_VALIDITY>";
             Con += Data;
             Data = "";
         }
         return Con; 
     }
     private string SW_Const(DataSet ds)
     {
         string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[6].Rows.Count; i++)
         {
             Con = "<INVOICE_SLNO>" + ds.Tables[6].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                       "<ITEM_SLNO>" + ds.Tables[6].Rows[i]["ITEM_SLNO"].ToString() + "</ITEM_SLNO>" +
                       "<CONSTITUENT_SRNO>" + ds.Tables[6].Rows[i]["CONSTITUENT_SRNO"].ToString() + "</CONSTITUENT_SRNO>" +
                       "<CONSTITUENT_ELEMENT_NAME>" + ds.Tables[6].Rows[i]["CONSTITUENT_ELEMENT_NAME"].ToString() + "</CONSTITUENT_ELEMENT_NAME>" +
                       "<CONSTITUENT_ELEMENT_CODE>" + ds.Tables[6].Rows[i]["CONSTITUENT_ELEMENT_CODE"].ToString() + "</CONSTITUENT_ELEMENT_CODE>" +
                       "<CONSTITUENT_PERCENTAGE>" + ds.Tables[6].Rows[i]["CONSTITUENT_PERCENTAGE"].ToString() + "</CONSTITUENT_PERCENTAGE>" +
                       "<CONSTITUENT_YIELD_PERCENTAGE>" + ds.Tables[6].Rows[i]["CONSTITUENT_YIELD_PERCENTAGE"].ToString() + "</CONSTITUENT_YIELD_PERCENTAGE>" +
                       "<ACTIVE_INGREDIENT>" + ds.Tables[6].Rows[i]["ACTIVE_INGREDIENT"].ToString() + "</ACTIVE_INGREDIENT>";
             Con += Data;
             Data = "";
         }
         return Con; 
     }
     private string SW_Prod(DataSet ds)
     {
         string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[7].Rows.Count; i++)
         {
             Con = "<INVOICE_SLNO>" + ds.Tables[7].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                       "<ITEM_SLNO>" + ds.Tables[7].Rows[i]["ITEM_SLNO"].ToString() + "</ITEM_SLNO>" +
                       "<PRODUCTION_BATCH_IDENTIFIER>" + ds.Tables[7].Rows[i]["PRODUCTION_BATCH_IDENTIFIER"].ToString() + "</PRODUCTION_BATCH_IDENTIFIER>" +
                       "<PRODUCTION_BATCH_QUANTITY>" + ds.Tables[7].Rows[i]["PRODUCTION_BATCH_QUANTITY"].ToString() + "</PRODUCTION_BATCH_QUANTITY>" +
                       "<UNIT_QTY_CODE>" + ds.Tables[7].Rows[i]["UNIT_QTY_CODE"].ToString() + "</UNIT_QTY_CODE>" +
                         "<DATE_OF_MANUFACTURING>" + ds.Tables[7].Rows[i]["DATE_OF_MANUFACTURING"].ToString() + "</DATE_OF_MANUFACTURING>" +
                           "<DATE_OF_EXPIRY>" + ds.Tables[7].Rows[i]["DATE_OF_EXPIRY"].ToString() + "</DATE_OF_EXPIRY>" +
                             "<BEST_BEFORE>" + ds.Tables[7].Rows[i]["BEST_BEFORE"].ToString() + "</BEST_BEFORE>" +
                               "<RESIDUAL_SHELF_LIFE_DAYS>" + ds.Tables[7].Rows[i]["RESIDUAL_SHELF_LIFE_DAYS"].ToString() + "</RESIDUAL_SHELF_LIFE_DAYS>" +
                                 "<TOTAL_SHELF_LIFE_DAYS>" + ds.Tables[7].Rows[i]["TOTAL_SHELF_LIFE_DAYS"].ToString() + "</TOTAL_SHELF_LIFE_DAYS>" +
                                   "<RESIDUAL_SHELF_PERCENT>" + ds.Tables[7].Rows[i]["RESIDUAL_SHELF_PERCENT"].ToString() + "</RESIDUAL_SHELF_PERCENT>" ;
             Con += Data;
             Data = "";
         }
         return Con; 
     }
     private string SW_Control(DataSet ds)
     {
         string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[8].Rows.Count; i++)
         {
             Con = "<INVOICE_SLNO>" + ds.Tables[8].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                       "<ITEM_SLNO>" + ds.Tables[8].Rows[i]["ITEM_SLNO"].ToString() + "</ITEM_SLNO>" +
                       "<CONTROL_TYPE_CODE>" + ds.Tables[8].Rows[i]["CONTROL_TYPE_CODE"].ToString() + "</CONTROL_TYPE_CODE>" +
                       "<CONTROL_LOCATION>" + ds.Tables[8].Rows[i]["CONTROL_LOCATION"].ToString() + "</CONTROL_LOCATION>" +
                       "<CONTROL_START_DATE>" + ds.Tables[8].Rows[i]["CONTROL_START_DATE"].ToString() + "</CONTROL_START_DATE>" +
                       "<CONTROL_END_DATE>" + ds.Tables[8].Rows[i]["CONTROL_END_DATE"].ToString() + "</CONTROL_END_DATE>" +
                       "<CONTROL_RESULT_CODE>" + ds.Tables[8].Rows[i]["CONTROL_RESULT_CODE"].ToString() + "</CONTROL_RESULT_CODE>" +
                       "<CONTROL_RESULT_TEXT>" + ds.Tables[8].Rows[i]["CONTROL_RESULT_TEXT"].ToString() + "</v>";
             Con += Data;
             Data = "";
         }
         return Con; 
     }
     private string SW_Stmt(DataSet ds)
     {
         string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[9].Rows.Count; i++)
         {
             Con = "<INVOICE_SLNO>" + ds.Tables[9].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                       "<ITEM_SLNO>" + ds.Tables[9].Rows[i]["ITEM_SLNO"].ToString() + "</ITEM_SLNO>" +
                       "<STMT_DECLARATION_TYPE>" + ds.Tables[9].Rows[i]["STMT_DECLARATION_TYPE"].ToString() + "</STMT_DECLARATION_TYPE>" +
                       "<STMT_DECLARATION_NUMBER>" + ds.Tables[9].Rows[i]["STMT_DECLARATION_NUMBER"].ToString() + "</STMT_DECLARATION_NUMBER>" +
                       "<STMT_DECLARATION_DATE>" + ds.Tables[9].Rows[i]["STMT_DECLARATION_DATE"].ToString() + "</STMT_DECLARATION_DATE>" +
                       "<STMT_TYPE>" + ds.Tables[9].Rows[i]["STMT_TYPE"].ToString() + "</STMT_TYPE>" +
                       "<STMT_CODE>" + ds.Tables[9].Rows[i]["STMT_CODE"].ToString() + "</STMT_CODE>" +
                       "<STMT_TEXT>" + ds.Tables[9].Rows[i]["STMT_TEXT"].ToString() + "</STMT_TEXT>";
             Con += Data;
             Data = "";
         }
         return Con; 
     }
     private string SW_Sup_doc(DataSet ds)
     {
         string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i <ds.Tables[10].Rows.Count; i++)
         {
             Con = "<INVOICE_SLNO>" + ds.Tables[10].Rows[i]["INVOICE_SLNO"].ToString() + "</INVOICE_SLNO>" +
                       "<ITEM_SLNO>" + ds.Tables[10].Rows[i]["ITEM_SLNO"].ToString() + "</ITEM_SLNO>" +
                       "<DECLARATION_TYPE>" + ds.Tables[10].Rows[i]["DECLARATION_TYPE"].ToString() + "</DECLARATION_TYPE>" +
                       "<IMAGE_REF_NUMBER>" + ds.Tables[10].Rows[i]["IMAGE_REF_NUMBER"].ToString() + "</IMAGE_REF_NUMBER>" +
                       "<DOC_TYPE_CODE>" + ds.Tables[10].Rows[i]["DOC_TYPE_CODE"].ToString() + "</DOC_TYPE_CODE>" +
                       "<DOC_ISSUING_PARTY_CODE>" + ds.Tables[10].Rows[i]["DOC_ISSUING_PARTY_CODE"].ToString() + "</DOC_ISSUING_PARTY_CODE>" +
                       "<DOC_ISSUING_PARTY_NAME>" + ds.Tables[10].Rows[i]["DOC_ISSUING_PARTY_NAME"].ToString() + "</DOC_ISSUING_PARTY_NAME>" +
                       "<DOC_ISSUING_PARTY_NAME_ADD1>" + ds.Tables[10].Rows[i]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString() + "</DOC_ISSUING_PARTY_NAME_ADD1>" +
                       "<DOC_ISSUING_PARTY_NAME_ADD2>" + ds.Tables[10].Rows[i]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString() + "</DOC_ISSUING_PARTY_NAME_ADD2>" +
                       "<DOC_ISSUING_PARTY_CITY>" + ds.Tables[10].Rows[i]["DOC_ISSUING_PARTY_CITY"].ToString() + "</DOC_ISSUING_PARTY_CITY>" +
                       "<DOC_ISSUING_PARTY_PIN>" + ds.Tables[10].Rows[i]["DOC_ISSUING_PARTY_PIN"].ToString() + "</DOC_ISSUING_PARTY_PIN>" +
                       "<DOC_REF_NUMBER>" + ds.Tables[10].Rows[i]["DOC_REF_NUMBER"].ToString() + "</DOC_REF_NUMBER>" +
                       "<PLACE_OF_ISSUE>" + ds.Tables[10].Rows[i]["PLACE_OF_ISSUE"].ToString() + "</PLACE_OF_ISSUE>" +
                       "<DOC_ISSUE_DATE>" + ds.Tables[10].Rows[i]["DOC_ISSUE_DATE"].ToString() + "</DOC_ISSUE_DATE>" +
                       "<DOC_EXPIRY_DATE>" + ds.Tables[10].Rows[i]["DOC_EXPIRY_DATE"].ToString() + "</DOC_EXPIRY_DATE>" +
                       "<BENEFICIARY_PARTY_CODE>" + ds.Tables[10].Rows[i]["BENEFICIARY_PARTY_CODE"].ToString() + "</BENEFICIARY_PARTY_CODE>" +
                       "<BENEFICIARY_PARTY_NAME>" + ds.Tables[10].Rows[i]["BENEFICIARY_PARTY_NAME"].ToString() + "</BENEFICIARY_PARTY_NAME>" +
                       "<BENEFICIARY_PARTY_ADDRESS1>" + ds.Tables[10].Rows[i]["BENEFICIARY_PARTY_ADDRESS1"].ToString() + "</BENEFICIARY_PARTY_ADDRESS1>" +
                       "<BENEFICIARY_PARTY_ADDRESS2>" + ds.Tables[10].Rows[i]["BENEFICIARY_PARTY_ADDRESS2"].ToString() + "</BENEFICIARY_PARTY_ADDRESS2>" +
                       "<BENEFICIARY_PARTY_CITY>" + ds.Tables[10].Rows[i]["BENEFICIARY_PARTY_CITY"].ToString() + "</BENEFICIARY_PARTY_CITY>" +
                       "<BENEFICIARY_PARTY_PIN>" + ds.Tables[10].Rows[i]["BENEFICIARY_PARTY_PIN"].ToString() + "</BENEFICIARY_PARTY_PIN>" +
                       "<FILE_TYPE>" + ds.Tables[10].Rows[i]["FILE_TYPE"].ToString() + "</FILE_TYPE>" +
                       "<SELECT_TYPE>" + ds.Tables[10].Rows[i]["SELECT_TYPE"].ToString() + "</SELECT_TYPE>" +
                       "<ICEGATE_ID>" + ds.Tables[10].Rows[i]["ICEGATE_ID"].ToString() + "</ICEGATE_ID>" +
                       "<AMENDMENT_TYPE>" + ds.Tables[10].Rows[i]["AMENDMENT_TYPE"].ToString() + "</AMENDMENT_TYPE>" +
                       "<AMENDMENT_STATUS>" + ds.Tables[10].Rows[i]["AMENDMENT_STATUS"].ToString() + "</AMENDMENT_STATUS>" +
                       "<ICEGATE_DOC_FILE_NAME>" + ds.Tables[10].Rows[i]["ICEGATE_DOC_FILE_NAME"].ToString() + "</ICEGATE_DOC_FILE_NAME>";
             Con += Data;
             Data = "";
         }
         return Con; 
     }
     private string BE_Details(DataSet ds)
     {
         string Con = string.Empty, Data = string.Empty;
         for (int i = 0; i < ds.Tables[11].Rows.Count; i++)
         {
             Con = "<BE_NO>" + ds.Tables[11].Rows[i]["BE_NO"].ToString() + "</BE_NO>" +
                   "<BE_DATE>" + ds.Tables[11].Rows[i]["BE_DATE"].ToString() + "</BE_DATE>";
             Con += Data;
             Data = "";
         }
         return Con;
     }
    public DataSet Select_IMP_EXP_Ryal(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@Cus_Code", objUserBL.A2);
            param[3] = new SqlParameter("@Area_Login", objUserBL.A3);

            param[4] = new SqlParameter("@Imp_Exp", objUserBL.A4);
            param[5] = new SqlParameter("@Flag", objUserBL.A5);
            param[6] = new SqlParameter("@I_Fact_Jobno", objUserBL.A6);
            param[7] = new SqlParameter("@FF_Company_Lic", objUserBL.A7);

            param[15] = new SqlParameter("@User", Connection.Current_User());
            param[16] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[17] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[19] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("RYAL_FF_DATA_SERVICES", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public string PostData(int is_live, string job_no, int job_type, int shipping_type, string data)
    {
        
         /**
          *  //is_live: 1 = Live, 0 = Testing
         //job_no: this is the Ryal Job No e.g. SJ000104/20-21
         //job_type: 0 = Export, 1 = Import
         //shipping_type: 0 = Air, 1 = SEA
          * */

       var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
        var url = "";
         if (is_live == 1)//*********IS LIVE IMPLEMENTATION********
         {
             url = "https://erp.ryal.in/RoyalWebhook/Index?job_no=" + HttpUtility.UrlEncode(job_no) + "&job_type=" + job_type + "&shipping_type=" + shipping_type;
         }
         else//*********IS TEST IMPLEMENTATION********
         {
            // url = "http://ec2-13-126-55-177.ap-south-1.compute.amazonaws.com/RyalErp2/RoyalWebhook/Index?job_no=" + HttpUtility.UrlEncode(job_no) + "&job_type=" + job_type + "&shipping_type=" + shipping_type;
            // url = "http://ec2-13-126-55-177.ap-south-1.compute.amazonaws.com/RyalErp2/RoyalWebhook/Index?job_no=" + HttpUtility.UrlEncode("SJAEC000001/20-21") + "&job_type=0&shipping_type=" + shipping_type;
            //url = "http://localhost:63075/ViewPage1.cshtml?action=wh&job_no=" + HttpUtility.UrlEncode(job_no) + "&job_type=" + job_type + "&shipping_type=" + shipping_type;

             url = "http://ec2-13-233-140-191.ap-south-1.compute.amazonaws.com/RyalErp2/RoyalWebhook/Index?job_no=" + HttpUtility.UrlEncode(job_no) + "&job_type=" + job_type + "&shipping_type=" + shipping_type;

         }

         var httpRequestMessage = new HttpRequestMessage
         {
             Method = HttpMethod.Post,
             RequestUri = new Uri(url),
             Headers = {
                 { HttpRequestHeader.Authorization.ToString(), "d880a9a425bd216fc90c69d17916a1d6" },
                 { HttpRequestHeader.ContentLength.ToString(), data.Length.ToString()},
                 { "X-Version", "1" }
                 },
             Content = new StringContent(data, Encoding.UTF8, "text/xml")
         };
         
        var response = client.SendAsync(httpRequestMessage).Result;
        var responseData = response.Content.ReadAsStringAsync().Result;
        return responseData;
       
    }
  
    public string PostjobReferenceNo(int is_live, string ryal_job_no, string royal_impex_jobno)
    {
        
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
        var url = "";

        if (is_live == 1 && Connection.COMPANYID() == "752")//*********IS LIVE IMPLEMENTATION********
        {
            url = liveURL + "saveJobReferenceNo?ryal_job_no=" + HttpUtility.UrlEncode(ryal_job_no) + "&royal_impex_jobno=" + HttpUtility.UrlEncode(royal_impex_jobno);
        }
     
        else//*********IS TEST IMPLEMENTATION********
        {
            url = stagingURL + "saveJobReferenceNo?ryal_job_no=" + HttpUtility.UrlEncode(ryal_job_no) + "&royal_impex_jobno=" + HttpUtility.UrlEncode(royal_impex_jobno);

        }

        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
            Headers = {
                    { HttpRequestHeader.Authorization.ToString(), "d880a9a425bd216fc90c69d17916a1d6" },
                    { "X-Version", "1" }
                }
        };

        var response = client.SendAsync(httpRequestMessage).Result;
        var responseData = response.Content.ReadAsStringAsync().Result;

        return responseData;
         
    }

    public string PostBillOfEntry(int is_live, string ryal_job_no, string royal_impex_jobno, string be_no, string be_date)
    {
        
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
        var url = "";

        if (is_live == 1)//*********IS LIVE IMPLEMENTATION********
        {
            url = liveURL + "saveBillOfEntry?ryal_job_no=" + HttpUtility.UrlEncode(ryal_job_no) + "&royal_impex_jobno=" + HttpUtility.UrlEncode(royal_impex_jobno);
            url += "&beno=" + HttpUtility.UrlEncode(be_no) + "&bedate=" + HttpUtility.UrlEncode(be_date);
        }
        else//*********IS TEST IMPLEMENTATION********
        {
            url = stagingURL + "saveBillOfEntry?ryal_job_no=" + HttpUtility.UrlEncode(ryal_job_no) + "&royal_impex_jobno=" + HttpUtility.UrlEncode(royal_impex_jobno);
            url += "&beno=" + HttpUtility.UrlEncode(be_no) + "&bedate=" + HttpUtility.UrlEncode(be_date);
        }

        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url),
            Headers = {
                    { HttpRequestHeader.Authorization.ToString(), "d880a9a425bd216fc90c69d17916a1d6" },
                    { "X-Version", "1" }
                }
        };

        var response = client.SendAsync(httpRequestMessage).Result;
        var responseData = response.Content.ReadAsStringAsync().Result;

        return responseData;        
    }
}