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

public partial class Acc_Company_Info : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    Company_Info_cs CI = new Company_Info_cs();
    Global_variables ObjUBO = new Global_variables();

    DataTable dt = new DataTable();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            T.Visible = false;

            if (Request.QueryString["C_ID"] == null)
            {
               HDupdate_id.Value = "";
               lbl_Job_Company_Lic.Text = Connection.Company_License().ToUpper();
            }
            else
            {
                if (Request.QueryString["C_ID"] != null && Request.QueryString["C_ID"] != string.Empty)
                {
                    Update_Item_Load(Request.QueryString["C_ID"].ToString());
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }
        }
    }
    private void Update_Item_Load(string Id)
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Id;
        ObjUBO.A9 = "Updated_Data_Select";
        dss = CI.Company_Entry_Select(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            HDupdate_id.Value = dss.Tables[0].Rows[0]["C_ID"].ToString();
            lbl_Job_Company_Lic.Text = dss.Tables[0].Rows[0]["JOB_LICENSE"].ToString();
            txt_Company_Name.Text=dss.Tables[0].Rows[0]["COMPANY_NAME"].ToString();
            txt_Branch.Text=dss.Tables[0].Rows[0]["COMPANY_BRANCH"].ToString();

            txt_Add_1.Text=dss.Tables[0].Rows[0]["ADD_1"].ToString();
            txt_Add_2.Text=dss.Tables[0].Rows[0]["ADD_2"].ToString();
            txt_Add_3.Text=dss.Tables[0].Rows[0]["ADD_3"].ToString();
            txt_Add_4.Text=dss.Tables[0].Rows[0]["ADD_4"].ToString();
            txt_Add_5.Text = dss.Tables[0].Rows[0]["ADD_5"].ToString();
            txt_Pan_Tan_No.Text = dss.Tables[0].Rows[0]["TAN_PAN_NO"].ToString();
            ddlGst_Reg_Type.SelectedValue = dss.Tables[0].Rows[0]["GST_REG_TYPE"].ToString();
            ddl_state_name.SelectedValue = dss.Tables[0].Rows[0]["STATE_CODE"].ToString();
            txt_Gst_Number.Text = dss.Tables[0].Rows[0]["GST_NO"].ToString();
        }
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page2();", true);
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Company Info', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Company Info', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
                           if (txt_Company_Name.Text != "")
                            {
                                if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                                {
                                    if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                                    {
                                        //--------------------------------------------------------------------------------------------------------------------------
                                       ds= Save_Update("S");
                                        if (ds.Tables[0].Rows.Count>0)
                                        {
                                            //-----------------------FOR USER RIGHTS--------------------------------//
                                            user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                                            PAGE_MODIFY = user_Create.PAGE_MODIFY;
                                            //---------------SAVE ONLY------------------//
                                            if (PAGE_MODIFY == "False")
                                            {
                                                btnNew_Click1(sender, e);
                                            }
                                            else
                                            {
                                                btnUpdate.CssClass = "save";
                                                btnUpdate.Visible = true;
                                                btnSave.Visible = false;
                                                btnSave.Focus();
                                            }
                                            //-----------------------FOR USER RIGHTS--------------------------------//

                                            ViewState["UPDATED_ID"] = null;
                                            HD_Showcon.Value = "SAVED";
                                            Alert_msg("Saved Successfully", "btnSave");
                                            HDupdate_id.Value = Convert.ToString(ds.Tables[0].Rows[0]["C_ID"].ToString());

                                            F.Visible = false;
                                            T.Visible = true;

                                        }
                                        else
                                        {
                                            btnUpdate.Visible = false;
                                            btnDelete.Visible = false;
                                            btnSave.Visible = true;
                                            btnNew.Visible = true;
                                            Alert_msg("Not Saved.", "btnSave");
                                        }
                                        //-------------------------------------------------------------
                                    }
                                    else
                                    {
                                        Alert_msg("Enter Ur GSTN Number!", "txt_Gst_Number"); 
                                    }
                                }
                                else
                                {
                                    Alert_msg("Select Ur State Name !", "ddl_state_name"); 
                                }
                            }
                            else
                            {
                                Alert_msg("Select Ur Party Name or Branch !", "ddlPartyName"); 
                            }
                        

                    //-------------------------------------------------------------------------------------
    }
    private DataSet Save_Update(string Flag)
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = txt_Company_Name.Text;
        ObjUBO.A3 = txt_Branch.Text;
        ObjUBO.A4 = txt_Add_1.Text;
        ObjUBO.A5 = txt_Add_2.Text;
        ObjUBO.A6 = txt_Add_3.Text;
        ObjUBO.A7 = txt_Add_4.Text;
        ObjUBO.A8 = txt_Add_5.Text;
        ObjUBO.A9 = txt_Pan_Tan_No.Text;
        ObjUBO.A10 = ddlGst_Reg_Type.SelectedValue.ToString();
        ObjUBO.A11 = ddl_state_name.SelectedValue.ToString();
        ObjUBO.A12 = txt_Gst_Number.Text;
        ObjUBO.A13 = lbl_Job_Company_Lic.Text;
        ObjUBO.A33 = Flag;
        ds = CI.Company_Entry_Ins_Upd(ObjUBO);
        return ds;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
                        if (txt_Company_Name.Text != "")
                            {
                                if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                                {
                                    if (ddl_state_name.SelectedValue.ToString() != string.Empty)
                                    {
                                       ds= Save_Update("U");
                                        if (ds.Tables[0].Rows.Count>0)
                                        {
                                            if (ViewState["UPDATED_ID"] != null)
                                            {
                                                Alert_msg("Updated Successfully", "btnUpdate");
                                            }
                                            else
                                            {
                                                Alert_msg("Saved Successfully", "btnUpdate");
                                                HD_Showcon.Value = "SAVED";
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
                                    }
                                    else
                                    {
                                        Alert_msg("Enter Ur GSTN Number!", "txt_Gst_Number");
                                    }
                                }
                                else
                                {
                                    Alert_msg("Select Ur State Name !", "ddl_state_name");
                                }
                            }
            else
            {
                Alert_msg("Select Ur Party Name or Branch !", "ddlPartyName");
            }
        
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds=new DataSet();
        try
        {
            ds = Save_Update("D");
            if (ds.Tables[0].Rows.Count == 0)
            {
                btnNew_Click1(sender, e);
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
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        btnUpdate.CssClass = "updates";

        ViewState["PARTY_ID"] = null;
        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        HDupdate_id.Value = string.Empty;
        clear();
    }

    private void clear()
    {
        txt_Add_1.Text = string.Empty;
        txt_Add_2.Text = string.Empty;
        txt_Add_3.Text = string.Empty;
        txt_Add_4.Text = string.Empty;
        txt_Add_5.Text = string.Empty;
        txt_Pan_Tan_No.Text = string.Empty;
        ddlGst_Reg_Type.SelectedIndex = -1;
        ddl_state_name.SelectedIndex = -1;
        txt_Gst_Number.Text = string.Empty;
        txt_Company_Name.Text = string.Empty;
        txt_Branch.Text = string.Empty;
    }

    
}