using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Accounts_Others_Payment_Request_Entry_Charge : ThemeClass
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    Payment_Request PR = new Payment_Request();
    Global_variables ObjUBO = new Global_variables();
    public string BP_ID, JOBNO_PS;
    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        BP_ID = Request.QueryString["BP_R_ID"];
        if (Request.QueryString["Pay_to"].ToString() == "E")
        {
            tag_PartA.Visible = true;
            tag_PartA1.Visible = true;
        }
        else
        {
            tag_PartA.Visible = false;
            tag_PartA1.Visible = false;
        }
        if (!IsPostBack)
        {
            txtPayable_To.Attributes.Add("readonly", "readonly");
            txtPayable_To.Style.Add("background-color", "#F0F0F0");

            txt_BP_R_No_F.Attributes.Add("readonly", "readonly");
            txt_BP_R_No_F.Style.Add("background-color", "#F0F0F0");

            txt_BP_R_M.Attributes.Add("readonly", "readonly");
            txt_BP_R_M.Style.Add("background-color", "#F0F0F0");

            txt_BP_R_L.Attributes.Add("readonly", "readonly");
            txt_BP_R_L.Style.Add("background-color", "#F0F0F0");
          


            string bpRNoF = Request.QueryString["BP_R_No_F"];
            string bpRM = Request.QueryString["BP_R_M"];
            string bpRL = Request.QueryString["BP_R_L"];
            string payCus = Request.QueryString["Pay_Cusname"];
          
            txt_BP_R_No_F.Text = bpRNoF;
            txt_BP_R_M.Text = bpRM;
            txt_BP_R_L.Text = bpRL;
            txtPayable_To.Text = payCus;
            Load_Charge();
            ddl_lOB_SelectedIndexChanged(this, null);
            if ((Request.QueryString["CHARGE_ID"] != null && Request.QueryString["CHARGE_ID"] != "") &&
                (Request.QueryString["BP_R_ID"] != null && Request.QueryString["BP_R_ID"] != ""))
            {
                Edit();
            }
        }
    }

    private void Edit()
    {

        DataSet ds = new DataSet();
        if (Request.QueryString["CHARGE_ID"] != null && Request.QueryString["CHARGE_ID"] != "")
        {
            ObjUBO.A15 = Request.QueryString["CHARGE_ID"].ToString();
        }
        else
        {
            ObjUBO.A15 = "";
        }
        if (Request.QueryString["BP_R_ID"] != null && Request.QueryString["BP_R_ID"] != "")
        {
            ObjUBO.A1 = Request.QueryString["BP_R_ID"].ToString();
        }
        else
        {
            ObjUBO.A1 = "";
        }
        ObjUBO.A2 = txt_BP_R_No_F.Text;
        ObjUBO.A3 = txt_BP_R_M.Text;
        ObjUBO.A4 = txt_BP_R_L.Text;
        ObjUBO.A50 = "SELECT_CHARGE";
        ds = PR.Payment_Request_Charge_Select(ObjUBO);
        
        if (Request.QueryString["CHARGE_ID"] != null && Request.QueryString["CHARGE_ID"] != "")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlcharge.SelectedValue = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();
                ddl_Cur_Rev.SelectedValue = ds.Tables[0].Rows[0]["CUR"].ToString();
                txt_Amount_HC.Text = ds.Tables[0].Rows[0]["PAY_AMOUNT_HC"].ToString();
                txtAmount_TC.Text = ds.Tables[0].Rows[0]["PAY_AMOUNT"].ToString();
                ddl_lOB.SelectedValue = ds.Tables[0].Rows[0]["LOB"].ToString();
                ddl_Jobno.SelectedItem.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                ddl_Jobno.SelectedValue = ds.Tables[0].Rows[0]["JOBNO_PS"].ToString();
                lblJobnoText.Text = ds.Tables[0].Rows[0]["JOBNO_PS"].ToString();
                ddl_Cost_Center.SelectedValue = ds.Tables[0].Rows[0]["COST_CENTER"].ToString();
                txtPayable_To.Text = ds.Tables[0].Rows[0]["PAYABLE_TO"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();
                ViewState["CHARGE_ID"] = ds.Tables[0].Rows[0]["CHARGE_ID"].ToString();
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
        }
    }

    private void Load_Charge()
    {
        ObjUBO.A50 = "Load_CHARGE";
        ds = PR.Payment_Request_Charge_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlcharge.DataSource = ds.Tables[0];
            ddlcharge.DataTextField = "CHARGE_NAME";
            ddlcharge.DataValueField = "CHARGE_VALUE";
            ddlcharge.DataBind();
        }
        ddlcharge.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlcharge.SelectedIndex = 0;
    }
  


    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";
            ViewState["CHARGE_ID"] = null;
            Clear();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Clear()
    {
        ddlcharge.SelectedIndex = -1;
        ddlcharge.SelectedValue = "INR";
        ddl_Cur_Rev.SelectedIndex = -1;
        txt_Amount_HC.Text = "";
        ddl_Cost_Center.SelectedIndex = -1;
        txtPayable_To.Text = "";
        txtRemarks.Text = "";
    }

    public void Acc_Chrg_Ins_Upd(string Flag, string id)
    {
        DataSet ds = new DataSet();
        ObjUBO.A7 = id;
        ObjUBO.A1 = BP_ID;
        ObjUBO.A2 = txt_BP_R_No_F.Text;
        ObjUBO.A3 = txt_BP_R_M.Text;
        ObjUBO.A4 = txt_BP_R_L.Text;
        ObjUBO.A5 = ddl_lOB.SelectedValue;
        ObjUBO.A6 = ddl_Jobno.SelectedItem.Text;
        ObjUBO.A21 = ddl_Jobno.SelectedValue;
        ObjUBO.A8 = ddlcharge.SelectedValue;
        ObjUBO.A9 = ddl_Cur_Rev.SelectedValue;
        ObjUBO.A12 = txt_Amount_HC.Text;
        ObjUBO.A11 = txtAmount_TC.Text;
        ObjUBO.A13 = ddl_Cost_Center.SelectedValue;
        ObjUBO.A14 = txtPayable_To.Text;
        ObjUBO.A15 = txtRemarks.Text;
        ObjUBO.A20 = Flag;
        ds = PR.Payment_Request_Charge_Details_Ins_Upd(ObjUBO);
    }
  

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlcharge.SelectedValue != "")
            {
                 Acc_Chrg_Ins_Upd("S", "");
                   i = PR.result;
                   ViewState["CHARGE_ID"] = Convert.ToString(PR.UPDATE_ID);
                    if (i == 1)
                    {
                        Alert_msg("Payment Charge Details Saved Successfully", "btnSave");
                        btnUpdate.CssClass = "updates";
                        btnDelete.Visible = true;
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                    }
                    else if (i == 2)
                    {
                        Alert_msg("Payment Charge Details already Exist", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Payment Charge Details Not Saved", "btnSave");
                    }
            }
            else
            {
                Alert_msg("Select Ur Charge Head!", "ddlcharge");
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
            if (Request.QueryString["CHARGE_ID"] != null && Request.QueryString["CHARGE_ID"] != "")
            {
                ObjUBO.A15 = Request.QueryString["CHARGE_ID"].ToString();
            }
            else
            {
                ObjUBO.A15 = "";
            }
            if (Request.QueryString["BP_R_ID"] != null && Request.QueryString["BP_R_ID"] != "")
            {
                ObjUBO.A1 = Request.QueryString["BP_R_ID"].ToString();
            }
            else
            {
                ObjUBO.A1 = "";
            }
            ObjUBO.A2 = txt_BP_R_No_F.Text;
            ObjUBO.A3 = txt_BP_R_M.Text;
            ObjUBO.A4 = txt_BP_R_L.Text;
            ObjUBO.A50 = "Delete";
            ds = PR.Payment_Request_Charge_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Alert_msg("Job Deleted.");
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                btnUpdate.CssClass = "updates";
                ViewState["CHARGE_ID"] = null;
                Clear();
            }
            else
            {
                Alert_msg("Job Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlcharge.SelectedValue != "")
            {
               
                    Acc_Chrg_Ins_Upd("U", ViewState["CHARGE_ID"].ToString());
                   i = PR.result;
                    if (i == 1)
                    {
                        Alert_msg("Charge Updated Successfully", "btnUpdate");
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                    }
                    else if (i == 2)
                    {
                        Alert_msg("Payment Charge Details already Exist", "btnSave");
                    }
                    else
                    {
                        Alert_msg("Payment Charge  Not Saved", "btnUpdate");
                    }
               
            }
            else
            {
                Alert_msg("Select Ur Charge Head!", "ddlcharge");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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

    protected void ddl_lOB_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjUBO.A8 = ddl_lOB.SelectedValue;
        ObjUBO.A50 = "LOAD_JOBNO";
        ds = PR.Payment_Request_Charge_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Jobno.DataSource = ds.Tables[0];
            ddl_Jobno.DataTextField = "JOBNO";
            ddl_Jobno.DataValueField = "JOBNO_PS";
            ddl_Jobno.DataBind();
        }
        ddl_Jobno.Items.Insert(0, new System.Web.UI.WebControls.ListItem(String.Empty, String.Empty));
        ddl_Jobno.SelectedIndex = 0;
    }
}