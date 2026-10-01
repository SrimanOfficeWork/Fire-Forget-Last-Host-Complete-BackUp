using System;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
/// <summary>
/// Summary description for Settlement_cs
/// </summary>
public class Settlement_cs
{
    DataSet ds = new DataSet();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    private bool _Check = false;
    public bool Checked { get { return _Check; } set { _Check = value; } }

    public DataSet Settlement_Entry_Insert_Update(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[30];
            param[0] = new SqlParameter("@S_PF", "BS");
            param[1] = new SqlParameter("@S_SF", objUserBL.A1);
            param[2] = new SqlParameter("@Organization_Name", objUserBL.A2);
            if (string.IsNullOrEmpty(objUserBL.A3))
            {
                objUserBL.A3 = "01/01/1900";
            }
            param[3] = new SqlParameter("@Entry_Date", DateTime.Parse(objUserBL.A3, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            if (string.IsNullOrEmpty(objUserBL.A4))
            {
                objUserBL.A4 = "01/01/1900";
            }
            param[4] = new SqlParameter("@PostingDate", DateTime.Parse(objUserBL.A4, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));
            param[5] = new SqlParameter("@Settlement_Type", objUserBL.A5);
            param[6] = new SqlParameter("@TDS", objUserBL.A6);
            param[7] = new SqlParameter("@Narration", objUserBL.A7);
            param[8] = new SqlParameter("@Job_License", Connection.Company_License());
            param[9] = new SqlParameter("@Job_WorkingPeriod", Connection.WorkingPeriod());
            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@WorkingPeriod", Connection.WorkingPeriod());
            param[12] = new SqlParameter("@User", Connection.Current_User());
            param[13] = new SqlParameter("@BRANCH_COMMON", Connection.Get_Company_Type());
            param[14] = new SqlParameter("@XMLGVCredits", objUserBL.A8);
            param[15] = new SqlParameter("@XMLGVDebits", objUserBL.A9);

            param[20] = new SqlParameter("@flag", objUserBL.A10);
            param[21] = new SqlParameter("@Mstatus", SqlDbType.Int);
            param[21].Direction = ParameterDirection.Output;
            param[22] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
            param[22].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_SETTLEMENT_ENTRY_INSERT_UPDATE", param);
            objUserBL.A25 = param[21].Value.ToString();
            objUserBL.A26 = param[22].Value.ToString();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet LoadClientName(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@NameSearch", objUserBL.A1);

            param[1] = new SqlParameter("@startRowIndex", objUserBL.A2);
            param[2] = new SqlParameter("@maximumRows", objUserBL.A3);
            param[3] = new SqlParameter("@Flag", objUserBL.A4);
            param[4] = new SqlParameter("@totalRows", SqlDbType.Int);
            param[4].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("ACC_IMPEXP_GET_CLIENT_BY_GL", param);
            objUserBL.A5 = (param[4].Value != null && param[4].Value != DBNull.Value) ? param[4].Value.ToString() : "0";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet LoadbankPayamentByVendor(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@ORGANIZATION_NAME", objUserBL.A1);
            param[1] = new SqlParameter("@RowNumber", int.Parse(objUserBL.A2));
            param[2] = new SqlParameter("@SettlementType", objUserBL.A3);
            param[3] = new SqlParameter("@TranxFrom", string.IsNullOrEmpty(objUserBL.A4) ? (object)DBNull.Value : DateTime.Parse(objUserBL.A4));
            param[4] = new SqlParameter("@TranxTo", string.IsNullOrEmpty(objUserBL.A5) ? (object)DBNull.Value : DateTime.Parse(objUserBL.A5));

            ds = Connection.Get_Dataset("LOADBANK_PAYAMENT_BY_VENDOR", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet LoadSettlementEntrySearch(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@OrganizationName", objUserBL.A1);
            param[1] = new SqlParameter("@TransNo", objUserBL.A2);
            param[2] = new SqlParameter("@Narration", objUserBL.A3);
            param[3] = new SqlParameter("@startRowIndex", objUserBL.A4);
            param[4] = new SqlParameter("@maximumRows", objUserBL.A5);
            param[5]=new SqlParameter("@Flag",objUserBL.A6);
            param[6]=new SqlParameter("@NAME",objUserBL.A7);
            param[13] = new SqlParameter("@totalRows", SqlDbType.Int);
            param[13].Direction = ParameterDirection.Output;
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GET_ACC_GST_SETTLEMENT", param);
            objUserBL.A8 = (param[13].Value != null && param[13].Value != DBNull.Value) ? param[13].Value.ToString() : "0";
            objUserBL.A9 = param[14].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public DataSet LoadSettlementData(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@S_PF", objUserBL.A1);
            param[1] = new SqlParameter("@S_NO", objUserBL.A2);
            param[2] = new SqlParameter("@S_SF", objUserBL.A3);
            ds = Connection.Get_Dataset("SETLLEMENT_ENTRY_SEARCH_DATA_BIND", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }




    /* Report Params */
    public DataSet SettlementRpt_Params(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@SR_P", objUserBL.A1);
            param[1] = new SqlParameter("@SR_NO", objUserBL.A2);
            param[2] = new SqlParameter("@SR_S", objUserBL.A3);
            param[3] = new SqlParameter("@STYPE", objUserBL.A4);
            param[4] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@MFLAG", objUserBL.A10);

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1);
            param[6].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_SETTLEMENT_REPORT", param);    //ACC_SETTLEMENT_REPORT- PROCEDURE NAME
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}