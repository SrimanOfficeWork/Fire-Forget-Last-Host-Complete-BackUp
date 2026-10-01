using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class DSR_Mail_Scheduler : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();

    DSR_Automail_Scheduler DSR = new DSR_Automail_Scheduler();
    
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            Load_Client_Name();
            EditGeneralDetails();
        }
    }
    private void Load_Client_Name()
    {
        DataSet dss = new DataSet();
        ObjUBO.A50 = "Load_Template_Client_Name";
        dss = DSR.Auto_Mail_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlReport.DataSource = dss.Tables[0];
            ddlReport.DataTextField = "TEMPLATE_NAME";
            ddlReport.DataValueField = "T_ID";
            ddlReport.DataBind();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            ddlNotifyTo.DataSource = dss.Tables[1];
            ddlNotifyTo.DataTextField = "IMP_EXP_NAME";
            ddlNotifyTo.DataValueField = "IMP_EXP_NAME";
            ddlNotifyTo.DataBind();
        }
        ddlReport.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlReport.SelectedIndex = 0;
        ddlNotifyTo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlNotifyTo.SelectedIndex = 0;
    }

    public void EditGeneralDetails()
    {
        if (Request.QueryString["SCHEDULER_ID"] != "" && Request.QueryString["SCHEDULER_ID"] != null)
        {
           
            ObjUBO.A1 = Request.QueryString["SCHEDULER_ID"].ToString();
            ObjUBO.A50 = "SELECT_CON";
            ds = DSR.Auto_Mail_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HdnUpdate_id.Value = ds.Tables[0].Rows[0]["SCHEDULER_ID"].ToString();
                txtScheduleName.Text = ds.Tables[0].Rows[0]["SCHEDULE_NAME"].ToString();
                ddlNotifyTo.SelectedValue = ds.Tables[0].Rows[0]["NOTIFY_TO"].ToString();
                ddlReport.SelectedItem.Text = ds.Tables[0].Rows[0]["REPORT"].ToString();
                txtSubject.Text = ds.Tables[0].Rows[0]["MAIL_SUBJECT"].ToString();
                txtFrom.Text = ds.Tables[0].Rows[0]["MAIL_FROM"].ToString();
                txtTo.Text = ds.Tables[0].Rows[0]["MAIL_TO"].ToString();
                txtCc.Text = ds.Tables[0].Rows[0]["MAIL_CC"].ToString();
                txtBcc.Text = ds.Tables[0].Rows[0]["MAIL_BCC"].ToString();
                ddlSchedule.SelectedValue = ds.Tables[0].Rows[0]["SCHEDULE"].ToString();
                ddlstatus.SelectedValue = ds.Tables[0].Rows[0]["MAIL_STATUS"].ToString();
                txtMailTemplate.InnerText = ds.Tables[0].Rows[0]["MAIL_BODY"].ToString();
                HdnUpdate_id.Value = ds.Tables[0].Rows[0]["SCHEDULER_ID"].ToString();
                
            }
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnNew.Visible = true;
            btnSave.Visible = false;
        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = false;
          }

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction Transact = new Transaction();
        Transact.ResetFields(Page.Controls);
        txtMailTemplate.InnerText = "";
        HdnUpdate_id.Value = "";
        
        ClientScript.RegisterStartupScript(this.GetType(), "clearPreviewBox", "document.getElementById('previewBox').innerHTML = ''; ", true);
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
    }
    
    public DataSet Mail_Ins_Upd(string flag)
    {
        ObjUBO.A3 =HdnUpdate_id.Value.ToString();
        ObjUBO.A4 = txtScheduleName.Text;
        ObjUBO.A5 = ddlNotifyTo.SelectedValue;
        ObjUBO.A6 = ddlReport.SelectedItem.Text;
        ObjUBO.A7 = txtSubject.Text;
        ObjUBO.A28 = txtFrom.Text;
        ObjUBO.A8 = txtTo.Text;
        ObjUBO.A9 = txtCc.Text;
        ObjUBO.A10 = txtBcc.Text;
        ObjUBO.A11 = hdnMailBody.Value;
        ObjUBO.A13 = ddlSchedule.SelectedValue.ToString();
        ObjUBO.A16 = ddlstatus.SelectedValue.ToString();
        ObjUBO.A50 = flag;
        return DSR.Auto_Mail_Ins_Upd(ObjUBO);
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
       ds=Mail_Ins_Upd("D");
       if (ds.Tables[0].Rows.Count == 0)
       {
           Alert_msg("Deleted Successfully.");
           btnNew_Click(sender, e);
       }
       else
       {
           Alert_msg("Not Deleted !");
       }
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ds = Mail_Ins_Upd("U");
            if(ds.Tables[0].Rows.Count>0)
            {
                txtMailTemplate.InnerText = ds.Tables[0].Rows[0]["MAIL_BODY"].ToString();
                HdnUpdate_id.Value = ds.Tables[0].Rows[0]["SCHEDULER_ID"].ToString();
                Alert_msg("Mail Scheduled update");

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
            }
            else
            {
                Alert_msg("Already Mail Scheduled for Same Notify and Report");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = Mail_Ins_Upd("S");
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtMailTemplate.InnerText = ds.Tables[0].Rows[0]["MAIL_BODY"].ToString();
                HdnUpdate_id.Value = ds.Tables[0].Rows[0]["SCHEDULER_ID"].ToString();
                Alert_msg("Mail Scheduled Successfully");
                
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
            }
            else
            {
               Alert_msg("Already Mail Scheduled for Same Notify and Report");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    [System.Web.Services.WebMethod]
    public static string Get_EmailId(string client)
    {
        string mailid = "";
        DSR_Automail_Scheduler DSR = new DSR_Automail_Scheduler();
        Global_variables ObjUBO = new Global_variables();
        DataSet ds = new DataSet();

        try
        {
            ObjUBO.A2 = client;
            ObjUBO.A50 = "Load_Client_mail";
            ds = DSR.Auto_Mail_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                mailid = ds.Tables[0].Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return mailid;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DSR MAIL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}
