using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Rpt_Accessory_Details
/// </summary>
public class Rpt_Accessory_Details
{
    #region Private Attributes
    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;

    private string _ITEM_ACCESSORIES_DESC;
   

    #endregion

    #region Public Attributes

    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string ITEM_ACCESSORIES_DESC { get { return _ITEM_ACCESSORIES_DESC; } set { _ITEM_ACCESSORIES_DESC = value; } }
   

    #endregion


    public List<Rpt_Accessory_Details> Get_Accessory_Details(DataTable Accessory_dt)
    {
        List<Rpt_Accessory_Details> list = new List<Rpt_Accessory_Details>();
        list.Clear();
        int C = 0, b = 0;
        while (Accessory_dt.Rows.Count > C)
        {

            INVOICE_SLNO = Accessory_dt.Rows[C]["INVOICE_SLNO"].ToString();
            ITEM_SLNO = Accessory_dt.Rows[C]["ITEM_SLNO"].ToString();

            ITEM_ACCESSORIES_DESC = Accessory_dt.Rows[C]["ITEM_ACCESSORIES_DESC"].ToString();

            if (ITEM_ACCESSORIES_DESC != "")
            {
                list.Add(new Rpt_Accessory_Details()
                    {
                        INVOICE_SLNO = INVOICE_SLNO,
                        ITEM_SLNO = ITEM_SLNO,
                        ITEM_ACCESSORIES_DESC = ITEM_ACCESSORIES_DESC,


                    });
            }
            C++;
        }                          

        return list;
    }
}