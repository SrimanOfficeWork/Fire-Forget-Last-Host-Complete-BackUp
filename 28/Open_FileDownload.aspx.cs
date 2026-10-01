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
        Export_FlatFile_Generation flatfile = new Export_FlatFile_Generation();
        //string errorFolder = HttpContext.Current.Server.MapPath("~/Submission/");
         string errorFolder="";
       
            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");
            flatfile.Open_Textfile(errorFolder);
     

    }
}