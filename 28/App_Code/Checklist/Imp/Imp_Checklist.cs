using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;
using Microsoft.ApplicationBlocks.Data;

public class Imp_Checklist
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;

    public DataSet Get_Notifications_Rate (UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[2] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[3] = new SqlParameter("@flag", objUserBL.flag);
            
            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "GET_NOTIFICATIONS_RATE_CHECKLIST", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet GetData(string Jobno,string Inv_Slno,string flag)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[2] = new SqlParameter("@Jobno", Jobno);
            param[3] = new SqlParameter("@Inv_Slno", Inv_Slno);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@COMPANY_LICENSE", string.Empty);
            param[6] = new SqlParameter("@flag", flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_CHECKLIST_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    //public void Upload_JobHistory(string Jobno, string errorFolder ,string CID ,string SELECT_BRANCH)
    //{
    //    Job_Histroy jh = new Job_Histroy();
    //    jh.JOB_ID = "";
    //    jh.JOB_TYPE = "IMP";
    //    jh.COMPANY_ID = CID;
    //    jh.JOBNO = Jobno;
    //    jh.JOBDATE = "01/01/1900";
    //    jh.DESCRIPTION = errorFolder;
    //    jh.ATTACHMENT_FILE = Jobno + " ~~" + Jobno + ".pdf";
    //    jh.FLAG = "Upload_File";
    //    jh.USER_ID = Connection.Current_User();
    //    jh.BRANCH_CODE = Connection.Current_Branch();
    //    jh.YEAR = "";
    //    jh.WORKING_PERIOD = Connection.WorkingPeriod();
    //    jh.BRANCH_COMMON = SELECT_BRANCH;
    //    jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
    //}


    public void Upload_JobHistory(string Jobno, string errorFolder, string CID, string SELECT_BRANCH)
    {
        Job_Histroy jh = new Job_Histroy();
        jh.JOB_ID = "";
        jh.JOB_TYPE = "IMP";
        jh.COMPANY_ID = CID;
        jh.JOBNO = Jobno;
        jh.JOBDATE = "01/01/1900";
        jh.DESCRIPTION = errorFolder;
        jh.ATTACHMENT_FILE = Jobno + " ~~" + Jobno + ".pdf";
        jh.FLAG = "Upload_File";
        jh.USER_ID = Connection.Current_User();
        jh.BRANCH_CODE = Connection.Current_Branch();
        jh.YEAR = "";

        if (Connection.Ryal() != string.Empty)
        {
            jh.FLAG = "Upload_File_Ryal";
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            url = url.Substring(0, url.IndexOf("Report")) + errorFolder.Substring(errorFolder.IndexOf("Submission"), errorFolder.Length - errorFolder.IndexOf("Submission")) + jh.ATTACHMENT_FILE;
            jh.YEAR = url.Replace(@"\", @"/");
        }



        jh.WORKING_PERIOD = Connection.WorkingPeriod();
        jh.BRANCH_COMMON = SELECT_BRANCH;
        jh.IMP_EXP_JOB_HISTROY_INSERT_UPDATE();
    }


    public DataSet Import_Item_ASS_Duty_CIF_CVD_VLAUE_UPDATE(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[8];

            param[1] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[2] = new SqlParameter("@xmlString", objUserBL.Xml_D);
            param[3] = new SqlParameter("@flag", objUserBL.flag);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_CHECKLIST_ITEM_VALUE_UPDATE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet GetData_ChkListNew(string Jobno, string Inv_Slno, string flag)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[2] = new SqlParameter("@Jobno", Jobno);
            param[3] = new SqlParameter("@Inv_Slno", Inv_Slno);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@COMPANY_LICENSE", string.Empty);
            param[6] = new SqlParameter("@flag", flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_CHECKLIST_SELECT_HTMLVIEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }  
  


    public DataSet Get_Notifications_RateNewJun16_18(UserBO objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@jobno", objUserBL.JOBNO);
            param[1] = new SqlParameter("@cuinvslno", objUserBL.INVOICE_SLNO);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "GET_NOTIFICATIONS_RATE_CHECKLIST_HTMLVIEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public void Import_Item_ASS_ValueBulkUpdate(UserBO objUserBL, DataTable dtdata, string flag, string SP_Name)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@WORKING_PERIOD", Connection.Get_Company_Type());
            param[1] = new SqlParameter("@Mflag", flag);
            param[2] = new SqlParameter("@ChkListUpData", dtdata);
            param[3] = new SqlParameter("@Mstatus", SqlDbType.Int, 0);
            param[3].Direction = ParameterDirection.Output;
            //Connection.Get_Dataset("SP_IMPORT_ITEM_ASSVALUE_UPDATE_BULK_UDT", param);
            Connection.Get_Dataset(SP_Name, param);
            result = Convert.ToInt32(param[3].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet Get_Imp_ChkList_All_New(string Jobno, string Inv_Slno, string flag)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[2] = new SqlParameter("@Jobno", Jobno);
            param[3] = new SqlParameter("@Inv_Slno", Inv_Slno);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@COMPANY_LICENSE", string.Empty);
            param[6] = new SqlParameter("@flag", flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_CHECKLIST_SELECT_ALL_NEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet GETDATA_XMLCHECKLIST(string Jobno, string Inv_Slno, string Item_slno, string flag)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[2] = new SqlParameter("@Jobno", Jobno);
            param[3] = new SqlParameter("@Inv_Slno", Inv_Slno);
            param[7] = new SqlParameter("@Item_slno", Item_slno);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@COMPANY_LICENSE", string.Empty);
            param[6] = new SqlParameter("@flag", flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_CHECKLIST_XMLVIEW", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Get_Number_to_Words(string Amount)
    {
        DataSet ds_num = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Amount", Amount);

            ds_num = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "NumberToRupees_New", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds_num;
    }

    public DataSet Imp_Checklist_Open_Logs(string Jobno, string Ename)
    {
        DataSet ds1 = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@UserID", Connection.Current_User());
            param[2] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[3] = new SqlParameter("@Ename", Ename);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds1 = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMP_CHECKLIST_LOGS_SEARCH_SELECT", param);
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