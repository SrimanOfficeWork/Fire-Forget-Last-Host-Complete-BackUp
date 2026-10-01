using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Amendment_IMP_Error_Code : ThemeClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtError_code.Attributes.Add("onblur", "javascript:CallServerside_Port_of_orgin('" + txtError_code.ClientID + "', '" + txtError_code.ClientID + "')");
    }

    [System.Web.Services.WebMethod]
    public static string Select_Error_Code(string custid )
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();

        Auto.Enamesearch = custid;
        Auto.Ename = "Amendment_IMP_Error_Code";
        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds.Tables[0].Rows.Count > 0)
        {
            custid = ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            custid = "Invalid Error Code";
        }

        return custid;
    }
}
   

   