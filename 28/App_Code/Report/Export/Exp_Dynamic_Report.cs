using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;


public class Exp_Dynamic_Report
{
    public int result = 0, UPDATE_ID = 0;
    DataSet ds = new DataSet();

    private string _T_ID;
    private string _TEMPLATE_NAME;
    private string _REPORT_COLUMN_NAME;
    private string _TR_MODE;
    private string _ACTIVE;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _flag;
    private string _TYPE;
    private string _Select_Con;

    private string _Jobno;
    private string _Report_Name;
    private string _From_date;
    private string _To_date;
    private string _Report_Name_id;
    private string _Orderby;
    private string _Rpt_Type;

    private string _COL_NAME;
    private string _Select_Item;


    private string _Exp_name;


    public string COL_NAME { get { return _COL_NAME; } set { _COL_NAME = value; } }
    public string Select_Item { get { return _Select_Item; } set { _Select_Item = value; } }

    public string T_ID { get { return _T_ID; } set { _T_ID = value; } }
    public string TEMPLATE_NAME { get { return _TEMPLATE_NAME; } set { _TEMPLATE_NAME = value; } }
    public string REPORT_COLUMN_NAME { get { return _REPORT_COLUMN_NAME; } set { _REPORT_COLUMN_NAME = value; } }
    public string TR_MODE { get { return _TR_MODE; } set { _TR_MODE = value; } }
    public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public string TYPE { get { return _TYPE; } set { _TYPE = value; } }
    public string Select_Con { get { return _Select_Con; } set { _Select_Con = value; } }

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Report_Name { get { return _Report_Name; } set { _Report_Name = value; } }
    public string Report_Name_id { get { return _Report_Name_id; } set { _Report_Name_id = value; } }

    public string From_date { get { return _From_date; } set { _From_date = value; } }
    public string To_date { get { return _To_date; } set { _To_date = value; } }

    public string Orderby { get { return _Orderby; } set { _Orderby = value; } }

    public string Rpt_Type { get { return _Rpt_Type; } set { _Rpt_Type = value; } }

    public string Exp_name { get { return _Exp_name; } set { _Exp_name = value; } }
    

    public DataSet All_Record()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Type", TYPE);
            param[1] = new SqlParameter("@Mode", TR_MODE);
            param[2] = new SqlParameter("@Active", ACTIVE);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[4] = new SqlParameter("@Select_Con", Select_Con);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_DYNAMIC_TABLE_SELECT", param);
            result = Convert.ToInt32(param[5].Value.ToString());
        }

        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet Report_data()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@Jobno", Jobno=Jobno==" "?string.Empty:Jobno);
            param[1] = new SqlParameter("@from_date", From_date);
            param[2] = new SqlParameter("@to_date", To_date);
            param[3] = new SqlParameter("@Branch", WORKING_PERIOD);
            param[4] = new SqlParameter("@Report_Name", Report_Name);
            param[5] = new SqlParameter("@Report_Name_id", Report_Name_id);
            param[6] = new SqlParameter("@Orderby", Orderby);
            param[7] = new SqlParameter("@Rpt_Type", Rpt_Type);
            param[8] = new SqlParameter("@Exp_name", Exp_name);
            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            if (WORKING_PERIOD != "")
            {
                ds = Connection.Get_Dataset("EXP_CUSTOMIZATION_RPT_BRANCH", param);
            }
            else
            {
                if (Connection.COMPANYID() == "382" || Connection.COMPANYID() == "350")
                {
                    ds = Connection.Get_Dataset("EXP_CUSTOMIZATION_RPT_COMMON_WithOut_EmptyRows", param);
                }
                else
                {
                    ds = Connection.Get_Dataset("EXP_CUSTOMIZATION_RPT_COMMON", param);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

}