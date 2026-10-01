using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ThirdParty_Details
/// </summary>
public class Rpt_ThirdParty_Details
{
    #region Private Attributes
    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;

    private string _ITEM_IECCODE;
    private string _ITEM_EXPORTER_NAME;
    private string _BR_SLNO;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;
    private string _ADDRESS;
    private string _GSTN_TYPE, _GSTN_ID;
    #endregion

    #region Public Attributes

    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string ITEM_EXPORTER_NAME { get { return _ITEM_EXPORTER_NAME; } set { _ITEM_EXPORTER_NAME = value; } }
    public string ITEM_IECCODE { get { return _ITEM_IECCODE; } set { _ITEM_IECCODE = value; } }
    public string BR_SLNO { get { return _BR_SLNO; } set { _BR_SLNO = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
    public string ADDRESS { get { return _ADDRESS; } set { _ADDRESS = value; } }
    public string GSTN_TYPE { get { return _GSTN_TYPE; } set { _GSTN_TYPE = value; } }
    public string GSTN_ID { get { return _GSTN_ID; } set { _GSTN_ID = value; } }

    #endregion


    public List<Rpt_ThirdParty_Details> Get_ThirdParty_Details(DataTable Third_dt)
    {
        List<Rpt_ThirdParty_Details> list = new List<Rpt_ThirdParty_Details>();
        list.Clear();
        int C = 0,b=0;
        while (Third_dt.Rows.Count > C)
        {

            INVOICE_SLNO = Third_dt.Rows[C]["INVOICE_SLNO"].ToString();
            ITEM_SLNO = Third_dt.Rows[C]["ITEM_SLNO"].ToString();

                 ITEM_IECCODE = Third_dt.Rows[C]["ITEM_IECCODE"].ToString();
                 ITEM_EXPORTER_NAME = Third_dt.Rows[C]["ITEM_EXPORTER_NAME"].ToString();
                 BR_SLNO = Third_dt.Rows[C]["BR_SLNO"].ToString();
                ADDRESS1 = Third_dt.Rows[C]["ADDRESS1"].ToString();
                ADDRESS2 = Third_dt.Rows[C]["ADDRESS2"].ToString();
                ADDRESS3 = Third_dt.Rows[C]["ADDRESS3"].ToString();
                ADDRESS4 = Third_dt.Rows[C]["ADDRESS4"].ToString();
                ADDRESS5 = Third_dt.Rows[C]["ADDRESS5"].ToString();

               
                ADDRESS = ADDRESS1 + ", " + ADDRESS2 + ", " + ADDRESS3;

                GSTN_TYPE = Third_dt.Rows[C]["GSTN_TYPE"].ToString();
                GSTN_ID = Third_dt.Rows[C]["GSTN_ID"].ToString();

                if (ITEM_IECCODE == "0")
                {
                    ITEM_IECCODE = "";
                }
                if (ITEM_IECCODE != "")
                {
                    list.Add(new Rpt_ThirdParty_Details()
                    {
                        INVOICE_SLNO = INVOICE_SLNO,
                        ITEM_SLNO = ITEM_SLNO,
                        ITEM_EXPORTER_NAME = ITEM_EXPORTER_NAME,
                        ITEM_IECCODE = ITEM_IECCODE,
                        BR_SLNO = BR_SLNO,
                        ADDRESS = ADDRESS,

                        ADDRESS4 = ADDRESS4,
                        ADDRESS5 = ADDRESS5,
                        GSTN_TYPE = GSTN_TYPE,
                        GSTN_ID = GSTN_ID

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