using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class EXP_Supportingdoc
{
    public int result, UPDATE_ID = 0;

    public int SW_Supportingdoc_Details_Insert_Update(UserBO objUserBL)
    {

        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@SW_SUP_DOC_ID", objUserBL.SW_STMT_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@SLNO", objUserBL.SLNO);
            param[5] = new SqlParameter("@UNIQUE_DOC_NUMBER", objUserBL.Unique_Document_No);
            param[6] = new SqlParameter("@DOC_TYPE_CODE", objUserBL.Doc_Type_Code);
            param[7] = new SqlParameter("@DOC_ISSUING_PARTY_CODE", objUserBL.Doc_Issuing_Party_Code);
            param[8] = new SqlParameter("@DOC_ISSUING_PARTY_NAME_ADD1", objUserBL.Doc_Issuing_Party_Name_Add1);
            param[21] = new SqlParameter("@DOC_ISSUING_PARTY_NAME_ADD2", objUserBL.Doc_Issuing_Party_Name_Add2);

            param[9] = new SqlParameter("@DOC_ISSUING_PARTY_CITY", objUserBL.Doc_Issuing_Party_Name_City);
            param[10] = new SqlParameter("@DOC_ISSUING_PARTY_PIN", objUserBL.Doc_Issuing_Party_Name_Pin);
            param[11] = new SqlParameter("@DOC_REF_NUMBER", objUserBL.Doc_Reference_No);
            param[12] = new SqlParameter("@PLACE_OF_ISSUE", objUserBL.Place_of_Issue);
            param[13] = new SqlParameter("@DOC_ISSUE_DATE", Connection.DATE_FORMAT(objUserBL.Doc_Issue_Date == null ? "01/01/1900" : objUserBL.Doc_Issue_Date));
            param[14] = new SqlParameter("@DOC_EXPIRY_DATE", Connection.DATE_FORMAT(objUserBL.Doc_Expiry_Date == null ? "01/01/1900" : objUserBL.Doc_Expiry_Date));
            param[15] = new SqlParameter("@BENEFICIARY_PARTY_CODE", objUserBL.Doc_Beneficiary_Party_Code);
            param[16] = new SqlParameter("@BENEFICIARY_PARTY_ADDRESS1", objUserBL.Doc_Beneficiary_Party_Name_Add1);
            param[17] = new SqlParameter("@BENEFICIARY_PARTY_ADDRESS2", objUserBL.Doc_Beneficiary_Party_Name_Add2);

            param[18] = new SqlParameter("@BENEFICIARY_PARTY_CITY", objUserBL.Doc_Beneficiary_Party_Name_City);
            param[19] = new SqlParameter("@BENEFICIARY_PARTY_PIN", objUserBL.Doc_Beneficiary_Party_Name_Pin);
            param[20] = new SqlParameter("@FILE_TYPE", objUserBL.File_Type);

            param[25] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[27] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[28] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[29] = new SqlParameter("@Mflag", objUserBL.flag);

            param[35] = new SqlParameter("@DOC_ISSUING_PARTY_NAME", objUserBL.DOC_ISSUING_PARTY_NAME);
            param[36] = new SqlParameter("@BENEFICIARY_PARTY_NAME", objUserBL.BENEFICIARY_PARTY_NAME);
            param[37] = new SqlParameter("@ICEGATE_ID", objUserBL.ICEGATE_ID);
            param[38] = new SqlParameter("@ICEGATE_DOC_FILE_NAME", objUserBL.ICEGATE_DOC_FILE_NAME);
            param[39] = new SqlParameter("@AMENDMENT_TYPE", objUserBL.AMENDMENT_TYPE);
            param[40] = new SqlParameter("@AMENDMENT_STATUS", objUserBL.AMENDMENT_STATUS);
            param[41] = new SqlParameter("@SELECT_TYPE", objUserBL.SELECT_TYPE);


            param[30] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[30].Direction = ParameterDirection.Output;

            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;

            param[33] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[33].Direction = ParameterDirection.Output;

            if (objUserBL.Ename == "B")
            {
                //Connection.Get_Dataset("EXP_ITEM_SINGLEWINDOW_CONSTITUENT_INS_UPD_BULK", param);
            }
            else
            {
                Connection.Get_Dataset("EXP_ITEM_SINGLEWINDOW_SUPPORTING_DOC_INS_UPD", param);
            }
            result = Convert.ToInt32(param[30].Value.ToString());

            if (objUserBL.flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[33].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    DataSet ds = new DataSet();
    public DataSet SingleWindow_Select(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[3] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[5] = new SqlParameter("@DELETE_ID", objUserBL.DELETE_ID);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXP_ITEM_SINGLEWINDOW_SELECT", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Exp_Sup_Doc_Xl_Upload(UserBO objUserBL, DataTable TEMP1)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@SW_SUP_DOC_ID", objUserBL.SW_STMT_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@SLNO", objUserBL.SLNO);
            param[5] = new SqlParameter("@UNIQUE_DOC_NUMBER", objUserBL.Unique_Document_No);
            param[6] = new SqlParameter("@DOC_TYPE_CODE", objUserBL.Doc_Type_Code);
            param[7] = new SqlParameter("@DOC_ISSUING_PARTY_CODE", objUserBL.Doc_Issuing_Party_Code);
            param[8] = new SqlParameter("@DOC_ISSUING_PARTY_NAME_ADD1", objUserBL.Doc_Issuing_Party_Name_Add1);
            param[21] = new SqlParameter("@DOC_ISSUING_PARTY_NAME_ADD2", objUserBL.Doc_Issuing_Party_Name_Add2);

            param[9] = new SqlParameter("@DOC_ISSUING_PARTY_CITY", objUserBL.Doc_Issuing_Party_Name_City);
            param[10] = new SqlParameter("@DOC_ISSUING_PARTY_PIN", objUserBL.Doc_Issuing_Party_Name_Pin);
            param[11] = new SqlParameter("@DOC_REF_NUMBER", objUserBL.Doc_Reference_No);
            param[12] = new SqlParameter("@PLACE_OF_ISSUE", objUserBL.Place_of_Issue);
            param[13] = new SqlParameter("@DOC_ISSUE_DATE", Connection.DATE_FORMAT(objUserBL.Doc_Issue_Date == null ? "01/01/1900" : objUserBL.Doc_Issue_Date));
            param[14] = new SqlParameter("@DOC_EXPIRY_DATE", Connection.DATE_FORMAT(objUserBL.Doc_Expiry_Date == null ? "01/01/1900" : objUserBL.Doc_Expiry_Date));
            param[15] = new SqlParameter("@BENEFICIARY_PARTY_CODE", objUserBL.Doc_Beneficiary_Party_Code);
            param[16] = new SqlParameter("@BENEFICIARY_PARTY_ADDRESS1", objUserBL.Doc_Beneficiary_Party_Name_Add1);
            param[17] = new SqlParameter("@BENEFICIARY_PARTY_ADDRESS2", objUserBL.Doc_Beneficiary_Party_Name_Add2);

            param[18] = new SqlParameter("@BENEFICIARY_PARTY_CITY", objUserBL.Doc_Beneficiary_Party_Name_City);
            param[19] = new SqlParameter("@BENEFICIARY_PARTY_PIN", objUserBL.Doc_Beneficiary_Party_Name_Pin);
            param[20] = new SqlParameter("@FILE_TYPE", objUserBL.File_Type);

            param[25] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[27] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[28] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[29] = new SqlParameter("@Mflag", objUserBL.flag);

            param[35] = new SqlParameter("@DOC_ISSUING_PARTY_NAME", objUserBL.DOC_ISSUING_PARTY_NAME);
            param[36] = new SqlParameter("@BENEFICIARY_PARTY_NAME", objUserBL.BENEFICIARY_PARTY_NAME);
            param[37] = new SqlParameter("@ICEGATE_ID", objUserBL.ICEGATE_ID);
            param[38] = new SqlParameter("@ICEGATE_DOC_FILE_NAME", objUserBL.ICEGATE_DOC_FILE_NAME);//'@ICEGATE_DOC_FILE_NAME', 
            param[39] = new SqlParameter("@SELECT_TYPE", objUserBL.SELECT_TYPE);


            param[30] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[30].Direction = ParameterDirection.Output;

            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;

            param[33] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[33].Direction = ParameterDirection.Output;



            if (objUserBL.flag == "autoid" || (objUserBL.flag == "Check_Avail") || (objUserBL.flag == "Excel_Avail") || (objUserBL.flag == "Delete_Excel"))
            {
                ds = Connection.Get_Dataset("EXP_SUP_DOC_XL_UPLOAD", param);
                result = Convert.ToInt32(param[30].Value.ToString());
            }


            if (objUserBL.flag == "Data_Check")
            {
                param[40] = new SqlParameter("@EXP_SUP_DOC_UDT", TEMP1);

                ds = Connection.Get_Dataset("EXP_SUP_DOC_XL_UPLOAD", param);
                result = Convert.ToInt32(param[30].Value.ToString());

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Exp_Sup_Doc_Xl_Upload(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@SW_SUP_DOC_ID", objUserBL.SW_STMT_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@SLNO", objUserBL.SLNO);
            param[5] = new SqlParameter("@UNIQUE_DOC_NUMBER", objUserBL.Unique_Document_No);
            param[6] = new SqlParameter("@DOC_TYPE_CODE", objUserBL.Doc_Type_Code);
            param[7] = new SqlParameter("@DOC_ISSUING_PARTY_CODE", objUserBL.Doc_Issuing_Party_Code);
            param[8] = new SqlParameter("@DOC_ISSUING_PARTY_NAME_ADD1", objUserBL.Doc_Issuing_Party_Name_Add1);
            param[21] = new SqlParameter("@DOC_ISSUING_PARTY_NAME_ADD2", objUserBL.Doc_Issuing_Party_Name_Add2);

            param[9] = new SqlParameter("@DOC_ISSUING_PARTY_CITY", objUserBL.Doc_Issuing_Party_Name_City);
            param[10] = new SqlParameter("@DOC_ISSUING_PARTY_PIN", objUserBL.Doc_Issuing_Party_Name_Pin);
            param[11] = new SqlParameter("@DOC_REF_NUMBER", objUserBL.Doc_Reference_No);
            param[12] = new SqlParameter("@PLACE_OF_ISSUE", objUserBL.Place_of_Issue);
            param[13] = new SqlParameter("@DOC_ISSUE_DATE", Connection.DATE_FORMAT(objUserBL.Doc_Issue_Date == null ? "01/01/1900" : objUserBL.Doc_Issue_Date));
            param[14] = new SqlParameter("@DOC_EXPIRY_DATE", Connection.DATE_FORMAT(objUserBL.Doc_Expiry_Date == null ? "01/01/1900" : objUserBL.Doc_Expiry_Date));
            param[15] = new SqlParameter("@BENEFICIARY_PARTY_CODE", objUserBL.Doc_Beneficiary_Party_Code);
            param[16] = new SqlParameter("@BENEFICIARY_PARTY_ADDRESS1", objUserBL.Doc_Beneficiary_Party_Name_Add1);
            param[17] = new SqlParameter("@BENEFICIARY_PARTY_ADDRESS2", objUserBL.Doc_Beneficiary_Party_Name_Add2);

            param[18] = new SqlParameter("@BENEFICIARY_PARTY_CITY", objUserBL.Doc_Beneficiary_Party_Name_City);
            param[19] = new SqlParameter("@BENEFICIARY_PARTY_PIN", objUserBL.Doc_Beneficiary_Party_Name_Pin);
            param[20] = new SqlParameter("@FILE_TYPE", objUserBL.File_Type);

            param[25] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[27] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[28] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[29] = new SqlParameter("@Mflag", objUserBL.flag);

            param[35] = new SqlParameter("@DOC_ISSUING_PARTY_NAME", objUserBL.DOC_ISSUING_PARTY_NAME);
            param[36] = new SqlParameter("@BENEFICIARY_PARTY_NAME", objUserBL.BENEFICIARY_PARTY_NAME);
            param[37] = new SqlParameter("@ICEGATE_ID", objUserBL.ICEGATE_ID);
            param[38] = new SqlParameter("@ICEGATE_DOC_FILE_NAME", objUserBL.ICEGATE_DOC_FILE_NAME);
            param[39] = new SqlParameter("@SELECT_TYPE", objUserBL.SELECT_TYPE);

            param[30] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[30].Direction = ParameterDirection.Output;

            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;

            param[33] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[33].Direction = ParameterDirection.Output;



            if (objUserBL.flag == "autoid" || (objUserBL.flag == "Check_Avail") || (objUserBL.flag == "Excel_Avail") || (objUserBL.flag == "Delete_Excel"))
            {
                ds = Connection.Get_Dataset("EXP_SUP_DOC_XL_UPLOAD", param);
                result = Convert.ToInt32(param[30].Value.ToString());
            }


            if (objUserBL.flag == "Data_Check")
            {


                ds = Connection.Get_Dataset("EXP_SUP_DOC_XL_UPLOAD", param);
                result = Convert.ToInt32(param[30].Value.ToString());

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public DataSet EXP_ITEM_SUPPROTING_DOCUMENTS_INS_UPD_DEL_BULK_SELECT(UserBO objUserBL) // Ajith //
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[1] = new SqlParameter("@Level", objUserBL.SELECT_TYPE);
            param[2] = new SqlParameter("@InvSlNo", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ItemSlNo", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@IRN", objUserBL.UNIQUE_DOC_NUMBER);
            param[5] = new SqlParameter("@Doc_typeCode", objUserBL.Doc_Type_Code);
            param[6] = new SqlParameter("@XmlString", objUserBL.Xml_A);

            param[7] = new SqlParameter("@Upd_ImageRef", objUserBL.Upd_ImageRef);
            param[8] = new SqlParameter("@Upd_DoctypeCode", objUserBL.Upd_DoctypeCode);
            param[9] = new SqlParameter("@Upd_Iss_Party", objUserBL.Upd_Iss_Party);
            param[10] = new SqlParameter("@Upd_PlaceOfIssue", objUserBL.Upd_PlaceOfIssue);
            param[11] = new SqlParameter("@Upd_Issuedate", objUserBL.Upd_Issuedate);
            param[12] = new SqlParameter("@Upd_BenParty", objUserBL.Upd_BenParty);
            param[13] = new SqlParameter("@Upd_IcegateID", objUserBL.Upd_IcegateID);
            param[14] = new SqlParameter("@Upd_Doc_Reference_No", objUserBL.Doc_Reference_No);
            param[15] = new SqlParameter("@Upd_ADDRESS1", objUserBL.ADDRESS1);
            param[16] = new SqlParameter("@Upd_ADDRESS2", objUserBL.ADDRESS2);
            param[17] = new SqlParameter("@Upd_ADDRESS4", objUserBL.ADDRESS4);
            param[18] = new SqlParameter("@Upd_ADDRESS5", objUserBL.ADDRESS5);
            param[19] = new SqlParameter("@Upd_CONSIGNEE_ADD_1", objUserBL.CONSIGNEE_ADD_1);
            param[20] = new SqlParameter("@Upd_CONSIGNEE_ADD_2", objUserBL.CONSIGNEE_ADD_2);
            param[21] = new SqlParameter("@Upd_CONSIGNEE_ADD_3", objUserBL.CONSIGNEE_ADD_3);
            param[22] = new SqlParameter("@Upd_CONSIGNEE_ADD_4", objUserBL.CONSIGNEE_ADD_4);


            param[23] = new SqlParameter("@UserId", Connection.Current_User());
            param[24] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[25] = new SqlParameter("@WorkingPeriod", Connection.WorkingPeriod());
            param[26] = new SqlParameter("@flag", objUserBL.Ename);

            param[27] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[27].Direction = ParameterDirection.Output;

            param[28] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[28].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXP_ITEM_SUPPORTING_DOCS_INS_UPD_DEL_BULK_SELECT", param);
            result = Convert.ToInt32(param[28].Value.ToString());


        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}