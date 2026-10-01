using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Commercial_Tax_Details
/// </summary>
public class Commercial_Tax_Details
{
    #region Private_Attributes

    //General Details

    private string _COMMERCIAL_DETAILS_STATUS;
    private string _COMMERCIAL_TAX_STATECODE;
    private string _COMMERCIAL_TAX_STATENAME;
    private string _COMMERCIAL_TAX_TYPE;
    private string _COMMERCIAL_TAX_REGISTRATION_NO;
    private string _IGST_ASSESSABLE_VALUE;
    private string _IGST_IGST_LEVY_AMOUNT;
    private string _IGST_COMPENSATION_CC_AMOUNT;

    #endregion

    #region Public_Attributes

    //General Details


    public string COMMERCIAL_DETAILS_STATUS { get { return _COMMERCIAL_DETAILS_STATUS; } set { _COMMERCIAL_DETAILS_STATUS = value; } }
    public string COMMERCIAL_TAX_STATECODE { get { return _COMMERCIAL_TAX_STATECODE; } set { _COMMERCIAL_TAX_STATECODE = value; } }
    public string COMMERCIAL_TAX_STATENAME { get { return _COMMERCIAL_TAX_STATENAME; } set { _COMMERCIAL_TAX_STATENAME = value; } }
    
    public string COMMERCIAL_TAX_TYPE { get { return _COMMERCIAL_TAX_TYPE; } set { _COMMERCIAL_TAX_TYPE = value; } }
    public string COMMERCIAL_TAX_REGISTRATION_NO { get { return _COMMERCIAL_TAX_REGISTRATION_NO; } set { _COMMERCIAL_TAX_REGISTRATION_NO = value; } }

    public string IGST_ASSESSABLE_VALUE { get { return _IGST_ASSESSABLE_VALUE; } set { _IGST_ASSESSABLE_VALUE = value; } }
    public string IGST_IGST_LEVY_AMOUNT { get { return _IGST_IGST_LEVY_AMOUNT; } set { _IGST_IGST_LEVY_AMOUNT = value; } }
    public string IGST_COMPENSATION_CC_AMOUNT { get { return _IGST_COMPENSATION_CC_AMOUNT; } set { _IGST_COMPENSATION_CC_AMOUNT = value; } }
    #endregion

    public List<Commercial_Tax_Details> Get_Commercial_Tax_Details(DataTable Commercial_Tax_dt, string tot_CHK_IGST_LEVY_AMT)
    {
        List<Commercial_Tax_Details> list = new List<Commercial_Tax_Details>();
        list.Clear();


        if (Commercial_Tax_dt.Rows.Count > 0)
        {
            //COMMERCIAL_DETAILS_STATUS = Commercial_Tax_dt.Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString();
            //if (COMMERCIAL_DETAILS_STATUS == "N")
            //{
                
                list.Add(new Commercial_Tax_Details()
                {
                    COMMERCIAL_DETAILS_STATUS = Commercial_Tax_dt.Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString(),
                    COMMERCIAL_TAX_STATECODE = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString() + "-" + Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString(),
                    //COMMERCIAL_TAX_STATENAME = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString(),
                    COMMERCIAL_TAX_TYPE = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_TYPE"].ToString(),
                    COMMERCIAL_TAX_REGISTRATION_NO = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString(),
                    IGST_ASSESSABLE_VALUE = tot_CHK_IGST_LEVY_AMT,
                    IGST_IGST_LEVY_AMOUNT = Commercial_Tax_dt.Rows[0]["IGST_IGST_LEVY_AMOUNT"].ToString(),
                    IGST_COMPENSATION_CC_AMOUNT = Commercial_Tax_dt.Rows[0]["IGST_COMPENSATION_CC_AMOUNT"].ToString(),


                });
            //}
            //else
            //{
                
            //    list.Add(new Commercial_Tax_Details()
            //    {
            //        COMMERCIAL_DETAILS_STATUS = COMMERCIAL_DETAILS_STATUS,
            //        COMMERCIAL_TAX_STATECODE = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString(),
            //        COMMERCIAL_TAX_TYPE = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_TYPE"].ToString(),
            //        COMMERCIAL_TAX_REGISTRATION_NO = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString(),

            //    });
            //}           
        }        
        return list;
    }



    public List<Commercial_Tax_Details> Get_Commercial_Tax_Details1(DataTable Commercial_Tax_dt)
    {
        List<Commercial_Tax_Details> list = new List<Commercial_Tax_Details>();
        list.Clear();


        if (Commercial_Tax_dt.Rows.Count > 0)
        {
            COMMERCIAL_DETAILS_STATUS = Commercial_Tax_dt.Rows[0]["COMMERCIAL_DETAILS_STATUS"].ToString();
            if (COMMERCIAL_DETAILS_STATUS == "N")
            {

                list.Add(new Commercial_Tax_Details()
                {

                    COMMERCIAL_TAX_STATECODE = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString(),
                    COMMERCIAL_TAX_TYPE = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_TYPE"].ToString(),
                    COMMERCIAL_TAX_REGISTRATION_NO = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString(),


                });
            }
            else
            {

                list.Add(new Commercial_Tax_Details()
                {
                    COMMERCIAL_DETAILS_STATUS = COMMERCIAL_DETAILS_STATUS,
                    COMMERCIAL_TAX_STATECODE = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString(),
                    COMMERCIAL_TAX_TYPE = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_TYPE"].ToString(),
                    COMMERCIAL_TAX_REGISTRATION_NO = Commercial_Tax_dt.Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString(),


                });

            }



        }


        return list;
    }
}