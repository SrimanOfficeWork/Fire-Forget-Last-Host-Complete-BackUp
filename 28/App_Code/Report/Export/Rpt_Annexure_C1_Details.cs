using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
/// <summary>
/// Summary description for Annexure
/// </summary>
public class Rpt_Annexure_C1_Details
{
   

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    public int result;



    # region Private Attributes

    private string _ANNEX_ADDRESS1;
    private string _ANNEX_ADDRESS2;
    private string _ANNEX_ADDRESS3;
    private string _ANNEX_ADDRESS4;
    private string _ANNEX_ADDRESS5;
    private string _ANNEX_ID;
    private string _ANNEX_JOBNO;
    private string _ANNEX_EXPORTERNAME;
    private string _ANNEX_IECCODE;

   
    



    #endregion

    # region Public Attributes
    public string ANNEX_ADDRESS1 { get { return _ANNEX_ADDRESS1; } set { _ANNEX_ADDRESS1 = value; } }
    public string ANNEX_ADDRESS2 { get { return _ANNEX_ADDRESS2; } set { _ANNEX_ADDRESS2 = value; } }
    public string ANNEX_ADDRESS3 { get { return _ANNEX_ADDRESS3; } set { _ANNEX_ADDRESS3 = value; } }
    public string ANNEX_ADDRESS4 { get { return _ANNEX_ADDRESS4; } set { _ANNEX_ADDRESS4 = value; } }
    public string ANNEX_ADDRESS5 { get { return _ANNEX_ADDRESS5; } set { _ANNEX_ADDRESS5 = value; } }
  
    public string ANNEX_EXPORTERNAME { get { return _ANNEX_EXPORTERNAME; } set { _ANNEX_EXPORTERNAME = value; } }

    public string ANNEX_IECCODE { get { return _ANNEX_IECCODE; } set { _ANNEX_IECCODE = value; } }

    public string ANNEX_BR_SLNO{ get { return _ANNEX_BR_SLNO; } set { _ANNEX_BR_SLNO = value; } }
    public string ANNEX_EXAM_DATE{ get { return _ANNEX_EXAM_DATE; } set { _ANNEX_EXAM_DATE = value; } }
    public string ANNEX_EXAM_OFFICER{ get { return _ANNEX_EXAM_OFFICER; } set { _ANNEX_EXAM_OFFICER = value; } }
    public string ANNEX_EXAM_DESIGN{ get { return _ANNEX_EXAM_DESIGN; } set { _ANNEX_EXAM_DESIGN = value; } }
    public string ANNEX_SUPER_NAME{ get { return _ANNEX_SUPER_NAME; } set { _ANNEX_SUPER_NAME = value; } }
    public string ANNEX_SUPER_DESIGN{ get { return _ANNEX_SUPER_DESIGN; } set { _ANNEX_SUPER_DESIGN = value; } }
    public string ANNEX_COMMISSION_RATE{ get { return _ANNEX_COMMISSION_RATE; } set { _ANNEX_COMMISSION_RATE = value; } }
    public string ANNEX_DIVISION{ get { return _ANNEX_DIVISION; } set { _ANNEX_DIVISION = value; } }
    public string ANNEX_RANGE{ get { return _ANNEX_RANGE; } set { _ANNEX_RANGE = value; } }
    public string ANNEX_VERIFIED_EXAM_OFFICER{ get { return _ANNEX_VERIFIED_EXAM_OFFICER; } set { _ANNEX_VERIFIED_EXAM_OFFICER = value; } }
    public string ANNEX_SAMPLE_DRAWN{ get { return _ANNEX_SAMPLE_DRAWN; } set { _ANNEX_SAMPLE_DRAWN = value; } }
    public string ANNEX_SEAL_NO{ get { return _ANNEX_SEAL_NO; } set { _ANNEX_SEAL_NO = value; } }

     private string _ANNEX_BR_SLNO;
    private string _ANNEX_EXAM_DATE;
    private string _ANNEX_EXAM_OFFICER;
    private string _ANNEX_EXAM_DESIGN;
    private string _ANNEX_SUPER_NAME;
    private string _ANNEX_SUPER_DESIGN;
    private string _ANNEX_COMMISSION_RATE;
    private string _ANNEX_DIVISION;
    private string _ANNEX_RANGE;
    private string _ANNEX_VERIFIED_EXAM_OFFICER;
    private string _ANNEX_SAMPLE_DRAWN;
    private string _ANNEX_SEAL_NO;
    #endregion

    public List<Rpt_Annexure_C1_Details> Get_Export_Annexure_c1_Details(DataTable Annex_dt)
    {
        List<Rpt_Annexure_C1_Details> list = new List<Rpt_Annexure_C1_Details>();
        list.Clear();
       
        if (Annex_dt.Rows.Count > 0)
        {

            ANNEX_EXPORTERNAME = Annex_dt.Rows[0]["ANNEX_EXPORTERNAME"].ToString();

            ANNEX_IECCODE = Annex_dt.Rows[0]["ANNEX_IECCODE"].ToString();
            ANNEX_BR_SLNO = Annex_dt.Rows[0]["ANNEX_BR_SLNO"].ToString();

            ANNEX_ADDRESS1 = Annex_dt.Rows[0]["ANNEX_ADDRESS1"].ToString();
            ANNEX_ADDRESS2 = Annex_dt.Rows[0]["ANNEX_ADDRESS2"].ToString();
            ANNEX_ADDRESS3 = Annex_dt.Rows[0]["ANNEX_ADDRESS3"].ToString();
            ANNEX_ADDRESS4 = Annex_dt.Rows[0]["ANNEX_ADDRESS4"].ToString();
            string[] s1 = ANNEX_ADDRESS4.Split(new string[] { "--" }, StringSplitOptions.None);

            ANNEX_ADDRESS4 = s1[0].ToString();

            string annex = Annex_dt.Rows[0]["ANNEX_ADDRESS4"].ToString();

            if (annex.Contains("--"))
            {
                ANNEX_ADDRESS5 = s1[1].ToString();
            }
            else
            {
                ANNEX_ADDRESS5 = "";
            }                               
            
            if (ANNEX_EXPORTERNAME != "")
            {

                list.Add(new Rpt_Annexure_C1_Details()
                {
                    ANNEX_EXPORTERNAME = ANNEX_EXPORTERNAME,

                    ANNEX_IECCODE = ANNEX_IECCODE,
                    ANNEX_BR_SLNO=ANNEX_BR_SLNO,

                    ANNEX_ADDRESS1 = ANNEX_ADDRESS1,
                    ANNEX_ADDRESS2 = ANNEX_ADDRESS2,
                    ANNEX_ADDRESS3 = ANNEX_ADDRESS3,
                    ANNEX_ADDRESS4 = ANNEX_ADDRESS4,
                    ANNEX_ADDRESS5 = ANNEX_ADDRESS5

                });
            }

            else
            {
                list.Add(new Rpt_Annexure_C1_Details()
                {
                   
                    ANNEX_IECCODE =string.Empty,

                    ANNEX_ADDRESS1 = string.Empty,
                    ANNEX_ADDRESS2 = string.Empty,
                    ANNEX_ADDRESS3 = string.Empty,
                    ANNEX_ADDRESS4 = string.Empty,
                    ANNEX_ADDRESS5 = string.Empty

                });
            }
            
        }

     
        return list;
    }

      public List<Rpt_Annexure_C1_Details> Get_Export_Annexure_c1_Report(DataTable Annex_dt)
    {
        List<Rpt_Annexure_C1_Details> list = new List<Rpt_Annexure_C1_Details>();
        list.Clear();
       
        if (Annex_dt.Rows.Count > 0)
        {

            ANNEX_EXPORTERNAME = Annex_dt.Rows[0]["ANNEX_EXPORTERNAME"].ToString();

            ANNEX_IECCODE = Annex_dt.Rows[0]["ANNEX_IECCODE"].ToString();

            ANNEX_ADDRESS1 = Annex_dt.Rows[0]["ANNEX_ADDRESS1"].ToString();
            ANNEX_ADDRESS2 = Annex_dt.Rows[0]["ANNEX_ADDRESS2"].ToString();
            ANNEX_ADDRESS3 = Annex_dt.Rows[0]["ANNEX_ADDRESS3"].ToString();
            ANNEX_ADDRESS4 = Annex_dt.Rows[0]["ANNEX_ADDRESS4"].ToString();

            ANNEX_BR_SLNO = Annex_dt.Rows[0]["ANNEX_BR_SLNO"].ToString();
            ANNEX_EXAM_DATE = Annex_dt.Rows[0]["ANNEX_EXAM_DATE"].ToString();
            if (ANNEX_EXAM_DATE == "01/01/1900" || ANNEX_EXAM_DATE == "01-01-1900")
            {
                ANNEX_EXAM_DATE = string.Empty;
            }
            ANNEX_EXAM_OFFICER = Annex_dt.Rows[0]["ANNEX_EXAM_OFFICER"].ToString();
            ANNEX_EXAM_DESIGN = Annex_dt.Rows[0]["ANNEX_EXAM_DESIGN"].ToString();
            ANNEX_SUPER_NAME = Annex_dt.Rows[0]["ANNEX_SUPER_NAME"].ToString();
            ANNEX_SUPER_DESIGN = Annex_dt.Rows[0]["ANNEX_SUPER_DESIGN"].ToString();
            ANNEX_COMMISSION_RATE = Annex_dt.Rows[0]["ANNEX_COMMISSION_RATE"].ToString();
            ANNEX_DIVISION = Annex_dt.Rows[0]["ANNEX_DIVISION"].ToString();
            ANNEX_RANGE = Annex_dt.Rows[0]["ANNEX_RANGE"].ToString();
            ANNEX_VERIFIED_EXAM_OFFICER = Annex_dt.Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString();
            ANNEX_SAMPLE_DRAWN = Annex_dt.Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString();
            ANNEX_SEAL_NO = Annex_dt.Rows[0]["ANNEX_SEAL_NO"].ToString();
            
            string[] s1 = ANNEX_ADDRESS4.Split(new string[] { "--" }, StringSplitOptions.None);
            //ANNEX_ADDRESS4 = s1[0].ToString();
            //ANNEX_ADDRESS5 = s1[1].ToString();

            ANNEX_ADDRESS4 = s1[0].ToString();

            string annex = Annex_dt.Rows[0]["ANNEX_ADDRESS4"].ToString();

            if (annex.Contains("--"))
            {
                ANNEX_ADDRESS5 = s1[1].ToString();
            }
            else
            {
                ANNEX_ADDRESS5 = "";
            }         

            if (ANNEX_EXPORTERNAME != "")
            {

                list.Add(new Rpt_Annexure_C1_Details()
                {
                    ANNEX_EXPORTERNAME = ANNEX_EXPORTERNAME,

                    ANNEX_IECCODE = ANNEX_IECCODE,

                    ANNEX_ADDRESS1 = ANNEX_ADDRESS1,
                    ANNEX_ADDRESS2 = ANNEX_ADDRESS2,
                    ANNEX_ADDRESS3 = ANNEX_ADDRESS3,
                    ANNEX_ADDRESS4 = ANNEX_ADDRESS4,
                    ANNEX_ADDRESS5 = ANNEX_ADDRESS5,

                    ANNEX_BR_SLNO = ANNEX_BR_SLNO,
                    ANNEX_EXAM_DATE = ANNEX_EXAM_DATE,
                    ANNEX_EXAM_OFFICER = ANNEX_EXAM_OFFICER,
                    ANNEX_EXAM_DESIGN = ANNEX_EXAM_DESIGN,
                    ANNEX_SUPER_NAME = ANNEX_SUPER_NAME,
                    ANNEX_SUPER_DESIGN = ANNEX_SUPER_DESIGN,
                    ANNEX_COMMISSION_RATE = ANNEX_COMMISSION_RATE,
                    ANNEX_DIVISION = ANNEX_DIVISION,
                    ANNEX_RANGE = ANNEX_RANGE,
                    ANNEX_VERIFIED_EXAM_OFFICER = ANNEX_VERIFIED_EXAM_OFFICER,
                    ANNEX_SAMPLE_DRAWN = ANNEX_SAMPLE_DRAWN,
                    ANNEX_SEAL_NO = ANNEX_SEAL_NO
                  
                });
            }

            else
            {
                list.Add(new Rpt_Annexure_C1_Details()
                {
                   
                    ANNEX_IECCODE =string.Empty,

                    ANNEX_ADDRESS1 = string.Empty,
                    ANNEX_ADDRESS2 = string.Empty,
                    ANNEX_ADDRESS3 = string.Empty,
                    ANNEX_ADDRESS4 = string.Empty,
                    ANNEX_ADDRESS5 = string.Empty

                });
            }
            
        }

     
        return list;
    }


   

}