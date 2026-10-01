using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using BussinessObject;

using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;

using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
public class Krishya_CS
{
  
    public DataSet Select_IMP_EXP_Ryal(Global_variables objUserBL)
    {
        DataSet ds = new DataSet();
        try
        {
            SqlParameter[] param = new SqlParameter[21];
            param[1] = new SqlParameter("@Jobno", objUserBL.A1);
            param[2] = new SqlParameter("@Imp_Exp", objUserBL.A2);
            param[3] = new SqlParameter("@Flag", objUserBL.A3);
            param[4] = new SqlParameter("@Company_Lic", objUserBL.A4);
            param[5] = new SqlParameter("@BRANCH_COMMON", objUserBL.A5);

            param[10] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[10].Direction = ParameterDirection.Output;

            ds = SqlHelper.ExecuteDataset("Server=69.162.74.182;database=KRISHYA_LOGISTICS2021;uid=impexkrishya;pwd=krishyaimpex@#1234#@;", CommandType.StoredProcedure, "KRISHYA_FF_DATA_SERVICES", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
}