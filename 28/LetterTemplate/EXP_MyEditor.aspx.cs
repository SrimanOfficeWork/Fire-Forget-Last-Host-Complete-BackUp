using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using TextEditor.Model;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;

public partial class LetterTemplate_EXP_MyEditor : ThemeClass
{
    AppSession aps = new AppSession();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Load_JobnoNew();
        }
        
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<TableVariables> GetTableVariables()
    {
        IMP_EXP_Letter_Template.IMP_EXP = "E";
        IMP_EXP_Letter_Template.BRANCH_COMMON = Branch_code();
        IMP_EXP_Letter_Template.Flag = "SELECT_TEMP_COLUMNS";

        var dt = IMP_EXP_Letter_Template.GetTemplateNames();

        List<TableVariables> lstTableVariables = new List<TableVariables>();
        List<TableColumns> lstTableColumns = new List<TableColumns>();

        foreach (DataRow row in dt.Rows)
        {
            if (lstTableVariables.Where(x => x.TableName == row["TableName"].ToString()).ToList().Count == 0)
            {
                TableVariables obj = new TableVariables()
                {
                    TableName = row["TableName"].ToString(),
                    ColumnNames = new List<TableColumns>()
                };
                lstTableVariables.Add(obj);
            }
        }
        foreach (DataRow row in dt.Rows)
        {
            var obj = lstTableVariables.Where(x => x.TableName == row["TableName"].ToString()).FirstOrDefault();
            TableColumns tableColumns = new TableColumns()
            {
                ColumnName = row["ColumnName"].ToString(),
                OrderBy = Convert.ToInt32(row["OrderBy"].ToString())
            };
            obj.ColumnNames.Add(tableColumns);
        }
        return new JavaScriptSerializer().ConvertToType<List<TableVariables>>(lstTableVariables);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<TemplateModel> LoadTemplates()
    {
        IMP_EXP_Letter_Template.IMP_EXP = "E";
        IMP_EXP_Letter_Template.BRANCH_COMMON = Branch_code();
        IMP_EXP_Letter_Template.Flag = "SELECT_TEMP_NAME";
        var dt = IMP_EXP_Letter_Template.GetTemplateNames();

        List<TemplateModel> lstTemplateModel = new List<TemplateModel>();
        lstTemplateModel.Add(new TemplateModel() { TemplateId = 0, TemplateName = "---Select---" });
        foreach (DataRow row in dt.Rows)
        {
            TemplateModel templateModel = new TemplateModel()
            {
                TemplateId = Convert.ToInt32(row["ID"].ToString()),
                TemplateName = row["TEMP_NAME"].ToString()
            };
            lstTemplateModel.Add(templateModel);
        }
        return new JavaScriptSerializer().ConvertToType<List<TemplateModel>>(lstTemplateModel); //JavaScriptSerializer().Serialize(templateModel);  
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string LoadTemplateSource(string templateId)
    {
        string strHTML = string.Empty;
        IMP_EXP_Letter_Template.IMP_EXP = "E";
        IMP_EXP_Letter_Template.ID = templateId;
        IMP_EXP_Letter_Template.BRANCH_COMMON = Branch_code();
        IMP_EXP_Letter_Template.Flag = "LOAD_HTMLSource";

        var dt = IMP_EXP_Letter_Template.GetTemplateNames();
        if (dt.Rows.Count > 0)
        {
            strHTML = dt.Rows[0]["HTMLSource"].ToString();
        }
        return new JavaScriptSerializer().ConvertToType<string>(strHTML);
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static TemplateModel GenerateTemplate(string name, string Tempname)
    {
        DataTable dt = new DataTable();

        IMP_EXP_Letter_Template.IMP_EXP = "E";
        IMP_EXP_Letter_Template.ID = Tempname;
        IMP_EXP_Letter_Template.TEMP_NAME = name;
        IMP_EXP_Letter_Template.BRANCH_COMMON = Branch_code();
        IMP_EXP_Letter_Template.Flag = "LOAD_RPT_DATA";

        dt = IMP_EXP_Letter_Template.GetTemplateNames();
        string strHTML = dt.Rows[0][0].ToString();

        TemplateModel templateModel = new TemplateModel()
        {
            HTMLSource = strHTML,
           // TemplateFields = lstTemplateField
        };

        return new JavaScriptSerializer().ConvertToType<TemplateModel>(templateModel); //JavaScriptSerializer().Serialize(templateModel);  
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string SaveTemplate(string templateName, string templateHtmlSource)
    {
        string strSavedTemplateFields = string.Empty; int i = 0;
        string pattern = string.Format( "{0}{1}{2}", Regex.Escape("{"),".+?", Regex.Escape("}"));
        foreach (var m in Regex.Matches(templateHtmlSource, pattern))
        {
            strSavedTemplateFields = strSavedTemplateFields + m.ToString().Split('{', '}')[1] + ",";
        }
        strSavedTemplateFields = strSavedTemplateFields.TrimEnd(',');

        if (templateName != "")
        {
            i= Save_Update(templateName, strSavedTemplateFields, templateHtmlSource ,"S","");
        }
        return new JavaScriptSerializer().ConvertToType<string>(i.ToString());
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string UpdateTemplate(int templateId, string templateHtmlSource)
    {
        string strSavedTemplateFields = string.Empty, Msg = string.Empty;
        string pattern = string.Format( "{0}{1}{2}", Regex.Escape("{"), ".+?", Regex.Escape("}"));

        foreach (var m in Regex.Matches(templateHtmlSource, pattern))
        {
            strSavedTemplateFields = strSavedTemplateFields + m.ToString().Split('{', '}')[1] + ",";
        }
        strSavedTemplateFields = strSavedTemplateFields.TrimEnd(',');
        Save_Update("", strSavedTemplateFields, templateHtmlSource, "U", templateId.ToString());

        Msg = "Template Successfully Updated.";
        return new JavaScriptSerializer().ConvertToType<string>(Msg);
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static string DeleteTemplate(int templateId)
    {
        Save_Update("", "", "", "D", templateId.ToString());
        return new JavaScriptSerializer().ConvertToType<string>("Template Deleted Saved.");
    }
    private static int Save_Update(string TEMP_NAME, string TEMP_FIELDS, string TEMP_FIELDS_TAG ,string Flag ,string ID)
    {
        IMP_EXP_Letter_Template.ID = ID;
        IMP_EXP_Letter_Template.IMP_EXP = "E";
        IMP_EXP_Letter_Template.TEMP_NAME = TEMP_NAME;
        IMP_EXP_Letter_Template.TEMP_FIELDS = TEMP_FIELDS;
        IMP_EXP_Letter_Template.TEMP_FIELDS_TAG = TEMP_FIELDS_TAG;
        IMP_EXP_Letter_Template.BRANCH_CODE = HttpContext.Current.Session["currentbranch"].ToString();
        IMP_EXP_Letter_Template.BRANCH_COMMON = Branch_code();
        IMP_EXP_Letter_Template.USER_ID = HttpContext.Current.Session["currentuser"].ToString(); 
        IMP_EXP_Letter_Template.Flag = Flag;
        IMP_EXP_Letter_Template.IE_Letter_Temp_IUD();
        return IMP_EXP_Letter_Template.result;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<TemplateModel> Load_Jobno()
    {
        IMP_EXP_Letter_Template.IMP_EXP = "E";
        IMP_EXP_Letter_Template.BRANCH_COMMON = Branch_code();
        IMP_EXP_Letter_Template.Flag = "IMP_JOBNO";
        var dt = IMP_EXP_Letter_Template.GetTemplateNames();

        List<TemplateModel> lstTemplateModel = new List<TemplateModel>();
        lstTemplateModel.Add(new TemplateModel() { TemplateId = 0, TemplateName = "---Select---" });
        foreach (DataRow row in dt.Rows)
        {
            TemplateModel templateModel = new TemplateModel()
            {
                TemplateId = Convert.ToInt32(row["JOBNO"].ToString()),
                TemplateName = row["JOBNO_PS"].ToString()
            };
            lstTemplateModel.Add(templateModel);
        }
        return new JavaScriptSerializer().ConvertToType<List<TemplateModel>>(lstTemplateModel); //JavaScriptSerializer().Serialize(templateModel);  
    }

    public static string Branch_code()
    {
        string BR, currentbranch, SELECT_TYPE;
        currentbranch = HttpContext.Current.Session["currentbranch"].ToString();
        if (HttpContext.Current.Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();
            if (SELECT_TYPE == "Branchwise Job")
            {
                BR = currentbranch;
            }
            else
            {
                BR = "";
            }
        }
        else
        {
            BR = "";
        }
        return BR;
    }

    public void Load_JobnoNew()
    {
        IMP_EXP_Letter_Template.IMP_EXP = "E";
        IMP_EXP_Letter_Template.BRANCH_COMMON = Branch_code();
        IMP_EXP_Letter_Template.Flag = "IMP_JOBNO";
        DataTable dt = IMP_EXP_Letter_Template.GetTemplateNames();
        ddlJobNo.Items.Clear();

        ddlJobNo.DataSource = dt;

        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Insert(0, "--Select--");

    }


    protected void btn2_Click(object sender, EventArgs e)
    {
        //if (CKEditor1.Text != "")
        //{
        //    Session["CKEDIT-Letter"] = CKEditor1.Text.ToString();
        //    Response.Redirect("~/Report/Import_ReportViewerNewFont.aspx?LetterTemp=Y");
        //}
        if (CKEditor1.Text != "")
        {
            string ss = CKEditor1.Text.ToString();
            Literal lbl = new Literal();
            ss = ss.Replace("<hr />", "").Replace("<table", "<br/><br/><table");
            int tablecnt = Regex.Matches(ss.ToLower(), "<table").Count;
            lbl.Text = ss.ToString();

            string filename = "LetterTemplate.pdf";

            Response.Clear();
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
            //Response.AppendHeader("Content-Disposition", "inline; filename=" + filename);


            using (StringWriter sw = new StringWriter())
            {

                HtmlTextWriter hw = new HtmlTextWriter(sw);
                lbl.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());

                Document pdfDoc = new Document(PageSize.A4, 40f, 10f, 5f, 5f);

                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);



                pdfDoc.Open();

                //pdfDoc.HtmlStyleClass = " <style type='text/css'>  .style1  {  font-family: 'Calibri (Body)'; } </style>";

                StyleSheet ST = new StyleSheet();
                FontFactory.Register("c:\\windows\\fonts\\Calibri.ttf");

                ST.LoadTagStyle("body", "face", "Calibri");
                ST.LoadTagStyle("body", "Size", "20px");
                htmlparser.SetStyleSheet(ST);
                htmlparser.StartDocument();
                htmlparser.Parse(sr);
                htmlparser.EndDocument();
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
            }
        }

    }

 

}