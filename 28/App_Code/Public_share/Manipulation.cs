using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Manipulation
/// </summary>
public class Manipulation :ErrorLogs
{
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds;
    //SqlConnection con;
    public bool AVAIL = false;

    # region Supplier Master
    public string sup_name = "";
    public string sup_add1 = "";
    public string sup_add2 = "";
    public string sup_add3 = "";
    public string sup_countryname = "";
    public string sup_countrycode = "";
    public string sup_pincode = "";
    public string sup_remarks = "";
   # endregion

    # region Consignee Master
    public string Con_name = "";
    public string Con_add1 = "";
    public string Con_add2 = "";
    public string Con_add3 = "";
    public string Con_countryname = "";
    public string Con_countrycode = "";
    public string Con_pincode = "";
    public string Con_remarks = "";
    # endregion

    # region Client Master(IMP_EXP_Master)
    public string IMP_EXP_NAME = "";
    public string IMP_EXP_IECNO = "";
    public string IMP_EXP_BRSLNO = "";
    public string IMP_EXP_TYPE = "";
    public string IMP_EXP_ADD1 = "";
    public string IMP_EXP_ADD2 = "";
    public string IMP_EXP_ADD3 = "";
    public string IMP_EXP_ADD4 = "";
    public string IMP_EXP_PIN_CODE = "";
    public string IMP_EXP_CONTACT_PERSON = "";
    public string IMP_EXP_PHONE = "";
    public string IMP_EXP_FAX = "";
    public string IMP_EXP_EMAIL = "";
    public string IMP_EXP_BINNO = "";
    public string IMP_EXP_REMARKS = "";   
    
    # endregion

    # region Adcode Master
    public string ADCODE_IEC_CODE = "";
    public string ADCODE_IEC_NAME = "";
    public string ADCODE_IEC_ADCODE = "";
    public string ADCODE_BANK_NAME = "";
    public string ADCODE_BANK_ACCOUNT_NO = "";
    public string ADCODE_BANK_ADD1 = "";
    public string ADCODE_BANK_ADD2 = "";
    public string ADCODE_BANK_CITY = "";
    public string ADCODE_BANK_STATE = "";
    public string ADCODE_BANK_PIN_CODE = "";
    public string ADCODE_REMARKS = "";
  
    # endregion
    
    # region Exchange Master

    public string EXCHANGE_EFFECT_DT_FROM = "";
    public string EXCHANGE_EFFECT_DT_TO = "";
    public string EXCHANGE_NONT_NO = "";
    public string EXCHANGE_NOTN_DATE = "";
    public string EXCHANGE_CUR_CODE = "";
    public string EXCHANGE_NAME = "";
    public string EXCHANGE_PER_UNIT = "";
    public string EXCHANGE_RATE_IMPORT = "";
    public string EXCHANGE_RATE_EXPORT = "";
    public string EXCHANGE_S_OR_N = "";
 
    # endregion
    
    # region Product Import Master


public string PRODUCT_DESCRIPTION= "";
public string PRODUCT_CODE= "";
public string PRODUCT_RITC= "";
public string PRODUCT_CTH= "";
public string PRODUCT_BCD_NOTN= "";
public string PRODUCT_BCD_SLNO= "";
public string PRODUCT_BCD_RATE= "";
public string PRODUCT_BCD_SPL= "";
public string PRODUCT_BCD_UNIT= "";
public string PRODUCT_BCD_SPL_TYPE= "";
public string PRODUCT_ADDL_DUTY_NOTN= "";
public string PRODUCT_ADDL_DUTY_NOTN_SL= "";
public string PRODUCT_EDU_CESS_NOTN= "";
public string PRODUCT_EDU_CESS_NOTN_SL= "";
public string PRODUCT_EDU_CESS_RATE= "";
public string PRODUCT_SEC_EDU_CESS_NOTN= "";
public string PRODUCT_SEC_EDU_CESS_NOTN_SL= "";
public string PRODUCT_SEC_EDU_CESS_RATE= "";
public string PRODUCT_NCD_NOTN= "";
public string PRODUCT_NCD_SLNO= "";
public string PRODUCT_NCD_RATE= "";
public string PRODUCT_NCD_SPL= "";
public string PRODUCT_NCD_UNIT= "";
public string PRODUCT_NCD_SPL_TYPE= "";
public string PRODUCT_AGGREGATE_DUTY_NOTN= "";
public string PRODUCT_AGGREGATE_DUTY_NOTN_SL= "";
public string PRODUCT_AGGREGATE_DUTY_NOTN_RATE= "";
public string PRODUCT_SAFEGUARD_NOTN= "";
public string PRODUCT_SAFEGUARD_SLNO= "";
public string PRODUCT_SAFEGUARD_RATE= "";
public string PRODUCT_SAFEGUARD_SPL= "";
public string PRODUCT_SAFEGUARD_UNIT= "";
public string PRODUCT_SAFEGUARD_SPL_TYPE= "";
public string PRODUCT_CETH= "";
public string PRODUCT_MRP_YN= "";
public string PRODUCT_MRP_SL_NO= "";
public string PRODUCT_MRP_AMOUNT= "";
public string PRODUCT_MRP_ABT_RATE= "";
public string PRODUCT_CVD_NOTN= "";
public string PRODUCT_CVD_SLNO= "";
public string PRODUCT_CVD_RATE= "";
public string PRODUCT_CVD_SPL= "";
public string PRODUCT_CVD_UNIT= "";
public string PRODUCT_CVD_SPL_TYPE= "";
public string PRODUCT_CVD_EDU_CESS_RATE= "";
public string PRODUCT_CVD_SEC_EDU_CESS_RATE= "";
public string PRODUCT_ADDL5_SIA_NOTN= "";
public string PRODUCT_ADDL5_SIA_NOTN_SL= "";
public string PRODUCT_ADDL5_SIA_RATE= "";
public string PRODUCT_ADDL_GSI_NOTN= "";
public string PRODUCT_ADDL_GSI_SLNO= "";
public string PRODUCT_ADDL_GSI_RATE= "";
public string PRODUCT_ADDL_GSI_SPL= "";
public string PRODUCT_ADDL_GSI_UNIT= "";
public string PRODUCT_ADDL_GSI_SPL_TYPE= "";
public string PRODUCT_ADDL_SHEII_NOTN= "";
public string PRODUCT_ADDL_SHEII_SLNO= "";
public string PRODUCT_ADDL_SHEII_RATE= "";
public string PRODUCT_ADDL_SHEII_SPL= "";
public string PRODUCT_ADDL_SHEII_UNIT= "";
public string PRODUCT_ADDL_SHEII_TYPE= "";
public string PRODUCT_ADDL_TTA_NOTN= "";
public string PRODUCT_ADDL_TTA_SLNO= "";
public string PRODUCT_ADDL_TTA_RATE= "";
public string PRODUCT_ADDL_TTA_SPL= "";
public string PRODUCT_ADDL_TTA_UNIT= "";
public string PRODUCT_ADDL_TTA_TYPE= "";
public string PRODUCT_ADDL_HEALTH_CESS_NOTN= "";
public string PRODUCT_ADDL_HEALTH_CESS_SLNO= "";
public string PRODUCT_ADDL_HEALTH_CESS_RATE= "";
public string PRODUCT_ADDL_HEALTH_CESS_SPL= "";
public string PRODUCT_ADDL_HEALTH_CESS_UNIT= "";
public string PRODUCT_ADDL_HEALTH_CESS_TYPE= "";
public string PRODUCT_CESS_NOTN= "";
public string PRODUCT_CESS_SLNO= "";
public string PRODUCT_CESS_RATE= "";
public string PRODUCT_CESS_SPL= "";
public string PRODUCT_CESS_UNIT= "";
public string PRODUCT_CESS_TYPE= "";
public string PRODUCT_GENERAL_DESC= "";
public string PRODUCT_MANUFACTURER= "";
public string PRODUCT_BRAND= "";
public string PRODUCT_MODEL= "";
public string PRODUCT_END_USE= "";
public string PRODUCT_COUNTRY_ORIGIN= "";
public string PRODUCT_ACCESSORIES= "";
public string PRODUCT_REMARKS= "";
//public string PRODUCT_USER_ID= "";
//public string PRODUCT_DATE_TIME= "";
//public string PRODUCT_STATUS= "";
//public string PRODUCT_BRANCH_CODE= "";
//public string PRODUCT_YEAR = "";
   

    # endregion




    int A1, A2;
    //string userid;

    SqlCommand cmd;
    //SqlConnection con = new SqlConnection();
	SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
  

# region ClearFunction
     public void ResetFields(ControlCollection pageControls)
     {
         foreach (Control contl in pageControls)
         {
             string strCntName = (contl.GetType()).Name;
             switch (strCntName)
             {
                 case "TextBox":
                     TextBox tbSource = (TextBox)contl;
                     tbSource.Text = "";
                     break;
                 //case "RadioButtonList":
                 //    RadioButtonList rblSource = (RadioButtonList)contl;
                 //    rblSource.SelectedIndex = -1;
                 //    break;
                 case "DropDownList":
                     DropDownList ddlSource = (DropDownList)contl;
                     ddlSource.SelectedIndex = -1;
                   
                     break;

                 case "CheckBox":
                     CheckBox chkSource = (CheckBox)contl;
                     chkSource.Checked = false;
                     break;

             }

             ResetFields(contl.Controls);
         }
     }
# endregion

# region Insert,Update,Delete

     public int tbmanipulate(string commandText,string ConStr)
    {
        con = new SqlConnection(ConStr);
        int i = 0;
        con.Open();
        
        try
        {
            cmd = new SqlCommand(commandText, con);
            i = cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        con.Close();
        return i;
    }


     public void MASTER_CODE_AVAIL(string query,string ConStr)
     {
         try
         {
             con = new SqlConnection(ConStr);
             con.Open();
             cmd = new SqlCommand(query, con);
             dr = cmd.ExecuteReader();
             dr.Read();
             if (dr.HasRows)
             {
                 AVAIL = true;
             }
             else
             {
                 AVAIL = false;
             }
             dr.Close();
             con.Close();
         }
         catch (Exception ex)
         {
             makeLog(ex.Message);
         }
     }

     //public int tbmanipulate_Without_WorkingPeriod(string commandText)
     //{
         
     //    int i = 0;
     //    con.Open();

     //    try
     //    {
     //        cmd = new SqlCommand(commandText, con);
     //        i = cmd.ExecuteNonQuery();

     //    }
     //    catch (Exception ex)
     //    {
     //        makeLog(ex.Message);
     //    }
     //    con.Close();
     //    return i;
     //}
# endregion

     #region AutoIncrementID
     public int RetrieveID(string SP_QUERY, string ConStr, string Working_Period)
    {
       
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            cmd = new SqlCommand(SP_QUERY, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    A1 = Convert.ToInt32(dr[0].ToString());
                    A2 = Convert.ToInt32(A1 + 1);
                    //userid = A2.ToString();
                }
                else
                {
                    A2 = 1;
                    //userid = "1";

                }
            }
            else
            {
                A2 = 1;
                //userid = "1";
            }
           
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return A2;
    }
     #endregion
    

     public int SUPPLIER_All_BIND(string query, string STR, string ConStr, string Working_Period)
    {
        int i = 0;
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUP_ID", STR);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                sup_name = dr["SUP_NAME"].ToString();
                sup_add1 = dr["SUP_ADD1"].ToString();
                sup_add2 = dr["SUP_ADD2"].ToString();
                sup_add3 = dr["SUP_ADD3"].ToString();
                sup_countryname = dr["SUP_COUNTRY_NAME"].ToString();
                sup_countrycode = dr["SUP_COUNTRY_CODE"].ToString();
                sup_pincode = dr["SUP_PIN_CODE"].ToString();
                sup_remarks = dr["SUP_REMARKS"].ToString();


            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

     public DataSet RetrieveAll_SUPPLIER_LIKE(string SP_NAME, string SP_CON, string ConStr, string Working_Period)
    {
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SUP_NAME", SP_CON);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public DataSet RetrieveAll_CONSIGNEE_LIKE(string SP_NAME, string SP_CON, string ConStr, string Working_Period)
    {
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CONSIGNEE_NAME", SP_CON);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return ds;

    }


    public int CONSIGNEE_All_BIND(string query, string STR, string ConStr, string Working_Period)
    {
        int i = 0;
        try
        {

            con = new SqlConnection(ConStr);
           
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CONSIGNEE_ID", STR);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                Con_name = dr["CONSIGNEE_NAME"].ToString();
                Con_add1 = dr["CONSIGNEE_ADD1"].ToString();
                Con_add2 = dr["CONSIGNEE_ADD2"].ToString();
                Con_add3 = dr["CONSIGNEE_ADD3"].ToString();
                Con_countryname = dr["CONSIGNEE_COUNTRY_NAME"].ToString();
                Con_countrycode = dr["CONSIGNEE_COUNTRY_CODE"].ToString();
                Con_pincode = dr["CONSIGNEE_PIN_CODE"].ToString();
                Con_remarks = dr["CONSIGNEE_REMARKS"].ToString();


            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public DataSet RetrieveAll_IMP_EXP_LIKE(string SP_NAME, string SP_CON, string ConStr, string Working_Period)
    {
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IMP_EXP_NAME", SP_CON);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public int IMP_EXP_All_BIND(string query, string STR, string ConStr, string Working_Period)
    {
        int i = 0;
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IMP_EXP_ID", STR);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {


                IMP_EXP_NAME = dr["IMP_EXP_NAME"].ToString();
                IMP_EXP_IECNO = dr["IMP_EXP_IECNO"].ToString();
                IMP_EXP_BRSLNO = dr["IMP_EXP_BRSLNO"].ToString();
                IMP_EXP_TYPE = dr["IMP_EXP_TYPE"].ToString();
                IMP_EXP_ADD1 = dr["IMP_EXP_ADD1"].ToString();
                IMP_EXP_ADD2 = dr["IMP_EXP_ADD2"].ToString();
                IMP_EXP_ADD3 = dr["IMP_EXP_ADD3"].ToString();
                IMP_EXP_ADD4 = dr["IMP_EXP_ADD4"].ToString();
                IMP_EXP_PIN_CODE = dr["IMP_EXP_PIN_CODE"].ToString();
                IMP_EXP_CONTACT_PERSON = dr["IMP_EXP_CONTACT_PERSON"].ToString();
                IMP_EXP_PHONE = dr["IMP_EXP_PHONE"].ToString();
                IMP_EXP_FAX = dr["IMP_EXP_FAX"].ToString();
                IMP_EXP_EMAIL = dr["IMP_EXP_EMAIL"].ToString();
                IMP_EXP_BINNO = dr["IMP_EXP_BINNO"].ToString();
                IMP_EXP_REMARKS = dr["IMP_EXP_REMARKS"].ToString();


            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public int IMP_EXP_All_BIND_BRANCHES(string query, string STR, string STR1, string ConStr, string Working_Period)
    {
        int i = 0;
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IMP_EXP_IECNO", STR);
            cmd.Parameters.AddWithValue("@IMP_EXP_BRSLNO", STR1);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {


                IMP_EXP_NAME = dr["IMP_EXP_NAME"].ToString();
                IMP_EXP_IECNO = dr["IMP_EXP_IECNO"].ToString();
                IMP_EXP_BRSLNO = dr["IMP_EXP_BRSLNO"].ToString();
                IMP_EXP_TYPE = dr["IMP_EXP_TYPE"].ToString();
                IMP_EXP_ADD1 = dr["IMP_EXP_ADD1"].ToString();
                IMP_EXP_ADD2 = dr["IMP_EXP_ADD2"].ToString();
                IMP_EXP_ADD3 = dr["IMP_EXP_ADD3"].ToString();
                IMP_EXP_ADD4 = dr["IMP_EXP_ADD4"].ToString();
                IMP_EXP_PIN_CODE = dr["IMP_EXP_PIN_CODE"].ToString();
                IMP_EXP_CONTACT_PERSON = dr["IMP_EXP_CONTACT_PERSON"].ToString();
                IMP_EXP_PHONE = dr["IMP_EXP_PHONE"].ToString();
                IMP_EXP_FAX = dr["IMP_EXP_FAX"].ToString();
                IMP_EXP_EMAIL = dr["IMP_EXP_EMAIL"].ToString();
                IMP_EXP_BINNO = dr["IMP_EXP_BINNO"].ToString();
                IMP_EXP_REMARKS = dr["IMP_EXP_REMARKS"].ToString();


            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public DataSet RetrieveAll_Adcode_LIKE(string SP_NAME, string SP_CON, string ConStr, string Working_Period)
    {
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ADCODE_IEC_NAME", SP_CON);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public int Adcode_All_BIND(string query, string STR, string ConStr)
    {
        int i = 0;
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ADCODE_ID", STR);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {

                ADCODE_IEC_CODE = dr["ADCODE_IEC_CODE"].ToString();
                ADCODE_IEC_NAME = dr["ADCODE_IEC_NAME"].ToString();
                ADCODE_IEC_ADCODE = dr["ADCODE_IEC_ADCODE"].ToString();
                ADCODE_BANK_NAME = dr["ADCODE_BANK_NAME"].ToString();
                ADCODE_BANK_ACCOUNT_NO = dr["ADCODE_BANK_ACCOUNT_NO"].ToString();
                ADCODE_BANK_ADD1 = dr["ADCODE_BANK_ADD1"].ToString();
                ADCODE_BANK_ADD2 = dr["ADCODE_BANK_ADD2"].ToString();
                ADCODE_BANK_CITY = dr["ADCODE_BANK_CITY"].ToString();
                ADCODE_BANK_STATE = dr["ADCODE_BANK_STATE"].ToString();
                ADCODE_BANK_PIN_CODE = dr["ADCODE_BANK_PIN_CODE"].ToString();
                ADCODE_REMARKS = dr["ADCODE_REMARKS"].ToString();


            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return i;

    }

    //public DataSet RetrieveAll_Exchange_LIKE(string SP_NAME, DateTime? date1, DateTime? date2, string str, DateTime? date4)
    public DataSet RetrieveAll_Exchange_LIKE(string SP_NAME, string str1, string str2, string str3, string str4, string ConStr, string Working_Period)
    {
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EXCHANGE_EFFECT_DT_FROM", str1);
            cmd.Parameters.AddWithValue("@EXCHANGE_EFFECT_DT_TO", str2);
            cmd.Parameters.AddWithValue("@EXCHANGE_NONT_NO", str3);
            cmd.Parameters.AddWithValue("@EXCHANGE_NOTN_DATE", str4);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return ds;

    }


    public DataSet RetrieveAll_PRODUCT_IMPORT_MASTER_LIKE(string SP_NAME, string str1, string str2, string str3, string str4, string ConStr, string Working_Period)
    {
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", str1);
            cmd.Parameters.AddWithValue("@PRODUCT_CTH", str2);
            cmd.Parameters.AddWithValue("@PRODUCT_CETH", str3);
            cmd.Parameters.AddWithValue("@PRODUCT_RITC", str4);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);

            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public int PRODUCT_IMPORT_MASTER_All_BIND(string query, string STR, string ConStr, string Working_Period)
    {
        int i = 0;
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PRODUCT_IMPORT_ID", STR);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {


                PRODUCT_DESCRIPTION = dr["PRODUCT_DESCRIPTION"].ToString();

                PRODUCT_CODE = dr["PRODUCT_CODE"].ToString();
                PRODUCT_RITC = dr["PRODUCT_RITC"].ToString();
                PRODUCT_CTH = dr["PRODUCT_CTH"].ToString();
                PRODUCT_BCD_NOTN = dr["PRODUCT_BCD_NOTN"].ToString();
                PRODUCT_BCD_SLNO = dr["PRODUCT_BCD_SLNO"].ToString();
                PRODUCT_BCD_RATE = dr["PRODUCT_BCD_RATE"].ToString();
                PRODUCT_BCD_SPL = dr["PRODUCT_BCD_SPL"].ToString();
                PRODUCT_BCD_UNIT = dr["PRODUCT_BCD_UNIT"].ToString();
                PRODUCT_BCD_SPL_TYPE = dr["PRODUCT_BCD_SPL_TYPE"].ToString();
                PRODUCT_ADDL_DUTY_NOTN = dr["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                PRODUCT_ADDL_DUTY_NOTN_SL = dr["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();
                PRODUCT_EDU_CESS_NOTN = dr["PRODUCT_EDU_CESS_NOTN"].ToString();
                PRODUCT_EDU_CESS_NOTN_SL = dr["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                PRODUCT_EDU_CESS_RATE = dr["PRODUCT_EDU_CESS_RATE"].ToString();
                PRODUCT_SEC_EDU_CESS_NOTN = dr["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();
                PRODUCT_SEC_EDU_CESS_NOTN_SL = dr["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();
                PRODUCT_SEC_EDU_CESS_RATE = dr["PRODUCT_SEC_EDU_CESS_RATE"].ToString();
                PRODUCT_NCD_NOTN = dr["PRODUCT_NCD_NOTN"].ToString();
                PRODUCT_NCD_SLNO = dr["PRODUCT_NCD_SLNO"].ToString();
                PRODUCT_NCD_RATE = dr["PRODUCT_NCD_RATE"].ToString();
                PRODUCT_NCD_SPL = dr["PRODUCT_NCD_SPL"].ToString();
                PRODUCT_NCD_UNIT = dr["PRODUCT_NCD_UNIT"].ToString();
                PRODUCT_NCD_SPL_TYPE = dr["PRODUCT_NCD_SPL_TYPE"].ToString();
                PRODUCT_AGGREGATE_DUTY_NOTN = dr["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
                PRODUCT_AGGREGATE_DUTY_NOTN_SL = dr["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
                PRODUCT_AGGREGATE_DUTY_NOTN_RATE = dr["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();
                PRODUCT_SAFEGUARD_NOTN = dr["PRODUCT_SAFEGUARD_NOTN"].ToString();
                PRODUCT_SAFEGUARD_SLNO = dr["PRODUCT_SAFEGUARD_SLNO"].ToString();
                PRODUCT_SAFEGUARD_RATE = dr["PRODUCT_SAFEGUARD_RATE"].ToString();
                PRODUCT_SAFEGUARD_SPL = dr["PRODUCT_SAFEGUARD_SPL"].ToString();
                PRODUCT_SAFEGUARD_UNIT = dr["PRODUCT_SAFEGUARD_UNIT"].ToString();
                PRODUCT_SAFEGUARD_SPL_TYPE = dr["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString();
                PRODUCT_CETH = dr["PRODUCT_CETH"].ToString();
                PRODUCT_MRP_YN = dr["PRODUCT_MRP_YN"].ToString();
                PRODUCT_MRP_SL_NO = dr["PRODUCT_MRP_SL_NO"].ToString();
                PRODUCT_MRP_AMOUNT = dr["PRODUCT_MRP_AMOUNT"].ToString();
                PRODUCT_MRP_ABT_RATE = dr["PRODUCT_MRP_ABT_RATE"].ToString();
                PRODUCT_CVD_NOTN = dr["PRODUCT_CVD_NOTN"].ToString();
                PRODUCT_CVD_SLNO = dr["PRODUCT_CVD_SLNO"].ToString();
                PRODUCT_CVD_RATE = dr["PRODUCT_CVD_RATE"].ToString();
                PRODUCT_CVD_SPL = dr["PRODUCT_CVD_SPL"].ToString();
                PRODUCT_CVD_UNIT = dr["PRODUCT_CVD_UNIT"].ToString();
                PRODUCT_CVD_SPL_TYPE = dr["PRODUCT_CVD_SPL_TYPE"].ToString();
                PRODUCT_CVD_EDU_CESS_RATE = dr["PRODUCT_CVD_EDU_CESS_RATE"].ToString();
                PRODUCT_CVD_SEC_EDU_CESS_RATE = dr["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString();
                PRODUCT_ADDL5_SIA_NOTN = dr["PRODUCT_ADDL5_SIA_NOTN"].ToString();
                PRODUCT_ADDL5_SIA_NOTN_SL = dr["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString();
                PRODUCT_ADDL5_SIA_RATE = dr["PRODUCT_ADDL5_SIA_RATE"].ToString();
                PRODUCT_ADDL_GSI_NOTN = dr["PRODUCT_ADDL_GSI_NOTN"].ToString();
                PRODUCT_ADDL_GSI_SLNO = dr["PRODUCT_ADDL_GSI_SLNO"].ToString();
                PRODUCT_ADDL_GSI_RATE = dr["PRODUCT_ADDL_GSI_RATE"].ToString();
                PRODUCT_ADDL_GSI_SPL = dr["PRODUCT_ADDL_GSI_SPL"].ToString();
                PRODUCT_ADDL_GSI_UNIT = dr["PRODUCT_ADDL_GSI_UNIT"].ToString();
                PRODUCT_ADDL_GSI_SPL_TYPE = dr["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString();
                PRODUCT_ADDL_SHEII_NOTN = dr["PRODUCT_ADDL_SHEII_NOTN"].ToString();
                PRODUCT_ADDL_SHEII_SLNO = dr["PRODUCT_ADDL_SHEII_SLNO"].ToString();
                PRODUCT_ADDL_SHEII_RATE = dr["PRODUCT_ADDL_SHEII_RATE"].ToString();
                PRODUCT_ADDL_SHEII_SPL = dr["PRODUCT_ADDL_SHEII_SPL"].ToString();
                PRODUCT_ADDL_SHEII_UNIT = dr["PRODUCT_ADDL_SHEII_UNIT"].ToString();
                PRODUCT_ADDL_SHEII_TYPE = dr["PRODUCT_ADDL_SHEII_TYPE"].ToString();
                PRODUCT_ADDL_TTA_NOTN = dr["PRODUCT_ADDL_TTA_NOTN"].ToString();
                PRODUCT_ADDL_TTA_SLNO = dr["PRODUCT_ADDL_TTA_SLNO"].ToString();
                PRODUCT_ADDL_TTA_RATE = dr["PRODUCT_ADDL_TTA_RATE"].ToString();
                PRODUCT_ADDL_TTA_SPL = dr["PRODUCT_ADDL_TTA_SPL"].ToString();
                PRODUCT_ADDL_TTA_UNIT = dr["PRODUCT_ADDL_TTA_UNIT"].ToString();
                PRODUCT_ADDL_TTA_TYPE = dr["PRODUCT_ADDL_TTA_TYPE"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_NOTN = dr["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_SLNO = dr["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_RATE = dr["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_SPL = dr["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_UNIT = dr["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString();
                PRODUCT_ADDL_HEALTH_CESS_TYPE = dr["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString();
                PRODUCT_CESS_NOTN = dr["PRODUCT_CESS_NOTN"].ToString();
                PRODUCT_CESS_SLNO = dr["PRODUCT_CESS_SLNO"].ToString();
                PRODUCT_CESS_RATE = dr["PRODUCT_CESS_RATE"].ToString();
                PRODUCT_CESS_SPL = dr["PRODUCT_CESS_SPL"].ToString();
                PRODUCT_CESS_UNIT = dr["PRODUCT_CESS_UNIT"].ToString();
                PRODUCT_CESS_TYPE = dr["PRODUCT_CESS_TYPE"].ToString();
                PRODUCT_GENERAL_DESC = dr["PRODUCT_GENERAL_DESC"].ToString();
                PRODUCT_MANUFACTURER = dr["PRODUCT_MANUFACTURER"].ToString();
                PRODUCT_BRAND = dr["PRODUCT_BRAND"].ToString();
                PRODUCT_MODEL = dr["PRODUCT_MODEL"].ToString();
                PRODUCT_END_USE = dr["PRODUCT_END_USE"].ToString();
                PRODUCT_COUNTRY_ORIGIN = dr["PRODUCT_COUNTRY_ORIGIN"].ToString();
                PRODUCT_ACCESSORIES = dr["PRODUCT_ACCESSORIES"].ToString();
                PRODUCT_REMARKS = dr["PRODUCT_REMARKS"].ToString();
                //PRODUCT_USER_ID= dr[""].ToString();
                //PRODUCT_DATE_TIME= dr[""].ToString();
                //PRODUCT_STATUS= dr[""].ToString();
                //PRODUCT_BRANCH_CODE= dr[""].ToString();
                //PRODUCT_YEAR = dr[""].ToString();





            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public DataSet RetrieveAll_CTH_MASTER_LIKE(string SP_NAME, string SP_CON,string str1)
    {
        try
        {

           //con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CTH_CODE", SP_CON);
            cmd.Parameters.AddWithValue("@CTH_DESCRIPTION", SP_CON);
            da.Fill(ds, "Temp");
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;
    }

    public DataSet RetrieveAll_CETH_MASTER_LIKE(string SP_NAME, string SP_CON)
    {
        try
        {

            //con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CETH_CODE", SP_CON);
            da.Fill(ds, "Temp");
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return ds;
    }


    public DataSet RetrieveAll_UNIT_MASTER_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {
            //con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UNIT_CODE", str1);
            cmd.Parameters.AddWithValue("@UNIT_NAME", str1);
            da.Fill(ds, "Temp");
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;
    }

    public DataSet RetrieveAll_NOTIFICATION_CUSTOMS_LIKE(string SP_NAME, string str1, string str2)
    {
        try
        {
            //con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(SP_NAME, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOTIFICATION_CUSTOMS_NOTN", str1);
            cmd.Parameters.AddWithValue("@NOTIFICATION_CUSTOMS_NOTN_SL", str2);



            da.Fill(ds, "Temp");

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }

    public int Exchange_All_BIND(string query, string STR, string ConStr, string Working_Period)
    {
        int i = 0;
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EXCHANGE_ID", STR);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {


                EXCHANGE_EFFECT_DT_FROM = dr["EXCHANGE_EFFECT_DT_FROM"].ToString();
                EXCHANGE_EFFECT_DT_TO = dr["EXCHANGE_EFFECT_DT_TO"].ToString();
                EXCHANGE_NONT_NO = dr["EXCHANGE_NONT_NO"].ToString();
                EXCHANGE_NOTN_DATE = dr["EXCHANGE_NOTN_DATE"].ToString();
                EXCHANGE_CUR_CODE = dr["EXCHANGE_CUR_CODE"].ToString();
                EXCHANGE_NAME = dr["EXCHANGE_NAME"].ToString();
                EXCHANGE_PER_UNIT = dr["EXCHANGE_PER_UNIT"].ToString();
                EXCHANGE_RATE_IMPORT = dr["EXCHANGE_RATE_IMPORT"].ToString();
                EXCHANGE_RATE_EXPORT = dr["EXCHANGE_RATE_EXPORT"].ToString();
                EXCHANGE_S_OR_N = dr["EXCHANGE_S_OR_N"].ToString();



            }
            //da.Fill(ds, "Temp");
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return i;

    }

    public DataSet RetrieveAllRecord_With_WorkingPeriod(string query, string ConStr, string Working_Period)
    {
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            da.Fill(ds);

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
            return ds;
      
    }

    public DataSet RetrieveAllRecord(string query)
    {
        try
        {
            //con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            da.Fill(ds);

            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;

    }
    public DataSet Retrieve_COUNTRYCODE(string query, string STR)
    {
        try
        {

           // con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@COUNTRY_NAME", STR);
            da.Fill(ds, "Temp");
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }
        return ds;


    }

    public DataSet Retrieve_IMP_EXP_IECNAME_IECCODE(string query, string STR, string STR1, string ConStr, string Working_Period)
    {
        try
        {
            con = new SqlConnection(ConStr);
            con.Open();
            ds = new DataSet();
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IMP_EXP_IECNO", STR);
            cmd.Parameters.AddWithValue("@IMP_EXP_NAME", STR1);
            cmd.Parameters.AddWithValue("@Working_Period", Working_Period);
            da.Fill(ds, "Temp");
            con.Close();
        }
        catch (Exception ex)
        {
            makeLog(ex.Message);
        }
        finally
        {
            con.Close();
        }

        return ds;


    }

  

   

   
}