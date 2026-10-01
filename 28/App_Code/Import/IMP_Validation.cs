using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;

public class IMP_Validation
{
    private string _Jobno;
    private string _Flag;
    private string _Branch_Type;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }

    public String Xml_A, Xml_B, Xml_C, Xml_D, Xml_E;

   
    public DataSet IMP_Data_Select()
    {
        DataSet ds_IV = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Branch_Type", Branch_Type);
            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@Flag", Flag);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            switch (Flag)
            {
                case "IMP_GENERAL_DETAILS":
                case "IMP_IGM_DETAILS":
                case "IMP_BOND_DETAILS":
                case "IMP_CONTAINER_DETAILS":
                case "IMP_Flat_File_DETAILS":
                case "Check_Exbond_Job":
                case "Validate_Exbond_Job":
                case "Check_Bond_Item_Scheme":
                case "CHA_LICENSE_DETAILS":
                    ds_IV = Connection.Get_Dataset("IMP_VALIDATION_GEN_IGM", param);
                    break;
                case "IMP_INVOICE_DETAILS":
                case "IMP_INVOICE_CUR_EXCHANGE_RATE":
                case "IMP_INV_SVB_DETAILS":
                    ds_IV = Connection.Get_Dataset("IMP_VALIDATION_INVOICE", param);
                    break;
                case "IMP_ITEM_DETAILS_ADMIN":
                case "IMP_ITEM_DETAILS_Val":
                case "IMP_CERTIFICATE_DETAILS":
                case "IMP_RE_IMPORT_DETAILS_Admin_Select":
                case "IMP_Single_Window_Admin_Select":
                case "IMP_ITEM_Lic":
                case "IMP_ITEM_NOTIF_ADMIN":
                case "IMP_Single_Window_Entry_Select":
                case "IMP_Items_SW_Entry_Table":
                case "IMP_Invoice_Item_Select":
                case "SW_Control_Table":
                case "Item_Special_Character":
                case "IMP_Items_SW_Auto_Entry":
                case "SW_SIMS_InfoType_Table":
                case "IMP_SW_SIMS_Sup_Doc_Entry_Select":
                case "FTA_NOTN_Val":
                case "SEZ_DETAILS_VAL":
                case "HAND_DETAILS_VAL":
                case "Get_SW_CCDC_Mandatory":
                    ds_IV = Connection.Get_Dataset("IMP_VALIDATION_ITEM", param);
                    break;
                case "Item_SW":
                    param[4] = new SqlParameter("@xmlString_A", Xml_A);
                    ds_IV = Connection.Get_Dataset("IMP_SW_VALIDATION_ITEM", param);
                    break;
                case "IMP_SPL_CHAR":
                    ds_IV = Connection.Get_Dataset("IMPORT_SPECIAL_CHARACTERS", param);
                    break;
                case "IMP_SPL_CHAR_Auto_Remove":
                    ds_IV = Connection.Get_Dataset("IMPORT_SPECIAL_CHARACTERS_AUTO_REMOVE", param);
                    break;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_IV;
    }

    
    public DataSet IMP_Admin_Select()
    {
        DataSet ds_2 = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@COMPANYID", Connection.COMPANYID());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds_2 = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "FLATFILE_VALIDATION_IMP_EXP", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_2;
    }

    public int DSC_Flatfile_DML(UserBO objUserBL)
    {
        int i = 0;
        try
        {
            SqlParameter[] param = new SqlParameter[18];

            //param[1] = new SqlParameter("@ID", "");
            param[1] = new SqlParameter("@ID", Connection.Company_License());
            param[2] = new SqlParameter("@JOB_TYPE", objUserBL.File_Type);
            param[3] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[4] = new SqlParameter("@FOLDER_PATH", objUserBL.ITEM_DESCRIPTION);
            param[5] = new SqlParameter("@FILE_STATUS", objUserBL.Select_Item);
            param[6] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[7] = new SqlParameter("@User_Name", Connection.Current_User());
            
            param[8] = new SqlParameter("@WORKING_PERIOD", Connection.WorkingPeriod());
            param[9] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[10] = new SqlParameter("@Mflag", objUserBL.flag);

            param[15] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
            param[15].Direction = ParameterDirection.Output;

            param[16] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[16].Direction = ParameterDirection.Output;

            param[17] = new SqlParameter("@WEB_PATHURL", objUserBL.ADDRESS1);


            Connection.Get_Dataset("DSC_FLATFILE_INSERT_UPDATE", param);
            i=Convert.ToInt32(param[15].Value.ToString()); 
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return i;
    }
    public DataSet DSC_Flatfile_Select(UserBO objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@JOB_TYPE", objUserBL.File_Type);
            param[2] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
            param[3] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[4] = new SqlParameter("@Mflag", objUserBL.flag);


            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            ds=Connection.Get_Dataset("DSC_FLATFILE_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public DataSet IMP_Job_Mismatched_Data_Select()
    {
        DataSet ds_IV = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Branch_Common", Connection.Current_Branch());
            param[2] = new SqlParameter("@xml_sw_InfoType", Xml_A);
            param[3] = new SqlParameter("@xml_SupDOc", Xml_B);
            param[4] = new SqlParameter("@xml_SW_Stmt", Xml_C);
            param[5] = new SqlParameter("@xml_License", Xml_D);
            param[6] = new SqlParameter("@xml_Container", Xml_E);

            param[7] = new SqlParameter("@Flag", Flag);
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            ds_IV = Connection.Get_Dataset("IMP_JOB_MISMATCHED_DATA_SELECT", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_IV;
    }


    public DataSet Country_of_orgin_select()
    {
        DataSet ds_IV = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[6];
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Branch_Type", Branch_Type);

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            ds_IV = Connection.Get_Dataset("IMP_VALIDATION_ITEM", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_IV;
    }
    public DataSet SVB_Relation_select()
    {
        DataSet ds_IV = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[6];
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Branch_Type", Connection.Current_Branch());

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            ds_IV = Connection.Get_Dataset("IMP_VALIDATION_ITEM", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_IV;
    }
    public DataSet Re_Bond_Validation()
    {
        DataSet ds_IV = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[6];
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Branch_Type", Connection.Current_Branch());

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            ds_IV = Connection.Get_Dataset("IMP_VALIDATION_ITEM", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_IV;
    }
    public DataSet IMP_QUC_VALIDATION_SELECT()
    {
        DataSet ds_IV = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Branch_Type", Branch_Type);
            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@Flag", Flag);

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds_IV = Connection.Get_Dataset("IMP_VALIDATION_ITEM", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_IV;

    }
    public DataSet IMP_DATE_Validation()
    {
        DataSet ds_IV = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Branch_Type", Branch_Type);
            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@Flag", Flag);

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds_IV = Connection.Get_Dataset("IMP_VALIDATION_GEN_IGM", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_IV;
    }

}