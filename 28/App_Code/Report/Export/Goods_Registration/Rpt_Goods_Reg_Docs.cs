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
/// Summary description for Rpt_Goods_Reg_Docs
/// </summary>
public class Rpt_Goods_Reg_Docs
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    
    //#region Private Attributes


    private string _GOODS_SEA_CON_ID;
    private string _GOODS_SEA_CON_JOBNO;
    private string _GOODS_SEA_CON_EQMT_SERIAL_NO;
    private string _GOODS_SEA_CON_EQMT_TYPE;
    private string _GOODS_SEA_CON_EQMT_ID;
    private string _GOODS_SEA_CON_EQMT_LOC;
    private string _GOODS_SEA_CON_PCKG_FROM;
    private string _GOODS_SEA_CON_PCKG_TO;
    private string _GOODS_SEA_CON_PCKG_COUNT;
    private string _GOODS_SEA_CON_PCKG_UQC;


    //--DOCUMENT TABLE
    private string _GOODS_DOCS_ID;
    private string _GOODS_DOCS_JOBNO;
    private string _MODE;
    private string _GOODS_DOCS_SERIAL_NO;
    private string _GOODS_DOCS_NAME;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;

    private string _Ename;

    private string _startRowIndex;
    private string _BRANCH_COMMON;
    private string _maximumRows;
    private string _totalRows;

    //#endregion

    //#region Public Attributes

    public string GOODS_SEA_CON_ID { get { return _GOODS_SEA_CON_ID; } set { _GOODS_SEA_CON_ID = value; } }
    public string GOODS_SEA_CON_JOBNO { get { return _GOODS_SEA_CON_JOBNO; } set { _GOODS_SEA_CON_JOBNO = value; } }
    public string GOODS_SEA_CON_EQMT_SERIAL_NO { get { return _GOODS_SEA_CON_EQMT_SERIAL_NO; } set { _GOODS_SEA_CON_EQMT_SERIAL_NO = value; } }
    public string GOODS_SEA_CON_EQMT_TYPE { get { return _GOODS_SEA_CON_EQMT_TYPE; } set { _GOODS_SEA_CON_EQMT_TYPE = value; } }
    public string GOODS_SEA_CON_EQMT_ID { get { return _GOODS_SEA_CON_EQMT_ID; } set { _GOODS_SEA_CON_EQMT_ID = value; } }
    public string GOODS_SEA_CON_EQMT_LOC { get { return _GOODS_SEA_CON_EQMT_LOC; } set { _GOODS_SEA_CON_EQMT_LOC = value; } }

    public string GOODS_SEA_CON_PCKG_FROM { get { return _GOODS_SEA_CON_PCKG_FROM; } set { _GOODS_SEA_CON_PCKG_FROM = value; } }
    public string GOODS_SEA_CON_PCKG_TO { get { return _GOODS_SEA_CON_PCKG_TO; } set { _GOODS_SEA_CON_PCKG_TO = value; } }
    public string GOODS_SEA_CON_PCKG_COUNT { get { return _GOODS_SEA_CON_PCKG_COUNT; } set { _GOODS_SEA_CON_PCKG_COUNT = value; } }
    public string GOODS_SEA_CON_PCKG_UQC { get { return _GOODS_SEA_CON_PCKG_UQC; } set { _GOODS_SEA_CON_PCKG_UQC = value; } }


    //--DOCUMENT TABLE
    public string GOODS_DOCS_ID { get { return _GOODS_DOCS_ID; } set { _GOODS_DOCS_ID = value; } }
    public string GOODS_DOCS_JOBNO { get { return _GOODS_DOCS_JOBNO; } set { _GOODS_DOCS_JOBNO = value; } }
    public string MODE { get { return _MODE; } set { _MODE = value; } }
    public string GOODS_DOCS_SERIAL_NO { get { return _GOODS_DOCS_SERIAL_NO; } set { _GOODS_DOCS_SERIAL_NO = value; } }
    public string GOODS_DOCS_NAME { get { return _GOODS_DOCS_NAME; } set { _GOODS_DOCS_NAME = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }


    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    //#endregion

    public List<Rpt_Goods_Reg_Docs> Rpt_Goods_Reg_Doc_Details(DataTable dt)
    {

        List<Rpt_Goods_Reg_Docs> list = new List<Rpt_Goods_Reg_Docs>();
        list.Clear();

        int i = 0;
        while (dt.Rows.Count > i)
        {

            DataRow row = dt.Rows[i];

            GOODS_DOCS_SERIAL_NO = row["GOODS_DOCS_SERIAL_NO"].ToString();
            GOODS_DOCS_NAME = row["GOODS_DOCS_NAME"].ToString();
           
            i++;

            list.Add(new Rpt_Goods_Reg_Docs()
            {
                GOODS_DOCS_SERIAL_NO = GOODS_DOCS_SERIAL_NO,
                GOODS_DOCS_NAME = GOODS_DOCS_NAME              
            });
        }

        return list;
    }
}