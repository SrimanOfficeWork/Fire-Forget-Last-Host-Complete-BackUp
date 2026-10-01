using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Services;

public partial class Bill_Inv_Copy : ThemeClass
{
    AppSession aps = new AppSession();
    Billing_Imp_Invoice BI = new Billing_Imp_Invoice();

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            Load_Inv_No();
        }
    }
    protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Select_Inv_Value();
    }

    private void Load_Inv_No()
    {
        ddlinvno.Items.Clear();
        DataSet ds = new DataSet();
        BI.Branch_Type = Connection.Get_Company_Type();
        BI.Mflag = "Imp_Billing_Invoice";
        ds = BI.Select_IMP_INV();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlinvno.DataSource = ds.Tables[0];
            ddlinvno.DataTextField = "BILL_INV_NO";
            ddlinvno.DataValueField = "BILL_INV_NO";
            ddlinvno.DataBind();
            ddlinvno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlinvno.SelectedIndex = 0;
        }
        else
        {
            ddlinvno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlinvno.SelectedIndex = 0;
        }
    }

    private void Select_Inv_Value()
    {
        if (ddlinvno.SelectedItem.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();

            BI.BILL_INV_NO=ddlinvno.SelectedItem.ToString();
            BI.JOBNO = ddlinvno.SelectedValue.ToString();
            
            BI.Branch_Type = Connection.Get_Company_Type();
            BI.COMPANY_LICENSE=Connection.Company_License();
            BI.Mflag = "Imp_Billing_Invoice_Value";

            ds = BI.Select_IMP_INV();

            if (ds.Tables[1].Rows.Count > 0)
            {
                txtjobno.Text = ds.Tables[1].Rows[0]["JOBNO"].ToString();
                txtfile_Ref_No.Text = ds.Tables[1].Rows[0]["FILE_REF_NO"].ToString();
                txt_inv_date.Text = ds.Tables[1].Rows[0]["BILL_INV_DATE"].ToString();
                txt_Imp_Name.Text = ds.Tables[1].Rows[0]["IMPORTER_NAME"].ToString();
                txt_Grand_Total.Text = ds.Tables[1].Rows[0]["Grand_tot"].ToString();
                txtDate.Text = ds.Tables[1].Rows[0]["Todate"].ToString();
            }
            else
            {
                txtjobno.Text = string.Empty;
                txtfile_Ref_No.Text = string.Empty;
                txt_inv_date.Text = string.Empty;
                txt_Imp_Name.Text = string.Empty;
                txt_Grand_Total.Text = string.Empty;
                txtDate.Text = string.Empty;

                ddlinvno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlinvno.SelectedIndex = 0;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtto_Inv_no.Text = ds.Tables[0].Rows[0]["Autoid"].ToString();
            }
            else
            {
                txtto_Inv_no.Text = string.Empty;

            }
        }
        else
        {
            txtjobno.Text = string.Empty;
            txtfile_Ref_No.Text = string.Empty;
            txt_inv_date.Text = string.Empty;
            txt_Imp_Name.Text = string.Empty;
            txt_Grand_Total.Text = string.Empty;
            txtto_Inv_no.Text = string.Empty;
            txtDate.Text = string.Empty;
        }
    }
    protected void btncopy_Click(object sender, EventArgs e)
    {
        if (ddlinvno.SelectedItem.Text != string.Empty)
        {
            DataSet ds = new DataSet();

            BI.BILL_INV_NO = ddlinvno.SelectedItem.ToString();
            BI.JOBNO = txtjobno.Text;
            BI.Branch_Type = Connection.Get_Company_Type();
            BI.Mflag = "Imp_Bill_Dup";
            BI.FROM_QUOTATION = Connection.Current_User();
            BI.Shipment_Type = txtto_Inv_no.Text;

            string[] arr = new string[] { };

            if (txtDate.Text != string.Empty && txtDate.Text != null)
            {
                arr = txtDate.Text.Split('/');
                BI.Branch = arr[1] + '/' + arr[0] + '/' + arr[2];
            }
            else
            {
                BI.Branch = "01/01/1900";
            }
            ds = BI.Select_IMP_INV();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Bill Duplicated Successfully.");
            }
            else
            {
                Alert_msg("Bill Not Duplicated");
            }

        }
        else
        {
            Alert_msg("Select Ur Invoice Number.");
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnnew_Click(object sender, EventArgs e)
    {
        txtjobno.Text = string.Empty;
        txtfile_Ref_No.Text = string.Empty;
        txt_inv_date.Text = string.Empty;
        txt_Imp_Name.Text = string.Empty;
        txt_Grand_Total.Text = string.Empty;
        txtto_Inv_no.Text = string.Empty;
        txtDate.Text = string.Empty;
        ddlinvno.SelectedIndex = -1;
    }
}