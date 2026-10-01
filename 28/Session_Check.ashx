<%@ WebHandler Language="C#" Class="Session_Check" %>

using System;
using System.Web;
using System.Web.SessionState;

public class Session_Check : IHttpHandler,IReadOnlySessionState {
    
    public void ProcessRequest (HttpContext context) {

        if (context.Session["currentuser"] != null && context.Session["currentpassword"] != null && context.Session["currentbranch"] != null)
        {
            context.Response.Redirect("~/Default.aspx?from='expired'");
        }
   
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}