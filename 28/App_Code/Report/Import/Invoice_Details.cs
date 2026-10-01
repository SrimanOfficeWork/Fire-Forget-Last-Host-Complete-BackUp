using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for Invoice_Details
/// </summary>
public class INVOICE_DETAILS
{
    #region Private_Attributes
   
    private string _IGM_TRANSPORTMODE;
    private string _MIS_CHARGES_;
   
    private string _SECTION46;
    private string _FIRSTCHECK;
    private string _GREEN_CHANNEL;

    // Invoice Details
    private int _INVOICE_SLNO;
    private string _INVOICE_NO, _INVOICE_NO_ITEM, _Invoice_No, _Invoice_Details, _Total_Invoice, _SupplierCountry_Name_Pincode;
    private string _INVOICE_DATE;
    private string _INVOICE_VALUE, _Invoice_value, _INVOICE_EXRATE;
    private string _TERMS;
    private string _INVOICE_CURRENCY, _Invoice_Currency;
    private string _SUPPLIER_NAME;
    private string _SUPPLIER_ADDRESS;
    private string _SUPPLIER_ADDRESS1;
    private string _SUPPLIER_ADDRESS2;
    private string _SUPPLIER_COUNTRY_NAME;
    private string _SUPPLIER_COUNTRY_PINCODE;
    private string _MIS_FREIGHT_CHARGES;
    private string _MIS_FREIGHT_RATE;
    private string _MIS_FREIGHT_CURRENCY;
    private string _MIS_FREIGHT_EXRATE;
    private string _MIS_INSURANCE_CHARGES;
    private string _MIS_INSURANCE_RATE;
    private string _MIS_INSURANCE_CURRENCY;
    private string _MIS_INSURANCE_EXRATE;
    private string _SVB_RELATION;
    private string _SVB_REF_NO;
    private string _SVB_ASSESABLE_RATE;
    private string _SVB_DUTY_RATE;
    private string _SVB_CUSTOM_HOUSE;
    private string _SVB_LOADING_ON;
    
    private string _MIS_CHARGES;
    private string _MIS_RATE;
    private string _MIS_EXRATE;
    private string _MIS_HIGHSEASALE_RATE;
    private string _MIS_HIGHSEASALE_CHARGES;
    private string _MIS_DISCOUNT_RATE;
    private string _MIS_DISCOUNT_CHARGES;

    private string _MIS_CURRENCY;
    private string _MIS_LOADING_CHARGES;
    private string _MIS_LOADING_CURRENCY;
    private string _MIS_LOADING_EXRATE;
    private string _MIS_DISCOUNT_CURRENCY;
    private string _MIS_DISCOUNT_EXRATE;
    private string _SVB_ASSESABLE_STATUS;
    private string _SVB_DUTY_STATUS;
    private string _KACHHA_BE;
    private string _SECTION48;
    private string _PROVISIONAL;
    private string _MIS_HIGHSEASALE_CURRENCY;
    private string _MIS_HIGHSEASALE_EXRATE;
    
    private string _OTHER_PURCHASE_ORDER;
    private string _OTHER_PURCHASE_ORDER_DATE;
    private string _OTHER_CONTRACT_NO;
    private string _OTHER_CONTRACT_DATE;
    private string _OTHER_LOC_NO;
    private string _OTHER_LOC_DATE;
    private string _TOTAL_HSS_AMOUNT;
        
    private string _SVB_REF_DATE;
    private string _OTHER_NATURE_OF_TRANSACTION;
    private string _OTHER_TERMS_OF_PAYMENT;
    private string _OTHER_CONDITIONS;
    private string _OTHER_VALUATION_METHOD;
    private string _TICK_SALE;
    private string _TICK_COSIGNMENT;
    private string _TICK_HIRE;
    private string _TICK_RENT;
    private string _TICK_REPLACEMENT;
    private string _TICK_GIFT;
    private string _TICK_SAMPLE;
    private string _TICK_OTHER_FREECOST;
    private string _TICK_LC;
    private string _TICK_FOC;
    private string _TICK_SD;
    private string _TICK_DP;
    private string _TICK_OTHER;
    private string _TICK_FOB;
    private string _TICK_CI;
    private string _TICK_CF;
    private string _TICK_CIF;
    private string _TICK_SVBLOAD_ASSESSABLE;
    private string _TICK_SVBLOAD_DUTY;
    private string _TICK_SVBLOAD_BOTH;
    private string _TICK_SVBLOAD_ASS_STATUS;
    private string _TICK_SVBLOAD_DUTY_STATUS;
    private string _TERMS_PLACE;
    private string _THIRDPARTY_NAME;
    private string _THIRDPARTY_ADD1;
    private string _THIRDPARTY_ADD2;
    private string _THIRDPARTY_CITY;
    private string _T_PARTY_COUNTRY_SUB_DIV;
    private string _T_PARTY_COUNTRY_CODE;
    private string _T_PARTY_PIN;
    private string _AUTHORIZED_ECONOMIC_OPERATOR_CODE;
    private string _A_E_O_COUNTRY;
    private string _AUTHORIZED_ECONOMIC_OPERATOR;
    private string _WHETHER_BUYER_SELLER_RELATED;
    private string _SELLER_NAME, _SELLER_ADDRESS, _SELLER_ADDRESS1, _SELLER_ADDRESS2, _SELLER_COUNTRY_NAME, _SELLER_COUNTRY_CODE, _SELLERCOUNTRY_PINCODE;
    private string _MIS_AGENCY_RATE, _MIS_AGENCY_CHARGES, _MIS_AGENCY_CURRENCY, _MIS_AGENCY_EXRATE, _TOTAL_FOC_Item_AMT;


    #endregion

    #region Public_Attributes
  
    public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }
    // Invoice Details
    public string OTHER_NATURE_OF_TRANSACTION { get { return _OTHER_NATURE_OF_TRANSACTION; } set { _OTHER_NATURE_OF_TRANSACTION = value; } }
    
    public string OTHER_TERMS_OF_PAYMENT { get { return _OTHER_TERMS_OF_PAYMENT; } set { _OTHER_TERMS_OF_PAYMENT = value; } }
    public string OTHER_CONDITIONS { get { return _OTHER_CONDITIONS; } set { _OTHER_CONDITIONS = value; } }
    public string OTHER_VALUATION_METHOD { get { return _OTHER_VALUATION_METHOD; } set { _OTHER_VALUATION_METHOD = value; } }
    
    public string MIS_CHARGES_ { get { return _MIS_CHARGES_; } set { _MIS_CHARGES_ = value; } }
    public int INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_NO_ITEM { get { return _INVOICE_NO_ITEM; } set { _INVOICE_NO_ITEM = value; } }
    public string Invoice_No { get { return _Invoice_No; } set { _Invoice_No = value; } }
    public string Invoice_Details { get { return _Invoice_Details; } set { _Invoice_Details = value; } }
    public string Total_Invoice { get { return _Total_Invoice; } set { _Total_Invoice = value; } }
    public string SupplierCountry_Name_Pincode { get { return _SupplierCountry_Name_Pincode; } set { _SupplierCountry_Name_Pincode = value; } }

    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string Invoice_value { get { return _Invoice_value; } set { _Invoice_value = value; } }
    public string TERMS { get { return _TERMS; } set { _TERMS = value; } }

    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }
    public string INVOICE_EXRATE { get { return _INVOICE_EXRATE; } set { _INVOICE_EXRATE = value; } }
    public string Invoice_Currency { get { return _Invoice_Currency; } set { _Invoice_Currency = value; } }
    public string SUPPLIER_NAME { get { return _SUPPLIER_NAME; } set { _SUPPLIER_NAME = value; } }
    public string SUPPLIER_ADDRESS { get { return _SUPPLIER_ADDRESS; } set { _SUPPLIER_ADDRESS = value; } }
    public string SUPPLIER_ADDRESS1 { get { return _SUPPLIER_ADDRESS1; } set { _SUPPLIER_ADDRESS1 = value; } }
    public string SUPPLIER_ADDRESS2 { get { return _SUPPLIER_ADDRESS2; } set { _SUPPLIER_ADDRESS2 = value; } }
    public string SUPPLIER_COUNTRY_NAME { get { return _SUPPLIER_COUNTRY_NAME; } set { _SUPPLIER_COUNTRY_NAME = value; } }
    public string SUPPLIER_COUNTRY_PINCODE { get { return _SUPPLIER_COUNTRY_PINCODE; } set { _SUPPLIER_COUNTRY_PINCODE = value; } }
    public string MIS_FREIGHT_CHARGES { get { return _MIS_FREIGHT_CHARGES; } set { _MIS_FREIGHT_CHARGES = value; } }

    public string MIS_FREIGHT_RATE { get { return _MIS_FREIGHT_RATE; } set { _MIS_FREIGHT_RATE = value; } }
    public string MIS_FREIGHT_CURRENCY { get { return _MIS_FREIGHT_CURRENCY; } set { _MIS_FREIGHT_CURRENCY = value; } }
    public string MIS_FREIGHT_EXRATE { get { return _MIS_FREIGHT_EXRATE; } set { _MIS_FREIGHT_EXRATE = value; } }
    public string MIS_INSURANCE_RATE { get { return _MIS_INSURANCE_RATE; } set { _MIS_INSURANCE_RATE = value; } }
    public string MIS_INSURANCE_CHARGES { get { return _MIS_INSURANCE_CHARGES; } set { _MIS_INSURANCE_CHARGES = value; } }
    public string MIS_INSURANCE_CURRENCY { get { return _MIS_INSURANCE_CURRENCY; } set { _MIS_INSURANCE_CURRENCY = value; } }
    public string MIS_INSURANCE_EXRATE { get { return _MIS_INSURANCE_EXRATE; } set { _MIS_INSURANCE_EXRATE = value; } }
    public string SVB_RELATION { get { return _SVB_RELATION; } set { _SVB_RELATION = value; } }
    public string SVB_REF_NO { get { return _SVB_REF_NO; } set { _SVB_REF_NO = value; } }
    public string SVB_ASSESABLE_RATE { get { return _SVB_ASSESABLE_RATE; } set { _SVB_ASSESABLE_RATE = value; } }
    public string SVB_DUTY_RATE { get { return _SVB_DUTY_RATE; } set { _SVB_DUTY_RATE = value; } }
    public string SVB_CUSTOM_HOUSE { get { return _SVB_CUSTOM_HOUSE; } set { _SVB_CUSTOM_HOUSE = value; } }
    public string MIS_CHARGES { get { return _MIS_CHARGES; } set { _MIS_CHARGES = value; } }
    public string MIS_RATE { get { return _MIS_RATE; } set { _MIS_RATE = value; } }
    public string MIS_EXRATE { get { return _MIS_EXRATE; } set { _MIS_EXRATE = value; } }
    public string MIS_HIGHSEASALE_RATE { get { return _MIS_HIGHSEASALE_RATE; } set { _MIS_HIGHSEASALE_RATE = value; } }
    public string MIS_HIGHSEASALE_CHARGES { get { return _MIS_HIGHSEASALE_CHARGES; } set { _MIS_HIGHSEASALE_CHARGES = value; } }
    public string MIS_DISCOUNT_RATE { get { return _MIS_DISCOUNT_RATE; } set { _MIS_DISCOUNT_RATE = value; } }
    public string MIS_DISCOUNT_CHARGES { get { return _MIS_DISCOUNT_CHARGES; } set { _MIS_DISCOUNT_CHARGES = value; } }
    public string MIS_CURRENCY { get { return _MIS_CURRENCY; } set { _MIS_CURRENCY = value; } }
    public string MIS_LOADING_CHARGES { get { return _MIS_LOADING_CHARGES; } set { _MIS_LOADING_CHARGES = value; } }
    public string MIS_LOADING_CURRENCY { get { return _MIS_LOADING_CURRENCY; } set { _MIS_LOADING_CURRENCY = value; } }
    public string MIS_LOADING_EXRATE { get { return _MIS_LOADING_EXRATE; } set { _MIS_LOADING_EXRATE = value; } }
    public string MIS_DISCOUNT_CURRENCY { get { return _MIS_DISCOUNT_CURRENCY; } set { _MIS_DISCOUNT_CURRENCY = value; } }
    public string MIS_DISCOUNT_EXRATE { get { return _MIS_DISCOUNT_EXRATE; } set { _MIS_DISCOUNT_EXRATE = value; } }
    public string SVB_ASSESABLE_STATUS { get { return _SVB_ASSESABLE_STATUS; } set { _SVB_ASSESABLE_STATUS = value; } }
    public string SVB_DUTY_STATUS { get { return _SVB_DUTY_STATUS; } set { _SVB_DUTY_STATUS = value; } }
    
    public string MIS_HIGHSEASALE_CURRENCY { get { return _MIS_HIGHSEASALE_CURRENCY; } set { _MIS_HIGHSEASALE_CURRENCY = value; } }
    public string MIS_HIGHSEASALE_EXRATE { get { return _MIS_HIGHSEASALE_EXRATE; } set { _MIS_HIGHSEASALE_EXRATE = value; } }
    
    public string SECTION46 { get { return _SECTION46; } set { _SECTION46 = value; } }
    public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
    public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
    public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
    public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
    public string PROVISIONAL { get { return _PROVISIONAL; } set { _PROVISIONAL = value; } }


    public string TERMS_PLACE { get { return _TERMS_PLACE; } set { _TERMS_PLACE = value; } }
    public string THIRDPARTY_NAME { get { return _THIRDPARTY_NAME; } set { _THIRDPARTY_NAME = value; } }
    public string THIRDPARTY_ADD1 { get { return _THIRDPARTY_ADD1; } set { _THIRDPARTY_ADD1 = value; } }
    public string THIRDPARTY_ADD2 { get { return _THIRDPARTY_ADD2; } set { _THIRDPARTY_ADD2 = value; } }
    public string THIRDPARTY_CITY { get { return _THIRDPARTY_CITY; } set { _THIRDPARTY_CITY = value; } }
    public string T_PARTY_COUNTRY_SUB_DIV { get { return _T_PARTY_COUNTRY_SUB_DIV; } set { _T_PARTY_COUNTRY_SUB_DIV = value; } }
    public string T_PARTY_COUNTRY_CODE { get { return _T_PARTY_COUNTRY_CODE; } set { _T_PARTY_COUNTRY_CODE = value; } }
    public string T_PARTY_PIN { get { return _T_PARTY_PIN; } set { _T_PARTY_PIN = value; } }
    public string AUTHORIZED_ECONOMIC_OPERATOR_CODE { get { return _AUTHORIZED_ECONOMIC_OPERATOR_CODE; } set { _AUTHORIZED_ECONOMIC_OPERATOR_CODE = value; } }
    public string A_E_O_COUNTRY { get { return _A_E_O_COUNTRY; } set { _A_E_O_COUNTRY = value; } }
    public string AUTHORIZED_ECONOMIC_OPERATOR { get { return _AUTHORIZED_ECONOMIC_OPERATOR; } set { _AUTHORIZED_ECONOMIC_OPERATOR = value; } }
    public string WHETHER_BUYER_SELLER_RELATED { get { return _WHETHER_BUYER_SELLER_RELATED; } set { _WHETHER_BUYER_SELLER_RELATED = value; } }

    public string SELLER_NAME { get { return _SELLER_NAME; } set { _SELLER_NAME = value; } }
    public string SELLER_ADDRESS { get { return _SELLER_ADDRESS; } set { _SELLER_ADDRESS = value; } }
    public string SELLER_ADDRESS1 { get { return _SELLER_ADDRESS1; } set { _SELLER_ADDRESS1 = value; } }
    public string SELLER_ADDRESS2 { get { return _SELLER_ADDRESS2; } set { _SELLER_ADDRESS2 = value; } }
    public string SELLER_COUNTRY_NAME { get { return _SELLER_COUNTRY_NAME; } set { _SELLER_COUNTRY_NAME = value; } }
    public string SELLER_COUNTRY_CODE { get { return _SELLER_COUNTRY_CODE; } set { _SELLER_COUNTRY_CODE = value; } }
    public string SELLERCOUNTRY_PINCODE { get { return _SELLERCOUNTRY_PINCODE; } set { _SELLERCOUNTRY_PINCODE = value; } }

    public string MIS_AGENCY_RATE { get { return _MIS_AGENCY_RATE; } set { _MIS_AGENCY_RATE = value; } }
    public string MIS_AGENCY_CHARGES { get { return _MIS_AGENCY_CHARGES; } set { _MIS_AGENCY_CHARGES = value; } }
    public string MIS_AGENCY_CURRENCY { get { return _MIS_AGENCY_CURRENCY; } set { _MIS_AGENCY_CURRENCY = value; } }
    public string MIS_AGENCY_EXRATE { get { return _MIS_AGENCY_EXRATE; } set { _MIS_AGENCY_EXRATE = value; } }


    #endregion
    
    private string _INVOICE_ID;
    public string INVOICE_ID { get { return _INVOICE_ID; } set { _INVOICE_ID = value; } }
    public string MIS_CHARGES_Add;
    public string INVOICE_EXCHANGERATE;
    
    public string OTHER_PURCHASE_ORDER { get { return _OTHER_PURCHASE_ORDER; } set { _OTHER_PURCHASE_ORDER = value; } }
    public string OTHER_PURCHASE_ORDER_DATE { get { return _OTHER_PURCHASE_ORDER_DATE; } set { _OTHER_PURCHASE_ORDER_DATE = value; } }
    public string OTHER_CONTRACT_NO { get { return _OTHER_CONTRACT_NO; } set { _OTHER_CONTRACT_NO = value; } }
    public string OTHER_CONTRACT_DATE { get { return _OTHER_CONTRACT_DATE; } set { _OTHER_CONTRACT_DATE = value; } }
    public string OTHER_LOC_NO { get { return _OTHER_LOC_NO; } set { _OTHER_LOC_NO = value; } }
    public string OTHER_LOC_DATE { get { return _OTHER_LOC_DATE; } set { _OTHER_LOC_DATE = value; } }
    public string TOTAL_HSS_AMOUNT { get { return _TOTAL_HSS_AMOUNT; } set { _TOTAL_HSS_AMOUNT = value; } }
    public string TOTAL_FOC_Item_AMT { get { return _TOTAL_FOC_Item_AMT; } set { _TOTAL_FOC_Item_AMT = value; } }

    
    public string SVB_REF_DATE { get { return _SVB_REF_DATE; } set { _SVB_REF_DATE = value; } }
    public string SVB_LOADING_ON { get { return _SVB_LOADING_ON; } set { _SVB_LOADING_ON = value; } }
    
    public string TICK_SALE { get { return _TICK_SALE; } set { _TICK_SALE = value; } }
    public string TICK_COSIGNMENT { get { return _TICK_COSIGNMENT; } set { _TICK_COSIGNMENT = value; } }
    public string TICK_HIRE { get { return _TICK_HIRE; } set { _TICK_HIRE = value; } }
    public string TICK_RENT { get { return _TICK_RENT; } set { _TICK_RENT = value; } }
    public string TICK_REPLACEMENT { get { return _TICK_REPLACEMENT; } set { _TICK_REPLACEMENT = value; } }
    public string TICK_GIFT { get { return _TICK_GIFT; } set { _TICK_GIFT = value; } }
    public string TICK_SAMPLE { get { return _TICK_SAMPLE; } set { _TICK_SAMPLE = value; } }
    public string TICK_OTHER_FREECOST { get { return _TICK_OTHER_FREECOST; } set { _TICK_OTHER_FREECOST = value; } }
    public string TICK_LC { get { return _TICK_LC; } set { _TICK_LC = value; } }
    public string TICK_FOC { get { return _TICK_FOC; } set { _TICK_FOC = value; } }
    public string TICK_SD { get { return _TICK_SD; } set { _TICK_SD = value; } }
    public string TICK_DP { get { return _TICK_DP; } set { _TICK_DP = value; } }
    public string TICK_OTHER { get { return _TICK_OTHER; } set { _TICK_OTHER = value; } }
    public string TICK_FOB { get { return _TICK_FOB; } set { _TICK_FOB = value; } }
    public string TICK_CI { get { return _TICK_CI; } set { _TICK_CI = value; } }
    public string TICK_CF { get { return _TICK_CF; } set { _TICK_CF = value; } }
    public string TICK_CIF { get { return _TICK_CIF; } set { _TICK_CIF = value; } }
    public string TICK_SVBLOAD_ASSESSABLE { get { return _TICK_SVBLOAD_ASSESSABLE; } set { _TICK_SVBLOAD_ASSESSABLE = value; } }
    public string TICK_SVBLOAD_DUTY { get { return _TICK_SVBLOAD_DUTY; } set { _TICK_SVBLOAD_DUTY = value; } }
    public string TICK_SVBLOAD_BOTH { get { return _TICK_SVBLOAD_BOTH; } set { _TICK_SVBLOAD_BOTH = value; } }
    public string TICK_SVBLOAD_ASS_STATUS { get { return _TICK_SVBLOAD_ASS_STATUS; } set { _TICK_SVBLOAD_ASS_STATUS = value; } }
    public string TICK_SVBLOAD_DUTY_STATUS { get { return _TICK_SVBLOAD_DUTY_STATUS; } set { _TICK_SVBLOAD_DUTY_STATUS = value; } }




    public List<INVOICE_DETAILS> Get_Invoice_Details(string ddlJobNo, DataTable ds, DataTable ds1)
    {

        List<INVOICE_DETAILS> list = new List<INVOICE_DETAILS>();

        if (ds.Rows.Count > 0)
        {
            SECTION46 = ds.Rows[0]["SECTION46"].ToString();
            FIRSTCHECK = ds.Rows[0]["FIRSTCHECK"].ToString();
            GREEN_CHANNEL = ds.Rows[0]["GREEN_CHANNEL"].ToString();
            KACHHA_BE = ds.Rows[0]["KACHHA_BE"].ToString();
            SECTION48 = ds.Rows[0]["SECTION48"].ToString();

        }
        //Invoice_Details = Convert.ToString(ds1.Rows.Count);


        int i = 0;
        //foreach (DataRow dRows in ds1.Rows)
        while (ds1.Rows.Count > i)
        //for (i = 0; i < ds1.Rows.Count; i++)
        {

            INVOICE_SLNO = Convert.ToInt32(ds1.Rows[i]["INVOICE_SLNO"].ToString());
            INVOICE_NO = ds1.Rows[i]["INVOICE_NO"].ToString();

            INVOICE_DATE = ds1.Rows[i]["INVOICE_DATE"].ToString();
            INVOICE_VALUE = ds1.Rows[i]["INVOICE_VALUE"].ToString();
            INVOICE_CURRENCY = ds1.Rows[i]["INVOICE_CURRENCY"].ToString();
            MIS_FREIGHT_CHARGES = ds1.Rows[i]["MIS_FREIGHT_CHARGES"].ToString();
            MIS_FREIGHT_RATE = ds1.Rows[i]["MIS_FREIGHT_RATE"].ToString();
            MIS_FREIGHT_CURRENCY = ds1.Rows[i]["MIS_FREIGHT_CURRENCY"].ToString();
            MIS_FREIGHT_EXRATE = ds1.Rows[i]["MIS_FREIGHT_EXRATE"].ToString();
            MIS_INSURANCE_CHARGES = ds1.Rows[i]["MIS_INSURANCE_CHARGES"].ToString();
            MIS_INSURANCE_RATE = ds1.Rows[i]["MIS_INSURANCE_RATE"].ToString();

            MIS_INSURANCE_CURRENCY = ds1.Rows[i]["MIS_INSURANCE_CURRENCY"].ToString();
            MIS_INSURANCE_EXRATE = ds1.Rows[i]["MIS_INSURANCE_EXRATE"].ToString();
            SUPPLIER_COUNTRY_NAME = ds1.Rows[i]["SUPPLIER_COUNTRY_NAME"].ToString();
            SUPPLIER_COUNTRY_PINCODE = ds1.Rows[i]["SUPPLIER_COUNTRY_PINCODE"].ToString();
            if (INVOICE_DATE == "01/01/1900" || INVOICE_DATE == "01-01-1900")
                INVOICE_DATE = "";

            Invoice_value = INVOICE_VALUE + " " + INVOICE_CURRENCY;
            //----------------------------------------------------------------------------------------------------------------//

            if (MIS_FREIGHT_RATE != "")
            {
                //----------FOR CHECKLIST PURPOSE-------------//
                if (MIS_FREIGHT_RATE == "20.0000" || MIS_FREIGHT_RATE == "20.0")
                    MIS_FREIGHT_RATE = "20";
                //----------FOR CHECKLIST PURPOSE-------------//

                MIS_FREIGHT_CHARGES = MIS_FREIGHT_RATE + "%";
            }
            else
            {
                if (MIS_FREIGHT_CHARGES != "")
                {
                    MIS_FREIGHT_CHARGES = MIS_FREIGHT_CHARGES + " " + MIS_FREIGHT_CURRENCY + " " + MIS_FREIGHT_EXRATE;
                }
                else
                {

                    // MIS_FREIGHT_CHARGES = "20%";
                }
                MIS_FREIGHT_RATE = "20";
            }
            //----------------------------------------------------------------------------------------------------------------//
            if (MIS_INSURANCE_RATE != "")
            {
                MIS_INSURANCE_CHARGES = MIS_INSURANCE_RATE + "%";
            }


            else
            {
                if (MIS_INSURANCE_CHARGES != "")
                {
                    MIS_INSURANCE_CHARGES = MIS_INSURANCE_CHARGES + " " + MIS_INSURANCE_CURRENCY + " " + MIS_INSURANCE_EXRATE;
                    // MIS_FREIGHT_CHARGES = MIS_FREIGHT_CHARGES + " " + MIS_FREIGHT_CURRENCY + " " + MIS_FREIGHT_EXRATE;
                }
                else
                {

                    //MIS_INSURANCE_CHARGES = "1.125%";
                }
                MIS_INSURANCE_RATE = "1.125";

            }
            //----------------------------------------------------------------------------------------------------------------//

            SVB_ASSESABLE_RATE = ds1.Rows[i]["SVB_ASSESABLE_RATE"].ToString();
            SVB_ASSESABLE_STATUS = ds1.Rows[i]["SVB_ASSESABLE_STATUS"].ToString();
            SVB_DUTY_STATUS = ds1.Rows[i]["SVB_DUTY_STATUS"].ToString();
            SVB_DUTY_RATE = ds1.Rows[i]["SVB_DUTY_RATE"].ToString();
            SVB_CUSTOM_HOUSE = ds1.Rows[i]["SVB_CUSTOM_HOUSE"].ToString();
            if (SVB_ASSESABLE_RATE != "")
            {
                SVB_ASSESABLE_RATE = SVB_ASSESABLE_RATE + "%" + "(" + SVB_ASSESABLE_STATUS + ")";
            }
            else
            {
                SVB_ASSESABLE_RATE = "";
            }
            if (SVB_DUTY_RATE != "")
            {
                SVB_DUTY_RATE = SVB_DUTY_RATE + "%" + "(" + SVB_DUTY_STATUS + ")";
            }
            else
            {
                SVB_DUTY_RATE = "";
            }
            MIS_CHARGES = ds1.Rows[i]["MIS_CHARGES"].ToString();

            MIS_RATE = ds1.Rows[i]["MIS_RATE"].ToString();
            MIS_EXRATE = ds1.Rows[i]["MIS_EXRATE"].ToString();
            if (MIS_CHARGES == "")
            {
                MIS_CHARGES = "0";
            }
            if (MIS_EXRATE == "")
            {
                MIS_EXRATE = "0";
            }
            //double mis_charge = Convert.ToDouble(MIS_CHARGES);
            // double mis_rate = Convert.ToDouble(MIS_EXRATE);
            //double ttl = Convert.ToDouble(mis_charge) * Convert.ToDouble(mis_rate);
            //Total_Invoice = Convert.ToString(ttl);
            string MIS_CHARGES_Add = "";
            SupplierCountry_Name_Pincode = SUPPLIER_COUNTRY_NAME + " " + SUPPLIER_COUNTRY_PINCODE;
            if (MIS_CHARGES != "0")
            {
                MIS_CHARGES_Add = MIS_CHARGES + " " + MIS_CURRENCY + " " + MIS_EXRATE;
            }
            else
            {
                MIS_CHARGES_Add = "";
            }
            MIS_HIGHSEASALE_RATE = ds1.Rows[i]["MIS_HIGHSEASALE_RATE"].ToString();
            string MIS_Hss_RATE = MIS_HIGHSEASALE_RATE.Substring(0, 1);


            if (MIS_HIGHSEASALE_RATE != "" && MIS_Hss_RATE != "0")
            {
                MIS_HIGHSEASALE_RATE = MIS_HIGHSEASALE_RATE + "%";

            }
            else
            {
                MIS_HIGHSEASALE_RATE = "";
            }

            MIS_HIGHSEASALE_CHARGES = ds1.Rows[i]["MIS_HIGHSEASALE_CHARGES"].ToString();
            MIS_HIGHSEASALE_CURRENCY = ds1.Rows[i]["MIS_HIGHSEASALE_CURRENCY"].ToString();
            MIS_HIGHSEASALE_EXRATE = ds1.Rows[i]["MIS_HIGHSEASALE_EXRATE"].ToString();
            if (MIS_HIGHSEASALE_CHARGES != "")
            {
                MIS_HIGHSEASALE_CHARGES = MIS_HIGHSEASALE_CHARGES + " " + MIS_HIGHSEASALE_CURRENCY + " " + MIS_HIGHSEASALE_EXRATE;
            }
            else
            {
                MIS_HIGHSEASALE_CHARGES = "";
            }

            MIS_LOADING_CHARGES = ds1.Rows[i]["MIS_LOADING_CHARGES"].ToString();
            MIS_LOADING_CURRENCY = ds1.Rows[i]["MIS_LOADING_CURRENCY"].ToString();
            MIS_LOADING_EXRATE = ds1.Rows[i]["MIS_LOADING_EXRATE"].ToString();
            if (MIS_LOADING_CHARGES != "")
            {
                MIS_LOADING_CHARGES = MIS_LOADING_CHARGES + " " + MIS_LOADING_CURRENCY + " " + MIS_LOADING_EXRATE;
            }
            else
            {
                MIS_LOADING_CHARGES = "";
            }


            MIS_DISCOUNT_RATE = ds1.Rows[i]["MIS_DISCOUNT_RATE"].ToString();
            MIS_DISCOUNT_CHARGES = ds1.Rows[i]["MIS_DISCOUNT_CHARGES"].ToString();
            MIS_DISCOUNT_CURRENCY = ds1.Rows[i]["MIS_DISCOUNT_CURRENCY"].ToString();
            MIS_DISCOUNT_EXRATE = ds1.Rows[i]["MIS_DISCOUNT_EXRATE"].ToString();
            string MIS_Dscount_RATE = MIS_DISCOUNT_RATE.Substring(0, 1);

            if (MIS_DISCOUNT_RATE != "" && MIS_Dscount_RATE != "0")
            {
                MIS_DISCOUNT_RATE = MIS_DISCOUNT_RATE + "%";
            }
            else
            {
                MIS_DISCOUNT_RATE = "";
            }
            if (MIS_DISCOUNT_CHARGES != "")
            {
                MIS_DISCOUNT_CHARGES = MIS_DISCOUNT_CHARGES + " " + MIS_DISCOUNT_CURRENCY + " " + MIS_DISCOUNT_EXRATE;
            }
            else
            {
                MIS_DISCOUNT_CHARGES = "";
            }
            // ITem(ddlJobNo, i);
            INVOICE_EXRATE = ds1.Rows[i]["INVOICE_EXRATE"].ToString();
            // if (INVOICE_EXRATE != "")
            INVOICE_EXCHANGERATE = "1.00" + " " + INVOICE_CURRENCY + "=" + INVOICE_EXRATE + " " + "INR";
            ///else
            // INVOICE_EXRATE = "1.00" + " " + INVOICE_CURRENCY + "=" + "0" + " " + "INR";
            if (INVOICE_EXRATE == "")
            {
                INVOICE_EXRATE = "0.00";
            }
            if (INVOICE_VALUE == "")
            {
                INVOICE_VALUE = "0.00";
            }
            //Invoice Details
            INVOICE_ID = ds1.Rows[i]["INVOICE_ID"].ToString();


            list.Add(new INVOICE_DETAILS()
            {
                INVOICE_ID = INVOICE_ID,

                INVOICE_EXRATE = INVOICE_EXCHANGERATE,

                Invoice_Details = Convert.ToString(ds1.Rows.Count),
                FIRSTCHECK = FIRSTCHECK,
                GREEN_CHANNEL = GREEN_CHANNEL,
                KACHHA_BE = KACHHA_BE,
                SECTION48 = SECTION48,

                INVOICE_NO = ds1.Rows[i]["INVOICE_NO"].ToString(),
                INVOICE_DATE = INVOICE_DATE,
                INVOICE_VALUE = Invoice_value,
                TERMS = ds1.Rows[i]["TERMS"].ToString(),
                INVOICE_CURRENCY = ds1.Rows[i]["INVOICE_CURRENCY"].ToString(),
                SUPPLIER_NAME = ds1.Rows[i]["SUPPLIER_NAME"].ToString(),
                SUPPLIER_ADDRESS = ds1.Rows[i]["SUPPLIER_ADDRESS"].ToString(),
                SUPPLIER_ADDRESS1 = ds1.Rows[i]["SUPPLIER_ADDRESS1"].ToString(),
                SUPPLIER_ADDRESS2 = ds1.Rows[i]["SUPPLIER_ADDRESS2"].ToString(),
                SUPPLIER_COUNTRY_NAME = SupplierCountry_Name_Pincode,

                MIS_FREIGHT_CHARGES = MIS_FREIGHT_CHARGES,

                MIS_INSURANCE_CHARGES = MIS_INSURANCE_CHARGES,

                SVB_RELATION = ds1.Rows[i]["SVB_RELATION"].ToString(),
                SVB_REF_NO = ds1.Rows[i]["SVB_REF_NO"].ToString(),
                SVB_REF_DATE = ds1.Rows[i]["SVB_REF_DATE"].ToString(),

                SVB_ASSESABLE_RATE = SVB_ASSESABLE_RATE,
                SVB_DUTY_RATE = SVB_DUTY_RATE,

                SVB_CUSTOM_HOUSE = ds1.Rows[i]["SVB_CUSTOM_HOUSE"].ToString(),

                MIS_CHARGES_ = MIS_CHARGES,

                MIS_CHARGES = MIS_CHARGES_Add,
                MIS_RATE = ds1.Rows[i]["MIS_RATE"].ToString(),
                MIS_EXRATE = MIS_EXRATE,
                MIS_HIGHSEASALE_RATE = MIS_HIGHSEASALE_RATE,
                MIS_HIGHSEASALE_CHARGES = MIS_HIGHSEASALE_CHARGES,

                MIS_LOADING_CHARGES = MIS_LOADING_CHARGES,
                MIS_DISCOUNT_RATE = MIS_DISCOUNT_RATE,
                MIS_DISCOUNT_CHARGES = MIS_DISCOUNT_CHARGES,

                MIS_AGENCY_CHARGES = MIS_AGENCY_CHARGES,
                MIS_AGENCY_CURRENCY = MIS_AGENCY_CURRENCY,
                MIS_AGENCY_RATE = MIS_AGENCY_RATE,
                MIS_AGENCY_EXRATE = MIS_AGENCY_EXRATE

            });

            i++;

        }
        return list;
    }
}