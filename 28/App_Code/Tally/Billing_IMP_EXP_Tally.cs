using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ApplicationBlocks.Data;


public class Billing_IMP_EXP_Tally
{
    DataSet ds = new DataSet();

    private string _startRowIndex;
    private string _maximumRows;
    private string _totalRows;

    public string startRowIndex { get { return _startRowIndex; } set { _startRowIndex = value; } }
    public string maximumRows { get { return _maximumRows; } set { _maximumRows = value; } }
    public string totalRows { get { return _totalRows; } set { _totalRows = value; } }
    public int result, UPDATE_ID = 0;

    public DataSet Select_IMP_INV(Billing_UserBO objUserBL, string SP_NAME)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };
            if (objUserBL.from_date != string.Empty && objUserBL.from_date != null)
            {
                arr = objUserBL.from_date.Split('/');
                objUserBL.from_date = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            if (objUserBL.todate != string.Empty && objUserBL.todate != null)
            {
                arr2 = objUserBL.todate.Split('/');
                objUserBL.todate = arr2[1] + '/' + arr2[0] + '/' + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[15];
            param[1] = new SqlParameter("@Bill_invno", objUserBL.BILL_INV_NO);
            //param[2] = new SqlParameter("@Imp_Name", objUserBL.Imp_Name);
            param[3] = new SqlParameter("@Jobno", objUserBL.JOBNO);
            param[4] = new SqlParameter("@Mflag", objUserBL.Flag);
            param[6] = new SqlParameter("@Tally_Status", objUserBL.BILL_TYPE == "Not Posted" ? "" : objUserBL.BILL_TYPE);

            param[11] = new SqlParameter("@fromdate", objUserBL.from_date);
            param[12] = new SqlParameter("@todate", objUserBL.todate);

            param[5] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());

            param[7] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[7].Direction = ParameterDirection.Output;

            param[8] = new SqlParameter("@startRowIndex", objUserBL.startRowIndex);

            param[9] = new SqlParameter("@maximumRows", objUserBL.maximumRows);

            param[10] = new SqlParameter("@totalRows", SqlDbType.Int, 1);
            param[10].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset(SP_NAME, param);
            result = Convert.ToInt32(param[10].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

}