using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

public partial class Docket_Entry_Docket_General : ThemeClass
{
    DataSet dtuser = new DataSet();
    Decket_General docket = new Decket_General();
    SqlConnection con;
    SqlCommand cmd;
    Manipulation mo = new Manipulation();
    AppSession aps = new AppSession();
    Transaction trans = new Transaction();

    IMP_JobEdit Jobedit = new IMP_JobEdit();

    Maildb mdb = new Maildb();
    DataSet ds = new DataSet();

    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;

    public string SUBSCRIBE, EMAILID, SELECT_TYPE, SELECT_BRANCH;

    public string SMTP_SERVER, USER_NAME, PWD, PORT, COMPANY_ID, ENABLE_SSL;


    public string LoginDate;
    Date_Time dt = new Date_Time();
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id, Screen_IdNew;
    public string JOB_LOCK, JOB_RELEASE, JOB_USER;


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

        hdn_Jobno.Value = "1";


        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                Session["Doc_branch"] = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                Session["Doc_branch"] = SELECT_BRANCH;
            }
        }
        else
        {
            SELECT_BRANCH = "";
            Session["Doc_branch"] = SELECT_BRANCH;
        }
        if (!this.IsPostBack)
        {
            drpbind();
            if (Request.QueryString["Page"] == "New")
            {
                if (SELECT_BRANCH != "")
                {
                    Load_FILE_REF_NO_NEW();
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    ddlfilerefno.Visible = true;
                }
                HDupdate_id.Value = "";
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }
        }
    }

    public void Load_FILE_REF_NO_NEW()
    {
        DataSet ds_New = new DataSet();
        docket.FILE_REFNO = Request.QueryString["Page"].ToString();
        //Transact.JOB_NO= Request.QueryString["Billinvno"].ToString();

        docket.BRANCH_CODE = SELECT_BRANCH;
        docket.Mflag = "GET_EXCEPT_FILEREF";

        ds_New = docket.DocketGeneral_SearchSelect();

        if (ds_New.Tables[0].Rows.Count > 0)
        {
            ddlfilerefno.DataSource = ds_New;
            ddlfilerefno.DataTextField = "FILE_REF_NO";
            ddlfilerefno.DataValueField = "FILE_REF_NO";
            ddlfilerefno.DataBind();
            ddlfilerefno.Items.Insert(0, "--Select--");
        }
    }


    private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        docket.FILE_REFNO = Request.QueryString["Page"].ToString();
        //Transact.JOB_NO= Request.QueryString["Billinvno"].ToString();

        docket.BRANCH_CODE = SELECT_BRANCH;
        docket.Mflag = "Docket_Update_Select";

        dss = docket.DocketGeneral_SearchSelect();
        if (dss.Tables[0].Rows.Count > 0)
        {
            txt_FileRefNo.Visible = true;
            //ddlfilerefno.SelectedValue = dss.Tables[0].Rows[0]["FILE_REFNO"].ToString();
            txt_FileRefNo.Text = dss.Tables[0].Rows[0]["FILE_REFNO"].ToString();
            //ddlfilerefno.SelectedItem.Text = dss.Tables[0].Rows[0]["FILE_REFNO"].ToString();

            txtooc_date.Text = dss.Tables[0].Rows[0]["OOC_DATE"].ToString();
            txtdocollected_date.Text = dss.Tables[0].Rows[0]["DO_COLLECTED_DATE"].ToString();
            txtdetention_free_days.Text = dss.Tables[0].Rows[0]["DETENTION_FREE_DAYS"].ToString();
            txtport_name.Text = dss.Tables[0].Rows[0]["PORT_NAME"].ToString();
            txtcontainer_landedtime.Text = dss.Tables[0].Rows[0]["CONTAINER_LANDED_TIME"].ToString();
            txtcontainer_landeddate.Text = dss.Tables[0].Rows[0]["CONTAINER_LANDED_DATE"].ToString();
            txtcontainer_outtime.Text = dss.Tables[0].Rows[0]["CONTAINER_OUT_TIME"].ToString();
            txtcontainer_outdate.Text = dss.Tables[0].Rows[0]["CONTAINER_OUT_DATE"].ToString();
            txttransport_name.Text = dss.Tables[0].Rows[0]["TRANSPORT_NAME"].ToString();
            txttruck_number.Text = dss.Tables[0].Rows[0]["TRUCK_NUMBER"].ToString();
            txttptnet_amount.Text = dss.Tables[0].Rows[0]["TPT_NET_AMOUNT"].ToString();
            txthalting_days.Text = dss.Tables[0].Rows[0]["HALTING_DAYS"].ToString();
            txthalt_net.Text = dss.Tables[0].Rows[0]["HALT_NET"].ToString();
            txtdovalid_date.Text = dss.Tables[0].Rows[0]["DOVALID_DATE"].ToString();
            txtdo_extenstion.Text = dss.Tables[0].Rows[0]["DO_EXTENSION"].ToString();
            txtvessel_name.Text = dss.Tables[0].Rows[0]["VESSEL_NAME"].ToString();
            txtvessel_voyage.Text = dss.Tables[0].Rows[0]["VESSEL_VOYAGE"].ToString();
            txtarrival_date.Text = dss.Tables[0].Rows[0]["ARRIVAL_DATE"].ToString();

            txtdutypaid_date.Text = dss.Tables[0].Rows[0]["DUTY_PAID_DATE"].ToString();
            txtdutypaid_by.Text = dss.Tables[0].Rows[0]["DUTY_PAID_BY"].ToString();
            txtadvancerec_amount.Text = dss.Tables[0].Rows[0]["ADVANCE_RECEIVED_AMOUNT"].ToString();
            txtadvance_recdate.Text = dss.Tables[0].Rows[0]["ADVANCE_RECEIVED_DATE"].ToString();
            txtadvance_paidby.Text = dss.Tables[0].Rows[0]["ADVANCE_PAID_BY"].ToString();
            txttin_no.Text = dss.Tables[0].Rows[0]["TIN_NO"].ToString();

            txtchecklist_sentdate.Text = dss.Tables[0].Rows[0]["CHECKLIST_SENT_DATE"].ToString();
            txtconfor_recdate.Text = dss.Tables[0].Rows[0]["CONFIRMATION_RECDATE"].ToString();
            txtCFS_name.Text = dss.Tables[0].Rows[0]["CFS_NAME"].ToString();
            txtfreight_certrecdate.Text = dss.Tables[0].Rows[0]["FREIGHT_CERT_RECDATE"].ToString();
            txteroyal_jobno.Text = dss.Tables[0].Rows[0]["EROYAL_JOBNO"].ToString();
            txtoriginal_docrecdate.Text = dss.Tables[0].Rows[0]["ORIGINAL_DOCRECEDATE"].ToString();
            txthous_agentname.Text = dss.Tables[0].Rows[0]["HOUSE_AGENTNAME"].ToString();
            txtmaster_agentname.Text = dss.Tables[0].Rows[0]["MASTER_AGENTNAME"].ToString();
            txtrms_orgroup.Text = dss.Tables[0].Rows[0]["RMS_ORGROUP"].ToString();
            txtcleared_date.Text = dss.Tables[0].Rows[0]["CLEARED_DATE"].ToString();
            txtcleared_inspername.Text = dss.Tables[0].Rows[0]["CLEARED_INSPERNAME"].ToString();
            txtcleared_delpername.Text = dss.Tables[0].Rows[0]["CLEARED_DELPERNAME"].ToString();
            txtmother_vessname.Text = dss.Tables[0].Rows[0]["MOTHER_VESSELNAME"].ToString();
            txtmother_voyname.Text = dss.Tables[0].Rows[0]["MOTHER_VESSELVOYAGE"].ToString();

            txt_ImporterName.Text = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
            txt_GrossWeight.Text = dss.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();
            txt_NetWeight.Text = dss.Tables[0].Rows[0]["NET_WEIGHT"].ToString();



            txtcontsize20.Text = dss.Tables[0].Rows[0]["CONTAINER_SIZE_20"].ToString();

            txtContsize40.Text = dss.Tables[0].Rows[0]["CONTAINER_SIZE_40"].ToString();

            txtLCL.Text = dss.Tables[0].Rows[0]["CONTAINER_TYPE"].ToString();

            txtnoofpckges.Text = dss.Tables[0].Rows[0]["NO_OF_PACKAGES"].ToString();

            txtsupplier.Text = dss.Tables[0].Rows[0]["SUPPLIER"].ToString();

            txtdesc.Text = dss.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString();

            txtclrdelivery.Text = dss.Tables[0].Rows[0]["CLEARANCE_DELIVERY"].ToString();

            txtclrperiod.Text = dss.Tables[0].Rows[0]["TOT_CLEARANCE_PERIOD"].ToString();

            txtsrvtask.Text = dss.Tables[0].Rows[0]["SERVICE_TASK_BWC"].ToString();

            txtupdationdate.Text = dss.Tables[0].Rows[0]["DUTY_UPDATED_DATE"].ToString(); 

        }

    }

    public int insert_update(string jobid, string flag)
    {
        docket.JOB_ID = jobid;
        //docket.FILE_REFNO = ddlfilerefno.SelectedValue;
        docket.FILE_REFNO = txt_FileRefNo.Text;
        docket.OOC_DATE = txtooc_date.Text.Trim();
        docket.DO_COLLECTED_DATE = txtdocollected_date.Text.Trim();
        docket.DETENTION_FREE_DAYS = txtdetention_free_days.Text.Trim();
        docket.PORT_NAME = txtport_name.Text.Trim();
        docket.CONTAINER_LANDED_TIME = txtcontainer_landedtime.Text.Trim();
        docket.CONTAINER_LANDED_DATE = txtcontainer_landeddate.Text.Trim();
        docket.CONTAINER_OUT_TIME = txtcontainer_outtime.Text.Trim();
        docket.CONTAINER_OUT_DATE = txtcontainer_outdate.Text.Trim();
        docket.TRANSPORT_NAME = txttransport_name.Text.Trim();
        docket.TRUCK_NUMBER = txttruck_number.Text.Trim();
        docket.TPT_NET_AMOUNT = txttptnet_amount.Text.Trim();
        docket.HALTING_DAYS = txthalting_days.Text.Trim();
        docket.HALT_NET = txthalt_net.Text.Trim();
        docket.DOVALID_DATE = txtdovalid_date.Text.Trim();
        docket.DO_EXTENSION = txtdo_extenstion.Text.Trim();
        docket.VESSEL_NAME = txtvessel_name.Text.Trim();
        docket.VESSEL_VOYAGE = txtvessel_voyage.Text.Trim();
        docket.ARRIVAL_DATE = txtarrival_date.Text.Trim();
        docket.DUTY_PAID_DATE = txtdutypaid_date.Text.Trim();
        docket.DUTY_PAID_BY = txtdutypaid_by.Text.Trim();
        docket.ADVANCE_RECEIVED_AMOUNT = txtadvancerec_amount.Text.Trim();
        docket.ADVANCE_RECEIVED_DATE = txtadvance_recdate.Text.Trim();
        docket.ADVANCE_PAID_BY = txtadvance_paidby.Text.Trim();
        docket.TIN_NO = txttin_no.Text.Trim();
        docket.CHECKLIST_SENT_DATE = txtchecklist_sentdate.Text.Trim();
        docket.CONFIRMATION_RECDATE = txtconfor_recdate.Text.Trim();
        docket.CFS_NAME = txtCFS_name.Text.Trim();
        docket.FREIGHT_CERT_RECDATE = txtfreight_certrecdate.Text.Trim();
        docket.EROYAL_JOBNO = txteroyal_jobno.Text.Trim();
        docket.ORIGINAL_DOCRECEDATE = txtoriginal_docrecdate.Text.Trim();
        docket.HOUSE_AGENTNAME = txthous_agentname.Text.Trim();
        docket.MASTER_AGENTNAME = txtmaster_agentname.Text.Trim();
        docket.RMS_ORGROUP = txtrms_orgroup.Text.Trim();
        docket.CLEARED_DATE = txtcleared_date.Text.Trim();
        docket.CLEARED_INSPERNAME = txtcleared_inspername.Text.Trim();
        docket.CLEARED_DELPERNAME = txtcleared_delpername.Text.Trim();
        docket.MOTHER_VESSELNAME = txtmother_vessname.Text.Trim();
        docket.MOTHER_VESSELVOYAGE = txtmother_voyname.Text.Trim();
        docket.USER_ID = currentuser;

        docket.Flag = flag;
        docket.BRANCH_CODE = currentbranch;
        docket.WORKING_PERIOD = Working_Period;

        docket.BRANCH_COMMON = SELECT_BRANCH;

        docket.IMPORTER_NAME = txt_ImporterName.Text;
        docket.GROSS_WEIGHT = txt_GrossWeight.Text;
        docket.NET_WEIGHT = txt_NetWeight.Text;

        docket.CONTAINER_SIZE_20 = txtcontsize20.Text;
        docket.CONTAINER_SIZE_40 = txtContsize40.Text;
        docket.CONTAINER_TYPE = txtLCL.Text;
        docket.NO_OF_PACKAGES = txtnoofpckges.Text;
        docket.SUPPLIER = txtsupplier.Text;
        docket.ITEM_DESCRIPTION = txtdesc.Text;
        docket.CLEARANCE_DELIVERY = txtclrdelivery.Text;
        docket.TOT_CLEARANCE_PERIOD = txtclrperiod.Text;
        docket.SERVICE_TASK_BWC = txtsrvtask.Text;
        docket.DUTY_UPDATED_DATE = txtupdationdate.Text.Trim();




        i = docket.General_details_insertupdate();
        return i;
    }


    protected void btnNew_Click(object sender, EventArgs e)
    {
        hdn_Jobno.Value = "";
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnClose.Visible = true;
        btnNew.Visible = true;
        ddlfilerefno.SelectedIndex= -1;
        trans.ResetFields(Page.Controls);
        ViewState["UPDATED_ID"] = null;
        ddlfilerefno.Visible = true;
        txt_FileRefNo.Visible = false;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ddlfilerefno.SelectedValue != "")
        {
            try
            {
                string f = "U";
                i = insert_update(HDupdate_id.Value, f);

                if (i == 1)
                {
                    hdn_Jobno.Value = "1";

                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnUpdate");
                    }
                }
                else
                {
                    hdn_Jobno.Value = "";
                    Alert_msg("Job Not Saved", "btnUpdate");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlfilerefno.SelectedValue != "")
        {
            try
            {
                string id = "";
                string f = "S";
                i = insert_update(id, f);
                HiddenField1.Value = Convert.ToString(docket.Update_Id);

                if (i == 1)
                {
                    btnSave.Focus();
                    ViewState["UPDATED_ID"] = null;
                    btnNew.Visible = true;
                    btnUpdate.Visible = true;
                    btnClose.Visible = true;
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                    HDupdate_id.Value = Convert.ToString(docket.Update_Id);
                    Alert_msg("Saved Successfully", "btnSave");

                }
                else if (i == 2)
                {
                    Alert_msg("Job No Already Exist!", "btnSave");
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            Alert_msg("Enter All Mandatory Field");
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            docket.JOB_ID = HDupdate_id.Value.ToString();
            docket.FILE_REFNO = txt_FileRefNo.Text;
            docket.BRANCH_CODE = currentbranch;

            docket.Flag = "D";
            docket.General_details_insertupdate();

            i = docket.result;

            if (i == 1)
            {
                btnNew_Click(sender, e);
                btnSave.Visible = true;
                btnNew.Visible = true;
                trans.ResetFields(Page.Controls);
                Alert_msg("Deleted");

            }

            else
            {
                Alert_msg("Not Deleted");
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DOCKET ENTRY', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DOCKET ENTRY', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnDelete_Click1(object sender, EventArgs e)
    {

    }
    
    private void drpbind()
    {
        Decket_General docket = new Decket_General();
        DataSet ds = new DataSet();

        docket.FILE_REFNO = "";

        docket.BRANCH_COMMON = HttpContext.Current.Session["Doc_branch"].ToString();
        docket.Mflag = "Docket_Select_New";

        ds = docket.DocketGeneral_SearchSelect();
        ddlfilerefno.DataValueField = "FILE_REFNO";
        ddlfilerefno.DataSource = ds;
        ddlfilerefno.DataBind();
        ddlfilerefno.Items.Insert(0, "--Select--");
    }

    protected void ddlfilerefno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlfilerefno.SelectedValue == "--Select--")
        {
            trans.ResetFields(Page.Controls);
        }
        else
        {

        }

        txt_FileRefNo.Text = ddlfilerefno.SelectedValue;

        DataSet dsdrp = new DataSet();
        DataSet ds_jobno = new DataSet();
        docket.FILE_REFNO = ddlfilerefno.SelectedValue; 

        docket.BRANCH_CODE = SELECT_BRANCH;
        docket.Mflag = "Docket_Select_Drp";

        dsdrp = docket.DocketGeneral_SearchSelect();

        if (dsdrp.Tables[0].Rows.Count > 0)
        {
            txteroyal_jobno.Text = dsdrp.Tables[0].Rows[0]["JOBNO"].ToString();
            txtport_name.Text = dsdrp.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
            txttransport_name.Text = dsdrp.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
            txthous_agentname.Text = dsdrp.Tables[0].Rows[0]["CUSTOMS_HOUSE_NAME"].ToString();
            txt_ImporterName.Text = dsdrp.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();

            if (dsdrp.Tables[0].Rows[0]["JOBNO"].ToString() != "")
            {
                docket.FILE_REFNO = dsdrp.Tables[0].Rows[0]["JOBNO"].ToString();

                docket.BRANCH_CODE = SELECT_BRANCH;
                docket.Mflag = "GET_IGM_from_FILEREF";

              ds_jobno = docket.DocketGeneral_SearchSelect();

              if (ds_jobno.Tables[0].Rows.Count > 0)
              {
                  txt_GrossWeight.Text = ds_jobno.Tables[0].Rows[0]["IGM_GROSSWEIGHT"].ToString() + "  " + ds_jobno.Tables[0].Rows[0]["IGM_TYPEOFWEIGHT"].ToString();
              }
              else
              {
                  txt_GrossWeight.Text = "";
              }
               
            }
        }
    }
}