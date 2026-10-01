using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for Licence_Details
/// </summary>
public class License_Details
{
    #region Private_Attributes
    // Invoice Details
    private string _INVOICE_SLNO;
    private string _INVOICE_NO;
   

    //ITEM DETAILS
    private string _ITEM_SLNO;
    private string _SCHEME_CODE;

    //LICENCE_DETAILS
    private int _LICENSE_SLNO;
    private string _REGISTRATION_NO, _REGISTRATION_DATE, _EXCEMPTION, _DEBIT_AMT, _DEBIT_QTY, _UNIT_QTY, _LICENSE_ITEM_NO, _PORT_OF_LICENSE;
    private string _TOTAL_DEBIT_DUTY;
    private string _DEBIT_DUTY;
    private string _LICENSE_NO;
    private string _LICENSE_DATE;
    private string _TOTAL_DEBIT_DUTY_FINAL;
    private string _ENTRY_DEBIT_DUTY;
    private string _SCHEME_CODE1;
    public int licen_slno;

    #endregion
    #region Public_Attributes
    // Invoice Details


    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }

    //item Details

    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
  
    //LICENCE_DETAILS
    public int LICENSE_SLNO { get { return _LICENSE_SLNO; } set { _LICENSE_SLNO = value; } }
    public string REGISTRATION_NO { get { return _REGISTRATION_NO; } set { _REGISTRATION_NO = value; } }
    public string REGISTRATION_DATE { get { return _REGISTRATION_DATE; } set { _REGISTRATION_DATE = value; } }
    public string EXCEMPTION { get { return _EXCEMPTION; } set { _EXCEMPTION = value; } }
    public string DEBIT_AMT { get { return _DEBIT_AMT; } set { _DEBIT_AMT = value; } }
    public string DEBIT_QTY { get { return _DEBIT_QTY; } set { _DEBIT_QTY = value; } }
    public string UNIT_QTY { get { return _UNIT_QTY; } set { _UNIT_QTY = value; } }
    public string LICENSE_ITEM_NO { get { return _LICENSE_ITEM_NO; } set { _LICENSE_ITEM_NO = value; } }
    public string PORT_OF_LICENSE { get { return _PORT_OF_LICENSE; } set { _PORT_OF_LICENSE = value; } }

    public string TOTAL_DEBIT_DUTY { get { return _TOTAL_DEBIT_DUTY; } set { _TOTAL_DEBIT_DUTY = value; } }

    public string DEBIT_DUTY { get { return _DEBIT_DUTY; } set { _DEBIT_DUTY = value; } }

    public string LICENSE_NO { get { return _LICENSE_NO; } set { _LICENSE_NO = value; } }
    public string LICENSE_DATE { get { return _LICENSE_DATE; } set { _LICENSE_DATE = value; } }

    public string TOTAL_DEBIT_DUTY_FINAL { get { return _TOTAL_DEBIT_DUTY_FINAL; } set { _TOTAL_DEBIT_DUTY_FINAL = value; } }
    public string ENTRY_DEBIT_DUTY { get { return _ENTRY_DEBIT_DUTY; } set { _ENTRY_DEBIT_DUTY = value; } }
    public string SCHEME_CODE1 { get { return _SCHEME_CODE1; } set { _SCHEME_CODE1 = value; } }
    
    #endregion


    public List<License_Details> Get_LICENCE_DETAILS(DataTable LICENCE_dt, string TOTAL_DEBIT_DUTY_FINAL)
    {


        List<License_Details> list = new List<License_Details>();
        list.Clear();

        TOTAL_DEBIT_DUTY_FINAL = TOTAL_DEBIT_DUTY_FINAL;
        int i = 0;

        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (LICENCE_dt.Rows.Count > i)
        {
            INVOICE_SLNO = LICENCE_dt.Rows[i]["INVOICE_SLNO"].ToString();

            ITEM_SLNO = LICENCE_dt.Rows[i]["ITEM_SLNO"].ToString();
            REGISTRATION_DATE = LICENCE_dt.Rows[i]["REGISTRATION_DATE"].ToString();
            if (REGISTRATION_DATE == "01/01/1900" || REGISTRATION_DATE == "01-01-1900")
            {
                REGISTRATION_DATE = "";
            }
            PORT_OF_LICENSE = LICENCE_dt.Rows[i]["PORT_OF_LICENSE"].ToString();

            licen_slno = i + 1;
            //LICENSE_SLNO =Convert.ToString(licen_slno);

            list.Add(new License_Details()
            {
                ITEM_SLNO = ITEM_SLNO,
                INVOICE_SLNO = INVOICE_SLNO + "/" + ITEM_SLNO,
                SCHEME_CODE = LICENCE_dt.Rows[i]["SCHEME_CODE"].ToString(),
                //LICENSE_SLNO = LICENCE_dt.Rows[i]["LICENSE_SLNO"].ToString(),
                //LICENSE_SLNO =Convert.ToString(licen_slno),
                LICENSE_SLNO = licen_slno,
                REGISTRATION_NO = LICENCE_dt.Rows[i]["REGISTRATION_NO"].ToString(),
                REGISTRATION_DATE = LICENCE_dt.Rows[i]["REGISTRATION_DATE"].ToString(),
                EXCEMPTION = LICENCE_dt.Rows[i]["EXCEMPTION"].ToString(),
                DEBIT_AMT = LICENCE_dt.Rows[i]["DEBIT_AMT"].ToString(),
                DEBIT_QTY = LICENCE_dt.Rows[i]["DEBIT_QTY"].ToString(),
                UNIT_QTY = LICENCE_dt.Rows[i]["UNIT_QTY"].ToString(),
                LICENSE_ITEM_NO = LICENCE_dt.Rows[i]["LICENSE_ITEM_NO"].ToString(),
                PORT_OF_LICENSE = LICENCE_dt.Rows[i]["PORT_OF_LICENSE"].ToString(),
                //TOTAL_DEBIT_DUTY_FINAL = TOTAL_DEBIT_DUTY_FINAL,
                DEBIT_DUTY = LICENCE_dt.Rows[i]["DEBIT_DUTY"].ToString(),
                LICENSE_NO = LICENCE_dt.Rows[i]["LICENSE_NO"].ToString(),
                LICENSE_DATE = LICENCE_dt.Rows[i]["LICENSE_DATE"].ToString(),
                ENTRY_DEBIT_DUTY = LICENCE_dt.Rows[i]["ENTRY_DEBIT_DUTY"].ToString(),
                SCHEME_CODE1=LICENCE_dt.Rows[i]["SCHEME_CODE1"].ToString()
                
            });

            i++;
        }
        return list;
    }


    public List<License_Details> Get_LICENCE_DETAILS_EXPORT_ANNEXURE(DataTable LICENCE_dt)
    {
        List<License_Details> list = new List<License_Details>();
        list.Clear();

        //TOTAL_DEBIT_DUTY_FINAL = TOTAL_DEBIT_DUTY_FINAL;
        int i = 0;
      
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (LICENCE_dt.Rows.Count > i)
        {
            INVOICE_SLNO = LICENCE_dt.Rows[i]["INVOICE_SLNO"].ToString();

            ITEM_SLNO = LICENCE_dt.Rows[i]["ITEM_SLNO"].ToString();
            REGISTRATION_DATE = LICENCE_dt.Rows[i]["REGISTRATION_DATE"].ToString();
            if (REGISTRATION_DATE == "01/01/1900" || REGISTRATION_DATE == "01-01-1900")
            {
                REGISTRATION_DATE = "";
            }
            PORT_OF_LICENSE = LICENCE_dt.Rows[i]["PORT_OF_LICENSE"].ToString();

            licen_slno = i+1;
            //LICENSE_SLNO =Convert.ToString(licen_slno);

            list.Add(new License_Details()
            {
                ITEM_SLNO = ITEM_SLNO,
                INVOICE_SLNO = INVOICE_SLNO,

                //INVOICE_SLNO = INVOICE_SLNO + "/" + ITEM_SLNO,
                SCHEME_CODE = LICENCE_dt.Rows[i]["SCHEME_CODE"].ToString(),
                //LICENSE_SLNO = LICENCE_dt.Rows[i]["LICENSE_SLNO"].ToString(),
                //LICENSE_SLNO =Convert.ToString(licen_slno),
                LICENSE_SLNO = licen_slno,
                REGISTRATION_NO = LICENCE_dt.Rows[i]["REGISTRATION_NO"].ToString(),
                REGISTRATION_DATE = LICENCE_dt.Rows[i]["REGISTRATION_DATE"].ToString(),
                EXCEMPTION = LICENCE_dt.Rows[i]["EXCEMPTION"].ToString(),
                DEBIT_AMT = LICENCE_dt.Rows[i]["DEBIT_AMT"].ToString(),
                DEBIT_QTY = LICENCE_dt.Rows[i]["DEBIT_QTY"].ToString(),
                UNIT_QTY = LICENCE_dt.Rows[i]["UNIT_QTY"].ToString(),
                LICENSE_ITEM_NO = LICENCE_dt.Rows[i]["LICENSE_ITEM_NO"].ToString(),
                PORT_OF_LICENSE = LICENCE_dt.Rows[i]["PORT_OF_LICENSE"].ToString(),
                //INVOICE_NO = LICENCE_dt.Rows[i]["INVOICE_NO"].ToString()

                //TOTAL_DEBIT_DUTY_FINAL = TOTAL_DEBIT_DUTY_FINAL,
                //DEBIT_DUTY = LICENCE_dt.Rows[i]["DEBIT_DUTY"].ToString(),
                LICENSE_NO = LICENCE_dt.Rows[i]["LICENSE_NO"].ToString()
                //LICENSE_DATE = LICENCE_dt.Rows[i]["LICENSE_DATE"].ToString()
            });

            i++;
        }
        return list;
    }
}