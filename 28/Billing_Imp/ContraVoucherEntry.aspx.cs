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

using System.Configuration;




public partial class PaymentEntry : ThemeClass
{

   


    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public int i;
    public string COMPANY_LICENSE; 
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            COMPANY_LICENSE = Connection.Company_License().ToLower();


            if (!Page.IsPostBack)
            {
                             

                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

                btnrpt.Visible = false;
                T.Visible = false;

                WK.Visible = true;
                LoadFinancialYear();
                ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();


                if (Request.QueryString["Page"] == null)
                {
                    GetAutono_Payment();
                    
                    

                    txtVoucherDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    FirstRow();
                    
                    
                }


                else
                {
                    if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                    {
                        Update_Item_Load();
                        btnDelete.Visible = true;
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                    }
                }


            }
        } 
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void GetAutono_Payment()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjUBO.Flag = "Generate-AutoNo";
            ObjUBO.BILL_TYPE = "Payment-Payment";
            ds = BI.Load_DDL(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtVoucherNo.Text = ds.Tables[0].Rows[0][0].ToString();

            }
            ds.Dispose();
            GC.Collect();
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

      private void LoadPendingJob()
        {
          try
          {
            DataSet ds = new DataSet();   
          
          }
          catch (Exception ex)
          {
              Connection.Error_Msg(ex.Message);
          }
        }

      protected void gvPaymentdetails_RowDataBound(object sender, GridViewRowEventArgs e)
      {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {

          }
      }



      protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
      {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              ////// DropDown Method start
              //DataTable dt = (DataTable)ViewState["PendingBillList"];              
              //if (dt.Rows.Count > 0)
              //{
              //    DropDownList ddlBill_inv_No = (e.Row.FindControl("ddlBill_inv_No") as DropDownList);
              //    ddlBill_inv_No.DataSource = dt;     //GetData("SELECT ")
              //    ddlBill_inv_No.DataTextField = "TRANSACTION_TYPE";
              //    ddlBill_inv_No.DataValueField = "TRANSACTION_TYPE";
              //    ddlBill_inv_No.DataBind();

              //    //ddlBill_inv_No.Items.Insert(0, new ListItem("Please select"));//Add Default Item in the DropDownList
                  
              //    string Bill_inv_No = (e.Row.FindControl("lblBill_inv_No") as Label).Text;
              //    ddlBill_inv_No.Items.FindByValue(Bill_inv_No).Selected = true;
              //}
              ////// DropDown Method End
          }
      }

     


    private void Update_Item_Load()
    {
        try
        {

            DataSet dss = new DataSet();
            ObjUBO.MODE = "Select ContraVocherEntry";
            ObjUBO.Flag = "Select-PaymentSingle";
            ObjUBO.FILE_REF_NO = Request.QueryString["Page"].ToString();
            HDupdate_id.Value = Request.QueryString["Page"].ToString();

            dss = BI.ContraVoucherEntry_Search(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = dss.Tables[0].Rows[0]["CONTRAVOUCHER_ID"].ToString();
                txtVoucherNo.Text = dss.Tables[0].Rows[0]["VOUCHER_NO"].ToString();
                //ddlCustomer.Text = dss.Tables[0].Rows[0]["Customer_Name"].ToString();
                //ddlModeofPay.SelectedValue = dss.Tables[0].Rows[0]["PaymentMode"].ToString();
                txtCommNarration.Text = dss.Tables[0].Rows[0]["NARRATION"].ToString();
                txtVoucherDate.Text = dss.Tables[0].Rows[0]["VOUCHER_DATE"].ToString();
              

               

                    gv_Chg_Details.DataSource = dss.Tables[0];
                    gv_Chg_Details.DataBind();
                    //  setting selected values into grid vew
                    int rowIndex = 0;
                    for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                    {

                        decimal totamt = 0;

                        TextBox txtCR_DR = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtCR_DR");
                        TextBox txtTransactionType = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtTransactionType");

                        TextBox txtBranchName = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtBranchName");

                        TextBox txtBankName = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtBankName");
                        TextBox txtPaymentRefno = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtPaymentRefno");
                        TextBox txtBillAmt = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtBillAmount");
                        TextBox txtPaymentMethod = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtPaymentMethod");

                        TextBox txtExRate1 = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtExRate");

                        TextBox txtCurrency1 = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtCurrency");
                        TextBox txtCredit1 = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtCredit");

                       
                        TextBox txtDebit1 = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtDebit");
                        CheckBox chksel = (CheckBox)gv_Chg_Details.Rows[rowIndex].FindControl("chk_inv");
                        chksel.Checked = true;
                   

                        string AA;
                        AA=dss.Tables[0].Rows[i]["BILL_AMOUNT"].ToString();

                        if (AA != "")
                        {
                            totamt = Convert.ToDecimal(AA);
                        }

                        else
                        {
                            totamt = 0;
                        }


                        rowIndex++;
                    }
                 
            }
            ViewState["CurrentTable"] = dss.Tables[1]; 
            ViewState["NewCurrentTable"] = dss.Tables[0];
         

            dss.Dispose();
            GC.Collect();
        }

        
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    protected void gv_Chg_Details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName.Equals("add"))
            {
                AddNewRow();
                
            }

            if (e.CommandName == "DeleteRow")
            {



                if (gv_Chg_Details.Rows.Count > 1)
                {
                   
                     DataTable dt = (DataTable)ViewState["NewCurrentTable"];
                    DataRow drCurrentRow = null;
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    if (dt.Rows.Count > 1)
                    {
                        if (dt.Columns.Contains("CONTRAVOUCHER_SUBID"))
                        {
                            string apay = dt.Rows[rowIndex]["CONTRAVOUCHER_SUBID"].ToString();
                            if (apay == "" || apay == "0")
                            {
                                dt.Rows.Remove(dt.Rows[rowIndex]);
                                drCurrentRow = dt.NewRow();
                                ViewState["NewCurrentTable"] = dt;
                                gv_Chg_Details.DataSource = dt;
                                gv_Chg_Details.DataBind();
                            }
                            else
                            {
                                i = PAYMENT_Delete("DELETE_SUB", apay);

                                if (i == 1)
                                {

                                    //btnNew_Click1(sender, e);
                                    Alert_msg("Deleted");
                                    btnrpt.Visible = false;
                                }
                                else
                                {
                                    Alert_msg("Not Deleted");
                                }
                            }

                        }
                        else
                        {
                            dt.Rows.Remove(dt.Rows[rowIndex]);
                            drCurrentRow = dt.NewRow();
                            ViewState["NewCurrentTable"] = dt;
                            gv_Chg_Details.DataSource = dt;
                            gv_Chg_Details.DataBind();
                        }

                    }

                    //Set Previous Data on Postbacks  
                    SetPreviousData();    
                
                   
                }
                else if (gv_Chg_Details.Rows.Count == 1)
                {
                    //SetInitialRow();
                }

            }
        }



        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void ResetRowID(DataTable dt)
    {
        int rowNumber = 1;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                row[0] = rowNumber;
                rowNumber++;
            }
        }
    }   
    private void FirstRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = dt.NewRow();

        dt.Columns.Add(new DataColumn("DR_CR", typeof(string)));
        dt.Columns.Add(new DataColumn("TRANSACTION_TYPE", typeof(string)));
        dt.Columns.Add(new DataColumn("BANK_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("BRANCH_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("PAYMENT_METHOD", typeof(string)));

        
        dt.Columns.Add(new DataColumn("PAYMENT_REF_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("CURRENCY", typeof(string)));
        dt.Columns.Add(new DataColumn("EX_RATE", typeof(string)));  
        dt.Columns.Add(new DataColumn("CREDIT", typeof(string)));  

      
        dt.Columns.Add(new DataColumn("DEBIT", typeof(string)));
        dt.Columns.Add(new DataColumn("BILL_AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("CONTRAVOUCHER_SUBID", typeof(string)));
        dt.Columns.Add(new DataColumn("CONTRAVOUCHER_ID", typeof(string)));
       
        
        dt.Rows.Add(dr);        


        
        ViewState["NewCurrentTable"] = dt;
        

        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();  


    }
    private void AddNewRow()
    {


        int rowIndex = 0;

        if (ViewState["NewCurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["NewCurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                int Slno = 1;
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    
                    TextBox txtCR_DR = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("txtCR_DR");
                    TextBox txtTransactionType = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtTransactionType");
                    TextBox txtBankName = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtBankName");
                    TextBox txtBranchName = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtBranchName");
                    TextBox txtPaymentRefno = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txtPaymentRefno");


                    TextBox txtBillAmt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txtBillAmount");
                    TextBox txtPaymentMethod = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtPaymentMethod");
                    TextBox txtCurrency = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txtCurrency");
                    TextBox txtExRate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtExRate");
                    TextBox txtCredit = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtCredit");

                    TextBox txtDebit = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtDebit");


                    drCurrentRow = dtCurrentTable.NewRow();


                    dtCurrentTable.Rows[i - 1]["DR_CR"] = txtCR_DR.Text;
                    dtCurrentTable.Rows[i - 1]["TRANSACTION_TYPE"] = txtTransactionType.Text;
                    dtCurrentTable.Rows[i - 1]["BANK_NAME"] = txtBankName.Text;
                    dtCurrentTable.Rows[i - 1]["BRANCH_NAME"] = txtBranchName.Text;
                    dtCurrentTable.Rows[i - 1]["PAYMENT_METHOD"] = txtPaymentMethod.Text;
                    //dtCurrentTable.Rows[i - 1][4] = txtPaymentRefno.Text;

                    dtCurrentTable.Rows[i - 1]["BILL_AMOUNT"] = (txtBillAmt.Text == string.Empty) ? "0" : txtBillAmt.Text;
                    dtCurrentTable.Rows[i - 1]["PAYMENT_REF_NO"] = txtPaymentRefno.Text;
                    dtCurrentTable.Rows[i - 1]["CURRENCY"] = txtCurrency.Text;
                    dtCurrentTable.Rows[i - 1]["EX_RATE"] = (txtExRate.Text == string.Empty) ? "0" : txtExRate.Text;
                    dtCurrentTable.Rows[i - 1]["CREDIT"] = (txtCredit.Text == string.Empty) ? "0" : txtCredit.Text; 

                   
                    
                  
                    dtCurrentTable.Rows[i - 1]["DEBIT"] = (txtDebit.Text == string.Empty) ? "0" : txtDebit.Text; 
                 

                    rowIndex++;
                    Slno++;
                    //txtgSLNo.Focus();
                }


                int index = gv_Chg_Details.Rows.Count - 1;

            

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["NewCurrentTable"] = dtCurrentTable;

                gv_Chg_Details.DataSource = dtCurrentTable;
                gv_Chg_Details.DataBind();


                int index1 = gv_Chg_Details.Rows.Count - 1;
               
            }
        }
        SetPreviousData();
    }

    private void SetPreviousData()
    {
        int rowIndex = 0;

        if (ViewState["NewCurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["NewCurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {


                 
                    TextBox txtCR_DR = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[1].FindControl("txtCR_DR");
                    TextBox txtTransactionType = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtTransactionType");
                    TextBox txtBankName = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtBankName");
                    TextBox txtBranchName = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtBranchName");
                    TextBox txtPaymentRefno = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txtPaymentRefno");


                    TextBox txtBillAmt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txtBillAmt");
                    TextBox txtPaymentMethod = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtPaymentMethod");
                    TextBox txtCurrency = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txtCurrency");
                    TextBox txtExRate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtExRate");
                    TextBox txtCredit = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtCredit");

                    TextBox txtDebit = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtDebit");
                  
                    //////////////////////////////////////////////////////////////////////
                 
                    txtCR_DR.Text = dt.Rows[i]["DR_CR"].ToString();
                    txtTransactionType.Text = dt.Rows[i]["TRANSACTION_TYPE"].ToString();
                    txtBankName.Text = dt.Rows[i]["BANK_NAME"].ToString();
                    txtBranchName.Text = dt.Rows[i]["BRANCH_NAME"].ToString();
                    txtPaymentMethod.Text = dt.Rows[i]["PAYMENT_METHOD"].ToString();

                    txtBillAmt.Text = dt.Rows[i]["BILL_AMOUNT"].ToString();
                    txtPaymentRefno.Text = dt.Rows[i]["PAYMENT_REF_NO"].ToString();
                    txtCurrency.Text = dt.Rows[i]["CURRENCY"].ToString();
                    txtExRate.Text = dt.Rows[i]["EX_RATE"].ToString();  //
                    txtCredit.Text = dt.Rows[i]["CREDIT"].ToString();//

                    
                   
                    txtDebit.Text = dt.Rows[i]["DEBIT"].ToString();
                   

                    rowIndex++;
                }
            }
        }
    }
     
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Height = 20;
        }


        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";

    }
    

    public void Alert_msg(string msg)
    {

        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ContraVocher Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {

        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'ContraVocher Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
        if (txtVoucherDate.Text != string.Empty)
        {

         

                if (gv_Chg_Details.Rows.Count > 0)
                {
                    PAYMENT_Ins_Del_Upd("S", "0");
                }
                else
                {
                    Alert_msg("No Records found in ContraVocher grid");
                }



            if (i == 1)
            {

                Alert_msg("Saved Successfully");
                //btnNew_Click1(sender, e);
                Update_Item_Load();
            }
            else if (i == -1 || i == -2)
            {
                Alert_msg("Not Saved");

            }
            else if (i == -100)
            {
                Alert_msg("This Voucher No Alredy Exists");
                txtVoucherNo.Focus();

            }
            else
            {
                Alert_msg("Not Saved");
                //btnNew_Click1(sender, e);
            }

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
            if (gv_Chg_Details.Rows.Count > 0)
            {
                i = PAYMENT_Ins_Del_Upd("U", HDupdate_id.Value);
                if (i == 2)
                {
                    Alert_msg("Updated Successfully");
                    //btnNew_Click1(sender, e);
                    Update_Item_Load();
                }
                else
                {
                    Alert_msg("Not Updated");
                }
               
            }
            else
            {
                Alert_msg("No Records found in ContraVocher grid");
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
            
            i = PAYMENT_Delete("D", HDupdate_id.Value);

            if (i == 3)
            {

                btnNew_Click1(sender, e);
                Alert_msg("Deleted");
                btnrpt.Visible = false;
                Update_Item_Load();
            }
            else
            {
                Alert_msg("Not Deleted");
            }
           // btnNew_Click1(sender, e);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }



    public int PAYMENT_Ins_Del_Upd(string I_Name, string CONTRAVOUCHER_ID)
    {
        
        DataTable dt;
        string totReceivedAmt = "0";
        
          

       
        ConvertGrid_Datatable(gv_Chg_Details);
       
        dt = (DataTable)ViewState["NewCurrentTable"];// new code
        if (dt.Rows.Count > 0)
        {

            ObjUBO.CONTRAVOUCHER_ID = CONTRAVOUCHER_ID;
                    ObjUBO.Flag = I_Name;
              

                ObjUBO.VOUCHER_NO = txtVoucherNo.Text;
                ObjUBO.BILL_INV_DATE = txtVoucherDate.Text;  // Payment voucher Date
                ObjUBO.VOUCHER_TYPE = txtVoucherType.Text;  
               
              
                ObjUBO.NARRATION = txtCommNarration.Text;
               
                BI.ContraVoucherEntryIDU(ObjUBO, dt);
                i = BI.result;
                return i;
          
        }
        else
        {
            i = -1;
            return i;
        }
        
    }

    public int PAYMENT_Delete(string I_Name, string PaymentID)
    {
            i = PAYMENT_Ins_Del_Upd(I_Name, PaymentID);
            return i;
      
    }

     
   

 


    protected void gv_Chg_Details_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (gv_Chg_Details.Rows.Count > 1)
            {
                ConvertGrid_Datatable(gv_Chg_Details);
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                int rowIndex = Convert.ToInt32(e.RowIndex);

                dt.Rows.Remove(dt.Rows[rowIndex]);
                ViewState["CurrentTable"] = dt;

                gv_Chg_Details.DataSource = dt;
                gv_Chg_Details.DataBind();

            }
            else if (gv_Chg_Details.Rows.Count == 1)
            {
                
            }
        }

        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    private void ConvertGrid_Datatable(GridView gg )
    {
        try
        {
        
        int cnt = 0;
        DataTable dt;
        DataRow dr;
        int R = 1;
       
        dt = (DataTable)ViewState["NewCurrentTable"];// old code
            
        if (dt.Rows.Count > 0)
        {
            dt.Rows.Clear();
        }
        
        foreach (GridViewRow row in gg.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chk_inv");
            if (chk.Checked == true)
            {
                TextBox txtExRate1 = (TextBox)row.FindControl("txtExRate");
                TextBox txtCredit1 = (TextBox)row.FindControl("txtCredit");
                TextBox txtDebit1 = (TextBox)row.FindControl("txtDebit");
                TextBox txtCurrency1 = (TextBox)row.FindControl("txtCurrency");

                //new code added start
                TextBox txtTransactionType = (TextBox)row.FindControl("txtTransactionType");
                TextBox txtBankName = (TextBox)row.FindControl("txtBankName");
                TextBox txtBranchName = (TextBox)row.FindControl("txtBranchName");
                TextBox txtPaymentRefno = (TextBox)row.FindControl("txtPaymentRefno");
                TextBox txtCR_DR = (TextBox)row.FindControl("txtCR_DR");
                TextBox txtPaymentMethod = (TextBox)row.FindControl("txtPaymentMethod");
                TextBox txtBillAmount = (TextBox)row.FindControl("txtBillAmount");
                //new code added End


                cnt = 1;
               
                if (txtBillAmount.Text.Trim() == "" || txtBillAmount.Text.Trim() == string.Empty)
                {
                    txtBillAmount.Text = "0";
                }
               
                dr = dt.NewRow();
                
                dr[0] = R;
                dr["TRANSACTION_TYPE"] = txtTransactionType.Text;                

                dr["BRANCH_NAME"] = txtBranchName.Text.Trim(); 

                dr["PAYMENT_METHOD"] = txtPaymentMethod.Text.Trim();
                dr["PAYMENT_REF_NO"] = txtPaymentRefno.Text;
                dr["CREDIT"] = (txtCredit1.Text == "") ? "0" : txtCredit1.Text;  
                dr["BILL_AMOUNT"] = (txtBillAmount.Text == "") ? "0" : txtBillAmount.Text;   
                dr["BANK_NAME"] = txtBankName.Text;
                
                dr["CURRENCY"] = txtCurrency1.Text.Trim(); 
                dr["EX_RATE"] = (txtExRate1.Text == "") ? "0" : txtExRate1.Text;   
                dr["DR_CR"] = txtCR_DR.Text.Trim(); 


                dr["RowNumber"] = 1;
                dr["CONTRAVOUCHER_SUBID"] = 1;
                dr["CONTRAVOUCHER_ID"] = 1;
               
              
                dr["DEBIT"] = (txtDebit1.Text == "") ? "0" : txtDebit1.Text;  
               
               
                dt.Rows.Add(dr);
                R = R + 1;
                // new code end
                

            }
            DataView dv = new DataView(dt);

            dt = dv.ToTable("selected", false, "RowNumber", "CONTRAVOUCHER_SUBID", "CONTRAVOUCHER_ID", "DR_CR", "TRANSACTION_TYPE", "BANK_NAME", "BRANCH_NAME", "PAYMENT_METHOD", "PAYMENT_REF_NO", "CURRENCY", "EX_RATE", "DEBIT", "CREDIT", "BILL_AMOUNT");
            
        }

        if (cnt == 1)
        {
            
            ViewState["NewCurrentTable"] = dt; //New code
        }
        else
        {
            Alert_msg("Select atleast one Transaction");          
           
        }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
         
    }


    protected void btnNew_Click1(object sender, EventArgs e)
    {
        try
        {
           
            Transaction trans = new Transaction();
            trans.ResetFields(Page.Controls);
            btnUpdate.CssClass = "updates";


            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;

            DataTable dt = new DataTable();
            gv_Chg_Details.DataSource = dt;
            gv_Chg_Details.DataBind();

            gvPaymentdetails.DataSource = dt;
            gvPaymentdetails.DataBind();
           


            HDupdate_id.Value = string.Empty;


            btnrpt.Visible = false;

            FirstRow();


           
            WK.Visible = true;
            txtVoucherDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
           
            GetAutono_Payment();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    
   
    protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    } 
    
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        DataTable dt = new DataTable();
        gv_Chg_Details.DataSource = dt;
        gv_Chg_Details.DataBind();

        dt.Dispose();
        GC.Collect();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void LoadFinancialYear()
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;

        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);
        try
        {
            con.Open();
            ddlWorkingPeriod.Items.Clear();
            cmd = new SqlCommand("select * from FINANCIAL_YEAR order by WORKING_PERIOD desc", con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ddlWorkingPeriod.Items.Add(dr["WORKING_PERIOD"].ToString());
            }
            dr.Close();
            con.Close();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        finally
        {
            con.Close();
        }
    }

    protected void ddlbranch_No_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

  
    private DataSet Database_Con_string()
    {
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
        if (Session["COMPANY_DETAILS_DS"] != null)
        {
            ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            DataTable ds3 = new DataTable();
            ds3 = ds.Tables[2];
            DataView view1 = ds3.DefaultView;
            string a = ddlWorkingPeriod.SelectedValue.ToString();
            view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            DataTable table1 = view1.ToTable();
            dss = BI.Load_DDL(ObjUBO, table1.Rows[0]["SERVER_NAME"].ToString());

        }
        return dss;
    }

    [System.Web.Services.WebMethod]
    public static IList<string> LoadPendingJob_webmethod(string mail, string TempRd_Job_Type, string Tempddlbranch_No, string TempddlCustomer)    
    {
        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt =new DataTable();
        IList<string> result = new List<string>();
        int i=0;
        string finder=mail;
        string ReturnStr;
        try
        {
           
            GST_Imp_Invoice BI = new GST_Imp_Invoice();
            Billing_UserBO ObjUBO = new Billing_UserBO();

            ObjUBO.Flag = "Select-ImpExp-VendorPendingBills";
            ObjUBO.BRANCH_CODE = Tempddlbranch_No;
            ObjUBO.Ref_ID = TempddlCustomer;

            ds = BI.Load_DDL_PAYMENTENTRY(ObjUBO);
            dt1 = ds.Tables[0];
            //dt= dt1.Select("TRANSACTION_TYPE");
            DataView dv = new DataView(dt1);
            //dt = dv.ToTable("selected", false, "TRANSACTION_TYPE");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ReturnStr=ds.Tables[0].Rows[i]["TRANSACTION_TYPE"].ToString();
                if (ReturnStr.Contains(finder))
                {
                    result.Add(ds.Tables[0].Rows[i]["TRANSACTION_TYPE"].ToString());
                }                
                i++;
            }
           
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);

        }
        return result;
    }

    [System.Web.Services.WebMethod]
    public static string Bill_Details_Pickup_webmethod(string mail, string TempRd_Job_Type, string Tempddlbranch_No, string TempddlCustomer)
    {
        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt = new DataTable();
        IList<string> result = new List<string>();
        int i = 0;
        string BillInvNo = mail;
        string ReturnStr = "", ReturnStrMore="";
        try
        {

            GST_Imp_Invoice BI = new GST_Imp_Invoice();
            Billing_UserBO ObjUBO = new Billing_UserBO();

            ObjUBO.Flag = "Select-ImpExp-VendorPendingBills";
            ObjUBO.BRANCH_CODE = Tempddlbranch_No;
            ObjUBO.Ref_ID = TempddlCustomer;

            ds = BI.Load_DDL_PAYMENTENTRY(ObjUBO);
            dt1 = ds.Tables[0];
            //dt= dt1.Select("TRANSACTION_TYPE");
            DataView dv = new DataView(dt1);
            //dt = dv.ToTable("selected", false, "TRANSACTION_TYPE");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ReturnStr = ds.Tables[0].Rows[i]["TRANSACTION_TYPE"].ToString();
                //if (ReturnStr.Contains(finder))
                if (ReturnStr==BillInvNo)
                {
                    //result.Add(ds.Tables[0].Rows[i]["TRANSACTION_TYPE"].ToString());
                    ReturnStrMore = ds.Tables[0].Rows[i]["TRANSACTION_TYPE"].ToString() + "~~" + ds.Tables[0].Rows[i]["BANK_NAME"].ToString() + "~~" + ds.Tables[0].Rows[i]["BRANCH_NAME"].ToString() + "~~" + ds.Tables[0].Rows[i]["IMP_EXP"].ToString() + "~~" + ds.Tables[0].Rows[i]["BILL_AMOUNT"].ToString() + "~~" + ds.Tables[0].Rows[i]["PAYMENT_REF_NO"].ToString() + "~~" + ds.Tables[0].Rows[i]["CURRENCY"].ToString();
                }
                i++;
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);

        }
        //return result;
        return ReturnStrMore;
    }

    

    protected void gv_Chg_Details_RowDeleting(object sender, CommandEventArgs e)
    {

        //SetRowData();  //must
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;
                gv_Chg_Details.DataSource = dt;
                gv_Chg_Details.DataBind();
               
                for (int i = 0; i <= gv_Chg_Details.Rows.Count - 1; i++)
                {
                    gv_Chg_Details.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                }
                //SetPreviousData();
            }
        }
        
        
        //SetGridRunningNo(); //must
    }

   
}