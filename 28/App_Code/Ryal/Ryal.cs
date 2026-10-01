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
using System.Xml;
using System.Web.Services.Protocols;
using System.Web.Services;   

public class Ryal : System.Web.Services.WebService {

    /// <summary>
    /// Summary description for Ryal
    /// </summary>
  //  [WebService(Namespace = "http://tempuri.org/")]
   // [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  //  [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    [WebMethod]
    public string Ryal_Exp_Data(string xmldoc)
    {

        string returnmsg = "";
        try
        {
            Ryal_CS ERM = new Ryal_CS();
            DataSet ds = new DataSet();
            //ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2021 - 31-Mar-2022", "Company_details", "E", xmldoc);
            //ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2022 - 31-Mar-2023", "Company_details", "E", xmldoc);
            //ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2023 - 31-Mar-2024", "Company_details", "E", xmldoc);
            //ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2024 - 31-Mar-2025", "Company_details", "E", xmldoc);
            //ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2025 - 31-Mar-2026", "Company_details", "E", xmldoc);
            ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2026 - 31-Mar-2027", "Company_details", "E", xmldoc);

            if (ds.Tables[0].Rows.Count > 0)
            {
                returnmsg = ERM.Ryal_Imp_Exp_Data(ds, "E");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return returnmsg;
    }

    [WebMethod]
    public string Ryal_Imp_Data(string xmldoc)
    {
        string returnmsg = "";
        try
        {
            Ryal_CS ERM = new Ryal_CS();
            DataSet ds = new DataSet();
            //ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2023 - 31-Mar-2024", "Company_details", "I", xmldoc);
              //ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2024 - 31-Mar-2025", "Company_details", "I", xmldoc);
            //ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2025 - 31-Mar-2026", "Company_details", "I", xmldoc);
            ds = ERM.Get_Login_Details("Eri00752", "01-Apr-2026 - 31-Mar-2027", "Company_details", "I", xmldoc);

            if (ds.Tables[0].Rows.Count > 0)
            {
                returnmsg = ERM.Ryal_Imp_Exp_Data(ds, "I");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return returnmsg;
    }



    [WebMethod]
    public string API_Imp_Exp_Data(string CID, string WKP, string ImpExp_type, string xmldoc)
    {

        string returnmsg = "";
        try
        {
            Ryal_CS ERM = new Ryal_CS();
            DataSet ds = new DataSet();
            DataSet ds_Res = new DataSet();

            ds = ERM.Get_Login_Details(CID, WKP, "Company_details", ImpExp_type, xmldoc);

            if (ds.Tables[0].Rows.Count > 0)
            {

                ds_Res = ERM.API_Post_DB(CID, WKP, "Save", ImpExp_type, xmldoc, ds.Tables[0].Rows[0][0].ToString());
                if (ds_Res.Tables.Count > 0)
                {
                    if (ds_Res.Tables[0].Rows.Count > 0)
                    {
                        returnmsg = ds_Res.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return returnmsg;
    }
    
   
}
