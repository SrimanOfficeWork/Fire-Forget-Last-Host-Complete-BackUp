using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;
using System.IO;
using System.Text;

public partial class Bank_Reconciliation_Entry : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Bank_Reconciliation_Entry_cs BR = new Bank_Reconciliation_Entry_cs();

    DataTable dt = new DataTable();

    //ACC_GST_BANK_RECONCILIATION

    public string COMPANY_ID, flag;
    private int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            Load_Group_Name();
            load_Bank_name();
            Edit_Cancellation();

        }
    }
    private void Load_Group_Name()
    {
        ddl_Location.Items.Clear();
        /*
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Location.DataSource = ds.Tables[0];
                ddl_Location.DataTextField = "GROUP_NAME";
                ddl_Location.DataValueField = "GROUP_ID";
                ddl_Location.DataBind();
            }
        }
        */
        ddl_Location.Items.Insert(0, new ListItem("All", String.Empty));
        ddl_Location.SelectedIndex = 0;
    }

    private void Edit_Cancellation()
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["RECON_ID"] != null && Request.QueryString["RECON_ID"] != string.Empty)
        {
            ObjUBO.A6 = Request.QueryString["RECON_ID"].ToString();
            ObjUBO.A40 = "load_Reconciliation_Select";
            ds = BR.Bank_Reconciliation_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_Bank_Name.SelectedValue = ds.Tables[0].Rows[0]["BANK_ACNO"].ToString();
                ddl_Bank_Name_SelectedIndexChanged(this, null);
                Literal1.Text = "";
                gvAll.DataSource = ds.Tables[0];
                gvAll.DataBind();
                btnSearch.Visible = false;
                btn_Recon.Visible = false;
                foreach (GridViewRow row in gvAll.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chk");
                    if (chk != null)
                    {
                        chk.Checked = true;
                    }
                }
            }
            else
            {
                btnSearch.Visible = true;
                btn_Recon.Visible = true;
            }
        }
        else
        {
            gvAll.DataSource = dt;
            gvAll.DataBind();
        }
    }
    private void load_Bank_name()
    {
        ddl_Bank_Name.Items.Clear();
        DataSet ds = new DataSet();

        ObjUBO.A40 = "Bank_Name_Select";
        ds = BR.Bank_Reconciliation_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_Bank_Name.DataSource = ds.Tables[0];
            ddl_Bank_Name.DataTextField = "BANK_NAME";
            ddl_Bank_Name.DataValueField = "ACCOUNT_NUMBER";
            ddl_Bank_Name.DataBind();
        }
        ddl_Bank_Name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddl_Bank_Name.SelectedIndex = 0;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            lbl_Bal_Per_Book_Amt.Text = "0.00";
            lbl_Non_Recon_Amt.Text = "0.00";
            lbl_Ins_not_Sys_Amt.Text = "0.00";
            lbl_Bal_Per_Bank.Text = "0.00";

            DataSet dss = new DataSet();
            ObjUBO.A1 = ddl_Bank_Name.SelectedValue.ToString();
            ObjUBO.A2 = ddl_Trans_Type.SelectedValue.ToString();
            ObjUBO.A4 = txt_trans_fromdate.Text;
            ObjUBO.A5 = txt_trans_todate.Text;
            ObjUBO.A40 = "Load_Grid_Data";
            dss = BR.Bank_Reconciliation_Select(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                gvAll.DataSource = dss.Tables[0];
            }
            else
            {
                gvAll.DataSource = dt;
            }
            gvAll.DataBind();

            if (dss.Tables[1].Rows.Count > 0)
            {
                lbl_Bal_Per_Book_Amt.Text = dss.Tables[1].Rows[0]["Rec_Amt"].ToString();
                lbl_Non_Recon_Amt.Text = dss.Tables[1].Rows[0]["Non_Rec_Amt"].ToString();
                lbl_Ins_not_Sys_Amt.Text = "0.00";
                lbl_Bal_Per_Bank.Text = dss.Tables[1].Rows[0]["Bal_Amt"].ToString();
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
    }
    private void Clear()
    {
        HD_Tr_mode.Value = string.Empty;

        gvAll.DataSource = null;
        gvAll.DataBind();
    }

    protected void gvAll_DataBound(object sender, EventArgs e)
    {

    }
    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string jobno = string.Empty;
        string rowID = String.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string values, Trans_no, tbl_name, PR_type;
            values = this.gvAll.DataKeys[e.Row.RowIndex]["TRANS_ID"].ToString();
            Trans_no = this.gvAll.DataKeys[e.Row.RowIndex]["TRANS_NO"].ToString();
            tbl_name = this.gvAll.DataKeys[e.Row.RowIndex]["TRANS_TBL"].ToString();
            PR_type = this.gvAll.DataKeys[e.Row.RowIndex]["P_Type"].ToString();

            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            if (PR_type == "R")
            {
                if (tbl_name == "ACC_GST_BR_RECEIPT_ENTRY")
                {
                    e.Row.Attributes.Add("ondblclick", "open_Bank_N_RC_Receipt_Entry_Upd('" + values + "','" + Trans_no + "')");
                }
                else if (tbl_name == "ACC_GST_BR_OTHER_RECEIPT_ENTRY")
                {
                    e.Row.Attributes.Add("ondblclick", "open_Bank_N_RC_Receipt_Entry_Others_Upd('" + values + "','" + Trans_no + "')");
                }
                else if (tbl_name == "ACC_GST_BR_CASH_DEPOSITE_RECEIPT_ENTRY")
                {
                    e.Row.Attributes.Add("ondblclick", "open_Bank_N_RC_Receipt_Entry_Cash_Upd('" + values + "','" + Trans_no + "')");
                }
            }
            else if (PR_type == "P")
            {
                if (tbl_name == "ACC_GST_BP_PAYMENT_ENTRY_DEBITORS")
                {
                    e.Row.Attributes.Add("ondblclick", "open_Bank_N_RC_Payment_Entry_Upd('" + values + "','" + Trans_no + "')");
                }
                else if (tbl_name == "ACC_GST_BP_OTHER_PAYMENT_ENTRY")
                {
                    e.Row.Attributes.Add("ondblclick", "open_Bank_N_RC_Payment_Entry_Others_Upd('" + values + "','" + Trans_no + "')");
                }
                else if (tbl_name == "ACC_GST_PAYMENT_ENTRY_CASH_WITHDRAWAL")
                {
                    e.Row.Attributes.Add("ondblclick", "open_Bank_N_RC_Payment_Entry_Cash_Upd('" + values + "','" + Trans_no + "')");
                }
            }

        }
    }
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }
    private DataTable Item_details()
    {
        hd_error.Value = string.Empty;
        string TRANS_ID = string.Empty, TRANS_TBL = string.Empty, P_Type = string.Empty;
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("TRANS_ID", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("TRANS_NO", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("TRANS_TBL", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("PR_TYPE", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("REC_DATE", typeof(String)));

        int R = 1;

        foreach (GridViewRow row in gvAll.Rows)
        {
            CheckBox INV_CHECK = (CheckBox)row.FindControl("chk");
            TextBox txt_Rec_Date = (TextBox)row.FindControl("txt_Rec_Date");

            if (INV_CHECK.Checked == true && txt_Rec_Date.Text != string.Empty)
            {
                string date = string.Empty;
                string[] arr = new string[] { };
                Literal txt_trans_no = (Literal)row.FindControl("txt_trans_no");

                arr = txt_Rec_Date.Text.Split('/');
                date = arr[1] + '/' + arr[0] + '/' + arr[2];

                dr = dtt.NewRow();
                dr[0] = gvAll.DataKeys[row.RowIndex]["TRANS_ID"].ToString();
                dr[1] = txt_trans_no.Text;
                dr[2] = gvAll.DataKeys[row.RowIndex]["TRANS_TBL"].ToString();
                dr[3] = gvAll.DataKeys[row.RowIndex]["P_Type"].ToString();
                dr[4] = date;
                dtt.Rows.Add(dr);
            }
        }
        return dtt;
    }

    protected void btn_Recon_Click(object sender, EventArgs e)
    {
        if (ddl_Bank_Name.SelectedValue.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            DataTable dtt = new DataTable();
            dtt = Item_details();
            if (dtt.Rows.Count > 0)
            {
                ObjUBO.A52 = ConvertDataTableToXML(dtt);
                ObjUBO.A80 = "S";
                BR.Bank_Reconciliation_Ins_Upd(ObjUBO);
                Alert_msg("Reconciliation Saved Successfully.", "btn_Recon");
                btnSearch_Click(sender, e);

                /*
                 lbl_Bal_Per_Book_Amt
                 lbl_Non_Recon_Amt
                 lbl_Ins_not_Sys_Amt
                 lbl_Bal_Per_Bank
                 */
            }
            else
            {
                Alert_msg("Select Ur Data !", "btn_Recon");
            }
        }
        else
        {
            Alert_msg("Select Ur BankName !", "ddl_Bank_Name");
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
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Bank Reconciliation', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddl_Bank_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            lbl_Bal_Per_Book_Amt.Text = "0.00";
            lbl_Non_Recon_Amt.Text = "0.00";
            lbl_Ins_not_Sys_Amt.Text = "0.00";
            lbl_Bal_Per_Bank.Text = "0.00";
            if (ddl_Bank_Name.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.A1 = ddl_Bank_Name.SelectedValue.ToString();
                ObjUBO.A40 = "Recon_Amt_Select";
                ds = BR.Bank_Reconciliation_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_Bal_Per_Book_Amt.Text = ds.Tables[0].Rows[0]["AMT_INR"].ToString();
                }


            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
}