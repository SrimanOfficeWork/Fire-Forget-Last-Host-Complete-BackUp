using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Live_Updation_Notification : ThemeClass
{

    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Live_updation LU = new Live_updation();
    Manipulation mo = new Manipulation();

    public int i;
    public string currentuser;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        if (!IsPostBack)
        {
            Load_Type();
            Edit_Btn();
            btnSearch_Click(sender, e);
        }

    }
    public void Edit_Btn()
    {
        if (ViewState["Scroll_Id"] != "" && ViewState["Scroll_Id"] != null)
        {
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Live_Updation_Insert_Update("S");
        if (i == 1)
        {
            ViewState["UPDATED_ID"] = null;
            Alert_msg("Saved Successfully", "btnSave");
            HDupdate_id.Value = Convert.ToString(LU.UPDATE_ID);

            btnUpdate.CssClass = "save";
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnSave.Focus();
            ddltype.SelectedIndex = 0;
            txtscroll_Msg.Text = string.Empty;
            txtEff_Date.Text = string.Empty;
            txtEfftoDate.Text = string.Empty;
            txtmessage.Text = string.Empty;
        }
        else if (i == 2)
        {
            Alert_msg("Job No Already Exist!", "btnSave");
        }
        else
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            Alert_msg("Not Saved", "btnSave");
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)// Modified by shanthini on 22-07-2026
    {
        Live_Updation_Insert_Update("U");
        if (i == 1)
        {
            if (ViewState["UPDATED_ID"] != null)
            {
                Alert_msg("Updated Successfully", "btnUpdate");
            }
            else
            {
                Alert_msg("Saved Successfully", "btnUpdate");
            }
            ddltype.SelectedIndex = 0;
            txtscroll_Msg.Text = string.Empty;
            txtEff_Date.Text = string.Empty;
            txtEfftoDate.Text = string.Empty;
            txtmessage.Text = string.Empty;
        }
        else if (i == 2)
        {
            Alert_msg("Not Updated", "btnUpdate");
        }
        else
        {
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;
            Alert_msg("Not Saved", "btnUpdate");
        }
    }
    public int Live_Updation_Insert_Update(string S1)
    {
        LU.ID = HDupdate_id.Value.ToString();
        LU.SCROLL_MSG = txtscroll_Msg.Text;
        LU.TYPE = ddltype.SelectedValue.ToString();
        LU.EFFECTIVE_FROM = txtEff_Date.Text;
        LU.EFFECTIVE_TO = txtEfftoDate.Text;

        LU.DETAIL_MSG = txtmessage.Text;
        LU.USERID = currentuser;
        LU.Flag = S1;
        LU.Live_Updation_INS_UPD();
        i = LU.result;
        return i;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        Live_Updation_Insert_Update("D");

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        mo.ResetFields(Page.Controls);

        txtscroll_Msg.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        mo.ResetFields(Page.Controls);

        txtscroll_Msg.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
        LU.TYPE = ddltype_search.SelectedValue.ToString();
        LU.SCROLL_MSG = txtscroll_Msg_Search.Text;

        dss = LU.Master_Search_live_updation();
        gvdetails.DataSource = dss;
        gvdetails.DataBind();

        ddltype.SelectedIndex = 0;
        txtscroll_Msg.Text = string.Empty;
        txtEff_Date.Text = string.Empty;
        txtEfftoDate.Text = string.Empty;
        txtmessage.Text = string.Empty;

        txtscroll_Msg.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;

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
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["Scroll_Id"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);
        HDupdate_id.Value = Convert.ToString(this.gvdetails.SelectedDataKey.Value);
        Edit_ExchangeDetails();
    }
    public void Edit_ExchangeDetails()
    {
        if (ViewState["Scroll_Id"] != "" && ViewState["Scroll_Id"] != null)
        {
            DataSet dss = new DataSet();
            int i = 0;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            LU.ID = ViewState["Scroll_Id"].ToString();
            LU.Flag = "Grid_Select";

            dss = LU.live_updation_Select();
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddltype.SelectedValue = dss.Tables[0].Rows[0]["TYPE"].ToString();
                txtscroll_Msg.Text = dss.Tables[0].Rows[0]["SCROLL_MSG"].ToString();
                txtEff_Date.Text = dss.Tables[0].Rows[0]["EFFECTIVE_FROM"].ToString();
                txtEfftoDate.Text = dss.Tables[0].Rows[0]["EFFECTIVE_TO"].ToString();
                txtmessage.Text = dss.Tables[0].Rows[0]["DETAIL_MSG"].ToString();
            }

        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

        }
    }
    private void Load_Type()
    {
        ddltype_search.Items.Add(new ListItem("", ""));
        ddltype_search.Items.Add(new ListItem("Import", "I"));
        ddltype_search.Items.Add(new ListItem("Export", "E"));
        ddltype_search.Items.Add(new ListItem("Other", "O"));
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnUploadClick_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string err = "";
            if (!validateImage(out err))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "imgErr", "alert('" + err + "');", true);
                return;
            }

            string SavedImagePath = SaveImage();
            LU.Flag = "INSERT";
            LU.ImagePath = SavedImagePath;
            LU.EFFECTIVE_FROM = txtEff_Date.Text;
            LU.EFFECTIVE_TO = txtEfftoDate.Text;

            
            LU.WhatsAppLink = txtWhatsAppLink.Text.Trim(); // Added by shanthini on 22-07-2026
            LU.DriveLink = txtDriveLink.Text.Trim();
            LU.YoutubeLink = txtYoutubeLink.Text.Trim();
            LU.WebsiteLink = txtWebsiteLink.Text.Trim();

            DataSet ds = LU.Live_Updation_Img_Select();
            if (LU.result == 1)
            {
                Alert_msg("Image has been upload successfully", string.Empty);
            }
            txtEff_Date.Text = "";
            txtEfftoDate.Text = "";
        }
    }
 

    public bool validateImage(out string errorMsg)
    {
        errorMsg = "";
        string extenstion = Path.GetExtension(FileUpload1.FileName).ToLower().Trim();
        if (extenstion != ".jpg".Trim() && extenstion != ".png".Trim()&&extenstion!=".jpeg".Trim())
        {
            errorMsg = "Only JPG and PNG files are allowed.";
            return false;
        }
        long size = 5 * 1024 * 1024;
        if (FileUpload1.PostedFile.ContentLength > size)
        {
            errorMsg = "Image size must not exceed 5MB.";
            return false;
        }
        return true;
    }

    public string SaveImage()
    {
        string folder = Server.MapPath("~/images/LiveUpdationImage");
        if (Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
      //  string Ext = Path.GetExtension(FileUpload1.FileName).ToLower();
        string name = Path.GetFileName(FileUpload1.FileName);
        FileUpload1.SaveAs(Path.Combine(folder, name));
        return "~/images/LiveUpdationImage/" + name;
    }
}