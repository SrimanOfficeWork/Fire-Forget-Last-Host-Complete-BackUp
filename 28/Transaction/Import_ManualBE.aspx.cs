using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Windows.Forms;

using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.IO;


public partial class Transaction_Import_ManualBE : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    
    public int i;
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string Company_ID;
    public string LoginDate;
    AppSession aps = new AppSession();
    Internal_Mail mail = new Internal_Mail();
    User_Creation user_Create = new User_Creation();
    User_Creation USER = new User_Creation();
    ErrorLogs er = new ErrorLogs();
   
   
    Import_ManualBE_LC Manual_BE = new Import_ManualBE_LC();
   
    public string getpath;
    public int ii = 1;
    public int Screen_Id;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;

    public string IEC_NO;

    bool[] rowChanged;  
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        Company_ID = Session["COMPANY_ID"].ToString();
        HdnDutyforgone.Value = "DUTY FOREGONE Rs.";

            // commented for areawise implementation on 05-mar-2020
        /*
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
            }
            else
            {
                SELECT_BRANCH = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
        }
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            LoadJobNo();
            
            //Checkbox_Checking();
        }
        GV_Details.Visible = true;

        int totalRows = GV_Details.Rows.Count;
        rowChanged = new bool[totalRows];

        if (ddlJobNo.SelectedItem.Text == "Select")
        {
            Empty_grid();
            tag_transact_srcinner_rght.Visible = false;
        }
        else
        {
            tag_transact_srcinner_rght.Visible = true;
        }

    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)   
     {
         CLEAR_Checking();
        try
        {
            
            if (ddlJobNo.SelectedItem.Text != "Select")
            {
                grid_load();
                string dutyWords;

                HdnDutyforgone.Value = "DUTY FOREGONE Rs.";
                Manual_BE.JOBNO = ddlJobNo.SelectedItem.Text;
                Manual_BE.Branchcode = SELECT_BRANCH;
                Manual_BE.Ename = "Bind_Igm_InvoiceDetails";
                ds = Manual_BE.ManualBE_Rpt();
                //Checkbox_Checking();
                int iResult = Manual_BE.result;
                if (iResult == 1)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txt_Date.Text = ds.Tables[1].Rows[0]["jobdate"].ToString();
                        IEC_NO = ds.Tables[1].Rows[0]["IEC_NO"].ToString();
                        ViewState["IEC_NO"] = IEC_NO;
                        txtImporter.Text = ds.Tables[1].Rows[0]["impname"].ToString();
                        txtAddress1.Text = ds.Tables[1].Rows[0]["impadd1"].ToString();
                        txtAddress2.Text = ds.Tables[1].Rows[0]["impadd2"].ToString();
                        txtAddress3.Text = ds.Tables[1].Rows[0]["impadd3"].ToString();
                        txtAddress4.Text = ds.Tables[1].Rows[0]["impadd4"].ToString();
                        txtAddress5.Text = ds.Tables[1].Rows[0]["impadd5"].ToString();

                        txtVesselname.Text = ds.Tables[1].Rows[0]["VesselName"].ToString();
                        txtPortofShipment.Text = ds.Tables[1].Rows[0]["portShipment"].ToString();
                        txtCountry.Text = ds.Tables[1].Rows[0]["Country_Origin"].ToString();
                        txtCountryOrigin.Text = ds.Tables[1].Rows[0]["Country_consignment"].ToString();

                        txtAWBLNo.Text = ds.Tables[1].Rows[0]["MAWBNO"].ToString();
                        txtAWBLDate.Text = ds.Tables[1].Rows[0]["MAWBDATE"].ToString();
                        txtHAWBNo.Text = ds.Tables[1].Rows[0]["HAWBNO"].ToString();
                        txtHAWBDate.Text = ds.Tables[1].Rows[0]["HAWBDATE"].ToString();
                        txtGrossWeight.Text = ds.Tables[1].Rows[0]["grosswt"].ToString() + " " + ds.Tables[1].Rows[0]["grossUnit"].ToString();

                        txtInvoiceTerms.Text = ds.Tables[1].Rows[0]["terms"].ToString();
                        //txtInvoiceNoDate.Text = ds.Tables[1].Rows[0]["InvoiceNo"].ToString() + " " + ds.Tables[1].Rows[0]["InvoiceDate"].ToString();

                        

                        hdnSup1.Value = ds.Tables[1].Rows[0]["suppName"].ToString();
                        hdnSup2.Value = ds.Tables[1].Rows[0]["supadd1"].ToString();
                        hdnSup3.Value = ds.Tables[1].Rows[0]["supadd2"].ToString();
                        hdnSup4.Value = ds.Tables[1].Rows[0]["supadd3"].ToString();

                        txtDutyValue.Text = ds.Tables[1].Rows[0]["DutyVal"].ToString();
                        txtTotalValue.Text = ds.Tables[1].Rows[0]["Total_Val"].ToString();
                        txtLandingCharges.Text = ds.Tables[1].Rows[0]["Landing"].ToString();
                        txtAssableValue.Text = ds.Tables[1].Rows[0]["AssableVal"].ToString();
                        decimal val1 = Convert.ToDecimal(txtAssableValue.Text);
                        int value = Convert.ToInt32(val1);
                       
                       // txtAssableValueinWords.Text = NumberToWords1(value);

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            string str = string.Empty;
                            string S = string.Empty;

                            for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                            {

                                if (i == ds.Tables[2].Rows.Count - 1)
                                {
                                    str = ds.Tables[2].Rows[i]["INVOICE_NO"].ToString() + "_" + ds.Tables[2].Rows[i]["INVOICE_DATE"].ToString();
                                }
                                else
                                {
                                    str = ds.Tables[2].Rows[i]["INVOICE_NO"].ToString() + "_" + ds.Tables[2].Rows[i]["INVOICE_DATE"].ToString() + ",";
                                }
                                S += str;

                            }


                            //txtInvoiceNoDate.Text = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString();
                            txtInvoiceNoDate.Text = S;
                        }
                        dutyWords = txtAssableValue.Text;
                        //txtAssableValueinWords.Text = NumtoWords.InWrods(Convert.ToDecimal(dutyWords));

                    }

                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;
                }
                else if (iResult == 2)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txt_Date.Text = ds.Tables[0].Rows[0]["DATE1"].ToString();
                        txtImporter.Text = ds.Tables[0].Rows[0]["IMPORTER"].ToString();
                        txtAddress1.Text = ds.Tables[0].Rows[0]["IM_ADDRESS1"].ToString();
                        txtAddress2.Text = ds.Tables[0].Rows[0]["IM_ADDRESS2"].ToString();
                        txtAddress3.Text = ds.Tables[0].Rows[0]["IM_ADDRESS3"].ToString();
                        txtAddress4.Text = ds.Tables[0].Rows[0]["IM_ADDRESS4"].ToString();
                        txtAddress5.Text = ds.Tables[0].Rows[0]["IM_ADDRESS5"].ToString();

                        hdnSup1.Value = ds.Tables[0].Rows[0]["SUPPLIERNAME"].ToString();
                        hdnSup2.Value = ds.Tables[0].Rows[0]["SUP_ADDRESS1"].ToString();
                        hdnSup3.Value = ds.Tables[0].Rows[0]["SUP_ADDRESS2"].ToString();
                        hdnSup4.Value = ds.Tables[0].Rows[0]["SUP_ADDRESS3"].ToString();

                        txtDutyforgone.Text = ds.Tables[0].Rows[0]["SUP_ADDRESS4"].ToString();
                        txtDutyforgone.Text = ds.Tables[0].Rows[0]["SUP_ADDRESS5"].ToString();
                        txtIncometax.Text = ds.Tables[0].Rows[0]["INCOME_TAX"].ToString();
                        txtPriorStamp.Text = ds.Tables[0].Rows[0]["PRIOR_STAMP"].ToString();
                        txtVesselname.Text = ds.Tables[0].Rows[0]["VESSEL_NAME"].ToString();
                        txtLineNo.Text = ds.Tables[0].Rows[0]["LINE_NO"].ToString();
                        txtPortofShipment.Text = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
                        txtImportDeptSlno.Text = ds.Tables[0].Rows[0]["IMPORT_DEPT"].ToString();
                        txtRotationNo.Text = ds.Tables[0].Rows[0]["ROTATION_NO_DATE"].ToString();
                        txtCountry.Text = ds.Tables[0].Rows[0]["COUN_CONSIGNMENT"].ToString();
                        txtCountryOrigin.Text = ds.Tables[0].Rows[0]["COUN_ORIGIN"].ToString();

                        txtAWBLNo.Text = ds.Tables[0].Rows[0]["AWBL_NO"].ToString();
                        txtAWBLDate.Text = ds.Tables[0].Rows[0]["AWBL_DATE"].ToString();
                        txtHAWBNo.Text = ds.Tables[0].Rows[0]["HAWB_NO"].ToString();
                        txtHAWBDate.Text = ds.Tables[0].Rows[0]["HAWB_DATE"].ToString();
                        txtGrossWeight.Text = ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();
                        txtTotalPkgs.Text = ds.Tables[0].Rows[0]["TOTAL_PKGS"].ToString();
                        txtAgencyCommission.Text = ds.Tables[0].Rows[0]["AGENCY_COMMISION"].ToString();
                        txtMiscellaneousCharges.Text = ds.Tables[0].Rows[0]["MIS_CHARGES"].ToString();
                        txtMiscCurrency.Text = ds.Tables[0].Rows[0]["MIS_CURRENCY"].ToString();

                        txtInvoiceTerms.Text = ds.Tables[0].Rows[0]["TERMS"].ToString();
                        txtTotalValue.Text = ds.Tables[0].Rows[0]["TOTAL_VAL"].ToString();
                        txtLandingCharges.Text = ds.Tables[0].Rows[0]["LANDING_CHARGES"].ToString();
                        txtDutyValue.Text = ds.Tables[0].Rows[0]["DUTY_VALUE"].ToString();
                        txtAssableValue.Text = ds.Tables[0].Rows[0]["ASSBL_VAL"].ToString();
                        txtITCLicense.Text = ds.Tables[0].Rows[0]["ITC_LICENSE"].ToString();
                        txtInvoiceNoDate.Text = ds.Tables[0].Rows[0]["INVOICE_NO_DATE"].ToString();

                        dutyWords = txtAssableValue.Text;
                       // txtAssableValueinWords.Text = NumtoWords.InWrods(Convert.ToDecimal(dutyWords));

                        btnDelete.Visible = true;
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;

                    }
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                }
            }
            else
            {
                CLEAR_Checking();
                tag_transact_srcinner_rght.Visible = false;
                
            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        
    }

    public void CLEAR_Checking()
     {
         ResetFields_Manual_BE(Page.Controls);
    }

    public void LoadJobNo()
    {
        DataSet ds = new DataSet();
        CheckList chklist = new CheckList();
        chklist.JOBNo = "";
        chklist.Ename = "select_jobno";
        chklist.Workingperiod = SELECT_BRANCH;

        ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }


    public int Insert_Update(string a1, string a2, string a3)
    {

        Manual_BE.M_ID = a1;
        Manual_BE.JOBNO = ddlJobNo.SelectedItem.Text;
        Manual_BE.DATE1=txt_Date.Text;
        Manual_BE.IMPORTER= txtImporter.Text;
        Manual_BE.IM_ADDRESS1=txtAddress1.Text;
        Manual_BE.IM_ADDRESS2=txtAddress2.Text;
        Manual_BE.IM_ADDRESS3=txtAddress3.Text;
        Manual_BE.IM_ADDRESS4=txtAddress4.Text;
        Manual_BE.IM_ADDRESS5=txtAddress5.Text;
        Manual_BE.SUPPLIERNAME=txtConsignee.Text;
        Manual_BE.SUP_ADDRESS1=txtConsignee_Add1.Text;
        Manual_BE.SUP_ADDRESS2=txtConsignee_Add2.Text;
        Manual_BE.SUP_ADDRESS3=txtConsignee_Add3.Text;
        Manual_BE.SUP_ADDRESS4 = txtConsignee_Add3.Text;
        Manual_BE.SUP_ADDRESS5=txtDutyforgone.Text;
        Manual_BE.INCOME_TAX=txtIncometax.Text;
        Manual_BE.PRIOR_STAMP=txtPriorStamp.Text;
        Manual_BE.VESSEL_NAME=txtVesselname.Text;
        Manual_BE.LINE_NO=txtLineNo.Text;
        Manual_BE.PORT_SHIPMENT=txtPortofShipment.Text;
        Manual_BE.IMPORT_DEPT=txtImportDeptSlno.Text;
        Manual_BE.ROTATION_NO_DATE=txtRotationNo.Text;
        Manual_BE.COUN_CONSIGNMENT=txtCountry.Text;
        Manual_BE.COUN_ORIGIN=txtCountryOrigin.Text;
        Manual_BE.AWBL_NO=txtAWBLNo.Text;
        Manual_BE.AWBL_DATE=txtAWBLDate.Text;
        Manual_BE.HAWB_NO=txtHAWBNo.Text;
        Manual_BE.HAWB_DATE=txtHAWBDate.Text;
        Manual_BE.GROSS_WEIGHT=txtGrossWeight.Text;
        Manual_BE.TOTAL_PKGS=txtTotalPkgs.Text;
        Manual_BE.AGENCY_COMMISION=txtAgencyCommission.Text;
        Manual_BE.MIS_CHARGES=txtMiscellaneousCharges.Text;
        Manual_BE.MIS_CURRENCY=txtMiscCurrency.Text;
        Manual_BE.TERMS=txtInvoiceTerms.Text;
        Manual_BE.TOTAL_VAL=txtTotalValue.Text;
        Manual_BE.LANDING_CHARGES=txtLandingCharges.Text;
        Manual_BE.DUTY_VALUE=txtDutyValue.Text;
        Manual_BE.ASSBL_VAL=txtAssableValue.Text;
        Manual_BE.ITC_LICENSE=txtITCLicense.Text;
        Manual_BE.INVOICE_NO_DATE=txtInvoiceNoDate.Text;
        Manual_BE.DUTY_VAL_WORDS=txtDutyValueWords.Text;
        Manual_BE.ASSBL_VAL_WORDS=txtAssableValueinWords.Text;
        Manual_BE.IEC_NO = ViewState["IEC_NO"].ToString();
        Manual_BE.M_BRANCHCODE = Session["currentbranch"].ToString();
        
        Manual_BE.flag=a2;
        Manual_BE.M_YEAR = " ";
        Manual_BE.M_WORKINGPERIOD=Working_Period;
        Manual_BE.BRANCH_COMMON = SELECT_BRANCH;
        

        i = Manual_BE.ManaulBE_Insert_Update();

        return i;
    }

    protected void btnSave_Click1(object sender, EventArgs e)
    {
        try
        {
            gridupdate();

            HiddenField1.Value = ddlJobNo.SelectedValue.ToString();
            ////string a1 = "1";
            string a1 = HiddenField1.Value;

            string a2 = "S";
            string a3 = "";
            i = Insert_Update(a1, a2, a3);
            HiddenField1.Value = Convert.ToString(Manual_BE.UPDATE_ID);

            if (i == 1)
            {
                //-----------------------FOR USER RIGHTS--------------------------------//
                user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);

                PAGE_MODIFY = user_Create.PAGE_MODIFY;


                //---------------SAVE ONLY------------------//

                if (PAGE_MODIFY == "False")
                {
                    btnNew_Click(sender, e);

                }
                else
                {
                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
               
                }
           

                ViewState["UPDATED_ID"] = null;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                Alert_msg("Saved Successfully", "btnSave");
               
            }
            else if (i == 2)
            {

                Alert_msg("Already exixts!", "btnSave");

            }
            else
            {
                Alert_msg("Not Saved", "btnNew");

            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            gridupdate();

            HiddenField1.Value = ddlJobNo.SelectedValue.ToString();
            string a1 = HiddenField1.Value;
            string a2 = "U";
            string a3 = "";
            i = Insert_Update(a1, a2, a3);
            if (i == 1)
            {
                ViewState["UPDATED_ID"] = HiddenField1.Value;

                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully");
                }

                else
                {
                    Alert_msg("Not Saved");

                }
            }
        }



        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            HiddenField1.Value = ddlJobNo.SelectedValue.ToString();

            //Manual_BE.M_ID = HiddenField1.Value;
            Manual_BE.JOBNO = HiddenField1.Value;
            Manual_BE.Working_Period = Working_Period;
            Manual_BE.Branchcode = SELECT_BRANCH;
            Manual_BE.Ename = "Manual_BE_Delete";
            
            Manual_BE.ManualBE_Rpt();
            int i = Manual_BE.result;

            Grid_jobdelete();

            if (i > 0)
            {

                string prompt = "<script>$(document).ready(function(){{jAlert('Manual BE Deleted', 'Manual BE MASTER', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

            }


            else
            {
                Alert_msg("Manual BE Job Deleted");

            }
        }


        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    protected void btnNew_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        
        ddlJobNo.SelectedIndex = -1;

    }

    protected void btn_print_Click(object sender, EventArgs e)
    {


        string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);

    }

    protected void GV_Details_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
        }

    }

    protected void GV_Details_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void GV_Details_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV_Details.PageIndex = e.NewPageIndex;
    }

    

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MANUAL BE', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'MANUAL BE', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    public void ResetFields_Manual_BE(ControlCollection pageControls)
    {
        foreach (System.Web.UI.Control contl in pageControls)
        {
            string strCntName = (contl.GetType()).Name;
            switch (strCntName)
            {
                case "TextBox":
                   System.Web.UI.WebControls.TextBox tbSource = (System.Web.UI.WebControls.TextBox)contl;
                    tbSource.Text = "";
                    break;
              
                case "CheckBox":
                    System.Web.UI.WebControls.CheckBox chkSource = (System.Web.UI.WebControls.CheckBox)contl;
                    chkSource.Checked = false;
                    break;

            }
            ResetFields_Manual_BE(contl.Controls);
        }
       
    }

    
    //------------------------------------------------------ManualBE grid start-------------------------
    private void grid_load()
    {
        DataSet ds = new DataSet();

        Import_ManualBE_LC BE = new Import_ManualBE_LC();
        BE.JOBNO = ddlJobNo.SelectedItem.Text;
        BE.Select_Type = "Select_All";
        BE.Working_Period = Working_Period;

        BE.M_BRANCHCODE = SELECT_BRANCH;
        BE.USER_ID = currentuser;

        ds = BE.Manual_BE_grid();

        GV_Details.DataSource = ds.Tables[0];
        GV_Details.DataBind();
        //GV_Details.Attributes.Add("style", "table-layout:fixed");

    }

    private void Empty_grid()
    {
        DataTable dt = new DataTable();
        GV_Details.DataSource = dt;
        GV_Details.DataBind();
        //GV_Details.Attributes.Add("style", "table-layout:fixed");
    }

    protected void TextBox_TextChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.TextBox thisTextBox = (System.Web.UI.WebControls.TextBox)sender;
        GridViewRow thisGridViewRow = (GridViewRow)thisTextBox.Parent.Parent;
        int row = thisGridViewRow.RowIndex;
        rowChanged[row] = true;
    }

    private void gridupdate()
    {
        if (Page.IsPostBack)
        {
            int totalRows = GV_Details.Rows.Count;
            for (int r = 0; r < totalRows; r++)
            {
                if (rowChanged[r])
                {
                    Import_ManualBE_LC BE = new Import_ManualBE_LC();

                    GridViewRow thisGridViewRow = GV_Details.Rows[r];
                    HiddenField hf1 = (HiddenField)thisGridViewRow.FindControl("HiddenField1");
                    string[] pk = hf1.Value.Split(',');

                    System.Web.UI.WebControls.TextBox txtNumbers_Desc = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtNumbers_Desc");
                    System.Web.UI.WebControls.TextBox txtMarks_Numbers = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtMarks_Numbers");
                    System.Web.UI.WebControls.TextBox txtItem_Slno = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtItem_Slno");
                    System.Web.UI.WebControls.TextBox txtUnit_Code = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtUnit_Code");
                    System.Web.UI.WebControls.TextBox txtWeight = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtWeight");
                    System.Web.UI.WebControls.TextBox txtGoods_Description = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtGoods_Description");
                    System.Web.UI.WebControls.TextBox txtCTH_No_Notn_no = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtCTH_No_Notn_no");
                    System.Web.UI.WebControls.TextBox txtDuty_Code = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtDuty_Code");
                    System.Web.UI.WebControls.TextBox txtAssablevalue = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtAssablevalue");
                    System.Web.UI.WebControls.TextBox txtCTH_Rate = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtCTH_Rate");
                    System.Web.UI.WebControls.TextBox txtCTH_AMT = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtCTH_AMT");
                    System.Web.UI.WebControls.TextBox txtCETH_Not = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtCETH_Not");
                    System.Web.UI.WebControls.TextBox txtCol9_and_11 = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtCol9_and_11");
                    System.Web.UI.WebControls.TextBox txtCETH_Rate = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtCETH_Rate");
                    System.Web.UI.WebControls.TextBox txtCETH_Amt = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtCETH_Amt");
                    System.Web.UI.WebControls.TextBox txtTotal_Duty = (System.Web.UI.WebControls.TextBox)thisGridViewRow.FindControl("txtTotal_Duty");


                    BE.Sl_No = pk[0].ToString();
                    BE.Jobno = ddlJobNo.SelectedItem.Text;
                    BE.Numbers_Desc = txtNumbers_Desc.Text;
                    BE.Marks_Numbers = txtMarks_Numbers.Text;
                    BE.Item_Slno = txtItem_Slno.Text;
                    BE.Unit_Code = txtUnit_Code.Text;
                    BE.Weight = txtWeight.Text;
                    BE.Goods_Description = txtGoods_Description.Text;
                    BE.CTH_No_Notn_no = txtCTH_No_Notn_no.Text;
                    BE.Duty_Code = txtDuty_Code.Text;
                    BE.Assablevalue = txtAssablevalue.Text;
                    BE.CTH_Rate = txtCTH_Rate.Text;
                    BE.CTH_AMT = txtCTH_AMT.Text;

                    BE.CETH_Not = txtCETH_Not.Text;
                    BE.Col9_and_11 = txtCol9_and_11.Text;
                    BE.CETH_Rate = txtCETH_Rate.Text;
                    BE.CETH_Amt = txtCETH_Amt.Text;
                    BE.Total_Duty = txtTotal_Duty.Text;
                    BE.M_BRANCHCODE = SELECT_BRANCH;
                    BE.M_WORKINGPERIOD = Working_Period;
                    BE.USER_ID = currentuser;
                    BE.Flag = "U";

                    BE.Manual_BE_insertupdate();
                }
            }
            GV_Details.DataBind();
            grid_load();
        }
    }

    private void Grid_jobdelete()
    {
        Import_ManualBE_LC BE = new Import_ManualBE_LC();
        BE.JOBNO = ddlJobNo.SelectedItem.Text;
        BE.Select_Type = "Delete";
        BE.Working_Period = Working_Period;

        BE.M_BRANCHCODE = SELECT_BRANCH;
        BE.USER_ID = currentuser;
        BE.Manual_BE_grid();

        grid_load();
    }

}