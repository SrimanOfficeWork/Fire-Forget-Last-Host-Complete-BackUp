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
using System.Linq;

public partial class Export_Acc_Convert_Invoice : ThemeClass
{
    Cha_Accounts Chrg = new Cha_Accounts();
    Global_variables ObjUBO = new Global_variables();
    GST_Sales_Entry_cs BP = new GST_Sales_Entry_cs();
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    public string EXPORT_JOBNO, ID, JOBNO_PS;
    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
        JOBNO_PS = Session["JOBNO_PS"].ToString();

        if (!IsPostBack)
        {
            Load_Inv();
            load_Bank_Name();
            Gridbind();
            
        }
    }
    private void load_Bank_Name()
    {
        try
        {
            ddlbank_name.Items.Clear();
            DataSet dss = new DataSet();
            ObjUBO.A40 = "BankName_Select";
            dss = BP.Select_Inv(ObjUBO, Get_Con_String());
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlbank_name.DataSource = dss.Tables[0];
                ddlbank_name.DataTextField = "BANK_NAME";
                ddlbank_name.DataValueField = "BANK_AC_NO";
                ddlbank_name.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private string Get_Con_String()
    {
        DataSet ds = new DataSet();
        string Con_wrk = string.Empty;
        ObjUBO.A292 = Connection.Company_License();
        ObjUBO.A299 = Connection.WorkingPeriod();
        ObjUBO.A300 = "DB_Name_Select";
        ds = BP.Db_Connection(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Con_wrk = ds.Tables[0].Rows[0][1].ToString();
        }
        return Con_wrk;
    }
    private void Load_Inv()
    {
        DataSet ss = new DataSet();
        ObjUBO.A40 = "Get_Inv_No";
        ss = BP.Select_Inv(ObjUBO);
        if (ss.Tables[0].Rows.Count > 0)
        {
            txtInvoice_No.Text = ss.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            txtInvoiceDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    public void Gridbind()
    {
        ObjUBO.A2 = EXPORT_JOBNO;
        ObjUBO.A15 = "select_not_converted_inv";
        gv_details.DataSource = Chrg.charge_Data_Search(ObjUBO);
        gv_details.DataBind();
    }

    private void CONVERT_INSERT()
    {
        DataSet ss = new DataSet();
        ObjUBO.A101 = txtInvoice_No.Text;
        ObjUBO.A102 = "E";
        ObjUBO.A103 = EXPORT_JOBNO;
        ObjUBO.A104 = JOBNO_PS;
        ObjUBO.A124 = "Select_Exp_Job_Data";
        ObjUBO.A105 = ddlbank_name.SelectedItem.Text;
        ObjUBO.A106 = ddlbank_name.SelectedValue;
        ss = Chrg.Convert_Inv_Ins_Upd(ObjUBO);

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            var checkedValues = gv_details.Rows.Cast<GridViewRow>()
             .Where(row => ((CheckBox)row.FindControl("chkSelect")).Checked)
             .Select(row => row.Cells[3].Text.ToString()).ToList();
            HiddenField_index.Value = string.Join(",", checkedValues);
            if (HiddenField_index.Value != "")
            {
                ObjUBO.A70 = "UPDATE_INV";
                ObjUBO.A27 = txtInvoice_No.Text;
                ObjUBO.A28 = txtInvoiceDate.Text;
                ObjUBO.A29 = HiddenField_index.Value;
                ObjUBO.A2 = EXPORT_JOBNO;
                ObjUBO.A6 = "E";
                ds = Chrg.Charge_Ins_Upd(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv_details.DataSource = ds.Tables[0];
                }
                else
                {
                    gv_details.DataSource = dt;
                }
                gv_details.DataBind();

                int i = Chrg.result;
                if (i == 1)
                {
                    Alert_msg("Created Successfully", "Convert Invoice");
                    CONVERT_INSERT();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Open", "javascript:Getbtn_Charge()", true);
                    Load_Inv();
                }
                else
                {
                    Alert_msg("Not Created", "Convert Invoice");
                }
            }
            else
            {
                Alert_msg("Select Ur Chrages", "Convert Invoice");
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (hdn_Grid_Disable.Value == "1")
            {
                e.Row.Enabled = false;
            }
            else
            {
                e.Row.Enabled = true;

                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_details, "Select$" + e.Row.RowIndex.ToString()));

            }

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

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GENERAL', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
}