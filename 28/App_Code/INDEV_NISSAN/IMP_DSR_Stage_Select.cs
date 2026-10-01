using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public class IMP_DSR_Stage_Select
{

    private string _from_date;
    private string _todate;
    private string _Imp_name;
    private string _BE_Status;
    private string _Jobno;
    private string _Flag;
    private string _Branch_Type;
    private string _flag;
    
    
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }

    public string Imp_name { get { return _Imp_name; } set { _Imp_name = value; } }
    public string BE_Status { get { return _BE_Status; } set { _BE_Status = value; } }
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public String Xml_D;

    public int result = 0, UPDATE_ID = 0;

    DataSet ds = new DataSet();
    public DataSet IMP_DSR_Stage_III_Select()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Imp_name", Imp_name);
            param[2] = new SqlParameter("@BE_Status", BE_Status);
            param[3] = new SqlParameter("@From_date", from_date);
            param[4] = new SqlParameter("@To_date", todate);
            param[5] = new SqlParameter("@Jobno", Jobno);
            param[6] = new SqlParameter("@Branch", Branch_Type);
            param[7] = new SqlParameter("@Flag", Flag);
            
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DSR_STAGE_III_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    DataSet dss = new DataSet();
    public DataSet IMP_Select()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Imp_name", Imp_name);
            param[2] = new SqlParameter("@BE_Status", BE_Status);
            param[3] = new SqlParameter("@From_date", from_date);
            param[4] = new SqlParameter("@To_date", todate);
            param[5] = new SqlParameter("@Jobno", Jobno);
            param[6] = new SqlParameter("@Branch", Branch_Type);
            param[7] = new SqlParameter("@Flag", Flag);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            dss = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DSR_STAGE_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return dss;
    }

    public void DSR_Stage_III_INS()
    {
        try
        {
            DataSet dw = new DataSet();

            SqlParameter[] param = new SqlParameter[15];

            param[3] = new SqlParameter("@xmlString", Xml_D);
            param[5] = new SqlParameter("@BRANCH_CODE", Branch_Type);
            param[7] = new SqlParameter("@flag", flag);

            param[8] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            dw = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_DSR_STAGE_III_INS_UPD", param);
            result = Convert.ToInt32(param[8].Value.ToString());

            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[10].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }


    public void DSR_Stage_IV_INS()
    {
        try
        {
            DataSet dw = new DataSet();

            SqlParameter[] param = new SqlParameter[15];

            param[3] = new SqlParameter("@xmlString", Xml_D);
            param[5] = new SqlParameter("@BRANCH_CODE", Branch_Type);
            param[7] = new SqlParameter("@flag", flag);

            param[8] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            dw = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_DSR_STAGE_IV_INS_UPD", param);
            result = Convert.ToInt32(param[8].Value.ToString());

            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[10].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void DSR_Stage_V_INS()
    {
        try
        {
            DataSet dw = new DataSet();

            SqlParameter[] param = new SqlParameter[15];

            param[3] = new SqlParameter("@xmlString", Xml_D);
            param[5] = new SqlParameter("@BRANCH_CODE", Branch_Type);
            param[7] = new SqlParameter("@flag", flag);

            param[8] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            dw = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_DSR_STAGE_V_INS_UPD", param);
            result = Convert.ToInt32(param[8].Value.ToString());

            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[10].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    DataSet ds_IV = new DataSet();
    public DataSet IMP_DSR_Stage_IV_Select()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Imp_name", Imp_name);
            param[2] = new SqlParameter("@BE_Status", BE_Status);
            param[3] = new SqlParameter("@From_date", from_date);
            param[4] = new SqlParameter("@To_date", todate);
            param[5] = new SqlParameter("@Jobno", Jobno);
            param[6] = new SqlParameter("@Branch", Branch_Type);
            param[7] = new SqlParameter("@Flag", Flag);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds_IV = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DSR_STAGE_IV_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds_IV;
    }

    DataSet ds_V = new DataSet();
    public DataSet IMP_DSR_Stage_V_Select()
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (from_date != string.Empty && from_date != null)
            {
                arr = from_date.Split('/');
                from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (todate != string.Empty && todate != null)
            {
                arr2 = todate.Split('/');
                todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Imp_name", Imp_name);
            param[2] = new SqlParameter("@BE_Status", BE_Status);
            param[3] = new SqlParameter("@From_date", from_date);
            param[4] = new SqlParameter("@To_date", todate);
            param[5] = new SqlParameter("@Jobno", Jobno);
            param[6] = new SqlParameter("@Branch", Branch_Type);
            param[7] = new SqlParameter("@Flag", Flag);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds_IV = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DSR_STAGE_V_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds_IV;
    }
}