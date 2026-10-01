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

/// <summary>
/// Summary description for SGATE
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SGATE : System.Web.Services.WebService {

    [WebMethod]
    public void Import_Planning_SGATE(DataSet ds)
    {
       
       
    }

    [WebMethod]
    public void Export_Planning_SGATE(DataSet ds)
    {


    }
}
