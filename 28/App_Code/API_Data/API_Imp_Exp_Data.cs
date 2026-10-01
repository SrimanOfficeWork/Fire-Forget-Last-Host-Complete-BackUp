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

public class API_Imp_Exp_Data : System.Web.Services.WebService
{

    /// <summary>
    /// Summary description for Ryal
    /// </summary>
    // [WebService(Namespace = "http://tempuri.org/")]
    // [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    [WebMethod]
    public string API_ImpExp_Data(string CID, string WKP, string ImpExp_type, string xmldoc)
    {

        string returnmsg = "";
        try
        {
            API_Data_CS API = new API_Data_CS();
            DataSet ds = new DataSet();
            
            ds = API.API_Get_Login_Details(CID, WKP, "Company_details", ImpExp_type, xmldoc);

            if (ds.Tables[0].Rows.Count > 0)
            {
                returnmsg = API.API_Imp_Exp_Data(ds, ImpExp_type);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return returnmsg;
    }

     [WebMethod]
    public string API_Imp_Exp_Full_Job_Data(string CID, string WKP, string ImpExp_type,string Branch, string xmldoc)
    {
        string returnmsg = "";
        try
        {
            API_Data_CS API = new API_Data_CS();
            DataSet ds = new DataSet();           
            DataSet ds_Res = new DataSet();

            ds = API.API_Get_Login_Details_Fulljob(CID, WKP, "Company_details", ImpExp_type, xmldoc);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ds_Res = API.API_Post_DB(CID, WKP, "Save", ImpExp_type,Branch, xmldoc, ds.Tables[0].Rows[0][0].ToString());
                if (ds_Res.Tables.Count > 0)
                {
                    if (ds_Res.Tables[0].Rows.Count > 0)
                    {
                        //returnmsg = ds_Res.Tables[0].Rows[0][0].ToString();
                        returnmsg = ds_Res.Tables[0].Rows[0]["Acknowledgment"].ToString() + "~"+"Jobno - " + ds_Res.Tables[0].Rows[0]["Jobno"].ToString();

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
    /*
    [WebMethod]//API_Get_Login_Details_Fulljob
    public string API_Imp_Exp_Full_Job_Data_test(string CID, string WKP, string ImpExp_type, string xmldoc)
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
   
   */
}
