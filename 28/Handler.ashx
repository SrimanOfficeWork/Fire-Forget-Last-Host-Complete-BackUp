<%@ WebHandler Language="C#" Class="Handler" %>
using System;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Collections.Generic;

public class Handler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            List<HttpPostedFile> files = (List<HttpPostedFile>)context.Session["Files"];
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            files.Add(postedFile);
            string filename = postedFile.FileName;
            context.Response.Write(filename);
            context.Response.StatusCode = 200;
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    //public void ProcessRequest (HttpContext context) {
    //    context.Response.ContentType = "text/plain";
    //    HttpPostedFile uploadFiles = context.Request.Files["Filedata"];
    //    string pathToSave = HttpContext.Current.Server.MapPath("~/UploadFiles/") + uploadFiles.FileName;
    //    uploadFiles.SaveAs(pathToSave);
    //}
 
    //public bool IsReusable {
    //    get {
    //        return false;
    //    }
    //}
}