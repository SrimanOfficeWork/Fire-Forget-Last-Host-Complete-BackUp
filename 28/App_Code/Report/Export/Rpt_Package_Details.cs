using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Rpt_Package_Details
/// </summary>
public class Rpt_Package_Details
{
    #region Private_Attributes

    private string _ANNEX_SEA_PACK_FROM;
    private string _ANNEX_SEA_PACK_TO;
    private string _ANNEX_SEA_PACK_PACKAGETYPE;
    private string _ANNEX_SEA_PACK_FROMDESC;
    private string _ANNEX_SEA_PACK_TODESC;

    #endregion

    #region Public Attributes

    public string ANNEX_SEA_PACK_FROM { get { return _ANNEX_SEA_PACK_FROM; } set { _ANNEX_SEA_PACK_FROM = value; } }
    public string ANNEX_SEA_PACK_TO { get { return _ANNEX_SEA_PACK_TO; } set { _ANNEX_SEA_PACK_TO = value; } }
    public string ANNEX_SEA_PACK_PACKAGETYPE { get { return _ANNEX_SEA_PACK_PACKAGETYPE; } set { _ANNEX_SEA_PACK_PACKAGETYPE = value; } }

    public string ANNEX_SEA_PACK_FROMDESC { get { return _ANNEX_SEA_PACK_FROMDESC; } set { _ANNEX_SEA_PACK_FROMDESC = value; } }
    public string ANNEX_SEA_PACK_TODESC { get { return _ANNEX_SEA_PACK_TODESC; } set { _ANNEX_SEA_PACK_TODESC = value; } }

    #endregion

    public string COMPANY_ID = "";

    public List<Rpt_Package_Details> Get_PACKAGE_DETAILS(DataTable dt)
    {
        COMPANY_ID = HttpContext.Current.Session["COMPANY_ID"].ToString();

        List<Rpt_Package_Details> list = new List<Rpt_Package_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (dt.Rows.Count > i)
        {

            ANNEX_SEA_PACK_FROM = dt.Rows[i]["ANNEX_SEA_PACK_FROM"].ToString();
            ANNEX_SEA_PACK_TO = dt.Rows[i]["ANNEX_SEA_PACK_TO"].ToString();
            ANNEX_SEA_PACK_PACKAGETYPE = dt.Rows[i]["ANNEX_SEA_PACK_PACKAGETYPE"].ToString();

            ANNEX_SEA_PACK_FROMDESC = dt.Rows[i]["ANNEX_SEA_PACK_FROMDESC"].ToString();
            ANNEX_SEA_PACK_TODESC = dt.Rows[i]["ANNEX_SEA_PACK_TODESC"].ToString();

            if (COMPANY_ID == "158")
            {
                ANNEX_SEA_PACK_FROM = dt.Rows[i]["ANNEX_SEA_PACK_FROMDESC"].ToString();
                ANNEX_SEA_PACK_TO = dt.Rows[i]["ANNEX_SEA_PACK_TODESC"].ToString();

                ANNEX_SEA_PACK_FROMDESC = "";
                ANNEX_SEA_PACK_TODESC = "";
            }
                       
            list.Add(new Rpt_Package_Details()
            {

                ANNEX_SEA_PACK_FROM = ANNEX_SEA_PACK_FROM,
                ANNEX_SEA_PACK_TO = ANNEX_SEA_PACK_TO,
                ANNEX_SEA_PACK_PACKAGETYPE = ANNEX_SEA_PACK_PACKAGETYPE,
                ANNEX_SEA_PACK_FROMDESC = ANNEX_SEA_PACK_FROMDESC,
                ANNEX_SEA_PACK_TODESC = ANNEX_SEA_PACK_TODESC


            });

            i++;
        }
        return list;
    }

}