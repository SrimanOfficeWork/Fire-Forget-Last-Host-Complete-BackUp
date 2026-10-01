using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for Rpt_Invoice_Details
/// </summary>
public class Rpt_Invoice_Details
{
    Export_CheckList CHKLIST = new Export_CheckList();

    #region Private_Attributes


    private string _INDIVIDUAL_INVOICE_VALUE;
    private string _INVOICE_SLNO;
    private string _INVOICE_NO;
    private string _INVOICE_DATE;
    private string _PAYMENT_METHOD;
    private string _PERIOD_PAYMENT;
    private string _INVOICE_VALUE;
    private string _INVOICE_CURRENCY;
    private string _EXCHANGE_RATE;
    private string _CONTRACT_NO;
    private string _TERMS;
    private string _BUYER;
    private string _BUYER_NAME;
    private string _BUYER_ADDRESS;
    private string _BUYER_ADDRESS1;
    private string _BUYER_ADDRESS2;
    private string _BUYER_ADDRESS3;
    private string _BUYER_ADDRESS4;
    private string _COMMISSION_RATE;
    private string _COMMISSION_CHARGES;
    private string _COMMISSION_CURRENCY;
    private string _FOB_RATE;
    private string _FOB_CHARGES;
    private string _FOB_CURRENCY;
    private string _PACKMISC_RATE;
    private string _PACKMISC_CHARGES;

    private string _PACKMISC_CURRENCY;
    private string _OTHER_DEDUCTION_RATE;
    private string _OTHER_DEDUCTION_CHARGES;
    private string _OTHER_DEDUCTION_CURRENCY;
    private string _FREIGHT_RATE;
    private string _FREIGHT_CHARGES;
    private string _FREIGHT_CURRENCY;

    private string _INSURANCE_RATE;
    private string _INSURANCE_CHARGES;
    private string _INSURANCE_CURRENCY;
    private string _WHEATHER_UNIT_PRICE;
    private string _No_Of_Invoices;

   
    #endregion



    #region Public_Attributes

    // Invoice Details

    public string INDIVIDUAL_INVOICE_VALUE { get { return _INDIVIDUAL_INVOICE_VALUE; } set { _INDIVIDUAL_INVOICE_VALUE = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_DATE { get { return _INVOICE_DATE; } set { _INVOICE_DATE = value; } }
    public string PAYMENT_METHOD { get { return _PAYMENT_METHOD; } set { _PAYMENT_METHOD = value; } }
    public string PERIOD_PAYMENT { get { return _PERIOD_PAYMENT; } set { _PERIOD_PAYMENT = value; } }
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }
    public string EXCHANGE_RATE { get { return _EXCHANGE_RATE; } set { _EXCHANGE_RATE = value; } }

    public string CONTRACT_NO { get { return _CONTRACT_NO; } set { _CONTRACT_NO = value; } }
    public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
    public string BUYER { get { return _BUYER; } set { _BUYER = value; } }
    public string BUYER_NAME { get { return _BUYER_NAME; } set { _BUYER_NAME = value; } }

    public string BUYER_ADDRESS { get { return _BUYER_ADDRESS; } set { _BUYER_ADDRESS = value; } }
    public string BUYER_ADDRESS1 { get { return _BUYER_ADDRESS1; } set { _BUYER_ADDRESS1 = value; } }
    public string BUYER_ADDRESS2 { get { return _BUYER_ADDRESS2; } set { _BUYER_ADDRESS2 = value; } }
    public string BUYER_ADDRESS3 { get { return _BUYER_ADDRESS3; } set { _BUYER_ADDRESS3 = value; } }
    public string BUYER_ADDRESS4 { get { return _BUYER_ADDRESS4; } set { _BUYER_ADDRESS4 = value; } }
    public string COMMISSION_RATE { get { return _COMMISSION_RATE; } set { _COMMISSION_RATE = value; } }
    public string COMMISSION_CHARGES { get { return _COMMISSION_CHARGES; } set { _COMMISSION_CHARGES = value; } }
    public string COMMISSION_CURRENCY { get { return _COMMISSION_CURRENCY; } set { _COMMISSION_CURRENCY = value; } }
    public string FOB_RATE { get { return _FOB_RATE; } set { _FOB_RATE = value; } }
    public string FOB_CHARGES { get { return _FOB_CHARGES; } set { _FOB_CHARGES = value; } }

    public string FOB_CURRENCY { get { return _FOB_CURRENCY; } set { _FOB_CURRENCY = value; } }
    public string PACKMISC_RATE { get { return _PACKMISC_RATE; } set { _PACKMISC_RATE = value; } }
    public string PACKMISC_CHARGES { get { return _PACKMISC_CHARGES; } set { _PACKMISC_CHARGES = value; } }
    public string PACKMISC_CURRENCY { get { return _PACKMISC_CURRENCY; } set { _PACKMISC_CURRENCY = value; } }
    public string OTHER_DEDUCTION_RATE { get { return _OTHER_DEDUCTION_RATE; } set { _OTHER_DEDUCTION_RATE = value; } }
    public string OTHER_DEDUCTION_CHARGES { get { return _OTHER_DEDUCTION_CHARGES; } set { _OTHER_DEDUCTION_CHARGES = value; } }
    public string OTHER_DEDUCTION_CURRENCY { get { return _OTHER_DEDUCTION_CURRENCY; } set { _OTHER_DEDUCTION_CURRENCY = value; } }
    public string FREIGHT_RATE { get { return _FREIGHT_RATE; } set { _FREIGHT_RATE = value; } }
    public string FREIGHT_CHARGES { get { return _FREIGHT_CHARGES; } set { _FREIGHT_CHARGES = value; } }
    public string FREIGHT_CURRENCY { get { return _FREIGHT_CURRENCY; } set { _FREIGHT_CURRENCY = value; } }
    public string INSURANCE_RATE { get { return _INSURANCE_RATE; } set { _INSURANCE_RATE = value; } }
    public string INSURANCE_CHARGES { get { return _INSURANCE_CHARGES; } set { _INSURANCE_CHARGES = value; } }
    public string INSURANCE_CURRENCY { get { return _INSURANCE_CURRENCY; } set { _INSURANCE_CURRENCY = value; } }
    public string WHEATHER_UNIT_PRICE { get { return _WHEATHER_UNIT_PRICE; } set { _WHEATHER_UNIT_PRICE = value; } }

    public string No_Of_Invoices { get { return _No_Of_Invoices; } set { _No_Of_Invoices = value; } }

   
    #endregion



    public List<Rpt_Invoice_Details> Get_Invoice_Details(string ddlJobNo,DataTable ds1)
    {
        List<Rpt_Invoice_Details> list = new List<Rpt_Invoice_Details>();
       
       
        int i = 0;
        //foreach (DataRow dRows in ds1.Rows)
        while (ds1.Rows.Count > i)
        //for (i = 0; i < ds1.Rows.Count; i++)
        {

            //INVOICE_SLNO = ds1.Rows[i]["INVOICE_SLNO"].ToString();
            //INVOICE_NO = ds1.Rows[i]["INVOICE_NO"].ToString();

            //INVOICE_DATE = ds1.Rows[i]["INVOICE_DATE"].ToString();
            //INVOICE_VALUE = ds1.Rows[i]["INVOICE_VALUE"].ToString();
            //INVOICE_CURRENCY = ds1.Rows[i]["INVOICE_CURRENCY"].ToString();
            //MIS_FREIGHT_CHARGES = ds1.Rows[i]["MIS_FREIGHT_CHARGES"].ToString();
            //MIS_FREIGHT_RATE = ds1.Rows[i]["MIS_FREIGHT_RATE"].ToString();
            //MIS_FREIGHT_CURRENCY = ds1.Rows[i]["MIS_FREIGHT_CURRENCY"].ToString();
            //MIS_FREIGHT_EXRATE = ds1.Rows[i]["MIS_FREIGHT_EXRATE"].ToString();
            //MIS_INSURANCE_CHARGES = ds1.Rows[i]["MIS_INSURANCE_CHARGES"].ToString();
            //MIS_INSURANCE_RATE = ds1.Rows[i]["MIS_INSURANCE_RATE"].ToString();

            //MIS_INSURANCE_CURRENCY = ds1.Rows[i]["MIS_INSURANCE_CURRENCY"].ToString();
            //MIS_INSURANCE_EXRATE = ds1.Rows[i]["MIS_INSURANCE_EXRATE"].ToString();
            //SUPPLIER_COUNTRY_NAME = ds1.Rows[i]["SUPPLIER_COUNTRY_NAME"].ToString();
            //SUPPLIER_COUNTRY_PINCODE = ds1.Rows[i]["SUPPLIER_COUNTRY_PINCODE"].ToString();
            //if (INVOICE_DATE == "01/01/1900" || INVOICE_DATE == "01-01-1900")
            //    INVOICE_DATE = "";

            //Invoice_value = INVOICE_VALUE + " " + INVOICE_CURRENCY;
            COMMISSION_RATE = ds1.Rows[i]["COMMISSION_RATE"].ToString();

                COMMISSION_CHARGES = ds1.Rows[i]["COMMISSION_CHARGES"].ToString();
           
                PACKMISC_RATE = ds1.Rows[i]["PACKMISC_RATE"].ToString();

                PACKMISC_CHARGES = ds1.Rows[i]["PACKMISC_CHARGES"].ToString();
           
                OTHER_DEDUCTION_RATE = ds1.Rows[i]["OTHER_DEDUCTION_RATE"].ToString();
                OTHER_DEDUCTION_CHARGES = ds1.Rows[i]["OTHER_DEDUCTION_CHARGES"].ToString();
              
                FREIGHT_RATE = ds1.Rows[i]["FREIGHT_RATE"].ToString();
                FREIGHT_CHARGES = ds1.Rows[i]["FREIGHT_CHARGES"].ToString();
            
                INSURANCE_RATE = ds1.Rows[i]["INSURANCE_RATE"].ToString();

                INSURANCE_CHARGES = ds1.Rows[i]["INSURANCE_CHARGES"].ToString();
              FREIGHT_CURRENCY = ds1.Rows[i]["FREIGHT_CURRENCY"].ToString();

              INSURANCE_CURRENCY = ds1.Rows[i]["INSURANCE_CURRENCY"].ToString();
              TERMS = ds1.Rows[i]["TERMS"].ToString();
            if (INSURANCE_RATE == "")
                INSURANCE_RATE = "0.00";
            if (FREIGHT_RATE == "")
                FREIGHT_RATE = "0.00";
            if (COMMISSION_RATE == "")
                COMMISSION_RATE = "0.00";
            if (OTHER_DEDUCTION_RATE == "")
                OTHER_DEDUCTION_RATE = "0.00";
            if (PACKMISC_RATE == "")
                PACKMISC_RATE = "0.00";

            if (INSURANCE_CHARGES == "")
                INSURANCE_CHARGES = "0.00";
            if (FREIGHT_CHARGES == "")
                FREIGHT_CHARGES = "0.00";
            if (COMMISSION_CHARGES == "")
                COMMISSION_CHARGES = "0.00";
            if (OTHER_DEDUCTION_CHARGES == "")
                OTHER_DEDUCTION_CHARGES = "0.00";
            if (PACKMISC_CHARGES == "")
                PACKMISC_CHARGES = "0.00";
            if (TERMS == "CF")
            {
                
                INSURANCE_CURRENCY = "INR";

            }
            else if (TERMS == "CI")
            {
                
                FREIGHT_CURRENCY = "INR";

            }

            list.Add(new Rpt_Invoice_Details()
            {
                No_Of_Invoices = Convert.ToString(ds1.Rows.Count),

                INVOICE_SLNO = ds1.Rows[i]["INVOICE_SLNO"].ToString(),

                INVOICE_NO = ds1.Rows[i]["INVOICE_NO"].ToString(),


                INVOICE_DATE = ds1.Rows[i]["INVOICE_DATE"].ToString(),
                PAYMENT_METHOD = ds1.Rows[i]["PAYMENT_METHOD"].ToString(),
                PERIOD_PAYMENT = ds1.Rows[i]["PERIOD_PAYMENT"].ToString(),
                INVOICE_VALUE = ds1.Rows[i]["INVOICE_VALUE"].ToString(),

                INVOICE_CURRENCY = ds1.Rows[i]["INVOICE_CURRENCY"].ToString(),
                EXCHANGE_RATE = ds1.Rows[i]["EXCHANGE_RATE"].ToString(),
                CONTRACT_NO = ds1.Rows[i]["CONTRACT_NO"].ToString(),
                TERMS = TERMS,
                BUYER = ds1.Rows[i]["BUYER"].ToString(),
                BUYER_NAME = ds1.Rows[i]["BUYER_NAME"].ToString(),
                BUYER_ADDRESS = ds1.Rows[i]["BUYER_ADDRESS"].ToString(),
                BUYER_ADDRESS1 = ds1.Rows[i]["BUYER_ADDRESS1"].ToString(),
                BUYER_ADDRESS2 = ds1.Rows[i]["BUYER_ADDRESS2"].ToString(),
                BUYER_ADDRESS3 = ds1.Rows[i]["BUYER_ADDRESS3"].ToString(),

                BUYER_ADDRESS4 = ds1.Rows[i]["BUYER_ADDRESS4"].ToString(),

                COMMISSION_RATE = COMMISSION_RATE,

                COMMISSION_CHARGES = COMMISSION_CHARGES,
                COMMISSION_CURRENCY = ds1.Rows[i]["COMMISSION_CURRENCY"].ToString(),

                FOB_RATE = ds1.Rows[i]["FOB_RATE"].ToString(),
                FOB_CHARGES = ds1.Rows[i]["FOB_CHARGES"].ToString(),

                FOB_CURRENCY = ds1.Rows[i]["FOB_CURRENCY"].ToString(),

                PACKMISC_RATE = PACKMISC_RATE,

                PACKMISC_CHARGES = PACKMISC_CHARGES,
                PACKMISC_CURRENCY = ds1.Rows[i]["PACKMISC_CURRENCY"].ToString(),
                OTHER_DEDUCTION_RATE = OTHER_DEDUCTION_RATE,
                OTHER_DEDUCTION_CHARGES = OTHER_DEDUCTION_CHARGES,
                OTHER_DEDUCTION_CURRENCY = ds1.Rows[i]["OTHER_DEDUCTION_CURRENCY"].ToString(),

                FREIGHT_RATE = FREIGHT_RATE,
                FREIGHT_CHARGES = FREIGHT_CHARGES,
                FREIGHT_CURRENCY = FREIGHT_CURRENCY,



                INSURANCE_RATE = INSURANCE_RATE,

                INSURANCE_CHARGES = INSURANCE_CHARGES,
                INSURANCE_CURRENCY = INSURANCE_CURRENCY,
                WHEATHER_UNIT_PRICE = ds1.Rows[i]["WHEATHER_UNIT_PRICE"].ToString()
            });
           
            i++;
          
        }
        return list;
       
    }
}
