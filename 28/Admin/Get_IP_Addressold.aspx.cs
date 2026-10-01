using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_Get_IP_Addressold : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text=getIpAddress();
        //Label1.Text = LocalIPAddress();
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

    //public static string LocalIPAddress()
    //{
    //    IPHostEntry host;
    //    string localIP = "";
    //    host = Dns.GetHostEntry(Dns.GetHostName());
    //    foreach (IPAddress ip in host.AddressList)
    //    {
    //        if (ip.AddressFamily.ToString() == "InterNetwork")
    //        {
    //            localIP = ip.ToString();
    //        }
    //    }
    //    return localIP;
    //}
}