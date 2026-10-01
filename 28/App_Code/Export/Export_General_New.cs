using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

    public class Export_General_New
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public int result, UPDATE_ID = 0;

        private string _OLD_JOBNO, _JOB_PREFIX, _JOB_SUFFIX, _SEARCH_CAT, _SEARCH_ITEM, _TYPE_OF_EXPORTER, _JOBNO_PS, _DB_Type, _DBS_Name, _Current_Working_Period, _JOBID, _JOBNO
        , _JOBDATE, _TRANSPORT_MODE, _CUSTOMS_HOUSE, _CUSTOMS_HOUSE_NAME, _FILE_REF_NO, _SB_TYPE, _EXPORTER_NAME, _BRANCH_NO, _IEC_NO, _ADDRESS1, _ADDRESS2, _ADDRESS3, _ADDRESS4
        , _ADDRESS5, _ADCODE, _BANK_ACCOUNT, _DRAWBACK_ACCOUNT, _CONSIGNEE_NAME, _CONSIGNEE_ADD1, _CONSIGNEE_ADD2, _CONSIGNEE_ADD3, _CONSIGNEE_ADD4, _CONSIGNEE_ADD5, _COUNTRY_DISCHARGE
        , _PORT_DISCHARGE, _COUNTRY_FINAL_DEST, _PORT_FINAL_DEST, _STATE_OF_EXPORT, _NFEI, _NFEI_TYPE, _RBI_WAIVER_NO, _RBI_WAIVER_DATE, _MARKS_NO, _flag, _USER_ID, _BRANCH_CODE, _YEAR
        , _WORKING_PERIOD, _BRANCH_COMMON, _Ename, _startRowIndex, _maximumRows, _totalRows, _CONSIGNEE_BRANCHSLNO, _GSTN_TYPE, _GSTN_ID, _PARTY_REF_NO, _CARTING_POINT, _IFSC_CODE
        , _AMENDMENT_TYPE, _AMENDMENT_STATUS, _PORT_OF_LOADING, _IMP_EXP_TYPE, _ICE_ID, _CHA_NO;

              
        public string SEARCH_CAT { get { return _SEARCH_CAT; } set { _SEARCH_CAT = value; } }
        public string SEARCH_ITEM { get { return _SEARCH_ITEM; } set { _SEARCH_ITEM = value; } }
        public string TYPE_OF_EXPORTER { get { return _TYPE_OF_EXPORTER; } set { _TYPE_OF_EXPORTER = value; } }
        public string JOBNO_PS { get { return _JOBNO_PS; } set { _JOBNO_PS = value; } }
        public string JOB_PREFIX { get { return _JOB_PREFIX; } set { _JOB_PREFIX = value; } }
        public string JOB_SUFFIX { get { return _JOB_SUFFIX; } set { _JOB_SUFFIX = value; } }
        public string OLD_JOBNO { get { return _OLD_JOBNO; } set { _OLD_JOBNO = value; } }
        public string DB_Type { get { return _DB_Type; } set { _DB_Type = value; } }
        public string DBS_Name { get { return _DBS_Name; } set { _DBS_Name = value; } }
        public string Current_Working_Period { get { return _Current_Working_Period; } set { _Current_Working_Period = value; } }
        public string JOBID { get { return _JOBID; } set { _JOBID = value; } }
        public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
        public string JOBDATE { get { return _JOBDATE; } set { _JOBDATE = value; } }
        public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
        public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
        public string FILE_REF_NO { get { return _FILE_REF_NO; } set { _FILE_REF_NO = value; } }
        public string CUSTOMS_HOUSE_NAME { get { return _CUSTOMS_HOUSE_NAME; } set { _CUSTOMS_HOUSE_NAME = value; } }

        public string SB_TYPE { get { return _SB_TYPE; } set { _SB_TYPE = value; } }
        public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
        public string BRANCH_NO { get { return _BRANCH_NO; } set { _BRANCH_NO = value; } }
        public string IEC_NO { get { return _IEC_NO; } set { _IEC_NO = value; } }
        public string ADDRESS1 { get { return _ADDRESS1; } set { _ADDRESS1 = value; } }
        public string ADDRESS2 { get { return _ADDRESS2; } set { _ADDRESS2 = value; } }
        public string ADDRESS3 { get { return _ADDRESS3; } set { _ADDRESS3 = value; } }
        public string ADDRESS4 { get { return _ADDRESS4; } set { _ADDRESS4 = value; } }
        public string ADDRESS5 { get { return _ADDRESS5; } set { _ADDRESS5 = value; } }
        public string ADCODE { get { return _ADCODE; } set { _ADCODE = value; } }
        public string BANK_ACCOUNT { get { return _BANK_ACCOUNT; } set { _BANK_ACCOUNT = value; } }
        public string DRAWBACK_ACCOUNT { get { return _DRAWBACK_ACCOUNT; } set { _DRAWBACK_ACCOUNT = value; } }
        public string CONSIGNEE_NAME { get { return _CONSIGNEE_NAME; } set { _CONSIGNEE_NAME = value; } }
        public string CONSIGNEE_ADD1 { get { return _CONSIGNEE_ADD1; } set { _CONSIGNEE_ADD1 = value; } }
        public string CONSIGNEE_ADD2 { get { return _CONSIGNEE_ADD2; } set { _CONSIGNEE_ADD2 = value; } }
        public string CONSIGNEE_ADD3 { get { return _CONSIGNEE_ADD3; } set { _CONSIGNEE_ADD3 = value; } }
        public string CONSIGNEE_ADD4 { get { return _CONSIGNEE_ADD4; } set { _CONSIGNEE_ADD4 = value; } }
        public string CONSIGNEE_ADD5 { get { return _CONSIGNEE_ADD5; } set { _CONSIGNEE_ADD5 = value; } }
        public string COUNTRY_DISCHARGE { get { return _COUNTRY_DISCHARGE; } set { _COUNTRY_DISCHARGE = value; } }
        public string PORT_DISCHARGE { get { return _PORT_DISCHARGE; } set { _PORT_DISCHARGE = value; } }
        public string COUNTRY_FINAL_DEST { get { return _COUNTRY_FINAL_DEST; } set { _COUNTRY_FINAL_DEST = value; } }
        public string PORT_FINAL_DEST { get { return _PORT_FINAL_DEST; } set { _PORT_FINAL_DEST = value; } }
        public string STATE_OF_EXPORT { get { return _STATE_OF_EXPORT; } set { _STATE_OF_EXPORT = value; } }
        public string NFEI { get { return _NFEI; } set { _NFEI = value; } }
        public string NFEI_TYPE { get { return _NFEI_TYPE; } set { _NFEI_TYPE = value; } }
        public string RBI_WAIVER_NO { get { return _RBI_WAIVER_NO; } set { _RBI_WAIVER_NO = value; } }
        public string RBI_WAIVER_DATE { get { return _RBI_WAIVER_DATE; } set { _RBI_WAIVER_DATE = value; } }
        public string MARKS_NO { get { return _MARKS_NO; } set { _MARKS_NO = value; } }
        public string flag { get { return _flag; } set { _flag = value; } }
        public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
        public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
        public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
        public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
        public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
        public string CONSIGNEE_BRANCHSLNO { get { return _CONSIGNEE_BRANCHSLNO; } set { _CONSIGNEE_BRANCHSLNO = value; } }
        public string Ename { get { return _Ename; } set { _Ename = value; } }
        public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
        public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
        public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
        public string GSTN_TYPE { get { return _GSTN_TYPE; } set { _GSTN_TYPE = value; } }
        public string GSTN_ID { get { return _GSTN_ID; } set { _GSTN_ID = value; } }

        public string PARTY_REF_NO { get { return _PARTY_REF_NO; } set { _PARTY_REF_NO = value; } }
        public string CARTING_POINT { get { return _CARTING_POINT; } set { _CARTING_POINT = value; } }
        public string IFSC_CODE { get { return _IFSC_CODE; } set { _IFSC_CODE = value; } }
        public string AMENDMENT_TYPE { get { return _AMENDMENT_TYPE; } set { _AMENDMENT_TYPE = value; } }
        public string AMENDMENT_STATUS { get { return _AMENDMENT_STATUS; } set { _AMENDMENT_STATUS = value; } }
        public string PORT_OF_LOADING { get { return _PORT_OF_LOADING; } set { _PORT_OF_LOADING = value; } }
        public string IMP_EXP_TYPE { get { return _IMP_EXP_TYPE; } set { _IMP_EXP_TYPE = value; } }
        public string ICE_ID { get { return _ICE_ID; } set { _ICE_ID = value; } }
        public string CHA_NO { get { return _CHA_NO; } set { _CHA_NO = value; } }

        //***********  start added by jayanthi to link freight job ***********//
        private string _FRT_JOBNO, _FRT_BRANCHCODE, _FRT_GROUPID;
        public string FRT_JOBNO { get { return _FRT_JOBNO; } set { _FRT_JOBNO = value; } }
        public string FRT_BRANCHCODE { get { return _FRT_BRANCHCODE; } set { _FRT_BRANCHCODE = value; } }
        public string FRT_GROUPID { get { return _FRT_GROUPID; } set { _FRT_GROUPID = value; } }
        //***********  start added by jayanthi to link freight job ***********//

        
        public int General_details_insertupdate()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[80];
                param[1] = new SqlParameter("@JOBNO", JOBNO);
                param[2] = new SqlParameter("@JOBDATE", Connection.DATE_FORMAT(JOBDATE == null ? "01/01/1900" :JOBDATE));  
                param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
                param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
                param[5] = new SqlParameter("@SB_TYPE", SB_TYPE);
                param[6] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
                param[7] = new SqlParameter("@BRANCH_NO", BRANCH_NO);
                param[8] = new SqlParameter("@IEC_NO", IEC_NO);
                param[9] = new SqlParameter("@ADDRESS1", ADDRESS1);
                param[10] = new SqlParameter("@ADDRESS2", ADDRESS2);
                param[11] = new SqlParameter("@ADDRESS3", ADDRESS3);
                param[12] = new SqlParameter("@ADDRESS4", ADDRESS4);
                param[13] = new SqlParameter("ADDRESS5", ADDRESS5);
                param[14] = new SqlParameter("@ADCODE", ADCODE);
                param[15] = new SqlParameter("@BANK_ACCOUNT", BANK_ACCOUNT);
                param[16] = new SqlParameter("@DRAWBACK_ACCOUNT", DRAWBACK_ACCOUNT);
                param[17] = new SqlParameter("@CONSIGNEE_NAME", CONSIGNEE_NAME);
                param[18] = new SqlParameter("@CONSIGNEE_ADD1", CONSIGNEE_ADD1);
                param[19] = new SqlParameter("@CONSIGNEE_ADD2", CONSIGNEE_ADD2);
                param[20] = new SqlParameter("@CONSIGNEE_ADD3", CONSIGNEE_ADD3);
                param[21] = new SqlParameter("@CONSIGNEE_ADD4", CONSIGNEE_ADD4);
                param[22] = new SqlParameter("@CONSIGNEE_ADD5", CONSIGNEE_ADD5);
                param[23] = new SqlParameter("@COUNTRY_DISCHARGE", COUNTRY_DISCHARGE);
                param[24] = new SqlParameter("@PORT_DISCHARGE", PORT_DISCHARGE);
                param[25] = new SqlParameter("@COUNTRY_FINAL_DEST", COUNTRY_FINAL_DEST);
                param[26] = new SqlParameter("@PORT_FINAL_DEST", PORT_FINAL_DEST);
                param[27] = new SqlParameter("@STATE_OF_EXPORT", STATE_OF_EXPORT);
                param[28] = new SqlParameter("@NFEI", NFEI);
                param[29] = new SqlParameter("@NFEI_TYPE", NFEI_TYPE);
                param[30] = new SqlParameter("@RBI_WAIVER_NO", RBI_WAIVER_NO);
                param[31] = new SqlParameter("@RBI_WAIVER_DATE", Connection.DATE_FORMAT(RBI_WAIVER_DATE == null ? "01/01/1900" :RBI_WAIVER_DATE));   
                param[32] = new SqlParameter("@MARKS_NO", MARKS_NO);
                param[33] = new SqlParameter("@USERID", USER_ID);
                param[34] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
                param[35] = new SqlParameter("@WORKINGPERIOD", WORKING_PERIOD);
                param[42] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
                param[36] = new SqlParameter("@Mflag", flag);
                param[37] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                param[37].Direction = ParameterDirection.Output;
                param[38] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                param[38].Direction = ParameterDirection.Output;
                param[39] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
                param[39].Direction = ParameterDirection.Output;
                param[40] = new SqlParameter("@CUSTOMS_HOUSE_NAME", CUSTOMS_HOUSE_NAME);
                param[41] = new SqlParameter("@FILE_REF_NO", FILE_REF_NO);
                param[43] = new SqlParameter("@TYPE_OF_EXPORTER", TYPE_OF_EXPORTER);
                param[44] = new SqlParameter("@JOBNO_PS", JOBNO_PS);
                param[45] = new SqlParameter("@CONSIGNEE_BRANCHSLNO", CONSIGNEE_BRANCHSLNO);

                param[46] = new SqlParameter("@JOB_PREFIX", JOB_PREFIX);
                param[47] = new SqlParameter("@JOB_SUFFIX", JOB_SUFFIX);

                param[48] = new SqlParameter("@GSTN_TYPE", GSTN_TYPE);
                param[49] = new SqlParameter("@GSTN_ID", GSTN_ID);

                param[50] = new SqlParameter("@PARTY_REF_NO", PARTY_REF_NO);
                param[51] = new SqlParameter("@CARTING_POINT", CARTING_POINT);
                param[52] = new SqlParameter("@IFSC_CODE", IFSC_CODE);

                // *********** start aded to link Freight jobs **************//
                param[53] = new SqlParameter("@GRP_ID", HttpContext.Current.Session["GroupID"].ToString());
                param[54] = new SqlParameter("@FRT_JOBNO", FRT_JOBNO);
                param[55] = new SqlParameter("@FRTGROUP_ID", FRT_GROUPID);
                param[56] = new SqlParameter("@FRT_BRANCHCODE", FRT_BRANCHCODE);
                // *********** start aded to link Freight jobs **************//

                param[57] = new SqlParameter("@AMENDMENT_TYPE", AMENDMENT_TYPE);
                param[58] = new SqlParameter("@AMENDMENT_STATUS", AMENDMENT_STATUS);
                param[59] = new SqlParameter("@PORT_OF_LOADING", PORT_OF_LOADING);
                param[60] = new SqlParameter("@IMP_EXP_TYPE", IMP_EXP_TYPE);
                param[61] = new SqlParameter("@ICE_ID", ICE_ID);
                param[62] = new SqlParameter("@CHA_NO", CHA_NO);

                Connection.Get_Dataset("SP_EXPORT_GENERAL_DETAILS_INSERT_UPDATE", param);
                result = Convert.ToInt32(param[37].Value.ToString());

                string err = param[38].Value.ToString();
                if (flag == "S")
                    UPDATE_ID = Convert.ToInt32(param[39].Value.ToString());

            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
            return result;
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

                Connection.Get_Dataset("SP_EXPORT_GENERAL_DETAILS_AUTOID", param);
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

        public DataTable RetrieveAll_General_Details_DataTable()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@JOBID", JOBID);
                param[1] = new SqlParameter("@JOBNO", JOBNO);
                param[2] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
                param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
                param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
                param[5] = new SqlParameter("@name", Ename);
                param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);

                param[12] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
                param[13] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);

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
                    Connection.Get_Dataset("SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT", param);
                    result = Convert.ToInt32(param[7].Value.ToString());
                }
                else if (Ename == "select_Id")
                {
                    ds = Connection.Get_Dataset("SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT", param);
                   
                    string err = param[8].Value.ToString();
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
                else
                {
                    ds = Connection.Get_Dataset("SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT", param);
                    
                    string err = param[8].Value.ToString();
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
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
            return ds.Tables[0];
        }

        public DataSet RetrieveAll_General_Details()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[20];
                param[0] = new SqlParameter("@JOBID", JOBID);
                param[1] = new SqlParameter("@JOBNO", JOBNO);
                param[2] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
                param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
                param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
                param[5] = new SqlParameter("@name", Ename);
                param[6] = new SqlParameter("@Working_Period", WORKING_PERIOD);
                param[12] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
                param[13] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);
                param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                param[7].Direction = ParameterDirection.Output;
                param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                param[8].Direction = ParameterDirection.Output;
                param[9] = new SqlParameter("@startRowIndex", startRowIndex);
                param[10] = new SqlParameter("@maximumRows", maximumRows);
                param[11] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
                param[11].Direction = ParameterDirection.Output;

                if (Ename == "delete" || Ename == "delete_SB_ENTRY")
                {
                    Connection.Get_Dataset("SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT", param);
                    result = Convert.ToInt32(param[7].Value.ToString());
                }
                else if (Ename == "select_Id" || Ename == "select_Id_Submission" || Ename == "SB_Entry")
                {
                    ds = Connection.Get_Dataset("SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT", param);
                    
                    string err = param[8].Value.ToString();
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
                else
                {
                    ds = Connection.Get_Dataset("SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT", param);

                    string err = param[8].Value.ToString();
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
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
            return ds;
        }

        public int Generate_Duplicate_Job()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[25];
                param[0] = new SqlParameter("@OLD_JOBNO", OLD_JOBNO);
                param[1] = new SqlParameter("@CURRENT_JOBNO", JOBNO);
                param[2] = new SqlParameter("@BRANCHCODE", BRANCH_CODE);
                param[3] = new SqlParameter("@Working_Period", WORKING_PERIOD);
                param[4] = new SqlParameter("@USERID", USER_ID);
                param[5] = new SqlParameter("@name", Ename);
                param[6] = new SqlParameter("@Company_license", Connection.Company_License());
                param[7] = new SqlParameter("@Current_Branch", Connection.Current_Branch());
                param[8] = new SqlParameter("@DB_Name", DBS_Name);
                param[9] = new SqlParameter("@Current_Working_Period", Current_Working_Period);
                param[10] = new SqlParameter("@Job_Prefix", JOB_PREFIX);
                param[11] = new SqlParameter("@Job_Suffix", JOB_SUFFIX);
               
                param[12] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                param[12].Direction = ParameterDirection.Output;
                param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                param[13].Direction = ParameterDirection.Output;

                if (Ename == "Duplicate_Job")
                {
                    if (DB_Type == "Same")
                    {
                        Connection.Get_Dataset("GENERATE_EXPORT_DUPLICATE_JOB", param);
                    }
                    else if (DB_Type == "Diff")
                    {
                       Connection.Get_Dataset("GENERATE_EXPORT_DUPLICATE_JOB_WORK_PERIOD", param);
                    }
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
            return result;
        }

        public DataSet RetrieveAll_ExpGeneral_Details_datatablefrmDelJobs()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[20];
                param[0] = new SqlParameter("@JOBID", JOBID);
                param[1] = new SqlParameter("@JOBNO", JOBNO);
                param[2] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
                param[3] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
                param[4] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
                param[5] = new SqlParameter("@name", Ename);
                param[6] = new SqlParameter("@Working_Period", WORKING_PERIOD);
                param[7] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
                param[8] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);

                param[9] = new SqlParameter("@USER_ID", Connection.Current_User());

                ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT_DelBck", param);
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
            return ds;
        }

        public DataSet Exp_Job_Logs_All_Details(string Jobno, string Invslno, string Item_slno, string Pagename, string Status, string Ename)
        {
            DataSet ds1 = new DataSet();
            try
            {
                SqlParameter[] param = new SqlParameter[20];
                param[0] = new SqlParameter("@Jobno", Jobno);
                param[1] = new SqlParameter("@Invoice_slno", Invslno);
                param[2] = new SqlParameter("@Item_slno", Item_slno);
                param[3] = new SqlParameter("@PageName", Pagename);
                param[4] = new SqlParameter("@Status", Status);
                param[5] = new SqlParameter("@UserID", Connection.Current_User());
                param[6] = new SqlParameter("@Branch", Connection.Current_Branch());
                param[7] = new SqlParameter("@Ename", Ename);

                param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
                param[9].Direction = ParameterDirection.Output;
                param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
                param[10].Direction = ParameterDirection.Output;

                ds1 = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_EXP_JOB_LOGS_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[9].Value.ToString());
                string err = param[10].Value.ToString();
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
            return ds1;
        }

    }




//public DataSet FREIGHT_IMP_EXP_Job_Load()
//    {
//        try
//        { 
//            SqlParameter[] param = new SqlParameter[20];
//            param[1] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
//            param[2] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);
//            param[3] = new SqlParameter("@IMPORTER_NAME", "");
//            param[4] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
//            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
//            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
//            param[7] = new SqlParameter("@GROUP_ID", HttpContext.Current.Session["GroupID"].ToString());
//            param[8] = new SqlParameter("@flag", @flag);
//            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db_FRT"].ToString(), CommandType.StoredProcedure, "From_CHA_FRT_JobLoad", param);
//        }
//        catch (Exception ex)
//        {
//            Connection.Error_Msg(ex.Message);
//        }
//        return ds;
//    }

//}
