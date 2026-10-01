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
using System.Linq;

public partial class Do_entry : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    DO_Entry DO = new DO_Entry();
    Global_variables ObjUBO = new Global_variables();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE,COMPANY_LICENSE;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        COMPANY_LICENSE = Connection.Company_License().ToLower();

        if (!Page.IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            //btnrpt.Visible = false;
            T.Visible = false;


            if (Request.QueryString["Page"] == null)
            {
               load_Cus_Name();
               HDupdate_id.Value = "";
               load_Ref_Id();
               SetInitialRow();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                    //SetInitialRow();
                    //SetPreviousData();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlCus_name.Enabled = false;
                    ddljobno.Enabled = false;
                   
                    HD_Showcon.Value = "SAVED";
                    ViewState["UPDATED_ID"] = null;
                }
            }
            

            txt_Ref_Id.Attributes.Add("readonly", "readonly");
            txt_Ref_Id.Style.Add("background-color", "#F0F0F0");
        }

    }
    
  private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Request.QueryString["Jobno"].ToString();
        ObjUBO.A2 = Request.QueryString["Page"].ToString();
        ObjUBO.A4 = "Update_Job_Values";
        dss = DO.DO_ENTRY_SELECT(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {

            //-----------------------------------------------------
            HDupdate_id.Value = dss.Tables[0].Rows[0]["DO_ID"].ToString();
             txt_Ref_Id.Text=  dss.Tables[0].Rows[0]["REF_ID"].ToString();
             ddlCus_name.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString(), dss.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString()));
             ddlCus_name.SelectedIndex = 0;
             ddljobno.Items.Insert(0, new ListItem (dss.Tables[0].Rows[0]["JOBNO"].ToString()));
             ddljobno.SelectedIndex = 0;
             txt_Manual_Jobno.Text=dss.Tables[0].Rows[0]["MANUAL_JOBNO"].ToString();
             txt_Consigee_Name.Text = dss.Tables[0].Rows[0]["Consignee_name"].ToString();
             txt_MBL_No.Text = dss.Tables[0].Rows[0]["MBL_NO"].ToString();
             txt_HBL_No.Text = dss.Tables[0].Rows[0]["HBL_NO"].ToString();
             txt_Pkg.Text = dss.Tables[0].Rows[0]["NO_OF_PKG"].ToString();
             ddl_Mode_Type.SelectedValue = dss.Tables[0].Rows[0]["LCL_FCL_AIR"].ToString();
             txt_20_F.Text = dss.Tables[0].Rows[0]["TWENTY_FEET_CNT"].ToString();
             txt_40_F.Text = dss.Tables[0].Rows[0]["FORTY_FEET_CNT"].ToString();
             txt_Gross_Wgt.Text = dss.Tables[0].Rows[0]["GROSS_WGT"].ToString();
             txt_Net_Wgt.Text = dss.Tables[0].Rows[0]["NET_WGT"].ToString();
             Txt_remarks.Text = dss.Tables[0].Rows[0]["Remarks"].ToString();
             Txt_ETA.Text = dss.Tables[0].Rows[0]["ETA"].ToString();

             DataTable dt_item = new DataTable();
             DataRow dr = null;
            
             dt_item.Columns.Add(new DataColumn("RowNumber", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Liner_name", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Consol_Name", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Consol_charges", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Line_Charge", typeof(string)));
             dt_item.Columns.Add(new DataColumn("DO_Free_days", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Port_Storage_Amt", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Port_do_Revalidition", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Detention_Amt", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Detention_do_Revalidition", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Damage_Charges", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Late_do_fee", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Tax_Invoice_No", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Tax_Invoice_Date", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Tax_Invoice_Amount", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Holding_Chq_No", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Holding_Chq_Date", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Holding_Amt", typeof(string)));
             dt_item.Columns.Add(new DataColumn("UTR_NO", typeof(string)));
             dt_item.Columns.Add(new DataColumn("UTR_Date", typeof(string)));
             dt_item.Columns.Add(new DataColumn("UTR_Amt", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Holding_chq_return_date", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Holding_Received_Date", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Do_Applied_date", typeof(string)));
             dt_item.Columns.Add(new DataColumn("Do_Received_date", typeof(string)));

             if (dss.Tables[0].Rows[0]["Liner_name"].ToString().Contains("~"))
             {
                 string[] linename = dss.Tables[0].Rows[0]["Liner_name"].ToString().Split('~');
                 string[] Consolname = dss.Tables[0].Rows[0]["Consol_Name"].ToString().Split('~');
                 string[] Consolcharges = dss.Tables[0].Rows[0]["Consol_charges"].ToString().Split('~');
                 string[] linechg = dss.Tables[0].Rows[0]["Line_Charge"].ToString().Split('~');
                 string[] DOFreedays = dss.Tables[0].Rows[0]["DO_Free_days"].ToString().Split('~');
                 string[] PortStorageAmt = dss.Tables[0].Rows[0]["Port_Storage_Amt"].ToString().Split('~');
                 string[] PortDORevalid = dss.Tables[0].Rows[0]["Port_do_Revalidition"].ToString().Split('~');
                 string[] DetentionAmt = dss.Tables[0].Rows[0]["Detention_Amt"].ToString().Split('~');
                 string[] DetenDORevalid = dss.Tables[0].Rows[0]["Detention_do_Revalidition"].ToString().Split('~');
                 string[] DamageChges = dss.Tables[0].Rows[0]["Damage_Charges"].ToString().Split('~');
                 string[] LateDoFee = dss.Tables[0].Rows[0]["Late_do_fee"].ToString().Split('~');
                 string[] tax = dss.Tables[0].Rows[0]["Tax_Invoice_No"].ToString().Split('~');
                 string[] TaxInvoiceDate = dss.Tables[0].Rows[0]["Tax_Invoice_Date"].ToString().Split('~');
                 string[] TaxInvoiceAmount = dss.Tables[0].Rows[0]["Tax_Invoice_Amount"].ToString().Split('~');
                 string[] HoldingChqNo = dss.Tables[0].Rows[0]["Holding_chq_No"].ToString().Split('~');
                 string[] HoldingChqDate = dss.Tables[0].Rows[0]["Holding_Chq_date"].ToString().Split('~');
                 string[] HoldingAmt = dss.Tables[0].Rows[0]["Holding_Amt"].ToString().Split('~');
                 string[] UTR_NO = dss.Tables[0].Rows[0]["UTR_No"].ToString().Split('~');
                 string[] UTR_Date = dss.Tables[0].Rows[0]["UTR_Date"].ToString().Split('~');
                 string[] UTRAmount = dss.Tables[0].Rows[0]["UTR_Amt"].ToString().Split('~');
                 string[] Holdingreturndt = dss.Tables[0].Rows[0]["Holding_chq_return_date"].ToString().Split('~');
                 string[] HoldingReceivedDate = dss.Tables[0].Rows[0]["Holding_Received_Date"].ToString().Split('~');
                 string[] Do_Applied_date = dss.Tables[0].Rows[0]["Do_Applied_date"].ToString().Split('~');
                 string[] Do_Received_date = dss.Tables[0].Rows[0]["Do_Received_date"].ToString().Split('~');
                 //string[] transporter = dss.Tables[0].Rows[0]["TRANSPORTER"].ToString().Split('~');
                 for (int k = 0; k <= Consolname.Count() - 1; k++)
                 {
                     if (linename[k] != "")
                     {
                         dt_item.Rows.Add(k + 1, linename[k], Consolname[k], Consolcharges[k], linechg[k], DOFreedays[k], PortStorageAmt[k], PortDORevalid[k], DetentionAmt[k], DetenDORevalid[k],
                            DamageChges[k], LateDoFee[k], tax[k], TaxInvoiceDate[k], TaxInvoiceAmount[k], HoldingChqNo[k], HoldingChqDate[k], HoldingAmt[k], UTR_NO[k],
                             UTR_Date[k], UTRAmount[k], Holdingreturndt[k], HoldingReceivedDate[k], Do_Applied_date[k], Do_Received_date[k]);
                     }

                 }

                 gvAll.DataSource = dt_item;
                 gvAll.DataBind();
                 ViewState["CurrentTable"] = dt_item;
                 SetPreviousData();
                 ViewState["UPDATED_ID"] = "U";
                 //DataTable firstTable = dss.Tables[1];
                 //ViewState["CurrentTable"] = firstTable;
             }
             else
             {
                 dt_item.Rows.Add("");
                 //SetInitialRow();
             }

            // txt_tax_inv_no.Text = dss.Tables[0].Rows[0]["Tax_Invoice_No"].ToString();
             //txt_Pkg.Text = dss.Tables[0].Rows[0]["NO_OF_PKG"].ToString();
             //txt_Gross_Wgt.Text=dss.Tables[0].Rows[0]["GROSS_WGT"].ToString();
            // txt_Net_Wgt.Text=dss.Tables[0].Rows[0]["NET_WGT"].ToString();
             //txt_Line_Chg.Text = dss.Tables[0].Rows[0]["Line_Charge"].ToString();
             //txt_Console_chg.Text = dss.Tables[0].Rows[0]["Consol_charges"].ToString();
             //txt_port_Str_amt.Text = dss.Tables[0].Rows[0]["Port_Storage_Amt"].ToString();
             //txt_Detent_Amt.Text = dss.Tables[0].Rows[0]["Detention_Amt"].ToString();
             //txt_dam_chg.Text = dss.Tables[0].Rows[0]["Damage_Charges"].ToString();
             //Txt_remarks.Text = dss.Tables[0].Rows[0]["Remarks"].ToString();
             //txt_UTR_No.Text = dss.Tables[0].Rows[0]["UTR_No"].ToString();
             //txt_UTR_date.Text = dss.Tables[0].Rows[0]["UTR_Date"].ToString();
             //txt_UTR_Amt.Text = dss.Tables[0].Rows[0]["UTR_Amt"].ToString();
             //txt_Hold_chq.Text = dss.Tables[0].Rows[0]["Holding_chq_No"].ToString();
             //txt_Hold_chq_date.Text = dss.Tables[0].Rows[0]["Holding_Chq_date"].ToString();
             //txt_port_revalidation.Text = dss.Tables[0].Rows[0]["Port_do_Revalidition"].ToString();
             //txt_do_fee.Text = dss.Tables[0].Rows[0]["Late_do_fee"].ToString();
             //txt_detention_revalidation.Text = dss.Tables[0].Rows[0]["Detention_do_Revalidition"].ToString();
             //txt_Hold_amt.Text = dss.Tables[0].Rows[0]["Holding_Amt"].ToString();
             //txt_Manual_Jobno.Text = dss.Tables[0].Rows[0]["CFS_MANUAL_JOBNO"].ToString();
             //txt_Job_dt.Text = dss.Tables[0].Rows[0]["CFS_JOBDATE"].ToString(); ;
             //txt_CHA_Ref_No.Text = dss.Tables[0].Rows[0]["CFS_FILE_REF_NO"].ToString();
             //txt_LCL.Text = dss.Tables[0].Rows[0]["CFS_LCL"].ToString();
             //txt_20_F.Text = dss.Tables[0].Rows[0]["CFS_TWENTY_FEET_CNT"].ToString();
             //txt_40_F.Text = dss.Tables[0].Rows[0]["CFS_FORTY_FEET_CNT"].ToString();
             //txt_FCL.Text = dss.Tables[0].Rows[0]["CFS_FCL"].ToString();
             //txt_Gross_wght.Text = dss.Tables[0].Rows[0]["CFS_GROSS_WGT"].ToString();
             //txt_BB.Text = dss.Tables[0].Rows[0]["CFS_BB"].ToString();
             //txt_CFS_Name.Text = dss.Tables[0].Rows[0]["CFS_Name"].ToString();
             //txt_Staff_Name.Text = dss.Tables[0].Rows[0]["CFS_Staff_Name"].ToString();
             //txt_trans_name.Text = dss.Tables[0].Rows[0]["CFS_Transporter_name"].ToString();
             //txt_Vehic_type.Text = dss.Tables[0].Rows[0]["CFS_Vehicle_type"].ToString();
             //txt_Veh_no.Text = dss.Tables[0].Rows[0]["CFS_Vehicle_No"].ToString();
             //txt_Inv_No.Text = dss.Tables[0].Rows[0]["CFS_Inv_No"].ToString();
             //txt_Inv_Date.Text = dss.Tables[0].Rows[0]["CFS_Inv_Date"].ToString();
             //txt_Inv_Amt.Text = dss.Tables[0].Rows[0]["CFS_Inv_Amt"].ToString();
             //txt_CFS_Dem_Charge.Text = dss.Tables[0].Rows[0]["CFS_Demmurage_Charges"].ToString();
             ////ddlCus_name.SelectedItem.ToString();
             ////ObjUBO.A57 = ddljobno.SelectedValue.ToString();
             //txt_Manual_Jobno.Text = dss.Tables[0].Rows[0]["AAI_MANUAL_JOBNO"].ToString();
             //txt_Job_date.Text = dss.Tables[0].Rows[0]["AAI_JOBDATE"].ToString();
             //txt_Cha_Ref_Num.Text = dss.Tables[0].Rows[0]["AAI_FILE_REF_NO"].ToString();
             //txt_no_pkgs.Text = dss.Tables[0].Rows[0]["AAI_NO_OF_PKG"].ToString();
             //txt_Gross_Wgt.Text = dss.Tables[0].Rows[0]["AAI_GROSS_WGT"].ToString();
             //txt_Chrg_wght.Text = dss.Tables[0].Rows[0]["AAI_Chargable_Weight"].ToString();
             //txt_airstaff_name.Text = dss.Tables[0].Rows[0]["AAI_Airport_Staff_Name"].ToString();
             //txt_transport_name.Text = dss.Tables[0].Rows[0]["AAI_Transporter_name"].ToString();
             //txt_vehicle_type.Text = dss.Tables[0].Rows[0]["AAI_Vehicle_type"].ToString();
             //txt_vehicle_No.Text = dss.Tables[0].Rows[0]["AAI_Vehicle_No"].ToString();
             //txt_Invoice_no.Text = dss.Tables[0].Rows[0]["AAI_Inv_No"].ToString();
             //txt_Invoice_date.Text = dss.Tables[0].Rows[0]["AAI_Inv_Date"].ToString();
             //txt_invoice_amt.Text = dss.Tables[0].Rows[0]["AAI_Inv_Amt"].ToString();
             //txt_Demur_Charge.Text = dss.Tables[0].Rows[0]["AAI_Demmurage_Charges"].ToString();
             
              
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

       
            i = DO_Jobno_Insert_Update(Imp_name, "S");
        
        //if (ddl_entry_type.SelectedValue.ToString() == "CFS")
        //{
        //    i = CFS_Jobno_Insert_Update(Imp_name, "S");
        //}
                                if (i == 1)
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
                                    HDupdate_id.Value = Convert.ToString(DO.UPDATE_ID);

                                    //btnrpt.Visible = true;
                                  
                                    F.Visible = false;
                                    T.Visible = true;

                                    ddlCus_name.Attributes.Add("readonly", "readonly");
                                    ddlCus_name.Style.Add("background-color", "#F0F0F0");

                                    ddljobno.Attributes.Add("readonly", "readonly");
                                    ddljobno.Style.Add("background-color", "#F0F0F0");

                                    ddlCus_name.Enabled = false;
                                    ddljobno.Enabled = false;

                                }
                                else if (i == 2)
                                {
                                    Alert_msg("Job No Already Exist!", "btnSave");
                                }
                                else
                                {
                                    btnUpdate.Visible = false;
                                    btnDelete.Visible = false;
                                    btnSave.Visible = true;
                                    btnNew.Visible = true;
                                    Alert_msg("Not Saved", "btnSave");
                                }
                                //-------------------------------------------------------------
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = DO_Jobno_Insert_Update(Imp_name, "U");
                    if (i == 1)
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
                    else if (i == 2)
                    {
                        Alert_msg("Job No Already Exist!", "btnUpdate");
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
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            i = DO_Jobno_Insert_Update("", "D");
            if (i == 1)
            {
                btnNew_Click1(sender, e);
                Alert_msg("Deleted");
               // btnrpt.Visible = false;
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
  
   public int DO_Jobno_Insert_Update(string I_Name , string Flag )
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();

        ObjUBO.A2 = ddlCus_name.SelectedItem.ToString();
        ObjUBO.A3 = ddljobno.SelectedValue.ToString();
        //ObjUBO.A4 = ddljobno.SelectedItem.ToString();
        ObjUBO.A4 = txt_Manual_Jobno.Text;
        ObjUBO.A5 = txt_MBL_No.Text;
        ObjUBO.A6 = txt_HBL_No.Text;
        ObjUBO.A7 = txt_Pkg.Text;
        ObjUBO.A8 = ddl_Mode_Type.SelectedValue.ToString();
        ObjUBO.A9 = txt_20_F.Text;
        ObjUBO.A10 = txt_40_F.Text;
        ObjUBO.A11 = txt_Gross_Wgt.Text;
        ObjUBO.A12 = txt_Net_Wgt.Text;
        //ObjUBO.A13 = (txt_tax_inv_no.Text == "" ? "0" : txt_tax_inv_no.Text);
        //ObjUBO.A14 = (txt_Line_Chg.Text == "" ? "0" : txt_Line_Chg.Text);
        //ObjUBO.A15 = (txt_Console_chg.Text == "" ? "0" : txt_Console_chg.Text);
        //ObjUBO.A16 = (txt_port_Str_amt.Text == "" ? "0" : txt_port_Str_amt.Text);
        //ObjUBO.A17 = (txt_Detent_Amt.Text == "" ? "0" : txt_Detent_Amt.Text);
        //ObjUBO.A18 = (txt_dam_chg.Text == "" ? "0" : txt_dam_chg.Text);
        //ObjUBO.A19 = txt_UTR_No.Text;
        //ObjUBO.A20 = txt_UTR_date.Text;
        //ObjUBO.A21 = (txt_UTR_Amt.Text == "" ? "0" : txt_UTR_Amt.Text);
        //ObjUBO.A22 = txt_Hold_chq.Text;
        //ObjUBO.A23 = txt_Hold_chq_date.Text;
        ObjUBO.A24 = Txt_remarks.Text;
       
        //ObjUBO.A33 = ddlCus_name.SelectedItem.ToString();
        //ObjUBO.A34 = ddljobno.SelectedValue.ToString();
        //ObjUBO.A35 = txt_Manual_Jobno.Text;
        //ObjUBO.A36 = txt_Job_dt.Text;
        //ObjUBO.A37= txt_CHA_Ref_No.Text;
        //ObjUBO.A38 = txt_LCL.Text;
        //ObjUBO.A39 = txt_20_F.Text;
        //ObjUBO.A40 = txt_40_F.Text;
        //ObjUBO.A41 = txt_FCL.Text;
        //ObjUBO.A42 = txt_Gross_wght.Text;
        //ObjUBO.A43 = txt_BB.Text;
        //ObjUBO.A44 = txt_CFS_Name.Text;
        //ObjUBO.A45 = txt_Staff_Name.Text;
        //ObjUBO.A46 = txt_trans_name.Text;
        //ObjUBO.A47 = txt_Vehic_type.Text;
        //ObjUBO.A48 = txt_Veh_no.Text;
        //ObjUBO.A49 = txt_Inv_No.Text;
        //ObjUBO.A50 = txt_Inv_Date.Text;
        //ObjUBO.A51 = txt_Inv_Amt.Text;
        //ObjUBO.A52 = txt_CFS_Dem_Charge.Text;
        //ObjUBO.A55 = ddlCus_name.SelectedItem.ToString();
        //ObjUBO.A57 = ddljobno.SelectedValue.ToString();
        //ObjUBO.A56 = txt_Manual_Jobno.Text;
        //ObjUBO.A58 = txt_Job_date.Text;
        //ObjUBO.A59 = txt_Cha_Ref_Num.Text;
        //ObjUBO.A60 = txt_no_pkgs.Text;
        //ObjUBO.A61 = txt_Gross_Wgt.Text;
        //ObjUBO.A62 = txt_Chrg_wght.Text;
        //ObjUBO.A63 = txt_airstaff_name.Text;
        //ObjUBO.A64 = txt_transport_name.Text;
        //ObjUBO.A65 = txt_vehicle_type.Text;
        //ObjUBO.A66 = txt_vehicle_No.Text;
        //ObjUBO.A67 = txt_Invoice_no.Text;
        //ObjUBO.A68 = txt_Invoice_date.Text;
        //ObjUBO.A69 = txt_invoice_amt.Text;
        //ObjUBO.A70 = txt_Demur_Charge.Text;
        ObjUBO.A25 = Flag;
        ObjUBO.A26 = txt_Ref_Id.Text;
        ObjUBO.A27 = txt_Consigee_Name.Text;
       // ObjUBO.A35 = ddl_entry_type.SelectedValue.ToString();
        //ObjUBO.A28 = txt_do_fee.Text;
        //ObjUBO.A29 = txt_port_revalidation.Text;
        //ObjUBO.A30 = txt_detention_revalidation.Text;
        //ObjUBO.A31 = txt_Hold_amt.Text;

        ObjUBO.A50 = Txt_ETA.Text;

        foreach (GridViewRow row in gvAll.Rows)
        {
            TextBox txt_Line_Name = (TextBox)row.FindControl("txt_Line_Name");
            TextBox txt_Console_chg = (TextBox)row.FindControl("txt_Console_chg");
            TextBox txt_Console_Name = (TextBox)row.FindControl("txt_Console_Name");
            TextBox txt_Line_Chg = (TextBox)row.FindControl("txt_Line_Chg");
            TextBox txt_do_free_days = (TextBox)row.FindControl("txt_do_free_days");
            TextBox txt_port_Str_amt = (TextBox)row.FindControl("txt_port_Str_amt");
            TextBox txt_port_revalidation = (TextBox)row.FindControl("txt_port_revalidation");
            TextBox txt_Detent_Amt = (TextBox)row.FindControl("txt_Detent_Amt");
            TextBox txt_detention_revalidation = (TextBox)row.FindControl("txt_detention_revalidation");
            TextBox txt_dam_chg = (TextBox)row.FindControl("txt_dam_chg");
            TextBox txt_do_fee = (TextBox)row.FindControl("txt_do_fee");
            TextBox txt_tax_inv_no = (TextBox)row.FindControl("txt_tax_inv_no");
            TextBox txt_Tax_Inv_date = (TextBox)row.FindControl("txt_Tax_Inv_date");
            TextBox txt_tax_inv_amt = (TextBox)row.FindControl("txt_tax_inv_amt");
            TextBox txt_Hold_chq = (TextBox)row.FindControl("txt_Hold_chq");
            TextBox txt_Hold_chq_date = (TextBox)row.FindControl("txt_Hold_chq_date");
            TextBox txt_Hold_amt = (TextBox)row.FindControl("txt_Hold_amt");
            TextBox txt_UTR_No = (TextBox)row.FindControl("txt_UTR_No");
            TextBox txt_UTR_date = (TextBox)row.FindControl("txt_UTR_date");
            TextBox txt_UTR_Amt = (TextBox)row.FindControl("txt_UTR_Amt");
            TextBox txt_Hold_chq_return_date = (TextBox)row.FindControl("txt_Hold_chq_return_date");
            TextBox txt_hold_rec_date = (TextBox)row.FindControl("txt_hold_rec_date");
            TextBox txt_Do_Applied_date = (TextBox)row.FindControl("txt_Do_Applied_date");
            TextBox txt_Do_Received_date = (TextBox)row.FindControl("txt_Do_Received_date");




            if (txt_Line_Name.Text != "")
            {
                //ObjUBO.A13 += Convert.ToDecimal(txt_tax_inv_no.Text == "" ? "0.00" : txt_tax_inv_no.Text) +"~";
                ObjUBO.A32 += txt_Line_Name.Text + "~";
                ObjUBO.A15 += txt_Console_chg.Text + "~";
                ObjUBO.A33 +=  txt_Console_Name.Text + "~";
                ObjUBO.A14 += txt_Line_Chg.Text + "~";
                ObjUBO.A36 += txt_do_free_days.Text + "~";
                ObjUBO.A16 += txt_port_Str_amt.Text + "~";
                ObjUBO.A29 += txt_port_revalidation.Text + "~";
                ObjUBO.A17 += txt_Detent_Amt.Text + "~";
                ObjUBO.A30 += txt_detention_revalidation.Text + "~";
                ObjUBO.A18 += txt_dam_chg.Text + "~";
                ObjUBO.A28 += txt_do_fee.Text + "~";
                ObjUBO.A13 += txt_tax_inv_no.Text + "~";
                ObjUBO.A37 += txt_Tax_Inv_date.Text + "~";
                ObjUBO.A38 += txt_tax_inv_amt.Text + "~";
                ObjUBO.A22 += txt_Hold_chq.Text + "~";
                ObjUBO.A23 += txt_Hold_chq_date.Text + "~";
                ObjUBO.A31 += txt_Hold_amt.Text + "~";
                ObjUBO.A19 += txt_UTR_No.Text + "~";
                ObjUBO.A20 += txt_UTR_date.Text + "~";
                ObjUBO.A21 += txt_UTR_Amt.Text + "~";
                ObjUBO.A34 += txt_Hold_chq_return_date.Text + "~";
                ObjUBO.A39 += txt_hold_rec_date.Text + "~";
                ObjUBO.A40 += txt_Do_Applied_date.Text + "~";
                ObjUBO.A41 += txt_Do_Received_date.Text + "~";
                
                //ObjUBO.A15 += Convert.ToDecimal(txt_Console_chg.Text == "" ? "0.00" : txt_Console_chg.Text);
                //ObjUBO.A16 += Convert.ToDecimal(txt_port_Str_amt.Text == "" ? "0.00" : txt_port_Str_amt.Text);
                //ObjUBO.A17 += Convert.ToDecimal(txt_Detent_Amt.Text  == "" ? "0.00" : txt_Detent_Amt.Text );
                //ObjUBO.A18 += Convert.ToDecimal(txt_dam_chg.Text == "" ? "0.00" :txt_dam_chg.Text);
                //ObjUBO.A21 += Convert.ToDecimal(txt_UTR_Amt.Text == "" ? "0.00" : txt_UTR_Amt.Text);
                
            }
        }

        DO.DO_INS_UPD(ObjUBO);
        i = DO.result;
        return i;
    }
/*public int CFS_Jobno_Insert_Update(string I_Name, string Flag)
   {
       ObjUBO.A1 = HDupdate_id.Value.ToString();

       ObjUBO.A2 = ddlCus_name.SelectedItem.ToString();
       ObjUBO.A3 = ddljobno.SelectedValue.ToString();
       //ObjUBO.A4 = ddljobno.SelectedItem.ToString();
       ObjUBO.A4 = txt_Manual_Jobno.Text;
       //ObjUBO.A5 = txt_Job_dt.Text;
       ObjUBO.A6 = txt_CHA_Ref_No.Text;
       ObjUBO.A7 = txt_twenty_cont.Text;
       ObjUBO.A8 = txt_LCL.Text;
       ObjUBO.A9 = txt_20_F.Text;
       ObjUBO.A10 = txt_40_F.Text;
       ObjUBO.A11 = txt_FCL.Text;
       ObjUBO.A12 = txt_Gross_wght.Text;
       ObjUBO.A13 = txt_BB.Text;
       ObjUBO.A14 = txt_CFS_Name.Text;
       ObjUBO.A15 = txt_Staff_Name.Text;
       //ObjUBO.A16 = txt_trans_name.Text;
       //ObjUBO.A17 = txt_Vehic_type.Text;
       //ObjUBO.A18 =txt_Veh_no.Text;
       //ObjUBO.A19 = txt_Inv_No.Text;
       //ObjUBO.A20 = txt_Inv_Date.Text;
       //ObjUBO.A21 = txt_Inv_Amt.Text;
       //ObjUBO.A22 = txt_CFS_Dem_Charge.Text;
       //ObjUBO.A23 = txt_Hold_chq_date.Text;
       //ObjUBO.A24 = Txt_remarks.Text;
       ObjUBO.A25 = Flag;
       ObjUBO.A26 = txt_Ref_Id.Text;
       ObjUBO.A27 = txt_Consigee_Name.Text;
       ObjUBO.A36 = ddl_entry_type.SelectedValue.ToString();
       //ObjUBO.A28 = txt_do_fee.Text;
       //ObjUBO.A29 = txt_port_revalidation.Text;
       //ObjUBO.A30 = txt_detention_revalidation.Text;
       //ObjUBO.A31 = txt_Hold_amt.Text;
       DO.CFS_INS_UPD(ObjUBO);
       i = DO.result;
       return i;
   }*/
/*public int AAI_Jobno_Insert_Update(string I_Name, string Flag)
{
    ObjUBO.A1 = HDupdate_id.Value.ToString();

    ObjUBO.A2 = ddlCus_name.SelectedItem.ToString();
    ObjUBO.A3 = ddljobno.SelectedValue.ToString();
    //ObjUBO.A4 = ddljobno.SelectedItem.ToString();
    ObjUBO.A4 = txt_Manual_Jobno.Text;
    ObjUBO.A5 = txt_Job_date.Text;
    ObjUBO.A6 = txt_Cha_Ref_Num.Text;
    ObjUBO.A7 = txt_no_pkgs.Text;
    //ObjUBO.A8 = ddl_Mode_Type.SelectedValue.ToString();
    //ObjUBO.A9 = txt_20_F.Text;
    //ObjUBO.A10 = txt_40_F.Text;
    ObjUBO.A11 = txt_Gross_Wgt.Text;
    ObjUBO.A12 = txt_Chrg_wght.Text;
    ObjUBO.A13 = txt_airstaff_name.Text;
    ObjUBO.A14 = txt_transport_name.Text;
    ObjUBO.A15 = txt_vehicle_type.Text;
    ObjUBO.A16 =  txt_vehicle_No.Text;
    ObjUBO.A17 = txt_Invoice_no.Text;
    ObjUBO.A18 = txt_Invoice_date.Text;
    ObjUBO.A19 = txt_invoice_amt.Text;
    ObjUBO.A20 = txt_Demur_Charge.Text;
    //ObjUBO.A21 = (txt_UTR_Amt.Text == "" ? "0" : txt_UTR_Amt.Text);
    //ObjUBO.A22 = txt_Hold_chq.Text;
    //ObjUBO.A23 = txt_Hold_chq_date.Text;
    //ObjUBO.A24 = Txt_remarks.Text;
    ObjUBO.A25 = Flag;
    ObjUBO.A26 = txt_Ref_Id.Text;
    ObjUBO.A27 = txt_Consigee_Name.Text;
    ObjUBO.A28 = txt_do_fee.Text;
    ObjUBO.A29 = txt_port_revalidation.Text;
    ObjUBO.A30 = txt_detention_revalidation.Text;
    ObjUBO.A31 = txt_Hold_amt.Text;
 *  ObjUBO.A36 = ddl_entry_type.SelectedValue.ToString();
    DO.AAI_INS_UPD(ObjUBO);
    i = DO.result;
    return i;
}*/
private void load_Cus_Name()
    {
        try
        {
            ddlCus_name.Items.Clear();
            ddljobno.Items.Clear();

            DataSet dss = new DataSet();
            ObjUBO.A4 = "Imp_Name_Select";
            dss = DO.DO_ENTRY_SELECT(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlCus_name.DataSource = dss.Tables[0];
                ddlCus_name.DataTextField = "Cus_Name";
                ddlCus_name.DataValueField = "Cus_Name";
                ddlCus_name.DataBind();
            }
            ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCus_name.SelectedIndex = 0;

            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Jobno()
    {
        ddljobno.Items.Clear();
        try
        {
            if (ddlCus_name.SelectedValue.ToString() != string.Empty)
            {
                DataSet dss = new DataSet();
                ObjUBO.A3 = ddlCus_name.SelectedValue.ToString();
                ObjUBO.A4 = "Jobno_Select";
                dss = DO.DO_ENTRY_SELECT(ObjUBO);
                //-----------end---------------------
                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddljobno.DataSource = dss.Tables[0];
                    ddljobno.DataTextField = "JOBNO";
                    ddljobno.DataValueField = "JOBNO";
                    ddljobno.DataBind();
                }
            }

            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Ref_Id()
    {
       
            DataSet dss = new DataSet();
            ObjUBO.A4 = "Load_Ref_Id";
            dss = DO.DO_ENTRY_SELECT(ObjUBO);
            //-----------end---------------------
            if (dss.Tables[0].Rows.Count > 0)
            {
                txt_Ref_Id.Text = dss.Tables[0].Rows[0]["REF_ID"].ToString();
            }
        
       
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        HDupdate_id.Value = string.Empty;

        ddlCus_name.Enabled = true;
        ddljobno.Enabled = true;
        //btnrpt.Visible = false;

        load_Cus_Name();

        ddlCus_name.Style.Add("background-color", "white");
        ddljobno.Style.Add("background-color", "white");

        load_Ref_Id();
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_data();
    }
    protected void ddlCus_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Jobno();
    }
    private void Load_data()
    {
        DataSet ds = new DataSet();
        if (ddljobno.SelectedValue.ToString() != string.Empty)
        {
            ObjUBO.A1 = ddljobno.SelectedValue.ToString();
            ObjUBO.A3 = ddlCus_name.SelectedValue.ToString();
            ObjUBO.A4 = "IMP_Job_Data";
            ds = DO.DO_ENTRY_SELECT(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_Consigee_Name.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                //txt_Job_dt.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                //txt_Job_date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                //txt_CHA_Ref_No.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                //txt_Cha_Ref_Num.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                txt_MBL_No.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                txt_HBL_No.Text = ds.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString();
                txt_Pkg.Text = ds.Tables[1].Rows[0]["NO_OF_PKG"].ToString();
                txt_Gross_Wgt.Text = ds.Tables[1].Rows[0]["GROSS_WGT"].ToString();
                txt_Net_Wgt.Text = ds.Tables[1].Rows[0]["NET_WGT"].ToString();
                Txt_ETA.Text = ds.Tables[1].Rows[0]["IGM_FLIGHT_VESSELDATE"].ToString();
                //txt_gros_wght.Text = ds.Tables[1].Rows[0]["GROSS_WGT"].ToString();
                //txt_Gross_wght.Text = ds.Tables[1].Rows[0]["GROSS_WGT"].ToString();
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                
                ddl_Mode_Type.SelectedValue = ds.Tables[2].Rows[0]["FCL_OR_LCL"].ToString();
                txt_20_F.Text = ds.Tables[2].Rows[0]["T20w_Ft"].ToString();
                txt_40_F.Text = ds.Tables[2].Rows[0]["F40_Ft"].ToString();
                //txt_twenty_cont.Text = ds.Tables[2].Rows[0]["T20w_Ft"].ToString();
                //txt_forty_Cont.Text = ds.Tables[2].Rows[0]["F40_Ft"].ToString();
                //txt_LCL.Text = ds.Tables[2].Rows[0]["FCL_OR_LCL"].ToString();
                //txt_FCL.Text = ds.Tables[2].Rows[0]["FCL_OR_LCL"].ToString();
            }

        }
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();

        DataRow dr = null;
       
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Liner_name", typeof(string)));
        dt.Columns.Add(new DataColumn("Consol_Name", typeof(string)));
        dt.Columns.Add(new DataColumn("Consol_charges", typeof(string)));
        dt.Columns.Add(new DataColumn("Line_Charge", typeof(string)));
        dt.Columns.Add(new DataColumn("DO_Free_days", typeof(string)));
        dt.Columns.Add(new DataColumn("Port_Storage_Amt", typeof(string)));
        dt.Columns.Add(new DataColumn("Port_do_Revalidition", typeof(string)));
        dt.Columns.Add(new DataColumn("Detention_Amt", typeof(string)));
        dt.Columns.Add(new DataColumn("Detention_do_Revalidition", typeof(string)));
        dt.Columns.Add(new DataColumn("Damage_Charges", typeof(string)));
        dt.Columns.Add(new DataColumn("Late_do_fee", typeof(string)));
        dt.Columns.Add(new DataColumn("Tax_Invoice_No", typeof(string)));
        dt.Columns.Add(new DataColumn("Tax_Invoice_Date", typeof(string)));
        dt.Columns.Add(new DataColumn("Tax_Invoice_Amount", typeof(string)));
        dt.Columns.Add(new DataColumn("Holding_Chq_No", typeof(string)));
        dt.Columns.Add(new DataColumn("Holding_Chq_date", typeof(string)));
        dt.Columns.Add(new DataColumn("Holding_Amt", typeof(string)));
        dt.Columns.Add(new DataColumn("UTR_No", typeof(string)));
        dt.Columns.Add(new DataColumn("UTR_Date", typeof(string)));
        dt.Columns.Add(new DataColumn("UTR_Amt", typeof(string)));
        dt.Columns.Add(new DataColumn("Holding_chq_return_date", typeof(string)));
        dt.Columns.Add(new DataColumn("Holding_Received_Date", typeof(string)));
        dt.Columns.Add(new DataColumn("Do_Applied_date", typeof(string)));
        dt.Columns.Add(new DataColumn("Do_Received_date", typeof(string)));
       
        dr = dt.NewRow();
        
        dr["RowNumber"] = 1;
        dr["Liner_name"] = "";
        dr["Consol_Name"] = "";
        dr["Consol_charges"] = "";
        dr["Line_Charge"] = "";
        dr["DO_Free_days"] = "";
        dr["Port_Storage_Amt"] = "";
        dr["Port_do_Revalidition"] = "";
        dr["Detention_Amt"] = "";
        dr["Detention_do_Revalidition"] = "";
        dr["Damage_Charges"] = "";
        dr["Late_do_fee"] = "";
        dr["Tax_Invoice_No"] = "";
        dr["Tax_Invoice_Date"] = "";
        dr["Tax_Invoice_Amount"] = "";
        dr["Holding_Chq_No"] = "";
        dr["Holding_Chq_date"] = "";
        dr["Holding_Amt"] = "";
        dr["UTR_No"] = "";
        dr["UTR_Date"] = "";
        dr["UTR_Amt"] = "";
        dr["Holding_chq_return_date"] = "";
        dr["Holding_Received_Date"] = "";
        dr["Do_Applied_date"] = "";
        dr["Do_Received_date"] = "";
        
        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        gvAll.DataSource = dt;
        gvAll.DataBind();

    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        //http://www.codeproject.com/Articles/30722/How-to-save-data-from-a-DataSet-into-a-T-SQL-table
        // sp_name EXP_BL_GENERATION_INS_UPD
    }

    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        /*if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("ddl_ContainerNo");

            DropDownList1.DataSource = dt_container;
            DropDownList1.DataTextField = "CONTAINER_NO";
            DropDownList1.DataValueField = "CONTAINER_NO";
            DropDownList1.DataBind();

            DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("ddl_size");

            if (dt_container.Rows.Count > 0)
            {
                if (dt_container.Rows[0]["TYPE"].ToString() != "")
                {
                    DropDownList2.DataSource = dt_container;
                    DropDownList2.DataTextField = "TYPE";
                    DropDownList2.DataValueField = "TYPE";
                    DropDownList2.DataBind();
                }
                else
                {
                    //DataTable dt_container = new DataTable();
                    //dt_container.Columns.Add("CONTAINER_NO");
                    //dt_container.Columns.Add("TYPE");
                    dt_container.Rows.Add("", "");
                    dt_container.Rows.Add("", "20");
                    dt_container.Rows.Add("", "40");
                    //ViewState["dt_container"] = dt_container;

                    DataView view = new DataView(dt_container);
                    DataTable distinctValues = view.ToTable(true, "TYPE");

                    DropDownList2.DataSource = distinctValues;
                    DropDownList2.DataTextField = "TYPE";
                    DropDownList2.DataValueField = "TYPE";
                    DropDownList2.DataBind();
                }
            }
            else
            {
                //DataTable dt_container = new DataTable();
                dt_container.Columns.Add("CONTAINER_NO");
                dt_container.Columns.Add("TYPE");

                dt_container.Rows.Add("", "");
                dt_container.Rows.Add("", "20");
                dt_container.Rows.Add("", "40");
                //ViewState["dt_container"] = dt_container;

                DataView view = new DataView(dt_container);
                DataTable distinctValues = view.ToTable(true, "TYPE");

                DropDownList2.DataSource = dt_container;
                DropDownList2.DataTextField = "TYPE";
                DropDownList2.DataValueField = "TYPE";
                DropDownList2.DataBind();
            }
        }*/
    }

    protected void gvAll_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAll.EditIndex = e.NewEditIndex;
    }

    
    protected void gvAll_RowDeleting(object sender, GridViewDeleteEventArgs e)
   {
       SetRowData();
       if (ViewState["CurrentTable"] != null)
       {
           DataTable dt = (DataTable)ViewState["CurrentTable"];
           DataRow drCurrentRow = null;
           int rowIndex = Convert.ToInt32(e.RowIndex);
           if (dt.Rows.Count > 1)
           {
               dt.Rows.Remove(dt.Rows[rowIndex]);
               // drCurrentRow = dt.NewRow();
               ViewState["CurrentTable"] = dt;


               /*gvAll.DataSource = dt;
               gvAll.DataBind();*/

               SetPreviousData();

               // for (int i = 0; i < gvAll.Rows.Count - 1; i++)
               // {
               //     gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
               // }
               //SetPreviousData();
           }
       }

   }
    private void AddNewRowToGrid()
    {
         int rowIndex = 0;
         string Emptyrow = string.Empty;

         if (ViewState["CurrentTable"] != null)
         {
             DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
             DataRow drCurrentRow = null;
             if (dtCurrentTable.Rows.Count > 0)
             {
                 for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                 {
                     //extract the TextBox values
                     TextBox txt_Line_Name = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Line_Name");
                     TextBox txt_Console_Name = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Console_Name");
                     TextBox txt_Console_chg = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Console_chg");
                     TextBox txt_Line_Chg = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Line_Chg");
                     TextBox txt_do_free_days = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_do_free_days");
                     TextBox txt_port_Str_amt = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_port_Str_amt");
                     TextBox txt_port_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_port_revalidation");
                     TextBox txt_Detent_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Detent_Amt");
                     TextBox txt_detention_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_detention_revalidation");
                     TextBox txt_dam_chg = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_dam_chg");
                     TextBox txt_do_fee = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_do_fee");
                     TextBox txt_tax_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_tax_inv_no");
                     TextBox txt_Tax_Inv_date = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Tax_Inv_date");
                     TextBox txt_tax_inv_amt = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_tax_inv_amt");
                     TextBox txt_Hold_chq = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Hold_chq");
                     TextBox txt_Hold_chq_date = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Hold_chq_date");
                     TextBox txt_Hold_amt = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Hold_amt");
                     TextBox txt_UTR_No = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_UTR_No");
                     TextBox txt_UTR_date = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_UTR_date");
                     TextBox txt_UTR_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_UTR_Amt");
                     TextBox txt_hold_rec_date = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_hold_rec_date");
                     TextBox txt_Hold_chq_return_date = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Hold_chq_return_date");
                     TextBox txt_Do_Applied_date = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Do_Applied_date");
                     TextBox txt_Do_Received_date = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Do_Received_date");
                     if (txt_Line_Name.Text == string.Empty)
                     {
                         Emptyrow = "Y";
                     }

                     drCurrentRow = dtCurrentTable.NewRow();
                     drCurrentRow["RowNumber"] = i + 1;
                     dtCurrentTable.Rows[i - 1]["Consol_Name"] = txt_Console_Name.Text;
                     dtCurrentTable.Rows[i - 1]["Consol_charges"] = txt_Console_chg.Text;
                     dtCurrentTable.Rows[i - 1]["Liner_name"] = txt_Line_Name.Text;
                     dtCurrentTable.Rows[i - 1]["Line_Charge"] = txt_Line_Chg.Text;
                     dtCurrentTable.Rows[i - 1]["DO_Free_days"] = txt_do_free_days.Text;
                     dtCurrentTable.Rows[i - 1]["Port_Storage_Amt"] = txt_port_Str_amt.Text;
                     dtCurrentTable.Rows[i - 1]["Port_do_Revalidition"] = txt_port_revalidation.Text;
                     dtCurrentTable.Rows[i - 1]["Detention_Amt"] = txt_Detent_Amt.Text;
                     dtCurrentTable.Rows[i - 1]["Detention_do_Revalidition"] = txt_detention_revalidation.Text;
                     dtCurrentTable.Rows[i - 1]["Damage_Charges"] = txt_dam_chg.Text;
                     dtCurrentTable.Rows[i - 1]["Late_do_fee"] = txt_do_fee.Text;
                     dtCurrentTable.Rows[i - 1]["Tax_Invoice_No"] = txt_tax_inv_no.Text;
                     dtCurrentTable.Rows[i - 1]["Tax_Invoice_Date"] = txt_Tax_Inv_date.Text;
                     dtCurrentTable.Rows[i - 1]["Tax_Invoice_Amount"] = txt_tax_inv_amt.Text;
                     dtCurrentTable.Rows[i - 1]["Holding_chq_No"] = txt_Hold_chq.Text;
                     dtCurrentTable.Rows[i - 1]["Holding_Chq_date"] = txt_Hold_chq_date.Text;
                     dtCurrentTable.Rows[i - 1]["Holding_Amt"] = txt_Hold_amt.Text;
                     dtCurrentTable.Rows[i - 1]["UTR_No"] = txt_UTR_No.Text;
                     dtCurrentTable.Rows[i - 1]["UTR_Date"] = txt_UTR_date.Text;
                     dtCurrentTable.Rows[i - 1]["UTR_Amt"] = txt_UTR_Amt.Text;
                     dtCurrentTable.Rows[i - 1]["Holding_Received_Date"] = txt_hold_rec_date.Text;
                     dtCurrentTable.Rows[i - 1]["Holding_chq_return_date"] = txt_Hold_chq_return_date.Text;
                     dtCurrentTable.Rows[i - 1]["Do_Applied_date"] = txt_Do_Applied_date.Text;
                     dtCurrentTable.Rows[i - 1]["Do_Received_date"] = txt_Do_Received_date.Text;
                     rowIndex++;
                 }

                 if (Emptyrow != "Y")
                 {
                     dtCurrentTable.Rows.Add(drCurrentRow);
                     ViewState["CurrentTable"] = dtCurrentTable;
                     gvAll.DataSource = dtCurrentTable;
                     gvAll.DataBind();

                 }
                 else
                 {
                     Alert_msg("Enter the value in Empty Row");
                 }
             }
         }
         else
         {
             //Response.Write("ViewState is null");
         }

         //Set Previous Data on Postbacks
        // SetPreviousData();
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
                    TextBox txt_Line_Name = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Line_Name");
                    TextBox txt_Console_Name = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_Console_Name");
                    TextBox txt_Console_chg = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_Console_chg");
                    TextBox txt_Line_Chg = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_Line_Chg");
                    TextBox txt_do_free_days = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_do_free_days");
                    TextBox txt_port_Str_amt = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_port_Str_amt");
                    TextBox txt_port_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_port_revalidation");
                    TextBox txt_Detent_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_Detent_Amt");
                    TextBox txt_detention_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[9].FindControl("txt_detention_revalidation");
                    TextBox txt_dam_chg = (TextBox)gvAll.Rows[rowIndex].Cells[10].FindControl("txt_dam_chg");
                    TextBox txt_do_fee = (TextBox)gvAll.Rows[rowIndex].Cells[11].FindControl("txt_do_fee");
                    TextBox txt_tax_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[12].FindControl("txt_tax_inv_no");
                    TextBox txt_Tax_Inv_date = (TextBox)gvAll.Rows[rowIndex].Cells[13].FindControl("txt_Tax_Inv_date");
                    TextBox txt_tax_inv_amt = (TextBox)gvAll.Rows[rowIndex].Cells[14].FindControl("txt_tax_inv_amt");
                    TextBox txt_Hold_chq = (TextBox)gvAll.Rows[rowIndex].Cells[15].FindControl("txt_Hold_chq");
                    TextBox txt_Hold_chq_date = (TextBox)gvAll.Rows[rowIndex].Cells[16].FindControl("txt_Hold_chq_date");
                    TextBox txt_Hold_amt = (TextBox)gvAll.Rows[rowIndex].Cells[17].FindControl("txt_Hold_amt");
                    TextBox txt_UTR_No = (TextBox)gvAll.Rows[rowIndex].Cells[18].FindControl("txt_UTR_No");
                    TextBox txt_UTR_date = (TextBox)gvAll.Rows[rowIndex].Cells[19].FindControl("txt_UTR_date");
                    TextBox txt_UTR_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[20].FindControl("txt_UTR_Amt");
                    TextBox txt_hold_rec_date = (TextBox)gvAll.Rows[rowIndex].Cells[21].FindControl("txt_hold_rec_date");
                    TextBox txt_Hold_chq_return_date = (TextBox)gvAll.Rows[rowIndex].Cells[22].FindControl("txt_Hold_chq_return_date");
                    TextBox txt_Do_Applied_date = (TextBox)gvAll.Rows[rowIndex].Cells[22].FindControl("txt_Do_Applied_date");
                    TextBox txt_Do_Received_date = (TextBox)gvAll.Rows[rowIndex].Cells[22].FindControl("txt_Do_Received_date");
                    
                    gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                    if (dt.Rows[i][1].ToString() != "")
                    {
                        //txtContainerNo.Text = dt.Rows[i][1].ToString();
                        txt_Line_Name.Text = dt.Rows[i][1].ToString();
                        txt_Console_Name.Text = dt.Rows[i][2].ToString();
                        txt_Console_chg.Text = dt.Rows[i][3].ToString();
                        txt_Line_Chg.Text = dt.Rows[i][4].ToString();
                        txt_do_free_days.Text = dt.Rows[i][5].ToString();
                        txt_port_Str_amt.Text = dt.Rows[i][6].ToString();
                        txt_port_revalidation.Text = dt.Rows[i][7].ToString();
                        txt_Detent_Amt.Text = dt.Rows[i][8].ToString();
                        txt_detention_revalidation.Text = dt.Rows[i][9].ToString();
                        txt_dam_chg.Text = dt.Rows[i][10].ToString();
                        txt_do_fee.Text = dt.Rows[i][11].ToString();
                        txt_tax_inv_no.Text = dt.Rows[i][12].ToString();
                        txt_Tax_Inv_date.Text = dt.Rows[i][13].ToString();
                        txt_tax_inv_amt.Text = dt.Rows[i][14].ToString();
                        txt_Hold_chq.Text = dt.Rows[i][15].ToString();
                        txt_Hold_chq_date.Text = dt.Rows[i][16].ToString();
                        txt_Hold_amt.Text = dt.Rows[i][17].ToString();
                        txt_UTR_No.Text = dt.Rows[i][18].ToString();
                        txt_UTR_date.Text = dt.Rows[i][19].ToString();
                        txt_UTR_Amt.Text = dt.Rows[i][20].ToString();
                        txt_Hold_chq_return_date.Text = dt.Rows[i][21].ToString();
                        txt_hold_rec_date.Text = dt.Rows[i][22].ToString();
                        txt_Do_Applied_date.Text = dt.Rows[i][23].ToString();
                        txt_Do_Received_date.Text = dt.Rows[i][24].ToString();
                        
                        DataTable dt_cont = new DataTable();
                        dt_cont = (DataTable)ViewState["dt_container"];

                     

                        rowIndex++;
                    }
                    else
                    {
                        txt_Line_Name.Text = "";
                        txt_Console_Name.Text = "";
                        txt_Console_chg.Text = "";
                        txt_Line_Chg.Text = "";
                        txt_do_free_days.Text = "";
                        txt_port_Str_amt.Text = "";
                        txt_port_revalidation.Text = "";
                        txt_Detent_Amt.Text = "";
                        txt_detention_revalidation.Text = "";
                        txt_dam_chg.Text = "";
                        txt_do_fee.Text = "";
                        txt_tax_inv_no.Text = "";
                        txt_Tax_Inv_date.Text = "";
                        txt_tax_inv_amt.Text = "";
                        txt_Hold_chq.Text = "";
                        txt_Hold_chq_date.Text = "";
                        txt_Hold_amt.Text = "";
                        txt_UTR_No.Text = "";
                        txt_UTR_date.Text = "";
                        txt_UTR_Amt.Text = "";
                        txt_Hold_chq_return_date.Text = "";
                        txt_hold_rec_date.Text = "";
                        txt_Do_Applied_date.Text = "";
                        txt_Do_Received_date.Text = "";
                       
                        DataTable dt_cont = new DataTable();
                        dt_cont = (DataTable)ViewState["dt_container"];
                       

                    }
                }
            }
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
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox txt_Line_Name = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Line_Name");
                    TextBox txt_Console_Name = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_Console_Name");
                    TextBox txt_Console_chg = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_Console_chg");
                    TextBox txt_Line_Chg = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_Line_Chg");
                    TextBox txt_do_free_days = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_do_free_days");
                    TextBox txt_port_Str_amt = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_port_Str_amt");
                    TextBox txt_port_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_port_revalidation");
                    TextBox txt_Detent_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_Detent_Amt");
                    TextBox txt_detention_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[9].FindControl("txt_detention_revalidation");
                    TextBox txt_dam_chg = (TextBox)gvAll.Rows[rowIndex].Cells[10].FindControl("txt_dam_chg");
                    TextBox txt_do_fee = (TextBox)gvAll.Rows[rowIndex].Cells[11].FindControl("txt_do_fee");
                    TextBox txt_tax_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[12].FindControl("txt_tax_inv_no");
                    TextBox txt_Tax_Inv_date = (TextBox)gvAll.Rows[rowIndex].Cells[13].FindControl("txt_Tax_Inv_date");
                    TextBox txt_tax_inv_amt = (TextBox)gvAll.Rows[rowIndex].Cells[14].FindControl("txt_tax_inv_amt");
                    TextBox txt_Hold_chq = (TextBox)gvAll.Rows[rowIndex].Cells[15].FindControl("txt_Hold_chq");
                    TextBox txt_Hold_chq_date = (TextBox)gvAll.Rows[rowIndex].Cells[16].FindControl("txt_Hold_chq_date");
                    TextBox txt_Hold_amt = (TextBox)gvAll.Rows[rowIndex].Cells[17].FindControl("txt_Hold_amt");
                    TextBox txt_UTR_No = (TextBox)gvAll.Rows[rowIndex].Cells[18].FindControl("txt_UTR_No");
                    TextBox txt_UTR_date = (TextBox)gvAll.Rows[rowIndex].Cells[19].FindControl("txt_UTR_date");
                    TextBox txt_UTR_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[20].FindControl("txt_UTR_Amt");
                    TextBox txt_Hold_chq_return_date = (TextBox)gvAll.Rows[rowIndex].Cells[21].FindControl("txt_Hold_chq_return_date");
                    TextBox txt_hold_rec_date = (TextBox)gvAll.Rows[rowIndex].Cells[22].FindControl("txt_hold_rec_date");
                    TextBox txt_Do_Applied_date = (TextBox)gvAll.Rows[rowIndex].Cells[22].FindControl("txt_Do_Applied_date");
                    TextBox txt_Do_Received_date = (TextBox)gvAll.Rows[rowIndex].Cells[22].FindControl("txt_Do_Received_date");
                    
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Consol_Name"] = txt_Console_Name.Text;
                    dtCurrentTable.Rows[i - 1]["Consol_charges"] = txt_Console_chg.Text;
                    dtCurrentTable.Rows[i - 1]["Liner_name"] = txt_Line_Name.Text;
                    dtCurrentTable.Rows[i - 1]["Line_Charge"] = txt_Line_Chg.Text;
                    dtCurrentTable.Rows[i - 1]["DO_Free_days"] = txt_do_free_days.Text;
                    dtCurrentTable.Rows[i - 1]["Port_Storage_Amt"] = txt_port_Str_amt.Text;
                    dtCurrentTable.Rows[i - 1]["Port_do_Revalidition"] = txt_port_revalidation.Text;
                    dtCurrentTable.Rows[i - 1]["Detention_Amt"] = txt_Detent_Amt.Text;
                    dtCurrentTable.Rows[i - 1]["Detention_do_Revalidition"] = txt_detention_revalidation.Text;
                    dtCurrentTable.Rows[i - 1]["Damage_Charges"] = txt_dam_chg.Text;
                    dtCurrentTable.Rows[i - 1]["Late_do_fee"] = txt_do_fee.Text;
                    dtCurrentTable.Rows[i - 1]["Tax_Invoice_No"] = txt_tax_inv_no.Text;
                    dtCurrentTable.Rows[i - 1]["Tax_Invoice_Date"] = txt_Tax_Inv_date.Text;
                    dtCurrentTable.Rows[i - 1]["Tax_Invoice_Amount"] = txt_tax_inv_amt.Text;
                    dtCurrentTable.Rows[i - 1]["Holding_chq_No"] = txt_Hold_chq.Text;
                    dtCurrentTable.Rows[i - 1]["Holding_Chq_date"] = txt_Hold_chq_date.Text;
                    dtCurrentTable.Rows[i - 1]["Holding_Amt"] = txt_Hold_amt.Text;
                    dtCurrentTable.Rows[i - 1]["UTR_No"] = txt_UTR_No.Text;
                    dtCurrentTable.Rows[i - 1]["UTR_Date"] = txt_UTR_date.Text;
                    dtCurrentTable.Rows[i - 1]["UTR_Amt"] = txt_UTR_Amt.Text;
                    dtCurrentTable.Rows[i - 1]["Holding_chq_return_date"] = txt_Hold_chq_return_date.Text;
                    dtCurrentTable.Rows[i - 1]["Holding_Received_Date"] = txt_hold_rec_date.Text;
                    dtCurrentTable.Rows[i - 1]["Do_Applied_date"] = txt_Do_Applied_date.Text;
                    dtCurrentTable.Rows[i - 1]["Do_Received_date"] = txt_Do_Received_date.Text;
                    
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
            }
        }
        else
        {
            //Response.Write("ViewState is null");
        }
    }
 /*protected void ddl_entry_type_SelectedIndexChanged(object sender, EventArgs e)
    {
         DataSet dss = new DataSet();
         if (ddl_entry_type.SelectedItem.Text == "DO")
         {
             load_Ref_Id();
             Lb_name.Text = "Consignee Name";
             Lb_mbl.Text = "MBL No";
             Lb_hbl.Text = "HBL No";
             Lb_pkg.Text = "Packages";
             Lb_type.Text = "Mode Type";
             Lb_cnt1.Text = "20'F";
             Lb_cnt.Text = "40'F";
             Lb_grwght.Text = "Gross Weight";
             Lb_netwght.Text = "Net Wgt";
             Lb_rem.Text = "Remarks";
             txt_Consigee_Name.Visible = true;
             txt_MBL_No.Visible = true;
             txt_HBL_No.Visible = true;
             txt_Pkg.Visible = true;
             ddl_Mode_Type.Visible = true;
             txt_20_F.Visible = true;
             txt_40_F.Visible = true;
             txt_Gross_Wgt.Visible = true;
             txt_Net_Wgt.Visible = true;
             Txt_remarks.Visible = true;
             txt_CHA_Ref_No.Visible = false;
             txt_twenty_cont.Visible = false;
             txt_forty_Cont.Visible = false;
             txt_LCL.Visible = false;
             txt_FCL.Visible = false;
             txt_Gross_wght.Visible = false;
             txt_BB.Visible = false;
             txt_Cha_Ref_Num.Visible = false;
             txt_no_pkgs.Visible = false;
             txt_gros_wght.Visible = false;
             txt_Chrg_wght.Visible = false;
             //txt_CFS_Name.Visible = false;
             //txt_Staff_Name.Visible = false;
             this.gvAll.Columns[1].HeaderText = "Tax Invoice No";
             //if (dss.Tables[0].Rows.Count > 0)
             //{
             //    gvAll.HeaderRow.Cells[1].Text = "Tax Invoice No";


             //}
         }
         if (ddl_entry_type.SelectedItem.Text == "CFS")
        {
            load_Ref_Id();
            Lb_name.Text = "Importer Ref";
            Lb_mbl.Text = "20'";
            Lb_hbl.Text = "40'";
            Lb_pkg.Text = "LCL";
            Lb_type.Text = "FCL";
            Lb_cnt1.Text = "Gross weight";
            Lb_cnt.Text = "BB";
            Lb_grwght.Visible = false;
            Lb_netwght.Visible = false;
            Lb_rem.Visible = false;
            txt_CHA_Ref_No.Visible = true;
            txt_twenty_cont.Visible = true;
            txt_forty_Cont.Visible = true;
            txt_LCL.Visible = true;
            txt_FCL.Visible = true;
            txt_Gross_wght.Visible = true;
            txt_BB.Visible = true;
            //txt_CFS_Name.Visible = true;
            //txt_Staff_Name.Visible = true;
            txt_Consigee_Name.Visible = false;
            txt_MBL_No.Visible = false;
            txt_HBL_No.Visible = false;
            txt_Pkg.Visible = false;
            ddl_Mode_Type.Visible = false;
            txt_20_F.Visible = false;
            txt_40_F.Visible = false;
            txt_Gross_Wgt.Visible = false;
            txt_Net_Wgt.Visible = false;
            Txt_remarks.Visible = false;
            txt_Cha_Ref_Num.Visible = false;
            txt_no_pkgs.Visible = false;
            txt_gros_wght.Visible = false;
            txt_Chrg_wght.Visible = false;
            this.gvAll.Columns[1].HeaderText = "Trasporter name";
            //if (dss.Tables[0].Rows.Count > 0)
            //{
            //    gvAll.HeaderRow.Cells[1].Text = "Trasporter name";


            //}
        }
         if (ddl_entry_type.SelectedItem.Text == "AAI")
         {
             load_Ref_Id();
             Lb_name.Text = "Importer Ref No";
             Lb_mbl.Text = "No of PKG";
             Lb_hbl.Text = "Gross Weight";
             Lb_pkg.Text = "Chargable Weight";
             txt_Cha_Ref_Num.Visible = true;
             txt_no_pkgs.Visible = true;
             txt_gros_wght.Visible = true;
             txt_Chrg_wght.Visible = true;
             Lb_type.Visible = false;
             Lb_cnt1.Visible = false;
             Lb_cnt.Visible = false;
             Lb_grwght.Visible = false;
             Lb_netwght.Visible = false;
             Lb_rem.Visible = false;
             txt_CHA_Ref_No.Visible = false;
             txt_twenty_cont.Visible = false;
             txt_forty_Cont.Visible = false;
             txt_LCL.Visible = false;
             txt_FCL.Visible = false;
             txt_Gross_wght.Visible = false;
             txt_BB.Visible = false;
             //txt_CFS_Name.Visible = true;
             //txt_Staff_Name.Visible = true;
             txt_Consigee_Name.Visible = false;
             txt_MBL_No.Visible = false;
             txt_HBL_No.Visible = false;
             txt_Pkg.Visible = false;
             ddl_Mode_Type.Visible = false;
             txt_20_F.Visible = false;
             txt_40_F.Visible = false;
             txt_Gross_Wgt.Visible = false;
             txt_Net_Wgt.Visible = false;
             Txt_remarks.Visible = false;
             this.gvAll.Columns[1].HeaderText = "Trasporter name";
             //if (dss.Tables[0].Rows.Count > 0)
             //{
             //    gvAll.HeaderRow.Cells[1].Text = "Trasporter name";


             //}
         }
    }*/
}