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


public class SB_Entry
{
    
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    
    int A1, A2;

    public int result = 0, UPDATE_ID = 0;
    private string _SB_ID,_JOBID,_SB_JOBNO,_SB_NO,_SB_DATE,_SB_PMV_VALUE,_SB_FOB_VALUE,_SB_DRAWBACK_VALUE,_USER_ID,_DATE_TIME,_STATUS,_BRANCH_CODE,_YEAR,_WORKING_PERIOD,_BRANCH_COMMON
                  , _flag, _Ename, _EXPENSE_AMT;

    public string JOBID { get { return _JOBID; } set { _JOBID = value; } }
    public string SB_ID { get { return _SB_ID; } set { _SB_ID = value; } }
    public string SB_JOBNO { get { return _SB_JOBNO; } set { _SB_JOBNO = value; } }
    public string SB_NO { get { return _SB_NO; } set { _SB_NO = value; } }
    public string SB_DATE { get { return _SB_DATE; } set { _SB_DATE = value; } }
    public string SB_PMV_VALUE { get { return _SB_PMV_VALUE; } set { _SB_PMV_VALUE = value; } }
    public string SB_FOB_VALUE { get { return _SB_FOB_VALUE; } set { _SB_FOB_VALUE = value; } }
    public string SB_DRAWBACK_VALUE { get { return _SB_DRAWBACK_VALUE; } set { _SB_DRAWBACK_VALUE = value; } }
     
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string EXPENSE_AMT { get { return _EXPENSE_AMT; } set { _EXPENSE_AMT = value; } }
    
    public int SB_Entry_Details_insertupdate()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[35];
            param[1] = new SqlParameter("@SB_ID",SB_ID);
            param[2] = new SqlParameter("@SB_JOBNO", SB_JOBNO);
            param[3] = new SqlParameter("@SB_NO", SB_NO);
            param[4] = new SqlParameter("@SB_DATE", DateTime.Parse(SB_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[5] = new SqlParameter("@SB_PMV_VALUE", SB_PMV_VALUE);
            param[6] = new SqlParameter("@SB_FOB_VALUE", SB_FOB_VALUE);
            param[7] = new SqlParameter("@SB_DRAWBACK_VALUE", SB_DRAWBACK_VALUE);

            param[8] = new SqlParameter("@EXPENSE_AMT", EXPENSE_AMT);
            param[9] = new SqlParameter("@USER_ID", USER_ID);
            param[10] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[11] = new SqlParameter("@YEAR", YEAR);
            param[12] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[14] = new SqlParameter("@Mflag", flag);

            param[32] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[32].Direction = ParameterDirection.Output;
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;
           
            param[34] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[34].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("EXPORT_SB_ENTRY_DETAILS_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[32].Value.ToString());

            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[34].Value.ToString());
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    ds = Return_Value();
                }
            }
            else
            {
                ds = Return_Value();
            }
        }
        catch (Exception ex)
        {
            Err_Msg(ex.Message);
        }
        return result;
    }

    public DataSet RetrieveAll_SB_Entry_Details()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@JOBID", JOBID);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                Connection.Get_Dataset("EXPORT_SB_ENTRY_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
            }
            else if (Ename == "select_Details" || Ename == "select_sb")
            {
                ds = Connection.Get_Dataset("EXPORT_SB_ENTRY_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds = Return_Value();
                    }
                }
                else
                {
                    ds = Return_Value();
                }
            }
            else
            {
                ds = Connection.Get_Dataset("EXPORT_SB_ENTRY_DETAILS_SELECT", param);
                result = Convert.ToInt32(param[4].Value.ToString());
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        ds = Return_Value();
                    }

                }
                else
                {
                    ds = Return_Value();
                }
            }


        }
        catch (Exception ex)
        {
            Err_Msg(ex.Message);
        }
        return ds;
    }

    private void Err_Msg(string Error)
    {
        Connection.Error_Msg(Error);
    }

    private DataSet Return_Value()
    {
        ds.Tables.Add(dt);
        return ds;
    }
}