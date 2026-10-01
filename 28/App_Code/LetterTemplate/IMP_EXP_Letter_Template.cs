using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;
using System.Data;

public static class IMP_EXP_Letter_Template
{
    public static int result = 0, UPDATE_ID = 0;

    private static string _ID;
    private static string _JOBNO;

    private static string _IMP_EXP;

    public static string IMP_EXP
    {
        get { return _IMP_EXP; }
        set { _IMP_EXP = value; }
    }
    private static string _TEMP_NAME;

    public static string TEMP_NAME
    {
        get { return _TEMP_NAME; }
        set { _TEMP_NAME = value; }
    }
    private static string _TEMP_FIELDS;

    public static string TEMP_FIELDS
    {
        get { return _TEMP_FIELDS; }
        set { _TEMP_FIELDS = value; }
    }
    private static string _BRANCH_CODE;

    public static string BRANCH_CODE
    {
        get { return _BRANCH_CODE; }
        set { _BRANCH_CODE = value; }
    }
    private static string _USER_ID;

    public static string USER_ID
    {
        get { return _USER_ID; }
        set { _USER_ID = value; }
    }
    private static string _Flag;

    public static string Flag
    {
        get { return _Flag; }
        set { _Flag = value; }
    }

    public static string ID { get { return _ID; } set { _ID = value; } }
    public static string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    private static string _BRANCH_COMMON;
    public static string BRANCH_COMMON
    {
        get { return _BRANCH_COMMON; }
        set { _BRANCH_COMMON = value; }
    }

    private static string _TEMP_FIELDS_TAG;
    public static string TEMP_FIELDS_TAG
    {
        get { return _TEMP_FIELDS_TAG; }
        set { _TEMP_FIELDS_TAG = value; }
    }


    // IMP_EXP_LETTER_TEMPLATE IMP_EXP_LETTER_TEMPLATE_COLUMNS
    public static void IE_Letter_Temp_IUD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[14];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@IMP_EXP", IMP_EXP);
            param[2] = new SqlParameter("@TEMP_NAME", TEMP_NAME);
            param[3] = new SqlParameter("@TEMP_FIELDS", TEMP_FIELDS);
            param[4] = new SqlParameter("@TEMP_FIELDS_TAG", TEMP_FIELDS_TAG);
            param[5] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[6] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[8] = new SqlParameter("@USER_ID", USER_ID);
            param[9] = new SqlParameter("@Mflag", Flag);

            param[10] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_LETTER_TEMPLATE_INS_UPD", param);
            result = Convert.ToInt32(param[10].Value.ToString());

            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[12].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public static DataTable GetTemplateNames()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[14];

            param[0] = new SqlParameter("@ID", ID);
            param[1] = new SqlParameter("@IMP_EXP", IMP_EXP);
            param[2] = new SqlParameter("@TEMP_NAME", TEMP_NAME);
            param[3] = new SqlParameter("@TEMP_FIELDS", TEMP_FIELDS);
            param[4] = new SqlParameter("@TEMP_FIELDS_TAG", TEMP_FIELDS_TAG);
            param[5] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[6] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[8] = new SqlParameter("@USER_ID", USER_ID);
            param[9] = new SqlParameter("@Mflag", Flag);

            param[10] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;


          ds=  SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_EXP_LETTER_TEMPLATE_INS_UPD", param);
            
        }
        catch (Exception ex)
        {
        }
        return dt = ds.Tables[0];
    }

}