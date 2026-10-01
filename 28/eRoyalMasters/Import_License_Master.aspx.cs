using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;


public partial class Import_License_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    eroyalmaster erm = new eroyalmaster();
    Imp_License_Master lic = new Imp_License_Master();
    adminmaster adm = new adminmaster();
    SqlConnection con;
    SqlCommand cmd;
    DataSet dtuser = new DataSet();
    AppSession aps = new AppSession();
    public string ADCODE_ID = "";
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public int i, Update_Id;
    public string AUTO_ID;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public int Screen_Id;
    public double Job_Remaing_Amt, Job_Remaing_Qty;
    public string SingleDutyY_N = "", click_SaveNew = "";
    public string License_ID, Name_Search;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            txt_PartyName.Focus();
            con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();

            if (!IsPostBack)
            {
                ddlBond_Type();
                //----------------SETTING SCREEN PERMISSION---------------//
                Screen_Id = 6;
                Page_Rights(Screen_Id);
                //----------------SETTING SCREEN PERMISSION---------------//
                //auto search


                Get_SchemeCode();

                EditSupDetails();

            }
            Get_Remaining_DEBIT_AMT();

            txt_LicenseCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txt_LicenseCurrency.ClientID + "', '" + txt_Exrate.ClientID + "')");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }


    public void Get_SchemeCode()
    {
        try
        {
            adm.SCHEME_IMPORT_CODE = "0";
            adm.SCHEME_NOTN = "0";
            adm.name = "SCHEME_IMPORT_CODE";

            adm.RetrieveAll_Scheme_Import();
            ddl_Lic_Type.DataSource = adm.ds.Tables[0];
            ddl_Lic_Type.DataTextField = "SCHEME_CODE";
            ddl_Lic_Type.DataValueField = "SCHEME_CODE";
            ddl_Lic_Type.DataBind();

            ddl_Lic_Type.Items.Insert(1, "PI-Project Imports");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message); 
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    public void Get_Remaining_DEBIT_AMT()
    {
        try
        {
            string single_YN = "";
            //erm.LICENSE_ID = "0";
            erm.LICENSE_ID = txt_License_ItemNo.Text;
            erm.LICENSE_NO = txtReg_No.Text;
            erm.LICENSE_ITEM_DESCRIPTION = txtReg_date.Text;
            erm.SCHEME_CODE = ddl_Lic_Type.SelectedItem.Text;
            if (chk_single_Duty.Checked == true)
            {
                single_YN = "Y";
            }
            else
            {
                single_YN = "N";
            }
            erm.LICENSE_ITEM_DESCRIPTION = single_YN;
            erm.Ename = "Get_Remaining_Debit_Amt";
            erm.EWorking_Period = Session["WorkingPeriod"].ToString();

            ds = erm.RetrieveAll_IMPORT_LICENSE_MASTER();

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["REMAINING_AMT"].ToString() != "")
                {
                    txt_Remaining_Amt.Text = ds.Tables[0].Rows[0]["REMAINING_AMT"].ToString();
                }
                else
                {
                    txt_Remaining_Amt.Text = txt_Debit_Amt.Text;
                }
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows[0]["REMAINING_QTY"].ToString() != "")
                {
                    txt_Remaining_Qty.Text = ds.Tables[1].Rows[0]["REMAINING_QTY"].ToString();
                }
                else
                {
                    txt_Remaining_Qty.Text = txtQty.Text;
                }
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                Job_Remaing_Amt = Convert.ToDouble(ds.Tables[2].Rows[0]["DEBIT_AMT"].ToString());
                ViewState["Job_Remaing_Amt"] = Job_Remaing_Amt;
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                Job_Remaing_Qty = Convert.ToDouble(ds.Tables[4].Rows[0]["DEBIT_QTY"].ToString());
                ViewState["Job_Remaing_Qty"] = Job_Remaing_Qty;
            }

            if (ds.Tables[6].Rows.Count > 0)
            {
                if (ds.Tables[6].Rows[0]["REMAINING_FC"].ToString() != "")
                {
                    txt_Remaining_FC.Text = ds.Tables[6].Rows[0]["REMAINING_FC"].ToString();
                }
                else
                {
                    txt_Remaining_FC.Text = txt_FCValue.Text;
                }
            }

            if (ds.Tables[7].Rows.Count > 0)
            {
                if (ds.Tables[7].Rows[0]["REMAINING_CIF"].ToString() != "")
                {
                    txt_Remaining_CIF.Text = ds.Tables[7].Rows[0]["REMAINING_CIF"].ToString();
                }
                else
                {
                    txt_Remaining_CIF.Text = txt_CIFValue.Text;
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }


    }
    public void Page_Rights(int i)
    {
        try
        {
            user_Create.RetrieveAll_User_Screen_Rights_Details(i);
            PAGE_WRITE = user_Create.PAGE_WRITE;
            PAGE_READ = user_Create.PAGE_READ;
            PAGE_MODIFY = user_Create.PAGE_MODIFY;
            PAGE_DELETE = user_Create.PAGE_DELETE;

            //---------------READ ONLY------------------//

            if (PAGE_READ == "False")
            {
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = false;
                btnNew.ToolTip = "You don't have permission to access";
                btnSave.ToolTip = "You don't have permission to access";
                btnUpdate.ToolTip = "You don't have permission to access";
                btnDelete.ToolTip = "You don't have permission to access";
            }
            else
            {
                //}
                //btnNew.Enabled = true;
                //---------------SAVE BUTTON------------------//
                if (PAGE_WRITE == "True")
                {
                    btnSave.Enabled = true;
                    btnNew.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                    btnSave.ToolTip = "You don't have permission to access";
                    btnNew.Enabled = false;
                }
                //---------------UPDATE BUTTON------------------//

                if (PAGE_MODIFY == "True")
                    btnUpdate.Enabled = true;
                else
                {
                    btnUpdate.Enabled = false;
                    btnUpdate.ToolTip = "You don't have permission to access";
                }
                //---------------DELETE BUTTON------------------//

                if (PAGE_DELETE == "True")
                    btnDelete.Enabled = true;
                else
                {
                    btnDelete.Enabled = false;
                    btnDelete.ToolTip = "You don't have permission to access";
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }

    public void EditSupDetails()
    {
        try
        {
            if (Request.QueryString["LICENSE_ID"] != "" && Request.QueryString["LICENSE_ID"] != null)
            {

                //txtLicense_No.Enabled = false;
                ADCODE_ID = Request.QueryString["LICENSE_ID"];

                erm.LICENSE_ID = ADCODE_ID;
                erm.LICENSE_NO = "0";
                erm.Ename = "select_conwithcode";
                erm.EWorking_Period = Working_Period;

                dtuser = erm.RetrieveAll_IMPORT_LICENSE_MASTER();

                if (dtuser.Tables[0].Rows.Count > 0)
                {

                    txtLicense_no.Text = dtuser.Tables[0].Rows[0]["LICENSE_NO"].ToString();
                    txtLicense_Date.Text = dtuser.Tables[0].Rows[0]["LICENSE_DATE"].ToString();
                    txtReg_No.Text = dtuser.Tables[0].Rows[0]["REGISTRATION_NO"].ToString();
                    txtReg_date.Text = dtuser.Tables[0].Rows[0]["REGISTRATION_DATE"].ToString();

                    string Excemption = dtuser.Tables[0].Rows[0]["EXCEMPTION"].ToString();
                    ddl_Excemption.Items.Clear();
                    ddl_Excemption.Items.Add("Y");
                    ddl_Excemption.Items.Add("N");
                    ddl_Excemption.Items.Add("E");
                    ddl_Excemption.Items.Remove(Excemption);
                    ddl_Excemption.Items.Insert(0, Excemption);

                    string Category_mode = dtuser.Tables[0].Rows[0]["LICENSE_TYPE"].ToString();
                    ddl_Lic_Type.Items.Clear();
                    Get_SchemeCode();
                    ddl_Lic_Type.Items.Remove(Category_mode);
                    ddl_Lic_Type.Items.Insert(0, Category_mode);

                    txt_Debit_Amt.Text = dtuser.Tables[0].Rows[0]["TOTAL_DEBIT_AMT"].ToString();
                    //txt_Remaining_Amt.Text = dtuser.Tables[0].Rows[0]["REMAINING_AMT"].ToString();
                    txtQty.Text = dtuser.Tables[0].Rows[0]["TOTAL_DEBIT_QTY"].ToString();
                    txtUnit.Text = dtuser.Tables[0].Rows[0]["UNIT_QTY"].ToString();
                    txt_License_ItemNo.Text = dtuser.Tables[0].Rows[0]["LICENSE_ITEM_NO"].ToString();
                    txtPort_Of_Licenses.Text = dtuser.Tables[0].Rows[0]["PORT_OF_LICENSE"].ToString();
                    txt_PartyName.Text = dtuser.Tables[0].Rows[0]["PARTY_NAME"].ToString();
                    txtLic_Desc.Text = dtuser.Tables[0].Rows[0]["LICENSE_DESC"].ToString();

                    if (dtuser.Tables[0].Rows[0]["SINGLE_DUTY_Y_N"].ToString() == "Y")
                    {
                        chk_single_Duty.Checked = true;
                    }
                    else
                    {
                        chk_single_Duty.Checked = false;
                    }

                    txt_FCValue.Text = dtuser.Tables[0].Rows[0]["TOTAL_FC_VALUE"].ToString();
                    txt_Remaining_FC.Text = dtuser.Tables[0].Rows[0]["REMAINING_FC"].ToString();
                    txt_Exrate.Text = dtuser.Tables[0].Rows[0]["EX_RATE"].ToString();
                    txt_CIFValue.Text = dtuser.Tables[0].Rows[0]["TOTAL_CIF_VALUE"].ToString();
                    txt_Remaining_CIF.Text = dtuser.Tables[0].Rows[0]["REMAINING_CIF"].ToString();
                    txt_LicenseCurrency.Text = dtuser.Tables[0].Rows[0]["LICENSE_CURRENCY"].ToString();

                    txt_BrokerName.Text = dtuser.Tables[0].Rows[0]["LICENSE_BROKER_NAME"].ToString();
                    txtTransferedTO.Text = dtuser.Tables[0].Rows[0]["LICENSE_TRANSFERED_TO"].ToString();
                    txtReceived_Date.Text = dtuser.Tables[0].Rows[0]["LICENSE_RECEIVED_DATE"].ToString();
                    txtBondNo.Text = dtuser.Tables[0].Rows[0]["BOND_NO"].ToString();
                    txtBond_date.Text = dtuser.Tables[0].Rows[0]["BOND_DATE"].ToString();
                    ddlBondType.Text = dtuser.Tables[0].Rows[0]["BOND_TYPE"].ToString();
                    txtLic_Exp_date.Text = dtuser.Tables[0].Rows[0]["LICENSE_EXPIRY_DATE"].ToString();
                    txtsur_date.Text = dtuser.Tables[0].Rows[0]["DATE_OF_SURRENDER"].ToString();
                    txt_PartNo.Text = dtuser.Tables[0].Rows[0]["PART_NO"].ToString();
                    txtBondLocation.Text = dtuser.Tables[0].Rows[0]["BOND_LOCATION"].ToString();

                    hdn_Update_Adcode.Value = txtLicense_no.Text;
                    //FOR UPDATED SUCCESSFULLY
                    ViewState["UPDATED_ID"] = null;
                    ViewState["UPDATED_ID"] = Request.QueryString["LICENSE_ID"].ToString();
                    //FOR UPDATED SUCCESSFULLY

                }

                HiddenField1.Value = Request.QueryString["LICENSE_ID"].ToString();
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
            }

            gridbind1();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }

    }


    protected void gvdetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow row = gvdetails.SelectedRow;
            ViewState["ID_TBL"] = Convert.ToString(this.gvdetails.SelectedDataKey.Value);

            if (row != null)
            {
                ViewState["ID_TBL"] = gvdetails.SelectedDataKey.Value.ToString();
                txtLicense_no.Text = row.Cells[2].Text.Replace("&nbsp;", "");
                txtLicense_Date.Text = row.Cells[3].Text.Replace("&nbsp;", "");
                txtReg_No.Text = row.Cells[0].Text.Replace("&nbsp;", "");
                txtReg_date.Text = row.Cells[1].Text.Replace("&nbsp;", "");

                string Excemption = row.Cells[4].Text.Replace("&nbsp;", "");
                ddl_Excemption.Items.Clear();
                ddl_Excemption.Items.Add("Y");
                ddl_Excemption.Items.Add("N");
                ddl_Excemption.Items.Add("E");
                ddl_Excemption.Items.Remove(Excemption);
                ddl_Excemption.Items.Insert(0, Excemption);

                string Category_mode = row.Cells[5].Text.Replace("&nbsp;", "");
                ddl_Lic_Type.Items.Clear();
                Get_SchemeCode();
                ddl_Lic_Type.Items.Remove(Category_mode);
                ddl_Lic_Type.Items.Insert(0, Category_mode);

                txt_Debit_Amt.Text = row.Cells[7].Text.Replace("&nbsp;", "");
                //txt_Remaining_Amt.Text = dtuser.Tables[0].Rows[0]["REMAINING_AMT"].ToString();
                txtQty.Text = row.Cells[8].Text.Replace("&nbsp;", "");
                txtUnit.Text = row.Cells[9].Text.Replace("&nbsp;", "");
                txt_License_ItemNo.Text = row.Cells[6].Text.Replace("&nbsp;", "");
                txtPort_Of_Licenses.Text = row.Cells[11].Text.Replace("&nbsp;", "");
                txt_PartyName.Text = row.Cells[10].Text.Replace("&nbsp;", "");
                txtLic_Desc.Text = row.Cells[12].Text.Replace("&nbsp;", "");

                if (row.Cells[13].Text.Replace("&nbsp;", "").ToString() == "Y")
                {
                    chk_single_Duty.Checked = true;
                }
                else
                {
                    chk_single_Duty.Checked = false;
                }

                txt_FCValue.Text = row.Cells[14].Text.Replace("&nbsp;", "");
                txt_Remaining_FC.Text = row.Cells[15].Text.Replace("&nbsp;", "");
                txt_Exrate.Text = row.Cells[16].Text.Replace("&nbsp;", "");
                txt_CIFValue.Text = row.Cells[17].Text.Replace("&nbsp;", "");
                txt_Remaining_CIF.Text = row.Cells[18].Text.Replace("&nbsp;", "");
                txt_LicenseCurrency.Text = row.Cells[19].Text.Replace("&nbsp;", "");

                txt_BrokerName.Text = row.Cells[20].Text.Replace("&nbsp;", "");
                txtTransferedTO.Text = row.Cells[21].Text.Replace("&nbsp;", "");
                txtReceived_Date.Text = row.Cells[22].Text.Replace("&nbsp;", "");

                txtBondNo.Text = row.Cells[23].Text.Replace("&nbsp;", "");
                txtBond_date.Text = row.Cells[24].Text.Replace("&nbsp;", "");
                //ddlBondType.Text = row.Cells[25].Text.Replace("&nbsp;", "");
                string bondType = row.Cells[25].Text.Replace("&nbsp;", "").Trim();

                if (!string.IsNullOrEmpty(bondType) && ddlBondType.Items.FindByText(bondType) != null)
                {
                    ddlBondType.SelectedValue = bondType;
                }
                else
                {
                    ddlBondType.ClearSelection();
                }
                txtLic_Exp_date.Text = row.Cells[28].Text.Replace("&nbsp;", "");
                txtsur_date.Text = row.Cells[26].Text.Replace("&nbsp;", "");
                txt_PartNo.Text = row.Cells[27].Text.Replace("&nbsp;", "");
                txtBondLocation.Text = row.Cells[29].Text.Replace("&nbsp;", "");

                hdn_Update_Adcode.Value = txtLicense_no.Text;

                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnNew.Visible = true;

                //  hdn_update_Bond.Value = ViewState["ID_TBL"].ToString();
                // HiddenField1.Value = Request.QueryString["LICENSE_ID"].ToString();
                HiddenField1.Value = ViewState["ID_TBL"].ToString();
            }
            else
            {
                HiddenField1.Value = Request.QueryString["LICENSE_ID"].ToString();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnNew.Visible = true;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }




    public void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Remaining_Qty.Text == "")
            {
                txt_Remaining_Qty.Text = "0.00";
            }
            if (txt_Remaining_Amt.Text == "")
            {
                txt_Remaining_Amt.Text = "0.00";
            }
            if (txt_Debit_Amt.Text != "")
            {
                if ((Convert.ToDouble(txt_Debit_Amt.Text)) >= (Convert.ToDouble(txt_Remaining_Amt.Text)))
                {
                    if (ddl_Lic_Type.SelectedItem.Text != "36-MEIS" && ddl_Lic_Type.SelectedItem.Text != "31-SHIS" && ddl_Lic_Type.SelectedItem.Text != "28-FPS" && ddl_Lic_Type.SelectedItem.Text != "27-FMS" && ddl_Lic_Type.SelectedItem.Text != "RD-RoDTEP Scheme" && ddl_Lic_Type.SelectedItem.Text != "RS-ROSCTL Scheme" && ddl_Lic_Type.SelectedItem.Text != "91-MEIS eCom")
                    {
                        if (txtQty.Text != "")
                        {
                            if ((Convert.ToDouble(txtQty.Text)) >= (Convert.ToDouble(txt_Remaining_Qty.Text)))
                            {
                                Inner_InsertUpdate("", "S");
                            }
                            else
                            {
                                Alert_msg("Todal Debit Qty is lesser than Remaining Qty");
                            }
                        }
                        else
                        {
                            Alert_msg("Qty can not be null");
                            txtQty.Focus();
                        }
                    }
                    else
                    {
                        Inner_InsertUpdate("", "S");
                    }

                }
                else
                {
                    Alert_msg("Todal Debit Amt is lesser than Remaining Amt");
                }
            }
            else
            {
                Alert_msg("Total Debit Duty - can not be null");
                txt_Debit_Amt.Focus();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    public void Inner_InsertUpdate(string a1, string a2)
    {
        try
        {
            string a3 = "";
            i = insert_update(a1, a2, a3);
            HiddenField1.Value = Convert.ToString(lic.UPDATE_ID);

            if (a2 == "S")
            {
                if (i == 1)
                {
                    if (click_SaveNew == "SaveNew_Click")
                    {
                        txt_License_ItemNo.Focus();
                    }
                    else
                    {
                        btnUpdate.CssClass = "save";
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        Alert_msg("Saved Successfully", "btnSave");
                        gridbind1();
                    }
                    //txtLicense_No.Enabled = false;
                    ViewState["UPDATED_ID"] = null;

                }
                else if (i == 2)
                {
                    Alert_msg("License No already exixts!", "btnSave");
                }
                else
                {
                    Alert_msg("License Not Saved", "btnNew");
                }
            }
            else if (a2 == "U")
            {
                if (i == 1)
                {
                    //hdn_Update_Adcode.Value = txtLicense_No.Text;
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                        gridbind1();
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnUpdate");
                        gridbind1();
                    }
                }
                else if (i == 2)
                {
                    Alert_msg("Item S.No already exixts!", "btnUpdate");
                }
                else
                {
                    Alert_msg("Item S.No Not Saved", "btnUpdate");
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string a1 = HiddenField1.Value;
            //string a2 = "U";
            string a3 = "";

            if (txt_Remaining_Amt.Text == "")
            {
                txt_Remaining_Amt.Text = "0.00";
            }
            else
            {
                //Job_Remaing_Amt = Convert.ToDouble(txt_Remaining_Amt.Text) + Convert.ToDouble(ViewState["Job_Remaing_Amt"]);
                Job_Remaing_Amt = Convert.ToDouble(ViewState["Job_Remaing_Amt"]);
            }

            if (txt_Remaining_Qty.Text == "")
            {
                txt_Remaining_Qty.Text = "0.00";
            }
            else
            {
                Job_Remaing_Qty = Convert.ToDouble(ViewState["Job_Remaing_Qty"]);
            }

            if ((Convert.ToDouble(txt_Debit_Amt.Text)) >= Job_Remaing_Amt)
            {
                if (ddl_Lic_Type.SelectedItem.Text != "36-MEIS" && ddl_Lic_Type.SelectedItem.Text != "31-SHIS" && ddl_Lic_Type.SelectedItem.Text != "28-FPS" && ddl_Lic_Type.SelectedItem.Text != "27-FMS")
                {
                    if (txtQty.Text != "")
                    {
                        if ((Convert.ToDouble(txtQty.Text)) >= Job_Remaing_Qty)
                        {
                            Inner_InsertUpdate(a1, "U");
                        }
                        else
                        {
                            Alert_msg("Todal Debit Qty is lesser than Remaining Qty");
                        }
                    }
                    else
                    {
                        Alert_msg("Qty Cannot be Null");
                    }
                }
                else
                {
                    Inner_InsertUpdate(a1, "U");
                }
            }
            else
            {
                Alert_msg("Todal Debit Amt is lesser than Remaining Amt");
            }

            Get_Remaining_DEBIT_AMT();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    public int insert_update(string a1, string a2, string a3)
    {
        try
        {
            //erm.LICENSE_ID = a1;

            lic.LICENSE_ID = a1;
            lic.REGISTRATION_NO = txtReg_No.Text;
            lic.REGISTRATION_DATE = txtReg_date.Text;
            lic.LICENSE_NO = txtLicense_no.Text;
            lic.LICENSE_DATE = txtLicense_Date.Text == "" ? "01/01/1900" : txtLicense_Date.Text;
            lic.EXCEMPTION = ddl_Excemption.SelectedItem.Text;
            lic.LICENSE_TYPE = ddl_Lic_Type.SelectedItem.Text;
            lic.TOTAL_DEBIT_AMT = txt_Debit_Amt.Text.Replace(",", "");
            lic.REMAINING_AMT = txt_Remaining_Amt.Text.Replace(",", "");
            lic.TOTAL_DEBIT_QTY = txtQty.Text.Replace(",", "");
            lic.UNIT_QTY = txtUnit.Text;
            lic.LICENSE_ITEM_NO = txt_License_ItemNo.Text;
            lic.PORT_OF_LICENSE = txtPort_Of_Licenses.Text;
            lic.REMAINING_QTY = txt_Remaining_Qty.Text;
            lic.PARTY_NAME = txt_PartyName.Text;
            lic.LICENSE_DESC = txtLic_Desc.Text;
            lic.USER_ID = currentuser;
            lic.DATE_TIME = LoginDate;
            lic.STATUS = "N";
            lic.BRANCH_CODE = currentbranch;
            lic.YEAR = a3;
            lic.WORKING_PERIOD = Working_Period;
            lic.MODIFIEDBY = currentuser;
            lic.MODIFIEDON = LoginDate;
            lic.flag = a2;


            string SingleDuty_YN = "";
            SingleDuty_YN = Check_Single_Duty_Available();

            if (chk_single_Duty.Checked == true)
            {
                if (ddl_Lic_Type.SelectedItem.Text == "36-MEIS" || ddl_Lic_Type.SelectedItem.Text == "03-DEEC" || ddl_Lic_Type.SelectedItem.Text == "01-DEEC")
                {
                    if (SingleDuty_YN == "Avail")
                    {
                        SingleDuty_YN = "N";
                    }
                    else
                    {
                        SingleDuty_YN = "Y";
                    }
                }
                else
                {
                    SingleDuty_YN = "N";
                }
            }
            else
            {
                SingleDuty_YN = "N";
            }

            lic.SINGLE_DUTY_Y_N = SingleDuty_YN;
            lic.TOTAL_FC_VALUE = txt_FCValue.Text.Replace(",", "");
            lic.REMAINING_FC = txt_Remaining_FC.Text.Replace(",", "");
            lic.EX_RATE = txt_Exrate.Text.Replace(",", "");
            lic.TOTAL_CIF_VALUE = txt_CIFValue.Text.Replace(",", "");
            lic.REMAINING_CIF = txt_Remaining_CIF.Text.Replace(",", "");
            lic.LICENSE_CURRENCY = txt_LicenseCurrency.Text;

            lic.LICENSE_BROKER_NAME = txt_BrokerName.Text;
            lic.LICENSE_TRANSFERED_TO = txtTransferedTO.Text;
            lic.LICENSE_RECEIVED_DATE = txtReceived_Date.Text;
            lic.BOND_NO = txtBondNo.Text;
            lic.BOND_DATE = txtBond_date.Text;
            lic.BOND_TYPE = ddlBondType.SelectedItem.Text;
            lic.LICENSE_EXPIRY_DATE = txtLic_Exp_date.Text;
            lic.DATE_OF_SURRENDER = txtsur_date.Text;
            lic.PART_NO = txt_PartNo.Text;
            lic.BOND_LOCATION = txtBondLocation.Text;


            i = lic.Import_License_Master_Insert_update();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
      
        return i;
    }

    private string Check_Single_Duty_Available()
    {
        try
        {
            DataSet ds_avail = new DataSet();
            int ii = 0;
            erm.LICENSE_ID = HiddenField1.Value;
            erm.LICENSE_NO = txtReg_No.Text;
            erm.SCHEME_CODE = ddl_Lic_Type.SelectedItem.Text;
            erm.Ename = "Check_License_SINGLE_DUTY_Available";
            erm.EWorking_Period = Working_Period;

            ds_avail = erm.RetrieveAll_IMPORT_LICENSE_MASTER();

            if (ds_avail.Tables[0].Rows.Count > 0)
            {
                SingleDutyY_N = "Avail";
            }
            else
            {
                SingleDutyY_N = "";
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
        return SingleDutyY_N;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            erm.LICENSE_ID = HiddenField1.Value;
            erm.LICENSE_NO = "0";
            erm.Ename = "delete";
            erm.EWorking_Period = Working_Period;

            erm.RetrieveAll_IMPORT_LICENSE_MASTER();
            int ii = 0;
            ii = erm.result;

            if (ii > 0)
            {
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Adcode Deleted')</script>", false);
                string prompt = "<script>$(document).ready(function(){{jAlert('License Deleted', 'IMPORT LICENSE MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("License Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Session["LICENSE_ID"] = "";
            Clear();
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnNew.Visible = true;
            btnSave.Visible = true;
            hdn_Update_Adcode.Value = "";
            ViewState["UPDATED_ID"] = null;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    protected void btnSaveNew_Click(object sender, EventArgs e)
    {
        try
        {
            click_SaveNew = "SaveNew_Click";
            btnSave_Click(sender, e);
            txt_License_ItemNo.Text = "";
            txt_License_ItemNo.Focus();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'LICENSE MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    ///auto search
    [System.Web.Services.WebMethod]
    public static string GetClient_Name(string custid)
    {
        try
        {
            if (custid.Length == 10)
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                // custid = Auto.Country_Master_FromClientSide_Calling(custid);
                Auto.Ename = "IMP_EXP_MASTER_IMPORTER_IECCODE_WISE";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    custid = ds.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                }
                else
                {
                    custid = "";
                }
            }
            else
            {
                custid = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
        return custid;
    }


    [System.Web.Services.WebMethod]
    public static string Get_Single_DutyValue(string RegNo, string Schemecode)
    {
        string TOT_DEBIT_AMT = "0";
        string TOT_DEBIT_QTY = "0";
        try
        {
            eroyalmaster erm = new eroyalmaster();
            DataSet ds = new DataSet();

            erm.LICENSE_ID = "0";
            erm.LICENSE_NO = RegNo;
            erm.LICENSE_ITEM_DESCRIPTION = "";
            erm.SCHEME_CODE = Schemecode;
            erm.Ename = "Get_License_SINGLE_DUTY_VALUE";
            erm.EWorking_Period = HttpContext.Current.Session["WorkingPeriod"].ToString();

            ds = erm.RetrieveAll_IMPORT_LICENSE_MASTER();

            if (ds.Tables[0].Rows.Count > 0)
            {
                TOT_DEBIT_AMT = ds.Tables[0].Rows[0]["TOTAL_DEBIT_AMT"].ToString();
                TOT_DEBIT_QTY = ds.Tables[0].Rows[0]["TOTAL_DEBIT_QTY"].ToString();

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return TOT_DEBIT_AMT + "~" + TOT_DEBIT_QTY;
    }


    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate_License_Cur(string custid)
    {
        try
        {
            if (custid.Length == 3)
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                Auto.Ename = "EXCHANGE_MASTER_RATE_IMPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_IMPORT"].ToString() + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " ";

                }
                else
                {
                    Auto.Ename = "NON_STD_CUR_RATE_IMPORTWISE";
                    Auto.Enamesearch = custid;
                    ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string NON_STD_RATE_IMPORT = ds.Tables[0].Rows[0]["NON_STD_RATE_IMPORT"].ToString();
                        string NON_STD_EFFECT_DT_IMP = ds.Tables[0].Rows[0]["NON_STD_EFFECT_DT_IMP"].ToString();
                        string NON_STD_BANKNAME = ds.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                        string NON_STD_CERTIFICATE_NO = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                        string NON_STD_CERTIFICATE_DATE = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString();

                        custid = NON_STD_RATE_IMPORT + "~~" + NON_STD_EFFECT_DT_IMP + "~~" + NON_STD_BANKNAME + "~~" + NON_STD_CERTIFICATE_NO + "~~" + NON_STD_CERTIFICATE_DATE;
                    }
                    else

                        custid = "";
                }
            }
            else
            {
                custid = "";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
        return custid;
    }

    public void ddlBond_Type()
    {
        try
        {
            ddlBondType.Items.Add(" ");
            ddlBondType.Items.Add("CE, central excise cert");
            ddlBondType.Items.Add("DE, DEEC Bond");
            ddlBondType.Items.Add("EU, End use Bond");
            ddlBondType.Items.Add("EO, EOU Bond");
            ddlBondType.Items.Add("EC, EPCG Bond");
            ddlBondType.Items.Add("EZ, EPZ Bond");
            ddlBondType.Items.Add("IT, ITC Bond");
            ddlBondType.Items.Add("JB, Jobbing");
            ddlBondType.Items.Add("LG, Letter of guarantee");
            ddlBondType.Items.Add("MS, Misc. cert");
            ddlBondType.Items.Add("PJ, Project Bond");
            ddlBondType.Items.Add("PD, Provisional duty bond");
            ddlBondType.Items.Add("RE, Re-export Bond");
            ddlBondType.Items.Add("TB, Test Bond");
            ddlBondType.Items.Add("TP, Transhipment Bond");
            ddlBondType.Items.Add("UT, Undertaking");
            ddlBondType.Items.Add("WH, Warehouse Bond");
            ddlBondType.Items.Add("NB,  National Bond");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }


    public void gridbind1()
    {
        try
        {
            Session["title"] = null;
            erm.LICENSE_ID = Request.QueryString["LICENSE_ID"];
            erm.LICENSE_NO = Name_Search;
            erm.SCHEME_CODE = ddl_Lic_Type.SelectedItem.Text;
            erm.PARTY_NAME = txt_PartyName.Text;
            erm.LICENSE_ITEM_DESCRIPTION = "";
            erm.Ename = "select_license_all";
            erm.EWorking_Period = Session["WorkingPeriod"].ToString();
            gvdetails.DataSource = erm.RetrieveAll_IMPORT_LICENSE_MASTER();
            DataSet ds = new DataSet();
            gvdetails.DataBind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
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
                    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                    e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gvdetails, "Select$" + e.Row.RowIndex.ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //Add CSS class on header row.
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";

            //Add CSS class on normal row.
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";

            //Add CSS class on alternate row.
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "alternate";
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
     
    }
}