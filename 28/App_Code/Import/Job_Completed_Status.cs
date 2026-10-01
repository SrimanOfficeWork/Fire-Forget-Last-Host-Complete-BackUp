using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for imp_Clear_Status
/// </summary>
public class Job_Completed_Status
{
    DataSet ds = new DataSet();
    int result = 0;

    private string _jobno;
    private string _fromdate;
    private string _Imp_name;
    private string _Tr_mode;
    private string _branch;
    private string _todate;
    private string _Flag;
    private string _ClearType;

    private string _Doc_Rec_Date;
    private string _Agent_Name;
    private string _Remarks;


    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public string fromdate
    {
        get { return _fromdate; }
        set { _fromdate = value; }
    }
    public string Imp_name
    {
        get { return _Imp_name; }
        set { _Imp_name = value; }
    }
    public string Tr_mode
    {
        get { return _Tr_mode; }
        set { _Tr_mode = value; }
    }
    public string Branch
    {
        get { return _branch; }
        set { _branch = value; }
    }
    public string To_date
    {
        get { return _todate; }
        set { _todate = value; }
    }
    public string JobNo
    {
        get { return _jobno; }
        set { _jobno = value; }
    }

    public string Flag
    {
        get { return _Flag; }
        set { _Flag = value; }
    }
    public string ClearType
    {
        get { return _ClearType; }
        set { _ClearType = value; }
    }

    public string Doc_Rec_Date
    {
        get { return _Doc_Rec_Date; }
        set { _Doc_Rec_Date = value; }
    }
    public string Agent_Name
    {
        get { return _Agent_Name; }
        set { _Agent_Name = value; }
    }
    public string Remarks
    {
        get { return _Remarks; }
        set { _Remarks = value; }
    }

    public DataTable General_Cleared_Status_Rpt()
    {
        try
        {

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            string[] arr3 = new string[] { };
            if (fromdate != string.Empty && fromdate != null)
            {
                arr = fromdate.Split('/');
                fromdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (To_date != string.Empty && To_date != null)
            {
                arr2 = To_date.Split('/');
                To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            if (Doc_Rec_Date != string.Empty && Doc_Rec_Date != null)
            {
                arr3 = Doc_Rec_Date.Split('/');
                Doc_Rec_Date = arr3[1] + '/' + arr3[0] + '/' + arr3[2];
            }


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@jobno", JobNo == string.Empty ? string.Empty : JobNo);
            param[1] = new SqlParameter("@imp_name", Imp_name == string.Empty ? string.Empty : Imp_name);
            param[2] = new SqlParameter("@from_date", fromdate == string.Empty ? string.Empty : fromdate); 

            param[3] = new SqlParameter("@to_date", To_date == string.Empty ? string.Empty : To_date);
            param[4] = new SqlParameter("@Tr_mode", Tr_mode == string.Empty ? string.Empty : Tr_mode);
            param[5] = new SqlParameter("@Branch", Branch == string.Empty ? string.Empty : Branch);

            param[6] = new SqlParameter("@Doc_Rec_Date", Doc_Rec_Date == string.Empty ? string.Empty : Doc_Rec_Date);
            param[7] = new SqlParameter("@Agent_Name", Agent_Name);
            param[8] = new SqlParameter("@Remarks", Remarks);

            param[9] = new SqlParameter("@flag", Flag);
            param[10] = new SqlParameter("@Type", ClearType);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_JOB_COMPLETED_STATUS", param);
            //result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
      
        }
        return ds.Tables[0];
        
    }

    /*
    public int General_Cleared_Select()
    {
        try
        {

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (Jobdate != string.Empty && Jobdate != null)
            {
                arr = Jobdate.Split('/');
                Jobdate = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (To_date != string.Empty && To_date != null)
            {
                arr2 = To_date.Split('/');
                To_date = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@jobno", JobNo == string.Empty ? string.Empty : JobNo);
            param[1] = new SqlParameter("@imp_name", Imp_name == string.Empty ? string.Empty : Imp_name);
            param[2] = new SqlParameter("@from_date", Jobdate == string.Empty ? string.Empty : Jobdate);

            param[3] = new SqlParameter("@to_date", To_date == string.Empty ? string.Empty : To_date);
            param[4] = new SqlParameter("@Tr_mode", Tr_mode == string.Empty ? string.Empty : Tr_mode);
            param[5] = new SqlParameter("@Branch", Branch == string.Empty ? string.Empty : Branch);

            param[8] = new SqlParameter("@flag", Flag);
            param[9] = new SqlParameter("@Type", ClearType);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_JOB_COMPLETED_STATUS", param);
            result = Convert.ToInt32(param[6].Value.ToString());

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return result;
       
    }
    */
}