using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class Dynamic_Report_GroupNew
{

    public int result = 0, UPDATE_ID = 0;
    DataSet ds = new DataSet();

    private string _T_ID, _TEMPLATE_NAME, _REPORT_COLUMN_NAME, _TR_MODE, _ACTIVE, _USER_ID, _BRANCH_CODE, _YEAR, _WORKING_PERIOD, _flag, _TYPE, _Select_Con, _Jobno,
    _Report_Name, _From_date, _To_date, _Report_Name_id, _Orderby, _Rpt_Type, _COL_NAME, _Select_Item, _IMP_EXP, _Imp_Name, _BE_Type, _SB_Type;

    public string COL_NAME { get { return _COL_NAME; } set { _COL_NAME = value; } }
    public string Select_Item { get { return _Select_Item; } set { _Select_Item = value; } }

    public string T_ID { get { return _T_ID; } set { _T_ID = value; } }
    public string TEMPLATE_NAME { get { return _TEMPLATE_NAME; } set { _TEMPLATE_NAME = value; } }
    public string REPORT_COLUMN_NAME { get { return _REPORT_COLUMN_NAME; } set { _REPORT_COLUMN_NAME = value; } }
    public string TR_MODE { get { return _TR_MODE; } set { _TR_MODE = value; } }
    public string ACTIVE { get { return _ACTIVE; } set { _ACTIVE = value; } }
    public string USER_ID { get { return _USER_ID; } set { _USER_ID = value; } }
    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string YEAR { get { return _YEAR; } set { _YEAR = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public string TYPE { get { return _TYPE; } set { _TYPE = value; } }
    public string Select_Con { get { return _Select_Con; } set { _Select_Con = value; } }

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Report_Name { get { return _Report_Name; } set { _Report_Name = value; } }
    public string Report_Name_id { get { return _Report_Name_id; } set { _Report_Name_id = value; } }

    public string From_date { get { return _From_date; } set { _From_date = value; } }
    public string To_date { get { return _To_date; } set { _To_date = value; } }

    public string Orderby { get { return _Orderby; } set { _Orderby = value; } }
    public string Rpt_Type { get { return _Rpt_Type; } set { _Rpt_Type = value; } }

    public string IMP_EXP { get { return _IMP_EXP; } set { _IMP_EXP = value; } }
    public string Imp_Name { get { return _Imp_Name; } set { _Imp_Name = value; } }

    public string BE_Type { get { return _BE_Type; } set { _BE_Type = value; } }
    public string SB_Type { get { return _SB_Type; } set { _SB_Type = value; } }



    public int Template_details_insertupdate(DataTable dt_list)
    {
        try
        {

            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@T_ID", T_ID);
            param[2] = new SqlParameter("@TEMPLATE_NAME", TEMPLATE_NAME);
            //param[3] = new SqlParameter("@REPORT_COLUMN_NAME", REPORT_COLUMN_NAME);
            param[3] = new SqlParameter("@Template_Table", dt_list);

            param[4] = new SqlParameter("@TR_MODE", TR_MODE);
            param[5] = new SqlParameter("@ACTIVE", ACTIVE);
            param[6] = new SqlParameter("@USER_ID", USER_ID);
            param[7] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[8] = new SqlParameter("@YEAR", YEAR);
            param[9] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[10] = new SqlParameter("@Mflag", flag);
            param[14] = new SqlParameter("@TYPE", TYPE);

            param[11] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[13].Direction = ParameterDirection.Output;

            //Connection.Get_Dataset("SP_DYNAMIC_TEMPLATE_INS_UPD", param);
            Connection.Get_Dataset("SP_DYNAMIC_TEMPLATE_INS_UPD_Group_New", param);
            result = Convert.ToInt32(param[11].Value.ToString());

            if (flag == "S")
            {
                UPDATE_ID = Convert.ToInt32(param[13].Value.ToString());
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return result;

    }

    public DataSet All_Record()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Type", TYPE);
            param[1] = new SqlParameter("@Mode", TR_MODE);
            param[2] = new SqlParameter("@Active", ACTIVE);
            param[3] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[4] = new SqlParameter("@Select_Con", Select_Con);
            param[7] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());


            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            //ds = Connection.Get_Dataset("SP_DYNAMIC_TABLE_SELECT_Group_New", param);
            ds = Connection.Get_Dataset("SP_DYNAMIC_TABLE_SELECT_Group_New_USERWISE_IEC_BASED_SEARCH", param);

            result = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    
    public DataSet Report_data()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@Jobno", Jobno = Jobno == " " ? string.Empty : Jobno);
            param[1] = new SqlParameter("@from_date", From_date);
            param[2] = new SqlParameter("@to_date", To_date);
            //param[3] = new SqlParameter("@Branch", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@Branch", BRANCH_CODE);
            param[4] = new SqlParameter("@Report_Name", Report_Name);
            param[5] = new SqlParameter("@Report_Name_id", Report_Name_id);
            param[6] = new SqlParameter("@Orderby", Orderby);
            param[7] = new SqlParameter("@Rpt_Type", Rpt_Type);
            param[8] = new SqlParameter("@Imp_Name", Imp_Name);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@BE_Type", BE_Type);

            ds = Connection.Get_Dataset("IMP_CUSTOMIZATION_RPT_GROUP_NEW", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Dynamic_Rpt()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[1] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[2] = new SqlParameter("@COL_NAME", COL_NAME);
            param[3] = new SqlParameter("@Select_Item", Select_Item);
            param[4] = new SqlParameter("@flag", flag);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            if (IMP_EXP == "Import")
            {
                ds = Connection.Get_Dataset("sp_Manual_Rpt_Group_New", param);
                //ds = Connection.Get_Dataset("sp_Manual_Rpt", param);
            }
            else if (IMP_EXP == "Export")
            {
                //ds = Connection.Get_Dataset("EXP_sp_Manual_Rpt", param);
                ds = Connection.Get_Dataset("EXP_sp_Manual_Rpt_Group_New", param);
            }
            result = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet DSR_DynamicRpt()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];

            param[0] = new SqlParameter("@T_ID", T_ID);
            param[1] = new SqlParameter("@TEMPLATE_NAME", TEMPLATE_NAME);
            param[2] = new SqlParameter("@REPORT_COLUMN_NAME", REPORT_COLUMN_NAME);
            param[3] = new SqlParameter("@ACTIVE", ACTIVE);
            param[4] = new SqlParameter("@TYPE", TYPE);
            param[5] = new SqlParameter("@USER_ID", USER_ID);
            param[6] = new SqlParameter("@BRANCH_CODE", BRANCH_CODE);
            param[7] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[8] = new SqlParameter("@Mflag", flag);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            param[11] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[11].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("DSR_DYNAMIC_RPT_SP", param);
            //result = Convert.ToInt32(param[9].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }



    public DataSet Exp_Report_data()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[18];
            param[0] = new SqlParameter("@Jobno", Jobno = Jobno == " " ? string.Empty : Jobno);
            param[1] = new SqlParameter("@from_date", From_date);
            param[2] = new SqlParameter("@to_date", To_date);
            param[3] = new SqlParameter("@Branch", BRANCH_CODE);
            param[4] = new SqlParameter("@Report_Name", Report_Name);
            param[5] = new SqlParameter("@Report_Name_id", Report_Name_id);
            param[6] = new SqlParameter("@Orderby", Orderby);
            param[7] = new SqlParameter("@Rpt_Type", Rpt_Type);
            param[8] = new SqlParameter("@Exp_name", Imp_Name);
            param[9] = new SqlParameter("@SB_Type", SB_Type);
            param[10] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXP_CUSTOMIZATION_RPT_BRANCH_Group_New", param);
           
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
}