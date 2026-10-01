using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Rpt_Jobbing_Details
/// </summary>
public class Rpt_Jobbing_Details
{
    #region Private_Attributes


    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;
    private string _SCHEME_CODE;
    private string _NOTIFICATION_NO;
    private string _BE_NO;
    private string _BE_DATE;
    private string _BE_INV_SLNO;
    private string _BE_INV_NO;
    private string _BE_ITEM_NO;
    private string _BE_PORT_CODE;
    private string _QTY;
    private string _UNIT;

    #endregion


    #region Public Attributes

    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string SCHEME_CODE { get { return _SCHEME_CODE; } set { _SCHEME_CODE = value; } }
    public string NOTIFICATION_NO { get { return _NOTIFICATION_NO; } set { _NOTIFICATION_NO = value; } }
    public string BE_NO { get { return _BE_NO; } set { _BE_NO = value; } }
    public string BE_DATE { get { return _BE_DATE; } set { _BE_DATE = value; } }
    public string BE_INV_SLNO { get { return _BE_INV_SLNO; } set { _BE_INV_SLNO = value; } }
    public string BE_INV_NO { get { return _BE_INV_NO; } set { _BE_INV_NO = value; } }
    public string BE_ITEM_NO { get { return _BE_ITEM_NO; } set { _BE_ITEM_NO = value; } }
    public string BE_PORT_CODE { get { return _BE_PORT_CODE; } set { _BE_PORT_CODE = value; } }

    public string QTY { get { return _QTY; } set { _QTY = value; } }
    public string UNIT { get { return _UNIT; } set { _UNIT = value; } }

    #endregion


    public List<Rpt_Jobbing_Details> Get_JOBBING_DETAILS(DataTable dt)
    {

        List<Rpt_Jobbing_Details> list = new List<Rpt_Jobbing_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (dt.Rows.Count > i)
        {
           
            INVOICE_SLNO = dt.Rows[i]["INVOICE_SLNO"].ToString();
            ITEM_SLNO = dt.Rows[i]["ITEM_SLNO"].ToString();
            SCHEME_CODE = dt.Rows[i]["SCHEME_CODE"].ToString();
            
            //NOTIFICATION_NO = dt.Rows[i]["NOTIFICATION_NO"].ToString();
            BE_NO = dt.Rows[i]["BE_NO"].ToString();
            BE_DATE = dt.Rows[i]["BE_DATE"].ToString();
            BE_INV_SLNO = dt.Rows[i]["BE_INV_SLNO"].ToString();
            BE_INV_NO = dt.Rows[i]["BE_INV_NO"].ToString();
            BE_ITEM_NO = dt.Rows[i]["BE_ITEM_NO"].ToString();
            BE_PORT_CODE = dt.Rows[i]["BE_PORT_CODE"].ToString();
            QTY = dt.Rows[i]["QTY"].ToString();
            UNIT = dt.Rows[i]["UNIT"].ToString();
          
            list.Add(new Rpt_Jobbing_Details()
            {
                ITEM_SLNO = ITEM_SLNO,
                INVOICE_SLNO = INVOICE_SLNO,
                SCHEME_CODE = SCHEME_CODE,
               // NOTIFICATION_NO = NOTIFICATION_NO,
                BE_NO = BE_NO,
                BE_DATE = BE_DATE,
                BE_INV_SLNO = BE_INV_SLNO,
                BE_INV_NO = BE_INV_NO,
                BE_ITEM_NO = BE_ITEM_NO,
                BE_PORT_CODE = BE_PORT_CODE,
                QTY = QTY,
                UNIT = UNIT
             

            });

            i++;
        }
        return list;
    }

    public List<Rpt_Jobbing_Details> Get_JOBBING_DETAILS_EXP_Anex(DataTable dt)
    {

        List<Rpt_Jobbing_Details> list = new List<Rpt_Jobbing_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (dt.Rows.Count > i)
        {

            INVOICE_SLNO = dt.Rows[i]["INVOICE_SLNO"].ToString();
            ITEM_SLNO = dt.Rows[i]["ITEM_SLNO"].ToString();
            SCHEME_CODE = dt.Rows[i]["SCHEME_CODE"].ToString();

            NOTIFICATION_NO = dt.Rows[i]["NOTIFICATION_NO"].ToString();
            BE_NO = dt.Rows[i]["BE_NO"].ToString();
            BE_DATE = dt.Rows[i]["BE_DATE"].ToString();
            BE_INV_SLNO = dt.Rows[i]["BE_INV_SLNO"].ToString();
            BE_INV_NO = dt.Rows[i]["BE_INV_NO"].ToString();
            BE_ITEM_NO = dt.Rows[i]["BE_ITEM_NO"].ToString();
            BE_PORT_CODE = dt.Rows[i]["BE_PORT_CODE"].ToString();
            QTY = dt.Rows[i]["QTY"].ToString();
            UNIT = dt.Rows[i]["UNIT"].ToString();

            list.Add(new Rpt_Jobbing_Details()
            {

                ITEM_SLNO = ITEM_SLNO,
                INVOICE_SLNO = INVOICE_SLNO,
                SCHEME_CODE = SCHEME_CODE,
                NOTIFICATION_NO = NOTIFICATION_NO,
                BE_NO = BE_NO,
                BE_DATE = BE_DATE,
                BE_INV_SLNO = BE_INV_SLNO,
                BE_INV_NO = BE_INV_NO,
                BE_ITEM_NO = BE_ITEM_NO,
                BE_PORT_CODE = BE_PORT_CODE,
                QTY = QTY,
                UNIT = UNIT


            });

            i++;
        }
        return list;
    }
}