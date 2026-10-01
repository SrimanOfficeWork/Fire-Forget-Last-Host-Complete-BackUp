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

public partial class Party_Master : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    Party_Master_cs PM = new Party_Master_cs();
    Global_variables ObjUBO = new Global_variables();
    DataTable dt = new DataTable();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE,COMPANY_LICENSE;

    decimal tax_amt, non_tax_amt, gst_toal, Reverse_total;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;
    public bool chk = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        hdn_Jobno.Value = "1";

        COMPANY_LICENSE = Connection.Company_License().ToLower();
        Hd_Company_Id.Value = Connection.COMPANYID();

        if (!Page.IsPostBack)
        {
            //
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnUpdate_V.Visible = false;
            btnDelete_V.Visible = false;
            HD_Bill_Jobno.Value = string.Empty;

            if (Request.QueryString["Page"] == null)
            {
                load_Party_name();
                HDupdate_id.Value = "";
                txt_Cr_St_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    txt_Cr_St_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    Update_Item_Load(Request.QueryString["Page"].ToString());
                   
                    btnaddnewParty.Visible = false;
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                    ddlPartyName.Enabled = false;
                    HD_Showcon.Value = "SAVED";
                }
            }
        }
    }

    private void Update_Item_Load(string Party_Name)
    {
        DataSet dss = new DataSet();
        ddlPartyName.Items.Clear();
        ObjUBO.A1 = Party_Name;
        ObjUBO.A15 = "Party_Name_Amt_Select";
        dss = PM.Party_Master_Data(ObjUBO);
        if (dss.Tables[0].Rows.Count>0)
        {
           ddlPartyName.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["PARTY_NAME"].ToString(), dss.Tables[0].Rows[0]["PARTY_NAME"].ToString()));
           ddlPartyName.SelectedIndex = 0;

           Rd_TDS_YN.SelectedValue = dss.Tables[0].Rows[0]["TDS_YN"].ToString();
           ddl_TDS_Section.SelectedValue = dss.Tables[0].Rows[0]["TDS_SECTION"].ToString();
           txt_TDS_Rate.Text = dss.Tables[0].Rows[0]["TDS_RATE"].ToString();

           if (dss.Tables[1].Rows.Count > 0)
           {
               gv.DataSource = dss.Tables[1];
           }
           else
           {
               gv.DataSource = dt;
           }
            gv.DataBind();
           if (dss.Tables[2].Rows.Count > 0)
           {
               lbl_Total_amt.Text = dss.Tables[2].Rows[0]["Total_Amt"].ToString();
           }
           else
           {
               lbl_Total_amt.Text = "0";
           }
            if (dss.Tables[3].Rows.Count > 0)
           {
               gv_Date.DataSource = dss.Tables[3];
           }
           else
           {
               gv_Date.DataSource = dt;
           }
            gv_Date.DataBind();

            if (dss.Tables[4].Rows.Count > 0)
            {
                lbl_balance_days.Text = dss.Tables[4].Rows[0]["Noofdays"].ToString();
                if (dss.Tables[4].Rows[0]["C"].ToString() == "G")
                {
                    lbb.Style.Add("color", "#008000");
                }
                else
                {
                    lbb.Style.Add("color", "#FF0000");
                }
            }
            else
            {
                lbl_balance_days.Text = "0";
            }

            if (dss.Tables[5].Rows.Count > 0)
            {
                txt_Cr_St_Date.Text = dss.Tables[5].Rows[0]["StartDate"].ToString();
            }
            else
            {
                txt_Cr_St_Date.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }

        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Credit', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Credit', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DataSet ss = new DataSet();
        string Re_Inv = string.Empty;
       //--------------------------------------------------------------------------------------------------------------------------
        if (ddlPartyName.SelectedValue.ToString() != string.Empty)
        {
            if (ddl_TDS_Section.SelectedValue.ToString() != string.Empty)
            {
                if (Tds_Val() == "1")
                {
                    if (txtEntry_Date.Text != string.Empty)
                    {
                        if (txt_Particulars.Text != string.Empty)
                        {
                            if (txt_Credit_Amount.Text != string.Empty ||  txt_Debit_Amount.Text != string.Empty)
                            {
                                ss = Save_Update("Cr_Amt_S", "");
                                if (ss.Tables[0].Rows.Count > 0)
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
                                    HDupdate_id.Value = Convert.ToString(ss.Tables[0].Rows[0][0].ToString());

                                    ViewState["UPDATED_ID"] = ss.Tables[0].Rows[0][0].ToString();
                                    //HdtxtInvoiceNo_id.Value = Convert.ToString(BI.UPDATE_ID);
                                    
                                    ddlPartyName.Attributes.Add("readonly", "readonly");
                                    ddlPartyName.Style.Add("background-color", "#F0F0F0");
                                    ddlPartyName.Enabled = false;
                                }
                                else
                                {
                                    btnUpdate.Visible = false;
                                    btnDelete.Visible = false;
                                    btnSave.Visible = true;
                                    btnNew.Visible = true;
                                    Alert_msg("Not Saved", "btnSave");
                                }
                            }
                            else
                            {
                                Alert_msg("Enter Ur Credit Amount  or Debit Amount!", "txt_Credit_Amount");
                            }
                        }
                        else
                        {
                            Alert_msg("Enter Ur Particulars", "txt_Particulars");
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Ur Entry Date!", "txtEntry_Date");
                    }
                }
                else
                {
                    Alert_msg("Select Ur TDS Section and Rate ! ", "ddl_TDS_Section");   
                }
            }
            else
            {
                Alert_msg("Select Ur TDS Section", "ddl_TDS_Section");
            }
        }
        else
        {
            Alert_msg("Select Ur Party Name!", "ddlPartyName");
        }

        //-------------------------------------------------------------
    }
    private string Tds_Val()
    { 
      string val="1";
      if (Rd_TDS_YN.SelectedValue.ToString() == "Y")
      {
          if (txt_TDS_Rate.Text != string.Empty)
          {
              val = "1";
          }
          else
          {
              val = "0";
          }
      }
      else
      {
          if (txt_TDS_Rate.Text != string.Empty)
          {
              val = "0";
          }
      }
      return val;
    }

    private DataSet Save_Update(string Flag,string Updated_Id)
    {
        DataSet ds = new DataSet();
        try
        {
            string dt = string.Empty;
            ObjUBO.A4 = ddlPartyName.SelectedValue.ToString();
            ObjUBO.A19 = Rd_TDS_YN.SelectedValue.ToString();
            ObjUBO.A20 = ddl_TDS_Section.SelectedValue.ToString();
            ObjUBO.A21 = txt_TDS_Rate.Text;
            ObjUBO.A23 = txtEntry_Date.Text;
            ObjUBO.A11 = txt_Particulars.Text;
            ObjUBO.A17 = txt_Credit_Amount.Text;
            ObjUBO.A18 = txt_Debit_Amount.Text;
            ObjUBO.A22 = Flag;
            ObjUBO.A34 = Updated_Id;
            ds = PM.Party_Master_Ins_Upd(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gv.DataSource = ds.Tables[1];
                    gv.DataBind();
                }
                else
                {
                    gv.DataSource = dt;
                    gv.DataBind();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    lbl_Total_amt.Text = ds.Tables[2].Rows[0]["Total_Amt"].ToString();
                }
                else {
                    lbl_Total_amt.Text = "";
                }
            }
            else
            {
                gv.DataSource = dt;
                gv.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataSet dds = new DataSet();
        try
        {
            if (Tds_Val() == "1")
            {
                if (txtEntry_Date.Text != string.Empty)
                    {
                        if (txt_Particulars.Text != string.Empty)
                        {
                                dds = Save_Update("Cr_Amt_U", ViewState["UPDATED_ID"].ToString());
                                if (dds.Tables[0].Rows.Count > 0)
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
                            Alert_msg("Enter Ur Particulars", "txt_Particulars");
                        }
                    }
                else
                {
                    Alert_msg("Enter Ur Entry Date!", "txtEntry_Date");
                }
            }
            else
            {
                Alert_msg("Select Ur TDS Section and Rate ! ", "ddl_TDS_Section");   
            }
        
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            /*
            ObjUBO.ID = HDupdate_id.Value.ToString();
            ObjUBO.IMPORTER_NAME = ddlImp_name.SelectedItem.Text;
            ObjUBO.BILL_INV_NO = txtInvoiceNo.Text;
            ObjUBO.Flag = "D";
            ObjUBO.HBL_NO_DATE = string.Empty;
            ObjUBO.MBL_NO_DATE = string.Empty;
            ObjUBO.FLIGHT_ARAIVAL_DATE = string.Empty;
            ObjUBO.BOND_DATE = string.Empty;
            BI.Imp_Billing_Invoice_INS_UPD(ObjUBO);
            i = BI.result;
            */
            if (i == 1)
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
        btnUpdate_V.CssClass = "updates";
        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        HDupdate_id.Value = string.Empty;

        ddlPartyName.Attributes.Add("readonly", "readonly");
        ddlPartyName.Style.Add("background-color", "#F0F0F0");
        txtEntry_Date.Text = string.Empty;
        txt_Particulars.Text = string.Empty;
        txt_Credit_Amount.Text = string.Empty;
        txt_Debit_Amount.Text = string.Empty;

        txt_Credit_Amount.Enabled = true;
        txt_Debit_Amount.Enabled = true;
    }
    private void load_Party_name()
    {
        try
        {
            DataSet dss = new DataSet();
            ddlPartyName.Items.Clear();
            ObjUBO.A15 = "Party_Name_Select";
            dss = PM.Party_Master_Data(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlPartyName.DataSource = dss.Tables[0];
                ddlPartyName.DataTextField = "PARTY_NAME";
                ddlPartyName.DataValueField = "PARTY_NAME";
                ddlPartyName.DataBind();
            }
            ddlPartyName.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlPartyName.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    
   
    protected void ddlPartyName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        gridbind();
    }

    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ViewState["ID"] = Convert.ToString(this.gv.SelectedDataKey.Value);
            ViewState["PARTY_ID"] = Convert.ToString(this.gv.SelectedDataKey.Value);

            if (ViewState["ID"] != "")
            {
                txtEntry_Date.Text = gv.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txt_Particulars.Text=  gv.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                txt_Credit_Amount.Text = gv.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                txt_Debit_Amount.Text = gv.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");

                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID"] = null;
                ViewState["UPDATED_ID"] = ViewState["ID"].ToString();
                //FOR UPDATED SUCCESSFULLY
                btnUpdate.CssClass = "updates";

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;

                txt_Credit_Amount.Enabled = false;
                txt_Debit_Amount.Enabled = false;
            }
            else
            {
                btnDelete.Visible = false;

                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void gridbind()
    {
        DataTable dt = new DataTable();
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void ddl_Noof_Days_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dds = new DataSet();
        if (txt_Cr_St_Date.Text != string.Empty)
        {
            ObjUBO.A23 = txt_Cr_St_Date.Text; 
            ObjUBO.A11 = ddl_Noof_Days.SelectedValue.ToString();
            ObjUBO.A22 = "Validity_End_Date";
            dds = PM.Party_Master_Ins_Upd(ObjUBO);
            if (dds.Tables[0].Rows.Count > 0)
            {
                txt_Cr_End_Date.Text = dds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                txt_Cr_End_Date.Text = string.Empty;
            }
        }
        txt_Cr_End_Date.Focus();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page3();", true);
    }

    protected void btnSave_V_Click(object sender, EventArgs e)
    {
        DataSet ss = new DataSet();
        //--------------------------------------------------------------------------------------------------------------------------
        if (Entry_Chk() == "Y")
        {
            if (txt_Cr_St_Date.Text != string.Empty)
            {
                if (txt_Cr_End_Date.Text != string.Empty)
                {
                    ss = Save_Update_Date("Cr_Date_S", "");
                    if (ss.Tables[0].Rows.Count > 0)
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

                        if (ss.Tables[1].Rows[0][0].ToString() == "V")
                        {
                            Alert_msg("Saved Successfully", "btnSave");
                        }
                        else
                        {
                            Alert_msg("Invalid Date Not Saved", "txt_Cr_St_Date");
                        }
                        HDupdate_id.Value = Convert.ToString(ss.Tables[0].Rows[0][0].ToString());

                        ViewState["UPDATED_ID"] = ss.Tables[0].Rows[0][0].ToString();

                    }
                    else
                    {
                        btnUpdate_V.Visible = false;
                        btnDelete_V.Visible = false;
                        btnSave_V.Visible = true;
                        btnNew_V.Visible = true;
                        Alert_msg("Not Saved", "btnSave");
                    }
                }
                else
                {
                    Alert_msg("Enter Ur  Credit End Date", "txt_Cr_End_Date");
                }
            }
            else
            {
                Alert_msg("Enter Ur Credit Start Date!", "txt_Cr_St_Date");
            }
        }
        else
        {
            Alert_msg("Save Ur PartyName !", "btnSave");
        }
        //-------------------------------------------------------------
    }

    private string Entry_Chk()
    {
        DataSet ds = new DataSet();
        string outval = "N";
        ObjUBO.A1 = ddlPartyName.SelectedValue.ToString();
        ObjUBO.A15 = "NewDateEntry_Chk";
        ds = PM.Party_Master_Data(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            outval = "Y";
        }
        return outval;
    }

    private DataSet Save_Update_Date(string Flag, string Updated_Id)
    {
        Tab_2();
        DataSet ds = new DataSet();
        try
        {
            ObjUBO.A4 = ddlPartyName.SelectedValue.ToString();
            ObjUBO.A20 = ddl_Noof_Days.SelectedValue.ToString();
            ObjUBO.A23 = txt_Cr_St_Date.Text;
            ObjUBO.A25 = txt_Cr_End_Date.Text; 
            ObjUBO.A22 = Flag;
            ObjUBO.A34 = Updated_Id;
            ds = PM.Party_Master_Ins_Upd(ObjUBO);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv_Date.DataSource = ds.Tables[0];
                }
                else
                {
                    gv_Date.DataSource = dt;
                }
                gv_Date.DataBind();
            /*
                if (ds.Tables[1].Rows.Count > 0)
                {
                    lbl_Total_amt.Text = ds.Tables[1].Rows[0]["Total_Amt"].ToString();
                }
                else
                {
                    lbl_Total_amt.Text = "";
                }
            */
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ds;
    }
    
    protected void gv_Date_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Tab_2();
        gv_Date.PageIndex = e.NewPageIndex;
        //gridbind();
    }
    protected void gv_Date_SelectedIndexChanged(object sender, EventArgs e)
    {
        Tab_2();
        try
        {
            ViewState["ID_V"] = Convert.ToString(this.gv_Date.SelectedDataKey.Value);
            ViewState["PARTY_ID_V"] = Convert.ToString(this.gv_Date.SelectedDataKey.Value);

            if (ViewState["ID_V"] != "")
            {
                txt_Cr_St_Date.Text = gv_Date.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                txt_Cr_End_Date.Text = gv_Date.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                ddl_Noof_Days.SelectedValue = gv_Date.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

                datediff(ViewState["ID_V"].ToString(), ViewState["PARTY_ID_V"].ToString(), txt_Cr_St_Date.Text, txt_Cr_End_Date.Text, "Validity_Check");


                //FOR UPDATED SUCCESSFULLY
                ViewState["UPDATED_ID_V"] = null;
                ViewState["UPDATED_ID_V"] = ViewState["ID_V"].ToString();
                //FOR UPDATED SUCCESSFULLY
                btnUpdate_V.CssClass = "updates";

                btnDelete_V.Visible = true;
                btnUpdate_V.Visible = true;
                btnSave_V.Visible = false;
                btnNew_V.Visible = true;
            }
            else
            {
                btnDelete_V.Visible = false;
                btnUpdate_V.Visible = false;
                btnSave_V.Visible = true;
                btnNew_V.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   
    protected void gv_Date_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_Date, "Select$" + e.Row.RowIndex.ToString()));
        }
    }
    protected void btnNew_ClickV(object sender, EventArgs e)
    {
        btnUpdate_V.CssClass = "updates";
        ViewState["UPDATED_ID_V"] = null;
        btnSave_V.Visible = true;
        btnDelete_V.Visible = false;
        btnUpdate_V.Visible = false;
        txt_Cr_St_Date.Enabled = true;
        HDupdate_id.Value = string.Empty;

        txt_Cr_St_Date.Text = string.Empty;
        ddl_Noof_Days.SelectedIndex = -1;
        txt_Cr_End_Date.Text = string.Empty;
        Tab_2();
        load_date();
    }

    private void load_date()
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = ddlPartyName.SelectedValue.ToString();
        ObjUBO.A15 = "NewDate_Select";
        ds = PM.Party_Master_Data(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_Cr_St_Date.Text = ds.Tables[0].Rows[0][0].ToString();
        }
    }

    private void Tab_2()
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "B_G_tab_page3();", true);
    }

    private void datediff(string Id ,string Party_id, string St_Date ,string End_Date,string flg )
    {
        DataSet ts = new DataSet();
        ObjUBO.A4 = ddlPartyName.SelectedValue.ToString();
        ObjUBO.A23 = txt_Cr_St_Date.Text;
        ObjUBO.A25 = txt_Cr_End_Date.Text;
        ObjUBO.A22 = flg;
        ObjUBO.A34 = Id;
        ts = PM.Party_Master_Ins_Upd(ObjUBO);
        if (ts.Tables[0].Rows.Count > 0)
        {
            txt_Cr_St_Date.Enabled = false;
            if (ts.Tables[0].Rows[0]["V_date"].ToString() == "Y")
            {
                btnUpdate_V.Visible = true;
            }
            else
            {
                btnUpdate_V.Visible = false;
            }
        }
    }

    protected void btnUpdate_V_Click(object sender, EventArgs e)
    {
        DataSet dds = new DataSet();
        try
        {
            if (txt_Cr_St_Date.Text != string.Empty)
                {
                    if (txt_Cr_End_Date.Text != string.Empty) 
                    {
                        dds = Save_Update_Date("Cr_Date_U", ViewState["UPDATED_ID_V"].ToString());
                        if (dds.Tables[0].Rows.Count > 0)
                        {
                            if (dds.Tables[1].Rows[0][0].ToString() == "Y")
                            {
                                if (ViewState["UPDATED_ID_V"] != null)
                                {
                                    Alert_msg("Updated Successfully", "btnUpdate_V");
                                }
                                else
                                {
                                    Alert_msg("Saved Successfully", "btnUpdate_V");
                                    HD_Showcon.Value = "SAVED";
                                }
                            }
                            else
                            {
                                Alert_msg("Not Saved Invalid Date !", "btnUpdate_V");
                            }
                        }
                        else
                        {
                            btnUpdate_V.Visible = true;
                            btnDelete_V.Visible = true;
                            btnSave_V.Visible = false;
                            btnNew_V.Visible = true;
                            Alert_msg("Not Saved", "btnUpdate");
                        }
                    }
                    else
                    {
                        Alert_msg("Enter Ur End Date", "txt_Cr_End_Date"); 
                    }
                }
                else
                {
                    Alert_msg("Enter Ur Start Date!", "txt_Cr_St_Date"); 
                }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

}