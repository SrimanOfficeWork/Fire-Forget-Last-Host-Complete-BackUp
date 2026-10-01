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
public partial class Vendor_Master : ThemeClass
{
    AppSession aps = new AppSession();
    Vendor_Master_cs BI = new Vendor_Master_cs();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public int i;
    public string currentuser;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            if (!Page.IsPostBack)
            {
                Load_Under();
                ObjUBO.ENAME = "VOURCHERID";
                ViewState["RowNumber"] = 1;
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                dt.Columns.Add(new DataColumn("BR_SL_NO", typeof(string)));
                dt.Columns.Add(new DataColumn("BR_CODE_LOCATION", typeof(string)));

                dt.Columns.Add(new DataColumn("BR_ADDRESS1", typeof(string)));
                dt.Columns.Add(new DataColumn("BR_ADDRESS2", typeof(string)));
                dt.Columns.Add(new DataColumn("BR_COUNTRY_NAME", typeof(string)));
                dt.Columns.Add(new DataColumn("BR_GSTIN_NO", typeof(string)));

                dt.Columns.Add(new DataColumn("BR_STATE", typeof(string)));
                dt.Columns.Add(new DataColumn("BR_PIN_CODE", typeof(string)));
                dt.Columns.Add(new DataColumn("BR_CONTACT_PERSON_NAME", typeof(string)));
                dt.Columns.Add(new DataColumn("BR_MOBILE_NO", typeof(string)));
                dt.Columns.Add(new DataColumn("BR_EMAIL_ID", typeof(string)));
                dt.Columns.Add(new DataColumn("ACTIVE_YES_NO", typeof(string)));
                dt.Rows.Add(dr);
                dr["ACTIVE_YES_NO"] = new ListItem("YES");
                dr["BR_SL_NO"] = ViewState["RowNumber"].ToString();
                ViewState["CurrentTable"] = dt;
                gvdetails.DataSource = dt;
                gvdetails.DataBind();

                if (Request.QueryString["Page"] == null)
                {
                    btnNew.Visible = false;
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btn.Visible = false;
                }
                else
                {
                    if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                    {
                        Update_Item_Load();

                        btnNew.Visible = false;
                        btnDelete.Visible = false;
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btn.Visible = false;
                        txtVendorName.Enabled = false;
                    }
                }
               
            }
            if (ddlTDSYesNo.SelectedValue == "YES")
            {
                txt_TDS_Rate.Enabled = true;
                ddlTDS_Section.Enabled = true;
            }
            else
            {
                txt_TDS_Rate.Enabled = false;
                ddlTDS_Section.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Load_Under()
    {
        try
        {
            DataSet dss = new DataSet();
            ddlUnder.Items.Clear();
            ObjUBO.ENAME = "Under_Select";
            dss = BI.VendorMaster(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlUnder.DataSource = dss.Tables[0];
                ddlUnder.DataTextField = "SUB_GROUP_NAME";
                ddlUnder.DataValueField = "SUB_GROUP_NAME";
                ddlUnder.DataBind();
            }
            ddlUnder.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlUnder.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void txtgFileRefNo_TextChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        GridViewRow currentRow = ((GridViewRow)((TextBox)sender).NamingContainer);
    }
    protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("add"))
        {
            AddNewRow();
        }
    }
    private void AddNewRow()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                int Slno = 1;
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    Label labgSLNo = (Label)gvdetails.Rows[rowIndex].Cells[0].FindControl("labgSLNo");
                    TextBox txtBranchLoc = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtBranchLoc");
                    TextBox txtAddress1 = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtAddress1");
                    TextBox txtAddress2 = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtAddress2");
                    TextBox txtCountryBranchName = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtCountryBranchName");
                    TextBox txtGSTNumber = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtGSTNumber");
                    TextBox txtState = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtState");
                    TextBox txtPinCode = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtPinCode");
                    TextBox txtContactName = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtContactName");
                    TextBox txtMobileNo = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtMobileNo");
                    TextBox txtEmail = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtEmail");
                    DropDownList ddlBRActiveYesNo = (DropDownList)gvdetails.Rows[rowIndex].Cells[11].FindControl("ddlBRActiveYesNo");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ACTIVE_YES_NO"] = new ListItem("YES");

                    dtCurrentTable.Rows[i - 1]["BR_SL_NO"] = Slno; // txtgSLNo.Text;
                    dtCurrentTable.Rows[i - 1]["BR_CODE_LOCATION"] = txtBranchLoc.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS1"] = txtAddress1.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS2"] = txtAddress2.Text;
                    dtCurrentTable.Rows[i - 1]["BR_COUNTRY_NAME"] = txtCountryBranchName.Text;
                    dtCurrentTable.Rows[i - 1]["BR_GSTIN_NO"] = txtGSTNumber.Text;
                    dtCurrentTable.Rows[i - 1]["BR_STATE"] = txtState.Text;
                    dtCurrentTable.Rows[i - 1]["BR_PIN_CODE"] = txtPinCode.Text;
                    dtCurrentTable.Rows[i - 1]["BR_CONTACT_PERSON_NAME"] = txtContactName.Text;
                    dtCurrentTable.Rows[i - 1]["BR_MOBILE_NO"] = txtMobileNo.Text;
                    dtCurrentTable.Rows[i - 1]["BR_EMAIL_ID"] = txtEmail.Text;
                    dtCurrentTable.Rows[i - 1]["ACTIVE_YES_NO"] = ddlBRActiveYesNo.SelectedValue;
                    rowIndex++;
                    Slno++;
                }
                int index = gvdetails.Rows.Count - 1;
                drCurrentRow["BR_SL_NO"] = Slno;
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                gvdetails.DataSource = dtCurrentTable;
                gvdetails.DataBind();

                TextBox txtBranchLocLast = (TextBox)gvdetails.Rows[index + 1].Cells[1].FindControl("txtBranchLoc");
                txtBranchLocLast.Focus();
                int index1 = gvdetails.Rows.Count - 1;
            }
        }
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
                    Label labgSLNo = (Label)gvdetails.Rows[rowIndex].Cells[0].FindControl("labgSLNo");
                    TextBox txtBranchLoc = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtBranchLoc");
                    TextBox txtAddress1 = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtAddress1");
                    TextBox txtAddress2 = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtAddress2");
                    TextBox txtCountryBranchName = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtCountryBranchName");
                    TextBox txtGSTNumber = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtGSTNumber");
                    TextBox txtState = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtState");
                    TextBox txtPinCode = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtPinCode");
                    TextBox txtContactName = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtContactName");
                    TextBox txtMobileNo = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtMobileNo");
                    TextBox txtEmail = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtEmail");
                    DropDownList ddlBRActiveYesNo = (DropDownList)gvdetails.Rows[rowIndex].Cells[11].FindControl("ddlBRActiveYesNo");

                    labgSLNo.Text = dt.Rows[i]["BR_SL_NO"].ToString();
                    txtBranchLoc.Text = dt.Rows[i]["BR_CODE_LOCATION"].ToString();
                    txtAddress1.Text = dt.Rows[i]["BR_ADDRESS1"].ToString();
                    txtAddress2.Text = dt.Rows[i]["BR_ADDRESS2"].ToString();
                    txtCountryBranchName.Text = dt.Rows[i]["BR_COUNTRY_NAME"].ToString();
                    txtGSTNumber.Text = dt.Rows[i]["BR_GSTIN_NO"].ToString();
                    txtState.Text = dt.Rows[i]["BR_STATE"].ToString();
                    txtPinCode.Text = dt.Rows[i]["BR_PIN_CODE"].ToString();
                    txtContactName.Text = dt.Rows[i]["BR_CONTACT_PERSON_NAME"].ToString();
                    txtMobileNo.Text = dt.Rows[i]["BR_MOBILE_NO"].ToString();
                    txtEmail.Text = dt.Rows[i]["BR_EMAIL_ID"].ToString();
                    ddlBRActiveYesNo.SelectedValue = dt.Rows[i]["ACTIVE_YES_NO"].ToString();
                    rowIndex++;
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ObjUBO.VENDOR_ID = HDN_VEN_ID.Value;
        ObjUBO.VENDOR_CODE = txtVendorCode.Text;
        ObjUBO.VENDOR_NAME = txtVendorName.Text;
        ObjUBO.TAX_TYPE = ddlTaxType.SelectedValue.ToString();
        ObjUBO.TAX_TYPE_ITC = ddlTaxTypeITC.SelectedValue.ToString();
        ObjUBO.PAN_NO = txtPANNo.Text;
        ObjUBO.TAN_NO = txtTANNo.Text;
        ObjUBO.CIN_NO = txtCINNo.Text;
        ObjUBO.TDS_YES_NO = ddlTDSYesNo.SelectedValue.ToString();
        ObjUBO.EXEMPTION_YES_NO = ddlExemptionYesNo.SelectedValue.ToString();
        ObjUBO.CERTIFICATE_NO = txtCertificateNo.Text;
        ObjUBO.VALID_FROM = txt_Valid_From_date.Text;
        ObjUBO.VALID_TO = txt_Valid_To_date.Text;
        ObjUBO.CREDIT_DAYS = txtCreditDays.Text;
        ObjUBO.CREDIT_LIMITS = txtCreditLimits.Text;
        ObjUBO.OPENING_BALANCE = txtOpeningBalance.Text;
        ObjUBO.REGISTERED_VENDOR_YES_NO = ddlRegisteredYesNo.SelectedValue.ToString();
        ObjUBO.FOREIGN_VENDOR_YES_NO = ddlForeignYesNo.SelectedValue.ToString();
        ObjUBO.COUNTRY_NAME = txtCountryName.Text;
        ObjUBO.ACTIVE_YES_NO = ddlActiveYesNo.SelectedValue.ToString();
        ObjUBO.NARRATION = txtNarration.Text;
        ObjUBO.EXEMPTION_VALUE = txtExemptionValue.Text;
        ObjUBO.charge_name = ddlUnder.SelectedValue.ToString();
        //gridtodt();
        ObjUBO.XML_DETAIL = ConvertDataTableToXML(gridtodt());
        ObjUBO.TDS_SECTION = ddlTDS_Section.SelectedValue;
        ObjUBO.TDS_RATE = txt_TDS_Rate.Text;
        ObjUBO.ENAME = "INSERT";
        ds = BI.VendorMaster(ObjUBO);
        if (BI.result == 1)
        {
            string cleanMessage = "Saved Successfully".Replace("'", "\'");
            Page page = HttpContext.Current.CurrentHandler as Page;
            string script = string.Format("alert('{0}');", cleanMessage);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
            }
        }
        else
        {
            Alert_msg("Not Saved");
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ObjUBO.VENDOR_ID = HDN_VEN_ID.Value;
        ObjUBO.VENDOR_CODE = txtVendorCode.Text;
        ObjUBO.VENDOR_NAME = txtVendorName.Text;
        ObjUBO.TAX_TYPE = ddlTaxType.SelectedValue.ToString();
        ObjUBO.TAX_TYPE_ITC = ddlTaxTypeITC.SelectedValue.ToString();
        ObjUBO.PAN_NO = txtPANNo.Text;
        ObjUBO.TAN_NO = txtTANNo.Text;
        ObjUBO.CIN_NO = txtCINNo.Text;
        ObjUBO.TDS_YES_NO = ddlTDSYesNo.SelectedValue.ToString();
        ObjUBO.EXEMPTION_YES_NO = ddlExemptionYesNo.SelectedValue.ToString();
        ObjUBO.CERTIFICATE_NO = txtCertificateNo.Text;
        ObjUBO.VALID_FROM = txt_Valid_From_date.Text;
        ObjUBO.VALID_TO = txt_Valid_To_date.Text;
        ObjUBO.CREDIT_DAYS = txtCreditDays.Text;
        ObjUBO.CREDIT_LIMITS = txtCreditLimits.Text;
        ObjUBO.OPENING_BALANCE = txtOpeningBalance.Text;
        ObjUBO.REGISTERED_VENDOR_YES_NO = ddlRegisteredYesNo.SelectedValue.ToString();
        ObjUBO.FOREIGN_VENDOR_YES_NO = ddlForeignYesNo.SelectedValue.ToString();
        ObjUBO.COUNTRY_NAME = txtCountryName.Text;
        ObjUBO.ACTIVE_YES_NO = ddlActiveYesNo.SelectedValue.ToString();
        ObjUBO.NARRATION = txtNarration.Text;
        ObjUBO.EXEMPTION_VALUE = txtExemptionValue.Text;
        ObjUBO.charge_name = ddlUnder.SelectedValue.ToString();
        ObjUBO.TDS_SECTION = ddlTDS_Section.SelectedValue;
        ObjUBO.TDS_RATE = txt_TDS_Rate.Text;
        // gridtodt();
        ObjUBO.XML_DETAIL = ConvertDataTableToXML(gridtodt());
        ObjUBO.ENAME = "UPDATE";
        ds = BI.VendorMaster(ObjUBO);
        if (BI.result == 1)
        {
            string cleanMessage = "Updated Successfully".Replace("'", "\'");
            Page page = HttpContext.Current.CurrentHandler as Page;
            string script = string.Format("alert('{0}');", cleanMessage);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
            }
        }
        else
        {
            Alert_msg("Not Updated");
        }

    }
    private void Repeat_Staus()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.VENDOR_NAME = txtVendorName.Text;
            ObjUBO.ENAME = "SELECT_NAME_ONLY";
            dss = BI.VendorMaster(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                string Vendor_Details;
                Vendor_Details = "Vendor Name: " + dss.Tables[0].Rows[0]["VEN_NAME"].ToString() + "  Already Exists in Vendor Code: " + dss.Tables[0].Rows[0]["VEN_CODE"].ToString();
                Alert_msg(Vendor_Details);
                txtVendorName.Text = "";
                txtVendorName.Focus();
            }
            else
            {

            }
            dss.Dispose();
            GC.Collect();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private DataTable gridtodt()
    {
        DataTable dt = new DataTable();
        if (gvdetails.Rows.Count != 0)
        {
            for (int i = 0; i < gvdetails.HeaderRow.Cells.Count - 1; i++)
            {
                dt.Columns.Add(gvdetails.HeaderRow.Cells[i].Text);
            }

            foreach (GridViewRow row in gvdetails.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (j == 0)
                    {
                        Label labgSLNo = row.FindControl("labgSLNo") as Label;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = labgSLNo.Text;
                    }
                    else if (j == 1)
                    {
                        TextBox txtBranchLoc = row.FindControl("txtBranchLoc") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtBranchLoc.Text;
                    }
                    else if (j == 2)
                    {
                        TextBox txtAddress1 = row.FindControl("txtAddress1") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtAddress1.Text;
                    }
                    else if (j == 3)
                    {
                        TextBox txtAddress2 = row.FindControl("txtAddress2") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtAddress2.Text;
                    }
                    else if (j == 4)
                    {
                        TextBox txtCountryBranchName = row.FindControl("txtCountryBranchName") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtCountryBranchName.Text;
                    }
                    else if (j == 5)
                    {
                        TextBox txtGSTNumber = row.FindControl("txtGSTNumber") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtGSTNumber.Text;

                    }
                    else if (j == 6)
                    {
                        TextBox txtState = row.FindControl("txtState") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtState.Text;
                    }
                    else if (j == 7)
                    {
                        TextBox txtPinCode = row.FindControl("txtPinCode") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtPinCode.Text;
                    }
                    else if (j == 8)
                    {
                        TextBox txtContactName = row.FindControl("txtContactName") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtContactName.Text;
                    }
                    else if (j == 9)
                    {
                        TextBox txtMobileNo = row.FindControl("txtMobileNo") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtMobileNo.Text;
                    }
                    else if (j == 10)
                    {
                        TextBox txtEmail = row.FindControl("txtEmail") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtEmail.Text;
                    }
                    else if (j == 11)
                    {
                        DropDownList ddlBRActiveYesNo = row.FindControl("ddlBRActiveYesNo") as DropDownList;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = ddlBRActiveYesNo.SelectedValue;

                    }

                }
                dt.Rows.Add(dr);
            }

        }
        return dt;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Vendor Master', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
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

    private void Update_Item_Load()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.VENDOR_ID = Request.QueryString["page"].ToString();
            ObjUBO.VENDOR_CODE = Request.QueryString["PageVendorcode"].ToString();
            ObjUBO.ENAME = "SELECT_ALL";
            dss = BI.VendorMaster(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                HDN_VEN_ID.Value = dss.Tables[0].Rows[0]["VEN_ID"].ToString();
                txtVendorCode.Text = dss.Tables[0].Rows[0]["VEN_CODE"].ToString();
                txtVendorName.Text = dss.Tables[0].Rows[0]["VEN_NAME"].ToString();
                ObjUBO.USER_ID = dss.Tables[0].Rows[0]["USERID"].ToString();
                ObjUBO.EntryDt = dss.Tables[0].Rows[0]["ENTRYDT"].ToString();
                ObjUBO.Modified_UserID = currentuser;
                ObjUBO.ModifiedDt = DateTime.Now.ToString();
                ddlTaxType.Text = dss.Tables[0].Rows[0]["TAX_TYPE"].ToString();
                ddlTaxTypeITC.Text = dss.Tables[0].Rows[0]["TAX_TYPE_ITC"].ToString();
                ddlTDSYesNo.Text = dss.Tables[0].Rows[0]["TDS_YES_NO"].ToString();
                txtPANNo.Text = dss.Tables[0].Rows[0]["PAN_NO"].ToString();
                txtTANNo.Text = dss.Tables[0].Rows[0]["TAN_NO"].ToString();
                txtCINNo.Text = dss.Tables[0].Rows[0]["CIN_NO"].ToString();
                ddlExemptionYesNo.Text = dss.Tables[0].Rows[0]["EXEMPTION_YES_NO"].ToString();
                txtCertificateNo.Text = dss.Tables[0].Rows[0]["CERTIFICATE_NO"].ToString();
                txt_Valid_From_date.Text = dss.Tables[0].Rows[0]["VALID_FROM"].ToString();
                txt_Valid_To_date.Text = dss.Tables[0].Rows[0]["VALID_TO"].ToString();
                txtCreditDays.Text = dss.Tables[0].Rows[0]["CREDIT_DAYS"].ToString();
                txtCreditLimits.Text = dss.Tables[0].Rows[0]["CREDIT_LIMITS"].ToString();
                txtOpeningBalance.Text = dss.Tables[0].Rows[0]["OPENING_BALANCE"].ToString();
                ddlRegisteredYesNo.Text = dss.Tables[0].Rows[0]["REGISTERED_VENDOR_YES_NO"].ToString();
                ddlForeignYesNo.Text = dss.Tables[0].Rows[0]["FOREIGN_VENDOR_YES_NO"].ToString();
                txtCountryName.Text = dss.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
                ddlActiveYesNo.Text = dss.Tables[0].Rows[0]["ACTIVE_YES_NO"].ToString();
                txtNarration.Text = dss.Tables[0].Rows[0]["NARRATION"].ToString();
                txtExemptionValue.Text = dss.Tables[0].Rows[0]["EXEMPTION_VALUE"].ToString();
                ddlUnder.SelectedValue = dss.Tables[0].Rows[0]["UNDER_NAME"].ToString();
                ddlTDS_Section.SelectedValue = dss.Tables[0].Rows[0]["TDS_SECTION"].ToString();
                txt_TDS_Rate.Text = dss.Tables[0].Rows[0]["TDS_RATE"].ToString();
            }
            ViewState["CurrentTable"] = dss.Tables[1];

            if (dss.Tables[1].Rows.Count > 0)
            {
                gvdetails.DataSource = dss.Tables[1];
                gvdetails.DataBind();
            }
            dss.Dispose();
            GC.Collect();
        }


        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void SetRowData()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                int Slno = 1;
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    Label labgSLNo = (Label)gvdetails.Rows[rowIndex].Cells[0].FindControl("labgSLNo");
                    TextBox txtBranchLoc = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtBranchLoc");
                    TextBox txtAddress1 = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtAddress1");
                    TextBox txtAddress2 = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtAddress2");
                    TextBox txtCountryBranchName = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtCountryBranchName");
                    TextBox txtGSTNumber = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtGSTNumber");
                    TextBox txtState = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtState");
                    TextBox txtPinCode = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtPinCode");
                    TextBox txtContactName = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtContactName");
                    TextBox txtMobileNo = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtMobileNo");
                    TextBox txtEmail = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtEmail");
                    DropDownList ddlBRActiveYesNo = (DropDownList)gvdetails.Rows[rowIndex].Cells[11].FindControl("ddlBRActiveYesNo");

                    ////////////
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ACTIVE_YES_NO"] = new ListItem("YES");
                    dtCurrentTable.Rows[i - 1]["BR_SL_NO"] = Slno;
                    dtCurrentTable.Rows[i - 1]["BR_CODE_LOCATION"] = txtBranchLoc.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS1"] = txtAddress1.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS2"] = txtAddress2.Text;
                    dtCurrentTable.Rows[i - 1]["BR_COUNTRY_NAME"] = txtCountryBranchName.Text;
                    dtCurrentTable.Rows[i - 1]["BR_GSTIN_NO"] = txtGSTNumber.Text;
                    dtCurrentTable.Rows[i - 1]["BR_STATE"] = txtState.Text;
                    dtCurrentTable.Rows[i - 1]["BR_PIN_CODE"] = txtPinCode.Text;
                    dtCurrentTable.Rows[i - 1]["BR_CONTACT_PERSON_NAME"] = txtContactName.Text;
                    dtCurrentTable.Rows[i - 1]["BR_MOBILE_NO"] = txtMobileNo.Text;
                    dtCurrentTable.Rows[i - 1]["BR_EMAIL_ID"] = txtEmail.Text;
                    dtCurrentTable.Rows[i - 1]["ACTIVE_YES_NO"] = ddlBRActiveYesNo.SelectedValue;
                    Slno++;
                    rowIndex++;
                }

                ViewState["CurrentTable"] = dtCurrentTable;
            }
        }
    }
    protected void gvdetails_RowDeleting(object sender, CommandEventArgs e)
    {

        SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                for (int i = 0; i <= gvdetails.Rows.Count - 1; i++)
                {
                    gvdetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                }
            }
        }
        SetGridRunningNo();
    }
    private void SetGridRunningNo()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                int Slno = 1;
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    Label labgSLNo = (Label)gvdetails.Rows[rowIndex].Cells[0].FindControl("labgSLNo");
                    TextBox txtBranchLoc = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtBranchLoc");

                    TextBox txtAddress1 = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtAddress1");
                    TextBox txtAddress2 = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtAddress2");

                    TextBox txtCountryBranchName = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtCountryBranchName");
                    TextBox txtGSTNumber = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtGSTNumber");
                    TextBox txtState = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtState");
                    TextBox txtPinCode = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtPinCode");
                    TextBox txtContactName = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtContactName");
                    TextBox txtMobileNo = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtMobileNo");
                    TextBox txtEmail = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtEmail");

                    DropDownList ddlBRActiveYesNo = (DropDownList)gvdetails.Rows[rowIndex].Cells[11].FindControl("ddlBRActiveYesNo");
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["ACTIVE_YES_NO"] = new ListItem("YES");
                    dtCurrentTable.Rows[i - 1]["BR_SL_NO"] = Slno; // txtgSLNo.Text;
                    dtCurrentTable.Rows[i - 1]["BR_CODE_LOCATION"] = txtBranchLoc.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS1"] = txtAddress1.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS2"] = txtAddress2.Text;
                    dtCurrentTable.Rows[i - 1]["BR_COUNTRY_NAME"] = txtCountryBranchName.Text;
                    dtCurrentTable.Rows[i - 1]["BR_GSTIN_NO"] = txtGSTNumber.Text;
                    dtCurrentTable.Rows[i - 1]["BR_STATE"] = txtState.Text;
                    dtCurrentTable.Rows[i - 1]["BR_PIN_CODE"] = txtPinCode.Text;
                    dtCurrentTable.Rows[i - 1]["BR_CONTACT_PERSON_NAME"] = txtContactName.Text;
                    dtCurrentTable.Rows[i - 1]["BR_MOBILE_NO"] = txtMobileNo.Text;
                    dtCurrentTable.Rows[i - 1]["BR_EMAIL_ID"] = txtEmail.Text;
                    dtCurrentTable.Rows[i - 1]["ACTIVE_YES_NO"] = ddlBRActiveYesNo.SelectedValue;
                    rowIndex++;
                    Slno++;
                }

                int index = gvdetails.Rows.Count - 1;
                drCurrentRow["BR_SL_NO"] = Slno;
                ViewState["CurrentTable"] = dtCurrentTable;
                gvdetails.DataSource = dtCurrentTable;
                gvdetails.DataBind();

                TextBox txtBranchLocLast = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtBranchLoc");
                txtBranchLocLast.Focus();
                int index1 = gvdetails.Rows.Count - 1;
            }
        }
    }

    protected void txtVendorName_TextChanged(object sender, EventArgs e)
    {
    }
    [System.Web.Services.WebMethod]
    public static string VendorName_RepeatStatus_webmethod(string mail, string b, string c, string d)
    {
        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt = new DataTable();
        IList<string> result = new List<string>();

        string TempVendorName = mail;
        string ReturnStrMore = "";
        try
        {
            Billing_UserBO ObjUBO = new Billing_UserBO();
            Vendor_Master_cs BI = new Vendor_Master_cs();
            DataSet dss = new DataSet();
            ObjUBO.VENDOR_NAME = TempVendorName;
            ObjUBO.ENAME = "SELECT_NAME_ONLY";
            dss = BI.VendorMaster(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                string Vendor_Details;
                Vendor_Details = "Vendor Name: " + dss.Tables[0].Rows[0]["VEN_NAME"].ToString() + "  Already Exists in Vendor Code: " + dss.Tables[0].Rows[0]["VEN_CODE"].ToString();
                ReturnStrMore = Vendor_Details;
            }
            else
            {

            }
            dss.Dispose();
            GC.Collect();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ReturnStrMore;
    }
}