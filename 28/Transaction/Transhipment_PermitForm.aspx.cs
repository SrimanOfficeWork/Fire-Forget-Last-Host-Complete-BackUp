using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


public partial class Transhipment_PermitForm : ThemeClass
{
    
    //Transaction trans = new Transaction();
    //Rpt_Invoice  inv = new Rpt_Invoice();
    TransPermit TP = new TransPermit();
    DataTable dt = new DataTable();  
    DataRow dr;//= dt.NewRow();
    DataSet dss = new DataSet();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();

    DataSet tbl = new DataSet();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    bool[] rowChanged;  
    public int i;
    public string AUTO_ID, flag;
    public string Button_Type;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, SCHEME_CODE, RITC_NO, ITEM_DESC;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string FILE_REF_NO, BRANCH_NO, IEC_NO, TRANSPORT_MODE, NO_KIND_OF_PACKAGES, ITEM_QTY_CODE, INVOICE_CURRENCY,F = "";
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
            pop_text_area_transac_popup_inn_container_export1.Style.Add("display", "block");
         
            txtExporter.Focus();
          
            jobno_load();

            btn_directprint.Visible = false;
            btn_manualprint.Visible = false;
            btn_excel.Visible = false;
            ddlJobNo.Focus();
        }

      
    }

    private void jobno_load()
    {
        CheckList chklist = new CheckList();
        Working_Period = Session["WorkingPeriod"].ToString();

        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }

   

    public int TP_Insert_Update()
    {

        //TP.ID = "";
        TP.JOBNO = ddlJobNo.SelectedItem.Text;

        TP.EXPORTERNAME = txtExporter.Text;
        TP.EXPORTER_ADDRESS1 = txtEx_Address1.Text;
        TP.EXPORTER_ADDRESS2 = txtEx_Address2.Text;
        TP.EXPORTER_ADDRESS3 = txtEx_Address3.Text;
        TP.EXPORTER_ADDRESS4 = txtEx_Address4.Text;
        TP.EXPORTER_ADDRESS5 = txtEx_Address5.Text;
        TP.CONSIGNEE_NAME = txtConsignee.Text;
        TP.CONSIGNEE_ADDRESS1 = txtConsignee_Add1.Text;
        TP.CONSIGNEE_ADDRESS2 = txtConsignee_Add2.Text;
        TP.CONSIGNEE_ADDRESS3 = txtConsignee_Add3.Text;
        TP.CONSIGNEE_ADDRESS4 = txtConsignee_Add4.Text;
        TP.CONSIGNEE_ADDRESS5 = txtConsignee_Add5.Text;
        TP.PORT_LOADING = txtPort_Of_Loading.Text;
        TP.PORT_FINAL_DEST = txt_PortDischarge.Text;
        TP.ITEM_DESC = txt_ItemDescription.Text;
        TP.COMMISSIONER_CUSTOMS = txtCommissioner_Customs.Text;
        TP.TRANSHIPED_FROM = txt_TranshipFrom.Text;
        TP.TP_BOONDNO = txt_BOOND_No.Text;
        TP.TP_BOOND_DATE = txt_BOOND_Date.Text;
        TP.VESSEL_NO = txtVessel_Flight_No.Text;
        TP.VESSEL_DATE = txtVessel_Flight_Date.Text;
        TP.IGM_NO = txt_IGM_No.Text;
        TP.IGM_DATE = txt_IGM_Date.Text;
        TP.INVOICE_NO = txt_InvoiceNo.Text;
        TP.INVOICE_DATE = txt_InvoiceDate.Text;
        TP.MAWBNO = txt_MAWBNo.Text;
        TP.MAWB_DATE = txt_MAWB_Date.Text;
        TP.HAWBNO = txt_HAWB_No.Text;
        TP.HAWB_DATE = txt_HAWB_Date.Text;
        TP.NO_OF_PKGS = txt_No_Of_Pkgs.Text;
        TP.NO_OF_PKGS_UNIT = txt_No_Of_Pkgs_Unit.Text;
        TP.WEIGHT1 = txt_Weight.Text;
        TP.WEIGHT_UNIT = txt_Weight_Unit.Text;
        TP.EXRATE = txt_Exrate.Text;
        TP.CURRENCY = txt_Currency.Text;
        TP.INVOICE_VALUE = txtInvoiceValue.Text;
        TP.CIF = txt_CIFValue.Text;
        TP.L_CHARGES = txt_LandingCharges.Text;
        TP.ASSESABLE_VAL = txt_AssesableValue.Text;
        TP.BOND_VALUE = txt_BondValue.Text;
        TP.DUTY_VALUE = txt_DutyValue.Text;
     

        TP.BRANCH_CODE = Session["currentbranch"].ToString();
        TP.BRANCH_COMMON = SELECT_BRANCH;
        TP.WORKING_PERIOD = Working_Period;
        TP.USER_ID = currentuser;
        TP.LOGINDATE = LoginDate;

        TP.flag = F;

        i = TP.TransPermit_Insert_Update();
      
        return i;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
    
            try
            {

                F = "S";           
                TP_Insert_Update();
                if (i == 1)
                {

                    txtExporter.Focus();
                    Alert_msg("Saved Successfully", "btnSave");

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                    btn_directprint.Visible = true;
                    btn_manualprint.Visible = true;
                    btn_excel.Visible = true;

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
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
      

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
              try
                {

                    F = "U";
                    TP_Insert_Update();
                    if (i == 1)
                    {

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = false;

                        txtExporter.Focus();
                        Alert_msg("Updated Successfully", "btnUpdate");

                    }
                    else if (i == 2)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = false;

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

                TP.JOBNO = ddlJobNo.SelectedItem.Text;
                TP.WORKING_PERIOD = Working_Period;
                TP.BRANCH_CODE = currentbranch;
                TP.BRANCH_COMMON = SELECT_BRANCH;
                TP.flag = "Delete";

                dss = TP.Retreive_TransPermit();
                i = TP.result;
                if (i == 1)
                {
                    btnNew_Click(sender, e);
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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
       
        txtExporter.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        hdn_val.Value = "";
       
    }

    protected void TextBox_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.TextBox thisTextBox = (System.Web.UI.WebControls.TextBox)sender;
        GridViewRow thisGridViewRow = (GridViewRow)thisTextBox.Parent.Parent;
        int row = thisGridViewRow.RowIndex;
        rowChanged[row] = true;
    }

    public void Get_AllDetails_TRANSPERMIT()
    {
        if (ddlJobNo.SelectedItem.Text != "Select")
        {  
                TP.JOBNO = ddlJobNo.SelectedItem.Text;
                TP.WORKING_PERIOD = Working_Period;
                TP.BRANCH_CODE = currentbranch;
                TP.BRANCH_COMMON = SELECT_BRANCH;
                TP.flag = "Get_TRANSPERMIT";

                dss = TP.Retreive_TransPermit();

                i = TP.result;

                if (dss.Tables[0].Rows.Count > 0)
                {
                    if (i == 1)
                    {
                        txtExporter.Text = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                        txtEx_Address1.Text = dss.Tables[0].Rows[0]["ADDRESS1"].ToString();
                        txtEx_Address2.Text = dss.Tables[0].Rows[0]["ADDRESS2"].ToString();
                        txtEx_Address3.Text = dss.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txtEx_Address4.Text = dss.Tables[0].Rows[0]["ADDRESS4"].ToString();
                        txtEx_Address5.Text = dss.Tables[0].Rows[0]["ADDRESS5"].ToString();
                        txtConsignee.Text = dss.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                        txtConsignee_Add1.Text = dss.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString();
                        txtConsignee_Add2.Text = dss.Tables[0].Rows[0]["SUPPLIER_ADDRESS1"].ToString();
                        txtConsignee_Add3.Text = dss.Tables[0].Rows[0]["SUPPLIER_ADDRESS2"].ToString();
                        txtConsignee_Add4.Text = dss.Tables[0].Rows[0]["SUPPLIER_COUNTRY_NAME"].ToString();
                        txtConsignee_Add5.Text = dss.Tables[0].Rows[0]["SUPPLIER_COUNTRY_PINCODE"].ToString();
                        txt_PortDischarge.Text = dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
                        txtPort_Of_Loading.Text = dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
                        txt_ItemDescription.Text = dss.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString();

                        txtVessel_Flight_No.Text = dss.Tables[0].Rows[0]["IGM_FLIGHTNO_VESSELNO"].ToString();
                        txtVessel_Flight_Date.Text = dss.Tables[0].Rows[0]["IGM_FLIGHT_VESSELDATE"].ToString();
                        txt_IGM_No.Text = dss.Tables[0].Rows[0]["IGM_NO"].ToString();
                        txt_IGM_Date.Text = dss.Tables[0].Rows[0]["IGM_DATE"].ToString();
                        txt_InvoiceNo.Text = dss.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                        txt_InvoiceDate.Text = dss.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                        txt_MAWBNo.Text = dss.Tables[0].Rows[0]["IGM_MAWB_MBL"].ToString();
                        txt_MAWB_Date.Text = dss.Tables[0].Rows[0]["IGM_MAWB_MBLDATE"].ToString();
                        txt_HAWB_No.Text = dss.Tables[0].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                        txt_HAWB_Date.Text = dss.Tables[0].Rows[0]["IGM_HAWB_HBLDATE"].ToString();
                        txt_No_Of_Pkgs.Text = dss.Tables[0].Rows[0]["IGM_NOOFPACKAGE"].ToString();
                        txt_No_Of_Pkgs_Unit.Text = dss.Tables[0].Rows[0]["IGM_PACKAGETYPE"].ToString();
                        txt_Weight.Text = dss.Tables[0].Rows[0]["IGM_NETWEIGHT"].ToString();
                        txt_Weight_Unit.Text = dss.Tables[0].Rows[0]["IGM_NETWEIGHTTYPE"].ToString();
                        txt_Exrate.Text = dss.Tables[0].Rows[0]["INVOICE_EXRATE"].ToString();
                        txt_Currency.Text = dss.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString();
                        txtInvoiceValue.Text = dss.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();
                        txt_CIFValue.Text = dss.Tables[0].Rows[0]["CIF_VALUE"].ToString();
                        //txt_LandingCharges.Text = dss.Tables[0].Rows[0]["L_CHARGES"].ToString();
                        txt_LandingCharges.Text = dss.Tables[0].Rows[0]["LANDING_CHARGES"].ToString();

                        txt_AssesableValue.Text = dss.Tables[0].Rows[0]["ASSESSABLE_VALUE"].ToString();
                        txt_BondValue.Text = dss.Tables[0].Rows[0]["BOND_VALUE"].ToString();
                        txt_DutyValue.Text = dss.Tables[0].Rows[0]["DUTY_VALUE"].ToString();

                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btnSave.Visible = true;


                        btn_directprint.Visible = false;
                        btn_manualprint.Visible = false;
                        btn_excel.Visible = false;

                    }
                    if (i == 2)
                    {

                        txtExporter.Text = dss.Tables[0].Rows[0]["EXPORTERNAME"].ToString();
                        txtEx_Address1.Text = dss.Tables[0].Rows[0]["EXPORTER_ADDRESS1"].ToString();
                        txtEx_Address2.Text = dss.Tables[0].Rows[0]["EXPORTER_ADDRESS2"].ToString();
                        txtEx_Address3.Text = dss.Tables[0].Rows[0]["EXPORTER_ADDRESS3"].ToString();
                        txtEx_Address4.Text = dss.Tables[0].Rows[0]["EXPORTER_ADDRESS4"].ToString();
                        txtEx_Address5.Text = dss.Tables[0].Rows[0]["EXPORTER_ADDRESS5"].ToString();
                        txtConsignee.Text = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                        txtConsignee_Add1.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADDRESS1"].ToString();
                        txtConsignee_Add2.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADDRESS2"].ToString();
                        txtConsignee_Add3.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADDRESS3"].ToString();
                        txtConsignee_Add4.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADDRESS4"].ToString();
                        txtConsignee_Add5.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADDRESS5"].ToString();
                        txt_PortDischarge.Text = dss.Tables[0].Rows[0]["PORT_LOADING"].ToString();
                        txtPort_Of_Loading.Text = dss.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                        txt_ItemDescription.Text = dss.Tables[0].Rows[0]["ITEM_DESC"].ToString();
                        txtCommissioner_Customs.Text = dss.Tables[0].Rows[0]["COMMISSIONER_CUSTOMS"].ToString();
                        txt_TranshipFrom.Text = dss.Tables[0].Rows[0]["TRANSHIPED_FROM"].ToString();
                        txt_BOOND_No.Text = dss.Tables[0].Rows[0]["TP_BOONDNO"].ToString();
                        txt_BOOND_Date.Text = dss.Tables[0].Rows[0]["TP_BOOND_DATE"].ToString();
                        txtVessel_Flight_No.Text = dss.Tables[0].Rows[0]["VESSEL_NO"].ToString();
                        txtVessel_Flight_Date.Text = dss.Tables[0].Rows[0]["VESSEL_DATE"].ToString();
                        txt_IGM_No.Text = dss.Tables[0].Rows[0]["IGM_NO"].ToString();
                        txt_IGM_Date.Text = dss.Tables[0].Rows[0]["IGM_DATE"].ToString();
                        txt_InvoiceNo.Text = dss.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                        txt_InvoiceDate.Text = dss.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                        txt_MAWBNo.Text = dss.Tables[0].Rows[0]["MAWBNO"].ToString();
                        txt_MAWB_Date.Text = dss.Tables[0].Rows[0]["MAWB_DATE"].ToString();
                        txt_HAWB_No.Text = dss.Tables[0].Rows[0]["HAWBNO"].ToString();
                        txt_HAWB_Date.Text = dss.Tables[0].Rows[0]["HAWB_DATE"].ToString();
                        txt_No_Of_Pkgs.Text = dss.Tables[0].Rows[0]["NO_OF_PKGS"].ToString();
                        txt_No_Of_Pkgs_Unit.Text = dss.Tables[0].Rows[0]["NO_OF_PKGS_UNIT"].ToString();
                        txt_Weight.Text = dss.Tables[0].Rows[0]["WEIGHT1"].ToString();
                        txt_Weight_Unit.Text = dss.Tables[0].Rows[0]["WEIGHT_UNIT"].ToString();
                        txt_Exrate.Text = dss.Tables[0].Rows[0]["EXRATE"].ToString();
                        txt_Currency.Text = dss.Tables[0].Rows[0]["CURRENCY"].ToString();
                        txtInvoiceValue.Text = dss.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();
                        txt_CIFValue.Text = dss.Tables[0].Rows[0]["CIF"].ToString();
                        txt_LandingCharges.Text = dss.Tables[0].Rows[0]["L_CHARGES"].ToString();
                        txt_AssesableValue.Text = dss.Tables[0].Rows[0]["ASSESABLE_VAL"].ToString();
                        txt_BondValue.Text = dss.Tables[0].Rows[0]["BOND_VALUE"].ToString();
                        txt_DutyValue.Text = dss.Tables[0].Rows[0]["DUTY_VALUE"].ToString();
                    
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;

                        btn_directprint.Visible = true;
                        btn_manualprint.Visible = true;
                        btn_excel.Visible = true;
                }
            }
        }
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            //Clear_SB_Duty_DBK();
            Get_AllDetails_TRANSPERMIT();
        }
        else
        {
            Clear_SB_Duty_DBK();
        }
 
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Manual SB', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Manual SB', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
 
    public void Clear_SB_Duty_DBK()
    {
       
        txtExporter.Text = "";
        txtEx_Address1.Text = "";
        txtEx_Address2.Text = "";
        txtEx_Address3.Text = "";
        txtEx_Address4.Text = "";
        txtEx_Address5.Text = "";
        txtConsignee.Text = "";
        txtConsignee_Add1.Text = "";
        txtConsignee_Add2.Text = "";
        txtConsignee_Add3.Text = "";
        txtConsignee_Add4.Text = "";
        txtConsignee_Add5.Text = "";
        txtPort_Of_Loading.Text = "";
        txt_PortDischarge.Text = "";
        txt_ItemDescription.Text = "";
        txtCommissioner_Customs.Text = "";
        txt_TranshipFrom.Text = "";
        txt_BOOND_No.Text = "";
        txt_BOOND_Date.Text = "";
        txtVessel_Flight_No.Text = "";
        txtVessel_Flight_Date.Text = "";
        txt_IGM_No.Text = "";
        txt_IGM_Date.Text = "";
        txt_InvoiceNo.Text = "";
        txt_InvoiceDate.Text = "";
        txt_MAWBNo.Text = "";
        txt_MAWB_Date.Text = "";
        txt_HAWB_No.Text = "";
        txt_HAWB_Date.Text = "";
        txt_No_Of_Pkgs.Text = "";
        txt_No_Of_Pkgs_Unit.Text = "";
        txt_Weight.Text = "";
        txt_Weight_Unit.Text = "";
        txt_Exrate.Text = "";
        txt_Currency.Text = "";
        txtInvoiceValue.Text = "";
        txt_CIFValue.Text = "";
        txt_LandingCharges.Text = "";
        txt_AssesableValue.Text = "";
        txt_BondValue.Text = "";
        txt_DutyValue.Text = "";

    }
}