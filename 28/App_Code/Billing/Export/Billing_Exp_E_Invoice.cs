using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using BussinessObject;
using System.Web.UI.WebControls;
using System.Web;
public class Billing_Exp_E_Invoice
{
    DataSet ds = new DataSet();
    public int result = 0, UPDATE_ID = 0;
    private string _flag;
    public string flag { get { return _flag; } set { _flag = value; } }
    public DataSet charge_Data_Search(Global_variables objUserBL)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];
            param[6] = new SqlParameter("@INV_NO", objUserBL.A9); 
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[14] = new SqlParameter("@flag", flag);
            param[13].Direction = ParameterDirection.Output;
            ds = Connection.Get_Dataset("GST_CHA_CHARGE_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}