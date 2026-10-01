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

public partial class Credit_Note : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    GST_Imp_Invoice_Credit_Note BI = new GST_Imp_Invoice_Credit_Note();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE,COMPANY_LICENSE;

    decimal tax_amt, non_tax_amt, gst_toal, Reverse_total;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        hdn_Jobno.Value = "1";

        COMPANY_LICENSE = Connection.Company_License().ToLower();
        Hd_Company_Id.Value = Connection.COMPANYID();

        CalendarExtender1.EndDate = DateTime.Today;

        Rd_Job_Status.Items[0].Attributes.Add("style", "color:red;");
        Rd_Job_Status.Items[1].Attributes.Add("style", "color:green;");

        Rd_Inv_Status.Items[0].Attributes.Add("style", "color:red;");
        Rd_Inv_Status.Items[1].Attributes.Add("style", "color:green;");

        if (!Page.IsPostBack)
        {
            DataTable dtt = new DataTable();
            GV.DataSource = dtt;
            GV.DataBind();

            GV1.DataSource = dtt;
            GV1.DataBind();
          
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnrpt.Visible = false;
            txtimportername_Other.Visible = false;

            T.Visible = false;
            txt_branch_No.Attributes.Add("readonly", "readonly");
            txt_branch_No.Style.Add("background-color", "#F0F0F0");

            if (COMPANY_LICENSE != "eri00287" && COMPANY_LICENSE != "eri00314" && COMPANY_LICENSE != "eri00381" && COMPANY_LICENSE != "eri00010" && COMPANY_LICENSE != "eri00677" && COMPANY_LICENSE != "eri03094")
            {
                txtInvoiceNo.Attributes.Add("readonly", "readonly");
                txtInvoiceNo.Style.Add("background-color", "#F0F0F0");
            }

            txt_tot_Rev_Amt.Attributes.Add("readonly", "readonly");
            txtnon_tax_amt.Attributes.Add("readonly", "readonly");
            txttax_amt.Attributes.Add("readonly", "readonly");
            txt_Expense_Amt.Attributes.Add("readonly", "readonly");

            HD_Bill_Jobno.Value = string.Empty;

            //Accounts Type Location 1 Start
            if (COMPANY_LICENSE == "eri00268" || COMPANY_LICENSE == "eri00353" || COMPANY_LICENSE == "eri00507" || COMPANY_LICENSE == "eri00677" || COMPANY_LICENSE == "eri01157" || COMPANY_LICENSE == "eri01316" || COMPANY_LICENSE == "eri01613" || COMPANY_LICENSE == "eri02085" || COMPANY_LICENSE == "eri03094")
            {
                ddlAccounts_Type.Visible = true;
            }
            else
            {
                ddlAccounts_Type.Visible = false;
            }
            //Accounts Type Location 1 End

            if (Request.QueryString["Page"] == null)
            {
                if (Connection.Billing_Working_Period() == "Y")
                {
                    WK.Visible = true;
                    LoadFinancialYear();
                    ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();
                }

               load_Imp_name();
               load_date();
               txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                HDupdate_id.Value = "";
                HdtxtInvoiceNo_id.Value = "";

                hd_hss_br_sl_no.Value = "";
                div_type_Other.Visible = false;

                if (COMPANY_LICENSE != "eri00146" || COMPANY_LICENSE != "eri00010")
                {
                    Chk_BWC_Tr.Visible = true;
                }
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();

                    btnloadData.Visible = false;
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlImp_name.Enabled = false;
                    ddljobno.Enabled = false;
                    Rd_Bill_Type.Enabled = false;

                    ddlbranch_No.Enabled=false;
                    ddl_tr_mode.Enabled=false;
                    ddlshipment_type.Enabled = false;

                    HD_Showcon.Value = "SAVED";
                    btnrpt.Visible = true;

                    HD_Bill_Jobno.Value = txtInvoiceNo.Text;

                    /*
                    if (COMPANY_LICENSE != "eri00287" || COMPANY_LICENSE != "eri00653" )
                    {
                        txtDate.Attributes.Add("readonly", "readonly");
                        txtDate.Style.Add("background-color", "#F0F0F0");
                        CalendarExtender1.Enabled = false;
                        MaskedEditExtender1.Enabled = false;
                        txtInvoiceNo.Attributes.Add("readonly", "readonly");
                        txtInvoiceNo.Style.Add("background-color", "#F0F0F0");
                    }
                    */
                }
            }
        }
        txtImportername.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtImportername.ClientID + "', '" + txtInvoiceNo.ClientID + "')");
        txtsuppliername.Attributes.Add("onblur", "javascript:CallServerside_Supplier('" + txtsuppliername.ClientID + "', '" + txtCon_Add1.ClientID + "')");

        txt_IMP_notify_party_1.Attributes.Add("onblur", "javascript:CallServerside_IMP_notify_party_1_Add('" + txt_IMP_notify_party_1.ClientID + "', '" + txtCon_Add1.ClientID + "')");
        txtimportername_Other.Attributes.Add("onblur", "javascript:CallServerside_Importer_other('" + txtimportername_Other.ClientID + "', '" + txtInvoiceNo.ClientID + "')");
        txtInvoiceNo.Attributes.Add("onblur", "javascript:CallServerside_IMP_INVCHK('" + txtInvoiceNo.ClientID + "', '" + txtInvoiceNo.ClientID + "')");

        if (COMPANY_LICENSE == "eri00384" )
        {
            txtInvoiceNo.Attributes.Remove("readonly");
            txtInvoiceNo.Style.Add("background-color", "white");
            txtDate.Attributes.Remove("readonly");
            txtDate.Style.Add("background-color", "white");
            CalendarExtender1.Enabled = true;
            MaskedEditExtender1.Enabled = true;
        }
    }
    private void load_date()
    {
        DataSet dss = new DataSet();
        ObjUBO.Flag = "Imp_Bill_Date";
        dss = BI.Select_IMP_INV(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            if (COMPANY_LICENSE != "eri00314" && COMPANY_LICENSE != "eri00381" && COMPANY_LICENSE != "eri00420" && COMPANY_LICENSE != "eri00677" && COMPANY_LICENSE != "eri03094")
            {
                if (dss.Tables[0].Rows[0][0].ToString() != string.Empty)
                {
                    CalendarExtender1.StartDate = Convert.ToDateTime(dss.Tables[0].Rows[0][0].ToString());
                    HDinv_date.Value = dss.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    CalendarExtender1.StartDate = DateTime.Today;
                    HDinv_date.Value = DateTime.Today.ToString();
                }
                CalendarExtender1.EndDate = DateTime.Today;
            }
        }
        else
        {
            HDinv_date.Value = DateTime.Today.ToString();
        }
    }
    
    private void Update_Item_Load()
    {
        div_type_Other .Visible=false;

        DataSet dss = new DataSet();

        ObjUBO.JOBNO = Request.QueryString["Page"].ToString();
        ObjUBO.BILL_INV_NO =  Request.QueryString["Billinvno"].ToString();
        ObjUBO.Flag = "Inv_Imp_Jobno_Update_Select";
        dss = BI.Select_IMP_INV(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlTerms.SelectedValue = dss.Tables[0].Rows[0]["TERMS"].ToString();
            //-----------------------BA--S---------------------------------------
           // Billing_Approve(dss.Tables[0].Rows[0]["JOB_STATUS"].ToString(), dss.Tables[0].Rows[0]["UNAPPROVAL_APPROVED"].ToString());
            //-----------------------BA--E---------------------------------------

            HDupdate_id.Value = dss.Tables[0].Rows[0]["ID"].ToString();
            HdtxtInvoiceNo_id.Value = dss.Tables[0].Rows[0]["ID"].ToString();
            Hdjobno.Value = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();

            ddljobno.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString(), dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString()));
            ddljobno.SelectedIndex = 0;

            ddlImp_name.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString(), dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString()));
            ddlImp_name.SelectedIndex = 0;

            ddl_tr_mode .SelectedValue=dss.Tables[0].Rows[0]["MODE"].ToString();

            J_no = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            Imp_name = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();

            ddlbranch_No.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["BRANCH_NO_LOC"].ToString(), dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()));
            ddlbranch_No.SelectedIndex = 0;

            txtInvoiceNo.Text = dss.Tables[0].Rows[0]["CREDIT_BILL_INV_NO"].ToString();
            txtDate.Text = dss.Tables[0].Rows[0]["CREDIT_BILL_INV_DATE"].ToString();
            txtjob_invno.Text = dss.Tables[0].Rows[0]["INV_NO"].ToString();
            txtBeno.Text = dss.Tables[0].Rows[0]["BE_NO"].ToString();
            txtBedate.Text = dss.Tables[0].Rows[0]["BE_DATE"].ToString();
            txtHblno.Text = dss.Tables[0].Rows[0]["HBL_NO"].ToString();
            txtMblno.Text = dss.Tables[0].Rows[0]["MBL_NO"].ToString();
            txtconatiner_no.Text = dss.Tables[0].Rows[0]["CONTAINER_NO"].ToString();
            txtno_of_pkg.Text = dss.Tables[0].Rows[0]["NO_OF_PKG"].ToString();
            txtgross_wgt.Text = dss.Tables[0].Rows[0]["GROSS_WGT"].ToString();
            txtnetwgt.Text = dss.Tables[0].Rows[0]["NET_WGT"].ToString();
            txtvolume.Text = dss.Tables[0].Rows[0]["VOLUME"].ToString();
            txtvessel.Text = dss.Tables[0].Rows[0]["VESSEL"].ToString();
            txtdestination.Text = dss.Tables[0].Rows[0]["DESTINATION"].ToString();
            txtcommodity.Text = dss.Tables[0].Rows[0]["COMMODITY"].ToString();
            ddl_freight_status.SelectedValue = dss.Tables[0].Rows[0]["FREIGHT_STATUS"].ToString();

            if (dss.Tables[0].Rows[0]["AC_BEHALF"].ToString() == "Y")
            {
                ch_Behalf.Checked = true;
            }

            txtImportername.Text = dss.Tables[0].Rows[0]["SHIPPER_NAME"].ToString();
            txtShip_Add1.Text = dss.Tables[0].Rows[0]["SHIPPER_ADDRESS"].ToString();
            txtsuppliername.Text = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            txtCon_Add1.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADDRESS"].ToString();
            txt_IMP_notify_party_1.Text = dss.Tables[0].Rows[0]["NOTIFY_PARTY_1"].ToString();
            txt_notify_party_1_add.Text = dss.Tables[0].Rows[0]["NOTIFY_PARTY_1_ADDRESS"].ToString();
            txt_notify_party_2.Text = dss.Tables[0].Rows[0]["NOTIFY_PARTY_2"].ToString();
            txt_notify_party_2_add.Text = dss.Tables[0].Rows[0]["NOTIFY_PARTY_2_ADDRESS"].ToString();
            txt_Remarks.Text = dss.Tables[0].Rows[0]["REMARKS"].ToString();
            txtnon_tax_amt.Text = dss.Tables[0].Rows[0]["NON_TAXABLE_AMT"].ToString();
            txttax_amt.Text = dss.Tables[0].Rows[0]["TAXABLE_AMT"].ToString();

            txt_Adv_amt.Text = dss.Tables[0].Rows[0]["ADVANCE_AMT"].ToString();

            txt_total_tax_amt.Text = dss.Tables[0].Rows[0]["TOTAL_TAX_AMT"].ToString();
            txt_total_amt_With_tax.Text = dss.Tables[0].Rows[0]["TOTAL_AMT_TAX"].ToString();

            txtchargeWeight.Text = dss.Tables[0].Rows[0]["CHARGE_WGT"].ToString();
            txtchargeWeightType.Text = dss.Tables[0].Rows[0]["CHARGE_TYPE"].ToString();
            txtJob_Date.Text = dss.Tables[0].Rows[0]["JOB_DATE"].ToString();

            txt_Ass_Value.Text = dss.Tables[0].Rows[0]["ASS_VALUE"].ToString();
            txt_CIF_Value.Text = dss.Tables[0].Rows[0]["CIF_VALUE"].ToString();

            Rd_Bill_Type.SelectedValue = dss.Tables[0].Rows[0]["BILL_TYPE"].ToString();

            ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
            txt_GSTN_Id.Text = dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
            txt_Party_Ref.Text = dss.Tables[0].Rows[0]["PARTY_REF"].ToString();
            txt_Duty_Value.Text = dss.Tables[0].Rows[0]["DUTY_VALUE"].ToString();

            /*
            txt_MAWB_MBL_date.Text = dss.Tables[0].Rows[0]["HBL_NO_DATE"].ToString();
            txt_HAWB_HBL_date.Text = dss.Tables[0].Rows[0]["MBL_NO_DATE"].ToString();
            */
            txt_MAWB_MBL_date.Text = dss.Tables[0].Rows[0]["MBL_NO_DATE"].ToString();
            txt_HAWB_HBL_date.Text = dss.Tables[0].Rows[0]["HBL_NO_DATE"].ToString();


            txt_flight_Ara_Date.Text = dss.Tables[0].Rows[0]["FLIGHT_ARAIVAL_DATE"].ToString();
            txt_Con_Size.Text = dss.Tables[0].Rows[0]["CONTAINER_SIZE"].ToString();
            txt_Bond_No.Text = dss.Tables[0].Rows[0]["BOND_NO"].ToString();
            txt_Bond_date.Text = dss.Tables[0].Rows[0]["BOND_DATE"].ToString();
            txt_tot_Rev_Amt.Text = dss.Tables[0].Rows[0]["TOT_REVERSE_TAX_AMT"].ToString();
            From_Quotation.Checked = Convert.ToBoolean(dss.Tables[0].Rows[0]["FROM_QUOTATION"].ToString());

            txt_ur_Ref_No.Text = dss.Tables[0].Rows[0]["YOUR_REF"].ToString();
            txtPackageType.Text = dss.Tables[0].Rows[0]["NO_OF_PKG_TYPE"].ToString();
            txt_Gross_Wgt_Type.Text = dss.Tables[0].Rows[0]["GROSS_WGT_TYPE"].ToString();
            txt_Net_Wgt_Type.Text = dss.Tables[0].Rows[0]["NET_WGT_TYPE"].ToString();
            txt_Item_Desc.Text = dss.Tables[0].Rows[0]["ITEM_DESC"].ToString();
            ddlshipment_type.SelectedValue = dss.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString();
            txt_Vendor_Code.Text = dss.Tables[0].Rows[0]["VENDOR_CODE"].ToString();
            txt_Expense_Amt.Text = dss.Tables[0].Rows[0]["EXPENSE_AMT"].ToString();

            Rd_Job_Status.SelectedValue = dss.Tables[0].Rows[0]["JOB_STATUS"].ToString();
            Rd_Inv_Status.SelectedValue = dss.Tables[0].Rows[0]["UNAPPROVAL_APPROVED"].ToString();

            txtCountryShipment.Text = dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString();
            txtPortShipment.Text = dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
            txt_tr_details.Text = dss.Tables[0].Rows[0]["TR_DETAILS"].ToString();
            Rd_Tax_NonTax.SelectedValue = dss.Tables[0].Rows[0]["TAX_NONTAX"].ToString();

            txt_CFS_Charge.Text = dss.Tables[0].Rows[0]["CFS_CHARGE"].ToString();
            txt_Attachment.Text = dss.Tables[0].Rows[0]["ATTACHMENT_DET"].ToString();
            txt_PO_No.Text = dss.Tables[0].Rows[0]["PO_NO"].ToString();

            ddl_LCL_FCL.SelectedValue = dss.Tables[0].Rows[0]["LCL_FCL"].ToString();
            ddl_20_feet_Cnt.SelectedValue = dss.Tables[0].Rows[0]["TWENTY_FEET_CNT"].ToString();
            ddl_40_feet_Cnt.SelectedValue = dss.Tables[0].Rows[0]["FORTY_FEET_CNT"].ToString();
            Rd_Reg_Sez.SelectedValue = dss.Tables[0].Rows[0]["INV_TYPE"].ToString();
            lbl_Created_Modified.Text = dss.Tables[0].Rows[0]["Created_Modified"].ToString();

            //Accounts Type Location 4 Start
            if (COMPANY_LICENSE == "eri00268" || COMPANY_LICENSE == "eri00353" || COMPANY_LICENSE == "eri00507" || COMPANY_LICENSE == "eri00677" || COMPANY_LICENSE == "eri01157" || COMPANY_LICENSE == "eri01316" || COMPANY_LICENSE == "eri01613" || COMPANY_LICENSE == "eri02085" || COMPANY_LICENSE == "eri03094")
            {
                if (txt_PO_No.Text.ToUpper() == "CREDIT NOTE")
                {
                    ddlAccounts_Type.SelectedValue = "CN";
                }
                else
                {
                    if (txt_PO_No.Text.ToUpper() == "DEBIT NOTE")
                    {
                        ddlAccounts_Type.SelectedValue = "DN";
                    }
                    else
                    {

                    }
                }                    
            }
            else
            {
                //
            }
            //Accounts Type Location 4 End

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
   
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Height = 20;
        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        //txtfocus.Focus();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }

    private void AddNewRowToGrid()
    {
        int rowIndex = 0;
        gst_toal = 0;
        Reverse_total = 0;
        string Emptyrow = string.Empty;

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


                    TextBox txtch_name = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtch_name");
                    TextBox txt_charge_desc = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txt_charge_desc");

                    DropDownList ddl_tax_nontax = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("ddl_tax_nontax");
                    TextBox txt_HSN_Code = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txt_HSN_Code");
                    TextBox txt_SA_Code = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txt_SA_Code");

                    TextBox txtqty = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtqty");
                    DropDownList ddl_CUR = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("ddl_CUR");
                    TextBox txt_Ex_Rate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txt_Ex_Rate");
                    TextBox txtunit_price = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtunit_price");
                    TextBox txtamt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[11].FindControl("txtamt");
                    TextBox txtCGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[12].FindControl("txtCGST_RATE");
                    TextBox txtCGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtCGST_AMT");
                    TextBox txtSGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[14].FindControl("txtSGST_RATE");
                    TextBox txtSGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[15].FindControl("txtSGST_AMT");
                    TextBox txtIGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[16].FindControl("txtIGST_RATE");
                    TextBox txtIGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[17].FindControl("txtIGST_AMT");

                    string Amt = string.Empty;
                    if (txtamt.Text == string.Empty || txtamt.Text == "0" || txtamt.Text == "0.00")
                    {
                        Amt = string.Empty;
                    }
                    else
                    {
                        Amt = "Yes";
                    }

                    if (INV_CHECK.Checked == true)
                    {
                        if (txtch_name.Text == string.Empty || txtunit_price.Text == string.Empty || txtunit_price.Text == "0.00" || Amt == string.Empty)
                        {
                            Emptyrow = "Y";
                        }
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["INV_CHECK"] = INV_CHECK.Checked == true ? "True" : "False";
                    drCurrentRow["RowNumber"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["ORDERBY"] = txtOrder_by.Text;
                    
                    dtCurrentTable.Rows[i - 1]["CHARGE_NAME"] = txtch_name.Text;
                    dtCurrentTable.Rows[i - 1]["TAX_NONTAX"] = ddl_tax_nontax.SelectedValue.ToString();

                    dtCurrentTable.Rows[i - 1]["HSN_CODE"] = txt_HSN_Code.Text;
                    dtCurrentTable.Rows[i - 1]["SA_CODE"] = txt_SA_Code.Text;
                    
                    dtCurrentTable.Rows[i - 1]["QTY"] = txtqty.Text;
                    dtCurrentTable.Rows[i - 1]["CUR"] = ddl_CUR.SelectedValue.ToString();
                    dtCurrentTable.Rows[i - 1]["EX_RATE"] = txt_Ex_Rate.Text;
                    dtCurrentTable.Rows[i - 1]["UNIT_RATE"] = txtunit_price.Text;
                    dtCurrentTable.Rows[i - 1]["AMOUNT"] = txtamt.Text;
                    dtCurrentTable.Rows[i - 1]["CGST_RATE"] = txtCGST_RATE.Text;
                    dtCurrentTable.Rows[i - 1]["CGST_AMT"] = txtCGST_AMT.Text;
                    dtCurrentTable.Rows[i - 1]["SGST_RATE"] = txtSGST_RATE.Text;
                    dtCurrentTable.Rows[i - 1]["SGST_AMT"] = txtSGST_AMT.Text;
                    dtCurrentTable.Rows[i - 1]["IGST_RATE"] = txtIGST_RATE.Text;
                    dtCurrentTable.Rows[i - 1]["IGST_AMT"] = txtIGST_AMT.Text;
                    dtCurrentTable.Rows[i - 1]["CHARGE_DESC"] = txt_charge_desc.Text;
                    rowIndex++;

                    if (ddl_tax_nontax.SelectedValue.ToString() == "T" && INV_CHECK.Checked == true)
                    {

                        if (Rd_Bill_Type.SelectedValue.ToString() == "L")
                        {
                            gst_toal = gst_toal + (Convert.ToDecimal(txtCGST_AMT.Text == "" ? "0.00" : txtCGST_AMT.Text)
                                              + Convert.ToDecimal(txtSGST_AMT.Text == "" ? "0.00" : txtSGST_AMT.Text));
                        }
                        else
                        {
                            gst_toal = gst_toal + Convert.ToDecimal(txtIGST_AMT.Text == "" ? "0.00" : txtIGST_AMT.Text);
                        }
                        tax_amt += Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text);

                    }
                    else if (INV_CHECK.Checked == true && ddl_tax_nontax.SelectedValue.ToString() == "N")
                    {
                        non_tax_amt = non_tax_amt + Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text);
                    }
                    else if (INV_CHECK.Checked == true && ddl_tax_nontax.SelectedValue.ToString() == "E")
                    {
                        non_tax_amt = non_tax_amt + Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text);
                    }
                    else if (ddl_tax_nontax.SelectedValue.ToString() == "P" && INV_CHECK.Checked == true)
                    {
                        gst_toal = gst_toal + (Convert.ToDecimal(txtCGST_AMT.Text == "" ? "0.00" : txtCGST_AMT.Text)
                                              + Convert.ToDecimal(txtSGST_AMT.Text == "" ? "0.00" : txtSGST_AMT.Text)
                                              + Convert.ToDecimal(txtIGST_AMT.Text == "" ? "0.00" : txtIGST_AMT.Text));

                        tax_amt += Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text);
                    }
                    else if (ddl_tax_nontax.SelectedValue.ToString() == "R" && INV_CHECK.Checked == true)
                    {
                        if (Rd_Bill_Type.SelectedValue.ToString() == "L")
                        {
                            Reverse_total = Reverse_total + (
                                (Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text) * Convert.ToDecimal(txtCGST_RATE.Text == "" ? "0.00" : txtCGST_RATE.Text)/100)
                                + (Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text) * Convert.ToDecimal(txtSGST_RATE.Text == "" ? "0.00" : txtSGST_RATE.Text) / 100)
                                );
                        }
                        else
                        {
                            Reverse_total = Reverse_total + (
                            (Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text) * Convert.ToDecimal(txtIGST_RATE.Text == "" ? "0.00" : txtIGST_RATE.Text) / 100)
                            );
                        }

                        tax_amt += Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text);
                    }
                }
                if (Emptyrow != "Y")
                {
                   
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["INV_CHECK"] = "True";
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    drCurrentRow["ORDERBY"] = dtCurrentTable.Rows.Count + 1;

                    drCurrentRow["CHARGE_NAME"] = string.Empty;
                    drCurrentRow["TAX_NONTAX"] = "N";

                    drCurrentRow["HSN_CODE"] = "";
                    drCurrentRow["SA_CODE"] = "";
                    
                    drCurrentRow["QTY"] = "1";
                    drCurrentRow["CUR"] = "INR";
                    drCurrentRow["EX_RATE"] = "1";

                    drCurrentRow["UNIT_RATE"] = "0";
                    drCurrentRow["AMOUNT"] = "0";

                    drCurrentRow["CGST_RATE"] = "0";
                    drCurrentRow["CGST_AMT"] = "0";
                    drCurrentRow["SGST_RATE"] = "0";
                    drCurrentRow["SGST_AMT"] = "0";

                    drCurrentRow["IGST_RATE"] = "0";
                    drCurrentRow["IGST_AMT"] = "0";
                    drCurrentRow["CHARGE_DESC"] = string.Empty;

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gv_Chg_Details.DataSource = dtCurrentTable;
                    gv_Chg_Details.DataBind();

                }
                else
                {
                    Alert_msg("Enter the value in Empty Row");
                }
                
                txtnon_tax_amt.Text = non_tax_amt.ToString();
                txttax_amt.Text = tax_amt.ToString();
                txt_total_tax_amt.Text = gst_toal.ToString();
                //-----------------------------
                txt_tot_Rev_Amt.Text = Reverse_total.ToString();

                //----------------------------
                txt_total_amt_With_tax.Text = (Convert.ToDecimal(txt_total_tax_amt.Text) + Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");
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
                    TextBox txtch_name = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("txtch_name");
                    TextBox txt_charge_desc = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("txt_charge_desc");

                    TextBox txtOrder_by = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtOrder_by");
                    DropDownList ddl_tax_nontax = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("ddl_tax_nontax");

                    TextBox txt_HSN_Code = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txt_HSN_Code");
                    TextBox txt_SA_Code = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txt_SA_Code");

                    TextBox txtqty = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txtqty");
                    DropDownList ddl_CUR = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("ddl_CUR");
                    TextBox txt_Ex_Rate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txt_Ex_Rate");

                    TextBox txtunit_price = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtunit_price");
                    TextBox txtamt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtamt");
                    TextBox txtCGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[11].FindControl("txtCGST_RATE");
                    TextBox txtCGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[12].FindControl("txtCGST_AMT");
                    TextBox txtSGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtSGST_RATE");
                    TextBox txtSGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[14].FindControl("txtSGST_AMT");
                    TextBox txtIGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[15].FindControl("txtIGST_RATE");
                    TextBox txtIGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[16].FindControl("txtIGST_AMT");
                    //--------------------------------------------------------------------

                    gv_Chg_Details.Rows[i].Cells[1].Text = Convert.ToString(i + 1);

                    txtch_name.Text = dt.Rows[i]["CHARGE_NAME"].ToString();
                    txtOrder_by.Text = dt.Rows[i]["ORDERBY"].ToString();
                    ddl_tax_nontax.SelectedValue = dt.Rows[i]["TAX_NONTAX"].ToString();

                    txt_HSN_Code.Text = dt.Rows[i]["HSN_CODE"].ToString();
                    txt_SA_Code.Text = dt.Rows[i]["SA_CODE"].ToString();

                    txtqty.Text = dt.Rows[i]["QTY"].ToString();
                    ddl_CUR.SelectedValue = dt.Rows[i]["CUR"].ToString();
                    txt_Ex_Rate.Text = dt.Rows[i]["EX_RATE"].ToString();

                    txtunit_price.Text = dt.Rows[i]["UNIT_RATE"].ToString();
                    txtamt.Text = dt.Rows[i]["AMOUNT"].ToString();
                    txtCGST_RATE.Text = dt.Rows[i]["CGST_RATE"].ToString();
                    txtCGST_AMT.Text = dt.Rows[i]["CGST_AMT"].ToString();
                    txtSGST_RATE.Text = dt.Rows[i]["SGST_RATE"].ToString();
                    txtSGST_AMT.Text = dt.Rows[i]["SGST_AMT"].ToString();
                    txtIGST_RATE.Text = dt.Rows[i]["IGST_RATE"].ToString();
                    txtIGST_AMT.Text = dt.Rows[i]["IGST_AMT"].ToString();

                    txt_charge_desc.Text = dt.Rows[i]["CHARGE_DESC"].ToString();
                    rowIndex++;
                }
            }
            TextBox txtch_namefocus = (TextBox)gv_Chg_Details.Rows[rowIndex - 1].Cells[3].FindControl("txtch_name");
            txtch_namefocus.Focus();
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
        string Re_Inv = string.Empty;

                        if (ddlImp_name.SelectedItem.Text != "" && ddlbranch_No.SelectedValue.ToString() != string.Empty)
                        {
                            if (txtInvoiceNo.Text != string.Empty)
                            {
                                //--------------------------------------------------------------------------------------------------------------------------

                                    Billing_Invoice_Jobno_Insert_Update(Imp_name, "S", Product_details());
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
                                        HDupdate_id.Value = Convert.ToString(BI.UPDATE_ID);
                                        HdtxtInvoiceNo_id.Value = Convert.ToString(BI.UPDATE_ID);

                                        btnrpt.Visible = true;

                                        F.Visible = false;
                                        T.Visible = true;

                                        HD_Bill_Jobno.Value = txtInvoiceNo.Text;

                                        ddlImp_name.Attributes.Add("readonly", "readonly");
                                        ddlImp_name.Style.Add("background-color", "#F0F0F0");

                                        ddljobno.Attributes.Add("readonly", "readonly");
                                        ddljobno.Style.Add("background-color", "#F0F0F0");

                                        From_Quotation.Attributes.Add("readonly", "readonly");
                                        From_Quotation.Style.Add("background-color", "#F0F0F0");

                                        txtimportername_Other.Attributes.Add("readonly", "readonly");
                                        txtimportername_Other.Style.Add("background-color", "#F0F0F0");

                                        txtInvoiceNo.Attributes.Add("readonly", "readonly");
                                        txtInvoiceNo.Style.Add("background-color", "#F0F0F0");

                                        ddlImp_name.Enabled = false;
                                        ddljobno.Enabled = false;

                                        ddlbranch_No.Attributes.Add("readonly", "readonly");
                                        ddlbranch_No.Style.Add("background-color", "#F0F0F0");
                                        ddl_tr_mode.Attributes.Add("readonly", "readonly");
                                        ddl_tr_mode.Style.Add("background-color", "#F0F0F0");
                                        ddlshipment_type.Attributes.Add("readonly", "readonly");
                                        ddlshipment_type.Style.Add("background-color", "#F0F0F0");

                                        ddlbranch_No.Enabled = false;
                                        ddl_tr_mode.Enabled = false;
                                        ddlshipment_type.Enabled = false;

                                        btnloadData.Visible = false;
                                        //Billing_Approve(Rd_Job_Status.SelectedValue.ToString(), Rd_Inv_Status.SelectedValue.ToString());
                                    }
                                    else if (i == 2)
                                    {
                                        if (COMPANY_LICENSE == "eri00480" || COMPANY_LICENSE == "eri00188" || COMPANY_LICENSE == "eri00653" || COMPANY_LICENSE == "eri01019" || COMPANY_LICENSE == "eri01011")
                                        {
                                            btn_Re_Inv_No.Visible = true;
                                        }
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
                            else
                            {
                                Alert_msg("Enter Ur Invoice Number!", "txtInvoiceNo");
                            }
                        }
                        else
                        {
                            Alert_msg("Select Importer Name or Branch !", "ddlImp_name");
                        }
                    //-------------------------------------------------------------------------------------
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
                    i = Billing_Invoice_Jobno_Insert_Update(Imp_name ,"U"  , Product_details());
                    if (i == 1)
                    {
                        //Billing_Approve(Rd_Job_Status.SelectedValue.ToString(), Rd_Inv_Status.SelectedValue.ToString());
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
            ObjUBO.ID = HDupdate_id.Value.ToString();
            ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
            ObjUBO.IMPORTER_NAME = ddlImp_name.SelectedItem.Text;
            ObjUBO.BILL_INV_NO = txtInvoiceNo.Text;
            ObjUBO.Flag = "D";
            ObjUBO.HBL_NO_DATE = string.Empty;
            ObjUBO.MBL_NO_DATE = string.Empty;
            ObjUBO.FLIGHT_ARAIVAL_DATE = string.Empty;
            ObjUBO.BOND_DATE = string.Empty;

            BI.Imp_Billing_Invoice_INS_UPD(ObjUBO);
            i = BI.result;

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
    private string Product_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("INV_CHECK", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("TAX_NONTAX", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("HSN_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("SA_CODE", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("QTY", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CUR", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("EX_RATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("UNIT_RATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("AMOUNT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CGST_RATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CGST_AMT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("SGST_RATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("SGST_AMT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGST_RATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGST_AMT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ROWNUM", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("ORDERBY", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_DESC", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            CheckBox INV_CHECK = (CheckBox)row.FindControl("chk_inv");
            TextBox txtch_name = (TextBox)row.FindControl("txtch_name");
            TextBox txt_charge_desc = (TextBox)row.FindControl("txt_charge_desc");

            DropDownList ddl_tax_nontax = (DropDownList)row.FindControl("ddl_tax_nontax");

            TextBox txt_HSN_Code = (TextBox)row.FindControl("txt_HSN_Code");
            TextBox txt_SA_Code = (TextBox)row.FindControl("txt_SA_Code");

            TextBox txtqty = (TextBox)row.FindControl("txtqty");
            DropDownList ddl_CUR = (DropDownList)row.FindControl("ddl_CUR");
            TextBox txt_Ex_Rate = (TextBox)row.FindControl("txt_Ex_Rate");
            TextBox txtunit_price = (TextBox)row.FindControl("txtunit_price");
            TextBox txtamt = (TextBox)row.FindControl("txtamt");
            TextBox txtCGST_RATE = (TextBox)row.FindControl("txtCGST_RATE");
            TextBox txtCGST_AMT = (TextBox)row.FindControl("txtCGST_AMT");
            TextBox txtSGST_RATE = (TextBox)row.FindControl("txtSGST_RATE");
            TextBox txtSGST_AMT = (TextBox)row.FindControl("txtSGST_AMT");
            TextBox txtIGST_RATE = (TextBox)row.FindControl("txtIGST_RATE");
            TextBox txtIGST_AMT = (TextBox)row.FindControl("txtIGST_AMT");
            TextBox txtOrder_by = (TextBox)row.FindControl("txtOrder_by");

            if (txtch_name.Text == string.Empty && txtqty.Text == string.Empty && txtunit_price.Text == string.Empty && txtamt.Text == string.Empty)
            {

            }
            else
            {
                dr = dtt.NewRow();
                dr[0] = INV_CHECK.Checked == true ? "True" : "False";
                dr[1] = txtch_name.Text;
                dr[2] = ddl_tax_nontax.SelectedValue.ToString();

                dr[3] = txt_HSN_Code.Text;
                dr[4] = txt_SA_Code.Text;
                dr[5] = txtqty.Text;
                dr[6] = ddl_CUR.SelectedValue.ToString();
                dr[7] = txt_Ex_Rate.Text;

                dr[8] = txtunit_price.Text;
                dr[9] = txtamt.Text;
                dr[10] = txtCGST_RATE.Text;
                dr[11] = txtCGST_AMT.Text;
                dr[12] = txtSGST_RATE.Text;
                dr[13] = txtSGST_AMT.Text;
                dr[14] = txtIGST_RATE.Text;
                dr[15] = txtIGST_AMT.Text;
                dr[16] = R;
                dr[17] = txtOrder_by.Text;
                dr[18] = txt_charge_desc.Text;
                dtt.Rows.Add(dr);
                R = R + 1;
            }
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }

  
    public int Billing_Invoice_Jobno_Insert_Update(string I_Name , string S1, String xmlData_D )
    {
         ObjUBO.ID = HDupdate_id.Value.ToString();
         ObjUBO.IMPORTER_NAME = ddlImp_name.SelectedValue.ToString();
         ObjUBO.MODE = ddl_tr_mode.SelectedValue.ToString();
         
         ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
         ObjUBO.BILL_INV_NO = txtInvoiceNo.Text;

         ObjUBO.BILL_INV_DATE = txtDate.Text == null ? string.Empty : txtDate.Text;
         ObjUBO.INV_NO = txtjob_invno.Text;
         ObjUBO.INV_DATE = "01/01/1900";
         ObjUBO.BE_NO = txtBeno.Text;
         ObjUBO.BE_DATE = txtBedate.Text ==null ?string.Empty : txtBedate.Text;
         ObjUBO.HBLNO = txtHblno.Text; 
         ObjUBO.MBLNO =  txtMblno.Text;
         ObjUBO.CONTAINER_NO = txtconatiner_no.Text;
         ObjUBO.NO_OF_PKG = txtno_of_pkg.Text;
         ObjUBO.GROSS_WGT = txtgross_wgt.Text;
         ObjUBO.NET_WGT = txtnetwgt.Text;
         ObjUBO.VOLUME = txtvolume.Text;
         ObjUBO.VESSEL = txtvessel.Text;
         ObjUBO.DESTINATION = txtdestination.Text;
         ObjUBO.COMMODITY = txtcommodity.Text;
         ObjUBO.FREIGHT_STATUS = ddl_freight_status.SelectedItem.Text;
         ObjUBO.AC_BEHALF = ch_Behalf.Checked == true ? "Y" : "N";
         ObjUBO.SHIPPER_NAME = txtImportername.Text;
         ObjUBO.SHIPPER_ADDRESS = txtShip_Add1.Text;
         ObjUBO.CONSIGNEE_NAME = txtsuppliername.Text;
         ObjUBO.CONSIGNEE_ADDRESS = txtCon_Add1.Text;
         ObjUBO.NOTIFY_PARTY_1 = txt_IMP_notify_party_1.Text;
         ObjUBO.NOTIFY_PARTY_1_ADDRESS = txt_notify_party_1_add.Text;
         ObjUBO.NOTIFY_PARTY_2 = txt_notify_party_2.Text;
         ObjUBO.NOTIFY_PARTY_2_ADDRESS = txt_notify_party_2_add.Text;
         ObjUBO.REMARKS = txt_Remarks.Text;
         ObjUBO.NON_TAXABLE_AMT = txtnon_tax_amt.Text;
         ObjUBO.TAXABLE_AMT = txttax_amt.Text;
         ObjUBO.TOTAL_TAX_AMT = txt_total_tax_amt.Text;
         ObjUBO.TOTAL_AMT_TAX = txt_total_amt_With_tax.Text;

         ObjUBO.FILE_REF_NO = "0"; //N
        
         ObjUBO.CHARGE_WGT= txtchargeWeight.Text;
         ObjUBO.CHARGE_TYPE=txtchargeWeightType.Text;
         ObjUBO.JOBDATE = txtJob_Date.Text == null ? string.Empty : txtJob_Date.Text;
         ObjUBO.Ass_Value = txt_Ass_Value.Text;

         ObjUBO.CIF_VALUE = txt_CIF_Value.Text;
         ObjUBO.BILL_TYPE = Rd_Bill_Type.SelectedValue.ToString();
         ObjUBO.ADVANCE_AMT = txt_Adv_amt.Text;

         ObjUBO.Party_Ref = txt_Party_Ref.Text;
         ObjUBO.Duty_Value = txt_Duty_Value.Text;
         ObjUBO.State_Name = ddl_state_name.Text;
         ObjUBO.GSTN_ID = txt_GSTN_Id.Text;

         ObjUBO.Flag = S1;
         ObjUBO.Xml_D = xmlData_D;
        
         ObjUBO.HBL_NO_DATE = txt_HAWB_HBL_date.Text;
         ObjUBO.MBL_NO_DATE = txt_MAWB_MBL_date.Text;

         ObjUBO.FLIGHT_ARAIVAL_DATE = txt_flight_Ara_Date.Text;
         ObjUBO.CONTAINER_SIZE = txt_Con_Size.Text;
         ObjUBO.BOND_NO = txt_Bond_No.Text;
         ObjUBO.BOND_DATE = txt_Bond_date.Text;
         ObjUBO.TOT_REVERSE_TAX_AMT = txt_tot_Rev_Amt.Text;

         chk = From_Quotation.Checked;
         ObjUBO.FROM_QUOTATION = chk.ToString();

         if (ddljobno.SelectedValue.ToString() == "0")
         {
             ObjUBO.TYPE_OF_INVOICE = "Other";
         }
         else
         {
             ObjUBO.TYPE_OF_INVOICE = "Job";
         }

         ObjUBO.YOUR_REF = txt_ur_Ref_No.Text;
         ObjUBO.NO_OF_PKG_TYPE = txtPackageType.Text;
         ObjUBO.GROSS_WGT_TYPE = txt_Gross_Wgt_Type.Text;
         ObjUBO.NET_WGT_TYPE =txt_Net_Wgt_Type.Text;
         ObjUBO.ITEM_DESC = txt_Item_Desc.Text;
         ObjUBO.SHIPMENT_TYPE = ddlshipment_type.SelectedValue.ToString();
         ObjUBO.Branch_No = ddlbranch_No.SelectedValue.ToString();
         ObjUBO.Branch_No_Loc = ddlbranch_No.SelectedItem.ToString();

         ObjUBO.VENDOR_CODE = txt_Vendor_Code.Text;
         ObjUBO.EXPENSE_AMT = txt_Expense_Amt.Text;
         ObjUBO.JOB_STATUS = Rd_Job_Status.SelectedValue.ToString();

        if (Connection.Billing_Aproval_Company() == "Y")
         {
             if (Connection.Billing_Aproval_Admin() == "Y")
             {
                 ObjUBO.UNAPPROVAL_APPROVED = Rd_Inv_Status.SelectedValue.ToString();
             }
             else
             {
                 ObjUBO.UNAPPROVAL_APPROVED = "UA";
             }
         }
         else
         {
             ObjUBO.UNAPPROVAL_APPROVED = Rd_Inv_Status.SelectedValue.ToString();
         }

          ObjUBO.COUNTRY_SHIPMENT = txtCountryShipment.Text;
          ObjUBO.PORT_SHIPMENT = txtPortShipment.Text;
          ObjUBO.TR_DETAILS = txt_tr_details.Text;
          ObjUBO.TAX_NONTAX = Rd_Tax_NonTax.SelectedValue.ToString();

          ObjUBO.CFS_CHARGE = txt_CFS_Charge.Text;
          ObjUBO.ATTACHMENT_DET = txt_Attachment.Text;
          ObjUBO.PO_NO = txt_PO_No.Text;

          ObjUBO.LCL_FCL = ddl_LCL_FCL.SelectedValue.ToString();
          ObjUBO.TWENTY_FEET_CNT = ddl_20_feet_Cnt.SelectedValue.ToString();
          ObjUBO.FORTY_FEET_CNT = ddl_40_feet_Cnt.SelectedValue.ToString();
          ObjUBO.INV_TYPE = Rd_Reg_Sez.SelectedValue.ToString();
          ObjUBO.TERMS = ddlTerms.SelectedValue.ToString();
          if (Connection.Billing_Working_Period() == "Y" && S1 == "S")
          {
              ObjUBO.JOB_WORKINGPERIOD = ddlWorkingPeriod.SelectedItem.ToString();
          }
          
          BI.Imp_Billing_Invoice_INS_UPD(ObjUBO);
        i = BI.result;
        
        return i;
    }
    private void Clear()
    {
        cl();
        ddl_clear();
        HD_Bill_Jobno.Value = string.Empty;
    }
    private void cl()
    {
        txtchargeWeight.Text = string.Empty;
        txtchargeWeightType.Text = string.Empty;

        txtjob_invno.Text = string.Empty;
        txtInvoiceNo.Text = string.Empty;

        txtBeno.Text = string.Empty;
        txtBedate.Text = string.Empty;
        txtMblno.Text = string.Empty;
        txtHblno.Text = string.Empty;
        txtconatiner_no.Text = string.Empty;
        txtno_of_pkg.Text = string.Empty;
        txtgross_wgt.Text = string.Empty;
        txtnetwgt.Text = string.Empty;
        txtvolume.Text = string.Empty;
        txtvessel.Text = string.Empty;
        txtdestination.Text = string.Empty;
        txtcommodity.Text = string.Empty;
        ddl_freight_status.SelectedIndex = -1;
        ch_Behalf.Checked = false;
        txtImportername.Text = string.Empty;
        txtShip_Add1.Text = string.Empty;
        txtsuppliername.Text = string.Empty;
        txtCon_Add1.Text = string.Empty;

        txt_IMP_notify_party_1.Text = string.Empty;
        txt_notify_party_1_add.Text = string.Empty;
        txt_notify_party_2.Text = string.Empty;
        txt_notify_party_2_add.Text = string.Empty;
        txt_Remarks.Text = string.Empty;
        txtnon_tax_amt.Text = string.Empty;
        txttax_amt.Text = string.Empty;
        

        txt_total_tax_amt.Text = string.Empty;
        txt_total_amt_With_tax.Text = string.Empty;
        txtJob_Date.Text = string.Empty;
        txt_Ass_Value.Text = string.Empty;
        txt_CIF_Value.Text = string.Empty;
        txt_Party_Ref.Text = string.Empty;
        txt_Duty_Value.Text = string.Empty;
        ddl_state_name.Text = string.Empty;
        txt_GSTN_Id.Text = string.Empty;

        txt_MAWB_MBL_date.Text = string.Empty;
        txt_HAWB_HBL_date.Text = string.Empty;

        txt_flight_Ara_Date.Text = string.Empty;
        txt_Con_Size.Text = string.Empty;
        txt_Bond_No.Text = string.Empty;
        txt_Bond_date.Text = string.Empty;
        txt_tot_Rev_Amt.Text = string.Empty;

        txt_ur_Ref_No.Text = string.Empty;
        txtPackageType.Text = string.Empty;
        txt_Gross_Wgt_Type.Text = string.Empty;
        txt_Net_Wgt_Type.Text = string.Empty;
        txt_Item_Desc.Text = string.Empty;
        txt_Vendor_Code.Text = string.Empty;
        txt_Expense_Amt.Text = string.Empty;

        Rd_Job_Status.SelectedValue = "C";

        txtCountryShipment.Text=string.Empty;
        ObjUBO.PORT_SHIPMENT = string.Empty;
        ObjUBO.TR_DETAILS =string.Empty;

        txt_CFS_Charge.Text = string.Empty;
        txt_Attachment.Text = string.Empty;
        txt_PO_No.Text = string.Empty;

        ddl_LCL_FCL.SelectedIndex = -1;
        ddl_20_feet_Cnt.SelectedIndex = -1;
        ddl_40_feet_Cnt.SelectedIndex = -1;
    }
   
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "TAX_NONTAX").ToString() == "T")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
            }
            else
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#C0C0C0");
            }

            TextBox txtamt = (e.Row.FindControl("txtamt") as TextBox);
            TextBox txtCGST_AMT = (e.Row.FindControl("txtCGST_AMT") as TextBox);
            TextBox txtSGST_AMT = (e.Row.FindControl("txtSGST_AMT") as TextBox);
            TextBox txtIGST_AMT = (e.Row.FindControl("txtIGST_AMT") as TextBox);

            txtamt.Attributes.Add("readonly", "readonly");
            txtIGST_AMT.Attributes.Add("readonly", "readonly");
            txtCGST_AMT.Attributes.Add("readonly", "readonly");
            txtSGST_AMT.Attributes.Add("readonly", "readonly");
        }
    }
 
    private void load_Imp_name()
    {
        try
        {
            ddlImp_name.Items.Clear();
            ddljobno.Items.Clear();

            DataSet dss = new DataSet();
            ObjUBO.Flag = "Imp_Name_Select";

            if (Connection.Billing_Working_Period() == "Y")
            {
                dss = Database_Con_string();
            }
            else
            {
                dss = BI.Select_IMP_INV(ObjUBO);
            }

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlImp_name.DataSource = dss.Tables[0];
                ddlImp_name.DataTextField = "Imp_Name";
                ddlImp_name.DataValueField = "Imp_Name";
                ddlImp_name.DataBind();
                ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlImp_name.SelectedIndex = 0;
            }
            else
            {
                 ddl_clear();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   
    private void load_Branch()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.Imp_Name = ddlImp_name.SelectedValue.ToString();
            ObjUBO.Flag = "Imp_Job_Select";
            //-----------start-----------------
            if (Connection.Billing_Working_Period() == "Y")
            {
                dss = Database_Con_string();
            }
            else
            {
                dss = BI.Select_IMP_INV(ObjUBO);
            }
            //-----------end---------------------
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlbranch_No.DataSource = dss.Tables[0];
                ddlbranch_No.DataTextField = "ADDRESS3";
                ddlbranch_No.DataValueField = "BRANCH_NO";
                ddlbranch_No.DataBind();
            }
            else
            {
                ddlbranch_No.Items.Clear();
            }
            ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlbranch_No.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddlImp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Imp_Jobno();
    }

    private void Load_Imp_Jobno()
    {
         ddljobno.Items.Clear();
         ddlbranch_No.Items.Clear();
         DataSet ds = new DataSet();
        if (ddlImp_name.SelectedItem.Text != "")
        {

            ObjUBO.Imp_Name = ddlImp_name.SelectedValue.ToString();
            ObjUBO.JOBNO = "";
            ObjUBO.Flag = "Imp_Jobno_Select";
            //-----------start-----------------
            if (Connection.Billing_Working_Period() == "Y")
            {
                ds = Database_Con_string();
            }
            else
            {
                ds = BI.Select_IMP_INV(ObjUBO);
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = ds.Tables[0];
                ddljobno.DataTextField = "BILL_INV_NO";
                ddljobno.DataValueField = "BILL_INV_NO";
                ddljobno.DataBind();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlbranch_No.DataSource = ds.Tables[1];
                ddlbranch_No.DataTextField = "ADDRESS3";
                ddlbranch_No.DataValueField = "BRANCH_NO";
                ddlbranch_No.DataBind();
            }
            
        }

        ddljobno.Items.Insert(0, new ListItem(String.Empty, "0"));
        ddljobno.SelectedIndex = 0;
        ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlbranch_No.SelectedIndex = 0;
    }

    private void ddl_clear()
    {
        ddlImp_name.Items.Clear();
        ddlImp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlImp_name.SelectedIndex = 0;

        ddljobno.Items.Clear();
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;
    }
    private void Jobno_clear()
    {
        ddljobno.Items.Clear();
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;
    }

   
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

        dt.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("ORDERBY", typeof(string)));
        dt.Columns.Add(new DataColumn("CHARGE_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("TAX_NONTAX", typeof(string)));

        dt.Columns.Add(new DataColumn("HSN_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("SA_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("CUR", typeof(string)));
        dt.Columns.Add(new DataColumn("EX_RATE", typeof(string)));

        dt.Columns.Add(new DataColumn("UNIT_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("CGST_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("CGST_AMT", typeof(string)));
        dt.Columns.Add(new DataColumn("SGST_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("SGST_AMT", typeof(string)));
        dt.Columns.Add(new DataColumn("IGST_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("IGST_AMT", typeof(string)));
        dt.Columns.Add(new DataColumn("CHARGE_DESC", typeof(string)));

        dr = dt.NewRow();
        dr["INV_CHECK"] = "True";
        dr["RowNumber"] = 1;
        dr["ORDERBY"] = string.Empty;
        dr["CHARGE_NAME"] = string.Empty;
        dr["TAX_NONTAX"] = "N";

        dr["HSN_CODE"] = string.Empty;
        dr["SA_CODE"] = string.Empty;
        dr["Qty"] = "1";
        dr["CUR"] = "INR";
        dr["EX_RATE"] = "1";

        dr["UNIT_RATE"] = "0";
        dr["AMOUNT"] = "0";
        dr["CGST_RATE"] = "0";
        dr["CGST_AMT"] = "0";

        dr["SGST_RATE"] = "0";
        dr["SGST_AMT"] = "0";
        dr["IGST_RATE"] = "0";
        dr["IGST_AMT"] = "0";
        dr["CHARGE_DESC"] = string.Empty;

        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();

        txttax_amt.Text = "0.00";
        txtnon_tax_amt.Text = "0.00";
        txt_tot_Rev_Amt.Text = "0.00";

        txt_total_tax_amt.Text = "0.00";
        txt_total_amt_With_tax.Text = "0.00";
    }
    protected void gv_Chg_Details_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // SetRowData();
        gst_toal = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];

            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                ViewState["CurrentTable"] = dt;
                //---------------------------------------------------------------------------------------
                DataTable dtnew = new DataTable();
                DataRow drnew = null;

                dtnew.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));
                dtnew.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dtnew.Columns.Add(new DataColumn("ORDERBY", typeof(string)));

                dtnew.Columns.Add(new DataColumn("CHARGE_NAME", typeof(string)));
                dtnew.Columns.Add(new DataColumn("TAX_NONTAX", typeof(string)));
                dtnew.Columns.Add(new DataColumn("HSN_CODE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("SA_CODE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("Qty", typeof(string)));
                dtnew.Columns.Add(new DataColumn("CUR", typeof(string)));
                dtnew.Columns.Add(new DataColumn("EX_RATE", typeof(string)));

                dtnew.Columns.Add(new DataColumn("UNIT_RATE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("AMOUNT", typeof(string)));
                dtnew.Columns.Add(new DataColumn("CGST_RATE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("CGST_AMT", typeof(string)));
                dtnew.Columns.Add(new DataColumn("SGST_RATE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("SGST_AMT", typeof(string)));
                dtnew.Columns.Add(new DataColumn("IGST_RATE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("IGST_AMT", typeof(string)));
                dtnew.Columns.Add(new DataColumn("CHARGE_DESC", typeof(string)));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    drnew = dtnew.NewRow();

                    drnew["INV_CHECK"] = dt.Rows[i][0].ToString();
                    drnew["RowNumber"] = i + 1;
                    drnew["ORDERBY"] = dt.Rows[i][2].ToString();

                    drnew["CHARGE_NAME"] = dt.Rows[i][3].ToString();
                    drnew["TAX_NONTAX"] = dt.Rows[i][4].ToString();

                    drnew["HSN_CODE"] = dt.Rows[i][5].ToString();
                    drnew["SA_CODE"] = dt.Rows[i][6].ToString();
                    drnew["Qty"] = dt.Rows[i][7].ToString();
                    drnew["CUR"] = dt.Rows[i][8].ToString();
                    drnew["EX_RATE"] = dt.Rows[i][9].ToString();

                    drnew["UNIT_RATE"] = dt.Rows[i][10].ToString();
                    drnew["AMOUNT"] = dt.Rows[i][11].ToString();
                    drnew["CGST_RATE"] = dt.Rows[i][12].ToString();
                    drnew["CGST_AMT"] = dt.Rows[i][13].ToString();
                    drnew["SGST_RATE"] = dt.Rows[i][14].ToString();
                    drnew["SGST_AMT"] = dt.Rows[i][15].ToString();
                    drnew["IGST_RATE"] = dt.Rows[i][16].ToString();
                    drnew["IGST_AMT"] = dt.Rows[i][17].ToString();
                    drnew["CHARGE_DESC"] = dt.Rows[i][18].ToString();

                    dtnew.Rows.Add(drnew);


                    if (dt.Rows[i][0].ToString() == "True" && dt.Rows[i][4].ToString() == "T")
                    {
                        if (Rd_Bill_Type.SelectedValue.ToString() == "L")
                        {
                            gst_toal = gst_toal + (Convert.ToDecimal(dt.Rows[i][13].ToString() == "" ? "0.00" : dt.Rows[i][13].ToString())
                                              + Convert.ToDecimal(dt.Rows[i][15].ToString() == "" ? "0.00" : dt.Rows[i][15].ToString()));
                        }
                        else
                        {
                            gst_toal = gst_toal + Convert.ToDecimal(dt.Rows[i][17].ToString() == "" ? "0.00" : dt.Rows[i][17].ToString());
                        }

                        tax_amt = tax_amt + Convert.ToDecimal(dt.Rows[i][11].ToString() == "" ? "0.00" : dt.Rows[i][11].ToString());
                    }
                    else if (dt.Rows[i][0].ToString() == "True" && dt.Rows[i][4].ToString() == "N")
                    {
                        non_tax_amt = non_tax_amt + Convert.ToDecimal(dt.Rows[i][11].ToString() == "" ? "0.00" : dt.Rows[i][11].ToString());
                    }
                    else if (dt.Rows[i][0].ToString() == "True" && dt.Rows[i][4].ToString() == "E")
                    {
                        non_tax_amt = non_tax_amt + Convert.ToDecimal(dt.Rows[i][11].ToString() == "" ? "0.00" : dt.Rows[i][11].ToString());
                    }
                    else if (dt.Rows[i][0].ToString() == "True" && dt.Rows[i][4].ToString() == "P")
                    {
                            gst_toal = gst_toal + (Convert.ToDecimal(dt.Rows[i][13].ToString() == "" ? "0.00" : dt.Rows[i][13].ToString())
                                              + Convert.ToDecimal(dt.Rows[i][15].ToString() == "" ? "0.00" : dt.Rows[i][15].ToString())
                                              + Convert.ToDecimal(dt.Rows[i][17].ToString() == "" ? "0.00" : dt.Rows[i][17].ToString())
                                              );

                        tax_amt = tax_amt + Convert.ToDecimal(dt.Rows[i][11].ToString() == "" ? "0.00" : dt.Rows[i][11].ToString());
                    }
                    else if (dt.Rows[i][0].ToString() == "True" && dt.Rows[i][4].ToString() == "R")
                    {
                        if (Rd_Bill_Type.SelectedValue.ToString() == "L")
                        {
                            Reverse_total = Reverse_total + (
                            (Convert.ToDecimal(dt.Rows[i][11].ToString() == "" ? "0.00" : dt.Rows[i][11].ToString()) * Convert.ToDecimal(dt.Rows[i][12].ToString() == "" ? "0.00" : dt.Rows[i][12].ToString())/100)
                            + (Convert.ToDecimal(dt.Rows[i][11].ToString() == "" ? "0.00" : dt.Rows[i][11].ToString()) * Convert.ToDecimal(dt.Rows[i][14].ToString() == "" ? "0.00" : dt.Rows[i][14].ToString()) / 100)
                            );
                        }
                        else
                        {
                            Reverse_total = Reverse_total + (
                            (Convert.ToDecimal(dt.Rows[i][11].ToString() == "" ? "0.00" : dt.Rows[i][11].ToString()) * Convert.ToDecimal(dt.Rows[i][16].ToString() == "" ? "0.00" : dt.Rows[i][16].ToString()) / 100)
                            );
                        }

                       tax_amt = tax_amt + Convert.ToDecimal(dt.Rows[i][11].ToString() == "" ? "0.00" : dt.Rows[i][11].ToString());

                        //-----------------------------------------------------
                    }
                }

                //---------------------------------------------------------------------------------------
                gv_Chg_Details.DataSource = dtnew;
                gv_Chg_Details.DataBind();

                txtnon_tax_amt.Text = non_tax_amt.ToString();
                txttax_amt.Text = tax_amt.ToString();
                txt_total_tax_amt.Text = gst_toal.ToString();
                txt_tot_Rev_Amt.Text = Reverse_total.ToString();

                txt_total_amt_With_tax.Text = (Convert.ToDecimal(txt_total_tax_amt.Text) + Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");
            }
            else if (dt.Rows.Count == 1)
            {
                DataTable dtt = new DataTable();
                DataRow drr = null;

                dtt.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));
                dtt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dtt.Columns.Add(new DataColumn("ORDERBY", typeof(string)));
                dtt.Columns.Add(new DataColumn("CHARGE_NAME", typeof(string)));
                dtt.Columns.Add(new DataColumn("TAX_NONTAX", typeof(string)));

                dtt.Columns.Add(new DataColumn("HSN_CODE", typeof(string)));
                dtt.Columns.Add(new DataColumn("SA_CODE", typeof(string)));
                dtt.Columns.Add(new DataColumn("Qty", typeof(string)));
                dtt.Columns.Add(new DataColumn("CUR", typeof(string)));
                dtt.Columns.Add(new DataColumn("EX_RATE", typeof(string)));

                dtt.Columns.Add(new DataColumn("UNIT_RATE", typeof(string)));
                dtt.Columns.Add(new DataColumn("AMOUNT", typeof(string)));
                dtt.Columns.Add(new DataColumn("CGST_RATE", typeof(string)));
                dtt.Columns.Add(new DataColumn("CGST_AMT", typeof(string)));
                dtt.Columns.Add(new DataColumn("SGST_RATE", typeof(string)));
                dtt.Columns.Add(new DataColumn("SGST_AMT", typeof(string)));
                dtt.Columns.Add(new DataColumn("IGST_RATE", typeof(string)));
                dtt.Columns.Add(new DataColumn("IGST_AMT", typeof(string)));
                dtt.Columns.Add(new DataColumn("CHARGE_DESC", typeof(string)));

                drr = dtt.NewRow();
                drr["INV_CHECK"] = "True";
                drr["RowNumber"] = 1;
                drr["ORDERBY"] = string.Empty;
                drr["CHARGE_NAME"] = string.Empty;
                drr["TAX_NONTAX"] = "N";

                drr["HSN_CODE"] = string.Empty;
                drr["SA_CODE"] = string.Empty;
                drr["Qty"] = "1";
                drr["CUR"] = "INR";
                drr["EX_RATE"] = "1";

                drr["UNIT_RATE"] = "0";
                drr["AMOUNT"] = "0";
                drr["CGST_RATE"] = "0";
                drr["CGST_AMT"] = "0";
                drr["SGST_RATE"] = "0";
                drr["SGST_AMT"] = "0";
                drr["IGST_RATE"] = "0";
                drr["IGST_AMT"] = "0";
                drr["CHARGE_DESC"] = string.Empty;

                dtt.Rows.Add(drr);

                ViewState["CurrentTable"] = dtt;

                gv_Chg_Details.DataSource = dtt;
                gv_Chg_Details.DataBind();

                txtnon_tax_amt.Text = "0";
                txttax_amt.Text = "0";
                txt_total_tax_amt.Text = "0";
                txt_tot_Rev_Amt.Text = "0";
                txt_total_amt_With_tax.Text = "0";

            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
        txtfocus.Focus();
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Other_Quotation.Checked = false;
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        hd_hss_br_sl_no.Value = "";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        DataTable dt = new DataTable();
        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();

        SetInitialRow();

        Clear();
        HDupdate_id.Value = string.Empty;
        HdtxtInvoiceNo_id.Value = string.Empty;

        ddlImp_name.Enabled = true;
        ddljobno.Enabled = true;
        btnrpt.Visible = false;

        ddlbranch_No.Enabled=true;
        ddl_tr_mode.Enabled=true;
        ddlshipment_type.Enabled = true;

        Rd_Tax_NonTax.SelectedValue = "B";
        ddlTerms.SelectedIndex = -1;

        ddl_clear();
        load_Imp_name();

        if (COMPANY_LICENSE != "eri00314" || COMPANY_LICENSE != "eri00287" )
        {
            txtDate.Attributes.Remove("readonly");
            txtDate.Style.Add("background-color", "white");
        }
        else
        {
            txtInvoiceNo.Attributes.Remove("readonly");
            txtInvoiceNo.Style.Add("background-color", "white");
        }

        From_Quotation.Attributes.Remove("readonly");
        From_Quotation.Style.Add("background-color", "white");
        ddlImp_name.Style.Add("background-color", "white");
        ddljobno.Style.Add("background-color", "white");
        txtimportername_Other.Attributes.Remove("readonly");
        txtimportername_Other.Style.Add("background-color", "white");

        ddlbranch_No.Enabled = true;
        ddl_tr_mode.Enabled = true;
        ddlshipment_type.Enabled = true;

        ddlbranch_No.Attributes.Remove("readonly");
        ddlbranch_No.Style.Add("background-color", "white");

        ddl_tr_mode.Attributes.Remove("readonly");
        ddl_tr_mode.Style.Add("background-color", "white");

        ddlshipment_type.Attributes.Remove("readonly");
        ddlshipment_type.Style.Add("background-color", "white");

        btnloadData.Visible = true;
        Rd_Bill_Type.Enabled = true;

        CalendarExtender1.Enabled = true;
        MaskedEditExtender1.Enabled = true;

        load_date();
        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        if (COMPANY_LICENSE != "eri00146" || COMPANY_LICENSE != "eri00010")
        {
            Chk_BWC_Tr.Visible = true;
        }
        
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
    public static string Get_Importer_other(string custid, string Mode , string Branch)
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
                if (Connection.Company_License().ToLower() == "eri00381" || Connection.Company_License().ToLower() == "eri00420" || Connection.Company_License().ToLower() == "eri00677" || Connection.Company_License().ToLower() == "eri03094")
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
                custid =string.Empty;
            }
        }
        else
        {
            custid = string.Empty;
        }
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Importer_Inv_Chk(string custid, string Mode, string Branch)
    {
        GST_Imp_Invoice BI = new GST_Imp_Invoice();
        Billing_UserBO ObjUBO = new Billing_UserBO();

        if (custid != string.Empty)
        {
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = Mode;
            if (Connection.Company_License().ToLower() == "eri00381")
            {
                 string Wrk =string.Empty;
                 Wrk=Connection.WorkingPeriod();
                 if (Wrk == "01-Apr-2021 - 31-Mar-2022")
                 {
                     //ObjUBO.BILL_INV_NO = "GST-" + custid + "/21-22";
                     ObjUBO.BILL_INV_NO = "GST/21-22/" + custid ;
                 }
                 else if (Wrk == "01-Apr-2020 - 31-Mar-2021")
                 {
                     ObjUBO.BILL_INV_NO = "GST-" + custid + "/20-21";
                 }
                 else if (Wrk == "01-Apr-2019 - 31-Mar-2020")
                 {
                     ObjUBO.BILL_INV_NO = "GST-" + custid + "/19-20";
                 }
                 else if (Wrk == "01-Apr-2018 - 31-Mar-2019")
                 {
                     ObjUBO.BILL_INV_NO = "GST-" + custid + "/18-19";
                 }
                 else
                 {
                     ObjUBO.BILL_INV_NO = "GST-" + custid + "/17-18";
                 }
            }
            else
            {
                ObjUBO.BILL_INV_NO = custid;
            }
            ObjUBO.Flag = "Imp_Inv_No_Check";
            dss = BI.Select_IMP_INV(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                custid = "No";
            }
            else
            {
                custid = "Yes";
            }
        }
        else
        {
            custid = "Yes";
        }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Supplier(string custid,string Jobno)
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
        txtjob_invno.Text = string.Empty;
        txtInvoiceNo.Text = string.Empty;
        txtBeno.Text = string.Empty;
        txtBedate.Text = string.Empty;
        txtMblno.Text = string.Empty;
        txtHblno.Text = string.Empty;
        txtconatiner_no.Text = string.Empty;
        txtno_of_pkg.Text = string.Empty;
        txtgross_wgt.Text = string.Empty;
        txtnetwgt.Text = string.Empty;
        txtvolume.Text = string.Empty;
        txtvessel.Text = string.Empty;
        txtdestination.Text = string.Empty;
        txtcommodity.Text = string.Empty;
        ddl_freight_status.SelectedIndex = -1;
        ch_Behalf.Checked = false;
        txtImportername.Text = string.Empty;
        txtShip_Add1.Text = string.Empty;
        txtsuppliername.Text = string.Empty;
        txtCon_Add1.Text = string.Empty;

        txt_IMP_notify_party_1.Text = string.Empty;
        txt_notify_party_1_add.Text = string.Empty;
        txt_notify_party_2.Text = string.Empty;
        txt_notify_party_2_add.Text = string.Empty;
        txt_Remarks.Text = string.Empty;
        txtnon_tax_amt.Text = string.Empty;
        txttax_amt.Text = string.Empty;

        txt_total_tax_amt.Text = string.Empty;
        txt_total_amt_With_tax.Text = string.Empty;
        txt_tot_Rev_Amt.Text = string.Empty;

        txt_MAWB_MBL_date.Text = string.Empty;
        txt_HAWB_HBL_date.Text = string.Empty;


        txt_flight_Ara_Date.Text = string.Empty;
        txt_Con_Size.Text = string.Empty;
        txt_Bond_No.Text = string.Empty;
        txt_Bond_date.Text = string.Empty;
        
        hd_hss_br_sl_no.Value = "";
        txt_Ass_Value.Text = string.Empty;
        txt_CIF_Value.Text = string.Empty;

       

        ddl_state_name.SelectedIndex = -1;
        txt_GSTN_Id.Text = string.Empty;
        txtJob_Date.Text = string.Empty;

        txt_ur_Ref_No.Text = string.Empty;
        txtPackageType.Text = string.Empty;
        txt_Gross_Wgt_Type.Text = string.Empty;
        txt_Net_Wgt_Type.Text = string.Empty;
        txt_Item_Desc.Text = string.Empty;
        txt_branch_No.Text = string.Empty;
        txt_Expense_Amt.Text = string.Empty;
    }
    [System.Web.Services.WebMethod]
    public static string GetImporter(string custid, string Branch)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();

        Auto.Name_Search = custid;
        //Auto.Jobno = Jobno;
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
    private void Add_Empty_Jobno()
    {
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;
    }
    protected void Rd_Bill_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Imp_name();
        ddlImp_name_SelectedIndexChanged(sender, e);
    }
    public void LoadFinancialYear()
    {
        ddlWorkingPeriod.Items.Clear();
        ddlWorkingPeriod.Items.Add(new ListItem("01-Apr-2026 - 31-Mar-2027", "01-Apr-2026 - 31-Mar-2027"));
        ddlWorkingPeriod.Items.Add(new ListItem("01-Apr-2025 - 31-Mar-2026", "01-Apr-2025 - 31-Mar-2026"));
        ddlWorkingPeriod.Items.Add(new ListItem("01-Apr-2024 - 31-Mar-2025", "01-Apr-2024 - 31-Mar-2025"));
        ddlWorkingPeriod.Items.Add(new ListItem("01-Apr-2023 - 31-Mar-2024", "01-Apr-2023 - 31-Mar-2024"));
        //ddlWorkingPeriod.Items.Add(new ListItem("01-Apr-2022 - 31-Mar-2023", "01-Apr-2022 - 31-Mar-2023"));
        //ddlWorkingPeriod.Items.Add(new ListItem("01-Apr-2021 - 31-Mar-2022", "01-Apr-2021 - 31-Mar-2022"));
        //ddlWorkingPeriod.Items.Add(new ListItem("01-Apr-2020 - 31-Mar-2021", "01-Apr-2020 - 31-Mar-2021"));
        //ddlWorkingPeriod.Items.Add(new ListItem("01-Apr-2019 - 31-Mar-2020", "01-Apr-2019 - 31-Mar-2020"));
        /*
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;

        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
        try
        {
            con.Open();
            ddlWorkingPeriod.Items.Clear();
            cmd = new SqlCommand("select * from FINANCIAL_YEAR order by WORKING_PERIOD desc", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ddlWorkingPeriod.Items.Add(dr["WORKING_PERIOD"].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {
            con.Close();
        }
        */
    }

    protected void ddlbranch_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlshipment_type.SelectedIndex = -1;
        ddl_tr_mode.SelectedIndex = -1;
        txt_ur_Ref_No.Text = string.Empty;

        txt_Ass_Value.Text = string.Empty;
        txt_CIF_Value.Text = string.Empty;
        if (ddlbranch_No.SelectedItem.Text != string.Empty && ddlImp_name.SelectedItem.Text != "")
        {
            load_Branch_Jobno();
        }
        cl();
        

    }

    private void load_Branch_Jobno()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.Imp_Name = ddlImp_name.SelectedValue.ToString();
            ObjUBO.JOBNO = ddlbranch_No.SelectedValue.ToString();
            ObjUBO.Flag = "Imp_Branch_Job_Select";
            //-----------start-----------------
            if (Connection.Billing_Working_Period() == "Y")
            {
                dss = Database_Con_string();
            }
            else
            {
                dss = BI.Select_IMP_INV(ObjUBO);
            }
            //-----------end---------------------
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = dss.Tables[0];
                ddljobno.DataTextField = "FILE_REF_NO";
                ddljobno.DataValueField = "JOBNO";
                ddljobno.DataBind();
            }

            ddljobno.Items.Insert(0, new ListItem(String.Empty, "0"));
            ddljobno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnloadData_Click(object sender, EventArgs e)
    {

        if (ddlImp_name.SelectedItem.Text != string.Empty)
        {
            if (ddlbranch_No.SelectedItem.Text != string.Empty)
            {
                if (ddljobno.SelectedValue != "0")
                {
                    load_Job_Data();
                }
                else
                {
                    load_Other_Job_data();
                }

                if (COMPANY_LICENSE.ToUpper() == "ERI00146" && ddl_tr_mode.SelectedValue.ToString() == "Sea")
                {
                    txt_Remarks.Text = "MERIT FCL  1 X 40’ SEA IMPORT TRANSPORTATION CHARGES GST ON CONSIGNEE A/C .";
                }
            }
            else
            {
                Alert_msg("Select Ur Branch Name!");
            }
        }
        else
        {
            Alert_msg("Select Ur Exporter Name!");
        }

        if(ddlshipment_type.SelectedValue.ToString()=="FCL")
        {
            ddl_LCL_FCL.SelectedValue = "F";
        }
        else if (ddlshipment_type.SelectedValue.ToString() == "LCL")
        {
            ddl_LCL_FCL.SelectedValue = "L";
        }
        else if (ddlshipment_type.SelectedValue.ToString() == "Exbond")
        {
            ddl_LCL_FCL.SelectedValue = "E";
        }
        else
        {
            ddl_LCL_FCL.SelectedIndex = -1;
        }
        
    }
    private void load_Job_Data()
    {
        DataSet dss = new DataSet();
        if (ddljobno.SelectedItem.Text != "")
        {
            Hdjobno.Value = ddljobno.SelectedValue.ToString();
            ObjUBO.Imp_Name = ddlImp_name.SelectedValue.ToString();
            ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
            ObjUBO.Branch_No = ddlbranch_No.SelectedValue.ToString(); 
            ObjUBO.MODE = ddl_tr_mode.SelectedValue.ToString();
            chk = From_Quotation.Checked;
            ObjUBO.FROM_QUOTATION = chk.ToString();
            ObjUBO.Ass_Value = txt_Ass_Value.Text;
            ObjUBO.CIF_VALUE = txt_CIF_Value.Text;
            ObjUBO.SHIPMENT_TYPE = ddlshipment_type.SelectedValue.ToString();




            ObjUBO.Flag = "Imp_Job_Grid_New";
            ObjUBO.BILL_INV_NO = Rd_Tax_NonTax.SelectedValue.ToString();
            ObjUBO.BILL_TYPE = Chk_BWC_Tr.Checked.ToString();
            //Accounts Type Location 2 Start
            if (COMPANY_LICENSE == "eri00268" || COMPANY_LICENSE == "eri00353" || COMPANY_LICENSE == "eri00507" || COMPANY_LICENSE == "eri00677" || COMPANY_LICENSE == "eri01157" || COMPANY_LICENSE == "eri01316" || COMPANY_LICENSE == "eri01613" || COMPANY_LICENSE == "eri02085" || COMPANY_LICENSE == "eri03094")
            {
                ObjUBO.BILL_TYPE = ddlAccounts_Type.SelectedValue.ToString();
            }
            else
            {
                //
            }
            //Accounts Type Location 2 End



            //-----------start-----------------
            if (Connection.Billing_Working_Period() == "Y")
            {
               ObjUBO.JOB_WORKINGPERIOD = ddlWorkingPeriod.SelectedValue.ToString();
               dss = Database_Con_string();
            }
            else
            {
                ObjUBO.JOB_WORKINGPERIOD = "";
                dss = BI.Select_IMP_INV(ObjUBO);
            }
            //-----------end---------------------
            if (dss.Tables[0].Rows.Count > 0)
            {
                if (Connection.Billing_Working_Period() == "Y")
                {
                    if (ddlWorkingPeriod.SelectedValue.ToString() == Connection.WorkingPeriod().ToString())
                    {
                        txtInvoiceNo.Text = dss.Tables[0].Rows[0]["Autoid"].ToString();
                    }
                    else
                    {
                        DataSet ss = new DataSet();
                        Hdjobno.Value = "";
                        ObjUBO.Imp_Name = "";
                        ObjUBO.JOBNO = "";
                        ObjUBO.Flag = "GST_IMP_Max_Id";

                        ss = BI.Select_IMP_INV(ObjUBO);
                        if (ss.Tables[0].Rows.Count > 0)
                        {
                            txtInvoiceNo.Text = ss.Tables[0].Rows[0]["Autoid"].ToString();
                        }
                    }
                }
                else
                {
                    txtInvoiceNo.Text = dss.Tables[0].Rows[0]["Autoid"].ToString();
                }

                if (COMPANY_LICENSE == "eri00381" || COMPANY_LICENSE == "eri00581" || COMPANY_LICENSE == "eri00620" || COMPANY_LICENSE == "eri00677" || COMPANY_LICENSE == "eri00581" || COMPANY_LICENSE == "eri00705" || COMPANY_LICENSE == "eri01069" || COMPANY_LICENSE == "eri03094")
                {
                    txtInvoiceNo.Text = "";
                }
            }
            //------------------------------------------------------------------
            if (dss.Tables[1].Rows.Count > 0)
            {
                 txt_Duty_Value.Text = dss.Tables[1].Rows[0]["Duty_Value"].ToString();
                 ddl_state_name.SelectedValue = dss.Tables[1].Rows[0]["STATE_NAME"].ToString();
                 txt_GSTN_Id.Text = dss.Tables[1].Rows[0]["GSTN_ID"].ToString();
                 txt_Party_Ref.Text = dss.Tables[1].Rows[0]["PARTY_REF"].ToString();
                 txt_Bond_No.Text = dss.Tables[1].Rows[0]["Bond_No"].ToString();
                 txt_Con_Size.Text = dss.Tables[1].Rows[0]["Container_Size"].ToString();
                 txtdestination.Text = dss.Tables[1].Rows[0]["DESTINATION"].ToString();
                 txtImportername.Text = dss.Tables[1].Rows[0]["SHIPPER_NAME"].ToString();
                 txtShip_Add1.Text = dss.Tables[1].Rows[0]["SHIPPER_ADDRESS"].ToString();
                 txtJob_Date.Text = dss.Tables[1].Rows[0]["JOBDATE"].ToString();
                 txtBeno.Text = dss.Tables[1].Rows[0]["BENo"].ToString();
                 txtBedate.Text = dss.Tables[1].Rows[0]["BEDate"].ToString();
                 txtconatiner_no.Text = dss.Tables[1].Rows[0]["CONTAINER_NO"].ToString();
                 txt_Expense_Amt.Text = dss.Tables[1].Rows[0]["EXPENSE_AMT"].ToString();
                 txtCountryShipment.Text = dss.Tables[1].Rows[0]["COUNTRY_SHIPMENT"].ToString();
                 txtPortShipment.Text = dss.Tables[1].Rows[0]["PORT_SHIPMENT"].ToString();

                 txtMblno.Text = dss.Tables[1].Rows[0]["MBL_NO"].ToString();
                 txtHblno.Text = dss.Tables[1].Rows[0]["HBL_NO"].ToString();
                 txtvessel.Text = dss.Tables[1].Rows[0]["VESSEL"].ToString();

                 txt_MAWB_MBL_date.Text = dss.Tables[1].Rows[0]["MBL_NO_DATE"].ToString();
                 txt_HAWB_HBL_date.Text = dss.Tables[1].Rows[0]["HBL_NO_DATE"].ToString();

                 txt_flight_Ara_Date.Text = dss.Tables[1].Rows[0]["FLIGHT_ARAIVAL_DATE"].ToString();

                 txtno_of_pkg.Text = dss.Tables[1].Rows[0]["NO_OF_PKG"].ToString();
                 txtgross_wgt.Text = dss.Tables[1].Rows[0]["GROSS_WGT"].ToString();
                 txtnetwgt.Text = dss.Tables[1].Rows[0]["NET_WGT"].ToString();
                 txtPackageType.Text = dss.Tables[1].Rows[0]["NO_OF_PKG_TYPE"].ToString();
                 txt_Gross_Wgt_Type.Text = dss.Tables[1].Rows[0]["GROSS_WGT_TYPE"].ToString();
                 txt_Net_Wgt_Type.Text = dss.Tables[1].Rows[0]["NET_WGT_TYPE"].ToString();

                 txtjob_invno.Text = dss.Tables[1].Rows[0]["INV_NO"].ToString();
                 txtsuppliername.Text = dss.Tables[1].Rows[0]["CONSIGNEE_NAME"].ToString();
                 txtCon_Add1.Text = dss.Tables[1].Rows[0]["CONSIGNEE_ADDRESS"].ToString();

                 txtcommodity.Text = dss.Tables[1].Rows[0]["ITEM_DESC"].ToString();
                 txt_Item_Desc.Text = dss.Tables[1].Rows[0]["ITEM_DESC"].ToString();
            }
            //--------------------------------------------------------------------------
            if (dss.Tables[2].Rows.Count > 0)
            {
                gv_Chg_Details.DataSource = dss.Tables[2];
                gv_Chg_Details.DataBind();

                ViewState["CurrentTable"] = dss.Tables[2];
            }
            else
            {
                SetInitialRow();
            }
        }
        else
        {
            DataTable dt = new DataTable();
            gv_Chg_Details.DataSource = dt;
            gv_Chg_Details.DataBind();
        }
    }
    private void load_Other_Job_data()
    {
        try
        {
            gv_Chg_Details.DataSource = null;
            gv_Chg_Details.DataBind();

            DataSet dss = new DataSet();
            ObjUBO.Imp_Name = ddlImp_name.SelectedItem.ToString();
            ObjUBO.Branch_No = ddlbranch_No.SelectedValue.ToString();
            ObjUBO.Ass_Value = txt_Ass_Value.Text == string.Empty ? "0" : txt_Ass_Value.Text;
            ObjUBO.CIF_VALUE = txt_CIF_Value.Text == string.Empty ? "0" : txt_CIF_Value.Text;
            ObjUBO.SHIPMENT_TYPE = ddlshipment_type.SelectedValue.ToString();
            ObjUBO.MODE = ddl_tr_mode.SelectedValue.ToString();
            ObjUBO.Flag = "Other_Quotation_Select";
            ObjUBO.BILL_INV_NO = Rd_Tax_NonTax.SelectedValue.ToString();
            ObjUBO.BILL_TYPE = Chk_BWC_Tr.Checked.ToString();
            //Accounts Type Location 3 Start
            if (COMPANY_LICENSE == "eri00268" || COMPANY_LICENSE == "eri00353" || COMPANY_LICENSE == "eri00507" || COMPANY_LICENSE == "eri00677" || COMPANY_LICENSE == "eri01157" || COMPANY_LICENSE == "eri01316" || COMPANY_LICENSE == "eri01613" || COMPANY_LICENSE == "eri02085" || COMPANY_LICENSE == "eri03094")
            {
                ObjUBO.BILL_TYPE = ddlAccounts_Type.SelectedValue.ToString();
            }
            else
            {
                //
            }
            //Accounts Type Location 3 End



            dss = BI.Select_IMP_INV(ObjUBO);
            
           // -----------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (dss.Tables[0].Rows.Count > 0)
            {
                if (Connection.Billing_Working_Period() == "Y")
                {
                    if (ddlWorkingPeriod.SelectedValue.ToString() == Connection.WorkingPeriod().ToString())
                    {
                        txtInvoiceNo.Text = dss.Tables[0].Rows[0]["Autoid"].ToString();
                    }
                    else
                    {
                        DataSet ss = new DataSet();
                        ObjUBO.Imp_Name = "";
                        ObjUBO.JOBNO = "";
                        ObjUBO.Flag = "GST_EXP_Max_Id";

                        ss = BI.Select_IMP_INV(ObjUBO);
                        if (ss.Tables[0].Rows.Count > 0)
                        {
                            txtInvoiceNo.Text = ss.Tables[0].Rows[0]["Autoid"].ToString();
                        }
                    }
                }
                else
                {
                    txtInvoiceNo.Text = dss.Tables[0].Rows[0]["Autoid"].ToString();
                }

                if (COMPANY_LICENSE == "eri00381" || COMPANY_LICENSE == "eri00420" || COMPANY_LICENSE == "eri00581" || COMPANY_LICENSE == "eri00620" || COMPANY_LICENSE == "eri00677" || COMPANY_LICENSE == "eri00705" || COMPANY_LICENSE == "eri01069" || COMPANY_LICENSE == "eri03094")
                {
                    txtInvoiceNo.Text = "";
                }
            }

            // -------------------------------------------------------------------------------------------------------------------------------------------------------------------

            if (dss.Tables[1].Rows.Count > 0)
            {
                gv_Chg_Details.DataSource = dss.Tables[1];
                gv_Chg_Details.DataBind();

                ViewState["CurrentTable"] = dss.Tables[1];
            }
            else
            {
                SetInitialRow();
            }
            // -------------------------------------------------------------------------------------------------------------------------------------------------------------------
            if (dss.Tables[2].Rows.Count > 0)
            {
                txtImportername.Text = dss.Tables[2].Rows[0]["IMP_EXP_NAME"].ToString();
                txtShip_Add1.Text = dss.Tables[2].Rows[0]["Exp_Address"].ToString();

                ddl_state_name.SelectedValue = dss.Tables[2].Rows[0]["State_Of_Export"].ToString();
                txt_GSTN_Id.Text = dss.Tables[2].Rows[0]["GSTN_ID"].ToString();
            }
            else
            {
                txtImportername.Text = string.Empty;
                txtShip_Add1.Text = string.Empty;

                ddl_state_name.SelectedIndex = -1;
                txt_GSTN_Id.Text = string.Empty;
            }

            // -------------------------------------------------------------------------------------------------------------------------------------------------------------------
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
        clear_Other_Inv();

        if (ddljobno.SelectedItem.Text != "")
        {
           
            Hdjobno.Value = ddljobno.SelectedValue.ToString();
            ObjUBO.Imp_Name = ddlImp_name.SelectedValue.ToString();
            ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
            ObjUBO.Flag = "Imp_Job_Mode";
            //-----------start-----------------
            if (Connection.Billing_Working_Period() == "Y")
            {
                dss = Database_Con_string();
            }
            else
            {
                dss = BI.Select_IMP_INV(ObjUBO);
            }
            if (dss.Tables[0].Rows.Count > 0)
            {
                txt_ur_Ref_No.Text = dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                ddl_tr_mode.SelectedValue = dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                ddlbranch_No.SelectedValue = dss.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                ddlshipment_type.SelectedValue = dss.Tables[0].Rows[0]["FCL_OR_LCL"].ToString();
                txt_Ass_Value.Text = dss.Tables[0].Rows[0]["ASS_Value"].ToString();
                txt_CIF_Value.Text = dss.Tables[0].Rows[0]["CIF_VALUE"].ToString();
            }
            else
            {
                ddl_tr_mode.SelectedIndex = -1;
                ddlbranch_No.SelectedIndex = -1;
                ddlshipment_type.SelectedIndex = -1;
                txt_ur_Ref_No.Text = string.Empty;
                txt_Ass_Value.Text = string.Empty;
                txt_CIF_Value.Text = string.Empty;
            }
           
        }
    }
    private DataSet Database_Con_string()
    {
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = ddlWorkingPeriod.SelectedValue.ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            //-----------------------------------------------------------------//
            dss = BI.Select_IMP_INV(ObjUBO, table1.Rows[0]["SERVER_NAME"].ToString());
        }
        return dss;
    }
    protected void Rd_Inv_Status_SelectedIndexChanged(object sender, EventArgs e)
    {  /*
        DataSet d = new DataSet();
        if(HDupdate_id.Value.ToString() !=string.Empty && HDupdate_id.Value.ToString() != null)
        {
            if (Rd_Inv_Status.SelectedValue.ToString() == "UA")
            {
                ObjUBO.JOBNO = HDupdate_id.Value.ToString();
                ObjUBO.SHIPMENT_TYPE = Rd_Inv_Status.SelectedValue.ToString();
                ObjUBO.Flag = "Invoice_Approve";
                d=BI.Select_IMP_INV(ObjUBO);

                Rd_Job_Status.SelectedValue = "P";
                Bill_Admin.Visible = false;
                if (d.Tables[0].Rows.Count > 0)
                {
                    txtInvoiceNo.Text = d.Tables[0].Rows[0][0].ToString();
                }

                Alert_msg("Unapproval Successfully", "Rd_Inv_Status");
            }
            else
            {
                ObjUBO.JOBNO = HDupdate_id.Value.ToString();
                ObjUBO.SHIPMENT_TYPE = Rd_Inv_Status.SelectedValue.ToString();
                ObjUBO.Flag = "Invoice_Approve";
                d = BI.Select_IMP_INV(ObjUBO);
                if (d.Tables[0].Rows.Count > 0)
                {
                    txtInvoiceNo.Text = d.Tables[0].Rows[0][0].ToString();
                }
                Alert_msg("Approved Successfully", "Rd_Inv_Status");
            }
        }
        */
    }
    /*
    private void Billing_Approve(string JobEntry, string Approve_Status)
    {
        if (Connection.Billing_Aproval_Company() == "Y")
        {
            if (Connection.Billing_Aproval_Admin() == "Y")
            {
                if (JobEntry == "C")
                {
                    Bill_Admin.Visible = true;
                }
            }
            else
            {
                if (Approve_Status == "A")
                {
                    btnNew.Enabled = false;
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                   
                    btnSave.ToolTip = "Can't be Modified";
                    btnUpdate.ToolTip = "Can't be Modified";
                    btnDelete.ToolTip = "Can't be Modified";

                    lblmsg.Text = "Note :- Invoice Approved Can't be Modified";

                }
            }
        }
    }
    */
    [System.Web.Services.WebMethod]
    public static string Inv_Refresh(string Inv)
    {
        DataSet ds =new DataSet();
        GST_Imp_Invoice BI = new GST_Imp_Invoice();
        Billing_UserBO ObjUBO = new Billing_UserBO();

        ObjUBO.Flag = "Refresh_Invoice";
        ds=BI.Select_IMP_INV(ObjUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            return ds.Tables[0].Rows[0][0].ToString();
        }
        else
        {
            return "";
        }
    }
    
}