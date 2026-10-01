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
using System.Net;
using iTextSharp.text.pdf.qrcode;
using System.Web.Script.Serialization;
using QRCoder;
using System.Drawing;

public partial class GST_Credit_Note_Entry : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    GST_Credit_Note_Entry_cs BP = new GST_Credit_Note_Entry_cs();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE, COMPANY_LICENSE;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        COMPANY_LICENSE = Connection.Company_License().ToLower();
        CalendarExtender1.EndDate = DateTime.Today;

        txtInvoiceNo.Attributes.Add("readonly", "readonly");
        txtInvoiceNo.Style.Add("background-color", "#F0F0F0");
        txt_S_Billno.Attributes.Add("readonly", "readonly");
        txt_S_Billno.Style.Add("background-color", "#F0F0F0");

        if (!Page.IsPostBack)
        {
            lbl_Com_Lic.Text = COMPANY_LICENSE.ToUpper();
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
            Cr_Page_8.Visible = false;

            txttax_amt.Attributes.Add("readonly", "readonly");
            txt_Expense_Amt.Attributes.Add("readonly", "readonly");

            load_Shipment_Type();
            if (Request.QueryString["Page"] == null)
            {
                load_Cus_name();
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                HDupdate_id.Value = "";
                Rd_Royal_Other.Enabled = true;
                E_Royal_Other_Jobs();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                  
                    ViewState["UPDATED_ID"] = Request.QueryString["Billinvno"].ToString();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    Update_Item_Load();
                    txtInvoiceNo.Enabled = false;
                    ddlCus_name.Enabled = false;
                    Rd_Imp_Exp.Enabled = false;
                    Rd_Bill_Type.Enabled = false;
                    ddlbranch_No.Enabled = false;
                    ddl_Billno.Enabled = false;
                    btnloadData.Visible = false;

                    HD_Showcon.Value = "SAVED";
                    
                    btnrpt.Visible = true;
                   
                    Rd_Royal_Other.Enabled = false;
                 
                }
            }
        }
        txt_Cus_name.Attributes.Add("onblur", "javascript:CallServerside_Customer('" + txt_Cus_name.ClientID + "', '" + txtInvoiceNo.ClientID + "')");
    }
    
    private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        ddlCus_name.Items.Clear();
        ddlWorkingPeriod.Items.Clear();
        ObjUBO.A4 = Request.QueryString["Billinvno"].ToString();
        ObjUBO.A7 = Request.QueryString["IMP_EXP"].ToString();
        ObjUBO.A12 = Request.QueryString["Page"].ToString();
        ObjUBO.A40 = "Billing_Updated_Data";
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

            ddlWorkingPeriod.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString(), dss.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString()));
            ddlWorkingPeriod.SelectedIndex = 0;

            ddl_Billno.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString(), dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString()));
            ddl_Billno.SelectedIndex = 0;

            txt_S_Billno.Text = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            txtInvoiceNo.Text = dss.Tables[0].Rows[0]["CR_BILL_INV_NO"].ToString();
            txtDate.Text = dss.Tables[0].Rows[0]["CR_BILL_INV_DATE"].ToString(); 
            txt_Cus_name.Text = dss.Tables[0].Rows[0]["PARTY_NAME"].ToString();

            if (dss.Tables[0].Rows[0]["AC_BEHALF"].ToString() == "Y")
            {
                ch_Behalf.Checked = true;
            }
           
            ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
            txt_GSTN_Id.Text = dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
            txt_Party_Add.Text = dss.Tables[0].Rows[0]["PARTY_ADDRESS"].ToString();
            Rd_Bill_Type.SelectedValue = dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString();
            ddlbank_name.SelectedValue = dss.Tables[0].Rows[0]["BANK_DETAILS"].ToString();

            ddl_tr_mode.SelectedValue = dss.Tables[0].Rows[0]["MODE"].ToString();
            ddlshipment_type.SelectedValue = dss.Tables[0].Rows[0]["SHIP_TYPE"].ToString();
            txtAccHead.Text = dss.Tables[0].Rows[0]["ACC_HEAD"].ToString();
            txtPONumber.Text = dss.Tables[0].Rows[0]["PO_NO"].ToString();
            txt_Shipper_name.Text = dss.Tables[0].Rows[0]["SHIPPER_NAME"].ToString();
            
            txt_Expense_Amt.Text = dss.Tables[0].Rows[0]["EXPENSE_AMT"].ToString();
            txt_Remarks.Text = dss.Tables[0].Rows[0]["REMARKS"].ToString();

            txt_Hss.Text = dss.Tables[0].Rows[0]["HSS_CODE"].ToString();
            txt_Parma_Code.Text = dss.Tables[0].Rows[0]["PARMA_CODE"].ToString();
            txt_Work_Id.Text = dss.Tables[0].Rows[0]["WORK_ID"].ToString();
            Rd_Royal_Other.SelectedValue = dss.Tables[0].Rows[0]["JOB_TYPE"].ToString();
          
            ddlWorkingPeriod.Enabled = false;

            Rd_Job_Status.SelectedValue = dss.Tables[0].Rows[0]["JOB_STATUS"].ToString();

            if (dss.Tables[0].Rows[0]["JOB_STATUS"].ToString() == "C")
            {
                    /*
                    btn_EInvoice.Visible = true;
                    if (dss.Tables[10].Rows.Count > 0)
                    {
                        //btn_EInvoice.Text = "Re-generate Einvoice";
                        lblmsg.Text = "E-Invoice generated.";
                        lbl_E_inv_msg.Text = "Note :- Invoice Approved Can't be Modified";
                        btnDelete.Visible = false;
                        btnNew.Visible = false;
                        btnSave.Visible = false;
                        btnUpdate.Visible = false;
                        btn_EInvoice.Visible = false;
                        Rd_Inv_Status.Visible = false;

                        //btn_Addjobno.Visible = false;
                        btn_EInvoice.Visible = false;
                        btn_Remove_Job.Visible = false;
                        btnloadData.Visible = false;
                    }
                    else
                    {
                        btn_EInvoice.Text = "Generate Einvoice";
                    }
                   */
               
            }

        }
        /*
        if (dss.Tables[1].Rows.Count > 0)
        {
            gv_Jobno.DataSource = dss.Tables[1];
            gv_Jobno.DataBind();



            if (dss.Tables[1].Rows.Count > 1)
            {
                Page_E.Visible = true;
                //Add_RptAnx.Visible = true;
                Add_Anx.Visible = true;
                gv_Chg_Details.ShowFooter = false;
            }
            else
            {
               // Add_RptAnx.Visible = false;
                Add_Anx.Visible = false;
                Page_E.Visible = false;
            }
        }
        else
        {
            gv_Jobno.DataSource = dt;
            gv_Jobno.DataBind();
        }

        if (dss.Tables[2].Rows.Count > 0)
        {
            gv_Gen.DataSource = dss.Tables[2];
            gv_Gen.DataBind();
        }
        else
        {
            gv_Gen.DataSource = dt;
            gv_Gen.DataBind();
        }
        if (dss.Tables[3].Rows.Count > 0)
        {
            gv_IGM.DataSource = dss.Tables[3];
            gv_IGM.DataBind();
        }
        else
        {
            gv_IGM.DataSource = dt;
            gv_IGM.DataBind();
        }
        if (dss.Tables[4].Rows.Count > 0)
        {
            gv_Inv.DataSource = dss.Tables[4];
            gv_Inv.DataBind();
        }
        else
        {
            gv_Inv.DataSource = dt;
            gv_Inv.DataBind();
        }
        if (dss.Tables[5].Rows.Count > 0)
        {
            gv_Item.DataSource = dss.Tables[5];
            gv_Item.DataBind();
        }
        else
        {
            gv_Item.DataSource = dt;
            gv_Item.DataBind();
        }
        if (dss.Tables[5].Rows.Count > 0)
        {
            gv_Item.DataSource = dss.Tables[5];
            gv_Item.DataBind();
        }
        else
        {
            gv_Item.DataSource = dt;
            gv_Item.DataBind();
        }
        if (dss.Tables[6].Rows.Count > 0)
        {
            gv_BE_SB.DataSource = dss.Tables[6];
            gv_BE_SB.DataBind();
        }
        else
        {
            gv_BE_SB.DataSource = dt;
            gv_BE_SB.DataBind();
        }
        if (dss.Tables[7].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[7];
            gv_Chg_Details.DataBind();

            DataTable firstTable = dss.Tables[7];
            ViewState["CurrentTable"] = firstTable;
        }
        else
        {
            SetInitialRow();
        }
        */
        if (dss.Tables[1].Rows.Count > 0)
        {
            gv_Jobno.DataSource = dss.Tables[1];
            gv_Jobno.DataBind();

            if (dss.Tables[1].Rows.Count > 1)
            {
                Cr_Page_8.Visible = true;
                Add_RptAnx.Visible = true;
                Add_Anx.Visible = true;
                gv_Chg_Details.ShowFooter = false;
            }
            else
            {
                Add_RptAnx.Visible = false;
                Add_Anx.Visible = false;
                Cr_Page_8.Visible = false;
            }
        }
        else
        {
            gv_Jobno.DataSource = dt;
            gv_Jobno.DataBind();
        }

        if (dss.Tables[2].Rows.Count > 0)
        {
            gv_Gen.DataSource = dss.Tables[2];
            gv_Gen.DataBind();
        }
        else
        {
            gv_Gen.DataSource = dt;
            gv_Gen.DataBind();
        }
        if (dss.Tables[3].Rows.Count > 0)
        {
            gv_IGM.DataSource = dss.Tables[3];
            gv_IGM.DataBind();
        }
        else
        {
            gv_IGM.DataSource = dt;
            gv_IGM.DataBind();
        }
        if (dss.Tables[4].Rows.Count > 0)
        {
            gv_Inv.DataSource = dss.Tables[4];
            gv_Inv.DataBind();
        }
        else
        {
            gv_Inv.DataSource = dt;
            gv_Inv.DataBind();
        }
        if (dss.Tables[5].Rows.Count > 0)
        {
            gv_Item.DataSource = dss.Tables[5];
            gv_Item.DataBind();
        }
        else
        {
            gv_Item.DataSource = dt;
            gv_Item.DataBind();
        }
        if (dss.Tables[6].Rows.Count > 0)
        {
            gv_BE_SB.DataSource = dss.Tables[6];
            gv_BE_SB.DataBind();
        }
        else
        {
            gv_BE_SB.DataSource = dt;
            gv_BE_SB.DataBind();
        }
        if (dss.Tables[7].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[7];
            gv_Chg_Details.DataBind();

            DataTable firstTable = dss.Tables[7];
            ViewState["CurrentTable"] = firstTable;
        }
        else
        {
            SetInitialRow();
        }

        if (dss.Tables[8].Rows.Count > 0)
        {
            ddl_cur.SelectedValue = dss.Tables[8].Rows[0]["CUR"].ToString();
            txtEx_Rate.Text = dss.Tables[8].Rows[0]["EX_RATE"].ToString();
        }
        /*
        if (dss.Tables[9].Rows.Count > 0)
        {
            txt_IRN_No.Text = dss.Tables[9].Rows[0]["IRN_NO"].ToString();
            txt_Ack_No.Text = dss.Tables[9].Rows[0]["ACKNO"].ToString();
            txt_Ack_Date.Text = dss.Tables[9].Rows[0]["ACKDT"].ToString();
            QR_Imagepath(dss.Tables[9].Rows[0]["SignedQRCode"].ToString(), dss.Tables[9].Rows[0]["BILL_INV_NO"].ToString().Replace('/', '_'));
            img_QR_Code.ImageUrl = ResolveUrl("~/Submission/" + "/Accounts/" + Connection.COMPANYID() + "/ACC_GST_BILL_QRCODE/" + "/" + Connection.Current_User() + "/" + dss.Tables[9].Rows[0]["BILL_INV_NO"].ToString().Replace('/', '_') + ".png");
        }
        else
        {
            txt_IRN_No.Text = "";
            txt_Ack_No.Text = "";
            txt_Ack_Date.Text = "";
            img_QR_Code.ImageUrl = "";
        }
        */
        //dss.Tables[9] IRN
       
    }
    private void load_Cus_name()
    {
        try
        {
            ddlCus_name.Items.Clear();
            DataSet dss = new DataSet();
            ObjUBO.A7 = Rd_Imp_Exp.SelectedValue.ToString();
            ObjUBO.A40 = "Cus_Name_Select";
            dss = BP.Select_Inv(ObjUBO, Get_Con_String());
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
        ddl_Billno.SelectedIndex = -1;
        txt_S_Billno.Text = string.Empty;
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

        ObjUBO.A5 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A7 = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A40 = "Cus_Branch_Select";
        dss = BP.Select_Inv(ObjUBO, Get_Con_String());
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
                    DropDownList txtch_name = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtch_name");
                    TextBox txt_charge_desc = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txt_charge_desc");
                    TextBox txtqty = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtqty");

                    DropDownList dl_CUR = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("dl_CUR");
                    TextBox txt_Ex_Rate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txt_Ex_Rate");

                    TextBox txtunit_price = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtunit_price");
                    TextBox txtamt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txtamt");
                    TextBox txtCGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtCGST_RATE");
                    TextBox txtCGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtCGST_AMT");
                    TextBox txtSGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[11].FindControl("txtSGST_RATE");
                    TextBox txtSGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[12].FindControl("txtSGST_AMT");
                    TextBox txtIGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtIGST_RATE");
                    TextBox txtIGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[14].FindControl("txtIGST_AMT");

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

                    dtCurrentTable.Rows[i - 1]["CUR"] = dl_CUR.SelectedValue.ToString();
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
                }
                if (Emptyrow != "Y")
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["INV_CHECK"] = "True";
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    drCurrentRow["ORDERBY"] = dtCurrentTable.Rows.Count + 1;
                    drCurrentRow["CHARGE_VALUE"] = string.Empty;
                    drCurrentRow["QTY"] = "1";

                    /*
                    drCurrentRow["CUR"] = "INR";
                    drCurrentRow["EX_RATE"] = "1";
                    */

                    drCurrentRow["CUR"] = ddl_cur.SelectedValue.ToString();
                    drCurrentRow["EX_RATE"] = txtEx_Rate.Text;

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

                    DropDownList dl_CUR = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("dl_CUR");
                    TextBox txt_Ex_Rate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txt_Ex_Rate");

                    TextBox txtunit_price = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txtunit_price");
                    TextBox txtamt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtamt");
                    TextBox txtCGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txtCGST_RATE");
                    TextBox txtCGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtCGST_AMT");
                    TextBox txtSGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtSGST_RATE");
                    TextBox txtSGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[11].FindControl("txtSGST_AMT");
                    TextBox txtIGST_RATE = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[12].FindControl("txtIGST_RATE");
                    TextBox txtIGST_AMT = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtIGST_AMT");
                    //--------------------------------------------------------------------

                    gv_Chg_Details.Rows[i].Cells[1].Text = Convert.ToString(i + 1);

                    txtch_name.SelectedValue = dt.Rows[i]["CHARGE_VALUE"].ToString();
                    txtOrder_by.Text = dt.Rows[i]["ORDERBY"].ToString();
                    txtqty.Text = dt.Rows[i]["QTY"].ToString();

                    dl_CUR.SelectedValue = dt.Rows[i]["CUR"].ToString();
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
        ss = Billing_Invoice_Jobno_Insert_Update(Get_Jobs_Tbl(), "S", Gen_details(), IGM_details(), Inv_details(), Item_details(), BE_SB_details(), Charge_details());

        if (ss.Tables[0].Rows.Count > 0)
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
            //if (ss.Tables[1].Rows.Count > 0)
            //{
            //    gv_Gen_Annexure.DataSource = ss.Tables[1];
            //    gv_Gen_Annexure.DataBind();
            //    gv_Gen_Annexure.Rows[0].BackColor = System.Drawing.Color.Orange;
            //    gv_Gen_Annexure.Rows[0].ForeColor = System.Drawing.Color.Black;
            //    Add_Anx.Visible = true;
            //}
            //else
            //{
            //    Add_Anx.Visible = false;
            //}
            if (gv_Jobno.Rows.Count > 1)
            {
                Cr_Page_8.Visible = true;
                Add_Anx.Visible = true;
                //Add_RptAnx.Visible = true;
            }
            else
            {
                Cr_Page_8.Visible = false;
                Add_Anx.Visible = false;
               // Add_RptAnx.Visible = false;
            }
            F.Visible = false;
            T.Visible = true;

            ddlCus_name.Enabled = false;
            ddlbranch_No.Enabled = false;
            Billing_Approve(Rd_Job_Status.SelectedValue.ToString(), Rd_Inv_Status.SelectedValue.ToString());
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
            dr = Billing_Invoice_Jobno_Insert_Update(Get_Jobs_Tbl(), "U", Gen_details(), IGM_details(), Inv_details(), Item_details(), BE_SB_details(), Charge_details());
            if (dr.Tables[0].Rows.Count > 0)
            {
                Billing_Approve(Rd_Job_Status.SelectedValue.ToString(), Rd_Inv_Status.SelectedValue.ToString());
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                    HD_Showcon.Value = "SAVED";
                }

                if (gv_Jobno.Rows.Count > 1)
                {
                    Cr_Page_8.Visible = true;
                    Add_Anx.Visible = true;
                   // Add_RptAnx.Visible = true;
                }
                else
                {
                    Cr_Page_8.Visible = false;
                    Add_Anx.Visible = false;
                   // Add_RptAnx.Visible = false;
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
            ObjUBO.A4 = txtInvoiceNo.Text;
            ObjUBO.A40 = "Cr_Delete";
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
    private string Gen_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("JOBNO_PS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("FILE_REF_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("PARTY_REF_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("JOB_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("TR_MODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BE_SB_TYPE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CUSTOMS_HOUSE_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CUSTOMS_HOUSE_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IMP_EXP_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("COUNTRY_ORIGIN_FINAL_DEST", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("PORT_ORIGIN_FINAL_DEST", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("HIGH_SEA_SALE_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_TYPE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("PAYMENT_METHOD_CODE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CONSIGNEE_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ETA", typeof(String)));
        int R = 1;
        foreach (GridViewRow row in gv_Gen.Rows)
        {
            TextBox txt_Jobno_PS_I = (TextBox)row.FindControl("txt_Jobno_PS_I");
            TextBox txt_Jobno_I = (TextBox)row.FindControl("txt_Jobno_I");
            TextBox txt_file_Refno = (TextBox)row.FindControl("txt_file_Refno");
            TextBox txt_Party_Refno = (TextBox)row.FindControl("txt_Party_Refno");
            TextBox txt_Job_Date = (TextBox)row.FindControl("txt_Job_Date");
            TextBox txt_tr_mode = (TextBox)row.FindControl("txt_tr_mode");
            TextBox txt_type = (TextBox)row.FindControl("txt_type");
            TextBox txt_Cus_House_Name = (TextBox)row.FindControl("txt_Cus_House_Name");
            TextBox txt_Cus_House_Code = (TextBox)row.FindControl("txt_Cus_House_Code");
            TextBox txt_Imp_Exp_Name = (TextBox)row.FindControl("txt_Imp_Exp_Name");
            TextBox txt_Cou_Org_final_dest = (TextBox)row.FindControl("txt_Cou_Org_final_dest");
            TextBox txt_Port_Org_final_dest = (TextBox)row.FindControl("txt_Port_Org_final_dest");
            TextBox txt_High_Sea_Sale_name = (TextBox)row.FindControl("txt_High_Sea_Sale_name");
            TextBox txt_Con_Type = (TextBox)row.FindControl("txt_Con_Type");
            TextBox txt_Payment_Method = (TextBox)row.FindControl("txt_Payment_Method");
            TextBox txt_Consignee_Name = (TextBox)row.FindControl("txt_Consignee_Name");
            TextBox txt_ETA = (TextBox)row.FindControl("txt_ETA");

            dr = dtt.NewRow();
            dr[0] = txt_Jobno_PS_I.Text;
            dr[1] = txt_Jobno_I.Text;
            dr[2] = txt_file_Refno.Text;
            dr[3] = txt_Party_Refno.Text;
            dr[4] = txt_Job_Date.Text;
            dr[5] = txt_tr_mode.Text;
            dr[6] = txt_type.Text;
            dr[7] = txt_Cus_House_Name.Text;
            dr[8] = txt_Cus_House_Code.Text;
            dr[9] = txt_Imp_Exp_Name.Text;
            dr[10] = txt_Cou_Org_final_dest.Text;
            dr[11] = txt_Port_Org_final_dest.Text;
            dr[12] = txt_High_Sea_Sale_name.Text;
            dr[13] = txt_Con_Type.Text;
            dr[14] = txt_Payment_Method.Text;
            dr[15] = txt_Consignee_Name.Text;
            dr[16] = txt_ETA.Text;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private string IGM_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("JOBNO_PS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_AIRLINENAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_FLIGHTNO_VESSELNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_FLIGHT_VESSELDATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_MAWB_MBL", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_MAWB_MBLDATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_HAWB_HBLNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_HAWB_HBLDATE", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("IGM_GROSSWEIGHT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_TYPEOFWEIGHT", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("IGM_NOOFPACKAGE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_PACKAGETYPE", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("IGM_NETWEIGHT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_NETWEIGHTTYPE", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("IGM_VOYAGE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_CHARGEABLE_WGT", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_TOTAL_PACKAGES", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_GROSS_WEIGHT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_NET_WEIGHT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_UNIT_MEASUREMENT", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_VOYAGENO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_VESSELNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_VESSEL_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_LOOSE_PACKETS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_NO_CONTAINERS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ANNEX_SEA_NATURE_OF_CARGO", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("IGM_CONTAINER_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IGM_NO_OF_CONTAINER", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in gv_IGM.Rows)
        {
            TextBox txt_Jobno_PS_I = (TextBox)row.FindControl("txt_Jobno_PS_I");
            TextBox txt_Jobno_I = (TextBox)row.FindControl("txt_Jobno_I");
            TextBox txt_Air_lineName = (TextBox)row.FindControl("txt_Air_lineName");
            TextBox txt_Flight_Vesselno = (TextBox)row.FindControl("txt_Flight_Vesselno");
            TextBox txt_Flight_Vessel_Date = (TextBox)row.FindControl("txt_Flight_Vessel_Date");
            TextBox txt_IGM_No = (TextBox)row.FindControl("txt_IGM_No");
            TextBox txt_IGM_Date = (TextBox)row.FindControl("txt_IGM_Date");
            TextBox txt_MAWB_MBL = (TextBox)row.FindControl("txt_MAWB_MBL");
            TextBox txt_MAWB_MBL_Date = (TextBox)row.FindControl("txt_MAWB_MBL_Date");
            TextBox txt_HAWB_HBLNO = (TextBox)row.FindControl("txt_HAWB_HBLNO");
            TextBox txt_HAWB_HBLNO_Date = (TextBox)row.FindControl("txt_HAWB_HBLNO_Date");

            TextBox txt_Gross_Wgt = (TextBox)row.FindControl("txt_Gross_Wgt");
            TextBox txt_Type_of_Wgt = (TextBox)row.FindControl("txt_Type_of_Wgt");

            TextBox txt_IGM_No_of_pkg = (TextBox)row.FindControl("txt_IGM_No_of_pkg");
            TextBox txt_Pkg_Type = (TextBox)row.FindControl("txt_Pkg_Type");

            TextBox txt_Net_Wgt = (TextBox)row.FindControl("txt_Net_Wgt");
            TextBox txt_Net_Wgt_Type = (TextBox)row.FindControl("txt_Net_Wgt_Type");

            TextBox txt_Voyage = (TextBox)row.FindControl("txt_Voyage");
            TextBox txt_Charge_Wgt = (TextBox)row.FindControl("txt_Charge_Wgt");

            TextBox txt_Sea_Tot_PKg = (TextBox)row.FindControl("txt_Sea_Tot_PKg");
            TextBox txt_Sea_Gross_Wgt = (TextBox)row.FindControl("txt_Sea_Gross_Wgt");
            TextBox txt_Sea_Net_Wgt = (TextBox)row.FindControl("txt_Sea_Net_Wgt");
            TextBox txt_Sea_Uint = (TextBox)row.FindControl("txt_Sea_Uint");
            TextBox txt_Sea_Voyage_No = (TextBox)row.FindControl("txt_Sea_Voyage_No");
            TextBox txt_Sea_Vessel_No = (TextBox)row.FindControl("txt_Sea_Vessel_No");
            TextBox txt_Sea_Vessel_Date = (TextBox)row.FindControl("txt_Sea_Vessel_Date");
            TextBox txt_Sea_Loose_Packets = (TextBox)row.FindControl("txt_Sea_Loose_Packets");
            TextBox txt_Sea_No_Of_Containers = (TextBox)row.FindControl("txt_Sea_No_Of_Containers");
            TextBox txt_Sea_Nature_of_Cargo = (TextBox)row.FindControl("txt_Sea_Nature_of_Cargo");

            TextBox txt_Igm_Con_No = (TextBox)row.FindControl("txt_Igm_Con_No");
            TextBox txt_Igm_No_of_Con = (TextBox)row.FindControl("txt_Igm_No_of_Con");

            dr = dtt.NewRow();
            dr[0] = txt_Jobno_PS_I.Text;
            dr[1] = txt_Jobno_I.Text;
            dr[2] = txt_Air_lineName.Text;
            dr[3] = txt_Flight_Vesselno.Text;
            dr[4] = txt_Flight_Vessel_Date.Text;
            dr[5] = txt_IGM_No.Text;
            dr[6] = txt_IGM_Date.Text;
            dr[7] = txt_MAWB_MBL.Text;
            dr[8] = txt_MAWB_MBL_Date.Text;
            dr[9] = txt_HAWB_HBLNO.Text;
            dr[10] = txt_HAWB_HBLNO_Date.Text;

            dr[11] = txt_Gross_Wgt.Text;
            dr[12] = txt_Type_of_Wgt.Text;
            dr[13] = txt_IGM_No_of_pkg.Text;
            dr[14] = txt_Pkg_Type.Text;
            dr[15] = txt_Net_Wgt.Text;
            dr[16] = txt_Net_Wgt_Type.Text;
            dr[17] = txt_Voyage.Text;
            dr[18] = txt_Charge_Wgt.Text;

            dr[19] = txt_Sea_Tot_PKg.Text;
            dr[20] = txt_Sea_Gross_Wgt.Text;
            dr[21] = txt_Sea_Net_Wgt.Text;
            dr[22] = txt_Sea_Uint.Text;
            dr[23] = txt_Sea_Voyage_No.Text;
            dr[24] = txt_Sea_Vessel_No.Text;
            dr[25] = txt_Sea_Vessel_Date.Text;
            dr[26] = txt_Sea_Loose_Packets.Text;
            dr[27] = txt_Sea_No_Of_Containers.Text;
            dr[28] = txt_Sea_Nature_of_Cargo.Text;

            dr[29] = txt_Igm_Con_No.Text;
            dr[30] = txt_Igm_No_of_Con.Text;

            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private string Inv_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("JOBNO_PS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("INVOICE_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("INVOICE_DATE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("TERMS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("INVOICE_VALUE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("INVOICE_CUR", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("SUPPLIER_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("OTHER_PURCHASE_ORDER", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("OTHER_PURCHASE_ORDER_DATE", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in gv_Inv.Rows)
        {
            TextBox txt_Jobno_PS_II = (TextBox)row.FindControl("txt_Jobno_PS_II");
            TextBox txt_Jobno_II = (TextBox)row.FindControl("txt_Jobno_II");
            TextBox txt_Inv_No = (TextBox)row.FindControl("txt_Inv_No");
            TextBox txt_Inv_Date = (TextBox)row.FindControl("txt_Inv_Date");
            TextBox txt_Terms = (TextBox)row.FindControl("txt_Terms");
            TextBox txt_Inv_Value = (TextBox)row.FindControl("txt_Inv_Value");
            TextBox txt_Inv_Cur = (TextBox)row.FindControl("txt_Inv_Cur");
            TextBox txt_Sup_Name = (TextBox)row.FindControl("txt_Sup_Name");
            TextBox txt_Purchase_Order = (TextBox)row.FindControl("txt_Purchase_Order");
            TextBox txt_Purchase_Order_Date = (TextBox)row.FindControl("txt_Purchase_Order_Date");

            dr = dtt.NewRow();
            dr[0] = txt_Jobno_PS_II.Text;
            dr[1] = txt_Jobno_II.Text;
            dr[2] = txt_Inv_No.Text;
            dr[3] = txt_Inv_Date.Text;
            dr[4] = txt_Terms.Text;
            dr[5] = txt_Inv_Value.Text;
            dr[6] = txt_Inv_Cur.Text;
            dr[7] = txt_Sup_Name.Text;
            dr[8] = txt_Purchase_Order.Text;
            dr[9] = txt_Purchase_Order_Date.Text;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private string Item_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;

        dtt.Columns.Add(new System.Data.DataColumn("JOBNO_PS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ITEM_DESCRIPTION", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("MANUFACTURER", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ASS_FOB_VALUE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DUTY_DRAWBACK_VALUE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CIF_PMV_VALUE", typeof(String)));
        int R = 1;
        foreach (GridViewRow row in gv_Item.Rows)
        {
            TextBox txt_Jobno_PS_I = (TextBox)row.FindControl("txt_Jobno_PS_I");
            TextBox txt_Jobno_I = (TextBox)row.FindControl("txt_Jobno_I");
            TextBox txt_Item_Dec = (TextBox)row.FindControl("txt_Item_Dec");
            TextBox txt_Manufacture = (TextBox)row.FindControl("txt_Manufacture");
            TextBox txt_Ass_FOB_Value = (TextBox)row.FindControl("txt_Ass_FOB_Value");
            TextBox txt_Duty_Dbk_Value = (TextBox)row.FindControl("txt_Duty_Dbk_Value");
            TextBox txt_CIF_PMV_Value = (TextBox)row.FindControl("txt_CIF_PMV_Value");

            dr = dtt.NewRow();
            dr[0] = txt_Jobno_PS_I.Text;
            dr[1] = txt_Jobno_I.Text;
            dr[2] = txt_Item_Dec.Text;
            dr[3] = txt_Manufacture.Text;
            dr[4] = txt_Ass_FOB_Value.Text;
            dr[5] = txt_Duty_Dbk_Value.Text;
            dr[6] = txt_CIF_PMV_Value.Text;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private string BE_SB_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("JOBNO_PS", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BE_SB_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("BE_SB_DATE", typeof(String)));
        int R = 1;
        foreach (GridViewRow row in gv_BE_SB.Rows)
        {
            TextBox txt_Jobno_PS_I = (TextBox)row.FindControl("txt_Jobno_PS_I");
            TextBox txt_Jobno_I = (TextBox)row.FindControl("txt_Jobno_I");
            TextBox txt_BE_SB_No = (TextBox)row.FindControl("txt_BE_SB_No");
            TextBox txt_BE_SB_Date = (TextBox)row.FindControl("txt_BE_SB_Date");
            dr = dtt.NewRow();
            dr[0] = txt_Jobno_PS_I.Text;
            dr[1] = txt_Jobno_I.Text;
            dr[2] = txt_BE_SB_No.Text;
            dr[3] = txt_BE_SB_Date.Text;
            dtt.Rows.Add(dr);
            R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    private string Charge_details()
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

            DropDownList dl_CUR = (DropDownList)row.FindControl("dl_CUR");
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
                if (txtch_name.SelectedValue.ToString() != string.Empty)
                {
                    ar = txtch_name.SelectedValue.ToString().Split('~');

                    dr[1] = ar[1];//txtch_name.SelectedValue.ToString();
                    dr[2] = ar[0];//ddl_tax_nontax.SelectedValue.ToString();
                }
                else
                {
                    dr[1] = "";
                    dr[2] = "";
                }
                dr[3] = "";
                dr[4] = "";
                dr[5] = txtqty.Text;

                dr[6] = dl_CUR.SelectedValue.ToString();
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
    public DataSet Billing_Invoice_Jobno_Insert_Update(String xmlJobs, string S1, String Gen_details, String IGM_details, String Inv_details, String Item_details, String BE_SB_details, String Charge_details)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = Rd_Royal_Other.SelectedValue.ToString();
        ObjUBO.A3 = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A4 = Rd_Bill_Type.SelectedValue.ToString();
        ObjUBO.A5 = lbl_Com_Lic.Text; 
        ObjUBO.A6 = ddlWorkingPeriod.SelectedValue.ToString();
        ObjUBO.A7 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A8 = ddlbranch_No.SelectedValue.ToString();
        ObjUBO.A9 = ddl_tr_mode.SelectedValue.ToString();
        ObjUBO.A10 = ddlshipment_type.SelectedValue.ToString();
        ObjUBO.A11 = From_Quotation.Checked.ToString();
        ObjUBO.A12 = ddl_cur.SelectedValue.ToString();
        ObjUBO.A13 = txtEx_Rate.Text;

        ObjUBO.A14 = ddl_Billno.SelectedValue.ToString();
        ObjUBO.A15 = txtDate.Text;

        ObjUBO.A16 = txt_Cus_name.Text;
        ObjUBO.A17 = ch_Behalf.Checked == true ? "Y" : "N";
        ObjUBO.A18 = txt_Shipper_name.Text;
        ObjUBO.A19 = ddl_state_name.SelectedValue.ToString();
        ObjUBO.A20 = txt_GSTN_Id.Text;
        ObjUBO.A21 = txt_Party_Add.Text;

        ObjUBO.A22 = txtPONumber.Text;
        ObjUBO.A23 = txtAccHead.Text;
        ObjUBO.A24 = txt_Remarks.Text;
        ObjUBO.A25 = txt_Hss.Text;
        ObjUBO.A26 = txt_Parma_Code.Text;
        ObjUBO.A27 = txt_Work_Id.Text;

        ObjUBO.A28 = txt_grand_total.Text;
        ObjUBO.A29 = txt_Adv_amt.Text;
        ObjUBO.A30 = txt_Expense_Amt.Text;
        ObjUBO.A31 = txttax_amt.Text;
        //---------------------------------------------------
        ObjUBO.A32 = ddlbank_name.SelectedValue.ToString();
        //ObjUBO.A33 = "UA";
        if (Acc_Connection.Billing_Aproval_Company() == "Y")
        {
            if (Acc_Connection.Billing_Aproval_Admin() == "Y")
            {
                ObjUBO.A33 = Rd_Inv_Status.SelectedValue.ToString();
            }
            else
            {
                ObjUBO.A33 = "UA";
            }
        }
        else
        {
            ObjUBO.A33 = Rd_Inv_Status.SelectedValue.ToString();
        }
        ObjUBO.A35 = ddlbranch_No.SelectedItem.ToString();
        ObjUBO.A36 = Rd_Royal_Other.SelectedValue.ToString();
        ObjUBO.A37 = txt_nontax_Amt.Text;
        ObjUBO.A38 = txt_tax_Amt.Text;
        ObjUBO.A39 = Rd_Job_Status.SelectedValue.ToString();
        
        ObjUBO.A40 =  txtInvoiceNo.Text;
        ObjUBO.A41 = txtDate.Text;

        ObjUBO.A73 = xmlJobs;
        ObjUBO.A74 = Gen_details;
        ObjUBO.A75 = IGM_details;
        ObjUBO.A76 = Inv_details;
        ObjUBO.A77 = Item_details;
        ObjUBO.A78 = BE_SB_details;
        ObjUBO.A79 = Charge_details;
        ObjUBO.A80 = S1;
        return BP.Billing_Invoice_INS_UPD(ObjUBO);
    }
    private void Clear()
    {
        txtInvoiceNo.Text = string.Empty;
        ch_Behalf.Checked = false;
        txt_Cus_name.Text = string.Empty;
        txt_Party_Add.Text = string.Empty;
        txttax_amt.Text = string.Empty;
        ddl_state_name.Text = string.Empty;
        txt_GSTN_Id.Text = string.Empty;
        txt_Expense_Amt.Text = string.Empty;
        txt_Remarks.Text = string.Empty;
        txt_Hss.Text = string.Empty;
        txt_Parma_Code.Text = string.Empty;
        txt_Work_Id.Text = string.Empty;
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
           
            ddlch_name.Items.Insert(0, new ListItem(""));
            ddlch_name.Items.FindByValue(Ch_name_select).Selected = true;

            //--------------------------------------------------------------------------
        }
        //https://www.aspsnippets.com/Articles/Dynamically-add-DropDownList-in-ASPNet-GridView-using-C-and-VBNet.aspx
        //https://www.aspsnippets.com/Articles/Get-Selected-Value-from-DropDownList-in-GridView-in-ASPNet.aspx
    }
    private DataSet load_Charge_Name()
    {
        ObjUBO.A40 = "Get_Charge_name_With_Tax";
        return BP.Select_Inv(ObjUBO, Get_Con_String());
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
        //dt.Columns.Add(new DataColumn("TAX_NONTAX", typeof(string)));
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
        dr["CHARGE_VALUE"] = string.Empty;
        //dr["TAX_NONTAX"] = "N";
        dr["Qty"] = "1";

        if (ddl_cur.SelectedValue.ToString() == "INR")
        {
            dr["CUR"] = "INR";
            dr["EX_RATE"] = "1";
        }
        else
        {
            dr["CUR"] = ddl_cur.SelectedValue.ToString();
            if (txtEx_Rate.Text != string.Empty)
            {
                dr["EX_RATE"] = txtEx_Rate.Text;
            }
            else
            {
                dr["EX_RATE"] = "1";
            }
        }

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
                //dtnew.Columns.Add(new DataColumn("TAX_NONTAX", typeof(string)));
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
                    drnew["CHARGE_VALUE"] = dt.Rows[i][3].ToString();
                    //drnew["TAX_NONTAX"] = dt.Rows[i][4].ToString();
                    drnew["Qty"] = dt.Rows[i][4].ToString();

                    drnew["CUR"] = dt.Rows[i][5].ToString();
                    drnew["EX_RATE"] = dt.Rows[i][6].ToString();

                    drnew["UNIT_RATE"] = dt.Rows[i][7].ToString();
                    drnew["AMOUNT"] = dt.Rows[i][8].ToString();
                    drnew["CGST_RATE"] = dt.Rows[i][9].ToString();
                    drnew["CGST_AMT"] = dt.Rows[i][10].ToString();
                    drnew["SGST_RATE"] = dt.Rows[i][11].ToString();
                    drnew["SGST_AMT"] = dt.Rows[i][12].ToString();
                    drnew["IGST_RATE"] = dt.Rows[i][13].ToString();
                    drnew["IGST_AMT"] = dt.Rows[i][14].ToString();
                    drnew["CHARGE_DESC"] = dt.Rows[i][15].ToString();
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
                drr["CHARGE_VALUE"] = string.Empty;
                drr["Qty"] = "1";
                if (ddl_cur.SelectedValue.ToString() == "INR")
                {
                    drr["CUR"] = "INR";
                    drr["EX_RATE"] = "1";
                }
                else
                {
                    drr["CUR"] = ddl_cur.SelectedValue.ToString();
                    if (txtEx_Rate.Text != string.Empty)
                    {
                        drr["EX_RATE"] = txtEx_Rate.Text;
                    }
                    else
                    {
                        drr["EX_RATE"] = "1";
                    }
                }
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

        gv_Jobno.DataSource = dt;
        gv_Jobno.DataBind();
        gv_Gen.DataSource = dt;
        gv_Gen.DataBind();
        gv_IGM.DataSource = dt;
        gv_IGM.DataBind();
        gv_Inv.DataSource = dt;
        gv_Inv.DataBind();
        gv_Item.DataSource = dt;
        gv_Item.DataBind();
        gv_BE_SB.DataSource = dt;
        gv_BE_SB.DataBind();
        //gv_Gen_Annexure.DataSource = dt;
        //gv_Gen_Annexure.DataBind();
    }
    [System.Web.Services.WebMethod]
    public static string Get_Importer_Inv_Chk(string custid, string Mode, string Branch)
    {
        GST_Sales_Entry_cs BI = new GST_Sales_Entry_cs();
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
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }
    [System.Web.Services.WebMethod]
    public static string Get_Cha_Type_Rate(string ChargeName, string Local_Other, string Mode)
    {
        string Ch_Name = "";
        DataSet ds = new DataSet();
        try
        {

            if (ChargeName != string.Empty)
            {
                string[] arr = new string[] { };
                arr = ChargeName.Split('~');

                GST_Sales_Entry_cs BI = new GST_Sales_Entry_cs();
                Global_variables ObjUBO = new Global_variables();

                ObjUBO.A14 = arr[0];
                ObjUBO.A13 = arr[1];
                ObjUBO.A15 = Local_Other;
                ObjUBO.A40 = "GST_Charge_Rate";
                ds = BI.Select_Inv(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Local_Other == "L")
                    {
                        Ch_Name = ds.Tables[0].Rows[0]["CGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["SGST_RATE"].ToString() + "~~" + "0";
                    }
                    else
                    {
                        Ch_Name = "0" + "~~" + "0" + "~~" + ds.Tables[0].Rows[0]["IGST_RATE"].ToString();
                    }

                }
                else
                {
                    Ch_Name = "";
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
    protected void Rd_Bill_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    [System.Web.Services.WebMethod]
    public static string Inv_Refresh(string Inv)
    {
        DataSet ds =new DataSet();
        GST_Sales_Entry_cs BI = new GST_Sales_Entry_cs();
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
        string values = "",Con_Val="";

        if (ddlCus_name.SelectedValue.ToString() != string.Empty && txt_S_Billno.Text != "")
           {
                 Con_Val=Get_Con_String();
                 Hd_I_E.Value = Rd_Imp_Exp.SelectedValue.ToString(); 

                 DataSet dss = new DataSet();
                 ObjUBO.A4 = txt_S_Billno.Text;
                
                 ObjUBO.A6 = Rd_Imp_Exp.SelectedValue.ToString();
                 ObjUBO.A7 = ddlCus_name.SelectedValue.ToString();
                 ObjUBO.A8 = ddlbranch_No.SelectedValue.ToString();
                 ObjUBO.A9 = Rd_Bill_Type.SelectedValue.ToString();//LO
                 ObjUBO.A12 = ddl_tr_mode.SelectedValue.ToString();
                 ObjUBO.A13 = ddlshipment_type.SelectedValue.ToString();

                 ObjUBO.A50 = "Select_Imp_Exp_Job_Data";
                 ObjUBO.A46 = "ACC_GST_BILL_IMP_EXP_CREDIT_NOTE_SELECT";
                 dss = BP.Select_Imp_Exp_Data(ObjUBO, Con_Val);

                 if (dss.Tables[0].Rows.Count > 0)
                 {
                     //-----------------------BA--S---------------------------------------
                     txt_Cus_name.Text = dss.Tables[0].Rows[0]["CUS_NAME"].ToString();

                     if (dss.Tables[0].Rows[0]["AC_BEHALF"].ToString() == "Y")
                     {
                         ch_Behalf.Checked = true;
                     }

                     ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["STATE_NAME"].ToString();
                     txt_GSTN_Id.Text = dss.Tables[0].Rows[0]["GSTN_ID"].ToString();
                     txt_Party_Add.Text = dss.Tables[0].Rows[0]["PARTY_ADDRESS"].ToString();
                     Rd_Bill_Type.SelectedValue = dss.Tables[0].Rows[0]["LOCAL_OTHER"].ToString();
                     ddlbank_name.SelectedValue = dss.Tables[0].Rows[0]["BANK_DETAILS"].ToString();

                     ddl_tr_mode.SelectedValue = dss.Tables[0].Rows[0]["MODE"].ToString();
                     ddlshipment_type.SelectedValue = dss.Tables[0].Rows[0]["SHIP_TYPE"].ToString();
                     txtAccHead.Text = dss.Tables[0].Rows[0]["ACC_HEAD"].ToString();
                     txtPONumber.Text = dss.Tables[0].Rows[0]["PO_NO"].ToString();
                     txt_Shipper_name.Text = dss.Tables[0].Rows[0]["SHIPPER_NAME"].ToString();

                     txt_Expense_Amt.Text = dss.Tables[0].Rows[0]["EXPENSE_AMT"].ToString();
                     txt_Remarks.Text = dss.Tables[0].Rows[0]["REMARKS"].ToString();

                     txt_Hss.Text = dss.Tables[0].Rows[0]["HSS_CODE"].ToString();
                     txt_Parma_Code.Text = dss.Tables[0].Rows[0]["PARMA_CODE"].ToString();
                     txt_Work_Id.Text = dss.Tables[0].Rows[0]["WORK_ID"].ToString();
                     Rd_Royal_Other.SelectedValue = dss.Tables[0].Rows[0]["JOB_TYPE"].ToString();

                     ddlWorkingPeriod.Enabled = false;
                 }
                 if (dss.Tables[1].Rows.Count > 0)
                 {
                     gv_Jobno.DataSource = dss.Tables[1];
                     gv_Jobno.DataBind();
                 }
                 else
                 {
                     gv_Jobno.DataSource = dt;
                     gv_Jobno.DataBind();
                 }

                 if (dss.Tables[2].Rows.Count > 0)
                 {
                     gv_Gen.DataSource = dss.Tables[2];
                     gv_Gen.DataBind();
                 }
                 else
                 {
                     gv_Gen.DataSource = dt;
                     gv_Gen.DataBind();
                 }

                 if (dss.Tables[3].Rows.Count > 0)
                 {
                     gv_IGM.DataSource = dss.Tables[3];
                     gv_IGM.DataBind();
                 }
                 else
                 {
                     gv_IGM.DataSource = dt;
                     gv_IGM.DataBind();
                 }

                 if (dss.Tables[4].Rows.Count > 0)
                 {
                     gv_Inv.DataSource = dss.Tables[4];
                     gv_Inv.DataBind();
                 }
                 else
                 {
                     gv_Inv.DataSource = dt;
                     gv_Inv.DataBind();
                 }
                 if (dss.Tables[5].Rows.Count > 0)
                 {
                     gv_Item.DataSource = dss.Tables[5];
                     gv_Item.DataBind();
                 }
                 else
                 {
                     gv_Item.DataSource = dt;
                     gv_Item.DataBind();
                 }

                 if (dss.Tables[6].Rows.Count > 0)
                 {
                     gv_BE_SB.DataSource = dss.Tables[6];
                     gv_BE_SB.DataBind();
                 }
                 else
                 {
                     gv_BE_SB.DataSource = dt;
                     gv_BE_SB.DataBind();
                 }
                 if (dss.Tables[7].Rows.Count > 0)
                 {
                     gv_Chg_Details.DataSource = dss.Tables[7];
                     gv_Chg_Details.DataBind();
                     ViewState["CurrentTable"] = dss.Tables[7];
                 }
                 else
                 {
                     SetInitialRow();
                 }

                 if (dss.Tables[8].Rows.Count > 0)
                 {
                     ddl_cur.SelectedValue = dss.Tables[8].Rows[0]["CUR"].ToString();
                     txtEx_Rate.Text = dss.Tables[8].Rows[0]["EX_RATE"].ToString();
                 }

                 if (dss.Tables[9].Rows.Count > 0)
                 {
                     txtInvoiceNo.Text = dss.Tables[9].Rows[0]["CR_BILL_INV_NO"].ToString();
                     txtDate.Text = txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                 }
                //-----------------------------------------------------------------------------------------
             }
             else
             {
                 Alert_msg("Select Ur Customer Name", "ddlCus_name");
             }
            
    }

    private string Get_Jobs_Tbl()
    {
        string Val = string.Empty;
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("JOBNO", typeof(string)));
        dt.Columns.Add(new DataColumn("JOBNO_PS", typeof(string)));
        dt.Columns.Add(new DataColumn("NON_TAX_AMT", typeof(string)));
        dt.Columns.Add(new DataColumn("TAX_AMT", typeof(string)));
        dt.Columns.Add(new DataColumn("TAX_VALUE", typeof(string)));
        dt.Columns.Add(new DataColumn("GRAND_TOTAL", typeof(string)));

        if (gv_Jobno.Rows.Count > 0)
        {
            for (int i = 0; i < gv_Jobno.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["JOBNO"] = gv_Jobno.Rows[i].Cells[2].Text;
                dr["JOBNO_PS"] = gv_Jobno.Rows[i].Cells[3].Text;
                dr["NON_TAX_AMT"] = gv_Jobno.Rows[i].Cells[4].Text.Replace("&nbsp;", "");
                dr["TAX_AMT"] = gv_Jobno.Rows[i].Cells[5].Text.Replace("&nbsp;", "");
                dr["TAX_VALUE"] = gv_Jobno.Rows[i].Cells[6].Text.Replace("&nbsp;", "");
                dr["GRAND_TOTAL"] = gv_Jobno.Rows[i].Cells[7].Text.Replace("&nbsp;", "");
                dt.Rows.Add(dr);
            }
            Val = ConvertDataTableToXML(dt);
        }

        return Val;
    }
    protected void gv_Gen_Item_I_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_I = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_I.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_I.Enabled = false;

            TextBox txt_Jobno_PS = (e.Row.FindControl("txt_Jobno_PS") as TextBox);
            txt_Jobno_PS.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS.Enabled = false;
        }
    }
    protected void gv_Gen_Item_II_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_II = (e.Row.FindControl("txt_Jobno_II") as TextBox);
            txt_Jobno_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_II.Enabled = false;

            TextBox txt_Jobno_PS_II = (e.Row.FindControl("txt_Jobno_PS_II") as TextBox);
            txt_Jobno_PS_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS_II.Enabled = false;
        }
    }
    private DataSet ds_value( string val)
    {
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        string Con_wrk = string.Empty;
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = ddlWorkingPeriod.SelectedValue.ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            Con_wrk = table1.Rows[0]["SERVER_NAME"].ToString();
            //-----------------------------------------------------------------//
            if (val == "1")
            {
                dss = BP.Select_Inv(ObjUBO, Connection.Get_Con_String(ddlWorkingPeriod.SelectedValue.ToString()));
            }
            else if (val == "2")
            {
                dss = BP.Select_Imp_Exp_Data(ObjUBO, Con_wrk);
            }
        }
        return dss;
    }
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Cus_name();
        ddlCus_name_SelectedIndexChanged(sender, e);
    }
    private string Get_Con_String()
    {
        DataSet ds = new DataSet();
        string Con_wrk = string.Empty;
        ObjUBO.A292 = lbl_Com_Lic.Text;
        ObjUBO.A299 = ddlWorkingPeriod.SelectedValue.ToString();
        ObjUBO.A300 = "DB_Name_Select";
        ds = BP.Db_Connection(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Con_wrk = ds.Tables[0].Rows[0][1].ToString();
        }
        return Con_wrk;
    }
    
    protected void Rd_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Cus_name();
        load_Shipment_Type();
    }
    private void load_Shipment_Type()
    {
        ddlshipment_type.Items.Clear();
        ddlshipment_type.Items.Add(new ListItem("", ""));
        if (Rd_Imp_Exp.SelectedValue.ToString() == "I")
        {
            ddlshipment_type.Items.Add(new ListItem("LCL", "LCL"));
            ddlshipment_type.Items.Add(new ListItem("FCL_20", "FCL_20"));
            ddlshipment_type.Items.Add(new ListItem("FCL_40", "FCL_40"));
            ddlshipment_type.Items.Add(new ListItem("FCL_20_40", "FCL_20_40"));
            ddlshipment_type.Items.Add(new ListItem("Bond", "Bond"));
        }
        else
        {
            ddlshipment_type.Items.Add(new ListItem("FCL_20", "FCL_20"));
            ddlshipment_type.Items.Add(new ListItem("FCL_40", "FCL_40"));
            ddlshipment_type.Items.Add(new ListItem("FCL_20_40", "FCL_20_40"));
        }
    }
    protected void gv_Gen_Annexure_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
            //gv_Gen_Annexure.Rows[1].ForeColor = System.Drawing.Color.DarkRed;
        }
    }
    //RR--------------------------------------------------------------------s
    protected void Rd_Royal_Other_SelectedIndexChanged(object sender, EventArgs e)
    {
        E_Royal_Other_Jobs();
    }
    private void E_Royal_Other_Jobs()
    {
        
        txt_S_Billno.Text = string.Empty;
        ddl_Billno.SelectedIndex = -1;

        if (Rd_Royal_Other.SelectedValue.ToString() == "R")
        {
            txt_S_Billno.Enabled = false;
            ddl_Billno.Enabled = true;
        }
        else
        {
            ddl_Billno.Enabled = false;
            txt_S_Billno.Enabled = true;
        }
        
    }
    protected void ddl_Billno_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Job_Data();
    }
    private void load_Job_Data()
    {
        txt_S_Billno.Text = string.Empty;
        Clear_N();
        if (ddl_Billno.SelectedValue.ToString() != string.Empty)
        {
            txt_S_Billno.Text = ddl_Billno.SelectedItem.ToString();
        }
    }
    private void Clear_N()
    {
        gv_Jobno.DataSource = dt;
        gv_Jobno.DataBind();

        gv_Gen.DataSource = dt;
        gv_Gen.DataBind();
        gv_IGM.DataSource = dt;
        gv_IGM.DataBind();
        gv_Inv.DataSource = dt;
        gv_Inv.DataBind();
        gv_Item.DataSource = dt;
        gv_Item.DataBind();
        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();
        Clear();
    }
    protected void ddlbranch_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCus_name.SelectedValue.ToString() != string.Empty && ddlbranch_No.SelectedValue.ToString() != string.Empty)
        {
            Load_Jobno();
        }
        else
        {
            ddl_Billno.Items.Clear();
            txt_S_Billno.Text = string.Empty;
            ddl_Billno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Billno.SelectedIndex = 0;
            Clear_N();
        }
    }
    private void Load_Jobno()
    {
        string con_String = string.Empty;
        ddl_Billno.Items.Clear();
        DataSet dss = new DataSet();
        con_String = Get_Con_String();
        ObjUBO.A5 = ddlCus_name.SelectedValue.ToString();
        ObjUBO.A6 = ddlbranch_No.SelectedValue.ToString();
        ObjUBO.A7 = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A40 = "Load_Bill_No";
        dss = BP.Select_Inv(ObjUBO, con_String);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddl_Billno.DataSource = dss.Tables[0];
            ddl_Billno.DataTextField = "BILL_INV_NO";
            ddl_Billno.DataValueField = "BILL_INV_NO";
            ddl_Billno.DataBind();
        }
        ddl_Billno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Billno.SelectedIndex = 0;
    }
    protected void gv_Jobno_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }

    private string Get_R_Jobs()
    {
        string values = "";

        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("JOBNO", typeof(string)));
        dt.Columns.Add(new DataColumn("JOBNO_PS", typeof(string)));

        for (int i = 0; i < gv_Jobno.Rows.Count; i++)
        {
            CheckBox chk_All = (CheckBox)gv_Jobno.Rows[i].Cells[1].FindControl("chk_All");

            if (chk_All.Checked == true)
            {
                dr = dt.NewRow();
                dr["JOBNO"] = gv_Jobno.Rows[i].Cells[2].Text;
                dr["JOBNO_PS"] = gv_Jobno.Rows[i].Cells[3].Text;
                dt.Rows.Add(dr);
            }
        }
        if (dt.Rows.Count > 0)
        {
            values = ConvertDataTableToXML(dt);
        }
        return values;   
    }
    protected void gv_Gen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_I = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_I.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_I.Enabled = false;

            TextBox txt_Jobno_PS = (e.Row.FindControl("txt_Jobno_PS_I") as TextBox);
            txt_Jobno_PS.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS.Enabled = false;
        }
    }
    protected void gv_IGM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_I = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_I.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_I.Enabled = false;

            TextBox txt_Jobno_PS = (e.Row.FindControl("txt_Jobno_PS_I") as TextBox);
            txt_Jobno_PS.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS.Enabled = false;
        }
    }
    protected void gv_Inv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_II = (e.Row.FindControl("txt_Jobno_II") as TextBox);
            txt_Jobno_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_II.Enabled = false;

            TextBox txt_Jobno_PS_II = (e.Row.FindControl("txt_Jobno_PS_II") as TextBox);
            txt_Jobno_PS_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS_II.Enabled = false;
        }
    }
    protected void gv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_II = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_II.Enabled = false;

            TextBox txt_Jobno_PS_II = (e.Row.FindControl("txt_Jobno_PS_I") as TextBox);
            txt_Jobno_PS_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS_II.Enabled = false;
        }
    }
    protected void gv_BE_SB_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt_Jobno_II = (e.Row.FindControl("txt_Jobno_I") as TextBox);
            txt_Jobno_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_II.Enabled = false;

            TextBox txt_Jobno_PS_II = (e.Row.FindControl("txt_Jobno_PS_I") as TextBox);
            txt_Jobno_PS_II.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5E4E2");
            txt_Jobno_PS_II.Enabled = false;
        }
    }
    protected void Rd_Inv_Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet d = new DataSet();
        if (HDupdate_id.Value.ToString() != string.Empty && HDupdate_id.Value.ToString() != null)
        {
            ObjUBO.A4 = txtInvoiceNo.Text;
            ObjUBO.A16 = Rd_Inv_Status.SelectedValue.ToString();
            ObjUBO.A40 = "Invoice_Approve";
            d = BP.Select_Inv(ObjUBO);

            if (Rd_Inv_Status.SelectedValue.ToString() == "UA")
            {
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
                if (d.Tables[0].Rows.Count > 0)
                {
                    txtInvoiceNo.Text = d.Tables[0].Rows[0][0].ToString();
                }
                Alert_msg("Approved Successfully", "Rd_Inv_Status");
            }
        }
    }
    private void Billing_Approve(string JobEntry, string Approve_Status)
    {
        if (Acc_Connection.Billing_Aproval_Company() == "Y")
        {
            if (Acc_Connection.Billing_Aproval_Admin() == "Y")
            {
                if (JobEntry == "C")
                {
                    //Bill_Admin.Visible = true;
                    Bill_Admin.Visible = false;
                    btn_EInvoice.Visible = true;
                    btn_EInvoice.Text = "Generate Einvoice";

                }
                else {
                    btn_EInvoice.Visible = false;
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

    protected void btn_EInvoice_Click(object sender, EventArgs e)
    {
        string Imp_Gen = string.Empty, GST_Bill_Cha = string.Empty, jsonOut = string.Empty;

        string filepath = string.Empty;
        filepath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");
        string TAX = string.Empty, IGSTOTRA = string.Empty, Out_Val = string.Empty;

        if (Directory.Exists(filepath) == false)
        {
            Directory.CreateDirectory(filepath);
        }

        DirectoryInfo dir = new DirectoryInfo(filepath);
        foreach (FileInfo fi in dir.GetFiles())
        {
            fi.Delete();
        }

        Credit_Note_Json_cs CJ = new Credit_Note_Json_cs();
        DataSet ds = new DataSet();
        ds = CJ.Data_Json(HDupdate_id.Value.ToString(), txtInvoiceNo.Text);
        if (ds.Tables[2].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TAX = ds.Tables[1].Rows[0]["TAX"].ToString();
                    IGSTOTRA = ds.Tables[1].Rows[0]["IGSTOTRA"].ToString();

                    Imp_Gen = "{" +
                        @"""" + "einvoiceusername" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["GSTNID"].ToString() + @"""" +
                   "," + @"""" + "Invoice" + @"""" + ":{" +


                    @"""" + "version" + @"""" + ":" + @"""" + "1.1" + @"""" +

                    "," + @"""" + "TranDtls" + @"""" + ":{" +
                             @"""" + "TaxSch" + @"""" + ":" + @"""" + "GST" + @"""" +
                            "," + @"""" + "SupTyp" + @"""" + ":" + @"""" + TAX + @"""" +
                            "," + @"""" + "RegRev" + @"""" + ":" + @"""" + "N" + @"""" +
                            "," + @"""" + "IgstOnIntra" + @"""" + ":" + @"""" + IGSTOTRA + @"""" +
                            "}" +

                            //================================
                            "," + @"""" + "DocDtls" + @"""" + ":{" +
                              @"""" + "Typ" + @"""" + ":" + @"""" + "CRN" + @"""" +
                             "," + @"""" + "No" + @"""" + ":" + @"""" + ds.Tables[1].Rows[0]["BILL_INV_NO"].ToString() + @"""" +
                             "," + @"""" + "Dt" + @"""" + ":" + @"""" + ds.Tables[1].Rows[0]["BILL_INV_DATE"].ToString() + @"""" +
                             "}" +

                               //==============Company==================
                               "," + @"""" + "SellerDtls" + @"""" + ":{" +
                                @"""" + "Gstin" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["GSTNID"].ToString() + @"""" +
                               "," + @"""" + "LglNm" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["COMPANY_NAME"].ToString() + @"""" +
                               "," + @"""" + "Addr1" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["C_ADDRESS"].ToString() + @"""" +
                               "," + @"""" + "Addr2" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["C_ADDRESS_II"].ToString() + @"""" +
                               "," + @"""" + "Loc" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["STATENAME"].ToString() + @"""" +
                               "," + @"""" + "Pin" + @"""" + ":" + @"" + ds.Tables[0].Rows[0]["PINCODE"].ToString() + @"" +
                               "," + @"""" + "Stcd" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["STATECODE"].ToString() + @"""" +
                               "," + @"""" + "Ph" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["MOBILE_NO"].ToString() + @"""" +
                               "," + @"""" + "Em" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["EMAILID"].ToString() + @"""" +
                               "}" +

                                //===============Customer=================
                                "," + @"""" + "BuyerDtls" + @"""" + ":{" +
                                 @"""" + "Gstin" + @"""" + ":" + @"""" + ds.Tables[1].Rows[0]["GSTN_ID"].ToString() + @"""" +
                                "," + @"""" + "LglNm" + @"""" + ":" + @"""" + ds.Tables[1].Rows[0]["PARTY_NAME"].ToString() + @"""" +
                                "," + @"""" + "Pos" + @"""" + ":" + @"""" + ds.Tables[1].Rows[0]["STATE_CODE"].ToString() + @"""" +
                                "," + @"""" + "Addr1" + @"""" + ":" + @"""" + ds.Tables[1].Rows[0]["PARTY_ADDRESS_I"].ToString() + @"""" +
                                "," + @"""" + "Addr2" + @"""" + ":" + @"""" + ds.Tables[1].Rows[0]["PARTY_ADDRESS_II"].ToString() + @"""" +
                                "," + @"""" + "Loc" + @"""" + ":" + @"""" + ds.Tables[1].Rows[0]["STATE_NAME"].ToString() + @"""" +
                                "," + @"""" + "Pin" + @"""" + ":" + @"" + ds.Tables[1].Rows[0]["PIN_CODE"].ToString() + @"" +
                                "," + @"""" + "Stcd" + @"""" + ":" + @"""" + ds.Tables[1].Rows[0]["STATE_CODE"].ToString() + @"""" +
                                "}";

                    //================================
                    GST_Bill_Cha = Gst_Bill_Charge(Imp_Gen, ds);

                    Out_Val = GST_Bill_Cha + "," + @"""" + "ValDtls" + @"""" + ":{" +
                     @"""" + "AssVal" + @"""" + ":" + @"" + ds.Tables[3].Rows[0]["AssVal"].ToString() + @"" +
                    "," + @"""" + "CgstVal" + @"""" + ":" + @"" + ds.Tables[3].Rows[0]["CgstVal"].ToString() + @"" +
                    "," + @"""" + "SgstVal" + @"""" + ":" + @"" + ds.Tables[3].Rows[0]["SgstVal"].ToString() + @"" +
                    "," + @"""" + "IgstVal" + @"""" + ":" + @"" + ds.Tables[3].Rows[0]["IgstVal"].ToString() + @"" +
                    "," + @"""" + "CesVal" + @"""" + ":" + @"" + "0" + @"" +
                    "," + @"""" + "StCesVal" + @"""" + ":" + @"" + "0" + @"" +
                    "," + @"""" + "Discount" + @"""" + ":" + @"" + "0" + @"" +
                    "," + @"""" + "OthChrg" + @"""" + ":" + @"" + "0" + @"" +
                    "," + @"""" + "RndOffAmt" + @"""" + ":" + @"" + "0" + @"" +
                    "," + @"""" + "TotInvVal" + @"""" + ":" + @"" + ds.Tables[3].Rows[0]["TotInvVal"].ToString() + @"" +
                    "}";
                    jsonOut = Out_Val + "}}";
                    //jsonOut = Out_Val + "}";
                    System.IO.File.WriteAllText(filepath + "Inv_" + txtInvoiceNo.Text.Replace('/', '_') + ".JSON", jsonOut);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                    SubmitInvoice(jsonOut, txtInvoiceNo.Text);
                    //---------EEEEE---------------
                }
            }
        }
    }
    private void SubmitInvoice(string _invoiceJSONString, string _Invno)
    {
        string result = "";
        /* testingS
        string AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjUzNTkyNzdkY2Y2MmQyYTE5YTkyNzU2ODQ3NTQxYmEzMzM4YTkzMTZmNzhlZmQxZGE5YzRiMWYwYTQ2MDkzYjQwY2NlY2YwYWQ5OTNiMjhhIn0.eyJhdWQiOiIxIiwianRpIjoiNTM1OTI3N2RjZjYyZDJhMTlhOTI3NTY4NDc1NDFiYTMzMzhhOTMxNmY3OGVmZDFkYTljNGIxZjBhNDYwOTNiNDBjY2VjZjBhZDk5M2IyOGEiLCJpYXQiOjE2NDg2MzM0NTYsIm5iZiI6MTY0ODYzMzQ1NiwiZXhwIjo0ODA0MzA3MDU2LCJzdWIiOiIxIiwic2NvcGVzIjpbXX0.uJpi9z5J_T97qJeNcoTFIsFCSMiq2JmZ1wfMMiVA5iQhOKkTC3b2TO56i8AGRjI__GQK2H5nX-28AJqFpxG0yoYb8sckd3IiQ-LUmk3ziSAUPSqSQvAsvbq5UhA66kPxQRnEnCN5o516uXT8tJdOssg3r5p7Z6xdA4Np3ysCerERhhrCUikxE0ppxyEQStXwVoLPAfFQshW5UpfqABE_uUMj07J6iWkR4xi1Hqn7sNs7Z_416Cs-Fw2HLg69TVzpKoqWJprgZUHQZSPMjIy5EX6M56m8SsscNPvhA39-QGUmS02c48scv8bvaE7o1RlpRNfFs5Ah72PUKQmqClvjwdkXxHzEnGf2ER6D1w22NSL5RQTjKpEquNNigTtT7-1XfDh30CD8dvlR_02MhHpLttnGikjhmfWWnkycRZAVw06sCEcFrkfY2DdrwhEUiT1jKxAY-UaTVEtT_82cC9EoCUMmRjw2UyzKAdDVzd5Kh_8HdAXorva_4Mfgr9CbMRKFagQm-_exGYLStiqExWfBzLnY8hJFg5gRrKZQr8De0eWH2AYRp0mzRrjPtS4SR9fUn2pric07YocCHDIVW2BoOW5lXtj8n_Yu1SpoqazwHQkgLmdsMHocq7gnzwwRU45UVtBjUV4R7rBgfKrS9B_I4eXSqeUwjGMlKrQ6vQrIffg";
        string urla = "http://einvoice.mazeworkssolutions.com/maze_eserver/public/api/einvoicegenerate";
        testingE */

        string AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxIiwianRpIjoiMjRmZmJmYmJiMjIxOGRhMzUzYmNhM2JjMzQxZTQ3YWMwZTc0MmM5MDIyOWUxYmRmMjBhZjcxODcxMWJlZmNjY2NjOTY5YmMxMTZjZWFjYWYiLCJpYXQiOjE3MjQzMTg4OTAuNTMyODIyLCJuYmYiOjE3MjQzMTg4OTAuNTMyODI1LCJleHAiOjE3NTU4NTQ4OTAuNTMwNzk3LCJzdWIiOiIzMCIsInNjb3BlcyI6W119.ibLHDFe9NNXq17wb5n6QpN3Nh-N9WlR-ikRMyZCaM0RUU8r4pSKzBuTzyqHVfRJDrcasmeA1JqEIMHx6_PiMh0r3LmuAhiPeHkDN0ATHx-WlFpJLwPt6Wjd49R6ZA2lHlpCYPJWd6Kf9OluibDooyITwSBuxI1_au_GtBcvDftuna9H4sss-atQrSj27u1lH7z8tjEwRSyINciHqyhKllT8Tx_1Gnj5V84xKmZHtP6Rrd-UvCcN19jtQ152mN05WfGJ2XhdXm5VlwBjdhZnNhZwGSpM9OKlBxfmCWc6t0Hd_374t50cZtolkFP_c1NwpJg0ikdg6X6Fjh51WJKE6p4QtgLWHJ3CmTCLxxVqQD5852r2tqawAauHAJKRasYjspqCz-85SWYAZ0dsj0pkjmDvBX_1cXl2wLFP1VF0L15gmVcYv65Z-q8zgdlVwAZvoXKN9jKpdwBCGE6kvomaSvjd06FiGIplFnyHvJ6TvFWhhGmHeYESjEsAhWGiCb4Xf1uIIHLWKTB3nrp0pdu-yqmn4sD7baIyH0UU3jAlkf53Y1wF8Im2dzUAt1_C1m6BxlS3-IHZfqkvySZJ7U-eqYX-n8W1PEdKs0KCiRmnneXdTAq5baXbQgqzJRo_NJYotRlMiBvCT1zjEyyTcVi9-t2UB3xEvrxMqDhc_uMUvTu4";
       
        string reqstr = _invoiceJSONString;
        string Imp_Exp = Rd_Imp_Exp.SelectedItem.Text;

        string urla = "http://einvoice2.mazeworkssolutions.com/maze_eserver/public/api/einvoicegenerate";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urla);
        request.Method = "POST";
        request.Headers.Add("Authorization", "Bearer " + AccessToken);
        request.ContentType = "application/json; charset=utf-8";

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(reqstr);
            streamWriter.Flush();
            streamWriter.Close();
        }
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
        }

        if (result != "")
        {
            string[] Resut_Res;
            Resut_Res = result.Split(',');
            if (Resut_Res.Length > 9)
            {
                if (Resut_Res[0].ToString().ToLower().Contains("success"))
                {
                    DataTable dt = new DataTable();
                    DataSet dss = new DataSet();
                    DataSet ds = new DataSet();
                    Credit_Note_Json_cs SJ = new Credit_Note_Json_cs();

                    string errorFolder = "";
                    errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/ACC_GST_BILL_CR_QRCODE/" + Imp_Exp + "/");

                    if (Directory.Exists(errorFolder) == false)
                    {
                        Directory.CreateDirectory(errorFolder);
                    }
                    ObjUBO.A201 = "";
                    ObjUBO.A202 = Rd_Imp_Exp.SelectedValue.ToString();
                    ObjUBO.A203 = txtInvoiceNo.Text;

                    string QRImg = Resut_Res[8].Substring(Resut_Res[8].ToString().IndexOf(":") + 2, Resut_Res[8].Length - (Resut_Res[8].ToString().IndexOf(":") + 3));


                    string url = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
                    url = url.Replace(@"\", @"/");
                    ObjUBO.A204 = Resut_Res[6].Substring(Resut_Res[6].ToString().IndexOf(":") + 2, Resut_Res[6].Length - (Resut_Res[6].ToString().IndexOf(":") + 3)); //IRN_No
                    ObjUBO.A205 = Resut_Res[1].Substring(Resut_Res[1].ToString().IndexOf(":") + 2, Resut_Res[1].Length - (Resut_Res[1].ToString().IndexOf(":") + 3)); // "ACK_No";
                    ObjUBO.A206 = Resut_Res[5].Substring(Resut_Res[5].ToString().IndexOf(":") + 2, 10);// ACK_Dt;
                    ObjUBO.A207 = Resut_Res[7].Substring(Resut_Res[7].ToString().IndexOf(":") + 2, Resut_Res[7].Length - (Resut_Res[7].ToString().IndexOf(":") + 3));  // SignedQRCodeImage;
                    ObjUBO.A208 = Resut_Res[8].Substring(Resut_Res[8].ToString().IndexOf(":") + 2, Resut_Res[8].Length - (Resut_Res[8].ToString().IndexOf(":") + 3)); // SignedQRCode;
                    ObjUBO.A209 = Resut_Res[9].Substring(Resut_Res[9].ToString().IndexOf(":") + 2, Resut_Res[9].Length - (Resut_Res[9].ToString().IndexOf(":") + 3)); //Status
                    ObjUBO.A210 = url; //QRCode_ImgPath
                    ObjUBO.A211 = "";
                    ObjUBO.A212 = "WebService";
                    ObjUBO.A213 = ddlWorkingPeriod.SelectedValue.ToString();
                    ObjUBO.A214 = "S";
                    dss = SJ.E_Invoice_Ins_Upd(ObjUBO);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        if (dss.Tables[0].Rows[0]["Outval"].ToString() == "S")
                        {
                            Alert_msg("E-Invoice Generated Successfully.");
                            lblmsg.Text = "E-Invoice generated.";
                            lbl_E_inv_msg.Text = "Note :- Invoice Approved Can't be Modified";
                            btnDelete.Visible = false;
                            btnNew.Visible = false;
                            btnSave.Visible = false;
                            btnUpdate.Visible = false;
                            btn_EInvoice.Visible = false;
                            Rd_Inv_Status.Visible = false;

                            //btn_Addjobno.Visible = false;
                            btn_EInvoice.Visible = false;
                            btn_Remove_Job.Visible = false;
                            btnloadData.Visible = false;
                        }
                        else if (dss.Tables[0].Rows[0]["Outval"].ToString() == "U")
                        {
                            Alert_msg("Already exists !");
                        }
                    }
                    else
                    {
                        Alert_msg("Not Saved");
                    }
                }
                else
                {
                    Alert_msg("Not Success");
                }
            }
            else
            {
                Alert_msg("Not Success" + result);
            }
        }
        else
        {
            Alert_msg("Not Success");
        }
    }
    public string Gst_Bill_Charge(string OP, DataSet dss)
    {
        string Ch_Data_A = string.Empty, Ch_Data_B = string.Empty, Ch_Data_C = string.Empty, Ch_Data = string.Empty;
        if (dss.Tables[2].Rows.Count > 0)
        {
            for (int i = 0; i < dss.Tables[2].Rows.Count; i++)
            {
                if (i == 0)
                {
                    // Ch_Data_A = OP + "," + @"""" + "ItemList" + @"""" + ":[{";
                    Ch_Data_A = OP + "," + @"""" + "ItemList" + @"""" + ":[{" + @"""" + "SlNo" + @"""" + ":" + @"""" + dss.Tables[2].Rows[i]["Id"].ToString() + @"""";
                }
                else
                {
                    Ch_Data_A = ",{" + @"""" + "SlNo" + @"""" + ":" + @"""" + dss.Tables[2].Rows[i]["Id"].ToString() + @"""";
                }
                Ch_Data_B = Ch_Data_A + "," + @"""" + "PrdDesc" + @"""" + ":" + @"""" + dss.Tables[2].Rows[i]["CHARGE_NAME"].ToString() + @"""" +
                 "," + @"""" + "IsServc" + @"""" + ":" + @"""" + "Y" + @"""" +

                 "," + @"""" + "HsnCd" + @"""" + ":" + @"""" + dss.Tables[2].Rows[i]["HSN_CODE"].ToString() + @"""" +
                 "," + @"""" + "Qty" + @"""" + ":" + @"""" + dss.Tables[2].Rows[i]["QTY"].ToString() + @"""" +
                 "," + @"""" + "FreeQty" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "Unit" + @"""" + ":" + @"""" + "PAC" + @"""" +
                 "," + @"""" + "UnitPrice" + @"""" + ":" + @"" + dss.Tables[2].Rows[i]["UNIT_PRICE"].ToString() + @"" +
                 "," + @"""" + "TotAmt" + @"""" + ":" + @"" + dss.Tables[2].Rows[i]["AMOUNT"].ToString() + @"" +
                 "," + @"""" + "Discount" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "PreTaxVal" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "AssAmt" + @"""" + ":" + @"" + dss.Tables[2].Rows[i]["AMOUNT"].ToString() + @"" +
                 "," + @"""" + "GstRt" + @"""" + ":" + @"" + dss.Tables[2].Rows[i]["GST_RATE"].ToString() + @"" +
                 "," + @"""" + "IgstAmt" + @"""" + ":" + @"" + dss.Tables[2].Rows[i]["IGST_AMT"].ToString() + @"" +
                 "," + @"""" + "CgstAmt" + @"""" + ":" + @"" + dss.Tables[2].Rows[i]["CGST_AMT"].ToString() + @"" +
                 "," + @"""" + "SgstAmt" + @"""" + ":" + @"" + dss.Tables[2].Rows[i]["SGST_AMT"].ToString() + @"" +
                 "," + @"""" + "CesRt" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "CesAmt" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "CesNonAdvlAmt" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "StateCesRt" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "StateCesAmt" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "StateCesNonAdvlAmt" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "OthChrg" + @"""" + ":" + @"" + "0" + @"" +
                 "," + @"""" + "TotItemVal" + @"""" + ":" + @"" + dss.Tables[2].Rows[i]["TOTAL_ITEM_VAL"].ToString() + @"" +
                 "," + @"""" + "OrdLineRef" + @"""" + ":" + "null" +
                 "," + @"""" + "OrgCntry" + @"""" + ":" + @"""" + "IN" + @"""" +

                 "," + @"""" + "PrdSlNo" + @"""" + ":" + @"""" + dss.Tables[2].Rows[i]["Id"].ToString() + @"""" + "}";

                Ch_Data_C += Ch_Data_B;
                Ch_Data_A = string.Empty;
                Ch_Data_B = string.Empty;
            }
            Ch_Data = Ch_Data_C + "]";
        }
        else
        {
            Ch_Data = OP;
        }
        return Ch_Data;
    }
    private string QR_Imagepath(string SignedQRCode, string Invno)
    {
        //https://www.aspsnippets.com/Articles/880/Dynamically-generate-and-display-QR-code-Image-in-ASPNet/
        string errorFolder = "", imagename = "";
        string QRimgpath = " ";
        if (SignedQRCode != "")
        {
            string code = SignedQRCode;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;
            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                    errorFolder = Server.MapPath("~/Submission/" + "/Accounts/" + Connection.COMPANYID() + "/ACC_GST_BILL_QRCODE/" + "/" + Connection.Current_User() + "/");
                    if (Directory.Exists(errorFolder) == false)
                    {
                        Directory.CreateDirectory(errorFolder);
                    }
                    if (Directory.Exists(errorFolder) == true)
                    {
                        DirectoryInfo dir = new DirectoryInfo(errorFolder);
                        foreach (FileInfo fi in dir.GetFiles())
                        {
                            fi.Delete();
                        }
                    }
                    imagename = Invno + ".png";
                    QRimgpath = errorFolder + imagename;
                    img.Save(QRimgpath);
                }
            }
        }
        return QRimgpath;
    }
}