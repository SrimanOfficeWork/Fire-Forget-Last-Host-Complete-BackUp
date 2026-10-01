using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

/// <summary>
/// Summary description for Decket_General
/// </summary>
/// 


public class Decket_General : ErrorLogs
{
    public int result = 0, UPDATE_ID = 0;

    #region Properties
    private string _JOB_ID;

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public string JOB_ID
    {
        get { return _JOB_ID; }
        set { _JOB_ID = value; }
    }
    private string _DOCKET_ID;

    public string DOCKET_ID
    {
        get { return _DOCKET_ID; }
        set { _DOCKET_ID = value; }
    }
    private string _FILE_REFNO;

    public string FILE_REFNO
    {
        get { return _FILE_REFNO; }
        set { _FILE_REFNO = value; }
    }
    private string _OOC_DATE;

    public string OOC_DATE
    {
        get { return _OOC_DATE; }
        set { _OOC_DATE = value; }
    }
    private string _DO_COLLECTED_DATE;

    public string DO_COLLECTED_DATE
    {
        get { return _DO_COLLECTED_DATE; }
        set { _DO_COLLECTED_DATE = value; }
    }
    private string _DETENTION_FREE_DAYS;

    public string DETENTION_FREE_DAYS
    {
        get { return _DETENTION_FREE_DAYS; }
        set { _DETENTION_FREE_DAYS = value; }
    }
    private string _PORT_NAME;

    public string PORT_NAME
    {
        get { return _PORT_NAME; }
        set { _PORT_NAME = value; }
    }
    private string _CONTAINER_LANDED_TIME;

    public string CONTAINER_LANDED_TIME
    {
        get { return _CONTAINER_LANDED_TIME; }
        set { _CONTAINER_LANDED_TIME = value; }
    }
    private string _CONTAINER_LANDED_DATE;

    public string CONTAINER_LANDED_DATE
    {
        get { return _CONTAINER_LANDED_DATE; }
        set { _CONTAINER_LANDED_DATE = value; }
    }
    private string _CONTAINER_OUT_TIME;

    public string CONTAINER_OUT_TIME
    {
        get { return _CONTAINER_OUT_TIME; }
        set { _CONTAINER_OUT_TIME = value; }
    }
    private string _CONTAINER_OUT_DATE;

    public string CONTAINER_OUT_DATE
    {
        get { return _CONTAINER_OUT_DATE; }
        set { _CONTAINER_OUT_DATE = value; }
    }
    private string _TRANSPORT_NAME;

    public string TRANSPORT_NAME
    {
        get { return _TRANSPORT_NAME; }
        set { _TRANSPORT_NAME = value; }
    }
    private string _TRUCK_NUMBER;

    public string TRUCK_NUMBER
    {
        get { return _TRUCK_NUMBER; }
        set { _TRUCK_NUMBER = value; }
    }
    private string _TPT_NET_AMOUNT;

    public string TPT_NET_AMOUNT
    {
        get { return _TPT_NET_AMOUNT; }
        set { _TPT_NET_AMOUNT = value; }
    }
    private string _HALTING_DAYS;

    public string HALTING_DAYS
    {
        get { return _HALTING_DAYS; }
        set { _HALTING_DAYS = value; }
    }
    private string _HALT_NET;

    public string HALT_NET
    {
        get { return _HALT_NET; }
        set { _HALT_NET = value; }
    }
    private string _DOVALID_DATE;

    public string DOVALID_DATE
    {
        get { return _DOVALID_DATE; }
        set { _DOVALID_DATE = value; }
    }
    private string _DO_EXTENSION;

    public string DO_EXTENSION
    {
        get { return _DO_EXTENSION; }
        set { _DO_EXTENSION = value; }
    }
    private string _VESSEL_NAME;

    public string VESSEL_NAME
    {
        get { return _VESSEL_NAME; }
        set { _VESSEL_NAME = value; }
    }
    private string _VESSEL_VOYAGE;

    public string VESSEL_VOYAGE
    {
        get { return _VESSEL_VOYAGE; }
        set { _VESSEL_VOYAGE = value; }
    }
    private string _ARRIVAL_DATE;

    public string ARRIVAL_DATE
    {
        get { return _ARRIVAL_DATE; }
        set { _ARRIVAL_DATE = value; }
    }
    private string _DUTY_PAID_DATE;

    public string DUTY_PAID_DATE
    {
        get { return _DUTY_PAID_DATE; }
        set { _DUTY_PAID_DATE = value; }
    }
    private string _DUTY_PAID_BY;

    public string DUTY_PAID_BY
    {
        get { return _DUTY_PAID_BY; }
        set { _DUTY_PAID_BY = value; }
    }
    private string _ADVANCE_RECEIVED_AMOUNT;

    public string ADVANCE_RECEIVED_AMOUNT
    {
        get { return _ADVANCE_RECEIVED_AMOUNT; }
        set { _ADVANCE_RECEIVED_AMOUNT = value; }
    }
    private string _ADVANCE_RECEIVED_DATE;

    public string ADVANCE_RECEIVED_DATE
    {
        get { return _ADVANCE_RECEIVED_DATE; }
        set { _ADVANCE_RECEIVED_DATE = value; }
    }
    private string _ADVANCE_PAID_BY;

    public string ADVANCE_PAID_BY
    {
        get { return _ADVANCE_PAID_BY; }
        set { _ADVANCE_PAID_BY = value; }
    }
    private string _TIN_NO;

    public string TIN_NO
    {
        get { return _TIN_NO; }
        set { _TIN_NO = value; }
    }

    private string _CHECKLIST_SENT_DATE;

    public string CHECKLIST_SENT_DATE
    {
        get { return _CHECKLIST_SENT_DATE; }
        set { _CHECKLIST_SENT_DATE = value; }
    }
    private string _CONFIRMATION_RECDATE;

    public string CONFIRMATION_RECDATE
    {
        get { return _CONFIRMATION_RECDATE; }
        set { _CONFIRMATION_RECDATE = value; }
    }
    private string _CFS_NAME;

    public string CFS_NAME
    {
        get { return _CFS_NAME; }
        set { _CFS_NAME = value; }
    }
    private string _FREIGHT_CERT_RECDATE;

    public string FREIGHT_CERT_RECDATE
    {
        get { return _FREIGHT_CERT_RECDATE; }
        set { _FREIGHT_CERT_RECDATE = value; }
    }
    private string _EROYAL_JOBNO;

    public string EROYAL_JOBNO
    {
        get { return _EROYAL_JOBNO; }
        set { _EROYAL_JOBNO = value; }
    }
    private string _ORIGINAL_DOCRECEDATE;

    public string ORIGINAL_DOCRECEDATE
    {
        get { return _ORIGINAL_DOCRECEDATE; }
        set { _ORIGINAL_DOCRECEDATE = value; }
    }
    private string _HOUSE_AGENTNAME;

    public string HOUSE_AGENTNAME
    {
        get { return _HOUSE_AGENTNAME; }
        set { _HOUSE_AGENTNAME = value; }
    }
    private string _MASTER_AGENTNAME;

    public string MASTER_AGENTNAME
    {
        get { return _MASTER_AGENTNAME; }
        set { _MASTER_AGENTNAME = value; }
    }
    private string _RMS_ORGROUP;

    public string RMS_ORGROUP
    {
        get { return _RMS_ORGROUP; }
        set { _RMS_ORGROUP = value; }
    }
    private string _CLEARED_DATE;

    public string CLEARED_DATE
    {
        get { return _CLEARED_DATE; }
        set { _CLEARED_DATE = value; }
    }
    private string _CLEARED_INSPERNAME;

    public string CLEARED_INSPERNAME
    {
        get { return _CLEARED_INSPERNAME; }
        set { _CLEARED_INSPERNAME = value; }
    }
    private string _CLEARED_DELPERNAME;

    public string CLEARED_DELPERNAME
    {
        get { return _CLEARED_DELPERNAME; }
        set { _CLEARED_DELPERNAME = value; }
    }
    private string _MOTHER_VESSELNAME;

    public string MOTHER_VESSELNAME
    {
        get { return _MOTHER_VESSELNAME; }
        set { _MOTHER_VESSELNAME = value; }
    }
    private string _MOTHER_VESSELVOYAGE;

    public string MOTHER_VESSELVOYAGE
    {
        get { return _MOTHER_VESSELVOYAGE; }
        set { _MOTHER_VESSELVOYAGE = value; }
    }

    private string _CREATED_BY;

    public string CREATED_BY
    {
        get { return _CREATED_BY; }
        set { _CREATED_BY = value; }
    }
    private string _CREATED_DATE;

    public string CREATED_DATE
    {
        get { return _CREATED_DATE; }
        set { _CREATED_DATE = value; }
    }
    private string _UPDATTED_BY;

    public string UPDATTED_BY
    {
        get { return _UPDATTED_BY; }
        set { _UPDATTED_BY = value; }
    }
    private string _UPDATED_DATE;

    public string UPDATED_DATE
    {
        get { return _UPDATED_DATE; }
        set { _UPDATED_DATE = value; }
    }
    private string _STATUS;

    public string STATUS
    {
        get { return _STATUS; }
        set { _STATUS = value; }
    }
    private string _BRANCH_CODE;

    public string BRANCH_CODE
    {
        get { return _BRANCH_CODE; }
        set { _BRANCH_CODE = value; }
    }
    private string _BRANCH_COMMON;

    public string BRANCH_COMMON
    {
        get { return _BRANCH_COMMON; }
        set { _BRANCH_COMMON = value; }
    }
    private string _YEAR;

    public string YEAR
    {
        get { return _YEAR; }
        set { _YEAR = value; }
    }
    private string _WORKING_PERIOD;

    public string WORKING_PERIOD
    {
        get { return _WORKING_PERIOD; }
        set { _WORKING_PERIOD = value; }
    }
    private string _Mflag;

    public string Mflag
    {
        get { return _Mflag; }
        set { _Mflag = value; }
    }
    private string _Mstatus;

    public string Mstatus
    {
        get { return _Mstatus; }
        set { _Mstatus = value; }
    }
    private string _ErrorMsg;

    public string ErrorMsg
    {
        get { return _ErrorMsg; }
        set { _ErrorMsg = value; }
    }
    private string _Update_Id;

    public string Update_Id
    {
        get { return _Update_Id; }
        set { _Update_Id = value; }
    }
    private string flag;

    public string Flag
    {
        get { return flag; }
        set { flag = value; }
    }

    private string _USER_ID;

    public string USER_ID
    {
        get { return _USER_ID; }
        set { _USER_ID = value; }
    }

    private string _Ename;

    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    private string _startRowIndex;

    public string StartRowIndex
    {
        get { return _startRowIndex; }
        set { _startRowIndex = value; }
    }
    private string _maximumRows;

    public string MaximumRows
    {
        get { return _maximumRows; }
        set { _maximumRows = value; }
    }
    private double _Total_Rows;

    public double Total_Rows
    {
        get { return _Total_Rows; }
        set { _Total_Rows = value; }
    }

    public string _IMPORTER_NAME, _GROSS_WEIGHT, _NET_WEIGHT;

    public string IMPORTER_NAME
    {
        get { return _IMPORTER_NAME; }
        set { _IMPORTER_NAME = value; }
    }

    public string GROSS_WEIGHT
    {
        get { return _GROSS_WEIGHT; }
        set { _GROSS_WEIGHT = value; }
    }

    public string NET_WEIGHT
    {
        get { return _NET_WEIGHT; }
        set { _NET_WEIGHT = value; }
    }

    public string _CONTAINER_SIZE_20, _CONTAINER_SIZE_40, _CONTAINER_TYPE, _NO_OF_PACKAGES, _SUPPLIER, _DUTY_UPDATED_DATE;

    public string _ITEM_DESCRIPTION, _CLEARANCE_DELIVERY, _TOT_CLEARANCE_PERIOD, _SERVICE_TASK_BWC;

    private string _Branch;
    public string Branch { get { return _Branch; } set { _Branch = value; } }

    public string CONTAINER_SIZE_20
    {
        get { return _CONTAINER_SIZE_20; }
        set { _CONTAINER_SIZE_20 = value; }
    }


    public string CONTAINER_SIZE_40
    {
        get { return _CONTAINER_SIZE_40; }
        set { _CONTAINER_SIZE_40 = value; }
    }



    public string CONTAINER_TYPE
    {
        get { return _CONTAINER_TYPE; }
        set { _CONTAINER_TYPE = value; }
    }

    public string NO_OF_PACKAGES
    {
        get { return _NO_OF_PACKAGES; }
        set { _NO_OF_PACKAGES = value; }
    }

    public string SUPPLIER
    {
        get { return _SUPPLIER; }
        set { _SUPPLIER = value; }
    }


    public string ITEM_DESCRIPTION
    {
        get { return _ITEM_DESCRIPTION; }
        set { _ITEM_DESCRIPTION = value; }
    }

    public string CLEARANCE_DELIVERY
    {
        get { return _CLEARANCE_DELIVERY; }
        set { _CLEARANCE_DELIVERY = value; }
    }

    public string TOT_CLEARANCE_PERIOD
    {
        get { return _TOT_CLEARANCE_PERIOD; }
        set { _TOT_CLEARANCE_PERIOD = value; }
    }


    public string SERVICE_TASK_BWC
    {
        get { return _SERVICE_TASK_BWC; }
        set { _SERVICE_TASK_BWC = value; }
    }


    public string DUTY_UPDATED_DATE
    {
        get { return _DUTY_UPDATED_DATE; }
        set { _DUTY_UPDATED_DATE = value; }
    }



    private string _TO_DATE;
    private string _FROM_DATE;

    private string _CLIENT_BRANCH_CODE;

    public string CLIENT_BRANCH_CODE { get { return _CLIENT_BRANCH_CODE; } set { _CLIENT_BRANCH_CODE = value; } }


    public string FROM_DATE { get { return _FROM_DATE; } set { _FROM_DATE = value; } }

    public string TO_DATE { get { return _TO_DATE; } set { _TO_DATE = value; } }



    #endregion Properties

  

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);


    public int General_details_insertupdate()
    {

            SqlParameter[] param = new SqlParameter[65];

            param[1] = new SqlParameter("@FILE_REFNO", this.FILE_REFNO);
            if (OOC_DATE == "" || OOC_DATE == null)
            {
                OOC_DATE = "01/01/1900";
            }
            param[2] = new SqlParameter("@OOC_DATE", DateTime.Parse(this.OOC_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            if (DO_COLLECTED_DATE == "" || DO_COLLECTED_DATE == null)
            {
                DO_COLLECTED_DATE = "01/01/1900";
            }
            param[3] = new SqlParameter("@DO_COLLECTED_DATE", DateTime.Parse(this.DO_COLLECTED_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[4] = new SqlParameter("@DETENTION_FREE_DAYS", this.DETENTION_FREE_DAYS);
            param[5] = new SqlParameter("@PORT_NAME", this.PORT_NAME);
            param[6] = new SqlParameter("@CONTAINER_LANDED_TIME", this.CONTAINER_LANDED_TIME);
            if (CONTAINER_LANDED_DATE == "" || CONTAINER_LANDED_DATE == null)
            {
                CONTAINER_LANDED_DATE = "01/01/1900";
            }
            param[7] = new SqlParameter("@CONTAINER_LANDED_DATE", DateTime.Parse(this.CONTAINER_LANDED_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[8] = new SqlParameter("@CONTAINER_OUT_TIME", this.CONTAINER_OUT_TIME);
            if (CONTAINER_OUT_DATE == "" || CONTAINER_OUT_DATE == null)
            {
                CONTAINER_OUT_DATE = "01/01/1900";
            }
            param[9] = new SqlParameter("@CONTAINER_OUT_DATE", DateTime.Parse(this.CONTAINER_OUT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[10] = new SqlParameter("@TRANSPORT_NAME", this.TRANSPORT_NAME);
            param[11] = new SqlParameter("@TRUCK_NUMBER", this.TRUCK_NUMBER);
            param[12] = new SqlParameter("@TPT_NET_AMOUNT", this.TPT_NET_AMOUNT);
            param[13] = new SqlParameter("@HALTING_DAYS", this.HALTING_DAYS);
            param[14] = new SqlParameter("@HALT_NET", this.HALT_NET);
            if (DOVALID_DATE == "" || DOVALID_DATE == null)
            {
                DOVALID_DATE = "01/01/1900";
            }
            param[15] = new SqlParameter("@DOVALID_DATE", DateTime.Parse(this.DOVALID_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));


            param[16] = new SqlParameter("@DO_EXTENSION", this.DO_EXTENSION);
            param[17] = new SqlParameter("@VESSEL_NAME", this.VESSEL_NAME);
            param[18] = new SqlParameter("@VESSEL_VOYAGE",this.VESSEL_VOYAGE);
            if (ARRIVAL_DATE == "" || ARRIVAL_DATE == null)
            {
                ARRIVAL_DATE = "01/01/1900";
            }
            param[19] = new SqlParameter("@ARRIVAL_DATE", DateTime.Parse(this.ARRIVAL_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            if (DUTY_PAID_DATE == "" || DUTY_PAID_DATE == null)
            {
                DUTY_PAID_DATE = "01/01/1900";
            }
            param[20] = new SqlParameter("@DUTY_PAID_DATE", DateTime.Parse(this.DUTY_PAID_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[21] = new SqlParameter("@DUTY_PAID_BY", this.DUTY_PAID_BY);
            param[22] = new SqlParameter("@ADVANCE_RECEIVED_AMOUNT", this.ADVANCE_RECEIVED_AMOUNT);
            if (ADVANCE_RECEIVED_DATE == "" || ADVANCE_RECEIVED_DATE == null)
            {
                ADVANCE_RECEIVED_DATE = "01/01/1900";
            }
            param[23] = new SqlParameter("@ADVANCE_RECEIVED_DATE", DateTime.Parse(this.ADVANCE_RECEIVED_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[24] = new SqlParameter("@ADVANCE_PAID_BY", this.ADVANCE_PAID_BY);
            param[25] = new SqlParameter("@TIN_NO", this.TIN_NO);
            if (CHECKLIST_SENT_DATE == "" || CHECKLIST_SENT_DATE == null)
            {
                CHECKLIST_SENT_DATE = "01/01/1900";
            }
            param[26] = new SqlParameter("@CHECKLIST_SENT_DATE", DateTime.Parse(this.CHECKLIST_SENT_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            if (CONFIRMATION_RECDATE == "" || CONFIRMATION_RECDATE == null)
            {
                CONFIRMATION_RECDATE = "01/01/1900";
            }
            param[27] = new SqlParameter("@CONFIRMATION_RECDATE", DateTime.Parse(this.CONFIRMATION_RECDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[28] = new SqlParameter("@CFS_NAME",this.CFS_NAME);
            if (FREIGHT_CERT_RECDATE == "" || FREIGHT_CERT_RECDATE == null)
            {
                FREIGHT_CERT_RECDATE = "01/01/1900";
            }
            param[29] = new SqlParameter("@FREIGHT_CERT_RECDATE", DateTime.Parse(this.FREIGHT_CERT_RECDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[30] = new SqlParameter("@EROYAL_JOBNO",this.EROYAL_JOBNO);
            if (ORIGINAL_DOCRECEDATE == "" || ORIGINAL_DOCRECEDATE == null)
            {
                ORIGINAL_DOCRECEDATE = "01/01/1900";
            }
            param[31] = new SqlParameter("@ORIGINAL_DOCRECEDATE", DateTime.Parse(this.ORIGINAL_DOCRECEDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[32] = new SqlParameter("@HOUSE_AGENTNAME",this.HOUSE_AGENTNAME);
            param[33] = new SqlParameter("@MASTER_AGENTNAME",this.MASTER_AGENTNAME);
            param[34] = new SqlParameter("@RMS_ORGROUP",this.RMS_ORGROUP);
            if (CLEARED_DATE == "" || CLEARED_DATE == null)
            {
                CLEARED_DATE = "01/01/1900";
            }
            param[35] = new SqlParameter("@CLEARED_DATE", DateTime.Parse(this.CLEARED_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[36] = new SqlParameter("@CLEARED_INSPERNAME",this.CLEARED_INSPERNAME);
            param[37] = new SqlParameter("@CLEARED_DELPERNAME",this.CLEARED_DELPERNAME);
            param[38] = new SqlParameter("@MOTHER_VESSELNAME",this.MOTHER_VESSELNAME);
            param[39] = new SqlParameter("@MOTHER_VESSELVOYAGE",this.MOTHER_VESSELVOYAGE);
        
            param[40] = new SqlParameter("@USER_ID", this.USER_ID);
            param[41] = new SqlParameter("@STATUS", this.STATUS);
            param[42] = new SqlParameter("@BRANCH_CODE", this.BRANCH_CODE);
            param[43] = new SqlParameter("@BRANCH_COMMON", this.BRANCH_COMMON);
            param[44] = new SqlParameter("@YEAR ", this.YEAR);
            param[45] = new SqlParameter("@WORKING_PERIOD", this.WORKING_PERIOD);

            param[50] = new SqlParameter("@IMPORTER_NAME", this.IMPORTER_NAME);
            param[51] = new SqlParameter("@GROSS_WEIGHT ", this.GROSS_WEIGHT);
            param[52] = new SqlParameter("@NET_WEIGHT", this.NET_WEIGHT);

            param[53] = new SqlParameter("@CONTAINER_SIZE_20", this.CONTAINER_SIZE_20);
            param[54] = new SqlParameter("@CONTAINER_SIZE_40", this.CONTAINER_SIZE_40);
            param[55] = new SqlParameter("@CONTAINER_TYPE", this.CONTAINER_TYPE);
            param[56] = new SqlParameter("@NO_OF_PACKAGES", this.NO_OF_PACKAGES);
            param[57] = new SqlParameter("@SUPPLIER", this.SUPPLIER);
            param[58] = new SqlParameter("@ITEM_DESCRIPTION", this.ITEM_DESCRIPTION);
            param[59] = new SqlParameter("@CLEARANCE_DELIVERY", this.CLEARANCE_DELIVERY);
            param[60] = new SqlParameter("@TOT_CLEARANCE_PERIOD", this.TOT_CLEARANCE_PERIOD);
            param[61] = new SqlParameter("@SERVICE_TASK_BWC", this.SERVICE_TASK_BWC);

            if (DUTY_UPDATED_DATE == "" || DUTY_UPDATED_DATE == null)
            {
                DUTY_UPDATED_DATE = "01/01/1900";
            }
            param[62] = new SqlParameter("@DUTY_UPDATED_DATE", DateTime.Parse(this.DUTY_UPDATED_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));





            param[46] = new SqlParameter("@Mflag", flag);

            param[47] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[47].Direction = ParameterDirection.Output;

            param[48] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[48].Direction = ParameterDirection.Output;

            param[49] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[49].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_DOCKET_DETAILS_INSERT_UPDATE", param);
            result = Convert.ToInt32(param[47].Value.ToString());
            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[49].Value.ToString());
            }
        return result;
    }

    public DataTable General_Search()
    
    
    {
        try
        {
          
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@FILE_REFNO", FILE_REFNO);
            param[1] = new SqlParameter("@PORT_NAME", PORT_NAME);
            param[2] = new SqlParameter("@TRANSPORT_NAME", TRANSPORT_NAME);
            param[3] = new SqlParameter("@TRUCK_NUMBER", TRUCK_NUMBER);
            param[4] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[5] = new SqlParameter("@Mflag", Mflag);
            param[6] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_DOCKET_GENEREL_SEARCH", param);
            result = Convert.ToInt32(param[6].Value.ToString());
            
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds.Tables[0];
    }

    public DataSet DocketGeneral_SearchSelect()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@FILE_REFNO", FILE_REFNO);
            param[2] = new SqlParameter("@Mflag", Mflag);
            param[3] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[4] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "IMPORT_DOCKET_SELECT", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }


    public DataSet Docket_Grid_Search()
    {
        try
        {

            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (FROM_DATE != string.Empty && FROM_DATE != null)
            {
                arr = FROM_DATE.Split('/');
                FROM_DATE = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (TO_DATE != string.Empty && TO_DATE != null)
            {
                arr2 = TO_DATE.Split('/');
                TO_DATE = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@from_date", FROM_DATE);
            param[1] = new SqlParameter("@to_date", TO_DATE);


            param[3] = new SqlParameter("@Branch", CLIENT_BRANCH_CODE);

            param[8] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);

            param[4] = new SqlParameter("@Ename", Ename);

            param[6] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;



            if (Ename == "Select_All_NormalSearch" || Ename == "Load_importer_name" || Ename == "Importernamewise_gridload" || Ename == "GridSearch_LoadAll" || Ename == "Importerwise_monthlyrpt")   
            {
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "DOCKET_ENTRY_GRID_LOAD", param);

                result = Convert.ToInt32(param[6].Value.ToString());

            }


            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);
            }
            else
                ds.Tables.Add(dt);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }


    public void Docket_Entry_XLs_Report(string ddlImp_name_, string Fromdate_, string Todate_, string Branch_, string Type_)
    {

      

        if (Fromdate_ != string.Empty || Todate_ != string.Empty)
        {
            FROM_DATE = Fromdate_;
            TO_DATE = Todate_;
        }


        HttpResponse Response = HttpContext.Current.Response;

        FROM_DATE = Fromdate_;
        TO_DATE = Todate_;





       if (ddlImp_name_ != string.Empty && Fromdate_ == string.Empty &&  Todate_ == string.Empty)
        {
            IMPORTER_NAME = ddlImp_name_;
            Ename = "Importernamewise_gridload";  
        }


        else if (ddlImp_name_ != string.Empty && Fromdate_ != string.Empty && Todate_ != string.Empty)
        {
            IMPORTER_NAME = ddlImp_name_;
            Ename = "Importerwise_monthlyrpt";
        }




       else if (ddlImp_name_ == string.Empty && Fromdate_ != string.Empty && Todate_ != string.Empty)
        {
            Ename = "Select_All_NormalSearch";
        }

        else
        {
            Ename = "GridSearch_LoadAll";  

        }



        IMPORTER_NAME = ddlImp_name_;

        CLIENT_BRANCH_CODE = Branch_;

        DataSet dss = Docket_Grid_Search();
        DataTable dt = dss.Tables[0];
        DateTime time = DateTime.Now;
        String s = time.ToString("yyyyMMddHHmm");//MMddHHmmss
        string Filename = "";

        Filename = "DocketEntry_Rpt";
        string strrptNametime = Filename + "_" + s;

        if (Type_ == "excel")
        {

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + strrptNametime + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = new GridView();
                gv.AllowPaging = false;
                gv.DataSource = dt;
                dt.Columns.Remove("FILE_REFNO");
                gv.DataBind();

                if (gv.Rows.Count > 0)
                {
                    foreach (TableCell cell in gv.HeaderRow.Cells)
                    {
                        cell.BackColor = gv.HeaderStyle.BackColor;
                    }
                    for (int i = 0; i < gv.HeaderRow.Cells.Count; i++)
                    {
                        gv.HeaderRow.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#D8D8D8 ");
                    }

                    gv.RenderControl(hw);
                }

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

        }
    }

    public void Open_PPT()
    {
        HttpResponse Response = HttpContext.Current.Response; 
        string filePath = System.Web.HttpContext.Current.Server.MapPath("~/LoginPage/GST.ppt");
        FileInfo file = new FileInfo(filePath);
        if (file.Exists)
        {
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/vnd.ms-powerpoint";
            file.IsReadOnly = true;
            Response.TransmitFile(file.FullName);
            Response.End();
        }
    }
    

}
