using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;
using BussinessObject;

public partial class Covering_Letter_Vaishnavi : ThemeClass
{
    EGM EGM = new EGM();
    Covering_LTR LTR = new Covering_LTR();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();
    int i, UpdateID;
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH, TRANSPORT_MODE, CUSTOMS_HOUSE;
    Billing_UserBO objUBO = new Billing_UserBO();

    DataSet dss = new DataSet();
    string Bind_Type = "", errorFolder = "", Update_Grid = "";

   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

      
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
        hd_Branch.Value = SELECT_BRANCH;
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");
        
        if (!IsPostBack)
        {
            if (Request.QueryString["Page"] == "New")
            {                           
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSearch.Visible = false;
                btnSave.Visible = true;
                //Get_EGM_JobNo_MAX();
                //Get_Except_JobNo();
                //Bind_EGM_Details();
                BIND_BILL_INVOICE_NO();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    //Bind_Type = "Rotation";
                    hdnfld_Jobno.Value = Request.QueryString["Page"].ToString();
                    //hdn_SB_SlNo.Value = "1";
                    BIND_BILL_INVOICE_NO();
                    Bind_COVERING_Details();
                    //gv_details_Grid_Bind();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSearch.Visible = true;
                    btnSave.Visible = false;
                }
            }

        }
        //if (IsPostBack)
        //{
            //BIND_BILL_INVOICE_NO();
        //}
    }

    public void BIND_BILL_INVOICE_NO()
    {
        DataSet ds_bill = new DataSet();
        objUBO.ID = "";
        objUBO.COVERING_NO = "";
        objUBO.TYPE = ddl_BillType.SelectedItem.Text;
        objUBO.BRANCH_CODE = Connection.Current_Branch();
        objUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        objUBO.flag = "SELECT_BILL_NO";

        ds_bill = LTR.RetrieveAll_CoveringLetter_Details_Vaishnavi(objUBO);
        if (ds_bill.Tables[0].Rows.Count > 0)
        {
            ddl_BillNo.DataSource = ds_bill.Tables[0];
            ddl_BillNo.DataTextField = "BILL_INV_NO";
            ddl_BillNo.DataValueField = "BILL_INV_NO";
            ddl_BillNo.DataBind();
            ddl_BillNo.Items.Insert(0, "");
        }
    }


    public void Get_Except_JobNo()
    {     
        EGM.JOBNO = "";
        EGM.WORKINGPERIOD = SELECT_BRANCH;
        EGM.Ename = "Get_Except_JobNo";
        ds = EGM.EGM_CONSOLIDATE_Select_All();
    }

    public void Get_EGM_JobNo_MAX()
    {
        EGM.JOBNO = "";
        //EGM.EGM_JOBNO = txt_EGM_Jobno.Text;
        EGM.WORKINGPERIOD = SELECT_BRANCH;
        EGM.Ename = "Get_EGM_JOBNO_MAXID";
        ds = EGM.EGM_CONSOLIDATE_Select_All();

        if (ds.Tables[0].Rows.Count > 0)
        {
            //txt_EGM_Jobno.Text = ds.Tables[0].Rows[0]["egm_MAXID"].ToString();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //i = Insert_Update("U", "U", Convert.ToInt32(hdn_SB_SlNo.Value));
            i = CoveringLetter_Insert_Update("N", "U");
            Alert_msg("Update Successfully", "btnUpdate");
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnSearch.Visible = true;
            btnSave.Visible = false;
            Update_Grid = "Update_Grid";

            Bind_COVERING_Details();
           
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EGM Consolidate', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EGM Consolidate', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Bind_COVERING_Details()
    {
        try
        {
            DataTable dt_item = new DataTable();

            objUBO.ID = Request.QueryString["Page"].ToString();
            objUBO.COVERING_NO = "";
            objUBO.TYPE = ddl_BillType.SelectedItem.Text;
            objUBO.BRANCH_CODE = Connection.Current_Branch();
            objUBO.BRANCH_COMMON = Connection.Get_Company_Type();
            objUBO.flag = "Bind_COVERING_LETTER_DETAILS";

            ds = LTR.RetrieveAll_CoveringLetter_Details_Vaishnavi(objUBO);

            //EGM.WORKINGPERIOD = SELECT_BRANCH;
            //ds = EGM.EGM_CONSOLIDATE_Select_All();
            int i = EGM.result;
            HD_Type.Value = i.ToString();

           
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                    //txt_JobNo.Visible = true;

                    //HD_Update_id.Value = ds.Tables[0].Rows[0]["EGM_ID"].ToString();
                    ////ddlJobNo.SelectedValue = ds.Tables[0].Rows[0]["JOBNO"].ToString();

                ddl_BillType.SelectedValue = ds.Tables[0].Rows[0]["TYPE"].ToString();
                ddl_BillNo.SelectedValue = ds.Tables[0].Rows[0]["BILL_NO"].ToString();

                txt_RefNo.Text = ds.Tables[0].Rows[0]["COVERING_REF_NO"].ToString();
                txt_RefDate.Text = ds.Tables[0].Rows[0]["COVERING_REF_DATE"].ToString();
                //hdn_Jobno.Value = txt_JobNo.Text;
                txt_ClientName.Text = ds.Tables[0].Rows[0]["CLIENT_NAME"].ToString();
                txt_Add1.Text = ds.Tables[0].Rows[0]["ADD1"].ToString();
                txt_Add2.Text = ds.Tables[0].Rows[0]["ADD2"].ToString();
                txt_Add3.Text = ds.Tables[0].Rows[0]["ADD3"].ToString();
                txt_Add4.Text = ds.Tables[0].Rows[0]["ADD4"].ToString();
                txt_BillDate.Text = ds.Tables[0].Rows[0]["BILL_DATE"].ToString();

                txt_Bill_Amount.Text = ds.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();
                txt_AnyotherDoc.Text = ds.Tables[0].Rows[0]["ANYOTHER_DOC"].ToString();
                txt_Subject.Text = ds.Tables[0].Rows[0]["SUBJECT"].ToString();


                if (ds.Tables[0].Rows[0]["INVOICE"].ToString() == "T")
                {
                    chk_Invoice.Checked = true;
                }
                else
                {
                    chk_Invoice.Checked = false;
                }

                if (ds.Tables[0].Rows[0]["PACKINGLIST"].ToString() == "T")
                {
                    chk_PList.Checked = true;
                }
                else
                {
                    chk_PList.Checked = false;
                }

                if (ds.Tables[0].Rows[0]["BILL_OF_ENTRY"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["BILL_OF_ENTRY"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_BOE.Checked = true;
                    }
                    else
                    {
                        chk_BOE.Checked = false;
                    }

                    txt_BOE.Text = sp[1];
                    txt_BOE_Date.Text = sp[2];
                    ddl_BOE_Duplicate.SelectedValue = sp[3];
                    ddl_BOE_Triplicate.SelectedValue = sp[4];
                }

                if (ds.Tables[0].Rows[0]["SHIPPING_BILL"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["SHIPPING_BILL"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_SB.Checked = true;
                    }
                    else
                    {
                        chk_SB.Checked = false;
                    }

                    txt_SB.Text = sp[1];
                    txt_SB_Date.Text = sp[2];
                    ddl_SB_Duplicate.SelectedValue = sp[3];
                    ddl_SB_Triplicate.SelectedValue = sp[4];
                }

                if (ds.Tables[0].Rows[0]["BILL_OF_LADING"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["BILL_OF_LADING"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_AWBNo.Checked = true;
                    }
                    else
                    {
                        chk_AWBNo.Checked = false;
                    }

                    txt_AWBNo.Text = sp[1];
                    txt_AWBNo_Date.Text = sp[2];
                    ddl_AWBNo.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["STPI_IMPORT"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["STPI_IMPORT"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_STPI.Checked = true;
                    }
                    else
                    {
                        chk_STPI.Checked = false;
                    }

                    txt_STPI.Text = sp[1];
                    txt_STPI_Date.Text = sp[2];
                    ddl_STPI.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["PROCUREMENT_CERT"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["PROCUREMENT_CERT"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_Procurement.Checked = true;
                    }
                    else
                    {
                        chk_Procurement.Checked = false;
                    }

                    txt_Procurement.Text = sp[1];
                    txt_Procurement_Date.Text = sp[2];
                    ddl_Procurement.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["CERTIFICATE_OF_ORIGIN"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["CERTIFICATE_OF_ORIGIN"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_Certificate.Checked = true;
                    }
                    else
                    {
                        chk_Certificate.Checked = false;
                    }

                    txt_Certificate.Text = sp[1];
                    txt_Certificate_Date.Text = sp[2];
                    ddl_Certificate.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["DUTY_PAID"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["DUTY_PAID"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_DutyPaid.Checked = true;
                    }
                    else
                    {
                        chk_DutyPaid.Checked = false;
                    }

                    txt_DutyPaid.Text = sp[1];
                    txt_DutyPaid_Date.Text = sp[2];
                    ddl_DutyPaid.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["DO_RECEIPT"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["DO_RECEIPT"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_DO_receipt.Checked = true;
                    }
                    else
                    {
                        chk_DO_receipt.Checked = false;
                    }

                    txt_DO_receipt.Text = sp[1];
                    txt_DO_receipt_Date.Text = sp[2];
                    ddl_DO_receipt.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["EDI_COUPON_RECEIPT"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["EDI_COUPON_RECEIPT"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_EDI.Checked = true;
                    }
                    else
                    {
                        chk_EDI.Checked = false;
                    }

                    txt_EDI.Text = sp[1];
                    txt_EDI_Date.Text = sp[2];
                    ddl_EDI.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["CFS_RECEIPT"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["CFS_RECEIPT"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_CFS.Checked = true;
                    }
                    else
                    {
                        chk_CFS.Checked = false;
                    }

                    txt_CFS.Text = sp[1];
                    txt_CFS_Date.Text = sp[2];
                    ddl_CFS.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["IAAI_RECEIPTNO"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["IAAI_RECEIPTNO"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_IAAI.Checked = true;
                    }
                    else
                    {
                        chk_IAAI.Checked = false;
                    }

                    txt_IAAI.Text = sp[1];
                    txt_IAAI_Date.Text = sp[2];
                    ddl_IAAI.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["ESCORT_CONVEYANCE"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["ESCORT_CONVEYANCE"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_Escort.Checked = true;
                    }
                    else
                    {
                        chk_Escort.Checked = false;
                    }

                    txt_Escort.Text = sp[1];
                    txt_Escort_Date.Text = sp[2];
                    ddl_Escort.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["TRANSPORT_BILL_NO"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["TRANSPORT_BILL_NO"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_Transport.Checked = true;
                    }
                    else
                    {
                        chk_Transport.Checked = false;
                    }

                    txt_Transport.Text = sp[1];
                    txt_Transport_Date.Text = sp[2];
                    ddl_Transport.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["VEHICLE_PASS"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["VEHICLE_PASS"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_VehiclePass.Checked = true;
                    }
                    else
                    {
                        chk_VehiclePass.Checked = false;
                    }

                    txt_VehiclePass.Text = sp[1];
                    txt_VehiclePass_Date.Text = sp[2];
                    ddl_VehiclePass.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["INSURANCE_CERTNO"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["INSURANCE_CERTNO"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_Insurance.Checked = true;
                    }
                    else
                    {
                        chk_Insurance.Checked = false;
                    }

                    txt_Insurance.Text = sp[1];
                    txt_Insurance_Date.Text = sp[2];
                    ddl_Insurance.SelectedValue = sp[3];
                }

                if (ds.Tables[0].Rows[0]["CE_CERTIFICATE_NO"].ToString() != "")
                {
                    string[] sp = ds.Tables[0].Rows[0]["CE_CERTIFICATE_NO"].ToString().Split('~');
                    if (sp[0] == "T")
                    {
                        chk_CE_Cert.Checked = true;
                    }
                    else
                    {
                        chk_CE_Cert.Checked = false;
                    }

                    txt_CE_Cert.Text = sp[1];
                    txt_CE_Cert_Date.Text = sp[2];
                    ddl_CE_Cert.SelectedValue = sp[3];
                }
                    //btnUpdate.Visible = true;
                    //btnDelete.Visible = true;
                    //btnSave.Visible = false;

            }
            else
            {

            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        //gv_details_Grid_Bind();
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
                //int Max_SlNo = Get_MAXID("Get_EGM_MAX_SLNO");

            i = CoveringLetter_Insert_Update("N", "S");

                if (i == 1)
                {
                    //int update_id = LTR.UpdateId;

                    //HD_Update_id.Value = Convert.ToString(update_id);
                    //HdnUpdate_id.Value = Convert.ToString(update_id);
                    //ViewState["UPDATE_ID"] = update_id;

                    hdnfld_Jobno.Value = Convert.ToString(UpdateID);
                    ViewState["UpdateID"] = hdnfld_Jobno.Value;
                    
                    Alert_msg("Saved Successfully", "btnSave");
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSearch.Visible = true;
                    btnSave.Visible = false;
                }
                else
                {
                    Alert_msg("Record Already Exists!!!", "btnSave");
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSearch.Visible = true;
                    btnSave.Visible = false;
                }
                
                //Bind_EGM_Details();
             
        }
        
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }



    public int CoveringLetter_Insert_Update(string a1, string a2)
    {
        objUBO.ID = hdnfld_Jobno.Value;
        objUBO.BILL_INV_NO = ddl_BillNo.SelectedItem.Text;
        objUBO.TYPE = ddl_BillType.SelectedItem.Text;
        objUBO.DISPATCH_DATE = txt_RefDate.Text == string.Empty ? "01/01/1900" : txt_RefDate.Text;

        objUBO.BILL_INVOICE_DATE = txt_BillDate.Text == string.Empty ? "01/01/1900" : txt_BillDate.Text;
        objUBO.REFNO = txt_RefNo.Text;
        objUBO.SHIPPER_NAME = txt_ClientName.Text;

        objUBO.ADD1 = txt_Add1.Text;
        objUBO.ADD2 = txt_Add2.Text;
        objUBO.ADD3 = txt_Add3.Text;
        objUBO.ADD4 = txt_Add4.Text;
        objUBO.BILL_REMARKS = txt_Bill_Amount.Text;
        objUBO.SUBJECT = txt_Subject.Text;



        if (chk_Invoice.Checked == true)
        {
            objUBO.INVOICE = "T";
        }
        else
        {
            objUBO.INVOICE = "F";
        }

        if (chk_PList.Checked == true)
        {
            objUBO.PACKINGLIST = "T";
        }
        else
        {
            objUBO.PACKINGLIST = "F";
        }

        if (chk_BOE.Checked == true)
        {
            objUBO.BILL_OF_ENTRY = "T" + "~" + txt_BOE.Text + "~" + txt_BOE_Date.Text + "~" + ddl_BOE_Duplicate.SelectedItem.Text + "~" + ddl_BOE_Triplicate.SelectedItem.Text;
        }
        else
        {
            objUBO.BILL_OF_ENTRY = "";
        }

        if (chk_SB.Checked == true)
        {
            objUBO.SHIPPING_BILL = "T" + "~" + txt_SB.Text + "~" + txt_SB_Date.Text + "~" + ddl_SB_Duplicate.SelectedItem.Text + "~" + ddl_SB_Triplicate.SelectedItem.Text;
        }
        else
        {
            objUBO.SHIPPING_BILL = "";
        }

        if (chk_AWBNo.Checked == true)
        {
            objUBO.BILL_OF_LADING = "T" + "~" + txt_AWBNo.Text + "~" + txt_AWBNo_Date.Text + "~" + ddl_AWBNo.SelectedItem.Text;
        }
        else
        {
            objUBO.BILL_OF_LADING = "";
        }

        if (chk_STPI.Checked == true)
        {
            objUBO.STPI_IMPORT = "T" + "~" + txt_STPI.Text + "~" + txt_STPI_Date.Text + "~" + ddl_STPI.SelectedItem.Text;
        }
        else
        {
            objUBO.STPI_IMPORT = "";
        }

        if (chk_Procurement.Checked == true)
        {
            objUBO.PROCUREMENT_CERT = "T" + "~" + txt_Procurement.Text + "~" + txt_Procurement_Date.Text + "~" + ddl_Procurement.SelectedItem.Text;
        }
        else
        {
            objUBO.PROCUREMENT_CERT = "";
        }

        if (chk_Certificate.Checked == true)
        {
            objUBO.CERTIFICATE_OF_ORIGIN = "T" + "~" + txt_Certificate.Text + "~" + txt_Certificate_Date.Text + "~" + ddl_Certificate.SelectedItem.Text;
        }
        else
        {
            objUBO.CERTIFICATE_OF_ORIGIN = "";
        }

        if (chk_DutyPaid.Checked == true)
        {
            objUBO.DUTY_PAID = "T" + "~" + txt_DutyPaid.Text + "~" + txt_DutyPaid_Date.Text + "~" + ddl_DutyPaid.SelectedItem.Text;
        }
        else
        {
            objUBO.DUTY_PAID = "";
        }

        if (chk_DO_receipt.Checked == true)
        {
            objUBO.DO_RECEIPT = "T" + "~" + txt_DO_receipt.Text + "~" + txt_DO_receipt_Date.Text + "~" + ddl_DO_receipt.SelectedItem.Text;
        }
        else
        {
            objUBO.DO_RECEIPT = "";
        }

        if (chk_EDI.Checked == true)
        {
            objUBO.EDI_COUPON_RECEIPT = "T" + "~" + txt_EDI.Text + "~" + txt_EDI_Date.Text + "~" + ddl_EDI.SelectedItem.Text;
        }
        else
        {
            objUBO.EDI_COUPON_RECEIPT = "";
        }

        if (chk_CFS.Checked == true)
        {
            objUBO.CFS_CHARGE = "T" + "~" + txt_CFS.Text + "~" + txt_CFS_Date.Text + "~" + ddl_CFS.SelectedItem.Text;
        }
        else
        {
            objUBO.CFS_CHARGE = "";
        }

        if (chk_IAAI.Checked == true)
        {
            objUBO.IAAI_RECEIPTNO = "T" + "~" + txt_IAAI.Text + "~" + txt_IAAI_Date.Text + "~" + ddl_IAAI.SelectedItem.Text;
        }
        else
        {
            objUBO.IAAI_RECEIPTNO = "";
        }

        if (chk_Escort.Checked == true)
        {
            objUBO.ESCORT_CONVEYANCE = "T" + "~" + txt_Escort.Text + "~" + txt_Escort_Date.Text + "~" + ddl_Escort.SelectedItem.Text;
        }
        else
        {
            objUBO.ESCORT_CONVEYANCE = "";
        }

        if (chk_Transport.Checked == true)
        {
            objUBO.TRANSPORT_BILL_NO = "T" + "~" + txt_Transport.Text + "~" + txt_Transport_Date.Text + "~" + ddl_Transport.SelectedItem.Text;
        }
        else
        {
            objUBO.TRANSPORT_BILL_NO = "";
        }

        if (chk_Insurance.Checked == true)
        {
            objUBO.INSURANCE_CERTNO = "T" + "~" + txt_Transport.Text + "~" + txt_VehiclePass.Text + "~" + ddl_VehiclePass.SelectedItem.Text;
        }
        else
        {
            objUBO.INSURANCE_CERTNO = "";
        }

        if (chk_VehiclePass.Checked == true)
        {
            objUBO.VEHICLE_PASS = "T" + "~" + txt_Insurance.Text + "~" + txt_Insurance_Date.Text + "~" + ddl_Insurance.SelectedItem.Text;
        }
        else
        {
            objUBO.VEHICLE_PASS = "";
        }

        if (chk_CE_Cert.Checked == true)
        {
            objUBO.CE_CERTIFICATE_NO = "T" + "~" + txt_CE_Cert.Text + "~" + txt_CE_Cert_Date.Text + "~" + ddl_CE_Cert.SelectedItem.Text;
        }
        else
        {
            objUBO.CE_CERTIFICATE_NO = "";
        }

        objUBO.ANYOTHER_DOC = txt_AnyotherDoc.Text;

        objUBO.USER_ID = Connection.Current_User();
        objUBO.BRANCH_CODE = Connection.Current_Branch();
        objUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        objUBO.WORKING_PERIOD = Connection.WorkingPeriod();
        objUBO.flag = a2;

        LTR.Covering_LTR_INS_UPD_Vaishnavi(objUBO);
        i = LTR.result;
        UpdateID = LTR.UPDATE_ID;
        return i;
    }



    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dt_max = new DataSet();

            objUBO.ID = hdnfld_Jobno.Value;
            objUBO.COVERING_NO = "";
            objUBO.TYPE = ddl_BillType.SelectedItem.Text;
            objUBO.BRANCH_CODE = Connection.Current_Branch();
            objUBO.BRANCH_COMMON = Connection.Get_Company_Type();
            objUBO.flag = "delete";

            dt_max = LTR.RetrieveAll_CoveringLetter_Details_Vaishnavi(objUBO);


            i = LTR.result;

            if (i == 1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Record Deleted', 'EGM', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

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
    protected void ddl_BillType_SelectedIndexChanged(object sender, EventArgs e)
    {
        BIND_BILL_INVOICE_NO();
    }
}
 