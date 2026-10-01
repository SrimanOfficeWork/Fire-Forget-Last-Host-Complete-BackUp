using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Management;


public partial class FlatFile_Test_4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      lblid.Text= GetMACAddress();
    }

    public string GetMACAddress()
    {
        ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = mc.GetInstances();
        string MACAddress = String.Empty;
        foreach (ManagementObject mo in moc)
        {
            if (MACAddress == String.Empty)  // only return MAC Address from first card
            {
                if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
            }
            mo.Dispose();
        }
        MACAddress = MACAddress.Replace(":", "");
        return MACAddress;
    }
}