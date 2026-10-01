using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for ITEM_DETAILS
/// </summary>
public class ITEM_DETAILS
{
    #region Private_Attributes
    private string _INVOICE_SLNO;
    private string _INVOICE_NO, _INVOICE_NO_ITEM, _Invoice_No, _Invoice_Details;

    private string _INVOICE_VALUE, _Invoice_value, _INVOICE_EXRATE;
    private string _MIS_FREIGHT_RATE;
   
    private string _MIS_INSURANCE_RATE;
   
    private string _IGM_TRANSPORTMODE;
    private string _PORT_ORIGIN;
    private string _Country_Origin;
    private string _Country_Shipment;
    //item Details
    private string _ITEM_SLNO;
    private string _ITEM_DESCRIPTION;
    private string _ITEM_QTY;
    private string _ITEM_QTY_CODE;
    private string _ITEM_UNIT_PRICE;

    private string _SCHEME_CODE, _SCHEME;
    private string _SCHEME_NOTN;
    private string _SCHEME_NOTN_SLNO;

    private string _PRODUCT_RITC;
    private string _PRODUCT_CTH;

    private string _PRODUCT_CVD_RATE, _PRODUCT_CVD_NOTN, _PRODUCT_CVD_NOTN_SLNO;
    private string _PRODUCT_EDU_CESS_RATE;
    private string _PRODUCT_SEC_EDU_CESS_RATE;

    private string _PRODUCT_BCD_RATE, _PRODUCT_BCD_NOTN, _PRODUCT_ADDL_DUTY_NOTN, _ADDTIONAL_DUTY_RATE,_PRODUCT_ADDL_DUTY_RATE,_PRODUCT_SEC_EDU_CESS_NOTN, _PRODUCT_EDU_CESS_NOTN, _EXCEMPTION, _INVOICE_CURRENCY, _Invoice_Currency;

    private string _PRODUCT_CETH, _ADDTIONAL_DUTY, _BASIC_DUTY_TOATAL, _CVD_TOTAL, _CEC_TOTAL, _CHEC_TOTAL, _ADDLTIONAL_DUTY_TOTAL, _TOTAL_ITEM_DUTY, _NUMBERTOWORDS;
    private string _PRODUCT_BCD_NOTN_SLNO, _PRODUCT_ADDL_DUTY_NOTN_SLNO, _PRODUCT_SEC_EDU_CESS_NOTN_SLNO, _PRODUCT_EDU_CESS_NOTN_SLNO;
    private double _ASSESABLE_VALUE, _ASSESSABLE_TOTAL, _ITEM_TOTAL;
    public string PRODUCT_BCD_NOTN_SLNO { get { return _PRODUCT_BCD_NOTN_SLNO; } set { _PRODUCT_BCD_NOTN_SLNO = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN_SLNO { get { return _PRODUCT_ADDL_DUTY_NOTN_SLNO; } set { _PRODUCT_ADDL_DUTY_NOTN_SLNO = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_SEC_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_SEC_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_EDU_CESS_NOTN_SLNO { get { return _PRODUCT_EDU_CESS_NOTN_SLNO; } set { _PRODUCT_EDU_CESS_NOTN_SLNO = value; } }
    public string PRODUCT_CVD_NOTN_SLNO { get { return _PRODUCT_CVD_NOTN_SLNO; } set { _PRODUCT_CVD_NOTN_SLNO = value; } }
  
    
    
   
    #endregion
    #region Public_Attributes
    //public double ;
    public double BASIC_DUTY, CVD, Customs_Edu_Cess, Customs_Higher_Edu_Cess, AddL_DUTY, TOTAL_DUTY = 0.0;
    public string SCHEME_NOTN_ = "";
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string INVOICE_NO_ITEM { get { return _INVOICE_NO_ITEM; } set { _INVOICE_NO_ITEM = value; } }
    public string Invoice_No { get { return _Invoice_No; } set { _Invoice_No = value; } }
    public string Invoice_Details { get { return _Invoice_Details; } set { _Invoice_Details = value; } }
   
    public string EXCEMPTION { get { return _EXCEMPTION; } set { _EXCEMPTION = value; } }

    
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }
    public string Invoice_value { get { return _Invoice_value; } set { _Invoice_value = value; } }
   
    public string INVOICE_CURRENCY { get { return _INVOICE_CURRENCY; } set { _INVOICE_CURRENCY = value; } }
    public string INVOICE_EXRATE { get { return _INVOICE_EXRATE; } set { _INVOICE_EXRATE = value; } }
    public string Invoice_Currency { get { return _Invoice_Currency; } set { _Invoice_Currency = value; } }

    public string MIS_FREIGHT_RATE { get { return _MIS_FREIGHT_RATE; } set { _MIS_FREIGHT_RATE = value; } }
    public string MIS_INSURANCE_RATE { get { return _MIS_INSURANCE_RATE; } set { _MIS_INSURANCE_RATE = value; } }
    public string IGM_TRANSPORTMODE { get { return _IGM_TRANSPORTMODE; } set { _IGM_TRANSPORTMODE = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }
    public string Country_Origin { get { return _Country_Origin; } set { _Country_Origin = value; } }
    public string Country_Shipment { get { return _Country_Shipment; } set { _Country_Shipment = value; } }
    //ITEM DETAILS
   
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
    public string SCHEME { get { return _SCHEME; } set { _SCHEME = value; } }

    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string SCHEME_NOTN { get { return _SCHEME_NOTN; } set { _SCHEME_NOTN = value; } }
    public string SCHEME_NOTN_SLNO { get { return _SCHEME_NOTN_SLNO; } set { _SCHEME_NOTN_SLNO = value; } }

    public string PRODUCT_RITC { get { return _PRODUCT_RITC; } set { _PRODUCT_RITC = value; } }
    public string PRODUCT_CTH { get { return _PRODUCT_CTH; } set { _PRODUCT_CTH = value; } }

    public string PRODUCT_CVD_RATE { get { return _PRODUCT_CVD_RATE; } set { _PRODUCT_CVD_RATE = value; } }
    public string PRODUCT_EDU_CESS_RATE { get { return _PRODUCT_EDU_CESS_RATE; } set { _PRODUCT_EDU_CESS_RATE = value; } }
    public string PRODUCT_EDU_CESS_NOTN { get { return _PRODUCT_EDU_CESS_NOTN; } set { _PRODUCT_EDU_CESS_NOTN = value; } }
    public string PRODUCT_SEC_EDU_CESS_NOTN { get { return _PRODUCT_SEC_EDU_CESS_NOTN; } set { _PRODUCT_SEC_EDU_CESS_NOTN = value; } }

    public string PRODUCT_SEC_EDU_CESS_RATE { get { return _PRODUCT_SEC_EDU_CESS_RATE; } set { _PRODUCT_SEC_EDU_CESS_RATE = value; } }

    public string PRODUCT_BCD_NOTN { get { return _PRODUCT_BCD_NOTN; } set { _PRODUCT_BCD_NOTN = value; } }
    public string PRODUCT_BCD_RATE { get { return _PRODUCT_BCD_RATE; } set { _PRODUCT_BCD_RATE = value; } }
    public string PRODUCT_CVD_NOTN { get { return _PRODUCT_CVD_NOTN; } set { _PRODUCT_CVD_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_NOTN { get { return _PRODUCT_ADDL_DUTY_NOTN; } set { _PRODUCT_ADDL_DUTY_NOTN = value; } }
    public string PRODUCT_ADDL_DUTY_RATE { get { return _PRODUCT_ADDL_DUTY_RATE; } set { _PRODUCT_ADDL_DUTY_RATE = value; } }

    public string PRODUCT_CETH { get { return _PRODUCT_CETH; } set { _PRODUCT_CETH = value; } }

    public double ASSESABLE_VALUE { get { return _ASSESABLE_VALUE; } set { _ASSESABLE_VALUE = value; } }
    public string ADDTIONAL_DUTY { get { return _ADDTIONAL_DUTY; } set { _ADDTIONAL_DUTY = value; } }
    public string ADDTIONAL_DUTY_RATE { get { return _ADDTIONAL_DUTY_RATE; } set { _ADDTIONAL_DUTY_RATE = value; } }

    public string BASIC_DUTY_TOTAL { get { return _BASIC_DUTY_TOATAL; } set { _BASIC_DUTY_TOATAL = value; } }
    public string CVD_TOTAL { get { return _CVD_TOTAL; } set { _CVD_TOTAL = value; } }
    public string CEC_TOTAL { get { return _CEC_TOTAL; } set { _CEC_TOTAL = value; } }
    public string CHEC_TOTAL { get { return _CHEC_TOTAL; } set { _CHEC_TOTAL = value; } }
    public string ADDLTIONAL_DUTY_TOTAL { get { return _ADDLTIONAL_DUTY_TOTAL; } set { _ADDLTIONAL_DUTY_TOTAL = value; } }
    public string TOTAL_ITEM_DUTY { get { return _TOTAL_ITEM_DUTY; } set { _TOTAL_ITEM_DUTY = value; } }
    public string NUMBERTOWORDS { get { return _NUMBERTOWORDS; } set { _NUMBERTOWORDS = value; } }
    public double ASSESSABLE_TOTAL { get { return _ASSESSABLE_TOTAL; } set { _ASSESSABLE_TOTAL = value; } }
    public double ITEM_TOTAL { get { return _ITEM_TOTAL; } set { _ITEM_TOTAL = value; } }
    
    #endregion



    public List<ITEM_DETAILS> Get_ITEM_Details(string ddlJobNo, DataTable ds, DataTable ds2,DataTable ds3)
    {

        List<ITEM_DETAILS> list1 = new List<ITEM_DETAILS>();
        list1.Clear();
        

        int b = 0, C = 0;

        double salary = 0.0;
        double salary1 = 0.0;
        double TOTAL_ITEM = 0.0;
     
        string preINVOICE_SLNO = "0", curINVOICE_SLNO = "0";
        while (ds.Rows.Count > C)
        {
            NUMBERTOWORDS = "";
            curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
            INVOICE_VALUE = ds.Rows[C]["INVOICE_VALUE"].ToString();
            INVOICE_EXRATE = ds.Rows[C]["INVOICE_EXRATE"].ToString();
            MIS_FREIGHT_RATE = ds.Rows[C]["MIS_FREIGHT_RATE"].ToString();
            MIS_INSURANCE_RATE = ds.Rows[C]["MIS_INSURANCE_RATE"].ToString();
            if (INVOICE_VALUE == "")
                INVOICE_VALUE = "0.00";
            if (INVOICE_EXRATE == "")
                INVOICE_EXRATE = "0.00";
            if (MIS_FREIGHT_RATE == "")
                MIS_FREIGHT_RATE = "0.00";
            if (MIS_INSURANCE_RATE == "")
                MIS_INSURANCE_RATE = "0.00";
            ASSESSABLE_TOTAL = 0;
            TOTAL_ITEM = 0.0;
            TOTAL_DUTY = 0.0;
            b = 0;
            
            DataView view = ds2.DefaultView;
            view.RowFilter = "INVOICE_SLNO = " + curINVOICE_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            while (dss.Tables[0].Rows.Count > b)
            {

                INVOICE_NO_ITEM = dss.Tables[0].Rows[b]["INVOICE_NO"].ToString();
                INVOICE_SLNO = dss.Tables[0].Rows[b]["INVOICE_SLNO"].ToString();
                ITEM_SLNO = dss.Tables[0].Rows[b]["ITEM_SLNO"].ToString();
                ITEM_DESCRIPTION = dss.Tables[0].Rows[b]["ITEM_DESCRIPTION"].ToString();
                ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();
                ITEM_QTY_CODE = dss.Tables[0].Rows[b]["ITEM_QTY_CODE"].ToString();
                ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();
                PRODUCT_RITC = dss.Tables[0].Rows[b]["PRODUCT_RITC"].ToString();
                PRODUCT_CTH = dss.Tables[0].Rows[b]["PRODUCT_CTH"].ToString();
                PRODUCT_CVD_RATE = dss.Tables[0].Rows[b]["PRODUCT_CVD_RATE"].ToString();
                PRODUCT_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_RATE"].ToString();

                PRODUCT_SEC_EDU_CESS_RATE = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();
                PRODUCT_SEC_EDU_CESS_NOTN = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();

                PRODUCT_SEC_EDU_CESS_NOTN_SLNO  = dss.Tables[0].Rows[b]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();

                PRODUCT_BCD_RATE = dss.Tables[0].Rows[b]["PRODUCT_BCD_RATE"].ToString();
                PRODUCT_CETH = dss.Tables[0].Rows[b]["PRODUCT_CETH"].ToString();
                PRODUCT_BCD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_BCD_NOTN"].ToString();
                PRODUCT_BCD_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_BCD_SLNO"].ToString();

                PRODUCT_CVD_NOTN = dss.Tables[0].Rows[b]["PRODUCT_CVD_NOTN"].ToString();
                PRODUCT_CVD_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_CVD_SLNO"].ToString();
                PRODUCT_EDU_CESS_NOTN = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_NOTN"].ToString();
                PRODUCT_EDU_CESS_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                PRODUCT_ADDL_DUTY_NOTN = dss.Tables[0].Rows[b]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                PRODUCT_ADDL_DUTY_NOTN_SLNO = dss.Tables[0].Rows[b]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
                PRODUCT_ADDL_DUTY_RATE = dss.Tables[0].Rows[b]["PRODUCT_ADDL_DUTY_RATE"].ToString();

                SCHEME_CODE = dss.Tables[0].Rows[b]["SCHEME_CODE"].ToString();
                SCHEME_NOTN = dss.Tables[0].Rows[b]["SCHEME_NOTN"].ToString();
                SCHEME_NOTN_SLNO = dss.Tables[0].Rows[b]["SCHEME_NOTN_SLNO"].ToString();
                if (PRODUCT_BCD_NOTN != "")
                    PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN + " " + PRODUCT_BCD_NOTN_SLNO;
                if (PRODUCT_CVD_NOTN != "")
                    PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN + " " + PRODUCT_CVD_NOTN_SLNO;
                if (PRODUCT_EDU_CESS_NOTN != "")
                    PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN + " " + PRODUCT_EDU_CESS_NOTN_SLNO;
                if (PRODUCT_SEC_EDU_CESS_NOTN != "")
                    PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN + " " + PRODUCT_SEC_EDU_CESS_NOTN_SLNO;
                if (PRODUCT_ADDL_DUTY_NOTN != "")
                    PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN + " " + PRODUCT_ADDL_DUTY_NOTN_SLNO;
                if (SCHEME_CODE != "")
                {
                    string[] s1 = SCHEME_CODE.Split(new string[] { "-" }, StringSplitOptions.None);
                    SCHEME_CODE = s1[0].ToString();
                    SCHEME_NOTN_ = s1[1].ToString();
                }
                else
                {
                    SCHEME_NOTN_ = "0";
                }
                // --------------------------------------- ITEM CALCULATION---------------------------------------------------------------

                double INV_EXRATE = Convert.ToDouble(INVOICE_VALUE) * Convert.ToDouble(INVOICE_EXRATE);
                double FRIEGHT_EXRATE = INV_EXRATE * Convert.ToDouble(MIS_FREIGHT_RATE) / 100;
                double INSURANCE_EXRATE = INV_EXRATE * Convert.ToDouble(MIS_INSURANCE_RATE) / 100;

                double TOTAL = INV_EXRATE + FRIEGHT_EXRATE + INSURANCE_EXRATE;
                double LANDING_CHARGE = TOTAL * 1 / 100;
                double ASSESABLE_VALUE = TOTAL + LANDING_CHARGE;
                ASSESSABLE_TOTAL = ASSESSABLE_TOTAL + ASSESABLE_VALUE;
                //------------------------------------------SCHEME_NOTNCALCULATION---------------------------------------------------------------//


                if (PRODUCT_BCD_RATE == "")
                {
                    PRODUCT_BCD_RATE = "0.00";
                }
                if (PRODUCT_CVD_RATE == "")
                {
                    PRODUCT_CVD_RATE = "0.00";

                }
                if (PRODUCT_EDU_CESS_RATE == "")
                {
                    PRODUCT_EDU_CESS_RATE = "2.00";
                }
                if (PRODUCT_SEC_EDU_CESS_RATE == "")
                {
                    PRODUCT_SEC_EDU_CESS_RATE = "1.00";
                }
                if (PRODUCT_ADDL_DUTY_NOTN == "" || PRODUCT_ADDL_DUTY_NOTN == "019/2006")
                {

                    PRODUCT_ADDL_DUTY_NOTN = "019/2006";
                    PRODUCT_ADDL_DUTY_NOTN_SLNO = "4";
                    ADDTIONAL_DUTY_RATE = ADDTIONAL_DUTY = PRODUCT_ADDL_DUTY_RATE="4.00";
                }
                else if (PRODUCT_ADDL_DUTY_NOTN != "019/2006")
                {
                    if (PRODUCT_ADDL_DUTY_RATE == "")
                    {
                        ADDTIONAL_DUTY_RATE = ADDTIONAL_DUTY = "0.00";
                    }
                    else 
                    {
                        ADDTIONAL_DUTY_RATE = ADDTIONAL_DUTY = PRODUCT_ADDL_DUTY_RATE;

                    }
                }
               
                string f = "";
                string[] arr = { "DEEC", "REP", "DIL", "JBG", "EOU", "DUTIABLE" };
                string[] arr1 = { "DEPB", "DFRC", "DFCC", "TRG+", "(KRSH)", "DFCS", "DFIA", "FMS", "FPS", "SHIS" };
                string[] arr2 = { "EPCG"};

               
                if (SCHEME_NOTN_ != "")
                {
                    if (SCHEME_NOTN_ != "0")
                    {

                        string value1 = Array.Find(arr, element => element.StartsWith(SCHEME_NOTN_, StringComparison.Ordinal));

                        if (SCHEME_NOTN_.Trim() == "DUTIABLE")
                        {
                            value1 = "";
                            SCHEME_NOTN_ = "";
                        }
                       
                        if (SCHEME_NOTN_ == value1)
                        {
                           
                            if ("DEEC" == value1 || "" == value1 )//this code for to check scheme 00-Dutiable)
                            {
                                DataView view1 = ds3.DefaultView;
                                view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                                DataTable table1 = view1.ToTable();
                                DataSet dss1 = new DataSet();
                                dss1.Tables.Add(table1);
                                //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//

                                if (dss1.Tables[0].Rows.Count > 0)
                                {
                                    EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();
                                    if (EXCEMPTION == "Y")
                                    {
                                        BASIC_DUTY = 0.00;
                                        CVD = 0.00;
                                        Customs_Edu_Cess = 0.00;
                                        Customs_Higher_Edu_Cess = 0.00;
                                        AddL_DUTY = 0.00;
                                        BASIC_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(BASIC_DUTY).ToString("F"));
                                        CVD_TOTAL = Convert.ToString(Convert.ToDouble(CVD).ToString("F"));
                                        CEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Edu_Cess).ToString("F"));
                                        CHEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Higher_Edu_Cess).ToString("F"));
                                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(AddL_DUTY).ToString("F"));

                                    }
                                }
                                //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//


                                else
                                {
                                    
                                    DataSet ds1 = new DataSet();
                                    if (PRODUCT_BCD_RATE == "" || PRODUCT_BCD_RATE == "0.00")
                                    {
                                        adminmaster adm = new adminmaster();
                                        adm.SCHEME_IMPORT_CODE = PRODUCT_CTH;
                                        adm.SCHEME_IMPORT_NAME = "";
                                        adm.SCHEME_NOTN = "";
                                        adm.SCHEME_NOTN_SLNO = "";
                                        adm.Name = "CTH_NOTN_RATE";
                                        
                                        ds1 = adm.RetrieveAll_CheckList_Scheme_Import();
                                        //------------------------------------------DATA FETCH FROM CTH MASTER------------------------------------------//
                                        if (ds1.Tables[0].Rows.Count > 0)
                                        {
                                            string CTH_Rate = ds1.Tables[0].Rows[0]["CTH_RATE"].ToString();
                                            double CTH_Rate1 = Convert.ToDouble(CTH_Rate);
                                            PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(CTH_Rate1).ToString("F"));
                                        }
                                        //------------------------------------------DATA FETCH FROM CTH MASTER------------------------------------------//
                                    }
                                    


                                    if (PRODUCT_CVD_RATE == "" || PRODUCT_CVD_RATE == "0.00")
                                    {
                                        //------------------------------------------DATA FETCH FROM CETH MASTER------------------------------------------//
                                        if (ds1.Tables[1].Rows.Count > 0)
                                        {
                                            string CETH_Rate = ds1.Tables[1].Rows[0]["CETH_ADDITIONAL_CVD_S_RATE"].ToString();
                                            double CETH_Rate1 = Convert.ToDouble(CETH_Rate);
                                            PRODUCT_CVD_RATE = Convert.ToString(Convert.ToDouble(CETH_Rate1).ToString("F"));
                                        }
                                        //------------------------------------------DATA FETCH FROM CETH MASTER------------------------------------------//
                                    }
                                    if (PRODUCT_ADDL_DUTY_RATE == "" || PRODUCT_ADDL_DUTY_RATE == "0.00")
                                    {
                                        adminmaster adm = new adminmaster();
                                        adm.SCHEME_IMPORT_CODE = PRODUCT_ADDL_DUTY_NOTN;
                                        adm.SCHEME_IMPORT_NAME = "";
                                        adm.SCHEME_NOTN = "";
                                        adm.SCHEME_NOTN_SLNO = "";
                                        adm.Name = "ADDL_DUTY_RATE";

                                        ds1 = adm.RetrieveAll_CheckList_Scheme_Import();
                                        //------------------------------------------DATA FETCH FROM NOTIFICATION_CUSTOMS MASTER------------------------------------------//
                                        if (ds1.Tables[0].Rows.Count > 0)
                                        {
                                            string ADDL_DUTY_RATE = ds1.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                                            double ADDL_DUTY_RATE1 = Convert.ToDouble(ADDL_DUTY_RATE);
                                            ADDTIONAL_DUTY_RATE = ADDTIONAL_DUTY_RATE = Convert.ToString(Convert.ToDouble(ADDL_DUTY_RATE1).ToString("F"));
                                        }
                                        //------------------------------------------DATA FETCH FROM NOTIFICATION_CUSTOMS MASTER------------------------------------------//
                                        
                                    }
                                  

                                    BASIC_DUTY = Math.Round(ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100,2);



                                    CVD = Math.Round((ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100, 2);


                                    Customs_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100, 2);


                                    Customs_Higher_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100, 2);
                                    AddL_DUTY = Math.Round((ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100, 2);
                               
                                    TOTAL_DUTY = Math.Round((BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY), 2);




                                    BASIC_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(BASIC_DUTY).ToString("F"));
                                    CVD_TOTAL = Convert.ToString(Convert.ToDouble(CVD).ToString("F"));
                                    CEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Edu_Cess).ToString("F"));
                                    CHEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Higher_Edu_Cess).ToString("F"));
                                    ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(AddL_DUTY).ToString("F"));
                                }
                            }
                            else
                            {
                                BASIC_DUTY = 0.00;
                                CVD = 0.00;
                                Customs_Edu_Cess = 0.00;
                                Customs_Higher_Edu_Cess = 0.00;
                                AddL_DUTY = 0.00;
                                BASIC_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(BASIC_DUTY).ToString("F"));
                                CVD_TOTAL = Convert.ToString(Convert.ToDouble(CVD).ToString("F"));
                                CEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Edu_Cess).ToString("F"));
                                CHEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Higher_Edu_Cess).ToString("F"));
                                ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(AddL_DUTY).ToString("F"));
                            }
                        }
                       
                        else if (SCHEME_NOTN_ == "EPCG")
                        {
                            adminmaster adm = new adminmaster();
                            adm.SCHEME_IMPORT_CODE = SCHEME_CODE;
                            adm.SCHEME_IMPORT_NAME = SCHEME_NOTN_;
                            adm.SCHEME_NOTN = SCHEME_NOTN;
                            adm.SCHEME_NOTN_SLNO = SCHEME_NOTN_SLNO;
                            adm.Name = "SCHEME_NOTN_RATE";
                            DataSet ds1 = new DataSet();
                            ds1 = adm.RetrieveAll_CheckList_Scheme_Import();
                            //------------------------------------------DATA FETCH FROM SCHEME IMPORT MASTER------------------------------------------//

                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                string SCHEME_Rate = ds1.Tables[0].Rows[0]["SCHEME_RATE"].ToString();
                                double SCHEME_Rate1 = Convert.ToDouble(SCHEME_Rate);
                                PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(SCHEME_Rate1).ToString("F"));
                                BASIC_DUTY = Math.Round(ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100, 2);



                                CVD = Math.Round((ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100, 2);


                                Customs_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100, 2);


                                Customs_Higher_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100, 2);
                                AddL_DUTY = Math.Round((ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100, 2);

                                TOTAL_DUTY = Math.Round((BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY), 2);




                                BASIC_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(BASIC_DUTY).ToString("F"));
                                CVD_TOTAL = Convert.ToString(Convert.ToDouble(CVD).ToString("F"));
                                CEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Edu_Cess).ToString("F"));
                                CHEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Higher_Edu_Cess).ToString("F"));
                                ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(AddL_DUTY).ToString("F"));
                            }
                            //------------------------------------------DATA FETCH FROM SCHEME IMPORT MASTER------------------------------------------//



                            else
                            {
                                BASIC_DUTY = ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100;
                                CVD = (ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100;
                                Customs_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100;
                                Customs_Higher_Edu_Cess = (BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100;
                                AddL_DUTY = (ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100;
                                TOTAL_DUTY = (BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY);
                                BASIC_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(BASIC_DUTY).ToString("F"));
                                CVD_TOTAL = Convert.ToString(Convert.ToDouble(CVD).ToString("F"));
                                CEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Edu_Cess).ToString("F"));
                                CHEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Higher_Edu_Cess).ToString("F"));
                                ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(AddL_DUTY).ToString("F"));
                            }
                        }

                        else
                        {
                          
                            string value2 = Array.Find(arr1, element => element.StartsWith(SCHEME_NOTN_, StringComparison.Ordinal));
                            if (SCHEME_NOTN_ == value2)
                            {
                                DataView view1 = ds3.DefaultView;
                                view1.RowFilter = "INVOICE_SLNO = " + INVOICE_SLNO + " and " + "ITEM_SLNO = " + ITEM_SLNO;
                                DataTable table1 = view1.ToTable();
                                DataSet dss1 = new DataSet();
                                dss1.Tables.Add(table1);

                                //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//

                                if (dss1.Tables[0].Rows.Count > 0)
                                {
                                    EXCEMPTION = dss1.Tables[0].Rows[0]["EXCEMPTION"].ToString();
                                    if (EXCEMPTION == "Y")
                                    {
                                        BASIC_DUTY = 0.00;
                                        CVD = 0.00;
                                        Customs_Edu_Cess = 0.00;
                                        Customs_Higher_Edu_Cess = 0.00;
                                        AddL_DUTY = 0.00;
                                        BASIC_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(BASIC_DUTY).ToString("F"));
                                        CVD_TOTAL = Convert.ToString(Convert.ToDouble(CVD).ToString("F"));
                                        CEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Edu_Cess).ToString("F"));
                                        CHEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Higher_Edu_Cess).ToString("F"));
                                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(AddL_DUTY).ToString("F"));
                                    }
                                    //------------------------------------------DATA FETCH FROM LICENSE DETAILS------------------------------------------//

                                    else
                                    {
                                        BASIC_DUTY = 0.00;
                                       
                                        CVD = Math.Round((ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100, 2);


                                        Customs_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100, 2);


                                        Customs_Higher_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100, 2);
                                        AddL_DUTY = Math.Round((ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100, 2);

                                        TOTAL_DUTY = Math.Round((BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY), 2);




                                        BASIC_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(BASIC_DUTY).ToString("F"));
                                        CVD_TOTAL = Convert.ToString(Convert.ToDouble(CVD).ToString("F"));
                                        CEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Edu_Cess).ToString("F"));
                                        CHEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Higher_Edu_Cess).ToString("F"));
                                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(AddL_DUTY).ToString("F"));
                                    }

                                }
                                else
                                {
                                    BASIC_DUTY = Math.Round(ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100, 2);



                                    CVD = Math.Round((ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100, 2);


                                    Customs_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100, 2);


                                    Customs_Higher_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100, 2);
                                    AddL_DUTY = Math.Round((ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100, 2);

                                    TOTAL_DUTY = Math.Round((BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY), 2);




                                    BASIC_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(BASIC_DUTY).ToString("F"));
                                    CVD_TOTAL = Convert.ToString(Convert.ToDouble(CVD).ToString("F"));
                                    CEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Edu_Cess).ToString("F"));
                                    CHEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Higher_Edu_Cess).ToString("F"));
                                    ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(AddL_DUTY).ToString("F"));
                                }
                            }

                        }
                    }
                    else
                    {
                        BASIC_DUTY = Math.Round(ASSESABLE_VALUE * Convert.ToDouble(PRODUCT_BCD_RATE) / 100, 2);



                        CVD = Math.Round((ASSESABLE_VALUE + BASIC_DUTY) * Convert.ToDouble(PRODUCT_CVD_RATE) / 100, 2);


                        Customs_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_EDU_CESS_RATE) / 100, 2);


                        Customs_Higher_Edu_Cess = Math.Round((BASIC_DUTY + CVD) * Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE) / 100, 2);
                        AddL_DUTY = Math.Round((ASSESABLE_VALUE + BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess) * Convert.ToDouble(ADDTIONAL_DUTY_RATE) / 100, 2);

                        TOTAL_DUTY = Math.Round((BASIC_DUTY + CVD + Customs_Edu_Cess + Customs_Higher_Edu_Cess + AddL_DUTY), 2);




                        BASIC_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(BASIC_DUTY).ToString("F"));
                        CVD_TOTAL = Convert.ToString(Convert.ToDouble(CVD).ToString("F"));
                        CEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Edu_Cess).ToString("F"));
                        CHEC_TOTAL = Convert.ToString(Convert.ToDouble(Customs_Higher_Edu_Cess).ToString("F"));
                        ADDLTIONAL_DUTY_TOTAL = Convert.ToString(Convert.ToDouble(AddL_DUTY).ToString("F"));
                    }
                }

             
                PRODUCT_BCD_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_BCD_RATE).ToString("F")) + "%";
                PRODUCT_CVD_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_CVD_RATE).ToString("F")) + "%";
                PRODUCT_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_EDU_CESS_RATE).ToString("F")) + "%";
                PRODUCT_SEC_EDU_CESS_RATE = Convert.ToString(Convert.ToDouble(PRODUCT_SEC_EDU_CESS_RATE).ToString("F")) + "%";
                ADDTIONAL_DUTY = Convert.ToString(Convert.ToDouble(ADDTIONAL_DUTY).ToString("F")) + "%";
                string ITEM_TTL = Convert.ToString(TOTAL_DUTY);
                ITEM_TTL = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(TOTAL_DUTY, 2))).ToString("F"));
                ITEM_TOTAL = Convert.ToDouble(ITEM_TTL);
                string ASS_TTL = Convert.ToString(ASSESSABLE_TOTAL);
                ASS_TTL = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(ASSESSABLE_TOTAL, 2))).ToString("F"));
                ASSESSABLE_TOTAL = Convert.ToDouble(ASS_TTL);
                string ASS_Value = Convert.ToString(ASSESSABLE_TOTAL);
                ASS_Value = Convert.ToString(Convert.ToDouble(Convert.ToString(Math.Round(ASSESABLE_VALUE, 2))).ToString("F"));
                ASSESABLE_VALUE = Convert.ToDouble(ASS_Value);
                if (SCHEME_CODE.Trim() == "00")
                {
                    SCHEME_CODE = "";
                }
                if (SCHEME_NOTN_ == "0" || SCHEME_NOTN_ == "")
                {
                    SCHEME_NOTN = "";

                    list1.Add(new ITEM_DETAILS()
                    {

                        INVOICE_NO = INVOICE_NO_ITEM,
                        ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                        ITEM_QTY = ITEM_QTY,
                        ITEM_QTY_CODE = ITEM_QTY_CODE,
                        ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                        SCHEME_CODE = SCHEME_CODE,


                        PRODUCT_RITC = PRODUCT_RITC,
                        PRODUCT_CTH = PRODUCT_CTH,
                        PRODUCT_CVD_RATE = PRODUCT_CVD_RATE,
                        PRODUCT_EDU_CESS_RATE = PRODUCT_EDU_CESS_RATE,
                        PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN,
                        PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN,

                        PRODUCT_SEC_EDU_CESS_RATE = PRODUCT_SEC_EDU_CESS_RATE,
                        PRODUCT_BCD_RATE = PRODUCT_BCD_RATE,
                        PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN,
                        PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN,
                        PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN,
                        PRODUCT_CETH = PRODUCT_CETH,
                        ITEM_SLNO = ITEM_SLNO,
                        BASIC_DUTY_TOTAL = BASIC_DUTY_TOTAL,
                        ASSESABLE_VALUE = ASSESABLE_VALUE,
                        ADDTIONAL_DUTY = ADDTIONAL_DUTY,

                        CVD_TOTAL = CVD_TOTAL,
                        CEC_TOTAL = CEC_TOTAL,
                        CHEC_TOTAL = CHEC_TOTAL,
                        ADDLTIONAL_DUTY_TOTAL = ADDLTIONAL_DUTY_TOTAL,
                        TOTAL_ITEM_DUTY = TOTAL_ITEM_DUTY,
                        NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS,
                        ASSESSABLE_TOTAL = ASSESSABLE_TOTAL,
                        ITEM_TOTAL = ITEM_TOTAL

                    });


                    b++;

                }
                else
                {
                    SCHEME_NOTN = SCHEME_NOTN_ + ":" + SCHEME_NOTN + " " + SCHEME_NOTN_SLNO;

                    list1.Add(new ITEM_DETAILS()
                    {

                        INVOICE_NO = INVOICE_NO_ITEM,
                        ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                        ITEM_QTY = ITEM_QTY,
                        ITEM_QTY_CODE = ITEM_QTY_CODE,
                        ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                        SCHEME_CODE = SCHEME_CODE,
                        SCHEME_NOTN = SCHEME_NOTN,
                        PRODUCT_RITC = PRODUCT_RITC,
                        PRODUCT_CTH = PRODUCT_CTH,
                        PRODUCT_CVD_RATE = PRODUCT_CVD_RATE,
                        PRODUCT_EDU_CESS_RATE = PRODUCT_EDU_CESS_RATE,
                        PRODUCT_EDU_CESS_NOTN = PRODUCT_EDU_CESS_NOTN,
                        PRODUCT_SEC_EDU_CESS_NOTN = PRODUCT_SEC_EDU_CESS_NOTN,

                        PRODUCT_SEC_EDU_CESS_RATE = PRODUCT_SEC_EDU_CESS_RATE,
                        PRODUCT_BCD_RATE = PRODUCT_BCD_RATE,
                        PRODUCT_BCD_NOTN = PRODUCT_BCD_NOTN,
                        PRODUCT_CVD_NOTN = PRODUCT_CVD_NOTN,
                        PRODUCT_ADDL_DUTY_NOTN = PRODUCT_ADDL_DUTY_NOTN,
                        PRODUCT_CETH = PRODUCT_CETH,
                        ITEM_SLNO = ITEM_SLNO,
                        BASIC_DUTY_TOTAL = BASIC_DUTY_TOTAL,
                        ASSESABLE_VALUE = ASSESABLE_VALUE,
                        ADDTIONAL_DUTY = ADDTIONAL_DUTY,

                        CVD_TOTAL = CVD_TOTAL,
                        CEC_TOTAL = CEC_TOTAL,
                        CHEC_TOTAL = CHEC_TOTAL,
                        ADDLTIONAL_DUTY_TOTAL = ADDLTIONAL_DUTY_TOTAL,
                        TOTAL_ITEM_DUTY = TOTAL_ITEM_DUTY,
                        NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS,
                        ASSESSABLE_TOTAL = ASSESSABLE_TOTAL,
                        ITEM_TOTAL = ITEM_TOTAL

                    });


                    b++;
                }

            }

            C++;

        }

        return list1;
    }
}