using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;



public partial class Export_ShippingBill_DBK_DutyFree : ThemeClass
{
    Exp_ShipingBill_Dutyfree_Dbk SB = new Exp_ShipingBill_Dutyfree_Dbk();
    Transaction trans = new Transaction();
    Rpt_Invoice  inv = new Rpt_Invoice();
    DataTable dt = new DataTable();  
    DataRow dr;//= dt.NewRow();
    DataSet dss = new DataSet();
    DataSet ds = new DataSet();
    DataSet ds2 = new DataSet();
    AppSession aps = new AppSession();
    DataSet tbl = new DataSet();
    public string Trans_ID = "";
    ErrorLogs er = new ErrorLogs();
    bool[] rowChanged;  
    public int i;
    public string AUTO_ID, flag;

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
    public double GetNumbers;


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
            tab2.Style.Add("display", "none");

            txtExporter.Focus();
            //gvAll.DataSource = dt;//add empty row

            //gvAll.DataBind();
            Get_JobNo();
            btn_Report.Visible = false;

        }

        GV_Details.Visible = true;

        int totalRows = GV_Details.Rows.Count;
        rowChanged = new bool[totalRows];
    }

    public void Get_JobNo()
    {

        Export_CheckList CHKLIST = new Export_CheckList();
        CHKLIST.JOBNo = "";
        CHKLIST.Ename = "select_jobno";
        CHKLIST.Workingperiod = SELECT_BRANCH;
        ddlJobNo.DataSource = CHKLIST.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }



    public int SB_Insert_Update()
    {

        //SB.ID = "";
        SB.JOBNO = ddlJobNo.SelectedItem.Text;
        SB.Sb_TYPE = ddlType.SelectedItem.Text;
        SB.Exporters_Reference = txtExporters_References.Text;
        SB.ExporterName = txtExporter.Text;
        SB.ExporterAdd1 = txtEx_Address1.Text;
        SB.ExporterAdd2 = txtEx_Address2.Text;
        SB.ExporterAdd3 = txtEx_Address3.Text;
        SB.ExporterAdd4 = txtEx_Address4.Text;
        SB.ExporterAdd5 = txtEx_Address5.Text;
        SB.ConsigneeName = txtConsignee.Text;
        SB.ConsigneeAdd1 = txtConsignee_Add1.Text;
        SB.ConsigneeAdd2 = txtConsignee_Add2.Text;
        SB.ConsigneeAdd3 = txtConsignee_Add3.Text;
        SB.ConsigneeAdd4 = txtConsignee_Add4.Text;
        SB.ConsigneeAdd5 = txtConsignee_Add5.Text;
        SB.CustomHouseAgent = txt_CustomHouseAgent.Text;
        SB.AgentLICNo = txt_LIC_No.Text;
        SB.PrecarriageBy = txt_PrecarriageBy.Text;
        SB.VesselFlightNo = txtVessel_Flight_No.Text;
        SB.Port_Of_Discharge = txt_PortDischarge.Text;
        SB.INVOICE_NO = txt_InvoiceNo_Date.Text;
        SB.AR4_No_Date = txtAR_No_Date.Text +"-"+ txtAR_No_Date2.Text;
        SB.Q_CertNo_Date = txt_QCertNo_Date.Text + "-" + txt_QCertNo_Date2.Text;
        SB.ExportTradeControl = txt_Export_Trade.Text;
        SB.Place_Receipt_ByCarrier = txtPlace_ReceiptBy_PreCarrier.Text;
        SB.RotationNo = txt_Rotation_No.Text;
        SB.Port_Of_Loading = txtPort_Of_Loading.Text;
        SB.Country_Destination = txtCountry_Final_Destination.Text;
        SB.ShippingBill_No_Date = txt_ShippingBillNo_Date.Text;
        SB.ImpEx_CodeNo_BIN = txt_Import_Export_BIN.Text;
        SB.RBI_CodeNo = txt_RBICodeNo.Text;
        SB.RB_DefferedCredit = RadioButton_Exporters.SelectedValue;
        //SB.RB_Joint_Ventures = RB_Joint.Text;
        //SB.RB_Rupees_Credit = RB_Rupees_Credit.Text;
        SB.RB_Exporter_Others = txt_exp_others.Text;
        SB.RB_OutRightSales = RadioButton_Ship.SelectedValue;
        //SB.RB_Consignment = RB_Consignment.Text;
        SB.RB_Ship_Others = txt_Ship_Others.Text;
        SB.RB_CIF = RadioButton_Nature.SelectedValue;
        //SB.RB_CFR = RB_CFR.Text;
        //SB.RB_FOB = RB_FOB.Text;
        //SB.RB_NatureOfOthers = RB_Nature_Others.Text;
        SB.RB_NatureOfOthers = txt_NatureOfOthers.Text;
        SB.ExchangeRate_US = txt_Ex_Rate_US.Text;
        SB.Invoice_Currency = txt_InvoiceCurrency.Text;
        SB.InvoiceAmount1 = txt_InvoiceAmount1.Text;
        SB.RBIApprovalNo = txt_RBIApprovalNo.Text;
        SB.Net_Weight = txt_NetWeight.Text;
        SB.GrossWeight = txt_GrossWeight.Text;
        SB.FOB_In_Words = txtFOB_In_Words.Text;
        SB.CIF_FOB_Currency = txt_CIF_FOB_Currency.Text;
        SB.CIF_FOB_Amount = txt_CIF_FOB_Amount.Text;
        SB.Currency = txt_Currency.Text;
        SB.Amount = txt_Amount.Text;
        SB.FOBValue_Currency = txtFOBValue_Currency.Text;
        SB.FOBValue_Amount = txtFOBValue_Amount.Text;
        SB.Freight_Currency = txtFreight_Currency.Text;
        SB.Freight_Amount = txtFreight_Amount.Text;
        SB.Insurance_Currency = txtInsurance_Currency.Text;
        SB.Insurance_Amount = txtInsurance_Amount.Text;
        SB.Commission_Currency = txtCommission_Currency.Text;
        SB.Commission_Amount = txtCommission_Amount.Text;
        SB.Discount_Currency = txtDiscount_Currency.Text;
        SB.Discount_Amount = txtDiscount_Amount.Text;
        SB.Otherdeduction_Currency = txt_Otherdeduction_Currency.Text;
        SB.Otherdeduction_Amount = txt_Otherdeduction_Amount.Text;
        SB.GR_No = txt_GR_No.Text;
        SB.Gi_BondNo = txt_Gi_BondNo.Text;
        SB.Declaration_Clause = txt_Declaration_Clause.Text;
        SB.public_Notice = txt_public_Notice.Text;
        SB.public_Date = txt_public_Date.Text;
        SB.Remarks = txtRemarks.Text;
        SB.DBK_Tarrif = txt_DBK_Tarrif.Text;
        SB.DBK_AssblValue = txt_DBK_AssblValue.Text;
        SB.DutyPercentage = txt_DutyPercentage.Text;
        SB.DutyAmount = txt_DutyAmount.Text;
        SB.DutyForgon = txt_DutyForgon.Text;
        SB.BRANCH_CODE = Session["currentbranch"].ToString();
        SB.BRANCH_COMMON = SELECT_BRANCH;
        SB.YEAR = "";
        SB.WORKING_PERIOD = Working_Period;
        SB.USER_ID = currentuser;
        SB.LOGINDATE = LoginDate;
        
        SB.flag = "S";

        i = SB.SB_DBK_DutyFree_Insert_Update();
      
        return i;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlType.SelectedItem.Text != "Select")
        {
           try
            {

                F = "S";
                //_Insert_Update(F, "0");
                SB_Insert_Update();
                Grid_Update();
                if (i == 1)
                {
                    hdn_val.Value = Convert.ToString(inv.update_id);
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                    btn_Report.Visible = true;

                    txtExporter.Focus();
                    Alert_msg("Saved Successfully", "btnSave");

                }
                else if (i == 2)
                {
                    Alert_msg("Saved Successfully!", "btnSave");
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;

                    Alert_msg("Not Saved", "btnSave");
                }

                btn_Report.Visible = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
        else
        {
            Alert_msg("Select ShippingBill Type");
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
     if (ddlType.SelectedItem.Text != "Select")
            {
              try
                {

                    F = "U";
                    SB_Insert_Update();
                    Grid_Update();
                    //_Insert_Update(F, hdn_val.Value);
                    if (i == 1)
                    {

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = false;
                        btn_Report.Visible = true;

                        txtExporter.Focus();
                        Alert_msg("Updated Successfully", "btnUpdate");

                    }
                    else if (i == 2)
                    {
                        //Alert_msg("Job No Already Exist!", "btnUpdate");
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
             else
             {
                 Alert_msg("Select ShippingBill Type");
             }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (ddlType.SelectedItem.Text != "Select")
        {

            try
            {

                SB.JOBNO = ddlJobNo.SelectedItem.Text;
                SB.Sb_TYPE = ddlType.SelectedItem.Text;
                SB.WORKING_PERIOD = Working_Period;
                SB.BRANCH_CODE = currentbranch;
                SB.BRANCH_COMMON = SELECT_BRANCH;
                SB.flag = "Delete";

                dss = SB.Retreive_SB_Duty_DBK();

                i = SB.result;
           
                //_Insert_Update(F, hdn_val.Value);

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
        else
        {
            Alert_msg("Select ShippingBill Type");
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
       
        btn_Report.Visible = false;

    }

    public void Get_AllDetails_Sb_Duty_Dbk_Grid()
    {
        if (ddlType.SelectedItem.Text != "Select")
        {
            SB.JOBNO = ddlJobNo.SelectedItem.Text;
            SB.Sb_TYPE = ddlType.SelectedItem.Text;
            SB.WORKING_PERIOD = Working_Period;
            SB.BRANCH_CODE = currentbranch;
            SB.BRANCH_COMMON = SELECT_BRANCH;
            SB.flag = "Get_SB_DBK_DUTYFREE_GRID";

            dss = SB.Retreive_SB_Duty_DBK();

            i = SB.result;
        }
    }

    public void Grid_DataBind()     
    {
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            if (ddlType.SelectedItem.Text != "Select")
            {
                SB.JOBNO = ddlJobNo.SelectedItem.Text;
                SB.Sb_TYPE = ddlType.SelectedItem.Text;
                SB.WORKING_PERIOD = Working_Period;
                SB.BRANCH_CODE = currentbranch;
                SB.BRANCH_COMMON = SELECT_BRANCH;
                SB.flag = "Get_SB_DBK_DUTYFREE_GRID";

                ds = SB.Retreive_SB_Duty_DBK();

                i = SB.result;

                //txt_DBK_Tarrif.Text = dss.Tables[0].Rows[0]["RITCNO"].ToString();
                //txt_DBK_AssblValue.Text = dss.Tables[0].Rows[0]["FOB_VALUE"].ToString();

                if (i == 1)
                {
                    GV_Details.DataSource = ds;
                    GV_Details.DataBind();
                }
                else if (i == 2)
                {
                    GV_Details.DataSource = ds;
                    GV_Details.DataBind();
                }
                else
                {
                    GV_Details.DataSource = ds;
                    GV_Details.DataBind();
                 
                    //Create_Empty_Grid();
                }
               
            }
        }
    }

    public void Get_NumtoWords()
    {

        SB.JOBNO = ddlJobNo.SelectedItem.Text;
        SB.BRANCH_CODE = currentbranch;
        SB.BRANCH_COMMON = SELECT_BRANCH;
        SB.WORKING_PERIOD = Working_Period;
        SB.Sb_TYPE = "";
        //SB.flag = "Get_SB_DBK_DUTYFREE_GRID";
        SB.flag = "select_RITC";
        

        ds2 = SB.Retreive_SB_Duty_DBK();

        if (ds2.Tables[1].Rows.Count > 0)
        {

            string num = ds2.Tables[1].Rows[0]["FOB_VALUE"].ToString();

            if (num != "0.00" && num != null && num != "")
            {
                GetNumbers = Convert.ToDouble(num);
                double d = GetNumbers;

                if (num.Contains('.'))
                {
                    string[] check_val = num.Split('.');
                    string part1 = check_val[1];

                    if (part1 != "00" && part1 != null)
                    {
                        int i = (int)d;
                        string decimalPart = d.ToString().Split('.')[1]; ;
                        string text = NumberToText(i, true, false) + " Rupees and" + DecimalToText(decimalPart);
                        txtFOB_In_Words.Text = text + " Paise Only";
                    }
                    else
                    {
                        int i = (int)d;
                        string text = NumberToText(i, true, false) + "Rupees Only";
                        txtFOB_In_Words.Text = text;
                    }


                }
                else
                {
                    int i = (int)d;
                    string text = NumberToText(i, true, false) + "Rupees Only";

                }
            }
            else
            {
                txtFOB_In_Words.Text = "Zero Rupees Only";
            }

           
        }
    }

    protected void TextBox_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.TextBox thisTextBox = (System.Web.UI.WebControls.TextBox)sender;
        GridViewRow thisGridViewRow = (GridViewRow)thisTextBox.Parent.Parent;
        int row = thisGridViewRow.RowIndex;
        rowChanged[row] = true;
    }

    public void Create_Empty_Grid()
    {
        DataColumn da = new DataColumn("MARKS_NO");

        //DataTable dtt = new DataTable();
        //dtt.Columns.Add(da);
    DataTable dt = new DataTable();
    dt.Columns.Add(da);
    DataRow dr = dt.NewRow();
    dr["MARKS_NO"] = string.Empty;
    dt.Rows.Add(dr);
    }

    public void Get_AllDetails_SB_Duty_DBK()
    {
        //Get_AllDetails_Sb_Duty_Dbk_Grid();

        if (ddlJobNo.SelectedItem.Text != "Select")
        {  
            if (ddlType.SelectedItem.Text != "Select")
            {
                //Grid_DataBind();
                SB.JOBNO = ddlJobNo.SelectedItem.Text;
                SB.Sb_TYPE = ddlType.SelectedItem.Text;
                SB.WORKING_PERIOD = Working_Period;
                SB.BRANCH_CODE = currentbranch;
                SB.BRANCH_COMMON = SELECT_BRANCH;
                SB.flag = "Get_SB_DBK_DUTYFREE_LIST";

                dss = SB.Retreive_SB_Duty_DBK();

                i = SB.result;

                if (dss.Tables[0].Rows.Count > 0)
                {
                    if (i == 1)
                    {

                        txt_InvoiceNo_Date.Text = dss.Tables[0].Rows[0]["INVOICE_NO"].ToString() + "-" + dss.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                        txt_ShippingBillNo_Date.Text = dss.Tables[0].Rows[0]["SB_NO"].ToString() + "-" + dss.Tables[0].Rows[0]["SB_DATE"].ToString();
                        //txtExporters_References.Text = dss.Tables[0].Rows[0]["Exporters_Reference"].ToString();
                        txtExporter.Text = dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                        txtEx_Address1.Text = dss.Tables[0].Rows[0]["ADDRESS1"].ToString();
                        txtEx_Address2.Text = dss.Tables[0].Rows[0]["ADDRESS2"].ToString();
                        txtEx_Address3.Text = dss.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txtEx_Address4.Text = dss.Tables[0].Rows[0]["ADDRESS4"].ToString();
                        txtEx_Address5.Text = dss.Tables[0].Rows[0]["ADDRESS5"].ToString();
                        txtConsignee.Text = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                        txtConsignee_Add1.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                        txtConsignee_Add2.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                        txtConsignee_Add3.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                        txtConsignee_Add4.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                        txtConsignee_Add5.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();
                        //txt_CustomHouseAgent.Text = dss.Tables[0].Rows[0]["CustomHouseAgent"].ToString();
                        txt_PortDischarge.Text = dss.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                        txtPort_Of_Loading.Text = dss.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                        txtCountry_Final_Destination.Text = dss.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString();
                        txt_Ex_Rate_US.Text = 1 + dss.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString() + " = Rs." + dss.Tables[0].Rows[0]["EXCHANGE_RATE"].ToString();
                        txt_InvoiceCurrency.Text = dss.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString();
                        txt_InvoiceAmount1.Text = dss.Tables[0].Rows[0]["INVOICE_VALUE"].ToString();
                        txtFreight_Currency.Text = dss.Tables[0].Rows[0]["FREIGHT_CURRENCY"].ToString();
                        txtFreight_Amount.Text = dss.Tables[0].Rows[0]["FREIGHT_RATE"].ToString();
                        txtInsurance_Currency.Text = dss.Tables[0].Rows[0]["INSURANCE_CURRENCY"].ToString();
                        txtInsurance_Amount.Text = dss.Tables[0].Rows[0]["INSURANCE_CHARGES"].ToString();
                        txtCommission_Currency.Text = dss.Tables[0].Rows[0]["COMMISSION_CURRENCY"].ToString();
                        txtCommission_Amount.Text = dss.Tables[0].Rows[0]["COMMISSION_CHARGES"].ToString();
                        txtDiscount_Currency.Text = dss.Tables[0].Rows[0]["PACKMISC_CURRENCY"].ToString();
                        txtDiscount_Amount.Text = dss.Tables[0].Rows[0]["PACKMISC_CHARGES"].ToString();
                        txt_Otherdeduction_Currency.Text = dss.Tables[0].Rows[0]["OTHER_DEDUCTION_CURRENCY"].ToString();
                        txt_Otherdeduction_Amount.Text = dss.Tables[0].Rows[0]["OTHER_DEDUCTION_CHARGES"].ToString();
                     

                        RadioButton_Nature.SelectedValue = "Others";
                        RadioButton_Exporters.SelectedValue = "Others";
                        RadioButton_Ship.SelectedValue = "Others";
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        btn_Report.Visible = false;
                        btnSave.Visible = true;
                        btn_Report.Visible = false;

                        Get_NumtoWords();

                    }
                    if (i == 2)
                    {

                        txt_InvoiceNo_Date.Text = dss.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                        txt_ShippingBillNo_Date.Text = dss.Tables[0].Rows[0]["ShippingBill_No_Date"].ToString();
                        txtExporters_References.Text = dss.Tables[0].Rows[0]["Exporters_Reference"].ToString();
                        txtExporter.Text = dss.Tables[0].Rows[0]["ExporterName"].ToString();
                        txtEx_Address1.Text = dss.Tables[0].Rows[0]["ExporterAdd1"].ToString();
                        txtEx_Address2.Text = dss.Tables[0].Rows[0]["ExporterAdd2"].ToString();
                        txtEx_Address3.Text = dss.Tables[0].Rows[0]["ExporterAdd3"].ToString();
                        txtEx_Address4.Text = dss.Tables[0].Rows[0]["ExporterAdd4"].ToString();
                        txtEx_Address5.Text = dss.Tables[0].Rows[0]["ExporterAdd5"].ToString();
                        txtConsignee.Text = dss.Tables[0].Rows[0]["ConsigneeName"].ToString();
                        txtConsignee_Add1.Text = dss.Tables[0].Rows[0]["ConsigneeAdd1"].ToString();
                        txtConsignee_Add2.Text = dss.Tables[0].Rows[0]["ConsigneeAdd2"].ToString();
                        txtConsignee_Add3.Text = dss.Tables[0].Rows[0]["ConsigneeAdd3"].ToString();
                        txtConsignee_Add4.Text = dss.Tables[0].Rows[0]["ConsigneeAdd4"].ToString();
                        txtConsignee_Add5.Text = dss.Tables[0].Rows[0]["ConsigneeAdd5"].ToString();
                        txt_CustomHouseAgent.Text = dss.Tables[0].Rows[0]["CustomHouseAgent"].ToString();
                        txt_LIC_No.Text = dss.Tables[0].Rows[0]["AgentLICNo"].ToString();
                        txt_PrecarriageBy.Text = dss.Tables[0].Rows[0]["PrecarriageBy"].ToString();
                        txtVessel_Flight_No.Text = dss.Tables[0].Rows[0]["VesselFlightNo"].ToString();
                        txt_PortDischarge.Text = dss.Tables[0].Rows[0]["Port_Of_Discharge"].ToString();
                        //txtAR_No_Date.Text = dss.Tables[0].Rows[0]["AR4_No_Date"].ToString();

                        string AR4_noDate = dss.Tables[0].Rows[0]["AR4_No_Date"].ToString();

                        string[] xyz = AR4_noDate.Split('-');
                        txtAR_No_Date.Text = xyz[0];
                        txtAR_No_Date2.Text = xyz[1];
                        
                        //txt_QCertNo_Date.Text = dss.Tables[0].Rows[0]["Q_CertNo_Date"].ToString();

                        string QCertNo_Date = dss.Tables[0].Rows[0]["Q_CertNo_Date"].ToString();
                        string[] abc = QCertNo_Date.Split('-');
                        txt_QCertNo_Date.Text = abc[0];
                        txt_QCertNo_Date2.Text = abc[1];

                        txt_Export_Trade.Text = dss.Tables[0].Rows[0]["ExportTradeControl"].ToString();
                        txtPlace_ReceiptBy_PreCarrier.Text = dss.Tables[0].Rows[0]["Place_Receipt_ByCarrier"].ToString();
                        txt_Rotation_No.Text = dss.Tables[0].Rows[0]["RotationNo"].ToString();
                        txtPort_Of_Loading.Text = dss.Tables[0].Rows[0]["Port_Of_Loading"].ToString();
                        txtCountry_Final_Destination.Text = dss.Tables[0].Rows[0]["Country_Destination"].ToString();
                        txt_Import_Export_BIN.Text = dss.Tables[0].Rows[0]["ImpEx_CodeNo_BIN"].ToString();
                        txt_RBICodeNo.Text = dss.Tables[0].Rows[0]["RBI_CodeNo"].ToString();
                    
                        txt_Ex_Rate_US.Text = dss.Tables[0].Rows[0]["ExchangeRate_US"].ToString();
                        txt_InvoiceCurrency.Text = dss.Tables[0].Rows[0]["Invoice_Currency"].ToString();
                        txt_InvoiceAmount1.Text = dss.Tables[0].Rows[0]["RB_CFR"].ToString();
                        txt_RBIApprovalNo.Text = dss.Tables[0].Rows[0]["RB_FOB"].ToString();

                        txt_NetWeight.Text = dss.Tables[0].Rows[0]["Net_Weight"].ToString();
                        txt_GrossWeight.Text = dss.Tables[0].Rows[0]["GrossWeight"].ToString();
                        txtFOB_In_Words.Text = dss.Tables[0].Rows[0]["FOB_In_Words"].ToString();
                        txt_CIF_FOB_Currency.Text = dss.Tables[0].Rows[0]["CIF_FOB_Currency"].ToString();
                        txt_CIF_FOB_Amount.Text = dss.Tables[0].Rows[0]["CIF_FOB_Amount"].ToString();
                        txt_Currency.Text = dss.Tables[0].Rows[0]["Currency"].ToString();
                        txt_Amount.Text = dss.Tables[0].Rows[0]["Amount"].ToString();
                        txtFOBValue_Currency.Text = dss.Tables[0].Rows[0]["FOBValue_Currency"].ToString();
                        txtFOBValue_Amount.Text = dss.Tables[0].Rows[0]["FOBValue_Amount"].ToString();
                        txtFreight_Currency.Text = dss.Tables[0].Rows[0]["Freight_Currency"].ToString();
                        txtFreight_Amount.Text = dss.Tables[0].Rows[0]["Freight_Amount"].ToString();
                        txtInsurance_Currency.Text = dss.Tables[0].Rows[0]["Insurance_Currency"].ToString();
                        txtInsurance_Amount.Text = dss.Tables[0].Rows[0]["Insurance_Amount"].ToString();

                        txtCommission_Currency.Text = dss.Tables[0].Rows[0]["Commission_Currency"].ToString();
                        txtCommission_Amount.Text = dss.Tables[0].Rows[0]["Commission_Amount"].ToString();
                        txtDiscount_Currency.Text = dss.Tables[0].Rows[0]["Discount_Currency"].ToString();
                        txtDiscount_Amount.Text = dss.Tables[0].Rows[0]["Discount_Amount"].ToString();
                        txt_Otherdeduction_Currency.Text = dss.Tables[0].Rows[0]["Otherdeduction_Currency"].ToString();
                        txt_Otherdeduction_Amount.Text = dss.Tables[0].Rows[0]["Otherdeduction_Amount"].ToString();
                        txt_GR_No.Text = dss.Tables[0].Rows[0]["GR_No"].ToString();
                        txt_Gi_BondNo.Text = dss.Tables[0].Rows[0]["Gi_BondNo"].ToString();
                        txt_Declaration_Clause.Text = dss.Tables[0].Rows[0]["Declaration_Clause"].ToString();
                        txt_public_Notice.Text = dss.Tables[0].Rows[0]["public_Notice"].ToString();
                        txt_public_Date.Text = dss.Tables[0].Rows[0]["public_Date"].ToString();
                        txtRemarks.Text = dss.Tables[0].Rows[0]["Remarks"].ToString();
                        txt_DBK_Tarrif.Text = dss.Tables[0].Rows[0]["DBK_Tarrif"].ToString();
                        txt_DBK_AssblValue.Text = dss.Tables[0].Rows[0]["DBK_AssblValue"].ToString();
                        txt_DutyPercentage.Text = dss.Tables[0].Rows[0]["DutyPercentage"].ToString();
                        txt_DutyAmount.Text = dss.Tables[0].Rows[0]["DutyAmount"].ToString();
                        txt_DutyForgon.Text = dss.Tables[0].Rows[0]["DutyForgon"].ToString();

                        //RadioButton_Conditions..............................................

                        RadioButton_Exporters.SelectedValue = dss.Tables[0].Rows[0]["RB_DefferedCredit"].ToString();
                        if (RadioButton_Nature.SelectedValue == "Others")
                        {
                            txt_NatureOfOthers.Text = dss.Tables[0].Rows[0]["RB_NatureOfOthers"].ToString();
                        }
                        else
                        {
                            txt_NatureOfOthers.Text = "";
                            txt_NatureOfOthers.Enabled = false;
                        }

                        //***************************************************

                        RadioButton_Nature.SelectedValue = dss.Tables[0].Rows[0]["RB_CIF"].ToString();
                        if (RadioButton_Exporters.SelectedValue == "Others")
                        {
                            txt_exp_others.Text = dss.Tables[0].Rows[0]["RB_Exporter_Others"].ToString();
                        }
                        else
                        {
                            txt_exp_others.Text = "";
                            txt_exp_others.Enabled = false;
                        }

                        //***************************************************

                        RadioButton_Ship.SelectedValue = dss.Tables[0].Rows[0]["RB_OutRightSales"].ToString();
                        if (RadioButton_Ship.SelectedValue == "Others")
                        {
                            txt_Ship_Others.Text = dss.Tables[0].Rows[0]["RB_Ship_Others"].ToString();
                        }
                        else
                        {
                            txt_Ship_Others.Text = "";
                            txt_Ship_Others.Enabled = false;
                        }

                        //***************************************************

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btn_Report.Visible = true;
                    }
                }
                Grid_DataBind();
            }
        }
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedItem.Text != "Select")
        {
            Clear_SB_Duty_DBK();
            Get_AllDetails_SB_Duty_DBK();         
        }
        else
        {
            Alert_msg("Select the ShippingBill Type");
        }      
    }

    public static string DecimalToText(string decimalPart)
    {
       string[] digits = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
       string result = "";
       foreach(char c in decimalPart)
       {
           int i = (int)c - 48;
           if (i < 0 || i > 9) return ""; // invalid number, don't return anything
           result += " " + digits[i];
       }
       return result;
    }

    public static string NumberToText(int number, bool useAnd, bool useArab)
    {
        if (number == 0) return "Zero";

        string and = useAnd ? "and " : ""; // deals with using 'and' separator

        if (number == -2147483648) return "Minus Two Hundred " + and + "Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred " + and +"Forty Eight";

        int[] num = new int[4];
        int first = 0;
        int u, h, t;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        if (number < 0)
        {
            sb.Append("Minus ");
            number = -number;
        }
        string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ", "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
        string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen "};
        string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ","Eighty ", "Ninety "};
        string[] words3 = { "Thousand ", "Lakh ", "Crore " };
        num[0] = number % 1000; // units
        num[1] = number / 1000;
        num[2] = number / 100000;
        num[1] = num[1] - 100 * num[2]; // thousands
        num[3] = number / 10000000; // crores
        num[2] = num[2] - 100 * num[3]; // lakhs
        for (int i = 3; i > 0; i--)
        {
            if (num[i] != 0)
            {
                first = i;
                break;
            }
        }

        for (int i = first; i >= 0; i--)
        {
            if (num[i] == 0) continue;

            u = num[i] % 10; // ones 
            t = num[i] / 10;
            h = num[i] / 100; // hundreds
            t = t - 10 * h; // tens

            if (h > 0) sb.Append(words0[h] + "Hundred ");
            if (u > 0 || t > 0)
            {
                if (h > 0 || i < first) sb.Append(and);

                if (t == 0)
                    sb.Append(words0[u]);
                else if (t == 1)
                    sb.Append(words1[u]);
                else
                    sb.Append(words2[t - 2] + words0[u]);
            }
            if (i != 0) sb.Append(words3[i - 1]);
        }

        string temp = sb.ToString().TrimEnd();

        if (useArab && Math.Abs(number) >= 1000000000)
        {
            int index = temp.IndexOf("Hundred Crore");
            if (index > -1) return temp.Substring(0, index) + "Arab" + temp.Substring(index + 13);
            index = temp.IndexOf("Hundred");
            return temp.Substring(0, index) + "Arab" + temp.Substring(index + 7);
        } 
        return temp;
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

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            if (ddlType.SelectedItem.Text == "DutyFree")
            {
                lbl_Tarrif.Visible = false;
                lbl_Assesable_Value.Visible = false;
                lbl_GI_BondNo.Visible = false;
                lbl_Duty_Amount.Visible = false;
                lbl_Duty_Perc.Visible = false;
                lbl_dutyforgon.Visible = false;

                txt_DBK_Tarrif.Visible = false;
                txt_DBK_AssblValue.Visible = false;
                txt_Gi_BondNo.Visible = false;
                txt_DutyAmount.Visible = false;
                txt_DutyPercentage.Visible = false;
                txt_DutyForgon.Visible = false;
                txtRemarks.Visible = true;
                lbl_Remarks.Visible = true;
                lblVesselFlight.Text = "Vessel/Flight No";
                lblPlaceofDelivery.Text = "Port Of Discharge";
                lblRotation.Text = "Rotation No";


            }
            else if (ddlType.SelectedItem.Text == "Bill Of Export")
            {
                lbl_Tarrif.Visible = false;
                lbl_Assesable_Value.Visible = false;
                lbl_GI_BondNo.Visible = false;
                lbl_Duty_Amount.Visible = false;
                lbl_Duty_Perc.Visible = false;
                lbl_dutyforgon.Visible = false;

                txt_DBK_Tarrif.Visible = false;
                txt_DBK_AssblValue.Visible = false;
                txt_Gi_BondNo.Visible = false;
                txt_DutyAmount.Visible = false;
                txt_DutyPercentage.Visible = false;
                txt_DutyForgon.Visible = false;
                txtRemarks.Visible = true;
                lbl_Remarks.Visible = true;
                lblVesselFlight.Text = "Lorry/Train";
                lblPlaceofDelivery.Text = "Port Of Delivery";
                lblRotation.Text = "Land Cus Station";
            }
            else if (ddlType.SelectedItem.Text == "Drawback")
            {
                lbl_Tarrif.Visible = true;
                lbl_Assesable_Value.Visible = true;
                lbl_GI_BondNo.Visible = true;
                lbl_Duty_Amount.Visible = true;
                lbl_Duty_Perc.Visible = true;
                lbl_dutyforgon.Visible = true;

                txt_DBK_Tarrif.Visible = true;
                txt_DBK_AssblValue.Visible = true;
                txt_Gi_BondNo.Visible = true;
                txt_DutyAmount.Visible = true;
                txt_DutyPercentage.Visible = true;
                txt_DutyForgon.Visible = true;
                txtRemarks.Visible = false;
                lbl_Remarks.Visible = false;
                lblVesselFlight.Text = "Lorry/Train";
                lblPlaceofDelivery.Text = "Port Of Delivery";
                lblRotation.Text = "Land Cus Station";


            }

            else if (ddlType.SelectedItem.Text == "Select")
            {
                Clear_SB_Duty_DBK();

                lbl_Tarrif.Visible = true;
                lbl_Assesable_Value.Visible = true;
                lbl_GI_BondNo.Visible = true;
                lbl_Duty_Amount.Visible = true;
                lbl_Duty_Perc.Visible = true;
                lbl_dutyforgon.Visible = true;

                txt_DBK_Tarrif.Visible = true;
                txt_DBK_AssblValue.Visible = true;
                txt_Gi_BondNo.Visible = true;
                txt_DutyAmount.Visible = true;
                txt_DutyPercentage.Visible = true;
                txt_DutyForgon.Visible = true;

            }
            Clear_SB_Duty_DBK();
            Get_AllDetails_SB_Duty_DBK();
        }
        else
        {
            Alert_msg("Select JobNo");
            btn_Report.Visible = false;
        }
    }

    public void Clear_SB_Duty_DBK()
    {

        txt_InvoiceNo_Date.Text = "";
        txt_ShippingBillNo_Date.Text = "";
        txtExporters_References.Text = "";
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
        txt_CustomHouseAgent.Text = "";
        txt_LIC_No.Text = "";
        txt_PrecarriageBy.Text = "";
        txtVessel_Flight_No.Text = "";
        txt_PortDischarge.Text = "";
        txtAR_No_Date.Text = "";
        txt_QCertNo_Date.Text = "";
        txt_Export_Trade.Text = "";
        txtPlace_ReceiptBy_PreCarrier.Text = "";
        txt_Rotation_No.Text = "";
        txtPort_Of_Loading.Text = "";
        txtCountry_Final_Destination.Text = "";
        txt_Import_Export_BIN.Text = "";
        txt_RBICodeNo.Text = "";
        //RB_Def_Credit.Text = "";
        //RB_Joint.Text = "";
        //RB_Rupees_Credit.Text = "";
        //RB_Export_Others.Text = "";
        //RB_OutRightSales.Text = "";
        //RB_Consignment.Text = "";
        //RB_Ship_others.Text = "";
        //RB_CIF.Text = "";
        //RB_CFR.Text = "";
        //RB_FOB.Text = "";
        //RB_Nature_Others.Text = "";
        txt_Ex_Rate_US.Text = "";
        txt_InvoiceCurrency.Text = "";
        txt_InvoiceAmount1.Text="";
        txt_RBIApprovalNo.Text = "";
        txt_NetWeight.Text = "";
        txt_GrossWeight.Text = "";
        txtFOB_In_Words.Text = "";
        txt_CIF_FOB_Currency.Text = "";
        txt_CIF_FOB_Amount.Text = "";
        txt_Currency.Text = "";
        txt_Amount.Text = "";
        txtFOBValue_Currency.Text = "";
        txtFOBValue_Amount.Text = "";
        txtFreight_Currency.Text = "";
        txtFreight_Amount.Text = "";
        txtInsurance_Currency.Text = "";
        txtInsurance_Amount.Text = "";

        txtCommission_Currency.Text = "";
        txtCommission_Amount.Text = "";
        txtDiscount_Currency.Text = "";
        txtDiscount_Amount.Text = "";
        txt_Otherdeduction_Currency.Text = "";
        txt_Otherdeduction_Amount.Text = "";
        txt_GR_No.Text = "";
        txt_Gi_BondNo.Text = "";
        txt_Declaration_Clause.Text = "";
        txt_public_Notice.Text = "";
        txt_public_Date.Text = "";
        txtRemarks.Text = "";
        txt_DBK_Tarrif.Text = "";
        txt_DBK_AssblValue.Text = "";
        txt_DutyPercentage.Text = "";
        txt_DutyAmount.Text = "";
        txt_DutyForgon.Text = "";
        txtAR_No_Date2.Text = "";
        txt_QCertNo_Date2.Text = "";      

    }

    protected void GV_Details_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
            //e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
            //e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;

            //e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            //e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.GV_Details, "Select$" + e.Row.RowIndex.ToString()));
            //if (e.Row.RowIndex == 0)
            //    e.Row.Style.Add("height", "30px");

        }
    }

    protected void GV_Details_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void GV_Details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Details.PageIndex = e.NewPageIndex;
        //Gridbind_INVOICE();
        //gv_Invoice.DataBind();
    }

    private void Empty_grid()
    {
        DataTable dt = new DataTable();
        GV_Details.DataSource = dt;
        GV_Details.DataBind();
        //GV_Details.Attributes.Add("style", "table-layout:fixed");
    }

    private void Grid_Update()
    {
        if (Page.IsPostBack)
        {

            SB.JOBNO = ddlJobNo.SelectedItem.Text;          
            SB.Sb_TYPE = ddlType.SelectedItem.Text;
            SB.WORKING_PERIOD = Working_Period;
            SB.BRANCH_CODE = currentbranch;
            SB.BRANCH_COMMON = SELECT_BRANCH;
            SB.flag = "Get_SB_DBK_DUTYFREE_GRID";

            ds = SB.Retreive_SB_Duty_DBK();

            int total_Rows = GV_Details.Rows.Count;

            for (int r = 0; r < total_Rows; r++)
            {
                if (rowChanged[r])
                {
                    GridViewRow thisGridViewRow = GV_Details.Rows[r];
                    HiddenField hf1 = (HiddenField)thisGridViewRow.FindControl("HiddenField1");
                    //string[] pk = hf1.Value.Split(',');

                    string id = ds.Tables[0].Rows[r]["ID"].ToString();

                    System.Web.UI.WebControls.TextBox txt_ItemSlNo = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txt_ItemSlNo");
                    System.Web.UI.WebControls.TextBox txt_MARKS_NO = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txt_MARKS_NO");
                    System.Web.UI.WebControls.TextBox txt_ITEM_DESCRIPTION = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txt_ITEM_DESCRIPTION");
                    System.Web.UI.WebControls.TextBox txt_RITCNO = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txt_RITCNO");
                    System.Web.UI.WebControls.TextBox txt_ITEM_QTY = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txt_ITEM_QTY");
                    //System.Web.UI.WebControls.TextBox txt_ITEM_QTY_CODE = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txt_ITEM_QTY_CODE");
                    System.Web.UI.WebControls.TextBox txt_FOB_VALUE = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txt_FOB_VALUE");


                    SB.ID = id;
                    SB.JOBNO = ddlJobNo.SelectedItem.Text;
                    SB.Sb_TYPE = ddlType.SelectedItem.Text;
                    //SB.ITEM_SLNO = txt_ItemSlNo.Text;
                    SB.MARKS_NO = txt_MARKS_NO.Text;
                    SB.ITEM_DESCRIPTION = txt_ITEM_DESCRIPTION.Text;
                    SB.RITCNO = txt_RITCNO.Text;
                    SB.ITEM_QTY = txt_ITEM_QTY.Text;
                    //SB.ITEM_QTY_CODE = txt_ITEM_QTY_CODE.Text;
                    SB.FOB_VALUE = txt_FOB_VALUE.Text;

                    SB.BRANCH_CODE = currentbranch;
                    SB.WORKING_PERIOD = Working_Period;
                    SB.YEAR = "ccc";
                    SB.USER_ID = currentuser;
                    SB.LOGINDATE = "";
                   
                   
                    SB.BRANCH_COMMON = SELECT_BRANCH;
                    SB.flag = "U";

                    SB.SB_Duty_Dbk_Grid_Insert_Update();
                }
            }
            GV_Details.DataBind();
            //Grid_DataBind_Finalize();
            Grid_DataBind();
        }
    }

}