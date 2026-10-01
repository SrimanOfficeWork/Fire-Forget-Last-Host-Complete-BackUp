using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

// Include System.Net Namspace
using System.Net;

public partial class Users_Get_IP_Address : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // To find IP address of a machine behind LAN you can use this code
        string strHostName = Dns.GetHostName();
        IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

        lblIPAddress.Text = Convert.ToString(ipEntry.AddressList[1]);
        lblHostName.Text = Convert.ToString(ipEntry.HostName);


        //Find IP Address Behind Proxy Or Client Machine In ASP.NET
        string IPAdd = string.Empty;
        IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(IPAdd))
        {
            IPAdd = Request.ServerVariables["REMOTE_ADDR"];
            lblIPBehindProxy.Text = IPAdd;
        }
    }

    public String getIpAddress()
    {
        string strIpAddress;
        strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (strIpAddress == null)
        {
            strIpAddress = Request.ServerVariables["REMOTE_ADDR"];
        }
        return Convert.ToString(strIpAddress);
    }
}