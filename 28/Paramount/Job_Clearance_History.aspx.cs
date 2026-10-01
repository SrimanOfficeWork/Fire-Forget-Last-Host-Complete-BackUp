using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Job_Clearance_History : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    
    User_Creation user_Create = new User_Creation();
    Paramount_Exp_Job_Clearance PEJC = new Paramount_Exp_Job_Clearance();

    public int i;
    
    public string currentuser;
    public string currentbranch;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
       
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();

            
        if (Session["SELECT_TYPE"] != null)
        {
            SELECT_TYPE = Session["SELECT_TYPE"].ToString();

            if (SELECT_TYPE == "Branchwise Job")
            {
                SELECT_BRANCH = currentbranch;
                hdBranch.Value = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                hdBranch.Value = "";
            }
        }
        else
        {
            SELECT_BRANCH = "";
            hdBranch.Value = "";
            Session["DB_no_Branch"] = "";
        }

        if (!Page.IsPostBack)
        {
            txtId.Attributes.Add("readonly", "readonly");
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

            Tr_mode_load();
           
            if (Request.QueryString["Page"] == "New")
            {
                Div_listbox.Visible = false;

                HD_Showcon.Value = "NEW";
                HDupdate_id.Value = "";
                Exporter_Name_Load();

            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Updated_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    HDupdate_id.Value = Request.QueryString["Page"].ToString();
                    ddltr_mode.Enabled = false;

                    HD_Showcon.Value = "SAVED"; 
                }
            }           
        }

       // HDEXP_Name.Value = ddlExp_name.SelectedItem.Text;
       // HDR_ID.Value=txtId.Text;

    }
    private void Updated_Item_Load()
    {
        DataSet ds = new DataSet();
        PEJC.Item_Id = Request.QueryString["Page"].ToString();
        PEJC.Branch = SELECT_BRANCH;
        PEJC.Flag = "Select_Update_Data";
        ds = PEJC.Item_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = ds.Tables[0];
            ddlExp_name.DataTextField = "M_EXP_NAME";
            ddlExp_name.DataValueField = "M_EXP_NAME";
            ddlExp_name.DataBind();

            txtrefname.Text = ds.Tables[0].Rows[0]["REF_NAME"].ToString();
            
            txtId.Text = ds.Tables[0].Rows[0]["R_ID"].ToString();
            ddltr_mode.SelectedValue = ds.Tables[0].Rows[0]["MODE"].ToString();
            txt_Shipper_Name.Text = ds.Tables[0].Rows[0]["INV_SHIPPER_NAME"].ToString();
            txt_Consignee_Name.Text  = ds.Tables[0].Rows[0]["INV_CONSIGNEE_NAME"].ToString();
            txt_Invoice_no.Text  = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
            txt_port_name.Text  = ds.Tables[0].Rows[0]["INV_PORT_NAME"].ToString();
            txt_gross_wgt.Text  = ds.Tables[0].Rows[0]["INV_GROSS_WGT"].ToString();
            txt_net_wgt.Text  = ds.Tables[0].Rows[0]["INV_NET_WGT"].ToString();
            txt_Copy.Text  = ds.Tables[0].Rows[0]["INV_COPY"].ToString();
            txt_Ori.Text = ds.Tables[0].Rows[0]["INV_ORI"].ToString();
            txt_booking_on_date.Text  = ds.Tables[0].Rows[0]["BOOKING_ON"].ToString();
            txt_liner_name.Text  = ds.Tables[0].Rows[0]["BOOKING_LINER"].ToString();
            txt_booking_no.Text  = ds.Tables[0].Rows[0]["BOOKING_NO"].ToString();
            txt_Fowarder_name.Text  = ds.Tables[0].Rows[0]["BOOKING_FORWARDER"].ToString();

            txt_Empty_Plot_In_date.Text = ds.Tables[0].Rows[0]["EMTPY_PLOT_IN"].ToString();
            txt_Empty_Plot_Out_date.Text  = ds.Tables[0].Rows[0]["EMTPY_PLOT_OUT"].ToString();
            txt_Vehicle_Factory_to_cfs.Text  = ds.Tables[0].Rows[0]["VEHICLE_FACTORY_TO_CFS"].ToString();
            txt_Vehicle_Number.Text  = ds.Tables[0].Rows[0]["VEHICLE_NUMBER"].ToString();
            txt_Vehicle_Cfs_to_Port.Text  = ds.Tables[0].Rows[0]["VEHICLE_CFS_TO_PORT"].ToString();
            txt_Vehicle_Number_2.Text  = ds.Tables[0].Rows[0]["VEHICLE_NUMBER_2"].ToString();
            txt_Container_size.Text  = ds.Tables[0].Rows[0]["CONTAINER_SIZE"].ToString();
            txt_Con_CNTR_No.Text  = ds.Tables[0].Rows[0]["CONTAINER_NUMBER"].ToString();
            txt_Container_S_no.Text  = ds.Tables[0].Rows[0]["CONTAINER_SEAL_NUMBER"].ToString();
            txt_Con_F_L_A.Text  = ds.Tables[0].Rows[0]["CONTAINER_LCL_FCL"].ToString();
            txt_Factory_In_date.Text  = ds.Tables[0].Rows[0]["FACTORY_IN"].ToString();
            txt_Factory_Out_date.Text  = ds.Tables[0].Rows[0]["FACTORY_OUT"].ToString();
            txt_Factory_halt_From.Text  = ds.Tables[0].Rows[0]["FACTORY_HALT_FROM"].ToString();
            txt_Factory_halt_To.Text  = ds.Tables[0].Rows[0]["FACTORY_HALT_TO"].ToString();
            txt_Factory_Remarks.Text  = ds.Tables[0].Rows[0]["FACTORY_REMARKS"].ToString();
            txt_SB_No.Text  = ds.Tables[0].Rows[0]["SB_NUMBER"].ToString();
            txt_SB_Date.Text  = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
            txt_DBK_amt.Text  = ds.Tables[0].Rows[0]["SB_DRAWBACK_AMT"].ToString();
            txt_Type_of_SB.Text  = ds.Tables[0].Rows[0]["SB_TYPE"].ToString();
            txt_SB_Remarks.Text  = ds.Tables[0].Rows[0]["SB_REMARKS"].ToString();
            txt_vessel_Planned.Text  = ds.Tables[0].Rows[0]["TENTATIAVE_VESSEL_PLANNED"].ToString();
            txt_tentative_voyage.Text  = ds.Tables[0].Rows[0]["TENTATIAVE_VOAGE"].ToString();
            txt_tentative_ETD_date.Text  = ds.Tables[0].Rows[0]["TENTATIAVE_ETD"].ToString();
            txt_CFS_name_port.Text  = ds.Tables[0].Rows[0]["CUSTOMS_CFS_NAME_PORT"].ToString();
            txt_CFS_IN_port.Text  = ds.Tables[0].Rows[0]["CUSTOMS_CFS_IN_PORT"].ToString();
            txt_Off_loaded.Text  = ds.Tables[0].Rows[0]["CUSTOMS_OFF_LOADED"].ToString();
            txt_Cus_Exam.Text  = ds.Tables[0].Rows[0]["CUSTOMS_C_EXAM"].ToString();
            txt_Cus_Exam_Halting.Text  = ds.Tables[0].Rows[0]["CUSTOMS_HALTING"].ToString();
            txt_Cus_Exam_Remarks.Text  = ds.Tables[0].Rows[0]["CUSTOMS_REMARKS"].ToString();
            txt_Cus_Exam_CFS_Out.Text  = ds.Tables[0].Rows[0]["CUSTOMS_CFS_OUT"].ToString();
            txt_Cus_Exam_port_In_Date.Text  = ds.Tables[0].Rows[0]["CUSTOMS_PORT_IN_DT"].ToString();
            txt_Confirmed_Vessel_Halting.Text  = ds.Tables[0].Rows[0]["CVP_HALTING"].ToString();
            txt_Confirmed_Vessel_Name.Text  = ds.Tables[0].Rows[0]["CVP_VESSEL_NAME"].ToString();
            txt_Confirmed_Vessel_Voyage.Text  = ds.Tables[0].Rows[0]["CVP_VOAGE"].ToString();
            txt_Confirmed_Vessel_Rotation_No.Text  = ds.Tables[0].Rows[0]["CVP_ROTATIONAL_NO_DATE"].ToString();
            txt_Confirmed_Vessel_Gate_Opening.Text  = ds.Tables[0].Rows[0]["CVP_GATE_OPENING"].ToString();
            txt_Post_Shipment_Cut_of_time.Text  = ds.Tables[0].Rows[0]["PSD_CUT_OFF_TIME"].ToString();
            txt_Post_Shipment_Form_13.Text  = ds.Tables[0].Rows[0]["PSD_F13"].ToString();
            txt_Post_Shipment_ETA_MAA.Text  = ds.Tables[0].Rows[0]["PSD_ETA_MAA"].ToString();
            txt_Post_Shipment_ETD_MAA.Text  = ds.Tables[0].Rows[0]["PSD_ETD_MAA"].ToString();
            txt_Post_Shipment_SI_Sent_liner.Text  = ds.Tables[0].Rows[0]["PSD_SI_SENT_LINER"].ToString();
            txt_BL_Draft.Text  = ds.Tables[0].Rows[0]["BL_DRAFT"].ToString();
            txt_BL_Approve.Text  = ds.Tables[0].Rows[0]["BL_APPROVE"].ToString();
            txt_BL_Number.Text  = ds.Tables[0].Rows[0]["BL_NO"].ToString();
            txt_BL_Date.Text  = ds.Tables[0].Rows[0]["BL_DATE"].ToString();
            txt_BL_Release.Text  = ds.Tables[0].Rows[0]["BL_RELEASE"].ToString();
            txt_TPT_Doc_Sent_Shipper.Text  = ds.Tables[0].Rows[0]["TPT_DOCK_SENT_SHIPPER"].ToString();
            txt_TPT_Factory_to_Cfs.Text  = ds.Tables[0].Rows[0]["TPT_FACTORY_TO_CFS"].ToString();


            txt_TPT_Bill_no_Date.Text  = ds.Tables[0].Rows[0]["TPT_BILL_NO_DATE"].ToString();
            txt_TPT_Cfs_to_Port.Text  = ds.Tables[0].Rows[0]["TPT_CFS_TO_PORT"].ToString();
            txt_TPT_Bill_no_Date_2.Text  = ds.Tables[0].Rows[0]["TPT_BILL_NO_DATE_2"].ToString();
            txt_TPT_A_C.Text  = ds.Tables[0].Rows[0]["TPT_A_C"].ToString();
            txt_TPT_Remarks.Text  = ds.Tables[0].Rows[0]["TPT_REMARKS"].ToString();
            HDupdate_id.Value = Request.QueryString["Page"].ToString();

            cbList.DataSource = ds.Tables[1];
            cbList.DataTextField = "JOBNO_PS";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();

            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                {
                    if (ds.Tables[1].Rows[i]["FeatureStatus"].ToString() == "True")
                    {
                        cbList.Items[i].Selected = true;
                    }
                }
            }

        }
    }

    public void Page_Rights(int i)
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
           
            btnSave.ToolTip = "You don't have permission to access";
            btnUpdate.ToolTip = "You don't have permission to access";
            btnDelete.ToolTip = "You don't have permission to access";
        }
        else
        {
            //---------------SAVE BUTTON------------------//
            if (PAGE_WRITE == "True")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ToolTip = "You don't have permission to access";
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
    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    private void Exporter_Name_Load()
    {
        DataSet ds = new DataSet();

        PEJC.Branch = SELECT_BRANCH;
        PEJC.Flag = "EXP_Name_Select";
        ds = PEJC.Item_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = ds.Tables[0];
            ddlExp_name.DataTextField = "Exporter_Name";
            ddlExp_name.DataValueField = "Exporter_Name";
            ddlExp_name.DataBind();
        }

        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkbox_load("S", "EXP_Name_Job_Select", "");
    }

    private void chkbox_load(string Type,string flag, string Ref_id)
    {
        if (ddlExp_name.SelectedValue.ToString() == string.Empty)
        {
            Div_listbox.Visible = false;
            Clear();
        }
        else
        {
            DataSet ds = new DataSet();
            PEJC.Item_Id = Ref_id;
            PEJC.Exp_name = ddlExp_name.SelectedItem.Text;
            PEJC.Branch_Common = SELECT_BRANCH;
            PEJC.Flag = flag;
            PEJC.Mode = ddltr_mode.SelectedItem.Text;

            ds = PEJC.Item_Select();
            cbList.DataSource = ds.Tables[0];
            cbList.DataTextField = "JOBNO_PS";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();

            if (Type == "S")
            {
                txtId.Text = ds.Tables[1].Rows[0][0].ToString();
                txtrefname.Text = ds.Tables[2].Rows[0][0].ToString();
            }

            Div_listbox.Visible = true;
        }
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Generation', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BL Generation', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btngenerate_Click(object sender, EventArgs e)
    {
        if (ddlExp_name.SelectedItem.Text != string.Empty)
        {
            string values = "";
            foreach (ListItem objItem in cbList.Items)
            {
                if (objItem.Selected)
                {
                    values += objItem.Value + ",";
                }
            }

            if (values != string.Empty)
            {
                DataSet ds = new DataSet();
                if (Request.QueryString["Page"] == "New")
                {
                    PEJC.R_Id = "";
                }
                else
                {
                    PEJC.R_Id = Request.QueryString["Page"].ToString();
                }
                PEJC.Jobno = values;
                PEJC.Exp_name = ddlExp_name.SelectedItem.Text;
                PEJC.Branch = SELECT_BRANCH;
                PEJC.Mode = ddltr_mode.SelectedItem.Text;
                PEJC.Flag = "EXP_Generate";
                ds = PEJC.Item_Select();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txt_Invoice_no.Text = ds.Tables[0].Rows[0]["Invocie_no"].ToString();
                    txt_Shipper_Name.Text = ddlExp_name.SelectedItem.Text;
                    txt_Consignee_Name.Text = ds.Tables[0].Rows[0]["Con_Name"].ToString();
                    txt_port_name.Text = ds.Tables[0].Rows[0]["Port_Discharge"].ToString();

                    txt_gross_wgt.Text = ds.Tables[0].Rows[0]["G_Wgt"].ToString();
                    txt_net_wgt.Text = ds.Tables[0].Rows[0]["N_Wgt"].ToString();
                    txt_Con_F_L_A.Text = ds.Tables[0].Rows[0]["Sea_con_type"].ToString();
                    txt_Con_CNTR_No.Text = ds.Tables[0].Rows[0]["Con_NO"].ToString();
                    txt_Container_S_no.Text = ds.Tables[0].Rows[0]["Sea_con_sealno"].ToString();
                }
                else
                {
                    txt_Invoice_no.Text = string.Empty;
                    txt_Shipper_Name.Text = string.Empty;
                    txt_Consignee_Name.Text = string.Empty;
                    txt_port_name.Text = string.Empty;

                    txt_gross_wgt.Text = string.Empty;
                    txt_net_wgt.Text = string.Empty;
                    txt_Con_F_L_A.Text = string.Empty;
                    txt_Con_CNTR_No.Text = string.Empty;
                    txt_Container_S_no.Text = string.Empty;
                }
            }
            else
            {
                //select Jobno
            }
        }
        else
        {
            Alert_msg("Select Exporter Name!", "ddlExp_name");
        }
    }

    public void Clear()
    {

        txtrefname.Text = string.Empty;
        txtId.Text = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
         try
         {
              string values = "",Items="";
             foreach (ListItem objItem in cbList.Items)
             {
                 if (objItem.Selected)
                 {
                     values += objItem.Value + ",";
                     Items += objItem.Text + ",";
                 }
             }

             if (values!="" && values!=string.Empty)
             {
                 if (ddlExp_name.SelectedItem.Text != string.Empty && ddlExp_name.SelectedItem.Text != "")
                 {
                   i = Export_Insert_Update( "S");
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
                                 btnSave.Focus();

                             }
                             //-----------------------FOR USER RIGHTS--------------------------------//

                             ViewState["UPDATED_ID"] = null;
                             HD_Showcon.Value = "SAVED"; 
                             Alert_msg("Saved Successfully", "btnSave");
                             HDupdate_id.Value = Convert.ToString(PEJC.UPDATE_ID);
                         }
                         else if (i == 2)
                         {
                             Alert_msg("Job No Already Exist!");
                         }
                         else
                         {
                             btnUpdate.Visible = false;
                             btnDelete.Visible = false;
                             btnSave.Visible = true;
                             btnNew.Visible = true;
                             Alert_msg("Not Saved");

                         }
           //---------------------------------------------------------------------------------------------
              }
                 else
                     {
                         Alert_msg("Select Exporter Name!");
                         
                     }
                }
                 else
                     {
                         Alert_msg("Select Job Number!");
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
              string values = "";
              foreach (ListItem objItem in cbList.Items)
              {
                  if (objItem.Selected)
                  {
                      values += objItem.Value + ",";
                  }
              }
              if (values != "" && values != string.Empty)
              {

                  if (ddlExp_name.SelectedItem.Text != string.Empty && ddlExp_name.SelectedItem.Text != "")
                  {

                      i = Export_Insert_Update("U");
              if (i == 1)
              {

                  if (ViewState["UPDATED_ID"] != null)
                  {
                      Alert_msg("Updated Successfully");

                  }
                  else
                  {
                      Alert_msg("Saved Successfully");
                      HD_Showcon.Value = "SAVED"; 
                  }
              }
              else if (i == 2)
              {
                  Alert_msg("Job No Already Exist!");
              }
              else
              {
                  btnUpdate.Visible = true;
                  btnDelete.Visible = true;
                  btnSave.Visible = false;
                  btnNew.Visible = true;
                  Alert_msg("Not Saved");
              }
             //----------------------------------------------------------------------------------------------
                  }
                  else
                  {
                      Alert_msg("Select Exporter Name!");
                  }
              }
              else
              {
                  Alert_msg("Select Job Number!");
              }

          }
          catch (Exception ex)
          {
              ErrorLogs er = new ErrorLogs();
              er.makeLog(ex.Message);
          }
      }
    protected void btnDelete_Click(object sender, EventArgs e)
      {
          try
          {

              PEJC.UPD_ID = HDupdate_id.Value.ToString();
              PEJC.R_Id = txtId.Text;
              PEJC.M_EXP_NAME = ddlExp_name.SelectedItem.Text;
              PEJC.Mode = ddltr_mode.SelectedItem.Text;
              PEJC.Flag = "D";
              PEJC.Branch_Common = SELECT_BRANCH;
              PEJC.EXP_INS_UPD();

              i = PEJC.result;

              if (i == 1)
              {
                  btnNew_Click(sender, e);
                  Alert_msg("Deleted");
                  Exporter_Name_Load();
                  Div_listbox.Visible = false;
                  ddltr_mode.Enabled = true;
              }

              else
              {
                  Alert_msg("Not Deleted");
              }
              

          }
          catch (Exception ex)
          {
              er.makeLog(ex.Message);
          }
      }

    public int Export_Insert_Update(string a1 )
    {
                string values = "",Items="";
                foreach (ListItem objItem in cbList.Items)
                {
                    if (objItem.Selected)
                    {
                        values += objItem.Value + ",";
                        Items += objItem.Text + ",";
                    }
                }
                PEJC.REF_NAME = txtrefname.Text;
                PEJC.M_EXP_NAME = ddlExp_name.SelectedItem.Text;


                PEJC.R_Id = txtId.Text;
                PEJC.Mode = ddltr_mode.SelectedItem.Text;
                PEJC.Exp_name = txt_Shipper_Name.Text;
                PEJC.Consignee_Name = txt_Consignee_Name.Text;
                PEJC.Invoice_no = txt_Invoice_no.Text;
                PEJC.port_name = txt_port_name.Text;
                PEJC.gross_wgt = txt_gross_wgt.Text;
                PEJC.net_wgt = txt_net_wgt.Text;
                PEJC.Copy = txt_Copy.Text;
                PEJC.Ori = txt_Ori.Text;
                PEJC.booking_on_date = txt_booking_on_date.Text;
                PEJC.liner_name = txt_liner_name.Text;
                PEJC.booking_no = txt_booking_no.Text;

                PEJC.Fowarder_name = txt_Fowarder_name.Text;
                PEJC.Empty_Plot_In_date = txt_Empty_Plot_In_date.Text;
                PEJC.Empty_Plot_Out_date = txt_Empty_Plot_Out_date.Text;
                PEJC.Vehicle_Factory_to_cfs = txt_Vehicle_Factory_to_cfs.Text;
                PEJC.Vehicle_Number = txt_Vehicle_Number.Text;
                PEJC.Vehicle_Cfs_to_Port = txt_Vehicle_Cfs_to_Port.Text;
                PEJC.Vehicle_Number_2 = txt_Vehicle_Number_2.Text;
                PEJC.Container_size = txt_Container_size.Text;
                PEJC.Con_CNTR_No = txt_Con_CNTR_No.Text;
                PEJC.Container_S_no = txt_Container_S_no.Text;
                PEJC.Con_F_L_A = txt_Con_F_L_A.Text;

                PEJC.Factory_In_date = txt_Factory_In_date.Text;
                PEJC.Factory_Out_date = txt_Factory_Out_date.Text;
                PEJC.Factory_halt_From = txt_Factory_halt_From.Text;
                PEJC.Factory_halt_To = txt_Factory_halt_To.Text;
                PEJC.Factory_Remarks = txt_Factory_Remarks.Text;

                PEJC.SB_No = txt_SB_No.Text;
                PEJC.SB_Date = txt_SB_Date.Text;
                PEJC.DBK_amt = txt_DBK_amt.Text;
                PEJC.Type_of_SB = txt_Type_of_SB.Text;
                PEJC.SB_Remarks = txt_SB_Remarks.Text;
                PEJC.vessel_Planned = txt_vessel_Planned.Text;
                PEJC.tentative_voyage = txt_tentative_voyage.Text;
                PEJC.tentative_ETD_date = txt_tentative_ETD_date.Text;
                PEJC.CFS_name_port = txt_CFS_name_port.Text;
                PEJC.CFS_IN_port = txt_CFS_IN_port.Text;
                PEJC.Off_loaded = txt_Off_loaded.Text;
                PEJC.Cus_Exam = txt_Cus_Exam.Text;
                PEJC.Cus_Exam_Halting = txt_Cus_Exam_Halting.Text;
                PEJC.Cus_Exam_Remarks = txt_Cus_Exam_Remarks.Text;
                PEJC.Cus_Exam_CFS_Out = txt_Cus_Exam_CFS_Out.Text;
                PEJC.Cus_Exam_port_In_Date = txt_Cus_Exam_port_In_Date.Text;
                PEJC.Confirmed_Vessel_Halting = txt_Confirmed_Vessel_Halting.Text;
                PEJC.Confirmed_Vessel_Name = txt_Confirmed_Vessel_Name.Text;
                PEJC.Confirmed_Vessel_Voyage = txt_Confirmed_Vessel_Voyage.Text;
                PEJC.Confirmed_Vessel_Rotation_No = txt_Confirmed_Vessel_Rotation_No.Text;
                PEJC.Confirmed_Vessel_Gate_Opening = txt_Confirmed_Vessel_Gate_Opening.Text;
                PEJC.Post_Shipment_Cut_of_time = txt_Post_Shipment_Cut_of_time.Text;
                PEJC.Post_Shipment_Form_13 = txt_Post_Shipment_Form_13.Text;
                PEJC.Post_Shipment_ETA_MAA = txt_Post_Shipment_ETA_MAA.Text;
                PEJC.Post_Shipment_ETD_MAA = txt_Post_Shipment_ETD_MAA.Text;
                PEJC.Post_Shipment_SI_Sent_liner = txt_Post_Shipment_SI_Sent_liner.Text;
                PEJC.BL_Draft = txt_BL_Draft.Text;
                PEJC.BL_Approve = txt_BL_Approve.Text;
                PEJC.BL_Number = txt_BL_Number.Text;
                PEJC.BL_Date = txt_BL_Date.Text;
                PEJC.BL_Release = txt_BL_Release.Text;
                PEJC.TPT_Doc_Sent_Shipper = txt_TPT_Doc_Sent_Shipper.Text;
                PEJC.TPT_Factory_to_Cfs = txt_TPT_Factory_to_Cfs.Text;
                PEJC.TPT_Bill_no_Date = txt_TPT_Bill_no_Date.Text;
                PEJC.TPT_Cfs_to_Port = txt_TPT_Cfs_to_Port.Text;
                PEJC.TPT_Bill_no_Date_2 = txt_TPT_Bill_no_Date_2.Text;
                PEJC.TPT_A_C = txt_TPT_A_C.Text;
                PEJC.TPT_Remarks = txt_TPT_Remarks.Text;
                PEJC.Jobno = values;
                PEJC.Flag = a1;
                PEJC.Workingperiod = Working_Period;
                PEJC.User_id = currentuser;
                PEJC.Branch = currentbranch;
                PEJC.JOBNO_PS = Items;
                PEJC.UPD_ID = HDupdate_id.Value.ToString();
        
                PEJC.EXP_INS_UPD();

                i = PEJC.result;
        
            return i;
        }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        Div_listbox.Visible = false;
        Clear();
        HDupdate_id.Value = string.Empty;

    }

    private void Tr_mode_load()
    {
        if (SELECT_BRANCH != "")
        {
            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();


            if (TRANS_MODE == "A")
            {
                ddltr_mode.Items.Add(new ListItem("Air", "Air"));
                hdfTransport_mode1.Value = "Air";
            }
            else if (TRANS_MODE == "S")
            {
                ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
                hdfTransport_mode1.Value = "Sea";
            }
            else if (TRANS_MODE == "L")
            {
                ddltr_mode.Items.Add(new ListItem("Land", "Land"));
                hdfTransport_mode1.Value = "Land";
            }
        }
        else
        {
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));
            ddltr_mode.Items.Add(new ListItem("", ""));

            string TRANS_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
            if (TRANS_MODE == "A")
            {
                hdfTransport_mode1.Value = "Air";
            }
            else if (TRANS_MODE == "S")
            {
                hdfTransport_mode1.Value = "Sea";
            }
            else if (TRANS_MODE == "L")
            {
                hdfTransport_mode1.Value = "Land";
            }
        }
    }
    
    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkbox_load("S", "EXP_Name_Job_Select", "");
    }
    protected void btnpdf_Click(object sender, EventArgs e)
    {
       // PEJC.Export_to_Pdf();
    }
}
 

            
           