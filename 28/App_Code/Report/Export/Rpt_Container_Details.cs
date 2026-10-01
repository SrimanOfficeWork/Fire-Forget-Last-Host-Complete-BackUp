using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Rpt_Container_Details
/// </summary>
public class Rpt_Container_Details
{
    #region Private_Attributes

    private string _ANNEX_SEA_CON_CONTAINERNO;
    private string _ANNEX_SEA_CON_SIZE;
    private string _ANNEX_SEA_CON_TYPE;
    private string _ANNEX_SEA_CON_EXCISE_SEALNO;
    private string _ANNEX_SEA_CON_SEAL_DATE;
    private string _ANNEX_SEA_CON_SEALTYPE_INDICATOR;
    private string _ANNEX_SEA_CON_SEAL_DEVICEID;
    private string _ANNEX_SEA_CON_DOC_TYPE;
    private string _ANNEX_SEA_CON_DOC_NUMBER;

    #endregion

    #region Public Attributes

    public string ANNEX_SEA_CON_CONTAINERNO { get { return _ANNEX_SEA_CON_CONTAINERNO; } set { _ANNEX_SEA_CON_CONTAINERNO = value; } }
    public string ANNEX_SEA_CON_SIZE { get { return _ANNEX_SEA_CON_SIZE; } set { _ANNEX_SEA_CON_SIZE = value; } }

    public string ANNEX_SEA_CON_TYPE { get { return _ANNEX_SEA_CON_TYPE; } set { _ANNEX_SEA_CON_TYPE = value; } }
    public string ANNEX_SEA_CON_EXCISE_SEALNO { get { return _ANNEX_SEA_CON_EXCISE_SEALNO; } set { _ANNEX_SEA_CON_EXCISE_SEALNO = value; } }
    public string ANNEX_SEA_CON_SEAL_DATE { get { return _ANNEX_SEA_CON_SEAL_DATE; } set { _ANNEX_SEA_CON_SEAL_DATE = value; } }

    public string ANNEX_SEA_CON_SEALTYPE_INDICATOR { get { return _ANNEX_SEA_CON_SEALTYPE_INDICATOR; } set { _ANNEX_SEA_CON_SEALTYPE_INDICATOR = value; } }
    public string ANNEX_SEA_CON_SEAL_DEVICEID { get { return _ANNEX_SEA_CON_SEAL_DEVICEID; } set { _ANNEX_SEA_CON_SEAL_DEVICEID = value; } }
    public string ANNEX_SEA_CON_DOC_TYPE { get { return _ANNEX_SEA_CON_DOC_TYPE; } set { _ANNEX_SEA_CON_DOC_TYPE = value; } }
    public string ANNEX_SEA_CON_DOC_NUMBER { get { return _ANNEX_SEA_CON_DOC_NUMBER; } set { _ANNEX_SEA_CON_DOC_NUMBER = value; } }

    #endregion

    public List<Rpt_Container_Details> Get_CONTAINER_DETAILS(DataTable dt)
    {

        List<Rpt_Container_Details> list = new List<Rpt_Container_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (dt.Rows.Count > i)
        {

            ANNEX_SEA_CON_CONTAINERNO = dt.Rows[i]["ANNEX_SEA_CON_CONTAINERNO"].ToString();
            ANNEX_SEA_CON_SIZE = dt.Rows[i]["ANNEX_SEA_CON_SIZE"].ToString();
            ANNEX_SEA_CON_TYPE = dt.Rows[i]["ANNEX_SEA_CON_TYPE"].ToString();

            // NOTIFICATION_NO = dt.Rows[i]["NOTIFICATION_NO"].ToString();
            ANNEX_SEA_CON_EXCISE_SEALNO = dt.Rows[i]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString();
            ANNEX_SEA_CON_SEAL_DATE = dt.Rows[i]["ANNEX_SEA_CON_SEAL_DATE"].ToString();

            ANNEX_SEA_CON_SEALTYPE_INDICATOR = dt.Rows[i]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString();

            ANNEX_SEA_CON_SEAL_DEVICEID = dt.Rows[i]["ANNEX_SEA_CON_SEAL_DEVICEID"].ToString();
            ANNEX_SEA_CON_DOC_TYPE = dt.Rows[i]["ANNEX_SEA_CON_DOC_TYPE"].ToString();
            ANNEX_SEA_CON_DOC_NUMBER = dt.Rows[i]["ANNEX_SEA_CON_DOC_NUMBER"].ToString();

            list.Add(new Rpt_Container_Details()
            {

                ANNEX_SEA_CON_CONTAINERNO = ANNEX_SEA_CON_CONTAINERNO,
                ANNEX_SEA_CON_SIZE = ANNEX_SEA_CON_SIZE,
                ANNEX_SEA_CON_TYPE = ANNEX_SEA_CON_TYPE,
                //NOTIFICATION_NO = NOTIFICATION_NO,
                ANNEX_SEA_CON_EXCISE_SEALNO = ANNEX_SEA_CON_EXCISE_SEALNO,
                ANNEX_SEA_CON_SEAL_DATE = ANNEX_SEA_CON_SEAL_DATE,
                ANNEX_SEA_CON_SEALTYPE_INDICATOR = ANNEX_SEA_CON_SEALTYPE_INDICATOR,
                ANNEX_SEA_CON_SEAL_DEVICEID = ANNEX_SEA_CON_SEAL_DEVICEID,
                ANNEX_SEA_CON_DOC_TYPE = ANNEX_SEA_CON_DOC_TYPE,
                ANNEX_SEA_CON_DOC_NUMBER = ANNEX_SEA_CON_DOC_NUMBER

            });

            i++;
        }
        return list;
    }
}