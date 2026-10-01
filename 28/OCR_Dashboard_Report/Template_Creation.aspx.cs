using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GeneraReport;
using Microsoft.Reporting.WebForms;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Text;
using ClosedXML.Excel;


public partial class PDF_Import_Report : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string LoginDate, Name_Search;

    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();

    ErrorLogs err = new ErrorLogs();
    eroyalmaster erm = new eroyalmaster();
    Company_Master Comp = new Company_Master();

    DataSet ds = new DataSet();

    private SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        SELECT_BRANCH = Connection.Get_Company_Type();

        con = new SqlConnection(HttpContext.Current.Session["currentcomp_db"].ToString());

        if (!IsPostBack)
        {
            string newTabUrl = "https://docparser.docr.online";
            string mode = Request.QueryString["mode"] ?? "";

            // This page is reached via a plain <a target="maineroyal"> navigation (OCR menu's
            // Import/Export -> "Template Creation"), so it loads INSIDE Main's
            // #mainiframecontainer, not at the top level. Calling open_Imp_UPload_PDF_AI/
            // open_Exp_UPload_PDF_New_AI() bare therefore resolved to THIS page's own local copy
            // (js/iframepopupwin.js is included here too) and opened the PDF tool popup confined
            // to that iframe box instead of covering the whole screen - same bug already fixed
            // for every other popup-opening page in this app (see Transaction/General_Search.aspx.cs
            // etc.). Route through window.top instead, falling back to the local copy only if this
            // page is ever opened standalone (no parent/top).
            string action = string.Equals(mode, "export", StringComparison.OrdinalIgnoreCase)
                ? "if (window.top && window.top.open_Exp_UPload_PDF_New_AI) { window.top.open_Exp_UPload_PDF_New_AI('New'); } else { open_Exp_UPload_PDF_New_AI('New'); }"
                : "if (window.top && window.top.open_Imp_UPload_PDF_AI) { window.top.open_Imp_UPload_PDF_AI('New'); } else { open_Imp_UPload_PDF_AI('New'); }";

            // This page's own body has no real content - it only ever exists to fire the new
            // tab + tool popup above, then sit there blank inside #mainiframecontainer. With
            // the popup now covering the full screen (fix above), navigating
            // #mainiframecontainer away from this blank page to the Dashboard - it's a sibling
            // of the (now top-level) popup in window.top's DOM, so this doesn't interfere with
            // it - means the Dashboard is already there, instead of a blank page, the moment the
            // popup is closed.
            //
            // MUST happen inside the same setTimeout callback, AFTER `action` opens the popup -
            // not as a separate statement run immediately. This page is itself the content of
            // #mainiframecontainer, so setting mif.src tears down THIS page's own JS context
            // (window/document, including any pending timers) the instant it runs. Done outside
            // the timeout (i.e. before it fires), that navigation was cancelling the pending
            // setTimeout before it ever got to open the popup - "Template Creation" looked like
            // it did nothing at all, only the new tab opened.
            string script =
                "window.open('" + newTabUrl + "','_blank');" +
                "setTimeout(function(){" +
                    action +
                    "try { var mif = (window.top || window).document.getElementById('mainiframecontainer'); if (mif) { mif.src = 'E_royal_Impex_Home.aspx'; } } catch (e) {}" +
                "}, 300);";

            ClientScript.RegisterStartupScript(this.GetType(), "OpenAndPopup", script, true);
        }
    }
}