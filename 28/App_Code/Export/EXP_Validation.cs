using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

public class EXP_Validation
{
    private string _Jobno;
    private string _Flag;
    private string _Branch_Type;

    public string Jobno { get { return _Jobno; } set { _Jobno = value; } }
    public string Flag { get { return _Flag; } set { _Flag = value; } }
    public string Branch_Type { get { return _Branch_Type; } set { _Branch_Type = value; } }

    public String Xml_A, Xml_B, Xml_C, Xml_D, Xml_E;

    DataSet ds = new DataSet();
    public DataSet EXP_Data_Select()
    {
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
                case "EXP_Flat_File_DETAILS":
                case "EXP_GENERAL_DETAILS":
                case "EXPORT_ANNEXURE_C_Air":
                case "EXPORT_ANNEXURE_C_Sea":
                case "EXPORT_ANNEXURE_C_Sea_Container":
                case "EXP_SW_SUP_DOC":
                case "EXP_ITEM_SCHEME_CODE":
                case "EXP_ITEM_PMV_VALUE":   
                    ds = Connection.Get_Dataset("EXP_VALIDATION_GEN", param);
                    break;
                case "EXP_INVOICE_DETAILS":
                case "EXP_AR4_DETAILS":
                case "EXP_INVOICE_CUR_EXCHANGE_RATE":
                    ds = Connection.Get_Dataset("EXP_VALIDATION_INVOICE", param);
                    break;
                case "EXP_ITEM_DETAILS_ADMIN":
                case "EXP_ITEM_CESS_DETAILS":
                case "EXP_Invoice_Item":
                case "Item_Special_Character":
                case "EXP_Invoice_No":
                case "EXP_SW_Info_Type_Cnt":
                case "EXP_SW_Info_Type":
                case "EXP_INSURANCE_FREIGHT_CUR":
                case "EXP_Inv_No":
                    ds = Connection.Get_Dataset("EXP_VALIDATION_ITEM", param);
                    break;
                case "EXP_ITEM_LIC_DETAILS":
                case "EXP_ITEM_LIC_VAL_DETAILS":
                case "EXP_Item_Mandatory_Check":
                case "EXP_ITEM_Lic_Dup_Check":
                case "EXP_ITEM_Annuxure_C1_Details":
                    ds = Connection.Get_Dataset("EXP_VALIDATION_ITEM_LIC", param);
                    break;
                case "EXP_SPL_CHAR":
                    ds = Connection.Get_Dataset("EXPORT_SPECIAL_CHARACTERS", param);
                    break;
                case "EXP_SPL_CHAR_Auto_Remove":
                    ds = Connection.Get_Dataset("EXPORT_SPECIAL_CHARACTERS_AUTO_REMOVE", param); 
                    break;
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds;
    }
    DataSet ds_2 = new DataSet();
    public DataSet EXP_Admin_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@Flag", Flag);

            param[9] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[9].Direction = ParameterDirection.Output;
            ds_2 = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "EXP_FLATFILE_VALIDATION", param);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds_2;
    }

/*
    public DataSet RetrieveAll_Export_Admin_Master_Validation()
    {
        DataSet ds = new DataSet();
        DataTable dtt = new DataTable();
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@xml_Data_Invoice", Xml_A);
            param[1] = new SqlParameter("@xml_Data_Item", Xml_B);
            param[2] = new SqlParameter("@xml_Data_Drawback", Xml_C);
            param[3] = new SqlParameter("@xml_Data_SW_Info", Xml_D);
            param[4] = new SqlParameter("@flag", Flag);

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "ADMIN_GET_ALL_EXPORT_VALIDATION", param);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                }
                else
                    ds.Tables.Add(dtt);
            }
            else
                ds.Tables.Add(dtt);
        }
        catch (Exception ex)
        {

           // er.makeLog(ex.Message);
        }
        return ds;
    }*/

    public DataSet RetrieveAll_Export_Admin_Master_Validation() // Added by pandiyan due to timeout error shortout 
    {
        DataSet ds = new DataSet();
        DataTable emptyTable = new DataTable();

        try
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@xml_Data_Invoice", Xml_A);
            param[1] = new SqlParameter("@xml_Data_Item", Xml_B);
            param[2] = new SqlParameter("@xml_Data_Drawback", Xml_C);
            param[3] = new SqlParameter("@xml_Data_SW_Info", Xml_D);
            param[4] = new SqlParameter("@xml_Data_SchemeDrawback", Xml_E); 

            param[5] = new SqlParameter("@flag", Flag);

            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;
                         
            using (SqlConnection con = new SqlConnection(
                System.Configuration.ConfigurationManager.AppSettings["con"]))
            {
                using (SqlCommand cmd = new SqlCommand("ADMIN_GET_ALL_EXPORT_VALIDATION", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;   // IMPORTANT

                    cmd.Parameters.AddRange(param);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                    }
                }
            }

            // Handle empty dataset properly
            if (ds == null || ds.Tables.Count == 0)
            {
                ds.Tables.Add(emptyTable);
            }
            else if (ds.Tables[0].Rows.Count == 0)
            {
                ds.Tables.Add(emptyTable);
            }
        }
        catch (Exception ex)
        {   
            ds = new DataSet();
            ds.Tables.Add(emptyTable);
        }

        return ds;
    }

    public DataSet EXP_DRAWBACK_Select()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Jobno", Jobno);
            param[1] = new SqlParameter("@Branch_Type", Branch_Type);
            param[2] = new SqlParameter("@xmlString", Xml_D);
            param[3] = new SqlParameter("@Flag", Flag);

            param[4] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[4].Direction = ParameterDirection.Output;

            ds_2 = Connection.Get_Dataset("EXP_VALIDATION_GEN", param);

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        return ds_2;
    }
}
