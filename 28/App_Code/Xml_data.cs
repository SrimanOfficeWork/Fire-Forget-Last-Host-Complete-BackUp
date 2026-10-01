using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

public class Xml_data
{
    public string load_XML(string C_Lic)
    {
        string Server_name=string.Empty;

        XmlDocument Doc = new XmlDocument();
        Doc.Load(HttpContext.Current.Server.MapPath("~/Submission/DSC_ClientList.xml"));

        if (Server_name == string.Empty) // Trade server
        {
            XmlNode node_org = Doc.GetElementsByTagName("Trade").Item(0);
            foreach (XmlNode item in node_org.ChildNodes)
            {
                if ((item).NodeType == XmlNodeType.Element)
                {
                    if (C_Lic == ((item).FirstChild).Value)
                    {
                        Server_name = "Server=103.211.202.92;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;";
                    }
                }
            }
        }
        if (Server_name == string.Empty) // Co server
        {
            XmlNode node_org = Doc.GetElementsByTagName("Co").Item(0);
            foreach (XmlNode item in node_org.ChildNodes)
            {
                if ((item).NodeType == XmlNodeType.Element)
                {
                    if (C_Lic == ((item).FirstChild).Value)
                    {
                        Server_name = "Server=103.185.74.178;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;";
                    }
                }
            }
        }
        if (Server_name == string.Empty)  // Co.in server
        {
            XmlNode node_org = Doc.GetElementsByTagName("Co_In").Item(0);
            foreach (XmlNode item in node_org.ChildNodes)
            {
                if ((item).NodeType == XmlNodeType.Element)
                {
                    if (C_Lic == ((item).FirstChild).Value)
                    {
                        Server_name = "Server=103.211.202.107;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;";
                    }
                }
            }
        }
        if (Server_name == string.Empty) //Pro server
        {
            XmlNode node_Pro = Doc.GetElementsByTagName("Pro").Item(0);
            foreach (XmlNode item in node_Pro.ChildNodes)
            {
                if ((item).NodeType == XmlNodeType.Element)
                {
                    if (C_Lic == ((item).FirstChild).Value)
                    {
                        Server_name = "Server=103.171.181.85;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;";
                    }
                }
            }
        }
        if (Server_name == string.Empty)  // Org server
        {
            XmlNode node_org = Doc.GetElementsByTagName("org").Item(0);
            foreach (XmlNode item in node_org.ChildNodes)
            {
                if ((item).NodeType == XmlNodeType.Element)
                {
                    if (C_Lic == ((item).FirstChild).Value)
                    {
                        Server_name = "Server=103.211.202.201;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;";
                    }
                }
            }
        }
        if (Server_name == string.Empty) // Net server
        {
            XmlNode node_org = Doc.GetElementsByTagName("Net").Item(0);
            foreach (XmlNode item in node_org.ChildNodes)
            {
                if ((item).NodeType == XmlNodeType.Element)
                {
                    if (C_Lic == ((item).FirstChild).Value)
                    {
                        Server_name = "Server=195.250.30.161;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;";
                    }
                }
            }
        }
        if (Server_name == string.Empty) // Info server
        {
            XmlNode node_org = Doc.GetElementsByTagName("Info").Item(0);
            foreach (XmlNode item in node_org.ChildNodes)
            {
                if ((item).NodeType == XmlNodeType.Element)
                {
                    if (C_Lic == ((item).FirstChild).Value)
                    {
                        Server_name = "Server=103.171.181.171;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;";
                    }
                }
            }
        }
        if (Server_name == string.Empty) // Live server
        {
            XmlNode node_org = Doc.GetElementsByTagName("Live").Item(0);
            foreach (XmlNode item in node_org.ChildNodes)
            {
                if ((item).NodeType == XmlNodeType.Element)
                {
                    if (C_Lic == ((item).FirstChild).Value)
                    {
                        Server_name = "Server=103.171.180.125;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;";
                    }
                }
            }
        }
        if (Server_name == string.Empty) // Indev server
        {
            XmlNode node_org = Doc.GetElementsByTagName("Indev").Item(0);
            foreach (XmlNode item in node_org.ChildNodes)
            {
                if ((item).NodeType == XmlNodeType.Element)
                {
                    if (C_Lic == ((item).FirstChild).Value)
                    {
                        Server_name = "Server=10.193.21.10;database=ADMIN_IMPEX;uid=rtsindevadmin;pwd=adminindev@123;";
                    }
                }
            }
        }
        
        if (Server_name == string.Empty)
        {
            Server_name = "Server=182.76.213.91;database=ADMIN_IMPEX;uid=rtsadmin;pwd=adminrts@#12345@#rtsadmin;";
        }

        return Server_name;

    }
   

}