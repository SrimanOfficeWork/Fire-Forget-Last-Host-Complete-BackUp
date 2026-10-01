using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;
using System.Collections.Generic;
using Microsoft.ApplicationBlocks.Data;

public class Exp_ETP
{
    DataSet ds = new DataSet();
    public int result, UPDATE_ID = 0;
    public string Xml_A;
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    public DataSet ETP_Data_Select(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[1] = new SqlParameter("@M_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);

            param[6] = new SqlParameter("@Flag", objUserBL.A40);
            param[7] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[8] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("EXPORT_ETP_MASTER_CONTAINER_DETAILS_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet ETP_Master_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[41];
            param[1] = new SqlParameter("@M_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@JOBNO_PS", objUserBL.A3);
            if (objUserBL.A4 == "" || objUserBL.A4 == null)
            {
                objUserBL.A4 = "01/01/1900";
            }
            param[4] = new SqlParameter("@JOBDATE", Connection.DATE_FORMAT(objUserBL.A4));
            param[5] = new SqlParameter("@SB_NO", objUserBL.A5);
            if (objUserBL.A6 == "" || objUserBL.A6 == null)
            {
                objUserBL.A6 = "01/01/1900";
            }
            param[6] = new SqlParameter("@SB_DATE", Connection.DATE_FORMAT(objUserBL.A6));
            if (objUserBL.A7 == "" || objUserBL.A7 == null)
            {
                objUserBL.A7 = "01/01/1900";
            }
            param[7] = new SqlParameter("@TRANSSHIPMENT_DATE", Connection.DATE_FORMAT(objUserBL.A7));
            param[8] = new SqlParameter("@GATEWAY_PORT", objUserBL.A8);
            param[9] = new SqlParameter("@PORT_DISCHARGE", objUserBL.A9);
            param[10] = new SqlParameter("@TR_MODE", objUserBL.A10);
            param[11] = new SqlParameter("@CARRIER_CODE", objUserBL.A11);
            param[12] = new SqlParameter("@CARRIER_NO", objUserBL.A12);
            param[13] = new SqlParameter("@GROSS_WGT", objUserBL.A13);
            param[14] = new SqlParameter("@TOTAL_PKG", objUserBL.A14);
            param[15] = new SqlParameter("@NATURE_OF_CARGO", objUserBL.A15);
           
            param[16] = new SqlParameter("@BOND_CODE", objUserBL.A16);
            param[17] = new SqlParameter("@BOND_NO", objUserBL.A17);
            if (objUserBL.A18 == "" || objUserBL.A18 == null)
            {
                objUserBL.A18 = "01/01/1900";
            }
            param[18] = new SqlParameter("@BOND_DATE", Connection.DATE_FORMAT(objUserBL.A18));
            param[19] = new SqlParameter("@BOND_SITE", objUserBL.A19);

            param[20] = new SqlParameter("@SITE_ID", objUserBL.A20);
            param[21] = new SqlParameter("@AWB_NO", objUserBL.A21);
            param[22] = new SqlParameter("@STUFF_PORT", objUserBL.A22);
            param[23] = new SqlParameter("@TRANSSHIPMENT_NO", objUserBL.A23);

            param[34] = new SqlParameter("@Flag", objUserBL.A40);
            param[35] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[36] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[37] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[38] = new SqlParameter("@User_Name", Connection.Current_User());

            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("EXPORT_ETP_MASTER_DETAILS_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet ETP_Container_Ins_Upd(Global_variables objUserBL)
    {
        try
        {
            //EXPORT_ETP_CONTAINER_DETAILS
            SqlParameter[] param = new SqlParameter[41];
            param[1] = new SqlParameter("@C_ID", objUserBL.A1);
            param[2] = new SqlParameter("@JOBNO", objUserBL.A2);
            param[3] = new SqlParameter("@JOBNO_PS", objUserBL.A3);
            if (objUserBL.A4 == "" || objUserBL.A4 == null)
            {
                objUserBL.A4 = "01/01/1900";
            }
            param[4] = new SqlParameter("@JOBDATE", Connection.DATE_FORMAT(objUserBL.A4));
            param[5] = new SqlParameter("@SB_NO", objUserBL.A5);
            if (objUserBL.A6 == "" || objUserBL.A6 == null)
            {
                objUserBL.A6 = "01/01/1900";
            }
            param[6] = new SqlParameter("@SB_DATE", Connection.DATE_FORMAT(objUserBL.A6));
            param[7] = new SqlParameter("@CON_NO", objUserBL.A7);
            param[8] = new SqlParameter("@CON_SIZE", objUserBL.A8);
            param[9] = new SqlParameter("@LCL_FCL", objUserBL.A9);
            param[10] = new SqlParameter("@SITE_ID", objUserBL.A10);

            param[34] = new SqlParameter("@Flag", objUserBL.A40);
            param[35] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[36] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[37] = new SqlParameter("@WORKINGPERIOD", Connection.WorkingPeriod());
            param[38] = new SqlParameter("@User_Name", Connection.Current_User());

            param[40] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[40].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("EXPORT_ETP_CONTAINER_DETAILS_INS_UPD", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_ETP_Details(UserBO Obj)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];

            param[0] = new SqlParameter("@JOBNO", Obj.JOBNO);
            param[2] = new SqlParameter("@CONTAINER_NO", Obj.Container_No);
            param[3] = new SqlParameter("@Ename", Obj.Ename);
            param[4] = new SqlParameter("@TRANSSHIPMENT_NO", Obj.TRANSSHIPMENT_NO);
            param[5] = new SqlParameter("@GATEWAY_PORT", Obj.GATEWAY_PORT);
            param[6] = new SqlParameter("@MODE_OF_TRANSPORT", Obj.MODE_OF_TRANSPORT);
            param[7] = new SqlParameter("@CARRIER_NO", Obj.CARRIER_NO);

            if (!string.IsNullOrEmpty(Obj.From_date))
                param[8] = new SqlParameter("@FROM_DATE", DateTime.Parse(Convert.ToString(Obj.From_date), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[8] = new SqlParameter("@FROM_DATE", Obj.From_date);
            }
            if (!string.IsNullOrEmpty(Obj.Todate))
                param[9] = new SqlParameter("@TO_DATE", DateTime.Parse(Convert.ToString(Obj.Todate), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            else
            {
                param[9] = new SqlParameter("@TO_DATE", Obj.Todate);
            }
            //param[10] = new SqlParameter("@ETA", Obj.ETA);
            param[11] = new SqlParameter("@ACTION", Obj.action);
            param[12] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
            param[13] = new SqlParameter("@USER_ID", Connection.Current_User());
            param[14] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;


            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_ETP_SEARCH_SELECT", param);
            result = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }

    public DataSet RetrieveAll_ETP_Details_Select(UserBO Obj)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBNO", Obj.JOBNO);
            param[1] = new SqlParameter("@name", Obj.Ename);
            param[2] = new SqlParameter("@Working_Period", Obj.WORKING_PERIOD);

            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "EXPORT_ETP_AUTO_SEARCH", param);
            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_CHECKLIST_SEARCH_Loading_Slow_Checking", param);

            if (!String.IsNullOrEmpty(param[3].Value.ToString()))
            {
                result = Convert.ToInt32(param[3].Value.ToString());
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }

    public DataSet RetrieveAll_AUTOCOMPLETE_ETP_SEARCH(UserBO Obj)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@Name_Search", Obj.Name_Search);
            param[2] = new SqlParameter("@name", Obj.Ename);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            //ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_AUTOCOMPLETE_SEARCH_ETP", param);
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure,"SP_AUTOCOMPLETE_SEARCH_ETP", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}