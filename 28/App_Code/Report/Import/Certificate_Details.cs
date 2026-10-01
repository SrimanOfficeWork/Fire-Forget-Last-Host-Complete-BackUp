using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Certificate_Details
/// </summary>
public class Certificate_Details
{
    #region Private_Attributes
    //CERTIFICATE_DETAILS
    private string _CERTIFICATE_NO;
    private string _CERTIFICATE_DATE;
    private string _CERTIFICATE_TYPE;

    #endregion
    #region Public_Attributes
    //CERTIFICATE_DETAILS
    public string CERTIFICATE_NO { get { return _CERTIFICATE_NO; } set { _CERTIFICATE_NO = value; } }
    public string CERTIFICATE_DATE { get { return _CERTIFICATE_DATE; } set { _CERTIFICATE_DATE = value; } }
    public string CERTIFICATE_TYPE { get { return _CERTIFICATE_TYPE; } set { _CERTIFICATE_TYPE = value; } }
    #endregion


    public List<Certificate_Details> Get_CERTIFICATE_DETAILS(DataTable CERTIFICATE_dt)
    {


        List<Certificate_Details> list = new List<Certificate_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (CERTIFICATE_dt.Rows.Count > i)
        {
            CERTIFICATE_DATE = CERTIFICATE_dt.Rows[i]["CERTIFICATE_DATE"].ToString();
            if (CERTIFICATE_DATE == "01/01/1900" || CERTIFICATE_DATE == "01-01-1900")
            {
                CERTIFICATE_DATE = "";
            }
            CERTIFICATE_TYPE = CERTIFICATE_dt.Rows[i]["CERTIFICATE_TYPE"].ToString();
            string[] s1 = CERTIFICATE_TYPE.Split(new string[] { "," }, StringSplitOptions.None);
            CERTIFICATE_TYPE = s1[0].ToString();
            list.Add(new Certificate_Details()
            {
                CERTIFICATE_NO = CERTIFICATE_dt.Rows[i]["CERTIFICATE_NO"].ToString(),
                CERTIFICATE_DATE = CERTIFICATE_DATE,
                CERTIFICATE_TYPE = CERTIFICATE_TYPE

            });

            i++;
        }
        return list;
    }
}