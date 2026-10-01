using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Exp_Invoice_Job : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    Billing_Exp_Invoice BI = new Billing_Exp_Invoice();
    AppSession aps = new AppSession();

    public int i,Screen_Id;

    public string currentuser, currentbranch, Working_Period, COMPANY_LICENSE,SELECT_BRANCH;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    DataSet ds_lic=new  DataSet();
    

    decimal tax_amt, non_tax_amt;
    string Exporter_name=string.Empty ;
    string J_no =string.Empty;

    string Ch_wgt = string.Empty;
    string Ch_type = string.Empty;
    public bool chk = false;
       
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
       
        currentuser = Connection.Current_User();
        currentbranch = Connection.Current_Branch();
        Working_Period = Connection.WorkingPeriod();

        hdn_Jobno.Value = "1";
        SELECT_BRANCH = Connection.Get_Company_Type();
        Hd_branch.Value = SELECT_BRANCH;

        COMPANY_LICENSE = Connection.Company_License().ToLower();

        if (COMPANY_LICENSE != "eri00314")
        {
            CalendarExtender1.EndDate = DateTime.Today;
        }

        if (!Page.IsPostBack)
        {
            load_Inv_Type();
            DataTable dtt = new DataTable();
            GV.DataSource = dtt;
            GV.DataBind();

            GV_2.DataSource = dtt;
            GV_2.DataBind();
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnrpt.Visible = false;
            btn_T_rpt.Visible = false;
            btn_T_N_rpt.Visible = false;  
            txtexporterName.Visible = false;

            T.Visible = false;

            //Company_details();

            Tr_mode_load();
            Shipment_Type();

            if (COMPANY_LICENSE != "eri00314" || COMPANY_LICENSE != "eri00287")
            {
                txtInvoiceNo.Attributes.Add("readonly", "readonly");
                txtInvoiceNo.Style.Add("background-color", "#F0F0F0");
            }

            txtnon_tax_amt.Attributes.Add("readonly", "readonly");
            txttax_amt.Attributes.Add("readonly", "readonly");
 
            HD_Bill_Jobno.Value = string.Empty;

            if (Request.QueryString["Page"] == null)
            {
                if (SELECT_BRANCH != "")
                {
                    //ddlbranch.SelectedValue = SELECT_BRANCH;

                    if (COMPANY_LICENSE == "eri00314")
                    {
                        WK.Visible = true;
                        LoadFinancialYear();
                        ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();
                    }

                    load_Exp_name();
                    load_date();
                }
                else
                {
                    load_date();
                }
                
                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                HDupdate_id.Value = "";
                hd_EXP_Brslno.Value = "";
                hd_EXP_br_sl_no.Value = "";
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                    if (Request.QueryString["Page"].ToString() == "0")
                    {
                        ddltype.SelectedItem.Text = "Other";
                        div_type.Visible = false;
                    }
                    else
                    {
                       // ddltype.SelectedItem.Text = "Job";
                    }

                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlmode.Enabled = false;
                    ddlExp_name.Enabled = false;
                    ddljobno.Enabled = false;
                   // ddlbranch.Enabled = false;

                    ddltype.Enabled = false;
                    ddl_loc.Enabled = false;
                   
                    HD_Showcon.Value = "SAVED";

                    btnrpt.Visible = true;

                    if (COMPANY_LICENSE == "eri00314")
                    {
                        btn_T_rpt.Visible = false;
                        btn_T_N_rpt.Visible = false;
                    }
                    else
                    {
                        btn_T_rpt.Visible = true;
                        btn_T_N_rpt.Visible = true;
                    }


                    From_Quotation.Enabled = false;
                    HD_Bill_Jobno.Value = txtInvoiceNo.Text;
                    txt_FOB_Value.Attributes.Add("readonly", "readonly");


                    if (COMPANY_LICENSE != "eri00314" || COMPANY_LICENSE != "eri00287")
                    {
                        txtDate.Attributes.Add("readonly", "readonly");
                        txtDate.Style.Add("background-color", "#F0F0F0");
                        CalendarExtender1.Enabled = false;
                        MaskedEditExtender1.Enabled = false;
                        txtInvoiceNo.Attributes.Add("readonly", "readonly");
                        txtInvoiceNo.Style.Add("background-color", "#F0F0F0");
                    }
                   
                }
            }
        }

        txtshippername.Attributes.Add("onblur", "javascript:CallServerside_Exporter_Add('" + txtshippername.ClientID + "', '" + txtInvoiceNo.ClientID + "')");
        txtconsigneename.Attributes.Add("onblur", "javascript:CallServerside_Consignee_Add('" + txtconsigneename.ClientID + "', '" + txtCon_Add1.ClientID + "')");

        txt_notify_party_1.Attributes.Add("onblur", "javascript:CallServerside_notify_party_1_Add('" + txt_notify_party_1.ClientID + "', '" + txtCon_Add1.ClientID + "')");

        txttax_amt.Attributes.Add("onblur", "javascript:CallServerside_txttax_amt('" + txttax_amt.ClientID + "', '" + txt_leg_Per_1.ClientID + "', '" + txt_leg_Per_2.ClientID + "', '" + txt_leg_Per_3.ClientID + "', '" + txt_leg_Per_4.ClientID + "')");

        txt_leg_Per_1.Attributes.Add("onblur", "javascript:CallServerside_txttax_amt('" + txttax_amt.ClientID + "', '" + txt_leg_Per_1.ClientID + "', '" + txt_leg_Per_2.ClientID + "', '" + txt_leg_Per_3.ClientID + "', '" + txt_leg_Per_4.ClientID + "')");
        txt_leg_Per_2.Attributes.Add("onblur", "javascript:CallServerside_txttax_amt('" + txttax_amt.ClientID + "', '" + txt_leg_Per_1.ClientID + "', '" + txt_leg_Per_2.ClientID + "', '" + txt_leg_Per_3.ClientID + "', '" + txt_leg_Per_4.ClientID + "')");
        txt_leg_Per_3.Attributes.Add("onblur", "javascript:CallServerside_txttax_amt('" + txttax_amt.ClientID + "', '" + txt_leg_Per_1.ClientID + "', '" + txt_leg_Per_2.ClientID + "', '" + txt_leg_Per_3.ClientID + "', '" + txt_leg_Per_4.ClientID + "')");

        txt_leg_Per_4.Attributes.Add("onblur", "javascript:CallServerside_txttax_amt('" + txttax_amt.ClientID + "', '" + txt_leg_Per_1.ClientID + "', '" + txt_leg_Per_2.ClientID + "', '" + txt_leg_Per_3.ClientID + "', '" + txt_leg_Per_4.ClientID + "')");
       
        Mode_selection();
    }
    private void load_date()
    {
        DataSet dss = new DataSet();
        BI.Mode = "";
        BI.Branch_Type = SELECT_BRANCH;
        BI.Mflag = "Exp_Bill_Date";
        dss = BI.Select_Exp_INV();
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (COMPANY_LICENSE != "eri00314")
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
    private void Mode_selection()
    {
        if (ddlmode.SelectedItem.Text == "Air")
        {
            divCh.Style.Add("display", "block");
            //divcon.Style.Add("display", "none");
        }
        else if (ddlmode.SelectedItem.Text == "Sea")
        {
            divCh.Style.Add("display", "none");
            //divcon.Style.Add("display", "block");
        }
        else if (ddlmode.SelectedItem.Text == "Land")
        {
            divCh.Style.Add("display", "block");
           // divcon.Style.Add("display", "block");
        }
    }
    private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        BI.Mode ="";
        BI.Branch = "";
        BI.JOBNO=Request.QueryString["Page"].ToString();
        BI.BILL_INV_NO = Request.QueryString["Billinvno"].ToString();
        BI.Branch_Type = SELECT_BRANCH;
        BI.Mflag = "Inv_Exp_Jobno_Update_Select";
        dss = BI.Select_Exp_INV();
        if (dss.Tables[0].Rows.Count > 0)
        {

            HDupdate_id.Value = dss.Tables[0].Rows[0]["ID"].ToString();

            ddljobno.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString(), dss.Tables[0].Rows[0]["JOBNO"].ToString()));
            ddljobno.SelectedIndex = 0;

            ddlExp_name.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString(), dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()));
            ddlExp_name.SelectedIndex = 0;

            J_no=dss.Tables[0].Rows[0]["JOBNO"].ToString();
            Exporter_name = dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
            
            ddlmode.Text = dss.Tables[0].Rows[0]["MODE"].ToString();
            txtjob_invno.Text = dss.Tables[0].Rows[0]["INV_NO"].ToString();
            txtDate.Text = dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();
            //ddlbranch.Text = dss.Tables[0].Rows[0]["AC_MAINTAINING_BRANCH"].ToString();
            txtInvoiceNo.Text = dss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            txtJob_inv_Date.Text = dss.Tables[0].Rows[0]["INV_DATE"].ToString();
            txtsbno.Text = dss.Tables[0].Rows[0]["SB_NO"].ToString();
            txtsbdate.Text = dss.Tables[0].Rows[0]["SB_DATE"].ToString();
            txtmawbno.Text = dss.Tables[0].Rows[0]["MAWB_NO"].ToString();
            txthawbno.Text = dss.Tables[0].Rows[0]["HAWB_NO"].ToString();
            txtconatiner_no.Text = dss.Tables[0].Rows[0]["CONTAINER_NO"].ToString();
            txtno_of_pkg.Text = dss.Tables[0].Rows[0]["NO_OF_PKG"].ToString();
            txtgross_wgt.Text = dss.Tables[0].Rows[0]["GROSS_WGT"].ToString();
            txtnetwgt.Text = dss.Tables[0].Rows[0]["NET_WGT"].ToString();
            txtvolume.Text = dss.Tables[0].Rows[0]["VOLUME"].ToString();
            txtvessel.Text = dss.Tables[0].Rows[0]["VESSEL"].ToString();
            txtdestination.Text = dss.Tables[0].Rows[0]["DESTINATION"].ToString();
            txtcommodity.Text = dss.Tables[0].Rows[0]["COMMODITY"].ToString();
            ddl_freight_status.SelectedValue = dss.Tables[0].Rows[0]["FREIGHT_STATUS"].ToString();

            if (dss.Tables[0].Rows[0]["AC_BEHALF"].ToString()=="Y" )
            {
                ch_Behalf.Checked = true;
            }

            txtshippername.Text = dss.Tables[0].Rows[0]["SHIPPER_NAME"].ToString();
            txtShip_Add1.Text = dss.Tables[0].Rows[0]["SHIPPER_ADDRESS"].ToString();
            txtconsigneename.Text = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            txtCon_Add1.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADDRESS"].ToString();
            txt_notify_party_1.Text = dss.Tables[0].Rows[0]["NOTIFY_PARTY_1"].ToString();
            txt_notify_party_1_add.Text = dss.Tables[0].Rows[0]["NOTIFY_PARTY_1_ADDRESS"].ToString();
            txt_notify_party_2.Text = dss.Tables[0].Rows[0]["NOTIFY_PARTY_2"].ToString();
            txt_notify_party_2_add.Text = dss.Tables[0].Rows[0]["NOTIFY_PARTY_2_ADDRESS"].ToString();
            txt_Remarks.Text = dss.Tables[0].Rows[0]["REMARKS"].ToString();
            txtnon_tax_amt.Text = dss.Tables[0].Rows[0]["NON_TAXABLE_AMT"].ToString();
            txttax_amt.Text = dss.Tables[0].Rows[0]["TAXABLE_AMT"].ToString();
            txt_tax_leg_1.Text = dss.Tables[0].Rows[0]["TAX_LEDGER_1"].ToString();
            txt_leg_Per_1.Text = dss.Tables[0].Rows[0]["LEDGER_1_TAX"].ToString();
            txt_tax_amt_1.Text = dss.Tables[0].Rows[0]["LEDGER_1_TAX_AMT"].ToString();
            txt_tax_leg_2.Text = dss.Tables[0].Rows[0]["TAX_LEDGER_2"].ToString();
            txt_leg_Per_2.Text = dss.Tables[0].Rows[0]["LEDGER_2_TAX"].ToString();
            txt_tax_amt_2.Text = dss.Tables[0].Rows[0]["LEDGER_2_TAX_AMT"].ToString();
            txt_tax_leg_3.Text = dss.Tables[0].Rows[0]["TAX_LEDGER_3"].ToString();
            txt_leg_Per_3.Text = dss.Tables[0].Rows[0]["LEDGER_3_TAX"].ToString();
            txt_tax_amt_3.Text = dss.Tables[0].Rows[0]["LEDGER_3_TAX_AMT"].ToString();

            txt_tax_leg_4.Text = dss.Tables[0].Rows[0]["TAX_LEDGER_4"].ToString();
            txt_leg_Per_4.Text = dss.Tables[0].Rows[0]["LEDGER_4_TAX"].ToString();
            txt_tax_amt_4.Text = dss.Tables[0].Rows[0]["LEDGER_4_TAX_AMT"].ToString();

            txt_total_tax_amt.Text = dss.Tables[0].Rows[0]["TOTAL_TAX_AMT"].ToString();
            txt_total_amt_With_tax.Text = dss.Tables[0].Rows[0]["TOTAL_AMT_TAX"].ToString();
            txt_tax_desc.Text = dss.Tables[0].Rows[0]["DESCRIPTION"].ToString();
            txtchargeWeight.Text = dss.Tables[0].Rows[0]["CHARGE_WGT"].ToString();
            txtchargeWeightType.Text = dss.Tables[0].Rows[0]["CHARGE_TYPE"].ToString();
            txtJob_Date.Text = dss.Tables[0].Rows[0]["JOB_DATE"].ToString();
            ddltype.SelectedValue = dss.Tables[0].Rows[0]["INV_TYPE"].ToString();
            if (dss.Tables[0].Rows[0]["INV_TYPE"].ToString() == "Other")
            {
                div_From_Quot.Visible = false;
                div_loc.Visible = false;
            }
            else
            {
                div_From_Quot.Visible = true;
                div_loc.Visible = true;
            }

            hd_EXP_Brslno.Value = dss.Tables[0].Rows[0]["EXP_BRANCH_SLNO"].ToString();
            hd_EXP_br_sl_no.Value = dss.Tables[0].Rows[0]["NOTIFY_PARTY_1_BR_SLNO"].ToString();
            ddl_Bill_status.SelectedValue = dss.Tables[0].Rows[0]["BILL_STATUS"].ToString();
           
            ddlShipment_type.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString(), dss.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString()));
            ddlShipment_type.SelectedIndex = 0;
            ddlShipment_type.SelectedValue = dss.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString();
            From_Quotation.Checked = Convert.ToBoolean(dss.Tables[0].Rows[0]["FROM_QUOTATION"].ToString());
            txt_Adv_amt.Text = dss.Tables[0].Rows[0]["ADVANCE_AMT"].ToString();
            txt_FOB_Value.Text = dss.Tables[0].Rows[0]["FOB_VALUE"].ToString();
            

            if (ddlmode.Text == "Air")
            {
                lblA_S_1.Text = "MAWB No:";
                lblA_S_2.Text = "HAWB No:";
            }
            else if (ddlmode.Text == "Sea")
            {
                lblA_S_1.Text = "MBL No:";
                lblA_S_2.Text = "HBL No:";
            }
            else if (ddlmode.Text == "Land")
            {
                lblA_S_1.Text = "";
                lblA_S_2.Text = "";
            }
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
        if (dss.Tables[2].Rows.Count > 0)
        {
            if (dss.Tables[2].Rows.Count > 1)
            {
                ddl_loc.DataSource = dss.Tables[2];
                ddl_loc.DataTextField = "ADDRESS3";
                ddl_loc.DataValueField = "BRANCH_NO";
                ddl_loc.DataBind();

                ddl_loc.Items.Insert(0, new ListItem("All", "500"));
                ddl_loc.SelectedIndex = 0;
                if (dss.Tables[0].Rows[0]["BRANCH_NO"].ToString() != "")
                {
                    ddl_loc.SelectedValue = dss.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                }

            }
            else if (dss.Tables[2].Rows.Count == 1)
            {
                ddl_loc.DataSource = dss.Tables[2];
                ddl_loc.DataTextField = "ADDRESS3";
                ddl_loc.DataValueField = "BRANCH_NO";
                ddl_loc.DataBind();
            }
            else
            {
                ddl_loc.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddl_loc.SelectedIndex = 0;
            }
        }


        //----------end
    }

    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
            if (TRANS_MODE == "A")
            {
                ddlmode.Items.Add(new ListItem("Air", "Air"));
                lblA_S_1.Text = "MAWB No:";
                lblA_S_2.Text = "HAWB No:";
            }
            else if (TRANS_MODE == "S")
            {
                ddlmode.Items.Add(new ListItem("Sea", "Sea"));
                lblA_S_1.Text = "MBL No:";
                lblA_S_2.Text = "HBL No:";
            }
            else if (TRANS_MODE == "L")
            {
                ddlmode.Items.Add(new ListItem("Land", "Land"));
            }
        }
        else
        {
            ddlmode.Items.Add(new ListItem("", ""));
            ddlmode.Items.Add(new ListItem("Air", "Air"));
            ddlmode.Items.Add(new ListItem("Sea", "Sea"));
            ddlmode.Items.Add(new ListItem("Land", "Land"));
        }
    }

    /*private void Company_details()
    {
        if (SELECT_BRANCH != "")
        {
            DataSet dss = new DataSet();
            DataTable table = new DataTable("MyTable");
            table.Columns.Add("Branch", typeof(string));

            string[] names = { SELECT_BRANCH };
            DataRow dr;
            for (int i = 0; i < names.Length; i++)
            {
                dr = table.NewRow();
                dr["Branch"] = names[i];
                table.Rows.Add(dr);
            }

            //up to here!

            //this is:
            dss.Tables.Add(table);
            ddlbranch.DataSource = dss.Tables["MyTable"];
            ddlbranch.DataTextField = dss.Tables[0].Columns["Branch"].ToString();
            ddlbranch.DataValueField = dss.Tables[0].Columns["Branch"].ToString();

            ddlbranch.DataBind();
        }
        else
        {
            DataSet dss = new DataSet();
            dss = (DataSet)Session["COMPANY_DETAILS_DS"];

            Company_Master Comp = new Company_Master();

            ddlbranch.SelectedIndex = -1;
            Comp.COMPANY_ID = "0";
            Comp.COMPANY_LICENSE = dss.Tables[0].Rows[0][3].ToString();
            Comp.CLIENT_NAME = "";
            Comp.CONTACT_PERSON = "";
            Comp.MOBILE_NO = "";
            Comp.Ename = "select_Company_Login_Details";
            Comp.startRowIndex = "0";
            Comp.maximumRows = "0";
            DataSet ds = new DataSet();
            ds = Comp.RetrieveAll_Company_Details();

            ddlbranch.DataTextField = ds.Tables[1].Columns["Branch"].ToString();
            ddlbranch.DataValueField = ds.Tables[1].Columns["Branch"].ToString();

            ddlbranch.DataSource = ds.Tables[1];
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlbranch.SelectedIndex = 0;
        }
    }*/
    protected void txtpp_CC_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void txtamt_TextChanged(object sender, EventArgs e)
    {
    }
    protected void chk_inv_CheckedChanged(object sender, EventArgs e)
    {
    }
    private void Tax_amt_calc()
    {
        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            CheckBox INV_CHECK = (CheckBox)row.FindControl("chk_inv");

            TextBox txtch_name = (TextBox)row.FindControl("txtch_name");
            TextBox txtch_det = (TextBox)row.FindControl("txtch_det");
            TextBox txtshiptype = (TextBox)row.FindControl("txtshiptype");

            TextBox txtEx_rate = (TextBox)row.FindControl("txtEx_rate");
            TextBox txtqty = (TextBox)row.FindControl("txtqty");
            TextBox txtunit_price = (TextBox)row.FindControl("txtunit_price");
            TextBox txtamt = (TextBox)row.FindControl("txtamt");

            DropDownList txtpp_CC = (DropDownList)row.FindControl("txtpp_CC");


            if (txtch_name.Text == string.Empty && txtch_det.Text==string.Empty && txtEx_rate.Text == string.Empty && txtqty.Text == string.Empty && txtunit_price.Text == string.Empty && txtamt.Text == string.Empty)
            {

            }
            else
            {

                if ( INV_CHECK.Checked == true && txtpp_CC.Text == "T")
                {
                    tax_amt = tax_amt + Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text);
                }
                else if (INV_CHECK.Checked == true && txtpp_CC.Text == "N")
                {
                    non_tax_amt = non_tax_amt + Convert.ToDecimal(txtamt.Text == "" ? "0.00" : txtamt.Text);
                }

                txttax_amt.Text = tax_amt.ToString();
                txtnon_tax_amt.Text = non_tax_amt.ToString();

                txt_tax_amt_1.Text = ((Convert.ToDecimal(txt_leg_Per_1.Text == "" ? "0.00" : txt_leg_Per_1.Text) / Convert.ToDecimal(100.00)) * tax_amt).ToString("#0.00");
                txt_tax_amt_2.Text = ((Convert.ToDecimal(txt_leg_Per_2.Text == "" ? "0.00" : txt_leg_Per_2.Text) / Convert.ToDecimal(100.00)) * Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");
                txt_tax_amt_3.Text = ((Convert.ToDecimal(txt_leg_Per_3.Text == "" ? "0.00" : txt_leg_Per_3.Text) / Convert.ToDecimal(100.00)) * Convert.ToDecimal(txt_tax_amt_1.Text)).ToString("#0.00");

                txt_total_tax_amt.Text = (Convert.ToDecimal(txt_tax_amt_1.Text) + Convert.ToDecimal(txt_tax_amt_2.Text) + Convert.ToDecimal(txt_tax_amt_3.Text)).ToString("#0.00");

                //txt_total_amt_With_tax.Text = (Convert.ToDecimal(txt_total_tax_amt.Text) + Convert.ToDecimal(txttax_amt.Text)).ToString();
                txt_total_amt_With_tax.Text = (Convert.ToDecimal(txt_total_tax_amt.Text) + Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");

            }
        }

        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
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

                    TextBox txtcharge_name = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("txtch_name");
                    TextBox txtch_det = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtch_det");
                   // DropDownList txtshipment_type = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtshiptype");
                    TextBox txtshipment_type = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtshiptype");
                    TextBox txtEx_rate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtEx_rate");
                    TextBox txt_Qty = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtqty");
                    TextBox txtdefault_Unit_Rate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtunit_price");
                    TextBox txt_amt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtamt");
                    TextBox txt_spltaxRate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txt_spltaxRate");
                    DropDownList txtpp_cc = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtpp_CC");

                   /* if (txtcharge_name.Text == string.Empty && txtch_det.Text == string.Empty && txtEx_rate.Text == string.Empty && txt_Qty.Text == string.Empty && txtdefault_Unit_Rate.Text == string.Empty && txt_amt.Text == string.Empty)
                    {
                        Emptyrow = "Y";
                    }
                    */
                    string Amt = string.Empty;
                   if (txt_amt.Text == string.Empty || txt_amt.Text == "0" || txt_amt.Text == "0.00")
                    {
                        Amt = string.Empty;
                    }
                    else
                    {
                        Amt = "Yes";
                    }

                    if (txtcharge_name.Text == string.Empty || txtdefault_Unit_Rate.Text == string.Empty || txtdefault_Unit_Rate.Text == "0.00" || Amt == string.Empty)
                    {
                        Emptyrow = "Y";
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;


                    dtCurrentTable.Rows[i - 1]["INV_CHECK"] = INV_CHECK.Checked==true?"True":"False";

                    dtCurrentTable.Rows[i - 1]["CHARGE_NAME"] = txtcharge_name.Text;
                    dtCurrentTable.Rows[i - 1]["CHARGE_DETAILS"] = txtch_det.Text;

                    dtCurrentTable.Rows[i - 1]["SHIPMENT_TYPE"] = txtshipment_type.Text;
                    dtCurrentTable.Rows[i - 1]["EX_RATE"] = txtEx_rate.Text;
                    dtCurrentTable.Rows[i - 1]["Qty"] = txt_Qty.Text;

                    dtCurrentTable.Rows[i - 1]["DEFAULT_UNIT_RATE"] = txtdefault_Unit_Rate.Text;
                    dtCurrentTable.Rows[i - 1]["MIN_AMOUNT"] = txt_amt.Text;
                    dtCurrentTable.Rows[i - 1]["SPL_CHARGE_RATE"] = txt_spltaxRate.Text;
                    dtCurrentTable.Rows[i - 1]["Type"] = txtpp_cc.Text;

                    rowIndex++;

                    if (txtpp_cc.Text == "T" && INV_CHECK.Checked == true) 
                    {
                        if (txt_spltaxRate.Text != string.Empty && txt_spltaxRate.Text != "0.00")
                        {
                            tax_amt += (Convert.ToDecimal(txt_amt.Text == "" ? "0.00" : txt_amt.Text) * Convert.ToDecimal(txt_spltaxRate.Text == "" ? "0.00" : txt_spltaxRate.Text)) / 100;
                        }
                        else
                        {
                            tax_amt += Convert.ToDecimal(txt_amt.Text == "" ? "0.00" : txt_amt.Text);
                        }
                    }
                    else if (INV_CHECK.Checked == true && txtpp_cc.Text == "N")
                    {
                        non_tax_amt = non_tax_amt + Convert.ToDecimal(txt_amt.Text == "" ? "0.00" : txt_amt.Text); 
                    }
                    
                }

                if (Emptyrow != "Y")
                {

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["INV_CHECK"] = "True";

                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;
                    drCurrentRow["CHARGE_NAME"] = string.Empty;
                    drCurrentRow["CHARGE_DETAILS"] = string.Empty;
                   // drCurrentRow["SHIPMENT_TYPE"] = "20 Feet";
                    drCurrentRow["SHIPMENT_TYPE"] = ddlShipment_type.SelectedItem.Text;
                    drCurrentRow["EX_RATE"] = string.Empty;
                    //drCurrentRow["Qty"] = string.Empty;
                    drCurrentRow["Qty"] = "1";
                    drCurrentRow["DEFAULT_UNIT_RATE"] = string.Empty;
                    //drCurrentRow["MIN_AMOUNT"] = string.Empty;
                    drCurrentRow["MIN_AMOUNT"] = "0";
                    drCurrentRow["SPL_CHARGE_RATE"] = "";
                    drCurrentRow["Type"] = "N";
                   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gv_Chg_Details.DataSource = dtCurrentTable; 
                    gv_Chg_Details.DataBind();

                    //gv_Chg_Details_2.DataSource = dtCurrentTable;
                    //gv_Chg_Details_2.DataBind();
                }
                else
                {
                    Alert_msg("Enter the value in Empty Row");
                }
                
                txttax_amt.Text = tax_amt.ToString();
                txtnon_tax_amt.Text = non_tax_amt.ToString();

                txt_tax_amt_1.Text = ((Convert.ToDecimal(txt_leg_Per_1.Text == "" ? "0.00" : txt_leg_Per_1.Text) / Convert.ToDecimal(100.00)) * tax_amt).ToString("#0.00");
                txt_tax_amt_2.Text = ((Convert.ToDecimal(txt_leg_Per_2.Text == "" ? "0.00" : txt_leg_Per_2.Text) / Convert.ToDecimal(100.00)) * Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");
                txt_tax_amt_3.Text = ((Convert.ToDecimal(txt_leg_Per_3.Text == "" ? "0.00" : txt_leg_Per_3.Text) / Convert.ToDecimal(100.00)) * Convert.ToDecimal(txt_tax_amt_1.Text)).ToString("#0.00");
                txt_tax_amt_4.Text = ((Convert.ToDecimal(txt_leg_Per_4.Text == "" ? "0.00" : txt_leg_Per_4.Text) / Convert.ToDecimal(100.00)) * Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");
               // txt_total_tax_amt.Text = (Convert.ToDecimal(txt_tax_amt_1.Text) + Convert.ToDecimal(txt_tax_amt_2.Text) + Convert.ToDecimal(txt_tax_amt_3.Text)).ToString("#0.00");
               // txt_total_amt_With_tax.Text = (Convert.ToDecimal(txt_total_tax_amt.Text) + Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");
                
                txt_total_tax_amt.Text = (Convert.ToDecimal(txt_tax_amt_1.Text) + Convert.ToDecimal(txt_tax_amt_2.Text) + Convert.ToDecimal(txt_tax_amt_3.Text) + Convert.ToDecimal(txt_tax_amt_4.Text)).ToString("#0.00");
                txt_total_amt_With_tax.Text = (Convert.ToDecimal(txt_total_tax_amt.Text) + Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");
               
            }
        }
        else
        {

        }

        //Set Previous Data on Postbacks
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
                    CheckBox INV_CHECK = (CheckBox)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("chk_inv");

                    TextBox txtcharge_name = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("txtch_name");
                    TextBox txtch_det = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtch_det");
                                     
                    //DropDownList txtshipment_type = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtshiptype");
                    TextBox txtshipment_type = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtshiptype");

                    TextBox txtEx_rate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtEx_rate");
                    TextBox txt_Qty = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtqty");
                    TextBox txtdefault_Unit_Rate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtunit_price");
                    TextBox txt_amt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtamt");

                   // TextBox txtpp_cc = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtpp_CC");
                    DropDownList txtpp_cc = (DropDownList)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtpp_CC");

                    TextBox txt_spltaxRate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txt_spltaxRate");

                   // INV_CHECK.Checked = false;

                    gv_Chg_Details.Rows[i].Cells[1].Text = Convert.ToString(i + 1);

                    txtcharge_name.Text = dt.Rows[i]["CHARGE_NAME"].ToString();
                    txtch_det.Text = dt.Rows[i]["CHARGE_DETAILS"].ToString();

                    txtshipment_type.Text = dt.Rows[i]["SHIPMENT_TYPE"].ToString();
                    txtEx_rate.Text = dt.Rows[i]["EX_RATE"].ToString();
                    txt_Qty.Text = dt.Rows[i]["Qty"].ToString();
                    txtdefault_Unit_Rate.Text = dt.Rows[i]["DEFAULT_UNIT_RATE"].ToString();
                    txt_amt.Text = dt.Rows[i]["MIN_AMOUNT"].ToString();
                    txt_spltaxRate.Text = dt.Rows[i]["SPL_CHARGE_RATE"].ToString();
                    txtpp_cc.Text = dt.Rows[i]["Type"].ToString();

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
        string Date_chk = string.Empty;

        if (COMPANY_LICENSE != "eri00314")
        {
            if (Convert.ToDateTime(txtDate.Text) <= DateTime.Today)
            {
                if (Convert.ToDateTime(HDinv_date.Value) <= Convert.ToDateTime(txtDate.Text))
                {
                    Date_chk = "Yes";
                }
                else
                {
                    Alert_msg("Enter the Correct Invoice date!", "txtDate");
                }
            }
            else
            {
                Alert_msg("Enter the Correct Invoice date!", "txtDate");
            }
        }
        else
        {
            Date_chk = "Yes";
        }

        if (Date_chk == "Yes")
        {

            if (ddltype.SelectedItem.Text == "Job" || ddltype.SelectedItem.Text == "BL")
            {
                Exporter_name = ddlExp_name.SelectedItem.Text;
                J_no = ddljobno.SelectedValue.ToString();
            }
            else if (ddltype.SelectedItem.Text == "Other")
            {
                Exporter_name = txtexporterName.Text;
                J_no = "0";
            }

           /* string Branch_Chk = string.Empty;
            if (SELECT_BRANCH != "")
            {
                Branch_Chk = ddlbranch.SelectedItem.Text;
            }
            else
            {
                Branch_Chk = "test";
            }

            if (Branch_Chk != "")
            {*/


                if (ddlmode.SelectedItem.Text != "")
                {
                    if (Exporter_name != "")
                    {

                        if (txtInvoiceNo.Text != string.Empty)
                        {
                            //}
                            //--------------------------------------------------------------------------------------------------------------------------
                            if (J_no != "0" && ddlmode.SelectedItem.Text == "Air")
                            {
                                if (txtchargeWeight.Text == string.Empty)
                                {
                                    Alert_msg("Enter a Charge Wgt!", "txtchargeWeight");
                                    Ch_type = "1";
                                }
                                if (txtchargeWeightType.Text == string.Empty)
                                {
                                    Alert_msg("Enter a Charge Type!", "txtchargeWeightType");
                                    Ch_type = "1";
                                }
                            }



                            if (Ch_type != "1")
                            {

                                DataTable dtt = new DataTable();
                                DataRow dr;
                                dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("MODE", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("JOB_TYPE", typeof(String)));

                                dtt.Columns.Add(new System.Data.DataColumn("CHARGE_NAME", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("CHARGE_DETAILS", typeof(String)));

                                dtt.Columns.Add(new System.Data.DataColumn("SHIPMENT_TYPE", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("EX_RATE", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("QTY", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("UNIT_RATE", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("AMOUNT", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("SPL_CHARGE_RATE", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("BRANCH_CODE", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("CREATEDBY", typeof(String)));

                                dtt.Columns.Add(new System.Data.DataColumn("INV_CHECK", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("BILL_INV_NO", typeof(String)));
                                dtt.Columns.Add(new System.Data.DataColumn("ROWNUM", typeof(String)));

                                int R = 1;
                                foreach (GridViewRow row in gv_Chg_Details.Rows)
                                {

                                    TextBox txtch_name = (TextBox)row.FindControl("txtch_name");
                                    TextBox txtch_det = (TextBox)row.FindControl("txtch_det");
                                    // DropDownList txtshiptype = (DropDownList)row.FindControl("txtshiptype");
                                    TextBox txtshiptype = (TextBox)row.FindControl("txtshiptype");

                                    TextBox txtEx_rate = (TextBox)row.FindControl("txtEx_rate");
                                    TextBox txtqty = (TextBox)row.FindControl("txtqty");
                                    TextBox txtunit_price = (TextBox)row.FindControl("txtunit_price");
                                    TextBox txtamt = (TextBox)row.FindControl("txtamt");
                                    TextBox txt_spltaxRate = (TextBox)row.FindControl("txt_spltaxRate");
                                    DropDownList txtpp_CC = (DropDownList)row.FindControl("txtpp_CC");

                                    CheckBox INV_CHECK = (CheckBox)row.FindControl("chk_inv");


                                    if (txtch_name.Text == string.Empty && txtch_det.Text == string.Empty && txtEx_rate.Text == string.Empty && txtqty.Text == string.Empty && txtunit_price.Text == string.Empty && txtamt.Text == string.Empty)
                                    {

                                    }
                                    else
                                    {
                                        dr = dtt.NewRow();
                                        dr[0] = J_no;
                                        dr[1] = ddlmode.SelectedItem.Text;
                                        dr[2] = "Jobwise";
                                        dr[3] = txtch_name.Text;
                                        dr[4] = txtch_det.Text;

                                        dr[5] = txtshiptype.Text;
                                        dr[6] = txtEx_rate.Text;
                                        dr[7] = txtqty.Text;
                                        dr[8] = txtunit_price.Text;
                                        dr[9] = txtamt.Text;
                                        dr[10] = txt_spltaxRate.Text;

                                        dr[11] = txtpp_CC.Text;
                                        dr[12] = currentbranch;
                                        dr[13] = Working_Period;
                                        dr[14] = currentuser;
                                        dr[15] = INV_CHECK.Checked == true ? "True" : "False";
                                        dr[16] = txtInvoiceNo.Text;
                                        dr[17] = R;

                                        dtt.Rows.Add(dr);
                                        R = R + 1;
                                    }
                                }

                                DataSet dsData = new DataSet();
                                dsData.Tables.Add(dtt);

                                String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

                                Billing_Invoice_Jobno_Insert_Update("S", xmlData, Exporter_name, J_no);
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

                                    btnrpt.Visible = true;
                                    btn_T_rpt.Visible = true;
                                    btn_T_N_rpt.Visible = true;
                                    From_Quotation.Enabled = false;

                                    HD_Bill_Jobno.Value = txtInvoiceNo.Text;

                                    ddlExp_name.Attributes.Add("readonly", "readonly");
                                    ddlExp_name.Style.Add("background-color", "#F0F0F0");

                                    ddljobno.Attributes.Add("readonly", "readonly");
                                    ddljobno.Style.Add("background-color", "#F0F0F0");

                                    ddlmode.Enabled = false;
                                    ddlExp_name.Enabled = false;
                                    ddljobno.Enabled = false;
                                    //ddlbranch.Enabled = false;

                                    ddltype.Enabled = false;
                                    F.Visible = false;
                                    T.Visible = true;

                                    WK.Visible = false;

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
                            //--------------------------------------------------------------------------------------------------------------------------
                        }
                        else
                        {
                            Alert_msg("Invalid Invoice Number !", "txtInvoiceNo");
                        }

                    }
                    else
                    {

                        if (ddltype.SelectedItem.Text == "Job")
                        {
                            Alert_msg("Select Exporter Name!", "ddlExp_name");
                        }
                        else if (ddltype.SelectedItem.Text == "Other")
                        {
                            Alert_msg("Enter a Exporter Name!", "txtexporterName");
                        }
                    }
                }
                else
                {
                    Alert_msg("Select Mode!", "ddlmode");
                }

                //-------------------------------------------------------------------------------------
         /*   }
            else
            {
                Alert_msg("Select Branch!", "ddlbranch");
            } */

        }
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
                  if (COMPANY_LICENSE != "eri00247")
                  {
                      if (ddljobno.SelectedValue.ToString() != "0" && ddlmode.SelectedItem.Text == "Air")
                      {
                          if (txtchargeWeight.Text == string.Empty)
                          {
                              Alert_msg("Enter a Charge Wgt!", "txtchargeWeight");
                              Ch_type = "1";
                          }
                          if (txtchargeWeightType.Text == string.Empty)
                          {
                              Alert_msg("Enter a Charge Type!", "txtchargeWeightType");
                              Ch_type = "1";
                          }
                      }
                  }

                     if (Ch_type != "1")
                     {
                         DataTable dtt = new DataTable();
                         DataRow dr;
                         dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("MODE", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("JOB_TYPE", typeof(String)));

                         dtt.Columns.Add(new System.Data.DataColumn("CHARGE_NAME", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("CHARGE_DETAILS", typeof(String)));

                         dtt.Columns.Add(new System.Data.DataColumn("SHIPMENT_TYPE", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("EX_RATE", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("QTY", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("UNIT_RATE", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("AMOUNT", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("SPL_CHARGE_RATE", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("BRANCH_CODE", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("CREATEDBY", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("INV_CHECK", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("BILL_INV_NO", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("ROWNUM", typeof(String)));

                         int N = 1;
                         foreach (GridViewRow row in gv_Chg_Details.Rows)
                         {

                             TextBox txtch_name = (TextBox)row.FindControl("txtch_name");
                             TextBox txtch_det = (TextBox)row.FindControl("txtch_det");
                             TextBox txtshiptype = (TextBox)row.FindControl("txtshiptype");
                             TextBox txtEx_rate = (TextBox)row.FindControl("txtEx_rate");
                             TextBox txtqty = (TextBox)row.FindControl("txtqty");
                             TextBox txtunit_price = (TextBox)row.FindControl("txtunit_price");
                             TextBox txtamt = (TextBox)row.FindControl("txtamt");
                             TextBox txt_spltaxRate = (TextBox)row.FindControl("txt_spltaxRate");
                             DropDownList txtpp_CC = (DropDownList)row.FindControl("txtpp_CC");

                             CheckBox INV_CHECK = (CheckBox)row.FindControl("chk_inv");

                             if (txtch_name.Text == string.Empty && txtch_det.Text == string.Empty && txtEx_rate.Text == string.Empty && txtqty.Text == string.Empty && txtunit_price.Text == string.Empty && txtamt.Text == string.Empty)
                             {

                             }
                             else
                             {
                                 dr = dtt.NewRow();

                                 // dr[0] = ddljobno.SelectedItem.Text;
                                 dr[0] = ddljobno.SelectedValue.ToString();
                                 dr[1] = ddlmode.SelectedItem.Text;
                                 dr[2] = "Jobwise";
                                 dr[3] = txtch_name.Text;
                                 dr[4] = txtch_det.Text;

                                 dr[5] = txtshiptype.Text;
                                 dr[6] = txtEx_rate.Text;
                                 dr[7] = txtqty.Text;
                                 dr[8] = txtunit_price.Text;
                                 dr[9] = txtamt.Text;
                                 dr[10] = txt_spltaxRate.Text;
                                 dr[11] = txtpp_CC.Text;
                                 dr[12] = currentbranch;
                                 dr[13] = Working_Period;
                                 dr[14] = currentuser;
                                 dr[15] = INV_CHECK.Checked == true ? "True" : "False";
                                 dr[16] = txtInvoiceNo.Text;
                                 dr[17] = N;
                                 dtt.Rows.Add(dr);
                                 N = N + 1;
                             }
                         }

                         DataSet dsData = new DataSet();
                         dsData.Tables.Add(dtt);

                         // Get the XML format of the data set.
                         String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

                         i = Billing_Invoice_Jobno_Insert_Update("U", xmlData, ddlExp_name.SelectedItem.Text, ddljobno.SelectedValue.ToString());
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

              BI.ID = HDupdate_id.Value.ToString();
              BI.JOBNO = ddljobno.SelectedValue.ToString();
              BI.EXPORTER_NAME = ddlExp_name.SelectedItem.Text;
              BI.MODE = ddlmode.SelectedItem.Text;
              BI.BRANCH_CODE=SELECT_BRANCH;

              BI.BILL_INV_NO = txtInvoiceNo.Text;
              BI.FILE_REF_NO = ddljobno.SelectedItem.Text;
              BI.USERID = currentuser;
              BI.Shipment_Type = ddlShipment_type.Text;
              BI.Flag = "D";
              BI.Exp_Billing_Invoice_INS_UPD();

              i = BI.result;

              if (i == 1)
              {
                 if (COMPANY_LICENSE == "eri00314")
                  {
                      WK.Visible = true;
                      LoadFinancialYear();
                      ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();
                  }

                  btnNew_Click1(sender, e);
                  Alert_msg("Deleted");
                  btnrpt.Visible = false;
                  btn_T_rpt .Visible = false;
                  btn_T_N_rpt.Visible = false;
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

    public int Billing_Invoice_Jobno_Insert_Update(string S1 ,String xmlData_D ,string Expname,string jono)
    {
         BI.ID = HDupdate_id.Value.ToString();
         BI.JOBNO = jono;
         BI.EXPORTER_NAME = Expname;
         
         BI.MODE=ddlmode.SelectedItem.Text;

         BI.BILL_INV_NO = txtInvoiceNo.Text;
         BI.BILL_INV_DATE = txtDate.Text;

        // BI.AC_MAINTAINING_BRANCH=ddlbranch.SelectedItem.Text;
         BI.AC_MAINTAINING_BRANCH = string.Empty;

         BI.INV_NO = txtjob_invno.Text;
         BI.INV_DATE = txtJob_inv_Date.Text;

         BI.SB_NO=txtsbno.Text;
         BI.SB_DATE=txtsbdate.Text;
         BI.MAWB_NO=txtmawbno.Text;
         BI.HAWB_NO=txthawbno.Text;
         BI.CONTAINER_NO=txtconatiner_no.Text;
         BI.NO_OF_PKG=txtno_of_pkg.Text;
         BI.GROSS_WGT=txtgross_wgt.Text;
         BI.NET_WGT=txtnetwgt.Text;
         BI.VOLUME=txtvolume.Text;
         BI.VESSEL=txtvessel.Text;
         BI.DESTINATION=txtdestination.Text;
         BI.COMMODITY=txtcommodity.Text;
         BI.FREIGHT_STATUS=ddl_freight_status.SelectedItem.Text;
         BI.AC_BEHALF=ch_Behalf.Checked == true ? "Y" : "N";
         BI.SHIPPER_NAME=txtshippername.Text;
         BI.SHIPPER_ADDRESS=txtShip_Add1.Text;
         BI.CONSIGNEE_NAME=txtconsigneename.Text;
         BI.CONSIGNEE_ADDRESS=txtCon_Add1.Text;

         BI.NOTIFY_PARTY_1= txt_notify_party_1.Text;
         BI.NOTIFY_PARTY_1_ADDRESS=txt_notify_party_1_add.Text;
         BI.NOTIFY_PARTY_2=txt_notify_party_2.Text;
         BI.NOTIFY_PARTY_2_ADDRESS=txt_notify_party_2_add.Text;
         BI.REMARKS=txt_Remarks.Text;
         BI.NON_TAXABLE_AMT=txtnon_tax_amt.Text;
         BI.TAXABLE_AMT=txttax_amt.Text;
         BI.TAX_LEDGER_1=txt_tax_leg_1.Text;
         BI.LEDGER_1_TAX=txt_leg_Per_1.Text;
         BI.LEDGER_1_TAX_AMT=txt_tax_amt_1.Text;

         BI.TAX_LEDGER_2=txt_tax_leg_2.Text;
         BI.LEDGER_2_TAX=txt_leg_Per_2.Text;
         BI.LEDGER_2_TAX_AMT=txt_tax_amt_2.Text;
         BI.TAX_LEDGER_3=txt_tax_leg_3.Text;
         BI.LEDGER_3_TAX=txt_leg_Per_3.Text;
         BI.LEDGER_3_TAX_AMT=txt_tax_amt_3.Text;
         // 01-june-2016 k
         BI.TAX_LEDGER_4 = txt_tax_leg_4.Text;
         BI.LEDGER_4_TAX = txt_leg_Per_4.Text;
         BI.LEDGER_4_TAX_AMT = txt_tax_amt_4.Text;

         BI.TOTAL_TAX_AMT=txt_total_tax_amt.Text;
         BI.TOTAL_AMT_TAX=txt_total_amt_With_tax.Text;
         BI.DESCRIPTION=txt_tax_desc.Text;
         BI.BRANCH_CODE=SELECT_BRANCH;
        
         BI.CHARGE_WGT = txtchargeWeight.Text;
         BI.CHARGE_TYPE =txtchargeWeightType.Text;
         BI.JOB_DATE = txtJob_Date.Text;
         BI.Inv_Type = ddltype.SelectedValue.ToString();

         BI.WORKINGPERIOD=Working_Period;
         BI.USERID=currentuser;
         BI.Branch=currentbranch;
         BI.Flag=S1;

         if (ddltype.SelectedValue.ToString() == "Other")
         {
             BI.FILE_REF_NO = "0";
         }
         else
         {
             BI.FILE_REF_NO = ddljobno.SelectedItem.Text;
         }
         BI.Xml_D = xmlData_D;
         BI.EXP_BRANCH_SLNO = hd_EXP_Brslno.Value;
         BI.NOTIFY_PARTY_1_BR_SLNO = hd_EXP_br_sl_no.Value;
         BI.BILL_STATUS = ddl_Bill_status.SelectedValue.ToString();
         BI.Shipment_Type = ddlShipment_type.SelectedItem.Text;
         chk = From_Quotation.Checked;
         BI.FROM_QUOTATION = chk.ToString();
         BI.ADVANCE_AMT = txt_Adv_amt.Text;
         BI.Branch_No = ddl_loc.SelectedValue.ToString();
         BI.FOB_Value = txt_FOB_Value.Text;
        
         BI.Exp_Billing_Invoice_INS_UPD();
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
        txtJob_inv_Date.Text = string.Empty;

        txtInvoiceNo.Text = string.Empty;
        txtJob_inv_Date.Text = string.Empty;
        txtsbno.Text = string.Empty;
        txtsbdate.Text = string.Empty;
        txtmawbno.Text = string.Empty;
        txthawbno.Text = string.Empty;
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
        txtshippername.Text = string.Empty;
        txtShip_Add1.Text = string.Empty;
        txtconsigneename.Text = string.Empty;
        txtCon_Add1.Text = string.Empty;

        txt_notify_party_1.Text = string.Empty;
        txt_notify_party_1_add.Text = string.Empty;
        txt_notify_party_2.Text = string.Empty;
        txt_notify_party_2_add.Text = string.Empty;
        txt_Remarks.Text = string.Empty;
        txtnon_tax_amt.Text = string.Empty;
        txttax_amt.Text = string.Empty;

        txt_tax_leg_1.Text = string.Empty;
        txt_leg_Per_1.Text = string.Empty;
        txt_tax_amt_1.Text = string.Empty;

        txt_tax_leg_2.Text = string.Empty;
        txt_leg_Per_2.Text = string.Empty;
        txt_tax_amt_2.Text = string.Empty;
        txt_tax_leg_3.Text = string.Empty;
        txt_leg_Per_3.Text = string.Empty;
        txt_tax_amt_3.Text = string.Empty;

        txt_tax_leg_4.Text = string.Empty;
        txt_leg_Per_4.Text = string.Empty;
        txt_tax_amt_4.Text = string.Empty;

        txt_total_tax_amt.Text = string.Empty;
        txt_total_amt_With_tax.Text = string.Empty;
        txt_tax_desc.Text = string.Empty;
        txtJob_Date.Text = string.Empty;

        hd_EXP_Brslno.Value = string.Empty;
        hd_EXP_br_sl_no.Value = string.Empty;
        txt_FOB_Value.Text = string.Empty;
    }
    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "Type").ToString() == "T")
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#F0F0F0");
            }
            else
            {
                e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#C0C0C0");
            }
           
            TextBox txtamt = (e.Row.FindControl("txtamt") as TextBox);
            txtamt.Attributes.Add("readonly", "readonly");
        }
       
    }
  /*  protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlbranch.SelectedItem.Text !="")
        {
          load_Exp_name();
        }
        else
        {
            ddl_clear();
        }
    } */
    private void load_Exp_name()
    {
        DataSet dss = new DataSet();
        BI.Mode=ddlmode.SelectedItem.Text;
        //BI.Branch = ddlbranch.SelectedItem.Text;
        BI.Inv_Type = ddltype.SelectedItem.Text;
        BI.Mflag = "Exp_Name_Select";
        BI.Branch_Type = SELECT_BRANCH;
        
        if (COMPANY_LICENSE == "eri00314")
        {
            DataSet ds = new DataSet();
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
                dss = BI.Select_Exp_INV(table1.Rows[0]["SERVER_NAME"].ToString());
            }
        }
        else
        {
            dss = BI.Select_Exp_INV();
        }

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = dss.Tables[0];
            ddlExp_name.DataTextField = "Exp_Name";
            ddlExp_name.DataValueField = "Exp_Name";
            ddlExp_name.DataBind();
            ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlExp_name.SelectedIndex = 0;
        }
        else
        {
            ddl_clear();
        }

    }
    private void load_Jobno()
    {
        DataSet dss = new DataSet();
        BI.Mode = ddlmode.SelectedItem.Text;
       // BI.Branch = ddlbranch.SelectedItem.Text;
        BI.Exp_Name = ddlExp_name.SelectedItem.Text;
        BI.Branch_Type=SELECT_BRANCH;
        BI.Inv_Type = ddltype.SelectedItem.Text;
        BI.Mflag = "Exp_Job_Select";

        if (COMPANY_LICENSE == "eri00314")
        {
            DataSet ds = new DataSet();
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
                dss = BI.Select_Exp_INV(table1.Rows[0]["SERVER_NAME"].ToString());
            }
        }
        else
        {
            dss = BI.Select_Exp_INV();
        }
        //-----------end---------------------

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = dss.Tables[0];

            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010")
            {
                ddljobno.DataTextField = "JOBNO_PS";
            }
            if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00352" )
            {
                ddljobno.DataTextField = "JOBNO";
            }
            else
            {
                ddljobno.DataTextField = "FILE_REF_NO";
            }
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
        }

        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;
    }
    protected void ddlmode_SelectedIndexChanged(object sender, EventArgs e)
    {

        if(ddltype.SelectedItem.Text=="Job")
        {
          load_Exp_name();
        }
        else if (ddltype.SelectedItem.Text == "Other")
        {
          Other_Inv_load();
        }
       Jobno_clear();

        if(ddlmode.SelectedItem.Text=="Air")
        {
            lblA_S_1.Text = "MAWB No:";
            lblA_S_2.Text = "HAWB No:";
        }
        else if (ddlmode.SelectedItem.Text == "Sea")
        {
            lblA_S_1.Text = "MBL No";
            lblA_S_2.Text = "HBL No";
        }
        else if (ddlmode.SelectedItem.Text == "Land")
        {
            lblA_S_1.Text = "";
            lblA_S_2.Text = "";
        }

        Shipment_Type();





    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (SELECT_BRANCH != "")
        {

            //if (ddlbranch.SelectedItem.Text != ""){
                if (ddlExp_name.SelectedItem.Text != "")
                {
                    Load_Client_Loction();
                    load_Jobno();
                    cl();
                }
                else
                {
                    cl();
                    Jobno_clear();
                }
           /* }
            else
            {
                Clear();
                Jobno_clear();
            }*/
        }
        else
        {
                if (ddlExp_name.SelectedItem.Text != "")
                {
                    Load_Client_Loction();
                    load_Jobno();
                    cl();
                }
                else
                {
                    cl();
                    Jobno_clear();
                }
           
        }
    }
    private void ddl_clear()
    {
        ddlExp_name.Items.Clear();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;

        ddljobno.Items.Clear();
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;

        ddl_loc.Items.Clear();
        ddl_loc.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_loc.SelectedIndex = 0;
    }
    private void Jobno_clear()
    {
        ddljobno.Items.Clear();
        ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddljobno.SelectedIndex = 0;

        ddl_loc.Items.Clear();
        ddl_loc.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_loc.SelectedIndex = 0;
    }
    private void Load_Client_Loction()
    {
        ddl_loc.Items.Clear();
        DataSet dss = new DataSet();
        BI.Mode = ddlmode.SelectedItem.Text;
        BI.Branch_Type = SELECT_BRANCH;
        BI.Exp_Name = ddlExp_name.SelectedItem.Text;
        BI.Mflag = "Exp_Client_Location";
        dss = BI.Select_Exp_INV();
        if (dss.Tables[0].Rows.Count > 1)
        {
            ddl_loc.DataSource = dss.Tables[0];
            ddl_loc.DataTextField = "ADDRESS3";
            ddl_loc.DataValueField = "BRANCH_NO";
            ddl_loc.DataBind();

            ddl_loc.Items.Insert(0, new ListItem("All.Loc.Same Add", "500"));
            ddl_loc.SelectedIndex = 0;
        }
        else if (dss.Tables[0].Rows.Count == 1)
        {
            ddl_loc.DataSource = dss.Tables[0];
            ddl_loc.DataTextField = "ADDRESS3";
            ddl_loc.DataValueField = "BRANCH_NO";
            ddl_loc.DataBind();

            ddl_loc.Items.Insert(0, new ListItem("All.Loc.Same Add", "500"));
            ddl_loc.SelectedIndex = 0;
        }
        else
        {
            ddl_loc.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            ddl_loc.SelectedIndex = 0;
        }
    }  

    protected void ddljobno_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddljobno.SelectedItem.Text != "")
        {
            txt_tax_leg_1.Text = "Service Tax Payable";
            txt_tax_leg_2.Text = "Swachh Bharat Cess";
            txt_tax_leg_3.Text = "Sec.Edu Cess Payable";
            txt_tax_leg_4.Text = "Krishi Kalyan Cess";

            txt_leg_Per_1.Text = "14.00";
            txt_leg_Per_2.Text = "0.50";
            txt_leg_Per_3.Text = "0.00";
            txt_leg_Per_4.Text = "0.50";

            DataSet dss = new DataSet();
            BI.Mode = ddlmode.SelectedItem.Text;
            //BI.Branch = ddlbranch.SelectedItem.Text;
            BI.Exp_Name = ddlExp_name.SelectedItem.Text;
            BI.JOBNO = ddljobno.SelectedValue.ToString();
            BI.Mflag = "Exp_Job_Grid";
            BI.Branch_Type = SELECT_BRANCH;
            BI.Inv_Type = ddltype.SelectedValue.ToString();
            BI.Shipment_Type = ddlShipment_type.SelectedItem.Text;
            chk = From_Quotation.Checked;
            BI.FROM_QUOTATION = chk.ToString();
            BI.COMPANY_LICENSE = Session["COMPANY_LICENSE"].ToString();
            //dss = BI.Select_Exp_INV();
            //--------------------------------------------------Start------------------------------------------------

            if (COMPANY_LICENSE == "eri00314")
            {
                DataSet ds = new DataSet();
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
                    dss = BI.Select_Exp_INV(table1.Rows[0]["SERVER_NAME"].ToString());
                }
            }
            else
            {
                dss = BI.Select_Exp_INV();
            }

            //----------------------------------------------------End-------------------------------------------

            if (dss.Tables[0].Rows.Count > 0)
            {
                gv_Chg_Details.DataSource = dss.Tables[0];
                gv_Chg_Details.DataBind();

                gv_Chg_Details_2.DataSource = dss.Tables[0];
                gv_Chg_Details_2.DataBind();

                Tax_amt_calc();
                ViewState["CurrentTable"] = dss.Tables[0];
            }
            else
            {
                SetInitialRow();
            }

            if (dss.Tables[1].Rows.Count > 0)
            {
                txtsbno.Text = dss.Tables[1].Rows[0]["SB_NO"].ToString();
                txtsbdate.Text = dss.Tables[1].Rows[0]["SB_DATE"].ToString();
            }

            if (dss.Tables[2].Rows.Count > 0)
            {
                txtmawbno.Text = dss.Tables[2].Rows[0]["MAWB_NO"].ToString();
                txthawbno.Text = dss.Tables[2].Rows[0]["HAWB_NO"].ToString();
                txtno_of_pkg.Text = dss.Tables[2].Rows[0]["Tot_pkg"].ToString();
                txtgross_wgt.Text = dss.Tables[2].Rows[0]["Gross_wgt"].ToString();
                txtnetwgt.Text = dss.Tables[2].Rows[0]["Net_wgt"].ToString();
            }

            if (dss.Tables[3].Rows.Count > 0)
            {
                txtconatiner_no.Text = dss.Tables[3].Rows[0]["CONTAINERNO"].ToString();
            }
            if (dss.Tables[4].Rows.Count > 0)
            {
                txtjob_invno.Text = dss.Tables[4].Rows[0]["INVOICE_NO"].ToString();
                txtJob_inv_Date.Text = dss.Tables[4].Rows[0]["INVOICE_DATE"].ToString();
            }

            if (dss.Tables[5].Rows.Count > 0)
            {
                txtdestination.Text = dss.Tables[5].Rows[0]["COUNTRY_FINAL_DEST"].ToString();

                txtshippername.Text = dss.Tables[5].Rows[0]["EXPORTER_NAME"].ToString();
                txtShip_Add1.Text = dss.Tables[5].Rows[0]["Exp_Address"].ToString();
                txtconsigneename.Text = dss.Tables[5].Rows[0]["CONSIGNEE_NAME"].ToString();
                txtCon_Add1.Text = dss.Tables[5].Rows[0]["Con_Address"].ToString();

                txtJob_Date.Text = dss.Tables[5].Rows[0]["JOBDATE"].ToString();

                if (ddltype.SelectedValue.ToString() == "BL")
                {
                    txt_notify_party_1.Text = dss.Tables[5].Rows[0]["Notify1"].ToString();
                    txt_notify_party_1_add.Text = dss.Tables[5].Rows[0]["Notify1_Address"].ToString();

                    txt_notify_party_2.Text = dss.Tables[5].Rows[0]["Notify2"].ToString();
                    txt_notify_party_2_add.Text = dss.Tables[5].Rows[0]["Notify2_Address"].ToString();
                    txtvessel.Text = dss.Tables[5].Rows[0]["OCEAN_VESSEL"].ToString();
                    txtvolume.Text = dss.Tables[5].Rows[0]["TOTALVOLUME"].ToString();
                }

            }
            if (dss.Tables[6].Rows.Count > 0)
            {
            }
            if (dss.Tables[7].Rows.Count > 0)
            {
                txtInvoiceNo.Text = dss.Tables[7].Rows[0]["Autoid"].ToString();
            }
            if (dss.Tables[8].Rows.Count > 0)
            {
                txt_FOB_Value.Text = dss.Tables[8].Rows[0]["FOB_VALUE"].ToString();
            }
        }
        else
        {
            cl();

        }

    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

        dt.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("CHARGE_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("CHARGE_DETAILS", typeof(string)));
        dt.Columns.Add(new DataColumn("SHIPMENT_TYPE", typeof(string)));
        dt.Columns.Add(new DataColumn("EX_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("Qty", typeof(string)));
        dt.Columns.Add(new DataColumn("DEFAULT_UNIT_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("MIN_AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("SPL_CHARGE_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("Type", typeof(string)));

        dr = dt.NewRow();
        dr["INV_CHECK"] = "True"; 

        dr["RowNumber"] = 1;
        dr["CHARGE_NAME"] = string.Empty;
        dr["CHARGE_DETAILS"] = string.Empty;
        dr["SHIPMENT_TYPE"] = ddlShipment_type.Text;
        dr["EX_RATE"] = string.Empty;
        dr["Qty"] = "1";
        dr["DEFAULT_UNIT_RATE"] = string.Empty;
        dr["MIN_AMOUNT"] = "0";
        dr["SPL_CHARGE_RATE"] = "";
        dr["Type"] = "N";

        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();

        txttax_amt.Text = "0.00";
        txtnon_tax_amt.Text = "0.00";

        txt_tax_amt_1.Text = "0.00";
        txt_tax_amt_2.Text = "0.00";
        txt_tax_amt_3.Text = "0.00";
        txt_tax_amt_4.Text = "0.00";

        txt_total_tax_amt.Text = "0.00";
        txt_total_amt_With_tax.Text = "0.00";

    }
    
   protected void gv_Chg_Details_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
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
                dtnew.Columns.Add(new DataColumn("CHARGE_NAME", typeof(string)));
                dtnew.Columns.Add(new DataColumn("CHARGE_DETAILS", typeof(string)));

                dtnew.Columns.Add(new DataColumn("SHIPMENT_TYPE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("EX_RATE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("Qty", typeof(string)));
                dtnew.Columns.Add(new DataColumn("DEFAULT_UNIT_RATE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("MIN_AMOUNT", typeof(string)));
                dtnew.Columns.Add(new DataColumn("SPL_CHARGE_RATE", typeof(string)));
                dtnew.Columns.Add(new DataColumn("Type", typeof(string)));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    drnew = dtnew.NewRow();
                    drnew["INV_CHECK"] = dt.Rows[i][0].ToString();
                    drnew["RowNumber"] = i + 1;
                    drnew["CHARGE_NAME"] = dt.Rows[i][2].ToString();
                    drnew["CHARGE_DETAILS"] = dt.Rows[i][3].ToString();
                    drnew["SHIPMENT_TYPE"] = dt.Rows[i][4].ToString();
                    drnew["EX_RATE"] = dt.Rows[i][5].ToString();
                    drnew["Qty"] = dt.Rows[i][6].ToString();
                    drnew["DEFAULT_UNIT_RATE"] = dt.Rows[i][7].ToString();
                    drnew["MIN_AMOUNT"] = dt.Rows[i][8].ToString();
                    drnew["SPL_CHARGE_RATE"] = dt.Rows[i][9].ToString();
                    drnew["Type"] = dt.Rows[i][10].ToString();
                   

                    dtnew.Rows.Add(drnew);

                    if (dt.Rows[i][0].ToString() == "True" && dt.Rows[i][10].ToString() == "T")
                    {
                        //tax_amt = tax_amt + Convert.ToDecimal(dt.Rows[i][8].ToString() == "" ? "0.00" : dt.Rows[i][8].ToString());

                        if (dt.Rows[i][9].ToString() != string.Empty && dt.Rows[i][9].ToString() != "0.00")
                        {
                            tax_amt += (Convert.ToDecimal(dt.Rows[i][8].ToString() == "" ? "0.00" : dt.Rows[i][8].ToString()) * Convert.ToDecimal(dt.Rows[i][9].ToString() == "" ? "0.00" : dt.Rows[i][9].ToString())) / 100;
                        }
                        else
                        {
                            tax_amt += Convert.ToDecimal(dt.Rows[i][8].ToString() == "" ? "0.00" : dt.Rows[i][8].ToString());
                        }
                    }
                    else if (dt.Rows[i][0].ToString() == "n" || dt.Rows[i][10].ToString() == "N")
                    {
                        non_tax_amt = non_tax_amt + Convert.ToDecimal(dt.Rows[i][8].ToString() == "" ? "0.00" : dt.Rows[i][8].ToString());
                    }
                }

                //---------------------------------------------------------------------------------------
                gv_Chg_Details.DataSource = dtnew;
                gv_Chg_Details.DataBind();

               /* gv_Chg_Details_2.DataSource = dtnew;
                gv_Chg_Details_2.DataBind();*/

                txttax_amt.Text = tax_amt.ToString();
                txtnon_tax_amt.Text = non_tax_amt.ToString();

                txt_tax_amt_1.Text = ((Convert.ToDecimal(txt_leg_Per_1.Text == "" ? "0.00" : txt_leg_Per_1.Text) / Convert.ToDecimal(100.00)) * tax_amt).ToString("#0.00");
                txt_tax_amt_2.Text = ((Convert.ToDecimal(txt_leg_Per_2.Text == "" ? "0.00" : txt_leg_Per_2.Text) / Convert.ToDecimal(100.00)) * Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");
                txt_tax_amt_3.Text = ((Convert.ToDecimal(txt_leg_Per_3.Text == "" ? "0.00" : txt_leg_Per_3.Text) / Convert.ToDecimal(100.00)) * Convert.ToDecimal(txt_tax_amt_2.Text)).ToString("#0.00");
                
                txt_tax_amt_4.Text = ((Convert.ToDecimal(txt_leg_Per_4.Text == "" ? "0.00" : txt_leg_Per_4.Text) / Convert.ToDecimal(100.00)) * Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");

                txt_total_tax_amt.Text = (Convert.ToDecimal(txt_tax_amt_1.Text) + Convert.ToDecimal(txt_tax_amt_2.Text) + Convert.ToDecimal(txt_tax_amt_3.Text) + Convert.ToDecimal(txt_tax_amt_4.Text)).ToString("#0.00");
                txt_total_amt_With_tax.Text = (Convert.ToDecimal(txt_total_tax_amt.Text) + Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");


                //txt_total_tax_amt.Text = (Convert.ToDecimal(txt_tax_amt_1.Text) + Convert.ToDecimal(txt_tax_amt_2.Text) + Convert.ToDecimal(txt_tax_amt_3.Text)).ToString("#0.00");
                //txt_total_amt_With_tax.Text = (Convert.ToDecimal(txt_total_tax_amt.Text) + Convert.ToDecimal(txttax_amt.Text)).ToString("#0.00");

            }
            else if (dt.Rows.Count == 1)
            {

                DataTable dtt = new DataTable();
                DataRow drr = null;

                dtt.Columns.Add(new DataColumn("INV_CHECK", typeof(string)));

                dtt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dtt.Columns.Add(new DataColumn("CHARGE_NAME", typeof(string)));
                dtt.Columns.Add(new DataColumn("CHARGE_DETAILS", typeof(string)));

                dtt.Columns.Add(new DataColumn("SHIPMENT_TYPE", typeof(string)));
                dtt.Columns.Add(new DataColumn("EX_RATE", typeof(string)));
                dtt.Columns.Add(new DataColumn("Qty", typeof(string)));
                dtt.Columns.Add(new DataColumn("DEFAULT_UNIT_RATE", typeof(string)));
                dtt.Columns.Add(new DataColumn("MIN_AMOUNT", typeof(string)));
                dtt.Columns.Add(new DataColumn("SPL_CHARGE_RATE", typeof(string)));
                dtt.Columns.Add(new DataColumn("Type", typeof(string)));


                drr = dtt.NewRow();
                drr["INV_CHECK"] = "True";
                drr["RowNumber"] = 1;
                drr["CHARGE_NAME"] = string.Empty;
                drr["CHARGE_DETAILS"] = string.Empty;
                drr["SHIPMENT_TYPE"] = ddlShipment_type.SelectedItem.Text;
                drr["EX_RATE"] = string.Empty;
                drr["Qty"] = "1";
                drr["DEFAULT_UNIT_RATE"] = string.Empty;
                drr["MIN_AMOUNT"] = "0";
                drr["SPL_CHARGE_RATE"] = "";
                drr["Type"] = "N";

                dtt.Rows.Add(drr);

                //Store the DataTable in ViewState
                ViewState["CurrentTable"] = dtt;

                gv_Chg_Details.DataSource = dtt;
                gv_Chg_Details.DataBind();
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

        ddlmode.Enabled = true;
        ddlExp_name.Enabled = true;
        ddljobno.Enabled = true;
        //ddlbranch.Enabled = true;
        btnrpt.Visible = false;
        btn_T_rpt.Visible = false;
        btn_T_N_rpt.Visible = false;
        From_Quotation.Enabled = true;
        From_Quotation.Checked = true;
        ddl_loc.Enabled = true;

        ddl_clear();
        div_From_Quot.Visible = true;
        div_loc.Visible = true;
        
        ddltype.Items.Clear();
        ddltype.Items.Insert(0, new ListItem("Job", "Job"));
        ddltype.SelectedIndex = 0;
        ddltype.Items.Insert(1, new ListItem("Other", "Other"));
        ddltype.SelectedIndex = 1;

        ddltype.SelectedIndex = -1;
        
        div_type.Visible = true;
        ddltype.Enabled = true;

        if (COMPANY_LICENSE == "eri00314")
        {
            LoadFinancialYear();
            WK.Visible = true;
            ddlWorkingPeriod.SelectedValue = Working_Period;
        }
       /* if (SELECT_BRANCH != "")
        {
            ddlbranch.SelectedValue = SELECT_BRANCH;

            if (ddlbranch.SelectedItem.Text != "")
            {
                load_Exp_name();
            }
            else
            {
                ddl_clear();
            }
        }*/

        load_Exp_name();


        ddlmode.Enabled = true;
        ddlExp_name.Enabled = true;
        ddljobno.Enabled = true;
        //ddlbranch.Enabled = true;
        ddltype.Enabled = true;
      
        ddlExp_name.Attributes.Remove("readonly");
        ddlExp_name.Style.Add("background-color", "White");

        ddljobno.Attributes.Remove("readonly");
        ddljobno.Style.Add("background-color", "White");


        txtDate.Attributes.Remove("readonly");
        txtDate.Style.Add("background-color", "white");

        ddltype.Enabled = true;
        ddltype.Style.Add("background-color", "white");

        CalendarExtender1.Enabled = true;
        MaskedEditExtender1.Enabled = true;


        if (COMPANY_LICENSE != "eri00314" || COMPANY_LICENSE != "eri00287")
        {
            txtDate.Attributes.Remove("readonly");
            txtDate.Style.Add("background-color", "white");
        }
        else
        {
            txtInvoiceNo.Attributes.Remove("readonly");
            txtInvoiceNo.Style.Add("background-color", "white");
        }

        DataSet dss = new DataSet();
        BI.Mode = "";
        BI.Branch_Type = SELECT_BRANCH;
        BI.Mflag = "Exp_Bill_Date";
        dss = BI.Select_Exp_INV();
        if (dss.Tables[0].Rows.Count > 0)
        {
            if (COMPANY_LICENSE != "eri00314")
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
        txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

       
    }

    [System.Web.Services.WebMethod]
    public static string GetExporter(string custid, string Branch)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Name_Search = custid;
        //Auto.Jobno = Jobno;
        Auto.Flag = "EXP_BILLING_EXPORTER_NAME_SEARCH";
        Auto.Branch = Branch;

        ds = Auto.Export_Billing_Mastersearch();

        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address = ds.Tables[0].Rows[0]["EXPORTER_ADDRESS"].ToString();
            custid = Address;
        }
        else
        {
            custid = "";
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string GetConsignee(string custid, string Branch)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();

        Auto.Name_Search = custid;
        //Auto.Jobno = Jobno;
        Auto.Flag = "EXP_BILLING_CONSIGNEE_ADD_SEARCH";
        Auto.Branch = Branch;

        ds = Auto.Export_Billing_Mastersearch();

        if (ds.Tables[0].Rows.Count > 0)
        {
            string Address = ds.Tables[0].Rows[0]["CONSIGNEE_ADDRESS"].ToString();
            custid = Address;
        }
        else
        {
            custid = "";
        }

        return custid;
    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedItem.Text == "Job")
        {
            div_type.Visible = true;
            ddlExp_name.Visible = true;
            txtexporterName.Visible =false;

            div_From_Quot.Visible = true;
            div_loc.Visible = true;

            clear_Other_Inv();
            load_Exp_name();
            DataTable dt = new DataTable();

            gv_Chg_Details.DataSource = dt;
            gv_Chg_Details.DataBind();

        }
        else if (ddltype.SelectedItem.Text == "Other")
        {
            div_type.Visible = false;
            ddlExp_name.Visible = false;
            txtexporterName.Visible = true;

            txtexporterName.Text = string.Empty;
            ddljobno.SelectedIndex = -1;
            div_From_Quot.Visible = false;
            div_loc.Visible = false;

            DataTable dt = new DataTable();

            gv_Chg_Details.DataSource = dt;
            gv_Chg_Details.DataBind();

            clear_Other_Inv();
        }
        else if (ddltype.SelectedItem.Text == "BL")
        {
            load_Exp_name();

            div_type.Visible = true;
            ddlExp_name.Visible = true;
            txtexporterName.Visible = false;
            clear_Other_Inv();

            DataTable dt = new DataTable();

            gv_Chg_Details.DataSource = dt;
            gv_Chg_Details.DataBind();
        }
        Jobno_clear();
    }


    protected void txtexporterName_TextChanged(object sender, EventArgs e)
    {
        Other_Inv_load();
    }

    private void Other_Inv_load()
    {
        if (txtexporterName.Text != string.Empty)
        {
            DataSet dss = new DataSet();
            BI.Mflag = "Exp_Other_Invoice_Autoid";
            BI.Branch_Type = SELECT_BRANCH;
            BI.Mode = ddlmode.SelectedItem.Text;
            BI.COMPANY_LICENSE = Session["COMPANY_LICENSE"].ToString();
            dss = BI.Select_Exp_INV();

            if (dss.Tables[0].Rows.Count > 0)
            {
                txtInvoiceNo.Text = dss.Tables[0].Rows[0]["Autoid"].ToString();

                SetInitialRow();

                txt_tax_leg_1.Text = "Service Tax Payable";
                txt_tax_leg_2.Text = "Swachh Bharat Cess";
                txt_tax_leg_3.Text = "Sec.Edu Cess Payable"; 
                txt_tax_leg_4.Text = "Krishi Kalyan Cess";

                txt_leg_Per_1.Text = "14.00";
                txt_leg_Per_2.Text = "0.50";
                txt_leg_Per_3.Text = "0.00";
                txt_leg_Per_4.Text = "0.50";
            }

        }
    
    }

    private void clear_Other_Inv()
    {
        txtjob_invno.Text = string.Empty;
        txtJob_inv_Date.Text = string.Empty;

        txtInvoiceNo.Text = string.Empty;
        txtJob_inv_Date.Text = string.Empty;
        txtsbno.Text = string.Empty;
        txtsbdate.Text = string.Empty;
        txtmawbno.Text = string.Empty;
        txthawbno.Text = string.Empty;
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
        txtshippername.Text = string.Empty;
        txtShip_Add1.Text = string.Empty;
        txtconsigneename.Text = string.Empty;
        txtCon_Add1.Text = string.Empty;

        txt_notify_party_1.Text = string.Empty;
        txt_notify_party_1_add.Text = string.Empty;
        txt_notify_party_2.Text = string.Empty;
        txt_notify_party_2_add.Text = string.Empty;
        txt_Remarks.Text = string.Empty;
        txtnon_tax_amt.Text = string.Empty;
        txttax_amt.Text = string.Empty;
        
        txt_tax_amt_1.Text = string.Empty;
        txt_tax_amt_2.Text = string.Empty;
        txt_tax_amt_3.Text = string.Empty;
        txt_tax_amt_4.Text = string.Empty;

        txt_total_tax_amt.Text = string.Empty;
        txt_total_amt_With_tax.Text = string.Empty;
        txt_tax_desc.Text = string.Empty;
        txt_FOB_Value.Text = string.Empty;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Cha_Type(string ChargeName, string Exp_Name, string Mode)
    {
        DataSet ds = new DataSet();
        try
        {
            string Charge_Modee = string.Empty;
            Billing_Exp_Invoice BII = new Billing_Exp_Invoice();
            BII.Exp_Name = ChargeName;
            BII.Mode = Mode + " Export";
            BII.Branch = Connection.Get_Company_Type(); 
            BII.Mflag = "Exp_Charge_type";
            ds = BII.Select_Exp_INV();

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

 
    protected void ddlShipment_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddljobno.Text != string.Empty)
        {
            ddljobno_SelectedIndexChanged1(sender, e);
        }
    }
    private void Shipment_Type()
    {
        Quotation_Master QM = new Quotation_Master();
        DataSet dss = new DataSet();
        QM.Licence_Id = Session["COMPANY_LICENSE"].ToString();
        if (ddlmode.SelectedItem.Text == "Air")
        {
            QM.MODULE = "AE";
        }
        else if (ddlmode.SelectedItem.Text == "Sea")
        {
            QM.MODULE = "SE";
        }
        else if (ddlmode.SelectedItem.Text == "Land")
        {
            QM.MODULE = "LE";
        }
        QM.BRANCH_CODE = SELECT_BRANCH;

        QM.Ename = "SELECT_SHIPMENT_TYPE";
        dss = QM.Admin_QUOTATION_PRODUCT_LIST();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlShipment_type.DataSource = dss.Tables[0];
            ddlShipment_type.DataTextField = dss.Tables[0].Columns["Shipment_Type"].ToString();
            ddlShipment_type.DataValueField = dss.Tables[0].Columns["Shipment_Type"].ToString();
            ddlShipment_type.DataBind();

            ViewState["Shipment_Type"] = dss.Tables[0];
        }
        else
        {
            ddlShipment_type.Items.Clear();
        }
    }
    protected void From_Quotation_CheckedChanged(object sender, EventArgs e)
    {
        if (ddljobno.Text != "")
        {
            ddljobno_SelectedIndexChanged1(sender, e);
        }
         
    }
    protected void ddl_loc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddljobno.Text != "")
        {
            ddljobno_SelectedIndexChanged1(sender, e);
        }
    }

    private void load_Inv_Type()
    {
        ddltype.Items.Add(new ListItem("Job", "Job"));
        if (Session["COMPANY_LICENSE"].ToString().ToLower() != "eri00247")
        {
            ddltype.Items.Add(new ListItem("BL", "BL"));
        }
        ddltype.Items.Add(new ListItem("Other", "Other"));
    }
    public void LoadFinancialYear()
    {
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
    }
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Exp_name();
        ddlExp_name_SelectedIndexChanged(sender, e);
    }
}
 

            
           