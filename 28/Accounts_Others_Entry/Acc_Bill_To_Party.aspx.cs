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

public partial class Import_Acc_Bill_To_Party : ThemeClass
{
    Cha_Accounts Bill = new Cha_Accounts();
    Global_variables ObjUBO = new Global_variables();
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            if (!Page.IsPostBack)
            {
                Jobno_E_D();
                txtjobps.Attributes.Add("readonly", "readonly");
                txtjobps.Style.Add("background-color", "#F0F0F0");
                hdn_Jobno.Value = "";
                ddlBill_party.Focus();
                Load_Party_Name();
              
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Jobno_E_D()
    {
        txtjobNo_PR.Attributes.Add("readonly", "readonly");
        txtjobNo_PR.Style.Add("background-color", "#F0F0F0");

        txtjobNo.Attributes.Add("readonly", "readonly");
        txtjobNo.Style.Add("background-color", "#F0F0F0");

        txtjobNo_SF.Attributes.Add("readonly", "readonly");
        txtjobNo_SF.Style.Add("background-color", "#F0F0F0");

        DataSet ds = new DataSet();
        try
        {
            txtjobNo_PR.Text = string.Empty;
            txtjobNo.Text = string.Empty;
            txtjobNo_SF.Text = string.Empty;
            ObjUBO.A6 = "OT_No_Select";
            ObjUBO.A5 = Rd_Imp_Exp.SelectedValue;
            ds = Bill.Other_Billing_Party_Data_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtjobNo_PR.Text = ds.Tables[0].Rows[0]["JOB_P"].ToString();
                txtjobNo.Text = ds.Tables[0].Rows[0]["JOB_NO"].ToString();
                txtjobNo_SF.Text = ds.Tables[0].Rows[0]["JOB_S"].ToString();
                //txt_BR_Entry_Date.Text = ds.Tables[0].Rows[0]["BP_Date"].ToString();
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Load_Party_Name()
    {
        DataSet dss = new DataSet();
        try
        {
            if (Request.QueryString["Bill_id"].ToString() != null && Request.QueryString["Bill_id"].ToString() != "")
            {
                ObjUBO.A1 = Request.QueryString["Bill_id"].ToString();
                Rd_Imp_Exp.Enabled = false;
            }
            else
            {
                btnAcc.Visible = false;
            }
            ObjUBO.A6 = "OTHERS_LOAD_PARTY_NAME";
            ds = Bill.Other_Billing_Party_Data_Search(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlBill_party.DataSource = ds.Tables[0];
                ddlBill_party.DataTextField = "PARTY_NAME";
                ddlBill_party.DataValueField = "PARTY_NAME";
                ddlBill_party.DataBind();
            }
            ddlBill_party.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlBill_party.SelectedIndex = 0;

            if (ds.Tables[2].Rows.Count > 0)
            {
                ddl_Branch.DataSource = ds.Tables[2];
                ddl_Branch.DataTextField = "BRANCH_NO";
                ddl_Branch.DataValueField = "BRANCH_NO";
                ddl_Branch.DataBind();
            }
            ddl_Branch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddl_Branch.SelectedIndex = 0;
            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlBill_party.SelectedValue = ds.Tables[1].Rows[0]["BILL_PARTY_NAME"].ToString();
                ddl_Branch.SelectedValue = ds.Tables[1].Rows[0]["BRANCH_NO"].ToString();
                txtAddress.Text = ds.Tables[1].Rows[0]["ADDRESS_I"].ToString();
                txtAddress2.Text = ds.Tables[1].Rows[0]["ADDRESS_II"].ToString();
                txtAddress3.Text = ds.Tables[1].Rows[0]["ADDRESS_III"].ToString();
                tXtPincode.Text = ds.Tables[1].Rows[0]["PINCODE"].ToString();
                ddl_state_name.SelectedValue = ds.Tables[1].Rows[0]["STATENAME"].ToString();
                txt_GSTN_Num.Text = ds.Tables[1].Rows[0]["GSTN_ID"].ToString();
                HiddenField1.Value = ds.Tables[1].Rows[0]["BILL_ID"].ToString();
                txtjobps.Text = ds.Tables[1].Rows[0]["JOBNO_PS"].ToString();
                txtjobNo.Text = ds.Tables[1].Rows[0]["JOBNO"].ToString();
                string[] parts = txtjobps.Text.Split(new string[] { txtjobNo.Text }, StringSplitOptions.None);
                txtjobNo_PR.Text = parts[0].TrimEnd();
                txtjobNo_SF.Text = parts[1].TrimStart();
                ddl_mode.SelectedValue = ds.Tables[1].Rows[0]["MODE"].ToString();
                Session["MOVE_ACCOUNTS_OJ"] = ds.Tables[1].Rows[0]["MOVE_TO_ACCOUNTS"].ToString();
                Session["JOBNO_PS_OJ"] = ds.Tables[1].Rows[0]["JOBNO_PS"].ToString();
                Session["JOBNO_OJ"] = ds.Tables[1].Rows[0]["JOBNO"].ToString();
                Session["IMP_EXP_OJ"] = ds.Tables[1].Rows[0]["JOBTYPE"].ToString();
                Rd_Imp_Exp.SelectedValue = ds.Tables[1].Rows[0]["JOBTYPE"].ToString();

                Session["GSTN_OJ"] = ds.Tables[1].Rows[0]["GSTN_ID"].ToString();
                Session["BILL_ID_OJ"] = ds.Tables[1].Rows[0]["BILL_ID"].ToString();
                Session["MODE_OJ"] = ds.Tables[1].Rows[0]["MODE"].ToString();

                txtjobNo.Enabled = false;
                txtjobNo_PR.Enabled = false;
                txtjobNo_SF.Enabled = false;
                hdn_Jobno.Value = txtjobNo.Text;
                Session["MOVE_ACCOUNTS_OJ"] = ds.Tables[1].Rows[0]["MOVE_TO_ACCOUNTS"].ToString();
                if (Session["MOVE_ACCOUNTS_OJ"].ToString() == "0")
                {
                    btnUpdate.Enabled = true;
                    btnAcc.Text = "Move To Accounts";
                    btnAcc.Visible = true;

                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    
                }
                else
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = false;
                   
                    if (ds.Tables[3].Rows[0]["Inv_cnt"].ToString() == "0")
                    {
                        btnAcc.Text = "Withdraw";
                    }
                    else
                    {
                        btnAcc.Text = "Invoice Created";
                        btnAcc.Visible = false;
                    }
                }
               
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet Acc_Bill_To_Part(string Party_Name, string Branch_No, string Flag)
    {
        ObjUBO.A1 = HiddenField1.Value.ToString();
        ObjUBO.A2 = txtjobNo.Text;
        ObjUBO.A3 = ddlBill_party.SelectedValue.ToString();
        ObjUBO.A4 = ddl_Branch.SelectedValue.ToString();
        ObjUBO.A5 = txtAddress.Text;
        ObjUBO.A6 = txtAddress2.Text;
        ObjUBO.A7 = txtAddress3.Text;
        ObjUBO.A8 = ddl_state_name.SelectedValue.ToString();
        ObjUBO.A9 = tXtPincode.Text;
        ObjUBO.A10 = txt_GSTN_Num.Text;
        ObjUBO.A11 = txtjobNo_PR.Text + txtjobNo.Text + txtjobNo_SF.Text;
        ObjUBO.A12 = Rd_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A14 = "O";
        ObjUBO.A15 = ddl_mode.SelectedValue;
        ObjUBO.A41 = Flag;
        return Bill.Other_Bill_To_Party_Ins_Upd(ObjUBO);
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlBill_party.SelectedValue != "")
            {
                if (ddl_Branch.SelectedValue != "")
                {
                    if (txtjobNo.Text != "")
                    {
                        ds = Acc_Bill_To_Part(ddlBill_party.SelectedValue.ToString(), ddl_Branch.SelectedValue.ToString(), "U");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Alert_msg("Bill to Party Updated Successfully", "btnUpdate");
                            Session["GSTN_OJ"] = txt_GSTN_Num.Text;
                            Session["MODE_OJ"] = ddl_mode.SelectedValue;
                        }
                        else
                        {
                            Alert_msg("Bill to Party  Not Updated", "btnUpdate");
                        }
                    }
                    else
                    {
                        hdn_Jobno.Value = "";
                        Alert_msg("Jobno already Exist", "btnUpdate");
                    }
                }
                else
                {
                    Alert_msg("Branch SL No Cannot be Empty", "btnUpdate");
                }
            }
            else
            {
                Alert_msg("Bill Party Name Cannot be Empty", "btnUpdate");
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

            if (ddlBill_party.SelectedValue != "")
            {
                if (ddl_Branch.SelectedValue != "")
                {
                    ds = Acc_Bill_To_Part(ddlBill_party.SelectedValue.ToString(), ddl_Branch.SelectedValue.ToString(), "S");
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Session.Remove("JOBNO_OJ");
                            Session.Remove("JOBNO_PS_OJ");
                            Session.Remove("GSTN_OJ");
                            Session.Remove("MOVE_ACCOUNTS_OJ");
                            Session.Remove("MODE_OJ");
                            btnUpdate.Visible = true;
                            btnSave.Visible = false;
                            btnDelete.Visible = true;
                            Alert_msg("Bill to Party saved Successfully", "btnUpdate");
                            Session["GSTN_OJ"] = txt_GSTN_Num.Text;
                            Session["MOVE_ACCOUNTS_OJ"] = ds.Tables[0].Rows[0]["MOVE_TO_ACCOUNTS"].ToString();
                            Session["JOBNO_OJ"] = txtjobNo.Text;
                            Session["JOBNO_PS_OJ"] = txtjobps.Text;
                            Session["MODE_OJ"] = ddl_mode.SelectedValue;
                            hdn_Jobno.Value = "1";

                          

                            btnAcc.Visible = true;
                            btnAcc.Text = "Move To Accounts";
                        }
                        else
                        {
                            hdn_Jobno.Value = "";
                            btnUpdate.Visible = false;
                            btnSave.Visible = true;
                            btnDelete.Visible = false;
                            Alert_msg("Bill to Party  Not saved", "btnUpdate");
                        }
                        Session["IMP_EXP_OJ"] = Rd_Imp_Exp.SelectedItem.Value;
                    }
                    else
                    {
                        hdn_Jobno.Value = "";
                        Alert_msg("Jobno already Exist", "btnUpdate");
                    }
                }
                else
                {
                    Alert_msg("Branch SL No Cannot be Empty", "btnUpdate");
                }
            }
            else
            {
                Alert_msg("Bill Party Name Cannot be Empty", "btnUpdate");
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
            ObjUBO.A2 = txtjobNo.Text;
            ObjUBO.A6 = "Delete";
            ObjUBO.A5 = Rd_Imp_Exp.SelectedValue;
            ObjUBO.A7 = "O";
            ObjUBO.A8 = txtjobps.Text;
            ds = Bill.Other_Billing_Party_Data_Search(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg(ds.Tables[0].Rows[0]["ALERT"].ToString());
                txtjobNo_PR.Text=string.Empty;
                txtjobNo.Text=string.Empty;
                txtjobNo_SF.Text = string.Empty;
                ddlBill_party.SelectedIndex = -1;
                ddl_Branch.SelectedIndex = -1;
                Clear();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnAcc.Text = "";
                btnAcc.Visible = false;


                txtjobNo_PR.Attributes.Remove("readonly");
                txtjobNo_PR.Style.Add("background-color", "White");

                txtjobNo.Attributes.Remove("readonly");
                txtjobNo.Style.Add("background-color", "White");

                txtjobNo_SF.Attributes.Remove("readonly");
                txtjobNo_SF.Style.Add("background-color", "White");
            }
            else
            {
                Alert_msg("Job not Deleted");
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
                ObjUBO.A6 = "OTHERS_LOAD_PARTY_BRANCH";
                dss = Bill.Other_Billing_Party_Data_Search(ObjUBO);
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
            txtAddress.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            tXtPincode.Text = string.Empty;
            ddl_state_name.SelectedIndex = -1;
            txt_GSTN_Num.Text = string.Empty;

            DataSet dss = new DataSet();
            if (ddlBill_party.SelectedValue.ToString() != string.Empty)
            {
                if (ddl_Branch.SelectedValue.ToString() != string.Empty)
                {
                    ObjUBO.A6 = "OTHERS_LOAD_PARTY_DETAILS";
                    ObjUBO.A3 = ddlBill_party.SelectedValue.ToString();
                    ObjUBO.A4 = ddl_Branch.SelectedValue.ToString();
                    dss = Bill.Other_Billing_Party_Data_Search(ObjUBO);
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
            if (ds.Tables[0].Rows[0][0].ToString() == "0" && ds.Tables[0].Rows[0][1].ToString() == "W")
            {
                Session["MOVE_ACCOUNTS_OJ"] = "0";
                btnAcc.Text = "Move To Accounts";
                btnUpdate.Visible = true;
                lbl_Msg.Text = "Job Withdrawal Successfully.";
                // lbl_Acc_Msg.Text = "";
               
            }
            else
            {
                lbl_Msg.Text = "Job Sent Successfully.";
                btnUpdate.Visible = false;
                // lbl_Acc_Msg.Text = "Once Created Invoice, it Can't be Modified";
                btnAcc.Text = "Withdraw";
                Session["MOVE_ACCOUNTS_OJ"] = ds.Tables[0].Rows[0]["MOVE_TO_ACCOUNTS"].ToString();
            
            }
        }
        else
        {
            lbl_Msg.Text = string.Empty;
            btnUpdate.Enabled = true;
            //lbl_Acc_Msg.Text = "";
            btnAcc.Visible = true;
            Session["MOVE_ACCOUNTS_OJ"] = "0";
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}