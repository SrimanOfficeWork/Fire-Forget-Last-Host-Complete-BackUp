using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class IMP_SingleWindow_2016
{
    public int result, UPDATE_ID = 0;

    private string _SW_ID, _JOBNO, _INVOICE_SLNO, _ITEM_SLNO, _INFO_TYPE, _INFO_QUALIFIER, _INFO_CODE, _INFO_TEXT, _INFO_MSR, _INFO_UQC,

    _CONSTITUENT_SRNO, _CONSTITUENT_ELEMENT_NAME, _CONSTITUENT_ELEMENT_CODE, _CONSTITUENT_PERCENTAGE, _CONSTITUENT_YIELD_PERCENTAGE, _ACTIVE_INGREDIENT,

    _PRODUCTION_BATCH_IDENTIFIER, _PRODUCTION_BATCH_QUANTITY, _UNIT_QTY_CODE, _DATE_OF_MANUFACTURING, _DATE_OF_EXPIRY, _BEST_BEFORE,

    _CONTROL_TYPE_CODE, _CONTROL_LOCATION, _CONTROL_START_DATE, _CONTROL_END_DATE, _CONTROL_RESULT_CODE, _CONTROL_RESULT_TEXT,

    _STMT_DECLARATION_TYPE, _STMT_DECLARATION_NUMBER, _STMT_DECLARATION_DATE, _STMT_TYPE, _STMT_CODE, _STMT_TEXT, _SUP_DECLARATION_NUMBER,
    _SUP_DECLARATION_DATE, _SUP_DECLARATION_TYPE, _UNIQUE_DOC_NUMBER, _DOC_TYPE_CODE, _DOC_ISSUING_PARTY_CODE, _DOC_ISSUING_PARTY_NAME_ADD1,
_DOC_ISSUING_PARTY_NAME_ADD2, _DOC_ISSUING_PARTY_CITY, _DOC_ISSUING_PARTY_PIN, _DOC_REF_NUMBER, _PLACE_OF_ISSUE, _DOC_ISSUE_DATE, _DOC_EXPIRY_DATE,
_BENEFICIARY_PARTY_CODE, _BENEFICIARY_PARTY_ADDRESS1, _BENEFICIARY_PARTY_ADDRESS2, _BENEFICIARY_PARTY_CITY, _BENEFICIARY_PARTY_PIN,
_FILE_TYPE, _BRANCH_CODE, _WORKING_PERIOD, _Ename, _BRANCH_COMMON, _NOC_APPLICABLE, _USER_ID ,_DEPARTMENT,_I_U_TYPE,_DELETE_ID;


    public string SW_ID { get { return _SW_ID; } set { _SW_ID = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string INFO_TYPE { get { return _INFO_TYPE; } set { _INFO_TYPE = value; } }
    public string INFO_QUALIFIER { get { return _INFO_QUALIFIER; } set { _INFO_QUALIFIER = value; } }
    public string INFO_CODE { get { return _INFO_CODE; } set { _INFO_CODE = value; } }
    public string INFO_TEXT { get { return _INFO_TEXT; } set { _INFO_TEXT = value; } }
    public string INFO_MSR { get { return _INFO_MSR; } set { _INFO_MSR = value; } }
    public string INFO_UQC { get { return _INFO_UQC; } set { _INFO_UQC = value; } }

    public string CONSTITUENT_SRNO { get { return _CONSTITUENT_SRNO; } set { _CONSTITUENT_SRNO = value; } }
    public string CONSTITUENT_ELEMENT_NAME { get { return _CONSTITUENT_ELEMENT_NAME; } set { _CONSTITUENT_ELEMENT_NAME = value; } }
    public string CONSTITUENT_ELEMENT_CODE { get { return _CONSTITUENT_ELEMENT_CODE; } set { _CONSTITUENT_ELEMENT_CODE = value; } }
    public string CONSTITUENT_PERCENTAGE { get { return _CONSTITUENT_PERCENTAGE; } set { _CONSTITUENT_PERCENTAGE = value; } }


    public string CONSTITUENT_YIELD_PERCENTAGE { get { return _CONSTITUENT_YIELD_PERCENTAGE; } set { _CONSTITUENT_YIELD_PERCENTAGE = value; } }
    public string ACTIVE_INGREDIENT { get { return _ACTIVE_INGREDIENT; } set { _ACTIVE_INGREDIENT = value; } }
    public string PRODUCTION_BATCH_IDENTIFIER { get { return _PRODUCTION_BATCH_IDENTIFIER; } set { _PRODUCTION_BATCH_IDENTIFIER = value; } }
    public string PRODUCTION_BATCH_QUANTITY { get { return _PRODUCTION_BATCH_QUANTITY; } set { _PRODUCTION_BATCH_QUANTITY = value; } }
    public string UNIT_QTY_CODE { get { return _UNIT_QTY_CODE; } set { _UNIT_QTY_CODE = value; } }
    public string DATE_OF_MANUFACTURING { get { return _DATE_OF_MANUFACTURING; } set { _DATE_OF_MANUFACTURING = value; } }
    public string DATE_OF_EXPIRY { get { return _DATE_OF_EXPIRY; } set { _DATE_OF_EXPIRY = value; } }
    public string BEST_BEFORE { get { return _BEST_BEFORE; } set { _BEST_BEFORE = value; } }

    public string CONTROL_TYPE_CODE { get { return _CONTROL_TYPE_CODE; } set { _CONTROL_TYPE_CODE = value; } }
    public string CONTROL_LOCATION { get { return _CONTROL_LOCATION; } set { _CONTROL_LOCATION = value; } }
    public string CONTROL_START_DATE { get { return _CONTROL_START_DATE; } set { _CONTROL_START_DATE = value; } }
    public string CONTROL_END_DATE { get { return _CONTROL_END_DATE; } set { _CONTROL_END_DATE = value; } }
    public string CONTROL_RESULT_CODE { get { return _CONTROL_RESULT_CODE; } set { _CONTROL_RESULT_CODE = value; } }
    public string CONTROL_RESULT_TEXT { get { return _CONTROL_RESULT_TEXT; } set { _CONTROL_RESULT_TEXT = value; } }
    public string STMT_DECLARATION_TYPE { get { return _STMT_DECLARATION_TYPE; } set { _STMT_DECLARATION_TYPE = value; } }
    public string STMT_DECLARATION_NUMBER { get { return _STMT_DECLARATION_NUMBER; } set { _STMT_DECLARATION_NUMBER = value; } }
    public string STMT_DECLARATION_DATE { get { return _STMT_DECLARATION_DATE; } set { _STMT_DECLARATION_DATE = value; } }
    public string STMT_TYPE { get { return _STMT_TYPE; } set { _STMT_TYPE = value; } }
    public string STMT_CODE { get { return _STMT_CODE; } set { _STMT_CODE = value; } }
    public string STMT_TEXT { get { return _STMT_TEXT; } set { _STMT_TEXT = value; } }
    public string SUP_DECLARATION_NUMBER { get { return _SUP_DECLARATION_NUMBER; } set { _SUP_DECLARATION_NUMBER = value; } }
    public string SUP_DECLARATION_DATE { get { return _SUP_DECLARATION_DATE; } set { _SUP_DECLARATION_DATE = value; } }
    public string SUP_DECLARATION_TYPE { get { return _SUP_DECLARATION_TYPE; } set { _SUP_DECLARATION_TYPE = value; } }
    public string UNIQUE_DOC_NUMBER { get { return _UNIQUE_DOC_NUMBER; } set { _UNIQUE_DOC_NUMBER = value; } }
    public string DOC_TYPE_CODE { get { return _DOC_TYPE_CODE; } set { _DOC_TYPE_CODE = value; } }
    public string DOC_ISSUING_PARTY_CODE { get { return _DOC_ISSUING_PARTY_CODE; } set { _DOC_ISSUING_PARTY_CODE = value; } }

    public string DOC_ISSUING_PARTY_NAME_ADD1 { get { return _DOC_ISSUING_PARTY_NAME_ADD1; } set { _DOC_ISSUING_PARTY_NAME_ADD1 = value; } }
    public string DOC_ISSUING_PARTY_NAME_ADD2 { get { return _DOC_ISSUING_PARTY_NAME_ADD2; } set { _DOC_ISSUING_PARTY_NAME_ADD2 = value; } }

    public string DOC_ISSUING_PARTY_CITY { get { return _DOC_ISSUING_PARTY_CITY; } set { _DOC_ISSUING_PARTY_CITY = value; } }
    public string DOC_ISSUING_PARTY_PIN { get { return _DOC_ISSUING_PARTY_PIN; } set { _DOC_ISSUING_PARTY_PIN = value; } }
    public string DOC_REF_NUMBER { get { return _DOC_REF_NUMBER; } set { _DOC_REF_NUMBER = value; } }
    public string PLACE_OF_ISSUE { get { return _PLACE_OF_ISSUE; } set { _PLACE_OF_ISSUE = value; } }
    public string DOC_ISSUE_DATE { get { return _DOC_ISSUE_DATE; } set { _DOC_ISSUE_DATE = value; } }
    public string DOC_EXPIRY_DATE { get { return _DOC_EXPIRY_DATE; } set { _DOC_EXPIRY_DATE = value; } }

    public string BENEFICIARY_PARTY_CODE { get { return _BENEFICIARY_PARTY_CODE; } set { _BENEFICIARY_PARTY_CODE = value; } }

    public string BENEFICIARY_PARTY_ADDRESS1 { get { return _BENEFICIARY_PARTY_ADDRESS1; } set { _BENEFICIARY_PARTY_ADDRESS1 = value; } }
    public string BENEFICIARY_PARTY_ADDRESS2 { get { return _BENEFICIARY_PARTY_ADDRESS2; } set { _BENEFICIARY_PARTY_ADDRESS2 = value; } }

    public string BENEFICIARY_PARTY_CITY { get { return _BENEFICIARY_PARTY_CITY; } set { _BENEFICIARY_PARTY_CITY = value; } }
    public string BENEFICIARY_PARTY_PIN { get { return _BENEFICIARY_PARTY_PIN; } set { _BENEFICIARY_PARTY_PIN = value; } }
    public string FILE_TYPE { get { return _FILE_TYPE; } set { _FILE_TYPE = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }

    public string BRANCH_COMMON { get { return _BRANCH_COMMON; } set { _BRANCH_COMMON = value; } }
    public string NOC_APPLICABLE { get { return _NOC_APPLICABLE; } set { _NOC_APPLICABLE = value; } }

    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }

    public string DEPARTMENT { get { return _DEPARTMENT; } set { _DEPARTMENT = value; } }
    public string I_U_TYPE { get { return _I_U_TYPE; } set { _I_U_TYPE = value; } }
    public string DELETE_ID { get { return _DELETE_ID; } set { _DELETE_ID = value; } }

    public int SW_INFOTYPE_Details_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_INFO_TYPE_ID", SW_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

            param[4] = new SqlParameter("@INFO_TYPE", INFO_TYPE);
            param[5] = new SqlParameter("@INFO_QUALIFIER", INFO_QUALIFIER);
            param[6] = new SqlParameter("@INFO_CODE", INFO_CODE);
            param[7] = new SqlParameter("@INFO_TEXT", INFO_TEXT);
            param[8] = new SqlParameter("@INFO_MSR", INFO_MSR);
            param[9] = new SqlParameter("@INFO_UQC", INFO_UQC);
            param[10] = new SqlParameter("@USER_ID", USER_ID);
            param[18] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[20] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[21] = new SqlParameter("@DEPARTMENT", DEPARTMENT);
            param[22] = new SqlParameter("@I_U_TYPE", I_U_TYPE);


            param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[14] = new SqlParameter("@Mflag", Ename);

            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_INFOTYPE_INS_UPD", param);
            result = Convert.ToInt32(param[15].Value.ToString());

            if (Ename == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[17].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    /*
    public int SW_CONSTITUENT_Details_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_CONST_ID", SW_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
           
            param[4] = new SqlParameter("@CONSTITUENT_SRNO", CONSTITUENT_SRNO);
            param[5] = new SqlParameter("@CONSTITUENT_ELEMENT_NAME", CONSTITUENT_ELEMENT_NAME);
            param[6] = new SqlParameter("@CONSTITUENT_ELEMENT_CODE", CONSTITUENT_ELEMENT_CODE);
            param[7] = new SqlParameter("@CONSTITUENT_PERCENTAGE", CONSTITUENT_PERCENTAGE);
            param[8] = new SqlParameter("@CONSTITUENT_YIELD_PERCENTAGE", CONSTITUENT_YIELD_PERCENTAGE);
            param[9] = new SqlParameter("@ACTIVE_INGREDIENT", ACTIVE_INGREDIENT);

            param[10] = new SqlParameter("@USER_ID", USER_ID);
            param[11] = new SqlParameter("@DATE_TIME", DATE_TIME);
            param[12] = new SqlParameter("@STATUS", STATUS);
            param[18] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[19] = new SqlParameter("@YEAR", YEAR);
            param[20] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[21] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
            param[22] = new SqlParameter("@MODIFIEDON", MODIFIEDON);

            param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[14] = new SqlParameter("@Mflag", Ename);

            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_CONSTITUENT_INS_UPD", param);
            result = Convert.ToInt32(param[15].Value.ToString());

            if (Ename == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[17].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public int SW_PRODUCTION_Details_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_PROD_ID", SW_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

            param[4] = new SqlParameter("@PRODUCTION_BATCH_IDENTIFIER", PRODUCTION_BATCH_IDENTIFIER);
            param[5] = new SqlParameter("@PRODUCTION_BATCH_QUANTITY", PRODUCTION_BATCH_QUANTITY);
            param[6] = new SqlParameter("@UNIT_QTY_CODE", UNIT_QTY_CODE);
           
            param[7] = new SqlParameter("@DATE_OF_MANUFACTURING", Connection.DATE_FORMAT(DATE_OF_MANUFACTURING == null ? "01/01/1900" : DATE_OF_MANUFACTURING));
            param[8] = new SqlParameter("@DATE_OF_EXPIRY", Connection.DATE_FORMAT(DATE_OF_EXPIRY == null ? "01/01/1900" : DATE_OF_EXPIRY));

            param[9] = new SqlParameter("@BEST_BEFORE", Connection.DATE_FORMAT(BEST_BEFORE == null ? "01/01/1900" : BEST_BEFORE));

            param[10] = new SqlParameter("@RESIDUAL_SHELF_LIFE_DAYS", RESIDUAL_SHELF_LIFE_DAYS);
            param[11] = new SqlParameter("@TOTAL_SHELF_LIFE_DAYS", TOTAL_SHELF_LIFE_DAYS);
            param[12] = new SqlParameter("@RESIDUAL_SHELF_PERCENT", RESIDUAL_SHELF_PERCENT);

            param[13] = new SqlParameter("@USER_ID", USER_ID);
            param[14] = new SqlParameter("@DATE_TIME", DATE_TIME);
            param[15] = new SqlParameter("@STATUS", STATUS);
            param[16] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[17] = new SqlParameter("@YEAR", YEAR);
            param[18] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[19] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
            param[20] = new SqlParameter("@MODIFIEDON", MODIFIEDON);
            param[21] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[22] = new SqlParameter("@Mflag", Ename);

            param[23] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[23].Direction = ParameterDirection.Output;

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;

            param[25] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[25].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_PRODUCTION_INS_UPD", param);
            result = Convert.ToInt32(param[23].Value.ToString());

            if (Ename == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[25].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public int SW_CONTROL_Details_Insert_Update()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@SW_CONTROL_ID", SW_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);

            param[4] = new SqlParameter("@CONTROL_TYPE_CODE", CONTROL_TYPE_CODE);
            param[5] = new SqlParameter("@CONTROL_LOCATION", CONTROL_LOCATION);
            param[6] = new SqlParameter("@CONTROL_START_DATE", Connection.DATE_FORMAT(CONTROL_START_DATE == null ? "01/01/1900" : CONTROL_START_DATE));
            param[7] = new SqlParameter("@CONTROL_END_DATE", Connection.DATE_FORMAT(CONTROL_END_DATE == null ? "01/01/1900" : CONTROL_END_DATE));

            param[8] = new SqlParameter("@CONTROL_RESULT_CODE", CONTROL_RESULT_CODE);
            param[9] = new SqlParameter("@CONTROL_RESULT_TEXT", CONTROL_RESULT_TEXT);

            param[10] = new SqlParameter("@USER_ID", USER_ID);
            param[11] = new SqlParameter("@DATE_TIME", DATE_TIME);
            param[12] = new SqlParameter("@STATUS", STATUS);
            param[18] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[19] = new SqlParameter("@YEAR", YEAR);
            param[20] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[21] = new SqlParameter("@MODIFIEDBY", MODIFIEDBY);
            param[22] = new SqlParameter("@MODIFIEDON", MODIFIEDON);

            param[13] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[14] = new SqlParameter("@Mflag", Ename);

            param[15] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[17].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_CONTROL_INS_UPD", param);
            result = Convert.ToInt32(param[15].Value.ToString());

            if (Ename == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[17].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    */
    DataSet ds = new DataSet();
    public DataSet SingleWindow_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[3] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[4] = new SqlParameter("@Mflag", Ename);
            param[5] = new SqlParameter("@DELETE_ID", DELETE_ID);
            
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    DataSet dss = new DataSet();
    public DataSet SingleWindow_Check()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[3] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);
            param[4] = new SqlParameter("@Mflag", Ename);
            param[5] = new SqlParameter("@DELETE_ID", DELETE_ID);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            dss = Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_BULK_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return dss;
    }
/*
    public int SW_Statement()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[100];

            param[0] = new SqlParameter("@SW_STMT_ID", SW_STMT_ID);
            param[1] = new SqlParameter("@JOBNO", JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[4] = new SqlParameter("@USER_ID", USER_ID);

            param[28] = new SqlParameter("@STMT_DECLARATION_TYPE", STMT_DECLARATION_TYPE);
            param[29] = new SqlParameter("@STMT_DECLARATION_NUMBER", STMT_DECLARATION_NUMBER);
            param[30] = new SqlParameter("@STMT_DECLARATION_DATE", Connection.DATE_FORMAT(STMT_DECLARATION_DATE == null ? "01/01/1900" : STMT_DECLARATION_DATE));

            param[31] = new SqlParameter("@STMT_TYPE", STMT_TYPE);
            param[32] = new SqlParameter("@STMT_CODE", STMT_CODE);
            param[33] = new SqlParameter("@STMT_TEXT", STMT_TEXT);
            param[34] = new SqlParameter("@I_U_TYPE", I_U_TYPE);
         
            param[57] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[58] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[59] = new SqlParameter("@Mflag", Ename);
          
            param[61] = new SqlParameter("@BRANCH_COMMON", BRANCH_COMMON);

            param[62] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[62].Direction = ParameterDirection.Output;

            param[63] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[63].Direction = ParameterDirection.Output;

            param[64] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[64].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_STMT_INS_UPD", param);
            result = Convert.ToInt32(param[62].Value.ToString());

            if (Ename == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[64].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    */
}