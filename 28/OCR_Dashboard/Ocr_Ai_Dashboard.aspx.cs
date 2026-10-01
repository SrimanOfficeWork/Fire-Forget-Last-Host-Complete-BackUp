using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
using Ionic.Zip;

public partial class OCR_Dashboard_Ocr_Ai_Dashboard : System.Web.UI.Page
{
    AppSession aps = new AppSession();

    protected bool showImport, showExport, showXmlJson, showImpExcel, showExpExcel, showImpChecklist;

    public string companyId, currentUser, sourceFolder, script, PDF_TYPE, zipName;

    protected void Page_Load(object sender, EventArgs e)
    {
        PDF_TYPE = Request.QueryString["Job_type"];

        aps.checkSession();

        showImport = Connection.Import_OCR() == "T";
        showExport = Connection.Export_OCR() == "T";
        showXmlJson = Connection.Export_XmlJson() == "T";
        showImpExcel = Connection.Import_Excel() == "T";
        showExpExcel = Connection.Export_Excel() == "T";
        showImpChecklist = Connection.Import_Checklist() == "T";

        script = string.Format(@"var SHOW_IMPORT = {0};var SHOW_EXPORT = {1};var SHOW_XMLJSON = {2};var SHOW_IMPORT_EXCEL = {3};var SHOW_EXPORT_EXCEL = {4};var SHOW_IMPORT_CHECKLIST = {5};var PDF_TYPE = '{6}';",
            showImport.ToString().ToLower(), showExport.ToString().ToLower(), showXmlJson.ToString().ToLower(), showImpExcel.ToString().ToLower(), showExpExcel.ToString().ToLower(), showImpChecklist.ToString().ToLower(), PDF_TYPE ?? "");

        ScriptManager.RegisterStartupScript(this, this.GetType(), "ocrFlags", script, true);

        companyId = Session["COMPANY_ID"] != null ? Session["COMPANY_ID"].ToString() : "";
        currentUser = Session["currentuser"] != null ? Session["currentuser"].ToString() : "";
        tabLogs.Visible = btnLogsTab.Visible = companyId == "1" || companyId == "10" || companyId == "3352" || string.Equals(currentUser, "rts", StringComparison.OrdinalIgnoreCase);

        if (!IsPostBack)
        {
        }
    }

    public string PDF_SUBSCRIBED_CLASS
    {
        get { return ""; }
    }
    
    protected void btnDownloadLogsZip_Click(object sender, EventArgs e)
    {
        try
        {
            sourceFolder = Server.MapPath("~/Submission/OCRImpExpLog/");
            if (!System.IO.Directory.Exists(sourceFolder))
            {
                Alert_msg("No log folder found yet - nothing has been logged.");
                return;
            }

            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectory(sourceFolder, "OCRImpExpLog");

                Response.Clear();
                Response.BufferOutput = false;
                zipName = "OCRImpExpLog_" + DateTime.Now.ToString("dd-MM-yyyy-HHmmss") + ".zip";
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(Response.OutputStream);
                Response.End();
            }
        }
        catch (System.Threading.ThreadAbortException)
        {            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Alert_msg(string msg)
    {
        msg = msg.Replace("'", "\\'");
        string script = "alert('" + msg + "');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "logZipAlert", script, true);
    }
}