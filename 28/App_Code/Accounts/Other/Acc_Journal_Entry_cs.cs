using System;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public class Acc_Journal_Entry_cs
{
    DataSet ds = new DataSet();

    public DataSet JV_Entry_Head_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[2] = new SqlParameter("@JV_P", objUserBL.A5);
            param[3] = new SqlParameter("@JV_NO", objUserBL.A6);
            param[4] = new SqlParameter("@JV_S", objUserBL.A7);            

            param[5] = new SqlParameter("@IMP_EXP", objUserBL.A51);
            param[6] = new SqlParameter("@CHARGE_NAME", objUserBL.A52);
            param[7] = new SqlParameter("@AMOUNT", objUserBL.A53);
            param[8] = new SqlParameter("@DR_CR", objUserBL.A54);
            param[09] = new SqlParameter("@LINKED_GL", objUserBL.A55);
            param[10] = new SqlParameter("@COST_CENTER", objUserBL.A56);
            param[11] = new SqlParameter("@BRANCH", objUserBL.A57);
            param[12] = new SqlParameter("@TAX_NONTAX", objUserBL.A58);
            param[13] = new SqlParameter("@TAX_AMT_PERCENT", objUserBL.A59);
            param[14] = new SqlParameter("@NARRATION", objUserBL.A60);
            param[35] = new SqlParameter("@flag", objUserBL.A100);
            param[36] = new SqlParameter("@User_Name", Connection.Current_User());            
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod()); 
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            param[41] = new SqlParameter("@XmlData", objUserBL.A101);

            ds = Connection.Get_Dataset("ACC_JOURNAL_LINE_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //details page insert update section
    public DataSet JV_Line_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[43];
            param[1] = new SqlParameter("@JL_ID", objUserBL.A1);

            param[5] = new SqlParameter("@JV_P", objUserBL.A5);
            param[6] = new SqlParameter("@JV_NO", objUserBL.A6);
            param[7] = new SqlParameter("@JV_S", objUserBL.A7);

            param[10] = new SqlParameter("@IMP_EXP", objUserBL.A10);
            param[11] = new SqlParameter("@CHARGE_NAME", objUserBL.A11);
            param[12] = new SqlParameter("@AMOUNT", objUserBL.A12);
            param[13] = new SqlParameter("@DR_CR", objUserBL.A13);
            param[14] = new SqlParameter("@LINKED_GL", objUserBL.A14);
            
            param[15] = new SqlParameter("@COST_CENTER", objUserBL.A15);
            param[16] = new SqlParameter("@ACC_BRANCH", objUserBL.A16);

            param[17] = new SqlParameter("@TAX_NONTAX", objUserBL.A17);
            param[18] = new SqlParameter("@TAX_AMT_PERCENT", objUserBL.A18);
            param[19] = new SqlParameter("@NARRATION", objUserBL.A19);

            param[20] = new SqlParameter("@xmlString_Gen", objUserBL.A49);
            param[21] = new SqlParameter("@flag", objUserBL.A50);

            param[36] = new SqlParameter("@User_Name", Connection.Current_User());

            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_JOURNAL_LINE_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    //1.SEARCH PAGE SEARCH BUTTON FUNCTION
    public DataSet JV_Header_Search(Global_variables objUserBL)
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
            param[2] = new SqlParameter("@from_date", objUserBL.A1);
            param[3] = new SqlParameter("@to_date", objUserBL.A2);
            param[1] = new SqlParameter("@JV_NO", objUserBL.A3);

            param[4] = new SqlParameter("@GL_NO", objUserBL.A4);

            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", objUserBL.A40);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_JV_HEADER_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    //comes from row select , jv NO GENERATION
    //2. asmx/Accounts_Auto_Search.cs 2functions
    public DataSet JV_Header_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[2] = new SqlParameter("@JV_ID", objUserBL.A1);
            param[3] = new SqlParameter("@C_Ch_Id", objUserBL.A2);

            param[4] = new SqlParameter("@JV_P", objUserBL.A3);
            param[5] = new SqlParameter("@JV_NO", objUserBL.A4);
            param[6] = new SqlParameter("@JV_S", objUserBL.A5);
            
            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@JV_JOB_AMT", objUserBL.A7);
            param[9] = new SqlParameter("@Party_Name", objUserBL.A8);
            param[10] = new SqlParameter("@Party_Name_Type", objUserBL.A9);
            param[11] = new SqlParameter("@JOBNO", objUserBL.A10);

            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag passed here
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_JV_HEADER_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    //3.entry page save section
    public DataSet JV_Header_Ins_Upd(Global_variables objUserBL)
    {
        try
        { 

            SqlParameter[] param = new SqlParameter[43];
            param[3] = new SqlParameter("@JV_ID", objUserBL.A1);
            
            param[5] = new SqlParameter("@JV_P", objUserBL.A3);
            param[6] = new SqlParameter("@JV_NO", objUserBL.A4);
            param[7] = new SqlParameter("@JV_S", objUserBL.A5);
            if (objUserBL.A6 == null)
            {
                objUserBL.A6 = string.Empty;
            }
            param[8] = new SqlParameter("@JV_DATE", Connection.DATE_FORMAT(objUserBL.A6 == string.Empty ? "01/01/1900" : objUserBL.A6));
            if (objUserBL.A7 == null)
            {
                objUserBL.A7 = string.Empty;
            }
            param[10] = new SqlParameter("@POSTING_DATE", Connection.DATE_FORMAT(objUserBL.A7 == string.Empty ? "01/01/1900" : objUserBL.A7));           

         
            param[15] = new SqlParameter("@JV_CUR", objUserBL.A12);
            param[16] = new SqlParameter("@JV_CUR_VALUE", objUserBL.A13);
            param[17] = new SqlParameter("@JV_REF_NO", objUserBL.A14);
            if (objUserBL.A15 == null)
            {
                objUserBL.A15 = string.Empty;
            }
            param[18] = new SqlParameter("@JV_REF_DATE", Connection.DATE_FORMAT(objUserBL.A15 == string.Empty ? "01/01/1900" : objUserBL.A15));
            param[19] = new SqlParameter("@JV_NARRATION", objUserBL.A16);

            param[33] = new SqlParameter("@JOB_LICENSE", objUserBL.A17);
            param[34] = new SqlParameter("@JOB_WORKINGPERIOD", objUserBL.A18);

            param[35] = new SqlParameter("@flag", objUserBL.A40);
            param[36] = new SqlParameter("@User_Name", Connection.Current_User());
            param[37] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[38] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[39] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_JOURNAL_HEADER_INS_UPD", param); //ACC_GST_JV_PAYMENT_ENTRY_INS_UPD
        } 
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    //Comes from entry page to Details page section load
    public DataSet JV_DetailsPage_GetData(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[2] = new SqlParameter("@JV_ID", objUserBL.A1);
            param[3] = new SqlParameter("@C_Ch_Id", objUserBL.A2);

            param[4] = new SqlParameter("@JV_P", objUserBL.A3);
            param[5] = new SqlParameter("@JV_NO", objUserBL.A4);
            param[6] = new SqlParameter("@JV_S", objUserBL.A5);

            param[7] = new SqlParameter("@JOB_ID", objUserBL.A6);
            param[8] = new SqlParameter("@JV_JOB_AMT", objUserBL.A7);
            param[9] = new SqlParameter("@Party_Name", objUserBL.A8);
            param[10] = new SqlParameter("@Party_Name_Type", objUserBL.A9);
            param[11] = new SqlParameter("@JOBNO", objUserBL.A10);

            param[16] = new SqlParameter("@flag", objUserBL.A40); //Flag passed here
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[18] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_GST_JV_HEADER_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    //added by Tamil
    public DataSet ACC_GST_JOURNAL_RPT(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();

        try
        {
            SqlParameter[] param = new SqlParameter[25];


            param[0] = new SqlParameter("@JV_P", objUserBL.A1);
            param[1] = new SqlParameter("@JV_NO", objUserBL.A2);
            param[2] = new SqlParameter("@JV_S", objUserBL.A3);

            param[4] = new SqlParameter("@MFLAG", objUserBL.A25);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1);
            param[5].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_JOURNAL_RPT", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
}