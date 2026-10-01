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
/// Summary description for Goods_Reg_Sea_Container
/// </summary>
public class Rpt_Goods_Reg_Sea_Container
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

    # region Private Attributes

    private string _GOODS_SEA_CON_ID;
    private string _GOODS_SEA_CON_JOBNO;
    private string _GOODS_SEA_CON_CONTAINERNO;
    private string _GOODS_SEA_CON_SIZE;
    private string _GOODS_SEA_CON_TYPE;
    private string _GOODS_SEA_CON_EXCISE_SEALNO;
    private string _GOODS_SEA_CON_SEAL_DATE;

    private string _GOODS_SEA_CON_SEALTYPE_INDICATOR;
    private string _GOODS_SEA_CON_SEAL_DEVICEID;
    private string _GOODS_SEA_CON_DOC_TYPE;
    private string _GOODS_SEA_CON_DOC_NUMBER;

    private string _GOODS_SEA_CON_EQMT_TYPE;
    private string _GOODS_SEA_CON_EQMT_QTY;
    private string _GOODS_SEA_CON_EQMT_QTY_CODE;

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;

    private string _Ename;

    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;

    #endregion

    # region Public Attributes

    public string GOODS_SEA_CON_ID { get { return _GOODS_SEA_CON_ID; } set { _GOODS_SEA_CON_ID = value; } }
    public string GOODS_SEA_CON_JOBNO { get { return _GOODS_SEA_CON_JOBNO; } set { _GOODS_SEA_CON_JOBNO = value; } }
    public string GOODS_SEA_CON_CONTAINERNO { get { return _GOODS_SEA_CON_CONTAINERNO; } set { _GOODS_SEA_CON_CONTAINERNO = value; } }
    public string GOODS_SEA_CON_SIZE { get { return _GOODS_SEA_CON_SIZE; } set { _GOODS_SEA_CON_SIZE = value; } }
    public string GOODS_SEA_CON_TYPE { get { return _GOODS_SEA_CON_TYPE; } set { _GOODS_SEA_CON_TYPE = value; } }
    public string GOODS_SEA_CON_EXCISE_SEALNO { get { return _GOODS_SEA_CON_EXCISE_SEALNO; } set { _GOODS_SEA_CON_EXCISE_SEALNO = value; } }
    public string GOODS_SEA_CON_SEAL_DATE { get { return _GOODS_SEA_CON_SEAL_DATE; } set { _GOODS_SEA_CON_SEAL_DATE = value; } }

    public string GOODS_SEA_CON_SEALTYPE_INDICATOR { get { return _GOODS_SEA_CON_SEALTYPE_INDICATOR; } set { _GOODS_SEA_CON_SEALTYPE_INDICATOR = value; } }
    public string GOODS_SEA_CON_SEAL_DEVICEID { get { return _GOODS_SEA_CON_SEAL_DEVICEID; } set { _GOODS_SEA_CON_SEAL_DEVICEID = value; } }
    public string GOODS_SEA_CON_DOC_TYPE { get { return _GOODS_SEA_CON_DOC_TYPE; } set { _GOODS_SEA_CON_DOC_TYPE = value; } }
    public string GOODS_SEA_CON_DOC_NUMBER { get { return _GOODS_SEA_CON_DOC_NUMBER; } set { _GOODS_SEA_CON_DOC_NUMBER = value; } }

    public string GOODS_SEA_CON_EQMT_TYPE { get { return _GOODS_SEA_CON_EQMT_TYPE; } set { _GOODS_SEA_CON_EQMT_TYPE = value; } }
    public string GOODS_SEA_CON_EQMT_QTY { get { return _GOODS_SEA_CON_EQMT_QTY; } set { _GOODS_SEA_CON_EQMT_QTY = value; } }
    public string GOODS_SEA_CON_EQMT_QTY_CODE { get { return _GOODS_SEA_CON_EQMT_QTY_CODE; } set { _GOODS_SEA_CON_EQMT_QTY_CODE = value; } }

    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }


    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    #endregion

    public List<Rpt_Goods_Reg_Sea_Container> Export_Goods_Reg_Sea_Container(DataTable dt)
    {

        List<Rpt_Goods_Reg_Sea_Container> list = new List<Rpt_Goods_Reg_Sea_Container>();
        list.Clear();

        int i = 0;
        while (dt.Rows.Count > i)
        {

            DataRow row = dt.Rows[i];




            GOODS_SEA_CON_CONTAINERNO = row["GOODS_SEA_CON_CONTAINERNO"].ToString();
            GOODS_SEA_CON_SIZE = row["GOODS_SEA_CON_SIZE"].ToString();
            GOODS_SEA_CON_TYPE = row["GOODS_SEA_CON_TYPE"].ToString();
            GOODS_SEA_CON_EXCISE_SEALNO = row["GOODS_SEA_CON_EXCISE_SEALNO"].ToString();
            GOODS_SEA_CON_SEAL_DATE = row["GOODS_SEA_CON_SEAL_DATE"].ToString();
            if (GOODS_SEA_CON_SEAL_DATE == "01/01/1900" || GOODS_SEA_CON_SEAL_DATE == "01-01-1900")
            {
                GOODS_SEA_CON_SEAL_DATE = "";
            }
            else
            {
                GOODS_SEA_CON_SEAL_DATE = GOODS_SEA_CON_SEAL_DATE;
            }

            
            GOODS_SEA_CON_SEALTYPE_INDICATOR = row["GOODS_SEA_CON_SEALTYPE_INDICATOR"].ToString();
            GOODS_SEA_CON_SEAL_DEVICEID = row["GOODS_SEA_CON_SEAL_DEVICEID"].ToString();
            GOODS_SEA_CON_DOC_TYPE = row["GOODS_SEA_CON_DOC_TYPE"].ToString();
            GOODS_SEA_CON_DOC_NUMBER = row["GOODS_SEA_CON_DOC_NUMBER"].ToString();
            GOODS_SEA_CON_EQMT_TYPE = row["GOODS_SEA_CON_EQMT_TYPE"].ToString();
            GOODS_SEA_CON_EQMT_QTY = row["GOODS_SEA_CON_EQMT_QTY"].ToString();
            GOODS_SEA_CON_EQMT_QTY_CODE = row["GOODS_SEA_CON_EQMT_QTY_CODE"].ToString();

            i++;


            list.Add(new Rpt_Goods_Reg_Sea_Container()
            {
                GOODS_SEA_CON_CONTAINERNO = GOODS_SEA_CON_CONTAINERNO,
                GOODS_SEA_CON_SIZE = GOODS_SEA_CON_SIZE,
                GOODS_SEA_CON_TYPE = GOODS_SEA_CON_TYPE,
                GOODS_SEA_CON_EXCISE_SEALNO = GOODS_SEA_CON_EXCISE_SEALNO,
                GOODS_SEA_CON_SEAL_DATE = GOODS_SEA_CON_SEAL_DATE,
                GOODS_SEA_CON_SEALTYPE_INDICATOR = GOODS_SEA_CON_SEALTYPE_INDICATOR,
                GOODS_SEA_CON_SEAL_DEVICEID = GOODS_SEA_CON_SEAL_DEVICEID,
                GOODS_SEA_CON_DOC_TYPE = GOODS_SEA_CON_DOC_TYPE,
                GOODS_SEA_CON_DOC_NUMBER = GOODS_SEA_CON_DOC_NUMBER,
                GOODS_SEA_CON_EQMT_TYPE = GOODS_SEA_CON_EQMT_TYPE,
                GOODS_SEA_CON_EQMT_QTY = GOODS_SEA_CON_EQMT_QTY,
                GOODS_SEA_CON_EQMT_QTY_CODE = GOODS_SEA_CON_EQMT_QTY_CODE

            });
        }

        return list;
    }
}