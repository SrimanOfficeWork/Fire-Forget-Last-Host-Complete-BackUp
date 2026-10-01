using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for AnnexureC
/// </summary>
public class AnnexureC
{
	public AnnexureC()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    int i=0;
    DataSet ds = new DataSet();
    public int result;

#region publicAttributes

    public string currentuser, ddlJobNo;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    private string _JOBNO;
    private string _Ename;
    private string _Workingperiod,_BranchCode;


    public string JOBNO
    {
        get { return _JOBNO; }
        set { _JOBNO = value; }
    }
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    public string BranchCode
    {
        get { return _BranchCode; }
        set { _BranchCode = value; }
    }

    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

#endregion

    #region Private_Attributes Annexure_Sea

    public string _ANNEX_SEA_JOBNO,
        _ANNEX_SEA_FAC_STUFFED,
        _ANNEX_SEA_SAMPLE_ACCOM,
        _ANNEX_SEA_NATURE_OF_CARGO,
        _ANNEX_SEA_MARKS_NOS,
        _ANNEX_SEA_TOTAL_PACKAGES,
        _ANNEX_SEA_LOOSE_PACKETS,
        _ANNEX_SEA_NO_CONTAINERS,
        _ANNEX_SEA_GROSS_WEIGHT,
        _ANNEX_SEA_NET_WEIGHT,
        _ANNEX_SEA_UNIT_MEASUREMENT,
        _ANNEX_SEA_ROTATION_NO,
        _ANNEX_SEA_ROTATION_DATE,
        _ANNEX_SEA_FOB_VALUE;


    public string ANNEX_SEA_JOBNO { get { return _ANNEX_SEA_JOBNO; } set { _ANNEX_SEA_JOBNO = value; } }
    public string ANNEX_SEA_FAC_STUFFED { get { return _ANNEX_SEA_FAC_STUFFED; } set { _ANNEX_SEA_FAC_STUFFED = value; } }
    public string ANNEX_SEA_SAMPLE_ACCOM { get { return _ANNEX_SEA_SAMPLE_ACCOM; } set { _ANNEX_SEA_SAMPLE_ACCOM = value; } }
    public string ANNEX_SEA_NATURE_OF_CARGO { get { return _ANNEX_SEA_NATURE_OF_CARGO; } set { _ANNEX_SEA_NATURE_OF_CARGO = value; } }
    public string ANNEX_SEA_MARKS_NOS { get { return _ANNEX_SEA_MARKS_NOS; } set { _ANNEX_SEA_MARKS_NOS = value; } }
    public string ANNEX_SEA_TOTAL_PACKAGES { get { return _ANNEX_SEA_TOTAL_PACKAGES; } set { _ANNEX_SEA_TOTAL_PACKAGES = value; } }
    public string ANNEX_SEA_LOOSE_PACKETS { get { return _ANNEX_SEA_LOOSE_PACKETS; } set { _ANNEX_SEA_LOOSE_PACKETS = value; } }
    public string ANNEX_SEA_NO_CONTAINERS { get { return _ANNEX_SEA_NO_CONTAINERS; } set { _ANNEX_SEA_NO_CONTAINERS = value; } }
    public string ANNEX_SEA_GROSS_WEIGHT { get { return _ANNEX_SEA_GROSS_WEIGHT; } set { _ANNEX_SEA_GROSS_WEIGHT = value; } }
    public string ANNEX_SEA_NET_WEIGHT { get { return _ANNEX_SEA_NET_WEIGHT; } set { _ANNEX_SEA_NET_WEIGHT = value; } }
    public string ANNEX_SEA_UNIT_MEASUREMENT { get { return _ANNEX_SEA_UNIT_MEASUREMENT; } set { _ANNEX_SEA_UNIT_MEASUREMENT = value; } }
    public string ANNEX_SEA_ROTATION_NO { get { return _ANNEX_SEA_ROTATION_NO; } set { _ANNEX_SEA_ROTATION_NO = value; } }
    public string ANNEX_SEA_ROTATION_DATE { get { return _ANNEX_SEA_ROTATION_DATE; } set { _ANNEX_SEA_ROTATION_DATE = value; } }
    public string ANNEX_SEA_FOB_VALUE { get { return _ANNEX_SEA_FOB_VALUE; } set { _ANNEX_SEA_FOB_VALUE = value; } }

    #endregion

    #region Container

    public string _ANNEX_SEA_CON_CONTAINERNO,
        _ANNEX_SEA_CON_SIZE,
        _ANNEX_SEA_CON_TYPE,
        _ANNEX_SEA_CON_EXCISE_SEALNO,
        _ANNEX_SEA_CON_SEAL_DATE;

    public string ANNEX_SEA_CON_CONTAINERNO { get { return _ANNEX_SEA_CON_CONTAINERNO; } set { _ANNEX_SEA_CON_CONTAINERNO = value; } }
    public string ANNEX_SEA_CON_SIZE { get { return _ANNEX_SEA_CON_SIZE; } set { _ANNEX_SEA_CON_SIZE = value; } }
    public string ANNEX_SEA_CON_TYPE { get { return _ANNEX_SEA_CON_TYPE; } set { _ANNEX_SEA_CON_TYPE = value; } }
    public string ANNEX_SEA_CON_EXCISE_SEALNO { get { return _ANNEX_SEA_CON_EXCISE_SEALNO; } set { _ANNEX_SEA_CON_EXCISE_SEALNO = value; } }
    public string ANNEX_SEA_CON_SEAL_DATE { get { return _ANNEX_SEA_CON_SEAL_DATE; } set { _ANNEX_SEA_CON_SEAL_DATE = value; } }

    #endregion Container

    #region AR4
    public string _AR4_NO,
        _AR4_DATE,
        _AR4_COMMISSION_RATE,
        _AR4_DIVISION,
        _AR4_RANGE;

    public string AR4_NO { get { return _AR4_NO; } set { _AR4_NO = value; } }
    public string AR4_DATE { get { return _AR4_DATE; } set { _AR4_DATE = value; } }
    public string AR4_COMMISSION_RATE { get { return _AR4_COMMISSION_RATE; } set { _AR4_COMMISSION_RATE = value; } }
    public string AR4_DIVISION { get { return _AR4_DIVISION; } set { _AR4_DIVISION = value; } }
    public string AR4_RANGE { get { return _AR4_RANGE; } set { _AR4_RANGE = value; } }

    #endregion AR4

    public List<AnnexureC> Load_AnnexureC(DataTable dt)
    {
        List<AnnexureC> list=new List<AnnexureC>();

        list.Clear();
        i=0;

        while(dt.Rows.Count> i)
        {
            DataRow row=dt.Rows[i];

            list.Add(new AnnexureC()
            {
                ANNEX_SEA_JOBNO = row["ANNEX_SEA_JOBNO"].ToString(),
                ANNEX_SEA_FAC_STUFFED=row["ANNEX_SEA_FAC_STUFFED"].ToString(),
                ANNEX_SEA_SAMPLE_ACCOM=row["ANNEX_SEA_SAMPLE_ACCOM"].ToString(),
                ANNEX_SEA_NATURE_OF_CARGO=row["ANNEX_SEA_NATURE_OF_CARGO"].ToString(),
                ANNEX_SEA_MARKS_NOS=row["ANNEX_SEA_MARKS_NOS"].ToString(),
                ANNEX_SEA_TOTAL_PACKAGES=row["ANNEX_SEA_TOTAL_PACKAGES"].ToString(),
                ANNEX_SEA_LOOSE_PACKETS=row["ANNEX_SEA_LOOSE_PACKETS"].ToString(),
                ANNEX_SEA_NO_CONTAINERS=row["ANNEX_SEA_NO_CONTAINERS"].ToString(),
                ANNEX_SEA_GROSS_WEIGHT=row["ANNEX_SEA_GROSS_WEIGHT"].ToString(),
                ANNEX_SEA_NET_WEIGHT=row["ANNEX_SEA_NET_WEIGHT"].ToString(),
                ANNEX_SEA_UNIT_MEASUREMENT=row["ANNEX_SEA_UNIT_MEASUREMENT"].ToString(),
                ANNEX_SEA_ROTATION_NO=row["ANNEX_SEA_ROTATION_NO"].ToString(),
                ANNEX_SEA_ROTATION_DATE=row["ANNEX_SEA_ROTATION_DATE"].ToString(),
                ANNEX_SEA_FOB_VALUE=row["ANNEX_SEA_FOB_VALUE"].ToString()

            });
            i++;
        }

        return list;
            
    }

    public List<AnnexureC> Load_AnnexureC_Container(DataTable dt)
    {
        List<AnnexureC> list = new List<AnnexureC>();

        list.Clear();
        i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new AnnexureC()
            {
                ANNEX_SEA_CON_CONTAINERNO = row["ANNEX_SEA_CON_CONTAINERNO"].ToString(),
                ANNEX_SEA_CON_SIZE = row["ANNEX_SEA_CON_SIZE"].ToString(),
                ANNEX_SEA_CON_TYPE = row["ANNEX_SEA_CON_TYPE"].ToString(),
                ANNEX_SEA_CON_EXCISE_SEALNO = row["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString(),
                ANNEX_SEA_CON_SEAL_DATE = row["ANNEX_SEA_CON_SEAL_DATE"].ToString()             

            });
            i++;
        }

        return list;

    }

    public List<AnnexureC> Load_AnnexureC_AR4(DataTable dt)
    {
        List<AnnexureC> list = new List<AnnexureC>();

        list.Clear();
        i = 0;

        while (dt.Rows.Count > i)
        {
            DataRow row = dt.Rows[i];

            list.Add(new AnnexureC()
            {
                AR4_NO = row["AR4_NO"].ToString(),
                AR4_DATE = row["AR4_DATE"].ToString(),
                AR4_COMMISSION_RATE = row["AR4_COMMISSION_RATE"].ToString(),
                AR4_DIVISION = row["AR4_DIVISION"].ToString(),
                AR4_RANGE = row["AR4_RANGE"].ToString()

            });
            i++;
        }

        return list;

    }


    public DataSet RetrieveAll_Annexure_C_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNO);


            param[1] = new SqlParameter("@name", Ename);

            param[2] = new SqlParameter("@Branch", BranchCode);


            param[3] = new SqlParameter("@Working_Period", Working_Period);


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;


            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;



            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_AnnexureC_Report", param);

            result = Convert.ToInt32(param[4].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_Annexure_C_Details_Area()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@name", Ename);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[4] = new SqlParameter("@Working_Period", Working_Period);
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_AnnexureC_Report_AREA", param);
            result = Convert.ToInt32(param[4].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }


}