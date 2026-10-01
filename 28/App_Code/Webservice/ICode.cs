using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.ApplicationBlocks.Data;
using System.Text;
using System.IO;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ICode : System.Web.Services.WebService {

    [WebMethod]
    public string Import_Planning_ICODE(string Company_Lic,string WORKINGPERIOD, DataSet ds)
    {
        string outval="0";
        try
        {
            DataSet dss = new DataSet();
            DataSet d = new DataSet();
            var IC = new ICode_CS();
            dss = IC.Get_Login_Details(Company_Lic, WORKINGPERIOD, "Company_details", "I", ds);
            if (dss.Tables[0].Rows.Count > 0)
            {
                d = IC.Ryal_Imp_Exp_Data(dss, "I");
                 if (d.Tables[0].Rows.Count > 0)
                 {
                     outval = "1";
                 }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return outval;
    }

    [WebMethod]
    public string Export_Planning_ICODE(string Company_Lic, string WORKINGPERIOD, DataSet ds)
    {
        string outval = "0";
        try
        {
            DataSet dss = new DataSet();
            DataSet d = new DataSet();
            var IC = new ICode_CS();
            dss = IC.Get_Login_Details(Company_Lic, WORKINGPERIOD,"Company_details", "E", ds);
            if (dss.Tables[0].Rows.Count > 0)
            {
                d = IC.Ryal_Imp_Exp_Data(dss, "E");
                if (d.Tables[0].Rows.Count > 0)
                {
                    outval = "1";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return outval;
    }
    
}
