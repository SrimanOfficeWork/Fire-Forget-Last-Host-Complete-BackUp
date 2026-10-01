using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Exbond_Details
/// </summary>
public class Exbond_Details
{
    #region Private_Attributes

    //General Details

    private string _EXBOND_INBOND_BE_NO;
    private string _EXBOND_INBOND_BE_DATE;
    private string _EXBOND_BOND_NO;
    private string _EXBOND_BOND_DATE;
    private string _EXBOND_WAREHOUSE_CUSTOMS;
    private string _EXBOND_WAREHOUSE_CUSTOMS_CODE;
    private string _EXBOND_NOOFPACKAGE;
    private string _EXBOND_NOOFPACKAGE_UNITCODE;
    private string _EXBOND_GROSS_WEIGHT;
    private string _EXBOND_GROSS_WEIGHT_UNITCODE;
    private string _EXBOND_DIRECT_EXBONDING;
    private string _EXBOND_ADDL_LOAD_HSS;
    private string _EXBOND_MISC_LOAD_RATE;

    #endregion

    #region Public_Attributes

    //General Details


    public string EXBOND_INBOND_BE_NO { get { return _EXBOND_INBOND_BE_NO; } set { _EXBOND_INBOND_BE_NO = value; } }
    public string EXBOND_INBOND_BE_DATE { get { return _EXBOND_INBOND_BE_DATE; } set { _EXBOND_INBOND_BE_DATE = value; } }
    public string EXBOND_BOND_NO { get { return _EXBOND_BOND_NO; } set { _EXBOND_BOND_NO = value; } }
    public string EXBOND_BOND_DATE { get { return _EXBOND_BOND_DATE; } set { _EXBOND_BOND_DATE = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS { get { return _EXBOND_WAREHOUSE_CUSTOMS; } set { _EXBOND_WAREHOUSE_CUSTOMS = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS_CODE { get { return _EXBOND_WAREHOUSE_CUSTOMS_CODE; } set { _EXBOND_WAREHOUSE_CUSTOMS_CODE = value; } }
    public string EXBOND_NOOFPACKAGE { get { return _EXBOND_NOOFPACKAGE; } set { _EXBOND_NOOFPACKAGE = value; } }
    public string EXBOND_NOOFPACKAGE_UNITCODE { get { return _EXBOND_NOOFPACKAGE_UNITCODE; } set { _EXBOND_NOOFPACKAGE_UNITCODE = value; } }
    public string EXBOND_GROSS_WEIGHT { get { return _EXBOND_GROSS_WEIGHT; } set { _EXBOND_GROSS_WEIGHT = value; } }
    public string EXBOND_GROSS_WEIGHT_UNITCODE { get { return _EXBOND_GROSS_WEIGHT_UNITCODE; } set { _EXBOND_GROSS_WEIGHT_UNITCODE = value; } }
    public string EXBOND_DIRECT_EXBONDING { get { return _EXBOND_DIRECT_EXBONDING; } set { _EXBOND_DIRECT_EXBONDING = value; } }
    public string EXBOND_ADDL_LOAD_HSS { get { return _EXBOND_ADDL_LOAD_HSS; } set { _EXBOND_ADDL_LOAD_HSS = value; } }
    public string EXBOND_MISC_LOAD_RATE { get { return _EXBOND_MISC_LOAD_RATE; } set { _EXBOND_MISC_LOAD_RATE = value; } }


    #endregion

    public List<Exbond_Details> Get_Exbond_Details(DataTable EXBOND_dt)
    {
        List<Exbond_Details> list = new List<Exbond_Details>();
        list.Clear();


        if (EXBOND_dt.Rows.Count > 0)
        {
            EXBOND_NOOFPACKAGE = EXBOND_dt.Rows[0]["EXBOND_NOOFPACKAGE"].ToString();
            EXBOND_GROSS_WEIGHT = EXBOND_dt.Rows[0]["EXBOND_GROSS_WEIGHT"].ToString();
            EXBOND_NOOFPACKAGE_UNITCODE = EXBOND_dt.Rows[0]["EXBOND_NOOFPACKAGE_UNITCODE"].ToString();
            EXBOND_GROSS_WEIGHT_UNITCODE = EXBOND_dt.Rows[0]["EXBOND_GROSS_WEIGHT_UNITCODE"].ToString();
            EXBOND_INBOND_BE_DATE = EXBOND_dt.Rows[0]["EXBOND_INBOND_BE_DATE"].ToString();
            EXBOND_BOND_DATE = EXBOND_dt.Rows[0]["EXBOND_BOND_DATE"].ToString();
            if (EXBOND_INBOND_BE_DATE == "01/01/1900" | EXBOND_INBOND_BE_DATE == "01-01-1900")
            {
                EXBOND_INBOND_BE_DATE = "";
            }
            else
            {
                EXBOND_INBOND_BE_DATE = EXBOND_INBOND_BE_DATE;
            }
            if (EXBOND_BOND_DATE == "01/01/1900" ||EXBOND_BOND_DATE == "01-01-1900")
            {
                EXBOND_BOND_DATE = "";
            }
            else
            {
                EXBOND_BOND_DATE = EXBOND_BOND_DATE;
            }
            EXBOND_INBOND_BE_NO = EXBOND_dt.Rows[0]["EXBOND_INBOND_BE_NO"].ToString();
            EXBOND_ADDL_LOAD_HSS = EXBOND_dt.Rows[0]["EXBOND_ADDL_LOAD_HSS"].ToString();
            EXBOND_MISC_LOAD_RATE = EXBOND_dt.Rows[0]["EXBOND_MISC_LOAD_RATE"].ToString();


            if (EXBOND_NOOFPACKAGE != "")
            {
                list.Add(new Exbond_Details()
                {
                    EXBOND_INBOND_BE_NO = EXBOND_INBOND_BE_NO,
                    EXBOND_INBOND_BE_DATE = EXBOND_INBOND_BE_DATE,
                    EXBOND_BOND_NO = EXBOND_dt.Rows[0]["EXBOND_BOND_NO"].ToString(),
                    EXBOND_BOND_DATE = EXBOND_BOND_DATE,
                    EXBOND_WAREHOUSE_CUSTOMS = EXBOND_dt.Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString(),
                    EXBOND_WAREHOUSE_CUSTOMS_CODE = EXBOND_dt.Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString(),
                    EXBOND_NOOFPACKAGE = EXBOND_NOOFPACKAGE + " " + EXBOND_NOOFPACKAGE_UNITCODE,
                    EXBOND_GROSS_WEIGHT = EXBOND_GROSS_WEIGHT + " " + EXBOND_GROSS_WEIGHT_UNITCODE,
                    EXBOND_ADDL_LOAD_HSS = EXBOND_ADDL_LOAD_HSS,
                    EXBOND_MISC_LOAD_RATE = EXBOND_MISC_LOAD_RATE

                });
            }
            else
            {
                list.Add(new Exbond_Details()
                {
                   
                    EXBOND_INBOND_BE_DATE = EXBOND_INBOND_BE_DATE,
                    EXBOND_BOND_NO = EXBOND_INBOND_BE_NO,
                    EXBOND_BOND_DATE = EXBOND_BOND_DATE,
                    EXBOND_WAREHOUSE_CUSTOMS = EXBOND_dt.Rows[0]["EXBOND_WAREHOUSE_CUSTOMS"].ToString(),
                    EXBOND_WAREHOUSE_CUSTOMS_CODE = EXBOND_dt.Rows[0]["EXBOND_WAREHOUSE_CUSTOMS_CODE"].ToString(),
                    EXBOND_NOOFPACKAGE = EXBOND_NOOFPACKAGE + " " + EXBOND_NOOFPACKAGE_UNITCODE,
                    EXBOND_GROSS_WEIGHT = EXBOND_GROSS_WEIGHT + " " + EXBOND_GROSS_WEIGHT_UNITCODE,
                    EXBOND_ADDL_LOAD_HSS = EXBOND_ADDL_LOAD_HSS,
                    EXBOND_MISC_LOAD_RATE = EXBOND_MISC_LOAD_RATE

                });
            }
           
        }
      

        return list;
    }
}