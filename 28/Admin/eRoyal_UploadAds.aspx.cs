using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Text;

public partial class eRoyal_UploadAds : ThemeClass
{
    DataRow dr;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    DataSet dss = new DataSet();
    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    AppSession aps = new AppSession();
    public string errorFolder = "", fileName, attach_File, Upload_Flag, active;
    public int i;
    Upload_Ad jh = new Upload_Ad();
    Global_variables ObjUBO = new Global_variables();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        errorFolder = HttpContext.Current.Server.MapPath("~/Submission/Upload_Poster/");
        if (!IsPostBack)
        {
            gvdetails.Columns[3].Visible = false;
            dt.Columns.Add("ATTACHMENT_FILE");
            dt.Columns.Add("DISPLAY_ORDER");
            dt.Columns.Add("FILE_PATH");
            dt.Columns.Add("ACTIVE");
            grid_Bind();
        }
    }

    public void grid_Bind()
    {
        ObjUBO.A1 = "SELECT";
        dss = jh.Upload_Ads_Ins_Up(ObjUBO, "");
        gvdetails.DataSource = dss.Tables[0];
        gvdetails.DataBind();
        ViewState["File_ds"] = dss.Tables[0];
    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        string saveFolder = Server.MapPath("~/Submission/Upload_Poster/");
        if (!Directory.Exists(saveFolder)) Directory.CreateDirectory(saveFolder);
        dt = ViewState["File_ds"] as DataTable ?? dt;
        int displayOrder = 1;
        foreach (GridViewRow row in gvdetails.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("ischk");
            Label lblFileName = (Label)row.FindControl("lblFileName");
            if (lblFileName != null)
            {
                string fileName = lblFileName.Text;
                string fullPath = Path.Combine(saveFolder, fileName);

                DataRow[] rowsToUpdate = dt.Select("ATTACHMENT_FILE = '" + fileName.Replace("'", "''") + "'");
                foreach (DataRow dr in rowsToUpdate) dr["ACTIVE"] = "False";

            }
        }
        if (FileUpload1.HasFiles)
        {
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                string fullPath = Path.Combine(saveFolder, fileName);
                if (!File.Exists(fullPath)) postedFile.SaveAs(fullPath);
                DataRow[] exists = dt.Select("ATTACHMENT_FILE = '" + fileName.Replace("'", "''") + "'");
                if (exists.Length == 0) dt.Rows.Add(fileName, displayOrder++, fullPath, "False");
            }
        }
        if (dt.Rows.Count > 0)
        {
            ViewState["File_ds"] = dt;
            string xmlData = ConvertDataTableToXML(dt);
            ObjUBO.A1 = "UPLOAD_FILE";
            ds = jh.Upload_Ads_Ins_Up(ObjUBO, xmlData);
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
            Alert_msg("Files uploaded and processed successfully.");
        }
        else Alert_msg("No files selected or all were removed.");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (gvdetails.Rows.Count == 0)
        {
            Alert_msg("No records found to process.");
            return;
        }
        DataTable dtUpdated = new DataTable();
        dtUpdated.Columns.Add("ATTACHMENT_FILE", typeof(string));
        dtUpdated.Columns.Add("DISPLAY_ORDER", typeof(int));
        dtUpdated.Columns.Add("FILE_PATH", typeof(string));
        dtUpdated.Columns.Add("ACTIVE", typeof(string));
        List<DataRow> rowsToDelete = new List<DataRow>();
        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            GridViewRow row = gvdetails.Rows[i];
            CheckBox chk = row.FindControl("ischk") as CheckBox;
            string attachmentFile = gvdetails.DataKeys[i]["ATTACHMENT_FILE"].ToString();
            string filePath = gvdetails.DataKeys[i]["FILE_PATH"].ToString();
            TextBox txt_Order = (TextBox)gvdetails.Rows[i].FindControl("txt_Order");
            string DisplayOrder = txt_Order.Text.Trim();
            DataRow newRow = dtUpdated.NewRow();
            newRow["ATTACHMENT_FILE"] = attachmentFile;
            newRow["DISPLAY_ORDER"] = DisplayOrder;
            newRow["FILE_PATH"] = filePath;
            newRow["ACTIVE"] = chk != null && chk.Checked ? "True" : "False";
            dtUpdated.Rows.Add(newRow);
            if (chk != null && chk.Checked)
            {
                if (hfActionFlag.Value == "DELETE_UPLOAD_FILE")
                {
                    if (File.Exists(filePath)) File.Delete(filePath);
                    rowsToDelete.Add(newRow);
                }
            }
        }
        foreach (DataRow row in rowsToDelete)
        {
            dtUpdated.Rows.Remove(row);
        }
        if (dtUpdated.Rows.Count == 0)
        {
            Alert_msg("No files selected to keep.");
            return;
        }
        ViewState["File_ds"] = dtUpdated;
        string xmlData = ConvertDataTableToXML(dtUpdated);
        ObjUBO.A1 = "UPLOAD_FILE";
        ds = jh.Upload_Ads_Ins_Up(ObjUBO, xmlData);
        if (ds != null && ds.Tables.Count > 0)
        {
            gvdetails.DataSource = ds.Tables[0];
            gvdetails.DataBind();
        }
        else
        {
            gvdetails.DataSource = dtUpdated;
            gvdetails.DataBind();
        }
        if (hfActionFlag.Value == "DELETE_UPLOAD_FILE")
        {
            Alert_msg("Files Deleted successfully.");
        }
        else
        {
            Alert_msg("Files Updated successfully.");
        }
    }


    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns) col.ColumnMapping = MappingType.Attribute;
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal) e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate) e.Row.CssClass = "alternate";
    }

    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
        grid_Bind();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Upload', function (r) {{}});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Date_Time dt = new Date_Time();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton txt = (LinkButton)e.Row.FindControl("txtfilename");
        }
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        if (lnkbtn.Text != "" && lnkbtn.Text != "&nbsp;")
        {
            System.IO.FileInfo file = new System.IO.FileInfo(errorFolder + lnkbtn.Text);
            string filePath = errorFolder + lnkbtn.Text;
            string ext = Path.GetExtension(file.Name).ToLower();
            Response.Clear();
            Response.ClearContent();
            if (ext == ".doc" || ext == ".docx") Response.ContentType = "Application/msword";
            else
                if (ext == ".pdf") Response.ContentType = "Application/pdf";
                else
                    if (ext == ".xls" || ext == ".xlsx") Response.ContentType = "Application/x-msexcel";
                    else
                        if (ext == ".jpg" || ext == ".jpeg") Response.ContentType = "image/jpeg";
                        else
                            if (ext == ".gif") Response.ContentType = "image/GIF";
                            else
                                if (ext == ".html" || ext == ".htm") Response.ContentType = "text/HTML";
                                else
                                    if (ext == ".txt" || ext == ".be" || ext == ".sb") Response.ContentType = "text/plain";
                                    else Response.ContentType = MimeType(Path.GetExtension(file.Name));
            Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkbtn.Text);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.TransmitFile(file.FullName);
            Response.End();
        }
    }

    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension)) return mime;
        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
        {
            if (ext == ".rtf" || ext == ".doc") mime = "application/rtf";
            else if (ext == ".sb" || ext == ".be" || ext == ".SB" || ext == ".BE") mime = "text/plain";
            else mime = rk.GetValue("Content Type").ToString();
        }
        return mime;
    }
}
