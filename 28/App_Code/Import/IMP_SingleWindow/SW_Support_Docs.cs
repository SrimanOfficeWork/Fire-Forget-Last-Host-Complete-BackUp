using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

/// <summary>
/// Summary description for SW_Support_Docs
/// </summary>
public class SW_Support_Docs
{
    public int result, UPDATE_ID = 0;
    //IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    DataTable dt = new DataTable();

    public int IMP_SW_Supportingdoc_Details_Insert_Update(UserBO objUserBL)
    {

        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@SW_ID", objUserBL.SW_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@DECLARATION_TYPE", objUserBL.DECLARATION_TYPE);
            param[5] = new SqlParameter("@IMAGE_REF_NUMBER", objUserBL.IMAGE_REF_NUMBER);
            param[6] = new SqlParameter("@DOC_TYPE_CODE", objUserBL.Doc_Type_Code);
            param[7] = new SqlParameter("@DOC_ISSUING_PARTY_CODE", objUserBL.Doc_Issuing_Party_Code);
            param[8] = new SqlParameter("@DOC_ISSUING_PARTY_NAME", objUserBL.DOC_ISSUING_PARTY_NAME);
            param[9] = new SqlParameter("@DOC_ISSUING_PARTY_NAME_ADD1", objUserBL.Doc_Issuing_Party_Name_Add1);
            param[10] = new SqlParameter("@DOC_ISSUING_PARTY_NAME_ADD2", objUserBL.Doc_Issuing_Party_Name_Add2);
            param[11] = new SqlParameter("@DOC_ISSUING_PARTY_CITY", objUserBL.Doc_Issuing_Party_Name_City);
            param[12] = new SqlParameter("@DOC_ISSUING_PARTY_PIN", objUserBL.Doc_Issuing_Party_Name_Pin);
            param[13] = new SqlParameter("@DOC_REF_NUMBER", objUserBL.Doc_Reference_No);
            param[14] = new SqlParameter("@PLACE_OF_ISSUE", objUserBL.Place_of_Issue);
            //param[15] = new SqlParameter("@DOC_ISSUE_DATE", Connection.DATE_FORMAT(objUserBL.Doc_Issue_Date == null ? "01/01/1900" : objUserBL.Doc_Issue_Date));
            //param[16] = new SqlParameter("@DOC_EXPIRY_DATE", Connection.DATE_FORMAT(objUserBL.Doc_Expiry_Date == null ? "01/01/1900" : objUserBL.Doc_Expiry_Date));

            param[15] = new SqlParameter("@DOC_ISSUE_DATE", DateTime.Parse(objUserBL.Doc_Issue_Date == null ? "01/01/1900" : objUserBL.Doc_Issue_Date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[16] = new SqlParameter("@DOC_EXPIRY_DATE", DateTime.Parse(objUserBL.Doc_Expiry_Date == null ? "01/01/1900" : objUserBL.Doc_Expiry_Date, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[17] = new SqlParameter("@BENEFICIARY_PARTY_CODE", objUserBL.Doc_Beneficiary_Party_Code);
            param[18] = new SqlParameter("@BENEFICIARY_PARTY_NAME", objUserBL.BENEFICIARY_PARTY_NAME);
            param[19] = new SqlParameter("@BENEFICIARY_PARTY_ADDRESS1", objUserBL.Doc_Beneficiary_Party_Name_Add1);
            param[20] = new SqlParameter("@BENEFICIARY_PARTY_ADDRESS2", objUserBL.Doc_Beneficiary_Party_Name_Add2);

            param[21] = new SqlParameter("@BENEFICIARY_PARTY_CITY", objUserBL.Doc_Beneficiary_Party_Name_City);
            param[22] = new SqlParameter("@BENEFICIARY_PARTY_PIN", objUserBL.Doc_Beneficiary_Party_Name_Pin);
            param[23] = new SqlParameter("@FILE_TYPE", objUserBL.File_Type);
            param[34] = new SqlParameter("@SELECT_TYPE", objUserBL.SELECT_TYPE);
            param[35] = new SqlParameter("@ICEGATE_ID", objUserBL.ICEGATE_ID);

            param[36] = new SqlParameter("@AMENDMENT_TYPE", objUserBL.AMENDMENT_TYPE);
            param[37] = new SqlParameter("@AMENDMENT_STATUS", objUserBL.AMENDMENT_STATUS);
            param[38] = new SqlParameter("@ICEGATE_DOC_FILE_NAME", objUserBL.ICEGATE_DOC_FILE_NAME);


            param[24] = new SqlParameter("@USER_ID", Connection.Current_User());
          
            param[25] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[26] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[27] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[28] = new SqlParameter("@Mflag", objUserBL.flag);

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
                Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_SUPPORTING_DOC_INS_UPD", param);
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
            param[6] = new SqlParameter("@xmlString", objUserBL.Xml_A);

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

    //public DataSet Get_SW_SupportingDocs(UserBO objUserBL)
    //{
    //    try
    //    {
    //        SqlParameter[] param = new SqlParameter[12];
    //        param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
    //        param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
    //        param[2] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
    //        param[9] = new SqlParameter("@DOC_REF_NUMBER", objUserBL.DOC_REF_NUMBER);
    //        param[10] = new SqlParameter("@IMAGE_REF_NUMBER", objUserBL.IMAGE_REF_NUMBER);
    //        param[3] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
    //        param[4] = new SqlParameter("@Mflag", objUserBL.Ename);
    //        param[5] = new SqlParameter("@DELETE_ID", objUserBL.DELETE_ID);
    //        param[6] = new SqlParameter("@xmlString", objUserBL.Xml_A);

    //        param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
    //        param[7].Direction = ParameterDirection.Output;

    //        param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
    //        param[8].Direction = ParameterDirection.Output;


    //        ds = Connection.Get_Dataset("IMP_ITEM_SINGLEWINDOW_SELECT", param);
    //        result = Convert.ToInt32(param[8].Value.ToString());
    //    }
    //    catch (Exception ex)
    //    {
    //        Connection.Error_Msg(ex.Message);
    //    }
    //    return ds;
   
       
    //}


   

    public DataSet SW_SUP_DOCS_FTA_COO_ITEMS_COPY(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[1] = new SqlParameter("@InvoiceSlno", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ItemSlno", objUserBL.ITEM_SLNO);
            param[3] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@flag", objUserBL.Ename);
            param[5] = new SqlParameter("@IRN_No", objUserBL.IMAGE_REF_NUMBER);
           
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_SW_SUP_DOCS_FTA_COO_ITEMS_COPY", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Imp_Sup_Doc_Xl_Upload(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@SW_ID", objUserBL.SW_STMT_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@SLNO", objUserBL.SLNO);
            param[39] = new SqlParameter("@DECLARATION_TYPE", objUserBL.DECLARATION_TYPE);
            param[5] = new SqlParameter("@IMAGE_REF_NUMBER", objUserBL.IMAGE_REF_NUMBER);
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
            param[40] = new SqlParameter("@SELECT_TYPE", objUserBL.SELECT_TYPE);
            param[25] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[27] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[28] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[29] = new SqlParameter("@Mflag", objUserBL.flag);

            param[35] = new SqlParameter("@DOC_ISSUING_PARTY_NAME", objUserBL.DOC_ISSUING_PARTY_NAME);
            param[36] = new SqlParameter("@BENEFICIARY_PARTY_NAME", objUserBL.BENEFICIARY_PARTY_NAME);
            param[37] = new SqlParameter("@ICEGATE_ID", objUserBL.ICEGATE_ID);
            param[38] = new SqlParameter("@ICEGATE_DOC_FILE_NAME", objUserBL.ICEGATE_ID);

            param[30] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[30].Direction = ParameterDirection.Output;

            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;

            param[33] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[33].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "autoid" || (objUserBL.flag == "Check_Avail") || (objUserBL.flag == "Excel_Avail") || (objUserBL.flag == "Delete_Excel"))
            {
                ds = Connection.Get_Dataset("IMP_SUP_DOC_XL_UPLOAD", param);
                string s = param[31].Value.ToString();
                result = Convert.ToInt32(param[30].Value.ToString());
            }
            if (objUserBL.flag == "Data_Check")
            {
                ds = Connection.Get_Dataset("IMP_SUP_DOC_XL_UPLOAD", param);
                string s = param[31].Value.ToString();
                result = Convert.ToInt32(param[30].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet Imp_Sup_Doc_Xl_Upload(UserBO objUserBL, DataTable TEMP1)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@SW_ID", objUserBL.SW_STMT_ID);
            param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[2] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@SLNO", objUserBL.SLNO);

            param[39] = new SqlParameter("@DECLARATION_TYPE", objUserBL.DECLARATION_TYPE);
            param[5] = new SqlParameter("@IMAGE_REF_NUMBER", objUserBL.IMAGE_REF_NUMBER);
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
            param[40] = new SqlParameter("@SELECT_TYPE", objUserBL.SELECT_TYPE);

            param[25] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[26] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[27] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[28] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[29] = new SqlParameter("@Mflag", objUserBL.flag);

            param[35] = new SqlParameter("@DOC_ISSUING_PARTY_NAME", objUserBL.DOC_ISSUING_PARTY_NAME);
            param[36] = new SqlParameter("@BENEFICIARY_PARTY_NAME", objUserBL.BENEFICIARY_PARTY_NAME);
            param[37] = new SqlParameter("@ICEGATE_ID", objUserBL.ICEGATE_ID);

            param[41] = new SqlParameter("@ICEGATE_DOC_FILE_NAME", objUserBL.ICEGATE_DOC_FILE_NAME);
            param[30] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[30].Direction = ParameterDirection.Output;

            param[31] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[31].Direction = ParameterDirection.Output;

            param[33] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[33].Direction = ParameterDirection.Output;



            if (objUserBL.flag == "autoid" || (objUserBL.flag == "Check_Avail"))
            {
                ds = Connection.Get_Dataset("IMP_SUP_DOC_XL_UPLOAD", param);
                result = Convert.ToInt32(param[30].Value.ToString());
            }


            if (objUserBL.flag == "Data_Check" || (objUserBL.flag == "Excel_Avail") || (objUserBL.flag == "Delete_Excel"))
            {
                param[38] = new SqlParameter("@IMP_SUP_DOC_UDT", TEMP1);

                ds = Connection.Get_Dataset("IMP_SUP_DOC_XL_UPLOAD", param);
                string str = param[31].Value.ToString();
                result = Convert.ToInt32(param[30].Value.ToString());

            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet IMP_ITEM_SUPPROTING_DOCUMENTS_INS_UPD_DEL_BULK_SELECT(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[1] = new SqlParameter("@Level", objUserBL.SELECT_TYPE);
            param[2] = new SqlParameter("@InvSlNo", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ItemSlNo", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@IRN", objUserBL.IMAGE_REF_NUMBER);
            param[5] = new SqlParameter("@Doc_typeCode", objUserBL.Doc_Type_Code);
            param[6] = new SqlParameter("@XmlString", objUserBL.Xml_A);

            param[7] = new SqlParameter("@Upd_ImageRef", objUserBL.Upd_ImageRef);
            param[8] = new SqlParameter("@Upd_DoctypeCode", objUserBL.Upd_DoctypeCode);
            param[9] = new SqlParameter("@Upd_Iss_Party", objUserBL.Upd_Iss_Party);
            param[10] = new SqlParameter("@Upd_PlaceOfIssue", objUserBL.Upd_PlaceOfIssue);
            param[11] = new SqlParameter("@Upd_Issuedate", objUserBL.Upd_Issuedate);
            param[12] = new SqlParameter("@Upd_BenParty", objUserBL.Upd_BenParty);
            param[13] = new SqlParameter("@Upd_IcegateID", objUserBL.Upd_IcegateID);


            param[15] = new SqlParameter("@UserId", Connection.Current_User());
            //param[16] = new SqlParameter("@Branch", Connection.Get_Company_Type());
            param[16] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[17] = new SqlParameter("@WorkingPeriod", Connection.WorkingPeriod());
            param[18] = new SqlParameter("@flag", objUserBL.Ename);

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_ITEM_SUPPORTING_DOCS_INS_UPD_DEL_BULK_SELECT", param);
            result = Convert.ToInt32(param[20].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public DataSet IMP_ITEM_SUPPROTING_DOCUMENTS_INS_UPD_DEL_BULK_SELECT_NEW(UserBO objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[20];

            // -----------------------------
            param[0] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[1] = new SqlParameter("@Level", objUserBL.SELECT_TYPE);
            param[2] = new SqlParameter("@InvSlNo", objUserBL.INVOICE_SLNO);
            param[3] = new SqlParameter("@ItemSlNo", objUserBL.ITEM_SLNO);
            param[4] = new SqlParameter("@IRN", objUserBL.IMAGE_REF_NUMBER);
            param[5] = new SqlParameter("@Doc_typeCode", objUserBL.Doc_Type_Code);
            param[6] = new SqlParameter("@XmlString", objUserBL.Xml_A);
            //param[13] = new SqlParameter("@swid", objUserBL.SW_ID);
      
            param[7] = new SqlParameter("@UserId", Connection.Current_User());
            param[8] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[9] = new SqlParameter("@WorkingPeriod", Connection.WorkingPeriod());
            param[10] = new SqlParameter("@flag", objUserBL.Ename);


            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 4000);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@Mstatus", SqlDbType.Int);
            param[12].Direction = ParameterDirection.Output;

       
            ds = Connection.Get_Dataset(
                    "IMP_ITEM_SUPPORTING_DOCS_INS_UPD_DEL_BULK_SELECT_NEW",
                    param
                 );

            result = Convert.ToInt32(param[12].Value);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet Get_Job_List()
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[12];

            param[0] = new SqlParameter("@JOBNO", "");
            param[1] = new SqlParameter("@INVOICE_SLNO", "");
            param[2] = new SqlParameter("@ITEM_SLNO", "");
            param[9] = new SqlParameter("@DOC_REF_NUMBER", "");
            param[10] = new SqlParameter("@IMAGE_REF_NUMBER", "");
            param[3] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Mflag", "select_JOB_List");
            param[5] = new SqlParameter("@DELETE_ID", "");
            param[6] = new SqlParameter("@xmlString", "");

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_BULK_SUP_DOC_NEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }


    public DataSet Get_SW_SupportingDocs(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[12];

            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO",
          string.IsNullOrEmpty(objUserBL.INVOICE_SLNO) ? "" : objUserBL.INVOICE_SLNO);

            param[2] = new SqlParameter("@ITEM_SLNO",
                string.IsNullOrEmpty(objUserBL.ITEM_SLNO) ? "" : objUserBL.ITEM_SLNO);

            param[3] = new SqlParameter("@IMAGE_REF_NUMBER",
                string.IsNullOrEmpty(objUserBL.IMAGE_REF_NUMBER) ? "" : objUserBL.IMAGE_REF_NUMBER);

            param[4] = new SqlParameter("@DOC_REF_NUMBER", "");

            param[5] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[7] = new SqlParameter("@DELETE_ID", objUserBL.DELETE_ID);
            param[8] = new SqlParameter("@xmlString", objUserBL.Xml_A);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_BULK_SUP_DOC_NEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet Supp_Doc_Item_Doc_Ref_Select(UserBO objUserBL)
   {
        try
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[9] = new SqlParameter("@DOC_REF_NUMBER", objUserBL.DOC_REF_NUMBER);
            param[10] = new SqlParameter("@IMAGE_REF_NUMBER", objUserBL.IMAGE_REF_NUMBER);
            param[3] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[5] = new SqlParameter("@DELETE_ID", objUserBL.DELETE_ID);
            param[6] = new SqlParameter("@xmlString", objUserBL.Xml_A);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;


            ds = Connection.Get_Dataset("IMP_BULK_SUP_DOC_NEW", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public DataSet Supp_Doc_IRN_Ref_Select(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[9] = new SqlParameter("@DOC_REF_NUMBER", objUserBL.DOC_REF_NUMBER);
            param[10] = new SqlParameter("@IMAGE_REF_NUMBER", objUserBL.IMAGE_REF_NUMBER);
            param[3] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[5] = new SqlParameter("@DELETE_ID", objUserBL.DELETE_ID);
            param[6] = new SqlParameter("@xmlString", objUserBL.Xml_A);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;


            ds = Connection.Get_Dataset("IMP_BULK_SUP_DOC_NEW", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Supp_Doc_Select(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", objUserBL.ITEM_SLNO);
            param[9] = new SqlParameter("@DOC_REF_NUMBER", objUserBL.DOC_REF_NUMBER);
            param[10] = new SqlParameter("@IMAGE_REF_NUMBER", objUserBL.IMAGE_REF_NUMBER);
            param[3] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Mflag", objUserBL.Ename);
            param[5] = new SqlParameter("@DELETE_ID", objUserBL.DELETE_ID);
            param[6] = new SqlParameter("@xmlString", objUserBL.Xml_A);

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000)
            {
                Direction = ParameterDirection.Output
            };

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000)
            {
                Direction = ParameterDirection.Output
            };

            ds = Connection.Get_Dataset("IMP_BULK_SUP_DOC_NEW", param);
            result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet Sup_Docs_Client_based_AutoInsert(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@Benificiary_Name", objUserBL.BENEFICIARY_PARTY_NAME);
            param[3] = new SqlParameter("@UserID", Connection.Current_User());
            param[4] = new SqlParameter("@flag", objUserBL.Ename);
            param[5] = new SqlParameter("@WorkingPeriod", Connection.WorkingPeriod());
            param[6] = new SqlParameter("@Branch_Common", Connection.Current_Branch());

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@Mstatus", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_SUP_DOCS_CLIENT_BASED_AUTO_INSERT", param);
           // result = Convert.ToInt32(param[8].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}