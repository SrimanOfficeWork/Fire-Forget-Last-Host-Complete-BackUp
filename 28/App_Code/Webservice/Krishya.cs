
using System.Web.Script.Serialization;  
using System.Web.Script.Services;  
using System.Web.Services;


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

/// <summary>
/// Summary description for Krishya
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Krishya : System.Web.Services.WebService
{

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Get_BE_Data(string Jobno)
    {
        string Imp_Data = string.Empty,IGM_Data=string.Empty;
        Global_variables ObjUBO = new Global_variables();
        Krishya_CS KR = new Krishya_CS();
        DataSet dss = new DataSet();
        ObjUBO.A1 = Jobno;
        ObjUBO.A2 = "I";
        ObjUBO.A3 = "FF_DATA_Krishya";
        ObjUBO.A4 = "ERI01120";
        ObjUBO.A5 = "";
        dss = KR.Select_IMP_EXP_Ryal(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            Imp_Data = "{" + @"""" + "GENERAL_DETAILS" + @"""" + ":[{" +
                   @"""" + "JOBNO" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["JOBNO"].ToString() + @"""" +
             "," + @"""" + "JOBNO_PS" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["JOBNO_PS"].ToString() + @"""" +
             "," + @"""" + "JOBDATE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["JOBDATE"].ToString() + @"""" +
             "," + @"""" + "TRANSPORT_MODE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() + @"""" +
             "," + @"""" + "BE_TYPE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["BE_TYPE"].ToString() + @"""" +
             "," + @"""" + "CUSTOMS_HOUSE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString() + @"""" +
             "," + @"""" + "CONTAINER_TYPE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString() + @"""" +
             "," + @"""" + "FILE_REF_NO" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString() + @"""" +
             "," + @"""" + "FILING_STATUS" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["FILING_STATUS"].ToString() + @"""" +

             "," + @"""" + "IMPORTER_NAME" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString() + @"""" +
             "," + @"""" + "ADDRESS1" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS1"].ToString() + @"""" +
             "," + @"""" + "ADDRESS2" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS2"].ToString() + @"""" +
             "," + @"""" + "ADDRESS3" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS3"].ToString() + @"""" +
             "," + @"""" + "ADDRESS4" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS4"].ToString() + @"""" +
             "," + @"""" + "ADDRESS5" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS5"].ToString() + @"""" +

             "," + @"""" + "IEC_NO" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["IEC_NO"].ToString() + @"""" +
             "," + @"""" + "BRANCH_NO" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["BRANCH_NO"].ToString() + @"""" +
             "," + @"""" + "COUNTRY_ORIGIN" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString() + @"""" +
             "," + @"""" + "PORT_ORIGIN" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString() + @"""" +
             "," + @"""" + "PORT_SHIPMENT" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString() + @"""" +
             "," + @"""" + "COUNTRY_SHIPMENT" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString() + @"""" +
             "," + @"""" + "COMMERCIAL_TAX_STATENAME" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString() + @"""" +
             "," + @"""" + "COMMERCIAL_TAX_STATECODE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATECODE"].ToString() + @"""" +"}]}";
            }

        return Imp_Data;
        }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat. Json)]
    public string Get_SB_Data(string Jobno)
    {
        string Exp_Data = string.Empty;
        Global_variables ObjUBO = new Global_variables();
        Krishya_CS KR = new Krishya_CS();
        DataSet dss = new DataSet();
        ObjUBO.A1 = Jobno;
        ObjUBO.A2 = "E";
        ObjUBO.A3 = "FF_DATA_Krishya";
        ObjUBO.A4 = "ERI01120";
        ObjUBO.A5 = "";
        dss = KR.Select_IMP_EXP_Ryal(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            Exp_Data = "{" + @"""" + "EXPORT_GENERAL_DETAILS" + @"""" + ":[{" +
                   @"""" + "JOBNO" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["JOBNO"].ToString() + @"""" +
             "," + @"""" + "FILE_REF_NO" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString() + @"""" +
             "," + @"""" + "JOBDATE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["JOBDATE"].ToString() + @"""" +
             "," + @"""" + "TRANSPORT_MODE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() + @"""" +
             "," + @"""" + "CUSTOMS_HOUSE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString() + @"""" +
             "," + @"""" + "CUSTOMS_HOUSE_NAME" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString() + @"""" +
             "," + @"""" + "SB_TYPE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["SB_TYPE"].ToString() + @"""" +
             "," + @"""" + "EXPORTER_NAME" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString() + @"""" +
             "," + @"""" + "BRANCH_NO" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["BRANCH_NO"].ToString() + @"""" +
              "," + @"""" + "IEC_NO" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["IEC_NO"].ToString() + @"""" +
               "," + @"""" + "ADDRESS1" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS1"].ToString() + @"""" +
                "," + @"""" + "ADDRESS2" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS2"].ToString() + @"""" +
                 "," + @"""" + "ADDRESS3" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS3"].ToString() + @"""" +
                  "," + @"""" + "ADDRESS4" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS4"].ToString() + @"""" +
                   "," + @"""" + "ADDRESS5" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADDRESS5"].ToString() + @"""" +
                    "," + @"""" + "ADCODE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["ADCODE"].ToString() + @"""" +
                    "," + @"""" + "BANK_ACCOUNT" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["BANK_ACCOUNT"].ToString() + @"""" +
                    "," + @"""" + "DRAWBACK_ACCOUNT" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["DRAWBACK_ACCOUNT"].ToString() + @"""" +
                    "," + @"""" + "CONSIGNEE_NAME" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString() + @"""" +
                    "," + @"""" + "CONSIGNEE_ADD1" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString() + @"""" +
                    "," + @"""" + "CONSIGNEE_ADD2" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString() + @"""" +
                    "," + @"""" + "CONSIGNEE_ADD3" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString() + @"""" +
                    "," + @"""" + "CONSIGNEE_ADD4" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString() + @"""" +
                    "," + @"""" + "CONSIGNEE_ADD5" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString() + @"""" +
                    "," + @"""" + "COUNTRY_DISCHARGE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString() + @"""" +
                    "," + @"""" + "PORT_DISCHARGE" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString() + @"""" +
                    "," + @"""" + "COUNTRY_FINAL_DEST" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString() + @"""" +
                    "," + @"""" + "PORT_FINAL_DEST" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString() + @"""" +
                    "," + @"""" + "STATE_OF_EXPORT" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString() + @"""" +
                    "," + @"""" + "CONSIGNEE_BRANCHSLNO" + @"""" + ":" + @"""" + dss.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString() + @"""" + "}]}";
        }
        return Exp_Data; 
    }
}
