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


public partial class GST_Imp_Invoice_No_Edit : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE,COMPANY_LICENSE;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!IsPostBack)
        {
            load_INV();
            Load_Type();
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//
        }
      
    }
    private void load_INV()
    {
        try
        {
            ddlinv_no.Items.Clear();
            DataSet dss = new DataSet();
            ObjUBO.Flag = "Imp_Invoice_No_Edit";
            dss = BI.Select_IMP_INV(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlinv_no.DataSource = dss.Tables[0];
                ddlinv_no.DataTextField = "BILL_INV_NO";
                ddlinv_no.DataValueField = "ID";
                ddlinv_no.DataBind();
            }
            ddlinv_no.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlinv_no.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Next_No()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.BILL_INV_NO = ddlinv_no.SelectedItem.ToString();
            ObjUBO.Flag = "GST_IMP_Max_Id_Edit";
            dss = BI.Select_IMP_INV(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                txt_InvoiceNo_New.Text = dss.Tables[0].Rows[0][0].ToString();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void ddlinv_no_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlinv_no.SelectedItem.ToString() != string.Empty)
        {
            DataSet ds = new DataSet();
            ObjUBO.BILL_INV_NO = ddlinv_no.SelectedItem.ToString();
            ObjUBO.JOBNO = ddlinv_no.SelectedValue.ToString();
            ObjUBO.Flag = "Inv_Edit_data";
            ds = BI.Select_IMP_INV(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_InvoiceNo_New.Text = ds.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
                lbl_from_date.Text = ds.Tables[0].Rows[0]["BILL_INV_DATE"].ToString();
                txt_to_Inv_Date.Text = lbl_from_date.Text;
                lblImp_name.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                lblCreatedby.Text = ds.Tables[0].Rows[0]["CREATEDBY"].ToString();
            }
            else
            {
                txt_InvoiceNo_New.Text = "";
                lbl_from_date.Text = "";
                txt_to_Inv_Date.Text = lbl_from_date.Text;
                lblCreatedby.Text = "";
            }
        }
        else
        {
            lblImp_name.Text = "";
            txt_InvoiceNo_New.Text = "";
            lbl_from_date.Text = "";
            txt_to_Inv_Date.Text = lbl_from_date.Text;
            lblCreatedby.Text = "";
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (ddlinv_no.SelectedValue.ToString() != string.Empty)
        {
            if (ddl_Convert_to.SelectedValue.ToString() == "I_NO")
            {
                if (txt_InvoiceNo_New.Text != string.Empty)
                {
                    ObjUBO.BILL_INV_NO = txt_InvoiceNo_New.Text;
                    load_Refresh_Data();
                }
                else
                {
                    Alert_msg("Enter Ur Invoice No !", "txt_InvoiceNo_New");
                }
            }
            else if (ddl_Convert_to.SelectedValue.ToString() == "I_DT")
            {

                if (txt_to_Inv_Date.Text != string.Empty)
                {

                    string[] arr = new string[] { };
                    if (txt_to_Inv_Date.Text != string.Empty && txt_to_Inv_Date.Text != null)
                    {
                        arr = txt_to_Inv_Date.Text.Split('/');
                        ObjUBO.FROM_QUOTATION = arr[1] + '/' + arr[0] + '/' + arr[2]; //inv_To_date
                    }
                    else
                    {
                        ObjUBO.FROM_QUOTATION = "";   //inv_To_date
                    }
                    load_Refresh_Data();

                }
                else
                {
                    Alert_msg("Enter Ur Invoice Date !", "txt_to_Inv_Date");
                }
            }
            else if (ddl_Convert_to.SelectedValue.ToString() == "I_DU")
            {
                if (txt_InvoiceNo_New.Text != string.Empty)
                {
                    ObjUBO.BILL_INV_NO = txt_InvoiceNo_New.Text;
                    load_Refresh_Data();
                }
                else
                {
                    Alert_msg("Enter Ur Invoice No !", "txt_InvoiceNo_New");
                }
            }
            else if (ddl_Convert_to.SelectedValue.ToString() == "I_ST")
            {

                ObjUBO.Ass_Value = Rd_Bill_Type.SelectedValue.ToString();
                load_Refresh_Data();
            }
        }
        else
        {
            Alert_msg("Select  Ur Invoice No !", "ddlinv_no");
        }
    }


    private void load_Refresh_Data()
    {
        DataSet dss = new DataSet();
        ObjUBO.SHIPMENT_TYPE = ddlinv_no.SelectedItem.ToString(); //inv_no
        ObjUBO.JOBNO = ddlinv_no.SelectedValue.ToString(); //inv_id
        ObjUBO.MODE = ddl_Convert_to.SelectedValue.ToString();  //inv_convert_Cat
        ObjUBO.CIF_VALUE = Connection.Current_User();
        ObjUBO.Flag = "Update_GST_Imp_Inv_no";
        dss = BI.Select_IMP_INV(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlinv_no.Items.Clear();
            ddlinv_no.DataSource = dss.Tables[0];
            ddlinv_no.DataTextField = "BILL_INV_NO";
            ddlinv_no.DataValueField = "ID";
            ddlinv_no.DataBind();

            ddlinv_no.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlinv_no.SelectedIndex = 0;

            ddl_Convert_to.SelectedIndex = -1;
            txt_InvoiceNo_New.Text = string.Empty;
            txt_to_Inv_Date.Text = string.Empty;


            lblImp_name.Text = "";
            lbl_from_date.Text = "";
            lblCreatedby.Text = "";

            txt_InvoiceNo_New.Text = "";
            txt_to_Inv_Date.Text = "";

            Alert_msg("Update Successfully", "txtInvoiceNo");
        }
        else
        {
            Alert_msg("Invoice Not Updated", "txtInvoiceNo");
        }
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Import Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void ddl_Convert_to_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlinv_no.SelectedValue.ToString() != string.Empty)
        {
            if (ddl_Convert_to.SelectedValue.ToString() == "I_NO")
            {
                txt_InvoiceNo_New.Enabled = true;
                txt_to_Inv_Date.Enabled = false;
                Rd_Bill_Type.Enabled = false;
            }
            else if (ddl_Convert_to.SelectedValue.ToString() == "I_DT")
            {
                txt_InvoiceNo_New.Enabled = false;
                txt_to_Inv_Date.Enabled = true;
                Rd_Bill_Type.Enabled = false;
            }
            else if (ddl_Convert_to.SelectedValue.ToString() == "I_DU")
            {
                
                txt_to_Inv_Date.Enabled = false;
                Rd_Bill_Type.Enabled = false;           

                txt_InvoiceNo_New.Text = "";  
                load_Next_No();
                if (Connection.COMPANYID() == "1120")
                {
                    txt_InvoiceNo_New.Enabled = false;
                }
                else {
                    txt_InvoiceNo_New.Enabled = true;
                }
                             
            }
            else if (ddl_Convert_to.SelectedValue.ToString() == "I_ST")
            {
                txt_InvoiceNo_New.Enabled = false;
                txt_to_Inv_Date.Enabled = false;
                Rd_Bill_Type.Enabled = true;
            }
        }
        else
        {
            txt_InvoiceNo_New.Enabled = true;
            txt_to_Inv_Date.Enabled = true;
            Rd_Bill_Type.Enabled = true;
            ddl_Convert_to.SelectedIndex = -1;
        }
    }
    private void Load_Type()
    {
        ddl_Convert_to.Items.Add(new ListItem(string.Empty, string.Empty));
        ddl_Convert_to.Items.Add(new ListItem("Inv.No. Modify", "I_NO"));
        ddl_Convert_to.Items.Add(new ListItem("Inv.Date. Modify", "I_DT"));
        ddl_Convert_to.Items.Add(new ListItem("Inv. Duplicate", "I_DU"));
        ddl_Convert_to.Items.Add(new ListItem("State Change", "I_ST"));
    }


}