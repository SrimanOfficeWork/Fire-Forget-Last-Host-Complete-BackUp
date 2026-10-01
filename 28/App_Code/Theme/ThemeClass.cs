using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ThemeClass
/// </summary>
public class ThemeClass:System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.Browser.ToString() == "Chrome")
        {
            string url = HttpContext.Current.Request.RawUrl;
            if (url.IndexOf("mywebfarm") < 1)
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("p3p", "CP=\"IDC DSP COR ADM DEVi TAIi PSA PSD IVAi IVDi CONi HIS OUR IND CNT\"");
            }
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        
        //solved not Working problem in chrome
        //string ss = Session["Theme"].ToString();
        if (Session["Theme"] != null && Session["Theme"] != "")
        {
            Page.Theme = Session["Theme"].ToString();
        }
  
        //else
        //{
        //    Session["Theme"] = "Orange";
        //    Page.Theme = Session["Theme"].ToString();

        //}
        //solved not Working problem in chrome
        //Reference by this url only  //http:///petesbloggerama.blogspot.in/2007/08/aspnet-loss-of-session-cookies-with.html 
        //http:///weblogs.asp.net/coltk/archive/2010/10/13/session-lost-in-iframe-p3p-issue.aspx
        //http:///kiranpatils.wordpress.com/2010/04/13/session-lost-in-iframe/
        if (Request.Browser.ToString() == "Chrome")
        {
            string url = HttpContext.Current.Request.RawUrl;
            if (url.IndexOf("mywebfarm") < 1)
            {
                HttpContext.Current.Response.Status = "301 Moved Permanently";
                HttpContext.Current.Response.AddHeader("p3p", "CP=\"IDC DSP COR ADM DEVi TAIi PSA PSD IVAi IVDi CONi HIS OUR IND CNT\"");
            }
        }
    }

}

