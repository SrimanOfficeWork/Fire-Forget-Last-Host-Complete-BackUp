using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

public class CustomDuty_Rpt
{

    public int result = 0, UPDATE_ID = 0;
    DataSet ds = new DataSet();

    private string _BRANCH_CODE, _Jobno, _From_date, _To_date, _Imp_Name, _flag;

    public string BRANCH_CODE { get { return _BRANCH_CODE; } set { _BRANCH_CODE = value; } }
    public string flag { get { return _flag; } set { _flag = value; } }
    public string Jobno { get { return _Jobno; } set { _Jobno = value; } } 
    public string From_date { get { return _From_date; } set { _From_date = value; } }
    public string To_date { get { return _To_date; } set { _To_date = value; } }
    public string Imp_Name { get { return _Imp_Name; } set { _Imp_Name = value; } }


    public DataSet Report_data()
    {
        try
        {
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@Jobno", Jobno = Jobno == " " ? string.Empty : Jobno);
            param[1] = new SqlParameter("@from_date", From_date);
            param[2] = new SqlParameter("@to_date", To_date);
            param[3] = new SqlParameter("@Branch", BRANCH_CODE);
            param[4] = new SqlParameter("@Imp_Name", Imp_Name);
            param[7] = new SqlParameter("@flag", flag);

            param[5] = new SqlParameter("@MStatus", SqlDbType.Int, 1);
            param[5].Direction = ParameterDirection.Output;
            param[6] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[6].Direction = ParameterDirection.Output;

            if (Connection.Get_Tr_Mode() == "Air")
            {
                ds = Connection.Get_Dataset("IMP_CUSTOMS_DUTY_RPT_FAIRMACS_AIR", param);
            }
            else
            {
                ds = Connection.Get_Dataset("IMP_CUSTOMS_DUTY_RPT_FAIRMACS", param);
            }

            result = Convert.ToInt32(param[5].Value.ToString());
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }

   

}