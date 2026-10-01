using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for Rpt_Item_Details
/// </summary>
public class Rpt_Item_Details
{
    #region Private_Attributes

    private string _INVOICE_SLNO;
    private string _INVOICE_NO;
    private string _ITEM_SLNO;
    private string _ITEM_DESCRIPTION;
    private string _RITCNO;
    private string _ITEM_QTY;
    private string _ITEM_QTY_CODE;
    private string _ITEM_UNIT_PRICE;
    private string _ITEM_PER;
    private string _ITEM_AMOUNT;
    private string _ITEM_PMVVALUE;
    private string _ITEM_SCHEME_CODE;
    private string _ITEM_ACCESSORIES_DESC;
    private string _ITEM_AR4_NO;
    private string _ITEM_AR4_DATE;
    private string _ITEM_COMMISSION_RATE;
    private string _ITEM_DIVISION;
    private string _ITEM_RANGE;
    private string _ITEM_REMARKS;
    private string _ITEM_IECCODE;
    private string _BR_SLNO;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;
    private string _ITEM_STR_CODE;
    private string _REWARD_POINTS;
    private string _NUMBERTOWORDS;

    private string _ITEM_SCHEME_DESC;
    private double _FOB_VALUE;
    private double _TOTAL_PMVVALUE;


    private string _STR_RATE;
    private double _STR_AMOUNT;

    //Invoice Details
    private string _TERMS;
    private string _EXCHANGE_RATE;
    private string _FREIGHT_RATE;
    private string _INSURANCE_RATE;
    private string _INVOICE_VALUE, _STR_AMOUNT1;
   

    #endregion

    #region Drawback Private_Attributes

    private string _DRAWBACK_ID;
    private string _JOBNO;
    //private string _INVOICE_SLNO;
    //private string _ITEM_SLNO;
    private string _SCHEME_CODE;
    private string _DRAWBACK_SLNO;
    private string _DRAWBACK_QTY;
    private string _DRAWBACK_UNIT;
    private string _DRAWBACK_NOOFUNITS;
    private string _DRAWBACK_RATE;
    private string _DRAWBACK_CAPS;
    private string _DRAWBACK_DESC;
    private string _DRAWBACK_CUSTOMS;
    private string _DRAWBACK_EXCISE;

    private double _DBK_VALUE;

    #endregion

    #region Drawback Public Attributes

    public string DRAWBACK_ID { get { return _DRAWBACK_ID; } set { _DRAWBACK_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    ////public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    ////public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string DRAWBACK_SLNO { get { return _DRAWBACK_SLNO; } set { _DRAWBACK_SLNO = value; } }
    public string DRAWBACK_QTY { get { return _DRAWBACK_QTY; } set { _DRAWBACK_QTY = value; } }
    public string DRAWBACK_UNIT { get { return _DRAWBACK_UNIT; } set { _DRAWBACK_UNIT = value; } }
    public string DRAWBACK_NOOFUNITS { get { return _DRAWBACK_NOOFUNITS; } set { _DRAWBACK_NOOFUNITS = value; } }
    public string DRAWBACK_RATE { get { return _DRAWBACK_RATE; } set { _DRAWBACK_RATE = value; } }
    public string DRAWBACK_CAPS { get { return _DRAWBACK_CAPS; } set { _DRAWBACK_CAPS = value; } }
    public string DRAWBACK_DESC { get { return _DRAWBACK_DESC; } set { _DRAWBACK_DESC = value; } }

    public string DRAWBACK_CUSTOMS { get { return _DRAWBACK_CUSTOMS; } set { _DRAWBACK_CUSTOMS = value; } }
    public string DRAWBACK_EXCISE { get { return _DRAWBACK_EXCISE; } set { _DRAWBACK_EXCISE = value; } }

    public double DBK_VALUE { get { return _DBK_VALUE; } set { _DBK_VALUE = value; } }

    public double cal1, cal2, DBK_FOB;

    #endregion


    #region Public_Attributes

    public string TERMS { get { return _TERMS; } set { _TERMS = value; } }
    public string EXCHANGE_RATE { get { return _EXCHANGE_RATE; } set { _EXCHANGE_RATE = value; } }
    public string FREIGHT_RATE { get { return _FREIGHT_RATE; } set { _FREIGHT_RATE = value; } }
    public string INSURANCE_RATE { get { return _INSURANCE_RATE; } set { _INSURANCE_RATE = value; } }
    public string INVOICE_VALUE { get { return _INVOICE_VALUE; } set { _INVOICE_VALUE = value; } }

    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string ITEM_DESCRIPTION { get { return _ITEM_DESCRIPTION; } set { _ITEM_DESCRIPTION = value; } }
    public string RITCNO { get { return _RITCNO; } set { _RITCNO = value; } }
    public string ITEM_QTY { get { return _ITEM_QTY; } set { _ITEM_QTY = value; } }
    public string ITEM_QTY_CODE { get { return _ITEM_QTY_CODE; } set { _ITEM_QTY_CODE = value; } }
    public string ITEM_UNIT_PRICE { get { return _ITEM_UNIT_PRICE; } set { _ITEM_UNIT_PRICE = value; } }
    public string ITEM_PER { get { return _ITEM_PER; } set { _ITEM_PER = value; } }
    public string ITEM_AMOUNT { get { return _ITEM_AMOUNT; } set { _ITEM_AMOUNT = value; } }
    public string ITEM_PMVVALUE { get { return _ITEM_PMVVALUE; } set { _ITEM_PMVVALUE = value; } }
    public string ITEM_SCHEME_CODE { get { return _ITEM_SCHEME_CODE; } set { _ITEM_SCHEME_CODE = value; } }
    public string ITEM_ACCESSORIES_DESC { get { return _ITEM_ACCESSORIES_DESC; } set { _ITEM_ACCESSORIES_DESC = value; } }
    public string ITEM_AR4_NO { get { return _ITEM_AR4_NO; } set { _ITEM_AR4_NO = value; } }
    public string ITEM_AR4_DATE { get { return _ITEM_AR4_DATE; } set { _ITEM_AR4_DATE = value; } }
    public string ITEM_COMMISSION_RATE { get { return _ITEM_COMMISSION_RATE; } set { _ITEM_COMMISSION_RATE = value; } }
    public string ITEM_DIVISION { get { return _ITEM_DIVISION; } set { _ITEM_DIVISION = value; } }
    public string ITEM_RANGE { get { return _ITEM_RANGE; } set { _ITEM_RANGE = value; } }
    public string ITEM_REMARKS { get { return _ITEM_REMARKS; } set { _ITEM_REMARKS = value; } }
    public string ITEM_IECCODE { get { return _ITEM_IECCODE; } set { _ITEM_IECCODE = value; } }
    public string BR_SLNO { get { return _BR_SLNO; } set { _BR_SLNO = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
    public string ITEM_STR_CODE { get { return _ITEM_STR_CODE; } set { _ITEM_STR_CODE = value; } }
    public string REWARD_POINTS { get { return _REWARD_POINTS; } set { _REWARD_POINTS = value; } }
    public string NUMBERTOWORDS { get { return _NUMBERTOWORDS; } set { _NUMBERTOWORDS = value; } }

    public string ITEM_SCHEME_DESC { get { return _ITEM_SCHEME_DESC; } set { _ITEM_SCHEME_DESC = value; } }

     public double FOB_VALUE { get { return _FOB_VALUE; } set { _FOB_VALUE = value; } }
     public double TOTAL_PMVVALUE { get { return _TOTAL_PMVVALUE; } set { _TOTAL_PMVVALUE = value; } }
   // public double FOB_VALUE;

     public string STR_RATE { get { return _STR_RATE; } set { _STR_RATE = value; } }
     //public double STR_AMOUNT { get { return _STR_AMOUNT; } set { _STR_AMOUNT = value; } }
     public string STR_AMOUNT { get { return _STR_AMOUNT1; } set { _STR_AMOUNT1 = value; } }

    #endregion

     public List<Rpt_Item_Details> Get_ITEM_PMV_VALUE(string ddlJobNo, DataTable ds, DataTable ds2, DataTable dt)
     {

         List<Rpt_Item_Details> list1 = new List<Rpt_Item_Details>();
         list1.Clear();


         int b = 0, C = 0, i = 0;

         double salary = 0.0;
         double salary1 = 0.0;
         double TOTAL_ITEM = 0.0;
         string preINVOICE_SLNO = "0", curINVOICE_SLNO = "0";

         while (ds.Rows.Count > C)
         {
             string FREIGHT_CHARGES, INSURANCE_CHARGES;
             curINVOICE_SLNO = "";
             NUMBERTOWORDS = "";
             curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
             INVOICE_VALUE = ds.Rows[C]["INVOICE_VALUE"].ToString();
             EXCHANGE_RATE = ds.Rows[C]["EXCHANGE_RATE"].ToString();
             FREIGHT_CHARGES = ds.Rows[C]["FREIGHT_CHARGES"].ToString();
             INSURANCE_CHARGES = ds.Rows[C]["INSURANCE_CHARGES"].ToString();
             FREIGHT_RATE = ds.Rows[C]["FREIGHT_RATE"].ToString();
             INSURANCE_RATE = ds.Rows[C]["INSURANCE_RATE"].ToString();
             TERMS = ds.Rows[C]["TERMS"].ToString();
             if (INVOICE_VALUE == "")
                 INVOICE_VALUE = "0.00";
             if (EXCHANGE_RATE == "")
                 EXCHANGE_RATE = "0.00";
             if (FREIGHT_RATE == "")
                 FREIGHT_RATE = "0.00";
             if (INSURANCE_RATE == "")
                 INSURANCE_RATE = "0.00";
             //ASSESSABLE_TOTAL = 0;
             //TOTAL_ITEM = 0.0;
             //TOTAL_DUTY = 0.0;
             b = 0;

             DataView view = ds2.DefaultView;
             view.RowFilter = "INVOICE_SLNO = " + curINVOICE_SLNO;
             DataTable table = view.ToTable();
             DataSet dss = new DataSet();
             dss.Tables.Add(table);
             while (dss.Tables[0].Rows.Count > b)
             {

                 INVOICE_SLNO = dss.Tables[0].Rows[b]["INVOICE_SLNO"].ToString();
                 INVOICE_NO = dss.Tables[0].Rows[b]["INVOICE_NO"].ToString();
                 ITEM_SLNO = dss.Tables[0].Rows[b]["ITEM_SLNO"].ToString();
                 ITEM_DESCRIPTION = dss.Tables[0].Rows[b]["ITEM_DESCRIPTION"].ToString();
                 RITCNO = dss.Tables[0].Rows[b]["RITCNO"].ToString();
                 ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();
                 ITEM_QTY_CODE = dss.Tables[0].Rows[b]["ITEM_QTY_CODE"].ToString();
                 ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();
                 ITEM_PER = dss.Tables[0].Rows[b]["ITEM_PER"].ToString();
                 ITEM_AMOUNT = dss.Tables[0].Rows[b]["ITEM_AMOUNT"].ToString();
                 ITEM_PMVVALUE = dss.Tables[0].Rows[b]["ITEM_PMVVALUE"].ToString();

                 ITEM_SCHEME_CODE = dss.Tables[0].Rows[b]["ITEM_SCHEME_CODE"].ToString();
                 ITEM_ACCESSORIES_DESC = dss.Tables[0].Rows[b]["ITEM_ACCESSORIES_DESC"].ToString();
                 ITEM_AR4_NO = dss.Tables[0].Rows[b]["ITEM_AR4_NO"].ToString();
                 ITEM_AR4_DATE = dss.Tables[0].Rows[b]["ITEM_AR4_DATE"].ToString();

                 ITEM_COMMISSION_RATE = dss.Tables[0].Rows[b]["ITEM_COMMISSION_RATE"].ToString();
                 ITEM_DIVISION = dss.Tables[0].Rows[b]["ITEM_DIVISION"].ToString();
                 ITEM_RANGE = dss.Tables[0].Rows[b]["ITEM_RANGE"].ToString();
                 ITEM_REMARKS = dss.Tables[0].Rows[b]["ITEM_REMARKS"].ToString();
                 ITEM_IECCODE = dss.Tables[0].Rows[b]["ITEM_IECCODE"].ToString();
                 BR_SLNO = dss.Tables[0].Rows[b]["BR_SLNO"].ToString();


                 ADDRESS1 = dss.Tables[0].Rows[b]["ADDRESS1"].ToString();
                 ADDRESS2 = dss.Tables[0].Rows[b]["ADDRESS2"].ToString();
                 ADDRESS3 = dss.Tables[0].Rows[b]["ADDRESS3"].ToString();
                 ADDRESS4 = dss.Tables[0].Rows[b]["ADDRESS4"].ToString();
                 ADDRESS5 = dss.Tables[0].Rows[b]["ADDRESS5"].ToString();
                 ITEM_STR_CODE = dss.Tables[0].Rows[b]["ITEM_STR_CODE"].ToString();
                 REWARD_POINTS = dss.Tables[0].Rows[b]["REWARD_POINTS"].ToString();

                 if (ITEM_SCHEME_CODE != "")
                 {
                     string[] s1 = ITEM_SCHEME_CODE.Split(new string[] { "-" }, StringSplitOptions.None);
                     ITEM_SCHEME_CODE = s1[0].ToString();
                     ITEM_SCHEME_DESC = s1[1].ToString();
                 }
                 else
                 {
                     ITEM_SCHEME_CODE = "0";
                     ITEM_SCHEME_DESC = "";
                 }


                 if (ITEM_PMVVALUE != "")
                 {
                     //ITEM_PMVVALUE = Convert.ToString(Convert.ToDouble(ITEM_PMVVALUE)/10);
                     TOTAL_PMVVALUE = Convert.ToDouble(ITEM_PMVVALUE) * Convert.ToDouble(ITEM_QTY); //* Convert.ToDouble(EXCHANGE_RATE));
                 }
                 else
                 //if (ITEM_PMVVALUE == "")
                 {
                     TOTAL_PMVVALUE = 0.00;
                 }

                 // --------------------------------------- ITEM CALCULATION---------------------------------------------------------------


                 if (TERMS == "FOB")
                 {
                     FOB_VALUE = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) * Convert.ToDouble(EXCHANGE_RATE));
                 }
                 else if (TERMS == "CIF")
                 {
                     double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_CHARGES) + Convert.ToDouble(INSURANCE_CHARGES)));
                     FOB_VALUE = FOB * Convert.ToDouble(EXCHANGE_RATE);
                 }
                 else if (TERMS == "CF")
                 {
                     double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_CHARGES)));
                     FOB_VALUE = FOB * Convert.ToDouble(EXCHANGE_RATE);
                 }
                 else if (TERMS == "CI")
                 {
                     double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(INSURANCE_CHARGES)));
                     FOB_VALUE = FOB * Convert.ToDouble(EXCHANGE_RATE);
                 }


                 DataView view1 = dt.DefaultView;
                 view1.RowFilter = "ITEM_SLNO = " + ITEM_SLNO;
                 DataTable table1 = view1.ToTable();
                 //DataSet dss1 = new DataSet();
                 //dss1.Tables.Add(table1);
                 //while (dss.Tables[0].Rows.Count > b)
                 //{

                 if (table1.Rows.Count >= i && table1.Rows.Count != 0)
                 {
                     //JOBNO = dt.Rows[i]["JOBNO"].ToString();
                     //INVOICE_SLNO = dt.Rows[i]["INVOICE_SLNO"].ToString();
                     //ITEM_SLNO = dt.Rows[i]["ITEM_SLNO"].ToString();
                     DRAWBACK_SLNO = table1.Rows[i]["DRAWBACK_SLNO"].ToString();


                     DRAWBACK_QTY = table1.Rows[i]["DRAWBACK_QTY"].ToString();
                     DRAWBACK_UNIT = table1.Rows[i]["DRAWBACK_UNIT"].ToString();
                     DRAWBACK_NOOFUNITS = table1.Rows[i]["DRAWBACK_NOOFUNITS"].ToString();
                     DRAWBACK_RATE = table1.Rows[i]["DRAWBACK_RATE"].ToString();
                     DRAWBACK_CAPS = table1.Rows[i]["DRAWBACK_CAPS"].ToString();
                     DRAWBACK_ID = dt.Rows[i]["DRAWBACK_ID"].ToString();
                     SCHEME_CODE = dt.Rows[i]["SCHEME_CODE"].ToString();
                     DRAWBACK_DESC = dt.Rows[i]["DRAWBACK_DESC"].ToString();

                     if (DRAWBACK_SLNO != "")
                     {
                         adminmaster adm = new adminmaster();
                         adm.Edrawback_id = "";
                         adm.Edrawback_slno = DRAWBACK_SLNO;
                         adm.Edrawback_description = "";
                         adm.Ename = "select_checklist";

                         DataSet ds1 = new DataSet();
                         ds1 = adm.Checklist_Drawback_master();

                         if (ds1.Tables[0].Rows.Count > 0)
                         {
                             DRAWBACK_CUSTOMS = ds1.Tables[0].Rows[0]["DRAWBACK_CUSTOMS"].ToString();
                             DRAWBACK_EXCISE = ds1.Tables[0].Rows[0]["DRAWBACK_EXCISE"].ToString();


                         }
                     }
                     else
                     {
                         DRAWBACK_CUSTOMS = "";
                         DRAWBACK_EXCISE = "";

                     }


                     // --------------------------------------- DRAWBACK CALCULATION---------------------------------------------------------------


                     cal1 = FOB_VALUE * Convert.ToDouble(DRAWBACK_RATE);

                     if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
                     {
                         cal2 = Convert.ToDouble(DRAWBACK_QTY) * Convert.ToDouble(DRAWBACK_CAPS);
                     }

                     if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
                     {
                         if (cal1 > cal2)
                         {
                             DBK_VALUE = cal2;
                         }
                         else
                         {
                             DBK_VALUE = cal1;
                         }

                     }
                     else
                     {
                         DBK_VALUE = cal1;
                     }


                     // --------------------------------------- STR CALCULATION---------------------------------------------------------------


                     if (ITEM_STR_CODE != "")
                     {
                         adminmaster adm = new adminmaster();
                         adm.STR_ID = "0";
                         adm.STR_SRNO = ITEM_STR_CODE;

                         adm.Ename = "select_value";

                         adm.startRowIndex = "0";
                         adm.maximumRows = "0";

                         DataSet ds1 = new DataSet();
                         ds1 = adm.RetrieveAll_STR_master();

                         if (ds1.Tables[0].Rows.Count > 0)
                         {
                             STR_RATE = ds1.Tables[0].Rows[0]["STR_RATE"].ToString();

                         }

                         STR_AMOUNT = Convert.ToString(Convert.ToDouble(STR_RATE) * FOB_VALUE);
                     }


                     // test();


                     list1.Add(new Rpt_Item_Details()
                     {

                         INVOICE_SLNO = INVOICE_SLNO,
                         INVOICE_NO = INVOICE_NO,
                         ITEM_SLNO = ITEM_SLNO,
                         ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                         RITCNO = RITCNO,
                         ITEM_QTY = ITEM_QTY,
                         ITEM_QTY_CODE = ITEM_QTY_CODE,
                         ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                         ITEM_PER = ITEM_PER,
                         ITEM_AMOUNT = ITEM_AMOUNT,
                         ITEM_PMVVALUE = ITEM_PMVVALUE,
                         ITEM_SCHEME_CODE = ITEM_SCHEME_CODE,
                         ITEM_SCHEME_DESC = ITEM_SCHEME_DESC,
                         ITEM_ACCESSORIES_DESC = ITEM_ACCESSORIES_DESC,
                         ITEM_AR4_NO = ITEM_AR4_NO,
                         ITEM_AR4_DATE = ITEM_AR4_DATE,
                         ITEM_COMMISSION_RATE = ITEM_COMMISSION_RATE,
                         ITEM_DIVISION = ITEM_DIVISION,
                         ITEM_RANGE = ITEM_RANGE,
                         ITEM_REMARKS = ITEM_REMARKS,
                         ITEM_IECCODE = ITEM_IECCODE,
                         BR_SLNO = BR_SLNO,

                         ADDRESS1 = ADDRESS1,
                         ADDRESS2 = ADDRESS2,
                         ADDRESS3 = ADDRESS3,
                         ADDRESS4 = ADDRESS4,
                         ADDRESS5 = ADDRESS5,
                         ITEM_STR_CODE = ITEM_STR_CODE,
                         REWARD_POINTS = REWARD_POINTS,
                         FOB_VALUE = FOB_VALUE,
                         TOTAL_PMVVALUE = TOTAL_PMVVALUE,

                         DRAWBACK_ID = DRAWBACK_ID,
                         SCHEME_CODE = SCHEME_CODE,
                         DRAWBACK_SLNO = DRAWBACK_SLNO,
                         DRAWBACK_QTY = DRAWBACK_QTY,
                         DRAWBACK_UNIT = DRAWBACK_UNIT,
                         DRAWBACK_NOOFUNITS = DRAWBACK_NOOFUNITS,
                         DRAWBACK_RATE = DRAWBACK_RATE,
                         DRAWBACK_CAPS = DRAWBACK_CAPS,
                         DRAWBACK_DESC = DRAWBACK_DESC,
                         DRAWBACK_CUSTOMS = DRAWBACK_CUSTOMS,
                         DRAWBACK_EXCISE = DRAWBACK_EXCISE,
                         DBK_VALUE = DBK_VALUE,

                         STR_RATE = STR_RATE,
                         STR_AMOUNT = STR_AMOUNT,

                         NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS


                     });

                     //i++;
                 }
                 else
                 {
                     list1.Add(new Rpt_Item_Details()
                     {

                         INVOICE_SLNO = INVOICE_SLNO,
                         INVOICE_NO = INVOICE_NO,
                         ITEM_SLNO = ITEM_SLNO,
                         ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                         RITCNO = RITCNO,
                         ITEM_QTY = ITEM_QTY,
                         ITEM_QTY_CODE = ITEM_QTY_CODE,
                         ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                         ITEM_PER = ITEM_PER,
                         ITEM_AMOUNT = ITEM_AMOUNT,
                         ITEM_PMVVALUE = ITEM_PMVVALUE,
                         ITEM_SCHEME_CODE = ITEM_SCHEME_CODE,
                         ITEM_SCHEME_DESC = ITEM_SCHEME_DESC,
                         ITEM_ACCESSORIES_DESC = ITEM_ACCESSORIES_DESC,
                         ITEM_AR4_NO = ITEM_AR4_NO,
                         ITEM_AR4_DATE = ITEM_AR4_DATE,
                         ITEM_COMMISSION_RATE = ITEM_COMMISSION_RATE,
                         ITEM_DIVISION = ITEM_DIVISION,
                         ITEM_RANGE = ITEM_RANGE,
                         ITEM_REMARKS = ITEM_REMARKS,
                         ITEM_IECCODE = ITEM_IECCODE,
                         BR_SLNO = BR_SLNO,

                         ADDRESS1 = ADDRESS1,
                         ADDRESS2 = ADDRESS2,
                         ADDRESS3 = ADDRESS3,
                         ADDRESS4 = ADDRESS4,
                         ADDRESS5 = ADDRESS5,
                         ITEM_STR_CODE = ITEM_STR_CODE,
                         REWARD_POINTS = REWARD_POINTS,
                         FOB_VALUE = FOB_VALUE,
                         TOTAL_PMVVALUE = TOTAL_PMVVALUE,

                         DRAWBACK_ID = DRAWBACK_ID,
                         SCHEME_CODE = SCHEME_CODE,
                         DRAWBACK_SLNO = DRAWBACK_SLNO,
                         DRAWBACK_QTY = DRAWBACK_QTY,
                         DRAWBACK_UNIT = DRAWBACK_UNIT,
                         DRAWBACK_NOOFUNITS = DRAWBACK_NOOFUNITS,
                         DRAWBACK_RATE = DRAWBACK_RATE,
                         DRAWBACK_CAPS = DRAWBACK_CAPS,
                         DRAWBACK_DESC = DRAWBACK_DESC,
                         DRAWBACK_CUSTOMS = DRAWBACK_CUSTOMS,
                         DRAWBACK_EXCISE = DRAWBACK_EXCISE,
                         DBK_VALUE = DBK_VALUE,

                         STR_RATE = STR_RATE,
                         STR_AMOUNT = STR_AMOUNT,

                         NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS


                     });
                 }


                 b++;

             }

             C++;

         }

         return list1;
     }
    public List<Rpt_Item_Details> Get_ITEM_Details(string ddlJobNo, DataTable ds, DataTable ds2, DataTable dt)
    {

        List<Rpt_Item_Details> list1 = new List<Rpt_Item_Details>();
        list1.Clear();


        int b = 0, C = 0,i=0;

        double salary = 0.0;
        double salary1 = 0.0;
        double TOTAL_ITEM = 0.0;
        string preINVOICE_SLNO = "0", curINVOICE_SLNO = "0";

        while (ds.Rows.Count > C)
        {
            string FREIGHT_CHARGES, INSURANCE_CHARGES;
            curINVOICE_SLNO = "";
            NUMBERTOWORDS = "";
            curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
            INVOICE_VALUE = ds.Rows[C]["INVOICE_VALUE"].ToString();
            EXCHANGE_RATE = ds.Rows[C]["EXCHANGE_RATE"].ToString();
            FREIGHT_CHARGES = ds.Rows[C]["FREIGHT_CHARGES"].ToString();
            INSURANCE_CHARGES = ds.Rows[C]["INSURANCE_CHARGES"].ToString();
            FREIGHT_RATE = ds.Rows[C]["FREIGHT_RATE"].ToString();
            INSURANCE_RATE = ds.Rows[C]["INSURANCE_RATE"].ToString();
            TERMS = ds.Rows[C]["TERMS"].ToString();
            if (INVOICE_VALUE == "")
                INVOICE_VALUE = "0.00";
            if (EXCHANGE_RATE == "")
                EXCHANGE_RATE = "0.00";
            if (FREIGHT_RATE == "")
                FREIGHT_RATE = "0.00";
            if (INSURANCE_RATE == "")
                INSURANCE_RATE = "0.00";
            //ASSESSABLE_TOTAL = 0;
            //TOTAL_ITEM = 0.0;
            //TOTAL_DUTY = 0.0;
            b = 0;

            DataView view = ds2.DefaultView;
            view.RowFilter = "INVOICE_SLNO = " + curINVOICE_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            while (dss.Tables[0].Rows.Count > b)
            {

                INVOICE_SLNO = dss.Tables[0].Rows[b]["INVOICE_SLNO"].ToString();
                INVOICE_NO = dss.Tables[0].Rows[b]["INVOICE_NO"].ToString();
                ITEM_SLNO = dss.Tables[0].Rows[b]["ITEM_SLNO"].ToString();
                ITEM_DESCRIPTION = dss.Tables[0].Rows[b]["ITEM_DESCRIPTION"].ToString();
                RITCNO = dss.Tables[0].Rows[b]["RITCNO"].ToString();
                ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();
                ITEM_QTY_CODE = dss.Tables[0].Rows[b]["ITEM_QTY_CODE"].ToString();
                ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();
                ITEM_PER = dss.Tables[0].Rows[b]["ITEM_PER"].ToString();
                ITEM_AMOUNT = dss.Tables[0].Rows[b]["ITEM_AMOUNT"].ToString();
                ITEM_PMVVALUE = dss.Tables[0].Rows[b]["ITEM_PMVVALUE"].ToString();

                ITEM_SCHEME_CODE = dss.Tables[0].Rows[b]["ITEM_SCHEME_CODE"].ToString();
                ITEM_ACCESSORIES_DESC = dss.Tables[0].Rows[b]["ITEM_ACCESSORIES_DESC"].ToString();
                ITEM_AR4_NO = dss.Tables[0].Rows[b]["ITEM_AR4_NO"].ToString();
                ITEM_AR4_DATE = dss.Tables[0].Rows[b]["ITEM_AR4_DATE"].ToString();

                ITEM_COMMISSION_RATE = dss.Tables[0].Rows[b]["ITEM_COMMISSION_RATE"].ToString();
                ITEM_DIVISION = dss.Tables[0].Rows[b]["ITEM_DIVISION"].ToString();
                ITEM_RANGE = dss.Tables[0].Rows[b]["ITEM_RANGE"].ToString();
                ITEM_REMARKS = dss.Tables[0].Rows[b]["ITEM_REMARKS"].ToString();
                ITEM_IECCODE = dss.Tables[0].Rows[b]["ITEM_IECCODE"].ToString();
                BR_SLNO = dss.Tables[0].Rows[b]["BR_SLNO"].ToString();


                ADDRESS1 = dss.Tables[0].Rows[b]["ADDRESS1"].ToString();
                ADDRESS2 = dss.Tables[0].Rows[b]["ADDRESS2"].ToString();
                ADDRESS3 = dss.Tables[0].Rows[b]["ADDRESS3"].ToString();
                ADDRESS4 = dss.Tables[0].Rows[b]["ADDRESS4"].ToString();
                ADDRESS5 = dss.Tables[0].Rows[b]["ADDRESS5"].ToString();
                ITEM_STR_CODE = dss.Tables[0].Rows[b]["ITEM_STR_CODE"].ToString();
                REWARD_POINTS = dss.Tables[0].Rows[b]["REWARD_POINTS"].ToString();

                if (ITEM_SCHEME_CODE != "")
                {
                    string[] s1 = ITEM_SCHEME_CODE.Split(new string[] { "-" }, StringSplitOptions.None);
                    ITEM_SCHEME_CODE = s1[0].ToString();
                    ITEM_SCHEME_DESC = s1[1].ToString();
                }
                else
                {
                    ITEM_SCHEME_CODE = "0";
                    ITEM_SCHEME_DESC = "";
                }


                if (ITEM_PMVVALUE != "")
                {
                    //ITEM_PMVVALUE = Convert.ToString(Convert.ToDouble(ITEM_PMVVALUE)/10);
                    TOTAL_PMVVALUE = Convert.ToDouble(ITEM_PMVVALUE) * Convert.ToDouble(ITEM_QTY); //* Convert.ToDouble(EXCHANGE_RATE));
                }
                else
                //if (ITEM_PMVVALUE == "")
                {
                    TOTAL_PMVVALUE = 0.00;
                }

                // --------------------------------------- ITEM CALCULATION---------------------------------------------------------------

              
                if (TERMS == "FOB")
                {
                    FOB_VALUE = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) * Convert.ToDouble(EXCHANGE_RATE));
                }
                else if (TERMS == "CIF")
                {
                    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_CHARGES)+Convert.ToDouble(INSURANCE_CHARGES)));
                    FOB_VALUE = FOB * Convert.ToDouble(EXCHANGE_RATE);
                }
                else if (TERMS == "CF")
                {
                    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_CHARGES)));
                    FOB_VALUE = FOB * Convert.ToDouble(EXCHANGE_RATE);
                }
                else if (TERMS == "CI")
                {
                    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(INSURANCE_CHARGES)));
                    FOB_VALUE = FOB * Convert.ToDouble(EXCHANGE_RATE);
                }


                DataView view1 = dt.DefaultView;
                view1.RowFilter = "ITEM_SLNO = " + ITEM_SLNO;
                DataTable table1 = view1.ToTable();
                //DataSet dss1 = new DataSet();
                //dss1.Tables.Add(table1);
                //while (dss.Tables[0].Rows.Count > b)
                //{

                if (table1.Rows.Count >= i && table1.Rows.Count != 0)
                {
                    //JOBNO = dt.Rows[i]["JOBNO"].ToString();
                    //INVOICE_SLNO = dt.Rows[i]["INVOICE_SLNO"].ToString();
                    //ITEM_SLNO = dt.Rows[i]["ITEM_SLNO"].ToString();
                    DRAWBACK_SLNO = table1.Rows[i]["DRAWBACK_SLNO"].ToString();


                    DRAWBACK_QTY = table1.Rows[i]["DRAWBACK_QTY"].ToString();
                    DRAWBACK_UNIT = table1.Rows[i]["DRAWBACK_UNIT"].ToString();
                    DRAWBACK_NOOFUNITS = table1.Rows[i]["DRAWBACK_NOOFUNITS"].ToString();
                    DRAWBACK_RATE = table1.Rows[i]["DRAWBACK_RATE"].ToString();
                    DRAWBACK_CAPS = table1.Rows[i]["DRAWBACK_CAPS"].ToString();
                    DRAWBACK_ID = dt.Rows[i]["DRAWBACK_ID"].ToString();
                    SCHEME_CODE = dt.Rows[i]["SCHEME_CODE"].ToString();
                    DRAWBACK_DESC = dt.Rows[i]["DRAWBACK_DESC"].ToString();

                    if (DRAWBACK_SLNO != "")
                    {
                        adminmaster adm = new adminmaster();
                        adm.Edrawback_id = "";
                        adm.Edrawback_slno = DRAWBACK_SLNO;
                        adm.Edrawback_description = "";
                        adm.Ename = "select_checklist";

                        DataSet ds1 = new DataSet();
                        ds1 = adm.Checklist_Drawback_master();

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            DRAWBACK_CUSTOMS = ds1.Tables[0].Rows[0]["DRAWBACK_CUSTOMS"].ToString();
                            DRAWBACK_EXCISE = ds1.Tables[0].Rows[0]["DRAWBACK_EXCISE"].ToString();


                        }
                    }
                    else
                    {
                        DRAWBACK_CUSTOMS = "";
                        DRAWBACK_EXCISE = "";

                    }


                    // --------------------------------------- DRAWBACK CALCULATION---------------------------------------------------------------


                    cal1 = FOB_VALUE * Convert.ToDouble(DRAWBACK_RATE);

                    if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
                    {
                        cal2 = Convert.ToDouble(DRAWBACK_QTY) * Convert.ToDouble(DRAWBACK_CAPS);
                    }

                    if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
                    {
                        if (cal1 > cal2)
                        {
                            DBK_VALUE = cal2;
                        }
                        else
                        {
                            DBK_VALUE = cal1;
                        }

                    }
                    else
                    {
                        DBK_VALUE = cal1;
                    }


                    // --------------------------------------- STR CALCULATION---------------------------------------------------------------


                    if (ITEM_STR_CODE != "")
                    {
                        adminmaster adm = new adminmaster();
                        adm.STR_ID = "0";
                        adm.STR_SRNO = ITEM_STR_CODE;

                        adm.Ename = "select_value";

                        adm.startRowIndex = "0";
                        adm.maximumRows = "0";

                        DataSet ds1 = new DataSet();
                        ds1 = adm.RetrieveAll_STR_master();

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            STR_RATE = ds1.Tables[0].Rows[0]["STR_RATE"].ToString();

                        }

                        STR_AMOUNT =Convert.ToString(Convert.ToDouble(STR_RATE) * FOB_VALUE);
                    }


                    // test();


                    list1.Add(new Rpt_Item_Details()
                    {

                        INVOICE_SLNO = INVOICE_SLNO,
                        INVOICE_NO = INVOICE_NO,
                        ITEM_SLNO = ITEM_SLNO,
                        ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                        RITCNO = RITCNO,
                        ITEM_QTY = ITEM_QTY,
                        ITEM_QTY_CODE = ITEM_QTY_CODE,
                        ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                        ITEM_PER = ITEM_PER,
                        ITEM_AMOUNT = ITEM_AMOUNT,
                        ITEM_PMVVALUE = ITEM_PMVVALUE,
                        ITEM_SCHEME_CODE = ITEM_SCHEME_CODE,
                        ITEM_SCHEME_DESC = ITEM_SCHEME_DESC,
                        ITEM_ACCESSORIES_DESC = ITEM_ACCESSORIES_DESC,
                        ITEM_AR4_NO = ITEM_AR4_NO,
                        ITEM_AR4_DATE = ITEM_AR4_DATE,
                        ITEM_COMMISSION_RATE = ITEM_COMMISSION_RATE,
                        ITEM_DIVISION = ITEM_DIVISION,
                        ITEM_RANGE = ITEM_RANGE,
                        ITEM_REMARKS = ITEM_REMARKS,
                        ITEM_IECCODE = ITEM_IECCODE,
                        BR_SLNO = BR_SLNO,

                        ADDRESS1 = ADDRESS1,
                        ADDRESS2 = ADDRESS2,
                        ADDRESS3 = ADDRESS3,
                        ADDRESS4 = ADDRESS4,
                        ADDRESS5 = ADDRESS5,
                        ITEM_STR_CODE = ITEM_STR_CODE,
                        REWARD_POINTS = REWARD_POINTS,
                        FOB_VALUE = FOB_VALUE,
                        TOTAL_PMVVALUE = TOTAL_PMVVALUE,

                        DRAWBACK_ID = DRAWBACK_ID,
                        SCHEME_CODE = SCHEME_CODE,
                        DRAWBACK_SLNO = DRAWBACK_SLNO,
                        DRAWBACK_QTY = DRAWBACK_QTY,
                        DRAWBACK_UNIT = DRAWBACK_UNIT,
                        DRAWBACK_NOOFUNITS = DRAWBACK_NOOFUNITS,
                        DRAWBACK_RATE = DRAWBACK_RATE,
                        DRAWBACK_CAPS = DRAWBACK_CAPS,
                        DRAWBACK_DESC = DRAWBACK_DESC,
                        DRAWBACK_CUSTOMS = DRAWBACK_CUSTOMS,
                        DRAWBACK_EXCISE = DRAWBACK_EXCISE,
                        DBK_VALUE = DBK_VALUE,

                        STR_RATE = STR_RATE,
                        STR_AMOUNT = STR_AMOUNT,

                        NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS


                    });

                    //i++;
                }
                else
                {
                    list1.Add(new Rpt_Item_Details()
                    {

                        INVOICE_SLNO = INVOICE_SLNO,
                        INVOICE_NO = INVOICE_NO,
                        ITEM_SLNO = ITEM_SLNO,
                        ITEM_DESCRIPTION = ITEM_DESCRIPTION,
                        RITCNO = RITCNO,
                        ITEM_QTY = ITEM_QTY,
                        ITEM_QTY_CODE = ITEM_QTY_CODE,
                        ITEM_UNIT_PRICE = ITEM_UNIT_PRICE,
                        ITEM_PER = ITEM_PER,
                        ITEM_AMOUNT = ITEM_AMOUNT,
                        ITEM_PMVVALUE = ITEM_PMVVALUE,
                        ITEM_SCHEME_CODE = ITEM_SCHEME_CODE,
                        ITEM_SCHEME_DESC = ITEM_SCHEME_DESC,
                        ITEM_ACCESSORIES_DESC = ITEM_ACCESSORIES_DESC,
                        ITEM_AR4_NO = ITEM_AR4_NO,
                        ITEM_AR4_DATE = ITEM_AR4_DATE,
                        ITEM_COMMISSION_RATE = ITEM_COMMISSION_RATE,
                        ITEM_DIVISION = ITEM_DIVISION,
                        ITEM_RANGE = ITEM_RANGE,
                        ITEM_REMARKS = ITEM_REMARKS,
                        ITEM_IECCODE = ITEM_IECCODE,
                        BR_SLNO = BR_SLNO,

                        ADDRESS1 = ADDRESS1,
                        ADDRESS2 = ADDRESS2,
                        ADDRESS3 = ADDRESS3,
                        ADDRESS4 = ADDRESS4,
                        ADDRESS5 = ADDRESS5,
                        ITEM_STR_CODE = ITEM_STR_CODE,
                        REWARD_POINTS = REWARD_POINTS,
                        FOB_VALUE = FOB_VALUE,
                        TOTAL_PMVVALUE = TOTAL_PMVVALUE,

                        DRAWBACK_ID = DRAWBACK_ID,
                        SCHEME_CODE = SCHEME_CODE,
                        DRAWBACK_SLNO = DRAWBACK_SLNO,
                        DRAWBACK_QTY = DRAWBACK_QTY,
                        DRAWBACK_UNIT = DRAWBACK_UNIT,
                        DRAWBACK_NOOFUNITS = DRAWBACK_NOOFUNITS,
                        DRAWBACK_RATE = DRAWBACK_RATE,
                        DRAWBACK_CAPS = DRAWBACK_CAPS,
                        DRAWBACK_DESC = DRAWBACK_DESC,
                        DRAWBACK_CUSTOMS = DRAWBACK_CUSTOMS,
                        DRAWBACK_EXCISE = DRAWBACK_EXCISE,
                        DBK_VALUE = DBK_VALUE,

                        STR_RATE = STR_RATE,
                        STR_AMOUNT = STR_AMOUNT,

                        NUMBERTOWORDS = "RUPEES " + NUMBERTOWORDS


                    });
                }
                

                    b++;
                                
             }
            
            C++;

        }

        return list1;
    }

    public List<Rpt_Item_Details> Get_FOB_DRAWBACK_VALUE_Details(string ddlJobNo, DataTable ds, DataTable ds2, DataTable dt)
    {

        List<Rpt_Item_Details> list1 = new List<Rpt_Item_Details>();
        list1.Clear();


        int b = 0, C = 0, i = 0;

        double salary = 0.0,FOB_VAL=0.0,DRAWBACK_VAL=0.0;
        double salary1 = 0.0;
        double TOTAL_ITEM = 0.0;
        string preINVOICE_SLNO = "0", curINVOICE_SLNO = "0";

        while (ds.Rows.Count > C)
        {
            curINVOICE_SLNO = "";
            NUMBERTOWORDS = "";
            curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
            INVOICE_VALUE = ds.Rows[C]["INVOICE_VALUE"].ToString();
            EXCHANGE_RATE = ds.Rows[C]["EXCHANGE_RATE"].ToString();
            FREIGHT_RATE = ds.Rows[C]["FREIGHT_RATE"].ToString();
            INSURANCE_RATE = ds.Rows[C]["INSURANCE_RATE"].ToString();
            TERMS = ds.Rows[C]["TERMS"].ToString();
            if (INVOICE_VALUE == "")
                INVOICE_VALUE = "0.00";
            if (EXCHANGE_RATE == "")
                EXCHANGE_RATE = "0.00";
            if (FREIGHT_RATE == "")
                FREIGHT_RATE = "0.00";
            if (INSURANCE_RATE == "")
                INSURANCE_RATE = "0.00";
            //ASSESSABLE_TOTAL = 0;
            //TOTAL_ITEM = 0.0;
            //TOTAL_DUTY = 0.0;
            b = 0;

            DataView view = ds2.DefaultView;
            view.RowFilter = "INVOICE_SLNO = " + curINVOICE_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            while (dss.Tables[0].Rows.Count > b)
            {
                ITEM_STR_CODE = dss.Tables[0].Rows[b]["ITEM_STR_CODE"].ToString();

                ITEM_SLNO = dss.Tables[0].Rows[b]["ITEM_SLNO"].ToString();
                
                ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();
                
                ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();
               
                // --------------------------------------- ITEM CALCULATION---------------------------------------------------------------


                if (TERMS == "FOB")
                {
                    FOB_VAL = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) * Convert.ToDouble(EXCHANGE_RATE));
                }
                else if (TERMS == "CIF")
                {
                    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_RATE) + Convert.ToDouble(INSURANCE_RATE)));
                    FOB_VAL = FOB * Convert.ToDouble(EXCHANGE_RATE);
                }
                else if (TERMS == "CF")
                {
                    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_RATE)));
                    FOB_VAL = FOB * Convert.ToDouble(EXCHANGE_RATE);
                }
                else if (TERMS == "CI")
                {
                    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(INSURANCE_RATE)));
                    FOB_VAL = FOB * Convert.ToDouble(EXCHANGE_RATE);
                }


                DataView view1 = dt.DefaultView;
                view1.RowFilter = "ITEM_SLNO = " + ITEM_SLNO;
                DataTable table1 = view1.ToTable();
                //DataSet dss1 = new DataSet();
                //dss1.Tables.Add(table1);
                //while (dss.Tables[0].Rows.Count > b)
                //{

                if (table1.Rows.Count >= i && table1.Rows.Count != 0)
                {
                 
                    DRAWBACK_QTY = table1.Rows[i]["DRAWBACK_QTY"].ToString();
                    DRAWBACK_RATE = table1.Rows[i]["DRAWBACK_RATE"].ToString();
                    DRAWBACK_CAPS = table1.Rows[i]["DRAWBACK_CAPS"].ToString();
                 
                    // --------------------------------------- DRAWBACK CALCULATION---------------------------------------------------------------


                    cal1 = FOB_VAL * Convert.ToDouble(DRAWBACK_RATE);

                    if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
                    {
                        cal2 = Convert.ToDouble(DRAWBACK_QTY) * Convert.ToDouble(DRAWBACK_CAPS);
                    }

                    if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
                    {
                        if (cal1 > cal2)
                        {
                            DRAWBACK_VAL = cal2;
                        }
                        else
                        {
                            DRAWBACK_VAL = cal1;
                        }

                    }
                    else
                    {
                        DRAWBACK_VAL = cal1;
                    }

                    FOB_VALUE = FOB_VALUE + FOB_VAL;
                    DBK_VALUE = DBK_VALUE + DRAWBACK_VAL;
                    // --------------------------------------- STR CALCULATION---------------------------------------------------------------


                    // test();


                  
                }
                else
                {
                    FOB_VALUE = FOB_VALUE + FOB_VAL;
                    DBK_VALUE = DBK_VALUE + DRAWBACK_VAL;
                }


                b++;

            }

            C++;

        }

        return list1;
    }


    public List<Rpt_Item_Details> Get_STR_Details(string ddlJobNo, DataTable ds, DataTable ds2, DataTable dt,int Check_STR)
    {

        List<Rpt_Item_Details> list1 = new List<Rpt_Item_Details>();
        list1.Clear();


        int b = 0, C = 0, i = 0;

        double salary = 0.0, FOB_VAL = 0.0, DRAWBACK_VAL = 0.0;
        double salary1 = 0.0;
        double TOTAL_ITEM = 0.0;
        string preINVOICE_SLNO = "0", curINVOICE_SLNO = "0";

        while (ds.Rows.Count > C)
        {
            curINVOICE_SLNO = "";
            NUMBERTOWORDS = "";
            curINVOICE_SLNO = ds.Rows[C]["INVOICE_SLNO"].ToString();
            INVOICE_VALUE = ds.Rows[C]["INVOICE_VALUE"].ToString();
            EXCHANGE_RATE = ds.Rows[C]["EXCHANGE_RATE"].ToString();
            FREIGHT_RATE = ds.Rows[C]["FREIGHT_RATE"].ToString();
            INSURANCE_RATE = ds.Rows[C]["INSURANCE_RATE"].ToString();
            TERMS = ds.Rows[C]["TERMS"].ToString();
            if (INVOICE_VALUE == "")
                INVOICE_VALUE = "0.00";
            if (EXCHANGE_RATE == "")
                EXCHANGE_RATE = "0.00";
            if (FREIGHT_RATE == "")
                FREIGHT_RATE = "0.00";
            if (INSURANCE_RATE == "")
                INSURANCE_RATE = "0.00";
            //ASSESSABLE_TOTAL = 0;
            //TOTAL_ITEM = 0.0;
            //TOTAL_DUTY = 0.0;
            b = 0;

            DataView view = ds2.DefaultView;
            view.RowFilter = "INVOICE_SLNO = " + curINVOICE_SLNO;
            DataTable table = view.ToTable();
            DataSet dss = new DataSet();
            dss.Tables.Add(table);
            while (dss.Tables[0].Rows.Count > b)
            {
                INVOICE_SLNO = dss.Tables[0].Rows[b]["INVOICE_SLNO"].ToString();
                INVOICE_NO = dss.Tables[0].Rows[b]["INVOICE_NO"].ToString();
                ITEM_SLNO = dss.Tables[0].Rows[b]["ITEM_SLNO"].ToString();
                ITEM_STR_CODE = dss.Tables[0].Rows[b]["ITEM_STR_CODE"].ToString();

            
                ITEM_QTY = dss.Tables[0].Rows[b]["ITEM_QTY"].ToString();

                ITEM_UNIT_PRICE = dss.Tables[0].Rows[b]["ITEM_UNIT_PRICE"].ToString();

                // --------------------------------------- ITEM CALCULATION---------------------------------------------------------------


                if (TERMS == "FOB")
                {
                    FOB_VAL = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) * Convert.ToDouble(EXCHANGE_RATE));
                }
                else if (TERMS == "CIF")
                {
                    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_RATE) + Convert.ToDouble(INSURANCE_RATE)));
                    FOB_VAL = FOB * Convert.ToDouble(EXCHANGE_RATE);
                }
                else if (TERMS == "CF")
                {
                    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(FREIGHT_RATE)));
                    FOB_VAL = FOB * Convert.ToDouble(EXCHANGE_RATE);
                }
                else if (TERMS == "CI")
                {
                    double FOB = ((Convert.ToDouble(ITEM_QTY) * Convert.ToDouble(ITEM_UNIT_PRICE)) - (Convert.ToDouble(INSURANCE_RATE)));
                    FOB_VAL = FOB * Convert.ToDouble(EXCHANGE_RATE);
                }


                DataView view1 = dt.DefaultView;
                view1.RowFilter = "ITEM_SLNO = " + ITEM_SLNO;
                DataTable table1 = view1.ToTable();
                //DataSet dss1 = new DataSet();
                //dss1.Tables.Add(table1);
                //while (dss.Tables[0].Rows.Count > b)
                //{

               // --------------------------------------- STR CALCULATION---------------------------------------------------------------
               
                if (Check_STR == 2)
                {
                    if (ITEM_STR_CODE != "")
                    {

                        adminmaster adm = new adminmaster();
                        adm.STR_ID = "0";
                        adm.STR_SRNO = ITEM_STR_CODE;

                        adm.Ename = "select_value";

                        adm.startRowIndex = "0";
                        adm.maximumRows = "0";

                        DataSet ds1 = new DataSet();
                        ds1 = adm.RetrieveAll_STR_master();

                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            STR_RATE = ds1.Tables[0].Rows[0]["STR_RATE"].ToString();

                        }

                        STR_AMOUNT = Convert.ToString(Convert.ToDouble(STR_RATE) * FOB_VALUE);
                        list1.Add(new Rpt_Item_Details()
                        {

                            INVOICE_SLNO = INVOICE_SLNO,
                            INVOICE_NO = INVOICE_NO,
                            ITEM_SLNO = ITEM_SLNO,

                            ITEM_STR_CODE = ITEM_STR_CODE,


                            STR_RATE = STR_RATE,
                            STR_AMOUNT = STR_AMOUNT,


                        });
                    }

                    //i++;
                }
                else
                {
                    
                    list1.Add(new Rpt_Item_Details()
                    {

                        INVOICE_SLNO = "",
                        INVOICE_NO = "",
                        ITEM_SLNO = "",
                      
                        //ITEM_STR_CODE = ITEM_STR_CODE,
                       
                        STR_RATE = "",
                        STR_AMOUNT = STR_AMOUNT

                    

                    });
                }
                

                b++;

            }

            C++;

        }

        return list1;
    }
    //public void test()
    //{
    //    DataTable dataSet1 = new DataTable();
    //    dataSet1.Columns.Add("DRAWBACK_ID");
    //   dataSet1.Columns.Add("INVOICE_SLNO");
    //    dataSet1.Columns.Add("ITEM_SLNO");
    //    dataSet1.Columns.Add("SCHEME_CODE");
    //   dataSet1.Columns.Add("DRAWBACK_SLNO");
    //    dataSet1.Columns.Add("DRAWBACK_QTY");
    //    dataSet1.Columns.Add("DRAWBACK_UNIT");
    //    dataSet1.Columns.Add("DRAWBACK_NOOFUNITS");
    //    dataSet1.Columns.Add("DRAWBACK_RATE");
    //    dataSet1.Columns.Add("DRAWBACK_CAPS");
    //    dataSet1.Columns.Add("DRAWBACK_RATE");
    //    dataSet1.Columns.Add("DRAWBACK_DESC");
    //    dataSet1.Columns.Add("DRAWBACK_CUSTOMS");
    //    dataSet1.Columns.Add("DRAWBACK_EXCISE");
    //    dataSet1.Columns.Add("DBK_VALUE");
    //    DataRow newCustomersRow = dataSet1.NewRow();

    //    newCustomersRow["DRAWBACK_ID"] = DRAWBACK_ID;
    //    newCustomersRow["INVOICE_SLNO"] = INVOICE_SLNO;
    //    newCustomersRow["ITEM_SLNO"] = ITEM_SLNO;
    //    newCustomersRow["SCHEME_CODE"] = SCHEME_CODE;
    //    newCustomersRow["DRAWBACK_SLNO"] = DRAWBACK_SLNO;
    //    newCustomersRow["DRAWBACK_QTY"] = DRAWBACK_QTY;
    //    newCustomersRow["DRAWBACK_UNIT"] = DRAWBACK_UNIT;
    //    newCustomersRow["DRAWBACK_NOOFUNITS"] = DRAWBACK_NOOFUNITS;
    //    newCustomersRow["DRAWBACK_RATE"] = DRAWBACK_RATE;
    //    newCustomersRow["DRAWBACK_CAPS"] = DRAWBACK_CAPS;
    //    newCustomersRow["DRAWBACK_RATE"] = DRAWBACK_RATE;
    //    newCustomersRow["DRAWBACK_DESC"] = DRAWBACK_DESC;
    //    newCustomersRow["DRAWBACK_CUSTOMS"] = DRAWBACK_CUSTOMS;
    //    newCustomersRow["DRAWBACK_EXCISE"] = DRAWBACK_EXCISE;
    //    newCustomersRow["DBK_VALUE"] = DBK_VALUE;


    //    dataSet1.Rows.Add(newCustomersRow);
    //    DataSet d = new DataSet();
    //    d.Tables.Add(dataSet1);
    //    HttpContext.Current.Session["DRAWBACK"] = d.Tables[0];
    //}
}