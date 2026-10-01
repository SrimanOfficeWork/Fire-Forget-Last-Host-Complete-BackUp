using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;


using System;
using System.Text;

using System.Management;

using System;
using System.Security.Permissions;
using Microsoft.Win32;

public partial class FlatFile_Test_3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UseDNS();
        UseWMI();
        UseRegistry();

    }
    // using System.Net; 
    public void UseDNS()
    {
        string hostName = Dns.GetHostName();
        Console.WriteLine("Host Name = " + hostName);
        IPHostEntry local = Dns.GetHostByName(hostName);
        foreach (IPAddress ipaddress in local.AddressList)
        {
            //Console.WriteLine("IPAddress = " + ipaddress.ToString());
            lblip.Text = lblip.Text + ipaddress.ToString();
        }
    }


    public void UseWMI()
    {
        string query = "SELECT * FROM Win32_NetworkAdapterConfiguration"
             + " WHERE IPEnabled = 'TRUE'";
        ManagementObjectSearcher moSearch = new ManagementObjectSearcher(query);
        ManagementObjectCollection moCollection = moSearch.Get();

        // Every record in this collection is a network interface
        foreach (ManagementObject mo in moCollection)
        {
            Console.WriteLine("HostName = " + mo["DNSHostName"]);
            Console.WriteLine("Description = " + mo["Description"]);

            lblip_2.Text = "HostName = " + mo["DNSHostName"].ToString();
            lblip_3.Text = "Description = " + mo["Description"].ToString();


            // IPAddresses, probably have more than one value
            string[] addresses = (string[])mo["IPAddress"];
            foreach (string ipaddress in addresses)
            {
               //Console.WriteLine("IPAddress = " + ipaddress);
                lblip_4.Text = "IPAddress = " + ipaddress.ToString();

            }

            // IPSubnets, probably have more than one value
            string[] subnets = (string[])mo["IPSubnet"];
            foreach (string ipsubnet in subnets)
            {
                Console.WriteLine("IPSubnet = " + ipsubnet);
                lblip_5.Text = "IPSubnet = " + ipsubnet.ToString();
            }

            // DefaultIPGateways, probably have more than one value
            string[] defaultgateways = (string[])mo["DefaultIPGateway"];
            foreach (string defaultipgateway in defaultgateways)
            {
               // Console.WriteLine("DefaultIPGateway = " + defaultipgateway);
                lblip_6.Text = "DefaultIPGateway = " + defaultipgateway.ToString();
            }
        }
    }

    public void UseRegistry()
    {
        string network_card_key = "SOFTWARE\\Microsoft\\Windows NT\\"
             + "CurrentVersion\\NetworkCards";
        string service_key = "SYSTEM\\CurrentControlSet\\Services\\";

        RegistryKey local_machine = Registry.LocalMachine;
        RegistryKey service_names = local_machine.OpenSubKey(network_card_key);



        if (service_names == null) return; // Invalid Registry

        string[] network_cards = service_names.GetSubKeyNames();
        service_names.Close();
        foreach (string key_name in network_cards)
        {
            string network_card_key_name = network_card_key + "\\" + key_name;
            RegistryKey card_service_name =
              local_machine.OpenSubKey(network_card_key_name);
            if (card_service_name == null) return; // Invalid Registry

            string device_service_name = (string)card_service_name.GetValue(
                "ServiceName");
            string device_name = (string)card_service_name.GetValue(
                "Description");
            //Console.WriteLine("Network Card = " + device_name);

            lblip_7.Text = "Network Card = " + device_name;

            string service_name = service_key + device_service_name +
                  "\\Parameters\\Tcpip";
            RegistryKey network_key = local_machine.OpenSubKey(service_name);
            if (network_key != null)
            {
                // IPAddresses
                string[] ipaddresses = (string[])network_key.GetValue("IPAddress");
                foreach (string ipaddress in ipaddresses)
                {
                    //Console.WriteLine("IPAddress = " + ipaddress);
                    lblip_8.Text =  lblip_8.Text+ "IPAddress = " + ipaddress;
                }

                // Subnets
                string[] subnets = (string[])network_key.GetValue("SubnetMask");
                foreach (string subnet in subnets)
                {
                    //Console.WriteLine("SubnetMask = " + subnet);
                    lblip_9.Text = lblip_9.Text +"SubnetMask = " + subnet;
                }

                //DefaultGateway
                string[] defaultgateways = (string[])
                     network_key.GetValue("DefaultGateway");
                foreach (string defaultgateway in defaultgateways)
                {
                  // Console.WriteLine("DefaultGateway = " + defaultgateway);
                    lblip_10.Text = lblip_10.Text+"DefaultGateway = " + defaultgateway;
                }
                network_key.Close();
            }
        }
        local_machine.Close();
    }

    //public sealed class RegistryKey : MarshalByRefObject,
    //IDisposable
    //{ 
    //}

}