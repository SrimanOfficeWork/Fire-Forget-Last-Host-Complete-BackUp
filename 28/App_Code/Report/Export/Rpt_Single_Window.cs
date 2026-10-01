using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Rpt_Single_Window
/// </summary>
public class Rpt_Single_Window
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
    private string _INFO_SERIAL_NO;

    private string _CONSTITUENT_SRNO;
    private string _CONSTITUENT_ELEMENT_NAME;
    private string _CONSTITUENT_ELEMENT_CODE;
    private string _CONSTITUENT_PERCENTAGE;
    private string _CONSTITUENT_YIELD_PERCENTAGE;
    private string _ACTIVE_INGREDIENT;
    private string _CONSTITUENT_SERIAL_NO;

    private string _PRODUCTION_BATCH_IDENTIFIER;
    private string _PRODUCTION_BATCH_QUANTITY;
    private string _UNIT_QTY_CODE;
    private string _DATE_OF_MANUFACTURING;
    private string _DATE_OF_EXPIRY;
    private string _BEST_BEFORE;
    private string _PRODUCTION_SERIAL_NO;

    private string _CONTROL_TYPE_CODE;
    private string _CONTROL_LOCATION;
    private string _CONTROL_START_DATE;
    private string _CONTROL_END_DATE;
    private string _CONTROL_RESULT_CODE;
    private string _CONTROL_RESULT_TEXT;
    private string _CONTROL_SERIAL_NO;

    private string _STMT_DECLARATION_TYPE;
    private string _STMT_DECLARATION_NUMBER;
    private string _STMT_DECLARATION_DATE;
    private string _STMT_TYPE;
    private string _STMT_CODE;
    private string _STMT_TEXT;
    private string _STMT_SERIAL_NO;

    private string _UNIQUE_DOC_NUMBER;
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
    private string _BENEFICIARY_PARTY_ADDRESS1;
    private string _BENEFICIARY_PARTY_ADDRESS2;
    private string _BENEFICIARY_PARTY_CITY;
    private string _BENEFICIARY_PARTY_PIN;
    private string _FILE_TYPE;
    private string _SUP_SERIAL_NO;
    private string _DOC_ISSUING_PARTY_NAME;
    private string _BENEFICIARY_PARTY_NAME;
    private string _ICEGATE_ID;
    private string _ICEGATE_DOC_FILE_NAME;
    private string _SELECT_TYPE;

   

    #endregion

    #region Public Attributes

    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string INFO_TYPE { get { return _INFO_TYPE; } set { _INFO_TYPE = value; } }
    public string INFO_QUALIFIER { get { return _INFO_QUALIFIER; } set { _INFO_QUALIFIER = value; } }
    public string INFO_CODE { get { return _INFO_CODE; } set { _INFO_CODE = value; } }
    public string INFO_TEXT { get { return _INFO_TEXT; } set { _INFO_TEXT = value; } }
    public string INFO_MSR { get { return _INFO_MSR; } set { _INFO_MSR = value; } }
    public string INFO_UQC { get { return _INFO_UQC; } set { _INFO_UQC = value; } }
    public string INFO_SERIAL_NO { get { return _INFO_SERIAL_NO; } set { _INFO_SERIAL_NO = value; } }

    public string CONSTITUENT_SRNO { get { return _CONSTITUENT_SRNO; } set { _CONSTITUENT_SRNO = value; } }
    public string CONSTITUENT_ELEMENT_NAME { get { return _CONSTITUENT_ELEMENT_NAME; } set { _CONSTITUENT_ELEMENT_NAME = value; } }
     public string CONSTITUENT_ELEMENT_CODE { get { return _CONSTITUENT_ELEMENT_CODE; } set { _CONSTITUENT_ELEMENT_CODE = value; } }
    public string CONSTITUENT_PERCENTAGE { get { return _CONSTITUENT_PERCENTAGE; } set { _CONSTITUENT_PERCENTAGE = value; } }
    public string CONSTITUENT_YIELD_PERCENTAGE { get { return _CONSTITUENT_YIELD_PERCENTAGE; } set { _CONSTITUENT_YIELD_PERCENTAGE = value; } }
    public string ACTIVE_INGREDIENT { get { return _ACTIVE_INGREDIENT; } set { _ACTIVE_INGREDIENT = value; } }
     public string CONSTITUENT_SERIAL_NO { get { return _CONSTITUENT_SERIAL_NO; } set { _CONSTITUENT_SERIAL_NO = value; } }

    public string PRODUCTION_BATCH_IDENTIFIER { get { return _PRODUCTION_BATCH_IDENTIFIER; } set { _PRODUCTION_BATCH_IDENTIFIER = value; } }
    public string PRODUCTION_BATCH_QUANTITY { get { return _PRODUCTION_BATCH_QUANTITY; } set { _PRODUCTION_BATCH_QUANTITY = value; } }
    public string UNIT_QTY_CODE { get { return _UNIT_QTY_CODE; } set { _UNIT_QTY_CODE = value; } }
    public string DATE_OF_MANUFACTURING { get { return _DATE_OF_MANUFACTURING; } set { _DATE_OF_MANUFACTURING = value; } }
    public string DATE_OF_EXPIRY { get { return _DATE_OF_EXPIRY; } set { _DATE_OF_EXPIRY = value; } }
    public string BEST_BEFORE { get { return _BEST_BEFORE; } set { _BEST_BEFORE = value; } }
    public string PRODUCTION_SERIAL_NO { get { return _PRODUCTION_SERIAL_NO; } set { _PRODUCTION_SERIAL_NO = value; } }

    public string CONTROL_TYPE_CODE { get { return _CONTROL_TYPE_CODE; } set { _CONTROL_TYPE_CODE = value; } }
    public string CONTROL_LOCATION { get { return _CONTROL_LOCATION; } set { _CONTROL_LOCATION = value; } }
    public string CONTROL_START_DATE { get { return _CONTROL_START_DATE; } set { _CONTROL_START_DATE = value; } }

     public string CONTROL_END_DATE { get { return _CONTROL_END_DATE; } set { _CONTROL_END_DATE = value; } }
    public string CONTROL_RESULT_CODE { get { return _CONTROL_RESULT_CODE; } set { _CONTROL_RESULT_CODE = value; } }
    public string CONTROL_RESULT_TEXT { get { return _CONTROL_RESULT_TEXT; } set { _CONTROL_RESULT_TEXT = value; } }
    public string CONTROL_SERIAL_NO { get { return _CONTROL_SERIAL_NO; } set { _CONTROL_SERIAL_NO = value; } }

  
    public string STMT_TYPE { get { return _STMT_TYPE; } set { _STMT_TYPE = value; } }
    public string STMT_CODE { get { return _STMT_CODE; } set { _STMT_CODE = value; } }
    public string STMT_TEXT { get { return _STMT_TEXT; } set { _STMT_TEXT = value; } }
    public string STMT_SERIAL_NO { get { return _STMT_SERIAL_NO; } set { _STMT_SERIAL_NO = value; } }


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
    public string SUP_SERIAL_NO { get { return _SUP_SERIAL_NO; } set { _SUP_SERIAL_NO = value; } }

    public string DOC_ISSUING_PARTY_NAME { get { return _DOC_ISSUING_PARTY_NAME; } set { _DOC_ISSUING_PARTY_NAME = value; } }
    public string BENEFICIARY_PARTY_NAME { get { return _BENEFICIARY_PARTY_NAME; } set { _BENEFICIARY_PARTY_NAME = value; } }

    public string ICEGATE_ID { get { return _ICEGATE_ID; } set { _ICEGATE_ID = value; } }
    public string ICEGATE_DOC_FILE_NAME { get { return _ICEGATE_DOC_FILE_NAME; } set { _ICEGATE_DOC_FILE_NAME = value; } }
    public string SELECT_TYPE { get { return _SELECT_TYPE; } set { _SELECT_TYPE = value; } }

    #endregion

    public List<Rpt_Single_Window> Get_Single_Window_details_INFOTYPE(DataTable Single_Window_dt)
    {
        List<Rpt_Single_Window> list = new List<Rpt_Single_Window>();
        list.Clear();

        int i = 0;

        var FullName1 = from DataRow drr in Single_Window_dt.AsEnumerable()
                        where drr.Field<string>("INFO_TYPE") != ""
                        select drr;

        DataView dvv = FullName1.AsDataView();

        int count = dvv.Count;
        string INFO_TEXT = "";

        if (count > 0)
        {
            Single_Window_dt = dvv.ToTable();
            while (Single_Window_dt.Rows.Count > i)
            {
                //if (Connection.COMPANYID() == "747" || Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10")
                //{
                //    if (Single_Window_dt.Rows[i]["INFO_CODE"].ToString() == "RODTEPY")
                //    {
                //        INFO_TEXT = "Claimed";
                //    }
                //    else
                //    {
                //        INFO_TEXT = "Not Claimed";
                //    }
                //}
                //else
                //{
                //    INFO_TEXT = Single_Window_dt.Rows[i]["INFO_CODE"].ToString();
                //}

                if (Single_Window_dt.Rows[i]["INFO_CODE"].ToString() == "RODTEPY")  // Implemented on 22July2021 by Sathish With Bala
                {
                    INFO_TEXT = "Claimed";
                }
                else if (Single_Window_dt.Rows[i]["INFO_CODE"].ToString() == "RODTEPN")
                {
                    INFO_TEXT = "Not Claimed";
                }
                else if (Single_Window_dt.Rows[i]["INFO_CODE"].ToString() == "DTASBY")
                {
                    INFO_TEXT = Single_Window_dt.Rows[i]["INFO_TEXT"].ToString();
                }
                else
                {
                    INFO_TEXT = "";
                }

                list.Add(new Rpt_Single_Window()
                {

                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),

                    INFO_TYPE = Single_Window_dt.Rows[i]["INFO_TYPE"].ToString(),
                    INFO_QUALIFIER = Single_Window_dt.Rows[i]["INFO_QUALIFIER"].ToString(),
                    INFO_CODE = Single_Window_dt.Rows[i]["INFO_CODE"].ToString(),
                    INFO_TEXT = INFO_TEXT,
                    INFO_MSR = Single_Window_dt.Rows[i]["INFO_MSR"].ToString(),
                    INFO_UQC = Single_Window_dt.Rows[i]["INFO_UQC"].ToString(),
                    INFO_SERIAL_NO = Single_Window_dt.Rows[i]["SLNO"].ToString()

                });

                i++;
            }
        }
        return list;
    }

    public List<Rpt_Single_Window> Get_Single_Window_details_Constituent(DataTable Single_Window_dt)
    {
        List<Rpt_Single_Window> list = new List<Rpt_Single_Window>();
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
                list.Add(new Rpt_Single_Window()
                {

                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),

                    CONSTITUENT_SRNO = Single_Window_dt.Rows[i]["CONSTITUENT_SRNO"].ToString(),
                    CONSTITUENT_ELEMENT_NAME = Single_Window_dt.Rows[i]["CONSTITUENT_ELEMENT_NAME"].ToString(),
                    CONSTITUENT_ELEMENT_CODE = Single_Window_dt.Rows[i]["CONSTITUENT_ELEMENT_CODE"].ToString(),
                    CONSTITUENT_PERCENTAGE = Single_Window_dt.Rows[i]["CONSTITUENT_PERCENTAGE"].ToString(),
                    CONSTITUENT_YIELD_PERCENTAGE = Single_Window_dt.Rows[i]["CONSTITUENT_YIELD_PERCENTAGE"].ToString(),
                    ACTIVE_INGREDIENT = Single_Window_dt.Rows[i]["ACTIVE_INGREDIENT"].ToString(),
                    CONSTITUENT_SERIAL_NO = Single_Window_dt.Rows[i]["SLNO"].ToString()

                });

                i++;
            }
        }
        return list;
    }

    public List<Rpt_Single_Window> Get_Single_Window_details_PRODUCTION(DataTable Single_Window_dt)
    {
        List<Rpt_Single_Window> list = new List<Rpt_Single_Window>();
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
                list.Add(new Rpt_Single_Window()
                {

                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),


                    PRODUCTION_BATCH_IDENTIFIER = Single_Window_dt.Rows[i]["PRODUCTION_BATCH_IDENTIFIER"].ToString(),
                    PRODUCTION_BATCH_QUANTITY = Single_Window_dt.Rows[i]["PRODUCTION_BATCH_QUANTITY"].ToString(),
                    UNIT_QTY_CODE = Single_Window_dt.Rows[i]["UNIT_QTY_CODE"].ToString(),
                    DATE_OF_MANUFACTURING = Single_Window_dt.Rows[i]["DATE_OF_MANUFACTURING"].ToString(),
                    DATE_OF_EXPIRY = Single_Window_dt.Rows[i]["DATE_OF_EXPIRY"].ToString(),
                    BEST_BEFORE = Single_Window_dt.Rows[i]["BEST_BEFORE"].ToString(),
                    PRODUCTION_SERIAL_NO = Single_Window_dt.Rows[i]["SLNO"].ToString()

                });

                i++;
            }
        }
        return list;
    }

    public List<Rpt_Single_Window> Get_Single_Window_details_CONTROL(DataTable Single_Window_dt)
    {
        List<Rpt_Single_Window> list = new List<Rpt_Single_Window>();
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
                list.Add(new Rpt_Single_Window()
                {

                    //INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    //ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),
                    INVOICE_SLNO = "0",
                    ITEM_SLNO = "0",
                    CONTROL_TYPE_CODE = Single_Window_dt.Rows[i]["CONTROL_TYPE_CODE"].ToString(),
                    CONTROL_LOCATION = Single_Window_dt.Rows[i]["CONTROL_LOCATION"].ToString(),
                    CONTROL_START_DATE = Single_Window_dt.Rows[i]["CONTROL_START_DATE"].ToString(),
                    CONTROL_END_DATE = Single_Window_dt.Rows[i]["CONTROL_END_DATE"].ToString(),
                    CONTROL_RESULT_CODE = Single_Window_dt.Rows[i]["CONTROL_RESULT_CODE"].ToString(),
                    CONTROL_RESULT_TEXT = Single_Window_dt.Rows[i]["CONTROL_RESULT_TEXT"].ToString(),
                    CONTROL_SERIAL_NO = Single_Window_dt.Rows[i]["SLNO"].ToString()

                });

                i++;
            }
        }
        return list;
    }

    public List<Rpt_Single_Window> Get_Single_Window_details_STATEMENT(DataTable Single_Window_dt)
    {
        List<Rpt_Single_Window> list = new List<Rpt_Single_Window>();
        list.Clear();

        int i = 0;

        string Check_Stmt = HttpContext.Current.Session["Check_Stmt"].ToString();

        var FullName1 = from DataRow drr in Single_Window_dt.AsEnumerable()
                        where drr.Field<string>("STMT_TYPE") != ""
                        select drr;

        DataView dvv_STMT = FullName1.AsDataView();

        if (Check_Stmt == "False")
        {
            foreach (DataRow row in dvv_STMT.Table.Rows)
            {
                if (Connection.COMPANYID() == "480")
                {
                    if (i != 0)
                    {
                        row["STMT_TEXT"] = "";
                    }
                    i = 1;
                }
                else
                {
                    row["STMT_TEXT"] = "";
                }
            }
        }

        i = 0;
        int count = dvv_STMT.Count;
        if (count > 0)
        {
            Single_Window_dt = dvv_STMT.ToTable();
            while (Single_Window_dt.Rows.Count > i)
            {

                list.Add(new Rpt_Single_Window()
                {

                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),
                    STMT_TYPE = Single_Window_dt.Rows[i]["STMT_TYPE"].ToString(),
                    STMT_CODE = Single_Window_dt.Rows[i]["STMT_CODE"].ToString(),
                    STMT_TEXT = Single_Window_dt.Rows[i]["STMT_TEXT"].ToString(),
                    STMT_SERIAL_NO = Single_Window_dt.Rows[i]["SLNO"].ToString()

                });

                i++;
            }
        }

        return list;
    }

    public List<Rpt_Single_Window> Get_Single_Window_details_SUP_DOC(DataTable Single_Window_dt)
    {
        List<Rpt_Single_Window> list = new List<Rpt_Single_Window>();
        list.Clear();

        int i = 0;

        var FullName1 = from DataRow drr in Single_Window_dt.AsEnumerable()
                        where drr.Field<string>("DOC_TYPE_CODE") != ""
                        select drr;

        DataView dvv_SUP = FullName1.AsDataView();

        int count = dvv_SUP.Count;

        if (count > 0)
        {
            Single_Window_dt = dvv_SUP.ToTable();
            while (Single_Window_dt.Rows.Count > i)
            {
                list.Add(new Rpt_Single_Window()
                {

                    INVOICE_SLNO = Single_Window_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                    ITEM_SLNO = Single_Window_dt.Rows[i]["ITEM_SLNO"].ToString(),
                    UNIQUE_DOC_NUMBER = Single_Window_dt.Rows[i]["UNIQUE_DOC_NUMBER"].ToString(),
                    DOC_TYPE_CODE = Single_Window_dt.Rows[i]["DOC_TYPE_CODE"].ToString(),
                    DOC_ISSUING_PARTY_CODE = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_CODE"].ToString(),
                    DOC_ISSUING_PARTY_NAME_ADD1 = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString(),
                    DOC_ISSUING_PARTY_NAME_ADD2 = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString(),
                    DOC_ISSUING_PARTY_CITY = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_CITY"].ToString(),

                    DOC_ISSUING_PARTY_PIN = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_PIN"].ToString(),
                    DOC_REF_NUMBER = Single_Window_dt.Rows[i]["DOC_REF_NUMBER"].ToString(),
                    PLACE_OF_ISSUE = Single_Window_dt.Rows[i]["PLACE_OF_ISSUE"].ToString(),
                    DOC_ISSUE_DATE = Single_Window_dt.Rows[i]["DOC_ISSUE_DATE"].ToString(),
                    DOC_EXPIRY_DATE = Single_Window_dt.Rows[i]["DOC_EXPIRY_DATE"].ToString(),
                    BENEFICIARY_PARTY_CODE = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_CODE"].ToString(),
                    BENEFICIARY_PARTY_ADDRESS1 = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_ADDRESS1"].ToString(),
                    BENEFICIARY_PARTY_ADDRESS2 = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_ADDRESS2"].ToString(),
                    BENEFICIARY_PARTY_CITY = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_CITY"].ToString(),
                    BENEFICIARY_PARTY_PIN = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_PIN"].ToString(),
                    FILE_TYPE = Single_Window_dt.Rows[i]["FILE_TYPE"].ToString(),
                    SUP_SERIAL_NO = Single_Window_dt.Rows[i]["SLNO"].ToString(),
                    DOC_ISSUING_PARTY_NAME = Single_Window_dt.Rows[i]["DOC_ISSUING_PARTY_NAME"].ToString(),
                    BENEFICIARY_PARTY_NAME = Single_Window_dt.Rows[i]["BENEFICIARY_PARTY_NAME"].ToString(),
                    ICEGATE_ID = Single_Window_dt.Rows[i]["ICEGATE_ID"].ToString(),
                    ICEGATE_DOC_FILE_NAME = Single_Window_dt.Rows[i]["ICEGATE_DOC_FILE_NAME"].ToString(),
                    SELECT_TYPE = Single_Window_dt.Rows[i]["SELECT_TYPE"].ToString()



                });

                i++;
            }
        }
        return list;
    }
}