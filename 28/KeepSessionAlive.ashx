<%@ WebHandler Language="C#" Class="KeepSessionAlive" %>

using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.SessionState;

public class KeepSessionAlive : IHttpHandler, IReadOnlySessionState
{

    public void ProcessRequest(HttpContext context)
    {

        if (HttpContext.Current.Request.QueryString["ses_id"] == "" || HttpContext.Current.Request.QueryString["ses_id"] == null)
        {

        }
        else
        {

            HttpContext.Current.Session["Transport_Mode_Port"] = null;
            HttpContext.Current.Session["Transport_Mode_Port"] = HttpContext.Current.Request.QueryString["ses_id"].ToString();
            //string s = Session["Transport_Mode_Port"].ToString();
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}