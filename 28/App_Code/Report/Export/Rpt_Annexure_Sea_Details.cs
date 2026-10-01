using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Rpt_Annexure_Sea_Details
/// </summary>
public class Rpt_Annexure_Sea_Details
{
    #region Private_Attributes

    private string _ANNEX_SEA_FAC_STUFFED;
    private string _ANNEX_SEA_SAMPLE_ACCOM;
    private string _ANNEX_SEA_FACTORY_ADD, _ANNEX_SEA_VOYAGENO, _ANNEX_SEA_VESSELNO, _ANNEX_SEA_VESSEL_DATE;

    #endregion

    #region Public Attributes

    public string ANNEX_SEA_FAC_STUFFED { get { return _ANNEX_SEA_FAC_STUFFED; } set { _ANNEX_SEA_FAC_STUFFED = value; } }
    public string ANNEX_SEA_SAMPLE_ACCOM { get { return _ANNEX_SEA_SAMPLE_ACCOM; } set { _ANNEX_SEA_SAMPLE_ACCOM = value; } }

    public string ANNEX_SEA_FACTORY_ADD { get { return _ANNEX_SEA_FACTORY_ADD; } set { _ANNEX_SEA_FACTORY_ADD = value; } }
    public string ANNEX_SEA_VOYAGENO { get { return _ANNEX_SEA_VOYAGENO; } set { _ANNEX_SEA_VOYAGENO = value; } }
    public string ANNEX_SEA_VESSELNO { get { return _ANNEX_SEA_VESSELNO; } set { _ANNEX_SEA_VESSELNO = value; } }
    public string ANNEX_SEA_VESSEL_DATE { get { return _ANNEX_SEA_VESSEL_DATE; } set { _ANNEX_SEA_VESSEL_DATE = value; } }

    #endregion

    public List<Rpt_Annexure_Sea_Details> Get_ANNEXURE_SEA_DETAILS(DataTable dt)
    {

        List<Rpt_Annexure_Sea_Details> list = new List<Rpt_Annexure_Sea_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (dt.Rows.Count > i)
        {

            ANNEX_SEA_FAC_STUFFED = dt.Rows[i]["ANNEX_SEA_FAC_STUFFED"].ToString();
            ANNEX_SEA_SAMPLE_ACCOM = dt.Rows[i]["ANNEX_SEA_SAMPLE_ACCOM"].ToString();
            ANNEX_SEA_FACTORY_ADD = dt.Rows[i]["ANNEX_SEA_FACTORY_ADD"].ToString();
            ANNEX_SEA_VOYAGENO = dt.Rows[i]["ANNEX_SEA_VOYAGENO"].ToString();
            ANNEX_SEA_VESSELNO = dt.Rows[i]["ANNEX_SEA_VESSELNO"].ToString();
            ANNEX_SEA_VESSEL_DATE = dt.Rows[i]["ANNEX_SEA_VESSEL_DATE"].ToString();



            list.Add(new Rpt_Annexure_Sea_Details()
            {

                ANNEX_SEA_FAC_STUFFED = ANNEX_SEA_FAC_STUFFED,
                ANNEX_SEA_SAMPLE_ACCOM = ANNEX_SEA_SAMPLE_ACCOM,
                ANNEX_SEA_FACTORY_ADD = ANNEX_SEA_FACTORY_ADD,
                ANNEX_SEA_VOYAGENO = ANNEX_SEA_VOYAGENO,
                ANNEX_SEA_VESSELNO = ANNEX_SEA_VESSELNO + " " + ANNEX_SEA_VESSEL_DATE,
                ANNEX_SEA_VESSEL_DATE = ANNEX_SEA_VESSEL_DATE


            });

            i++;
        }
        return list;
    }
}