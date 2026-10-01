using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for Bond_Details
/// </summary>
public class Bond_Details
{
    #region Private_Attributes
    //BOND_DETAILS
    private string _BOND_NO;
    private string _BOND_TYPE, _BOND_LOCATION;
    #endregion

    #region Public_Attributes
    //BOND_DETAILS
    public string BOND_NO { get { return _BOND_NO; } set { _BOND_NO = value; } }
    public string BOND_TYPE { get { return _BOND_TYPE; } set { _BOND_TYPE = value; } }
    public string BOND_LOCATION { get { return _BOND_LOCATION; } set { _BOND_LOCATION = value; } }
    #endregion

    public List<Bond_Details> Get_Bond_Details(DataTable BOND_dt)
	{
        List<Bond_Details> list = new List<Bond_Details>();
        list.Clear();

        int i = 0;
        //foreach (DataRow dr in ds.Tables[0].Rows)

        while (BOND_dt.Rows.Count > i)
        {
            BOND_TYPE = BOND_dt.Rows[i]["BOND_TYPE"].ToString();
            
            string[] s1 = BOND_TYPE.Split(new string[] { "," }, StringSplitOptions.None);
            BOND_TYPE = s1[0].ToString();

            list.Add(new Bond_Details()
            {
                BOND_NO = BOND_dt.Rows[i]["BOND_NO"].ToString(),
                BOND_LOCATION = BOND_dt.Rows[i]["BOND_LOCATION"].ToString(),
                BOND_TYPE = BOND_TYPE

            });

            i++;
        }

        return list;
	}
}