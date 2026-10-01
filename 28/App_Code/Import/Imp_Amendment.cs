using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using BussinessObject;


public class Imp_Amendment
{

    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();
    SqlCommand cmd;
    DataTable dt = new DataTable();


    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);


    # region Common_Private_Attributes
    private string _IMP_EXP_TYPE, _flag;

    private string _USER_ID, _BRANCH_CODE, _ITEM_ID, _INVOICE_SLNO, _ITEM_SLNO, _JOBNO, _Ename, _WORKING_PERIOD, _BRANCH_COMMON, _INVOICE_NO, _SELECT_ITEM, _AMEND_TYPE;

    public string JOBNO { get { return _JOBNO; } set { _JOBNO = value; } }
    public string ITEM_ID { get { return _ITEM_ID; } set { _ITEM_ID = value; } }
    public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }

    public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }
    public string Ename { get { return _Ename; } set { _Ename = value; } }
    public string WORKING_PERIOD { get { return _WORKING_PERIOD; } set { _WORKING_PERIOD = value; } }
    public string INVOICE_NO { get { return _INVOICE_NO; } set { _INVOICE_NO = value; } }
    public string SELECT_ITEM { get { return _SELECT_ITEM; } set { _SELECT_ITEM = value; } }
    public string AMEND_TYPE { get { return _AMEND_TYPE; } set { _AMEND_TYPE = value; } }


    #endregion

    public DataSet RetrieveAll_Amend_Details()
    {
        try
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@JOBNO", JOBNO);
            param[1] = new SqlParameter("@INVOICE_SLNO", INVOICE_SLNO);
            param[2] = new SqlParameter("@ITEM_SLNO", ITEM_SLNO);
            param[3] = new SqlParameter("@SELECT_ITEM", SELECT_ITEM);
            param[4] = new SqlParameter("@AMEND_TYPE", AMEND_TYPE);
            param[5] = new SqlParameter("@name", Ename);
            param[6] = new SqlParameter("@WORKING_PERIOD", WORKING_PERIOD);
            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[7].Direction = ParameterDirection.Output;
            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;
           
            param[13] = new SqlParameter("@BRANCH_CODE", Connection.Current_Branch());
          
            ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_IMPORT_AMENDMENT_SELECT", param);
            //result = Convert.ToInt32(param[7].Value.ToString());


            string err = param[8].Value.ToString();

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