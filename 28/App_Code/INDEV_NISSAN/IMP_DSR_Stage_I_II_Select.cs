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


public class IMP_DSR_Stage_I_II_Select
{

    private string _from_date;
    private string _todate;
    private string _Imp_name;
    private string _BE_Status;
    private string _Jobno;
    private string _GridName;

    private string _BEType;
    private string _Flag;
    private string _Branch_Type;

     private string _AGING;
     private string _STATUS;
     private string _REMARKS;
     private string _BRANCH_CODE;
     private string _WORKINGPERIOD,_CREATEDON,_CREATEDBY,_MODIFIEDBY,_MODIFIEDON;

     IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }

    public string Imp_name { get { return _Imp_name; } set { _Imp_name = value; } }
    public string BE_Status { get { return _BE_Status; } set { _BE_Status = value; } }
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }

    public string BEType { get { return _BEType; } set { _BEType = value; } }
    public string GridName { get { return _GridName; } set { _GridName = value; } }

    public string AGING { get { return _AGING; } set { _AGING = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }

    public string CREATEDON { get { return _CREATEDON; } set { _CREATEDON = value; } }
    public string CREATEDBY { get { return _CREATEDBY; } set { _CREATEDBY = value; } }
    public string MODIFIEDBY { get { return _MODIFIEDBY; } set { _MODIFIEDBY = value; } }
    public string MODIFIEDON { get { return _MODIFIEDON; } set { _MODIFIEDON = value; } }

    public string _II_ID,
    _DOCUMENTS_RECEIVED_DATE,
    _GATE_IN_EXPORT,
    _I_ETD_FROM_ORIGIN_PORT,
    _I_TRANSIT_PORT_ETA,
    _II_TRANSIT_PORT_ETA,
    _II_ETD_FROM_TRANSIT_PORT,
    _III_TRANSIT_PORT_ETA,
    _III_ETD_FROM_TRANSIT_PORT,
    _FUL_DISCHRGE_AT_TRANSIT_PRT,
    _FINAL_VESSEL_TO_CHPT,
    _ETA,
    _ATA;

    public string II_ID { get { return _II_ID; } set { _II_ID = value; } }
    public string DOCUMENTS_RECEIVED_DATE { get { return _DOCUMENTS_RECEIVED_DATE; } set { _DOCUMENTS_RECEIVED_DATE = value; } }
    public string GATE_IN_EXPORT { get { return _GATE_IN_EXPORT; } set { _GATE_IN_EXPORT = value; } }
    public string I_ETD_FROM_ORIGIN_PORT { get { return _I_ETD_FROM_ORIGIN_PORT; } set { _I_ETD_FROM_ORIGIN_PORT = value; } }
    public string I_TRANSIT_PORT_ETA { get { return _I_TRANSIT_PORT_ETA; } set { _I_TRANSIT_PORT_ETA = value; } }

    public string II_TRANSIT_PORT_ETA { get { return _II_TRANSIT_PORT_ETA; } set { _II_TRANSIT_PORT_ETA = value; } }
    public string II_ETD_FROM_TRANSIT_PORT { get { return _II_ETD_FROM_TRANSIT_PORT; } set { _II_ETD_FROM_TRANSIT_PORT = value; } }
    public string III_TRANSIT_PORT_ETA { get { return _III_TRANSIT_PORT_ETA; } set { _III_TRANSIT_PORT_ETA = value; } }
    public string III_ETD_FROM_TRANSIT_PORT { get { return _III_ETD_FROM_TRANSIT_PORT; } set { _III_ETD_FROM_TRANSIT_PORT = value; } }

    public string FUL_DISCHRGE_AT_TRANSIT_PRT { get { return _FUL_DISCHRGE_AT_TRANSIT_PRT; } set { _FUL_DISCHRGE_AT_TRANSIT_PRT = value; } }
    public string FINAL_VESSEL_TO_CHPT { get { return _FINAL_VESSEL_TO_CHPT; } set { _FINAL_VESSEL_TO_CHPT = value; } }
    public string ETA { get { return _ETA; } set { _ETA = value; } }
    public string ATA { get { return _ATA; } set { _ATA = value; } }

    public int result,UPDATE_ID;

    DataSet ds = new DataSet();
    
    public DataSet IMP_DSR_Stage_I_Select_ALL(string STAGE)
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
            param[2] = new SqlParameter("@Jobno", Jobno);
            param[3] = new SqlParameter("@From_date", from_date);
            param[4] = new SqlParameter("@To_date", todate);

            param[5] = new SqlParameter("@BEType", BEType);
            param[6] = new SqlParameter("@GridName", GridName);
            param[7] = new SqlParameter("@Branch", Branch_Type);
            param[8] = new SqlParameter("@Flag", Flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            if (STAGE == "STAGE_II")
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DSR_STAGE_II_SELECT_ALL", param);
            }
            else
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMP_DSR_STAGE_I_SELECT_ALL", param);
            }        
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

     public int Imp_DSR_Stage_I_Ins_Upd()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[17];
            //string[] arr = new string[] { };
            //if (CLEARED_DATE_WOT != string.Empty && CLEARED_DATE_WOT != null)
            //{
            //    arr = CLEARED_DATE_WOT.Split('/');
            //    CLEARED_DATE_WOT = arr[1] + '/' + arr[0] + '/' + arr[2];
            //}
           // param[0] = new SqlParameter("@ID", @JOBNO);
            param[1] = new SqlParameter("@JOBNO", Jobno);
            param[2] = new SqlParameter("@AGING", AGING);
            param[3] = new SqlParameter("@STATUS", STATUS);
            param[4] = new SqlParameter("@REMARKS", REMARKS);

            param[5] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[6] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

            param[7] = new SqlParameter("@CREATEDON", DateTime.Parse(this.CREATEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[8] = new SqlParameter("@CREATEDBY", CREATEDBY);
            param[9] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
            param[10] = new SqlParameter("@MODIFIEDON", DateTime.Parse(this.MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[11] = new SqlParameter("@Branch",Branch_Type );
          
            param[12] = new SqlParameter("@flag", Flag);
           
            param[13] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            param[15] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_IMP_DSR_STAGE_I_INS_UPD", param);
            result = Convert.ToInt32(param[13].Value.ToString());

            if (Flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[73].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
         return result;
    }

     public int Imp_DSR_Stage_II_Ins_Upd()
     {
         try
         {
             SqlParameter[] param = new SqlParameter[40];
             //string[] arr = new string[] { };
             //if (CLEARED_DATE_WOT != string.Empty && CLEARED_DATE_WOT != null)
             //{
             //    arr = CLEARED_DATE_WOT.Split('/');
             //    CLEARED_DATE_WOT = arr[1] + '/' + arr[0] + '/' + arr[2];
             //}
             // param[0] = new SqlParameter("@ID", @JOBNO);
             param[1] = new SqlParameter("@JOBNO", Jobno);
             param[2] = new SqlParameter("@DOCUMENTS_RECEIVED_DATE", DOCUMENTS_RECEIVED_DATE);
             param[3] = new SqlParameter("@GATE_IN_EXPORT", GATE_IN_EXPORT);
             param[4] = new SqlParameter("@I_ETD_FROM_ORIGIN_PORT", I_ETD_FROM_ORIGIN_PORT);
             param[5] = new SqlParameter("@I_TRANSIT_PORT_ETA", I_TRANSIT_PORT_ETA);
             param[6] = new SqlParameter("@II_TRANSIT_PORT_ETA", II_TRANSIT_PORT_ETA);
             param[7] = new SqlParameter("@II_ETD_FROM_TRANSIT_PORT", II_ETD_FROM_TRANSIT_PORT);
             param[8] = new SqlParameter("@III_TRANSIT_PORT_ETA", III_TRANSIT_PORT_ETA);
             param[9] = new SqlParameter("@III_ETD_FROM_TRANSIT_PORT", III_ETD_FROM_TRANSIT_PORT);
             param[10] = new SqlParameter("@FUL_DISCHRGE_AT_TRANSIT_PRT", FUL_DISCHRGE_AT_TRANSIT_PRT);
             param[11] = new SqlParameter("@FINAL_VESSEL_TO_CHPT", FINAL_VESSEL_TO_CHPT);
             param[12] = new SqlParameter("@ETA", ETA);
             param[13] = new SqlParameter("@ATA", ATA);
           

             param[14] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
             param[15] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);

             param[16] = new SqlParameter("@CREATEDON", DateTime.Parse(this.CREATEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
             param[17] = new SqlParameter("@CREATEDBY", CREATEDBY);
             param[18] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
             param[19] = new SqlParameter("@MODIFIEDON", DateTime.Parse(this.MODIFIEDON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
             param[20] = new SqlParameter("@Branch", Branch_Type);

             param[21] = new SqlParameter("@flag", Flag);

             param[22] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
             param[22].Direction = ParameterDirection.Output;

             param[23] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[23].Direction = ParameterDirection.Output;

             param[24] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
             param[24].Direction = ParameterDirection.Output;


             SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "INDEV_IMP_DSR_STAGE_II_INS_UPD", param);
             result = Convert.ToInt32(param[22].Value.ToString());

             if (Flag == "S")
             {
                 UPDATE_ID = Convert.ToInt32(param[24].Value.ToString());
             }
         }
         catch (Exception ex)
         {
             ErrorLogs er = new ErrorLogs();
             er.makeLog(ex.Message);
         }
         return result;
     }
    
}
