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

public class Import_General_Grid_Search
{
    DataSet ds = new DataSet();
    public int result;

    private string _SEARCH_CAT, _SEARCH_ITEM, _IMPORTER_NAME, _TRANSPORT_MODE, _CUSTOMS_HOUSE, _BE_TYPE, _startRowIndex, _maximumRows, _flag, _Selected_Index, _FromDt, _ToDt;

    public string IMPORTER_NAME { get { return _IMPORTER_NAME; } set { _IMPORTER_NAME = value; } }
    public string TRANSPORT_MODE { get { return _TRANSPORT_MODE; } set { _TRANSPORT_MODE = value; } }
    public string CUSTOMS_HOUSE { get { return _CUSTOMS_HOUSE; } set { _CUSTOMS_HOUSE = value; } }
    public string BE_TYPE { get { return _BE_TYPE; } set { _BE_TYPE = value; } }
    public string SEARCH_CAT { get { return _SEARCH_CAT; } set { _SEARCH_CAT = value; } }
    public string SEARCH_ITEM { get { return _SEARCH_ITEM; } set { _SEARCH_ITEM = value; } }
    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string Selected_Index { get { return _Selected_Index; } set { _Selected_Index = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }

    public DataSet IMP_General_Search()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[20];
            param[1] = new SqlParameter("@SEARCH_CAT", SEARCH_CAT);
            param[2] = new SqlParameter("@SEARCH_ITEM", SEARCH_ITEM);
            param[3] = new SqlParameter("@IMPORTER_NAME", IMPORTER_NAME);
            param[4] = new SqlParameter("@TRANSPORT_MODE", TRANSPORT_MODE);
            param[5] = new SqlParameter("@CUSTOMS_HOUSE", CUSTOMS_HOUSE);
            param[6] = new SqlParameter("@startRowIndex", startRowIndex);
            param[7] = new SqlParameter("@maximumRows", maximumRows);
            param[8] = new SqlParameter("@Selected_Index", Selected_Index);
            param[9] = new SqlParameter("@BE_TYPE", string.IsNullOrEmpty(BE_TYPE) ? "" : BE_TYPE);
            param[10] = new SqlParameter("@UserCreation_ID", HttpContext.Current.Session["USER_CREATION_ID"].ToString());
            param[11] = new SqlParameter("@flag", flag);
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            

            param[18] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[18].Direction = ParameterDirection.Output;

            param[19] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[19].Direction = ParameterDirection.Output;

            //ds = Connection.Get_Dataset("IMPORT_GENERAL_DETAILS_SEARCH", param);//hide on 17-08-2026
            ds = Connection.Get_Dataset("IMPORT_GENERAL_DETAILS_SEARCH_USERWISE_IEC_BASED_SEARCH", param);
            result = Convert.ToInt32(param[18].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
            //throw new Exception("BE_TYPE DEBUG: " + ex.Message);
        }
        return ds;
    }

}