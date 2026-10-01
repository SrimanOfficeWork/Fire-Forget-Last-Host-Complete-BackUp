using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;

public partial class Imp_DSR_Entry : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    Transaction trans = new Transaction();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();

    public int i;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    IMP_INDEV_DSR_Entry IDSE = new IMP_INDEV_DSR_Entry();
         
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
        if (!IsPostBack)
        {
            load_Jobno();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
        }
    }

    private void load_Jobno()
    {
        DataSet ds = new DataSet();
        IDSE.Flag = "Select_Jobno";
        IDSE.Branch_Type = SELECT_BRANCH;
        ds = IDSE.IMP_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = ds.Tables[0];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();

            ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddljobno.SelectedIndex = 0;
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SUBMISSION', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        trans.ResetFields(Page.Controls);

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            Insert_Update("S");
            if (i == 1)
            {
                Alert_msg("Saved Successfully", "btnSave");
                HDupdate_id.Value = Convert.ToString(IDSE.result);

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                Alert_msg("Not Saved", "btnSave");
            }
        }
        else
        {
            Alert_msg("Select a Jobno !", "ddljobno");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            Insert_Update("U");

            if (i == 1)
            {
                Alert_msg("Updated Successfully", "btnUpdate");
                HDupdate_id.Value = Convert.ToString(IDSE.result);
                btnDelete.Visible = true;
            }
            else
            {
                Alert_msg("Not Updated", "btnUpdate");
            }
        }
        else
        {
            Alert_msg("Select a Jobno !", "ddljobno");
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            Insert_Update("D");
            if (i == 1)
            {
                Alert_msg("Deleted Successfully", "btnDelete");
                HDupdate_id.Value = Convert.ToString(IDSE.result);
                btnDelete.Visible = false;
                Clear();
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }
            else
            {
                Alert_msg("Not deleted", "btnDelete");
            }
        }
        else
        {
            Alert_msg("Select a Jobno !", "ddljobno");
        }
    }

    private int Insert_Update(string a)
    { 

            IDSE.JOBNO=ddljobno.SelectedValue.ToString();
            if (txt_Doc_Rec_Date.Text != string.Empty)
            {
                IDSE.DOCUMENTS_RECEIVED_DATE=  txt_Doc_Rec_Date.Text +":"+ddlhrs_Doc_Rec_Date.SelectedValue.ToString()+":" + ddlsec_Doc_Rec_Date.SelectedValue.ToString();
            }
            else
            {
                IDSE.DOCUMENTS_RECEIVED_DATE = string.Empty;
            }

            if (txtchklist_date.Text != string.Empty)
            {
                IDSE.CHECKLIST_DATE=  txtchklist_date.Text +":"+ddlhrs_chklist_date.SelectedValue.ToString()+":" + ddlsec_chklist_date.SelectedValue.ToString();
            }
            else
            {
                IDSE.CHECKLIST_DATE = string.Empty;
            }
        
            if (txtchk_app_date.Text!= string.Empty)
            {
                IDSE.CHECKLIST_APPROVAL_DATE=  txtchk_app_date.Text +":"+ddlhrs_chk_app_date.SelectedValue.ToString()+":" + ddlsec_chk_app_date.SelectedValue.ToString();
            }
            else
            {
                IDSE.CHECKLIST_APPROVAL_DATE= string.Empty;
            }
            if (txt_Ass_date.Text != string.Empty)
            {
               IDSE.ASSESMENT_DATE=  txt_Ass_date.Text +":"+ddlhrs_Ass_date.SelectedValue.ToString()+":" + ddlsec_Ass_date.SelectedValue.ToString();
            }
            else
            {
                IDSE.ASSESMENT_DATE = string.Empty;
            }
            if (txt_Cleared_date.Text != string.Empty)
            {
                IDSE.CLEARED_DATE=  txt_Cleared_date.Text +":"+ddlhrs_Cleared_dat.SelectedValue.ToString()+":" + ddlsec_Cleared_dat.SelectedValue.ToString();
            }
            else
            {
                 IDSE.CLEARED_DATE= string.Empty;
            }
            if (txt_DO_Valid_date.Text != string.Empty)
            {
                IDSE.DO_VALIDITY_DATE=  txt_DO_Valid_date.Text +":"+ddlhrs_DO_Valid_date.SelectedValue.ToString()+":" + ddlsec_DO_Valid_date.SelectedValue.ToString();
            }
            else
            {
                IDSE.DO_VALIDITY_DATE = string.Empty;
            }
            IDSE.PD_BOND_NO= txtBondno.Text ;
            IDSE.BOE_TYPE= txtboetype.Text ;
            if (txt_duty_Rec_date.Text != string.Empty)
            {
                IDSE.DUTY_RECEIVED_DATE=  txt_duty_Rec_date.Text +":"+ddlhrs_duty_Rec_date.SelectedValue.ToString()+":" + ddlsec_duty_Rec_date.SelectedValue.ToString();
            }
            else
            {
               IDSE.DUTY_RECEIVED_DATE = string.Empty;
            }

             if (txt_duty_paid_date.Text != string.Empty)
            {
                IDSE.DUTY_PAID_DATE=  txt_duty_paid_date.Text +":"+ddlhrs_duty_paid_date.SelectedValue.ToString()+":" + ddlsec_duty_paid_date.SelectedValue.ToString();
            }
            else
            {
                IDSE.DUTY_PAID_DATE = string.Empty;
            }
           
           IDSE.GATE_IN_EXPORT=txtgateinExport.Text;
           IDSE.I_ETD_FROM_ORIGIN_PORT=txtI_Orginport.Text;
           IDSE.I_TRANSIT_PORT_ETA=txt_I_transit_Port_ETA.Text;
           IDSE.II_ETD_FROM_TRANSIT_PORT=txt_II_ETD_from_Transit_Port.Text;
           IDSE.II_TRANSIT_PORT_ETA=txt_II_Transit_Port_ETA.Text;
           IDSE.III_ETD_FROM_TRANSIT_PORT=txt_III_ETD_from_Transit_Port.Text ;
           IDSE.III_TRANSIT_PORT_ETA=txt_III_Transit_Port_ETA.Text;
           IDSE.FUL_DISCHRGE_AT_TRANSIT_PRT=txt_Ful_Discharge_at_Transit_Port.Text;
           IDSE.FINAL_VESSEL_TO_CHPT=txt_Final_Vessel_to_CHPT.Text ;
           IDSE.ETA=txt_ETA.Text ;
          // IDSE.ATA=txt_ATA.Text;

           if (txt_ATA_Date.Text != string.Empty)
           {
               IDSE.ATA = txt_ATA_Date.Text + ":" + ddlhrs_txt_ATA_Date.SelectedValue.ToString() + ":" + ddlsec_txt_ATA_Date.SelectedValue.ToString();
           }
           else
           {
               IDSE.ATA = string.Empty;
           }

           IDSE.CONTAINER_REACHED_CFS=txt_Container_Reached_CFS.Text;


             if (txt_Out_of_Charge_RCVD_Date.Text != string.Empty)
            {
                IDSE.OUT_OF_CHARGE_RCVD_DATE=  txt_Out_of_Charge_RCVD_Date.Text +":"+ddlhrs_Out_of_Charge_RCVD_Date.SelectedValue.ToString()+":" + ddlsec_Out_of_Charge_RCVD_Date.SelectedValue.ToString();
            }
            else
            {
               IDSE.OUT_OF_CHARGE_RCVD_DATE = string.Empty;
            }

            if (txt_Bill_Pass_Date.Text  != string.Empty)
            {
                IDSE.BILL_PASS_DATE=  txt_Bill_Pass_Date.Text +":"+ddlhrs_Bill_Pass_Date.SelectedValue.ToString()+":" + ddlsec_Bill_Pass_Date.SelectedValue.ToString();
            }
            else
            {
                IDSE.BILL_PASS_DATE = string.Empty;
            }

             if (txt_Bill_SUbmitted_Date.Text  != string.Empty)
            {
               IDSE.BILL_SUBMITTED_DATE=  txt_Bill_SUbmitted_Date.Text +":"+ddlhrs_Bill_SUbmitted_Date.SelectedValue.ToString()+":" + ddlsec_Bill_SUbmitted_Date.SelectedValue.ToString();
            }
            else
            {
                IDSE.BILL_SUBMITTED_DATE = string.Empty;
            }
            if (txt_Payment_Recd_Date.Text != string.Empty)
            {
                IDSE.PAYMENT_RECD_DATE=  txt_Payment_Recd_Date.Text +":"+ddlhrs_Payment_Recd_Date.SelectedValue.ToString()+":" + ddlsec_Payment_Recd_Date.SelectedValue.ToString();
            }
            else
            {
                IDSE.PAYMENT_RECD_DATE = string.Empty;
            }

           IDSE.CONTR_ARVAL_CCTL_WIT_TIMG=txt_Contr_Arval_CCTL_WIT_TIMG.Text ;
           IDSE.LAST_FREE_DATE_GRND_RENT_CFS=txt_Last_Free_Date_Grnd_Rent_CFS.Text;

             if (txt_Delivery_Date_from_CFS.Text != string.Empty)
            {
                IDSE.DELIVERY_DATE_FROM_CFS=  txt_Delivery_Date_from_CFS.Text +":"+ddlhrs_Delivery_Date_from_CFS.SelectedValue.ToString()+":" + ddlsec_Delivery_Date_from_CFS.SelectedValue.ToString();
            }
            else
            {
                IDSE.DELIVERY_DATE_FROM_CFS = string.Empty;
            }

           IDSE.NO_OF_GROUNDRENT_DAYS=txt_No_of_GroundRent_Days.Text;
           IDSE.GROUND_RENT_CHARGES=txt_Ground_Rent_Charges.Text;

            if (txt_Reported_Date_to_WH.Text != string.Empty)
            {
                IDSE.REPORTED_DATE_TO_WH=  txt_Reported_Date_to_WH.Text +":"+ddlhrs_Reported_Date_to_WH.SelectedValue.ToString()+":" + ddlsec_Reported_Date_to_WH.SelectedValue.ToString();
            }
            else
            {
                IDSE.REPORTED_DATE_TO_WH= string.Empty;
            }

           IDSE.GATE_OUT_DATE_FROM_WH= txt_Gate_Out_Date_from_WH.Text;
           IDSE.VEHICLE_DETENTION_DAYS=txt_Vehicle_Detention_Days.Text;

            if (txt_Last_free_date_CNTR_Detention.Text != string.Empty)
            {
                IDSE.LAST_FREE_DATE_CNTR_DETENTION=  txt_Last_free_date_CNTR_Detention.Text +":"+ddlhrs_Last_free_date_CNTR_Detention.SelectedValue.ToString()+":" + ddlsec_Last_free_date_CNTR_Detention.SelectedValue.ToString();
            }
            else
            {
                IDSE.LAST_FREE_DATE_CNTR_DETENTION= string.Empty;
            }
             if (txt_Empty_CNTR_Handed_Over_Date.Text != string.Empty)
            {
                IDSE.EMPTY_CNTR_HANDED_OVER_DATE=  txt_Empty_CNTR_Handed_Over_Date.Text +":"+ddlhrs_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString()+":" + ddlsec_Empty_CNTR_Handed_Over_Date.SelectedValue.ToString();
            }
            else
            {
                IDSE.EMPTY_CNTR_HANDED_OVER_DATE= string.Empty;
            }
           IDSE.NO_OF_DETENTION_DAYS=txt_No_of_Detention_Days.Text ;
           IDSE.AGING=txt_Aging.Text;
           IDSE.DETENTION=txt_Detention.Text;
           IDSE.STATUS=txt_Status.Text;
           IDSE.CFS_CHARGES=txt_CFS_Charges.Text;

           if (txt_License_Date.Text != string.Empty)
           {
               IDSE.LICENSE_DATE=  txt_License_Date.Text +":"+ddlhrs_License_Date.SelectedValue.ToString()+":" + ddlsec_License_Date.SelectedValue.ToString();
           }
           else
           {
               IDSE.LICENSE_DATE= string.Empty;
           }

           IDSE.REMARKS=txt_Remarks.Text;
           IDSE.PD_BOND_BALNCE=txt_PD_Bond_Balance.Text;
           IDSE.CUST_REF_NO=txt_CUST_Ref_No.Text;
           IDSE.BRANCH_CODE=currentbranch;
           IDSE.Branch_Type = SELECT_BRANCH;
           IDSE.WORKINGPERIOD=Working_Period;
           IDSE.USERID=currentuser;
           IDSE.Flag= a;
           IDSE.CLEARED_DATE_WOT = txt_Cleared_date.Text;
         
           IDSE.Imp_DSR_Entry_Ins_Upd(); 
          i = IDSE.result;
         return i;
    }

    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            DataSet ds = new DataSet();
            IDSE.Jobno = ddljobno.SelectedValue.ToString();
            IDSE.Flag = "Select_DSR_Entry";
            IDSE.Branch_Type = SELECT_BRANCH;
            ds = IDSE.IMP_Select();
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                string[] DOCUMENTS_RECEIVED_DATE = new string[] { };
                string[] CHECKLIST_DATE = new string[] { };
                string[] CHECKLIST_APPROVAL_DATE = new string[] { };
                string[] ASSESMENT_DATE = new string[] { };
                string[] CLEARED_DATE = new string[] { };
                string[] DO_VALIDITY_DATE = new string[] { };
                string[] DUTY_RECEIVED_DATE = new string[] { };
                string[] DUTY_PAID_DATE = new string[] { };
                string[] OUT_OF_CHARGE_RCVD_DATE = new string[] { };
                string[] BILL_PASS_DATE = new string[] { };
                string[] BILL_SUBMITTED_DATE = new string[] { };
                string[] PAYMENT_RECD_DATE = new string[] { };
                string[] DELIVERY_DATE_FROM_CFS = new string[] { };
                string[] REPORTED_DATE_TO_WH = new string[] { };
                string[] LAST_FREE_DATE_CNTR_DETENTION = new string[] { };
                string[] EMPTY_CNTR_HANDED_OVER_DATE = new string[] { };
                string[] LICENSE_DATE = new string[] { };

                string[] ATA_Date = new string[] { };

                if (ds.Tables[0].Rows[0]["DOCUMENTS_RECEIVED_DATE"].ToString() != string.Empty)
                {
                    DOCUMENTS_RECEIVED_DATE = ds.Tables[0].Rows[0]["DOCUMENTS_RECEIVED_DATE"].ToString().Split(':');
                    txt_Doc_Rec_Date.Text = DOCUMENTS_RECEIVED_DATE[0];
                    ddlhrs_Doc_Rec_Date.SelectedValue = DOCUMENTS_RECEIVED_DATE[1];
                    ddlsec_Doc_Rec_Date.SelectedValue = DOCUMENTS_RECEIVED_DATE[2];
                }
                else
                {
                    txt_Doc_Rec_Date.Text = string.Empty;
                    ddlhrs_Doc_Rec_Date.SelectedValue = "00";
                    ddlsec_Doc_Rec_Date.SelectedValue = "00";
                }
                if (ds.Tables[0].Rows[0]["CHECKLIST_DATE"].ToString() != string.Empty)
                {
                    CHECKLIST_DATE = ds.Tables[0].Rows[0]["CHECKLIST_DATE"].ToString().Split(':');
                    txtchklist_date.Text = CHECKLIST_DATE[0];
                    ddlhrs_chklist_date.SelectedValue = CHECKLIST_DATE[1];
                    ddlsec_chklist_date.SelectedValue = CHECKLIST_DATE[2];
                }
                else
                {
                    txtchklist_date.Text = string.Empty;
                    ddlhrs_chklist_date.SelectedValue = "00";
                    ddlsec_chklist_date.SelectedValue = "00";
                }
                if (ds.Tables[0].Rows[0]["CHECKLIST_APPROVAL_DATE"].ToString() != string.Empty)
                {
                    CHECKLIST_APPROVAL_DATE = ds.Tables[0].Rows[0]["CHECKLIST_APPROVAL_DATE"].ToString().Split(':');
                    txtchk_app_date.Text = CHECKLIST_APPROVAL_DATE[0];
                    ddlhrs_chk_app_date.SelectedValue = CHECKLIST_APPROVAL_DATE[1];
                    ddlsec_chk_app_date.SelectedValue = CHECKLIST_APPROVAL_DATE[2];
                }
                else
                {
                    txtchk_app_date.Text = string.Empty;
                    ddlhrs_chk_app_date.SelectedValue = "00";
                    ddlsec_chk_app_date.SelectedValue = "00";
                }

                if (ds.Tables[0].Rows[0]["ASSESMENT_DATE"].ToString() != string.Empty)
                {
                    ASSESMENT_DATE = ds.Tables[0].Rows[0]["ASSESMENT_DATE"].ToString().Split(':');
                    txt_Ass_date.Text = ASSESMENT_DATE[0];
                    ddlhrs_Ass_date.SelectedValue = ASSESMENT_DATE[1];
                    ddlsec_Ass_date.SelectedValue = ASSESMENT_DATE[2];
                }
                else
                {
                    txt_Ass_date.Text = string.Empty;
                    ddlhrs_Ass_date.SelectedValue = "00";
                    ddlsec_Ass_date.SelectedValue = "00";
                }

                if (ds.Tables[0].Rows[0]["CLEARED_DATE"].ToString() != string.Empty)
                {
                    CLEARED_DATE = ds.Tables[0].Rows[0]["CLEARED_DATE"].ToString().Split(':');
                    txt_Cleared_date.Text = CLEARED_DATE[0];
                    ddlhrs_Cleared_dat.SelectedValue = CLEARED_DATE[1];
                    ddlsec_Cleared_dat.SelectedValue = CLEARED_DATE[2];
                }
                else
                {
                    txt_Cleared_date.Text = string.Empty;
                    ddlhrs_Cleared_dat.SelectedValue = "00";
                    ddlsec_Cleared_dat.SelectedValue = "00";
                }

                if (ds.Tables[0].Rows[0]["DO_VALIDITY_DATE"].ToString() != string.Empty)
                {
                    DO_VALIDITY_DATE = ds.Tables[0].Rows[0]["DO_VALIDITY_DATE"].ToString().Split(':');
                    txt_DO_Valid_date.Text = DO_VALIDITY_DATE[0];
                    ddlhrs_DO_Valid_date.SelectedValue = DO_VALIDITY_DATE[1];
                    ddlsec_DO_Valid_date.SelectedValue = DO_VALIDITY_DATE[2];
                }
                else
                {
                    txt_DO_Valid_date.Text = string.Empty;
                    ddlhrs_DO_Valid_date.SelectedValue = "00";
                    ddlsec_DO_Valid_date.SelectedValue = "00";
                }
                txtBondno.Text = ds.Tables[0].Rows[0]["PD_BOND_NO"].ToString();
                txtboetype.Text = ds.Tables[0].Rows[0]["BOE_TYPE"].ToString();

                if (ds.Tables[0].Rows[0]["DUTY_RECEIVED_DATE"].ToString() != string.Empty)
                {
                    DUTY_RECEIVED_DATE = ds.Tables[0].Rows[0]["DUTY_RECEIVED_DATE"].ToString().Split(':');
                    txt_duty_Rec_date.Text = DUTY_RECEIVED_DATE[0];
                    ddlhrs_duty_Rec_date.SelectedValue = DUTY_RECEIVED_DATE[1];
                    ddlsec_duty_Rec_date.SelectedValue = DUTY_RECEIVED_DATE[2];
                }
                else
                {
                    txt_duty_Rec_date.Text = string.Empty;
                    ddlhrs_duty_Rec_date.SelectedValue = "00";
                    ddlsec_duty_Rec_date.SelectedValue = "00";
                }

                if (ds.Tables[0].Rows[0]["DUTY_PAID_DATE"].ToString() != string.Empty)
                {
                    DUTY_PAID_DATE = ds.Tables[0].Rows[0]["DUTY_PAID_DATE"].ToString().Split(':');
                    txt_duty_paid_date.Text = DUTY_PAID_DATE[0];
                    ddlhrs_duty_paid_date.SelectedValue = DUTY_PAID_DATE[1];
                    ddlsec_duty_paid_date.SelectedValue = DUTY_PAID_DATE[2];
                }
                else
                {
                    txt_duty_paid_date.Text = string.Empty;
                    ddlhrs_duty_paid_date.SelectedValue = "00";
                    ddlsec_duty_paid_date.SelectedValue = "00";
                }
                txtgateinExport.Text = ds.Tables[0].Rows[0]["GATE_IN_EXPORT"].ToString();
                txtI_Orginport.Text = ds.Tables[0].Rows[0]["I_ETD_FROM_ORIGIN_PORT"].ToString();
                txt_I_transit_Port_ETA.Text = ds.Tables[0].Rows[0]["I_TRANSIT_PORT_ETA"].ToString();
                txt_II_ETD_from_Transit_Port.Text = ds.Tables[0].Rows[0]["II_ETD_FROM_TRANSIT_PORT"].ToString();
                txt_II_Transit_Port_ETA.Text = ds.Tables[0].Rows[0]["II_TRANSIT_PORT_ETA"].ToString();
                txt_III_ETD_from_Transit_Port.Text = ds.Tables[0].Rows[0]["III_ETD_FROM_TRANSIT_PORT"].ToString();
                txt_III_Transit_Port_ETA.Text = ds.Tables[0].Rows[0]["III_TRANSIT_PORT_ETA"].ToString();
                txt_Ful_Discharge_at_Transit_Port.Text = ds.Tables[0].Rows[0]["FUL_DISCHRGE_AT_TRANSIT_PRT"].ToString();
                txt_Final_Vessel_to_CHPT.Text = ds.Tables[0].Rows[0]["FINAL_VESSEL_TO_CHPT"].ToString();
                txt_ETA.Text = ds.Tables[0].Rows[0]["ETA"].ToString();
                //txt_ATA.Text = ds.Tables[0].Rows[0]["ATA"].ToString();

                if (ds.Tables[0].Rows[0]["ATA"].ToString() != string.Empty)
                {
                    ATA_Date = ds.Tables[0].Rows[0]["ATA"].ToString().Split(':');
                    txt_ATA_Date.Text = ATA_Date[0];
                    ddlhrs_txt_ATA_Date.SelectedValue = ATA_Date[1];
                    ddlsec_txt_ATA_Date.SelectedValue = ATA_Date[2];
                }
                else
                {
                    txt_ATA_Date.Text = string.Empty;
                    ddlhrs_txt_ATA_Date.SelectedValue = "00";
                    ddlsec_txt_ATA_Date.SelectedValue = "00";
                }

                txt_Container_Reached_CFS.Text = ds.Tables[0].Rows[0]["CONTAINER_REACHED_CFS"].ToString();

                if (ds.Tables[0].Rows[0]["OUT_OF_CHARGE_RCVD_DATE"].ToString() != string.Empty)
                {
                    OUT_OF_CHARGE_RCVD_DATE = ds.Tables[0].Rows[0]["OUT_OF_CHARGE_RCVD_DATE"].ToString().Split(':');
                    txt_Out_of_Charge_RCVD_Date.Text = OUT_OF_CHARGE_RCVD_DATE[0];
                    ddlhrs_Out_of_Charge_RCVD_Date.SelectedValue = OUT_OF_CHARGE_RCVD_DATE[1];
                    ddlsec_Out_of_Charge_RCVD_Date.SelectedValue = OUT_OF_CHARGE_RCVD_DATE[2];
                }
                else
                {
                    txt_Out_of_Charge_RCVD_Date.Text = string.Empty;
                    ddlhrs_Out_of_Charge_RCVD_Date.SelectedValue = "00";
                    ddlsec_Out_of_Charge_RCVD_Date.SelectedValue = "00";
                }

                if (ds.Tables[0].Rows[0]["BILL_PASS_DATE"].ToString() != string.Empty)
                {
                    BILL_PASS_DATE = ds.Tables[0].Rows[0]["BILL_PASS_DATE"].ToString().Split(':');
                    txt_Bill_Pass_Date.Text = BILL_PASS_DATE[0];
                    ddlhrs_Bill_Pass_Date.SelectedValue = BILL_PASS_DATE[1];
                    ddlsec_Bill_Pass_Date.SelectedValue = BILL_PASS_DATE[2];
                }
                else
                {
                    txt_Bill_Pass_Date.Text = string.Empty;
                    ddlhrs_Bill_Pass_Date.SelectedValue = "00";
                    ddlsec_Bill_Pass_Date.SelectedValue = "00";
                }

                if (ds.Tables[0].Rows[0]["BILL_SUBMITTED_DATE"].ToString() != string.Empty)
                {
                    BILL_SUBMITTED_DATE = ds.Tables[0].Rows[0]["BILL_SUBMITTED_DATE"].ToString().Split(':');
                    txt_Bill_SUbmitted_Date.Text = BILL_SUBMITTED_DATE[0];
                    ddlhrs_Bill_SUbmitted_Date.SelectedValue = BILL_SUBMITTED_DATE[1];
                    ddlsec_Bill_SUbmitted_Date.SelectedValue = BILL_SUBMITTED_DATE[2];
                }
                else
                {
                    txt_Bill_SUbmitted_Date.Text = string.Empty;
                    ddlhrs_Bill_SUbmitted_Date.SelectedValue = "00";
                    ddlsec_Bill_SUbmitted_Date.SelectedValue = "00";
                }

                if (ds.Tables[0].Rows[0]["PAYMENT_RECD_DATE"].ToString() != string.Empty)
                {
                    PAYMENT_RECD_DATE = ds.Tables[0].Rows[0]["PAYMENT_RECD_DATE"].ToString().Split(':');
                    txt_Payment_Recd_Date.Text = PAYMENT_RECD_DATE[0];
                    ddlhrs_Payment_Recd_Date.SelectedValue = PAYMENT_RECD_DATE[1];
                    ddlsec_Payment_Recd_Date.SelectedValue = PAYMENT_RECD_DATE[2];
                }
                else
                {
                    txt_Payment_Recd_Date.Text = string.Empty;
                    ddlhrs_Payment_Recd_Date.SelectedValue = "00";
                    ddlsec_Payment_Recd_Date.SelectedValue = "00";
                }

                txt_Contr_Arval_CCTL_WIT_TIMG.Text = ds.Tables[0].Rows[0]["CONTR_ARVAL_CCTL_WIT_TIMG"].ToString();
                txt_Last_Free_Date_Grnd_Rent_CFS.Text = ds.Tables[0].Rows[0]["LAST_FREE_DATE_GRND_RENT_CFS"].ToString();

                if (ds.Tables[0].Rows[0]["DELIVERY_DATE_FROM_CFS"].ToString() != string.Empty)
                {
                    DELIVERY_DATE_FROM_CFS = ds.Tables[0].Rows[0]["DELIVERY_DATE_FROM_CFS"].ToString().Split(':');
                    txt_Delivery_Date_from_CFS.Text = DELIVERY_DATE_FROM_CFS[0];
                    ddlhrs_Delivery_Date_from_CFS.SelectedValue = DELIVERY_DATE_FROM_CFS[1];
                    ddlsec_Delivery_Date_from_CFS.SelectedValue = DELIVERY_DATE_FROM_CFS[2];
                }
                else
                {
                    txt_Delivery_Date_from_CFS.Text = string.Empty;
                    ddlhrs_Delivery_Date_from_CFS.SelectedValue = "00";
                    ddlsec_Delivery_Date_from_CFS.SelectedValue = "00";
                }

                txt_No_of_GroundRent_Days.Text = ds.Tables[0].Rows[0]["NO_OF_GROUNDRENT_DAYS"].ToString();
                txt_Ground_Rent_Charges.Text = ds.Tables[0].Rows[0]["GROUND_RENT_CHARGES"].ToString();

                if (ds.Tables[0].Rows[0]["REPORTED_DATE_TO_WH"].ToString() != string.Empty)
                {
                    REPORTED_DATE_TO_WH = ds.Tables[0].Rows[0]["REPORTED_DATE_TO_WH"].ToString().Split(':');
                    txt_Reported_Date_to_WH.Text = REPORTED_DATE_TO_WH[0];
                    ddlhrs_Reported_Date_to_WH.SelectedValue = REPORTED_DATE_TO_WH[1];
                    ddlsec_Reported_Date_to_WH.SelectedValue = REPORTED_DATE_TO_WH[2];
                }
                else
                {
                    txt_Reported_Date_to_WH.Text = string.Empty;
                    ddlhrs_Reported_Date_to_WH.SelectedValue = "00";
                    ddlsec_Reported_Date_to_WH.SelectedValue = "00";
                }

                txt_Gate_Out_Date_from_WH.Text = ds.Tables[0].Rows[0]["GATE_OUT_DATE_FROM_WH"].ToString();
                txt_Vehicle_Detention_Days.Text = ds.Tables[0].Rows[0]["VEHICLE_DETENTION_DAYS"].ToString();

                if (ds.Tables[0].Rows[0]["LAST_FREE_DATE_CNTR_DETENTION"].ToString() != string.Empty)
                {
                    LAST_FREE_DATE_CNTR_DETENTION = ds.Tables[0].Rows[0]["LAST_FREE_DATE_CNTR_DETENTION"].ToString().Split(':');
                    txt_Last_free_date_CNTR_Detention.Text = LAST_FREE_DATE_CNTR_DETENTION[0];
                    ddlhrs_Last_free_date_CNTR_Detention.SelectedValue = LAST_FREE_DATE_CNTR_DETENTION[1];
                    ddlsec_Last_free_date_CNTR_Detention.SelectedValue = LAST_FREE_DATE_CNTR_DETENTION[2];
                }
                else
                {
                    txt_Last_free_date_CNTR_Detention.Text = string.Empty;
                    ddlhrs_Last_free_date_CNTR_Detention.SelectedValue = "00";
                    ddlsec_Last_free_date_CNTR_Detention.SelectedValue = "00";
                }

                if (ds.Tables[0].Rows[0]["EMPTY_CNTR_HANDED_OVER_DATE"].ToString() != string.Empty)
                {
                    EMPTY_CNTR_HANDED_OVER_DATE = ds.Tables[0].Rows[0]["EMPTY_CNTR_HANDED_OVER_DATE"].ToString().Split(':');
                    txt_Empty_CNTR_Handed_Over_Date.Text = EMPTY_CNTR_HANDED_OVER_DATE[0];
                    ddlhrs_Empty_CNTR_Handed_Over_Date.SelectedValue = EMPTY_CNTR_HANDED_OVER_DATE[1];
                    ddlsec_Empty_CNTR_Handed_Over_Date.SelectedValue = EMPTY_CNTR_HANDED_OVER_DATE[2];
                }
                else
                {
                    txt_Empty_CNTR_Handed_Over_Date.Text = string.Empty;
                    ddlhrs_Empty_CNTR_Handed_Over_Date.SelectedValue = "00";
                    ddlsec_Empty_CNTR_Handed_Over_Date.SelectedValue = "00";
                }
                txt_No_of_Detention_Days.Text = ds.Tables[0].Rows[0]["NO_OF_DETENTION_DAYS"].ToString();
                txt_Aging.Text = ds.Tables[0].Rows[0]["AGING"].ToString();
                txt_Detention.Text = ds.Tables[0].Rows[0]["DETENTION"].ToString();
                txt_Status.Text = ds.Tables[0].Rows[0]["STATUS"].ToString();
                txt_CFS_Charges.Text = ds.Tables[0].Rows[0]["CFS_CHARGES"].ToString();


                if (ds.Tables[0].Rows[0]["LICENSE_DATE"].ToString() != string.Empty)
                {
                    LICENSE_DATE = ds.Tables[0].Rows[0]["EMPTY_CNTR_HANDED_OVER_DATE"].ToString().Split(':');
                    txt_License_Date.Text = LICENSE_DATE[0];
                    ddlhrs_License_Date.SelectedValue = LICENSE_DATE[1];
                    ddlsec_License_Date.SelectedValue = LICENSE_DATE[2];
                }
                else
                {
                    txt_License_Date.Text = string.Empty;
                    ddlhrs_License_Date.SelectedValue = "00";
                    ddlsec_License_Date.SelectedValue = "00";
                }
                txt_Remarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();
                txt_PD_Bond_Balance.Text = ds.Tables[0].Rows[0]["PD_BOND_BALNCE"].ToString();
                txt_CUST_Ref_No.Text = ds.Tables[0].Rows[0]["CUST_REF_NO"].ToString();


                btnSave.Visible = false;
                btnDelete.Enabled = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                //trans.ResetFields(Page.Controls);
                Clear();
                btnSave.Visible = true;
                btnDelete.Enabled = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
        }
        else
        {
           // trans.ResetFields(Page.Controls);
            Clear();
            btnSave.Visible = true;
            btnDelete.Enabled = false;
            btnUpdate.Visible = false;
        }
    }
    private void Clear()
    {
            txt_Doc_Rec_Date.Text = string.Empty;
            ddlhrs_Doc_Rec_Date.SelectedValue = "00";
            ddlsec_Doc_Rec_Date.SelectedValue = "00";
        
            txtchklist_date.Text = string.Empty;
            ddlhrs_chklist_date.SelectedValue = "00";
            ddlsec_chklist_date.SelectedValue = "00";
        
            txtchk_app_date.Text = string.Empty;
            ddlhrs_chk_app_date.SelectedValue = "00";
            ddlsec_chk_app_date.SelectedValue = "00";
        
            txt_Ass_date.Text = string.Empty;
            ddlhrs_Ass_date.SelectedValue = "00";
            ddlsec_Ass_date.SelectedValue = "00";
        
            txt_Cleared_date.Text = string.Empty;
            ddlhrs_Cleared_dat.SelectedValue = "00";
            ddlsec_Cleared_dat.SelectedValue = "00";
        
            txt_DO_Valid_date.Text = string.Empty;
            ddlhrs_DO_Valid_date.SelectedValue = "00";
            ddlsec_DO_Valid_date.SelectedValue = "00";

            txtBondno.Text = string.Empty;
            txtboetype.Text = string.Empty;

        
            txt_duty_Rec_date.Text = string.Empty;
            ddlhrs_duty_Rec_date.SelectedValue = "00";
            ddlsec_duty_Rec_date.SelectedValue = "00";
        
            txt_duty_paid_date.Text = string.Empty;
            ddlhrs_duty_paid_date.SelectedValue = "00";
            ddlsec_duty_paid_date.SelectedValue = "00";

            txtgateinExport.Text = string.Empty;
            txtI_Orginport.Text = string.Empty;
            txt_I_transit_Port_ETA.Text = string.Empty;
            txt_II_ETD_from_Transit_Port.Text = string.Empty;
            txt_II_Transit_Port_ETA.Text = string.Empty;
            txt_III_ETD_from_Transit_Port.Text = string.Empty;
            txt_III_Transit_Port_ETA.Text = string.Empty;
            txt_Ful_Discharge_at_Transit_Port.Text = string.Empty;
            txt_Final_Vessel_to_CHPT.Text = string.Empty;
            txt_ETA.Text = string.Empty;
           
            txt_Container_Reached_CFS.Text = string.Empty;
        
            txt_Out_of_Charge_RCVD_Date.Text = string.Empty;
            ddlhrs_Out_of_Charge_RCVD_Date.SelectedValue = "00";
            ddlsec_Out_of_Charge_RCVD_Date.SelectedValue = "00";
        
            txt_Bill_Pass_Date.Text = string.Empty;
            ddlhrs_Bill_Pass_Date.SelectedValue = "00";
            ddlsec_Bill_Pass_Date.SelectedValue = "00";
        
            txt_Bill_SUbmitted_Date.Text = string.Empty;
            ddlhrs_Bill_SUbmitted_Date.SelectedValue = "00";
            ddlsec_Bill_SUbmitted_Date.SelectedValue = "00";
        
            txt_Payment_Recd_Date.Text = string.Empty;
            ddlhrs_Payment_Recd_Date.SelectedValue = "00";
            ddlsec_Payment_Recd_Date.SelectedValue = "00";

            txt_Contr_Arval_CCTL_WIT_TIMG.Text = string.Empty;
            txt_Last_Free_Date_Grnd_Rent_CFS.Text = string.Empty;

            txt_Delivery_Date_from_CFS.Text = string.Empty;
            ddlhrs_Delivery_Date_from_CFS.SelectedValue = "00";
            ddlsec_Delivery_Date_from_CFS.SelectedValue = "00";

            txt_No_of_GroundRent_Days.Text = string.Empty;
            txt_Ground_Rent_Charges.Text = string.Empty;
        
            txt_Reported_Date_to_WH.Text = string.Empty;
            ddlhrs_Reported_Date_to_WH.SelectedValue = "00";
            ddlsec_Reported_Date_to_WH.SelectedValue = "00";

            txt_Gate_Out_Date_from_WH.Text = string.Empty;
            txt_Vehicle_Detention_Days.Text = string.Empty;
        
            txt_Last_free_date_CNTR_Detention.Text = string.Empty;
            ddlhrs_Last_free_date_CNTR_Detention.SelectedValue = "00";
            ddlsec_Last_free_date_CNTR_Detention.SelectedValue = "00";
        
            txt_Empty_CNTR_Handed_Over_Date.Text = string.Empty;
            ddlhrs_Empty_CNTR_Handed_Over_Date.SelectedValue = "00";
            ddlsec_Empty_CNTR_Handed_Over_Date.SelectedValue = "00";

            txt_No_of_Detention_Days.Text = string.Empty;
            txt_Aging.Text = string.Empty;
            txt_Detention.Text = string.Empty;
            txt_Status.Text = string.Empty;
            txt_CFS_Charges.Text = string.Empty;

            txt_License_Date.Text = string.Empty;
            ddlhrs_License_Date.SelectedValue = "00";
            ddlsec_License_Date.SelectedValue = "00";

            txt_Remarks.Text = string.Empty;
            txt_PD_Bond_Balance.Text = string.Empty;
            txt_CUST_Ref_No.Text = string.Empty;

            txt_ATA_Date.Text = string.Empty;
            ddlhrs_txt_ATA_Date.SelectedValue = "00";
            ddlsec_txt_ATA_Date.SelectedValue = "00";
    }
}