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


public partial class GST_Imp_Exp_Invoice_Job : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    GST_Bill_Consolidate GBC= new GST_Bill_Consolidate();
         
//--------------------------------------------------------------------------------

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE,COMPANY_LICENSE;

    decimal tax_amt, non_tax_amt, gst_toal, Reverse_total;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        COMPANY_LICENSE = Connection.Company_License().ToLower();
        if (COMPANY_LICENSE != "eri00314" && COMPANY_LICENSE != "eri00381" && COMPANY_LICENSE != "eri00420")
        {
            CalendarExtender1.EndDate = DateTime.Today;
        }
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
            T.Visible = false;

           /* if (COMPANY_LICENSE != "eri00287" && COMPANY_LICENSE != "eri00314" && COMPANY_LICENSE != "eri00381" && COMPANY_LICENSE != "eri00010")
            {
                txtInvoiceNo.Attributes.Add("readonly", "readonly");
                txtInvoiceNo.Style.Add("background-color", "#F0F0F0");
            }*/

            txt_tot_Rev_Amt.Attributes.Add("readonly", "readonly");
            txtnon_tax_amt.Attributes.Add("readonly", "readonly");
            txttax_amt.Attributes.Add("readonly", "readonly");

            HD_Bill_Jobno.Value = string.Empty;

            if (Request.QueryString["Page"] == null)
            {

                load_Imp_name();
                load_date();
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

                HDupdate_id.Value = "";
                HdtxtInvoiceNo_id.Value = "";
                hd_hss_br_sl_no.Value = "";
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

                    ddlCustomer_name.Enabled = false;
                    Rd_Inv_Type.Enabled = false;
                    Rd_Bill_Type.Enabled = false;

                    ddlbranch_No.Enabled = false;
                    HD_Showcon.Value = "SAVED";
                    btnrpt.Visible = true;

                    HD_Bill_Jobno.Value = txtInvoiceNo.Text;

                    if (COMPANY_LICENSE != "eri00287" || COMPANY_LICENSE != "eri00314" || COMPANY_LICENSE != "eri00381" || COMPANY_LICENSE != "eri00420")
                    {
                        txtDate.Attributes.Add("readonly", "readonly");
                        txtDate.Style.Add("background-color", "#F0F0F0");
                        CalendarExtender1.Enabled = false;
                        txtInvoiceNo.Attributes.Add("readonly", "readonly");
                        txtInvoiceNo.Style.Add("background-color", "#F0F0F0");
                    }
                }
            }
        }
        txtInvoiceNo.Attributes.Add("onblur", "javascript:CallServerside_IMP_EXP_INVCHK('" + txtInvoiceNo.ClientID + "', '" + txtInvoiceNo.ClientID + "')");
    }
    private void load_date()
    {
        DataSet dss = new DataSet();
        ObjUBO.Flag = "Imp_Bill_Date";
        dss = BI.Select_IMP_INV(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            if (COMPANY_LICENSE != "eri00314" && COMPANY_LICENSE != "eri00381" && COMPANY_LICENSE != "eri00420")
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

        DataSet dss = new DataSet();
        Hdjobno.Value = Request.QueryString["Page"].ToString();

        ObjUBO.Imp_Name = Request.QueryString["Page"].ToString();
        ObjUBO.BILL_TYPE = Request.QueryString["IMP_EXP"].ToString();
        ObjUBO.CHARGE_NAME = Request.QueryString["Billinvno"].ToString();

        ObjUBO.Flag = "Imp_Exp_Update_Select";

        dss = GBC.GST_Bill_Consolidate_Select(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            cbList.DataSource = dss.Tables[0];
            cbList.DataTextField = "FILE_REF_NO";
            cbList.DataValueField = "Jobno";
            cbList.DataBind();

            for (int i = 0; i <= dss.Tables[0].Rows.Count - 1; i++)
            {
                if (dss.Tables[0].Rows[i]["FeatureStatus"].ToString() == "True")
                {
                    cbList.Items[i].Selected = true;
                    cbList.Items[i].Attributes.Add("style", "background-color: white;color: blue;font-weight: bold;");
                }
            }
        }

       if (dss.Tables[1].Rows.Count > 0)
        {
            HDupdate_id.Value = dss.Tables[1].Rows[0]["ID"].ToString();
            HdtxtInvoiceNo_id.Value = dss.Tables[1].Rows[0]["BILL_INV_NO"].ToString();
            HD_I_E.Value = dss.Tables[1].Rows[0]["IMP_EXP"].ToString();
           /* J_no = dss.Tables[0].Rows[0]["JOBNO"].ToString();
            Imp_name = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();*/
           

            Rd_Inv_Type.SelectedValue=dss.Tables[1].Rows[0]["IMP_EXP"].ToString();
            Rd_Bill_Type.SelectedValue=dss.Tables[1].Rows[0]["LOCAL_OTHER"].ToString();

            ddlCustomer_name.Items.Insert(0, new ListItem(dss.Tables[1].Rows[0]["CUSTOMER_NAME"].ToString(), dss.Tables[1].Rows[0]["CUSTOMER_NAME"].ToString()));
            ddlCustomer_name.SelectedIndex = 0;

            ddlbranch_No.Items.Insert(0, new ListItem(dss.Tables[1].Rows[0]["BRANCH_DETAILS"].ToString(), dss.Tables[1].Rows[0]["BRANCH_DETAILS"].ToString()));
            ddlbranch_No.SelectedIndex = 0;
            
            txtInvoiceNo.Text = dss.Tables[1].Rows[0]["BILL_INV_NO"].ToString();
            txtDate.Text = dss.Tables[1].Rows[0]["BILL_INV_DATE"].ToString(); 
            txt_Manual_Jobno.Text = dss.Tables[1].Rows[0]["MANUAL_JOBNO"].ToString();
            txt_Job_Details.Text = dss.Tables[1].Rows[0]["CHA_JOB_DETAILS"].ToString();
            txt_To_Customer_name.Text = dss.Tables[1].Rows[0]["TO_CUSTOMER_NAME"].ToString();
            txt_To_Add.Text = dss.Tables[1].Rows[0]["CUSTOMER_ADDRESS"].ToString();


            txtnon_tax_amt.Text = dss.Tables[1].Rows[0]["NON_TAXABLE_AMT"].ToString();
            txttax_amt.Text = dss.Tables[1].Rows[0]["TAXABLE_AMT"].ToString();

            txt_total_tax_amt.Text = dss.Tables[1].Rows[0]["TOTAL_TAX_AMT"].ToString();
            txt_total_amt_With_tax.Text = dss.Tables[1].Rows[0]["TOTAL_AMT_TAX"].ToString();

            if(dss.Tables[1].Rows[0]["STATE_NAME"].ToString()!="")
            {
                string[] arr = new string[] { };
                arr=dss.Tables[1].Rows[0]["STATE_NAME"].ToString().Replace("--","_").Split('_');
                ddl_state_name.SelectedValue=arr[1].ToString();
                txt_GSTN_Id.Text = dss.Tables[1].Rows[0]["GSTN_ID"].ToString();
            }
        }

        gv_Chg_Details.Visible = true;

        if (dss.Tables[2].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[2];
            gv_Chg_Details.DataBind();

            DataTable firstTable = dss.Tables[2];
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
        txtfocus.Focus();
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

                    //drCurrentRow["RowNumber"] = i + 1;

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
                      
                            if (txtInvoiceNo.Text != string.Empty)
                            {
                                //--------------------------------------------------------------------------------------------------------------------------

                                Billing_Invoice_Jobno_Insert_Update(ddlCustomer_name.SelectedValue.ToString(), "S", Product_details());
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
                                    HDupdate_id.Value = Convert.ToString(GBC.UPDATE_ID);
                                    HD_I_E.Value = Rd_Inv_Type.SelectedValue.ToString();
                                    //HdtxtInvoiceNo_id.Value = Convert.ToString(BI.UPDATE_ID);
                                    btnrpt.Visible = true;
                                  
                                    F.Visible = false;
                                    T.Visible = true;
                                  

                                    HD_Bill_Jobno.Value = txtInvoiceNo.Text;

                                    ddlCustomer_name.Attributes.Add("readonly", "readonly");
                                    ddlCustomer_name.Style.Add("background-color", "#F0F0F0");

                                    txtInvoiceNo.Attributes.Add("readonly", "readonly");
                                    txtInvoiceNo.Style.Add("background-color", "#F0F0F0");

                                    ddlCustomer_name.Enabled = false;

                                    ddlbranch_No.Attributes.Add("readonly", "readonly");
                                    ddlbranch_No.Style.Add("background-color", "#F0F0F0");
                                    
                                    ddlbranch_No.Enabled = false;
                                    Rd_Inv_Type.Enabled = false;

                                    btnloadData.Visible = false;
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
                            else
                            {
                                Alert_msg("Enter Ur Invoice Number!", "txtInvoiceNo");
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
                        HD_I_E.Value = Rd_Inv_Type.SelectedValue.ToString();
                        HD_Bill_Jobno.Value = txtInvoiceNo.Text;
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
            ObjUBO.TYPE = HD_I_E.Value.ToString();
            ObjUBO.BILL_INV_NO = HD_Bill_Jobno.Value.ToString();
            ObjUBO.Flag = "D";

            GBC.Imp_Exp_Invoice_INS_UPD(ObjUBO);
            i = GBC.result;

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

  
    public int Billing_Invoice_Jobno_Insert_Update(string Customer_Name , string flg, String xmlData_D )
    {

        ObjUBO.ID = HDupdate_id.Value.ToString();
        ObjUBO.TYPE=Rd_Inv_Type.SelectedValue.ToString();
        ObjUBO.TYPE_OF_INVOICE=Rd_Bill_Type.SelectedValue.ToString();
        ObjUBO.SHIPPER_ADDRESS=ddlCustomer_name.SelectedValue.ToString();
        ObjUBO.Branch_No_Loc = ddlbranch_No.SelectedItem.ToString();

        string values = "", Items = "";
            foreach (ListItem objItem in cbList.Items)
            {
                if (objItem.Selected)
                {
                    values += objItem.Value + ",";
                    Items += objItem.Text + ",";
                }
            }

        ObjUBO.CH_DESCRIPTION =  values;
        ObjUBO.FILE_REF_NO = Items;
        ObjUBO.BILL_INV_NO = txtInvoiceNo.Text;
        ObjUBO.BILL_INV_DATE = txtDate.Text;
        ObjUBO.YOUR_REF =txt_Manual_Jobno.Text;
        ObjUBO.DESTINATION=txt_Job_Details.Text;
        ObjUBO.NOTIFY_PARTY_1=txt_To_Customer_name.Text;
        ObjUBO.NOTIFY_PARTY_1_ADDRESS=txt_To_Add.Text;
        ObjUBO.REMARKS=string.Empty;
        ObjUBO.NON_TAXABLE_AMT = txtnon_tax_amt.Text;
        ObjUBO.TAXABLE_AMT = txttax_amt.Text;
        ObjUBO.TOTAL_TAX_AMT = txt_total_tax_amt.Text;
        ObjUBO.TOTAL_AMT_TAX = txt_total_amt_With_tax.Text;
        ObjUBO.ADVANCE_AMT = txt_Adv_amt.Text;
        ObjUBO.Xml_D = xmlData_D;
        ObjUBO.TOT_REVERSE_TAX_AMT = txt_tot_Rev_Amt.Text;
        ObjUBO.Flag = flg;
        ObjUBO.State_Name = ddl_state_name.SelectedItem.ToString();
        ObjUBO.GSTN_ID = txt_GSTN_Id.Text;

         GBC.Imp_Exp_Invoice_INS_UPD(ObjUBO);
         i = GBC.result;
        
        return i;
    }
    private void Clear()
    {
        cl();
        HD_Bill_Jobno.Value = string.Empty;
    }
    private void cl()
    {
        txtInvoiceNo.Text = string.Empty;
        txtnon_tax_amt.Text = string.Empty;
        txttax_amt.Text = string.Empty;

        txt_total_tax_amt.Text = string.Empty;
        txt_total_amt_With_tax.Text = string.Empty;
        txt_tot_Rev_Amt.Text = string.Empty;
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
            ddlCustomer_name.Items.Clear();
            DataSet dss = new DataSet();
            ObjUBO.Flag = "Clients_List";
            dss = GBC.GST_Bill_Consolidate_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlCustomer_name.DataSource = dss.Tables[0];
                ddlCustomer_name.DataTextField = "IMP_EXP_NAME";
                ddlCustomer_name.DataValueField = "IMP_EXP_NAME";
                ddlCustomer_name.DataBind();
            }
            
            ddlCustomer_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCustomer_name.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    

    protected void ddlCustomer_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Branch();
    }

    private void Load_Branch()
    {
        ddlbranch_No.Items.Clear();
        cbList.Items.Clear();

        if (ddlCustomer_name.SelectedValue.ToString() != string.Empty)
        {
            DataSet dss = new DataSet();
            ObjUBO.Imp_Name = ddlCustomer_name.SelectedValue.ToString();
            ObjUBO.BILL_TYPE = Rd_Inv_Type.SelectedValue.ToString();
            ObjUBO.Flag = "Branch_List";
            dss = GBC.GST_Bill_Consolidate_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlbranch_No.DataSource = dss.Tables[0];
                ddlbranch_No.DataTextField = "Branch";
                ddlbranch_No.DataValueField = "Branch_Slno";
                ddlbranch_No.DataBind();
            }
            ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlbranch_No.SelectedIndex = 0;

            if (dss.Tables[1].Rows.Count > 0)
            {
                cbList.DataSource = dss.Tables[1];
                cbList.DataTextField = "FILE_REF_NO";
                cbList.DataValueField = "JOBNO";
                cbList.DataBind();
            }
            if (dss.Tables[0].Rows.Count == 1)
            {
                txt_To_Add.Text = dss.Tables[0].Rows[0]["Cus_Address"].ToString();
                ddlbranch_No.SelectedValue = dss.Tables[0].Rows[0]["Branch_Slno"].ToString();

                if (dss.Tables[0].Rows[0]["State_Name"].ToString() != string.Empty)
                {
                    ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["State_Name"].ToString();
                    txt_GSTN_Id.Text = dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
                }
                else
                {
                    ddl_state_name.SelectedIndex = -1;
                    txt_GSTN_Id.Text = string.Empty;
                }
            }
            else
            {
                txt_To_Add.Text = string.Empty;
                ddl_state_name.SelectedIndex = -1;
                txt_GSTN_Id.Text = string.Empty;
            }

            txt_To_Customer_name.Text = ddlCustomer_name.SelectedValue.ToString();
            SetInitialRow();
        }
        else
        {
            Clear_II();
        }
       
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

                //SetPreviousData();
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
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        hd_hss_br_sl_no.Value = "";

        ViewState["UPDATED_ID"] = null;

        ddlbranch_No.Enabled = true;
        btnloadData.Visible = true;
        Rd_Inv_Type.Enabled = true;
        Rd_Bill_Type.Enabled = true;
        CalendarExtender1.Enabled = true;
        btnSave.Visible = true;
        ddlCustomer_name.Enabled = true;
        ddlbranch_No.Enabled = true;

        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnrpt.Visible = false;

        DataTable dt = new DataTable();
        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();
        
        HDupdate_id.Value = string.Empty;
        HdtxtInvoiceNo_id.Value = string.Empty;
        
        txtInvoiceNo.Attributes.Remove("readonly");
        ddlbranch_No.Attributes.Remove("readonly");
        txtInvoiceNo.Style.Add("background-color", "white");
        ddlCustomer_name.Style.Add("background-color", "white");
        ddlbranch_No.Style.Add("background-color", "white");

        SetInitialRow();
        Clear();
        load_date();
        load_Imp_name();

        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        ddlbranch_No.Items.Clear();
        cbList.Items.Clear();

        ddl_state_name.SelectedIndex = -1;
        txt_GSTN_Id.Text = string.Empty;
    }
    [System.Web.Services.WebMethod]
    public static string Get_Importer_Inv_Chk(string Inv_no, string Id, string Branch)
    {
        GST_Bill_Consolidate BC = new GST_Bill_Consolidate();
        Billing_UserBO ObjUBO = new Billing_UserBO();

        if (Inv_no != string.Empty)
        {
            DataSet dss = new DataSet();
            ObjUBO.BILL_TYPE = Id;
            ObjUBO.Imp_Name = Inv_no;
            ObjUBO.Flag = "Imp_Inv_No_Check";
            dss = BC.GST_Bill_Consolidate_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                Inv_no = "No";
            }
            else
            {
                Inv_no = "Yes";
            }
        }
        else
        {
            Inv_no = "Yes";
        }
        return Inv_no;
    }
    
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    
    private void clear_Other_Inv()
    {
        txtInvoiceNo.Text = string.Empty;
        txtnon_tax_amt.Text = string.Empty;
        txttax_amt.Text = string.Empty;

        txt_total_tax_amt.Text = string.Empty;
        txt_total_amt_With_tax.Text = string.Empty;
        txt_tot_Rev_Amt.Text = string.Empty;

        hd_hss_br_sl_no.Value = "";
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
        DataSet ds = new DataSet();
        try
        {
            string Charge_Modee = string.Empty;
            Billing_Imp_Invoice BII = new Billing_Imp_Invoice();
           
            BII.Imp_Name = ChargeName;
            BII.Mode = Mode + " Import";
            BII.Branch = Connection.Get_Company_Type();
            BII.Mflag = "GST_Imp_EXP_Charge_type";
            ds = BII.Select_IMP_INV();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Charge_Modee = ds.Tables[0].Rows[0]["TAX_MODE"].ToString();
                ChargeName = Charge_Modee;
            }
            else
            {
                ChargeName = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ChargeName;
    }
    protected void Rd_Inv_Type_SelectedIndexChanged(object sender, EventArgs e)
    {

        load_Imp_name();

        DataTable dt = new DataTable();

        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();

        clear_Other_Inv();
        SetInitialRow();

        ddlbranch_No.Items.Clear();
        cbList.Items.Clear();

        ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlbranch_No.SelectedIndex = 0;

        ddlCustomer_name.SelectedIndex = -1;
        ddlbranch_No.SelectedIndex = -1;
    }
    protected void Rd_Bill_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Imp_name();
        ddlCustomer_name_SelectedIndexChanged(sender, e);
    }
    
    protected void ddlbranch_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        cbList.Items.Clear();
        if (ddlCustomer_name.SelectedValue.ToString() != string.Empty )
        {
            DataSet dss = new DataSet();
            ObjUBO.Imp_Name = ddlCustomer_name.SelectedValue.ToString();
            ObjUBO.CHARGE_NAME = ddlbranch_No.SelectedValue.ToString();
            ObjUBO.BILL_TYPE = Rd_Inv_Type.SelectedValue.ToString();
            ObjUBO.Flag = "Jobno_List";
            dss = GBC.GST_Bill_Consolidate_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                cbList.DataSource = dss.Tables[0];
                cbList.DataTextField = "FILE_REF_NO";
                cbList.DataValueField = "JOBNO";
                cbList.DataBind();
            }

            if (dss.Tables[1].Rows.Count > 0)
            {
                txt_To_Add.Text=dss.Tables[1].Rows[0][0].ToString();

                if (dss.Tables[1].Rows[0]["State_Name"].ToString() != string.Empty)
                {
                    ddl_state_name.SelectedValue = dss.Tables[1].Rows[0]["State_Name"].ToString();
                    txt_GSTN_Id.Text = dss.Tables[1].Rows[0]["GSTN_ID"].ToString();
                }
                else
                {
                    ddl_state_name.SelectedIndex = -1;
                    txt_GSTN_Id.Text = string.Empty;
                }
            }
            else
            {
                txt_To_Add.Text = string.Empty;
                ddl_state_name.SelectedIndex = -1;
                txt_GSTN_Id.Text = string.Empty;
            }
        }
       
    }
    protected void btnloadData_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ddlCustomer_name.SelectedValue.ToString() != string.Empty)
        {
            string values = "";
            foreach (ListItem objItem in cbList.Items)
            {
                if (objItem.Selected)
                {
                    values += objItem.Value + ",";
                }
            }
            /*if (values != string.Empty)
            {*/
                ObjUBO.Imp_Name = ddlCustomer_name.SelectedValue.ToString();
                ObjUBO.CHARGE_NAME = values;
                ObjUBO.BILL_TYPE = Rd_Inv_Type.SelectedValue.ToString();
                ObjUBO.Flag = "Get_CHA_Job_Data";
                ds = GBC.GST_Bill_Consolidate_Select(ObjUBO);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_Job_Details.Text=ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    txt_Job_Details.Text = string.Empty;
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtInvoiceNo.Text = ds.Tables[1].Rows[0][0].ToString();
                }
                else
                {
                    txtInvoiceNo.Text = string.Empty;
                }
           // }
        }
        else
        {
            Alert_msg("Select Customer Name!", "ddlCustomer_name");
        }
        
    }

    private void Clear_II()
    {
        txtnon_tax_amt.Text = string.Empty;
        txttax_amt.Text = string.Empty;

        txt_total_tax_amt.Text = string.Empty;
        txt_total_amt_With_tax.Text = string.Empty;
        txt_tot_Rev_Amt.Text = string.Empty;

        
        txt_Manual_Jobno.Text = string.Empty;
        
        ddlbranch_No.Items.Clear();
        ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlbranch_No.SelectedIndex = 0;
        cbList.Items.Clear();

        txt_To_Customer_name.Text = string.Empty;
        txt_To_Add.Text = string.Empty;
        txt_Job_Details.Text = string.Empty;
        ddl_state_name.SelectedIndex = -1;
        txt_GSTN_Id.Text = string.Empty;
    }

}