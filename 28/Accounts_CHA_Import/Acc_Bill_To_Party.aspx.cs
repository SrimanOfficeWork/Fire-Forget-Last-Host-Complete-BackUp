using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Import_Acc_Bill_To_Party : ThemeClass
{
    Cha_Accounts Bill = new Cha_Accounts();
    Global_variables ObjUBO = new Global_variables();
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    public string IMPORT_JOBNO = string.Empty, JOBNO_PS = string.Empty, Company_ID = string.Empty,Mode;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            IMPORT_JOBNO = Connection.IMP_Jobno();
            JOBNO_PS = Session["JOBNO_PS"].ToString();
            Session["IMP_EXP"] = "I";
            Mode = (Session["TRANSPORT_MODE"].ToString() == "Air") ? "A" : (Session["TRANSPORT_MODE"].ToString() == "Sea") ? "S" : (Session["TRANSPORT_MODE"].ToString() == "Land") ? "L" : "";
            Company_ID = Connection.COMPANYID();
            if (!Page.IsPostBack)
            {
                ddlBill_party.Focus();
                Insert();
                if (Company_ID == "3196" || Company_ID == "480" )
                {
                    Cha_Accounts Chrg = new Cha_Accounts();
                    ObjUBO.A2 = IMPORT_JOBNO;
                    ObjUBO.A3 = JOBNO_PS;
                    ObjUBO.A10 = "I";
                    ObjUBO.A40 = "Quotaion_Charge";
                    Chrg.CHA_Quotation_Charge_Select(ObjUBO);
                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Insert()
    {
        ddl_Branch.Items.Clear();
        ds = Acc_Bill_To_Part("", "", "Save_Party_Details");
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlBill_party.DataSource = ds.Tables[0];
            ddlBill_party.DataTextField = "PARTY_NAME";
            ddlBill_party.DataValueField = "PARTY_NAME";
            ddlBill_party.DataBind();
        }
        ddlBill_party.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlBill_party.SelectedIndex = 0;

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddl_Branch.DataSource = ds.Tables[1];
            ddl_Branch.DataTextField = "PARTY_BRANCH_NO";
            ddl_Branch.DataValueField = "PARTY_BRANCH_NO";
            ddl_Branch.DataBind();
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            ddlBill_party.SelectedValue = ds.Tables[2].Rows[0]["BILL_PARTY_NAME"].ToString();
            ddl_Branch.SelectedValue = ds.Tables[2].Rows[0]["BRANCH_NO"].ToString();
            txtAddress.Text = ds.Tables[2].Rows[0]["ADDRESS_I"].ToString();
            txtAddress2.Text = ds.Tables[2].Rows[0]["ADDRESS_II"].ToString();
            txtAddress3.Text = ds.Tables[2].Rows[0]["ADDRESS_III"].ToString();
            tXtPincode.Text = ds.Tables[2].Rows[0]["PINCODE"].ToString();
            ddl_state_name.SelectedValue = ds.Tables[2].Rows[0]["STATENAME"].ToString();
            txt_GSTN_Num.Text = ds.Tables[2].Rows[0]["GSTN_ID"].ToString();
            Rd_Job_Status.SelectedValue = ds.Tables[2].Rows[0]["JOB_STATUS"].ToString();
            rblPartyType.SelectedValue = ds.Tables[2].Rows[0]["PARTY_TYPE"].ToString();
            HiddenField1.Value = ds.Tables[2].Rows[0]["BILL_ID"].ToString();

            Session["MOVE_ACCOUNTS"] = ds.Tables[2].Rows[0]["MOVE_TO_ACCOUNTS"].ToString();
            if (Session["MOVE_ACCOUNTS"].ToString() == "0")
            {
                btnUpdate.Enabled = true;
                btnAcc.Text = "Move To Accounts";
                btnAcc.Visible = true;

                btnSave.Visible = false;
                btnUpdate.Visible = true;
                rblPartyType.Enabled = true;
            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                rblPartyType.Enabled = false;
                if (ds.Tables[2].Rows[0]["Inv_cnt"].ToString() == "0")
                {
                    btnAcc.Text = "Withdraw";
                }
                else
                {
                    btnAcc.Text = "Invoice Created";
                    btnAcc.Visible = false;
                }
            }
            Session["GSTN"] = ds.Tables[2].Rows[0]["GSTN_ID"].ToString();
            Session["BILL_ID"] = ds.Tables[2].Rows[0]["BILL_ID"].ToString();
            Session["JOBNO_PS"] = ds.Tables[2].Rows[0]["JOBNO_PS"].ToString();
        }
        else
        {
            Clear();
            rblPartyType.SelectedValue = "ML";
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnAcc.Visible = false;
        }

        if (ds.Tables[3].Rows.Count > 0)
        {
            btnAcc.Visible = false;
            if (ds.Tables[3].Rows.Count == 1)
            {
                lbl_Inv_Cnt.Text = "1";
                ddl_Invno.Items.Insert(0, new ListItem(ds.Tables[3].Rows[0]["BILL_INV_NO"].ToString(), ds.Tables[3].Rows[0]["BILL_INV_NO"].ToString()));
                ddl_Invno.SelectedIndex = 0;

                lbl_Non_Tax_Amt.Text = ds.Tables[3].Rows[0]["NON_TAXABLE_AMT"].ToString();
                lbl_taxable_Amt.Text = ds.Tables[3].Rows[0]["TAXABLE_AMT"].ToString();
                lbl_Tax_Amt.Text = ds.Tables[3].Rows[0]["TOTAL_TAX_AMT"].ToString();
                lbl_Grand_total.Text = ds.Tables[3].Rows[0]["GRAND_TOTAL"].ToString();
                btnInv_Rpt.Visible = true;
            }
            else
            {
                lbl_Inv_Cnt.Text = ds.Tables[3].Rows.Count.ToString();

                ddl_Invno.DataSource = ds.Tables[3];
                ddl_Invno.DataTextField = "BILL_INV_NO";
                ddl_Invno.DataValueField = "BILL_INV_NO";
                ddl_Invno.DataBind();

                ddl_Invno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddl_Invno.SelectedIndex = 0;
            }
        }
        else
        {
           // btnAcc.Visible = true;
            lbl_Inv_Cnt.Text = "0";
        }
        if (ds.Tables[4].Rows.Count > 0)
        {
            string partyType = ds.Tables[4].Rows[0]["PARTY_TYPE"].ToString();
            if (partyType == "GN")
            {
                rblPartyType.Items.FindByValue("ML").Enabled = false;
                rblPartyType.Items.FindByValue("SN").Enabled = false;

            } else if (partyType == "SN")
            {
                rblPartyType.Items.FindByValue("ML").Enabled = false;
            }
            else if (partyType == "ML")
            {
                rblPartyType.Items.FindByValue("SN").Enabled = false;
            }
            else
            {
                rblPartyType.Items.FindByValue("ML").Enabled = true;
                rblPartyType.Items.FindByValue("SN").Enabled = true;
                rblPartyType.Items.FindByValue("ML").Enabled = true;
            }
        }
    }
    public DataSet Acc_Bill_To_Part(string Party_Name, string Branch_No, string Flag)
    {
        ObjUBO.A1 = HiddenField1.Value.ToString();
        ObjUBO.A2 = Connection.IMP_Jobno();
        ObjUBO.A3 = ddlBill_party.SelectedValue.ToString();
        ObjUBO.A4 = ddl_Branch.SelectedValue.ToString();
        ObjUBO.A5 = txtAddress.Text;
        ObjUBO.A6 = txtAddress2.Text;
        ObjUBO.A7 = txtAddress3.Text;
        ObjUBO.A8 = ddl_state_name.SelectedValue.ToString();
        ObjUBO.A9 = tXtPincode.Text;
        ObjUBO.A10 = txt_GSTN_Num.Text;
        ObjUBO.A11 = Session["JOBNO_PS"].ToString();
        ObjUBO.A12 = "I";
        ObjUBO.A14 = "R";
        ObjUBO.A15 = Mode;
        ObjUBO.A16 = rblPartyType.SelectedValue;
        ObjUBO.A41 = Flag;
        return Bill.Bill_To_Party_Ins_Upd(ObjUBO);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            ds = Acc_Bill_To_Part(ddlBill_party.SelectedValue.ToString(), ddl_Branch.SelectedValue.ToString(), "U");
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnUpdate.Visible = true;
                Alert_msg("Bill to Party Updated Successfully", "btnUpdate");
                Session["GSTN"] = txt_GSTN_Num.Text;
            }
            else
            {
                btnUpdate.Visible = true;
                Alert_msg("Bill to Party  Not Updated", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = Acc_Bill_To_Part(ddlBill_party.SelectedValue.ToString(), ddl_Branch.SelectedValue.ToString(), "S");
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                Alert_msg("Bill to Party saved Successfully", "btnUpdate");
                Session["GSTN"] = txt_GSTN_Num.Text;
                btnAcc.Visible = true;
                btnAcc.Text = "Move To Accounts";   
            }  
            else
            {
                btnUpdate.Visible = false;
                btnSave.Visible = false;
                Alert_msg("Bill to Party  Not saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddlBill_party_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dss = new DataSet();
            ddl_Branch.Items.Clear();
            Clear();
            if (ddlBill_party.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.A3 = ddlBill_party.SelectedValue.ToString();
                ObjUBO.A6 = "LOAD_PARTY_BRANCH";
                ObjUBO.A5 = "I";
                ObjUBO.A2 = IMPORT_JOBNO;
                dss = Bill.Billing_Party_Data_Search(ObjUBO);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddl_Branch.DataSource = dss.Tables[0];
                    ddl_Branch.DataTextField = "PARTY_BRANCH_NO";
                    ddl_Branch.DataValueField = "PARTY_BRANCH_NO";
                    ddl_Branch.DataBind();
                }
            }
            ddl_Branch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Branch.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void ddl_Branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dss = new DataSet();
            if (ddlBill_party.SelectedValue.ToString() != string.Empty)
            {
                if (ddlBill_party.SelectedValue.ToString() != string.Empty)
                {
                    ObjUBO.A6 = "LOAD_PARTY_DETAILS";
                    ObjUBO.A3 = ddlBill_party.SelectedValue.ToString();
                    ObjUBO.A4 = ddl_Branch.SelectedValue.ToString();
                    ObjUBO.A5 = "I";
                    ObjUBO.A2 = IMPORT_JOBNO;
                    dss = Bill.Billing_Party_Data_Search(ObjUBO);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        txtAddress.Text = dss.Tables[0].Rows[0]["PARTY_ADD_1"].ToString();
                        txtAddress2.Text = dss.Tables[0].Rows[0]["PARTY_ADD_2"].ToString();
                        txtAddress3.Text = dss.Tables[0].Rows[0]["PARTY_ADD_3"].ToString();
                        tXtPincode.Text = dss.Tables[0].Rows[0]["PINCODE"].ToString();
                        ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["STATE_CODE"].ToString();
                        txt_GSTN_Num.Text = dss.Tables[0].Rows[0]["GST_NO"].ToString();
                    }
                }
                else
                {
                    Alert_msg("Select Ur Party Branch Details !");
                }
            }
            else
            {
                Alert_msg("Select Ur Party Details !");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Clear()
    {
        txtAddress.Text = string.Empty;
        txtAddress2.Text = string.Empty;
        txtAddress3.Text = string.Empty;
        tXtPincode.Text = string.Empty;
        ddl_state_name.SelectedIndex = -1;
        txt_GSTN_Num.Text = string.Empty;
    }
    protected void btnAccounts_Click(object sender, EventArgs e)
    {
        string flg = string.Empty;
        if (btnAcc.Text == "Withdraw")
        {
            flg = "Withdrawal_MOVE_TO_ACCOUNTS_STATUS";
        }
        else
        {
            flg = "UPDATE_MOVE_TO_ACCOUNTS_STATUS";
        }
        ds = Acc_Bill_To_Part("", "", flg);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0][0].ToString() == "0"  && ds.Tables[0].Rows[0][1].ToString() == "W")
            {
                Session["MOVE_ACCOUNTS"] = "0";
                btnAcc.Text = "Move To Accounts";   
                btnUpdate.Visible = true;
                lbl_Msg.Text = "Job Withdrawal Successfully.";
               // lbl_Acc_Msg.Text = "";
                rblPartyType.Enabled = true;
            }
            else
            {
                lbl_Msg.Text = "Job Sent Successfully.";
                btnUpdate.Visible = false;
               // lbl_Acc_Msg.Text = "Once Created Invoice, it Can't be Modified";
                btnAcc.Text = "Withdraw"; 
                Session["MOVE_ACCOUNTS"] = ds.Tables[0].Rows[0]["MOVE_TO_ACCOUNTS"].ToString();
                rblPartyType.Enabled = false;
            }
        }
        else
        {
            lbl_Msg.Text = string.Empty;
            btnUpdate.Enabled = true;
            //lbl_Acc_Msg.Text = "";
            btnAcc.Visible = true;
            Session["MOVE_ACCOUNTS"] = "0";
        }
    }
   
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Bill to Party', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Bill to Party', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddl_Invno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Invno.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A9 = ddl_Invno.SelectedValue.ToString();
            ds = Acc_Bill_To_Part("", "", "Invoice_Details");
            if (ds.Tables[0].Rows.Count>0)
            {
                lbl_Non_Tax_Amt.Text = ds.Tables[0].Rows[0]["NON_TAXABLE_AMT"].ToString();
                lbl_taxable_Amt.Text = ds.Tables[0].Rows[0]["TAXABLE_AMT"].ToString();
                lbl_Tax_Amt.Text = ds.Tables[0].Rows[0]["TOTAL_TAX_AMT"].ToString();
                lbl_Grand_total.Text = ds.Tables[0].Rows[0]["GRAND_TOTAL"].ToString();
                btnInv_Rpt.Visible = true;
            }
        }
        else
        {
            Alert_msg("Select Ur Invoice No!");
        }
    }
    protected void Rd_Job_Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ObjUBO.A1 = HiddenField1.Value.ToString();
            ObjUBO.A2 = Connection.IMP_Jobno();
            ObjUBO.A5 = Rd_Job_Status.SelectedValue.ToString();
            ObjUBO.A11 = Session["JOBNO_PS"].ToString();
            ObjUBO.A12 = "I";
            ObjUBO.A14 = "R";
            ObjUBO.A41 = "Job_Status_Update";
            ds = Bill.Bill_To_Party_Ins_Upd(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Job Status Updated Successfully.");
            }
            else
            {
                Alert_msg("Not Updated !");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void rblPartyType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = Acc_Bill_To_Part("", "", "DELETE_PARTY_INSERT");
        Insert();
    }
}