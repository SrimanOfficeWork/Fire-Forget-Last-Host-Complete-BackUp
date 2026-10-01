using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.ApplicationBlocks.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Net;


public class Auto_Search
{
    DataTable dt = new DataTable();
    
    private string _Ename,_Enamesearch, _NSearch, _Notn_No_Search, _Slno ;
    private string _Flag, _Jobno, _Name_Search, _Branch, _IMP_EXP, _SHIPMENT_TYPE, _JobID, _Working_Period, _Notn_Type;
    public string _STANDARD_TYPE;

    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string Enamesearch { get { return _Enamesearch; } set { _Enamesearch = value; } }
    public string NSearch { get { return _NSearch; } set { _NSearch = value; } }
    public string Notn_No_Search { get { return _Notn_No_Search; } set { _Notn_No_Search = value; } }
    public string Slno { get { return _Slno; } set { _Slno = value; } }
    public string Notn_Type { get { return _Notn_Type; } set { _Notn_Type = value; } }


    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Name_Search { get { return _Name_Search; } set { _Name_Search = value; } }
    public string Branch { get { return _Branch; } set { _Branch = value; } }
    public string IMP_EXP { get { return _IMP_EXP; } set { _IMP_EXP = value; } }
    public string SHIPMENT_TYPE { get { return _SHIPMENT_TYPE; } set { _SHIPMENT_TYPE = value; } }
    public string JobID { get { return _JobID; } set { _JobID = value; } }
    public string Working_Period { get { return _Working_Period; } set { _Working_Period = value; } }
    public string STANDARD_TYPE{ get {  return _STANDARD_TYPE; } set {_STANDARD_TYPE = value; }}
     
    public DataSet RetrieveAll_AUTOCOMPLETE_SEARCH()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@Name_Search", Enamesearch);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@Notn_No_Search", Notn_No_Search);
            param[6] = new SqlParameter("@Notn_Type", Notn_Type);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_AUTOCOMPLETE_SEARCH_MASTER", param);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type()
    {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Name_Search", Enamesearch);
            param[5] = new SqlParameter("@NSearch", NSearch);
            param[6] = new SqlParameter("@STD_Type", STANDARD_TYPE);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            
            return ds = Value(Connection.Get_Dataset("SP_AUTOCOMPLETE_SEARCH_EROYAL_MASTER_STD_TYPE", param));
    }

    public DataSet ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type__USERWISE_IEC_SEARCH()
    {
        DataSet ds = new DataSet();
        SqlParameter[] param = new SqlParameter[12];
        param[1] = new SqlParameter("@Name_Search", Enamesearch);
        param[5] = new SqlParameter("@NSearch", NSearch);
        param[6] = new SqlParameter("@STD_Type", STANDARD_TYPE);
        param[2] = new SqlParameter("@name", Ename);
        param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
        param[3].Direction = ParameterDirection.Output;
        param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[4].Direction = ParameterDirection.Output;
        param[7] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());
        param[8] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
        param[9] = new SqlParameter("@JobType", SHIPMENT_TYPE);


        return ds = Value(Connection.Get_Dataset("SP_AUTOCOMPLETE_SEARCH_EROYAL_MASTER_STD_TYPE_USERWISE_IEC_BASED_SEARCH", param));
    }

    public DataSet ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Name_Search", Enamesearch);
            param[5] = new SqlParameter("@NSearch", NSearch);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            
           return ds = Value(Connection.Get_Dataset("SP_AUTOCOMPLETE_SEARCH_EROYAL_MASTER", param));
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_BILLING_OTHERS()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@Name_Search", Enamesearch);
            param[5] = new SqlParameter("@NSearch", NSearch);
            param[6] = new SqlParameter("@SlNo", Slno);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            return ds = Value(Connection.Get_Dataset("SP_AUTOCOMPLETE_SEARCH_BILLING_OTHERS", param));
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet ERoyalmaste_Retrieve_ADCode_Export()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@JOBID", JobID);
            param[1] = new SqlParameter("@JOBNO", Jobno);
            param[2] = new SqlParameter("@IMPORTER_NAME", STANDARD_TYPE);
            param[3] = new SqlParameter("@TRANSPORT_MODE", Enamesearch);
            param[4] = new SqlParameter("@CUSTOMS_HOUSE", NSearch);
            param[5] = new SqlParameter("@Working_Period", Working_Period);
            param[6] = new SqlParameter("@name", Ename);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
            return ds = Value(Connection.Get_Dataset("SP_GENERAL_DETAILS_SEARCH", param));
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);   
        }
        return ds;
    }

    public DataSet Export_Billing_Mastersearch()
    {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Name_Search", Name_Search);
            param[2] = new SqlParameter("@Jobno", Jobno);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Branch", Branch);
            param[5] = new SqlParameter("@SHIPMENT_TYPE", SHIPMENT_TYPE);
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            return ds = Value(Connection.Get_Dataset("BILL_INVOICE_MASTER_SEARCH", param));
    }
    public DataSet Import_Export_Genral_Search()
    {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Name_Search", Name_Search);
            param[2] = new SqlParameter("@Jobno", Jobno);

            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Branch", Branch);
            param[5] = new SqlParameter("@Type", IMP_EXP);
            param[6] = new SqlParameter("@COMPANYID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            return ds = Value(Connection.Get_Dataset("IMP_EXP_GENERAL_SEARCH", param));
    }

    public DataSet Import_Export_Genral_Search_USERWISE_IEC_SETTINGS()
    {
        DataSet ds = new DataSet();
        SqlParameter[] param = new SqlParameter[15];
        param[1] = new SqlParameter("@Name_Search", Name_Search);
        param[2] = new SqlParameter("@Jobno", Jobno);

        param[3] = new SqlParameter("@Flag", Flag);
        param[4] = new SqlParameter("@Branch", Branch);
        param[5] = new SqlParameter("@Type", IMP_EXP);
        param[6] = new SqlParameter("@COMPANYID", Connection.COMPANYID());
        param[7] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());


        param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[14].Direction = ParameterDirection.Output;
        return ds = Value(Connection.Get_Dataset("IMP_EXP_GENERAL_SEARCH_USERWISE_IEC_BASED_SEARCH", param));
    }

    public DataSet Paramount_Imp_Exp_Billing_General_Search()
    {
        DataSet ds = new DataSet();
        SqlParameter[] param = new SqlParameter[15];

        param[2] = new SqlParameter("@Cus_Name", Name_Search);
        param[3] = new SqlParameter("@Branch_No", Branch);
        param[4] = new SqlParameter("@Jobno", Jobno);
        param[5] = new SqlParameter("@Jobno_List", SHIPMENT_TYPE);
        param[6] = new SqlParameter("@Tr_mode", Slno);

        param[11] = new SqlParameter("@Flag", Flag);
        param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
        param[13] = new SqlParameter("@Company_Lic", Connection.Company_License());

        param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
        param[14].Direction = ParameterDirection.Output;
        /*
         if (Working_Period != null && Working_Period != string.Empty)
         {
             ds = Value(SqlHelper.ExecuteDataset(Connection.Get_Con_String(Working_Period), CommandType.StoredProcedure, "PARAMOUNT_BILLING_IMP_EXP_GENERAL_SEARCH", param));
         }
         else
         { 
         ds = Value(Connection.Get_Dataset("PARAMOUNT_BILLING_IMP_EXP_GENERAL_SEARCH", param));
         }
         */

        ds = Value(SqlHelper.ExecuteDataset(Db_Connection(STANDARD_TYPE, Working_Period), CommandType.StoredProcedure, "PARAMOUNT_BILLING_IMP_EXP_GENERAL_SEARCH", param));

        return ds;
    }
    public string Db_Connection(string com_lic, string wrk)
    {
        string Con_Val = string.Empty;
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@ID", "");
            param[2] = new SqlParameter("@Customer_Name", "");
            param[3] = new SqlParameter("@Branch_Common", "");
            param[4] = new SqlParameter("@Company_Lic", com_lic);
            param[5] = new SqlParameter("@Company_Id", "");
            param[6] = new SqlParameter("@Type", "");
            param[7] = new SqlParameter("@Flag", "DB_Name_Select");

            param[8] = new SqlParameter("@Server_Name", "");
            param[9] = new SqlParameter("@Login_Name", "");
            param[10] = new SqlParameter("@Login_Pwd", "");
            param[11] = new SqlParameter("@From_Databse", "");

            param[12] = new SqlParameter("@WorkingPeriod", Working_Period);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "AUTO_INSTAL_SELECT", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Con_Val = ds.Tables[0].Rows[0][1].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Con_Val;
    }

    public DataSet Get_IGST( string IGST_LEVY_NOTN,string IGST_LEVY_SLNO,string IGST_LEVY_EXCEPTION_NOTN
                  ,string IGST_LEVY_EXCEPTION_SLNO,string IGST_LEVY_COMPENSATION_CESS_NOTN,string IGST_LEVY_COMPENSATION_CESS_SLNO
                   , string IGST_LEVY_EXCEPTION_CC_NOTN, string IGST_LEVY_EXCEPTION_CC_SLNO, string flg)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@IGST_LEVY_NOTN", IGST_LEVY_NOTN);
            param[2] = new SqlParameter("@IGST_LEVY_SLNO", IGST_LEVY_SLNO);
            param[3] = new SqlParameter("@IGST_LEVY_EXCEPTION_NOTN", IGST_LEVY_EXCEPTION_NOTN);
            param[4] = new SqlParameter("@IGST_LEVY_EXCEPTION_SLNO", IGST_LEVY_EXCEPTION_SLNO);
            param[5] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_NOTN", IGST_LEVY_COMPENSATION_CESS_NOTN);
            param[6] = new SqlParameter("@IGST_LEVY_COMPENSATION_CESS_SLNO", IGST_LEVY_COMPENSATION_CESS_SLNO);
            param[7] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_NOTN", IGST_LEVY_EXCEPTION_CC_NOTN);
            param[8] = new SqlParameter("@IGST_LEVY_EXCEPTION_CC_SLNO", IGST_LEVY_EXCEPTION_CC_SLNO);
            param[9] = new SqlParameter("@name", flg);
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "IMPORT_IGST_SEARCH", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Import_Export_Genral_Search_FromDelBck()
    {
            DataSet ds = new DataSet();
       
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Name_Search", Name_Search);
            param[2] = new SqlParameter("@Jobno", Jobno);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Branch", Branch);
            param[5] = new SqlParameter("@Type", IMP_EXP);
            param[6] = new SqlParameter("@COMPANYID", Connection.COMPANYID());

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;

           return ds =Value(Connection.Get_Dataset("IMP_EXP_GENERAL_SEARCH_FROM_DELBCK", param));
    }
    public string Country_Master_FromClientSide_Calling(string custid, string name, string rows)
    {
        try
        {
            DataSet ds = new DataSet();
            Ename = name;

            Enamesearch = custid;
            NSearch = custid;

            ds = RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (name == "CETH_MASTER_RATE" && (custid == "27101949" || custid == "27101930" || custid == "27101290"))
                {
                    custid = ds.Tables[0].Rows[0]["CETH_CODE"].ToString() + "~~" + ds.Tables[0].Rows[0]["CETH_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["CETH_SPL_AMT"].ToString() + "~~" + ds.Tables[0].Rows[0]["CETH_SPL_UNIT"].ToString() + "~~" + ds.Tables[0].Rows[0]["CETH_SIA_I_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["CETH_CESS_AMTS"].ToString() + "~~" + ds.Tables[0].Rows[0]["CETH_CESS_UQC"].ToString() + "~~" + ds.Tables[0].Rows[0]["CETH_FLAG"].ToString();
                }
                else
                {
                    custid = ds.Tables[0].Rows[0][rows].ToString();
                }
                Ename = "1";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    public string SingleWindow_CTH_Code_FromClientSide_Calling(string custid, string name, string rows)
    {
        try
        {
            DataSet ds = new DataSet();
            Ename = name;
            Enamesearch = custid;
            NSearch = custid;
            ds = RetrieveAll_AUTOCOMPLETE_SEARCH();
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                custid = "";
                for (int i = 0; i <= count - 1; i++)
                {
                    custid += ds.Tables[0].Rows[i]["AGENCY_CODE"].ToString() + "  ";
                    Ename = "1";
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    public string SingleWindow_CTH_Code_FromClientSide_Calling_SplAmt(string custid, string name, string rows)
    {
        try
        {
            DataSet ds = new DataSet();
            Ename = name;
            Enamesearch = custid;
            NSearch = custid;
            ds = RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = ds.Tables[0].Rows[0]["CTH_SPL_AMT"].ToString() + "~~" + ds.Tables[0].Rows[0]["CTH_SPL_UNIT"].ToString() + "~~" + ds.Tables[0].Rows[0]["CTH_CODE"].ToString();
                Ename = "1";
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                custid += "~~" + ds.Tables[1].Rows[0]["CTH_STATUS"].ToString();
                Ename = "1";
            }
            else
            {
                custid += "~~" + " ";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return custid;
    }

    private DataSet Value(DataSet d)
    {
        try
        {
            if (d.Tables.Count > 0)
            {
                if (d.Tables[0].Rows.Count > 0)
                {
                }
                else
                {
                    d.Tables.Add(dt);
                }
            }
            else
            {
                d.Tables.Add(dt);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return d;
    }
    public DataSet RetrieveAll_AUTOCOMPLETE_SEARCH_PART_II()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@Name_Search", Enamesearch);
            param[2] = new SqlParameter("@name", Ename);
            param[3] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[3].Direction = ParameterDirection.Output;
            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;
            param[5] = new SqlParameter("@Notn_No_Search", Notn_No_Search);
            param[6] = new SqlParameter("@Notn_Type", Notn_Type);

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "SP_AUTOCOMPLETE_SEARCH_MASTER_PART_II", param);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dt);

            }
            else
                ds.Tables.Add(dt);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}