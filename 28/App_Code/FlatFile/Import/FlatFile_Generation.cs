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
using System.IO;

/// <summary>
/// Summary description for FlatFile_Generation
/// </summary>
public class FlatFile_Generation
{

    #region Private string

    private int result;
    private bool result1;
    private string _JOBNO;
    private string _Ename;
    private string _Workingperiod;

    #region GeneralDetails_Private_Attributes
    private string _JOBID, _Name_Search;
    private string _JOBDATE;
    private string _TRANSPORT_MODE;
    private string _BE_TYPE;
    private string _CUSTOMS_HOUSE;
    private string _IMPORTER_NAME;
    private string _ADDRESS1;
    private string _ADDRESS2;
    private string _ADDRESS3;
    private string _ADDRESS4;
    private string _ADDRESS5;
    private string _IEC_NO;
    private string _BRANCH_NO;
    private string _COUNTRY_ORIGIN;
    private string _PORT_ORIGIN;

    private string _PORT_SHIPMENT;
    private string _COUNTRY_SHIPMENT;
    private string _FILING_STATUS;
    private string _SECTION46;
    private string _SECTION46_DESC;
    private string _FIRSTCHECK;
    private string _FIRSTCHECK_DESC;
    private string _GREEN_CHANNEL;
    private string _GREEN_CHANNEL_DESC;
    private string _KACHHA_BE;
    private string _KACHHA_BE_DESC;
    private string _SECTION48;
    private string _SECTION48_DESC;
    private string _HIGH_SEA_SALE;
    private string _HIGH_SEA_SALE_NAME;
    private string _HIGH_SEA_IEC;
    private string _HIGH_SEA_BRANCH_SL_NO;
    private string _HSS_ADD1;
    private string _HSS_ADD2;
    private string _HSS_ADD3;
    private string _HSS_ADD4;
    private string _HSS_ADD5;
    private string _WAREHOUSE_NAME;
    private string _WAREHOUSE_CODE;
    private string _REMARKS;
    #endregion

    #endregion
       
     
    #region public string

    public DataSet ds = new DataSet();

    public string JOBNo
    {
        get { return _JOBNO; }
        set { _JOBNO = value; }
    }
    public string Ename
    {
        get { return _Ename; }
        set { _Ename = value; }
    }
    public string Workingperiod
    {
        get { return _Workingperiod; }
        set { _Workingperiod = value; }
    }

    #region GeneralDetails_Public_Attributes

    public string Name_Search { get { return _Name_Search; } set { _Name_Search = value; } }
    public string JOBID { get { return _JOBID; } set { _JOBID = value; } }

    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
    public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
    public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
    public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
    public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
    public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
    public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
    public string COUNTRY_ORIGIN { get { return _COUNTRY_ORIGIN; } set { _COUNTRY_ORIGIN = value; } }
    public string PORT_ORIGIN { get { return _PORT_ORIGIN; } set { _PORT_ORIGIN = value; } }

    public string PORT_SHIPMENT { get { return _PORT_SHIPMENT; } set { _PORT_SHIPMENT = value; } }
    public string COUNTRY_SHIPMENT { get { return _COUNTRY_SHIPMENT; } set { _COUNTRY_SHIPMENT = value; } }
    public string FILING_STATUS { get { return _FILING_STATUS; } set { _FILING_STATUS = value; } }
    public string SECTION46 { get { return _SECTION46; } set { _SECTION46 = value; } }
    public string SECTION46_DESC { get { return _SECTION46_DESC; } set { _SECTION46_DESC = value; } }
    public string FIRSTCHECK { get { return _FIRSTCHECK; } set { _FIRSTCHECK = value; } }
    public string FIRSTCHECK_DESC { get { return _FIRSTCHECK_DESC; } set { _FIRSTCHECK_DESC = value; } }
    public string GREEN_CHANNEL { get { return _GREEN_CHANNEL; } set { _GREEN_CHANNEL = value; } }
    public string GREEN_CHANNEL_DESC { get { return _GREEN_CHANNEL_DESC; } set { _GREEN_CHANNEL_DESC = value; } }
    public string KACHHA_BE { get { return _KACHHA_BE; } set { _KACHHA_BE = value; } }
    public string KACHHA_BE_DESC { get { return _KACHHA_BE_DESC; } set { _KACHHA_BE_DESC = value; } }
    public string SECTION48 { get { return _SECTION48; } set { _SECTION48 = value; } }
    public string SECTION48_DESC { get { return _SECTION48_DESC; } set { _SECTION48_DESC = value; } }
    public string HIGH_SEA_SALE { get { return _HIGH_SEA_SALE; } set { _HIGH_SEA_SALE = value; } }
    public string HIGH_SEA_SALE_NAME { get { return _HIGH_SEA_SALE_NAME; } set { _HIGH_SEA_SALE_NAME = value; } }
    public string HIGH_SEA_IEC { get { return _HIGH_SEA_IEC; } set { _HIGH_SEA_IEC = value; } }
    public string HIGH_SEA_BRANCH_SL_NO { get { return _HIGH_SEA_BRANCH_SL_NO; } set { _HIGH_SEA_BRANCH_SL_NO = value; } }
    public string HSS_ADD1 { get { return _HSS_ADD1; } set { _HSS_ADD1 = value; } }
    public string HSS_ADD2 { get { return _HSS_ADD2; } set { _HSS_ADD2 = value; } }
    public string HSS_ADD3 { get { return _HSS_ADD3; } set { _HSS_ADD3 = value; } }
    public string HSS_ADD4 { get { return _HSS_ADD4; } set { _HSS_ADD4 = value; } }
    public string HSS_ADD5 { get { return _HSS_ADD5; } set { _HSS_ADD5 = value; } }
    public string REMARKS { get { return _REMARKS; } set { _REMARKS = value; } }
    public string WAREHOUSE_NAME { get { return _WAREHOUSE_NAME; } set { _WAREHOUSE_NAME = value; } }
    public string WAREHOUSE_CODE { get { return _WAREHOUSE_CODE; } set { _WAREHOUSE_CODE = value; } }
    
    #endregion

 
    #endregion

    public DataSet RetrieveAll_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", JOBNo);
            
            param[1] = new SqlParameter("@name", Ename);

            param[2] = new SqlParameter("@Working_Period", Workingperiod);


            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_FLAT_FILE_GENERATION", param);
            string err = param[5].Value.ToString();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
           
    }

    public void Get_AllDetails(string ddlJobNo)
    {
        //JOBNo = "";
        Ename = "FlatFile";
        Workingperiod = Workingperiod;
        ds = RetrieveAll_Details();

    }

}