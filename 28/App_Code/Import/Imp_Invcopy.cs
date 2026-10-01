using System;
using System.Linq;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;
using System.Web.UI;
using System.Web.UI.WebControls;

public class Imp_Invcopy
{
    public int result = 0, UPDATE_ID = 0;

    private string _Jobno, _Inv_slno, _Item_slno, _Flag, _Branch_Type, _User_id, _Inv_value, _Inv_date, _Inv_no, _MISC_tot_Amt
        , _FRT_Curr, _FRT_Exrate, _INS_Curr, _INS_Exrate, _HSS_tot_Amt, _Old_Jobno, _Cur_job, _Cur_invslno, _Old_invslno, _Tbl_Name, _WH_Jobno,
                   _chk_Freight, _chk_Insurance, _chk_Misc, _chk_HSS, _DB_Name;
    private string _Lic_Reg_No, _Priority_Type, _Copy_jobno, _Lic_Id, _JobNo_PS, _Scheme_Notn,_Scheme_Notn_Slno;
    
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string WH_Jobno { get { return _WH_Jobno; } set { _WH_Jobno = value; } }
    public string Inv_slno { get { return _Inv_slno; } set { _Inv_slno = value; } }
    public string Item_slno { get { return _Item_slno; } set { _Item_slno = value; } }
    public string MISC_tot_Amt { get { return _MISC_tot_Amt; } set { _MISC_tot_Amt = value; } }

    public string FRT_Curr { get { return _FRT_Curr; } set { _FRT_Curr = value; } }
    public string FRT_Exrate { get { return _FRT_Exrate; } set { _FRT_Exrate = value; } }
    public string INS_Curr { get { return _INS_Curr; } set { _INS_Curr = value; } }
    public string INS_Exrate { get { return _INS_Exrate; } set { _INS_Exrate = value; } }
    public string HSS_tot_Amt { get { return _HSS_tot_Amt; } set { _HSS_tot_Amt = value; } }

    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string User_id { get { return _User_id; } set { _User_id = value; } }
    public string Inv_value { get { return _Inv_value; } set { _Inv_value = value; } }
    public string Inv_date { get { return _Inv_date; } set { _Inv_date = value; } }
    public string Inv_no { get { return _Inv_no; } set { _Inv_no = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }
    public string Old_Jobno { get { return _Old_Jobno; } set { _Old_Jobno = value; } }
    public string Cur_job { get { return _Cur_job; } set { _Cur_job = value; } }

    public string Cur_invslno { get { return _Cur_invslno; } set { _Cur_invslno = value; } }
    public string Old_invslno { get { return _Old_invslno; } set { _Old_invslno = value; } }
    public string Tbl_Name { get { return _Tbl_Name; } set { _Tbl_Name = value; } }

    public string chk_Freight { get { return _chk_Freight; } set { _chk_Freight = value; } }
    public string chk_Insurance { get { return _chk_Insurance; } set { _chk_Insurance = value; } }
    public string chk_Misc { get { return _chk_Misc; } set { _chk_Misc = value; } }
    public string chk_HSS { get { return _chk_HSS; } set { _chk_HSS = value; } }
    public string DB_Name { get { return _DB_Name; } set { _DB_Name = value; } }

    public string Lic_Reg_No { get { return _Lic_Reg_No; } set { _Lic_Reg_No = value; } }
    public string Priority_Type { get { return _Priority_Type; } set { _Priority_Type = value; } }
    public string Copy_Job_No { get { return _Copy_jobno; } set { _Copy_jobno = value; } }
    public string Lic_Id { get { return _Lic_Id; } set { _Lic_Id = value; } }
    public string JobNo_Ps { get { return _JobNo_PS; } set { _JobNo_PS = value; } }
    public string Scheme_Notn { get { return _Scheme_Notn; } set { _Scheme_Notn = value; } }
    public string Scheme_Notn_Slno { get { return _Scheme_Notn_Slno; } set { _Scheme_Notn_Slno = value; } }

    public String Xml_D;

    DataSet ds = new DataSet();

    public DataSet Imp_Inv_Copy_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", Jobno);
            param[2] = new SqlParameter("@Tbl_Name", Tbl_Name);
            param[3] = new SqlParameter("@Inv_slno", Inv_slno);
            param[4] = new SqlParameter("@Item_slno", Item_slno);
            param[5] = new SqlParameter("@xmlString", Xml_D);

            param[6] = new SqlParameter("@Flag", Flag);
           // param[7] = new SqlParameter("@Branch_Type", Branch_Type);
            param[7] = new SqlParameter("@Branch_Type", Connection.Current_Branch());
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_INV_COPY", param);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public string Invoice_Item_Copy()
    {
        DataSet ds1 = new DataSet();
        string result = "";

        try
        {
            SqlParameter[] param = new SqlParameter[25];

            string[] arr = new string[] { };

            if (Inv_date != string.Empty && Inv_date != null)
            {
                arr = Inv_date.Split('/');
                Inv_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }

            param[0] = new SqlParameter("@Old_Jobno", Old_Jobno);
            param[1] = new SqlParameter("@Inv_no", Inv_no);
            param[2] = new SqlParameter("@Inv_slno", Inv_slno);
            param[3] = new SqlParameter("@Inv_date", Inv_date);
            param[4] = new SqlParameter("@Inv_value", Inv_value);
            param[5] = new SqlParameter("@Item_slno", Item_slno);
            param[6] = new SqlParameter("@Flag", Flag);
            param[7] = new SqlParameter("@USERID", User_id);
            param[8] = new SqlParameter("@Branch_Type", Branch_Type);
            param[9] = new SqlParameter("@Cur_job", Cur_job);

            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;

            //Connection.Get_Dataset("IMP_INV_COPY_ITEMS", param);
            //result = Convert.ToInt32(param[9].Value.ToString());

            ds1 = Connection.Get_Dataset("[IMP_INV_COPY_ITEMS]", param);
            result = ds1.Tables[0].Rows[0][0] + "," + param[9].Value.ToString();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    public int Item_Copy()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Cur_invslno", Cur_invslno);
            param[2] = new SqlParameter("@Old_invslno", Old_invslno);

            param[3] = new SqlParameter("@Item_slno", Item_slno);
            param[4] = new SqlParameter("@Flag", Flag);
            param[5] = new SqlParameter("@USERID", User_id);
            param[6] = new SqlParameter("@Branch_Type", Branch_Type);

            param[20] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[20].Direction = ParameterDirection.Output;
            param[21] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[21].Direction = ParameterDirection.Output;

            Connection.Get_Dataset("IMP_ITEMS_COPY", param);
            result = Convert.ToInt32(param[9].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
   
    public DataSet Imp_Multiple_Inv_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Inv_slno", Inv_slno);
            param[2] = new SqlParameter("@Item_slno", Item_slno);
            param[3] = new SqlParameter("@xmlString", Xml_D);
            param[4] = new SqlParameter("@Branch_Type", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Flag", Flag);
            param[6] = new SqlParameter("@User_id", Connection.Current_User());
            param[7] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[8] = new SqlParameter("@MISC_tot_Amt", MISC_tot_Amt);
            param[9] = new SqlParameter("@HSS_tot_Amt", HSS_tot_Amt);

            param[10] = new SqlParameter("@FRT_Curr", FRT_Curr);
            param[11] = new SqlParameter("@FRT_Exrate", FRT_Exrate);
            param[12] = new SqlParameter("@INS_Curr", INS_Curr);
            param[13] = new SqlParameter("@INS_Exrate", INS_Exrate);

            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            //ds = Connection.Get_Dataset("IMP_MULTIPLE_INVOICE_SPLIT_WITH_MISC_SPLIT", param);
            ds = Connection.Get_Dataset("IMP_MULTIPLE_INVOICE_SPLIT_WITH_MISC_SPLIT_HSS_SPLIT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Inv_Move_Re_Arrange(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Jobno", Connection.IMP_Jobno());
            param[2] = new SqlParameter("@Tbl_Name", Tbl_Name);
            param[3] = new SqlParameter("@Inv_slno", objUserBL.A1);
            param[4] = new SqlParameter("@Item_slno", objUserBL.A2);
            param[5] = new SqlParameter("@xmlString", Xml_D);
            param[6] = new SqlParameter("@Flag", objUserBL.A3);
            param[7] = new SqlParameter("@Branch_Type", Connection.Get_Company_Type());

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_INV_COPY", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Imp_License_View()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Inv_slno", Inv_slno);
            param[2] = new SqlParameter("@Item_slno", Item_slno);
            param[3] = new SqlParameter("@Flag", Flag);
            param[4] = new SqlParameter("@Branch_Type", Branch_Type);

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_LICENSE_VIEW", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet FTA_INS_UPD()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Inv_slno", Inv_slno);
            param[2] = new SqlParameter("@Item_slno", Item_slno);
            param[3] = new SqlParameter("@xmlString", Xml_D);
            param[4] = new SqlParameter("@Flag", Flag);
            param[5] = new SqlParameter("@Branch_code", Connection.Current_Branch());
            param[6] = new SqlParameter("@Branch_Type", Connection.Get_Company_Type());

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("FTA_IMP_INS_UPD", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Imp_Multiple_Inv_Select_XBE()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@WH_Jobno", WH_Jobno);
            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@DB_Name", DB_Name);
            param[4] = new SqlParameter("@chk_Freight", chk_Freight);
            param[5] = new SqlParameter("@chk_Insurance", chk_Insurance);
            param[6] = new SqlParameter("@chk_Misc", chk_Misc);
            param[7] = new SqlParameter("@chk_HSS", chk_HSS);

            param[8] = new SqlParameter("@Flag", Flag);
            param[9] = new SqlParameter("@User_id", Connection.Current_User());
            param[10] = new SqlParameter("@Branch_Type", Connection.Current_Branch());
            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("IMP_MULTIPLE_INVOICE_SPLIT_WITH_MISC_SPLIT_HSS_SPLIT_XBE", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

  
    public DataSet Imp_Lic_Copy_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Inv_slno", Inv_slno);
            param[2] = new SqlParameter("@Item_slno", Item_slno);
            param[3] = new SqlParameter("@xmlString", Xml_D);
            param[4] = new SqlParameter("@Branch_Type", Connection.Current_Branch());
            param[5] = new SqlParameter("@Flag", Flag);
            param[6] = new SqlParameter("@User_id", Connection.Current_User());
            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@Lic_Reg_No", Lic_Reg_No);
            param[9] = new SqlParameter("@Priority_Type", Priority_Type);
            param[10] = new SqlParameter("@CopyJobno", Copy_Job_No);
            param[11] = new SqlParameter("@Lic_Id", Lic_Id);
            param[12] = new SqlParameter("@Inv_No", Inv_no);
            param[13] = new SqlParameter("@JobNo_PS", JobNo_Ps);
            param[14] = new SqlParameter("@Scheme_Notn", Scheme_Notn);
            param[15] = new SqlParameter("@Scheme_Notn_Slno", Scheme_Notn_Slno);

            ds = Connection.Get_Dataset("IMP_LIC_COPY_SCHEME_PRIORITY_UPDATE", param);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }     
}