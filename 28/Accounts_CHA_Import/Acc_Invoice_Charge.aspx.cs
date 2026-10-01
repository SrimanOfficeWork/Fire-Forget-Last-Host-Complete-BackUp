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
using System.Linq;
public partial class Export_Acc_Invoice_Charge : ThemeClass
{
    Cha_Accounts Chrg = new Cha_Accounts();
    Global_variables ObjUBO = new Global_variables();
    AppSession aps = new AppSession();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    public string IMPORT_JOBNO, BILL_ID, JOBNO_PS;
    public int i;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            HiddenField_ImportJobNo.Value = IMPORT_JOBNO;
            JOBNO_PS = Session["JOBNO_PS"].ToString();
            HDupdate_IMP_EXP_id.Value = "I";
            if (!IsPostBack)
            {
                btn_EInvoice.Visible = false;
                btnrpt.Visible = false;
                btnUpdate.Visible = false;
                Gridbind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Gridbind()
    {
        DataSet dss = new DataSet();
        ObjUBO.A2 = IMPORT_JOBNO;
        ObjUBO.A15 = "Inv_select_conwithcode";
        ObjUBO.A8 = "I";
        dss = Chrg.charge_Data_Search(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            gv_details.DataSource = dss.Tables[0];
            gv_details.DataBind();
            if (dss.Tables[0].Rows.Count == 1)
            {
                gv_details.SelectedIndex = 0;
                EventArgs args = new EventArgs();
                gv_details_SelectedIndexChanged(gv_details, args);
            }
        }
        else
        {
            gv_details.DataSource = dt;
            gv_details.DataBind();
        }
    }
    public void Acc_Chrg_Ins_Upd(string Flag)
    {
        DataSet ds = new DataSet();
        ObjUBO.A2 = IMPORT_JOBNO;
        ObjUBO.A36 = Hdn_Inv.Value;
        ObjUBO.A27 = txtInvoiceNo.Text;
        ObjUBO.A30 = Session["JOBNO_PS"].ToString();
        ObjUBO.A31 = Rdb_reg_cess.SelectedValue;
        ObjUBO.A32 = Rdb_Transport_Bill.SelectedValue;
        ObjUBO.A33 = Rd_Job_Status.SelectedValue;
        ObjUBO.A6 = "I";
        if (Acc_Connection.Billing_Aproval_Company() == "Y")
        {
            if (Acc_Connection.Billing_Aproval_Admin() == "Y")
            {
                ObjUBO.A34 = Rd_Inv_Status.SelectedValue.ToString();
            }
            else
            {
                ObjUBO.A34 = "UA";
            }
        }
        else
        {
            ObjUBO.A34 = Rd_Inv_Status.SelectedValue.ToString();
        }
        ObjUBO.A70 = Flag;
        DataSet ds1 = new DataSet();
        ds1 = Chrg.Charge_Ins_Upd(ObjUBO);
        gv_details.DataSource = ds1;
        gv_details.DataBind();
        if (ds1.Tables[1].Rows[0]["JOB_STATUS"].ToString() == "C")
        {
            Bill_Admin.Visible = true;
            if (ds1.Tables[1].Rows[0]["UNAPPROVAL_APPROVED"].ToString() == "A")
            {
                btn_EInvoice.Visible = true;
            }
            else
            {
                btn_EInvoice.Visible = false;
            }
        }
        else
        {
            Bill_Admin.Visible = false;
            btn_EInvoice.Visible = false;
        }

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            btnUpdate.Visible = false;
            btnUpdate.CssClass = "updates";
            ViewState["UPDATED_ID"] = null;
           // Chrg.ResetFields(Page.Controls);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void Rd_Inv_Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GST_Sales_Entry_cs BP = new GST_Sales_Entry_cs();
            DataSet d = new DataSet();
            if (HDupdate_id.Value.ToString() != string.Empty && HDupdate_id.Value.ToString() != null)
            {
                ObjUBO.A4 = txtInvoiceNo.Text;
                ObjUBO.A12 = HDupdate_id.Value.ToString();
                ObjUBO.A16 = Rd_Inv_Status.SelectedValue.ToString();
                ObjUBO.A40 = "Invoice_Approve";
                d = BP.Select_Inv(ObjUBO);
                if (Rd_Inv_Status.SelectedValue.ToString() == "UA")
                {
                    Rd_Job_Status.SelectedValue = "P";
                    Bill_Admin.Visible = false;
                    if (d.Tables[0].Rows.Count > 0)
                    {
                        Hdn_Inv.Value = txtInvoiceNo.Text;
                        txtInvoiceNo.Text = d.Tables[0].Rows[0][0].ToString();
                        txtInvoiceNo.Text = d.Tables[0].Rows[0][0].ToString();
                        LBL_InvoiceNo.Text = d.Tables[0].Rows[0][0].ToString();
                        string flag = "UPDATE_INVOICENO";
                        Acc_Chrg_Ins_Upd(flag);
                        btnUpdate.Visible = true;
                    }
                    Alert_msg("Unapproval Successfully", "Rd_Inv_Status");
                }
                else
                {
                    if (d.Tables[0].Rows.Count > 0)
                    {
                        Hdn_Inv.Value = txtInvoiceNo.Text;
                        txtInvoiceNo.Text = d.Tables[0].Rows[0][0].ToString();
                        LBL_InvoiceNo.Text = d.Tables[0].Rows[0][0].ToString();
                        string flag = "UPDATE_INVOICENO";
                        Acc_Chrg_Ins_Upd(flag);
                        btnUpdate.Visible = false;
                    }
                    Alert_msg("Approved Successfully", "Rd_Inv_Status");
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
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
                    Bill_Admin.Visible = true;
                    if (Approve_Status == "A")
                    {
                        btnUpdate.Enabled = false;
                        btnUpdate.ToolTip = "Can't be Modified";
                    }
                }
            }
            else
            {
                if (Approve_Status == "A")
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "Can't be Modified";
                }
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        try
        {
            string id = ViewState["Inv_NO"].ToString();
            string F = "UPDATE_INVOICE_CHARGE";
            Acc_Chrg_Ins_Upd(F);
            i = Chrg.result;
            if (i == 1)
            {
                Billing_Approve(Rd_Job_Status.SelectedValue.ToString(), Rd_Inv_Status.SelectedValue.ToString());
                Alert_msg("Charge Updated Successfully", "btnUpdate");
                btnUpdate.Visible = true;
            }
            else
            {
                Alert_msg("Charge  Not Saved", "btnUpdate");

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    protected void gv_details_SelectedIndexChanged(object sender, EventArgs e)
    {

        ViewState["JOBNO"] = Convert.ToString(this.gv_details.SelectedDataKey.Value);
        ViewState["Inv_NO"] = Convert.ToString(this.gv_details.SelectedRow.Cells[2].Text);
        ViewState["ID"] = Convert.ToString(this.gv_details.SelectedRow.Cells[10].Text);
        if (ViewState["JOBNO"] != "" && ViewState["JOBNO"] != null)
        {
            txtInvoiceNo.Text = gv_details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            LBL_InvoiceNo.Text = gv_details.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string a = gv_details.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            if (a == "R")
            {
                Rdb_reg_cess.SelectedIndex = 0;
            }
            else
            {
                Rdb_reg_cess.SelectedIndex = 1;
            }

            string value = gv_details.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txtgrand_tot.Text = gv_details.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            if (value == "Y")
            {
                Rdb_Transport_Bill.SelectedIndex = 1;
            }
            else
            {
                Rdb_Transport_Bill.SelectedIndex = 0;
            }

            string Pen_St = gv_details.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            if (Pen_St == "P")
            {
                Rd_Job_Status.SelectedIndex = 0;
            }
            else
            {
                Rd_Job_Status.SelectedIndex = 1;
            }

            string inv_St = gv_details.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            if (inv_St == "UA")
            {
                Rd_Inv_Status.SelectedIndex = 0;
            }
            else
            {
                Rd_Inv_Status.SelectedIndex = 1;
            }
            string INV_STATUS = gv_details.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            if (Pen_St == "C")
            {
                Bill_Admin.Visible = true;

                if (inv_St == "A" && INV_STATUS == "NOT GENERATED")
                {
                    btn_EInvoice.Visible = true;
                    btnUpdate.Visible = false;
                    lbl_Inv_Status.Text = "";
                    Rd_Inv_Status.Enabled = true;
                    Rd_Job_Status.Enabled = true;
                }
                else if (inv_St == "UA" && INV_STATUS == "NOT GENERATED")
                {
                    btn_EInvoice.Visible = false;
                    btnUpdate.Visible = true;
                    lbl_Inv_Status.Text = "";
                    Rd_Inv_Status.Enabled = true;
                    Rd_Job_Status.Enabled = true;
                }
                else
                {
                    lbl_Inv_Status.Text = "E-Invoice Generated";
                    btn_EInvoice.Visible = false;
                    btnUpdate.Visible = false;
                    Rd_Inv_Status.Enabled = false;
                    Rd_Job_Status.Enabled = false;

                }
            }
            else
            {
                Bill_Admin.Visible = false;
                btn_EInvoice.Visible = false;
                btnUpdate.Visible = true;
                lbl_Inv_Status.Text = "";
                Rd_Inv_Status.Enabled = true;
                Rd_Job_Status.Enabled = true;
            }


            HDupdate_id.Value = ViewState["ID"].ToString();
            ViewState["Inv_NO"].ToString();
            btnUpdate.CssClass = "updates";
            btnrpt.Visible = true;
        }
        else
        {
            btnrpt.Visible = false;
            btnUpdate.Visible = false;
        }
    }
    protected void btn_EInvoice_Click(object sender, EventArgs e)
    {

        ObjUBO.A9 = txtInvoiceNo.Text;
        ObjUBO.A15 = "Select_E_Invoice_Details";
        DataSet ds = Chrg.charge_Data_Search(ObjUBO);
        string alertMessage = "";


        if (ds.Tables[0].Rows.Count > 0)
        {
            string Bill_No = ds.Tables[0].Rows[0]["BILL_INV_NO"].ToString();
            string tax_amt = ds.Tables[0].Rows[0]["TAX_AMT"].ToString();
            string Non_Tax = ds.Tables[0].Rows[0]["NON_TAX_AMT"].ToString();
            string Total_Amt = ds.Tables[0].Rows[0]["TOTAL_AMT"].ToString();
            string cgst_Amt = ds.Tables[0].Rows[0]["CGST_AMT"].ToString();
            string sgst_amt = ds.Tables[0].Rows[0]["SGST_AMT"].ToString();
            string Igst_Amt = ds.Tables[0].Rows[0]["IGST_AMT"].ToString();
            string Total_Inv_val = ds.Tables[0].Rows[0]["TotInvVal"].ToString();
            string Bill_To = ds.Tables[0].Rows[0]["local"].ToString();

            string lineWidth = "20%";
            alertMessage = "<table style='width:100%;'>" +
      "<tr><td style='width:37%;'>Invoice No</td><td style='text-align:left;'>: <span style='color: red;'>" + Bill_No +
      "</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='color: black;'>Bill To: </span><span style='color: #8E4585;'>" + Bill_To + "</span></td></tr>" +
      "<tr><td style='width:37%;'>Tax Amt</td><td style='text-align:left;'>: <span style='color: #191970;'>" + tax_amt + "</span></td></tr>" +
      "<tr><td style='width:37%;'>Non Tax Amt</td><td style='text-align:left;'>: <span style='color: #191970;'>" + Non_Tax + "</span></td></tr>" +
      "<tr><td colspan='2' style='text-align:center;'><hr style='width: " + lineWidth + "; margin: auto;'/></td></tr>" +
      "<tr><td style='width:37%;'>Total Amt</td><td style='text-align:left;'>: <span style='color: #800020;'>" + Total_Amt + "</span></td></tr>" +
      "<tr><td colspan='2' style='text-align:center;'><hr style='width: " + lineWidth + "; margin: auto;'/></td></tr>" +
      "<tr><td style='width:37%;'>CGST</td><td style='text-align:left;'>: <span style='color: green;'>" + cgst_Amt + "</span></td></tr>" +
      "<tr><td style='width:37%;'>SGST</td><td style='text-align:left;'>: <span style='color: green;'>" + sgst_amt + "</span></td></tr>" +
      "<tr><td style='width:37%;'>IGST</td><td style='text-align:left;'>: <span style='color: #4B0082;'>" + Igst_Amt + "</span></td></tr>" +
      "<tr><td colspan='2' style='text-align:center;'><hr style='width: " + lineWidth + "; margin: auto;'/></td></tr>" +
      "<tr><td style='width:37%;'>Grand Total</td><td style='text-align:left;'>: <span style='color: blue;'>" + Total_Inv_val + "</span></td></tr>" +
      "<tr><td colspan='2' style='text-align:center;'><hr style='width: " + lineWidth + "; margin: auto;'/></td></tr>" +
      "</table>" +
      "<span>Do you want to proceed with generating the e-invoice?</span>";

        }
        Alert_Einvoice(alertMessage);

    }
    public void Alert_Einvoice(string msg)
    {
        int buttonWidth = 50, buttonHeight = 5, dialogWidth = 445, dialogHeight = 325;
        string buttonId = Btn_Generate_Inv.ClientID;
        string prompt = "<script>" +
    "$(document).ready(function() {" +
    "$('<div></div>').dialog({" +
    "modal: true," +
    "title: 'E-Invoice Charges'," +
    "width: " + dialogWidth + "," +
    "height: " + dialogHeight + "," +
    "buttons: {" +
    "'OK': function() {" +
    "$(this).dialog('close');" +
    "setTimeout(function() {" +
    "document.getElementById('" + buttonId + "').click();" +
    "}, 0);" +
    "}," +
    "'Cancel': function() {" +
    "$(this).dialog('close');" +
    "}" +
    "}," +
    "open: function() {" +
    "$(this).html('" + msg.Replace("'", "\\'").Replace("\n", "\\n") + "');" +
    "$(this).dialog('option', 'position', { my: 'center', at: 'center', of: window });" +
    "$(this).css({'overflow': 'hidden'}); " +
    "}," +
    "create: function() {" +
    "$(this).parent().find('.ui-dialog-buttonpane button').css({" +
    "'width': '" + buttonWidth + "px'," +
    "'height': '" + buttonHeight + "px'," +
    "'padding': '1px 1px', " +
    "'margin': '2px' " +
    "});" +
    "}" +
    "});" +
    "});" +
    "</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btn_Generate_EInvoice_Click(object sender, EventArgs e)
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

        Sales_Inv_Json_cs SJ = new Sales_Inv_Json_cs();
        DataSet ds = new DataSet();
        ds = SJ.Data_Json(HDupdate_id.Value.ToString(), txtInvoiceNo.Text);

        if (ds.Tables[2].Rows.Count > 0)
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    TAX = ds.Tables[1].Rows[0]["TAX"].ToString();
                    IGSTOTRA = ds.Tables[1].Rows[0]["IGSTOTRA"].ToString();

                    Imp_Gen = "{" + @"""" + "einvoiceusername" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["GSTNID"].ToString() + @"""" +
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
                              @"""" + "Typ" + @"""" + ":" + @"""" + "INV" + @"""" +
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
                    System.IO.File.WriteAllText(filepath + "Inv_" + txtInvoiceNo.Text.Replace('/', '_') + ".JSON", jsonOut);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();

                    //SubmitInvoice(jsonOut, txtInvoiceNo.Text);
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
        string Imp_Exp = "I";

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
                    Sales_Inv_Json_cs SJ = new Sales_Inv_Json_cs();

                    string errorFolder = "";
                    errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/ACC_GST_BILL_QRCODE/" + Imp_Exp + "/");

                    if (Directory.Exists(errorFolder) == false)
                    {
                        Directory.CreateDirectory(errorFolder);
                    }
                    ObjUBO.A201 = "";
                    ObjUBO.A202 = "I";
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
                    //ObjUBO.A213 = ddlWorkingPeriod.SelectedValue.ToString();
                    ObjUBO.A213 = Connection.WorkingPeriod();
                    ObjUBO.A214 = "S";
                    dss = SJ.E_Invoice_Ins_Upd(ObjUBO);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        if (dss.Tables[0].Rows[0]["Outval"].ToString() == "S")
                        {
                            Alert_msg("E-Invoice Generated Successfully.");
                            btn_EInvoice.Visible = false;
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
                 "," + @"""" + "OrdLineRef" + @"""" + ":" + @"""" + "" + @"""" +
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


    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate_Invoice_Cur(string custid)
    {
        if (custid.Length == 3)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
            Auto.Enamesearch = custid;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                //custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString() + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " ";
                custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();

            }
            else
            {
                Auto.Ename = "NON_STD_CUR_RATE_EXPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {


                    string NON_STD_RATE_EXPORT = ds.Tables[0].Rows[0]["NON_STD_RATE_EXPORT"].ToString();
                    string NON_STD_EFFECT_DT_EXP = ds.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString();
                    string NON_STD_BANKNAME = ds.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                    string NON_STD_CERTIFICATE_NO = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                    string NON_STD_CERTIFICATE_DATE = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString();

                    custid = NON_STD_RATE_EXPORT + "~~" + NON_STD_EFFECT_DT_EXP + "~~" + NON_STD_BANKNAME + "~~" + NON_STD_CERTIFICATE_NO + "~~" + NON_STD_CERTIFICATE_DATE;
                }
                else

                    custid = "";
            }
        }
        else
        {
            custid = "";
        }
        return custid;
    }

}