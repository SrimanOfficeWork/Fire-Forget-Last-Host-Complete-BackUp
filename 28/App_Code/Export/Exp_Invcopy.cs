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



public class Exp_Invcopy
{
    public int result = 0, UPDATE_ID = 0, Max_ItemSlno = 0, Max_Item_id = 0;

    private string _Jobno,_Inv_slno,_Item_slno,_Flag,_Branch_Type,_User_id,_Inv_value,_Inv_date,_Inv_no
                   , _Old_Jobno, _Cur_job, _Cur_invslno, _Old_invslno, _Working_period, _BranchCode, 
                   _Check_Type ,_DBK_Slno ,_Stmt_Code,_Selected_Value, _To_Stmt_Code ;
    
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Inv_slno { get { return _Inv_slno; } set { _Inv_slno = value; } }
    public string Item_slno { get { return _Item_slno; } set { _Item_slno = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string User_id { get { return _User_id; } set { _User_id = value; } }
    public string Inv_value { get { return _Inv_value; } set { _Inv_value = value; } }
    public string Inv_date { get { return _Inv_date; } set { _Inv_date = value; } }
    public string Inv_no { get { return _Inv_no; } set { _Inv_no = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }
    public string Working_period { get { return _Working_period; } set { _Working_period = value; } }
    public string BranchCode { get { return _BranchCode; } set { _BranchCode = value; } }
    public string Check_Type { get { return _Check_Type; } set { _Check_Type = value; } }

    public string DBK_Slno { get { return _DBK_Slno; } set { _DBK_Slno = value; } }
    public string Stmt_Code { get { return _Stmt_Code; } set { _Stmt_Code = value; } }
    public string To_Stmt_Code { get { return _To_Stmt_Code; } set { _To_Stmt_Code = value; } }

    
    public string Selected_Value { get { return _Selected_Value; } set { _Selected_Value = value; } }

    public string Old_Jobno { get { return _Old_Jobno; } set { _Old_Jobno = value; } }
    public string Cur_job { get { return _Cur_job; } set { _Cur_job = value; } }

    public string Cur_invslno { get { return _Cur_invslno; } set { _Cur_invslno = value; } }
    public string Old_invslno { get { return _Old_invslno; } set { _Old_invslno = value; } }
    public string FRT_tot_Amt { get; set; }
    public string FRT_Curr { get; set; }
    public string FRT_Exrate { get; set; }
    public string INS_AMT_RATE_FLAG { get; set; }
    public string INS_tot_Amt { get; set; }
    public string INS_Curr { get; set; }
    public string INS_Exrate { get; set; }
    public String Xml_D;

    DataSet ds = new DataSet();

    public DataSet Exp_Inv_Copy_Select()
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
            ds = Connection.Get_Dataset("EXP_INV_COPY", param);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    public int Invoice_Item_Copy()
    {
        DataSet ds = new DataSet();
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

            Connection.Get_Dataset("EXP_INV_COPY_ITEMS", param);
            result = Convert.ToInt32(param[9].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }
    //public int Item_Copy()

    public int Item_Copy()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@Old_Jobno", Jobno);
            param[1] = new SqlParameter("@Cur_job", Cur_job);
            param[2] = new SqlParameter("@Cur_invslno", Cur_invslno);
            //param[3] = new SqlParameter("@Inv_slno", Cur_invslno);
            param[4] = new SqlParameter("@Old_invslno", Old_invslno);
            param[5] = new SqlParameter("@Item_slno", Item_slno);
            param[6] = new SqlParameter("@Flag", Flag);
            param[7] = new SqlParameter("@USERID", User_id);
            param[8] = new SqlParameter("@Branch_Type", Branch_Type);
            param[11] = new SqlParameter("@Check_Type", Check_Type);

            param[9] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;
            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            param[12] = new SqlParameter("@MaxItemSlno", SqlDbType.NVarChar, 1000);
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@MaxItem_id", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXP_ITEMS_COPY", param);
            result = Convert.ToInt32(param[9].Value.ToString());
            Max_ItemSlno = Convert.ToInt32(param[12].Value.ToString());
            Max_Item_id = Convert.ToInt32(param[13].Value.ToString());

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return result;
    }

    // Add this method to Exp_Invcopy class
    public DataSet Exp_Multiple_Inv_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@xmlString", Xml_D ?? string.Empty);
            param[2] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[3] = new SqlParameter("@Branch", Connection.Current_Branch());
            param[4] = new SqlParameter("@User_id", Connection.Current_User());
            param[5] = new SqlParameter("@Flag", Flag);
            param[6] = new SqlParameter("@FRT_tot_Amt", FRT_tot_Amt ?? string.Empty);
            param[7] = new SqlParameter("@FRT_Curr", FRT_Curr ?? string.Empty);
            param[8] = new SqlParameter("@FRT_Exrate", FRT_Exrate ?? string.Empty);
            param[9] = new SqlParameter("@INS_tot_Amt", INS_tot_Amt ?? string.Empty);
            param[10] = new SqlParameter("@INS_Curr", INS_Curr ?? string.Empty);
            param[11] = new SqlParameter("@INS_Exrate", INS_Exrate ?? string.Empty);
            param[12] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, -1);
            param[12].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXP_MULTIPLE_INVOICE_SPLIT_FRT_INS", param);
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
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Inv_slno", Inv_slno);
            param[2] = new SqlParameter("@Item_slno", Item_slno);
            param[3] = new SqlParameter("@xmlString", Xml_D);
            param[4] = new SqlParameter("@Branch_Type", Connection.Get_Company_Type());
            param[5] = new SqlParameter("@Flag", Flag);
            param[6] = new SqlParameter("@User_id", Connection.Current_User());
            param[7] = new SqlParameter("@Branch", Connection.Current_Branch());

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_LIC_COPY", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
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

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("IMP_LIC_COPY", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

    public DataSet Exp_SW_STMT_DBK_DECL_BULK_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[16];
            param[1] = new SqlParameter("@Jobno", Connection.EXP_Jobno());
            param[2] = new SqlParameter("@Check_Type_Flag", Check_Type);
            param[3] = new SqlParameter("@Inv_slno", Inv_slno);
            param[4] = new SqlParameter("@Item_slno", Item_slno);
            param[5] = new SqlParameter("@STMT_CODE", Stmt_Code);
            param[6] = new SqlParameter("@TO_STMT_CODE", To_Stmt_Code);
            
            param[7] = new SqlParameter("@DBK_Slno", DBK_Slno);
            param[8] = new SqlParameter("@Selected_Value", Selected_Value);

            param[10] = new SqlParameter("@Branch_Code", Connection.Current_Branch());
            param[11] = new SqlParameter("@UserID", Connection.Current_User());
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Flag", Flag);
          
            param[14] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14].Direction = ParameterDirection.Output;
            param[15] = new SqlParameter("@MStatus", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXP_SW_STMT_DBK_DECL_BULK_UPLOAD", param);
            result = Convert.ToInt32(param[15].Value.ToString());
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
            param[0] = new SqlParameter("@Jobno", Connection.EXP_Jobno());
            param[1] = new SqlParameter("@Inv_slno", objUserBL.A1);
            param[2] = new SqlParameter("@Item_slno", objUserBL.A2);
            param[3] = new SqlParameter("@Flag", objUserBL.A3);
            param[4] = new SqlParameter("@Branch_Type",Connection.Get_Company_Type());

            param[11] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[11].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("EXP_INV_COPY", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}