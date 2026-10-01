using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for HSS_Details
/// </summary>
public class HSS_Details
{
    #region Private_Attributes
   
    //General Details
   
    private string _HIGH_SEA_SALE_NAME;
    private string _HIGH_SEA_IEC;
    private string _HIGH_SEA_BRANCH_SL_NO;
    private string _HSS_ADD1;
    private string _HSS_ADD2;
    private string _HSS_ADD3;
    private string _HSS_ADD4;
    private string _HSS_ADD5;
    private string _PRECEDING_LEVEL;

    #endregion

    #region Public_Attributes
   
    //General Details

   
    public string HIGH_SEA_SALE_NAME { get { return _HIGH_SEA_SALE_NAME; } set { _HIGH_SEA_SALE_NAME = value; } }
    public string HIGH_SEA_IEC { get { return _HIGH_SEA_IEC; } set { _HIGH_SEA_IEC = value; } }
    public string HIGH_SEA_BRANCH_SL_NO { get { return _HIGH_SEA_BRANCH_SL_NO; } set { _HIGH_SEA_BRANCH_SL_NO = value; } }
    public string HSS_ADD1 { get { return _HSS_ADD1; } set { _HSS_ADD1 = value; } }
    public string HSS_ADD2 { get { return _HSS_ADD2; } set { _HSS_ADD2 = value; } }
    public string HSS_ADD3 { get { return _HSS_ADD3; } set { _HSS_ADD3 = value; } }
    public string HSS_ADD4 { get { return _HSS_ADD4; } set { _HSS_ADD4 = value; } }
    public string HSS_ADD5 { get { return _HSS_ADD5; } set { _HSS_ADD5 = value; } }

    public string PRECEDING_LEVEL { get { return _PRECEDING_LEVEL; } set { _PRECEDING_LEVEL = value; } }
    
    #endregion

    public List<HSS_Details> Get_HSS_Details(DataTable HSS_dt)
    {
        List<HSS_Details> list = new List<HSS_Details>();
        list.Clear();


        if (HSS_dt.Rows.Count > 0)
        {
            HIGH_SEA_IEC = HSS_dt.Rows[0]["HIGH_SEA_IEC"].ToString();
            if (HIGH_SEA_IEC == "0")
            {
                HIGH_SEA_IEC = "";
            }
            if (HIGH_SEA_IEC != "")
            {
                list.Add(new HSS_Details()
                {
                    HIGH_SEA_SALE_NAME = HSS_dt.Rows[0]["HIGH_SEA_SALE_NAME"].ToString(),
                    HIGH_SEA_IEC = HIGH_SEA_IEC,
                    HIGH_SEA_BRANCH_SL_NO = HSS_dt.Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString(),
                    HSS_ADD1 = HSS_dt.Rows[0]["HSS_ADD1"].ToString(),
                    HSS_ADD2 = HSS_dt.Rows[0]["HSS_ADD2"].ToString(),
                    HSS_ADD3 = HSS_dt.Rows[0]["HSS_ADD3"].ToString(),
                    HSS_ADD4 = HSS_dt.Rows[0]["HSS_ADD4"].ToString(),
                    HSS_ADD5 = HSS_dt.Rows[0]["HSS_ADD5"].ToString(),
                    PRECEDING_LEVEL = HSS_dt.Rows[0]["PRECEDING_LEVEL"].ToString()
                    
                });
            }
        }
        else
        {
            list.Add(new HSS_Details()
            {

                
                HIGH_SEA_BRANCH_SL_NO = HSS_dt.Rows[0]["HIGH_SEA_BRANCH_SL_NO"].ToString(),
                HSS_ADD1 = HSS_dt.Rows[0]["HSS_ADD1"].ToString(),
                HSS_ADD2 = HSS_dt.Rows[0]["HSS_ADD2"].ToString(),
                HSS_ADD3 = HSS_dt.Rows[0]["HSS_ADD3"].ToString(),
                HSS_ADD4 = HSS_dt.Rows[0]["HSS_ADD4"].ToString(),
                HSS_ADD5 = HSS_dt.Rows[0]["HSS_ADD5"].ToString()
            });
        }

        return list;
    }
}