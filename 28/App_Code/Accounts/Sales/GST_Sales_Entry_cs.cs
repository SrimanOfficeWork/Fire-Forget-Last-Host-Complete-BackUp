using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;


public class GST_Sales_Entry_cs
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    Global_variables ObjUBO = new Global_variables();

    public DataSet Db_Connection(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@ID", objUserBL.A289); //A1
            param[2] = new SqlParameter("@Customer_Name", objUserBL.A290); //A2
            param[3] = new SqlParameter("@Branch_Common", objUserBL.A291); //A3
            param[4] = new SqlParameter("@Company_Lic", objUserBL.A292); //A4
            param[5] = new SqlParameter("@Company_Id", objUserBL.A293); //A5
            param[6] = new SqlParameter("@Type", objUserBL.A294); //A6

            param[8] = new SqlParameter("@Server_Name", objUserBL.A295);//A8
            param[9] = new SqlParameter("@Login_Name", objUserBL.A296);//A9
            param[10] = new SqlParameter("@Login_Pwd", objUserBL.A297); //A10
            param[11] = new SqlParameter("@From_Databse", objUserBL.A298);//A11

            param[12] = new SqlParameter("@WorkingPeriod", objUserBL.A299); //A12
            param[7] = new SqlParameter("@Flag", objUserBL.A300);//A7

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "AUTO_INSTAL_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Select_Inv(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[41];

            param[2] = new SqlParameter("@R_O_TYPE", objUserBL.A1);
            param[3] = new SqlParameter("@JOB_LICENSE", objUserBL.A2);
            param[4] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A3);
            param[5] = new SqlParameter("@Bill_Invno", objUserBL.A4);
            param[6] = new SqlParameter("@Cus_Name", objUserBL.A5);
            param[7] = new SqlParameter("@Branch_No", objUserBL.A6);
            param[8] = new SqlParameter("@Imp_Exp", objUserBL.A7);
            param[9] = new SqlParameter("@xml_Jobnos", objUserBL.A8);
            param[10] = new SqlParameter("@xml_R_Jobno", objUserBL.A9);
            param[11] = new SqlParameter("@Trans_Mode", objUserBL.A10);
            param[12] = new SqlParameter("@From_Quotation", objUserBL.A11);
            param[13] = new SqlParameter("@Bill_Id", objUserBL.A12);
            param[14] = new SqlParameter("@Charge_Name", objUserBL.A13);
            param[15] = new SqlParameter("@Tax_Nontax", objUserBL.A14);
            param[16] = new SqlParameter("@Local_Other", objUserBL.A15);
            param[17] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.A16);

            param[21] = new SqlParameter("@xmlstring_A", objUserBL.A37);
            param[22] = new SqlParameter("@xmlstring_B", objUserBL.A38);
            param[23] = new SqlParameter("@xmlstring_D", objUserBL.A39);

            param[24] = new SqlParameter("@flag", objUserBL.A40);
            param[25] = new SqlParameter("@xmlstring_Gen", objUserBL.A41);
            param[26] = new SqlParameter("@xmlstring_IGM", objUserBL.A42);
            param[27] = new SqlParameter("@xmlstring_Inv", objUserBL.A43);
            param[28] = new SqlParameter("@xmlstring_Item", objUserBL.A44);
            param[29] = new SqlParameter("@xmlstring_BE_SB", objUserBL.A45);

            param[35] = new SqlParameter("@User_Name", Connection.Current_User());
            param[36] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[37] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[38] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[39] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_BILL_SALES_INV_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Inv(Global_variables objUserBL, string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[41];

            param[2] = new SqlParameter("@R_O_TYPE", objUserBL.A1);
            param[3] = new SqlParameter("@JOB_LICENSE", objUserBL.A2);
            param[4] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A3);
            param[5] = new SqlParameter("@Bill_Invno", objUserBL.A4);
            param[6] = new SqlParameter("@Cus_Name", objUserBL.A5);
            param[7] = new SqlParameter("@Branch_No", objUserBL.A6);
            param[8] = new SqlParameter("@Imp_Exp", objUserBL.A7);
            param[9] = new SqlParameter("@xml_Jobnos", objUserBL.A8);
            param[10] = new SqlParameter("@xml_R_Jobno", objUserBL.A9);
            param[11] = new SqlParameter("@Trans_Mode", objUserBL.A10);
            param[12] = new SqlParameter("@From_Quotation", objUserBL.A11);
            param[13] = new SqlParameter("@Bill_Id", objUserBL.A12);
            param[14] = new SqlParameter("@Charge_Name", objUserBL.A13);
            param[15] = new SqlParameter("@Tax_Nontax", objUserBL.A14);
            param[16] = new SqlParameter("@Local_Other", objUserBL.A15);
            param[17] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.A16);

            param[21] = new SqlParameter("@xmlstring_A", objUserBL.A37);
            param[22] = new SqlParameter("@xmlstring_B", objUserBL.A38);
            param[23] = new SqlParameter("@xmlstring_D", objUserBL.A39);

            param[24] = new SqlParameter("@flag", objUserBL.A40);
            param[25] = new SqlParameter("@xmlstring_Gen", objUserBL.A41);
            param[26] = new SqlParameter("@xmlstring_IGM", objUserBL.A42);
            param[27] = new SqlParameter("@xmlstring_Inv", objUserBL.A43);
            param[28] = new SqlParameter("@xmlstring_Item", objUserBL.A44);
            param[29] = new SqlParameter("@xmlstring_BE_SB", objUserBL.A45);
            
            param[35] = new SqlParameter("@User_Name", Connection.Current_User());
            param[36] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[37] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[38] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[39] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, "ACC_GST_BILL_SALES_INV_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet BILL_INV_SEARCH(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (objUserBL.A1 != string.Empty && objUserBL.A1 != null)
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.A2 != string.Empty && objUserBL.A2 != null)
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@from_date", objUserBL.A1);
            param[2] = new SqlParameter("@to_date", objUserBL.A2);
            param[3] = new SqlParameter("@Cus_name", objUserBL.A3);
            param[4] = new SqlParameter("@Search_Cat", objUserBL.A4);
            param[5] = new SqlParameter("@Search_Item", objUserBL.A5);
            param[6] = new SqlParameter("@Imp_Exp", objUserBL.A6);
            param[7] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[8] = new SqlParameter("@Flag", objUserBL.A7);
            param[10] = new SqlParameter("@Approval", objUserBL.A8);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILL_INV_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Billing_Invoice_INS_UPD(Global_variables objUserBL)
    {
        DataSet ds_s = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[81];

            param[1] = new SqlParameter("@ID", objUserBL.A1); //A1
            param[2] = new SqlParameter("@R_O_TYPE", objUserBL.A2);
            param[3] = new SqlParameter("@IMP_EXP", objUserBL.A3);//A2
            param[4] = new SqlParameter("@LOCAL_OTHER", objUserBL.A4);//A3
            param[5] = new SqlParameter("@JOB_COMPANY_LIC", objUserBL.A5);
            param[6] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A6);
            param[7] = new SqlParameter("@CUS_NAME", objUserBL.A7); //A4
            param[8] = new SqlParameter("@CUS_BRANCH_NO", objUserBL.A8);//A5
            param[9] = new SqlParameter("@MODE", objUserBL.A9); //A26
            param[10] = new SqlParameter("@SHIP_TYPE", objUserBL.A10);//A27
            param[11] = new SqlParameter("@FROM_QUOTATION", objUserBL.A11);//A6

            param[14] = new SqlParameter("@BILL_INV_NO", objUserBL.A14);//A8
            if (objUserBL.A15 == null)
            {
                objUserBL.A15 = string.Empty;
            }
            param[15] = new SqlParameter("@BILL_INV_DATE", Connection.DATE_FORMAT(objUserBL.A15 == string.Empty ? "01/01/1900" : objUserBL.A15)); //A9
            param[16] = new SqlParameter("@PARTY_NAME", objUserBL.A16);//A10
            param[17] = new SqlParameter("@AC_BEHALF", objUserBL.A17);//A11
            param[18] = new SqlParameter("@SHIPPER_NAME", objUserBL.A18);//A42
            param[19] = new SqlParameter("@STATE_NAME", objUserBL.A19);//A12
            param[20] = new SqlParameter("@GSTN_ID", objUserBL.A20);//A13
            param[21] = new SqlParameter("@PARTY_ADDRESS", objUserBL.A21);//A14
            param[22] = new SqlParameter("@PO_NO", objUserBL.A22);//A41
            param[23] = new SqlParameter("@ACC_HEAD", objUserBL.A23);//A40
            param[24] = new SqlParameter("@REMARKS", objUserBL.A24);//A44
            param[25] = new SqlParameter("@HSS_CODE", objUserBL.A25);//A46
            param[26] = new SqlParameter("@PARMA_CODE", objUserBL.A26);//A47
            param[27] = new SqlParameter("@WORK_ID", objUserBL.A27);//A48

            param[28] = new SqlParameter("@GRAND_TOTAL", objUserBL.A28);//A20
            param[29] = new SqlParameter("@ADVANCE_AMT", objUserBL.A29);//A21
            param[30] = new SqlParameter("@EXPENSE_AMT", objUserBL.A30);//A22
            param[31] = new SqlParameter("@TOTAL_TAX_AMT", objUserBL.A31);//A22
            param[32] = new SqlParameter("@BANK_DETAILS", objUserBL.A32);//A25
            param[33] = new SqlParameter("@UNAPPROVAL_APPROVED", objUserBL.A33);//A43
            param[34] = new SqlParameter("@TAX_NON_TAX", objUserBL.A34);
            param[35] = new SqlParameter("@CUS_BRANCH_NO_LOC", objUserBL.A35); //A23
            param[36] = new SqlParameter("@JOB_TYPE", objUserBL.A36); //A23

            param[37] = new SqlParameter("@NON_TAX_AMT", objUserBL.A37);//A19
            param[38] = new SqlParameter("@TAX_AMT", objUserBL.A38);//A18
            param[39] = new SqlParameter("@JOB_STATUS", objUserBL.A39);
            param[40] = new SqlParameter("@REG_SEZ", objUserBL.A40);
            param[41] = new SqlParameter("@TR_YN", objUserBL.A41);
            param[42] = new SqlParameter("@BANK_AC_NO", objUserBL.A42); //32
            param[43] = new SqlParameter("@BILL_TYPE", objUserBL.A43); //32

            if (objUserBL.A44 == null)
            {
                objUserBL.A44 = string.Empty;
            }
            param[44] = new SqlParameter("@DUE_DATE", Connection.DATE_FORMAT(objUserBL.A44 == string.Empty ? "01/01/1900" : objUserBL.A44)); 
            param[45] = new SqlParameter("@TDS_YN", objUserBL.A45); //32
            param[46] = new SqlParameter("@TDS_RATE", objUserBL.A46); //32
            param[47] = new SqlParameter("@TDS_AMT", objUserBL.A47); //32


            param[67] = new SqlParameter("@xmlString_Job", objUserBL.A73);//A35
            param[68] = new SqlParameter("@xmlString_Gen", objUserBL.A74);//A35
            param[69] = new SqlParameter("@xmlString_IGM", objUserBL.A75);//A35
            param[70] = new SqlParameter("@xmlString_Inv", objUserBL.A76);//A36
            param[71] = new SqlParameter("@xmlString_Item", objUserBL.A77);//A37
            param[72] = new SqlParameter("@xmlString_BE_SB", objUserBL.A78);//A38
            param[73] = new SqlParameter("@xmlString_Charge", objUserBL.A79);//A38
            param[74] = new SqlParameter("@flag", objUserBL.A80);//A39

            param[75] = new SqlParameter("@Company_Lic", Connection.Company_License());
            param[76] = new SqlParameter("@USER_NAME", Connection.Current_User());
            param[77] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[78] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[79] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

            param[80] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[80].Direction = ParameterDirection.Output;

            ds_s = Connection.Get_Dataset("ACC_GST_BILL_INVOICE_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds_s;
    }
    public DataSet Select_IMP_INV(Billing_UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Branch_No", objUserBL.Branch_No);
            param[1] = new SqlParameter("@Trans_Mode", objUserBL.MODE);
            param[2] = new SqlParameter("@Imp_Name", objUserBL.Imp_Name);
            param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[6] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
            param[7] = new SqlParameter("@FROM_QUOTATION", objUserBL.FROM_QUOTATION);
            param[9] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());
            param[10] = new SqlParameter("@J_ASS_VALUE", objUserBL.Ass_Value);
            param[11] = new SqlParameter("@J_CIF_VALUE", objUserBL.CIF_VALUE);
            param[12] = new SqlParameter("@SHIPMENT_TYPE", objUserBL.SHIPMENT_TYPE);

            param[13] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.JOB_WORKINGPERIOD);
            param[14] = new SqlParameter("@BILL_TYPE", objUserBL.BILL_TYPE);

            param[15] = new SqlParameter("@DEFAULT_CUR", objUserBL.DEFAULT_CUR);
            param[16] = new SqlParameter("@EX_RATE", objUserBL.EX_RATE);

            param[24] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[24].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_BILL_IMPORT_INV_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Imp_Exp_Data(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[2] = new SqlParameter("@Bill_Invno", objUserBL.A1);
            param[3] = new SqlParameter("@Cus_Name", objUserBL.A2);
            param[4] = new SqlParameter("@Branch_No", objUserBL.A3);
            param[5] = new SqlParameter("@Jobno", objUserBL.A4);
            param[6] = new SqlParameter("@Trans_Mode", objUserBL.A5);
            param[7] = new SqlParameter("@From_Quotation", objUserBL.A6);
            param[8] = new SqlParameter("@Imp_Exp", objUserBL.A7);
            param[9] = new SqlParameter("@Mflag", objUserBL.A8);

            param[10] = new SqlParameter("@xmlstring_A", objUserBL.A9);
            param[11] = new SqlParameter("@xmlstring_B", objUserBL.A10);
            param[12] = new SqlParameter("@xmlstring_D", objUserBL.A11);
            param[13] = new SqlParameter("@Local_Other", objUserBL.A12);

            param[14] = new SqlParameter("@Av_Value", objUserBL.A13);
            param[15] = new SqlParameter("@Dv_Value", objUserBL.A14);

            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@Wrk_period", Connection.WorkingPeriod());
            param[19] = new SqlParameter("@Company_Lic", Connection.Company_License());

            param[20] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[20].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset(objUserBL.A15, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Select_Imp_Exp_Data(Global_variables objUserBL, string constr)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[51];

            param[2] = new SqlParameter("@R_O_TYPE", objUserBL.A1);
            param[3] = new SqlParameter("@JOB_LICENSE", objUserBL.A2);
            param[4] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A3);

            param[5] = new SqlParameter("@Bill_Invno", objUserBL.A4);
            param[6] = new SqlParameter("@Bill_Id", objUserBL.A5);
            param[7] = new SqlParameter("@Imp_Exp", objUserBL.A6);
            param[8] = new SqlParameter("@Cus_Name", objUserBL.A7);
            param[9] = new SqlParameter("@Branch_No", objUserBL.A8);
            param[10] = new SqlParameter("@Local_Other", objUserBL.A9);
            param[11] = new SqlParameter("@From_Quotation", objUserBL.A10);
            param[12] = new SqlParameter("@xml_Jobnos", objUserBL.A11);
            param[13] = new SqlParameter("@Ship_Type_1", objUserBL.A12);
            param[14] = new SqlParameter("@Ship_Type_2", objUserBL.A13);

           
            param[42] = new SqlParameter("@xmlstring_A", objUserBL.A47);
            param[43] = new SqlParameter("@xmlstring_B", objUserBL.A48);
            param[44] = new SqlParameter("@xmlstring_D", objUserBL.A49);
           
            param[46] = new SqlParameter("@flag", objUserBL.A50);
            param[47] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[48] = new SqlParameter("@Company_Lic", Connection.Company_License());

            param[50] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[50].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(constr, CommandType.StoredProcedure, objUserBL.A46, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet Invoice_Job_Rpt_data(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Bill_Inv_No", objUserBL.A3);
            param[1] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[3].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset(objUserBL.A9, param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    /*****************************************************/
    public DataSet Ass_Gst_Bill_Job_Rpt_Ann_Invoice_Exp_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[81];

            param[1] = new SqlParameter("@BILL_INV_NO", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.A2);
            param[3] = new SqlParameter("@ID", objUserBL.A3);
            param[4] = new SqlParameter("@JOBNO", objUserBL.A4);
            param[5] = new SqlParameter("@JOBTYPE", objUserBL.A5);
            param[6] = new SqlParameter("@SB_NO", objUserBL.A6);
            param[7] = new SqlParameter("@SB_DATE", Connection.DATE_FORMAT(objUserBL.A7 == string.Empty ? "01/01/1900" : objUserBL.A7));
            param[8] = new SqlParameter("@CUS_REF_NO", objUserBL.A8);
            param[9] = new SqlParameter("@SB_TYPE", objUserBL.A9);
            param[10] = new SqlParameter("@JOB_INV_NO", objUserBL.A10);
            param[11] = new SqlParameter("@JOB_INV_DATE", Connection.DATE_FORMAT(objUserBL.A11 == string.Empty ? "01/01/1900" : objUserBL.A11));
            param[12] = new SqlParameter("@MBL_NO", objUserBL.A12);
            param[13] = new SqlParameter("@MBL_DATE", Connection.DATE_FORMAT(objUserBL.A13 == string.Empty ? "01/01/1900" : objUserBL.A13));
            param[14] = new SqlParameter("@TERM_OF_INV", objUserBL.A14);
            param[15] = new SqlParameter("@HBL_NO", objUserBL.A15);
            param[16] = new SqlParameter("@HBL_DATE", Connection.DATE_FORMAT(objUserBL.A16 == string.Empty ? "01/01/1900" : objUserBL.A16));
            param[17] = new SqlParameter("@INV_VALUE", objUserBL.A17);
            param[18] = new SqlParameter("@CIF_VALUE", objUserBL.A18);
            param[19] = new SqlParameter("@CUSTOM_HOUSE", objUserBL.A19);
            param[20] = new SqlParameter("@FOB_VALUE", objUserBL.A20);
            param[21] = new SqlParameter("@VESSEL", objUserBL.A21);
            param[22] = new SqlParameter("@VOYAGE_NO", objUserBL.A22);
            param[23] = new SqlParameter("@CONSIGNEE_NAME", objUserBL.A23);
            param[24] = new SqlParameter("@ORGIN_PORT", objUserBL.A24);
            param[25] = new SqlParameter("@SB_HEADING", objUserBL.A25);
            param[26] = new SqlParameter("@EXPORTER_NAME", objUserBL.A26);
            param[27] = new SqlParameter("@CONTAINERS", objUserBL.A27);
            param[28] = new SqlParameter("@JOB_LICENSE", objUserBL.A28);
            param[29] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A29);
            param[30] = new SqlParameter("@flag", objUserBL.A30);
            param[31] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[32] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;
            param[34] = new SqlParameter("@user_id", Connection.Current_User());

            param[35] = new SqlParameter("@CONSIGNE_TYPE", objUserBL.A31);
            param[36] = new SqlParameter("@PKG", objUserBL.A32);
            param[37] = new SqlParameter("@GROSS_WEIGHT", objUserBL.A33);
            param[38] = new SqlParameter("@NET_WGT", objUserBL.A34);
            param[39] = new SqlParameter("@CHARGE_WT", objUserBL.A35);
            param[40] = new SqlParameter("@NO_OF_CONTAINERS", objUserBL.A36);

            ds = Connection.Get_Dataset("ACC_GST_BILL_JOB_RPT_ANNEXURE_EXP_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
    public DataSet Ass_Gst_Bill_Job_Rpt_Ann_Invoice_Exp_Select(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[81];

            param[1] = new SqlParameter("@BILL_INV_NO", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.A2);

            param[30] = new SqlParameter("@flag", objUserBL.A30);
            param[31] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[32] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;
            param[34] = new SqlParameter("@user_id", Connection.Current_User());
            ds = Connection.Get_Dataset("ACC_GST_BILL_JOB_RPT_ANNEXURE_EXP_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
    public DataSet Ass_Gst_Bill_Job_Rpt_Ann_Invoice_Imp_Ins_Upd(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[81];

            param[1] = new SqlParameter("@BILL_INV_NO", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.A2);
            param[3] = new SqlParameter("@ID", objUserBL.A3);
            param[4] = new SqlParameter("@JOBNO", objUserBL.A4);
            param[5] = new SqlParameter("@JOBTYPE", objUserBL.A5);
            param[6] = new SqlParameter("@BE_NO", objUserBL.A6);
            param[7] = new SqlParameter("@BE_DATE", Connection.DATE_FORMAT(objUserBL.A7 == string.Empty ? "01/01/1900" : objUserBL.A7));
            param[8] = new SqlParameter("@CUS_REF_NO", objUserBL.A8);
            param[9] = new SqlParameter("@BE_TYPE", objUserBL.A9);
            param[10] = new SqlParameter("@JOB_INV_NO", objUserBL.A10);
            param[11] = new SqlParameter("@JOB_INV_DATE", Connection.DATE_FORMAT(objUserBL.A11 == string.Empty ? "01/01/1900" : objUserBL.A11));
            param[12] = new SqlParameter("@MBL_NO", objUserBL.A12);
            param[13] = new SqlParameter("@MBL_DATE", Connection.DATE_FORMAT(objUserBL.A13 == string.Empty ? "01/01/1900" : objUserBL.A13));
            param[14] = new SqlParameter("@TERM_OF_INV", objUserBL.A14);
            param[15] = new SqlParameter("@HBL_NO", objUserBL.A15);
            param[16] = new SqlParameter("@HBL_DATE", Connection.DATE_FORMAT(objUserBL.A16 == string.Empty ? "01/01/1900" : objUserBL.A16));
            param[17] = new SqlParameter("@INV_VALUE", objUserBL.A17);
            param[18] = new SqlParameter("@CIF_VALUE", objUserBL.A18);
            param[19] = new SqlParameter("@CUSTOM_HOUSE", objUserBL.A19);
            param[20] = new SqlParameter("@ASSESS_VALUE", objUserBL.A20);
            param[21] = new SqlParameter("@VESSEL", objUserBL.A21);
            param[22] = new SqlParameter("@VOYAGE_NO", objUserBL.A22);
            param[23] = new SqlParameter("@SHIPPER_NAME", objUserBL.A23);
            param[24] = new SqlParameter("@ORGIN_PORT", objUserBL.A24);
            param[25] = new SqlParameter("@BE_HEADING", objUserBL.A25);
            param[26] = new SqlParameter("@IMPORTER_NAME", objUserBL.A26);
            param[27] = new SqlParameter("@CONTAINERS", objUserBL.A27);
            param[28] = new SqlParameter("@JOB_LICENSE", objUserBL.A28);
            param[29] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A29);
            param[30] = new SqlParameter("@flag", objUserBL.A30);
            param[31] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[32] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;
            param[34] = new SqlParameter("@user_id", Connection.Current_User());

            param[35] = new SqlParameter("@CONSIGNE_TYPE", objUserBL.A31);
            param[36] = new SqlParameter("@PKG", objUserBL.A32);
            param[37] = new SqlParameter("@GROSS_WEIGHT", objUserBL.A33);
            param[38] = new SqlParameter("@NET_WGT", objUserBL.A34);
            param[39] = new SqlParameter("@CHARGE_WT", objUserBL.A35);
            param[40] = new SqlParameter("@NO_OF_CONTAINERS", objUserBL.A36);
            param[41] = new SqlParameter("@DUTY_VALUE", objUserBL.A37);
            ds = Connection.Get_Dataset("ACC_GST_BILL_JOB_RPT_ANNEXURE_IMP_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
    public DataSet Ass_Gst_Bill_Job_Rpt_Ann_Invoice_Imp_Select(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[81];

            param[1] = new SqlParameter("@BILL_INV_NO", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.A2);

            param[30] = new SqlParameter("@flag", objUserBL.A30);
            param[31] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[32] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;
            param[34] = new SqlParameter("@user_id", Connection.Current_User());
            ds = Connection.Get_Dataset("ACC_GST_BILL_JOB_RPT_ANNEXURE_IMP_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
    public DataSet Ass_Gst_Annexure_Invoice_Select(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[35];

            param[1] = new SqlParameter("@BILL_INV_NO", objUserBL.A1);
            param[2] = new SqlParameter("@IMP_EXP", objUserBL.A2);

            param[30] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[31] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[32] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_ANNEXURE_INVOICE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
    public DataSet Acc_Gst_Annexure_Search_Select(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[35];

            param[1] = new SqlParameter("@BILL_INV_NO", objUserBL.A1);

            param[30] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[31] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[32] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[33] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[33].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_ANNEXURE_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
}