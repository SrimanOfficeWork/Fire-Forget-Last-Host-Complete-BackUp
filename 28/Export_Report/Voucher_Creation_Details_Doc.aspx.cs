using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;

public partial class Export_Report_Voucher_Creation_Details_Doc : ThemeClass
{
    DataTable dt = new DataTable();
    DataRow dr;
    DataSet dss = new DataSet();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);

    AppSession aps = new AppSession();
    Voucher_creation VC = new Voucher_creation();

    public string currentbranch, currentuser, Working_Period, SELECT_BRANCH, VOUCHER_ID, KYC_SUB_ID, DOCUMENTS_NAME, path,Customer_name;
    public string errorFolder = "", fileName, attach_File, Upload_Flag, NAME;


    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();

        currentbranch = Connection.Current_Branch();
        Working_Period = Connection.WorkingPeriod();
        currentuser = Connection.Current_User();
        SELECT_BRANCH = Connection.Get_Company_Type();
        Customer_name = Session["Customer_Name"].ToString();
        VOUCHER_ID = Session["Voucher_id"].ToString();
       // KYC_SUB_ID = Session["KYC_SUB_ID"].ToString();
        txt_dirname.Text = Customer_name;



        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/Voucher_docs/");
        //errorFolder = HttpContext.Current.Server.MapPath("~/Customer_Docs/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + "_docs" + "/");
        if (!IsPostBack)

        {
            if (Directory.Exists(errorFolder) == false)
            {
                Directory.CreateDirectory(errorFolder);
            }

            //Documents_Required();
            grid_Bind();

        }
    }


    public void grid_Bind()
    {

        VC.flag = "SELECT";
        VC.Voucher_id = VOUCHER_ID;
        VC.DOCUMENTS_NAME = DOCUMENTS_NAME;
        VC.FILE_PATH = path;
        Insert_Update(VC.flag, VC.Voucher_id, VC.DOCUMENTS_NAME, path);
    }



    protected void btn_Save_Click(object sender, EventArgs e)
    {
    }


    public void Insert_Update(string flag, string VOUCHER_ID, string DOCUMENTS_NAME, string path)
    {

        VC.Voucher_id = VOUCHER_ID;
        //VC.KYC_SUB_ID= KYC_SUB_ID;
        VC.Customer_Name = Customer_name;
        //VC.IEC_NUMBER=IEC_NUMBER;
        //VC.NAME = NAME;
        VC.DOCUMENTS_NAME = DOCUMENTS_NAME;
        VC.FILE_PATH = fileName;
        VC.flag = flag;
        VC.USER_ID = currentuser;
        VC.BRANCH_CODE = currentbranch;
        VC.WORKING_PERIOD = Working_Period;
        dss = VC.Voucher_Creation_Doc_Details_Insert();

        if (dss.Tables.Count > 0)
        {
            DataTable da = new DataTable();

            if (dss.Tables[0].Rows.Count > 0)
            {

                gvdetails.DataSource = dss.Tables[0];
                gvdetails.DataBind();


                ViewState["dt"] = dss.Tables[0];
            }
            else
            {

                gvdetails.DataSource = da;
                gvdetails.DataBind();

            }

        }
        else
        {
            pageload();
        }

    }


    public void Delete(string flag, string VOUCHER_ID, string DOCUMENTS_NAME, string path)
    {

        VC.Voucher_id = VOUCHER_ID;
        VC.Customer_Name = Customer_name;
        VC.DOCUMENTS_NAME = DOCUMENTS_NAME;
        VC.FILE_PATH = path;
        VC.flag = flag;
        VC.BRANCH_CODE = currentbranch;
        VC.WORKING_PERIOD = Working_Period;
        dss = VC.Voucher_Creation_Doc_Details_Insert();
    }

    public void pageload()
    {
        DataColumn da = new DataColumn("UPLOAD_DATE", typeof(DateTime));
        DataColumn da1 = new DataColumn("DOCUMENTS_NAME");
        DataColumn da2 = new DataColumn("Voucher_id");
        DataTable dtt = new DataTable();
        dtt.Columns.Add(da);
        dtt.Columns.Add(da1);
        dtt.Columns.Add(da2);
        dr = dtt.NewRow();

        string a = String.Format("{0: dd/MM/yyyy HH:mm:ss}", Convert.ToString(DateTime.Parse(String.Format("{0: dd/MM/yyyy HH:mm:ss}", DateTime.Now), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault)));
        dr["UPLOAD_DATE"] = a;

        dr["DOCUMENTS_NAME"] = "";
        dr["Voucher_id"] = "";

        dtt.Rows.Add(dr);
        ViewState["dt"] = dtt;
    }

    protected void GridView1_OnDataBound(object source, EventArgs e)
    {

    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        HttpFileCollection fileCollection = Request.Files;

        for (int i = 0; i < fileCollection.Count; i++)
        {
            HttpPostedFile uploadfile = fileCollection[i];



            if (Path.GetFileName(uploadfile.FileName) != "")
            {
                
                
                string ext = Path.GetExtension(uploadfile.FileName).ToLower();
                fileName = (FileUpload1.FileName);
                if (ext == ".sb" || ext == ".be" || ext == ".rtf" || ext == ".txt" || ext == ".doc" || ext == ".docx" || ext == ".xml" || ext == ".html" || ext == ".htm" || ext == ".xls" || ext == ".xlsx" || ext == ".pdf" || ext == ".jpg" || ext == ".jpeg" || ext == ".zip" || ext == ".rar" || ext == ".png" || ext == ".gif" || ext == ".rpl")
                {
                    if (uploadfile.ContentLength > 0)
                    {
                        if (uploadfile.ContentLength < 10485760)
                        {

                            string file = fileName;
                            hidden_path.Value= path = errorFolder + file;
                            VC.flag = "FILE_EXISTS";
                            VC.DOCUMENTS_NAME = fileName;
                            VC.FILE_PATH = path;
                            VC.Voucher_id = VOUCHER_ID;
                            Upload_Flag = "UPLOAD";
                            Insert_Update(VC.flag, VC.Voucher_id, VC.DOCUMENTS_NAME, path);
                            HiddenDoc.Value = Convert.ToString(VC.UPDATE_ID);
                            if (VC.result == 1)
                            {
                                Alert_msg("File already exists! Please Try another one file for upload");
                                grid_Bind();
                            }
                            else
                            {
                                uploadfile.SaveAs(errorFolder + file);
                                txtItem_TextChanged(sender, e);
                                Alert_msg("File uploaded sucessfully");
                            }
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        Alert_msg("File cannot be empty");
                    }
                }
                else
                    Alert_msg(ext + " File format not allowed.");
            }
            else
                Alert_msg("No Files Selected.");
        }
    }
    protected void txtItem_TextChanged(object sender, EventArgs e)
    {

        if (Upload_Flag == "UPLOAD")
        {
            VC.flag = "Upload_File";
            path = hidden_path.Value;
            VC.DOCUMENTS_NAME = fileName;
            Insert_Update(VC.flag, VC.Voucher_id, VC.DOCUMENTS_NAME, path);
        }


    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "txt";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "txt";
    }



    protected void gvdetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvdetails.PageIndex = e.NewPageIndex;
        grid_Bind();

    }

    protected void btn_File_Delete_Click(object source, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");
        for (int i = 0; i < gvdetails.Rows.Count; i++)
        {
            if (chkAll.Checked)
            {
                CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    VC.flag = "DELETE_ALL_FILE";
                    VC.Voucher_id = VOUCHER_ID;
                    //VC.KYC_SUB_ID = KYC_SUB_ID;
                    Insert_Update(VC.flag, VC.Voucher_id, VC.DOCUMENTS_NAME, path);
                }
            }
            else
            {
                CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
                if (chk.Checked)
                {
                    VC.flag = "DELETE_UPLOAD_FILE";
                    VC.Voucher_id = VOUCHER_ID;
                    //kyc.KYC_SUB_ID = KYC_SUB_ID;
                    VC.DOC_ID=gvdetails.Rows[i].Cells[2].Text;
                    Insert_Update(VC.flag, VC.Voucher_id, VC.DOCUMENTS_NAME, path);
                }

            }
        }
        if (VC.result == 1)
        {
            Alert_msg("File Deleted");
            grid_Bind();
        }

    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'VOUCHER CREATION DOC UPLOAD', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Date_Time dt = new Date_Time();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton txt = (LinkButton)e.Row.FindControl("txtdate");
            if (txt.Text != "" && txt.Text != "&nbsp;")
            {
                //txt.Text = dt.Split_main("~~", txt.Text);
            }
            CheckBox headerchk = (CheckBox)gvdetails.HeaderRow.FindControl("chkAll");
            CheckBox childchk = (CheckBox)e.Row.FindControl("chk");
            childchk.Attributes.Add("onclick", "javascript:Selectchildcheckboxes('" + headerchk.ClientID + "','gvdetails','btn_File_Delete')");
        }
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        if (lnkbtn.Text != "" && lnkbtn.Text != "&nbsp;")
        {
            System.IO.FileInfo file = new System.IO.FileInfo(errorFolder  + lnkbtn.Text);
            string filePath = errorFolder +  lnkbtn.Text;
            string ext = Path.GetExtension(file.Name).ToLower();

            Response.Clear();
            Response.ClearContent();

            if (ext == ".doc" || ext == ".docx")
            {
                Response.ContentType = "Application/msword";
            }
            else if (ext == ".pdf")
            {
                Response.ContentType = "Application/pdf";
            }
            else if (ext == ".xls" || ext == ".xlsx")
            {
                Response.ContentType = "Application/x-msexcel";
            }
            else if (ext == ".jpg" || ext == ".jpeg")
            {
                Response.ContentType = "image/jpeg";
            }
            else if (ext == ".gif")
            {
                Response.ContentType = "image/GIF";
            }
            else if (ext == ".html" || ext == ".htm")
            {
                Response.ContentType = "text/HTML";
            }
            else if (ext == ".txt" || ext == ".be" || ext == ".sb")
            {
                Response.ContentType = "text/plain";
            }
            else
            {
                Response.ContentType = MimeType(Path.GetExtension(file.Name));
            }

            Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkbtn.Text);
            Response.AddHeader("Content-Length", file.Length.ToString());

            Response.TransmitFile(file.FullName);
            Response.End();


        }
    }
    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension))
            return mime;
        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
        {
            if (ext == ".rtf" || ext == ".doc")
            {
                mime = "application/rtf";
            }
            else if (ext == ".sb" || ext == ".be" || ext == ".SB" || ext == ".BE")
            {
                mime = "text/plain";
            }
            else
                mime = rk.GetValue("Content Type").ToString();
        }
        return mime;
    }

}