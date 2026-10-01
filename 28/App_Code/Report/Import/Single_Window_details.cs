using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Single_Window_details
/// </summary>
public class Single_Window_details
{
    #region Private_Attributes
  
    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;
    private string _INFO_TYPE;
    private string _INFO_QUALIFIER;
    private string _INFO_CODE;
    private string _INFO_TEXT;
    private string _INFO_MSR;
    private string _INFO_UQC;
    private string _REGN_DATE;
    private string _REGN_VALIDITY;

    private string _CONSTITUENT_SRNO;
    private string _CONSTITUENT_ELEMENT_NAME;
    private string _CONSTITUENT_ELEMENT_CODE;
    private string _CONSTITUENT_PERCENTAGE;
    private string _CONSTITUENT_YIELD_PERCENTAGE;
    private string _ACTIVE_INGREDIENT;
    private string _PRODUCTION_BATCH_IDENTIFIER;
    private string _PRODUCTION_BATCH_QUANTITY;
    private string _UNIT_QTY_CODE;
    private string _DATE_OF_MANUFACTURING;
    private string _DATE_OF_EXPIRY;
    private string _BEST_BEFORE;
    private string _CONTROL_TYPE_CODE;
    private string _CONTROL_LOCATION;
    private string _CONTROL_START_DATE;
    private string _CONTROL_END_DATE;
    private string _CONTROL_RESULT_CODE;
    private string _CONTROL_RESULT_TEXT;


    private string _STMT_DECLARATION_TYPE;
    private string _STMT_DECLARATION_NUMBER;
    private string _STMT_DECLARATION_DATE;
    private string _STMT_TYPE;
    private string _STMT_CODE;
    private string _STMT_TEXT;
    private string _SUP_DECLARATION_NUMBER;
    private string _SUP_DECLARATION_DATE;
    private string _SUP_DECLARATION_TYPE;
    private string _UNIQUE_DOC_NUMBER;

    private string _CONTROL_MSR;
    private string _CONTROL_UQC;
    private string _CONTROL_SLNO;

    private string _DOC_TYPE_CODE;
    private string _DOC_ISSUING_PARTY_CODE;
    private string _DOC_ISSUING_PARTY_NAME_ADD1;
    private string _DOC_ISSUING_PARTY_NAME_ADD2;
    private string _DOC_ISSUING_PARTY_CITY;
    private string _DOC_ISSUING_PARTY_PIN;
    private string _DOC_REF_NUMBER;
    private string _PLACE_OF_ISSUE;
    private string _DOC_ISSUE_DATE;
    private string _DOC_EXPIRY_DATE;
    private string _BENEFICIARY_PARTY_CODE;
    private string _ICEGATE_DOC_FILE_NAME;
    
    private string _BENEFICIARY_PARTY_ADDRESS1;
    private string _BENEFICIARY_PARTY_ADDRESS2;
    private string _BENEFICIARY_PARTY_CITY;
    private string _BENEFICIARY_PARTY_PIN;
    private string _FILE_TYPE;
    private string _SELECT_TYPE;

    private string _DECLARATION_TYPE;
    private string _IMAGE_REF_NUMBER;
    private string _DOC_ISSUING_PARTY_NAME;
    private string _BENEFICIARY_PARTY_NAME;
    private string _ICEGATE_ID;



    #endregion

    #region Public_Attributes
    
    
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string INFO_TYPE { get { return _INFO_TYPE; } set { _INFO_TYPE = value; } }
    public string INFO_QUALIFIER { get { return _INFO_QUALIFIER; } set { _INFO_QUALIFIER = value; } }
    public string INFO_CODE { get { return _INFO_CODE; } set { _INFO_CODE = value; } }
    public string INFO_TEXT { get { return _INFO_TEXT; } set { _INFO_TEXT = value; } }
    public string INFO_MSR { get { return _INFO_MSR; } set { _INFO_MSR = value; } }
    public string INFO_UQC { get { return _INFO_UQC; } set { _INFO_UQC = value; } }
    public string REGN_DATE { get { return _REGN_DATE; } set { _REGN_DATE = value; } }
    public string REGN_VALIDITY { get { return _REGN_VALIDITY; } set { _REGN_VALIDITY = value; } }


    public string CONSTITUENT_SRNO { get { return _CONSTITUENT_SRNO; } set { _CONSTITUENT_SRNO = value; } }
    public string CONSTITUENT_ELEMENT_NAME { get { return _CONSTITUENT_ELEMENT_NAME; } set { _CONSTITUENT_ELEMENT_NAME = value; } }

    public string CONSTITUENT_ELEMENT_CODE { get { return _CONSTITUENT_ELEMENT_CODE; } set { _CONSTITUENT_ELEMENT_CODE = value; } }
    public string CONSTITUENT_PERCENTAGE { get { return _CONSTITUENT_PERCENTAGE; } set { _CONSTITUENT_PERCENTAGE = value; } }
    public string CONSTITUENT_YIELD_PERCENTAGE { get { return _CONSTITUENT_YIELD_PERCENTAGE; } set { _CONSTITUENT_YIELD_PERCENTAGE = value; } }
    public string ACTIVE_INGREDIENT { get { return _ACTIVE_INGREDIENT; } set { _ACTIVE_INGREDIENT = value; } }
    public string PRODUCTION_BATCH_IDENTIFIER { get { return _PRODUCTION_BATCH_IDENTIFIER; } set { _PRODUCTION_BATCH_IDENTIFIER = value; } }
    public string PRODUCTION_BATCH_QUANTITY { get { return _PRODUCTION_BATCH_QUANTITY; } set { _PRODUCTION_BATCH_QUANTITY = value; } }
    public string UNIT_QTY_CODE { get { return _UNIT_QTY_CODE; } set { _UNIT_QTY_CODE = value; } }
    public string DATE_OF_MANUFACTURING { get { return _DATE_OF_MANUFACTURING; } set { _DATE_OF_MANUFACTURING = value; } }
    public string DATE_OF_EXPIRY { get { return _DATE_OF_EXPIRY; } set { _DATE_OF_EXPIRY = value; } }
    public string BEST_BEFORE { get { return _BEST_BEFORE; } set { _BEST_BEFORE = value; } }
    public string CONTROL_TYPE_CODE { get { return _CONTROL_TYPE_CODE; } set { _CONTROL_TYPE_CODE = value; } }
    public string CONTROL_LOCATION { get { return _CONTROL_LOCATION; } set { _CONTROL_LOCATION = value; } }



    public string CONTROL_START_DATE { get { return _CONTROL_START_DATE; } set { _CONTROL_START_DATE = value; } }
    public string CONTROL_END_DATE { get { return _CONTROL_END_DATE; } set { _CONTROL_END_DATE = value; } }
    public string CONTROL_RESULT_CODE { get { return _CONTROL_RESULT_CODE; } set { _CONTROL_RESULT_CODE = value; } }
    public string CONTROL_RESULT_TEXT { get { return _CONTROL_RESULT_TEXT; } set { _CONTROL_RESULT_TEXT = value; } }
    public string STMT_DECLARATION_TYPE { get { return _STMT_DECLARATION_TYPE; } set { _STMT_DECLARATION_TYPE = value; } }
    public string STMT_DECLARATION_NUMBER { get { return _STMT_DECLARATION_NUMBER; } set { _STMT_DECLARATION_NUMBER = value; } }
    public string STMT_DECLARATION_DATE { get { return _STMT_DECLARATION_DATE; } set { _STMT_DECLARATION_DATE = value; } }
    public string STMT_TYPE { get { return _STMT_TYPE; } set { _STMT_TYPE = value; } }
    public string STMT_CODE { get { return _STMT_CODE; } set { _STMT_CODE = value; } }
    public string STMT_TEXT { get { return _STMT_TEXT; } set { _STMT_TEXT = value; } }

    public string CONTROL_MSR { get { return _CONTROL_MSR; } set { _CONTROL_MSR = value; } }
    public string CONTROL_UQC { get { return _CONTROL_UQC; } set { _CONTROL_UQC = value; } }
    public string CONTROL_SLNO { get { return _CONTROL_SLNO; } set { _CONTROL_SLNO = value; } }


    public string SUP_DECLARATION_NUMBER { get { return _SUP_DECLARATION_NUMBER; } set { _SUP_DECLARATION_NUMBER = value; } }
    public string SUP_DECLARATION_DATE { get { return _SUP_DECLARATION_DATE; } set { _SUP_DECLARATION_DATE = value; } }
    public string SUP_DECLARATION_TYPE { get { return _SUP_DECLARATION_TYPE; } set { _SUP_DECLARATION_TYPE = value; } }
    public string UNIQUE_DOC_NUMBER { get { return _UNIQUE_DOC_NUMBER; } set { _UNIQUE_DOC_NUMBER = value; } }
    public string DOC_TYPE_CODE { get { return _DOC_TYPE_CODE; } set { _DOC_TYPE_CODE = value; } }
    public string DOC_ISSUING_PARTY_CODE { get { return _DOC_ISSUING_PARTY_CODE; } set { _DOC_ISSUING_PARTY_CODE = value; } }
    public string DOC_ISSUING_PARTY_NAME_ADD1 { get { return _DOC_ISSUING_PARTY_NAME_ADD1; } set { _DOC_ISSUING_PARTY_NAME_ADD1 = value; } }
    public string DOC_ISSUING_PARTY_NAME_ADD2 { get { return _DOC_ISSUING_PARTY_NAME_ADD2; } set { _DOC_ISSUING_PARTY_NAME_ADD2 = value; } }
    public string DOC_ISSUING_PARTY_CITY { get { return _DOC_ISSUING_PARTY_CITY; } set { _DOC_ISSUING_PARTY_CITY = value; } }
    public string DOC_ISSUING_PARTY_PIN { get { return _DOC_ISSUING_PARTY_PIN; } set { _DOC_ISSUING_PARTY_PIN = value; } }

    
    public string DOC_REF_NUMBER { get { return _DOC_REF_NUMBER; } set { _DOC_REF_NUMBER = value; } }
    public string PLACE_OF_ISSUE { get { return _PLACE_OF_ISSUE; } set { _PLACE_OF_ISSUE = value; } }
    public string DOC_ISSUE_DATE { get { return _DOC_ISSUE_DATE; } set { _DOC_ISSUE_DATE = value; } }
    public string DOC_EXPIRY_DATE { get { return _DOC_EXPIRY_DATE; } set { _DOC_EXPIRY_DATE = value; } }
    public string BENEFICIARY_PARTY_CODE { get { return _BENEFICIARY_PARTY_CODE; } set { _BENEFICIARY_PARTY_CODE = value; } }    
    public string BENEFICIARY_PARTY_ADDRESS1 { get { return _BENEFICIARY_PARTY_ADDRESS1; } set { _BENEFICIARY_PARTY_ADDRESS1 = value; } }
    public string BENEFICIARY_PARTY_ADDRESS2 { get { return _BENEFICIARY_PARTY_ADDRESS2; } set { _BENEFICIARY_PARTY_ADDRESS2 = value; } }
    public string BENEFICIARY_PARTY_CITY { get { return _BENEFICIARY_PARTY_CITY; } set { _BENEFICIARY_PARTY_CITY = value; } }
    public string BENEFICIARY_PARTY_PIN { get { return _BENEFICIARY_PARTY_PIN; } set { _BENEFICIARY_PARTY_PIN = value; } }
    public string FILE_TYPE { get { return _FILE_TYPE; } set { _FILE_TYPE = value; } }
    public string SELECT_TYPE { get { return _SELECT_TYPE; } set { _SELECT_TYPE = value; } }
    public string ICEGATE_DOC_FILE_NAME { get { return _ICEGATE_DOC_FILE_NAME; } set { _ICEGATE_DOC_FILE_NAME = value; } }


    public string DECLARATION_TYPE { get { return _DECLARATION_TYPE; } set { _DECLARATION_TYPE = value; } }
    public string IMAGE_REF_NUMBER { get { return _IMAGE_REF_NUMBER; } set { _IMAGE_REF_NUMBER = value; } }
    public string DOC_ISSUING_PARTY_NAME { get { return _DOC_ISSUING_PARTY_NAME; } set { _DOC_ISSUING_PARTY_NAME = value; } }
    public string BENEFICIARY_PARTY_NAME { get { return _BENEFICIARY_PARTY_NAME; } set { _BENEFICIARY_PARTY_NAME = value; } }
    public string ICEGATE_ID { get { return _ICEGATE_ID; } set { _ICEGATE_ID = value; } }

    #endregion

    //public List<Single_Window_details> Get_Single_Window_details(DataTable Single_Window_dt)
    //{


    //    List<Single_Window_details> list = new List<Single_Window_details>();
    //    list.Clear();

    //    int i = 0;
    //    //foreach (DataRow dr in ds.Tables[0].Rows)

    //    while (Single_Window_dt.Rows.Count > i)
    //    {

    //        list.Add(new Single_Window_details()
    //        {
    //            //INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),

    //            INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
    //            ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),
    //            INFO_TYPE = Single_Window_dt.Rows[i]["INFO_TYPE"].ToString(),
    //            INFO_QUALIFIER = Single_Window_dt.Rows[i]["INFO_QUALIFIER"].ToString(),
    //            INFO_CODE = Single_Window_dt.Rows[i]["INFO_CODE"].ToString(),
    //            INFO_TEXT = Single_Window_dt.Rows[i]["INFO_TEXT"].ToString(),
    //            INFO_MSR = Single_Window_dt.Rows[i]["INFO_MSR"].ToString(),
    //            INFO_UQC = Single_Window_dt.Rows[i]["INFO_UQC"].ToString(),

    //            CONSTITUENT_SRNO = Single_Window_dt.Rows[i]["CONSTITUENT_SRNO"].ToString(),
    //            CONSTITUENT_ELEMENT_NAME = Single_Window_dt.Rows[i]["CONSTITUENT_ELEMENT_NAME"].ToString(),
    //            CONSTITUENT_ELEMENT_CODE = Single_Window_dt.Rows[i]["CONSTITUENT_ELEMENT_CODE"].ToString(),
    //            CONSTITUENT_PERCENTAGE = Single_Window_dt.Rows[i]["CONSTITUENT_PERCENTAGE"].ToString(),
    //            CONSTITUENT_YIELD_PERCENTAGE = Single_Window_dt.Rows[i]["CONSTITUENT_YIELD_PERCENTAGE"].ToString(),
    //            ACTIVE_INGREDIENT = Single_Window_dt.Rows[i]["ACTIVE_INGREDIENT"].ToString(),

    //            PRODUCTION_BATCH_IDENTIFIER = Single_Window_dt.Rows[i]["PRODUCTION_BATCH_IDENTIFIER"].ToString(),
    //            PRODUCTION_BATCH_QUANTITY = Single_Window_dt.Rows[i]["PRODUCTION_BATCH_QUANTITY"].ToString(),
    //            UNIT_QTY_CODE = Single_Window_dt.Rows[i]["UNIT_QTY_CODE"].ToString(),
    //            DATE_OF_MANUFACTURING = Single_Window_dt.Rows[i]["DATE_OF_MANUFACTURING"].ToString(),
    //            DATE_OF_EXPIRY = Single_Window_dt.Rows[i]["DATE_OF_EXPIRY"].ToString(),
    //            BEST_BEFORE = Single_Window_dt.Rows[i]["BEST_BEFORE"].ToString(),

    //            CONTROL_TYPE_CODE = Single_Window_dt.Rows[i]["CONTROL_TYPE_CODE"].ToString(),
    //            CONTROL_LOCATION = Single_Window_dt.Rows[i]["CONTROL_LOCATION"].ToString(),
    //            CONTROL_START_DATE = Single_Window_dt.Rows[i]["CONTROL_START_DATE"].ToString(),
    //            CONTROL_END_DATE = Single_Window_dt.Rows[i]["CONTROL_END_DATE"].ToString(),
    //            CONTROL_RESULT_CODE = Single_Window_dt.Rows[i]["CONTROL_RESULT_CODE"].ToString(),
    //            CONTROL_RESULT_TEXT = Single_Window_dt.Rows[i]["CONTROL_RESULT_TEXT"].ToString(),

    //            STMT_DECLARATION_TYPE = Single_Window_dt.Rows[i]["STMT_DECLARATION_TYPE"].ToString(),
    //            STMT_DECLARATION_NUMBER = Single_Window_dt.Rows[i]["STMT_DECLARATION_NUMBER"].ToString(),
    //            STMT_DECLARATION_DATE = Single_Window_dt.Rows[i]["STMT_DECLARATION_DATE"].ToString(),
    //            STMT_TYPE = Single_Window_dt.Rows[i]["STMT_TYPE"].ToString(),
    //            STMT_CODE = Single_Window_dt.Rows[i]["STMT_CODE"].ToString(),
    //            STMT_TEXT = Single_Window_dt.Rows[i]["STMT_TEXT"].ToString(),

    //            SUP_DECLARATION_NUMBER = Single_Window_dt.Rows[i]["SUP_DECLARATION_NUMBER"].ToString(),
    //            SUP_DECLARATION_DATE = Single_Window_dt.Rows[i]["SUP_DECLARATION_DATE"].ToString(),
    //            SUP_DECLARATION_TYPE = Single_Window_dt.Rows[i]["SUP_DECLARATION_TYPE"].ToString(),
    //            UNIQUE_DOC_NUMBER = Single_Window_dt.Rows[i]["UNIQUE_DOC_NUMBER"].ToString(),
    //            DOC_TYPE_CODE = Single_Window_dt.Rows[i]["DOC_TYPE_CODE"].ToString(),
    //            DOC_ISSUING_PARTY_CODE = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_CODE"].ToString(),
    //            DOC_ISSUING_PARTY_NAME_ADD1 = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString(),
    //            DOC_ISSUING_PARTY_NAME_ADD2 = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString(),
    //            DOC_ISSUING_PARTY_CITY = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_CITY"].ToString(),

    //            DOC_ISSUING_PARTY_PIN = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_PIN"].ToString(),
    //            DOC_REF_NUMBER = Single_Window_dt.Rows[i]["DOC_REF_NUMBER"].ToString(),
    //            PLACE_OF_ISSUE = Single_Window_dt.Rows[i]["PLACE_OF_ISSUE"].ToString(),
    //            DOC_ISSUE_DATE = Single_Window_dt.Rows[i]["DOC_ISSUE_DATE"].ToString(),
    //            DOC_EXPIRY_DATE = Single_Window_dt.Rows[i]["DOC_EXPIRY_DATE"].ToString(),
    //            BENEFICIARY_PARTY_CODE = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_CODE"].ToString(),
    //            BENEFICIARY_PARTY_ADDRESS1 = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_ADDRESS1"].ToString(),
    //            BENEFICIARY_PARTY_ADDRESS2 = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_ADDRESS2"].ToString(),
    //            BENEFICIARY_PARTY_CITY = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_CITY"].ToString(),
    //            BENEFICIARY_PARTY_PIN = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_PIN"].ToString(),
    //            FILE_TYPE = Single_Window_dt.Rows[i]["FILE_TYPE"].ToString()



    //        });

    //        i++;
    //    }
    //    return list;
    //}

    public List<Single_Window_details> Get_Single_Window_details_INFOTYPE(DataTable Single_Window_dt)
    {
        List<Single_Window_details> list = new List<Single_Window_details>();
        list.Clear();

        int i = 0;

        var FullName1 = from DataRow drr in Single_Window_dt.AsEnumerable()
                        where drr.Field<string>("INFO_TYPE") != ""
                        select drr;

        DataView dvv = FullName1.AsDataView();

        int count = dvv.Count;

        if (count > 0)
        {
            Single_Window_dt = dvv.ToTable();
            while (Single_Window_dt.Rows.Count > i)
            {
                list.Add(new Single_Window_details()
                {

                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),

                    INFO_TYPE = Single_Window_dt.Rows[i]["INFO_TYPE"].ToString(),
                    INFO_QUALIFIER = Single_Window_dt.Rows[i]["INFO_QUALIFIER"].ToString(),
                    INFO_CODE = Single_Window_dt.Rows[i]["INFO_CODE"].ToString(),
                    INFO_TEXT = Single_Window_dt.Rows[i]["INFO_TEXT"].ToString(),
                    INFO_MSR = Single_Window_dt.Rows[i]["INFO_MSR"].ToString(),
                    INFO_UQC = Single_Window_dt.Rows[i]["INFO_UQC"].ToString(),
                    REGN_DATE = Single_Window_dt.Rows[i]["REGN_DATE"].ToString().Replace("01/01/1900",""),
                    REGN_VALIDITY = Single_Window_dt.Rows[i]["REGN_VALIDITY"].ToString()


                });

                i++;
            }
        }
        return list;
    }

    public List<Single_Window_details> Get_Single_Window_details_Constituent(DataTable Single_Window_dt)
    {
        List<Single_Window_details> list = new List<Single_Window_details>();
        list.Clear();

        int i = 0;

        var FullName1 = from DataRow drr in Single_Window_dt.AsEnumerable()
                        where drr.Field<string>("CONSTITUENT_SRNO") != ""
                        select drr;

        DataView dvv_CONS = FullName1.AsDataView();

        int count = dvv_CONS.Count;

        if (count > 0)
        {
            Single_Window_dt = dvv_CONS.ToTable();
            while (Single_Window_dt.Rows.Count > i)
            {
                list.Add(new Single_Window_details()
                {

                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),

                    CONSTITUENT_SRNO = Single_Window_dt.Rows[i]["CONSTITUENT_SRNO"].ToString(),
                    CONSTITUENT_ELEMENT_NAME = Single_Window_dt.Rows[i]["CONSTITUENT_ELEMENT_NAME"].ToString(),
                    CONSTITUENT_ELEMENT_CODE = Single_Window_dt.Rows[i]["CONSTITUENT_ELEMENT_CODE"].ToString(),
                    CONSTITUENT_PERCENTAGE = Single_Window_dt.Rows[i]["CONSTITUENT_PERCENTAGE"].ToString(),
                    CONSTITUENT_YIELD_PERCENTAGE = Single_Window_dt.Rows[i]["CONSTITUENT_YIELD_PERCENTAGE"].ToString(),
                    ACTIVE_INGREDIENT = Single_Window_dt.Rows[i]["ACTIVE_INGREDIENT"].ToString()

                });

                i++;
            }
        }
        return list;
    }

    public List<Single_Window_details> Get_Single_Window_details_PRODUCTION(DataTable Single_Window_dt)
    {
        List<Single_Window_details> list = new List<Single_Window_details>();
        list.Clear();

        int i = 0;
       
        var FullName1 = from DataRow drr in Single_Window_dt.AsEnumerable()
                        where drr.Field<string>("PRODUCTION_BATCH_IDENTIFIER") != ""
                        select drr;

        DataView dvv = FullName1.AsDataView();

        int count = dvv.Count;

        if (count > 0)
        {
            Single_Window_dt = dvv.ToTable();
            while (Single_Window_dt.Rows.Count > i)
            {
                list.Add(new Single_Window_details()
                {
                   
                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),


                    PRODUCTION_BATCH_IDENTIFIER = Single_Window_dt.Rows[i]["PRODUCTION_BATCH_IDENTIFIER"].ToString(),
                    PRODUCTION_BATCH_QUANTITY = Single_Window_dt.Rows[i]["PRODUCTION_BATCH_QUANTITY"].ToString(),
                    UNIT_QTY_CODE = Single_Window_dt.Rows[i]["UNIT_QTY_CODE"].ToString(),
                    DATE_OF_MANUFACTURING = Single_Window_dt.Rows[i]["DATE_OF_MANUFACTURING"].ToString(),
                    DATE_OF_EXPIRY = Single_Window_dt.Rows[i]["DATE_OF_EXPIRY"].ToString(),
                    BEST_BEFORE = Single_Window_dt.Rows[i]["BEST_BEFORE"].ToString()

                });

                i++;
            }
        }    
        return list;
    }

    public List<Single_Window_details> Get_Single_Window_details_CONTROL(DataTable Single_Window_dt)
    {
        List<Single_Window_details> list = new List<Single_Window_details>();
        list.Clear();

        int i = 0;

        var FullName1 = from DataRow drr in Single_Window_dt.AsEnumerable()
                        where drr.Field<string>("CONTROL_TYPE_CODE") != ""
                        select drr;

        DataView dvv = FullName1.AsDataView();

        int count = dvv.Count;

        if (count > 0)
        {
            Single_Window_dt = dvv.ToTable();
            while (Single_Window_dt.Rows.Count > i)
            {
                /* hide on 28-09-2024
                if (Single_Window_dt.Rows[i]["CONTROL_TYPE_CODE"].ToString().Contains("SEC65"))
                {
                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString();
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString();
                }
                else
                {
                     INVOICE_SLNO="0";
                     ITEM_SLNO = "0";
                }
                */

                INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString();
                ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString();

                list.Add(new Single_Window_details()
                {

                   INVOICE_SLNO=INVOICE_SLNO,
                    ITEM_SLNO=ITEM_SLNO,
                   
                    CONTROL_TYPE_CODE = Single_Window_dt.Rows[i]["CONTROL_TYPE_CODE"].ToString(),
                    CONTROL_LOCATION = Single_Window_dt.Rows[i]["CONTROL_LOCATION"].ToString(),
                    CONTROL_START_DATE = Single_Window_dt.Rows[i]["CONTROL_START_DATE"].ToString(),
                    CONTROL_END_DATE = Single_Window_dt.Rows[i]["CONTROL_END_DATE"].ToString(),
                    CONTROL_RESULT_CODE = Single_Window_dt.Rows[i]["CONTROL_RESULT_CODE"].ToString(),
                    CONTROL_RESULT_TEXT = Single_Window_dt.Rows[i]["CONTROL_RESULT_TEXT"].ToString(),

                    CONTROL_MSR = Single_Window_dt.Rows[i]["CONTROL_MSR"].ToString() + " " + Single_Window_dt.Rows[i]["CONTROL_UQC"].ToString(),
                    CONTROL_SLNO = Single_Window_dt.Rows[i]["CONTROL_SLNO"].ToString()


                });

                i++;
            }
        }
        return list;
    }

    public List<Single_Window_details> Get_Single_Window_details_STATEMENT(DataTable Single_Window_dt)
    {
        List<Single_Window_details> list = new List<Single_Window_details>();
        list.Clear();

        string Check_Stmt = HttpContext.Current.Session["Check_Stmt"].ToString();
        string Stmt_Text = "";

        int i = 0;

        var FullName1 = from DataRow drr in Single_Window_dt.AsEnumerable()
                        where drr.Field<string>("STMT_TYPE") != ""
                        select drr;

        DataView dvv_STMT = FullName1.AsDataView();

        int count = dvv_STMT.Count;

        //if (Check_Stmt == "True")
        //{
            if (count > 0)
            {
                Single_Window_dt = dvv_STMT.ToTable();
                while (Single_Window_dt.Rows.Count > i)
                {
                    if (Check_Stmt == "True")
                    {
                        Stmt_Text = Single_Window_dt.Rows[i]["STMT_TEXT"].ToString();
                    }
                    list.Add(new Single_Window_details()
                    {

                        INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                        ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),

                        STMT_DECLARATION_TYPE = Single_Window_dt.Rows[i]["STMT_DECLARATION_TYPE"].ToString(),
                        STMT_DECLARATION_NUMBER = Single_Window_dt.Rows[i]["STMT_DECLARATION_NUMBER"].ToString(),
                        STMT_DECLARATION_DATE = Single_Window_dt.Rows[i]["STMT_DECLARATION_DATE"].ToString(),
                        STMT_TYPE = Single_Window_dt.Rows[i]["STMT_TYPE"].ToString(),
                        STMT_CODE = Single_Window_dt.Rows[i]["STMT_CODE"].ToString(),
                        STMT_TEXT = Stmt_Text,

                    });

                    i++;
                }
            }
        //}
        return list;
    }

    public List<Single_Window_details> Get_Single_Window_details_SUP_DOC(DataTable Single_Window_dt)
    {
        List<Single_Window_details> list = new List<Single_Window_details>();
        list.Clear();

        int i = 0;

        var FullName1 = from DataRow drr in Single_Window_dt.AsEnumerable()
                        where drr.Field<string>("DECLARATION_TYPE") != ""
                        select drr;

        DataView dvv_SUP = FullName1.AsDataView();

        int count = dvv_SUP.Count;

        if (count > 0)
        {
            Single_Window_dt = dvv_SUP.ToTable();
            while (Single_Window_dt.Rows.Count > i)
            {

                string select_level = "";
                //string Transport_Mode = HttpContext.Current.Session["TRANSPORT_MODE"].ToString();


                /* this below condition hide by Chithra on 02/10/2020 suggest by Subbu sir for can't identity which Itemslno
                    if (Single_Window_dt.Rows[i]["SELECT_TYPE"].ToString() == "JOB")
                    {
                        INVOICE_SLNO = "0";
                        ITEM_SLNO = "0";
                        select_level = "Job Level";
                    }
                    else if (Single_Window_dt.Rows[i]["SELECT_TYPE"].ToString() == "INVOICE")
                    {
                        INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString();
                        ITEM_SLNO = "0";
                        select_level = "Invoice Level";
                    }
                    else if (Single_Window_dt.Rows[i]["SELECT_TYPE"].ToString() == "ITEM")
                    {
                        INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString();
                        ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString();
                        select_level = "Item Level";
                    }
                    else
                    {
                        INVOICE_SLNO = "0";
                        ITEM_SLNO = "0";
                        select_level = "Job Level";
                    }
              */
               

                list.Add(new Single_Window_details()
                {
                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),

                    //INVOICE_SLNO = INVOICE_SLNO ,
                    //ITEM_SLNO = ITEM_SLNO ,

                    DECLARATION_TYPE = Single_Window_dt.Rows[i]["DECLARATION_TYPE"].ToString(),
                    IMAGE_REF_NUMBER = Single_Window_dt.Rows[i]["IMAGE_REF_NUMBER"].ToString(),
                    DOC_TYPE_CODE = Single_Window_dt.Rows[i]["DOC_TYPE_CODE"].ToString(),
                    DOC_ISSUING_PARTY_CODE = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_CODE"].ToString(),
                    DOC_ISSUING_PARTY_NAME = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_NAME"].ToString(),
                    DOC_ISSUING_PARTY_NAME_ADD1 = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString(),
                    DOC_ISSUING_PARTY_NAME_ADD2 = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString(),
                    DOC_ISSUING_PARTY_CITY = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_CITY"].ToString(),

                    DOC_ISSUING_PARTY_PIN = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_PIN"].ToString(),
                    DOC_REF_NUMBER = Single_Window_dt.Rows[i]["DOC_REF_NUMBER"].ToString(),
                    PLACE_OF_ISSUE = Single_Window_dt.Rows[i]["PLACE_OF_ISSUE"].ToString(),
                    DOC_ISSUE_DATE = Single_Window_dt.Rows[i]["DOC_ISSUE_DATE"].ToString(),
                    DOC_EXPIRY_DATE = Single_Window_dt.Rows[i]["DOC_EXPIRY_DATE"].ToString(),
                    BENEFICIARY_PARTY_CODE = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_CODE"].ToString(),
                    BENEFICIARY_PARTY_NAME = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_NAME"].ToString(),
                    BENEFICIARY_PARTY_ADDRESS1 = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_ADDRESS1"].ToString(),
                    BENEFICIARY_PARTY_ADDRESS2 = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_ADDRESS2"].ToString(),
                    BENEFICIARY_PARTY_CITY = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_CITY"].ToString(),
                    BENEFICIARY_PARTY_PIN = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_PIN"].ToString(),
                    FILE_TYPE = Single_Window_dt.Rows[i]["FILE_TYPE"].ToString(),
                    SELECT_TYPE = select_level,
                    ICEGATE_ID = Single_Window_dt.Rows[i]["ICEGATE_ID"].ToString(),
                    ICEGATE_DOC_FILE_NAME = Single_Window_dt.Rows[i]["ICEGATE_DOC_FILE_NAME"].ToString()

                });

                i++;
            }
        }
        return list;
    }

}