using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Rpt_STR_Details
/// </summary>
public class Rpt_STR_Details
{
    #region Private Attributes

    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;
    private string _ITEM_STR_CODE;
    private string _STR_RATE;
    private string _STR_AMOUNT;

    #endregion

    #region Public Attributes

    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string ITEM_STR_CODE { get { return _ITEM_STR_CODE; } set { _ITEM_STR_CODE = value; } }
    public string STR_RATE { get { return _STR_RATE; } set { _STR_RATE = value; } }
    public string STR_AMOUNT { get { return _STR_AMOUNT; } set { _STR_AMOUNT = value; } }

    #endregion

    public List<Rpt_STR_Details> Get_ThirdParty_Details(DataTable STR_dt)
    {
        List<Rpt_STR_Details> list = new List<Rpt_STR_Details>();
        list.Clear();
        int C = 0, b = 0;
        while (STR_dt.Rows.Count > C)
        {

            INVOICE_SLNO = STR_dt.Rows[C]["INVOICE_SLNO"].ToString();
            ITEM_SLNO = STR_dt.Rows[C]["ITEM_SLNO"].ToString();

            ITEM_STR_CODE = STR_dt.Rows[C]["ITEM_STR_CODE"].ToString();
           
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
                list.Add(new Rpt_STR_Details()
                {
                    INVOICE_SLNO = INVOICE_SLNO,
                    ITEM_SLNO = ITEM_SLNO,
                    ITEM_STR_CODE = ITEM_STR_CODE,
                    STR_RATE = STR_RATE

                });
            }

            else
            {
                list.Add(new Rpt_STR_Details()
                {
                    INVOICE_SLNO = "",
                    ITEM_SLNO = "",
                    //ITEM_STR_CODE = "",
                    STR_RATE = ""

                });
            }
            C++;
        }

        //else
        //{
        //    list.Add(new Rpt_ThirdParty_Details()
        //    {


        //        HIGH_SEA_BRANCH_SL_NO = HSS_dt.Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString(),
        //        HSS_ADD1 = HSS_dt.Rows[0]["HSS_ADD1"].ToString(),
        //        HSS_ADD2 = HSS_dt.Rows[0]["HSS_ADD2"].ToString(),
        //        HSS_ADD3 = HSS_dt.Rows[0]["HSS_ADD3"].ToString(),
        //        HSS_ADD4 = HSS_dt.Rows[0]["HSS_ADD4"].ToString(),
        //        HSS_ADD5 = HSS_dt.Rows[0]["HSS_ADD5"].ToString()
        //    });
        //}

        return list;
    }

}