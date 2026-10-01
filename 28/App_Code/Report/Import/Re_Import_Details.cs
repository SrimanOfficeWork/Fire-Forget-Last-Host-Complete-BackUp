using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for Re_Import_Details
/// </summary>
public class Re_Import_Details
{
    #region Private_Attributes
    // Invoice Details
    private string _INVOICE_SLNO;
    private string _INVOICE_NO;


    //ITEM DETAILS
    private string _ITEM_SLNO;

    //RE-IMPORT DETAILS
    private string _SB_NO, _SB_DATE, _PORT_EXPORT, _SB_INVOICE_NO, _SB_INVOICE_ITEM_NO, _NOTN_NO, _NOTN_SLNO, _EXPORT_FREIGHT, _EXPORT_INSURANCE, _CUSTOMS_DUTY, _EXCISE_DUTY;
 

    #endregion
    #region Public_Attributes
    // Invoice Details


    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }

    //item Details

    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    //RE-IMPORT DETAILS
    public string SB_NO { get { return _SB_NO; } set { _SB_NO = value; } }
    public string SB_DATE { get { return _SB_DATE; } set { _SB_DATE = value; } }
    public string PORT_EXPORT { get { return _PORT_EXPORT; } set { _PORT_EXPORT = value; } }
    public string SB_INVOICE_NO { get { return _SB_INVOICE_NO; } set { _SB_INVOICE_NO = value; } }
    public string SB_INVOICE_ITEM_NO { get { return _SB_INVOICE_ITEM_NO; } set { _SB_INVOICE_ITEM_NO = value; } }
    public string NOTN_NO { get { return _NOTN_NO; } set { _NOTN_NO = value; } }
    public string NOTN_SLNO { get { return _NOTN_SLNO; } set { _NOTN_SLNO = value; } }
    public string EXPORT_FREIGHT { get { return _EXPORT_FREIGHT; } set { _EXPORT_FREIGHT = value; } }
    public string EXPORT_INSURANCE { get { return _EXPORT_INSURANCE; } set { _EXPORT_INSURANCE = value; } }
    public string CUSTOMS_DUTY { get { return _CUSTOMS_DUTY; } set { _CUSTOMS_DUTY = value; } }
    public string EXCISE_DUTY { get { return _EXCISE_DUTY; } set { _EXCISE_DUTY = value; } }
    #endregion


    public List<Re_Import_Details> Get_RE_IMPORT_DETAILS(DataTable RE_IMPORT_dt)
    {


        List<Re_Import_Details> list = new List<Re_Import_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (RE_IMPORT_dt.Rows.Count > i)
        {

            SB_DATE = RE_IMPORT_dt.Rows[i]["SB_DATE"].ToString();
            if (SB_DATE == "01/01/1900" || SB_DATE == "01-01-1900")
            {
                SB_DATE = "";
            }

            SB_INVOICE_ITEM_NO = RE_IMPORT_dt.Rows[i]["SB_INVOICE__ITEM_NO"].ToString();
            SB_INVOICE_NO = RE_IMPORT_dt.Rows[i]["SB_INVOICE_NO"].ToString();
            SB_INVOICE_NO = SB_INVOICE_NO + " / " + SB_INVOICE_ITEM_NO;

            list.Add(new Re_Import_Details()
            {
                INVOICE_NO = RE_IMPORT_dt.Rows[i]["INVOICE_NO"].ToString(),
                ITEM_SLNO = RE_IMPORT_dt.Rows[i]["ITEM_SLNO"].ToString(),
                INVOICE_SLNO = RE_IMPORT_dt.Rows[i]["INVOICE_SLNO"].ToString(),
                NOTN_NO = RE_IMPORT_dt.Rows[i]["NOTN_NO"].ToString(),
                NOTN_SLNO = RE_IMPORT_dt.Rows[i]["NOTN_SLNO"].ToString(),
                SB_NO = RE_IMPORT_dt.Rows[i]["SB_NO"].ToString(),
                SB_DATE = SB_DATE,
                //SB_INVOICE_NO = RE_IMPORT_dt.Rows[i]["SB_INVOICE_NO"].ToString(),
                SB_INVOICE_NO=SB_INVOICE_NO,
                PORT_EXPORT = RE_IMPORT_dt.Rows[i]["PORT_EXPORT"].ToString(),
                EXPORT_FREIGHT = RE_IMPORT_dt.Rows[i]["EXPORT_FREIGHT"].ToString(),
                EXPORT_INSURANCE = RE_IMPORT_dt.Rows[i]["EXPORT_INSURANCE"].ToString(),
                CUSTOMS_DUTY = RE_IMPORT_dt.Rows[i]["CUSTOMS_DUTY"].ToString(),
                EXCISE_DUTY = RE_IMPORT_dt.Rows[i]["EXCISE_DUTY"].ToString()

            });

            i++;
        }
        return list;
    }
}