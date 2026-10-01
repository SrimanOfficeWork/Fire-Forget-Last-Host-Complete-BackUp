
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Container_Details
/// </summary>
public class Container_Details
{
    #region Private_Attributes
    //CONTAINER_DETAILS
    private string _CONTAINERID;
    private string _CONTAINER_NO;
    private string _SEAL_NO;
    private string _FCL_OR_LCL;
    private string _TYPE;
    private string _CONTAINER_IGM_SLNO;
    #endregion
    #region Public_Attributes
    //CONTAINER_DETAILS
    public string CONTAINERID { get { return _CONTAINERID; } set { _CONTAINERID = value; } }
    public string CONTAINER_IGM_SLNO { get { return _CONTAINER_IGM_SLNO; } set { _CONTAINER_IGM_SLNO = value; } }
    public string CONTAINER_NO { get { return _CONTAINER_NO; } set { _CONTAINER_NO = value; } }
    public string SEAL_NO { get { return _SEAL_NO; } set { _SEAL_NO = value; } }
    public string FCL_OR_LCL { get { return _FCL_OR_LCL; } set { _FCL_OR_LCL = value; } }
    public string TYPE { get { return _TYPE; } set { _TYPE = value; } }

    #endregion


    public List<Container_Details> Get_CONTAINER_DETAILS(DataTable CONTAINER_dt)
    {


        List<Container_Details> list = new List<Container_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (CONTAINER_dt.Rows.Count > i)
        {

            list.Add(new Container_Details()
            {
                CONTAINERID = CONTAINER_dt.Rows[i]["CONTAINERID"].ToString(),
                CONTAINER_IGM_SLNO = CONTAINER_dt.Rows[i]["CONTAINER_IGM_SLNO"].ToString() + " / " + CONTAINER_dt.Rows[i]["CONTAINERID"].ToString(),
                CONTAINER_NO = CONTAINER_dt.Rows[i]["CONTAINER_NO"].ToString(),
                SEAL_NO = CONTAINER_dt.Rows[i]["SEAL_NO"].ToString(),
                FCL_OR_LCL = CONTAINER_dt.Rows[i]["FCL_OR_LCL"].ToString(),
                TYPE = CONTAINER_dt.Rows[i]["TYPE"].ToString()
            });

            i++;
        }
        return list;
    }
}