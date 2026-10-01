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

/// <summary>
/// Summary description for Mapping_Master
/// </summary>
public class Mapping_Master
{
    ErrorLogs er = new ErrorLogs();
    SqlDataAdapter da;
    SqlDataReader dr;
    DataSet ds = new DataSet();

    DataTable dt = new DataTable();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    SqlCommand cmd;
    int A1, A2;
    //SqlConnection con = new SqlConnection();
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);


    private string _startRowIndex;

    private string _maximumRows;
    private string _totalRows;


    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public int UPDATE_ID = 0;



    #region Mapping_Master Private_Attributes

    private string _MAPPING_ID;
    private string _EROYAL_LICENSE;
    private string _NEWAGE_LICENSE;
    private string _COMPANY_NAME;
    private string _CREATED_ON;
    private string _MODIFIED_ON;
    
    private string _name;
    private string _flag;

    #endregion

    #region Mapping_Master Public_Attributes

    public string MAPPING_ID { get { return _MAPPING_ID; } set { _MAPPING_ID = value; } }
    public string EROYAL_LICENSE { get { return _EROYAL_LICENSE; } set { _EROYAL_LICENSE = value; } }
    ////public string INVOICE_SLNO { get { return _INVOICE_SLNO; } set { _INVOICE_SLNO = value; } }
    ////public string ITEM_SLNO { get { return _ITEM_SLNO; } set { _ITEM_SLNO = value; } }

    public string NEWAGE_LICENSE { get { return _NEWAGE_LICENSE; } set { _NEWAGE_LICENSE = value; } }
    public string COMPANY_NAME { get { return _COMPANY_NAME; } set { _COMPANY_NAME = value; } }
    public string CREATED_ON { get { return _CREATED_ON; } set { _CREATED_ON = value; } }

    public string MODIFIED_ON { get { return _MODIFIED_ON; } set { _MODIFIED_ON = value; } }          

    public string name { get { return _name; } set { _name = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    // ---- Start here for new RTS- Elogix mappibng master -------------//
    private string _ELogix_LICENSE, _ERoyal_UserName, _Elogix_UserName, _ERoyal_Branch, _Elogix_Branch, _ERoyal_WKP, _Elogix_WKP, _Isactive;

    public string ELogix_LICENSE { get { return _ELogix_LICENSE; } set { _ELogix_LICENSE = value; } }
    public string ERoyal_UserName { get { return _ERoyal_UserName; } set { _ERoyal_UserName = value; } }
    public string Elogix_UserName { get { return _Elogix_UserName; } set { _Elogix_UserName = value; } }
    public string ERoyal_Branch { get { return _ERoyal_Branch; } set { _ERoyal_Branch = value; } }
    public string Elogix_Branch { get { return _Elogix_Branch; } set { _Elogix_Branch = value; } }
    public string ERoyal_WKP { get { return _ERoyal_WKP; } set { _ERoyal_WKP = value; } }
    public string Elogix_WKP { get { return _Elogix_WKP; } set { _Elogix_WKP = value; } }
    public string Isactive { get { return _Isactive; } set { _Isactive = value; } }  


    // ---- End here for new RTS- Elogix mappibng master ------------- //

    public int result = 0;

    public string License_No;

    #endregion

    

    public int Mapping_Master_Insert_update()
    {
        DataSet ds = new DataSet();
        try
        {
            //Now what i want is if i delete Record from 70 to 100 it start from 71 or from 101 ? can you ... Autoincrement ID in SQL Server I've deleted all Record
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@MAPPING_ID", MAPPING_ID);
            param[1] = new SqlParameter("@EROYAL_LICENSE", EROYAL_LICENSE);

            param[2] = new SqlParameter("@NEWAGE_LICENSE", NEWAGE_LICENSE);
            param[3] = new SqlParameter("@COMPANY_NAME", COMPANY_NAME);

            //param[4] = new SqlParameter("@CREATED_ON", DateTime.Parse(CREATED_ON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            //param[5] = new SqlParameter("@MODIFIED_ON", DateTime.Parse(MODIFIED_ON, provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault));

            param[6] = new SqlParameter("@name", name);

            param[7] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[8].Direction = ParameterDirection.Output;

            param[9] = new SqlParameter("@Update_Id", SqlDbType.Int, 1);
            param[9].Direction = ParameterDirection.Output;


            SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "MAPPING_MASTER_INSERT_UPDATE", param);

            result = Convert.ToInt32(param[7].Value.ToString());

            if (name == "S")
                UPDATE_ID = Convert.ToInt32(param[16].Value.ToString());

        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return result;

    }

    public DataSet RetrieveAll_Mapping_Master()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@MAPPING_ID", MAPPING_ID);
            param[1] = new SqlParameter("@COMPANY_NAME", COMPANY_NAME);

            param[2] = new SqlParameter("@name", name);
            


            param[4] = new SqlParameter("@MStatus", SqlDbType.Int, 1);

            param[4].Direction = ParameterDirection.Output;

            param[5] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);

            param[7] = new SqlParameter("@maximumRows", maximumRows);

            param[8] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[8].Direction = ParameterDirection.Output;
            if (name == "delete")
            {
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIERMASTER", param);
                //SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "MAPPING_MASTER_SEARCH_SELECT", param);

                SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "MAPPING_MASTER_SEARCH_SELECT", param);

                result = Convert.ToInt32(param[4].Value.ToString());
                
            }
            else
            {
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "SP_SUPPLIERMASTER", param);
                //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "MAPPING_MASTER_SEARCH_SELECT", param);

                ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "MAPPING_MASTER_SEARCH_SELECT", param);
                result = Convert.ToInt32(param[8].Value.ToString());

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
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return ds;

    }

    

     public DataSet  RTS_LogixMapping()
    {
        DataSet ds = new DataSet();
        try
        {
             
            SqlParameter[] param = new SqlParameter[25];

            param[0] = new SqlParameter("@MTID", MAPPING_ID);
            param[1] = new SqlParameter("@RTS_CompLicenseID", EROYAL_LICENSE);
            param[2] = new SqlParameter("@Elogix_CompLicenseID", ELogix_LICENSE);
            param[3] = new SqlParameter("@RTS_UserName", ERoyal_UserName);
            param[4] = new SqlParameter("@Elogix_UserName", Elogix_UserName);
            param[5] = new SqlParameter("@RTS_Branch", ERoyal_Branch);
            param[6] = new SqlParameter("@Elogix_Branch", Elogix_Branch);
            param[7] = new SqlParameter("@RTS_WorkingPeriod",ERoyal_WKP);
            param[8] = new SqlParameter("@Elogix_WorkingPeriod", _Elogix_WKP);
            param[9] = new SqlParameter("@IsActive", Isactive);
            param[10] = new SqlParameter("@COMPANY_NAME", COMPANY_NAME);
            param[11] = new SqlParameter("@Flag", flag);

            //ds = SqlHelper.ExecuteDataset(HttpContext.Current.Session["currentcomp_db"].ToString(), CommandType.StoredProcedure, "RTS_ETLogixMapping_SP", param);
            ds = SqlHelper.ExecuteDataset(System.Configuration.ConfigurationManager.AppSettings["con"], CommandType.StoredProcedure, "RTS_ETLogixMapping_SP", param);
        }
        catch (Exception ex)
        {

            er.makeLog(ex.Message);
        }


        return ds;

    }

}