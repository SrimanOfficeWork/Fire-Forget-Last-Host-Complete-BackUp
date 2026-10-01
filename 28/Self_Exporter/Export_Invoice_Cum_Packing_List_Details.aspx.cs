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

public partial class Export_Invoice_Cum_Packing_List_Details : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    Rpt_Invoice inv = new Rpt_Invoice();
    DataTable dt = new DataTable();
    DataRow dr;//= dt.NewRow();
    DataSet dss = new DataSet();
    DataSet dtuser = new DataSet();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    public int i, Screen_Id;

 
    public string FILE_REF_NO, BRANCH_NO, IEC_NO, TRANSPORT_MODE;

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    Self_Exporter_BO SEBOV = new Self_Exporter_BO();   //SEBOV Means SELF_EXPORTER Business Object Variables    
    Self_Exporter SEOM = new Self_Exporter();          //SEOM  Means SELF_EXPORTER Object Methods

    
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE, COMPANY_LICENSE;    

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;
    public bool chk = false;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            hdn_Jobno.Value = "1";

            COMPANY_LICENSE = Connection.Company_License().ToLower();
            Hd_Company_Id.Value = Connection.COMPANYID();


            if (!Page.IsPostBack)
            {
                GV1.DataSource = dt;
                GV1.DataBind();
                GV.DataSource = dt;//No need rows
                GV.DataBind();


                if (Request.QueryString["Page"] == null)
                {
                    HDupdate_id.Value = "";
                    
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnrpt.Visible = false;
                    txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtIRN.Visible = false;

                    Get_JobNo();

                    SetInitialRow();
                }
                else
                {
                    if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                    {
                        Update_Item_Load();
                        btnDelete.Visible = true;
                        btnUpdate.Visible = true;
                        btnrpt.Visible = true;
                        btnSave.Visible = false;
                        ddlJobNo.Text = "Nil";
                    }
                }
                Read_Only_Some_Textboxs();
            }
            //txtexporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtexporterName.ClientID + "', '" + txtexporterName.ClientID + "')");
            txtInvoiceCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExchangeRate.ClientID + "')");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
    
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

        dt.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("ORDERBY", typeof(string)));
        dt.Columns.Add(new DataColumn("PKGS", typeof(string)));
        dt.Columns.Add(new DataColumn("PKGS_UNIT", typeof(string)));
        dt.Columns.Add(new DataColumn("CHARGE_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("QTY", typeof(string)));
        dt.Columns.Add(new DataColumn("QTY_UNIT", typeof(string)));
        dt.Columns.Add(new DataColumn("BOX", typeof(string)));
        dt.Columns.Add(new DataColumn("BOX_UNIT", typeof(string)));
        dt.Columns.Add(new DataColumn("NET_WT", typeof(string)));
        dt.Columns.Add(new DataColumn("SPL_PERCENTAGE", typeof(string)));
        dt.Columns.Add(new DataColumn("GR_WT", typeof(string)));
        dt.Columns.Add(new DataColumn("RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("CIF_AMOUNT", typeof(string)));

       dr = dt.NewRow();
        dr["INV_CHECK"] = true;
        dr["RowNumber"] = 1;
        dr["ORDERBY"] = 1;
        dr["PKGS"] = "";
        dr["PKGS_UNIT"] = "PKG";
        dr["CHARGE_NAME"] = "";
        dr["QTY"] = "";
        dr["QTY_UNIT"] = "KG";
        dr["BOX"] = "";
        dr["BOX_UNIT"] = "BOX";
        dr["NET_WT"] = "";
        dr["SPL_PERCENTAGE"] = "";
        dr["GR_WT"] = "";
        dr["RATE"] = "";
        dr["CIF_AMOUNT"] = "";

        dt.Rows.Add(dr);
        ViewState["CurrentTable"] = dt;


        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();
    }
    
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;
        string Emptyrow = string.Empty, T_N = string.Empty;
        string[] arr = new string[] { };

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    CheckBox INV_CHECK = (CheckBox)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("chk_inv");
                    TextBox txtOrder_by = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtOrder_by");
                    TextBox txtPkgs = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtPkgs");
                    DropDownList ddlPKGS_UNIT = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("ddlPKGS_UNIT");
                    TextBox txtch_name = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txtch_name");

                    TextBox txtQty = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txtQty");
                    DropDownList ddlQty_Unit = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("ddlQty_Unit");
                    TextBox txtBox = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txtBox");
                    DropDownList ddlBox_Unit = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("ddlBox_Unit");
                    TextBox txtNetwt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtNetwt");
                    TextBox txtSpecialCommissionPercent = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[11].FindControl("txtSpecialCommissionPercent");
                    TextBox txtGrwt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[12].FindControl("txtGrwt");
                    TextBox txtRate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtRate");
                    TextBox txtCIF = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[14].FindControl("txtCIF");

                    if (txtQty.Text == string.Empty || txtQty.Text == "0.00")
                    {
                        Emptyrow = "Y";
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["INV_CHECK"] = INV_CHECK.Checked == true ? "True" : "False";
                    drCurrentRow["RowNumber"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["ORDERBY"] = txtOrder_by.Text;
                    dtCurrentTable.Rows[i - 1]["PKGS"] = txtPkgs.Text.ToString();
                    dtCurrentTable.Rows[i - 1]["PKGS_UNIT"] = ddlPKGS_UNIT.SelectedValue.ToString();
                    dtCurrentTable.Rows[i - 1]["CHARGE_NAME"] = txtch_name.Text;
                    dtCurrentTable.Rows[i - 1]["QTY"] = txtQty.Text.ToString();
                    dtCurrentTable.Rows[i - 1]["QTY_UNIT"] = ddlQty_Unit.SelectedValue.ToString();
                    dtCurrentTable.Rows[i - 1]["BOX"] = txtBox.Text.ToString();
                    dtCurrentTable.Rows[i - 1]["BOX_UNIT"] = ddlBox_Unit.SelectedValue.ToString();
                    dtCurrentTable.Rows[i - 1]["NET_WT"] = txtNetwt.Text.ToString();
                    dtCurrentTable.Rows[i - 1]["SPL_PERCENTAGE"] = txtSpecialCommissionPercent.Text.ToString();
                    dtCurrentTable.Rows[i - 1]["GR_WT"] = txtGrwt.Text.ToString();
                    dtCurrentTable.Rows[i - 1]["RATE"] = txtRate.Text.ToString();
                    dtCurrentTable.Rows[i - 1]["CIF_AMOUNT"] = txtCIF.Text.ToString();

                    rowIndex++;

                }
                if (Emptyrow != "Y")
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["INV_CHECK"] = "True";
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    drCurrentRow["ORDERBY"] = dtCurrentTable.Rows.Count + 1;
                    drCurrentRow["PKGS"] = string.Empty;
                    drCurrentRow["PKGS_UNIT"] = "PKG";
                    drCurrentRow["CHARGE_NAME"] = "";
                    drCurrentRow["QTY"] = "";
                    drCurrentRow["QTY_UNIT"] = "KG";
                    drCurrentRow["BOX"] = "";
                    drCurrentRow["BOX_UNIT"] = "BOX";
                    drCurrentRow["NET_WT"] = "";
                    drCurrentRow["SPL_PERCENTAGE"] = "";
                    drCurrentRow["GR_WT"] = "";
                    drCurrentRow["RATE"] = "";
                    drCurrentRow["CIF_AMOUNT"] = "";

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gv_Chg_Details.DataSource = dtCurrentTable;
                    gv_Chg_Details.DataBind();

                    int index1 = gv_Chg_Details.Rows.Count - 1;
                    gv_Chg_Details.Rows[index1].Cells[1].Text = Convert.ToString(gv_Chg_Details.Rows.Count);
                    gv_Chg_Details.Rows[index1].Cells[1].FindControl("txtPkgs").Focus();
                }
                else
                {
                    Alert_msg("Enter the value in Empty Row");
                }

            }
        }
        SetPreviousData();
    }

    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CheckBox INV_CHECK = (CheckBox)gv_Chg_Details.Rows[rowIndex].Cells[0].FindControl("chk_inv");
                    TextBox txtOrder_by = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtOrder_by");
                    TextBox txtPkgs = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtPkgs");
                    DropDownList ddlPKGS_UNIT = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("ddlPKGS_UNIT");
                    TextBox txtch_name = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtch_name");
                    TextBox txtQty = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txtQty");
                    DropDownList ddlQty_Unit = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("ddlQty_Unit");
                    TextBox txtBox = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtBox");
                    DropDownList ddlBox_Unit = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("ddlBox_Unit");
                    TextBox txtNetwt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtNetwt");
                    TextBox txtSpecialCommissionPercent = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtSpecialCommissionPercent");
                    TextBox txtGrwt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[11].FindControl("txtGrwt");
                    TextBox txtRate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[12].FindControl("txtRate");
                    TextBox txtCIF = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtCIF");   
                    //--------------------------------------------------------------------
                    gv_Chg_Details.Rows[i].Cells[1].Text = Convert.ToString(i + 1);
                    txtOrder_by.Text = dt.Rows[i]["ORDERBY"].ToString();
                    txtPkgs.Text = dt.Rows[i]["PKGS"].ToString();
                    ddlPKGS_UNIT.Text = dt.Rows[i]["PKGS_UNIT"].ToString();
                    txtch_name.Text = dt.Rows[i]["CHARGE_NAME"].ToString();
                    txtQty.Text = dt.Rows[i]["QTY"].ToString();
                    ddlQty_Unit.Text = dt.Rows[i]["QTY_UNIT"].ToString();
                    txtBox.Text = dt.Rows[i]["BOX"].ToString();
                    ddlBox_Unit.Text = dt.Rows[i]["BOX_UNIT"].ToString();
                    txtNetwt.Text = dt.Rows[i]["NET_WT"].ToString();
                    txtSpecialCommissionPercent.Text = dt.Rows[i]["SPL_PERCENTAGE"].ToString();
                    txtGrwt.Text = dt.Rows[i]["GR_WT"].ToString();
                    txtRate.Text = dt.Rows[i]["RATE"].ToString();
                    txtCIF.Text = dt.Rows[i]["CIF_AMOUNT"].ToString();
                    rowIndex++;
                }
            }
        }
    }
    public void Get_JobNo()
    {
        Export_CheckList CHKLIST = new Export_CheckList();
        CHKLIST.JOBNo = "";
        CHKLIST.Ename = "select_jobno";
        //CHKLIST.Workingperiod = SELECT_BRANCH;
        ddlJobNo.DataSource = CHKLIST.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();

        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Nil");


        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }


    private void Update_Item_Load()
    {
        try
        {
        DataSet dss = new DataSet();
        ObjUBO.JOBNO = Request.QueryString["Page"].ToString();
        ObjUBO.BILL_INV_NO = Request.QueryString["Billinvno"].ToString();
        ObjUBO.Flag = "Self_Exporter_Update_Select";
        //dss = BI.Select_Exp_INV(ObjUBO);
        dss = SEOM.SELECT_SELF_EXPORTER_INV_CUM_PACKING_LIST(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            //ddlTerms.SelectedValue = dss.Tables[0].Rows[0]["TERMS"].ToString();

            HDupdate_id.Value = dss.Tables[0].Rows[0]["ID"].ToString();
            HdtxtInvoiceNo_id.Value = dss.Tables[0].Rows[0]["ID"].ToString();
            Hdjobno.Value = dss.Tables[0].Rows[0]["JOBNO"].ToString();

            ddlJobNo.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["JOBNO"].ToString(), dss.Tables[0].Rows[0]["JOBNO"].ToString()));
            ddlJobNo.SelectedIndex = 0;
            txtInvoiceNo_Date.Text = dss.Tables[0].Rows[0]["INVOICE_NO"].ToString();
            hd_BILL_INV_NO.Value = txtInvoiceNo_Date.Text;
            txtDate.Text = dss.Tables[0].Rows[0]["INVOICE_DATE"].ToString();

            txtExporters_Ref.Text = dss.Tables[0].Rows[0]["EXPORTERS_REF"].ToString();
            txtBuyerOrderNo_Date.Text = dss.Tables[0].Rows[0]["BUYER_ORDER_NO_DATE"].ToString();
            txtOther_References.Text = dss.Tables[0].Rows[0]["OTHER_REFERENCES"].ToString();
            txtInvoiceName.Text = dss.Tables[0].Rows[0]["INVOICE_NAME"].ToString();

            txtexporterName.Text = dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
            hdexp_Brslno.Value = dss.Tables[0].Rows[0]["EXPORTER_BRANCH_NO"].ToString();
            txtexporter_Add1.Text = dss.Tables[0].Rows[0]["EXPORTER_ADD1"].ToString();

            txtconsigneename.Text = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            hdconsignee_Brslno.Value = dss.Tables[0].Rows[0]["CONSIGNEE_BRANCH_NO"].ToString();
            txtConsignee_Add1.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();

            txtBuyerName.Text = dss.Tables[0].Rows[0]["BUYER_NAME"].ToString();
            hdBuyer_Brslno.Value = dss.Tables[0].Rows[0]["BUYER_BRANCH_NO"].ToString();
            txtBuyer_Add1.Text = dss.Tables[0].Rows[0]["BUYER_ADD1"].ToString();

            txtImportername.Text = dss.Tables[0].Rows[0]["NOTIFY_NAME"].ToString();
            hdNotify_Brslno.Value = dss.Tables[0].Rows[0]["NOTIFY_BRANCH_NO"].ToString();
            txtNotify_Add1.Text = dss.Tables[0].Rows[0]["NOTIFY_ADD1"].ToString();
            txtPre_Carriageby.Text = dss.Tables[0].Rows[0]["PRE_CARRIAGE_BY"].ToString();
            txtPlace_ReceiptBy_PreCarrier.Text = dss.Tables[0].Rows[0]["PLACE_OF_RECEIPT"].ToString();

            txtVessel_Flight_No.Text = dss.Tables[0].Rows[0]["VESSEL_FLIGHT_NO"].ToString();
            txtPort_Of_Discharge.Text = dss.Tables[0].Rows[0]["PORT_OF_DISCHARGE"].ToString();
            txtPort_Of_Loading.Text = dss.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
            txtFinal_Destination.Text = dss.Tables[0].Rows[0]["FINAL_DEST"].ToString();
            txtCountry_Origin_Goods.Text = dss.Tables[0].Rows[0]["COUNTRY_OF_ORIGIN"].ToString();

            txtCountry_Final_Destination.Text = dss.Tables[0].Rows[0]["COUNTRY_OF_FINAL_DEST"].ToString();
            txtTerms_Delivery_Payment.Text = dss.Tables[0].Rows[0]["TERMS_OF_DELIVERY_PAYMENT"].ToString();
            txtInvoiceCurrency.Text = dss.Tables[0].Rows[0]["CURRENCY"].ToString();
            txtExchangeRate.Text = dss.Tables[0].Rows[0]["CUR_VALUE"].ToString();
            txtCommonCommissionPercent.Text = dss.Tables[0].Rows[0]["COMMON_PERCENTAGE"].ToString();

            txtTotalPkgs.Text = dss.Tables[0].Rows[0]["TOTAL_PACKAGES"].ToString();
            hdtxtTotalPkgsUnit.Value = dss.Tables[0].Rows[0]["TOTAL_PACKAGES_UNIT"].ToString();
            txtTotalNetwt.Text = dss.Tables[0].Rows[0]["TOTAL_NET_WT"].ToString();
            txtTotalGrwt.Text = dss.Tables[0].Rows[0]["TOTAL_GR_WT"].ToString();
            txtTotalCIF.Text = dss.Tables[0].Rows[0]["TOTAL_CIF"].ToString();

            txtWords.Text = dss.Tables[0].Rows[0]["WORDS"].ToString();

            txtPackage_Range.Text = dss.Tables[0].Rows[0]["PACKAGE_RANGE"].ToString();
            txtCIF_FOREIGN.Text = dss.Tables[0].Rows[0]["CIF_FOREIGN"].ToString();
            txtCIF_LOCAL.Text = dss.Tables[0].Rows[0]["CIF_LOCAL"].ToString();
            txtFRT_FOREIGN.Text = dss.Tables[0].Rows[0]["FRT_FOREIGN"].ToString();

            txtFRT_LOCAL.Text = dss.Tables[0].Rows[0]["FRT_LOCAL"].ToString();
            txtINS_FOREIGN.Text = dss.Tables[0].Rows[0]["INS_FOREIGN"].ToString();
            txtINS_LOCAL.Text = dss.Tables[0].Rows[0]["INS_LOCAL"].ToString();
            txtFOB_FOREIGN.Text = dss.Tables[0].Rows[0]["FOB_FOREIGN"].ToString();
            txtFOB_LOCAL.Text = dss.Tables[0].Rows[0]["FOB_LOCAL"].ToString();
            txtRemarks.Text = dss.Tables[0].Rows[0]["REMARKS"].ToString();


        }
        gv_Chg_Details.Visible = true;

        if (dss.Tables[1].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[1];
            gv_Chg_Details.DataBind();

            DataTable firstTable = dss.Tables[1];
            ViewState["CurrentTable"] = firstTable;
        }
        else
        {
            SetInitialRow();
        }

        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    
    protected void btnloadData_Click(object sender, EventArgs e)
    {       
        ddl_changed();       
        
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //ObjUBO.ID = HDupdate_id.Value.ToString();
            //ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
            //ObjUBO.BILL_INV_NO = txtInvoiceNo_Date.Text;
            //ObjUBO.Flag = "D";
            Self_Exporter_Billing_Insert_Update("D", HDupdate_id.Value);
            
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Re_Inv = string.Empty;

        if (txtexporterName.Text != "" && hdexp_Brslno.Value != string.Empty)
        {
            if (HDupdate_id.Value == "")//first time Save then only call 
            {
                HDupdate_id.Value = "1";//Pass as dummy
            }
            if (txtInvoiceNo_Date.Text != string.Empty)
            {
                Self_Exporter_Billing_Insert_Update("S", Product_details());
                if (i == 1)
                {
                    ViewState["UPDATED_ID"] = null;
                    HD_Showcon.Value = "SAVED";
                    Alert_msg("Saved Successfully", "btnSave");
                    HDupdate_id.Value = Convert.ToString(SEOM.UPDATE_ID);
                    hd_BILL_INV_NO.Value = txtInvoiceNo_Date.Text;
                    btnrpt.Visible = true;
                    txtInvoiceNo_Date.Attributes.Add("readonly", "readonly");
                    txtInvoiceNo_Date.Style.Add("background-color", "#F0F0F0");
                    txtInvoiceNo_Date.Style.Add("background-color", "white");
                }
                else if (i == 2)
                {
                    Alert_msg("Invoice No Already Exist!", "btnSave");
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
            else
            {
                Alert_msg("Enter Ur Invoice Number and Date!", "txtInvoiceNo_Date");
            }
        }
        else
        {
            Alert_msg("Select Exporter Name or Branch !", "txtexporterName");
        }        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (gv_Chg_Details.Rows.Count > 0)
            {
                i = Self_Exporter_Billing_Insert_Update("U", Product_details());
                if (i == 1)
                {
                    Alert_msg("Updated Successfully");                    
                    Update_Item_Load();
                    btnrpt.Visible = true;
                    txtInvoiceNo_Date.Attributes.Add("readonly", "readonly");
                    txtInvoiceNo_Date.Style.Add("background-color", "#F0F0F0");
                    txtInvoiceNo_Date.Style.Add("background-color", "white");
                }
                else
                {
                    Alert_msg("Not Updated");
                }
            }
            else
            {
                Alert_msg("No Records found in Packing List grid");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public int Self_Exporter_Billing_Insert_Update(string S1, String xmlData_D)
    {
        //ObjUBO = TBOV;
        //ObjUBO.IMPORTER_NAME = ddlImp_name.SelectedValue.ToString();
        //ObjUBO.MODE = ddl_tr_mode.SelectedValue.ToString();
        string Wrk = string.Empty;
        Wrk = Connection.WorkingPeriod();

        SEBOV.ID = HDupdate_id.Value.ToString();

        //if (COMPANY_LICENSE != "eri02198")
        //{
            SEBOV.BILL_INV_NO = txtInvoiceNo_Date.Text;
            SEBOV.BILL_INV_DATE = txtDate.Text == null ? string.Empty : txtDate.Text;
        //}
        //else{
        //}
                    
        SEBOV.JOBNO = ddlJobNo.SelectedValue.ToString();

        SEBOV.INVOICE_NO = txtInvoiceNo_Date.Text;
        SEBOV.INVOICE_DATE = txtDate.Text == null ? string.Empty : txtDate.Text;

        SEBOV.EXPORTERS_REF = txtExporters_Ref.Text;
        SEBOV.BUYER_ORDER_NO_DATE = txtBuyerOrderNo_Date.Text;
        SEBOV.OTHER_REFERENCES = txtOther_References.Text;
        SEBOV.INVOICE_NAME = txtInvoiceName.Text;

        SEBOV.EXPORTER_NAME = txtexporterName.Text;
        SEBOV.EXPORTER_BRANCH_NO = hdexp_Brslno.Value.ToString();
        SEBOV.EXPORTER_IEC_NO = hdexp_Brslno.Value.ToString();//Branch & Iec both are not same
        SEBOV.EXPORTER_ADD1 = txtexporter_Add1.Text;
        SEBOV.CONSIGNEE_NAME = txtconsigneename.Text;
        SEBOV.CONSIGNEE_BRANCH_NO = hdconsignee_Brslno.Value.ToString();
        SEBOV.CONSIGNEE_ADD1 = txtConsignee_Add1.Text;
        SEBOV.BUYER_NAME = txtBuyerName.Text;
        SEBOV.BUYER_BRANCH_NO = hdBuyer_Brslno.Value.ToString();
        SEBOV.BUYER_ADD1 = txtBuyer_Add1.Text;

        SEBOV.NOTIFY_NAME = txtImportername.Text;//for notify
        SEBOV.NOTIFY_BRANCH_NO = hdNotify_Brslno.Value.ToString();
        SEBOV.NOTIFY_ADD1 = txtNotify_Add1.Text;
        SEBOV.PRE_CARRIAGE_BY = txtPre_Carriageby.Text;
        SEBOV.PLACE_OF_RECEIPT = txtPlace_ReceiptBy_PreCarrier.Text;

        SEBOV.VESSEL_FLIGHT_NO = txtVessel_Flight_No.Text;
        SEBOV.PORT_OF_DISCHARGE = txtPort_Of_Discharge.Text;
        SEBOV.PORT_OF_LOADING = txtPort_Of_Loading.Text;
        SEBOV.FINAL_DEST = txtFinal_Destination.Text;
        SEBOV.COUNTRY_OF_ORIGIN = txtCountry_Origin_Goods.Text;

        SEBOV.COUNTRY_OF_FINAL_DEST = txtCountry_Final_Destination.Text;
        SEBOV.TERMS_OF_DELIVERY_PAYMENT = txtTerms_Delivery_Payment.Text;
        SEBOV.CURRENCY = txtInvoiceCurrency.Text;
        SEBOV.CUR_VALUE = txtExchangeRate.Text;
        SEBOV.COMMON_PERCENTAGE = txtCommonCommissionPercent.Text;

        SEBOV.TOTAL_PACKAGES = txtTotalPkgs.Text;
        SEBOV.TOTAL_PACKAGES_UNIT = hdtxtTotalPkgsUnit.Value.ToString();//Unit 
        SEBOV.TOTAL_NET_WT = txtTotalNetwt.Text;
        SEBOV.TOTAL_GR_WT = txtTotalGrwt.Text;
        SEBOV.TOTAL_CIF = txtTotalCIF.Text;

        SEBOV.WORDS = txtWords.Text;

        SEBOV.PACKAGE_RANGE = txtPackage_Range.Text;
        SEBOV.CIF_FOREIGN = txtCIF_FOREIGN.Text;
        SEBOV.CIF_LOCAL = txtCIF_LOCAL.Text;
        SEBOV.FRT_FOREIGN = txtFRT_FOREIGN.Text;

        SEBOV.FRT_LOCAL = txtFRT_LOCAL.Text;
        SEBOV.INS_FOREIGN = txtINS_FOREIGN.Text;
        SEBOV.INS_LOCAL = txtINS_LOCAL.Text;
        SEBOV.FOB_FOREIGN = txtFOB_FOREIGN.Text;
        SEBOV.FOB_LOCAL = txtFOB_LOCAL.Text;
        SEBOV.REMARKS = txtRemarks.Text;
        
        //// 9 field value not passed
        SEBOV.CREATEDON = DateTime.Now.ToString("dd/MMM/yyyy");
        SEBOV.CREATEDBY = Connection.Current_User();
        SEBOV.MODIFIEDBY = Connection.Current_User();
        SEBOV.MODIFIEDON = DateTime.Now.ToString("dd/MMM/yyyy");


        SEBOV.Flag = S1;
        SEBOV.Xml_D = xmlData_D;

        SEOM.SELF_EXPORTER_INVOICE_CUM_PACKING_LIST_INS_UPD(SEBOV);
        i = SEOM.result;

        return i;
    }
    private string Product_details()// TRANSPORT CHARGE DETAILS
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));
        dtt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dtt.Columns.Add(new DataColumn("ORDERBY", typeof(string)));
        dtt.Columns.Add(new DataColumn("PKGS", typeof(string)));
        dtt.Columns.Add(new DataColumn("PKGS_UNIT", typeof(string)));
        dtt.Columns.Add(new DataColumn("CHARGE_NAME", typeof(string)));
        dtt.Columns.Add(new DataColumn("QTY", typeof(string)));
        dtt.Columns.Add(new DataColumn("QTY_UNIT", typeof(string)));
        dtt.Columns.Add(new DataColumn("BOX", typeof(string)));
        dtt.Columns.Add(new DataColumn("BOX_UNIT", typeof(string)));
        dtt.Columns.Add(new DataColumn("NET_WT", typeof(string)));
        dtt.Columns.Add(new DataColumn("SPL_PERCENTAGE", typeof(string)));
        dtt.Columns.Add(new DataColumn("GR_WT", typeof(string)));
        dtt.Columns.Add(new DataColumn("RATE", typeof(string)));
        dtt.Columns.Add(new DataColumn("CIF_AMOUNT", typeof(string)));

        int R = 1;
        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {


            CheckBox INV_CHECK = (CheckBox)row.FindControl("chk_inv");

            TextBox txtOrder_by = (TextBox)row.FindControl("txtOrder_by");
            TextBox txtPkgs = (TextBox)row.FindControl("txtPkgs");
            DropDownList ddlPKGS_UNIT = (DropDownList)row.FindControl("ddlPKGS_UNIT");
            TextBox txtch_name = (TextBox)row.FindControl("txtch_name");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            DropDownList ddlQty_Unit = (DropDownList)row.FindControl("ddlQty_Unit");
            TextBox txtBox = (TextBox)row.FindControl("txtBox");
            DropDownList ddlBox_Unit = (DropDownList)row.FindControl("ddlBox_Unit");
            TextBox txtNetwt = (TextBox)row.FindControl("txtNetwt");
            TextBox txtSpecialCommissionPercent = (TextBox)row.FindControl("txtSpecialCommissionPercent");
            TextBox txtGrwt = (TextBox)row.FindControl("txtGrwt");
            TextBox txtRate = (TextBox)row.FindControl("txtRate");
            TextBox txtCIF = (TextBox)row.FindControl("txtCIF");

            dr = dtt.NewRow();
            dr[0] = INV_CHECK.Checked == true ? "True" : "False";
            dr[1] = R;
            dr[2] = txtOrder_by.Text;
            dr[3] = txtPkgs.Text;
            dr[4] = ddlPKGS_UNIT.SelectedValue.ToString();
            dr[5] = txtch_name.Text;
            dr[6] = txtQty.Text;
            dr[7] = ddlQty_Unit.SelectedValue.ToString();
            dr[8] = txtBox.Text;
            dr[9] = ddlBox_Unit.SelectedValue.ToString();
            dr[10] = txtNetwt.Text;
            dr[11] = txtSpecialCommissionPercent.Text;
            dr[12] = txtGrwt.Text;
            dr[13] = txtRate.Text;
            dr[14] = txtCIF.Text;           


            dtt.Rows.Add(dr);
            R = R + 1;
            
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }

    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        StringBuilder sbSQL;
        StringWriter swSQL;
        string XMLformat;
        try
        {
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
            dsData.Tables[0].TableName = "SampleDataTable";
            foreach (DataColumn col in dsData.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
            XMLformat = sbSQL.ToString();
            return XMLformat;
        }
        catch (Exception sysException)
        {
            throw sysException;
        }
    }
    

   
   
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        
    }

    [System.Web.Services.WebMethod]
    public static string Get_Importer(string custid, string Jobno, string Branch)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Name_Search = custid;
        Auto.Flag = "IMP_Billing_IMPORTER_NAME_SEARCH";
        Auto.Branch = Branch;
        ds = Auto.Export_Billing_Mastersearch();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address1 = ds.Tables[0].Rows[0]["IMPORTER_ADDRESS"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();

            string State = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
            custid = Address1 + "~~" + Address2 + "~~" + State;
        }
        else
        {
            custid = "";
        }

        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Importer_other(string custid, string Mode, string Branch)
    {
        GST_Imp_Invoice BI = new GST_Imp_Invoice();
        Billing_UserBO ObjUBO = new Billing_UserBO();

        if (custid != string.Empty)
        {
            DataSet dss = new DataSet();
            ObjUBO.Flag = "GST_Imp_Other_Invoice_Autoid";

            if (HttpContext.Current.Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString() == "A")
            {
                ObjUBO.BILL_INV_NO = "Air";
            }
            else if (HttpContext.Current.Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString() == "S")
            {
                ObjUBO.BILL_INV_NO = "Sea";
            }
            else if (HttpContext.Current.Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString() == "L")
            {
                ObjUBO.BILL_INV_NO = "Land";
            }
            dss = BI.Select_IMP_INV(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                if (Connection.Company_License().ToLower() == "eri00381" || Connection.Company_License().ToLower() == "eri00420")
                {
                    custid = "";
                }
                else
                {
                    custid = dss.Tables[0].Rows[0]["Autoid"].ToString();
                }
            }
            else
            {
                custid = string.Empty;
            }
        }
        else
        {
            custid = string.Empty;
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Supplier(string custid, string Jobno)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();

        Auto.Name_Search = custid;
        Auto.Flag = "IMP_SUPPLIER_NAME_SEARCH";
        Auto.Branch = Connection.Get_Company_Type();

        ds = Auto.Export_Billing_Mastersearch();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS"].ToString();
            custid = Address;
        }
        else
        {
            custid = "";
        }
        return custid;
    }
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    private void clear_Other_Inv()
    {
        
    }
    [System.Web.Services.WebMethod]
    public static string GetImporter(string custid, string Branch)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Name_Search = custid;
        Auto.Flag = "IMP_BILLING_IMPORTER_NAME_SEARCH";
        Auto.Branch = Branch;
        ds = Auto.Export_Billing_Mastersearch();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address = ds.Tables[0].Rows[0]["IMPORTER_ADDRESS"].ToString();
            custid = Address;
        }
        else
        {
            custid = "";
        }

        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Cha_Type(string ChargeName, string Imp_Name, string Mode)
    {
        string Ch_Name = "";
        DataSet ds = new DataSet();
        try
        {
            GST_Imp_Invoice BI = new GST_Imp_Invoice();
            Billing_UserBO ObjUBO = new Billing_UserBO();

            ObjUBO.Imp_Name = ChargeName;
            ObjUBO.Flag = "GST_Imp_EXP_Charge_type";
            ds = BI.Select_IMP_INV(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Ch_Name = ds.Tables[0].Rows[0]["TAX_MODE"].ToString() + "~~" + ds.Tables[0].Rows[0]["HSN_CODE"].ToString() + "~~" + ds.Tables[0].Rows[0]["SA_CODE"].ToString() + "~~" + ds.Tables[0].Rows[0]["CGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["SGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
            }
            else
            {
                Ch_Name = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Ch_Name;
    }
    
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item_id = e.Row.Cells[0].Text;
        }
    }

    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
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


    protected void gv_Chg_Details_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                // drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;

                /*gv_Chg_Details.DataSource = dt;
                gv_Chg_Details.DataBind();*/

                SetPreviousData();

            }
        }
    }


    public void ddl_changed()
    {

    }
    

    public void Alert_msg(string msg)
    {        
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'INVOICE CUM PACKING LIST', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {     
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'INVOICE CUM PACKING LIST', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }    
    

    [System.Web.Services.WebMethod]
    public static string Inv_Refresh(string Inv)
    {
        DataSet ds = new DataSet();
        GST_Imp_Invoice BI = new GST_Imp_Invoice();
        Billing_UserBO ObjUBO = new Billing_UserBO();

        ObjUBO.Flag = "Refresh_Invoice";
        ds = BI.Select_IMP_INV(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            return "";
        }
    }

    [System.Web.Services.WebMethod]
    public static string Get_Exporter(string custid, string Jobno, string Branch)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Name_Search = custid;
        Auto.Flag = "IMP_Billing_IMPORTER_NAME_SEARCH";
        Auto.Branch = Branch;
        ds = Auto.Export_Billing_Mastersearch();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address1 = ds.Tables[0].Rows[0]["IMPORTER_ADDRESS"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();

            string State = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
            custid = Address1 + "~~" + Address2 + "~~" + State;
        }
        else
        {
            custid = "";
        }

        return custid;
    }


    [System.Web.Services.WebMethod]
    public static string Get_ConsigneeName(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();      
        Auto.Ename = "CONSIGNEE_MASTER_SEARCH";
          Auto.Enamesearch = custid;
        //Auto.NSearch = Branchslno;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds.Tables[0].Rows.Count > 0)
        {

            string Address1 = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
            string Address3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString();
            string CONSIGNEE_PIN_CODE = ds.Tables[0].Rows[0]["CONSIGNEE_PIN_CODE"].ToString();

            custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5;
        }

        return custid;
    }


    [System.Web.Services.WebMethod]
        public static string Get_ConsigneeName(string custid, string Jobno, string Branchslno)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();

        if (Branchslno != "")
        {
            Auto.Ename = "CONSIGNEE_MASTER_SEARCH_with_BRANCH_SLNO";
        }
        else
        {
            Auto.Ename = "CONSIGNEE_MASTER_SEARCH";
        }
        
        Auto.Enamesearch = custid;
        Auto.NSearch = Branchslno;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString() + "\r\n" + ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString() + "\r\n" + ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString() + "\r\n" + ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString() + "\r\n" + ds.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString() + "\r\n" + ds.Tables[0].Rows[0]["CONSIGNEE_PIN_CODE"].ToString();                    
            custid = Address1 ;
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Buyer(string custid, string Jobno, string Branch)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Name_Search = custid;
        Auto.Flag = "IMP_Billing_IMPORTER_NAME_SEARCH";
        Auto.Branch = Branch;
        ds = Auto.Export_Billing_Mastersearch();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address1 = ds.Tables[0].Rows[0]["IMPORTER_ADDRESS"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();

            string State = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
            custid = Address1 + "~~" + Address2 + "~~" + State;
        }
        else
        {
            custid = "";
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Notify(string custid, string Jobno, string Branch)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Name_Search = custid;
        Auto.Flag = "IMP_Billing_IMPORTER_NAME_SEARCH";
        Auto.Branch = Branch;
        ds = Auto.Export_Billing_Mastersearch();
        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address1 = ds.Tables[0].Rows[0]["IMPORTER_ADDRESS"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["GSTN_ID"].ToString();

            string State = ds.Tables[0].Rows[0]["M_COMMERCIAL_TAX_STATENAME"].ToString();
            custid = Address1 + "~~" + Address2 + "~~" + State;
        }
        else
        {
            custid = "";
        }

        return custid;
    }


    private void Read_Only_Some_Textboxs()
    {        
        txtTotalPkgs.Attributes.Add("readonly", "readonly");
        txtTotalPkgs.Style.Add("background-color", "#F0F0F0");

        txtTotalNetwt.Attributes.Add("readonly", "readonly");
        txtTotalNetwt.Style.Add("background-color", "#F0F0F0");

        txtTotalGrwt.Attributes.Add("readonly", "readonly");
        txtTotalGrwt.Style.Add("background-color", "#F0F0F0");

        txtTotalCIF.Attributes.Add("readonly", "readonly");
        txtTotalCIF.Style.Add("background-color", "#F0F0F0");


        //txtWords.Attributes.Add("readonly", "readonly");
        //txtWords.Style.Add("background-color", "#F0F0F0");

        txtCIF_FOREIGN.Attributes.Add("readonly", "readonly");
        txtCIF_FOREIGN.Style.Add("background-color", "#F0F0F0");

        txtCIF_LOCAL.Attributes.Add("readonly", "readonly");
        txtCIF_LOCAL.Style.Add("background-color", "#F0F0F0");

        txtFRT_LOCAL.Attributes.Add("readonly", "readonly");
        txtFRT_LOCAL.Style.Add("background-color", "#F0F0F0");

        txtINS_LOCAL.Attributes.Add("readonly", "readonly");
        txtINS_LOCAL.Style.Add("background-color", "#F0F0F0");

        txtFOB_FOREIGN.Attributes.Add("readonly", "readonly");
        txtFOB_FOREIGN.Style.Add("background-color", "#F0F0F0");

        txtFOB_LOCAL.Attributes.Add("readonly", "readonly");
        txtFOB_LOCAL.Style.Add("background-color", "#F0F0F0");
    }

    [System.Web.Services.WebMethod]
    public static string txtInvoiceCurrency_TextChanged(string Tcur,string TW,string TTemp)    
    {        
        DataSet dss = new DataSet();        
        adminmaster erm = new adminmaster();
        erm.Invoice_Currency = Tcur;
        //erm.Ename = "IMPORT_INVOICE_EX_RATE";
        erm.Ename = "Ex_Rate";
        erm.EWorking_Period = TW;
        string res="";
        dss = erm.RetrieveAll_Exchange_master_INV_Currency();
        if (dss.Tables[0].Rows.Count > 0)
        {
            res = dss.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
        }
        return res;
    }

}