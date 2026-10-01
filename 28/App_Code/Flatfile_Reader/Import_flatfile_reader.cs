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
/// Summary description for Import_General
/// </summary>
public class Import_flatfile_reader
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
    public int result;
    public string err;
    public int UPDATE_ID = 0;

    # region Common Attributes

    private string _flag;
    private string _USER_ID;
    private string _BRANCH_CODE;
    private string _YEAR;
    private string _WORKING_PERIOD;
    private string _JOBNO;
    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }

    #endregion


    #region Private Attributes

    private string _JOBID, _Ename, _JOBDATE, _TRANSPORT_MODE, _BE_TYPE, _CUSTOMS_HOUSE, _CUSTOMS_HOUSE_NAME, _IMPORTER_NAME, _ADDRESS1, _ADDRESS2, _ADDRESS3, _ADDRESS4
   , _ADDRESS5, _IEC_NO, _BRANCH_NO, _COUNTRY_ORIGIN, _PORT_ORIGIN, _PORT_SHIPMENT, _COUNTRY_SHIPMENT, _FILING_STATUS, _SECTION46, _SECTION46_DESC, _FIRSTCHECK, _FIRSTCHECK_DESC,
   _GREEN_CHANNEL, _GREEN_CHANNEL_DESC, _KACHHA_BE, _KACHHA_BE_DESC, _SECTION48, _SECTION48_DESC, _HIGH_SEA_SALE, _HIGH_SEA_SALE_NAME, _HIGH_SEA_IEC, _HIGH_SEA_BRANCH_SL_NO,
    _HSS_ADD1, _HSS_ADD2, _HSS_ADD3, _HSS_ADD4, _HSS_ADD5, _WAREHOUSE_NAME, _WAREHOUSE_CODE, _REMARKS, _IMP_EXP_TYPE, _COMMERCIAL_DETAILS_STATUS, _COMMERCIAL_TAX_STATENAME,
    _COMMERCIAL_TAX_STATECODE, _COMMERCIAL_TAX_TYPE, _COMMERCIAL_TAX_REGISTRATION_NO, _EXBOND_INBOND_BE_NO, _EXBOND_INBOND_BE_DATE, _EXBOND_BOND_NO, _EXBOND_BOND_DATE, _EXBOND_WAREHOUSE_CUSTOMS, _EXBOND_WAREHOUSE_CUSTOMS_CODE,
    _EXBOND_NOOFPACKAGE, _EXBOND_NOOFPACKAGE_UNITCODE, _EXBOND_GROSS_WEIGHT, _EXBOND_GROSS_WEIGHT_UNITCODE, _EXBOND_DIRECT_EXBONDING, _BRANCHCODE, _WORKINGPERIOD, _FILE_REF_NO, _ADCODE,
    _UCR_NO, _UCR_TYPE, _PAYMENT_METHOD_CODE, _PRECEDING_LEVEL, _DOC_RECEIVED_DATE, _AImpT_NAME, _EXBOND_ADDL_LOAD_HSS, _EXBOND_MISC_LOAD_RATE, _GSTN_TYPE, _GSTN_ID, _PARTY_REF_NO, _ETA,
    _AMENDMENT_TYPE, _AMENDMENT_STATUS, _GROUP_ID, _FRT_JOBNO, _FRT_GROUPID, _FRT_BRANCHCODE, _JOB_PREFIX, _JOB_SUFFIX, _JOBNO_PS, _COMPLETED_DATE, _CONTAINER_TYPE, _BRANCH_COMMON, _HSS_ADCODE, _ICE_ID, _CHA_NO, _PROVISIONAL, _PROVISIONAL_DESC,
    _INVOICE_SLNO, _ITEM_SLNO, _COUNTRY_CODE, _PORT_CODE, _STATE_CODE, _XMLGEN, _ITEM_COUNTRY, _SCHEM_CODE, _RITC, _Debit_Duty, _LICENSE_ID;
    

    #endregion

    #region Public Attributes

    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string COUNTRY_CODE { get { return _COUNTRY_CODE; } set { _COUNTRY_CODE = value; } }
    public string PORT_CODE { get { return _PORT_CODE; } set { _PORT_CODE = value; } }
    public string STATE_CODE { get { return _STATE_CODE; } set { _STATE_CODE = value; } }
    public string XMLGEN { get { return _XMLGEN; } set { _XMLGEN = value; } }
    public string ITEM_COUNTRY { get { return _ITEM_COUNTRY; } set { _ITEM_COUNTRY = value; } }
    public string SCHEM_CODE { get { return _SCHEM_CODE; } set { _SCHEM_CODE = value; } }
    public string RITC { get { return _RITC; } set { _RITC = value; } }
    public string Debit_Duty { get { return _Debit_Duty; } set { _Debit_Duty = value; } }
    public string LICENSE_ID { get { return _LICENSE_ID; } set { _LICENSE_ID = value; } }

    public string JOBID { get { return _JOBID; } set { _JOBID = value; } }
   
    public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }//_CUSTOMS_HOUSE_NAME
    public string CUSTOMS_HOUSE_NAME { get { return _CUSTOMS_HOUSE_NAME; } set { _CUSTOMS_HOUSE_NAME = value; } }
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
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string IMP_EXP_TYPE { get { return _IMP_EXP_TYPE; } set { _IMP_EXP_TYPE = value; } }
    public string COMMERCIAL_DETAILS_STATUS { get { return _COMMERCIAL_DETAILS_STATUS; } set { _COMMERCIAL_DETAILS_STATUS = value; } }
    public string COMMERCIAL_TAX_STATENAME { get { return _COMMERCIAL_TAX_STATENAME; } set { _COMMERCIAL_TAX_STATENAME = value; } }
    public string COMMERCIAL_TAX_STATECODE { get { return _COMMERCIAL_TAX_STATECODE; } set { _COMMERCIAL_TAX_STATECODE = value; } }
    public string COMMERCIAL_TAX_TYPE { get { return _COMMERCIAL_TAX_TYPE; } set { _COMMERCIAL_TAX_TYPE = value; } }
    public string COMMERCIAL_TAX_REGISTRATION_NO { get { return _COMMERCIAL_TAX_REGISTRATION_NO; } set { _COMMERCIAL_TAX_REGISTRATION_NO = value; } }
    public string EXBOND_INBOND_BE_NO { get { return _EXBOND_INBOND_BE_NO; } set { _EXBOND_INBOND_BE_NO = value; } }
    public string EXBOND_INBOND_BE_DATE { get { return _EXBOND_INBOND_BE_DATE; } set { _EXBOND_INBOND_BE_DATE = value; } }
    public string EXBOND_BOND_NO { get { return _EXBOND_BOND_NO; } set { _EXBOND_BOND_NO = value; } }
    public string EXBOND_BOND_DATE { get { return _EXBOND_BOND_DATE; } set { _EXBOND_BOND_DATE = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS { get { return _EXBOND_WAREHOUSE_CUSTOMS; } set { _EXBOND_WAREHOUSE_CUSTOMS = value; } }
    public string EXBOND_WAREHOUSE_CUSTOMS_CODE { get { return _EXBOND_WAREHOUSE_CUSTOMS_CODE; } set { _EXBOND_WAREHOUSE_CUSTOMS_CODE = value; } }
    public string EXBOND_NOOFPACKAGE { get { return _EXBOND_NOOFPACKAGE; } set { _EXBOND_NOOFPACKAGE = value; } }
    public string EXBOND_NOOFPACKAGE_UNITCODE { get { return _EXBOND_NOOFPACKAGE_UNITCODE; } set { _EXBOND_NOOFPACKAGE_UNITCODE = value; } }
    public string EXBOND_GROSS_WEIGHT { get { return _EXBOND_GROSS_WEIGHT; } set { _EXBOND_GROSS_WEIGHT = value; } }
    public string EXBOND_GROSS_WEIGHT_UNITCODE { get { return _EXBOND_GROSS_WEIGHT_UNITCODE; } set { _EXBOND_GROSS_WEIGHT_UNITCODE = value; } }
    public string EXBOND_DIRECT_EXBONDING { get { return _EXBOND_DIRECT_EXBONDING; } set { _EXBOND_DIRECT_EXBONDING = value; } }
    public string BRANCHCODE { get { return _BRANCHCODE; } set { _BRANCHCODE = value; } }
    public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
    public string JOB_PREFIX { get { return _JOB_PREFIX; } set { _JOB_PREFIX = value; } }
    public string JOB_SUFFIX { get { return _JOB_SUFFIX; } set { _JOB_SUFFIX = value; } }
    public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }
    public string COMPLETED_DATE { get { return _COMPLETED_DATE; } set { _COMPLETED_DATE = value; } }
    public string ADCODE { get { return _ADCODE; } set { _ADCODE = value; } }
    public string UCR_NO { get { return _UCR_NO; } set { _UCR_NO = value; } }
    public string UCR_TYPE { get { return _UCR_TYPE; } set { _UCR_TYPE = value; } }
    public string PAYMENT_METHOD_CODE { get { return _PAYMENT_METHOD_CODE; } set { _PAYMENT_METHOD_CODE = value; } }
    public string PRECEDING_LEVEL { get { return _PRECEDING_LEVEL; } set { _PRECEDING_LEVEL = value; } }
    public string DOC_RECEIVED_DATE { get { return _DOC_RECEIVED_DATE; } set { _DOC_RECEIVED_DATE = value; } }
    public string AImpT_NAME { get { return _AImpT_NAME; } set { _AImpT_NAME = value; } }
    public string EXBOND_ADDL_LOAD_HSS { get { return _EXBOND_ADDL_LOAD_HSS; } set { _EXBOND_ADDL_LOAD_HSS = value; } }
    public string EXBOND_MISC_LOAD_RATE { get { return _EXBOND_MISC_LOAD_RATE; } set { _EXBOND_MISC_LOAD_RATE = value; } }
    public string GSTN_TYPE { get { return _GSTN_TYPE; } set { _GSTN_TYPE = value; } }
    public string GSTN_ID { get { return _GSTN_ID; } set { _GSTN_ID = value; } }
    public string PARTY_REF_NO { get { return _PARTY_REF_NO; } set { _PARTY_REF_NO = value; } }
    public string ETA { get { return _ETA; } set { _ETA = value; } }
    public string AMENDMENT_TYPE { get { return _AMENDMENT_TYPE; } set { _AMENDMENT_TYPE = value; } }
    public string AMENDMENT_STATUS { get { return _AMENDMENT_STATUS; } set { _AMENDMENT_STATUS = value; } }
    public string GROUP_ID { get { return _GROUP_ID; } set { _GROUP_ID = value; } }
    public string FRT_JOBNO { get { return _FRT_JOBNO; } set { _FRT_JOBNO = value; } }
    public string FRT_GROUPID { get { return _FRT_GROUPID; } set { _FRT_GROUPID = value; } }
    public string FRT_BRANCHCODE { get { return _FRT_BRANCHCODE; } set { _FRT_BRANCHCODE = value; } }
    public string CONTAINER_TYPE { get { return _CONTAINER_TYPE; } set { _CONTAINER_TYPE = value; } }
    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string HSS_ADCODE { get { return _HSS_ADCODE; } set { _HSS_ADCODE = value; } }
    public string ICE_ID { get { return _ICE_ID; } set { _ICE_ID = value; } }
    public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }
    public string PROVISIONAL { get { return _PROVISIONAL; } set { _PROVISIONAL = value; } }
    public string PROVISIONAL_DESC { get { return _PROVISIONAL_DESC; } set { _PROVISIONAL_DESC = value; } }

    #endregion


    #region Insert & Update
 
    public int General_details_insertupdate()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[120];
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@JOBDATE", DateTime.Parse(JOBDATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[4] = new SqlParameter("@BE_TYPE", BE_TYPE);
            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[6] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[7] = new SqlParameter("@ADDRESS1", ADDRESS1);
            param[8] = new SqlParameter("@ADDRESS2", ADDRESS2);
            param[9] = new SqlParameter("@ADDRESS3", ADDRESS3);
            param[10] = new SqlParameter("@ADDRESS4", ADDRESS4);
            param[11] = new SqlParameter("@IEC_NO", IEC_NO);
            param[12] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
            param[13] = new SqlParameter("@COUNTRY_ORIGIN", COUNTRY_ORIGIN);
            param[14] = new SqlParameter("@PORT_SHIPMENT", PORT_SHIPMENT);
            param[15] = new SqlParameter("@COUNTRY_SHIPMENT", COUNTRY_SHIPMENT);
            param[16] = new SqlParameter("@FILING_STATUS", FILING_STATUS);
            param[17] = new SqlParameter("@SECTION46", SECTION46);
            param[18] = new SqlParameter("@SECTION46_DESC", SECTION46_DESC);
            param[19] = new SqlParameter("@FIRSTCHECK", FIRSTCHECK);
            param[20] = new SqlParameter("@FIRSTCHECK_DESC", FIRSTCHECK_DESC);
            param[21] = new SqlParameter("@GREEN_CHANNEL", GREEN_CHANNEL);
            param[22] = new SqlParameter("@GREEN_CHANNEL_DESC", GREEN_CHANNEL_DESC);
            param[23] = new SqlParameter("@KACHHA_BE", KACHHA_BE);
            param[24] = new SqlParameter("@KACHHA_BE_DESC", KACHHA_BE_DESC);
            param[25] = new SqlParameter("@SECTION48", SECTION48);
            param[26] = new SqlParameter("@SECTION48_DESC", SECTION48_DESC);
            param[27] = new SqlParameter("@HIGH_SEA_SALE", HIGH_SEA_SALE);
            param[28] = new SqlParameter("@HIGH_SEA_SALE_NAME", HIGH_SEA_SALE_NAME);
            param[29] = new SqlParameter("@HIGH_SEA_IEC", HIGH_SEA_IEC);
            param[30] = new SqlParameter("@HIGH_SEA_BRANCH_SL_NO", HIGH_SEA_BRANCH_SL_NO);
            param[31] = new SqlParameter("@HSS_ADD1", HSS_ADD1);
            param[32] = new SqlParameter("@HSS_ADD2", HSS_ADD2);
            param[33] = new SqlParameter("@HSS_ADD3", HSS_ADD3);
            param[34] = new SqlParameter("@HSS_ADD4", HSS_ADD4);
            param[35] = new SqlParameter("@HSS_ADD5", HSS_ADD5);
            param[36] = new SqlParameter("@WAREHOUSE_NAME", WAREHOUSE_NAME);
            param[37] = new SqlParameter("@WAREHOUSE_CODE", WAREHOUSE_CODE);
            param[38] = new SqlParameter("@REMARKS", REMARKS);
            param[39] = new SqlParameter("@USERID", USER_ID);
            param[40] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
            param[41] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);
            param[42] = new SqlParameter("@ADDRESS5", ADDRESS5);
            param[43] = new SqlParameter("@Mflag", flag);
            param[63] = new SqlParameter("@IMP_EXP_TYPE", IMP_EXP_TYPE);
            param[44] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[44].Direction = ParameterDirection.Output;
            param[45] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[45].Direction = ParameterDirection.Output;
            param[46] = new SqlParameter("@PORT_ORIGIN", PORT_ORIGIN);
            param[47] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[47].Direction = ParameterDirection.Output;

            param[48] = new SqlParameter("@COMMERCIAL_DETAILS_STATUS", COMMERCIAL_DETAILS_STATUS);
            param[67] = new SqlParameter("@COMMERCIAL_TAX_STATENAME", COMMERCIAL_TAX_STATENAME);
            param[49] = new SqlParameter("@COMMERCIAL_TAX_STATECODE", COMMERCIAL_TAX_STATECODE);
            param[50] = new SqlParameter("@COMMERCIAL_TAX_TYPE", COMMERCIAL_TAX_TYPE);
            param[51] = new SqlParameter("@COMMERCIAL_TAX_REGISTRATION_NO", COMMERCIAL_TAX_REGISTRATION_NO);
            param[52] = new SqlParameter("@EXBOND_INBOND_BE_NO", EXBOND_INBOND_BE_NO);
            param[53] = new SqlParameter("@EXBOND_INBOND_BE_DATE", DateTime.Parse(EXBOND_INBOND_BE_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[54] = new SqlParameter("@EXBOND_BOND_NO", EXBOND_BOND_NO);
            param[55] = new SqlParameter("@EXBOND_BOND_DATE", DateTime.Parse(EXBOND_BOND_DATE, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[56] = new SqlParameter("@EXBOND_WAREHOUSE_CUSTOMS", EXBOND_WAREHOUSE_CUSTOMS);
            param[57] = new SqlParameter("@EXBOND_WAREHOUSE_CUSTOMS_CODE", EXBOND_WAREHOUSE_CUSTOMS_CODE);
            param[58] = new SqlParameter("@EXBOND_NOOFPACKAGE", EXBOND_NOOFPACKAGE);
            param[59] = new SqlParameter("@EXBOND_NOOFPACKAGE_UNITCODE", EXBOND_NOOFPACKAGE_UNITCODE);
            param[60] = new SqlParameter("@EXBOND_GROSS_WEIGHT", EXBOND_GROSS_WEIGHT);
            param[61] = new SqlParameter("@EXBOND_GROSS_WEIGHT_UNITCODE", EXBOND_GROSS_WEIGHT_UNITCODE);
            param[62] = new SqlParameter("@EXBOND_DIRECT_EXBONDING", EXBOND_DIRECT_EXBONDING);
            param[64] = new SqlParameter("@CUSTOMS_HOUSE_NAME", CUSTOMS_HOUSE_NAME);
            param[65] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);
            param[66] = new SqlParameter("@CONTAINER_TYPE", CONTAINER_TYPE);
            param[68] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[69] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
            param[70] = new SqlParameter("@ADCODE", ADCODE);
            param[71] = new SqlParameter("@UCR_NO", UCR_NO);
            param[72] = new SqlParameter("@UCR_TYPE", UCR_TYPE);
            param[73] = new SqlParameter("@PAYMENT_METHOD_CODE", PAYMENT_METHOD_CODE);
            param[74] = new SqlParameter("@PRECEDING_LEVEL", PRECEDING_LEVEL);
            param[75] = new SqlParameter("@EXBOND_ADDL_LOAD_HSS", EXBOND_ADDL_LOAD_HSS);
            param[76] = new SqlParameter("@EXBOND_MISC_LOAD_RATE", EXBOND_MISC_LOAD_RATE);
            param[77] = new SqlParameter("@JOB_PREFIX", JOB_PREFIX);
            param[78] = new SqlParameter("@JOB_SUFFIX", JOB_SUFFIX);
            param[79] = new SqlParameter("@GSTN_TYPE", GSTN_TYPE);
            param[80] = new SqlParameter("@GSTN_ID", GSTN_ID);
            param[81] = new SqlParameter("@PARTY_REF_NO", PARTY_REF_NO);
            param[82] = new SqlParameter("@ETA", ETA);
            param[83] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
            param[84] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);
            // *********** start aded to link Freight jobs **************//
            param[85] = new SqlParameter("@GRP_ID", HttpContext.Current.Session["GroupID"].ToString());
            param[86] = new SqlParameter("@FRT_JOBNO", FRT_JOBNO);
            param[87] = new SqlParameter("@FRTGROUP_ID", FRT_GROUPID);
            param[88] = new SqlParameter("@FRT_BRANCHCODE", FRT_BRANCHCODE);
            // *********** start aded to link Freight jobs **************//
            param[89] = new SqlParameter("@HSS_ADCODE", HSS_ADCODE);
            param[90] = new SqlParameter("@Company_id", Connection.COMPANYID());
            param[91] = new SqlParameter("@ICE_ID", ICE_ID);
            param[92] = new SqlParameter("@CHA_NO", CHA_NO);
            param[93] = new SqlParameter("@PROVISIONAL", PROVISIONAL);
            param[94] = new SqlParameter("@PROVISIONAL_DESC", PROVISIONAL_DESC);


            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_INSERT_UPDATE", param);
            //SqlHelper.ExecuteNonQuery(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_INSERT_UPDATE_KJ", param);

            result = Convert.ToInt32(param[44].Value.ToString());
            if (flag == "S")
                UPDATE_ID = Convert.ToInt32(param[47].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    #endregion Insert & Update

    #region Retrieve Record

    public DataSet RetrieveAll_General_Details()
    {
        try
        {


            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBID", JOBID);

            param[1] = new SqlParameter("@JOBNO", JOBNO);

            param[2] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);

            param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);

            param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);

            param[5] = new SqlParameter("@name", Ename);

            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);


            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            param[9] = new SqlParameter("@startRowIndex", startRowIndex);

            param[10] = new SqlParameter("@maximumRows", maximumRows);

            param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            if (Ename == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[7].Value.ToString());


            }
            else
            {

                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH", param);
                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_GENERAL_DETAILS_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[11].Value.ToString());
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
                //string err = param[8].Value.ToString();
            }


        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
            //throw new ArgumentException(ex.Message);
        }
        return ds;
    }

    #endregion Retrieve Record


    public DataSet Retrieve_Custom_House_details()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[1] = new SqlParameter("@CUSTOMHOUSE_CODE", CUSTOMS_HOUSE);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "CUSTOM_HOUSE_DETAILS", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {

        }
        return ds;
    }


    public DataSet Retrieve_Import_Flatfile_JobNO()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[50];
            param[4] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[1] = new SqlParameter("@Working_Period", WORKING_PERIOD);
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("FLATFILE_READER_IMPORT_JOB_AUTOID", param);
            string err = param[2].Value.ToString();
            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {

        }
        return ds;
    }


    public int Retrieve_JobNO()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[50];
            param[4] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[1] = new SqlParameter("@Working_Period", WORKING_PERIOD);
            param[2] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[2].Direction = ParameterDirection.Output;
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("GENERAL_DETAILS_SP_AUTOID", param);
            result = Convert.ToInt32(param[2].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {

        }
        return result;
    }

    public DataSet Retrieve_County_Port_State_details()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@COUNTRY_CODE", COUNTRY_CODE);
            param[2] = new SqlParameter("@PORT_CODE", PORT_CODE);
            param[3] = new SqlParameter("@STATE_CODE", STATE_CODE);
            param[4] = new SqlParameter("@Flag", flag);
            param[5] = new SqlParameter("@Item_Country", ITEM_COUNTRY);
            param[6] = new SqlParameter("@Schem_Code", SCHEM_CODE);
            param[7] = new SqlParameter("@Ritc", RITC);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IMPORT_FF_READER_MASTER_DETAILS_UPDATE", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {

        }
        return ds;
    }


    public DataSet Update_Gen_Ms_Inv_Item_Details()
    {

        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[4] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[5] = new SqlParameter("@XML_Gen", XMLGEN);
            param[6] = new SqlParameter("@flag", flag);
            param[7] = new SqlParameter("@Debit_Duty", Debit_Duty);
            param[8] = new SqlParameter("@License_Id", LICENSE_ID);

            ds = Connection.Get_Dataset("IMPORT_FF_READER_GEN_INV_ITEM_DETAILS_UPDATE", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {

        }
        return ds;
    }
}