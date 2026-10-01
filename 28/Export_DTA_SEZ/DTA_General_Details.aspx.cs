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

public partial class DTA_General_Details : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    Exp_DTA DTA = new Exp_DTA();
    Global_variables ObjUBO = new Global_variables();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    public string Exp_Jobno = string.Empty, Filepath_ETP = string.Empty, logFileName=string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        Exp_Jobno = Connection.EXP_Jobno();
        hdn_Jobno.Value = Exp_Jobno;

        if (!Page.IsPostBack)
        {
            if (Exp_Jobno != string.Empty)
            {
                load_Data(Exp_Jobno);
            }
        }
    }

    private void load_Data(string Jobno)
    {
        try
        {
            ObjUBO.A2 = Jobno;
            ObjUBO.A10 = "Select_DTA_General_Details";
            ds= DTA.DTA_Data_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["JOBID"].ToString();
                ViewState["UPDATED_ID"] = ds.Tables[0].Rows[0]["JOBID"].ToString();
             
                txt_SezUnitCode.Text = ds.Tables[0].Rows[0]["SEZ_UNIT_CODE"].ToString();
                txt_SezUnitName.Text = ds.Tables[0].Rows[0]["SEZ_UNIT_NAME"].ToString();
                txt_SezUnitAddress.Text = ds.Tables[0].Rows[0]["SEZ_UNIT_ADDRESS"].ToString();
                txt_SezCity.Text = ds.Tables[0].Rows[0]["SEZ_UNIT_CITY"].ToString();
                txt_SezState.Text = ds.Tables[0].Rows[0]["SEZ_UNIT_STATE"].ToString();
                txt_SezPinCode.Text = ds.Tables[0].Rows[0]["SEZ_UNIT_PINCODE"].ToString();
                txt_IEC_Code.Text = ds.Tables[0].Rows[0]["SEZ_UNIT_IEC"].ToString();
                txt_SezGSTIN.Text = ds.Tables[0].Rows[0]["SEZ_UNIT_GSTIN"].ToString();

                txt_DTA_Unit_GSTIN.Text = ds.Tables[0].Rows[0]["DTA_UNIT_GSTIN"].ToString();
                txt_DTA_Unit_PAN.Text = ds.Tables[0].Rows[0]["DTA_UNIT_PAN"].ToString();
                txt_DTA_UnitName.Text = ds.Tables[0].Rows[0]["DTA_UNIT_NAME"].ToString();
                txt_DTA_UnitAddress.Text = ds.Tables[0].Rows[0]["DTA_UNIT_ADDRESS"].ToString();
                txt_DTA_UnitCity.Text = ds.Tables[0].Rows[0]["DTA_UNIT_CITY"].ToString();
                txt_DTA_UnitState.Text = ds.Tables[0].Rows[0]["DTA_UNIT_STATE"].ToString();
                txt_DTA_UnitPincode.Text = ds.Tables[0].Rows[0]["DTA_UNIT_PINCODE"].ToString();
                txt_DTA_UnitIEC.Text = ds.Tables[0].Rows[0]["DTA_UNIT_IEC_CODE"].ToString();
                ddl_DTA_Unit_Type.SelectedValue = ds.Tables[0].Rows[0]["DTA_UNIT_TYPE"].ToString();

                ddl_Declaration_of_IGST.SelectedValue = ds.Tables[0].Rows[0]["IGST_DECLARATION"].ToString();
                txt_LUT_Number.Text = ds.Tables[0].Rows[0]["LUT_NUMBER"].ToString();
                txt_LUT_Date.Text = ds.Tables[0].Rows[0]["LUT_DATE"].ToString();
                txt_ARE_Number.Text = ds.Tables[0].Rows[0]["ARE_NUMBER"].ToString();
                txt_ARE_Date.Text = ds.Tables[0].Rows[0]["ARE_DATE"].ToString();
                txt_ARE_Range.Text = ds.Tables[0].Rows[0]["ARE_RANGE"].ToString();
                txt_ARE_Division.Text = ds.Tables[0].Rows[0]["ARE_DIVISION"].ToString();
                txt_ARE_Address.Text = ds.Tables[0].Rows[0]["ARE_ADDRESS"].ToString();
                txt_ARE_Commissionerate.Text = ds.Tables[0].Rows[0]["ARE_COMMISSIONERATE"].ToString();
                txt_ARE_DutyAmount.Text = ds.Tables[0].Rows[0]["ARE_DUTY_AMOUNT"].ToString();
                RDL_Cenvat.Text = ds.Tables[0].Rows[0]["CENVAT_YN"].ToString();
                RDL_CentralExcise_41.Text = ds.Tables[0].Rows[0]["CENTRAL_EXCISE_41"].ToString();
                RDL_CentralExcise_43.Text = ds.Tables[0].Rows[0]["CENTRAL_EXCISE_43"].ToString();
                txt_AddlRemarks.Text = ds.Tables[0].Rows[0]["ADDL_REMARKS"].ToString();

                if (ds.Tables[0].Rows[0]["ARE_YN"].ToString() == "Yes")
                {
                    chk_ARE_YN.Checked = true;
                }

                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnDelete.Visible = true;
                Load_JSON();
                btn_Json.Visible = true;
            }
            else
            {
                //**************************************************
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_SezUnitCode.Text = ds.Tables[1].Rows[0]["SEZ_UNIT_CODE"].ToString();
                    txt_SezUnitName.Text = ds.Tables[1].Rows[0]["SEZ_UNIT_NAME"].ToString();
                    txt_SezUnitAddress.Text = ds.Tables[1].Rows[0]["SEZ_UNIT_ADDRESS"].ToString();
                    txt_SezCity.Text = ds.Tables[1].Rows[0]["SEZ_UNIT_CITY"].ToString();
                    txt_SezState.Text = ds.Tables[1].Rows[0]["SEZ_UNIT_STATE"].ToString();

                    txt_SezPinCode.Text = ds.Tables[1].Rows[0]["SEZ_UNIT_PINCODE"].ToString();
                    txt_IEC_Code.Text = ds.Tables[1].Rows[0]["SEZ_UNIT_IEC"].ToString();
                    txt_SezGSTIN.Text = ds.Tables[1].Rows[0]["SEZ_UNIT_GSTIN"].ToString();

                    //txt_DTA_Unit_GSTIN.Text = ds.Tables[1].Rows[0]["DTA_UNIT_GSTIN"].ToString();
                    //txt_DTA_Unit_PAN.Text = ds.Tables[1].Rows[0]["DTA_UNIT_PAN"].ToString();
                    //txt_DTA_UnitName.Text = ds.Tables[1].Rows[0]["DTA_UNIT_NAME"].ToString();
                    //txt_DTA_UnitAddress.Text = ds.Tables[1].Rows[0]["DTA_UNIT_ADDRESS"].ToString();
                    //txt_DTA_UnitCity.Text = ds.Tables[1].Rows[0]["DTA_UNIT_CITY"].ToString();
                    //txt_DTA_UnitState.Text = ds.Tables[1].Rows[0]["DTA_UNIT_STATE"].ToString();
                    //txt_DTA_UnitPincode.Text = ds.Tables[1].Rows[0]["DTA_UNIT_PINCODE"].ToString();
                    //txt_DTA_UnitIEC.Text = ds.Tables[1].Rows[0]["DTA_UNIT_IEC_CODE"].ToString();
                    //ddl_DTA_Unit_Type.SelectedValue = ds.Tables[1].Rows[0]["DTA_UNIT_TYPE"].ToString();

                    //ddl_Declaration_of_IGST.SelectedValue = ds.Tables[1].Rows[0]["IGST_DECLARATION"].ToString();
                    //txt_LUT_Number.Text = ds.Tables[1].Rows[0]["LUT_NUMBER"].ToString();
                    //txt_LUT_Date.Text = ds.Tables[1].Rows[0]["LUT_DATE"].ToString();
                    //txt_ARE_Number.Text = ds.Tables[1].Rows[0]["ARE_NUMBER"].ToString();
                    //txt_ARE_Date.Text = ds.Tables[1].Rows[0]["ARE_DATE"].ToString();
                    //txt_ARE_Range.Text = ds.Tables[1].Rows[0]["ARE_RANGE"].ToString();
                    //txt_ARE_Division.Text = ds.Tables[1].Rows[0]["ARE_DIVISION"].ToString();
                    //txt_ARE_Address.Text = ds.Tables[1].Rows[0]["ARE_ADDRESS"].ToString();
                    //txt_ARE_Commissionerate.Text = ds.Tables[1].Rows[0]["ARE_COMMISSIONERATE"].ToString();
                    //txt_ARE_DutyAmount.Text = ds.Tables[1].Rows[0]["ARE_DUTY_AMOUNT"].ToString();
                    //RDL_Cenvat.Text = ds.Tables[1].Rows[0]["CENVAT_YN"].ToString();
                    //RDL_CentralExcise_41.Text = ds.Tables[1].Rows[0]["CENTRAL_EXCISE_41"].ToString();
                    //RDL_CentralExcise_43.Text = ds.Tables[1].Rows[0]["CENTRAL_EXCISE_43"].ToString();
                    //txt_AddlRemarks.Text = ds.Tables[1].Rows[0]["ADDL_REMARKS"].ToString();

                    //if (ds.Tables[1].Rows[0]["ARE_YN"].ToString() == "Yes")
                    //{
                    //    chk_ARE_YN.Checked = true;
                    //}
                }
                //**************************************************
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;                
                btn_Json.Visible = false;
                imgbtnFlatFile.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
  
    protected void btnNew_Click(object sender, EventArgs e)
    {
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["TRANSPORT_MODE"] != null)
            {

                ds = Save_Update("U");
                if (DTA.result==1)
                {
                    Load_JSON();
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

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ds = Save_Update("S");
            if (DTA.result==1)
            {
                btnUpdate.CssClass = "save";
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                btnSave.Focus();
                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");
                HDupdate_id.Value = Convert.ToString(DTA.UPDATE_ID);
                btn_Json.Visible = true;
            }
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
                Alert_msg("Not Saved.", "btnSave");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        try
        {
            ObjUBO.A2 = Exp_Jobno;
            ObjUBO.A10 = "Delete_DTA_General_Details";
            ds= DTA.DTA_Data_Select(ObjUBO);

            if (DTA.result==1)
            {
                Alert_msg("Deleted");
                btn_Json.Visible = false;
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

    private DataSet Save_Update(string Flag)
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = HDupdate_id.Value.ToString();
        ObjUBO.A2 = Exp_Jobno;
        ObjUBO.A3 = txt_SezUnitCode.Text;
        ObjUBO.A4 = txt_SezUnitName.Text;
        ObjUBO.A5 = txt_SezUnitAddress.Text;
        ObjUBO.A6 = txt_SezCity.Text;
        ObjUBO.A7 = txt_SezState.Text;
        ObjUBO.A8 = txt_SezPinCode.Text;
        ObjUBO.A9 = txt_IEC_Code.Text;
        ObjUBO.A10 = txt_SezGSTIN.Text;

        ObjUBO.A11 = txt_DTA_Unit_GSTIN.Text;
        ObjUBO.A12 = txt_DTA_Unit_PAN.Text;
        ObjUBO.A13 = txt_DTA_UnitName.Text;
        ObjUBO.A14 = txt_DTA_UnitAddress.Text;
        ObjUBO.A15 = txt_DTA_UnitCity.Text;
        ObjUBO.A16 = txt_DTA_UnitState.Text;
        ObjUBO.A17 = txt_DTA_UnitPincode.Text;
        ObjUBO.A18 = txt_DTA_UnitIEC.Text;
        ObjUBO.A19 = ddl_DTA_Unit_Type.SelectedItem.Text;

        ObjUBO.A20 = ddl_Declaration_of_IGST.SelectedItem.Text;
        ObjUBO.A21 = txt_LUT_Number.Text;
        ObjUBO.A22 = txt_LUT_Date.Text;

        ObjUBO.A23 = chk_ARE_YN.Checked == true ? "Yes" : "No";
        ObjUBO.A24 = txt_ARE_Number.Text;
        ObjUBO.A25 = txt_ARE_Date.Text;
        ObjUBO.A26 = txt_ARE_Range.Text;
        ObjUBO.A27 = txt_ARE_Division.Text;
        ObjUBO.A28 = txt_ARE_Address.Text;
        ObjUBO.A29 = txt_ARE_Commissionerate.Text;
        ObjUBO.A30 = txt_ARE_DutyAmount.Text;

        ObjUBO.A31 = RDL_Cenvat.SelectedValue;
        ObjUBO.A32 = RDL_CentralExcise_41.SelectedValue;
        ObjUBO.A33 = RDL_CentralExcise_43.SelectedValue;
        ObjUBO.A34 = txt_AddlRemarks.Text;//Remarks


        ObjUBO.A35 = Flag;
        ds = DTA.Export_DTA_GENERAL_Ins_Upd(ObjUBO);
        return ds;
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DTA - SEZ', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'DTA - SEZ', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private void Load_JSON()
    {
        imgbtnFlatFile.Visible = false;
        string Gen_det = string.Empty, Con_det = string.Empty, DTA_Invoice_Result = string.Empty, DTA_Item_Result = string.Empty, Master_Det = string.Empty, jsonOut = string.Empty, filepath = string.Empty;
        filepath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + "Export_DTA_SEZ" + "/" + Session["currentuser"].ToString() + "/");

        if (Directory.Exists(filepath) == false)
        {
            Directory.CreateDirectory(filepath);
        }

        DirectoryInfo dir = new DirectoryInfo(filepath);
        foreach (FileInfo fi in dir.GetFiles())
        {
            fi.Delete();
        }
        //----------------------------------
        DataSet ds = new DataSet();
        ObjUBO.A2 = Exp_Jobno;
        ObjUBO.A10 = "DTA_All_JSon_Data";
        ds = DTA.DTA_Data_Select(ObjUBO);


        if (ds.Tables[0].Rows.Count > 0)
        {
            
            DTA_Invoice_Result = DTA_INVOICE(Gen_det, ds.Tables[1]);
            DTA_Item_Result = DTA_ITEM(Gen_det, ds.Tables[2]);


            Master_Det = "{" + @"""" + "generalDetailsRequest" + @"""" + ":{" +
                        @"""" + "sezUnitCode" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SEZ_UNIT_CODE"].ToString() + @"""" +
                       "," + @"""" + "sezUnitName" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SEZ_UNIT_NAME"].ToString() + @"""" +
                       "," + @"""" + "sezIecCode" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SEZ_UNIT_IEC"].ToString() + @"""" +
                       "," + @"""" + "sezUnitAddress" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SEZ_UNIT_ADDRESS"].ToString() + @"""" +
                       "," + @"""" + "sezCity" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SEZ_UNIT_CITY"].ToString() + @"""" +
                       "," + @"""" + "sezState" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SEZ_UNIT_STATE"].ToString() + @"""" +
                       "," + @"""" + "sezPinCode" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SEZ_UNIT_PINCODE"].ToString() + @"""" +
                       "," + @"""" + "sezGstin" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["SEZ_UNIT_GSTIN"].ToString() + @"""" +

                       "," + @"""" + "dtaUnitGstin" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["DTA_UNIT_GSTIN"].ToString() + @"""" +
                       "," + @"""" + "dtaUnitPan" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["DTA_UNIT_PAN"].ToString() + @"""" +
                       "," + @"""" + "dtaUnitName" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["DTA_UNIT_NAME"].ToString() + @"""" +
                       "," + @"""" + "dtaUnitAddressLine1" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["DTA_UNIT_ADDRESS"].ToString() + @"""" +
                       "," + @"""" + "dtaUnitCity" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["DTA_UNIT_CITY"].ToString() + @"""" +
                       "," + @"""" + "dtaUnitState" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["DTA_UNIT_STATE"].ToString() + @"""" +
                       "," + @"""" + "dtaUnitPinCode" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["DTA_UNIT_PINCODE"].ToString() + @"""" +
                       "," + @"""" + "dtaIecCode" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["DTA_UNIT_IEC_CODE"].ToString() + @"""" +
                       "," + @"""" + "typeOfDtaUnit" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["DTA_UNIT_TYPE"].ToString() + @"""" +

                       "," + @"""" + "igstDeclaration" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["IGST_DECLARATION"].ToString() + @"""" +
                       "," + @"""" + "lutNumber" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["LUT_NUMBER"].ToString() + @"""" +
                       "," + @"""" + "lutDate" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["LUT_DATE"].ToString() + @"""" +
                       "," + @"""" + "areDetailsToBeFilled" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["ARE_YN"].ToString() + @"""" +
                       "," + @"""" + "areNumber" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["ARE_NUMBER"].ToString() + @"""" +
                       "," + @"""" + "areDate" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["ARE_DATE"].ToString() + @"""" +
                       "," + @"""" + "range" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["ARE_RANGE"].ToString() + @"""" +
                       "," + @"""" + "division" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["ARE_DIVISION"].ToString() + @"""" +
                       "," + @"""" + "address" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["ARE_ADDRESS"].ToString() + @"""" +
                       "," + @"""" + "commissionerate" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["ARE_COMMISSIONERATE"].ToString() + @"""" +
                       "," + @"""" + "dutyAmountAsPerAre" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["ARE_DUTY_AMOUNT"].ToString() + @"""" +
                       "," + @"""" + "availingFacilityOfCenvatCreditUnderCenvatCreditRules" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["CENVAT_YN"].ToString() + @"""" +
                       "," + @"""" + "availingFacilityUnderNotification41" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["CENTRAL_EXCISE_41"].ToString() + @"""" +
                       "," + @"""" + "availingFacilityUnderNotification43" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["CENTRAL_EXCISE_43"].ToString() + @"""" +
                       "," + @"""" + "generalRemarks" + @"""" + ":" + @"""" + ds.Tables[0].Rows[0]["ADDL_REMARKS"].ToString() + @"""" +

                       "}";

            jsonOut = Master_Det + DTA_Invoice_Result + DTA_Item_Result + "}";
            logFileName = "sez-dta-procurement_" + Exp_Jobno + ".JSON";
            Session["createflename"] = logFileName;
            System.IO.File.WriteAllText(filepath + logFileName, jsonOut);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
            imgbtnFlatFile.Visible = true;
            //--------------------------------
            DateTime date = System.DateTime.Now;
            string yy = Convert.ToDateTime(date).ToString("yyyy").ToString();
            lblmsg.Text = "Json Generated Successfully. " + "( " + date + " )";
        }
        else
        {
            lblmsg.Text = "";
            Alert_msg("Enter Ur Master Details !");
        }
    }


    public string DTA_INVOICE(string OP, DataTable dtt)
    {
        string Ch_Data_A = string.Empty, Ch_Data_B = string.Empty, Ch_Data_C = string.Empty, Ch_Data = string.Empty;
        if (dtt.Rows.Count > 0)
        {
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    Ch_Data_A = OP + "," + @"""" + "invoiceDetailsRequest" + @"""" + ":[{" + @"""" + "invoiceNumber" + @"""" + ":" + @"""" + dtt.Rows[i]["INVOICE_NO"].ToString() + @"""";
                }
                else
                {
                    Ch_Data_A = ",{" + @"""" + "invoiceNumber" + @"""" + ":" + @"""" + dtt.Rows[i]["INVOICE_NO"].ToString() + @"""";
                }
                Ch_Data_B = Ch_Data_A + "," + @"""" + "invoiceValue" + @"""" + ":" + @"""" + dtt.Rows[i]["INVOICE_VALUE"].ToString() + @"""" +
                 "," + @"""" + "invoiceValueInr" + @"""" + ":" + @"""" + dtt.Rows[i]["INVOICE_VALUE_INR"].ToString() + @"""" +
                 "," + @"""" + "invoiceDate" + @"""" + ":" + @"""" + dtt.Rows[i]["INVOICE_DATE"].ToString() + @"""" +
                 "," + @"""" + "natureOfTransaction" + @"""" + ":" + @"""" + dtt.Rows[i]["NATURE_OF_TRANSACTION"].ToString() + @"""" +
                 "," + @"""" + "natureOfSupply" + @"""" + ":" + @"""" + dtt.Rows[i]["NATURE_OF_SUPPLY"].ToString() + @"""" +
                 "," + @"""" + "invoiceCurrency" + @"""" + ":" + @"""" + dtt.Rows[i]["INVOICE_CURRENCY"].ToString() + @"""" +
                 "," + @"""" + "exchangeRate" + @"""" + ":" + @"""" + dtt.Rows[i]["EXCHANGE_RATE"].ToString() + @"""" +
                 "," + @"""" + "igstAmount" + @"""" + ":" + @"""" + dtt.Rows[i]["TOT_IGST_AMOUNT"].ToString() + @"""" +
                 "," + @"""" + "cessAmount" + @"""" + ":" + @"""" + dtt.Rows[i]["TOT_CESS_AMOUNT"].ToString() + @"""" +
                  "," + @"""" + "dutyAmountasPer" + @"""" + ":" + @"""" + dtt.Rows[i]["DUTY_AMT_AS_PER_ARE"].ToString() + @""""+
                 "," + @"""" + "invoiceFileIrn" + @"""" + ":" + @"""" + dtt.Rows[i]["UNIQUE_DOC_NUMBER"].ToString() + @"""" +
                 "," + @"""" + "invoiceFileName" + @"""" + ":" + @"""" + dtt.Rows[i]["ICEGATE_DOC_FILE_NAME"].ToString() + @"""" + "}";
               

                Ch_Data_C += Ch_Data_B;
                Ch_Data_A = string.Empty;
                Ch_Data_B = string.Empty;
            }
            Ch_Data = Ch_Data_C + "]";
        }
        else
        {
            //Ch_Data = OP;
            Ch_Data_A = OP + "," + @"""" + "invoiceDetailsRequest" + @"""" + ":[";
            Ch_Data = Ch_Data_A + "]";
        }
        return Ch_Data;
    }


    public string DTA_ITEM(string OP, DataTable dtt)
    {
        string Ch_Data_A = string.Empty, Ch_Data_B = string.Empty, Ch_Data_C = string.Empty, Ch_Data = string.Empty;
        if (dtt.Rows.Count > 0)
        {
            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    Ch_Data_A = OP + "," + @"""" + "itemDetailsRequest" + @"""" + ":[{" + @"""" + "invoiceNumber" + @"""" + ":" + @"""" + dtt.Rows[i]["INVOICE_NO"].ToString() + @"""";
                }
                else
                {
                    Ch_Data_A = ",{" + @"""" + "invoiceNumber" + @"""" + ":" + @"""" + dtt.Rows[i]["INVOICE_NO"].ToString() + @"""";
                }
                Ch_Data_B = Ch_Data_A + "," + @"""" + "invoiceDate" + @"""" + ":" + @"""" + dtt.Rows[i]["INVOICE_DATE"].ToString() + @"""" +
                    "," + @"""" + "itemDescription1" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_DESCRIPTION1"].ToString() + @"""" +
                 "," + @"""" + "itemDescription2" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_DESCRIPTION2"].ToString() + @"""" +
                 "," + @"""" + "itemDescription3" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_DESCRIPTION3"].ToString() + @"""" +
                 "," + @"""" + "quantity" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_QTY"].ToString() + @"""" +
                 "," + @"""" + "unitOfMeasurement" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_QTY_CODE"].ToString() + @"""" +
                    "," + @"""" + "unitPrice" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_UNIT_PRICE"].ToString() + @"""" +
                    "," + @"""" + "productValue" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_AMOUNT"].ToString() + @"""" +
                 "," + @"""" + "presentMarketValue" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_PMVVALUE"].ToString() + @"""" +
                 "," + @"""" + "itemAccessories" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_ACCESSORIES_DESC"].ToString() + @"""" +
                 "," + @"""" + "hsCode" + @"""" + ":" + @"""" + dtt.Rows[i]["RITCNO"].ToString() + @"""" +
                 "," + @"""" + "rebateClaimed" + @"""" + ":" + @"""" + dtt.Rows[i]["REBATE_CLAIMED_AMOUNT"].ToString() + @"""" +
                 "," + @"""" + "itemType" + @"""" + ":" + @"""" + dtt.Rows[i]["ITEM_TYPE"].ToString() + @"""" +
                 "," + @"""" + "taxableValue" + @"""" + ":" + @"""" + dtt.Rows[i]["TAXABLE_VALUE"].ToString() + @"""" +
                 "," + @"""" + "igstNotificationNumber" + @"""" + ":" + @"""" + dtt.Rows[i]["IGST_NOTN_NO"].ToString() + @"""" +
                 "," + @"""" + "igstNotificationSerialNumber" + @"""" + ":" + @"""" + dtt.Rows[i]["IGST_NOTN_SLNO"].ToString() + @"""" +
                 //"," + @"""" + "isGstExempt" + @"""" + ":" + @"""" + dtt.Rows[i]["GST_EXEMPT_YN"].ToString() + @"""" +
                 "," + @"""" + "isGstExempt" + @"""" + ":" + @"""" + dtt.Rows[i]["IGST_EXEMPT"].ToString() + @"""" +
                 "," + @"""" + "igstRate" + @"""" + ":" + @"""" + dtt.Rows[i]["IGST_RATE"].ToString() + @"""" +
                 "," + @"""" + "igstAmount" + @"""" + ":" + @"""" + dtt.Rows[i]["IGST_AMT"].ToString() + @"""" +
                 "," + @"""" + "cessNotificationNumber" + @"""" + ":" + @"""" + dtt.Rows[i]["COMPENSATION_CESS_NOTN"].ToString() + @"""" +
                 "," + @"""" + "cessNotificationSerialNumber" + @"""" + ":" + @"""" + dtt.Rows[i]["COMPENSATION_CESS_NOTN_SLNO"].ToString() + @"""" +
                 "," + @"""" + "cessRate" + @"""" + ":" + @"""" + dtt.Rows[i]["CESS_RATE"].ToString() + @"""" +
                 "," + @"""" + "cessAmount" + @"""" + ":" + @"""" + dtt.Rows[i]["CESS_AMOUNT"].ToString() + @"""" + "}";

                Ch_Data_C += Ch_Data_B;
                Ch_Data_A = string.Empty;
                Ch_Data_B = string.Empty;
            }
            Ch_Data = Ch_Data_C + "]";
        }
        else
        {
            //Ch_Data = OP;
            Ch_Data_A = OP + "," + @"""" + "itemDetailsRequest" + @"""" + ":[";
            Ch_Data = Ch_Data_A + "]";
        }
        return Ch_Data;
    }

    protected void btn_Json_Click(object sender, EventArgs e)
    {
        if (HDupdate_id.Value.ToString() != string.Empty)
        {
            Load_JSON();
            Alert_msg("Json Generated Successfully!..");
        }
        else
        {
            Alert_msg("Save Master Details after generate Json", "btnSave");
        }
    }
}