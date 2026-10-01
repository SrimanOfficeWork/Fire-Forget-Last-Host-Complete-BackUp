using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.IO;

public partial class eRoyalMasters_Product_Import_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();

    DataSet dtuser = new DataSet();
    public int i;
    public string  chk;
    adminmaster adm = new adminmaster();
    
    AppSession aps = new AppSession();
    public string ID = "";
    ErrorLogs er = new ErrorLogs();

    IFormatProvider provider = new System.Globalization.CultureInfo("es-ES", true);
    
   
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public int Screen_Id;

    protected void Page_Load(object sender, EventArgs e)
    {

        txtDescription.Focus();
        aps.checkSession();

        hdn_companyID.Value = Connection.COMPANYID();
        hdfTransport_mode.Value = "";
        Call_Server_Side_Method();
      
        if (!IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 27;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            ddlBind();

            EditSupDetails();
        }
        
    }
    public void Page_Rights(int i)
    {
        user_Create.RetrieveAll_User_Screen_Rights_Details(i);
        PAGE_WRITE = user_Create.PAGE_WRITE;
        PAGE_READ = user_Create.PAGE_READ;
        PAGE_MODIFY = user_Create.PAGE_MODIFY;
        PAGE_DELETE = user_Create.PAGE_DELETE;

        //---------------READ ONLY------------------//

        if (PAGE_READ == "False")
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
            btnNew.ToolTip = "You don't have permission to access";
            btnSave.ToolTip = "You don't have permission to access";
            btnUpdate.ToolTip = "You don't have permission to access";
            btnDelete.ToolTip = "You don't have permission to access";

        }
        else
        {
            //}
            //btnNew.Enabled = true;
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
                btnNew.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
                btnNew.Enabled = false;
            }
            //---------------UPDATE BUTTON------------------//

            if (PAGE_MODIFY == "True")
                btnUpdate.Enabled = true;
            else
            {
                btnUpdate.Enabled = false;
                btnUpdate.ToolTip = "You don't have permission to access";
            }
            //---------------DELETE BUTTON------------------//

            if (PAGE_DELETE == "True")
                btnDelete.Enabled = true;
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ToolTip = "You don't have permission to access";
            }
        }
    }


   
    public void ddlBind()
    {
        #region SPL Type
        ddlBasicSPLTYPE.Items.Clear();
        ddlBasicSPLTYPE.Items.Add("Plus");
        ddlBasicSPLTYPE.Items.Add("Minus");
        ddlBasicSPLTYPE.Items.Add("Lower");
        ddlBasicSPLTYPE.Items.Add("Higher");

        ddlNCD_SPL_TYPE.Items.Clear();
        ddlNCD_SPL_TYPE.Items.Add("Plus");
        ddlNCD_SPL_TYPE.Items.Add("Minus");
        ddlNCD_SPL_TYPE.Items.Add("Lower");
        ddlNCD_SPL_TYPE.Items.Add("Higher");

        ddlSafeguard_SPL_TYPE.Items.Clear();
        ddlSafeguard_SPL_TYPE.Items.Add("Plus");
        ddlSafeguard_SPL_TYPE.Items.Add("Minus");
        ddlSafeguard_SPL_TYPE.Items.Add("Lower");
        ddlSafeguard_SPL_TYPE.Items.Add("Higher");

        ddlCVD_SPL_TYPE.Items.Clear();
        ddlCVD_SPL_TYPE.Items.Add("Plus");
        ddlCVD_SPL_TYPE.Items.Add("Minus");
        ddlCVD_SPL_TYPE.Items.Add("Lower");
        ddlCVD_SPL_TYPE.Items.Add("Higher");

        ddl_Addl_GSI_SPL_TYPE.Items.Clear();
        ddl_Addl_GSI_SPL_TYPE.Items.Add("Plus");
        ddl_Addl_GSI_SPL_TYPE.Items.Add("Minus");
        ddl_Addl_GSI_SPL_TYPE.Items.Add("Lower");
        ddl_Addl_GSI_SPL_TYPE.Items.Add("Higher");

        ddl_Addl_SHE11_Type.Items.Clear();
        ddl_Addl_SHE11_Type.Items.Add("Plus");
        ddl_Addl_SHE11_Type.Items.Add("Minus");
        ddl_Addl_SHE11_Type.Items.Add("Lower");
        ddl_Addl_SHE11_Type.Items.Add("Higher");


        ddl_Addl_TTA_Type.Items.Clear();
        ddl_Addl_TTA_Type.Items.Add("Plus");
        ddl_Addl_TTA_Type.Items.Add("Minus");
        ddl_Addl_TTA_Type.Items.Add("Lower");
        ddl_Addl_TTA_Type.Items.Add("Higher");

        ddl_Addl_Health_CESS_Type.Items.Clear();
        ddl_Addl_Health_CESS_Type.Items.Add("Plus");
        ddl_Addl_Health_CESS_Type.Items.Add("Minus");
        ddl_Addl_Health_CESS_Type.Items.Add("Lower");
        ddl_Addl_Health_CESS_Type.Items.Add("Higher");

        ddl_CESS_Type.Items.Clear();
        ddl_CESS_Type.Items.Add("Plus");
        ddl_CESS_Type.Items.Add("Minus");
        ddl_CESS_Type.Items.Add("Lower");
        ddl_CESS_Type.Items.Add("Higher");

        ddlOther_Duty_Type.Items.Clear();
        ddlOther_Duty_Type.Items.Add("Plus");
        ddlOther_Duty_Type.Items.Add("Minus");
        ddlOther_Duty_Type.Items.Add("Lower");
        ddlOther_Duty_Type.Items.Add("Higher");



        # endregion
    }

    public void EditSupDetails()
    {
      
        if (Request.QueryString["ID"] != "" && Request.QueryString["ID"] != null)
        {
            int i = 0;
            ID = Request.QueryString["ID"];
            erm.Eproduct_imp_id = ID;
            erm.Eproduct_imp_cth = "0";
            erm.Eproduct_imp_ceth = "0";
            erm.Eproduct_imp_ritc = "0";
            //erm.Eproduct_imp_potype = "0";
            erm.Eproduct_imp_description = "0";
            erm.Ename = "select_conwithcode";
            erm.EWorking_Period = Connection.WorkingPeriod();

            dtuser = erm.RetrieveAll_Import_Caterpillar_MASTER();
            if (dtuser.Tables[0].Rows.Count > 0)
            {
                ddlBind();
                txtDescription.Text = dtuser.Tables[0].Rows[0]["PRODUCT_DESCRIPTION"].ToString();               
                txtRITCNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_RITC"].ToString();
                txtCTHNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CTH"].ToString();
                txtBasicNotn.Text = dtuser.Tables[0].Rows[0]["PRODUCT_BCD_NOTN"].ToString();
                txtBasicSLNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_BCD_SLNO"].ToString();
                txtBasicRate.Text = dtuser.Tables[0].Rows[0]["PRODUCT_BCD_RATE"].ToString();
                txtBasicSPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_BCD_SPL"].ToString();

                txtBasicUnit.Text = dtuser.Tables[0].Rows[0]["PRODUCT_BCD_UNIT"].ToString();
                string ddlBasicSPL = dtuser.Tables[0].Rows[0]["PRODUCT_BCD_SPL_TYPE"].ToString();
                ddlBasicSPLTYPE.Items.Remove(ddlBasicSPL);

                ddlBasicSPLTYPE.Items.Insert(0, ddlBasicSPL);
                

                txtAddlDuty_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN"].ToString();
                txtAddlDuty_NOTN_SL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_NOTN_SL"].ToString();

                txtAddlDuty_Rate.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_DUTY_RATE"].ToString();

                txtEdu_Cess_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN"].ToString();
                txtEdu_Cess_NOTN_SL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_EDU_CESS_NOTN_SL"].ToString();
                txtEdu_Cess_Rate.Text = dtuser.Tables[0].Rows[0]["PRODUCT_EDU_CESS_RATE"].ToString();
                txtSec_Edu_Cess_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN"].ToString();
                txtSec_Edu_Cess_NOTN_SL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_NOTN_SL"].ToString();
                txtSec_Edu_Cess_Rate.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SEC_EDU_CESS_RATE"].ToString();

                txtNCD_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_NCD_NOTN"].ToString();
                txtNCD_SLNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_NCD_SLNO"].ToString();
                txtNCD_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_NCD_RATE"].ToString();
                txtNCD_SPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_NCD_SPL"].ToString();
                txtNCD_UNIT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_NCD_UNIT"].ToString();                
                string ddlNCD_SPL = dtuser.Tables[0].Rows[0]["PRODUCT_NCD_SPL_TYPE"].ToString();
                ddlNCD_SPL_TYPE.Items.Remove(ddlNCD_SPL);

                ddlNCD_SPL_TYPE.Items.Insert(0, ddlNCD_SPL);
                txtAggregate_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN"].ToString();
                txtAggregate_NOTN_SL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_SL"].ToString();
                txtAggregate_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_AGGREGATE_DUTY_NOTN_RATE"].ToString();
                txtSafeguard_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_NOTN"].ToString();
                txtSafeguard_SL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SLNO"].ToString();
                txtSafeguard_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_RATE"].ToString();
                txtSafeguard_SPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL"].ToString();
                txtSafeguard_UNIT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_UNIT"].ToString();                
                string ddlSafeguard_SPL = dtuser.Tables[0].Rows[0]["PRODUCT_SAFEGUARD_SPL_TYPE"].ToString();
                ddlSafeguard_SPL_TYPE.Items.Remove(ddlSafeguard_SPL);

                ddlSafeguard_SPL_TYPE.Items.Insert(0, ddlSafeguard_SPL);
                txtCETH_No.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CETH"].ToString();
                chk = dtuser.Tables[0].Rows[0]["PRODUCT_MRP_YN"].ToString();
                if (chk == "Y")
                {
                    chkMRP_Duty.Checked = true;
                    txtMRP_SL_NO.Enabled = true;
                    txtMRP_AMOUNT.Enabled = true;
                    txtMRP_ABT_RATE.Enabled = true;
                    txtRSP_Notn_No.Enabled = true;
                    txtRSP_Notn_Slno.Enabled = true;
                }
                else
                {
                    chkMRP_Duty.Checked = false;
                    txtMRP_SL_NO.Enabled = false;
                    txtMRP_AMOUNT.Enabled = false;
                    txtMRP_ABT_RATE.Enabled = false;
                    txtRSP_Notn_No.Enabled = false;
                    txtRSP_Notn_Slno.Enabled = false;
                }
                //chkMRP_Duty=   PRODUCT_MRP_YN

                txtMRP_SL_NO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_MRP_SL_NO"].ToString();
                txtMRP_AMOUNT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_MRP_AMOUNT"].ToString();
                txtMRP_ABT_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_MRP_ABT_RATE"].ToString();
                txtRSP_Notn_No.Text = dtuser.Tables[0].Rows[0]["PRODUCT_MRP_ABT_RATE"].ToString();
                txtRSP_Notn_Slno.Text = dtuser.Tables[0].Rows[0]["PRODUCT_MRP_ABT_RATE"].ToString();
                txt_CVD_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CVD_NOTN"].ToString();
                txt_CVD_SLNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CVD_SLNO"].ToString();
                txt_CVD_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CVD_RATE"].ToString();
                txt_CVD_SPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CVD_SPL"].ToString();
                txt_CVD_UNIT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CVD_UNIT"].ToString();

                string ddlCVD_SPL = dtuser.Tables[0].Rows[0]["PRODUCT_CVD_SPL_TYPE"].ToString();
                ddlCVD_SPL_TYPE.Items.Remove(ddlCVD_SPL);

                ddlCVD_SPL_TYPE.Items.Insert(0, ddlCVD_SPL);   

                txt_CVD_Education_CESS_Rate.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CVD_EDU_CESS_RATE"].ToString();
                txt_CVD_Sec_Edu_CESS_Rate.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CVD_SEC_EDU_CESS_RATE"].ToString();
                txt_Addl5_SIA_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN"].ToString();
                txt_Addl5_SIA_NOTN_SL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_NOTN_SL"].ToString();
                txt_Addl5_SIA_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL5_SIA_RATE"].ToString();

                txt_Addl_GSI_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_NOTN"].ToString();
                txt_Addl_GSI_SL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SLNO"].ToString();
                txt_Addl_GSI_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_RATE"].ToString();
                txt_Addl_GSI_SPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL"].ToString();
                txt_Addl_GSI_UNIT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_UNIT"].ToString();               
                string ddl_Addl_GSI_SPL = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_GSI_SPL_TYPE"].ToString();
                ddl_Addl_GSI_SPL_TYPE.Items.Remove(ddl_Addl_GSI_SPL);

                ddl_Addl_GSI_SPL_TYPE.Items.Insert(0, ddl_Addl_GSI_SPL);
                txt_Addl_SHE11_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_NOTN"].ToString();
                txt_Addl_SHE11_SLNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SLNO"].ToString();
                txt_Addl_SHE11_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_RATE"].ToString();
                txt_Addl_SHE11_SPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_SPL"].ToString();
                txt_Addl_SHE11_UNIT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_UNIT"].ToString();              
                string ddl_Addl_SHE11 = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_SHEII_TYPE"].ToString();
                ddl_Addl_SHE11_Type.Items.Remove(ddl_Addl_SHE11);

                ddl_Addl_SHE11_Type.Items.Insert(0, ddl_Addl_SHE11);
                txt_Addl_TTA_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_NOTN"].ToString();
                txt_Addl_TTA_SLNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SLNO"].ToString();
                txt_Addl_TTA_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_RATE"].ToString();
                txt_Addl_TTA_SPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_SPL"].ToString();
                txt_Addl_TTA_UNIT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_UNIT"].ToString();              
                string ddl_Addl_TTA = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_TTA_TYPE"].ToString();
                ddl_Addl_TTA_Type.Items.Remove(ddl_Addl_TTA);

                ddl_Addl_TTA_Type.Items.Insert(0, ddl_Addl_TTA);

                txt_Addl_Health_CESS_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_NOTN"].ToString();
                txt_Addl_Health_CESS_SLNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SLNO"].ToString();
                txt_Addl_Health_CESS_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_RATE"].ToString();
                txt_Addl_Health_CESS_SPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_SPL"].ToString();
                txt_Addl_Health_CESS_UNIT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_UNIT"].ToString();                
                string ddl_Addl_Health_CESS = dtuser.Tables[0].Rows[0]["PRODUCT_ADDL_HEALTH_CESS_TYPE"].ToString();
                ddl_Addl_Health_CESS_Type.Items.Remove(ddl_Addl_Health_CESS);

                ddl_Addl_Health_CESS_Type.Items.Insert(0, ddl_Addl_Health_CESS);

                txt_CESS_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CESS_NOTN"].ToString();
                txt_CESS_SLNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CESS_SLNO"].ToString();
                txt_CESS_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CESS_RATE"].ToString();
                txt_CESS_SPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CESS_SPL"].ToString();
                txt_CESS_UNIT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CESS_UNIT"].ToString();             
                string ddl_CESS = dtuser.Tables[0].Rows[0]["PRODUCT_CESS_TYPE"].ToString();
                ddl_CESS_Type.Items.Remove(ddl_CESS);
                ddl_CESS_Type.Items.Insert(0, ddl_CESS);

                //---------------------07/08/2024/ kavi & Ajith -----------
                txtOther_Duty_Notn.Text = dtuser.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_NOTN"].ToString();
                txtOther_Duty_SLNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_SLNO"].ToString();
                txtOther_Duty_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_RATE"].ToString();
                txtOther_Duty_SPL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_SPL"].ToString();
                txtOther_Duty_UNIT.Text = dtuser.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_UNIT"].ToString();
                string ddlOther_Duty = dtuser.Tables[0].Rows[0]["PRODUCT_OTHER_DUTY_TYPE"].ToString();
                ddlOther_Duty_Type.Items.Remove(ddlOther_Duty);
                ddlOther_Duty_Type.Items.Insert(0, ddlOther_Duty);
                //---------------------07/08/2024/-----------
               
                txtSAPTA_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SAPTA_NOTN"].ToString();
                txtSAPTA_NOTN_SL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SAPTA_SLNO"].ToString();
                txtSAPTA_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_SAPTA_RATE"].ToString();
                txtTariff_NOTN.Text = dtuser.Tables[0].Rows[0]["PRODUCT_TARIFF_NOTN"].ToString();
                txtTariff_SL.Text = dtuser.Tables[0].Rows[0]["PRODUCT_TARIFF_SLNO"].ToString();
                txtTariff_Qty.Text = dtuser.Tables[0].Rows[0]["PRODUCT_TARIFF_QTY"].ToString();
                txtTariff_Amount.Text = dtuser.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT"].ToString();
                txtTariff_Amount_unitCode.Text = dtuser.Tables[0].Rows[0]["PRODUCT_TARIFF_AMOUNT_UNIT"].ToString();
                txtRSP_Notn_No.Text = dtuser.Tables[0].Rows[0]["PRODUCT_RSP_NOTN_NO"].ToString();
                txtRSP_Notn_Slno.Text = dtuser.Tables[0].Rows[0]["PRODUCT_RSP_NOTN_SL_NO"].ToString();
            
                txtGenericDesc.Text = dtuser.Tables[0].Rows[0]["PRODUCT_GENERAL_DESC"].ToString();
                txtManufacturer.Text = dtuser.Tables[0].Rows[0]["PRODUCT_MANUFACTURER"].ToString();
                txtBrand.Text = dtuser.Tables[0].Rows[0]["PRODUCT_BRAND"].ToString();
                txtModel.Text = dtuser.Tables[0].Rows[0]["PRODUCT_MODEL"].ToString();
                txtEndUse.Text = dtuser.Tables[0].Rows[0]["PRODUCT_END_USE"].ToString();
                txtCountryName.Text = dtuser.Tables[0].Rows[0]["PRODUCT_COUNTRY_ORIGIN"].ToString();
                txtAccessories.Text = dtuser.Tables[0].Rows[0]["PRODUCT_ACCESSORIES"].ToString();
                txtRemarks.Text = dtuser.Tables[0].Rows[0]["PRODUCT_REMARKS"].ToString();

                hdn_Update_Product.Value = txtDescription.Text;       
                txtinfra_cess_Notn.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CTH_INFRA_CESS_NOTN"].ToString();
                txtinfra_cess_Notn_SLNO.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CTH_INFRA_CESS_NOTN_SLNO"].ToString();
                txtinfra_cess_Notn_RATE.Text = dtuser.Tables[0].Rows[0]["PRODUCT_CTH_INFRA_CESS_RATE"].ToString();

                txt_Cus_not_exe_Cen_flag.Text = dtuser.Tables[0].Rows[0]["CENTRAL_EXCISE_FLAG"].ToString();
                txt_Manufacturer_producer.Text = dtuser.Tables[0].Rows[0]["MANUFACTURER_PRODUCER"].ToString();
                txt_Manu_produ_grower_code.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_CODE"].ToString();
                txt_Manufacturer_Add1.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_ADD1"].ToString();
                txt_Manufacturer_Add2.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_ADD2"].ToString();
                txt_Manufacturer_City.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_CITY"].ToString();
                txt_Manu_Country_Subdiv.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_COUNTRY_SUBDIV"].ToString();
                txt_Manufacturer_pincode.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_PIN"].ToString();
                txt_Manufacturer_Country.Text = dtuser.Tables[0].Rows[0]["M_P_GROWER_COUNTRY"].ToString();
                txt_Manu_Source_Country.Text = dtuser.Tables[0].Rows[0]["SOURCE_COUNTRY"].ToString();
                txt_manu_Transit_Country.Text = dtuser.Tables[0].Rows[0]["TRANSIT_COUNTRY"].ToString();
                ddl_Accesory_status.SelectedValue = dtuser.Tables[0].Rows[0]["ACCESSORY_STATUS"].ToString();

                txt_IGST_LEVY_NOTN.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_NOTN"].ToString();
                txt_IGST_LEVY_SLNO.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_SLNO"].ToString();
                txt_IGST_LEVY_RATE.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_RATE"].ToString();
                txt_IGST_LEVY_SPL_Amt.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_SPL"].ToString();
                txt_IGST_LEVY_UNIT.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_UNIT"].ToString();
                
                txt_IGST_LEVY_EXCEPTION_NOTN.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_NOTN"].ToString();
                txt_IGST_LEVY_EXCEPTION_SLNO.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_SLNO"].ToString();
                txt_IGST_LEVY_EXCEPTION_RATE.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_RATE"].ToString();
                txt_IGST_LEVY_COMPENSATION_CESS_NOTN.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_NOTN"].ToString();
                txt_IGST_LEVY_COMPENSATION_CESS_SLNO.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SLNO"].ToString();
                txt_IGST_LEVY_COMPENSATION_CESS_RATE.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_RATE"].ToString();
                txt_IGST_LEVY_COMPENSATION_CESS_SPL.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_SPL"].ToString();
                txt_IGST_LEVY_COMPENSATION_CESS_UNIT.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_COMPENSATION_CESS_UNIT"].ToString();               
                txt_IGST_LEVY_EXCEPTION_CC_NOTN.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_CC_NOTN"].ToString();
                txt_IGST_LEVY_EXCEPTION_CC_SLNO.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_CC_SLNO"].ToString();
                txt_IGST_LEVY_EXCEPTION_CC_RATE.Text = dtuser.Tables[0].Rows[0]["IGST_LEVY_EXCEPTION_CC_RATE"].ToString();
                ddl_LEVY_EXCEMPTION_NOTN_TYPE.SelectedValue = dtuser.Tables[0].Rows[0]["LEVY_EXCEMPTION_NOTN_TYPE"].ToString();
                ddl_LEVY_EXCEPTION_CC_NOTN_TYPE.SelectedValue = dtuser.Tables[0].Rows[0]["LEVY_EXCEPTION_CC_NOTN_TYPE"].ToString();

                txt_Social_Welfare_NOTN.Text = dtuser.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN"].ToString();
                txt_Social_Welfare_NOTN_SL.Text = dtuser.Tables[0].Rows[0]["SOCIAL_WELFARE_NOTN_SLNO"].ToString();
                txt_Social_Welfare_Rate.Text = dtuser.Tables[0].Rows[0]["SOCIAL_WELFARE_RATE"].ToString();

                txt_AIDC_NOTN.Text = dtuser.Tables[0].Rows[0]["AIDC_NOTN"].ToString();
                txt_AIDC_NOTN_SLNO.Text = dtuser.Tables[0].Rows[0]["AIDC_NOTN_SLNO"].ToString();
                txt_AIDC_RATE.Text = dtuser.Tables[0].Rows[0]["AIDC_RATE"].ToString();


                txt_AntiDumping_Notn.Text = dtuser.Tables[0].Rows[0]["ANTI_DUMPING_NOTN"].ToString();
                txt_AntiDumping_Notn_SL.Text = dtuser.Tables[0].Rows[0]["ANTI_DUMPING_NOTN_SLNO"].ToString();
                txtCTH_SL_No.Text = dtuser.Tables[0].Rows[0]["CTH_SLNO"].ToString();
                txtCTH_Supplier_SL.Text = dtuser.Tables[0].Rows[0]["CTH_SUPPLIER_SLNO"].ToString();
                txtCTH_Qty.Text = dtuser.Tables[0].Rows[0]["CTH_QTY"].ToString();            

                txtImporterName.Text = dtuser.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txtBranchNo.Text = dtuser.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                txtIECNo.Text = dtuser.Tables[0].Rows[0]["IEC_NO"].ToString();
                txtCommon_Part_No.Text = dtuser.Tables[0].Rows[0]["PART_NO"].ToString();
                txt_ADCode.Text = dtuser.Tables[0].Rows[0]["ADCODE"].ToString();
                
                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["ID"].ToString();
                //FOR UPDATED SUCCESSFULLY


            }
            HiddenField1.Value = Request.QueryString["ID"].ToString();
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
            btnNew.Visible = true;


           
            {
                PartName.Visible = false;
                TaxBenifitYN.Visible = false;
                TaxBenifitPerc.Visible = false;
                EPANotifi.Visible = false;
                SIMAYN.Visible = false;
                FTAYN.Visible = false;
                CEFAImplDate.Visible = false;
            }

        }
        else
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
        }
    }

    public int insert_update(string a1, string a2, string a3, string a4)
    {
        
        erm.ID = a1;
        erm.PRODUCT_DESCRIPTION = txtDescription.Text;        
        erm.PRODUCT_RITC = txtRITCNO.Text;
        erm.PRODUCT_CTH = txtCTHNO.Text;
        erm.PRODUCT_BCD_NOTN = txtBasicNotn.Text;
        erm.PRODUCT_BCD_SLNO = txtBasicSLNO.Text;
        erm.PRODUCT_BCD_RATE = txtBasicRate.Text;
        erm.PRODUCT_BCD_SPL = txtBasicSPL.Text;
        erm.PRODUCT_BCD_UNIT = txtBasicUnit.Text;
        erm.PRODUCT_BCD_SPL_TYPE = ddlBasicSPLTYPE.SelectedValue.ToString();
        erm.PRODUCT_ADDL_DUTY_NOTN = txtAddlDuty_NOTN.Text;
        erm.PRODUCT_ADDL_DUTY_NOTN_SL = txtAddlDuty_NOTN_SL.Text;
        erm.PRODUCT_EDU_CESS_NOTN = txtEdu_Cess_NOTN.Text;
        erm.PRODUCT_EDU_CESS_NOTN_SL = txtEdu_Cess_NOTN_SL.Text;
        erm.PRODUCT_EDU_CESS_RATE = txtEdu_Cess_Rate.Text;
        erm.PRODUCT_SEC_EDU_CESS_NOTN = txtSec_Edu_Cess_NOTN.Text;
        erm.PRODUCT_SEC_EDU_CESS_NOTN_SL = txtSec_Edu_Cess_NOTN_SL.Text;
        erm.PRODUCT_SEC_EDU_CESS_RATE = txtSec_Edu_Cess_Rate.Text;
        

        erm.PRODUCT_NCD_NOTN = "";
        erm.PRODUCT_NCD_SLNO = "";
        erm.PRODUCT_NCD_RATE = "";
        erm.PRODUCT_NCD_SPL = "";
        erm.PRODUCT_NCD_UNIT = "";
        erm.PRODUCT_NCD_SPL_TYPE = "";

        erm.PRODUCT_AGGREGATE_DUTY_NOTN = txtAggregate_NOTN.Text;
        erm.PRODUCT_AGGREGATE_DUTY_NOTN_SL = txtAggregate_NOTN_SL.Text;
        erm.PRODUCT_AGGREGATE_DUTY_NOTN_RATE = txtAggregate_RATE.Text;
        erm.PRODUCT_SAFEGUARD_NOTN = txtSafeguard_NOTN.Text;
        erm.PRODUCT_SAFEGUARD_SLNO = txtSafeguard_SL.Text;
        erm.PRODUCT_SAFEGUARD_RATE = txtSafeguard_RATE.Text;
        erm.PRODUCT_SAFEGUARD_SPL = txtSafeguard_SPL.Text;
        erm.PRODUCT_SAFEGUARD_UNIT = txtSafeguard_UNIT.Text;
        erm.PRODUCT_SAFEGUARD_SPL_TYPE = ddlSafeguard_SPL_TYPE.SelectedValue.ToString();
        erm.PRODUCT_CETH = txtCETH_No.Text;
        erm.PRODUCT_MRP_YN = a4;
        erm.PRODUCT_MRP_SL_NO = txtMRP_SL_NO.Text;
        erm.PRODUCT_MRP_AMOUNT = txtMRP_AMOUNT.Text;
        erm.PRODUCT_MRP_ABT_RATE = txtMRP_ABT_RATE.Text;
        erm.PRODUCT_CVD_NOTN = txt_CVD_NOTN.Text;
        erm.PRODUCT_CVD_SLNO = txt_CVD_SLNO.Text;
        erm.PRODUCT_CVD_RATE = txt_CVD_RATE.Text;
        erm.PRODUCT_CVD_SPL = txt_CVD_SPL.Text;
        erm.PRODUCT_CVD_UNIT = txt_CVD_UNIT.Text;
        erm.PRODUCT_CVD_SPL_TYPE = ddlCVD_SPL_TYPE.SelectedValue.ToString();
        erm.PRODUCT_CVD_EDU_CESS_RATE = txt_CVD_Education_CESS_Rate.Text;
        erm.PRODUCT_CVD_SEC_EDU_CESS_RATE = txt_CVD_Sec_Edu_CESS_Rate.Text;
        erm.PRODUCT_ADDL5_SIA_NOTN = txt_Addl5_SIA_NOTN.Text;
        erm.PRODUCT_ADDL5_SIA_NOTN_SL = txt_Addl5_SIA_NOTN_SL.Text;
        erm.PRODUCT_ADDL5_SIA_RATE = txt_Addl5_SIA_RATE.Text;
        erm.PRODUCT_ADDL_GSI_NOTN = txt_Addl_GSI_NOTN.Text;
        erm.PRODUCT_ADDL_GSI_SLNO = txt_Addl_GSI_SL.Text;
        erm.PRODUCT_ADDL_GSI_RATE = txt_Addl_GSI_RATE.Text;
        erm.PRODUCT_ADDL_GSI_SPL = txt_Addl_GSI_SPL.Text;
        erm.PRODUCT_ADDL_GSI_UNIT = txt_Addl_GSI_UNIT.Text;
        erm.PRODUCT_ADDL_GSI_SPL_TYPE = ddl_Addl_GSI_SPL_TYPE.SelectedValue.ToString();
        erm.PRODUCT_ADDL_SHEII_NOTN = txt_Addl_SHE11_NOTN.Text;
        erm.PRODUCT_ADDL_SHEII_SLNO = txt_Addl_SHE11_SLNO.Text;
        erm.PRODUCT_ADDL_SHEII_RATE = txt_Addl_SHE11_RATE.Text;
        erm.PRODUCT_ADDL_SHEII_SPL = txt_Addl_SHE11_SPL.Text;
        erm.PRODUCT_ADDL_SHEII_UNIT = txt_Addl_SHE11_UNIT.Text;
        erm.PRODUCT_ADDL_SHEII_TYPE = ddl_Addl_SHE11_Type.Text;
        erm.PRODUCT_ADDL_TTA_NOTN = txt_Addl_TTA_NOTN.Text;
        erm.PRODUCT_ADDL_TTA_SLNO = txt_Addl_TTA_SLNO.Text;
        erm.PRODUCT_ADDL_TTA_RATE = txt_Addl_TTA_RATE.Text;
        erm.PRODUCT_ADDL_TTA_SPL = txt_Addl_TTA_SPL.Text;
        erm.PRODUCT_ADDL_TTA_UNIT = txt_Addl_TTA_UNIT.Text;
        erm.PRODUCT_ADDL_TTA_TYPE = ddl_Addl_TTA_Type.SelectedValue.ToString();
        erm.PRODUCT_ADDL_HEALTH_CESS_NOTN = txt_Addl_Health_CESS_NOTN.Text;
        erm.PRODUCT_ADDL_HEALTH_CESS_SLNO = txt_Addl_Health_CESS_SLNO.Text;
        erm.PRODUCT_ADDL_HEALTH_CESS_RATE = txt_Addl_Health_CESS_RATE.Text;
        erm.PRODUCT_ADDL_HEALTH_CESS_SPL = txt_Addl_Health_CESS_SPL.Text;
        erm.PRODUCT_ADDL_HEALTH_CESS_UNIT = txt_Addl_Health_CESS_UNIT.Text;
        erm.PRODUCT_ADDL_HEALTH_CESS_TYPE = ddl_Addl_Health_CESS_Type.SelectedValue.ToString();
        erm.PRODUCT_CESS_NOTN = txt_CESS_NOTN.Text;
        erm.PRODUCT_CESS_SLNO = txt_CESS_SLNO.Text;
        erm.PRODUCT_CESS_RATE = txt_CESS_RATE.Text;
        erm.PRODUCT_CESS_SPL = txt_CESS_SPL.Text;
        erm.PRODUCT_CESS_UNIT = txt_CESS_UNIT.Text;
        erm.PRODUCT_CESS_TYPE = ddl_CESS_Type.SelectedValue.ToString();

        erm.PRODUCT_OTHER_DUTY_NOTN = txtOther_Duty_Notn.Text;
        erm.PRODUCT_OTHER_DUTY_SLNO = txtOther_Duty_SLNO.Text;
        erm.PRODUCT_OTHER_DUTY_RATE = txtOther_Duty_RATE.Text;
        erm.PRODUCT_OTHER_DUTY_SPL = txtOther_Duty_SPL.Text;
        erm.PRODUCT_OTHER_DUTY_UNIT = txtOther_Duty_UNIT.Text;
        erm.PRODUCT_OTHER_DUTY_TYPE = ddlOther_Duty_Type.SelectedValue.ToString();

       
        erm.PRODUCT_GENERAL_DESC = txtGenericDesc.Text;
        erm.PRODUCT_MANUFACTURER = txtManufacturer.Text;
        erm.PRODUCT_BRAND = txtBrand.Text;
        erm.PRODUCT_MODEL = txtModel.Text;
        erm.PRODUCT_END_USE = txtEndUse.Text;
        erm.PRODUCT_COUNTRY_ORIGIN = txtCountryName.Text;
        erm.PRODUCT_ACCESSORIES = txtAccessories.Text;
        erm.PRODUCT_REMARKS = txtRemarks.Text;
        erm.PRODUCT_SAPTA_NOTN = txtSAPTA_NOTN.Text;
        erm.PRODUCT_SAPTA_SLNO = txtSAPTA_NOTN_SL.Text;
        erm.PRODUCT_SAPTA_RATE = txtSAPTA_RATE.Text;
        erm.PRODUCT_TARIFF_NOTN = txtTariff_NOTN.Text;
        erm.PRODUCT_TARIFF_SLNO = txtTariff_SL.Text;
        erm.PRODUCT_TARIFF_QTY = txtTariff_Qty.Text;
        erm.PRODUCT_TARIFF_AMOUNT = txtTariff_Amount.Text;
        erm.PRODUCT_TARIFF_AMOUNT_UNIT = txtTariff_Amount_unitCode.Text;
        erm.RSP_NOTN_NO = txtRSP_Notn_No.Text;
        erm.RSP_NOTN_SL_NO = txtRSP_Notn_Slno.Text;
        erm.USER_ID = Connection.Current_User();
        erm.BRANCH_CODE = Connection.Current_Branch();
        erm.flag = a2;
        erm.YEAR = a3;
        erm.EWorking_Period = Connection.WorkingPeriod();            
        erm.PRODUCT_CTH_INFRA_CESS_NOTN = txtinfra_cess_Notn.Text;
        erm.PRODUCT_CTH_INFRA_CESS_NOTN_SLNO = txtinfra_cess_Notn_SLNO.Text;
        erm.PRODUCT_CTH_INFRA_CESS_RATE = txtinfra_cess_Notn_RATE.Text;
        erm.PRODUCT_ADDL_DUTY_RATE = txtAddlDuty_Rate.Text;
        erm.CENTRAL_EXCISE_FLAG = txt_Cus_not_exe_Cen_flag.Text;
        erm.MANUFACTURER_PRODUCER = txt_Manufacturer_producer.Text;
        erm.M_P_GROWER_CODE = txt_Manu_produ_grower_code.Text;
        erm.M_P_GROWER_ADD1 = txt_Manufacturer_Add1.Text;
        erm.M_P_GROWER_ADD2 = txt_Manufacturer_Add2.Text;
        erm.M_P_GROWER_CITY = txt_Manufacturer_City.Text;
        erm.M_P_GROWER_COUNTRY_SUBDIV = txt_Manu_Country_Subdiv.Text;
        erm.M_P_GROWER_PIN = txt_Manufacturer_pincode.Text;
        erm.M_P_GROWER_COUNTRY = txt_Manufacturer_Country.Text;
        erm.SOURCE_COUNTRY = txt_Manu_Source_Country.Text;
        erm.TRANSIT_COUNTRY = txt_manu_Transit_Country.Text;
        erm.ACCESSORY_STATUS = ddl_Accesory_status.SelectedValue;

        erm.IGST_LEVY_NOTN = txt_IGST_LEVY_NOTN.Text;
        erm.IGST_LEVY_SLNO = txt_IGST_LEVY_SLNO.Text;
        erm.IGST_LEVY_RATE = txt_IGST_LEVY_RATE.Text;
        erm.IGST_LEVY_SPL = txt_IGST_LEVY_SPL_Amt.Text;
        erm.IGST_LEVY_UNIT = txt_IGST_LEVY_UNIT.Text;
        
        erm.IGST_LEVY_EXCEPTION_NOTN = txt_IGST_LEVY_EXCEPTION_NOTN.Text;
        erm.IGST_LEVY_EXCEPTION_SLNO = txt_IGST_LEVY_EXCEPTION_SLNO.Text;
        erm.IGST_LEVY_EXCEPTION_RATE = txt_IGST_LEVY_EXCEPTION_RATE.Text;
        erm.IGST_LEVY_COMPENSATION_CESS_NOTN = txt_IGST_LEVY_COMPENSATION_CESS_NOTN.Text;
        erm.IGST_LEVY_COMPENSATION_CESS_SLNO = txt_IGST_LEVY_COMPENSATION_CESS_SLNO.Text;
        erm.IGST_LEVY_COMPENSATION_CESS_RATE = txt_IGST_LEVY_COMPENSATION_CESS_RATE.Text;
        erm.IGST_LEVY_COMPENSATION_CESS_SPL = txt_IGST_LEVY_COMPENSATION_CESS_SPL.Text;
        erm.IGST_LEVY_COMPENSATION_CESS_UNIT = txt_IGST_LEVY_COMPENSATION_CESS_UNIT.Text;
       
        erm.IGST_LEVY_EXCEPTION_CC_NOTN = txt_IGST_LEVY_EXCEPTION_CC_NOTN.Text;
        erm.IGST_LEVY_EXCEPTION_CC_SLNO = txt_IGST_LEVY_EXCEPTION_CC_SLNO.Text;
        erm.IGST_LEVY_EXCEPTION_CC_RATE = txt_IGST_LEVY_EXCEPTION_CC_RATE.Text;

        erm.LEVY_EXCEMPTION_NOTN_TYPE =ddl_LEVY_EXCEMPTION_NOTN_TYPE.SelectedValue;
        erm.LEVY_EXCEPTION_CC_NOTN_TYPE = ddl_LEVY_EXCEPTION_CC_NOTN_TYPE.SelectedValue;

        erm.SOCIAL_WELFARE_NOTN = txt_Social_Welfare_NOTN.Text;
        erm.SOCIAL_WELFARE_NOTN_SLNO = txt_Social_Welfare_NOTN_SL.Text;
        erm.SOCIAL_WELFARE_RATE = txt_Social_Welfare_Rate.Text;


        erm.AIDC_NOTN = txt_AIDC_NOTN.Text;
        erm.AIDC_NOTN_SLNO = txt_AIDC_NOTN_SLNO.Text;
        erm.AIDC_RATE = txt_AIDC_RATE.Text;

        erm.ANTI_DUMPING_NOTN = txt_AntiDumping_Notn.Text;
        erm.ANTI_DUMPING_NOTN_SLNO = txt_AntiDumping_Notn_SL.Text;
        erm.CTH_SLNO = txtCTH_SL_No.Text;
        erm.CTH_SUPPLIER_SLNO = txtCTH_Supplier_SL.Text;            

        erm.IMPORTER_NAME = txtImporterName.Text;
        erm.IEC_NO = txtIECNo.Text;
        erm.BRANCH_NO = txtBranchNo.Text;
        erm.PART_NO = txtCommon_Part_No.Text;
        erm.ADCODE = txt_ADCode.Text;     

        i = erm.Import_Product_Caterpillar_Master_Insert_update();
        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtDescription.Text != "" &&  txtRITCNO.Text != "" && txtCTHNO.Text != "" && txtCETH_No.Text != "" )
        {
            try
            {
                string chk;
                if (chkMRP_Duty.Checked == true)
                {
                    chk = "Y";
                    txtMRP_SL_NO.Enabled = true;
                    txtMRP_AMOUNT.Enabled = true;
                    txtMRP_ABT_RATE.Enabled = true;
                }
                else
                {
                    chk = "N";
                    txtMRP_SL_NO.Enabled = false;
                    txtMRP_AMOUNT.Enabled = false;
                    txtMRP_ABT_RATE.Enabled = false;
                }

                string a1 = "";
                string a2 = "S";
                string a3 = "";
                i = insert_update(a1, a2, a3, chk);
                HiddenField1.Value = Convert.ToString(erm.UPDATE_ID);
              
                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                    PAGE_MODIFY = user_Create.PAGE_MODIFY;


                    //---------------SAVE ONLY------------------//

                    if (PAGE_MODIFY == "False")
                    {
                        btnNew_Click(sender, e);

                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSave.Focus();
                        hdn_Update_Product.Value = txtDescription.Text;
                       
                    }
                    //-----------------------FOR USER RIGHTS--------------------------------//
                
                    ViewState["UPDATED_ID"] = null;
                    Alert_msg("Saved Successfully", "btnSave");
                }
                else if (i == 2)
                {
                    Alert_msg("Product already exixts!", "btnSave");
                }

                else
                {
                    Alert_msg("Product Not Saved", "btnNew");               
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
            erm.Eproduct_imp_id = HiddenField1.Value;
            erm.Eproduct_imp_cth = "0";
            erm.Eproduct_imp_ceth = "0";
            erm.Eproduct_imp_ritc = "0";    
            erm.Eproduct_imp_description = "0";

            erm.EWorking_Period = Connection.WorkingPeriod();

            erm.Ename = "delete";


            erm.RetrieveAll_Import_Caterpillar_MASTER();
            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {

                ViewState["UPDATED_ID"] = null;

                string prompt = "<script>$(document).ready(function(){{jAlert('Product Deleted', 'IMPORT CATERPILLAR MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

            }


            else
            {
                Alert_msg("Product Not Deleted");
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
            string chk;
            if (chkMRP_Duty.Checked == true)
            {
                chk = "Y";
            }
            else
            {
                chk = "N";
            }

            string a1 = HiddenField1.Value;
            string a2 = "U";
            string a3 = "";
            i = insert_update(a1, a2, a3, chk);
            if (i == 1)
            {
                hdn_Update_Product.Value = txtDescription.Text;


                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                }
            }
            else if (i == 2)
            {
                Alert_msg("Product already exixts!", "btnUpdate");
            }
            else
            {
                Alert_msg("Product Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Manipulation mo = new Manipulation();
        mo.ResetFields(Page.Controls);
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        hdn_Update_Product.Value = "";
        ViewState["UPDATED_ID"] = null;

    }

    public void hiddenval()
    {
        if (HiddenField2.Value != "")
        {
            string a = HiddenField2.Value;
            if (a == "1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clientscript", "<script language='javascript'>Tab('1');</script>", false);
            }
            else if (a == "2")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clientscript", "<script language='javascript'>Tab('2');</script>", false);
            }
            else if (a == "3")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clientscript", "<script language='javascript'>Tab('3');</script>", false);
            }
        }
    }


    protected void txtDescription_TextChanged(object sender, EventArgs e)
    {
        if (hdn_Update_Product.Value != txtDescription.Text)
        {

            try
            {
                erm.Eproduct_imp_id = "0";
                erm.Eproduct_imp_cth = "0";
                erm.Eproduct_imp_ceth = "0";
                erm.Eproduct_imp_ritc = "0";      
                erm.Eproduct_imp_description = txtDescription.Text;

                erm.EWorking_Period = Connection.WorkingPeriod();

                erm.Ename = "Check_Product";

                dtuser = erm.RetrieveAll_Product_import_MASTER();
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    Alert_msg("Product already exists!", "txtMaterialCode");                  
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'IMPORT CATERPILLAR MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'IMPORT CATERPILLAR MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Call_Server_Side_Method()
    {

        //txtBranchNo.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txtImporterName.ClientID + "', '" + txtBranchNo.ClientID + "')");
       // txtImporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txtImporterName.ClientID + "')");
        txtImporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txtImporterName.ClientID + "' ,'" + txtBranchNo.ClientID + "' , ,'" + txt_ADCode.ClientID + "')");
        //infra_cess
        txtinfra_cess_Notn_SLNO.Attributes.Add("onblur", "javascript:CallServerside_infra_cess_Notn_SLNO('" + txtinfra_cess_Notn_SLNO.ClientID + "', '" + txtinfra_cess_Notn.ClientID + "')");
        //infra_cess
       
        txtCTHNO.Attributes.Add("onblur", "javascript:Call_CTH_Rate('" + txtCTHNO.ClientID + "', '" + txtBasicSLNO.ClientID + "')");
        txtCETH_No.Attributes.Add("onblur", "javascript:Call_CETH_Rate('" + txtCETH_No.ClientID + "', '" + txtBasicSLNO.ClientID + "')"); 

        //--------------------------------------------------NOTN-----------------------------------------------------------------------------------------------------
        //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------
        //BASIC_DUTY_CTH
        txtBasicSLNO.Attributes.Add("onBlur", "javascript:CallServerside_Basic_Duty_Cth_Notn_Slno('" + txtBasicSLNO.ClientID + "', '" + txtBasicNotn.ClientID + "')");

        //BASIC_DUTY_CTH

        //ADD_DUTY_CTH
        txtAddlDuty_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Cth_Notn_Slno('" + txtAddlDuty_NOTN_SL.ClientID + "', '" + txtAddlDuty_NOTN.ClientID + "')");
        //ADD_DUTY_CTH

        //Edu_Cess_Cth
        txtEdu_Cess_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Edu_Cess_Cth_Notn_Slno('" + txtEdu_Cess_NOTN_SL.ClientID + "', '" + txtEdu_Cess_NOTN.ClientID + "')");
        //Edu_Cess_Cth

        //Sec_Higher_Edu_Cth
        txtSec_Edu_Cess_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Sec_Higher_Edu_Cth_Notn_Slno('" + txtSec_Edu_Cess_NOTN_SL.ClientID + "', '" + txtSec_Edu_Cess_NOTN.ClientID + "')");
        //Sec_Higher_Edu_Cth  

        //NCD_Cth
        txtNCD_SLNO.Attributes.Add("onblur", "javascript:CallServerside_NCD_Cth_Notn_Slno('" + txtNCD_SLNO.ClientID + "', '" + txtNCD_NOTN.ClientID + "')");
        //NCD_Cth

        //Aggregate_Duty_Cth
        txtAggregate_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Aggregate_Duty_Cth_Notn_Slno('" + txtAggregate_NOTN_SL.ClientID + "', '" + txtAggregate_NOTN.ClientID + "')");
        //Aggregate_Duty_Cth

        //SafeGuard_Duty_Cth
        txtSafeguard_SL.Attributes.Add("onblur", "javascript:CallServerside_SafeGuard_Duty_Cth_Notn_Slno('" + txtSafeguard_SL.ClientID + "', '" + txtSafeguard_NOTN.ClientID + "')");
        //SafeGuard_Duty_Cth
        txtSAPTA_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_SAPTA_NOTN_Cth_Notn_Slno('" + txtSAPTA_NOTN_SL.ClientID + "', '" + txtSAPTA_NOTN.ClientID + "')");
        //SAPTA_NOTN_Cth
            
        //CVD_CETH
        txt_CVD_SLNO.Attributes.Add("onblur", "javascript:CallServerside_CVD_Duty_Ceth_Notn_SlNo('" + txt_CVD_SLNO.ClientID + "', '" + txt_CVD_NOTN.ClientID + "')");
        //CVD_CETH

        //Addl_CETH
        txt_Addl5_SIA_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Ceth_Notn_SlNo('" + txt_Addl5_SIA_NOTN_SL.ClientID + "', '" + txt_Addl5_SIA_NOTN.ClientID + "')");
        //Addl_CETH

        //Addl_GSI_CETH
        txt_Addl_GSI_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_GSI_Ceth_Notn_SlNo('" + txt_Addl_GSI_SL.ClientID + "', '" + txt_Addl_GSI_NOTN.ClientID + "')");
        //Addl_GSI_CETH

        //Addl_SHE11_NOTN
        txt_Addl_SHE11_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Spl_Excise_Duty_Ceth_Notn_SlNo('" + txt_Addl_SHE11_SLNO.ClientID + "', '" + txt_Addl_SHE11_NOTN.ClientID + "')");
        //Addl_SHE11_NOTN

        //Addl_TTA_SLNO
        txt_Addl_TTA_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Excise_TTA_Ceth_Notn_SlNo('" + txt_Addl_TTA_SLNO.ClientID + "', '" + txt_Addl_TTA_NOTN.ClientID + "')");
        //Addl_TTA_SLNO

        //Addl_Health_CESS_SLNO
        txt_Addl_Health_CESS_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Health_Cess_Ceth_Notn_SlNo('" + txt_Addl_Health_CESS_SLNO.ClientID + "', '" + txt_Addl_Health_CESS_NOTN.ClientID + "')");
        //Addl_Health_CESS_SLNO

        //CESS_SLNO
        txt_CESS_SLNO.Attributes.Add("onblur", "javascript:CallServerside_Cess_Notn_Ceth_Notn_SlNo('" + txt_CESS_SLNO.ClientID + "', '" + txt_CESS_NOTN.ClientID + "')");
        //CESS_SLNO
        //--------------------------------------------------NOTNSL---------------------------------------------------------------------------------------------------

        ///------------------------------------------------CETH-----------------------------------------------------------------


        ///------------------------------------------------auto search-----------------------------------------------------------------

        //ADD_DUTY_CTH
        txtAddlDuty_NOTN_SL.Attributes.Add("onblur", "javascript:CallServerside_Add_Duty_Cth_Notn_Slno('" + txtAddlDuty_NOTN_SL.ClientID + "', '" + txtAddlDuty_NOTN.ClientID + "')");
        //ADD_DUTY_CTH

        //IGST
        txt_IGST_LEVY_SLNO.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_SLNO('" + txt_IGST_LEVY_SLNO.ClientID + "', '" + txt_IGST_LEVY_NOTN.ClientID + "')");
        txt_IGST_LEVY_EXCEPTION_SLNO.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_EXCEPTION_SLNO('" + txt_IGST_LEVY_EXCEPTION_SLNO.ClientID + "', '" + txt_IGST_LEVY_EXCEPTION_NOTN.ClientID + "')");
        txt_IGST_LEVY_COMPENSATION_CESS_SLNO.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_COMPENSATION_CESS_SLNO('" + txt_IGST_LEVY_COMPENSATION_CESS_SLNO.ClientID + "', '" + txt_IGST_LEVY_COMPENSATION_CESS_NOTN.ClientID + "')");
        txt_IGST_LEVY_EXCEPTION_CC_SLNO.Attributes.Add("onblur", "javascript:CallServerside_txt_IGST_LEVY_EXCEPTION_CC_SLNO('" + txt_IGST_LEVY_EXCEPTION_CC_SLNO.ClientID + "', '" + txt_IGST_LEVY_EXCEPTION_CC_NOTN.ClientID + "')");

    }
    [System.Web.Services.WebMethod]
    public static string Get_RITC(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "IMP_ITEM_DESC_SEARCH";
        Auto.Enamesearch = custid;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string CTH_NO = ds.Tables[0].Rows[0]["CTH_NO"].ToString();

            custid = CTH_NO;
        }
        else
        {
            custid = "";
        }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_RSPDetails(string custid)
    {

        DataSet ds = new DataSet();
        adminmaster adm = new adminmaster();
        adm.ERSP_cthno = custid;
        adm.startRowIndex = "0";
        adm.maximumRows = "0";

        adm.Ename = "RSP_CTH_NO_SEARCH";

        adm.RetrieveAll_RSP_master();



        string Address1 = adm.ERSP_id;


        custid = Address1;

        return custid;
    }
    
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_NO(string Notn_no, string Notn_no_sl)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "";

        if (Notn_no != "" && Notn_no != "019/2006")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_NO";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                if (Address5 == "-1")
                    Address5 = "";

            }
        }
        Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;

        return Notn_no_sl;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master_CTH_NOTN_SLNO(string Notn_no_sl, string Notn_no)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "";
        if (Notn_no != "" && Notn_no != "019/2006")
        {

            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL_CTH_NOTN_SLNO";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
                Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
                Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();
                if (Address5 == "-1")
                    Address5 = "";

            }
        }
        Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;

        return Notn_no_sl;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_CETH_NOTN_NO(string Notn_no, string Notn_no_sl)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

        if (Notn_no != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_NO";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {


                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                if (Address5 == "-1")
                    Address5 = "";
                Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
                Address8 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
                Address9 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

            }
        }
        Notn_no = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;

        return Notn_no;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_CETH_NOTN_SLNO(string Notn_no_sl, string Notn_no)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

        if (Notn_no != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {


                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                if (Address5 == "-1")
                    Address5 = "";
                Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
                Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
                Address8 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
                Address9 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

            }
        }
        Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;

        return Notn_no_sl;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Custom_Master(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "NOTIFICATIONCUSTOM_MASTER_ALL";
        Auto.Enamesearch = custid;

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_NOTN_SL"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_RATE"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_SPL"].ToString();
            string Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_CUSTOMS_BCD_UNIT"].ToString();

            custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6;
        }

        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "NOTIFICATIONC_EXCISE_MASTER_ALL";
        Auto.Enamesearch = custid;

        ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {


            string Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_NOTN_SL"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
            string Address6 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();
            string Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_RATE"].ToString();
            string Address8 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_SPL"].ToString();
            string Address9 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_CVD_UNIT"].ToString();

            custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
        }

        return custid;
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string Get_RSP_Rate(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        string name = "RSP_MASTER";
        string rows = "RSP_RATE";
        custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
        if (Auto.Ename != "1")
        {
            custid = "";
        }
        return custid;
    }     

    [System.Web.Services.WebMethod]
    public static string Get_CTH_Rate(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        string name = "CTH_MASTER_RATE";
        string rows = "CTH_RATE";
        custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
        if (Auto.Ename != "1")
        {
            custid = "";
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_CETH_Rate(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        string name = "CETH_MASTER_RATE";
        string rows = "CETH_RATE";
        custid = Auto.Country_Master_FromClientSide_Calling(custid, name, rows);
        if (Auto.Ename != "1")
        {
            custid = "";
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_GST_CTH_CODE(string custid)
    {
        
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

        if (custid != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "GST_CTH_CODE";
            Auto.Enamesearch = custid;
            Auto.Notn_No_Search = custid;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Address1 = ds.Tables[0].Rows[0]["LEVY_1NOTIFICATION"].ToString();
                Address2 = ds.Tables[0].Rows[0]["LEVY_1NOTIFICATION_SLNO"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();

                Address5 = ds.Tables[0].Rows[0]["LEVY_2NOTIFICATION"].ToString();
                Address6 = ds.Tables[0].Rows[0]["LEVY_2NOTIFICATION_SLNO"].ToString();
                Address7 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE2"].ToString();
            }
        }
        custid = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
        return custid;

    }

    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_1E(string Notn_no_sl, string Notn_no)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

        if (Notn_no != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_1E";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();

            }
        }
        Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
        return Notn_no_sl;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_1L(string Notn_no_sl, string Notn_no)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

        if (Notn_no != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_1L";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();

            }
        }
        Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
        return Notn_no_sl;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_2E(string Notn_no_sl, string Notn_no)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

        if (Notn_no != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_2E";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();

            }
        }
        Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
        return Notn_no_sl;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Notn_Excise_Master_txt_IGST_LEVY_SLNO_2L(string Notn_no_sl, string Notn_no)
    {
        string Address1 = "", Address2 = "", Address4 = "", Address5 = "", Address6 = "", Address7 = "", Address8 = "", Address9 = "";

        if (Notn_no != "")
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "NOTIFICATION_EXCISE_MASTER_CETH_NOTN_SLNO_IGST_2L";
            Auto.Enamesearch = Notn_no_sl;
            Auto.Notn_No_Search = Notn_no;

            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Address1 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_RATE"].ToString();
                Address2 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_SPL"].ToString();
                Address4 = ds.Tables[0].Rows[0]["NOTIFICATION_EXCISE_BCD_UNIT"].ToString();

            }
        }
        Notn_no_sl = Address1 + "~~" + Address2 + "~~" + Address4 + "~~" + Address5 + "~~" + Address6 + "~~" + Address7 + "~~" + Address8 + "~~" + Address9;
        return Notn_no_sl;
    }
    [System.Web.Services.WebMethod]
    public static string GetImporter_ChkBind(string custid, string SearchType)
    {
        string IEC_NO_BIND = "", BRANCH_NO_BIND = "";

        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "Import_Datas_Bind";
        Auto.Enamesearch = custid;
        Auto.Notn_No_Search = SearchType;

        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            IEC_NO_BIND = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
            BRANCH_NO_BIND = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();
        }
        custid = IEC_NO_BIND + "~~" + BRANCH_NO_BIND;
        return custid;
    }
      

    [System.Web.Services.WebMethod]
    public static string GetImporter_2(string custid, string custid_2)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        string STD_Type = "";

        Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_ADCODE";
        Auto.Enamesearch = custid;
        Auto.NSearch = custid_2;
        Auto.STANDARD_TYPE = "STD";

        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Adcode = "", Adcode_Bank_Account = "", IFSC_Code = "";

            string IECNo = ds.Tables[0].Rows[0]["IMP_EXP_IECNO"].ToString();
            string BranchNo = ds.Tables[0].Rows[0]["IMP_EXP_BRSLNO"].ToString();

            if (IECNo != "")
            {
                Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                Auto.Enamesearch = BranchNo;
                Auto.NSearch = IECNo;
                dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

                if (dss.Tables[0].Rows.Count == 0)
                {
                    Auto.Ename = "ADCODE_MASTER_SEARCH_branch_slno_wise";
                    Auto.Enamesearch = "";
                    Auto.NSearch = IECNo;
                    dss = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                }

                if (dss.Tables[0].Rows.Count > 0)
                {
                    if (dss.Tables[0].Rows.Count == 1)
                    {
                        Adcode = dss.Tables[0].Rows[0]["ADCODE_IEC_ADCODE"].ToString();
                        Adcode_Bank_Account = dss.Tables[0].Rows[0]["ADCODE_BANK_ACCOUNT_NO"].ToString();
                        IFSC_Code = dss.Tables[0].Rows[0]["ADCODE_IFSC_CODE"].ToString();
                    }
                }
            }


            custid = IECNo + "~~" + BranchNo + "~~" + Adcode;
        }

        return custid;
    }
}