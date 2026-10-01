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

using System.Net;

public partial class FlatFile_Test_2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strHostName = Dns.GetHostName();
        IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

        lblIPAddress.Text = Convert.ToString(ipEntry.AddressList[0]);
        lblHostName.Text = Convert.ToString(ipEntry.HostName);


        //Find IP Address Behind Proxy Or Client Machine In ASP.NET
        string IPAdd = string.Empty;
       // IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (string.IsNullOrEmpty(IPAdd))
        {
            IPAdd = Request.ServerVariables["REMOTE_ADDR"];
            lblIPBehindProxy.Text = IPAdd;
        }
    }
}