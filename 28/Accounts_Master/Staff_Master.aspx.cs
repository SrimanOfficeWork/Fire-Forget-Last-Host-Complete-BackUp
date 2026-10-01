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


public partial class Staff_Master : ThemeClass
{
    AppSession aps = new AppSession();
    User_Creation user_Create = new User_Creation();
    Global_variables ObjUBO = new Global_variables();

    Staff_Master_cs SM = new Staff_Master_cs();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    public int i, Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!IsPostBack)
        {
            txtStaffcode.Attributes.Add("readonly", "readonly");
            txtStaffcode.Style.Add("background-color", "#F0F0F0");
            Load_idType();
            EditSupDetails();          
        }
    }
    public void Load_idType()
    {
        ddlotheridType.Items.Clear();
        ddlotheridType.Items.Add(new ListItem("Gas book", "GB"));
        ddlotheridType.Items.Add(new ListItem("Ration Card", "RC"));
    }
    private void GetAutono_Receipt()
    {
        txtStaffcode.Text = string.Empty;
        DataSet ds = new DataSet();
        ObjUBO.A15 = "Staff_Auto_no";
        ds = SM.Staff_Master_Data(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtStaffcode.Text = ds.Tables[0].Rows[0][0].ToString();
        }
    }
    public void EditSupDetails()
    {
        DataSet ds = new DataSet();
        if (Request.QueryString["STAFF_ID"] != "" && Request.QueryString["STAFF_ID"] != null)
        {
            ObjUBO.A1 = Request.QueryString["STAFF_ID"].ToString();
            ObjUBO.A15 = "Staff_Data_Select";
            ds = SM.Staff_Master_Data(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HiddenField1.Value = ds.Tables[0].Rows[0]["STAFF_ID"].ToString();
                txtStaffcode.Text = ds.Tables[0].Rows[0]["STAFF_CODE"].ToString();
                txtstafullName.Text = ds.Tables[0].Rows[0]["STAFF_FULL_NAME"].ToString();
                txt_staffname.Text = ds.Tables[0].Rows[0]["STAFF_NAME"].ToString();
                txt_empid.Text = ds.Tables[0].Rows[0]["EMPLOYEE_ID"].ToString();
                txtAdno.Text = ds.Tables[0].Rows[0]["AADHAR_ID"].ToString();
                txtpanid.Text = ds.Tables[0].Rows[0]["PAN_ID"].ToString();
                txt_MobileNo.Text = ds.Tables[0].Rows[0]["MOBILE_NO"].ToString();
                ddlotheridType.SelectedValue = ds.Tables[0].Rows[0]["OTHER_ID_TYPE"].ToString();
                txtothidno.Text = ds.Tables[0].Rows[0]["OTHER_ID_NO"].ToString();
                txtentDate.Text = ds.Tables[0].Rows[0]["ENTRY_DATE"].ToString();
                txt_doj.Text = ds.Tables[0].Rows[0]["DOJ"].ToString();

                ddl_Bandk_Name.SelectedValue = ds.Tables[0].Rows[0]["BANK_NAME"].ToString();
                txt_bank_branch.Text = ds.Tables[0].Rows[0]["BANK_BRANCH_NAME"].ToString();

                txtremarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();
                txtlicno.Text = ds.Tables[0].Rows[0]["DRIVING_LICENSE"].ToString();
                txtpass.Text = ds.Tables[0].Rows[0]["PASSPORT"].ToString();
                txtreason.Text = ds.Tables[0].Rows[0]["REASON"].ToString();
                Rd_Active_InActive.SelectedValue = ds.Tables[0].Rows[0]["EMP_STATUS"].ToString();

                txt_bankuser_name.Text = ds.Tables[0].Rows[0]["BANK_USER_NAME"].ToString();
                txt_acc_no.Text = ds.Tables[0].Rows[0]["ACCOUNT_NO"].ToString();
                txt_ifsc.Text = ds.Tables[0].Rows[0]["IFSC_CODE"].ToString();
                txt_swift_code.Text = ds.Tables[0].Rows[0]["SWIFT_CODE"].ToString();
                txt_Inactive_Date.Text = ds.Tables[0].Rows[0]["INACTIVE_DATE"].ToString();
  
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = Request.QueryString["STAFF_ID"].ToString();

                txtstafullName.Attributes.Add("readonly", "readonly");
                txtstafullName.Style.Add("background-color", "#F0F0F0");
            }
                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
        }
        else
        {
               GetAutono_Receipt();
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                GetAutono_Receipt();   
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
            if (txtStaffcode.Text != string.Empty)
            {
                if (txtstafullName.Text != string.Empty)
                {
                    if (txtAdno.Text != string.Empty)
                    {
                        if (txtpanid.Text != string.Empty)
                        {
                            if (txtentDate.Text != string.Empty)
                            {
                                if (txt_doj.Text != string.Empty)
                                {
                                     ds=insert_update("", "S");
                                        if (ds.Tables[0].Rows.Count > 0)
                                        {
                                            if (ds.Tables[1].Rows[0][0].ToString() == "4")
                                            {
                                                HiddenField1.Value = ds.Tables[0].Rows[0]["STAFF_ID"].ToString();
                                                btnUpdate.CssClass = "save";
                                                btnUpdate.Visible = true;
                                                btnSave.Visible = false;
                                                btnSave.Focus();
                                                ViewState["UPDATED_ID"] = null;
                                                Alert_msg("Staff Entry Saved Successfully", "btnSave");
                                            }
                                        }
                                        else
                                        {
                                            if (ds.Tables[0].Rows.Count == 0)
                                            {
                                                if (ds.Tables[1].Rows[0][0].ToString() == "1")
                                                {
                                                    Alert_msg("Staff Code ! Already Exists! Not Saved ", "txtStaffcode");
                                                }
                                                else if (ds.Tables[1].Rows[0][0].ToString() == "2")
                                                {
                                                    Alert_msg("Aadhar Id ! Already Exists! Not Saved", "txtAdno");
                                                }
                                                else if (ds.Tables[1].Rows[0][0].ToString() == "3")
                                                {
                                                    Alert_msg("PAN Id ! Already Exists! Not Saved", "txtpanid");
                                                }
                                            }
                                            else
                                            {
                                                Alert_msg("Staff Not Saved", "btnSave");
                                            }
                                        }
                                }
                                else
                                {
                                    Alert_msg("Enter Ur DOJ Date !", "txt_doj");
                                }

                            }
                            else
                            {
                                Alert_msg("Enter Ur Entry Date !", "txtentDate");
                            }
                        }
                        else
                        {
                            Alert_msg("Enter Ur Staff PAN No !", "txtpanid");
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Ur Staff Aadhar Id !", "txtAdno");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Staff Full Name!", "txtstafullName");
                }
            }
            else
            {
                Alert_msg("Enter Ur Staff Code!", "txtStaffcode");
            }
            //--------------------------
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
            if (txtStaffcode.Text != string.Empty)
            {
                if (txtstafullName.Text != string.Empty)
                {
                    if (txtAdno.Text != string.Empty)
                    {
                        if (txtpanid.Text != string.Empty)
                        {
                            if (txtentDate.Text != string.Empty)
                            {
                                if (txt_doj.Text != string.Empty)
                                {
           ds=insert_update(HiddenField1.Value.ToString(), "U");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                }
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
                Alert_msg("Not Saved", "btnUpdate");
            }
            //--------------------
                                }
                                else
                                {
                                    Alert_msg("Enter Ur DOJ Date !", "txt_doj");
                                }

                            }
                            else
                            {
                                Alert_msg("Enter Ur Entry Date !", "txtentDate");
                            }
                        }
                        else
                        {
                            Alert_msg("Enter Ur Staff PAN No !", "txtpanid");
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Ur Staff Aadhar Id !", "txtAdno");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Staff Full Name!", "txtstafullName");
                }
            }
            else
            {
                Alert_msg("Enter Ur Staff Code!", "txtStaffcode");
            }
            //--------------------
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public DataSet insert_update(string Id , string flg)
    {
        ObjUBO.A1 = Id;
        ObjUBO.A2 = txtStaffcode.Text;
        ObjUBO.A3 = txtstafullName.Text.ToUpper();
        ObjUBO.A4 = txt_staffname.Text.ToUpper().Trim();//txtBankName.Text;
        ObjUBO.A5 = txt_empid.Text.ToUpper().Trim();
        ObjUBO.A6 = txtAdno.Text.ToUpper().Trim();
        ObjUBO.A7 = txtpanid.Text.ToUpper().Trim();
        ObjUBO.A8 = txt_MobileNo.Text;
        ObjUBO.A9 = ddlotheridType.SelectedValue.ToString();
        ObjUBO.A10 = txtothidno.Text;
        ObjUBO.A11 = txtentDate.Text;
        ObjUBO.A13 = txt_doj.Text;
        ObjUBO.A14 = txtremarks.Text;
        ObjUBO.A15 = txtlicno.Text;
        ObjUBO.A16 = txtpass.Text;
        ObjUBO.A17 = txtreason.Text;
        ObjUBO.A18 = ddl_Bandk_Name.SelectedValue.ToString();
        ObjUBO.A19 = txt_acc_no.Text;
        ObjUBO.A20 = txt_bankuser_name.Text;
        ObjUBO.A21 = txt_ifsc.Text;
        ObjUBO.A22 = txt_bank_branch.Text;
        ObjUBO.A23 = txt_swift_code.Text;
        ObjUBO.A24 = Rd_Active_InActive.SelectedValue.ToString();
        ObjUBO.A25 = txt_Inactive_Date.Text;
        ObjUBO.A27 = flg;
        ds = SM.Staff_Master_Ins_Upd(ObjUBO);
        return ds;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = insert_update(HiddenField1.Value.ToString(), "D");
            if (ds.Tables[0].Rows.Count == 0)
            {
                btnNew_Click(sender, e);
                Alert_msg("Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Session["STAFF_ID"] = "";
        Clear();
        GetAutono_Receipt();
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnNew.Visible = true;
        btnSave.Visible = true;
        hdn_Update_Adcode.Value = "";
        ViewState["UPDATED_ID"] = null;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'STAFF MASTER', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'STAFF MASTER', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    
}