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

public class Default_Settings
{
    DataSet ds = new DataSet();

    #region User_DefaultSettings private Attributes

    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _BRANCH_COMMON;
    private string _flag;

    private string _YesNo;
    private string _DEFAULT_ID;

    private string _SCHEME;
    private string _DUTY_BASED;
    private string _CIF_BASED;
    private string _QTY_BASED;

    #endregion User_DefaultSettings private Attributes

    #region User_DefaultSettings public Attributes

    public string YesNo
    {
        get
        {
            return _YesNo;
        }
        set
        {
            _YesNo = value;
        }
    }

    public string DEFAULT_ID
    {
        get
        {
            return _DEFAULT_ID;
        }
        set
        {
            _DEFAULT_ID = value;
        }
    }


    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public string SCHEME { get { return _SCHEME; } set { _SCHEME = value; } }
    public string DUTY_BASED { get { return _DUTY_BASED; } set { _DUTY_BASED = value; } }
    public string CIF_BASED { get { return _CIF_BASED; } set { _CIF_BASED = value; } }
    public string QTY_BASED { get { return _QTY_BASED; } set { _QTY_BASED = value; } }

    #endregion User_DefaultSettings public Attributes

    private string _PREFIX;
    private string _PMONTH;
    private string _PYEAR;
    private string _SUFFIX;
    private string _SMONTH;
    private string _SYEAR;
    private string _Start_id;

    public string PREFIX
    {
        get { return _PREFIX; }
        set { _PREFIX = value; }
    }
    public string Start_id { get { return _Start_id; } set { _Start_id = value; } }
    public string PMONTH { get { return _PMONTH; } set { _PMONTH = value; } }
    public string PYEAR { get { return _PYEAR; } set { _PYEAR = value; } }
    public string SUFFIX { get { return _SUFFIX; } set { _SUFFIX = value; } }
    public string SMONTH { get { return _SMONTH; } set { _SMONTH = value; } }
    public string SYEAR { get { return _SYEAR; } set { _SYEAR = value; } }


    #region Client_Default settings
    public string _STANDARD_TYPE;

    public string STANDARD_TYPE
    {
        get
        {
            return _STANDARD_TYPE;
        }
        set
        {
            _STANDARD_TYPE = value;
        }
    }

    #endregion

    public int result = 0;

    #region User_DefaultSettings

    public DataSet User_DefaultSettings_Insert_Update()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@DEFAULT_ID", DEFAULT_ID);
            param[1] = new SqlParameter("@MANUFAC_NAME_FROM_SUP", YesNo);
            param[2] = new SqlParameter("@USER_ID", USER_ID);
            param[3] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[4] = new SqlParameter("@YEAR", YEAR);
            param[5] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[6] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[7] = new SqlParameter("@Mflag", flag);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_DEFAULT_SETTINGS_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }

        return ds;
    }

    #endregion User_DefaultSettings


    #region Client_DefaultSettings

    public DataSet Client_DefaultSettings_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@DEFAULT_ID", DEFAULT_ID);
            param[1] = new SqlParameter("@STANDARD_TYPE", STANDARD_TYPE);
            param[2] = new SqlParameter("@USER_ID", USER_ID);
            param[3] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[4] = new SqlParameter("@YEAR", YEAR);
            param[5] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[6] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[7] = new SqlParameter("@Mflag", flag);

            param[8] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "CLIENT_DEFAULT_SETTINGS_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }

        return ds;
    }

    #endregion Client_DefaultSettings

    public DataSet User_PurchaseSettings_Insert_Update()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[13];

            param[0] = new SqlParameter("@PREFIX", PREFIX);
            param[1] = new SqlParameter("@PMONTH", PMONTH);
            param[2] = new SqlParameter("@PYEAR", PYEAR);
            param[3] = new SqlParameter("@SUFFIX", SUFFIX);
            param[4] = new SqlParameter("@SMONTH", SMONTH);
            param[5] = new SqlParameter("@SYEAR", SYEAR);
            //param[2] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCH", BRANCH_CODE);
            param[7] = new SqlParameter("@YEAR", YEAR);
            param[8] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            //param[6] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[9] = new SqlParameter("@Flag", flag);
            param[12] = new SqlParameter("@Start_id", Start_id);

            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "GST_PUR_ENTRY_SETTING", param);
            result = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }

        return ds;
    }


    #region Import_License_Default_Settings

    public DataSet Import_License_Default_Settings_Insert_Update()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[12];

            param[0] = new SqlParameter("@DEFAULT_ID", DEFAULT_ID);
            param[1] = new SqlParameter("@SCHEME", SCHEME);
            param[2] = new SqlParameter("@DUTY_BASED", DUTY_BASED);
            param[3] = new SqlParameter("@CIF_BASED", CIF_BASED);
            param[4] = new SqlParameter("@QTY_BASED", QTY_BASED);

            param[5] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[7] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[8] = new SqlParameter("@Mflag", flag);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_LICENSE_SETTINGS_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[9].Value.ToString());
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }

        return ds;
    }

    #endregion Import_License_Default_Settings



}