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

    /*
     
  Tables Used
      --> Tbl_PaymentMain , Tbl_PaymentSub. [Tbl_PaymentMain - Header info  , Tbl_PaymentSub -line items ]
  Procedures Used
     -->  ACC_PAYMENT_SP , AccExp_Pay_PAYMENT_Select_SP , Load_ddl_SP  [ACC_PAYMENT_SP - For insert, delete & update the expenses info. AccExp_Pay_PAYMENT_Select_SP - All selection , Load_ddl_SP -load the DDL value ]
     
  */


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
               ////load_Imp_name();                

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
                    
                        //WK.Visible = true;
                        //LoadFinancialYear();
                        //ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();
                  

                     ////load_Imp_name();

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
            //if (Rd_Job_Type.SelectedIndex == 0)
            //    ObjUBO.Flag = "Select-Imp-CustomerPendingBills";
            //else if (Rd_Job_Type.SelectedIndex == 1)
            //    ObjUBO.Flag = "Select-Exp-CustomerPendingBills";
            //else if (Rd_Job_Type.SelectedIndex == 2)
            //    ObjUBO.Flag = "Select-ImpExp-CustomerPendingBills";
            //ObjUBO.Flag = "Select-ImpExp-VendorPendingBills";
            //ObjUBO.BRANCH_CODE = ddlbranch_No.SelectedValue.ToString();
            //ObjUBO.Ref_ID = ddlCustomer.SelectedValue.ToString();

            //if (Connection.Billing_Working_Period() == "Y" && HDupdate_id.Value == "" )
            //{

            //    ds = Database_Con_string();
            //}
            //else
            //{
               // ds = BI.Load_DDL_PAYMENTENTRY(ObjUBO);
            //}



            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //    ViewState["PendingBillList"] = ds.Tables[0];



            //    if (RdBillsLoad.SelectedIndex != 0) //Means Auto Selection  // if (RdPayFor.SelectedIndex == 0)
            //    {
            //        gv_Chg_Details.DataSource = ds.Tables[0];
            //        gv_Chg_Details.DataBind();
            //    }
            //    else
            //    {
                    
            //        FirstRow();
            //    }

            //}
            //else
            //{
            //    Alert_msg("No Pending Bills, Choose Advance Payment Mode");
            //    //Grid Row add one by one
            //}
          
            //ViewState["CurrentTable"] = ds.Tables[1];
            
            ////AddNewRow();
         
            //if (ds.Tables[2].Rows.Count > 0)
            //{
            //    gvPaymentdetails.DataSource = ds.Tables[2];
            //    gvPaymentdetails.DataBind();

            //    ViewState["PaymentHistory"] = ds.Tables[2];

            //    txtTotBillAmt.Text = ds.Tables[2].Compute("Sum(ReceivedAmt)", "").ToString();  
            //    txtTotTDSAmt.Text = ds.Tables[2].Compute("Sum(TDSAmt)", "").ToString();
            //    txtFinalReceivedAmt.Text = ds.Tables[2].Compute("Sum(TotalReceived)", "").ToString();
            //    txtTotWriteOff.Text = ds.Tables[2].Compute("Sum(WriteOffAmt)", "").ToString(); 
            //}

            //ds.Dispose();
            //GC.Collect();
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
      //protected void btnview_Click(object sender, EventArgs e)
      //{
      //    Button btnview = sender as Button;
      //    GridViewRow gvrow = (GridViewRow)btnview.NamingContainer;

      //    View_Grid(gvrow.Cells[5].Text);
      //}

      private void View_Grid(string name)
      {

          Auto_Search Auto = new Auto_Search();

          Auto.Name_Search = name;
          Auto.Flag = "IMP_EXP_FILEREFNO";
          Auto.Branch = Connection.Current_Branch();
          Auto.IMP_EXP = "Both";

          Load_Grid(Auto.Import_Export_Genral_Search());
      }
      private void Load_Grid(DataSet dss)
      {
          try
          {
              DataTable dt = new DataTable();
              if (dss.Tables[0].Rows.Count > 0)
              {
                  gvdetails.DataSource = dss.Tables[0];
                  gvdetails.DataBind();
                  //Add_Pageno(Imp.result);
                  MP_JOB.Show();
              }
              else
              {
                  MP_JOB.Hide();

                  gvdetails.DataSource = dt;
                  gvdetails.DataBind();
              }
          }
          catch (Exception ex)
          {
              Connection.Error_Msg(ex.Message);
          }
      }
      protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
      {
          if (e.Row.RowType == DataControlRowType.Header)
              e.Row.CssClass = "header";
          if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
              e.Row.CssClass = "normal";
          if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
              e.Row.CssClass = "alternate";
      }
      protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
      {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              string branch = this.gvdetails.DataKeys[e.Row.RowIndex]["BRANCHCODE"].ToString();
              string[] s1 = branch.Split(new string[] { "," }, StringSplitOptions.None);
              e.Row.Cells[4].Text = s1[1].ToString();
              string WORKINGPERIOD = this.gvdetails.DataKeys[e.Row.RowIndex]["WORKINGPERIOD"].ToString();
              string[] s2 = WORKINGPERIOD.Split(new string[] { "-" }, StringSplitOptions.None);
              e.Row.Cells[5].Text = s2[2].ToString()+"-"+s2[5].ToString();
           
          }
      }
      protected void gv_Chg_Details_RowDataBound(object sender, GridViewRowEventArgs e)
      {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              string txtCR_DR = (e.Row.FindControl("txtCR_DR") as TextBox).Text;
              string txtCurrency = (e.Row.FindControl("txtCurrency") as TextBox).Text;
                
                  if (txtCR_DR == "CR")
                  {
                      (e.Row.FindControl("txtCredit") as TextBox).Enabled = true;
                      (e.Row.FindControl("txtDebit") as TextBox).Enabled = false;
                      (e.Row.FindControl("txtDebit") as TextBox).Text = string.Empty;
                  }
                  else if (txtCR_DR == "DR")
                  {
                      (e.Row.FindControl("txtDebit") as TextBox).Enabled = true;
                      (e.Row.FindControl("txtCredit") as TextBox).Enabled = false;
                      (e.Row.FindControl("txtCredit") as TextBox).Text = string.Empty;
                  }

                  if (txtCurrency == "INR" || txtCurrency == "inr")
                  {
                      (e.Row.FindControl("txtBillAmount") as TextBox).Enabled = false;
                      (e.Row.FindControl("txtBillAmount") as TextBox).Text = string.Empty;
                  }
                  else 
                  {
                      (e.Row.FindControl("txtBillAmount") as TextBox).Enabled = true;
                     
                  }

                

              ////// DropDown Method start
              //DataTable dt = (DataTable)ViewState["PendingBillList"];              
              //if (dt.Rows.Count > 0)
              //{
              //    DropDownList ddlBill_inv_No = (e.Row.FindControl("ddlBill_inv_No") as DropDownList);
              //    ddlBill_inv_No.DataSource = dt;     //GetData("SELECT ")
              //    ddlBill_inv_No.DataTextField = "BILL_NO";
              //    ddlBill_inv_No.DataValueField = "BILL_NO";
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
            ObjUBO.MODE = "Select JournalEntry";
            ObjUBO.Flag = "Select-PaymentSingle";
            ObjUBO.FILE_REF_NO = Request.QueryString["Page"].ToString();
            HDupdate_id.Value = Request.QueryString["Page"].ToString();

            dss = BI.JornalEntry_Search(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = dss.Tables[0].Rows[0]["JOURNAL_ID"].ToString();
                txtVoucherNo.Text = dss.Tables[0].Rows[0]["VOUCHER_NO"].ToString();
                //ddlCustomer.Text = dss.Tables[0].Rows[0]["Customer_Name"].ToString();
                //ddlModeofPay.SelectedValue = dss.Tables[0].Rows[0]["PaymentMode"].ToString();
                txtCommNarration.Text = dss.Tables[0].Rows[0]["NARRATION"].ToString();
                txtVoucherDate.Text = dss.Tables[0].Rows[0]["VOUCHER_DATE"].ToString();
                txtVoucherType.Text = dss.Tables[0].Rows[0]["VOUCHER_TYPE"].ToString();

                //if (dss.Tables[0].Rows[0]["imp_exp"].ToString() == "Imp")
                //{
                //    Rd_Job_Type.SelectedIndex = 0;
                //    //load_Imp_name();
                //}
                //else if (dss.Tables[0].Rows[0]["imp_exp"].ToString() == "Exp")
                //{
                //    Rd_Job_Type.SelectedIndex = 1;
                //    //load_Imp_name();
                //}
                //else if (dss.Tables[0].Rows[0]["imp_exp"].ToString() == "Both")
                //{
                //    Rd_Job_Type.SelectedIndex = 2;
                //    //load_Imp_name();
                //}

               

                    gv_Chg_Details.DataSource = dss.Tables[0];
                    gv_Chg_Details.DataBind();
                    //  setting selected values into grid vew
                    int rowIndex = 0;
                    for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                    {

                        decimal totamt = 0;

                        TextBox txtCR_DR = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtCR_DR");
                        TextBox txtBill_inv_No = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtBill_inv_No");

                        TextBox txtBill_inv_date = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtBill_inv_date");

                        TextBox txtchargehead = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtchargehead");
                        TextBox txtFilerefno = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtFilerefno");
                        TextBox txtBillAmt = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtBillAmount");
                        TextBox txtAmount = (TextBox)gv_Chg_Details.Rows[rowIndex].FindControl("txtAmount");

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


                        //txtExRate1.Text = dss.Tables[0].Rows[i]["EX_RATE"].ToString();
                        //txtCredit1.Text = dss.Tables[0].Rows[i]["CREDIT"].ToString();
                        //txtBill_inv_date.Text = dss.Tables[0].Rows[i]["BILL_DATE"].ToString();
                       
                        //txtDebit1.Text = dss.Tables[0].Rows[i]["DEBIT"].ToString();
                      

                        rowIndex++;
                    }
                 
            }
            ViewState["CurrentTable"] = dss.Tables[1];  // old coding
            ViewState["NewCurrentTable"] = dss.Tables[0];
            //if (dss.Tables[2].Rows.Count > 0)
            //{
            //    gvPaymentdetails.DataSource = dss.Tables[2];
            //    gvPaymentdetails.DataBind();

            //    ViewState["PaymentHistory"] = dss.Tables[2];

            //    txtTotBillAmt.Text = dss.Tables[2].Compute("Sum(ReceivedAmt)", "").ToString();
            //    txtTotTDSAmt.Text = dss.Tables[2].Compute("Sum(TDSAmt)", "").ToString();
            //    txtFinalReceivedAmt.Text = dss.Tables[2].Compute("Sum(TotalReceived)", "").ToString();
            //    txtTotWriteOff.Text = dss.Tables[2].Compute("Sum(WriteOffAmt)", "").ToString();
            //}

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
                //Repeat_Staus();
            }

            if (e.CommandName.Equals("View"))
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = gv_Chg_Details.Rows[rowIndex];

                //Fetch value of Name.
                string name = (row.FindControl("txtFilerefno") as TextBox).Text;
                View_Grid(name);
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
                        if (dt.Columns.Contains("JOURNAL_SUBID"))
                        {
                            string apay = dt.Rows[rowIndex]["JOURNAL_SUBID"].ToString();
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
                    SetPreviousData();    //gv_Chg_Details.DeleteRow(index);
                    //DataTable  dt = (DataTable)gv_Chg_Details.DeleteRow(index);
                    //dt.Rows[index].Delete();
                    //ViewState["CurrentTable"] = dt;

                    //gv_Chg_Details.DataSource = dt;
                    //gv_Chg_Details.DataBind();
                    //string val = (string)this.gv_Chg_Details.DataKeys[index]["JOURNAL_SUBID"];
                    //i = PAYMENT_Delete("DELETE_SUB", val);

                    //if (i == 3)
                    //{

                    //    btnNew_Click1(sender, e);
                    //    Alert_msg("Deleted");
                    //    btnrpt.Visible = false;
                    //}
                    //else
                    //{
                    //    Alert_msg("Not Deleted");
                    //}
                   
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
        dt.Columns.Add(new DataColumn("BILL_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("BILL_DATE", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("CHARGE_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("FILE_REF_NO", typeof(string)));

        dt.Columns.Add(new DataColumn("BILL_AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("CURRENCY", typeof(string)));
        dt.Columns.Add(new DataColumn("EX_RATE", typeof(string)));  //txtExRate
        dt.Columns.Add(new DataColumn("CREDIT", typeof(string)));  //txtCredit

      
        dt.Columns.Add(new DataColumn("DEBIT", typeof(string)));//txtDebit.Text
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("JOURNAL_SUBID", typeof(string)));
        dt.Columns.Add(new DataColumn("JOURNAL_ID", typeof(string)));
       
        
        dt.Rows.Add(dr);        


        //ViewState["StartingTable"] = dt;
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
                    TextBox txtBill_inv_No = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtBill_inv_No");
                    TextBox txtBill_inv_date = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtBill_inv_date");
                    TextBox txtchargehead = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtchargehead");
                    TextBox txtFilerefno = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txtFilerefno");


                    TextBox txtBillAmt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txtBillAmount");
                    TextBox txtAmount = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtAmount");
                    TextBox txtCurrency = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txtCurrency");
                    TextBox txtExRate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtExRate");
                    TextBox txtCredit = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtCredit");

                    TextBox txtDebit = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtDebit");


                    drCurrentRow = dtCurrentTable.NewRow();


                    dtCurrentTable.Rows[i - 1]["DR_CR"] = txtCR_DR.Text;
                    dtCurrentTable.Rows[i - 1]["BILL_NO"] = txtBill_inv_No.Text;
                    dtCurrentTable.Rows[i - 1]["BILL_DATE"] = Convert.ToDateTime(Connection.DATE_FORMAT((txtBill_inv_date.Text == string.Empty) ? DateTime.Parse(("01/01/1900")).ToString("dd/MM/yyyy") : txtBill_inv_date.Text)).ToString("MM/dd/yyyy"); 

                    dtCurrentTable.Rows[i - 1]["CHARGE_NAME"] = txtchargehead.Text;
                    dtCurrentTable.Rows[i - 1]["FILE_REF_NO"] = txtFilerefno.Text;
                    //dtCurrentTable.Rows[i - 1][4] = txtFilerefno.Text;

                    dtCurrentTable.Rows[i - 1]["BILL_AMOUNT"] = (txtBillAmt.Text == string.Empty) ? "0" : txtBillAmt.Text; 
                    dtCurrentTable.Rows[i - 1]["AMOUNT"] = (txtAmount.Text == string.Empty) ? "0" : txtAmount.Text; 
                    dtCurrentTable.Rows[i - 1]["CURRENCY"] = (txtCurrency.Text == string.Empty) ? "0" : txtCurrency.Text; 
                    dtCurrentTable.Rows[i - 1]["EX_RATE"] = (txtExRate.Text == string.Empty) ? "0" : txtExRate.Text; 
                    dtCurrentTable.Rows[i - 1]["CREDIT"] = txtCredit.Text;//

                   
                    
                  
                    dtCurrentTable.Rows[i - 1]["DEBIT"] = (txtDebit.Text == string.Empty) ? "0" : txtDebit.Text; 
                 

                    rowIndex++;
                    Slno++;
                    //txtgSLNo.Focus();
                }


                int index = gv_Chg_Details.Rows.Count - 1;

                //TextBox txtgSLNolast = (TextBox)gvdetails.Rows[index + 1].Cells[0].FindControl("txtgSLNo");
                //txtgSLNolast.Focus();

                //drpgImpex.Focus();
                //drCurrentRow["SNo"] = Convert.ToInt32(txtsl.Text) + 1;
                //drCurrentRow["BR_SL_NO"] = Slno;
                // drCurrentRow["Debit"] = Convert.ToDecimal(txtTotalamtininr.Text) - total;
                //ViewState["RowNumber"] = Convert.ToInt32(txtsl.Text) + 1;




                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["NewCurrentTable"] = dtCurrentTable;

                gv_Chg_Details.DataSource = dtCurrentTable;
                gv_Chg_Details.DataBind();


                int index1 = gv_Chg_Details.Rows.Count - 1;
                ////gvdetails.Rows[index1].Cells[1].FindControl("txtgImpSLNo").Focus();
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
                    TextBox txtBill_inv_No = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[2].FindControl("txtBill_inv_No");
                    TextBox txtBill_inv_date = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[3].FindControl("txtBill_inv_date");
                    TextBox txtchargehead = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[4].FindControl("txtchargehead");
                    TextBox txtFilerefno = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[5].FindControl("txtFilerefno");


                    TextBox txtBillAmt = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[6].FindControl("txtBillAmt");
                    TextBox txtAmount = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[7].FindControl("txtAmount");
                    TextBox txtCurrency = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[8].FindControl("txtCurrency");
                    TextBox txtExRate = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[9].FindControl("txtExRate");
                    TextBox txtCredit = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[10].FindControl("txtCredit");

                    TextBox txtDebit = (TextBox)gv_Chg_Details.Rows[rowIndex].Cells[13].FindControl("txtDebit");
                  
                    //////////////////////////////////////////////////////////////////////
                    //chk_inv.Checked = dt.Rows[i][""].ToString();


                    txtCR_DR.Text = dt.Rows[i]["DR_CR"].ToString();
                    txtBill_inv_No.Text = dt.Rows[i]["BILL_NO"].ToString();
                    txtBill_inv_date.Text = dt.Rows[i]["BILL_DATE"].ToString();
                    txtchargehead.Text = dt.Rows[i]["CHARGE_NAME"].ToString();
                    txtFilerefno.Text = dt.Rows[i]["FILE_REF_NO"].ToString();

                    txtBillAmt.Text = dt.Rows[i]["BILL_AMOUNT"].ToString();
                    txtAmount.Text = dt.Rows[i]["AMOUNT"].ToString();
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

        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Journal Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {

        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Journal Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
        if (txtVoucherDate.Text != string.Empty)
        {

            //OLD CODE START
            //if (RdPayFor.SelectedIndex == 0)
            //{
            //    if (gv_Chg_Details.Rows.Count > 0)
            //    {
            //        PAYMENT_Ins_Del_Upd("S", "0");                    
            //    }
            //    else
            //    {
            //        Alert_msg("No Records found in Payment grid");
            //    }
            //}

            //else
            //{
            //    PAYMENT_Ins_Del_Upd("S", "0");
            //}
            //OLD CODE END


                if (gv_Chg_Details.Rows.Count > 0)
                {
                    PAYMENT_Ins_Del_Upd("S", "0");
                }
                else
                {
                    Alert_msg("No Records found in Journal grid");
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
                Alert_msg("No Records found in Journal grid");
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



    public int PAYMENT_Ins_Del_Upd(string I_Name, string JOURNAL_ID)
    {
        
        DataTable dt;
        string totReceivedAmt = "0";
        
          

       
        ConvertGrid_Datatable(gv_Chg_Details);
       
        dt = (DataTable)ViewState["NewCurrentTable"];// new code
        if (dt.Rows.Count > 0)
        {

            ObjUBO.JOURNAL_ID = JOURNAL_ID;
                    ObjUBO.Flag = I_Name;
              

                ObjUBO.VOUCHER_NO = txtVoucherNo.Text;
                ObjUBO.BILL_INV_DATE = txtVoucherDate.Text;  // Payment voucher Date
                ObjUBO.VOUCHER_TYPE = txtVoucherType.Text;  // customer name
               
              
                ObjUBO.NARRATION = txtCommNarration.Text;
               
                BI.JournalEntryIDU(ObjUBO, dt);
                i = BI.result;
                return i;
            //}
            //else
            //{
            //    Alert_msg("The Payment amount not equal to sum of bill received amount");
            //    i = -2;
            //    return i;
            //}

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
                //SetInitialRow();
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
        //decimal gst_total = 0;
        int cnt = 0;
        DataTable dt;
        DataRow dr;
        int R = 1;
        //dt = (DataTable)ViewState["CurrentTable"];// old code
        dt = (DataTable)ViewState["NewCurrentTable"];// old code
            
        if (dt.Rows.Count > 0)
        {
            dt.Rows.Clear();
        }
        //select PAYMENT_ID,ReceivedAmt,Job_referenceNo,Bill_Inv_RefNo,TDS_No,TDS_Date,TDS_Percent,TDS_Amt,Remarks from Tbl_PaymentSub where 1=0; 
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
                TextBox txtchargehead = (TextBox)row.FindControl("txtchargehead");
                TextBox txtBill_inv_No = (TextBox)row.FindControl("txtBill_inv_No");
                TextBox txtBilldate = (TextBox)row.FindControl("txtBill_inv_date");
                TextBox txtFilerefno = (TextBox)row.FindControl("txtFilerefno");
                TextBox txtCR_DR = (TextBox)row.FindControl("txtCR_DR");
                TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
                TextBox txtBillAmount = (TextBox)row.FindControl("txtBillAmount");
                //new code added End


                cnt = 1;
                if (txtBilldate.Text == null)
                {
                    txtBilldate.Text = string.Empty;
                }

                if (txtBillAmount.Text.Trim() == "" || txtBillAmount.Text.Trim() == string.Empty)
                {
                    txtBillAmount.Text = "0";
                }
                if (txtAmount.Text.Trim() == "" || txtAmount.Text.Trim() == string.Empty)
                {
                    txtAmount.Text = "0";
                }
               

                //if (Convert.ToDecimal(txtExRate1.Text) > Convert.ToDecimal(txtCurrency1.Text))
                //{
                //    if (RdPayFor.SelectedIndex == 0)
                //    {
                //        Alert_msg("Current Receivable should less than balance amount ");
                //        return;
                //    }
                //    else
                //    {
                //        //Advance mode code required
                //    }
                //}
                //dt.Columns["BILL_DATE"].DataType = typeof(Convert.ToString(DateTime.toString(txtBilldate.Text));
                    //(DateTime.toString(MM-dd-yyyy)));
                // new code start
                dr = dt.NewRow();
                
                dr[0] = R;
                dr["BILL_NO"] = txtBill_inv_No.Text;  // Payment                
                
                dr["CHARGE_NAME"] = txtchargehead.Text.Trim(); // job no from grid column 4   //3

                dr["FILE_REF_NO"] = txtFilerefno.Text.Trim();
                dr["AMOUNT"] = (txtAmount.Text == "") ? "0" : txtAmount.Text;   // TDSAmt
                dr["CREDIT"] = (txtCredit1.Text == "") ? "0" : txtDebit1.Text;   // TDSAmt
                dr["BILL_AMOUNT"] = (txtBillAmount.Text == "") ? "0" : txtBillAmount.Text;   // TDSAmt txtBillAmount.Text.Trim(); // TDS dt
                dr["BILL_DATE"] = Connection.DATE_FORMAT((txtBilldate.Text == string.Empty) ? "01/01/1900" : txtBilldate.Text).ToLongDateString();
                    //Convert.ToDateTime(Connection.DATE_FORMAT((txtBilldate.Text == string.Empty) ? DateTime.Parse(("01/01/1900")).ToString("dd/MM/yyyy") : DateTime.Parse((txtBilldate.Text)).ToString("dd/MM/yyyy"))).ToString("MM/dd/yyyy");   // TDS dt 
                //DateTime dat = DateTime.Parse((txtBilldate.Text == string.Empty) ? "01/01/1900" : txtBilldate.Text);
                //dr["BILL_DATE"] = dat.ToString().Replace(" 00:00:00", "");
                
                dr["CURRENCY"] = txtCurrency1.Text.Trim(); // TDS dt
                dr["EX_RATE"] = (txtExRate1.Text == "") ? "0" : txtExRate1.Text;   // TDSAmt txtExRate1.Text.Trim(); // TDS dt
                dr["DR_CR"] = txtCR_DR.Text.Trim(); // TDS dt


                dr["RowNumber"] = 1;
                dr["JOURNAL_SUBID"] = 1;
                dr["JOURNAL_ID"] = 1;
               
              
                dr["DEBIT"] = (txtDebit1.Text == "") ? "0" : txtDebit1.Text;   // TDSAmt
               
               
                dt.Rows.Add(dr);
                R = R + 1;
                // new code end
                

            }
            DataView dv = new DataView(dt);

            dt = dv.ToTable("selected", false, "RowNumber", "JOURNAL_SUBID", "JOURNAL_ID", "DR_CR", "CHARGE_NAME", "BILL_NO","BILL_DATE", "FILE_REF_NO", "CURRENCY", "EX_RATE", "DEBIT", "CREDIT", "AMOUNT", "BILL_AMOUNT");
            
        }

        if (cnt == 1)
        {
            //ViewState["CurrentTable"] = dt; //old code
            ViewState["NewCurrentTable"] = dt; //New code
        }
        else
        {
            Alert_msg("Select atleast one Bill");          
            //DataTable dt1=new DataTable();
            //ViewState["CurrentTable"] = dt1;
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
            //Other_Quotation.Checked = false;
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
            //SetInitialRow();


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

       // //load_Imp_name();
       // ddlImp_name_SelectedIndexChanged(sender, e);
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
            //if (ddlbranch_No.SelectedItem.Text != string.Empty)
            //{
                //LoadPendingJob();
                //LoadPendingJob_webmethod();

            //}
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
            //string TempRd_Job_Type = "2";
            //string Tempddlbranch_No = "All";
            //string TempddlCustomer = "Chennai, Air";
            GST_Imp_Invoice BI = new GST_Imp_Invoice();
            Billing_UserBO ObjUBO = new Billing_UserBO();

            //if (TempRd_Job_Type == "Imp")
            //    ObjUBO.Flag = "Select-Imp-CustomerPendingBills";
            //else if (TempRd_Job_Type== "Exp")
            //    ObjUBO.Flag = "Select-Exp-CustomerPendingBills";
            //else if (TempRd_Job_Type== "Both")
            //    ObjUBO.Flag = "Select-ImpExp-CustomerPendingBills";
            //ObjUBO.BRANCH_CODE = Tempddlbranch_No;
            //ObjUBO.Ref_ID = TempddlCustomer;

            //ds = BI.Load_DDL(ObjUBO);

          
            ObjUBO.Flag = "Select-ImpExp-VendorPendingBills";
            ObjUBO.BRANCH_CODE = Tempddlbranch_No;
            ObjUBO.Ref_ID = TempddlCustomer;

            ds = BI.Load_DDL_PAYMENTENTRY(ObjUBO);
            dt1 = ds.Tables[0];
            //dt= dt1.Select("BILL_NO");
            DataView dv = new DataView(dt1);
            //dt = dv.ToTable("selected", false, "BILL_NO");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ReturnStr=ds.Tables[0].Rows[i]["BILL_NO"].ToString();
                if (ReturnStr.Contains(finder))
                {
                    result.Add(ds.Tables[0].Rows[i]["BILL_NO"].ToString());
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

            //if (TempRd_Job_Type == "Imp")
            //    ObjUBO.Flag = "Select-Imp-CustomerPendingBills";
            //else if (TempRd_Job_Type == "Exp")
            //    ObjUBO.Flag = "Select-Exp-CustomerPendingBills";
            //else if (TempRd_Job_Type == "Both")
            //    ObjUBO.Flag = "Select-ImpExp-CustomerPendingBills";
            ObjUBO.Flag = "Select-ImpExp-VendorPendingBills";
            ObjUBO.BRANCH_CODE = Tempddlbranch_No;
            ObjUBO.Ref_ID = TempddlCustomer;

            ds = BI.Load_DDL_PAYMENTENTRY(ObjUBO);
            dt1 = ds.Tables[0];
            //dt= dt1.Select("BILL_NO");
            DataView dv = new DataView(dt1);
            //dt = dv.ToTable("selected", false, "BILL_NO");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ReturnStr = ds.Tables[0].Rows[i]["BILL_NO"].ToString();
                //if (ReturnStr.Contains(finder))
                if (ReturnStr==BillInvNo)
                {
                    //result.Add(ds.Tables[0].Rows[i]["BILL_NO"].ToString());
                    ReturnStrMore = ds.Tables[0].Rows[i]["BILL_NO"].ToString() + "~~" + ds.Tables[0].Rows[i]["BILL_DATE"].ToString() + "~~" + ds.Tables[0].Rows[i]["CHARGE_NAME"].ToString() + "~~" + ds.Tables[0].Rows[i]["IMP_EXP"].ToString() + "~~" + ds.Tables[0].Rows[i]["BILL_AMOUNT"].ToString() + "~~" + ds.Tables[0].Rows[i]["AMOUNT"].ToString() + "~~" + ds.Tables[0].Rows[i]["CURRENCY"].ToString();
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
                //TextBox txtfcredittotal = (TextBox)gvdetails.FooterRow.FindControl("txtcredittotal");
                //TextBox txtfdebittotal = (TextBox)gvdetails.FooterRow.FindControl("txtdebittotal");
                //TextBox txtfcgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtcgsttotal");
                //TextBox txtfsgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtsgsttotal");
                //TextBox txtfigsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtigsttotal");
                //TextBox txtftdstotal = (TextBox)gvdetails.FooterRow.FindControl("txttdstotal");
                //txtfcredittotal.Text = ViewState["credit"].ToString();
                //txtfdebittotal.Text = ViewState["debit"].ToString();
                //txtfcgsttotal.Text = ViewState["cgst"].ToString();
                //txtfsgsttotal.Text = ViewState["sgst"].ToString();
                //txtfigsttotal.Text = ViewState["igst"].ToString();
                //txtftdstotal.Text = ViewState["tdsamt"].ToString();

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