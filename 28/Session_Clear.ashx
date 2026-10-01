<%@ WebHandler Language="C#" Class="Session_Clear" %>

using System;
using System.Web;
using System.Web.SessionState;
public class Session_Clear : IHttpHandler, IReadOnlySessionState
{
    
    public void ProcessRequest (HttpContext context) {
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Session.Abandon();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}