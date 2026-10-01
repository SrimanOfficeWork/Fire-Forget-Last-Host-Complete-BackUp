using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Despatch
{
    DataSet ds = new DataSet();
    public int result, UpdateId;
    
    private string _JOBNO,_FILE_REFNO, _COURIER_NAME, _PACKAGES,_PKGS_UNIT, _PORT_OF_DISCHARGE,   _DESCRIPTION, _OTHER_DESCRIPTION, _USERID, _STATUS, _BRANCHCODE, _WORKINGPERIOD, _flag;

    public string flag { get { return _flag; } set { _flag = value; } }
    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string FILE_REFNO { get { return _FILE_REFNO; } set { _FILE_REFNO = value; } }
    public string COURIER_NAME { get { return _COURIER_NAME; } set { _COURIER_NAME = value; } }
    public string PACKAGES { get { return _PACKAGES; } set { _PACKAGES = value; } }
    public string PKGS_UNIT { get { return _PKGS_UNIT; } set { _PKGS_UNIT = value; } }
    public string PORT_OF_DISCHARGE { get { return _PORT_OF_DISCHARGE; } set { _PORT_OF_DISCHARGE = value; } }
    public string DESCRIPTION { get { return _DESCRIPTION; } set { _DESCRIPTION = value; } }
    public string OTHER_DESCRIPTION { get { return _OTHER_DESCRIPTION; } set { _OTHER_DESCRIPTION = value; } }
    private string _ID,_MASTER_EXPORTER_NAME,_MODE,_R_ID,_REF_NAME,_EXPORTER_NAME, _TO_ADD1,_TO_ADD2,_WAYBILLNO,_LOGIN_DATE,_from_date,_todate,_R_Id,_Branch;
    public string R_Id { get { return _R_Id; } set { _R_Id = value; } }
    public string ID { get { return _ID; } set { _ID = value; } }
    public string MASTER_EXPORTER_NAME { get { return _MASTER_EXPORTER_NAME; } set { _MASTER_EXPORTER_NAME = value; } }
    public string MODE { get { return _MODE; } set { _MODE = value; } }
    public string R_ID { get { return _R_ID; } set { _R_ID = value; } }
    public string REF_NAME { get { return _REF_NAME; } set { _REF_NAME = value; } }
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string TO_ADD1 { get { return _TO_ADD1; } set { _TO_ADD1 = value; } }
    public string TO_ADD2 { get { return _TO_ADD2; } set { _TO_ADD2 = value; } }
    public string WAYBILLNO { get { return _WAYBILLNO; } set { _WAYBILLNO = value; } }
    public string LOGIN_DATE { get { return _LOGIN_DATE; } set { _LOGIN_DATE = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string from_date { get { return _from_date; } set { _from_date = value; } }
    public string todate { get { return _todate; } set { _todate = value; } }
    public string USERID { get { return _USERID; } set { _USERID = value; } }
    public string STATUS { get { return _STATUS; } set { _STATUS = value; } }
    public string BRANCHCODE { get { return _BRANCHCODE; } set { _BRANCHCODE = value; } }
    public string WORKINGPERIOD { get { return _WORKINGPERIOD; } set { _WORKINGPERIOD = value; } }

    public void EXPORT_Dispatch_Insert_Update()
    {
        SqlParameter[] param = new SqlParameter[35];

        param[0] = new SqlParameter("@ID", ID);
        param[1] = new SqlParameter("@MASTER_EXPORTER_NAME", MASTER_EXPORTER_NAME);
        param[2] = new SqlParameter("@MODE", MODE);
        param[3] = new SqlParameter("@R_ID", R_ID);
        param[4] = new SqlParameter("@REF_NAME", REF_NAME);
        param[5] = new SqlParameter("@JOBNO", JOBNO);
        param[6] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
        param[7] = new SqlParameter("@TO_ADD1", TO_ADD1);
        param[8] = new SqlParameter("@TO_ADD2", TO_ADD2);
        param[9] = new SqlParameter("@PORT_OF_DISCHARGE", PORT_OF_DISCHARGE);
        param[10] = new SqlParameter("@WAYBILLNO", WAYBILLNO);
        param[11] = new SqlParameter("@COURIER_NAME", COURIER_NAME);
        param[12] = new SqlParameter("@PACKAGES", PACKAGES);
        param[13] = new SqlParameter("@DESCRIPTION", DESCRIPTION);
        param[14] = new SqlParameter("@USERID", USERID);
        param[15] = new SqlParameter("@LOGIN_DATE", Connection.DATE_FORMAT(LOGIN_DATE == null ? "01/01/1900" : LOGIN_DATE));
        param[16] = new SqlParameter("@STATUS", STATUS);
        param[17] = new SqlParameter("@BRANCHCODE", BRANCHCODE);
        param[18] = new SqlParameter("@WORKINGPERIOD", WORKINGPERIOD);
        param[28] = new SqlParameter("@FILE_REF_NO", FILE_REFNO);

        param[23] = new SqlParameter("@flag", flag);
        param[24] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
        param[24].Direction = ParameterDirection.Output;

        param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[25].Direction = ParameterDirection.Output;

        param[26] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
        param[26].Direction = ParameterDirection.Output;

        param[27] = new SqlParameter("@Branch", Branch);

        Connection.Get_Dataset("EXPORT_DESPATCH_INS_UPD", param);
        result = Convert.ToInt32(param[24].Value.ToString());

        if (flag == "S")
        {
            UpdateId = Convert.ToInt32(param[26].Value.ToString());
        }
    }
     public DataSet Export_Despatch_Name()
     {
         try
         {
             SqlParameter[] param = new SqlParameter[15];
             param[0] = new SqlParameter("@Item_Id", ID);
             param[1] = new SqlParameter("@Exp_name", EXPORTER_NAME);
             param[2] = new SqlParameter("@Branch", BRANCHCODE);
             param[3] = new SqlParameter("@Flag", flag);
             param[4] = new SqlParameter("@Mode", MODE);
             param[7] = new SqlParameter("@Jobno", JOBNO);
             param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
             param[5].Direction = ParameterDirection.Output;
             param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[6].Direction = ParameterDirection.Output;

             ds = Connection.Get_Dataset("EXPORT_DESPATCH_SELECT", param);
             result = Convert.ToInt32(param[5].Value.ToString());
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
         return ds;
     }

     public DataSet EXPORT_DESPATCH_GENERAL_Search()
     {
         try
         {
             SqlParameter[] param = new SqlParameter[15];
             param[0] = new SqlParameter("@jobno", JOBNO);
             param[1] = new SqlParameter("@Shipper_name", EXPORTER_NAME);
             param[2] = new SqlParameter("@Ref_name", REF_NAME);
             param[3] = new SqlParameter("@from_date", Connection.Date(from_date));
             param[4] = new SqlParameter("@to_date", Connection.Date(todate));
             param[5] = new SqlParameter("@Branch", Branch);
             param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
             param[7].Direction = ParameterDirection.Output;
             ds = Connection.Get_Dataset("EXPORT_DESPATCH_GENERAL_SEARCH", param);
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
         return ds;
     }
    
    public DataSet Imp_Despatch_Select(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            
            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@File_Refno", objUserBL.File_Refno);
            param[3] = new SqlParameter("@Imp_name", objUserBL.Imp_Name);
            param[4] = new SqlParameter("@Branch_common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Flag", objUserBL.flag);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

            if (objUserBL.flag == "Imp_Despatch_Grid_Search")
            {
                param[6] = new SqlParameter("@from_date",Connection.Date(objUserBL.From_date));
                param[7] = new SqlParameter("@to_date", Connection.Date(objUserBL.Todate));
                ds = Connection.Get_Dataset("IMP_DESPATCH_SEARCH", param);
            }
            else
            {
                param[0] = new SqlParameter("@Item_Id",objUserBL.ITEM_ID );
                ds = Connection.Get_Dataset("IMPORT_DESPATCH_SELECT", param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Imp_Insert_Update(UserBO objUserBL)
    {
        SqlParameter[] param = new SqlParameter[35];

        param[0] = new SqlParameter("@DESPATCH_ID", objUserBL.ITEM_ID);
        param[1] = new SqlParameter("@JOBNO", objUserBL.JOBNO);
        param[2] = new SqlParameter("@FILE_REFNO", objUserBL.File_Refno);
        param[3] = new SqlParameter("@IMPORTER_NAME", objUserBL.Imp_Name);
        param[14] = new SqlParameter("@ADDRESS", objUserBL.ADDRESS1);

        param[4] = new SqlParameter("@INVOICE_DETAILS", objUserBL.INVOICE_NO);
        param[5] = new SqlParameter("@MAWB_NO", objUserBL.MAWB_NO);
        param[6] = new SqlParameter("@HAWB_NO", objUserBL.HAWB_NO);

        param[7] = new SqlParameter("@COURIER_NO", objUserBL.Courier_No);
        param[8] = new SqlParameter("@COURIER_DATE", objUserBL.Courier_Date);
        param[9] = new SqlParameter("@PACKAGES", objUserBL.Pkg);
        param[10] = new SqlParameter("@PKGS_UNIT", objUserBL.Pkg_Unit);
        param[11] = new SqlParameter("@GROSS_WEIGHT", objUserBL.Gross_Wgt);

        param[12] = new SqlParameter("@GROSS_WEIGHT_UNIT", objUserBL.Gross_Wgt_Unit);
        param[13] = new SqlParameter("@PORT_OF_LOADING", objUserBL.Port_of_Loading);
        param[15] = new SqlParameter("@INWARD_DATE", objUserBL.Inward_Date);
        param[16] = new SqlParameter("@CONATAINER_NO", objUserBL.Container_No);
        param[17] = new SqlParameter("@OTHER_DESCRIPTION", objUserBL.Other_Description);

        param[27] = new SqlParameter("@JOB_DATE", objUserBL.Jobdate);
        param[28] = new SqlParameter("@BE_NO", objUserBL.BE_No);
        param[29] = new SqlParameter("@BE_DATE", objUserBL.BE_Date);
        param[30] = new SqlParameter("@DESCRIPTION", objUserBL.Description);
        param[31] = new SqlParameter("@COURIER_NAME", objUserBL.Courier_Name);

        param[18] = new SqlParameter("@USERID", Connection.Current_User());
        param[19] = new SqlParameter("@Branch_Common", objUserBL.BRANCH_COMMON);
        param[20] = new SqlParameter("@BRANCHCODE", Connection.Current_Branch());
        param[21] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());

        param[23] = new SqlParameter("@Mflag", objUserBL.flag);
        param[24] = new SqlParameter("@Mstatus", SqlDbType.Int, 1);
        param[24].Direction = ParameterDirection.Output;

        param[25] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[25].Direction = ParameterDirection.Output;

        param[26] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
        param[26].Direction = ParameterDirection.Output;

        Connection.Get_Dataset("IMPORT_DESPATCH_INFORMATION_INS_UPD", param);
        result = Convert.ToInt32(param[24].Value.ToString());

        if (flag == "S")
        {
            UpdateId = Convert.ToInt32(param[26].Value.ToString());
        }
    }
}