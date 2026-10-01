using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Configuration;
using System.Drawing.Printing;

public partial class Transaction_GATT_form : System.Web.UI.Page
{
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
   
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
   public string Working_Period;
   Date_Time dt = new Date_Time();
   AppSession aps = new AppSession();
   Gatt_CS GT = new Gatt_CS();
   ErrorLogs er = new ErrorLogs();
   DataSet dss = new DataSet();
   string Invoice_details, aa;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            currentuser = Session["currentuser"].ToString();
            currentbranch = Session["currentbranch"].ToString();
            currentcomp_name = Session["currentcomp_name"].ToString();
            comp_ConnectionStr = Session["currentcomp_db"].ToString();
            Working_Period = Session["WorkingPeriod"].ToString();
            LoginDate = Session["LoginDate"].ToString();
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

                if (Request.QueryString["jobno"] == "" || Request.QueryString["jobno"] == null)
                {
                    LoadJobNo();
                }
                else
                {
                    LoadJobNo();
                    ddlJobNo.SelectedValue = Request.QueryString["jobno"].ToString();
                    DropDownList1_SelectedIndexChanged(sender, e);
                }
                Save_Update_Btn();
            }
            Session["JobNo"] = ddlJobNo.SelectedItem.Text;
            txtDate.Text = dt.Today_Date();
            // hdnPlace.Value = txtPlace.Text;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void LoadJobNo()
    {
        try
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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
                 
    }



    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedItem.Text != "Select")
            {

                clear();
                DataSet ds = new DataSet();
                Gatt_CS GT = new Gatt_CS();
                GT.Jobno = ddlJobNo.SelectedValue.ToString();
                GT.Ename = "Select_GATT";
                GT.WORKING_PERIOD = SELECT_BRANCH;
                ds = GT.Exists_Gatt();

                if (ds.Tables[0].Rows.Count > 0)
                {

                    txtImporter.Text = ds.Tables[1].Rows[0]["Imp_Name"].ToString();
                    txtImporterAddress.Text = ds.Tables[1].Rows[0]["Imp_Address"].ToString();
                    txtImporterAddress1.Text = ds.Tables[1].Rows[0]["Imp_Address_2"].ToString();

                    txtSupName.Text = ds.Tables[1].Rows[0]["Supplier_Name"].ToString();
                    txtSupAddress.Text = ds.Tables[1].Rows[0]["Supplier_Address"].ToString();

                    txtSupAddress1.Text = ds.Tables[1].Rows[0]["Supplier_Address_2"].ToString();
                    txtAgentName.Text = ds.Tables[1].Rows[0]["Agent_Name"].ToString();
                    txtAgentAddress.Text = ds.Tables[1].Rows[0]["Agent_Address"].ToString();
                    txtDescription.Text = ds.Tables[1].Rows[0]["Goods_Desc"].ToString();
                    txtCountry.Text = ds.Tables[1].Rows[0]["Country_Org"].ToString();
                    txtPortShip.Text = ds.Tables[1].Rows[0]["Port_Of_Ship"].ToString();
                    txtAWBNo.Text = ds.Tables[1].Rows[0]["AWB_BL_Number_and_Date"].ToString();
                    txtIGMNo.Text = ds.Tables[1].Rows[0]["IGM_Number_and_Date"].ToString();
                    txtContact.Text = ds.Tables[1].Rows[0]["Conact_No_and_Date"].ToString();
                    txtTransaction.Text = ds.Tables[1].Rows[0]["Nature_Of_Tran"].ToString();
                    txtInvoiceNo.Text = ds.Tables[1].Rows[0]["Invoice_No_and_Date"].ToString();
                    txtInvoiceVal.Text = ds.Tables[1].Rows[0]["Invoice_Value"].ToString();
                    txtTerms.Text = ds.Tables[1].Rows[0]["Terms_Of_Payment"].ToString();
                    txtCurrency.Text = ds.Tables[1].Rows[0]["Currency_of_Payment"].ToString();
                    txtExchange.Text = ds.Tables[1].Rows[0]["Exchange_Rate"].ToString();
                    txtTermsDelivery.Text = ds.Tables[1].Rows[0]["Terms_of_Delivery"].ToString();

                    txtRelationship.Text = ds.Tables[1].Rows[0]["Difference_Buyer_Seller"].ToString();
                    txtDeclaredVal.Text = ds.Tables[1].Rows[0]["Base_Of_Decl_Value"].ToString();
                    txtCondition.Text = ds.Tables[1].Rows[0]["Condition_or_Restrictions"].ToString();
                    txtValuation.Text = ds.Tables[1].Rows[0]["Valuation_Method"].ToString();
                    txtCost.Text = ds.Tables[1].Rows[0]["Cost_and_Services"].ToString();
                    txtBrokerage.Text = ds.Tables[1].Rows[0]["Brokerage_and_Commissions"].ToString();

                    txtContainers.Text = ds.Tables[1].Rows[0]["Cost_of_Containers"].ToString();
                    txtPacking.Text = ds.Tables[1].Rows[0]["Packing_Cost"].ToString();
                    txtCostOfGoods.Text = ds.Tables[1].Rows[0]["Cost_of_goods_and_services"].ToString();
                    txtRoyalities.Text = ds.Tables[1].Rows[0]["Royalties_and_License"].ToString();
                    txtProceeds.Text = ds.Tables[1].Rows[0]["Value_of_proceeds"].ToString();
                    txtFreight.Text = ds.Tables[1].Rows[0]["Freight"].ToString();

                    txtInsurance.Text = ds.Tables[1].Rows[0]["Insurance"].ToString();
                    txtLoading.Text = ds.Tables[1].Rows[0]["L_U_H_charges"].ToString();
                    //txtLanding.Text = ds.Tables[1].Rows[0]["Landing_charges"].ToString();
                    txtLanding.Text = "";

                    txtPayments.Text = ds.Tables[1].Rows[0]["Other_payments"].ToString();
                    txtAssessable.Text = ds.Tables[1].Rows[0]["Assessable_value"].ToString();
                    txtPreviousImport.Text = ds.Tables[1].Rows[0]["Previous_Imports"].ToString();
                    BOENumber.Text = ds.Tables[1].Rows[0]["Bill_of_Entry_Number_and_Date"].ToString();

                    txtIgmNumber.Text = ds.Tables[1].Rows[0]["IGM_Number_and_Date_2"].ToString();
                    txtRelevent.Text = ds.Tables[1].Rows[0]["Any_other_relevant"].ToString();
                    txtPlace.Text = ds.Tables[1].Rows[0]["Place"].ToString();
                    txtDate.Text = ds.Tables[1].Rows[0]["Date"].ToString();
                    txtValuationRules.Text = ds.Tables[1].Rows[0]["Valuation_Method_Applied"].ToString();
                    txtAssessed.Text = ds.Tables[1].Rows[0]["Value_Assessed"].ToString();

                    btnupdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnRpt.Visible = true;
                    btn_PrePrint.Visible = true;
                    btn_ReGenerate.Visible = true;
                }
                else
                {
                    ddl_data();
                    btnSave.Visible = true;
                    btnupdate.Visible = false;
                    btnDelete.Visible = false;
                    btnRpt.Visible = false;
                    btn_PrePrint.Visible = false;
                    btn_ReGenerate.Visible = false;
                }
                //Save_Update_Btn();

            }
            else
            {

                btnRpt.Visible = false;
                btn_PrePrint.Visible = false;
                clear();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void Save_Update_Btn()
    {
        try
        {
            if (ddlJobNo.SelectedItem.Text != "Select")
            {
                btnRpt.Visible = true;
                btn_PrePrint.Visible = true;
                btn_ReGenerate.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
                btnRpt.Visible = false;
                btn_PrePrint.Visible = false;
                btnupdate.Visible = false;
                btnDelete.Visible = false;
                btn_ReGenerate.Visible = false;
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void ddl_data()
    {
        try
        {
            string jobno;
            jobno = ddlJobNo.SelectedValue.ToString();
            Label2.Text = jobno;
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();


            DataSet ds = new DataSet();
            CheckList CHKLIST = new CheckList();
            CHKLIST.JOBNo = jobno;
            CHKLIST.Ename = "GATT_CHECKLIST";
            CHKLIST.Workingperiod = SELECT_BRANCH;
            ds.Clear();
            ds = CHKLIST.RetrieveAll_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {

                txtImporter.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                //txtImporterAddress.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + "," + ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                //txtImporterAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + "," + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + "," + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

                txtImporterAddress.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + "," + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + "," + ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                txtImporterAddress1.Text =  ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + "," + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

                txtCountry.Text = ds.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString();
                txtPortShip.Text = ds.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                txtIGMNo.Text = ds.Tables[1].Rows[0]["IGM_NO"].ToString() + "  " + ds.Tables[1].Rows[0]["IGM_DATE"].ToString();
                txtAWBNo.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString() + " , " + ds.Tables[1].Rows[0]["IGM_HAWB_HBLNO"].ToString() + " - " + ds.Tables[1].Rows[0]["IGM_MAWB_MBLDATE"].ToString() + " , " + ds.Tables[1].Rows[0]["IGM_HAWB_HBLDATE"].ToString();
                //txtContact.Text = "NIL";
            }


            if (ds.Tables[2].Rows.Count > 0)
            {
                int Inv_count = ds.Tables[2].Rows.Count;
                Invoice_details = "";
                for (int i = 0; i <= Inv_count - 1; i++)
                {
                    Invoice_details = ds.Tables[2].Rows[i]["INVOICE_NO"].ToString() + "-" + ds.Tables[2].Rows[i]["INVOICE_DATE"].ToString() + ",";
                    aa += Invoice_details;
                }
                int count = aa.Length;

                if (count > 60)
                {
                    aa = aa.Substring(0, 60).TrimEnd(',');
                }

                txtInvoiceNo.Text = aa;

                //txtInvoiceNo.Text = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + "  " + ds.Tables[2].Rows[0]["INVOICE_DATE"].ToString();
                //txtInvoiceVal.Text = ds.Tables[2].Rows[0]["INVOICE_VALUE"].ToString();

                txtSupName.Text = ds.Tables[2].Rows[0]["SUPPLIER_NAME"].ToString();
                txtSupAddress.Text = ds.Tables[2].Rows[0]["SUPPLIER_ADDRESS"].ToString() + "," + ds.Tables[2].Rows[0]["SUPPLIER_ADDRESS1"].ToString();
                txtSupAddress1.Text = ds.Tables[2].Rows[0]["SUPPLIER_ADDRESS2"].ToString() + "," + ds.Tables[2].Rows[0]["SUPPLIER_COUNTRY_NAME"].ToString() + "," + ds.Tables[2].Rows[0]["SUPPLIER_COUNTRY_PINCODE"].ToString();

                string CHANAME = Session["CHA_NAME"].ToString();
                txtAgentName.Text = CHANAME;

                txtTerms.Text = ds.Tables[2].Rows[0]["TERMS"].ToString();
                txtCurrency.Text = ds.Tables[2].Rows[0]["INVOICE_CURRENCY"].ToString();
                txtExchange.Text = ds.Tables[2].Rows[0]["INVOICE_EXRATE"].ToString();
                txtTermsDelivery.Text = ds.Tables[2].Rows[0]["OTHER_TERMS_OF_PAYMENT"].ToString();


                txtValuation.Text = ds.Tables[2].Rows[0]["OTHER_VALUATION_METHOD"].ToString();
                txtValuationRules.Text = ds.Tables[2].Rows[0]["OTHER_VALUATION_METHOD"].ToString();

                txtLoading.Text = ds.Tables[2].Rows[0]["MIS_LOADING_CHARGES"].ToString();
                txtTransaction.Text = ds.Tables[2].Rows[0]["OTHER_NATURE_OF_TRANSACTION"].ToString();
                txtRelationship.Text = ds.Tables[2].Rows[0]["SVB_REF_NO"].ToString();

                // FOR VELJI.P
                if (Connection.COMPANYID() == "526")
                {
                    txtContact.Text = ds.Tables[2].Rows[0]["OTHER_CONTRACT_NO"].ToString() + "  " + ds.Tables[2].Rows[0]["OTHER_CONTRACT_DATE"].ToString();
                }


                if (ds.Tables[3].Rows.Count > 0)
                {
                    txtDescription.Text = ds.Tables[3].Rows[0]["ITEM_DESCRIPTION"].ToString();

                }

                if ((ds.Tables[4].Rows.Count > 0) && (ds.Tables[2].Rows.Count > 0))
                {

                    if ((ds.Tables[4].Rows[0]["MIS_FREIGHT_CHARGES"].ToString() == "") || (ds.Tables[4].Rows[0]["MIS_FREIGHT_CHARGES"].ToString() == "Null") || (ds.Tables[4].Rows[0]["MIS_FREIGHT_CHARGES"].ToString() == "0.00"))
                    {
                        txtFreight.Text = "";
                    }
                    else
                    {
                        txtFreight.Text = ds.Tables[4].Rows[0]["MIS_FREIGHT_CHARGES"].ToString() + " " + ds.Tables[2].Rows[0]["MIS_FREIGHT_CURRENCY"].ToString();
                    }

                }

                if ((ds.Tables[5].Rows.Count > 0) && (ds.Tables[2].Rows.Count > 0))
                {

                    if ((ds.Tables[5].Rows[0]["MIS_INSURANCE_CHARGES"].ToString() == "") || (ds.Tables[5].Rows[0]["MIS_INSURANCE_CHARGES"].ToString() == "Null") || (ds.Tables[5].Rows[0]["MIS_INSURANCE_CHARGES"].ToString() == "0.00"))
                    {
                        txtInsurance.Text = "";
                    }
                    else
                    {
                        txtInsurance.Text = ds.Tables[5].Rows[0]["MIS_INSURANCE_CHARGES"].ToString() + " " + ds.Tables[2].Rows[0]["MIS_INSURANCE_CURRENCY"].ToString();
                    }


                }
                if (ds.Tables[6].Rows.Count > 0)
                {
                    txtAssessable.Text = ds.Tables[6].Rows[0]["ASSESSABLE_VALUE"].ToString();

                    txtAssessed.Text = ds.Tables[6].Rows[0]["ASSESSABLE_VALUE"].ToString();
                }

                if (ds.Tables[7].Rows.Count > 0)
                {
                    //txtLanding.Text = ds.Tables[7].Rows[0][0].ToString();
                    txtLanding.Text = "";
                }

                if (ds.Tables[8].Rows.Count > 0)
                {
                    txtInvoiceVal.Text = ds.Tables[8].Rows[0]["INVOICE_VALUE"].ToString();
                }

                if (ds.Tables[9].Rows.Count > 0)
                {
                    //BOENumber.Text = ds.Tables[8].Rows[0]["BE_NO"].ToString() + " - " + ds.Tables[8].Rows[0]["BE_DATE"].ToString();
                }
            }
        }

        catch (SqlException)
        {
        }
    
    }


    protected void btn_print_Click(object sender, EventArgs e)
    {
        try
        {

            //Response.Redirect("GATT_form.aspx");
            //btn_print.Attributes.Add("onClick", "return PrintGridData()");
            //string prompt = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

            string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
       
                
    }

    public DataSet cc(string page)
    {
        DataSet ds = new DataSet();
        try
        {
          
            page.Reverse();

           

            //Response.Redirect("GATT_form.aspx");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        return ds;
    }
    
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        try
        {
            Gatt_Ins_Upd();
            btnRpt.Visible = true;
            btn_PrePrint.Visible = true;
            btn_ReGenerate.Visible = true;
            Alert_msg("Saved Successfully");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

  
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        try
        {
            Gatt_Ins_Upd();
            btnRpt.Visible = true;
            btn_PrePrint.Visible = true;
            btn_ReGenerate.Visible = true;
            Alert_msg("Updated Successfully");
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
            
            GT.Jobno = ddlJobNo.SelectedItem.Text;
            GT.WORKING_PERIOD = SELECT_BRANCH;
            GT.Ename = "GATT_Delete";
            dss = GT.Exists_Gatt();

            int i = GT.result;


            if (i > 0)
            {

                string prompt = "<script>$(document).ready(function(){{jAlert('GATT-FORM Deleted', 'GATT-FORM', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

            }


            else
            {
                Alert_msg("GATT FORM Not Deleted");

            }
        }


        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void Gatt_Ins_Upd()
    {
        try
        {

            GT.Jobno = ddlJobNo.SelectedItem.Text;
            GT.Imp_Name = txtImporter.Text;
            GT.Imp_Address = txtImporterAddress.Text;
            GT.Imp_Address_2 = txtImporterAddress1.Text;
            GT.Supplier_Name = txtSupName.Text;
            GT.Supplier_Address = txtSupAddress.Text;
            GT.Supplier_Address_2 = txtSupAddress1.Text;

            GT.Agent_Name = txtAgentName.Text;
            GT.Agent_Address = txtAgentAddress.Text;
            GT.Goods_Desc = txtDescription.Text;
            GT.Country_Org = txtCountry.Text;
            GT.Port_Of_Ship = txtPortShip.Text;
            GT.AWB_BL_Number_and_Date = txtAWBNo.Text;
            GT.IGM_Number_and_Date = txtIGMNo.Text;
            GT.Conact_No_and_Date = txtContact.Text;
            GT.Nature_Of_Tran = txtTransaction.Text;
            GT.Invoice_No_and_Date = txtInvoiceNo.Text;
            GT.Invoice_Value = txtInvoiceVal.Text;
            GT.Terms_Of_Payment = txtTerms.Text;
            GT.Currency_of_Payment = txtCurrency.Text;
            GT.Exchange_Rate = txtExchange.Text;
            GT.Terms_of_Delivery = txtTermsDelivery.Text;
            GT.Difference_Buyer_Seller = txtRelationship.Text;
            GT.Base_Of_Decl_Value = txtDeclaredVal.Text;
            GT.Condition_or_Restrictions = txtCondition.Text;
            GT.Valuation_Method = txtValuation.Text;
            GT.Cost_and_Services = txtCost.Text;
            GT.Brokerage_and_Commissions = txtBrokerage.Text;
            GT.Cost_of_Containers = txtContainers.Text;
            GT.Packing_Cost = txtPacking.Text;
            GT.Cost_of_goods_and_services = txtCostOfGoods.Text;
            GT.Royalties_and_License = txtRoyalities.Text;
            GT.Value_of_proceeds = txtProceeds.Text;
            GT.Freight = txtFreight.Text;
            GT.Insurance = txtInsurance.Text;
            GT.L_U_H_charges = txtLoading.Text;
            GT.Landing_charges = txtLanding.Text;
            GT.Other_payments = txtPayments.Text;
            GT.Assessable_value = txtAssessable.Text;
            GT.Previous_Imports = txtPreviousImport.Text;
            GT.Bill_of_Entry_Number_and_Date = BOENumber.Text;
            GT.IGM_Number_and_Date_2 = txtIgmNumber.Text;
            GT.Any_other_relevant = txtRelevent.Text;
            GT.Place = txtPlace.Text;
            GT.Date = txtDate.Text;
            GT.Bill_of_Entry_Date = string.Empty;
            GT.Valuation_Method_Applied = txtValuationRules.Text;
            GT.Declared_value = string.Empty;
            GT.Reference_No_and_Date = string.Empty;
            GT.Value_Assessed = txtAssessed.Text;

            GT.USER_ID = currentuser;
            GT.BRANCH_COMMON = SELECT_BRANCH;
            GT.BRANCH_CODE = currentbranch;
            GT.YEAR = string.Empty;
            GT.WORKING_PERIOD = Working_Period;
            GT.Ename = "S";

            GT.IGM_Details_insertupdate();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void clear()
    {
        try
        {
            txtImporter.Text = string.Empty;
            txtImporterAddress.Text = string.Empty;
            txtImporterAddress1.Text = string.Empty;
            txtSupName.Text = string.Empty;
            txtSupAddress.Text = string.Empty;
            txtSupAddress1.Text = string.Empty;
            txtAgentName.Text = string.Empty;
            txtAgentAddress.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPortShip.Text = string.Empty;
            txtAWBNo.Text = string.Empty;
            txtIGMNo.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtTransaction.Text = string.Empty;
            txtInvoiceNo.Text = string.Empty;
            txtInvoiceVal.Text = string.Empty;
            txtTerms.Text = string.Empty;
            txtCurrency.Text = string.Empty;
            txtExchange.Text = string.Empty;
            txtTermsDelivery.Text = string.Empty;

            txtRelationship.Text = string.Empty;
            txtDeclaredVal.Text = string.Empty;
            txtCondition.Text = string.Empty;
            txtValuation.Text = string.Empty;
            txtCost.Text = string.Empty;
            txtBrokerage.Text = string.Empty;

            txtContainers.Text = string.Empty;
            txtPacking.Text = string.Empty;
            txtCostOfGoods.Text = string.Empty;
            txtRoyalities.Text = string.Empty;
            txtProceeds.Text = string.Empty;
            txtFreight.Text = string.Empty;

            txtInsurance.Text = string.Empty;
            txtLoading.Text = string.Empty;
            txtLanding.Text = string.Empty;

            txtPayments.Text = string.Empty;
            txtAssessable.Text = string.Empty;
            txtPreviousImport.Text = string.Empty;
            BOENumber.Text = string.Empty;

            txtIgmNumber.Text = string.Empty;
            txtRelevent.Text = string.Empty;
            txtPlace.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtValuationRules.Text = string.Empty;
            txtAssessed.Text = string.Empty;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GATT-FORM', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btn_ReGenerate_Click(object sender, EventArgs e)
    {
        try
        {
            ddl_data();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
}