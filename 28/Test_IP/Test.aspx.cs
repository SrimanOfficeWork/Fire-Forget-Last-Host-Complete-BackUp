using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.Management;


public partial class FlatFile_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
         lblid.Text = GetVisitorIpAddress();
        //Get The Lan Ip Address
        lbadd.Text = GetLanIPAddress();
    }

    public string GetVisitorIpAddress()
    {
        string stringIpAddress;
        stringIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (stringIpAddress == null) //may be the HTTP_X_FORWARDED_FOR is null
        {
            stringIpAddress = Request.ServerVariables["REMOTE_ADDR"];//we can use REMOTE_ADDR
        }
        return "Your ip is " + stringIpAddress;
    }


    public string GetLanIPAddress()
    {
        //Get the Host Name
        string stringHostName = Dns.GetHostName();
        //Get The Ip Host Entry
        IPHostEntry ipHostEntries = Dns.GetHostEntry(stringHostName);
        //Get The Ip Address From The Ip Host Entry Address List
        IPAddress[] arrIpAddress = ipHostEntries.AddressList;
        return arrIpAddress[arrIpAddress.Length - 1].ToString();
    }
   
}