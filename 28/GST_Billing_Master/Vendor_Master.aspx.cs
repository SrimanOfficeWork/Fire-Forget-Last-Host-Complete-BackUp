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

    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();
    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    public int i;
    public string COMPANY_LICENSE;

    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    
  
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            DataSet ds = new DataSet();
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            COMPANY_LICENSE = Connection.Company_License().ToLower();
            if (!Page.IsPostBack)
            {

                ObjUBO.ENAME = "VOURCHERID";
                //ds = BI.PurchaseEntry(ObjUBO);

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
                    GetAutono_Vendor_Entry();
                    ////if (COMPANY_LICENSE == "eri00247" || COMPANY_LICENSE == "eri00010")
                    ////{
                    ////    WK.Visible = true;
                    ////    LoadFinancialYear();
                    ////    ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();
                    ////}

                    //txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    //SetInitialRow();

                    btnNew.Visible = false;
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btn.Visible = false;                    
                    
                    //gv.Visible = false;

                    txtVendorName.Enabled = true;
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

                        ////ddltype.Enabled = false;
                        ////ddlSearch.Enabled = false;

                        ////btnNewRow.Visible = true;
                        ////btnSaveRow.Visible = true;
                        ////btnUpdateRow.Visible = false;
                        ////btnDeleteRow.Visible = false;

                        ////FileUpload1.Visible = false;
                        ////btnUploadRow.Visible = false;

                        ////chkImageFileRow.Visible = false;
                        ////lbtnImageFileRow.Visible = false;

                        txtVendorName.Enabled = false;

                    }
                }





            }





        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    

    private void GetAutono_Vendor_Entry()
    {
        DataSet ds = new DataSet();
        ObjUBO.Flag = "Generate-AutoNo";
        ObjUBO.BILL_TYPE = "Vendor-Entry";
        ds = BI.Load_DDL(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
           
           HDN_VEN_ID.Value = ds.Tables[0].Rows[0]["RUNNO"].ToString();
           txtVendorCode.Text = ds.Tables[0].Rows[0]["VENDOR_CODE"].ToString();
        }
        ds.Dispose();
        GC.Collect();
    }




    protected void txtgFileRefNo_TextChanged(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        GridViewRow currentRow = ((GridViewRow)((TextBox)sender).NamingContainer);

        //ObjUBO.ENAME = "CUST_NAME";
        //ObjUBO.VENDOR_NAME = Hdnfileref.Value;
        //ds = BI.PurchaseEntry(ObjUBO);
        //txtgCusName.Text = ds.Tables[0].Rows[0][0].ToString();


    }

    


    protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("add"))
        {
            AddNewRow();
            //Repeat_Staus();
        }
    }
    private void AddNewRow()
    {


        int rowIndex = 0;
        //decimal totalcredit = 0;
        //decimal totaldebit = 0;
        //decimal totalcgst = 0;
        //decimal totalsgst = 0;
        //decimal totaligst = 0;
        //decimal totaltds = 0;
        //decimal total = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                int Slno = 1;
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //TextBox txtgSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txtgSLNo");
                    Label     labgSLNo = (Label)gvdetails.Rows[rowIndex].Cells[0].FindControl("labgSLNo");
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
                    //drCurrentRow["ImpExp"] = new ListItem("Imp");

                    dtCurrentTable.Rows[i - 1]["BR_SL_NO"] = Slno; // txtgSLNo.Text;
                    dtCurrentTable.Rows[i - 1]["BR_CODE_LOCATION"] = txtBranchLoc.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS1"] = txtAddress1.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS2"] = txtAddress2.Text;
                    //dtCurrentTable.Rows[i - 1]["txtAddress2"] = drpgDrCr.SelectedValue;

                    //dtCurrentTable.Rows[i - 1]["ImpExp"] = drpgImpexp.SelectedValue;
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
                    //txtgSLNo.Focus();
                }


                int index = gvdetails.Rows.Count - 1;

                //TextBox txtgSLNolast = (TextBox)gvdetails.Rows[index + 1].Cells[0].FindControl("txtgSLNo");
                //txtgSLNolast.Focus();

                //drpgImpex.Focus();
                //drCurrentRow["SNo"] = Convert.ToInt32(txtsl.Text) + 1;
                drCurrentRow["BR_SL_NO"] = Slno;
               // drCurrentRow["Debit"] = Convert.ToDecimal(txtTotalamtininr.Text) - total;
                //ViewState["RowNumber"] = Convert.ToInt32(txtsl.Text) + 1;


                

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                gvdetails.DataSource = dtCurrentTable;
                gvdetails.DataBind();

                TextBox txtBranchLocLast = (TextBox)gvdetails.Rows[index + 1].Cells[1].FindControl("txtBranchLoc");
                txtBranchLocLast.Focus();


                //txtgSLNo.Focus();
                int index1 = gvdetails.Rows.Count - 1;
                ////gvdetails.Rows[index1].Cells[1].FindControl("txtgImpSLNo").Focus();
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

                    //TextBox txtgSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txtgSLNo");
                    Label  labgSLNo = (Label)gvdetails.Rows[rowIndex].Cells[0].FindControl("labgSLNo");
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
                    //TextBox ddlBRActiveYesNo = (TextBox)gvdetails.Rows[rowIndex].Cells[11].FindControl("ddlBRActiveYesNo");

                    DropDownList ddlBRActiveYesNo = (DropDownList)gvdetails.Rows[rowIndex].Cells[11].FindControl("ddlBRActiveYesNo");

                    //////////////////////////////////////////////////////////////////////
                    //txtgSLNo.Text = dt.Rows[i]["SNo"].ToString();
                    labgSLNo.Text = dt.Rows[i]["BR_SL_NO"].ToString();
                    txtBranchLoc.Text = dt.Rows[i]["BR_CODE_LOCATION"].ToString();
                    txtAddress1.Text = dt.Rows[i]["BR_ADDRESS1"].ToString();
                    txtAddress2.Text = dt.Rows[i]["BR_ADDRESS2"].ToString();
                    //drpgImpexp.SelectedValue = dt.Rows[i]["ImpExp"].ToString();
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
        //ObjUBO.VENDOR_ID
        //CalendarExtender1.EndDate = DateTime.Now;
        ObjUBO.VENDOR_ID = HDN_VEN_ID.Value;
        //ObjUBO.VENDOR_ID = "3";
        ObjUBO.VENDOR_CODE = txtVendorCode.Text;
        ObjUBO.VENDOR_NAME = txtVendorName.Text;
        ObjUBO.USER_ID = currentuser;
        ObjUBO.EntryDt = DateTime.Now.ToString(); 
	    ObjUBO.Modified_UserID="";
        ObjUBO.ModifiedDt = "";// DateTime.Now.ToString();
	    ObjUBO.TAX_TYPE=ddlTaxType.SelectedValue.ToString();
	    ObjUBO.TAX_TYPE_ITC=ddlTaxTypeITC.SelectedValue.ToString();
	    ObjUBO.PAN_NO=txtPANNo.Text;
	    ObjUBO.TAN_NO=txtTANNo.Text;
	    ObjUBO.CIN_NO=txtCINNo.Text;
	    ObjUBO.TDS_YES_NO=ddlTDSYesNo.SelectedValue.ToString();
        ObjUBO.EXEMPTION_YES_NO = ddlExemptionYesNo.SelectedValue.ToString();
	    ObjUBO.CERTIFICATE_NO=txtCertificateNo.Text;
	    ObjUBO.VALID_FROM=txt_Valid_From_date.Text;
	    ObjUBO.VALID_TO=txt_Valid_To_date.Text; 
	    ObjUBO.CREDIT_DAYS=txtCreditDays.Text;
	    ObjUBO.CREDIT_LIMITS=txtCreditLimits.Text;
	    ObjUBO.OPENING_BALANCE=txtOpeningBalance.Text;
	    ObjUBO.REGISTERED_VENDOR_YES_NO=ddlRegisteredYesNo.SelectedValue.ToString();
	    ObjUBO.FOREIGN_VENDOR_YES_NO=ddlForeignYesNo.SelectedValue.ToString();
	   // ObjUBO.COUNTRY_NAME=ddlCountryName.SelectedValue.ToString();
        ObjUBO.COUNTRY_NAME = txtCountryName.Text;
	    ObjUBO.ACTIVE_YES_NO=ddlActiveYesNo.SelectedValue.ToString();
        ObjUBO.NARRATION  = txtNarration.Text;
        ObjUBO.EXEMPTION_VALUE = txtExemptionValue.Text; 

        
        //ObjUBO.VENDOR_BRANCH = txtVendorbranch.Text;
        //ObjUBO.VENDOR_STATE = txtVendorstate.Text;
        //ObjUBO.GSTN = txtGstn.Text;
        //ObjUBO.GSTN_TYPE = txtGstntype.Text;
        //ObjUBO.COUNTRY = txtCountry.Text;
        //ObjUBO.VENDOR_BILL = txtVendorbillno.Text;
        //ObjUBO.BILL_DATE = "";
        //ObjUBO.BILL_AMOUNT = txtbillamount.Text;
        //ObjUBO.CURRENCY = txtInvoiceCurrency.Text;
        //ObjUBO.EX_RATE = txtExrate.Text;
        //ObjUBO.AMT_IN_INR = txtTotalamtininr.Text;
        //ObjUBO.NARRATION = txtNarration.Text;

        //ObjUBO.BRANCH_CODE = currentbranch;
        //ObjUBO.WORKING_PERIOD = Working_Period;
        gridtodt();
        ObjUBO.XML_DETAIL = ConvertDataTableToXML(gridtodt());
        ObjUBO.ENAME = "INSERT";
        ds = BI.VendorMaster(ObjUBO);
        if (BI.result == 1)
        {
            //Alert_msg("Saved Successfully.");
            //Response.Write("<script>alert('Saved Successfully.');</script>");
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Saved Successfully');", true);
            string cleanMessage = "Saved Successfully".Replace("'", "\'");
            Page page = HttpContext.Current.CurrentHandler as Page;
            string script = string.Format("alert('{0}');", cleanMessage);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
            }
        }
        else
        { Alert_msg("Not Saved"); 
        }


    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ObjUBO.VENDOR_ID = HDN_VEN_ID.Value;
        //ObjUBO.VENDOR_ID = "3";
        ObjUBO.VENDOR_CODE = txtVendorCode.Text;
        ObjUBO.VENDOR_NAME = txtVendorName.Text;
        ObjUBO.USER_ID = currentuser;
        ObjUBO.EntryDt = DateTime.Now.ToString();
        ObjUBO.Modified_UserID = currentuser;
        ObjUBO.ModifiedDt = DateTime.Now.ToString();
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
        //ObjUBO.COUNTRY_NAME = ddlCountryName.SelectedValue.ToString();
        ObjUBO.COUNTRY_NAME = txtCountryName.Text;
        ObjUBO.ACTIVE_YES_NO = ddlActiveYesNo.SelectedValue.ToString();
        ObjUBO.NARRATION = txtNarration.Text;
        ObjUBO.EXEMPTION_VALUE = txtExemptionValue.Text;
        
        gridtodt();
        ObjUBO.XML_DETAIL = ConvertDataTableToXML(gridtodt());
        ObjUBO.ENAME = "UPDATE";
        ds = BI.VendorMaster(ObjUBO);
        if (BI.result == 1)
        {
            //Alert_msg("Saved Successfully.");
            //Response.Write("<script>alert('Saved Successfully.');</script>");
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Saved Successfully');", true);
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
                //txtVendorCode.Text = dss.Tables[0].Rows[0]["VEN_CODE"].ToString();
                //txtVendorName.Text = dss.Tables[0].Rows[0]["VEN_NAME"].ToString();
                string Vendor_Details;
                Vendor_Details="Vendor Name: " + dss.Tables[0].Rows[0]["VEN_NAME"].ToString()  +  "  Already Exists in Vendor Code: " + dss.Tables[0].Rows[0]["VEN_CODE"].ToString() ;
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
                    //if (j != 5)
                    //{
                    //    dr[gvdetails.HeaderRow.Cells[j].Text] = row.Cells[j].Text;
                    //}
                    //else
                    //{
                    if (j == 0)
                    {
                        //TextBox txtgSLNo = row.FindControl("txtgSLNo") as TextBox;
                        //dr[gvdetails.HeaderRow.Cells[j].Text] = txtgSLNo.Text;
                        Label labgSLNo = row.FindControl("labgSLNo") as Label;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = labgSLNo.Text;
                        //dr[gvdetails.HeaderRow.Cells[j].Text] =

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
                        //DropDownList drpcdr = row.FindControl("drpDrcr") as DropDownList;
                        //dr[gvdetails.HeaderRow.Cells[j].Text] = drpcdr.SelectedValue;
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
                        //DropDownList drpimexp = row.FindControl("drpImpexp") as DropDownList;
                        //dr[gvdetails.HeaderRow.Cells[j].Text] = drpimexp.SelectedValue;
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
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, true);
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

            //DataSet dss = new DataSet();
            //ObjUBO.VOUCHER_NO = Request.QueryString["voucherno"].ToString();
            //ObjUBO.ENAME = "SELETG";
            //dss = BI.PurchaseEntry(ObjUBO);

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
                //ObjUBO.USER_ID = currentuser;
                //ObjUBO.EntryDt = DateTime.Now.ToString();
                //ObjUBO.Modified_UserID = "";
                //ObjUBO.ModifiedDt = DateTime.Now.ToString();

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
                //ddlCountryName.Text = dss.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
                txtCountryName.Text = dss.Tables[0].Rows[0]["COUNTRY_NAME"].ToString();
                ddlActiveYesNo.Text = dss.Tables[0].Rows[0]["ACTIVE_YES_NO"].ToString();
                txtNarration.Text = dss.Tables[0].Rows[0]["NARRATION"].ToString();
                txtExemptionValue.Text = dss.Tables[0].Rows[0]["EXEMPTION_VALUE"].ToString();



            }
            ViewState["CurrentTable"] = dss.Tables[1];

            if (dss.Tables[1].Rows.Count > 0)
            {
                //dss.Tables[1].Columns.Add(new DataColumn("SNo", typeof(string)));
                //dss.Tables[1].Columns.Add(new DataColumn("SNo", typeof(string)));
                //gvdetails.Visible = false;

                //gvbind.Visible = true;

                //drCurrentRow["SNo"] = Slno;

                gvdetails.DataSource = dss.Tables[1];
                gvdetails.DataBind();

            ////

            
            ////


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
                int Slno=1;
                for ( int i = 1; i <= dtCurrentTable.Rows.Count; i++)
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
                    //drCurrentRow["ImpExp"] = new ListItem("Imp");


                    //labgSLNo.Text = "" + Convert.ToString(i);
                    //labgSLNo = slno.ToString();
                    dtCurrentTable.Rows[i - 1]["BR_SL_NO"] = Slno;  //labgSLNo.Text; // txtgSLNo.Text;
                    dtCurrentTable.Rows[i - 1]["BR_CODE_LOCATION"] = txtBranchLoc.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS1"] = txtAddress1.Text;
                    dtCurrentTable.Rows[i - 1]["BR_ADDRESS2"] = txtAddress2.Text;
                    //dtCurrentTable.Rows[i - 1]["txtAddress2"] = drpgDrCr.SelectedValue;

                    //dtCurrentTable.Rows[i - 1]["ImpExp"] = drpgImpexp.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["BR_COUNTRY_NAME"] = txtCountryBranchName.Text;
                    dtCurrentTable.Rows[i - 1]["BR_GSTIN_NO"] = txtGSTNumber.Text;
                    dtCurrentTable.Rows[i - 1]["BR_STATE"] = txtState.Text;
                    dtCurrentTable.Rows[i - 1]["BR_PIN_CODE"] = txtPinCode.Text;


                    dtCurrentTable.Rows[i - 1]["BR_CONTACT_PERSON_NAME"] = txtContactName.Text;
                    dtCurrentTable.Rows[i - 1]["BR_MOBILE_NO"] = txtMobileNo.Text;
                    dtCurrentTable.Rows[i - 1]["BR_EMAIL_ID"] = txtEmail.Text;
                    dtCurrentTable.Rows[i - 1]["ACTIVE_YES_NO"] = ddlBRActiveYesNo.SelectedValue;


                    ////////////
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
                //TextBox txtfcredittotal = (TextBox)gvdetails.FooterRow.FindControl("txtcredittotal");
                //TextBox txtfdebittotal = (TextBox)gvdetails.FooterRow.FindControl("txtdebittotal");
                //TextBox txtfcgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtcgsttotal");
                //TextBox txtfsgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtsgsttotal");
                //TextBox txtfigsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtigsttotal");
                //TextBox txtftdstotal = (TextBox)gvdetails.FooterRow.FindControl("txttdstotal");
                //txtfcredittotal.Text = ViewState["credit"].ToString();
                //txtfdebittotal.Text = ViewState["debit"].ToString();
                //txtfcgsttotal.Text = ViewState["cgst"].ToString();
                //txtfsgsttotal.Text = ViewState["sgst"].ToString();
                //txtfigsttotal.Text = ViewState["igst"].ToString();
                //txtftdstotal.Text = ViewState["tdsamt"].ToString();

                for (int i = 0; i <= gvdetails.Rows.Count-1; i++)
                {
                    gvdetails.Rows[i].Cells[0].Text = Convert.ToString(i+1);
                }
                //SetPreviousData();
            }
        }
        //SetRowData();
        //AddNewRow();
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
                    //dtCurrentTable.Rows[i - 1]["txtAddress2"] = drpgDrCr.SelectedValue;

                    //dtCurrentTable.Rows[i - 1]["ImpExp"] = drpgImpexp.SelectedValue;
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




                //dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                gvdetails.DataSource = dtCurrentTable;
                gvdetails.DataBind();

                TextBox txtBranchLocLast = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtBranchLoc");
                txtBranchLocLast.Focus();

                //txtgSLNo.Focus();
                int index1 = gvdetails.Rows.Count - 1;
                ////gvdetails.Rows[index1].Cells[1].FindControl("txtgImpSLNo").Focus();
            }
        }
        //SetPreviousData();
    }

    protected void txtVendorName_TextChanged(object sender, EventArgs e)
    {
        //Repeat_Staus();
    }


    
    //public static string VendorName_RepeatStatus_webmethod(string mail, string TempRd_Job_Type, string Tempddlbranch_No, string TempddlCustomer)
    [System.Web.Services.WebMethod]
    public static string VendorName_RepeatStatus_webmethod(string mail,string b,string c, string d)
    {
        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt = new DataTable();
        IList<string> result = new List<string>();
        //int i = 0;
        
        string TempVendorName = mail;
        string  ReturnStrMore = "";
        try
        {
            Billing_UserBO ObjUBO = new Billing_UserBO();
            GST_Imp_Invoice BI = new GST_Imp_Invoice();
            DataSet dss = new DataSet();
            ObjUBO.VENDOR_NAME = TempVendorName;
            ObjUBO.ENAME = "SELECT_NAME_ONLY";
            dss = BI.VendorMaster(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                //txtVendorCode.Text = dss.Tables[0].Rows[0]["VEN_CODE"].ToString();
                //txtVendorName.Text = dss.Tables[0].Rows[0]["VEN_NAME"].ToString();
                string Vendor_Details;
                Vendor_Details = "Vendor Name: " + dss.Tables[0].Rows[0]["VEN_NAME"].ToString() + "  Already Exists in Vendor Code: " + dss.Tables[0].Rows[0]["VEN_CODE"].ToString();
                ReturnStrMore= Vendor_Details;
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
        //return result;
        return ReturnStrMore;
    }
}