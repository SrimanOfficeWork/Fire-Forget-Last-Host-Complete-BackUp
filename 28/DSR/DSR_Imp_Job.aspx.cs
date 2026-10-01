using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;


public partial class DSR_Imp_Job : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    DSR_CS DR = new DSR_CS();
    Global_variables ObjUBO = new Global_variables();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE,COMPANY_LICENSE;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        COMPANY_LICENSE = Connection.Company_License().ToLower();

        if (!Page.IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            btnrpt.Visible = false;
            T.Visible = false;


            if (Request.QueryString["Page"] == null)
            {
               load_Cus_Name();
               HDupdate_id.Value = "";
               load_Ref_Id();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                  
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlCus_name.Enabled = false;
                    ddljobno.Enabled = false;
                   
                    HD_Showcon.Value = "SAVED";
                    ViewState["UPDATED_ID"] = null;
                }
            }
            

            txt_Ref_Id.Attributes.Add("readonly", "readonly");
            txt_Ref_Id.Style.Add("background-color", "#F0F0F0");
        }

    }
    
    private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Request.QueryString["Jobno"].ToString();
        ObjUBO.A2 = Request.QueryString["Page"].ToString();
        ObjUBO.A4 = "Update_Job_Values";
        dss = DR.DSR_Select(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {

            //-----------------------------------------------------
             HDupdate_id.Value= dss.Tables[0].Rows[0]["ID"].ToString();
             txt_Ref_Id.Text=  dss.Tables[0].Rows[0]["REF_ID"].ToString();

             ddlCus_name.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString(), dss.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString()));
             ddlCus_name.SelectedIndex = 0;

             ddljobno.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString(), dss.Tables[0].Rows[0]["JOBNO"].ToString()));
             ddljobno.SelectedIndex = 0;

             txt_Manual_Jobno.Text=dss.Tables[0].Rows[0]["MANUAL_JOBNO"].ToString();
             txt_Business_Unit.Text= dss.Tables[0].Rows[0]["BUSINESS_UNIT"].ToString();
             ddl_Month.SelectedValue = dss.Tables[0].Rows[0]["MONTH"].ToString();
             ddl_Year.SelectedValue = dss.Tables[0].Rows[0]["YEAR"].ToString();
             txt_CHA_Ref_No.Text=dss.Tables[0].Rows[0]["CHA_REF_NO"].ToString();
             txt_Doc_Receipt_date.Text=dss.Tables[0].Rows[0]["DC_RECEIPT_DATE"].ToString();
             txt_Imp_Ref_No.Text=dss.Tables[0].Rows[0]["IMPORT_REF_NO"].ToString();
             txt_Filling_Scheme.Text=dss.Tables[0].Rows[0]["FILING_SCHEME"].ToString();
             txt_Br_Slno.Text=dss.Tables[0].Rows[0]["BRANCH_SL_NO"].ToString();
             ddl_BE_Type.SelectedValue=  dss.Tables[0].Rows[0]["BE_TYPE"].ToString();

             txt_MBL_No.Text= dss.Tables[0].Rows[0]["MBL_NO"].ToString();
             txt_MBL_Date.Text=dss.Tables[0].Rows[0]["MBL_DATE"].ToString();
             txt_HBL_No.Text=dss.Tables[0].Rows[0]["HBL_NO"].ToString();
             txt_HBL_Date.Text=dss.Tables[0].Rows[0]["HBL_DATE"].ToString();
             txt_Pkg.Text=dss.Tables[0].Rows[0]["PACKAGES"].ToString();
             txt_Gross_Wgt.Text=dss.Tables[0].Rows[0]["GROSS_WGT"].ToString();
             txt_Net_Wgt.Text=dss.Tables[0].Rows[0]["NET_WGT"].ToString();
             txt_Container_No.Text=dss.Tables[0].Rows[0]["CONTAINER_NO"].ToString();
             txt_20_F.Text=dss.Tables[0].Rows[0]["TWENTY_F"].ToString();
             txt_40_F.Text=dss.Tables[0].Rows[0]["FOURTY_f"].ToString();
             txt_CBM_CHG_Wgt.Text=dss.Tables[0].Rows[0]["CBM_CHG_WGT"].ToString();
             ddl_Mode_Type.SelectedValue=dss.Tables[0].Rows[0]["MODE_TYPE"].ToString();
             ddl_Inco_Terms.SelectedValue=dss.Tables[0].Rows[0]["INCO_TERMS"].ToString();
             txt_Supplier_Name.Text=dss.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
             txt_Supplier_Inv_No.Text=dss.Tables[0].Rows[0]["SUPPLIER_INV_NO"].ToString();
             txt_Supplier_Inv_Date.Text=dss.Tables[0].Rows[0]["SUPPLIER_INV_DATE"].ToString();
             txt_Supplier_Inv_Value.Text=dss.Tables[0].Rows[0]["SUPPLIER_INV_VALUE"].ToString();
             txt_Currency.Text=dss.Tables[0].Rows[0]["CURRENCY"].ToString();
             txt_Bond_No.Text=dss.Tables[0].Rows[0]["BOND_NO"].ToString();
             txt_Bond_Date.Text=dss.Tables[0].Rows[0]["BOND_DATE"].ToString();
             txt_WH_Details.Text=dss.Tables[0].Rows[0]["WARE_HOUSE_DETAILS"].ToString();
             txt_License_Type.Text=dss.Tables[0].Rows[0]["LICENSE_TYPE"].ToString();
             txt_Freight_For_Name.Text=dss.Tables[0].Rows[0]["FREIGHT_FORWARDING_NAME"].ToString();
             txt_Freight_Inv_Rec_Date.Text=dss.Tables[0].Rows[0]["FREIGHT_INVOICE_RECD_DATE"].ToString();
             txt_Freight_Rec_Date.Text=dss.Tables[0].Rows[0]["FREIGHT_LINER_REC_DATE"].ToString();
             ddl_CFS_Location.SelectedValue= dss.Tables[0].Rows[0]["CFS_LOCATION"].ToString();
             txt_De_Stuffing_Date.Text=dss.Tables[0].Rows[0]["DE_STUFFING_DATE"].ToString();
             txt_Mother_Vessel_Name.Text=dss.Tables[0].Rows[0]["MOTHER_VESSEL_NAME"].ToString();
             txt_Mother_Vessel_Date.Text=dss.Tables[0].Rows[0]["MOTHER_VESSEL_DATE"].ToString();
             txt_Feeder_Vessel_Name.Text=dss.Tables[0].Rows[0]["FEEDER_VESSEL_NAME"].ToString();
             txt_Feeder_Vessel_Date.Text=dss.Tables[0].Rows[0]["FEEDER_VESSEL_DATE"].ToString();
             ddl_BOE_Type.SelectedValue=dss.Tables[0].Rows[0]["BOE_TYPE"].ToString();
             txt_ETA_Date.Text= dss.Tables[0].Rows[0]["ETA"].ToString();
             txt_ETD_Date.Text=dss.Tables[0].Rows[0]["ETD"].ToString();
             txt_Ass_value.Text=dss.Tables[0].Rows[0]["ASS_VALUE"].ToString();
             txt_Customs_Duty.Text=dss.Tables[0].Rows[0]["CUSTOMS_DUTY"].ToString();
             txt_BOE_No.Text= dss.Tables[0].Rows[0]["BOE_NO"].ToString();
             txt_BOE_Date.Text=dss.Tables[0].Rows[0]["BOE_DATE"].ToString();
             txt_TR6_No.Text=dss.Tables[0].Rows[0]["TR_SIX_NO"].ToString();
             txt_TR6_Date.Text=dss.Tables[0].Rows[0]["TR_SIX_DATE"].ToString();
             txt_Duty_Req_date.Text=dss.Tables[0].Rows[0]["DUTY_REQUEST_DATE"].ToString();
             txt_EDD_Paid_On.Text=dss.Tables[0].Rows[0]["EDD_PAID_ON"].ToString();
             txt_Duty_Penalty.Text=dss.Tables[0].Rows[0]["DUTY_PNALTY"].ToString();
             txt_Duty_Interst.Text= dss.Tables[0].Rows[0]["DUTY_INTEREST"].ToString();
             txt_Examination_Date.Text=dss.Tables[0].Rows[0]["EXAMINATION_DATE"].ToString();
             txt_OOC.Text=dss.Tables[0].Rows[0]["OOC"].ToString();
             txt_Shipment_Ready_Delivery.Text=dss.Tables[0].Rows[0]["SHIPMENT_READY_DELIVERY_DATE"].ToString();
             txt_Shipment_Cleared_date.Text=dss.Tables[0].Rows[0]["SHIPMENT_CLEARED_DATE"].ToString();
             txt_Shipment_Recd_date.Text=dss.Tables[0].Rows[0]["SHIPMENT_RECD_DATE"].ToString();
             txt_Halting_Days.Text=dss.Tables[0].Rows[0]["HALTING_DAYS"].ToString();
             txt_BOE_Despatch_date.Text=dss.Tables[0].Rows[0]["BOE_DESPATCH_DATE"].ToString();
             txt_BOE_H_Over_date.Text=dss.Tables[0].Rows[0]["BOE_HANDOVER_DATE"].ToString();
             ddl_From_CFS.SelectedValue= dss.Tables[0].Rows[0]["FROM_CFS"].ToString();
             txt_No_of_Container.Text=dss.Tables[0].Rows[0]["NO_OF_CONTAINER"].ToString();
             txt_Daily_Status.Text=dss.Tables[0].Rows[0]["DAILY_STATUS_REMARKS"].ToString();
             txt_Detailed_Status.Text=dss.Tables[0].Rows[0]["DETAILED_STATUS"].ToString();
             txt_H_Over_To_Tr_Date.Text=dss.Tables[0].Rows[0]["DOC_HANDOVER_TO_TRANSPORT_DATE"].ToString();
             txt_PD_Bond_No.Text=dss.Tables[0].Rows[0]["PD_BOND_NO"].ToString();
             txt_PD_Bond_Debit_Date.Text=dss.Tables[0].Rows[0]["PD_BOND_DEBIT_DATE"].ToString();
             txt_PD_Bond_Amt.Text=dss.Tables[0].Rows[0]["PD_BOND_AMOUNT"].ToString();
             txt_Original_Doc_Rec.Text=dss.Tables[0].Rows[0]["ORIGINAL_DOCUMENT_REC_REMARKS"].ToString();
             txt_Original_Doc_date.Text=dss.Tables[0].Rows[0]["ORIGINAL_DOCUMENT_DATE"].ToString();
             txt_CHA_Inv_No.Text=dss.Tables[0].Rows[0]["CHA_INVOICE_NO"].ToString();
             txt_Service_Bill_Date.Text=dss.Tables[0].Rows[0]["SERVICE_BILL_DATE"].ToString();
             txt_Liner_Charge.Text=dss.Tables[0].Rows[0]["LINER_CHARGES"].ToString();
             txt_Memurrage_Charge.Text=dss.Tables[0].Rows[0]["DUMURRAGE_CHARGES"].ToString();
             txt_Container_Detention.Text=dss.Tables[0].Rows[0]["CONTAINER_DETENTION"].ToString();
             txt_CFS_Charges.Text=dss.Tables[0].Rows[0]["CFS_CHARGES"].ToString();
             txt_AAI_Charges.Text=dss.Tables[0].Rows[0]["AAI_CHARGES"].ToString();
             txt_AAI_Demurrage_Charge.Text=dss.Tables[0].Rows[0]["AAI_DUMURRAGE_CHARGES"].ToString();
             txt_CHA_Service_Charge.Text=dss.Tables[0].Rows[0]["CHA_SERVICE_CHARGES"].ToString();
             txt_MISC.Text=dss.Tables[0].Rows[0]["MISC"].ToString();
             txt_Transport_Charge.Text=dss.Tables[0].Rows[0]["TRANSPORT_CHARGES"].ToString();
             txt_FSC.Text=dss.Tables[0].Rows[0]["FSC"].ToString();
             txt_Halting_Charge.Text=dss.Tables[0].Rows[0]["HALTING_CHARGES"].ToString();
             txt_Service_Tax.Text=dss.Tables[0].Rows[0]["SERVICE_TAX_RS"].ToString();
             txt_Total_Clearance_Charge.Text=dss.Tables[0].Rows[0]["TOTAL_CLEARANCE_CHARGES"].ToString();
             txt_Bills_Handover_Date.Text=dss.Tables[0].Rows[0]["BILLS_HANDED_OVER_DATE"].ToString();

             txt_LHA_Name.Text = dss.Tables[0].Rows[0]["LHA_NAME"].ToString();
             txt_Branch_name.Text = dss.Tables[0].Rows[0]["BRANCH_NAME"].ToString();
             txt_Place.Text = dss.Tables[0].Rows[0]["PLACE"].ToString();
             txt_Origin.Text = dss.Tables[0].Rows[0]["ORIGIN"].ToString();
             txt_HS_Code.Text = dss.Tables[0].Rows[0]["HS_CODE"].ToString();
             txt_Description.Text = dss.Tables[0].Rows[0]["DESCRIPTION"].ToString();
             txt_CBM.Text = dss.Tables[0].Rows[0]["CBM"].ToString();
             txt_Dimension.Text = dss.Tables[0].Rows[0]["DIMENSION"].ToString();
             txt_Port_of_Loading.Text = dss.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
             txt_Port_of_Discharge.Text = dss.Tables[0].Rows[0]["PORT_OF_DISCHARGE"].ToString();
             txt_ATD_Date.Text = dss.Tables[0].Rows[0]["ATD_DATE"].ToString();
             txt_ATA_Date.Text = dss.Tables[0].Rows[0]["ATA_DATE"].ToString();
             txt_Transit_Time.Text = dss.Tables[0].Rows[0]["TRANSIT_TIME"].ToString();
             txt_Port_Name.Text = dss.Tables[0].Rows[0]["PORT_NAME"].ToString();
             txt_Copy_Doc_Recivied_Dt.Text = dss.Tables[0].Rows[0]["COPY_DOC_REC_DATE"].ToString();
             txt_Checklist_Confim.Text = dss.Tables[0].Rows[0]["CHECKLIST_CONFIRMATION_DATE"].ToString();
             txt_BE_Assesed_Dt.Text = dss.Tables[0].Rows[0]["BE_ASSESED_DATE"].ToString();
             txt_Duty_Informed_Dt.Text = dss.Tables[0].Rows[0]["DUTY_INFORMED_DATE"].ToString();
             txt_Duty_Received.Text = dss.Tables[0].Rows[0]["DUTY_RECEVIED_DATE"].ToString();
             txt_Duty_Paid_Dt.Text = dss.Tables[0].Rows[0]["DUTY_PAID_DATE"].ToString();
             txt_Actual_Proc_Time.Text = dss.Tables[0].Rows[0]["ACTUAL_PROCESSING_TIME"].ToString();
             txt_RE_Bond_No.Text = dss.Tables[0].Rows[0]["RE_BOND_NO"].ToString();
             txt_RE_Bond_Amt.Text = dss.Tables[0].Rows[0]["RE_BOND_AMOUNT"].ToString();
        }
    }
  
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

              i= DSR_Jobno_Insert_Update(Imp_name, "S");
                                if (i == 1)
                                {
                                    //-----------------------FOR USER RIGHTS--------------------------------//
                                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                                    PAGE_MODIFY = user_Create.PAGE_MODIFY;
                                    //---------------SAVE ONLY------------------//

                                    if (PAGE_MODIFY == "False")
                                    {
                                        btnNew_Click1(sender, e);
                                    }
                                    else
                                    {
                                        btnUpdate.CssClass = "save";
                                        btnUpdate.Visible = true;
                                        btnSave.Visible = false;
                                        btnSave.Focus();
                                    }
                                    //-----------------------FOR USER RIGHTS--------------------------------//

                                    ViewState["UPDATED_ID"] = null;
                                    HD_Showcon.Value = "SAVED";
                                    Alert_msg("Saved Successfully", "btnSave");
                                    HDupdate_id.Value = Convert.ToString(DR.UPDATE_ID);

                                    btnrpt.Visible = true;
                                  
                                    F.Visible = false;
                                    T.Visible = true;

                                    ddlCus_name.Attributes.Add("readonly", "readonly");
                                    ddlCus_name.Style.Add("background-color", "#F0F0F0");

                                    ddljobno.Attributes.Add("readonly", "readonly");
                                    ddljobno.Style.Add("background-color", "#F0F0F0");

                                    ddlCus_name.Enabled = false;
                                    ddljobno.Enabled = false;

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
                                //-------------------------------------------------------------
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = DSR_Jobno_Insert_Update(Imp_name, "U");
                    if (i == 1)
                    {
                        if (ViewState["UPDATED_ID"] != null)
                        {
                            Alert_msg("Updated Successfully", "btnUpdate");
                        }
                        else
                        {
                            Alert_msg("Saved Successfully", "btnUpdate");
                            HD_Showcon.Value = "SAVED";
                        }
                    }
                    else if (i == 2)
                    {
                        Alert_msg("Job No Already Exist!", "btnUpdate");
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            i = DSR_Jobno_Insert_Update("", "D");
            if (i == 1)
            {
                btnNew_Click1(sender, e);
                Alert_msg("Deleted");
                btnrpt.Visible = false;
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
  
    public int DSR_Jobno_Insert_Update(string I_Name , string Flag )
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();

        ObjUBO.A2 = ddlCus_name.SelectedItem.ToString();
        ObjUBO.A3 = ddljobno.SelectedValue.ToString();
        ObjUBO.A4 = ddljobno.SelectedItem.ToString();
        ObjUBO.A5 = txt_Manual_Jobno.Text;
        ObjUBO.A6 = txt_Business_Unit.Text;
        ObjUBO.A7 = ddl_Month.SelectedValue.ToString();
        ObjUBO.A8 = ddl_Year.SelectedValue.ToString();
        ObjUBO.A9 = txt_CHA_Ref_No.Text;
        ObjUBO.A10 = txt_Doc_Receipt_date.Text;
        ObjUBO.A11 = txt_Imp_Ref_No.Text;

        ObjUBO.A12 = txt_Filling_Scheme.Text;
        ObjUBO.A13 = txt_Br_Slno.Text;
        ObjUBO.A14 = ddl_BE_Type.SelectedValue.ToString();
        ObjUBO.A15 = txt_MBL_No.Text;
        ObjUBO.A16 = txt_MBL_Date.Text;
        ObjUBO.A17 = txt_HBL_No.Text;
        ObjUBO.A18 = txt_HBL_Date.Text;
        ObjUBO.A19 = txt_Pkg.Text;
        ObjUBO.A20 = txt_Gross_Wgt.Text;
        ObjUBO.A21 = txt_Net_Wgt.Text;

        ObjUBO.A22 = txt_Container_No.Text;
        ObjUBO.A23 = txt_20_F.Text;
        ObjUBO.A24 = txt_40_F.Text;
        ObjUBO.A25 = txt_CBM_CHG_Wgt.Text;
        ObjUBO.A26 = ddl_Mode_Type.SelectedValue.ToString();
        ObjUBO.A27 = ddl_Inco_Terms.SelectedValue.ToString();
        ObjUBO.A28 = txt_Supplier_Name.Text;
        ObjUBO.A29 = txt_Supplier_Inv_No.Text;
        ObjUBO.A30 = txt_Supplier_Inv_Date.Text;
        ObjUBO.A31 = txt_Supplier_Inv_Value.Text;

        ObjUBO.A32 = txt_Currency.Text;
        ObjUBO.A33 = txt_Bond_No.Text;
        ObjUBO.A34 = txt_Bond_Date.Text;
        ObjUBO.A35 = txt_WH_Details.Text;

        ObjUBO.A36 = txt_License_Type.Text;
        ObjUBO.A37 = txt_Freight_For_Name.Text;
        ObjUBO.A38 = txt_Freight_Inv_Rec_Date.Text;
        ObjUBO.A39 = txt_Freight_Rec_Date.Text;
        ObjUBO.A40 = ddl_CFS_Location.SelectedValue.ToString();
        ObjUBO.A41 = txt_De_Stuffing_Date.Text;

        ObjUBO.A42 = txt_Mother_Vessel_Name.Text;
        ObjUBO.A43 = txt_Mother_Vessel_Date.Text;
        ObjUBO.A44 = txt_Feeder_Vessel_Name.Text;
        ObjUBO.A45 = txt_Feeder_Vessel_Date.Text;
        ObjUBO.A46 = ddl_BOE_Type.SelectedValue.ToString();
        ObjUBO.A47 = txt_ETA_Date.Text;
        ObjUBO.A48 = txt_ETD_Date.Text;
        ObjUBO.A49 = txt_Ass_value.Text;
        ObjUBO.A50 = txt_Customs_Duty.Text;
        ObjUBO.A51 = txt_BOE_No.Text;

        ObjUBO.A52 = txt_BOE_Date.Text;
        ObjUBO.A53 = txt_TR6_No.Text;
        ObjUBO.A54 = txt_TR6_Date.Text;
        ObjUBO.A55 = txt_Duty_Req_date.Text;
        ObjUBO.A56 = txt_EDD_Paid_On.Text;
        ObjUBO.A57 = txt_Duty_Penalty.Text;
        ObjUBO.A58 = txt_Duty_Interst.Text;
        ObjUBO.A59 = txt_Examination_Date.Text;
        ObjUBO.A60 = txt_OOC.Text;
        ObjUBO.A61 = txt_Shipment_Ready_Delivery.Text;

        ObjUBO.A62 = txt_Shipment_Cleared_date .Text;
        ObjUBO.A63 = txt_Shipment_Recd_date.Text;
        ObjUBO.A64 = txt_Halting_Days.Text;
        ObjUBO.A65 = txt_BOE_Despatch_date.Text;
        ObjUBO.A66 = txt_BOE_H_Over_date.Text;
        ObjUBO.A67 = ddl_From_CFS.SelectedValue.ToString();
        ObjUBO.A68 = txt_No_of_Container.Text;
        ObjUBO.A69 = txt_Daily_Status.Text;
        ObjUBO.A70 = txt_Detailed_Status.Text;
        ObjUBO.A71 = txt_H_Over_To_Tr_Date.Text;

        ObjUBO.A72 = txt_PD_Bond_No.Text;
        ObjUBO.A73 = txt_PD_Bond_Debit_Date.Text;
        ObjUBO.A74 = txt_PD_Bond_Amt.Text;
        ObjUBO.A75 = txt_Original_Doc_Rec.Text;
        ObjUBO.A76 = txt_Original_Doc_date.Text;

        ObjUBO.A77 = txt_CHA_Inv_No.Text;
        ObjUBO.A78 = txt_Service_Bill_Date.Text;
        ObjUBO.A79 = txt_Liner_Charge.Text;
        ObjUBO.A80 = txt_Memurrage_Charge.Text;
        ObjUBO.A81 = txt_Container_Detention.Text;

        ObjUBO.A82 = txt_CFS_Charges.Text;
        ObjUBO.A83 = txt_AAI_Charges.Text;
        ObjUBO.A84 = txt_AAI_Demurrage_Charge.Text;
        ObjUBO.A85 = txt_CHA_Service_Charge.Text;
        ObjUBO.A86 = txt_MISC.Text;
        ObjUBO.A87 = txt_Transport_Charge.Text;
        ObjUBO.A88 = txt_FSC.Text;
        ObjUBO.A89 = txt_Halting_Charge.Text;
        ObjUBO.A90 = txt_Service_Tax.Text;
        ObjUBO.A91 = txt_Total_Clearance_Charge.Text;
        ObjUBO.A92 = txt_Bills_Handover_Date.Text;
        ObjUBO.A93 = Flag;
        ObjUBO.A94 = txt_Ref_Id.Text;

        ObjUBO.A95 = txt_LHA_Name.Text;
        ObjUBO.A96 = txt_Branch_name.Text;
        ObjUBO.A97 = txt_Place.Text;
        ObjUBO.A98 = txt_Origin.Text;
        ObjUBO.A99 = txt_HS_Code.Text;
        ObjUBO.A100 = txt_Description.Text;
        ObjUBO.A101 = txt_CBM.Text;
        ObjUBO.A102 = txt_Dimension.Text;
        ObjUBO.A103 = txt_Port_of_Loading.Text;
        ObjUBO.A104 = txt_Port_of_Discharge.Text;
        ObjUBO.A105 = txt_ATD_Date.Text;
        ObjUBO.A106 = txt_ATA_Date.Text;
        ObjUBO.A107 = txt_Transit_Time.Text;
        ObjUBO.A108 = txt_Port_Name.Text;
        ObjUBO.A109 = txt_Copy_Doc_Recivied_Dt.Text;
        ObjUBO.A110 = txt_Checklist_Confim.Text;
        ObjUBO.A111 = txt_BE_Assesed_Dt.Text;
        ObjUBO.A112 = txt_Duty_Informed_Dt.Text;
        ObjUBO.A113 = txt_Duty_Received.Text;
        ObjUBO.A114 = txt_Duty_Paid_Dt.Text;
        ObjUBO.A115 = txt_Actual_Proc_Time.Text;
        ObjUBO.A116 = txt_RE_Bond_No.Text;
        ObjUBO.A117 = txt_RE_Bond_Amt.Text;

        DR.DSR_INS_UPD(ObjUBO);
        i = DR.result;
        return i;
    }
    private void load_Cus_Name()
    {
        try
        {
            ddlCus_name.Items.Clear();
            ddljobno.Items.Clear();

            DataSet dss = new DataSet();
            ObjUBO.A4 = "Imp_Name_Select";
            dss = DR.DSR_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlCus_name.DataSource = dss.Tables[0];
                ddlCus_name.DataTextField = "Cus_Name";
                ddlCus_name.DataValueField = "Cus_Name";
                ddlCus_name.DataBind();
            }
            ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCus_name.SelectedIndex = 0;

            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Jobno()
    {
        ddljobno.Items.Clear();
        try
        {
            if (ddlCus_name.SelectedValue.ToString() != string.Empty)
            {
                DataSet dss = new DataSet();
                ObjUBO.A3 = ddlCus_name.SelectedValue.ToString();
                ObjUBO.A4 = "Jobno_Select";
                dss = DR.DSR_Select(ObjUBO);
                //-----------end---------------------
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddljobno.DataSource = dss.Tables[0];
                    ddljobno.DataTextField = "JOBNO";
                    ddljobno.DataValueField = "JOBNO";
                    ddljobno.DataBind();
                }
            }

            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Ref_Id()
    {
        DataSet dss = new DataSet();
        ObjUBO.A4 = "Load_Ref_Id";
        dss = DR.DSR_Select(ObjUBO);
        //-----------end---------------------
        if (dss.Tables[0].Rows.Count > 0)
        {
            txt_Ref_Id.Text = dss.Tables[0].Rows[0]["REF_ID"].ToString();
        }
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        HDupdate_id.Value = string.Empty;

        ddlCus_name.Enabled = true;
        ddljobno.Enabled = true;
        btnrpt.Visible = false;

        load_Cus_Name();

        ddlCus_name.Style.Add("background-color", "white");
        ddljobno.Style.Add("background-color", "white");

        load_Ref_Id();
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_data();
    }
    protected void ddlCus_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Jobno();
    }
    private void Load_data()
    {
        DataSet ds = new DataSet();
        if (ddljobno.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddljobno.SelectedValue.ToString();
            ObjUBO.A3 = ddlCus_name.SelectedValue.ToString();
            ObjUBO.A4 = "IMP_Job_Data";
            ds = DR.DSR_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_CHA_Ref_No.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                txt_Doc_Receipt_date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                txt_Imp_Ref_No.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                txt_Br_Slno.Text = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                ddl_BE_Type.SelectedValue = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();

                txt_Port_of_Loading.Text = ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
                txt_Port_of_Discharge.Text = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                txt_MBL_No.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                txt_MBL_Date.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBLDATE"].ToString();
                txt_HBL_No.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                txt_HBL_Date.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLDATE"].ToString();

                txt_Pkg.Text = ds.Tables[1].Rows[0]["Tot_pkg"].ToString();
                txt_Gross_Wgt.Text = ds.Tables[1].Rows[0]["Gross_Wgt"].ToString();
                txt_Net_Wgt.Text = ds.Tables[1].Rows[0]["Net_Wgt"].ToString();

                txt_Feeder_Vessel_Name.Text = ds.Tables[1].Rows[0]["IGM_AIRLINENAME"].ToString();
                txt_ETA_Date.Text = ds.Tables[1].Rows[0]["IGM_FLIGHT_VESSELDATE"].ToString();
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                txt_Container_No.Text = ds.Tables[2].Rows[0]["Con_No"].ToString();
                ddl_Mode_Type.SelectedValue = ds.Tables[2].Rows[0]["FCL_OR_LCL"].ToString();

                txt_20_F.Text = ds.Tables[2].Rows[0]["T20w_Ft"].ToString();
                txt_40_F.Text = ds.Tables[2].Rows[0]["F40_Ft"].ToString();
                txt_No_of_Container.Text = ds.Tables[2].Rows[0]["Con_cnt"].ToString();
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                txt_Supplier_Inv_No.Text = ds.Tables[3].Rows[0]["INVOICE_NO"].ToString();
                txt_Supplier_Inv_Date.Text = ds.Tables[3].Rows[0]["INVOICE_DATE"].ToString();
                txt_Supplier_Name.Text = ds.Tables[3].Rows[0]["SUPPLIER_NAME"].ToString();
                txt_Supplier_Inv_Value.Text = ds.Tables[3].Rows[0]["INVOICE_VALUE"].ToString();
                txt_Currency.Text = ds.Tables[3].Rows[0]["INVOICE_CURRENCY"].ToString();
                ddl_Inco_Terms.SelectedValue= ds.Tables[3].Rows[0]["TERMS"].ToString();
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                txt_Bond_No.Text = ds.Tables[4].Rows[0]["Bond_No"].ToString();
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                txt_License_Type.Text = ds.Tables[5].Rows[0]["SCHEME_CODE"].ToString();
                txt_Ass_value.Text = ds.Tables[5].Rows[0]["Ass_value"].ToString();
                txt_Customs_Duty.Text = ds.Tables[5].Rows[0]["Duty_value"].ToString();
                txt_Description.Text = ds.Tables[5].Rows[0]["ITEM_DESCRIPTION"].ToString();
                txt_HS_Code.Text = ds.Tables[5].Rows[0]["CTH_NO"].ToString();
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                txt_BOE_No.Text = ds.Tables[6].Rows[0]["BE_NO"].ToString();
                txt_BOE_Date.Text = ds.Tables[6].Rows[0]["BE_DATE"].ToString();
            }
        }
    }
}