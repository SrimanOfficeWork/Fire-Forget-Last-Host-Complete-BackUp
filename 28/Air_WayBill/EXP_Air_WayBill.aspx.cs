using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;

public partial class EXP_Air_WayBill : ThemeClass
{
    AppSession aps = new AppSession();
    UserBO ObjUBO = new UserBO();
    AWB_Export_CS AWB_EXP = new AWB_Export_CS();
    User_Creation user_Create = new User_Creation();
    ErrorLogs er = new ErrorLogs();

    public int i, Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        if (!Page.IsPostBack)
        {
            T.Visible = false;
            btnrpt.Visible = false;
            if (Request.QueryString["Page"] == null)
            {
                load_Exp_name();
                
                Screen_Id = 11;

                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlExp_name.Enabled = false;
                    ddljobno.Enabled = false;
                    ddlAWB_Type.Enabled = false;
                    btnrpt.Visible = true;
                }
            }
        }
    }
    private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        ObjUBO.JOBNO = Request.QueryString["Page"].ToString();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.ITEM_EXPORTER_NAME = ddlExp_name.SelectedValue.ToString();
        ObjUBO.flag = "AWB_Exp_Jobno_Select";
        dss = AWB_EXP.AWB_EXPORT_INV_SELECT(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            ViewState["UPDATED_ID"] = "U";
            HDupdate_id.Value = dss.Tables[0].Rows[0]["ID"].ToString();
            ddljobno.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["JOBNO"].ToString(), dss.Tables[0].Rows[0]["JOBNO"].ToString()));
            ddljobno.SelectedIndex = 0;
            ddlExp_name.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString(), dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()));
            ddlExp_name.SelectedIndex = 0;
            ddlAWB_Type.SelectedValue= dss.Tables[0].Rows[0]["AWB_TYPE"].ToString();
            txtMaster_Awb_no_1.Text= dss.Tables[0].Rows[0]["MASTER_AWB_NO_1"].ToString();
            txtMaster_Awb_no_2.Text= dss.Tables[0].Rows[0]["MASTER_AWB_NO_2"].ToString();
            txtHouse_Awb_no.Text= dss.Tables[0].Rows[0]["HOUSE_AWB_NO"].ToString();
            txtAWBDate.Text= dss.Tables[0].Rows[0]["AWB_DATE"].ToString()=="01/01/1900 00:00:00"?"":dss.Tables[0].Rows[0]["AWB_DATE"].ToString();
            txtDSRDate.Text= dss.Tables[0].Rows[0]["DSR_DATE"].ToString()=="01/01/1900 00:00:00"?"":dss.Tables[0].Rows[0]["DSR_DATE"].ToString();
            txt_Shipper_Accno.Text= dss.Tables[0].Rows[0]["SHIPPER_ACNO"].ToString();
            txt_Shipper_Name.Text= dss.Tables[0].Rows[0]["SHIPPER_NAME"].ToString();
            txt_Shipper_Add1.Text= dss.Tables[0].Rows[0]["SHIPPER_ADD_1"].ToString();
            txt_Shipper_Add2.Text= dss.Tables[0].Rows[0]["SHIPPER_ADD_2"].ToString();
            txt_Shipper_Add3.Text= dss.Tables[0].Rows[0]["SHIPPER_ADD_3"].ToString();
            txt_Shipper_Add4.Text= dss.Tables[0].Rows[0]["SHIPPER_ADD_4"].ToString();
            txt_Consignee_Accno.Text= dss.Tables[0].Rows[0]["CONSIGNEE_ACNO"].ToString();
            txt_Consignee_LC_No.Text= dss.Tables[0].Rows[0]["CONSIGNEE_LCNO"].ToString();
            txt_Consignee_Name.Text= dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            txt_Consignee_Add1.Text= dss.Tables[0].Rows[0]["CONSIGNEE_ADD_1"].ToString();
            txt_Consignee_Add2.Text= dss.Tables[0].Rows[0]["CONSIGNEE_ADD_2"].ToString();
            txt_Consignee_Add3.Text= dss.Tables[0].Rows[0]["CONSIGNEE_ADD_3"].ToString();
            txt_Consignee_Add4.Text= dss.Tables[0].Rows[0]["CONSIGNEE_ADD_4"].ToString();
            txt_Agent_Name.Text= dss.Tables[0].Rows[0]["AGENT_NAME"].ToString();
            txt_Agent_City.Text= dss.Tables[0].Rows[0]["AGENT_CITY"].ToString();
            txt_Agent_IATA_Code.Text= dss.Tables[0].Rows[0]["AGENT_IATA_CODE"].ToString();
            txt_Agent_Acc_No.Text= dss.Tables[0].Rows[0]["AGENT_ACNO"].ToString();
            txt_Agent_Acc_info.Text= dss.Tables[0].Rows[0]["AGENT_AC_INFO"].ToString();
            txt_Airport_Departure.Text= dss.Tables[0].Rows[0]["AIRPORT_DEPATURE_REQ_ROUTING"].ToString();
            txt_Airport_Destination.Text= dss.Tables[0].Rows[0]["AIRPORT_DESTINATION"].ToString();
            txt_flight_No.Text= dss.Tables[0].Rows[0]["FLIGHT_NO"].ToString();
            txtflight_date.Text = dss.Tables[0].Rows[0]["FLIGHT_DATE"].ToString() == "01/01/1900 00:00:00" ? "" : dss.Tables[0].Rows[0]["FLIGHT_DATE"].ToString();
            txt_Amt_of_Insurance.Text= dss.Tables[0].Rows[0]["AMT_OF_INSURANCE"].ToString();
            txt_DV_for_Carriage.Text= dss.Tables[0].Rows[0]["DV_FOR_CARRIAGE"].ToString();
            txt_DV_for_Customs.Text= dss.Tables[0].Rows[0]["DV_FOR_CUSTOMS"].ToString();
            txt_Handling_info.Text= dss.Tables[0].Rows[0]["HANDLING_INFO"].ToString();
            txt_Issued_by.Text= dss.Tables[0].Rows[0]["ISSUED_BY"].ToString();
            txt_to_1.Text= dss.Tables[0].Rows[0]["R_D_TO_1"].ToString();
            txt_by_1.Text= dss.Tables[0].Rows[0]["R_D_BY_1"].ToString();
            txt_to_2.Text= dss.Tables[0].Rows[0]["R_D_TO_2"].ToString();
            txt_by_2.Text= dss.Tables[0].Rows[0]["R_D_BY_2"].ToString();
            txt_to_3.Text= dss.Tables[0].Rows[0]["R_D_TO_3"].ToString();
            txt_by_3.Text= dss.Tables[0].Rows[0]["R_D_BY_3"].ToString();
            txt_Currency.Text= dss.Tables[0].Rows[0]["CURRENCY"].ToString();
            ddlCHGS_Code.SelectedValue= dss.Tables[0].Rows[0]["CHGS_CODE"].ToString();
            txt_WT_VAL.Text= dss.Tables[0].Rows[0]["WT_VAL"].ToString();
            txt_WT_VAL_Other.Text= dss.Tables[0].Rows[0]["OTHER"].ToString();
          
            txt_total_No_of_Pieces_RCP.Text = dss.Tables[0].Rows[0]["CH_NO_OF_PIECES_RCP"].ToString();
            txt_total_Gross_Wgt.Text = dss.Tables[0].Rows[0]["CH_GROSS_WGT"].ToString();
            txt_grid_total.Text = dss.Tables[0].Rows[0]["CH_TOTAL"].ToString();

            txt_wgt_ch_PP.Text= dss.Tables[0].Rows[0]["PP_WGT_CHARGE"].ToString();
            txt_wgt_ch_CC.Text= dss.Tables[0].Rows[0]["CC_WGT_CHARGE"].ToString();
            txt_valuation_Ch_PP.Text= dss.Tables[0].Rows[0]["PP_VALUATION_CHARGE"].ToString();
            txt_valuation_Ch_CC.Text= dss.Tables[0].Rows[0]["CC_VALUATION_CHARGE"].ToString();
            txt_Tax_PP.Text= dss.Tables[0].Rows[0]["PP_TAX"].ToString();
            txt_Tax_CC.Text= dss.Tables[0].Rows[0]["CC_TAX"].ToString();
            txt_tot_oth_Ch_due_agent_PP.Text= dss.Tables[0].Rows[0]["PP_TOTAL_OTH_CH_DUE_AGENT"].ToString();
            txt_tot_oth_Ch_due_agent_CC.Text= dss.Tables[0].Rows[0]["CC_TOTAL_OTH_CH_DUE_AGENT"].ToString();
            txt_tot_oth_Ch_due_Carrier_PP.Text= dss.Tables[0].Rows[0]["PP_TOTAL_OTH_CH_DUE_CARRIER"].ToString();
            txt_tot_oth_Ch_due_Carrier_CC.Text= dss.Tables[0].Rows[0]["CC_TOTAL_OTH_CH_DUE_CARRIER"].ToString();
            txt_total_PP.Text= dss.Tables[0].Rows[0]["PP_TOTAL"].ToString();
            txt_total_CC.Text= dss.Tables[0].Rows[0]["CC_TOTAL"].ToString();

            txt_Notify.Text= dss.Tables[0].Rows[0]["NOTIFY"].ToString();
            txt_other_Ch.Text= dss.Tables[0].Rows[0]["OTHER_CHARGES"].ToString();
            txt_Shipper_or_Agent.Text= dss.Tables[0].Rows[0]["SIGN_OF_SHIPPER"].ToString();
            txt_Exec_on.Text = dss.Tables[0].Rows[0]["EXECUTED_ON"].ToString() == "01/01/1900 00:00:00" ? "" : dss.Tables[0].Rows[0]["EXECUTED_ON"].ToString();
            txt_place_At.Text= dss.Tables[0].Rows[0]["PLACE_AT"].ToString();
            txt_sign_iss_carrier.Text= dss.Tables[0].Rows[0]["SIGN_OF_ISS_CARRIER"].ToString();
            txt_tot_Collect_Charges.Text= dss.Tables[0].Rows[0]["TOTAL_COLLECT_CHARGES"].ToString();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[1];
            gv_Chg_Details.DataBind();
        }
        else
        {
            SetInitialRow();
        }
    }
    private void SetInitialRow()
    {
        try
        {
        DataTable dt = new DataTable();
        DataRow dr = null;

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("No_of_Pieces_RCB", typeof(string)));
        dt.Columns.Add(new DataColumn("Gross_Wgt", typeof(string)));
        dt.Columns.Add(new DataColumn("Kg_Lb", typeof(string)));
        dt.Columns.Add(new DataColumn("Rate_Class", typeof(string)));
        dt.Columns.Add(new DataColumn("Commodity_item_No", typeof(string)));
        dt.Columns.Add(new DataColumn("Charge_wgt", typeof(string)));
        dt.Columns.Add(new DataColumn("Rate_Charge", typeof(string)));
        dt.Columns.Add(new DataColumn("Total", typeof(string)));
        dt.Columns.Add(new DataColumn("Nature_and_Qty", typeof(string)));

        for(int i=1;i<=6;i++)
        {
            dr = dt.NewRow();
            dr["RowNumber"] = i;
            dr["No_of_Pieces_RCB"] = string.Empty;
            dr["Gross_Wgt"] = string.Empty;
            dr["Kg_Lb"] = string.Empty;
            dr["Rate_Class"] = string.Empty;
            dr["Commodity_item_No"] = string.Empty;
            dr["Charge_wgt"] = string.Empty;
            dr["Rate_Charge"] = string.Empty;
            dr["Total"] = string.Empty;
            dr["Nature_and_Qty"] = string.Empty;
            dt.Rows.Add(dr);
        }
        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();
    }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gv_Chg_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
      
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'AWB Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'AWB Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
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
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        Load_Jobno();
    }
    public int Insert_Update(string flag, String xmlData_D, string Expname, string jobno)
    {
        ObjUBO.ITEM_ID = HDupdate_id.Value.ToString();
        ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
        ObjUBO.AWB_INV_NO = "";
        ObjUBO.ITEM_EXPORTER_NAME = ddlExp_name.SelectedValue.ToString();
        ObjUBO.AWB_TYPE = ddlAWB_Type.SelectedValue.ToString();
        ObjUBO.MASTER_AWB_NO_1 = txtMaster_Awb_no_1.Text;
        ObjUBO.MASTER_AWB_NO_2 = txtMaster_Awb_no_2.Text;
        ObjUBO.HOUSE_AWB_NO = txtHouse_Awb_no.Text;
        ObjUBO.AWB_DATE = txtAWBDate.Text==""?"01/01/1900":txtAWBDate.Text;
        ObjUBO.DSR_DATE = txtDSRDate.Text == "" ? "01/01/1900" : txtDSRDate.Text;
        ObjUBO.SHIPPER_ACNO = txt_Shipper_Accno.Text;
        ObjUBO.SHIPPER_NAME = txt_Shipper_Name.Text;
        ObjUBO.SHIPPER_ADD_1 = txt_Shipper_Add1.Text;
        ObjUBO.SHIPPER_ADD_2 = txt_Shipper_Add2.Text;
        ObjUBO.SHIPPER_ADD_3 = txt_Shipper_Add3.Text;
        ObjUBO.SHIPPER_ADD_4 = txt_Shipper_Add4.Text;
        ObjUBO.CONSIGNEE_ACNO = txt_Consignee_Accno.Text;
        ObjUBO.CONSIGNEE_LCNO = txt_Consignee_LC_No.Text;
        ObjUBO.CONSIGNEE_NAME = txt_Consignee_Name.Text;

        ObjUBO.CONSIGNEE_ADD_1 = txt_Consignee_Add1.Text;
        ObjUBO.CONSIGNEE_ADD_2 = txt_Consignee_Add2.Text;
        ObjUBO.CONSIGNEE_ADD_3 = txt_Consignee_Add3.Text;
        ObjUBO.CONSIGNEE_ADD_4 = txt_Consignee_Add4.Text;
        ObjUBO.AGENT_NAME = txt_Agent_Name.Text;
        ObjUBO.AGENT_CITY = txt_Agent_City.Text;
        ObjUBO.AGENT_IATA_CODE = txt_Agent_IATA_Code.Text;
        ObjUBO.AGENT_ACNO = txt_Agent_Acc_No.Text;
        ObjUBO.AGENT_AC_INFO = txt_Agent_Acc_info.Text;
        ObjUBO.AIRPORT_DEPATURE_REQ_ROUTING = txt_Airport_Departure.Text;
        ObjUBO.AIRPORT_DESTINATION = txt_Airport_Destination.Text;
        ObjUBO.FLIGHT_NO = txt_flight_No.Text;
        ObjUBO.FLIGHT_DATE = txtflight_date.Text == "" ? "01/01/1900" : txtflight_date.Text;
        ObjUBO.AMT_OF_INSURANCE = txt_Amt_of_Insurance.Text;
        ObjUBO.DV_FOR_CARRIAGE = txt_DV_for_Carriage.Text;
        ObjUBO.DV_FOR_CUSTOMS = txt_DV_for_Customs.Text;
        ObjUBO.HANDLING_INFO = txt_Handling_info.Text;
        ObjUBO.ISSUED_BY = txt_Issued_by.Text;
        ObjUBO.R_D_TO_1 = txt_to_1.Text;
        ObjUBO.R_D_BY_1 = txt_by_1.Text;
        ObjUBO.R_D_TO_2 = txt_to_2.Text;
        ObjUBO.R_D_BY_2 = txt_by_2.Text;
        ObjUBO.R_D_TO_3 = txt_to_3.Text;
        ObjUBO.R_D_BY_3 = txt_by_3.Text;
        ObjUBO.CURRENCY = txt_Currency.Text;
        ObjUBO.CHGS_CODE = ddlCHGS_Code.SelectedValue.ToString();
        ObjUBO.WT_VAL = txt_WT_VAL.Text;
        ObjUBO.OTHER = txt_WT_VAL_Other.Text;

        ObjUBO.CH_NO_OF_PIECES_RCP=txt_total_No_of_Pieces_RCP.Text;
        ObjUBO.CH_GROSS_WGT=txt_total_Gross_Wgt.Text ;
        ObjUBO.CH_TOTAL=txt_grid_total.Text;
        ObjUBO.PP_WGT_CHARGE = txt_wgt_ch_PP.Text;
        ObjUBO.CC_WGT_CHARGE = txt_wgt_ch_CC.Text;
        ObjUBO.PP_VALUATION_CHARGE = txt_valuation_Ch_PP.Text;
        ObjUBO.CC_VALUATION_CHARGE = txt_valuation_Ch_CC.Text;
        ObjUBO.PP_TAX = txt_Tax_PP.Text;
        ObjUBO.CC_TAX = txt_Tax_CC.Text;
        ObjUBO.PP_TOTAL_OTH_CH_DUE_AGENT = txt_tot_oth_Ch_due_agent_PP.Text;
        ObjUBO.CC_TOTAL_OTH_CH_DUE_AGENT = txt_tot_oth_Ch_due_agent_CC.Text;
        ObjUBO.PP_TOTAL_OTH_CH_DUE_CARRIER = txt_tot_oth_Ch_due_Carrier_PP.Text;
        ObjUBO.CC_TOTAL_OTH_CH_DUE_CARRIER = txt_tot_oth_Ch_due_Carrier_CC.Text;
        ObjUBO.PP_TOTAL = txt_total_PP.Text;
        ObjUBO.CC_TOTAL = txt_total_CC.Text;
        ObjUBO.NOTIFY = txt_Notify.Text;
        ObjUBO.OTHER_CHARGES = txt_other_Ch.Text;
        ObjUBO.SIGN_OF_SHIPPER = txt_Shipper_or_Agent.Text;
        ObjUBO.EXECUTED_ON = txt_Exec_on.Text == "" ? "01/01/1900" : txt_Exec_on.Text;
        ObjUBO.PLACE_AT = txt_place_At.Text;
        ObjUBO.SIGN_OF_ISS_CARRIER = txt_sign_iss_carrier.Text;
        ObjUBO.TOTAL_COLLECT_CHARGES = txt_tot_Collect_Charges.Text;
        ObjUBO.USER_ID = Connection.Current_User();
        ObjUBO.BRANCH_CODE = Connection.Current_Branch();
        ObjUBO.WORKING_PERIOD = Connection.WorkingPeriod();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        AWB_EXP.Xml_D = xmlData_D;
        ObjUBO.flag = flag;
        AWB_EXP.Export_Item_Details_insertupdate(ObjUBO);
        i = AWB_EXP.result;
        return i;
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            Load_Job_Details();
        }
        else
        {
            gv_Chg_Details.DataSource = null;
            gv_Chg_Details.DataBind();
        }
    }
    private void Load_Job_Details()
    {
        try
        {
        DataSet dss = new DataSet();
        ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.flag = "Exp_Jobno_Details_Select";
        dss = AWB_EXP.AWB_EXPORT_INV_SELECT(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            string AP = string.Empty;
            AP = Connection.Current_Branch();
               string[] arr = new string[] { };

               if (AP != string.Empty && AP != null)
               {
                   arr = AP.Split(',');
                   AP = arr[1].ToString().TrimStart();
                   txt_Airport_Departure.Text = AP.ToUpper() + " / " + "INDIA";
               }
            ddlExp_name.SelectedValue = dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
            txt_Shipper_Name.Text = dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
            txt_Shipper_Add1.Text = dss.Tables[0].Rows[0]["ADDRESS1"].ToString();
            txt_Shipper_Add2.Text = dss.Tables[0].Rows[0]["ADDRESS2"].ToString();
            txt_Shipper_Add3.Text = dss.Tables[0].Rows[0]["ADDRESS4"].ToString();
            txt_Shipper_Add4.Text = dss.Tables[0].Rows[0]["ADDRESS5"].ToString();

            txt_Consignee_Name.Text = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            txt_Consignee_Add1.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
            txt_Consignee_Add2.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
            txt_Consignee_Add3.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
            txt_Consignee_Add4.Text = dss.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();
        }
        else
        {
            Clear();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            gv_Chg_Details.DataSource = dss.Tables[1];
            gv_Chg_Details.DataBind();
        }
        else
        {
            SetInitialRow();
        }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void Clear()
    {
        txt_Shipper_Name.Text = string.Empty;
        txt_Shipper_Add1.Text = string.Empty;
        txt_Shipper_Add2.Text = string.Empty;
        txt_Shipper_Add3.Text = string.Empty;
        txt_Shipper_Add4.Text = string.Empty;

        txt_Consignee_Name.Text = string.Empty;
        txt_Consignee_Add1.Text = string.Empty;
        txt_Consignee_Add2.Text = string.Empty;
        txt_Consignee_Add3.Text = string.Empty;
        txt_Consignee_Add4.Text = string.Empty;
    }
    private void Load_Jobno()
    {
        try
        {
        DataSet dss = new DataSet();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.ITEM_EXPORTER_NAME = ddlExp_name.SelectedValue.ToString();
        ObjUBO.flag = "Exp_Jobno_Select";
        dss = AWB_EXP.AWB_EXPORT_INV_SELECT(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            ddljobno.DataSource = dss.Tables[0];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Clear();
        }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private String Read_grid()
    {
       
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("ID", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("No_of_Pieces_RCB", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Gross_Wgt", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Kg_Lb", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Rate_Class", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Commodity_item_No", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Charge_wgt", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Rate_Charge", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Total", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Nature_and_Qty", typeof(String)));
       
        int R = 1;
        foreach (GridViewRow row in gv_Chg_Details.Rows)
        {
            TextBox txt_No_of_Pieces_RCB = (TextBox)row.FindControl("txt_No_of_Pieces_RCB");
            TextBox txt_Gross_Wgt = (TextBox)row.FindControl("txt_Gross_Wgt");
            TextBox txt_Kg_Lb = (TextBox)row.FindControl("txt_Kg_Lb");
            TextBox txt_Rate_Class = (TextBox)row.FindControl("txt_Rate_Class");

            TextBox txt_Commodity_item_No = (TextBox)row.FindControl("txt_Commodity_item_No");
            TextBox txt_Charge_wgt = (TextBox)row.FindControl("txt_Charge_wgt");
            TextBox txt_Rate_Charge = (TextBox)row.FindControl("txt_Rate_Charge");
            TextBox txt_Total = (TextBox)row.FindControl("txt_Total");
            TextBox txt_Nature_and_Qty = (TextBox)row.FindControl("txt_Nature_and_Qty");

                dr = dtt.NewRow();
                dr[0] = R;
                dr[1] = txt_No_of_Pieces_RCB.Text;
                dr[2] = txt_Gross_Wgt.Text;
                dr[3] = txt_Kg_Lb.Text;
                dr[4] = txt_Rate_Class.Text;
                dr[5] = txt_Commodity_item_No.Text;
                dr[6] = txt_Charge_wgt.Text;
                dr[7] = txt_Rate_Charge.Text;
                dr[8] = txt_Total.Text;
                dr[9] = txt_Nature_and_Qty.Text;

                dtt.Rows.Add(dr);
                R = R + 1;
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData ;
         
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
        if (ddljobno.SelectedItem.Text != string.Empty)
        {
            Insert_Update("S", Read_grid(), ddlExp_name.SelectedValue.ToString(), ddljobno.SelectedValue.ToString());
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
                // HD_Showcon.Value = "SAVED";
                Alert_msg("Saved Successfully", "btnSave");
                HDupdate_id.Value = Convert.ToString(AWB_EXP.UPDATE_ID);
                ddlExp_name.Attributes.Add("readonly", "readonly");
                ddlExp_name.Style.Add("background-color", "#F0F0F0");
                ddljobno.Attributes.Add("readonly", "readonly");
                ddljobno.Style.Add("background-color", "#F0F0F0");
                ddlExp_name.Enabled = false;
                ddljobno.Enabled = false;
                ddlAWB_Type.Enabled = false;
                F.Visible = false;
                T.Visible = true;
                btnrpt.Visible = true;
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
        }
        else
        {
            Alert_msg("Select Ur Jobno");
        }
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
            i = Insert_Update("U", Read_grid(), ddlExp_name.SelectedItem.Text, ddljobno.SelectedValue.ToString());
                if (i == 1)
                {
                    if (ViewState["UPDATED_ID"] != null)
                    {
                        Alert_msg("Updated Successfully", "btnUpdate");
                    }
                    else
                    {
                        Alert_msg("Saved Successfully", "btnUpdate");
                       // HD_Showcon.Value = "SAVED";
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
            ObjUBO.ITEM_ID = HDupdate_id.Value.ToString();
            ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
            ObjUBO.ITEM_EXPORTER_NAME = ddlExp_name.SelectedValue.ToString();
            ObjUBO.flag = "D";
            AWB_EXP.Export_Item_Details_insertupdate(ObjUBO);
            i = AWB_EXP.result;

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
            er.makeLog(ex.Message);
        }
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        try
        {
            Transaction trans = new Transaction();
            trans.ResetFields(Page.Controls);
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;

            DataTable dt = new DataTable();
            gv_Chg_Details.DataSource = dt;
            gv_Chg_Details.DataBind();

            SetInitialRow();

            Clear();
            HDupdate_id.Value = string.Empty;

            ddlExp_name.Enabled = true;
            ddljobno.Enabled = true;
            ddlExp_name.Enabled = true;
            ddljobno.Enabled = true;
            ddlExp_name.Attributes.Remove("readonly");
            ddlExp_name.Style.Add("background-color", "White");

            ddljobno.Attributes.Remove("readonly");
            ddljobno.Style.Add("background-color", "White");

            ddlAWB_Type.Enabled = true;
            ddlAWB_Type.SelectedIndex = -1;

            load_Exp_name();
            btnrpt.Visible = false;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Exp_name()
    {
        try
        {
        DataSet dss = new DataSet();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.flag = "Exp_Name_Select";
        dss = AWB_EXP.AWB_EXPORT_INV_SELECT(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            ddlExp_name.DataSource = dss.Tables[0];
            ddlExp_name.DataTextField = "Exp_Name";
            ddlExp_name.DataValueField = "Exp_Name";
            ddlExp_name.DataBind();
            ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlExp_name.SelectedIndex = 0;
        }
        else
        {
            ddlExp_name.Items.Clear();
        }
        if (dss.Tables[1].Rows.Count > 0)
        {
            ddljobno.DataSource = dss.Tables[1];
            ddljobno.DataTextField = "JOBNO";
            ddljobno.DataValueField = "JOBNO";
            ddljobno.DataBind();
            ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddljobno.SelectedIndex = 0;
        }
        else
        {
            ddljobno.Items.Clear();
        }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
}