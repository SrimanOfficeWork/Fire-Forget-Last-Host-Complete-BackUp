using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

public class Supporting_Document
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0 ;
    Global_variables ObjUBO = new Global_variables();

    public DataSet Select_Sup(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.A2);
            param[3] = new SqlParameter("@Icegate_Id", objUserBL.A3);
            param[4] = new SqlParameter("@flag", objUserBL.A4);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Company_Lic", Connection.Company_License());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("SUPPORTING_DOCUMENTS_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Sup_Doc_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[37];
            param[1] = new SqlParameter("@ID", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.A2);
            param[3] = new SqlParameter("@ICEGATE_ID", objUserBL.A3);
            param[4] = new SqlParameter("@DOC_APPLICABLE_FOR", objUserBL.A4);
            param[5] = new SqlParameter("@IMAGE_REF_NO", objUserBL.A5);
            param[6] = new SqlParameter("@DOC_UPLOAD_DATE_TIME", objUserBL.A6);
            param[7] = new SqlParameter("@DOC_TYPE", objUserBL.A7);
            param[8] = new SqlParameter("@FILE_TYPE", objUserBL.A8);
            param[9] = new SqlParameter("@ICEGATE_FILE_NAME", objUserBL.A9);
            param[10] = new SqlParameter("@ISSUED_AT", objUserBL.A10);
            param[11] = new SqlParameter("@DOC_NAME", objUserBL.A11);
            param[12] = new SqlParameter("@ISSUED_ON", Connection.DATE_FORMAT(objUserBL.A12 == string.Empty ? "01/01/1900" : objUserBL.A12));
            param[13] = new SqlParameter("@REFERENCE_NO", objUserBL.A13);
            param[14] = new SqlParameter("@EXPIRY_DATE", Connection.DATE_FORMAT(objUserBL.A14 == string.Empty ? "01/01/1900" : objUserBL.A14));
            param[15] = new SqlParameter("@ISSUING_PARTY_NAME", objUserBL.A15);
            param[16] = new SqlParameter("@ISSUING_PARTY_CODE", objUserBL.A16);
            param[17] = new SqlParameter("@ISSUING_PARTY_ADD_1", objUserBL.A17);
            param[18] = new SqlParameter("@ISSUING_PARTY_ADD_2", objUserBL.A18);
            param[19] = new SqlParameter("@ISSUING_PARTY_CITY", objUserBL.A19);
            param[20] = new SqlParameter("@ISSUING_PARTY_PIN_CODE", objUserBL.A20);
            param[21] = new SqlParameter("@BENEFICIARY_PARTY_NAME", objUserBL.A21);
            param[22] = new SqlParameter("@BENEFICIARY_PARTY_CODE", objUserBL.A22);
            param[23] = new SqlParameter("@BENEFICIARY_PARTY_ADD_1", objUserBL.A23);
            param[24] = new SqlParameter("@BENEFICIARY_PARTY_ADD_2", objUserBL.A24);
            param[25] = new SqlParameter("@BENEFICIARY_PARTY_CITY", objUserBL.A25);
            param[26] = new SqlParameter("@BENEFICIARY_PARTY_PIN_CODE", objUserBL.A26);
            param[27] = new SqlParameter("@Flag", objUserBL.A27);
            param[35] = new SqlParameter("@AUTO_SAVE", objUserBL.A28);
            param[36] = new SqlParameter("@SELECT_LEVEL", objUserBL.A29);


            param[28] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[29] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[30] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[31] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());

            param[32] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[32].Direction = ParameterDirection.Output;

            param[33] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[33].Direction = ParameterDirection.Output;
            param[34] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[34].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("SUPPORTING_DOCUMENTS_INS_UPD", param);
            result = Convert.ToInt32(param[33].Value.ToString());
            if (objUserBL.A27 == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[32].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Sup_Doc_Search(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A7 != string.Empty && objUserBL.A7 != null)
            {
                arr = objUserBL.A7.Split('/');
                objUserBL.A7 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A8 != string.Empty && objUserBL.A8 != null)
            {
                arr2 = objUserBL.A8.Split('/');
                objUserBL.A8 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Imp_Exp", objUserBL.A1);
            param[2] = new SqlParameter("@Issuing_Party_Name", objUserBL.A2);
            param[3] = new SqlParameter("@Beneficiary_Party_Name", objUserBL.A3);
            param[4] = new SqlParameter("@Icegate_ID", objUserBL.A4);
            param[5] = new SqlParameter("@Img_Ref_no", objUserBL.A5);
            param[6] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[7] = new SqlParameter("@Flag", objUserBL.A6);
            param[10] = new SqlParameter("@from_date", objUserBL.A7);
            param[11] = new SqlParameter("@to_date", objUserBL.A8);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("SUPPORTING_DOCUMENTS_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet SUP_DOC_MASTER_XL_UPD(UserBO objUserBL)
    {

        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[2] = new SqlParameter("@flag", objUserBL.flag);
            param[3] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[4] = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SUP_DOC_MASTER_EXL_UPLOAD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}