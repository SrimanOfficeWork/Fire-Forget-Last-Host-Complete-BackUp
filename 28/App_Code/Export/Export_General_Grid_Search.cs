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


public class Export_General_Grid_Search
{
    DataSet ds = new DataSet();
    public int result;

    private string _SEARCH_CAT, _SEARCH_ITEM, _EXPORTER_NAME, _TRANSPORT_MODE, _CUSTOMS_HOUSE, _startRowIndex, _maximumRows, _flag, _Selected_Index, _FromDt, _ToDt;
      
    public string EXPORTER_NAME { get { return _EXPORTER_NAME; } set { _EXPORTER_NAME = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string SEARCH_CAT { get { return _SEARCH_CAT; } set { _SEARCH_CAT = value; } }
    public string SEARCH_ITEM { get { return _SEARCH_ITEM; } set { _SEARCH_ITEM = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string Selected_Index { get { return _Selected_Index; } set { _Selected_Index = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public string FromDt { get { return _FromDt; } set { _FromDt = value; } }
    public string ToDt { get { return _ToDt; } set { _ToDt = value; } }


    public DataSet EXP_General_Search()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[15];

            param[1] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
            param[2] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);
            param[3] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[4] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);
            param[7] = new SqlParameter("@maximumRows", maximumRows);
            param[8] = new SqlParameter("@Selected_Index", Selected_Index);
            param[9] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());

            param[10] = new SqlParameter("@flag", flag);
            param[11] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[12] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[12].Direction = ParameterDirection.Output;

            param[13] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[13].Direction = ParameterDirection.Output;

            //ds = Connection.Get_Dataset("EXPORT_GENERAL_DETAILS_SEARCH", param);//hide on 17-08-2026
            ds = Connection.Get_Dataset("EXPORT_GENERAL_DETAILS_SEARCH_USERWISE_IEC_BASED_SEARCH", param);
            result = Convert.ToInt32(param[12].Value.ToString());
            //SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }


    public DataSet EXP_General_Search_Bulk()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[25];

            param[1] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
            param[2] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);
            param[3] = new SqlParameter("@EXPORTER_NAME", EXPORTER_NAME);
            param[4] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);
            param[7] = new SqlParameter("@maximumRows", maximumRows);
            param[8] = new SqlParameter("@Selected_Index", Selected_Index);

            param[16] = new SqlParameter("@flag", flag);
            param[17] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[18] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            param[20] = new SqlParameter("@FromDate", FromDt);
            param[21] = new SqlParameter("@ToDate", ToDt);

            ds = Connection.Get_Dataset("EXPORT_GENERAL_DETAILS_SEARCH_BulkChkList", param);
            result = Convert.ToInt32(param[18].Value.ToString());
            //SP_EXPORT_GENERAL_DETAILS_SEARCH_SELECT
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
	
}