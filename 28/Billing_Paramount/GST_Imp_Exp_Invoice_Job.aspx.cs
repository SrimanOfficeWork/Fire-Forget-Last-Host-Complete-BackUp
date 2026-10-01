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

    GST_Billing_Paramount BP = new GST_Billing_Paramount();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        CalendarExtender1.EndDate = DateTime.Today;
        if (!Page.IsPostBack)
        {
            DataTable dtt = new DataTable();
            GV.DataSource = dtt;
            GV.DataBind();

            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnrpt.Visible = false;
            T.Visible = false;

            txttax_amt.Attributes.Add("readonly", "readonly");
            txt_Expense_Amt.Attributes.Add("readonly", "readonly");
            Load_Bank_Details();
            Checked_Jobs();
            if (Request.QueryString["Page"] == null)
            {
                load_Cus_name();
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                HDupdate_id.Value = "";
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {

                    Update_Item_Load();
                    ViewState["UPDATED_ID"] = Request.QueryString["Billinvno"].ToString();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    txtInvoiceNo.Enabled = false;
                    ddlCus_name.Enabled = false;
                    Rd_Imp_Exp.Enabled = false;
                    Rd_Bill_Type.Enabled = false;
                    ddlbranch_No.Enabled = false;
                    HD_Showcon.Value = "SAVED";
                    btnrpt.Visible = true;
                }
            }
        }
        txt_Cus_name.Attributes.Add("onblur", "javascript:CallServerside_Customer('" + txt_Cus_name.ClientID + "', '" + txtInvoiceNo.ClientID + "')");
        //txtInvoiceNo.Attributes.Add("onblur", "javascript:CallServerside_IMP_INVCHK('" + txtInvoiceNo.ClientID + "', '" + txtInvoiceNo.ClientID + "')");
    }
    private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        ddlCus_name.Items.Clear();
        ObjUBO.A1 = Request.QueryString["Billinvno"].ToString();
        ObjUBO.A7 = Request.QueryString["IMP_EXP"].ToString();
        ObjUBO.A4 = Request.QueryString["Page"].ToString();
        ObjUBO.A8 = "Billing_Updated_Data";
        dss = BP.Select_Inv(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            //-----------------------BA--S---------------------------------------
            HDupdate_id.Value = dss.Tables[0].Rows[0]["ID"].ToString();
            HDupdate_IMP_EXP_id.Value = dss.Tables[0].Rows[0]["IMP_EXP"].ToString();
            Rd_Imp_Exp.SelectedValue = dss.Tables[0].Rows[0]["IMP_EXP"].ToString();

            ddlCus_name.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["CUS_NAME"].ToString(), dss.Tables[0].Rows[0]["CUS_NAME"].ToString()));
            ddlCus_name.SelectedIndex = 0;

            ddlbranch_No.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["CUS_BRANCH_NO_LOC"].ToString(), dss.Tables[0].Rows[0]["CUS_BRANCH_NO"].ToString()));
            ddlbranch_No.SelectedIndex = 0;

            From_Quotation.Checked = Convert.ToBoolean(dss.Tables[0].Rows[0]["FROM_QUOTATION"].ToString());

            txtInvoiceNo.Text = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            txtDate.Text = dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();
            txt_Cus_name.Text = dss.Tables[0].Rows[0]["PARTY_NAME"].ToString();

            if (dss.Tables[0].Rows[0]["AC_BEHALF"].ToString() == "Y")
            {
                ch_Behalf.Checked = true;
            }

            ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
            txt_GSTN_Id.Text = dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
            txt_Party_Add.Text = dss.Tables[0].Rows[0]["PARTY_ADDRESS"].ToString();
            Rd_Tax_NonTax.SelectedValue = dss.Tables[0].Rows[0]["TAX_NON_TAX"].ToString();
            Rd_Bill_Type.SelectedValue = dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString();
            ddlbank_name.SelectedValue = dss.Tables[0].Rows[0]["BANK_DETAILS"].ToString();

            ddl_tr_mode.SelectedValue = dss.Tables[0].Rows[0]["MODE"].ToString();
            ddlshipment_type.SelectedValue = dss.Tables[0].Rows[0]["SHIP_TYPE"].ToString();
            txtAccHead.Text = dss.Tables[0].Rows[0]["ACC_HEAD"].ToString();
            txtPONumber.Text = dss.Tables[0].Rows[0]["PO_NO"].ToString();

            txt_Expense_Amt.Text = dss.Tables[0].Rows[0]["EXPENSE_AMT"].ToString();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            cbList.DataSource = dss.Tables[1];
            cbList.DataTextField = "JOBNO_PS";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();
            Billing_Others();
        }
        if (dss.Tables[2].Rows.Count > 0)
        {
            gv_Gen_Item_I.DataSource = dss.Tables[2];
            gv_Gen_Item_I.DataBind();
        }
        else
        {
            gv_Gen_Item_I.DataSource = dt;
            gv_Gen_Item_I.DataBind();
        }

        if (dss.Tables[3].Rows.Count > 0)
        {
            gv_Gen_Item_II.DataSource = dss.Tables[3];
            gv_Gen_Item_II.DataBind();
        }
        else
        {
            gv_Gen_Item_II.DataSource = dt;
            gv_Gen_Item_II.DataBind();
        }

        if (dss.Tables[4].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[4];
            gv_Chg_Details.DataBind();

            DataTable firstTable = dss.Tables[4];
            ViewState["CurrentTable"] = firstTable;
        }
        else
        {
            SetInitialRow();
        }

        if (dss.Tables[5].Rows.Count > 0)
        {
            gv_Gen_Annexure.DataSource = dss.Tables[5];
            gv_Gen_Annexure.DataBind();
        }
        else
        {
            // SetInitialRow();
        }

        if (dss.Tables[6].Rows.Count > 0)
        {
            ddl_cur.SelectedValue = dss.Tables[6].Rows[0]["CUR"].ToString();
            txtEx_Rate.Text = dss.Tables[6].Rows[0]["EX_RATE"].ToString();
        }
    }
    private void load_Cus_name()
    {
        try
        {
            ddlCus_name.Items.Clear();
            DataSet dss = new DataSet();
            ObjUBO.A8 = "Cus_Name_Select";
            dss = BP.Select_Inv(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlCus_name.DataSource = dss.Tables[0];
                ddlCus_name.DataTextField = "Cus_Name";
                ddlCus_name.DataValueField = "Cus_Name";
                ddlCus_name.DataBind();
            }
           ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
           ddlCus_name.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddlCus_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlbranch_No.Items.Clear();
        Clear();
        if (ddlCus_name.SelectedValue.ToString() != string.Empty)
        {
            Load_Branch();
        }
    }
    private void Load_Branch()
    {
        ddlbranch_No.Items.Clear();
        DataSet dss = new DataSet();
        ObjUBO.A2 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A8 = "Cus_Branch_Select";
        dss = BP.Select_Inv(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlbranch_No.DataSource = dss.Tables[0];
            ddlbranch_No.DataTextField = "Branch_Name";
            ddlbranch_No.DataValueField = "Branch_Slno";
            ddlbranch_No.DataBind();
        }
        ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlbranch_No.SelectedIndex = 0;
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
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;
        string Emptyrow = string.Empty,T_N =string.Empty;
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
                    DropDownList txtch_name = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtch_name");
                    TextBox txt_charge_desc = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txt_charge_desc");
                    TextBox txtqty = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtqty");
                   
                    TextBox txtunit_price = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txtunit_price");
                    TextBox txtamt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txtamt");
                    TextBox txtCGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtCGST_RATE");
                    TextBox txtCGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txtCGST_AMT");
                    TextBox txtSGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtSGST_RATE");
                    TextBox txtSGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtSGST_AMT");
                    TextBox txtIGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[11].FindControl("txtIGST_RATE");
                    TextBox txtIGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[12].FindControl("txtIGST_AMT");

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
                        if (txtch_name.SelectedValue.ToString() == string.Empty || txtunit_price.Text == string.Empty || txtunit_price.Text == "0.00" || Amt == string.Empty)
                        {
                            Emptyrow = "Y";
                        }
                    }
                    arr = txtch_name.SelectedValue.ToString().Split('~');
                    T_N = arr[0];

                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["INV_CHECK"] = INV_CHECK.Checked == true ? "True" : "False";
                    drCurrentRow["RowNumber"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["ORDERBY"] = txtOrder_by.Text;
                    dtCurrentTable.Rows[i - 1]["CHARGE_VALUE"] = txtch_name.SelectedValue.ToString();
                    dtCurrentTable.Rows[i - 1]["QTY"] = txtqty.Text;
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

                    /*
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
                    */
                }
                if (Emptyrow != "Y")
                {
                   
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["INV_CHECK"] = "True";
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    drCurrentRow["ORDERBY"] = dtCurrentTable.Rows.Count + 1;
                    drCurrentRow["CHARGE_VALUE"] = string.Empty;
                    drCurrentRow["QTY"] = "1";
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
                    DropDownList txtch_name = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("txtch_name");
                    TextBox txt_charge_desc = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("txt_charge_desc");
                    TextBox txtOrder_by = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtOrder_by");
                    TextBox txtqty = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtqty");

                    TextBox txtunit_price = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtunit_price");
                    TextBox txtamt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txtamt");
                    TextBox txtCGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txtCGST_RATE");
                    TextBox txtCGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtCGST_AMT");
                    TextBox txtSGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txtSGST_RATE");
                    TextBox txtSGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtSGST_AMT");
                    TextBox txtIGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtIGST_RATE");
                    TextBox txtIGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[11].FindControl("txtIGST_AMT");
                    //--------------------------------------------------------------------

                    gv_Chg_Details.Rows[i].Cells[1].Text = Convert.ToString(i + 1);

                    txtch_name.SelectedValue = dt.Rows[i]["CHARGE_VALUE"].ToString();
                    txtOrder_by.Text = dt.Rows[i]["ORDERBY"].ToString();
                    txtqty.Text = dt.Rows[i]["QTY"].ToString();
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
            DropDownList txtch_namefocus = (DropDownList)gv_Chg_Details.Rows[rowIndex - 1].Cells[3].FindControl("txtch_name");
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
                    DataSet ss = new DataSet();
                    //--------------------------------------------------------------------------------------------------------------------------
                    ss = Billing_Invoice_Jobno_Insert_Update(Get_Jobs(), "S", Product_Item_I_details(), Product_Item_II_details(), Product_details(), Product_Annexure_details());
                    if (ss.Tables[0].Rows.Count>0)
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

                                        HDupdate_id.Value = ss.Tables[0].Rows[0][0].ToString();
                                        txtInvoiceNo.Text = ss.Tables[0].Rows[0][1].ToString();
                                        HDupdate_IMP_EXP_id.Value = Rd_Imp_Exp.SelectedValue.ToString();

                                        btnrpt.Visible = true;

                                        F.Visible = false;
                                        T.Visible = true;
                                        
                                        ddlCus_name.Enabled = false;
                                        ddlbranch_No.Enabled = false;
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
        DataSet dr = new DataSet();
        try
        {
                dr = Billing_Invoice_Jobno_Insert_Update(Get_Jobs(), "U", Product_Item_I_details(), Product_Item_II_details(), Product_details(), Product_Annexure_details());
                if (dr.Tables[0].Rows.Count > 0)
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
            DataSet dss = new DataSet();
            ObjUBO.A1 = txtInvoiceNo.Text;
            ObjUBO.A8 = "Delete";
            dss = BP.Select_Inv(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Not Deleted");
            }
            else
            {
                btnNew_Click1(sender, e);
                Alert_msg("Deleted");
                btnrpt.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private string Product_Item_I_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("TR_MODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("FILE_REF_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("PARTY_REF_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("NO_OF_PKGS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("PKGS_TYPE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("FLT_VSL_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MAWB_MBL_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MAWB_MBL_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("HAWB_HBL_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("HAWB_HBL_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("GROSS_WGT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("GROSS_WGT_TYPE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("NET_WGT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("NET_WGT_TYPE", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in gv_Gen_Item_I.Rows)
        {
            TextBox txt_Jobno = (TextBox)row.FindControl("txt_Jobno_I");
            TextBox txt_tr_mode = (TextBox)row.FindControl("txt_tr_mode");
            TextBox txt_file_Refno = (TextBox)row.FindControl("txt_file_Refno");
            TextBox txt_Party_Refno = (TextBox)row.FindControl("txt_Party_Refno");
            TextBox txt_no_of_pkg = (TextBox)row.FindControl("txt_no_of_pkg");
            TextBox txt_no_of_pkg_type = (TextBox)row.FindControl("txt_no_of_pkg_type");
            TextBox txt_flt_vessel_no = (TextBox)row.FindControl("txt_flt_vessel_no");
            TextBox txt_MAWB_MBL = (TextBox)row.FindControl("txt_MAWB_MBL");
            TextBox txt_MAWB_MBL_Date = (TextBox)row.FindControl("txt_MAWB_MBL_Date");
            TextBox txt_HAWB_HBLNO = (TextBox)row.FindControl("txt_HAWB_HBLNO");
            TextBox txt_HAWB_HBLDATE = (TextBox)row.FindControl("txt_HAWB_HBLDATE");
            TextBox txt_Gross_Wgt = (TextBox)row.FindControl("txt_Gross_Wgt");
            TextBox txt_Gross_Wgt_Type = (TextBox)row.FindControl("txt_Gross_Wgt_Type");
            TextBox txt_net_Wgt = (TextBox)row.FindControl("txt_net_Wgt");
            TextBox txt_net_Wgt_Type = (TextBox)row.FindControl("txt_net_Wgt_Type");

            dr = dtt.NewRow();
            dr[0] = txt_Jobno.Text;
            dr[1] = txt_tr_mode.Text;
            dr[2] = txt_file_Refno.Text;
            dr[3] = txt_Party_Refno.Text;
            dr[4] = txt_no_of_pkg.Text;
            dr[5] = txt_no_of_pkg_type.Text;
            dr[6] = txt_flt_vessel_no.Text;
            dr[7] = txt_MAWB_MBL.Text;
            dr[8] = txt_MAWB_MBL_Date.Text;
            dr[9] = txt_HAWB_HBLNO.Text;
            dr[10] = txt_HAWB_HBLDATE.Text;
            dr[11] = txt_Gross_Wgt.Text;
            dr[12] = txt_Gross_Wgt_Type.Text;
            dr[13] = txt_net_Wgt.Text;
            dr[14] = txt_net_Wgt_Type.Text;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private string Product_Item_II_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("INV_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("INV_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ITEM_DESC", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ASS_VALUE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DUTY_VALUE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CIF_VALUE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BE_SB_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BE_SB_DATE", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in gv_Gen_Item_II.Rows)
        {
            TextBox txt_Jobno = (TextBox)row.FindControl("txt_Jobno_II");
            TextBox txt_Inv_No = (TextBox)row.FindControl("txt_Inv_No");
            TextBox txt_Inv_Date = (TextBox)row.FindControl("txt_Inv_Date");
            TextBox txt_Item_Dec = (TextBox)row.FindControl("txt_Item_Dec");
            TextBox txt_Ass_Value = (TextBox)row.FindControl("txt_Ass_Value");
            TextBox txt_Duty_Value = (TextBox)row.FindControl("txt_Duty_Value");
            TextBox txt_CIF_Value = (TextBox)row.FindControl("txt_CIF_Value");
            TextBox txt_BE_SB_NO = (TextBox)row.FindControl("txt_BE_SB_NO");
            TextBox txt_BE_SB_DATE = (TextBox)row.FindControl("txt_BE_SB_DATE");

            dr = dtt.NewRow();
            dr[0] = txt_Jobno.Text;
            dr[1] = txt_Inv_No.Text;
            dr[2] = txt_Inv_Date.Text;
            dr[3] = txt_Item_Dec.Text;
            dr[4] = txt_Ass_Value.Text;
            dr[5] = txt_Duty_Value.Text;
            dr[6] = txt_CIF_Value.Text;
            dr[7] = txt_BE_SB_NO.Text;
            dr[8] = txt_BE_SB_DATE.Text;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private string Product_details()
    {
        string[] ar = new string[] { };

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
            DropDownList txtch_name = (DropDownList)row.FindControl("txtch_name");
            TextBox txt_charge_desc = (TextBox)row.FindControl("txt_charge_desc");
            //DropDownList ddl_tax_nontax = (DropDownList)row.FindControl("ddl_tax_nontax");
            TextBox txtqty = (TextBox)row.FindControl("txtqty");
            
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
                ar = txtch_name.SelectedValue.ToString().Split('~');
                dr = dtt.NewRow();
                dr[0] = INV_CHECK.Checked == true ? "True" : "False";
                dr[1] = ar[1];//txtch_name.SelectedValue.ToString();
                dr[2] = ar[0];//ddl_tax_nontax.SelectedValue.ToString();

                dr[3] = "";
                dr[4] = "";
                dr[5] = txtqty.Text;
                dr[6] = ddl_cur.SelectedValue.ToString();
                dr[7] = txtEx_Rate.Text; 
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
    private string Product_Annexure_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_A", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_B", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_C", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_D", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_E", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_F", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_G", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_H", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_I", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_J", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_K", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_L", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_M", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_N", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CH_AMT_O", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in gv_Gen_Annexure.Rows)
        {
            TextBox txt_Anx_Jobno = (TextBox)row.FindControl("txt_Anx_Jobno");
            TextBox txt_Ch_Amt_A = (TextBox)row.FindControl("txt_Ch_Amt_A");
            TextBox txt_Ch_Amt_B = (TextBox)row.FindControl("txt_Ch_Amt_B");
            TextBox txt_Ch_Amt_C = (TextBox)row.FindControl("txt_Ch_Amt_C");
            TextBox txt_Ch_Amt_D = (TextBox)row.FindControl("txt_Ch_Amt_D");
            TextBox txt_Ch_Amt_E = (TextBox)row.FindControl("txt_Ch_Amt_E");
            TextBox txt_Ch_Amt_F = (TextBox)row.FindControl("txt_Ch_Amt_F");
            TextBox txt_Ch_Amt_G = (TextBox)row.FindControl("txt_Ch_Amt_G");
            TextBox txt_Ch_Amt_H = (TextBox)row.FindControl("txt_Ch_Amt_H");
            TextBox txt_Ch_Amt_I = (TextBox)row.FindControl("txt_Ch_Amt_I");
            TextBox txt_Ch_Amt_J = (TextBox)row.FindControl("txt_Ch_Amt_J");
            TextBox txt_Ch_Amt_K = (TextBox)row.FindControl("txt_Ch_Amt_K");
            TextBox txt_Ch_Amt_L = (TextBox)row.FindControl("txt_Ch_Amt_L");
            TextBox txt_Ch_Amt_M = (TextBox)row.FindControl("txt_Ch_Amt_M");
            TextBox txt_Ch_Amt_N = (TextBox)row.FindControl("txt_Ch_Amt_N");
            TextBox txt_Ch_Amt_O = (TextBox)row.FindControl("txt_Ch_Amt_O");

            dr = dtt.NewRow();
            dr[0] = txt_Anx_Jobno.Text;
            dr[1] = txt_Ch_Amt_A.Text;
            dr[2] = txt_Ch_Amt_B.Text;
            dr[3] = txt_Ch_Amt_C.Text;
            dr[4] = txt_Ch_Amt_D.Text;
            dr[5] = txt_Ch_Amt_E.Text;
            dr[6] = txt_Ch_Amt_F.Text;
            dr[7] = txt_Ch_Amt_G.Text;
            dr[8] = txt_Ch_Amt_H.Text;
            dr[9] = txt_Ch_Amt_I.Text;
            dr[10] = txt_Ch_Amt_J.Text;
            dr[11] = txt_Ch_Amt_K.Text;
            dr[12] = txt_Ch_Amt_L.Text;
            dr[13] = txt_Ch_Amt_M.Text;
            dr[14] = txt_Ch_Amt_N.Text;
            dr[15] = txt_Ch_Amt_O.Text;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    public DataSet Billing_Invoice_Jobno_Insert_Update(string Jobs, string S1, String xmlData_A, String xmlData_B, String xmlData_C, String xmlData_D)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A3 = Rd_Bill_Type.SelectedValue.ToString();
        ObjUBO.A4 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A5 = ddlbranch_No.SelectedValue.ToString();
        ObjUBO.A23 = ddlbranch_No.SelectedItem.ToString();

        ObjUBO.A6 = From_Quotation.Checked.ToString();
        ObjUBO.A7 = Jobs; 
        ObjUBO.A8 = txtInvoiceNo.Text;
        ObjUBO.A9 = txtDate.Text;
        ObjUBO.A10 = txt_Cus_name.Text;
        ObjUBO.A11 = ch_Behalf.Checked == true ? "Y" : "N"; 
        ObjUBO.A12 = ddl_state_name.SelectedValue.ToString();
        ObjUBO.A13 = txt_GSTN_Id.Text;
        ObjUBO.A14 = txt_Party_Add.Text;

        ObjUBO.A15 = "0";// txtnon_tax_amt.Text;
        ObjUBO.A16 = txttax_amt.Text;
        ObjUBO.A17 = "0";  // txt_tot_Rev_Amt.Text;
        ObjUBO.A18 = "0"; // txt_total_tax_amt.Text;
        ObjUBO.A19 = "0"; //txt_total_amt_With_tax.Text;
        ObjUBO.A20 = txt_grand_total.Text;
        ObjUBO.A21 = txt_Adv_amt.Text;
        ObjUBO.A22 = txt_Expense_Amt.Text;
        ObjUBO.A24 = Rd_Tax_NonTax.SelectedValue.ToString();
        ObjUBO.A25 = ddlbank_name.SelectedValue.ToString();

        ObjUBO.A26 = ddl_tr_mode.SelectedValue.ToString();
        ObjUBO.A27 = ddlshipment_type.SelectedValue.ToString();
        ObjUBO.A35 = xmlData_A;
        ObjUBO.A36 = xmlData_B;
        ObjUBO.A37 = xmlData_C;
        ObjUBO.A38 = xmlData_D;
        ObjUBO.A39 = S1;
        ObjUBO.A40 = txtAccHead.Text;
        ObjUBO.A41 = txtPONumber.Text;
        return BP.Billing_Invoice_INS_UPD(ObjUBO);
    }
    private void Clear()
    {
        txtInvoiceNo.Text = string.Empty;
        ch_Behalf.Checked = false;
        txt_Cus_name.Text = string.Empty;
        txtDate.Text = string.Empty;

        txt_Party_Add.Text = string.Empty;
        txttax_amt.Text = string.Empty;

        ddl_state_name.Text = string.Empty;
        txt_GSTN_Id.Text = string.Empty;
        txt_Expense_Amt.Text = string.Empty;
        cbList.Items.Clear();

        ddl_tr_mode.SelectedIndex = -1;
        ddlshipment_type.SelectedIndex = -1;
    }
    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Ch_name_select = string.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TextBox txtamt = (e.Row.FindControl("txtamt") as TextBox);
            TextBox txtCGST_RATE = (e.Row.FindControl("txtCGST_RATE") as TextBox);
            TextBox txtSGST_RATE = (e.Row.FindControl("txtSGST_RATE") as TextBox);
            TextBox txtIGST_RATE = (e.Row.FindControl("txtIGST_RATE") as TextBox);
            TextBox txtCGST_AMT = (e.Row.FindControl("txtCGST_AMT") as TextBox);
            TextBox txtSGST_AMT = (e.Row.FindControl("txtSGST_AMT") as TextBox);
            TextBox txtIGST_AMT = (e.Row.FindControl("txtIGST_AMT") as TextBox);

            Ch_name_select = this.gv_Chg_Details.DataKeys[e.Row.RowIndex]["CHARGE_VALUE"].ToString();
            DropDownList ddlchname = (e.Row.FindControl("txtch_name") as DropDownList);

            txtamt.Attributes.Add("readonly", "readonly");
            txtCGST_RATE.Attributes.Add("readonly", "readonly");
            txtSGST_RATE.Attributes.Add("readonly", "readonly");
            txtIGST_RATE.Attributes.Add("readonly", "readonly");
            txtIGST_AMT.Attributes.Add("readonly", "readonly");
            txtCGST_AMT.Attributes.Add("readonly", "readonly");
            txtSGST_AMT.Attributes.Add("readonly", "readonly");

            //---------------------

            DropDownList ddlch_name = (e.Row.FindControl("txtch_name") as DropDownList);
            if (ViewState["CurrentTable_Ch"] != null && ViewState["CurrentTable_Ch"] != string.Empty)
            {
                DataSet dtt = (DataSet)ViewState["CurrentTable_Ch"];
                ddlch_name.DataSource = dtt.Tables[0];
                ddlch_name.DataTextField = "CHARGE_NAME";
                ddlch_name.DataValueField = "CHARGE_VALUE";
                ddlch_name.DataBind();
            }
            else
            {
                DataSet ss = new DataSet();
                ss = load_Charge_Name();
                ViewState["CurrentTable_Ch"] = ss;
                ddlch_name.DataSource = ss;
                ddlch_name.DataTextField = "CHARGE_NAME";
                ddlch_name.DataValueField = "CHARGE_VALUE";
                ddlch_name.DataBind();
            }
           
            //Add Default Item in the DropDownList.
            //ddlch_name.Items.Insert(0, new ListItem("Please select"));
            //------------------------------------------------------------
            //Select the Country of Customer in DropDownList.
            //ddlch_name.Items.FindByValue(Ch_name_select).Selected = true;


            ddlch_name.Items.Insert(0, new ListItem(""));
            ddlch_name.Items.FindByValue(Ch_name_select).Selected = true;

            //--------------------------------------------------------------------------
        }
        //https://www.aspsnippets.com/Articles/Dynamically-add-DropDownList-in-ASPNet-GridView-using-C-and-VBNet.aspx
        //https://www.aspsnippets.com/Articles/Get-Selected-Value-from-DropDownList-in-GridView-in-ASPNet.aspx
    }
    private DataSet load_Charge_Name()
    {
        DataSet dss = new DataSet();
        //ObjUBO.A8 = "Get_Charge_name";
        ObjUBO.A8 = "Get_Charge_name_With_Tax";
        return BP.Select_Inv(ObjUBO);
        //------------------------------------------------------------
        //Select the Country of Customer in DropDownList.
        //string country = (e.Row.FindControl("lblCountry") as Label).Text;
        //ddlch_name.Items.FindByValue(country).Selected = true;
        //--------------------------------------------------------------------------
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

        dt.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("ORDERBY", typeof(string)));
        dt.Columns.Add(new DataColumn("CHARGE_VALUE", typeof(string)));
        dt.Columns.Add(new DataColumn("TAX_NONTAX", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        
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
        dr["CHARGE_VALUE"] = string.Empty;
        dr["TAX_NONTAX"] = "N";
        dr["Qty"] = "1";
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

        ViewState["CurrentTable"] = dt;

        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();

        txttax_amt.Text = "0.00";
    }
    protected void gv_Chg_Details_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
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

                dtnew.Columns.Add(new DataColumn("CHARGE_VALUE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("Qty", typeof(string)));
                
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
                    drnew["CHARGE_VALUE"] = dt.Rows[i][3].ToString();
                    drnew["Qty"] = dt.Rows[i][4].ToString();
                    
                    drnew["UNIT_RATE"] = dt.Rows[i][5].ToString();
                    drnew["AMOUNT"] = dt.Rows[i][6].ToString();
                    drnew["CGST_RATE"] = dt.Rows[i][7].ToString();
                    drnew["CGST_AMT"] = dt.Rows[i][8].ToString();
                    drnew["SGST_RATE"] = dt.Rows[i][9].ToString();
                    drnew["SGST_AMT"] = dt.Rows[i][10].ToString();
                    drnew["IGST_RATE"] = dt.Rows[i][11].ToString();
                    drnew["IGST_AMT"] = dt.Rows[i][12].ToString();
                    drnew["CHARGE_DESC"] = dt.Rows[i][13].ToString();
                    dtnew.Rows.Add(drnew);
                }
                //---------------------------------------------------------------------------------------
                gv_Chg_Details.DataSource = dtnew;
                gv_Chg_Details.DataBind();
            }
            else if (dt.Rows.Count == 1)
            {
                DataTable dtt = new DataTable();
                DataRow drr = null;

                dtt.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));
                dtt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dtt.Columns.Add(new DataColumn("ORDERBY", typeof(string)));
                dtt.Columns.Add(new DataColumn("CHARGE_VALUE", typeof(string)));
                dtt.Columns.Add(new DataColumn("Qty", typeof(string)));
                
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
                drr["CHARGE_VALUE"] = string.Empty;
                drr["Qty"] = "1";
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

                txttax_amt.Text = "0";
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

        ddlCus_name.Enabled = true;
        ddlbranch_No.Enabled = true;
        btnrpt.Visible = false;

        load_Cus_name();
        ddlbranch_No.Items.Clear();
        ddlbranch_No.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlbranch_No.SelectedIndex = 0;

        ddlCus_name.Style.Add("background-color", "white");
        Rd_Bill_Type.Enabled = true;
        Rd_Imp_Exp.Enabled = true;
        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        gv_Gen_Item_I.DataSource = dt;
        gv_Gen_Item_I.DataBind();

        gv_Gen_Item_II.DataSource = dt;
        gv_Gen_Item_II.DataBind();

        gv_Gen_Annexure.DataSource = dt;
        gv_Gen_Annexure.DataBind();
    }

    [System.Web.Services.WebMethod]
    public static string Get_Cus_det(string custid, string Jobno, string Branch)
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
    public static string Get_Importer_Inv_Chk(string custid, string Mode, string Branch)
    {
        GST_Imp_Invoice BI = new GST_Imp_Invoice();
        Billing_UserBO ObjUBO = new Billing_UserBO();

        if (custid != string.Empty)
        {
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = Mode;
            ObjUBO.BILL_INV_NO = custid;
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
    public static string Get_Cha_Type_Rate(string ChargeName, string Local_Other, string Mode)
    {
        string Ch_Name = "";
        DataSet ds = new DataSet();
        try
        {
            string[] arr = new string[] { };
            arr = ChargeName.Split('~');

            GST_Billing_Paramount BI = new GST_Billing_Paramount();
            Global_variables ObjUBO = new Global_variables();

            ObjUBO.A1 = arr[0];
            ObjUBO.A2 = arr[1];
            ObjUBO.A3 = Local_Other;
            ObjUBO.A8 = "GST_Charge_Rate";
            ds = BI.Select_Inv(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Local_Other == "L")
                {
                    Ch_Name = ds.Tables[0].Rows[0]["CGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["SGST_RATE"].ToString() + "~~" + "0";
                }
                else {
                    Ch_Name = "0" + "~~" + "0" + "~~" + ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
                }
                
            }
            else
            {
                Ch_Name = "";
            }
            //------------------------------------
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Ch_Name;
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
            //------------------------------------
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return Ch_Name;
    }
    protected void Rd_Bill_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
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
    protected void btn_Addjobno_Click(object sender, EventArgs e)
    {
        DataSet s = new DataSet();
        if (txt_Jobno.Text != string.Empty)
        {
            ObjUBO.A2 = ddlCus_name.SelectedValue.ToString();
            ObjUBO.A3 = ddlbranch_No.SelectedValue.ToString();
            ObjUBO.A4 = Get_Jobs();
            ObjUBO.A5 = txt_Jobno.Text;
            ObjUBO.A7 = Rd_Imp_Exp.SelectedValue.ToString();
            ObjUBO.A8 = "Bill_Jobno_Validate";
            s = BP.Select_Inv(ObjUBO);
            if (s.Tables[0].Rows.Count > 0)
            {
                Rd_Imp_Exp.Enabled = false;

                cbList.DataSource = s.Tables[0];
                cbList.DataTextField = "JOBNO_PS";
                cbList.DataValueField = "JOBNO";
                cbList.DataBind();

                txt_Jobno.Text = string.Empty;
                Checked_Jobs();
                Billing_Others();
            }
            else
            {
                Alert_msg("Invalid Jobno !");
            }
         
        }
        else
        {
            Alert_msg("Enter Ur Jobno", "txt_Jobno");
        }
    }

    private void Checked_Jobs()
    {
        string values = "", Val=string.Empty;
        foreach (ListItem objItem in cbList.Items)
        {
            values += objItem.ToString() + ",";
        }
        hd_Selected_Jobs.Value = values;
    }

    private void Billing_Others()
    {
        string Val = string.Empty;
        foreach (ListItem objItem in cbList.Items)
        {
            Val += objItem.Value.ToString() + ",";
        }
        hd_Jobs.Value = Val;
        hd_Imp_Exp.Value = Rd_Imp_Exp.SelectedValue.ToString();
        Hdjobno.Value = Val;
        Hd_I_E.Value = Rd_Imp_Exp.SelectedValue.ToString(); 
    }
    protected void GV_Gen_head_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void btnloadData_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
         string values = "";
         values = Get_Jobs();

         if (values != "" && values != string.Empty)
         {
             if (ddlCus_name.SelectedItem.Text != string.Empty && ddlCus_name.SelectedItem.Text != "")
             {
                 Hdjobno.Value = values;
                 Hd_I_E.Value = Rd_Imp_Exp.SelectedValue.ToString(); 
                 DataSet dss = new DataSet();
                 ObjUBO.A1 = ddlshipment_type.SelectedValue.ToString();
                 ObjUBO.A2 = ddlCus_name.SelectedValue.ToString();
                 ObjUBO.A3 = ddlbranch_No.SelectedValue.ToString();
                 ObjUBO.A4 = values;
                 ObjUBO.A5 = ddl_tr_mode.SelectedValue.ToString();
                 ObjUBO.A6 = From_Quotation.Checked.ToString();
                 ObjUBO.A7 = Rd_Imp_Exp.SelectedValue.ToString();
                 ObjUBO.A12 = Rd_Bill_Type.SelectedValue.ToString();
                 
                 if (Rd_Imp_Exp.SelectedValue.ToString() == "I")
                 {
                     ObjUBO.A8 = "Select_Imp_Job_Data";
                     ObjUBO.A15 = "GST_BILL_IMP_COMBINE_JOB_SELECT";
                 }
                 else
                 {
                     ObjUBO.A8 = "Select_Exp_Job_Data";
                     ObjUBO.A15 = "GST_BILL_EXP_COMBINE_JOB_SELECT";
                 }

                 dss = BP.Select_Imp_Exp_Data(ObjUBO);
                 if (dss.Tables[0].Rows.Count > 0)
                 {
                     ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["COMMERCIAL_TAX_STATENAME"].ToString();
                     txt_GSTN_Id.Text = dss.Tables[0].Rows[0]["COMMERCIAL_TAX_REGISTRATION_NO"].ToString();
                     txt_Cus_name.Text = dss.Tables[0].Rows[0]["Party_name"].ToString();
                     txt_Party_Add.Text = dss.Tables[0].Rows[0]["Party_Address"].ToString();
                     Rd_Bill_Type.SelectedValue = dss.Tables[0].Rows[0]["Local_Other"].ToString();
                 }
                 else
                 {
                     ddl_state_name.SelectedValue = string.Empty;
                     txt_GSTN_Id.Text = string.Empty;
                     txt_Cus_name.Text = string.Empty;
                     txt_Party_Add.Text = string.Empty;
                 }

                 if (dss.Tables[1].Rows.Count > 0)
                 {
                     gv_Gen_Item_I.DataSource = dss.Tables[1];
                     gv_Gen_Item_I.DataBind();
                 }
                 else
                 {
                     gv_Gen_Item_I.DataSource = dt;
                     gv_Gen_Item_I.DataBind();
                 }

                 if (dss.Tables[2].Rows.Count > 0)
                 {
                     gv_Gen_Item_II.DataSource = dss.Tables[2];
                     gv_Gen_Item_II.DataBind();
                 }
                 else
                 {
                     gv_Gen_Item_II.DataSource = dt;
                     gv_Gen_Item_II.DataBind();
                 }
                 
                 if (dss.Tables[3].Rows.Count > 0)
                 {
                     gv_Chg_Details.DataSource = dss.Tables[3];
                     gv_Chg_Details.DataBind();

                     ViewState["CurrentTable"] = dss.Tables[3];
                 }
                 else
                 {
                     SetInitialRow();
                 }
                 if (dss.Tables[4].Rows.Count > 0)
                 {
                     txt_Expense_Amt.Text = dss.Tables[4].Rows[0]["Exp_Amount"].ToString();
                 }
                 else
                 {
                     txt_Expense_Amt.Text = "0";
                 }
                 if (dss.Tables[5].Rows. Count> 0)
                 {
                     gv_Gen_Annexure.DataSource = dss.Tables[5];
                     gv_Gen_Annexure.DataBind();
                 }
                 else
                 {
                    // SetInitialRow();
                 }
             }
             else
             {
                 Alert_msg("Select Ur Customer Name", "ddlCus_name");
             }
         }
         else
         {
             Alert_msg("Select Ur Jobno !", "cbList");
         }
    }
    protected void gv_Gen_Annexure_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex == 0)
            {
                TextBox txt_Anx_Jobno = (e.Row.FindControl("txt_Anx_Jobno") as TextBox);
                TextBox txt_Ch_Amt_A = (e.Row.FindControl("txt_Ch_Amt_A") as TextBox);
                TextBox txt_Ch_Amt_B = (e.Row.FindControl("txt_Ch_Amt_B") as TextBox);
                TextBox txt_Ch_Amt_C = (e.Row.FindControl("txt_Ch_Amt_C") as TextBox);
                TextBox txt_Ch_Amt_D = (e.Row.FindControl("txt_Ch_Amt_D") as TextBox);
                TextBox txt_Ch_Amt_E = (e.Row.FindControl("txt_Ch_Amt_E") as TextBox);
                TextBox txt_Ch_Amt_F = (e.Row.FindControl("txt_Ch_Amt_F") as TextBox);
                TextBox txt_Ch_Amt_G = (e.Row.FindControl("txt_Ch_Amt_G") as TextBox);
                TextBox txt_Ch_Amt_H = (e.Row.FindControl("txt_Ch_Amt_H") as TextBox);
                TextBox txt_Ch_Amt_I = (e.Row.FindControl("txt_Ch_Amt_I") as TextBox);
                TextBox txt_Ch_Amt_J = (e.Row.FindControl("txt_Ch_Amt_J") as TextBox);
                TextBox txt_Ch_Amt_K = (e.Row.FindControl("txt_Ch_Amt_K") as TextBox);
                TextBox txt_Ch_Amt_L = (e.Row.FindControl("txt_Ch_Amt_L") as TextBox);
                TextBox txt_Ch_Amt_M = (e.Row.FindControl("txt_Ch_Amt_M") as TextBox);
                TextBox txt_Ch_Amt_N = (e.Row.FindControl("txt_Ch_Amt_N") as TextBox);
                TextBox txt_Ch_Amt_O = (e.Row.FindControl("txt_Ch_Amt_O") as TextBox);

                txt_Anx_Jobno.BackColor = System.Drawing.ColorTranslator.FromHtml("#008000");
                txt_Ch_Amt_A.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_B.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_C.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_D.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_E.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");

                txt_Ch_Amt_F.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_G.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_H.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_I.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_J.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");

                txt_Ch_Amt_K.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_L.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_M.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_N.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Ch_Amt_O.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");

                txt_Ch_Amt_A.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_B.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_C.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_D.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_E.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");

                txt_Ch_Amt_F.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_G.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_H.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_I.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_J.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");

                txt_Ch_Amt_K.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_L.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_M.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_N.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                txt_Ch_Amt_O.ForeColor = System.Drawing.ColorTranslator.FromHtml("#808080");
            }
            else
            {
                TextBox txt_Anx_Jobno = (e.Row.FindControl("txt_Anx_Jobno") as TextBox);
                txt_Anx_Jobno.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
                txt_Anx_Jobno.Enabled = false;
            }
        }
    }
    private string Get_Jobs()
    {
       string values = "";
         foreach (ListItem objItem in cbList.Items)
           {
               values += objItem.Value + ",";
           }
         return values;
    }
    protected void gv_Gen_Item_I_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_I = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_I.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_I.Enabled = false;
        }
    }
    protected void gv_Gen_Item_II_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_II = (e.Row.FindControl("txt_Jobno_II") as TextBox);
            txt_Jobno_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_II.Enabled = false;
        }
    }

    protected void btn_Remove_Click(object sender, EventArgs e)
    {
        DataSet ds_R = new DataSet();
        string Jobs = string.Empty;
        Jobs = Get_Remove_Jobs();
        if (Jobs != string.Empty)
        {
         
           DataSet dss = new DataSet();
           ObjUBO.A4 = Jobs;
           ObjUBO.A7 = Rd_Imp_Exp.SelectedValue.ToString();
           ObjUBO.A8 = "Bill_Job_Remove";

           ObjUBO.A9 = Product_Item_I_details();
           ObjUBO.A10 = Product_Item_II_details();
           ObjUBO.A11 = Product_Annexure_details();
           ds_R = BP.Select_Inv(ObjUBO);
           if (ds_R.Tables[0].Rows.Count > 0)
           {
               gv_Gen_Item_I.DataSource = ds_R.Tables[0];
               gv_Gen_Item_I.DataBind();
           }
           else
           {
               gv_Gen_Item_I.DataSource = dt;
               gv_Gen_Item_I.DataBind();
           }
           if (ds_R.Tables[1].Rows.Count > 0)
           {
               gv_Gen_Item_II.DataSource = ds_R.Tables[1];
               gv_Gen_Item_II.DataBind();
           }
           else
           {
               gv_Gen_Item_II.DataSource = dt;
               gv_Gen_Item_II.DataBind();
           }

           if (ds_R.Tables[2].Rows.Count > 0)
           {
               gv_Gen_Annexure.DataSource = ds_R.Tables[2];
               gv_Gen_Annexure.DataBind();
           }
           else
           {
               gv_Gen_Annexure.DataSource = dt;
               gv_Gen_Annexure.DataBind();
           }

           if (ds_R.Tables[3].Rows.Count > 0)
           {
               cbList.DataSource = ds_R.Tables[3];
               cbList.DataTextField = "JOBNO_PS";
               cbList.DataValueField = "JOBNO";
               cbList.DataBind();
               Billing_Others();
           }
           else
           {
               cbList.Items.Clear();
           }

        }
        else
        {
            Alert_msg("Select Ur Remove Job(s)!");
        }

    }
    private string Get_Remove_Jobs()
    {
        string values = "";
        foreach (ListItem objItem in cbList.Items)
        {
            if (objItem.Selected)
             {
                     values += objItem.Value + ",";
             }
        }
        return values;
    }

    private void Load_Bank_Details()
    {
        string Company_id = Connection.COMPANYID();
        ddlbank_name.Items.Clear();
        ddlbank_name.Items.Add(new ListItem("", ""));
        if (Company_id == "744")
        {
            ddlbank_name.Items.Add(new ListItem("BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD, BANK NAME : IDBI BANK LTD,BRANCH NAME : PARRYS, CURRENT A/C NO : #907102000039127,IFS CODE NO. : IBKL0000907,SWIFT CODE : IBKLINBB005,MICR NO. : 600259007", "BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME        : IDBI BANK LTD,BRANCH NAME      : PARRYS,CURRENT A/C NO   : #907102000039127,IFS CODE NO.     : IBKL0000907,SWIFT CODE       : IBKLINBB005,MICR NO.         : 600259007"));
            ddlbank_name.Items.Add(new ListItem("BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME : AXIS BANK LTD,BRANCH NAME: GEORGE TOWN, CHENNAI,CURRENT A/C NO: #424010200003926,IFS CODE NO.: UTIB0000424,SWIFT CODE: AXISINBB424,MICR NO. : 600211016", "BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME        : AXIS BANK LTD,BRANCH NAME      : GEORGE TOWN CHENNAI,CURRENT A/C NO   : #424010200003926,IFS CODE NO.     : UTIB0000424,SWIFT CODE       : AXISINBB424,MICR NO.         : 600211016"));
            ddlbank_name.Items.Add(new ListItem("BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME: AXIS BANK LTD,BRANCH NAME: CBB, CHENNAI,CURRENT A/C NO : #006010300017471,IFS CODE NO. : UTIB0001165,SWIFT CODE : AXISINBBA01,MICR NO. : 600211036", "BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME        : AXIS BANK LTD,BRANCH NAME      : CBB CHENNAI,CURRENT A/C NO   : #006010300017471,IFS CODE NO.     : UTIB0001165,SWIFT CODE       : AXISINBBA01,MICR NO.         : 600211036"));
        }
    }
}
