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

public partial class Accounts_Cash_Payment_Request_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    Payment_Request PR = new Payment_Request();
    Global_variables ObjUBO = new Global_variables();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public int i;
    public string a;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            if (!Page.IsPostBack)
            {
                lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
                lbl_Job_Wrk_Period.Text = Connection.WorkingPeriod();
                gv_JIE_Leg.DataSource = dt;
                gv_JIE_Leg.DataBind();
                gvAll_Pur.DataSource = dt;
                gvAll_Pur.DataBind();
                gv_details.DataSource = dt;
                gv_details.DataBind();

                if (Request.QueryString["BP_R_ID"] == null || Request.QueryString["BP_R_ID"] == "undefined")
                {

                    Load_PR_No();
                    btnsup.Text = "Save";

                    btn_PR_Delete.Visible = false;
                    txtRefDate.Text = DateTime.Now.ToString("dd/MM/yyyy");


                    if ((Request.QueryString["JOBNO"] != null && Request.QueryString["JOBNO_PS"] != ""))
                    {

                        Load_Charge();
                    }
                    else
                    {
                        load_Pay_Cusname();
                    }
                }
                else
                {
                    if (Request.QueryString["BP_R_ID"] != null && Request.QueryString["BP_R_ID"] != string.Empty)
                    {
                        btnsup.Text = "Update";
                        btn_PR_Delete.Visible = true;
                        Hidden_Auto.Value = "";
                        Update_Item_Load();
                    }
                }


            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void Update_Item_Load()
    {
        try
        {
            DataSet dSS = new DataSet();
            ObjUBO.A1 = Request.QueryString["BP_R_ID"].ToString();
            ObjUBO.A50 = "SEARCH_SELECT";
            dSS = PR.Payment_Request_Select(ObjUBO);
            if (dSS.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = dSS.Tables[0].Rows[0]["BP_R_ID"].ToString();
                txt_BP_R_No_F.Text = dSS.Tables[0].Rows[0]["BP_R_P"].ToString();
                txt_BP_R_M.Text = dSS.Tables[0].Rows[0]["BP_R_NO"].ToString();
                txt_BP_R_L.Text = dSS.Tables[0].Rows[0]["BP_R_S"].ToString();

                ddlpayto.SelectedValue = dSS.Tables[0].Rows[0]["Pay_To_Type"].ToString();
                //ddlpay_Cusname.SelectedValue = dSS.Tables[0].Rows[0]["Pay_To_Cus_Name"].ToString();
                if (ddlpayto.SelectedValue.ToString() == "E")
                {
                    txt_container_Transact_Main_l_jO.Visible = false;
                }
                else
                {
                    txt_container_Transact_Main_l_jO.Visible = true;
                }

                ddlpay_Cusname.Items.Insert(0, new ListItem(dSS.Tables[0].Rows[0]["Pay_To_Cus_Name"].ToString(), dSS.Tables[0].Rows[0]["Pay_To_Cus_Name"].ToString()));
                ddlpay_Cusname.SelectedIndex = 0;
                ddlpay_Cusname.Enabled = false;
                ddlpayto.Enabled = false;



                txtRefDate.Text = dSS.Tables[0].Rows[0]["Ref_Date"].ToString().Replace("01/01/1900", "");
                ddl_Against.SelectedValue = dSS.Tables[0].Rows[0]["Against"].ToString();
                ddl_Against.Enabled = false;
                ddl_Mode_of_Payment.SelectedValue = dSS.Tables[0].Rows[0]["Mode_of_Payment"].ToString();
                a = dSS.Tables[0].Rows[0]["Mark_As_Urgent"].ToString();
                if (a == "true")
                {
                    chk_Urgent.Checked = true;
                }
                else
                {
                    chk_Urgent.Checked = false;
                }
                //Load_Jobno();
                /*
              ddlJobno.SelectedValue = dSS.Tables[0].Rows[0]["Job_No"].ToString();
              ddlJobno.SelectedItem.Text = dSS.Tables[0].Rows[0]["JobNo_Ps"].ToString();
                */
                Rd_Job_Non_Exp.SelectedValue = dSS.Tables[0].Rows[0]["JOB_NON_JOB_EXPENSE"].ToString();
                Rd_Job_Non_Exp.Enabled = false;
                ddlJobno.Items.Insert(0, new ListItem(
                      dSS.Tables[0].Rows[0]["JobNo_Ps"].ToString(),
              dSS.Tables[0].Rows[0]["Job_No"].ToString()
                    ));
                ddlJobno.SelectedIndex = 0;
                ddlJobno.Enabled = false;

                ddl_Imp_Exp.SelectedValue = dSS.Tables[0].Rows[0]["IMP_EXP"].ToString();
                ddl_Imp_Exp.Enabled = false;

                txtJobno_ps.Text = dSS.Tables[0].Rows[0]["JobNo_Ps"].ToString();
                ddlrequest.SelectedValue = dSS.Tables[0].Rows[0]["Request_To"].ToString();
                lbl_Job_Company_Lic.Text = dSS.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
                lbl_Job_Wrk_Period.Text = dSS.Tables[0].Rows[0]["JOB_WORKINGPERIOD"].ToString();
                txt_Amount.Text = dSS.Tables[0].Rows[0]["Amount"].ToString();
                txtNarration.Text = dSS.Tables[0].Rows[0]["Narration"].ToString();

            }
            else
            {
                btn_PR_Delete.Visible = false;
            }
            if (dSS.Tables[1].Rows.Count > 0)
            {
                gv_JIE_Leg.DataSource = dSS.Tables[1];
                gv_JIE_Leg.DataBind();
            }
            else
            {
                load_Grid();
            }
            if (dSS.Tables[2].Rows.Count > 0)
            {
                gv_details.DataSource = dSS.Tables[2];
                gv_details.DataBind();
            }
            else
            {
                gv_details.DataSource = dt;
                gv_details.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_JIE_Leg_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Payment Request', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Payment Request', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btn_PR_Delete_Click(object sender, EventArgs e)
    {
        try
        {
            Ins_Upd("Delete");
            if (ds.Tables[0].Rows.Count == 0)
            {
                ViewState["UPDATED_ID"] = null;
                Hidden_Auto.Value = "1";
                btnNew_Click(sender, e);
                Alert_msg("Payment Entry Deleted");

            }
            else
            {
                Alert_msg("Payment Entry Not Deleted", "btnDelete");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            btn_PR_Delete.Visible = false;
            btnsup.Text = "Save";
            ViewState["UPDATED_ID"] = null;
            HD_Ch_update_id.Value = "";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btn_Save_Update_Click(object sender, EventArgs e)
    {
        try
        {
            Payment_Save();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void Payment_Save()
    {
        if (btnsup.Text == "Save")
        {
            ds = Ins_Upd("S");
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BP_R_ID"].ToString();
                btnsup.Text = "Update";

                btn_PR_Delete.Visible = true;
                Alert_msg("Saved Successfully!", "btn_Save_Update");
            }
        }
        else if (btnsup.Text == "Update")
        {
            ds = Ins_Upd("U");
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnsup.Text = "Update";
                Alert_msg("Updated Successfully!", "btn_Save_Update");
            }
        }
    }

    public DataSet Ins_Upd(string S1)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txt_BP_R_No_F.Text;
        ObjUBO.A3 = txt_BP_R_M.Text;
        ObjUBO.A4 = txt_BP_R_L.Text;
        ObjUBO.A5 = txtRefDate.Text;
        ObjUBO.A6 = ddlpayto.SelectedValue.ToString();
        ObjUBO.A7 = ddlpay_Cusname.SelectedValue.ToString();
        ObjUBO.A8 = ddl_Against.SelectedValue.ToString();
        ObjUBO.A9 = Rd_Job_Non_Exp.SelectedValue.ToString();
        ObjUBO.A10 = ddl_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A12 = ddlJobno.SelectedItem.ToString();
        ObjUBO.A11 = ddlJobno.SelectedValue.ToString();
        ObjUBO.A13 = ddlrequest.SelectedValue.ToString();
        ObjUBO.A14 = ddl_Mode_of_Payment.SelectedValue.ToString();
        ObjUBO.A15 = chk_Urgent.Checked.ToString().ToUpper();
        ObjUBO.A16 = txt_Amount.Text;
        ObjUBO.A17 = txtNarration.Text;

        ObjUBO.A29 = Job_Leg_details();
        ObjUBO.A30 = lbl_Job_Company_Lic.Text;
        ObjUBO.A31 = lbl_Job_Wrk_Period.Text;
        ObjUBO.A32 = S1;
        ds = PR.Payment_Request_Ins_Upd(ObjUBO);
        return ds;
    }

    private void load_Pay_Cusname()
    {
        DataSet ds = new DataSet();
        ObjUBO.A5 = ddlpayto.SelectedValue.ToString();
        ObjUBO.A50 = "Load_Pay_Cusname";
        ds = PR.Payment_Request_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlpay_Cusname.DataSource = ds.Tables[0];
            ddlpay_Cusname.DataTextField = "Pay_CusName";
            ddlpay_Cusname.DataValueField = "Pay_CusName";
            ddlpay_Cusname.DataBind();
        }
        ddlpay_Cusname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlpay_Cusname.SelectedIndex = 0;
        if (lbl_Job_Company_Lic.Text == "ERI00480")
        {

            if (ds.Tables[1].Rows.Count > 0)
            {
                ddlrequest.DataSource = ds.Tables[1];
                ddlrequest.DataTextField = "REQUEST_TO";
                ddlrequest.DataValueField = "REQUEST_TO";
                ddlrequest.DataBind();
            }
            ddlrequest.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlrequest.SelectedIndex = 0;
        }
        else
        {
            ddlrequest.Items.Clear();
            if (Session["ClientGrpMst"] != null)
            {
                DataSet dds = (DataSet)Session["ClientGrpMst"];
                if (dds.Tables[0].Rows.Count > 0)
                {
                    ddlrequest.DataSource = dds.Tables[0];
                    ddlrequest.DataTextField = "GROUP_NAME";
                    ddlrequest.DataValueField = "GROUP_ID";
                    ddlrequest.DataBind();
                }
            }
            ddlrequest.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlrequest.SelectedIndex = 0;
        }
    }

    private void Load_PR_No()
    {
        DataSet ds = new DataSet();
        try
        {
            txt_BP_R_No_F.Text = string.Empty;
            txt_BP_R_M.Text = string.Empty;
            txt_BP_R_L.Text = string.Empty;
            txtRefDate.Text = string.Empty;
            ObjUBO.A50 = "PR_No_Select";
            ds = PR.Payment_Request_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_BP_R_No_F.Text = ds.Tables[0].Rows[0]["BP_R_P"].ToString();
                txt_BP_R_M.Text = ds.Tables[0].Rows[0]["BP_R_NO"].ToString();
                txt_BP_R_L.Text = ds.Tables[0].Rows[0]["BP_R_S"].ToString();
                txtRefDate.Text = ds.Tables[0].Rows[0]["REF_DATE"].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Load_Jobno()
    {
        ddlJobno.Items.Clear();
        gv_JIE_Leg.DataSource = dt;
        gv_JIE_Leg.DataBind();

        if (ddlpay_Cusname.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A5 = ddlpayto.SelectedValue.ToString();
            ObjUBO.A6 = ddlpay_Cusname.SelectedValue.ToString();
            ObjUBO.A7 = Rd_Job_Non_Exp.SelectedValue.ToString();
            ObjUBO.A8 = ddl_Imp_Exp.SelectedValue.ToString();

            ObjUBO.A50 = "Load_Jobno";
            ds = PR.Payment_Request_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlJobno.DataSource = ds.Tables[0];
                ddlJobno.DataValueField = "JOBNO";
                ddlJobno.DataTextField = "JOBNO_PS";
                ddlJobno.DataBind();
            }
            ddlJobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlJobno.SelectedIndex = 0;
        }
    }

    protected void ddlpay_Cusname_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((Request.QueryString["JOBNO"] != null && Request.QueryString["JOBNO_PS"] != ""))
        {
            ddlJobno_SelectedIndexChanged(this, null);
        }
        else
        {
            Load_Jobno();
        }
    }
    protected void ddl_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Jobno();
    }
    protected void ddlJobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Grid();
    }
    private void Load_Charge()
    {

        ddlJobno.Items.Insert(0, new ListItem(Request.QueryString["JOBNO_PS"].ToString(), Request.QueryString["JOBNO"].ToString()));
        ddlJobno.SelectedIndex = 0;
        ddlJobno.Enabled = false;
        ddl_Imp_Exp.SelectedValue = Request.QueryString["I_E"].ToString();
        ObjUBO.A10 = ddlJobno.SelectedItem.Text.ToString();
        ObjUBO.A9 = ddlJobno.SelectedValue.ToString();
        ObjUBO.A8 = ddl_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A50 = "Load_Charge";
        ds = PR.Payment_Request_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count == 1)
            {
                if (Rd_Job_Non_Exp.SelectedValue == "J")
                {
                    ddlpayto.SelectedValue = ds.Tables[0].Rows[0]["Pay_To_Type"].ToString();
                    if (ddlpayto.SelectedValue.ToString() == "E")
                    {
                        txt_container_Transact_Main_l_jO.Visible = false;
                    }
                    else
                    {
                        txt_container_Transact_Main_l_jO.Visible = true;
                    }
                    ddlpay_Cusname.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["Pay_To_Cus_Name"].ToString(), ds.Tables[0].Rows[0]["Pay_To_Cus_Name"].ToString()));
                    ddlpay_Cusname.SelectedIndex = 0;
                    ddlpay_Cusname.Enabled = false;
                    ddlpayto.Enabled = false;

                }
            }
            if (ds.Tables[0].Rows.Count > 1)
            {
                ddlpay_Cusname.DataSource = ds.Tables[0];
                ddlpay_Cusname.DataTextField = "Pay_To_Cus_Name";
                ddlpay_Cusname.DataValueField = "Pay_To_Cus_Name";
                ddlpay_Cusname.DataBind();

                ddlpay_Cusname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlpay_Cusname.SelectedIndex = 0;
                ddlpay_Cusname.Enabled = true;
                ddlpayto.Enabled = true;
            }


            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_JIE_Leg.DataSource = ds.Tables[1];
                gv_JIE_Leg.DataBind();
            }
        }
    }
  
    private void load_Grid()
    {
        ObjUBO.A10 = ddlJobno.SelectedItem.Text.ToString();
        ObjUBO.A9 = ddlJobno.SelectedValue.ToString();
        ObjUBO.A8 = ddl_Imp_Exp.SelectedValue.ToString();
        ObjUBO.A5 = ddlpayto.SelectedValue.ToString();
        ObjUBO.A6 = ddlpay_Cusname.SelectedValue.ToString();
        ObjUBO.A1 = HDupdate_id.Value;
        ObjUBO.A2 = txt_BP_R_No_F.Text;
        ObjUBO.A3 = txt_BP_R_M.Text;
        ObjUBO.A4 = txt_BP_R_L.Text;
        ObjUBO.A50 = "Load_GRID";
        ds = PR.Payment_Request_Select(ObjUBO);
        if (Rd_Job_Non_Exp.SelectedValue == "J")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_JIE_Leg.DataSource = ds.Tables[0];
                gv_JIE_Leg.DataBind();
            }
            else
            {
                gv_JIE_Leg.DataSource = dt;
                gv_JIE_Leg.DataBind();
            }
        }
        if (Rd_Job_Non_Exp.SelectedValue == "NJ")
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                gv_details.DataSource = ds.Tables[1];
                gv_details.DataBind();
            }
            else
            {
                gv_details.DataSource = dt;
                gv_details.DataBind();
            }
        }
    }

    private string Job_Leg_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("ID", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CHK", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CHARGE_NAME", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("AMOUNT_TC", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("PAYABLE_TO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("REMARKS", typeof(String)));
        if (Rd_Job_Non_Exp.SelectedValue == "J")
        {
            foreach (GridViewRow row in gv_JIE_Leg.Rows)
            {
                Literal txt_BILL = (Literal)row.FindControl("txt_BILL");
                CheckBox chkRow = (CheckBox)row.FindControl("chk");
                Literal txt_ChargeName = (Literal)row.FindControl("txt_ChargeName");
                TextBox txt_Amount_TC = (TextBox)row.FindControl("txt_Amount_Tc");
                Literal txt_Payable_To = (Literal)row.FindControl("txt_Payable_To");
                TextBox txt_Remark = (TextBox)row.FindControl("txt_Remark");

                if (chkRow.Checked)
                {
                    dr = dtt.NewRow();
                    dr[0] = txt_BILL.Text;
                    dr[1] = chkRow.Checked;
                    dr[2] = txt_ChargeName.Text;
                    dr[3] = txt_Amount_TC.Text;
                    dr[4] = txt_Payable_To.Text;
                    dr[5] = txt_Remark.Text;
                    dtt.Rows.Add(dr);
                }
            }
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = Common_CS.ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }
    protected void Load_Excel_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.A2 = txt_BP_R_No_F.Text;
            ObjUBO.A3 = txt_BP_R_M.Text;
            ObjUBO.A4 = txt_BP_R_L.Text;
            ObjUBO.A8 = ddl_Imp_Exp.SelectedValue;
            ObjUBO.A50 = "Load_Excel_grid";
            ds = PR.Payment_Request_Select(ObjUBO);
            {
                gv_JIE_Leg.DataSource = ds.Tables[0];
                gv_JIE_Leg.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void Load_Click(object sender, EventArgs e)
    {

        try
        {
            load_Grid();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    protected void ddlpayto_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ddlpayto.SelectedValue.ToString() == "E")
        {
            txt_container_Transact_Main_l_jO.Visible = false;
        }
        else
        {
            txt_container_Transact_Main_l_jO.Visible = true;
        }
        if ((Request.QueryString["JOBNO"] != null && Request.QueryString["JOBNO_PS"] != ""))
        {
        }
        else
        {
            ObjUBO.A5 = ddlpayto.SelectedValue.ToString();
            ObjUBO.A50 = "Load_Pay_Cusname";
            ds = PR.Payment_Request_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlpay_Cusname.DataSource = ds.Tables[0];
                ddlpay_Cusname.DataTextField = "Pay_CusName";
                ddlpay_Cusname.DataValueField = "Pay_CusName";
                ddlpay_Cusname.DataBind();
            }
            ddlpay_Cusname.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlpay_Cusname.SelectedIndex = 0;
        }

    }
}