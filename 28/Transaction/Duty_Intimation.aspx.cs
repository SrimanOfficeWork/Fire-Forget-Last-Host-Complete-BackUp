using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Transaction_Duty_Intimation : ThemeClass
{
 
    Duty_Intimation duty = new Duty_Intimation();
    Transaction Transact = new Transaction();
    CheckList CHKLIST = new CheckList();
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
  
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, SCHEME_CODE, RITC_NO, ITEM_DESC;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string FILE_REF_NO, BRANCH_NO, IEC_NO, TRANSPORT_MODE, Attach_Folder;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        // commented for areawise implementation on 05-mar-2020
        /*

        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
        
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            Get_JobNo();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            /*
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            */
        }
        //changed by jayanthi on 7-Mar-2020
        //Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["currentbranch"].ToString() + "/" + "Attachments/");
        Attach_Folder = HttpContext.Current.Server.MapPath("~/Submission/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + HttpContext.Current.Session["GroupName"].ToString() + "/" + "Attachments/");
    }
    public void Get_JobNo()
    {
       
        CHKLIST.JOBNo = "";
        CHKLIST.Ename = "select_jobno";
        CHKLIST.Workingperiod = SELECT_BRANCH;
        ddlJobNo.DataSource = CHKLIST.RetrieveAll_General_Details();
        dtuser = CHKLIST.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string F = "S";
            i = Duty_Intimation_Insert_Update(F);
            if (i == 1)
            {
                Alert_msg("Saved Successfully", "btnSave");
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnSave");
            }
            else
            {
                Alert_msg("Not Saved", "btnSave");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            string F = "U";
            i = Duty_Intimation_Insert_Update(F);
            if (i == 1)
            {
                Alert_msg("Updated Successfully", "btnUpdate");
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnUpdate");
            }
            else
            {
                Alert_msg("Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            string F = "D";
            i = Duty_Intimation_Insert_Update(F);
            if (i == 1)
            {
                Alert_msg("Record Deleted", "btnUpdate");
                ddlJobNo_SelectedIndexChanged(sender, e);
            }
            
            else
            {
                Alert_msg("Record Not Deleted", "btnUpdate");
            }


        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Duty Intimation', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Duty Intimation', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Add CSS class on header row.
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        //Add CSS class on normal row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        //Add CSS class on alternate row.
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Clear();
            if (ddlJobNo.SelectedValue == "Select")
            {
                Clear();

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = false;
            }
            else
            {
                DataSet dss = new DataSet();
                duty.JOBNO = ddlJobNo.SelectedItem.Text;
                duty.BRANCH_CODE = SELECT_BRANCH;
                duty.Ename = "Email_Read_Select";
                dss = duty.EmailsRead();
                gvdetails.DataSource = dss;
                gvdetails.DataBind();

                CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                CHKLIST.Ename = "select_duty_intimation";

                CHKLIST.Workingperiod = SELECT_BRANCH;
                DataSet ds = new DataSet();
                ds = CHKLIST.RetrieveAll_General_Details();

                if (ds.Tables[0].Rows[0]["Job_Type"].ToString() == "N")
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtDescription.Text = ds.Tables[1].Rows[0]["ITEM_DESCRIPTION"].ToString();
                        txtAss_Value.Text = ds.Tables[1].Rows[0]["ASSESSABLE_VALUE"].ToString();
                        txtDuty_Amount.Text = ds.Tables[1].Rows[0]["DUTY_VALUE"].ToString();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtPackages.Text = ds.Tables[2].Rows[0]["NO_PKG"].ToString();
                        txtGross_Weight.Text = ds.Tables[2].Rows[0]["GROSS_WT"].ToString();
                    }
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtInvoiceNo.Text = ds.Tables[3].Rows[0]["INVOICE_NO"].ToString();
                        txtInvoiceDate.Text = ds.Tables[3].Rows[0]["INV_DATE"].ToString();
                        txtSupplier_Name.Text = ds.Tables[3].Rows[0]["SUPPLIER_NAME"].ToString();
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        txtImporter.Text = ds.Tables[4].Rows[0]["IMPORTER_NAME"].ToString();
                        txtAddress1.Text = ds.Tables[4].Rows[0]["ADDRESS1"].ToString();
                        txtAddress2.Text = ds.Tables[4].Rows[0]["ADDRESS2"].ToString();
                        txtAddress3.Text = ds.Tables[4].Rows[0]["ADDRESS3"].ToString();
                        txtAddress4.Text = ds.Tables[4].Rows[0]["ADDRESS4"].ToString();
                        txtAddress5.Text = ds.Tables[4].Rows[0]["ADDRESS5"].ToString();
                    }
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        txt_TR6ChallanNo.Text = ds.Tables[5].Rows[0]["TR6_CHALLAN_NO"].ToString();
                        txt_EDD.Text = ds.Tables[5].Rows[0]["EDD"].ToString();
                    }

                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;

                }
                else if (ds.Tables[0].Rows[0]["Job_Type"].ToString() == "U")
                {
                        txtImporter.Text = ds.Tables[1].Rows[0]["IMPORTER_NAME"].ToString();
                        txtAddress1.Text = ds.Tables[1].Rows[0]["ADDRESS1"].ToString();
                        txtAddress2.Text = ds.Tables[1].Rows[0]["ADDRESS2"].ToString();
                        txtAddress3.Text = ds.Tables[1].Rows[0]["ADDRESS3"].ToString();
                        txtAddress4.Text = ds.Tables[1].Rows[0]["ADDRESS4"].ToString();
                        txtAddress5.Text = ds.Tables[1].Rows[0]["ADDRESS5"].ToString();
                        txtAttention.Text = ds.Tables[1].Rows[0]["ATTENTION"].ToString();
                        txtSubject.Text = ds.Tables[1].Rows[0]["SUBJECT"].ToString();
                        txtRef_No.Text = ds.Tables[1].Rows[0]["FILE_REF_NO"].ToString();
                        txtDescription.Text = ds.Tables[1].Rows[0]["DESCRIPTION"].ToString();
                        txtPackages.Text = ds.Tables[1].Rows[0]["PACKAGES"].ToString();
                        txtInvoiceNo.Text = ds.Tables[1].Rows[0]["INVOICE_NO"].ToString();
                        txtInvoiceDate.Text = ds.Tables[1].Rows[0]["INVOICE_DATE"].ToString();
                        txtSupplier_Name.Text = ds.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
                        txtGross_Weight.Text = ds.Tables[1].Rows[0]["GROSSWEIGHT"].ToString();
                        txtAss_Value.Text = ds.Tables[1].Rows[0]["ASSESSABLE_VALUE"].ToString();
                        txtDuty_Amount.Text = ds.Tables[1].Rows[0]["DUTY_VALUE"].ToString();
                        txtDirect_InDirect.Text = ds.Tables[1].Rows[0]["DIRECT_INDIRECT"].ToString();
                        txtName1.Text = ds.Tables[1].Rows[0]["NAME1"].ToString();
                        txtName2.Text = ds.Tables[1].Rows[0]["NAME2"].ToString();
                        txtName3.Text = ds.Tables[1].Rows[0]["NAME3"].ToString();
                        txtDD.Text = ds.Tables[1].Rows[0]["DD"].ToString();
                        txt_TR6ChallanNo.Text = ds.Tables[1].Rows[0]["TR6_CHALLAN_NO"].ToString();
                        txt_EDD.Text = ds.Tables[1].Rows[0]["EDD"].ToString();

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }
    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        string a = gvdetails.DataKeys[gvrow.RowIndex].Value.ToString();
        string filePath = Attach_Folder + a;

        Response.ContentType = "Text/Plain";
        Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");

        Response.TransmitFile(filePath);
        Response.End();
    }
    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
        }
    }

    public int Duty_Intimation_Insert_Update(string Flag)
    {

        duty.DUTY_ID = "0";
        duty.JOBNO = ddlJobNo.SelectedValue;
        duty.FILE_REF_NO = txtRef_No.Text;

        duty.IMPORTER_NAME = txtImporter.Text;
      
        duty.ADDRESS1 = txtAddress1.Text;
        duty.ADDRESS2 = txtAddress2.Text;
        duty.ADDRESS3 = txtAddress3.Text;
        duty.ADDRESS4 = txtAddress4.Text;
        duty.ADDRESS5 = txtAddress5.Text;
        duty.ATTENTION = txtAttention.Text;
        duty.SUBJECT = txtSubject.Text;
        duty.DESCRIPTION = txtDescription.Text;
        duty.PACKAGES = txtPackages.Text;
        duty.INVOICE_NO = txtInvoiceNo.Text;
        duty.INVOICE_DATE = txtInvoiceDate.Text;
        duty.SUPPLIER_NAME = txtSupplier_Name.Text;
        duty.GROSSWEIGHT = txtGross_Weight.Text;
        duty.ASSESSABLE_VALUE = txtAss_Value.Text;
        duty.DUTY_VALUE = txtDuty_Amount.Text;
        duty.DIRECT_INDIRECT = txtDirect_InDirect.Text;
        duty.NAME1 = txtName1.Text;
        duty.NAME2 = txtName2.Text;
        duty.NAME3 = txtName3.Text;
        duty.DD = txtDD.Text;
        duty.TR6_CHALLAN_NO = txt_TR6ChallanNo.Text;
        duty.EDD = txt_EDD.Text;
       
        duty.USER_ID = currentuser;
        duty.YEAR = "";
        duty.flag = Flag;
        duty.BRANCH_CODE = currentbranch;
        duty.WORKING_PERIOD = Working_Period;
        duty.BRANCH_COMMON = SELECT_BRANCH;

        i = duty.Duty_Intimation_insertupdate();
        return i;
    }


    private void Clear()
    {
        txtImporter.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtAddress3.Text = "";
        txtAddress4.Text = "";
        txtAddress5.Text = "";
        txtAttention.Text = "";
        txtSubject.Text = "";
        txtInvoiceNo.Text = "";
        txtInvoiceDate.Text = "";
        txtSupplier_Name.Text = "";
        txtDescription.Text = "";
        txtAss_Value.Text = "";
        txtDuty_Amount.Text = "";
        txtPackages.Text = "";
        txtGross_Weight.Text = "";
        txtRef_No.Text = "";

        txtDirect_InDirect.Text = "";
        txtName1.Text = "";
        txtName2.Text = "";
        txtName3.Text = "";
        txtDD.Text = "";
        txt_TR6ChallanNo.Text = "";
        txt_EDD.Text = "";
    
    }

}