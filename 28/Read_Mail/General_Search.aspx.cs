using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Globalization;
using System.Web.Services;
public partial class Transaction_Default2 : ThemeClass
{
  
    AppSession aps = new AppSession();
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate, Name_Search;
  

    protected void Page_Load(object sender, EventArgs e)
    {

       

        if (Request.QueryString["JOBTYPE"].ToString() == "Import" || Request.QueryString["JOBTYPE"].ToString() == "Export")
        {
            a.Attributes.Add("src", "Read_mail_new_Iframe.aspx");
        }
        if (Request.QueryString["JOBTYPE"].ToString() == "Import-Esanchit" || Request.QueryString["JOBTYPE"].ToString() == "Export-Esanchit")
        {
            a.Attributes.Add("src", "Read_mail_new_IframeEsanchit.aspx");
        }
        aps.checkSession();
        if (!string.IsNullOrEmpty(Request["JOBTYPE"]))
        {
            Session.Remove("JOBTYPE_new");
            Session["JOBTYPE_new"] = Request["JOBTYPE"].ToString();

        }

    }
  
}