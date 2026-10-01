using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;
using System.Net;


public class Ryal_test
{
    public string RYAL_REFNO; //subjob no 
    public string IECNO;//consignee iec code
    public string BRANCH_SL_NO; //ask
    public string IMPORTER_NAME; //consignee
    public string ADCODE;//ask
    public string TRANSPORT_MODE;//sea or air
    public string PORT_OF_FILLING_CODE; //user code shipment
    public string PORT_OF_ORIGIN_CODE;//origin
    public string PORT_OF_SHIPMENT_CODE;//origin
    public string STATE_CODE;//segment state
    public string GSTN_REGISTRATION_NO;//consinee gst no
    public string COUNTRY_ORGIN; //contry code of origin
    public string COUNTRY_SHIPMENT;//contry code of origin
    public string FLAG;//s or u
    private string RYAL_USER_ID = "demo";


    public void assignVal(int? segmentno, string type)
    {
        if (segmentno == 0)
        {
            this.STATE_CODE = "27";
            if (type == "air")
                this.PORT_OF_FILLING_CODE = "BOM";
            else
                this.PORT_OF_FILLING_CODE = "INBOM";
        }
        else if (segmentno == 1)
        {
            this.STATE_CODE = "33";
            if (type == "air")
                this.PORT_OF_FILLING_CODE = "MAA";
            else
                this.PORT_OF_FILLING_CODE = "INMAA";
        }
        else
        {
            this.STATE_CODE = "24";
            if (type == "air")
                this.PORT_OF_FILLING_CODE = "AMD";
            else
                this.PORT_OF_FILLING_CODE = "INAMD";
        }
    }

    public string PostData()
    {
        var responseData = "";
        if (this.RYAL_REFNO == null || this.IECNO == null || this.BRANCH_SL_NO == null || this.IMPORTER_NAME == null || this.ADCODE == null || this.TRANSPORT_MODE == null ||
            this.PORT_OF_FILLING_CODE == null || this.PORT_OF_ORIGIN_CODE == null || this.PORT_OF_SHIPMENT_CODE == null || this.STATE_CODE == null || this.GSTN_REGISTRATION_NO == null ||
            this.COUNTRY_ORGIN == null || this.COUNTRY_SHIPMENT == null || this.FLAG == null)
        {
            return "Error|Please provide all the data";
        }
        
        var requestStr = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body>" +
            "<Ryal_Imp_Data xmlns=\"http://tempuri.org/\">" +
            "<xmldoc><![CDATA[" +
           "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
           "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body>" +
           "<Ryal_Imp_Data xmlns=\"http://tempuri.org/\">" +
           "<RYAL_REFNO>" + this.RYAL_REFNO + "</RYAL_REFNO>" +
           "<IECNO>" + this.IECNO + "</IECNO>" +
           "<BRANCH_SL_NO>" + this.BRANCH_SL_NO + "</BRANCH_SL_NO>" +
           "<IMPORTER_NAME>" + this.IMPORTER_NAME + "</IMPORTER_NAME>" +
           "<ADCODE>" + this.ADCODE + "</ADCODE>" +
           "<TRANSPORT_MODE>" + this.TRANSPORT_MODE + "</TRANSPORT_MODE>" +
           "<PORT_OF_FILLING_CODE>" + this.PORT_OF_FILLING_CODE + "</PORT_OF_FILLING_CODE>" +
           "<PORT_OF_ORIGIN_CODE>" + this.PORT_OF_ORIGIN_CODE + "</PORT_OF_ORIGIN_CODE>" +
           "<PORT_OF_SHIPMENT_CODE>" + this.PORT_OF_SHIPMENT_CODE + "</PORT_OF_SHIPMENT_CODE>" +
           "<STATE_CODE>" + this.STATE_CODE + "</STATE_CODE>" +
           "<GSTN_REGISTRATION_NO>" + this.GSTN_REGISTRATION_NO + "</GSTN_REGISTRATION_NO>" +
           "<COUNTRY_ORGIN>" + this.COUNTRY_ORGIN + "</COUNTRY_ORGIN>" +
           "<COUNTRY_SHIPMENT>" + this.COUNTRY_SHIPMENT + "</COUNTRY_SHIPMENT>" +
           "<FLAG>" + this.FLAG + "</FLAG>" +
           "<RYAL_USER_ID>" + "demo" + "</RYAL_USER_ID>" +
           "</Ryal_Imp_Data></soap:Body></soap:Envelope>"
            +
            "]]></xmldoc>" +
            "</Ryal_Imp_Data></soap:Body></soap:Envelope>";

        var requestData = requestStr;
        HttpWebRequest request = CreateSOAPWebRequest();
       
        XmlDocument SOAPReqBody = new XmlDocument();

        SOAPReqBody.LoadXml(requestData);

        try
        {
            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //Getting response from request    
            using (WebResponse Serviceres = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(Serviceres.GetResponseStream()))
                {
                    //reading stream    
                    responseData = rd.ReadToEnd();
                }
            }

            //return responseData;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return responseData;
    }

    public HttpWebRequest CreateSOAPWebRequest()
    {
        //Making Web Request    
       // HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://demo.eroyalimpex.org/Ryal/Ryal.asmx?op=Ryal_Imp_Data");
        //HttpWebRequest Req = (HttpWebRequest)WebRequest.Create("http://localhost:63075/Ryal.asmx?op=Ryal_Imp_Data");
        HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(@"http://demo.eroyalimpex.org/Ryal/Ryal.asmx?op=Ryal_Imp_Data");
       
        //SOAPAction    
        Req.Headers.Add(@"SOAPAction:http://tempuri.org/Ryal_Imp_Data");
        Req.Host = "demo.eroyalimpex.org";
        //Req.Host = "localhost";

        //Content_type    
        Req.ContentType = "text/xml; charset=\"utf-8\"";
        Req.Accept = "text/xml";
        Req.Method = "POST";
        Req.Timeout = 30000;
        return Req;
    }
}