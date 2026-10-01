using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

public class ParaMount_Connection
{
    public static DataSet Get_Combined_Con( string SP_name ,SqlParameter[] param)
    {
        DataSet ds = new DataSet();
         try
        {
                
                string Company_Id = string.Empty , a=string.Empty,b=string.Empty,c=string.Empty,d=string.Empty;
                Company_Id = Connection.COMPANYID();
                if (Company_Id == "293" || Company_Id == "485" || Company_Id == "534" || Company_Id == "919")
                {   
                    a = "Server=103.171.181.171;database=PARAMOUNT_SHIPPING_IMPORT2425;uid=impexparamountimport;pwd=paramountimportimpex@#1234#@;";
                    b = "Server=103.171.181.171;database=PARAMOUNT_SHIPPING_EXP_TUTI2425;uid=impexparamounttuti;pwd=paramounttutiimpex@#1234#@;";
                    c = "Server=103.171.181.171;database=PARAMOUNT_SUBAGENT2425;uid=impexparamountsubagent;pwd=paramountsubagentimpex@#1234#@;";
                    d = "Server=103.171.181.171;database=PARAMOUNT_HOSUR2425;uid=impexparamounthosur;pwd=paramounthosurimpex@#1234#@;";
                   ds = SqlHelper.ExecuteDataset(a, CommandType.StoredProcedure, SP_name, param);
                   ds = SqlHelper.ExecuteDataset(b, CommandType.StoredProcedure, SP_name, param);
                   ds = SqlHelper.ExecuteDataset(c, CommandType.StoredProcedure, SP_name, param);
                   ds = SqlHelper.ExecuteDataset(d, CommandType.StoredProcedure, SP_name, param);
                }
                else
                {
                    ds = Connection.Get_Dataset(SP_name, param);
                }
        }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
        return ds;
    }
    public static DataSet Get_Combined_Acc_Con(string SP_name, SqlParameter[] param)
    {
        DataSet ds = new DataSet();
        try
        {

            string Company_Id = string.Empty, a = string.Empty, b = string.Empty, c = string.Empty, d = string.Empty;
            Company_Id = Connection.COMPANYID();
            if (Company_Id == "293" || Company_Id == "485" || Company_Id == "534" || Company_Id == "919")
            {
                a = "Server=103.171.181.171;database=PARAMOUNT_SHIPPING_ACCOUNTS2526;uid=impexparamountaccounts;pwd=paramountaccountsimpex@#1234#@;";
                ds = SqlHelper.ExecuteDataset(a, CommandType.StoredProcedure, SP_name, param);
                //ERI01187
            }
            else
            {
                ds = Connection.Get_Dataset(SP_name, param);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}