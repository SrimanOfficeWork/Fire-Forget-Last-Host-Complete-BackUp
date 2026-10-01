using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Rpt_Drawback_Details
/// </summary>
public class Rpt_Drawback_Details
{
    #region Private_Attributes
  
    private string _DRAWBACK_ID;
    private string _JOBNO;
    private string _INVOICE_SLNO;
    private string _ITEM_SLNO;
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

    #region Public Attributes

    public string DRAWBACK_ID { get { return _DRAWBACK_ID; } set { _DRAWBACK_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

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

    public double cal1, cal2,DBK_FOB;

    #endregion

    public List<Rpt_Drawback_Details> Get_DRAWBACK_DETAILS(DataTable dt,DataTable ds2)
    {
        
        List<Rpt_Drawback_Details> list = new List<Rpt_Drawback_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (dt.Rows.Count > i)
        {
            JOBNO = dt.Rows[i]["JOBNO"].ToString();
            INVOICE_SLNO = dt.Rows[i]["INVOICE_SLNO"].ToString();
            ITEM_SLNO = dt.Rows[i]["ITEM_SLNO"].ToString();
            DRAWBACK_SLNO = dt.Rows[i]["DRAWBACK_SLNO"].ToString();


             DRAWBACK_QTY = dt.Rows[i]["DRAWBACK_QTY"].ToString();
             DRAWBACK_UNIT = dt.Rows[i]["DRAWBACK_UNIT"].ToString();
             DRAWBACK_NOOFUNITS = dt.Rows[i]["DRAWBACK_NOOFUNITS"].ToString();
             DRAWBACK_RATE = dt.Rows[i]["DRAWBACK_RATE"].ToString();
             DRAWBACK_CAPS = dt.Rows[i]["DRAWBACK_CAPS"].ToString();

            if (DRAWBACK_SLNO != "")
            {
                adminmaster adm = new adminmaster();
                adm.Edrawback_id = "0";
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


            //int b = 0;
            // DataView view = ds2.DefaultView;
            // view.RowFilter = "INVOICE_SLNO = " + ITEM_SLNO;
            //DataTable table = view.ToTable();
            //DataSet dss = new DataSet();
            //dss.Tables.Add(table);
            //while (dss.Tables[0].Rows.Count > b)
            //{

            //    DBK_FOB = Convert.ToDouble(dss.Tables[0].Rows[b]["FOB_VALUE"].ToString());


            //    cal1 = DBK_FOB * Convert.ToDouble(DRAWBACK_RATE);

            //    if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
            //    {
            //        cal2 = Convert.ToDouble(DRAWBACK_QTY) * Convert.ToDouble(DRAWBACK_CAPS);
            //    }

            //    if (Convert.ToDouble(DRAWBACK_CAPS) > 0)
            //    {
            //        if (cal1 > cal2)
            //        {
            //            DBK_VALUE = cal2;
            //        }
            //        else
            //        {
            //            DBK_VALUE = cal1;
            //        }

            //    }
            //    else
            //    {
            //        DBK_VALUE = cal1;
            //    }



            //}

           // -------------------------------------------------------


           // List<Rpt_Item_Details> list1 = new List<Rpt_Item_Details>();
           //while(list1.IndexOf(

    //        Configuration config = Configurations.Find(
    //delegate(Configuration item) { return item.Name == "myConfig"; });



            cal1 = DBK_FOB * Convert.ToDouble(DRAWBACK_RATE);

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




            list.Add(new Rpt_Drawback_Details()
            {
                 JOBNO = JOBNO,
                 ITEM_SLNO = ITEM_SLNO,
                 INVOICE_SLNO = INVOICE_SLNO,
                 DRAWBACK_ID = dt.Rows[i]["DRAWBACK_ID"].ToString(),
                 SCHEME_CODE = dt.Rows[i]["SCHEME_CODE"].ToString(),
                 DRAWBACK_SLNO = DRAWBACK_SLNO,
                 DRAWBACK_QTY = DRAWBACK_QTY,
                 DRAWBACK_UNIT = DRAWBACK_UNIT,
                 DRAWBACK_NOOFUNITS = DRAWBACK_NOOFUNITS,
                 DRAWBACK_RATE = DRAWBACK_RATE,
                 DRAWBACK_CAPS = DRAWBACK_CAPS,
                 DRAWBACK_DESC = dt.Rows[i]["DRAWBACK_DESC"].ToString(),
                 DRAWBACK_CUSTOMS=DRAWBACK_CUSTOMS,
                 DRAWBACK_EXCISE = DRAWBACK_EXCISE,
                 DBK_VALUE=DBK_VALUE
               

            });

            i++;
        }
        return list;
    }
}