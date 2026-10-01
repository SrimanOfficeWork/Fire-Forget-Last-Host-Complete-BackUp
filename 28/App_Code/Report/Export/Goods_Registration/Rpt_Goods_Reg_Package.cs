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
/// Summary description for Goods_Reg_Package
/// </summary>
public class Rpt_Goods_Reg_Package
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
    public int result, UPDATE_ID = 0;

    # region Private Attributes

    private string _GOODS_PACK_ID;
    private string _GOODS_PACK_JOBNO;
    private string _GOODS_PACK_GROUP;
    private string _GOODS_PACK_FROM;
    private string _GOODS_PACK_TO;
    private string _GOODS_PACK_PACKAGETYPE;
    private string _GOODS_PACK_MODE;

    private string _GOODS_PACK_FROM_DESC;
    private string _GOODS_PACK_TO_DESC;

    private string _max_packages;

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

    public string GOODS_PACK_ID { get { return _GOODS_PACK_ID; } set { _GOODS_PACK_ID = value; } }
    public string GOODS_PACK_JOBNO { get { return _GOODS_PACK_JOBNO; } set { _GOODS_PACK_JOBNO = value; } }
    public string GOODS_PACK_GROUP { get { return _GOODS_PACK_GROUP; } set { _GOODS_PACK_GROUP = value; } }
    public string GOODS_PACK_FROM { get { return _GOODS_PACK_FROM; } set { _GOODS_PACK_FROM = value; } }
    public string GOODS_PACK_TO { get { return _GOODS_PACK_TO; } set { _GOODS_PACK_TO = value; } }
    public string GOODS_PACK_PACKAGETYPE { get { return _GOODS_PACK_PACKAGETYPE; } set { _GOODS_PACK_PACKAGETYPE = value; } }
    public string GOODS_PACK_MODE { get { return _GOODS_PACK_MODE; } set { _GOODS_PACK_MODE = value; } }

    public string GOODS_PACK_FROM_DESC { get { return _GOODS_PACK_FROM_DESC; } set { _GOODS_PACK_FROM_DESC = value; } }

    public string GOODS_PACK_TO_DESC { get { return _GOODS_PACK_TO_DESC; } set { _GOODS_PACK_TO_DESC = value; } }
        
    

    public string max_packages { get { return _max_packages; } set { _max_packages = value; } }
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

    public List<Rpt_Goods_Reg_Package> Export_Goods_Reg_Package(DataTable dt)
    {

        List<Rpt_Goods_Reg_Package> list = new List<Rpt_Goods_Reg_Package>();
        list.Clear();
        int i = 0;
        while (dt.Rows.Count > i)
        {

            DataRow row = dt.Rows[i];



            GOODS_PACK_GROUP = row["GOODS_PACK_GROUP"].ToString();
            GOODS_PACK_FROM = row["GOODS_PACK_FROM"].ToString();
            GOODS_PACK_TO = row["GOODS_PACK_TO"].ToString();
            GOODS_PACK_PACKAGETYPE = row["GOODS_PACK_PACKAGETYPE"].ToString();
            GOODS_PACK_MODE = row["GOODS_PACK_MODE"].ToString();

            GOODS_PACK_FROM_DESC = row["GOODS_PACK_FROM_DESC"].ToString();
            GOODS_PACK_TO_DESC = row["GOODS_PACK_TO_DESC"].ToString();

            i++;




            list.Add(new Rpt_Goods_Reg_Package()
            {


                GOODS_PACK_GROUP = GOODS_PACK_GROUP,
                GOODS_PACK_FROM = GOODS_PACK_FROM,
                GOODS_PACK_TO = GOODS_PACK_TO,
                GOODS_PACK_PACKAGETYPE = GOODS_PACK_PACKAGETYPE,
                GOODS_PACK_MODE = GOODS_PACK_MODE,
                GOODS_PACK_FROM_DESC=GOODS_PACK_FROM_DESC,
                GOODS_PACK_TO_DESC=GOODS_PACK_TO_DESC

            });
        }
        
        return list;
    }
}