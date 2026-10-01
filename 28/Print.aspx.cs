using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
{
        Response.ContentType = "application/pdf";// set the MIME type here
       
        byte[] bytes = (byte[])Session["report"];
        Response.OutputStream.Write(bytes, 0, bytes.Length);

    }
}