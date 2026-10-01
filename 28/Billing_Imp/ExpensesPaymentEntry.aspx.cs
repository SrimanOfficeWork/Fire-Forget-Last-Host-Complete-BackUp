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


public partial class ExpensesPaymentEntry : ThemeClass
{

    /*
     
     Tables Used
         --> Tbl_ExpensesMain , Tbl_ExpensesSub. [Tbl_ExpensesMain - Header info  , Tbl_ExpensesSub -line items ]
     Procedures Used
        -->  AccExp_Payment_SP , AccExp_Pay_Receipt_Select_SP , Load_ddl_SP  [AccExp_Payment_SP - For insert, delete & update the expenses info. AccExp_Pay_Receipt_Select_SP - All selection , Load_ddl_SP -load the DDL value ]
     
     */

    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();

    public int i;
    public string COMPANY_LICENSE;

    Job_Histroy jh = new Job_Histroy();
    public string errorFolder = "", fileName, attach_File, Upload_Flag, finYear, expMainRootfolder;

    
  

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
        aps.checkSession();
      

        COMPANY_LICENSE = Connection.Company_License().ToLower();
        ////errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "Expense_Entry" + "/");
       // string com = Session["currentbranch"].ToString();
       
        if (!Page.IsPostBack)
        {

            //errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + jh.JOB_TYPE + "_Job_history" + "/");
            ////errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "Expense_Entry" + "/");
            ////if (Directory.Exists(errorFolder) == false)
            ////{
            ////    Directory.CreateDirectory(errorFolder);
            ////}

            Load_CRDR();
            Load_ClassifyType();
            LoadBranch() ;
            Load_Based_On();

            ddlbranch_No_SelectedIndexChanged(sender, e);
            ddlbranch_No.Focus();

            Loadddltype();
            LoadddlSearch();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            btnrpt.Visible = false;
           
            T.Visible = false;
           
            
            DataTable dtt = new DataTable();
            gv.DataSource = dtt;
            gv.DataBind();

            if (Request.QueryString["Page"] == null)
            {
                GetAutono_Receipt();
                if (COMPANY_LICENSE == "eri00247" || COMPANY_LICENSE == "eri00010")
                {
                    WK.Visible = true;
                    LoadFinancialYear();
                    ddlWorkingPeriod.SelectedValue = Connection.WorkingPeriod();
                }

                txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                SetInitialRow();

                btnNew.Visible = false;
                btnSave.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btn.Visible = false;
                gv.Visible = false;               
            }


            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty  )
                {
                    Update_Item_Load();                    
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddltype.Enabled = false;
                    ddlSearch.Enabled = false;

                    btnNewRow.Visible = true;
                    btnSaveRow.Visible = true;
                    btnUpdateRow.Visible = false;
                    btnDeleteRow.Visible = false;

                    FileUpload1.Visible = false;
                    btnUploadRow.Visible = false;

                    chkImageFileRow.Visible = false;
                    lbtnImageFileRow.Visible = false;

                }
            }
             
        }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    private void LoadBranch()
    {
        try
        {
        DataSet ds = new DataSet();
            ddljobno.Items.Clear();
            ddlbranch_No.Items.Clear();
            txtJobInfo.Text = "";
            txtCustName.Text = "";

            txtBranchSlNo.Text = "";
            txtFileRefNo.Text = "";
            txtjobno.Text = "";
            


            if (Rd_Job_Type.SelectedIndex == 0)
                ObjUBO.Flag = "Select-ImpBranch";
            else if (Rd_Job_Type.SelectedIndex == 1)
                ObjUBO.Flag = "Select-ExpBranch";

            /* OLD CODE START
            ds = BI.Load_DDL(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlbranch_No.DataSource = ds.Tables[0];
                ddlbranch_No.DataTextField = "BRANCHCODE";
                ddlbranch_No.DataValueField = "BRANCHCODE";
                ddlbranch_No.DataBind();
            } OLD CODE END */

            //ddlbranch_No.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            //ddlbranch_No.SelectedIndex = 0;
            ddlbranch_No.Items.Insert(0, Session["currentbranch"].ToString());
            ddlbranch_No.SelectedValue = Session["currentbranch"].ToString();

            ds.Dispose();
            GC.Collect();

         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    private void Loadddltype()
    {
        try
        {
            if (ddltype.SelectedItem.Text==" ")
            {
                ddltype.SelectedValue = "FRN";                  
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    private void LoadJob()
    {
          try
          {
            DataSet ds = new DataSet();   
            ddljobno.Items.Clear();
            if (chkIncludeJob.Checked == true)
            {
                if (Rd_Job_Type.SelectedIndex == 0)
                    ObjUBO.Flag = "Select-ImpBrnWiseJob";
                else if (Rd_Job_Type.SelectedIndex == 1)
                    ObjUBO.Flag = "Select-ExpBrnWiseJob";
            }
            else
            {
                if (Rd_Job_Type.SelectedIndex == 0)
                    ObjUBO.Flag = "Select-ImpBrnWiseJob_ExcludeExistJob";
                else if (Rd_Job_Type.SelectedIndex == 1)
                    ObjUBO.Flag = "Select-ExpBrnWiseJob_ExcludeExistJob";
            }
            ObjUBO.BRANCH_CODE = ddlbranch_No.SelectedValue.ToString();
            ds = BI.Load_DDL(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddljobno.DataSource = ds.Tables[0];               

                ddljobno.DataTextField = "JOBNO";
                ddljobno.DataValueField = "JOBID";
                ddljobno.DataBind();
            }
            ddljobno.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddljobno.SelectedIndex = 0;


            ds.Dispose();
            GC.Collect();
        
           }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        }

      private void LoadddlSearch()
      {
          try
          {
              DataSet ds = new DataSet();
              ddlSearch.Items.Clear(); 
              ObjUBO.BRANCH_CODE = ddlbranch_No.SelectedValue.ToString();

              if (ddltype.SelectedItem.Text == "File.Ref.no")
              {
                  if (Rd_Job_Type.SelectedIndex == 0)
                      ObjUBO.Flag = "Select-ImpBrnWiseFRN_ExcludeExistFRN";
                  else if (Rd_Job_Type.SelectedIndex == 1)
                      ObjUBO.Flag = "Select-ExpBrnWiseFRN_ExcludeExistFRN";

                  ds = BI.Load_DDL(ObjUBO);
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                      ddlSearch.DataSource = ds.Tables[0];
                      ddlSearch.DataTextField = "FILE_REF_NO";
                      ddlSearch.DataValueField = "FILE_REF_NO";
                      ddlSearch.DataBind();
                      ddlSearch.Items.Add ("OTHERS");
                  }
              }
              else if (ddltype.SelectedItem.Text == "Job No")
              {
                  if (Rd_Job_Type.SelectedIndex == 0)
                      ObjUBO.Flag = "Select-ImpBrnWiseJob_ExcludeExistJob";
                  else if (Rd_Job_Type.SelectedIndex == 1)
                      ObjUBO.Flag = "Select-ExpBrnWiseJob_ExcludeExistJob";

                  ds = BI.Load_DDL(ObjUBO);
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                      ddlSearch.DataSource = ds.Tables[0];
                      ddlSearch.DataTextField = "JOBNO";
                      ddlSearch.DataValueField = "JOBNO";
                      ddlSearch.DataBind();
                  }

              }
              else if (ddltype.SelectedItem.Text == "Inv No")
              {
                  if (Rd_Job_Type.SelectedIndex == 0)
                      ObjUBO.Flag = "Select-ImpBrnWiseInvNo_ExcludeExistInvNo";
                  else if (Rd_Job_Type.SelectedIndex == 1)
                      ObjUBO.Flag = "Select-ExpBrnWiseInvNo_ExcludeExistInvNo";

                  //ds = BI.Load_DDL(ObjUBO);
                  ds = BI.Load_DDL_Accounts(ObjUBO);
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                      ddlSearch.DataSource = ds.Tables[0];
                      ddlSearch.DataTextField = "BILL_INV_NO";
                      ddlSearch.DataValueField = "BILL_INV_NO";
                      ddlSearch.DataBind();
                  }
              }
              else
              {

              }

              ddlSearch.Items.Insert(0, new ListItem("--Select--", "--Select--"));
              ddlSearch.SelectedIndex = 0;

              ds.Dispose();
              GC.Collect();
              
          }
          catch (Exception ex)
          {
              Connection.Error_Msg(ex.Message);
          }

      }

      private void Load_CRDR()
      {
          ddlCrDr.Items.Clear();
          ddlCrDr.Items.Add(new ListItem("Credit"));
          ddlCrDr.Items.Add(new ListItem("Debit"));
         
      }
      private void Load_Based_On()
      {

          if (COMPANY_LICENSE == "eri00945")// ERI00945 is INBA LOGISTICS Required Invoice No Only
          {
              //ddltype.Items[0].Enabled = true;
              //ddltype.Items[1].Enabled = false;
              //ddltype.Items[2].Enabled = false;
              //ddltype.Items[3].Enabled = false;
              //ddltype.Items[4].Enabled = false;
              //ddltype.Items[5].Enabled = true;
              //ddltype.Items[6].Enabled = false;
              //ddltype.SelectedItem.Text = "";


              ddltype.Items[0].Enabled = true;
              ddltype.Items[1].Enabled = true;
              ddltype.Items[2].Enabled = true;
              ddltype.Items[3].Enabled = false;
              ddltype.Items[4].Enabled = false;
              ddltype.Items[5].Enabled = true;
              ddltype.Items[6].Enabled = false;
              ddltype.SelectedItem.Text = "";


          }          
      }


      private void Load_ClassifyType()
      {
          ddlClassType.Items.Clear();
          
          ddlClassType.Items.Add(new ListItem("B2B REGISTERED PURCHASE"));
          ddlClassType.Items.Add(new ListItem("B2B UNREGISTERED PURCHASE"));
          ddlClassType.Items.Add(new ListItem("B2B SEZ PURCHASE"));
          ddlClassType.Items.Add(new ListItem("B2B IMPORT"));
          ddlClassType.Items.Add(new ListItem("NON GST PURCHASE"));
          ddlClassType.Items.Add(new ListItem("B2B ZERO RATE PURCHASE"));
          ddlClassType.Items.Add(new ListItem("B2B PURCHASE WITH GST"));
          ddlClassType.Items.Add(new ListItem("B2B PURCHASE WITHOUT GST"));                                       

      }



      private void Update_Item_Load_Fresh()
      {
          try
          {
              DataSet dss = new DataSet();
              ObjUBO.MODE = "Select Exp-Payment";
              ObjUBO.Flag = "Select-ExpSingle";
              ObjUBO.FILE_REF_NO = HDupdate_id.Value;
              dss = BI.Exp_Pay_Search(ObjUBO);

              if (dss.Tables[1].Rows.Count > 0)
              {
                  gv.Visible = true;
                  gv.DataSource = dss.Tables[1];
                  gv.DataBind();
                  
                  
                  txtTotalExpAmt.Text = "";
                  decimal gst_total = 0;
                  string secondval = "";                  
                  for (int r = 0; r < dss.Tables[1].Rows.Count; r++)
                  {
                      secondval = dss.Tables[1].Rows[r]["Exp_Amount"].ToString();
                      gst_total = gst_total + (Convert.ToDecimal(secondval));
                  }
                  txtTotalExpAmt.Text = gst_total.ToString();
                  ObjUBO.ID = HDupdate_id.Value;
                  ObjUBO.Flag = "ASU";                  
                  ObjUBO.TOTAL_TAX_AMT = txtTotalExpAmt.Text;
                  //BI.ExpIDU_V3(ObjUBO);
                  //BI.ExpIDU_V4(ObjUBO);
                  BI.ExpIDU_V5(ObjUBO);
                  if (i != 7)
                  {
                      Alert_msg("Total Expense not updated");                      
                  }
                  ViewState["CurrentTable"] = dss.Tables[1];
              }
              else
              {
                  SetInitialRow();
              }

              JobInfoDisplay();

              dss.Dispose();
              GC.Collect();

          }
          catch (Exception ex)
          {
              Connection.Error_Msg(ex.Message);
          }
      }
    private void Update_Item_Load()
    {
        try
        {
        DataSet dss = new DataSet();
        ObjUBO.MODE = "Select Exp-Payment";
        ObjUBO.Flag = "Select-ExpSingle";
        ObjUBO.FILE_REF_NO = Request.QueryString["Page"].ToString();
      
        HDupdate_id.Value = Request.QueryString["Page"].ToString();

        dss = BI.Exp_Pay_Search(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {
            HDupdate_id.Value = dss.Tables[0].Rows[0]["Exp_ID"].ToString();
            txtExpVoucherNo.Text = dss.Tables[0].Rows[0]["Exp_VoucherNo"].ToString();
            txtCustName.Text = dss.Tables[0].Rows[0]["Customer_name"].ToString();
            txtTotalExpAmt.Text = dss.Tables[0].Rows[0]["TotalExpAmt"].ToString();
            txtCommNarration.Text = dss.Tables[0].Rows[0]["Narration"].ToString();
            txtDate.Text = dss.Tables[0].Rows[0]["Exp_Date"].ToString();
            if (dss.Tables[0].Rows[0]["imp_exp"].ToString()=="Imp") 
            {
                Rd_Job_Type.SelectedIndex = 0;
            }
            else
            {
                Rd_Job_Type.SelectedIndex = 1;
            }




            ddltype.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["BASED_ON"].ToString(), dss.Tables[0].Rows[0]["BASED_ON"].ToString()));
            ddltype.SelectedIndex = 0;
            ddlSearch.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["SEARCH_CONTENT"].ToString(), dss.Tables[0].Rows[0]["SEARCH_CONTENT"].ToString()));
            ddlSearch.SelectedIndex = 0;
            txtFileRefNo.Text = dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
            txtjobno.Text = dss.Tables[0].Rows[0]["JOB_NO"].ToString();
            txtBranchSlNo.Text = dss.Tables[0].Rows[0]["BR_SL_NO"].ToString();
            txtJobInfo.Text = dss.Tables[0].Rows[0]["JOB_INFO"].ToString();

            //ddljobno.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["JOB_NO"].ToString(), dss.Tables[0].Rows[0]["JOB_NO"].ToString()));
            ddljobno.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["JOB_NO"].ToString(), dss.Tables[0].Rows[0]["JOB_ID"].ToString()));
            ddljobno.SelectedIndex = 0;
            ddlbranch_No.Items.Clear();
            ddlbranch_No.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["BRANCHCODE"].ToString(), dss.Tables[0].Rows[0]["BRANCHCODE"].ToString()));
            ddlbranch_No.SelectedIndex = 0;
        }
         

        if (dss.Tables[1].Rows.Count > 0)
        {
            gv.DataSource = dss.Tables[1];
            gv.DataBind();
           // int rowIndex = 0;
            //for (int i = 0; i < dss.Tables[1].Rows.Count; i++)
            //{
                ////DropDownList ddl_PayMode1 = (DropDownList)gv_Chg_Details.Rows[i].Cells[4].FindControl("ddl_PayMode");               
                ////ddl_PayMode1.SelectedValue= dss.Tables[1].Rows[i]["PaymentMode"].ToString();
              //  DropDownList ddl_PayMode1 = (DropDownList)gv.Rows[i].Cells[4].FindControl("ddlPayMode");
              //  ddl_PayMode1.SelectedValue = dss.Tables[1].Rows[i]["PaymentMode"].ToString();

           // }

            ViewState["CurrentTable"] = dss.Tables[1];
         
        }
        else
        {
            SetInitialRow();
        }

        //JobInfoDisplay(); //NOT REQUIRED HERE, IF PROBLEM OCCUR PLEASE REMOVE IT

        dss.Dispose();
        GC.Collect();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
     
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Height = 20;
        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
       
       
    }

    private void AddNewRowToGrid()
    {
        try
        {
            int rowIndex = 0;
            decimal gst_total = 0;

            string Emptyrow = string.Empty;


            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {


                        TextBox txtExpDetails1 = (TextBox)gv.Rows[rowIndex].Cells[1].FindControl("txtExpDetails");
                        TextBox txtRefVoucherNo1 = (TextBox)gv.Rows[rowIndex].Cells[2].FindControl("txtRefVoucherNo");
                        TextBox txtExpAmount1 = (TextBox)gv.Rows[rowIndex].FindControl("txtExpAmount");
                        DropDownList ddl_PayMode1 = (DropDownList)gv.Rows[rowIndex].FindControl("ddl_PayMode");
                        TextBox txtGivenBy1 = (TextBox)gv.Rows[rowIndex].FindControl("txtGivenBy");
                        TextBox txtAssignee1 = (TextBox)gv.Rows[rowIndex].FindControl("txtAssignee");
                        TextBox txtRemarks1 = (TextBox)gv.Rows[rowIndex].FindControl("txtRemarks");
                        TextBox 	VENDOR_BRANCH1 = (TextBox)gv.Rows[rowIndex].FindControl("VENDOR_BRANCH");
                        TextBox 	VENDOR_GSTIN1 = (TextBox)gv.Rows[rowIndex].FindControl("VENDOR_GSTIN");
                        DropDownList CR_DR1 = (DropDownList)gv.Rows[rowIndex].FindControl("CR_DR");
                        TextBox 	EX_RATE1 = (TextBox)gv.Rows[rowIndex].FindControl("EX_RATE");
                        TextBox 	CURRENCY1 = (TextBox)gv.Rows[rowIndex].FindControl("CURRENCY");
                        TextBox 	FOREIGN_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("FOREIGN_AMOUNT");
                        DropDownList CLASSIFY_TYPE1 = (DropDownList)gv.Rows[rowIndex].FindControl("CLASSIFY_TYPE");
                        TextBox 	TAXABLE_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("TAXABLE_AMOUNT");
                        TextBox 	CGST_PERCENTAGE1 = (TextBox)gv.Rows[rowIndex].FindControl("CGST_PERCENTAGE");
                        TextBox 	CGST_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("CGST_AMOUNT");
                        TextBox 	SGST_PERCENTAGE1 = (TextBox)gv.Rows[rowIndex].FindControl("SGST_PERCENTAGE");
                        TextBox 	SGST_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("SGST_AMOUNT");
                        TextBox 	IGST_PERCENTAGE1 = (TextBox)gv.Rows[rowIndex].FindControl("IGST_PERCENTAGE");
                        TextBox 	IGST_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("IGST_AMOUNT");


                        if (txtExpAmount1.Text.Trim() == "" || txtExpAmount1.Text.Trim() == string.Empty)
                        {
                            txtExpAmount1.Text = "0";
                        }

                        if (txtExpAmount1.Text == "0" || txtExpDetails1.Text.Trim() == "" || txtExpDetails1.Text.Trim() == string.Empty || txtGivenBy1.Text.Trim() == "" || txtGivenBy1.Text.Trim() == string.Empty || txtAssignee1.Text.Trim() == "" || txtAssignee1.Text.Trim() == string.Empty)
                        {
                            Emptyrow = "Y";
                        }


                        drCurrentRow = dtCurrentTable.NewRow();



                        drCurrentRow["RowNumber"] = i + 1;


                        dtCurrentTable.Rows[i - 1]["Exp_Details"] = txtExpDetails1.Text;
                        dtCurrentTable.Rows[i - 1]["Ref_VoucherNo"] = txtRefVoucherNo1.Text;
                        dtCurrentTable.Rows[i - 1]["Exp_Amount"] = txtExpAmount1.Text;
                        dtCurrentTable.Rows[i - 1]["PaymentMode"] = ddl_PayMode1.SelectedValue.ToString();
                        dtCurrentTable.Rows[i - 1]["Remarks"] = txtRemarks1.Text;
                        dtCurrentTable.Rows[i - 1]["GivenBy"] = txtGivenBy1.Text;
                        dtCurrentTable.Rows[i - 1]["Assignee"] = txtAssignee1.Text;
                        dtCurrentTable.Rows[i - 1]["VENDOR_BRANCH"] = txtVendorBranch.Text;
                        dtCurrentTable.Rows[i - 1]["VENDOR_GSTIN"] = txtVendorGSTIN.Text;
                        dtCurrentTable.Rows[i - 1]["CR_DR"] = ddlCrDr.SelectedItem.ToString();
                        dtCurrentTable.Rows[i - 1]["EX_RATE"] = txtExrate.Text;
                        dtCurrentTable.Rows[i - 1]["CURRENCY"] = txtCurrency.Text;
                        dtCurrentTable.Rows[i - 1]["TAXABLE_AMOUNT"] = txtTaxAmount.Text;
                        dtCurrentTable.Rows[i - 1]["CLASSIFY_TYPE"] = ddlClassType.SelectedItem.ToString();
                        dtCurrentTable.Rows[i - 1]["FOREIGN_AMOUNT"] = txtForeignamt.Text;
                        dtCurrentTable.Rows[i - 1]["CGST_PERCENTAGE"] = txtCgstpercentage.Text;
                        dtCurrentTable.Rows[i - 1]["CGST_AMOUNT"] = txtCgstAmount.Text;
                        dtCurrentTable.Rows[i - 1]["SGST_PERCENTAGE"] = txtSGSTPercentage.Text;
                        dtCurrentTable.Rows[i - 1]["SGST_AMOUNT"] = txtSGSTAmount.Text;
                        dtCurrentTable.Rows[i - 1]["IGST_PERCENTAGE"] = txtIGSTPercentage.Text;
                        dtCurrentTable.Rows[i - 1]["IGST_AMOUNT"] = txtIGSTAmount.Text;

                        rowIndex++;

                        if (txtExpAmount1.Text.Trim() == "" || txtExpAmount1.Text.Trim() == string.Empty)
                        {
                            txtExpAmount1.Text = "0";
                        }
                        gst_total = gst_total + (Convert.ToDecimal(txtExpAmount1.Text));
                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gv.DataSource = dtCurrentTable;
                    gv.DataBind();

                    if (Emptyrow == "Y")
                    {
                        Alert_msg("Enter the value in Empty Row");
                    }



                    txtTotalExpAmt.Text = gst_total.ToString();
                }

            }
            SetPreviousData();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void SetPreviousData()
    {
        try
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        //--------------------------------------------------------------------

                        TextBox txtExpDetails1 = (TextBox)gv.Rows[rowIndex].Cells[1].FindControl("txtExpDetails");
                        TextBox txtRefVoucherNo1 = (TextBox)gv.Rows[rowIndex].Cells[2].FindControl("txtRefVoucherNo");
                        TextBox txtExpAmount1 = (TextBox)gv.Rows[rowIndex].Cells[3].FindControl("txtExpAmount");
                        DropDownList ddl_PayMode1 = (DropDownList)gv.Rows[rowIndex].Cells[4].FindControl("ddl_PayMode");
                        TextBox txtGivenBy1 = (TextBox)gv.Rows[rowIndex].Cells[5].FindControl("txtGivenBy");
                        TextBox txtAssignee1 = (TextBox)gv.Rows[rowIndex].Cells[6].FindControl("txtAssignee");
                        TextBox txtRemarks1 = (TextBox)gv.Rows[rowIndex].Cells[7].FindControl("txtRemarks");
                        TextBox VENDOR_BRANCH1 = (TextBox)gv.Rows[rowIndex].FindControl("VENDOR_BRANCH");
                        TextBox VENDOR_GSTIN1 = (TextBox)gv.Rows[rowIndex].FindControl("VENDOR_GSTIN");
                        DropDownList CR_DR1 = (DropDownList)gv.Rows[rowIndex].FindControl("CR_DR");
                        TextBox EX_RATE1 = (TextBox)gv.Rows[rowIndex].FindControl("EX_RATE");
                        TextBox CURRENCY1 = (TextBox)gv.Rows[rowIndex].FindControl("CURRENCY");
                        TextBox FOREIGN_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("FOREIGN_AMOUNT");
                        DropDownList CLASSIFY_TYPE1 = (DropDownList)gv.Rows[rowIndex].FindControl("CLASSIFY_TYPE");
                        TextBox TAXABLE_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("TAXABLE_AMOUNT");
                        TextBox CGST_PERCENTAGE1 = (TextBox)gv.Rows[rowIndex].FindControl("CGST_PERCENTAGE");
                        TextBox CGST_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("CGST_AMOUNT");
                        TextBox SGST_PERCENTAGE1 = (TextBox)gv.Rows[rowIndex].FindControl("SGST_PERCENTAGE");
                        TextBox SGST_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("SGST_AMOUNT");
                        TextBox IGST_PERCENTAGE1 = (TextBox)gv.Rows[rowIndex].FindControl("IGST_PERCENTAGE");
                        TextBox IGST_AMOUNT1 = (TextBox)gv.Rows[rowIndex].FindControl("IGST_AMOUNT");




                        txtExpDetails1.Text = dt.Rows[i]["Exp_Details"].ToString();
                        txtRefVoucherNo1.Text = dt.Rows[i]["Ref_VoucherNo"].ToString();

                        txtExpAmount1.Text = dt.Rows[i]["Exp_Amount"].ToString();
                        ddl_PayMode1.SelectedValue = dt.Rows[i]["PaymentMode"].ToString();
                        txtGivenBy1.Text = dt.Rows[i]["GivenBy"].ToString();
                        txtAssignee1.Text = dt.Rows[i]["Assignee"].ToString();
                        txtRemarks1.Text = dt.Rows[i]["Remarks"].ToString();

                        txtVendorBranch.Text = dt.Rows[i]["VENDOR_BRANCH"].ToString();
                        txtVendorGSTIN.Text = dt.Rows[i]["VENDOR_GSTIN"].ToString();
                       
                        string CrDr = dt.Rows[i]["CR_DR"].ToString();
                        Load_CRDR();



                        ddlCrDr.Items.Remove(CrDr);
                        ddlCrDr.Items.Insert(0, CrDr);
                        txtExrate.Text = dt.Rows[i]["EX_RATE"].ToString();
                        txtCurrency.Text = dt.Rows[i]["CURRENCY"].ToString();
                        txtForeignamt.Text = dt.Rows[i]["FOREIGN_AMOUNT"].ToString();
                        
                        string ClassType = dt.Rows[i]["CLASSIFY_TYPE"].ToString();
                        Load_ClassifyType();
                        ddlClassType.Items.Remove(ClassType);
                        ddlClassType.Items.Insert(0, ClassType);

                        txtTaxAmount.Text = dt.Rows[i]["TAXABLE_AMOUNT"].ToString();
                        txtCgstpercentage.Text = dt.Rows[i]["CGST_PERCENTAGE"].ToString();
                        txtCgstAmount.Text = dt.Rows[i]["CGST_AMOUNT"].ToString();
                        txtSGSTPercentage.Text = dt.Rows[i]["SGST_PERCENTAGE"].ToString();
                        txtSGSTAmount.Text = dt.Rows[i]["SGST_AMOUNT"].ToString();
                        txtIGSTPercentage.Text = dt.Rows[i]["IGST_PERCENTAGE"].ToString();
                        txtIGSTAmount.Text = dt.Rows[i]["IGST_AMOUNT"].ToString();


                        rowIndex++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Alert_msg(string msg)
    {
        
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Expenses Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
      
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Expenses Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //try
        //{
        //if (txtDate.Text != string.Empty)
        //{            

        //    Exp_Ins_Del_Upd("S", "0");

        //    if (i == 1)
        //    {

        //        Alert_msg("Saved Successfully");
        //        //btnNew_Click1(sender, e);
        //    }
        //    else if(i==-1)
        //    {
        //        Alert_msg("Not Saved");
                 
        //    }
        //    else if (i == -100)
        //    {
        //        Alert_msg("This Voucher No Alredy Exists");
        //        txtExpVoucherNo.Focus();

        //    }
        //    else  
        //    {
        //        Alert_msg("Not Saved");
        //        btnNew_Click1(sender, e);
        //    }
        //}
        //}
        //catch (Exception ex)
        //{
        //    Connection.Error_Msg(ex.Message);
        //}
    }

    protected void Before_TotalExpAmt_Calc()
    {
        try
        {
            DataSet dss = new DataSet();
            ObjUBO.MODE = "Select Exp-Payment";
            ObjUBO.Flag = "Select-ExpSingle";
            ObjUBO.FILE_REF_NO = HDupdate_id.Value;
            //dss = BI.Exp_Pay_Search(ObjUBO);
            dss = BI.Exp_Pay_Search(ObjUBO);

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }
    protected void btnSaveRow_Click(object sender, EventArgs e)
    {

        try
        {
            
            if (txtDate.Text != string.Empty)
            {
                //Before_TotalExpAmt_Calc();
                if (txtTotalExpAmt.Text == "")
                { 
                    txtTotalExpAmt.Text = "0"; 
                }
                txtTotalExpAmt.Text = Convert.ToString(Convert.ToDouble(txtTotalExpAmt.Text) + Convert.ToDouble(txtExpAmountRow.Text));

                //if (ddlPaymentRow.Text != "Not Paid")
                //{
                //    if (txtPaidOnRow.Text == "")
                //    {
                //        //Alert_msg("Not Saved Enter Paid On Date Otherwise Choose Payment 'Not Paid' option");
                //        goto NotSaveLoc;
                //    }
                //}

                //**********************

                //**********************
             
                if (HDupdate_id.Value == "")
                {
                    Exp_Ins_Del_Upd("S", "0");

                    if (i > 0)
                    {

                    Alert_msg("Saved Successfully");
                    HDupdate_id.Value = Convert.ToString(i);

                    //Update_Item_Load();
                    Update_Item_Load_Fresh();
                    btnNewRow_Click(sender, e); 
                    }
                    else if (i == -1)
                    {
                        Alert_msg("Not Saved");

                    }
                    else if (i == -100)
                    {
                        Alert_msg("This Voucher No Alredy Exists");
                        txtExpVoucherNo.Focus();

                    }
                    else
                    {
                        Alert_msg("Not Saved");
                        btnNew_Click1(sender, e);
                    }
                }
                else
                {
                    Exp_Ins_Del_Upd("SL", HDupdate_id.Value);

                    if (i == 2)
                    {
                    Alert_msg("Saved Successfully Particular Expense");
                    //btnNew_Click1(sender, e);

                    Update_Item_Load_Fresh();
                    btnNewRow_Click(sender, e); 

                    }
                    else if (i == -1)
                    {
                        Alert_msg("Not Saved");

                    }
                    else if (i == -100)
                    {
                        Alert_msg("This Voucher No Alredy Exists");
                        txtExpVoucherNo.Focus();

                    }
                    else
                    {
                        Alert_msg("Not Saved");
                        btnNew_Click1(sender, e);
                    }
                }
             //   goto NormalPlace;
            }
        //NotSaveLoc: Alert_msg("Not Saved Enter Paid On Date Otherwise Choose Payment 'Not Paid' option");
        //NormalPlace: ;
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
            Before_TotalExpAmt_Calc();
            if (txtTotalExpAmt.Text == "")
            {
                txtTotalExpAmt.Text = "0";
            }
            txtTotalExpAmt.Text = Convert.ToString(Convert.ToDouble(txtTotalExpAmt.Text) + Convert.ToDouble(txtExpAmountRow.Text)); 



            i = Exp_Ins_Del_Upd("U", HDupdate_id.Value);
            if (i == 3)
            {
                Alert_msg("Updated Successfully All Expenses");
                Update_Item_Load_Fresh();
                //btnNew_Click1(sender, e);
            }
            else if (i == -1)
            {
                Alert_msg("Not Saved");

            }
            else
            {
                Alert_msg("Not Updated");
            } 

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnUpdateRow_Click(object sender, EventArgs e)
    {
        try
        {

            Before_TotalExpAmt_Calc();
            if (txtTotalExpAmt.Text == "")
            {
                txtTotalExpAmt.Text = "0";
            }
            txtTotalExpAmt.Text = Convert.ToString(Convert.ToDouble(txtTotalExpAmt.Text) + Convert.ToDouble(txtExpAmountRow.Text)); 


            i = Exp_Ins_Del_Upd("UL", HDupdate_id.Value);
            if (i == 4)
            {
                Alert_msg("Updated Successfully Particular Expense Head ");
                //btnNew_Click1(sender, e);
                Update_Item_Load_Fresh();
                btnNewRow_Click(sender, e); 
            }
            else if (i == -1)
            {
                Alert_msg("Not Saved");

            }
            else
            {
                Alert_msg("Not Updated");
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
            
            //i = Exp_Delete("D", HDupdate_id.Value,hdn_Exp_SubID.Value);

                              
                //////////////////////////////////////Delete files and folders one by one Start
                DataSet dss = new DataSet();
                ObjUBO.MODE = "Select Exp-Payment";
                ObjUBO.Flag = "Select-ExpSingle";
                ObjUBO.FILE_REF_NO = HDupdate_id.Value;                


                dss = BI.Exp_Pay_Search(ObjUBO);

                if (dss.Tables[1].Rows.Count > 0)
                {
                    for (int r = 0; r < dss.Tables[1].Rows.Count; r++)
                    {
                        hdn_ATTACHMENT_FILE.Value = dss.Tables[1].Rows[r]["ATTACHMENT_FILE"].ToString();
                        hdn_FILE_PATH.Value = dss.Tables[1].Rows[r]["FILE_PATH"].ToString();
                        if (hdn_ATTACHMENT_FILE.Value != "")
                        {
                            FileInfo file = new FileInfo(hdn_ATTACHMENT_FILE.Value);
                            if (file.Exists) //check file exsit or not
                            {
                                file.Delete();
                            }
                            //if (Directory.Exists(hdn_FILE_PATH.Value) == true)   //check folder exsit or not
                            //{
                            //    Directory.Delete(hdn_FILE_PATH.Value);
                            //}
                        }
                    }
                }

                //finYear = Connection.WorkingPeriod();
                //expMainRootfolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "Expense_Entry" + "/" + finYear + "/" + HDupdate_id.Value + "/");
                //if (Directory.Exists(expMainRootfolder) == true)   //check Main folder exsit or not
                //{
                //    Directory.Delete(expMainRootfolder);
                //}
                //////////////////////////////////////Delete files and folders one by one End
                ObjUBO.ID = HDupdate_id.Value;  
                ObjUBO.Flag = "D";
                //BI.ExpIDU_V3(ObjUBO);
                //BI.ExpIDU_V4(ObjUBO);
                BI.ExpIDU_V5(ObjUBO);
                i = BI.result;

            ////////////////////
          
            if (i == 5)
            {

                btnNew_Click1(sender, e);
                Alert_msg("Deleted");

                btnrpt.Visible = false;
            }
            else
            {
                Alert_msg("Not Deleted");
            }
            btnNew_Click1(sender, e);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnDeleteRow_Click(object sender, EventArgs e)
    {
        try
        {

            //i = Exp_Delete("DL", HDupdate_id.Value, hdn_Exp_SubID.Value);
            ///////////////////////////////////////////////////////////////


            ObjUBO.ID = HDupdate_id.Value;
            ObjUBO.Flag = "DL";
            ObjUBO.Exp_SubID = hdn_Exp_SubID.Value; 

            //BI.ExpIDU_V3(ObjUBO);
            //BI.ExpIDU_V4(ObjUBO);
            BI.ExpIDU_V5(ObjUBO);
            i = BI.result;


            ///////////////////////////////////////////////////////////////

            if (i == 6)
            {

                //btnNew_Click1(sender, e);                
                //////////////////////////////Delete file folder start   hdn_ATTACHMENT_FILE
                if (hdn_ATTACHMENT_FILE.Value != "")
                {
                    FileInfo file = new FileInfo(hdn_ATTACHMENT_FILE.Value);
                    if (file.Exists) //check file exsit or not
                    {
                        file.Delete();
                    }
                   // if (Directory.Exists(hdn_FILE_PATH.Value) == true)   //check folder exsit or not
                   // {
                   //     Directory.Delete(hdn_FILE_PATH.Value);
                   // }
                }
                //////////////////////////////Delete file folder end
                Alert_msg("Particular Expense Head Deleted");
                //Update_Item_Load();
                Update_Item_Load_Fresh();
                //btnrpt.Visible = false;
                btnNewRow_Click(sender, e);

                Before_TotalExpAmt_Calc();// Change After_TotalExpAmt_Calc

                
            }
            else
            {
                Alert_msg("Not Deleted");
            }
            //btnNew_Click1(sender, e);
            btnNewRow_Click(sender, e);
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    protected void btnSingleFileDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (hdn_ATTACHMENT_FILE.Value != "")
            {
                FileInfo file = new FileInfo(hdn_ATTACHMENT_FILE.Value);
                if (file.Exists) //check file exsit or not
                {
                    file.Delete();
                }

               // if (Directory.Exists(hdn_FILE_PATH.Value) == true)   //check folder exsit or not
               // {
               //     Directory.Delete(hdn_FILE_PATH.Value);
               // }
               // FileUpload1.Visible = true;
               // btnUploadRow.Visible = true;

                lbtnImageFileRow.Text = "No File";                
                chkImageFileRow.Visible = false;
                hdn_FILE_IMAGE_NAME.Value = "";
                hdn_FILE_PATH.Value = "";
                hdn_ATTACHMENT_FILE.Value = "";

            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    public int Exp_Ins_Del_Upd_OLD(string I_Name, string expid)
    {

        ConvertGrid_Datatable(gv);
        DataTable dt;
        dt = (DataTable)ViewState["CurrentTable"];
        if (dt.Rows.Count > 0)
        {

            if (I_Name == "S")
            {
                ObjUBO.ID = expid;
                ObjUBO.Flag = "S";
            }
            else if (I_Name == "D")
            {
                ObjUBO.ID = HDupdate_id.Value;
                ObjUBO.Flag = "D";
            }
            else if (I_Name == "U")
            {
                ObjUBO.ID = HDupdate_id.Value;
                ObjUBO.Flag = "U";
            }
            ObjUBO.ExpVoucherNo = txtExpVoucherNo.Text;
            ObjUBO.BILL_INV_DATE = txtDate.Text;
            if (Rd_Job_Type.SelectedIndex == 0)
                ObjUBO.BILL_TYPE = "Imp";
            else if (Rd_Job_Type.SelectedIndex == 1)
                ObjUBO.BILL_TYPE = "Exp";


            ObjUBO.IMPORTER_NAME = txtCustName.Text;
            ObjUBO.Ref_ID = ddljobno.SelectedValue.ToString();  // for JOb ID
            // ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
            //ObjUBO.JOBNO = ddljobno.SelectedItem.Text.Trim();  // Job no
            ObjUBO.JOBNO = ddljobno.SelectedItem.Text;  // Job no
            ObjUBO.BRANCH_CODE = ddlbranch_No.SelectedValue.ToString();

            ObjUBO.TOTAL_TAX_AMT = txtTotalExpAmt.Text;
            ObjUBO.REMARKS = txtCommNarration.Text;
            ObjUBO.FILE_REF_NO = txtFileRefNo.Text;
            ObjUBO.BASED_ON = ddltype.SelectedItem.Text;
            ObjUBO.SEARCH_CONTENT = ddlSearch.SelectedItem.Text;
            ObjUBO.Branch_No = txtBranchSlNo.Text;



            BI.ExpIDU_V2(ObjUBO, dt);

            i = BI.result;
        }
        else
        {
            i = -1;
        }

        return i;
    }
    public int Exp_Ins_Del_Upd(string I_Name, string expid)
    {
            if (I_Name == "S")
            {
                ObjUBO.ID = expid;
                //ObjUBO.ID = HDupdate_id.Value;
                ObjUBO.Flag = "S";

                ObjUBO.Exp_SubID = "0";
            }
            else if (I_Name == "SL")
            {
                ObjUBO.ID = HDupdate_id.Value;
                ObjUBO.Flag = "SL";
                ObjUBO.Exp_SubID = "0";
            }

            else if (I_Name == "U")
            {
                ObjUBO.ID = HDupdate_id.Value;
                ObjUBO.Flag = "U";
                ObjUBO.Exp_SubID = hdn_Exp_SubID.Value;
            }
            else if (I_Name == "UL")
            {
                ObjUBO.ID = HDupdate_id.Value;
                ObjUBO.Flag = "UL";
                ObjUBO.Exp_SubID = hdn_Exp_SubID.Value;
            }

            ObjUBO.ExpVoucherNo = txtExpVoucherNo.Text;
            ObjUBO.BILL_INV_DATE = txtDate.Text;
            if (Rd_Job_Type.SelectedIndex == 0)
                ObjUBO.BILL_TYPE = "Imp";
            else if (Rd_Job_Type.SelectedIndex == 1)
                ObjUBO.BILL_TYPE = "Exp";


            ObjUBO.IMPORTER_NAME = txtCustName.Text;
            ObjUBO.Ref_ID = ddljobno.SelectedValue.ToString();  // for JOb ID
            // ObjUBO.JOBNO = ddljobno.SelectedValue.ToString();
            //ObjUBO.JOBNO = ddljobno.SelectedItem.Text.Trim();  // Job no
            //ObjUBO.JOBNO = ddljobno.SelectedItem.Text;  // Job no original
            //ObjUBO.JOBNO = ddljobno.SelectedItem.ToString();
            if (ddljobno.SelectedValue.ToString() == null || ddljobno.SelectedValue.ToString() == "") 
                ObjUBO.JOBNO = txtjobno.Text;
            else
                ObjUBO.JOBNO = ddljobno.SelectedItem.Text;
            
            ObjUBO.BRANCH_CODE = ddlbranch_No.SelectedValue.ToString();

            ObjUBO.TOTAL_TAX_AMT = txtTotalExpAmt.Text;
            ObjUBO.REMARKS = txtCommNarration.Text;
            ObjUBO.FILE_REF_NO = txtFileRefNo.Text;
            ObjUBO.BASED_ON = ddltype.SelectedItem.Text;
            ObjUBO.SEARCH_CONTENT = ddlSearch.SelectedItem.Text;
            ObjUBO.Branch_No = txtBranchSlNo.Text;

            ObjUBO.STAFF_NAME_MAIN = ddltype.SelectedItem.Text == "Staff Name" ? ddlSearch.SelectedItem.Text : "";
            ObjUBO.EXPENSE_HEAD = ddltype.SelectedItem.Text == "Expense Head" ? ddlSearch.SelectedItem.Text : "";
            ObjUBO.BILL_INV_NO = ddltype.SelectedItem.Text == "Inv No" ? ddlSearch.SelectedItem.Text : "";
            ObjUBO.GENERAL = ddltype.SelectedItem.Text == "General" ? ddlSearch.SelectedItem.Text : "";
            ObjUBO.JOB_INFO=txtJobInfo.Text;





            //ObjUBO.Exp_SubID = hdn_Exp_SubID.Value;
            ObjUBO.Exp_Details=txtExpDetailsRow.Text;
            ObjUBO.Ref_VoucherNo=txtRefVoucherNoRow.Text;

            ObjUBO.Exp_Amount=txtExpAmountRow.Text;
            ObjUBO.PaymentMode=ddlPaymentRow.Text;
            ObjUBO.Remarks=txtRemarksRow.Text;
            ObjUBO.GivenBy=txtGivenByRow.Text;
            ObjUBO.Assignee=txtAssigneeRow.Text;
            ObjUBO.PAID_ON=txtPaidOnRow.Text;
            ObjUBO.STAFF_NAME=txtStaffNameRow.Text;




            if (hdn_BROWSE_UPLOADED.Value != "1")
            {
                if (lbtnImageFileRow.Text == "No File" || lbtnImageFileRow.Text == "View File")
                {
                    ObjUBO.FILE_IMAGE_NAME = "";
                }
                else
                {
                    ObjUBO.FILE_IMAGE_NAME = lbtnImageFileRow.Text;
                    
                }
                ObjUBO.FILE_PATH = hdn_FILE_PATH.Value;
                ObjUBO.ATTACHMENT_FILE = hdn_ATTACHMENT_FILE.Value;
            }
            else
            {
                ObjUBO.FILE_IMAGE_NAME = hdn_FILE_IMAGE_NAME.Value;
                ObjUBO.FILE_PATH = hdn_FILE_PATH.Value;
                ObjUBO.ATTACHMENT_FILE = hdn_ATTACHMENT_FILE.Value;
                lbtnImageFileRow.Visible = false;
                
            }
            ObjUBO.VENDOR_BRANCH = txtVendorBranch.Text;
            ObjUBO.VENDOR_GSTIN = txtVendorGSTIN.Text;
            ObjUBO.CR_DR = ddlCrDr.SelectedItem.ToString();
            //ObjUBO.EX_RATE = txtExrate.Text;
            ObjUBO.EX_RATE = string.IsNullOrEmpty(txtExrate.Text) ? "0" : txtExrate.Text;
            ObjUBO.CURRENCY = txtCurrency.Text;            
            ObjUBO.TAXABLE_AMOUNT = txtTaxAmount.Text;
            ObjUBO.CLASSIFY_TYPE = ddlClassType.SelectedItem.ToString();
            //ObjUBO.FOREIGN_AMOUNT = txtForeignamt.Text;
            ObjUBO.FOREIGN_AMOUNT = string.IsNullOrEmpty(txtForeignamt.Text) ? "0" : txtForeignamt.Text;

            ObjUBO.CGST_PERCENTAGE = string.IsNullOrEmpty(txtCgstpercentage.Text) ? "0" : txtCgstpercentage.Text;
            ObjUBO.CGST_AMOUNT = string.IsNullOrEmpty(txtCgstAmount.Text) ? "0" : txtCgstAmount.Text  ;
            ObjUBO.SGST_PERCENTAGE = string.IsNullOrEmpty(txtSGSTPercentage.Text) ? "0" : txtSGSTPercentage.Text;
            ObjUBO.SGST_AMOUNT = string.IsNullOrEmpty(txtSGSTAmount.Text) ? "0" : txtSGSTAmount.Text;
            ObjUBO.IGST_PERCENTAGE = string.IsNullOrEmpty(txtIGSTPercentage.Text) ? "0" : txtIGSTPercentage.Text;
            ObjUBO.IGST_AMOUNT = string.IsNullOrEmpty(txtIGSTAmount.Text) ? "0" : txtIGSTAmount.Text;
           
            //BI.ExpIDU_V3(ObjUBO);
            //BI.ExpIDU_V4(ObjUBO);
            BI.ExpIDU_V5(ObjUBO);

            i = BI.result;

        return i;
    }

    public int Exp_Delete(string I_Name, string expid,string hdn_Exp_SubID)
    {
         //Old coding Starting       
        
            //// DataTable dt = new DataTable();
            //DataTable dt = (DataTable)ViewState["CurrentTable"];
            //ObjUBO.ID = HDupdate_id.Value;
            //ObjUBO.Flag = "D";


            ////BI.ExpIDU(ObjUBO, dt);
            //BI.ExpIDU_V2(ObjUBO, dt);
            //i = BI.result;
            //return i;
        //Old coding Ending

        if (hdn_Exp_SubID != "")
        {
            ObjUBO.ID = HDupdate_id.Value;
            ObjUBO.Flag = "DL";
        }
        else
        {
            ObjUBO.ID = HDupdate_id.Value;
            ObjUBO.Flag = "D";
        }
        
        
        //BI.ExpIDU_V3(ObjUBO);
        //BI.ExpIDU_V4(ObjUBO);
        BI.ExpIDU_V5(ObjUBO);
        i = BI.result;
        return i;

        
    }

  
    private void Clear()
    {

        ddljobno.Items.Clear();
    
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

            //  if Read Permiision given true for gridview enabled or Disabled----------//

          //if (hdn_Grid_Disable.Value == "1")
          //  {
          //      e.Row.Enabled = false;
          //  }
          //  else
           // {
                e.Row.Enabled = true;

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
                e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv, "Select$" + e.Row.RowIndex.ToString()));

            //}
            //  if Read Permiision given true for gridview enabled or Disabled----------//


        //}

                //string MINDATE = "01/01/1900";

                //if (e.Row.Cells[5].Text == MINDATE)
                //{
                //    if (Convert.ToDateTime(e.Row.Cells[5].Text) <= Convert.ToDateTime(MINDATE))
                //        e.Row.Cells[5].Text = string.Empty;
                //}

    }

    


 
    private void load_Imp_name()
    {
        try
        {
            

            //DataSet dss = new DataSet();
            //ObjUBO.Flag = "Imp_Name_Select";
            //if (COMPANY_LICENSE == "eri00247")
            //{
            //    DataSet ds = new DataSet();
            //    if (Session["COMPANY_DETAILS_DS"] != null)
            //    {
            //        ds = (DataSet)Session["COMPANY_DETAILS_DS"];

            //        DataTable ds3 = new DataTable();
            //        ds3 = ds.Tables[2];
            //        DataView view1 = ds3.DefaultView;
            //        string a = ddlWorkingPeriod.SelectedValue.ToString();
            //        view1.RowFilter = "WORKING_PERIOD = '" + a + "'";
            //        DataTable table1 = view1.ToTable();
            //        //-----------------------------------------------------------------//
            //        dss = BI.Select_IMP_INV(ObjUBO, table1.Rows[0]["SERVER_NAME"].ToString());
            //    }
            //}
            //else
            //{
            //    dss = BI.Select_IMP_INV(ObjUBO);
            //}

            //if (dss.Tables[0].Rows.Count > 0)
            //{
                
            //}
            //else
            //{
            //     ddl_clear();
            //}
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    } 
   
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

 
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Exp_Details", typeof(string)));
        dt.Columns.Add(new DataColumn("Ref_VoucherNo", typeof(string)));
        dt.Columns.Add(new DataColumn("Exp_Amount", typeof(string)));

        dt.Columns.Add(new DataColumn("PaymentMode", typeof(string)));
        dt.Columns.Add(new DataColumn("PAID_ON", typeof(string)));
        dt.Columns.Add(new DataColumn("STAFF_NAME", typeof(string)));
        
        dt.Columns.Add(new DataColumn("GivenBy", typeof(string)));
        dt.Columns.Add(new DataColumn("Assignee", typeof(string)));
        dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        dt.Columns.Add(new DataColumn("FILE_IMAGE_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("FILE_PATH", typeof(string)));
        dt.Columns.Add(new DataColumn("ATTACHMENT_FILE", typeof(string)));
        dt.Columns.Add(new DataColumn("FILE_REF_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("EXP_SUBID", typeof(string)));
        dt.Columns.Add(new DataColumn("EXP_ID", typeof(string)));
        dt.Columns.Add(new DataColumn("VENDOR_BRANCH", typeof(string)));
        dt.Columns.Add(new DataColumn("VENDOR_GSTIN", typeof(string)));
        dt.Columns.Add(new DataColumn("CR_DR", typeof(string)));
        dt.Columns.Add(new DataColumn("EX_RATE", typeof(string)));
        dt.Columns.Add(new DataColumn("CURRENCY", typeof(string)));
        dt.Columns.Add(new DataColumn("FOREIGN_AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("CLASSIFY_TYPE", typeof(string)));
        dt.Columns.Add(new DataColumn("TAXABLE_AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("CGST_PERCENTAGE", typeof(string)));
        dt.Columns.Add(new DataColumn("CGST_AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("SGST_PERCENTAGE", typeof(string)));
        dt.Columns.Add(new DataColumn("SGST_AMOUNT", typeof(string)));
        dt.Columns.Add(new DataColumn("IGST_PERCENTAGE", typeof(string)));
        dt.Columns.Add(new DataColumn("IGST_AMOUNT", typeof(string)));

        

        dr = dt.NewRow();
       
        dr["RowNumber"] = 1;
        dr["Exp_Details"] = string.Empty;
        dr["Ref_VoucherNo"] = string.Empty;
        dr["Exp_Amount"] = "0";
        dr["PaymentMode"] = string.Empty;
        dr["PAID_ON"] = string.Empty;
        dr["STAFF_NAME"] = string.Empty;
        dr["Remarks"] = string.Empty;
        dr["GivenBy"] = string.Empty;
        dr["Assignee"] = string.Empty;        
        dr["FILE_IMAGE_NAME"] = string.Empty;

        dr["FILE_PATH"] = string.Empty;
        dr["ATTACHMENT_FILE"] = string.Empty;
        dr["FILE_REF_NO"] = string.Empty;

        dr["EXP_SUBID"] = string.Empty;
        dr["EXP_ID"] = string.Empty;
        dr["VENDOR_BRANCH"] = string.Empty;
        dr["VENDOR_GSTIN"] = string.Empty;
        dr["CR_DR"] = string.Empty;
        dr["EX_RATE"] = string.Empty;
        dr["CURRENCY"] = string.Empty;
        dr["FOREIGN_AMOUNT"] = string.Empty;
        dr["CLASSIFY_TYPE"] = string.Empty;
        dr["TAXABLE_AMOUNT"] = string.Empty;
        dr["CGST_PERCENTAGE"] = string.Empty;
        dr["CGST_AMOUNT"] = string.Empty;
        dr["SGST_PERCENTAGE"] = string.Empty;
        dr["SGST_AMOUNT"] = string.Empty;
        dr["IGST_PERCENTAGE"] = string.Empty;
        dr["IGST_AMOUNT"] = string.Empty;


        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        gv.DataSource = dt;
        gv.DataBind();

        btnNewRow.Visible = true;
        btnSaveRow.Visible = true;
        btnUpdateRow.Visible = false;
        btnDeleteRow.Visible = false;

        FileUpload1.Visible = false;
        btnUploadRow.Visible = false;


        chkImageFileRow.Visible = false;
        lbtnImageFileRow.Visible = false;
 
    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;
        Gridbind_ExpenseHead();
    }    

    protected void gv_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["EXP_SUBID"] = Convert.ToString(this.gv.SelectedDataKey.Value);
        if (ViewState["EXP_SUBID"] != "" && ViewState["EXP_SUBID"] != null)
        {
            //sno = gv.SelectedRow.Cells[2].Text;
            //ViewState["IGMSLNO"] = sno;
            //Session["IGMSLNO"] = sno;

            //txtIGMNo.Text = gv_IGM.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

            //ViewState["IGMNO"] = txtIGMNo.Text;
            //Session["IGMNO"] = txtIGMNo.Text;
            //txtIGMDate.Text = gv_IGM.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");
            //Session["IGMDATE"] = txtIGMDate.Text;
            
            txtExpDetailsRow.Text = gv.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");            
            txtRefVoucherNoRow.Text = gv.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txtExpAmountRow.Text = gv.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            if (gv.SelectedRow.Cells[7].Text.Replace("&nbsp;", "") != "")
            {
                ddlPaymentRow.Text = gv.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                if (ddlPaymentRow.Text != "Not Paid")
                {
                    ddlPaymentRow.Enabled = false;
                    txtPaidOnRow.Enabled = false;
                }
                else
                {
                    ddlPaymentRow.Enabled = true;
                    txtPaidOnRow.Enabled = true;
                }
            }
            else
            {
                ddlPaymentRow.Text = "Not Paid";
                ddlPaymentRow.Enabled = true;
                txtPaidOnRow.Enabled = true;
            }


            txtPaidOnRow.Text = gv.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            txtStaffNameRow.Text = gv.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            txtGivenByRow.Text = gv.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            txtAssigneeRow.Text = gv.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            txtRemarksRow.Text = gv.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
            lbtnImageFileRow.Text = gv.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");

            hdn_FILE_IMAGE_NAME.Value  =lbtnImageFileRow.Text;

            if (lbtnImageFileRow.Text == "")
            {
                lbtnImageFileRow.Text = "No File";
                lbtnImageFileRow.Visible = true;// This true is correct 
                //lbtnImageFileRow.Visible = false;// This true is not correct 
                lbtnImageFileRow.Enabled = false;                
                chkImageFileRow.Visible = false;

                FileUpload1.Visible = true;
                btnUploadRow.Visible = true;

            }
            else
            {
                lbtnImageFileRow.Visible = true;
                lbtnImageFileRow.Enabled = true;                
                chkImageFileRow.Visible = true;

                FileUpload1.Visible = false;
                btnUploadRow.Visible = false;

            }


            hdn_FILE_PATH.Value = gv.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            hdn_ATTACHMENT_FILE.Value = gv.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
            hdn_FILE_REF_NO.Value = gv.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");

            hdn_Exp_SubID.Value  = gv.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
            hdn_Exp_ID.Value = gv.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");
            txtVendorBranch.Text = gv.SelectedRow.Cells[19].Text.Replace("&nbsp;", "");
            txtVendorGSTIN.Text = gv.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");
            
               // ddlCrDr.SelectedValue = gv.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");
            string CrDr = gv.SelectedRow.Cells[21].Text.Replace("&nbsp;", "");
            Load_CRDR();
            ddlCrDr.Items.Remove(CrDr);
            ddlCrDr.Items.Insert(0, CrDr);

            txtExrate.Text = gv.SelectedRow.Cells[22].Text.Replace("&nbsp;", "");
            txtCurrency.Text = gv.SelectedRow.Cells[23].Text.Replace("&nbsp;", "");
            txtForeignamt.Text = gv.SelectedRow.Cells[24].Text.Replace("&nbsp;", "");
            //ddlClassType.SelectedValue = gv.SelectedRow.Cells[24].Text.Replace("&nbsp;", "");
            string ClassType = gv.SelectedRow.Cells[25].Text.Replace("&nbsp;", "");
            Load_ClassifyType();
            ddlClassType.Items.Remove(ClassType);
            ddlClassType.Items.Insert(0, ClassType);

            txtTaxAmount.Text = gv.SelectedRow.Cells[26].Text.Replace("&nbsp;", "");
           
            txtCgstpercentage.Text = gv.SelectedRow.Cells[27].Text.Replace("&nbsp;", "");
            txtCgstAmount.Text = gv.SelectedRow.Cells[28].Text.Replace("&nbsp;", "");
            txtSGSTPercentage.Text = gv.SelectedRow.Cells[29].Text.Replace("&nbsp;", "");
            txtSGSTAmount.Text = gv.SelectedRow.Cells[30].Text.Replace("&nbsp;", "");
           
            txtIGSTPercentage.Text = gv.SelectedRow.Cells[31].Text.Replace("&nbsp;", "");
            txtIGSTAmount.Text = gv.SelectedRow.Cells[32].Text.Replace("&nbsp;", "");
            


            btnSaveRow.Visible = false;
            btnDeleteRow.Visible = true;
            btnUpdateRow.Visible = true;

            //FileUpload1.Visible = true;
            //btnUploadRow.Visible = true;


        }


        //////////////////////////////////////////////////////
        //ViewState["IGM_ID"] = Convert.ToString(this.gv_IGM.SelectedDataKey.Value);

        //if (ViewState["IGM_ID"] != "" && ViewState["IGM_ID"] != null)
        //{
        //    sno = gv_IGM.SelectedRow.Cells[2].Text;
        //    ViewState["IGMSLNO"] = sno;
        //    Session["IGMSLNO"] = sno;

        //    txtIGMNo.Text = gv_IGM.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");

        //    ViewState["IGMNO"] = txtIGMNo.Text;
        //    Session["IGMNO"] = txtIGMNo.Text;
        //    txtIGMDate.Text = gv_IGM.SelectedRow.Cells[4].Text.Replace("01/01/1900", "");
        //    Session["IGMDATE"] = txtIGMDate.Text;

        //    txtAirlineName.Text = rep.Replace(gv_IGM.SelectedRow.Cells[5].Text);
        //    txtFlightVesselNo.Text = gv_IGM.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
        //    txtFlightVesselDate.Text = gv_IGM.SelectedRow.Cells[7].Text.Replace("01/01/1900", "");


        //    txtMAWBMBLNo.Text = gv_IGM.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
        //    txtMAWBMBLDate.Text = gv_IGM.SelectedRow.Cells[9].Text.Replace("01/01/1900", "");

        //    txtHAWBHBLNo.Text = gv_IGM.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
        //    txtHAWBHBLDate.Text = gv_IGM.SelectedRow.Cells[11].Text.Replace("01/01/1900", "");

        //    txtAirlineCode.Text = rep.Replace(gv_IGM.SelectedRow.Cells[12].Text.Replace("&nbsp;", ""));

        //    txtPackages.Text = gv_IGM.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");

        //    txtPackageType.Text = gv_IGM.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");


        //    txtGrossWeight.Text = gv_IGM.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");

        //    txtGrossWeightType.Text = gv_IGM.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");

        //    txtNetWeight.Text = gv_IGM.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
        //    txtNetWeightType.Text = gv_IGM.SelectedRow.Cells[18].Text.Replace("&nbsp;", "");

        //    txtMarksNos.Text = rep.Replace(gv_IGM.SelectedRow.Cells[19].Text);

        //    txtGateway_Igm_No.Text = gv_IGM.SelectedRow.Cells[20].Text.Replace("&nbsp;", "");
        //    txtGateway_Igm_Date.Text = gv_IGM.SelectedRow.Cells[21].Text.Replace("01/01/1900", "");
        //    txtGateway_Port_Code.Text = gv_IGM.SelectedRow.Cells[22].Text.Replace("&nbsp;", "");

        //    txt_LineNumber.Text = gv_IGM.SelectedRow.Cells[24].Text.Replace("&nbsp;", "");
        //    txt_ShippingLine.Text = gv_IGM.SelectedRow.Cells[25].Text.Replace("&nbsp;", "");
        //    txt_Voyage.Text = gv_IGM.SelectedRow.Cells[26].Text.Replace("&nbsp;", "");

        //    if (Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00247" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00004" || Session["COMPANY_LICENSE"].ToString().ToLower() == "eri00010")
        //    {
        //        ddlhrs_FV_dat.SelectedValue = gv_IGM.SelectedRow.Cells[27].Text.Replace("&nbsp;", "");
        //        ddlMin_FV_dat.SelectedValue = gv_IGM.SelectedRow.Cells[28].Text.Replace("&nbsp;", "");
        //    }

        //    txtChargable_Wgt.Text = gv_IGM.SelectedRow.Cells[29].Text.Replace("&nbsp;", "");
        //    txt_RotationNo.Text = gv_IGM.SelectedRow.Cells[30].Text.Replace("&nbsp;", "");
        //    txt_Rotation_Date.Text = gv_IGM.SelectedRow.Cells[31].Text.Replace("&nbsp;", "");

        //    //FOR UPDATED SUCCESSFULLY
        //    ViewState["UPDATED_ID"] = null;
        //    ViewState["UPDATED_ID"] = ViewState["IGMSLNO"].ToString();
        //    //FOR UPDATED SUCCESSFULLY
        //    btnUpdate.CssClass = "updates";

        //    btnDelete.Visible = true;
        //    btnUpdate.Visible = true;
        //    btnSave.Visible = false;
        //    btnNew.Visible = true;
        //    if (hdn_Transport_Mode.Value == "Land" || hdn_Transport_Mode.Value == "Sea")
        //    {
        //        CONTAINER.Style.Add("display", "block");
        //    }
        //    else
        //    {
        //        CONTAINER.Style.Add("display", "none");

        //    }
        //}
        //else
        //{
        //    btnDelete.Visible = false;

        //    btnUpdate.Visible = false;
        //    btnSave.Visible = true;
        //    btnNew.Visible = true;
        //}

    }
    public void Gridbind_ExpenseHead()
    {
        //Transact.JOBNO = IMPORT_JOBNO;

        //Transact.TRANSPORT_MODE = IGM_Transportmode;
        ////Transact.WORKING_PERIOD = Working_Period;
        //Transact.WORKING_PERIOD = @SELECT_BRANCH;
        ////Transact.flag = "";

        //Transact.IGM_SLNO_UPDATE = "0";

        //Transact.Ename = "select_con";
        //gv_IGM.DataSource = Transact.RetrieveAll_IGM_Details();
        //gv_IGM.DataBind();

        //if (gv_IGM.Rows.Count > 0)
        //{
        //    ViewState["IGM_ID"] = gv_IGM.Rows[0].Cells[23].Text.Replace("&nbsp;", "");

        //    IGM_Edit_UpdateDetails();
        //}
        ////dss = Transact.RetrieveAll_IGM_Details();
        ////Grid_Empty();
    }

    protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try{
         
            if (gv.Rows.Count > 1)
            {
                ConvertGrid_Datatable(gv);
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                int rowIndex = Convert.ToInt32(e.RowIndex);
                
                dt.Rows.Remove(dt.Rows[rowIndex]);
                ViewState["CurrentTable"] = dt;

                gv.DataSource = dt;
                gv.DataBind();

            }
            else if (gv.Rows.Count == 1)
            {
                SetInitialRow();
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
        decimal gst_total = 0;
        DataTable dt;
        DataRow dr;
        int R = 1;
        dt = (DataTable)ViewState["CurrentTable"];
        if (dt.Rows.Count > 0)
        {
            dt.Rows.Clear();
        }

         

        foreach (GridViewRow row in gg.Rows)
        {

            TextBox txtExpDetails1 = (TextBox)row.FindControl("txtExpDetails");
            TextBox txtRefVoucherNo1 = (TextBox)row.FindControl("txtRefVoucherNo");
            TextBox txtExpAmount1 = (TextBox)row.FindControl("txtExpAmount");
           // DropDownList ddl_PayMode1 = (DropDownList)row.FindControl("ddl_PayMode"); //Cells[4].FindControl("ddl_PayMode");
            DropDownList ddl_PayMode1 = (DropDownList)row.Cells[4].FindControl("ddl_PayMode"); //Cells[4].FindControl("ddl_PayMode");
            TextBox txtRemarks1 = (TextBox)row.FindControl("txtRemarks");
            TextBox txtGivenBy1 = (TextBox)row.FindControl("txtGivenBy");
            TextBox txtAssignee1 = (TextBox)row.FindControl("txtAssignee");
           

            if (txtExpAmount1.Text.Trim() == "" || txtExpAmount1.Text.Trim() == string.Empty)
            {
                txtExpAmount1.Text = "0";
            }

            if (txtExpAmount1.Text == "0" || txtExpDetails1.Text.Trim() == "" || txtExpDetails1.Text.Trim() == string.Empty || txtGivenBy1.Text.Trim() == "" || txtGivenBy1.Text.Trim() == string.Empty || txtAssignee1.Text.Trim() == "" || txtAssignee1.Text.Trim() == string.Empty)
            {
                Alert_msg("Enter Expenses Details ");
                return;
            }

            gst_total = gst_total + (Convert.ToDecimal(txtExpAmount1.Text));


            if (txtExpDetails1.Text.Trim() == string.Empty && txtExpAmount1.Text.Trim() == string.Empty)
            {

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = R;
                dr[1] = txtExpDetails1.Text;
                dr[2] = txtRefVoucherNo1.Text;
                dr[3] = txtExpAmount1.Text;
                dr[4] = ddl_PayMode1.SelectedValue.ToString();
                dr[5] = txtRemarks1.Text;
                dr[6] = txtGivenBy1.Text;
                dr[7] = txtAssignee1.Text;
                dt.Rows.Add(dr);
                R = R + 1;
            }
        }

        txtTotalExpAmt.Text = gst_total.ToString(); 

        ViewState["CurrentTable"]=dt;

        } 
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }


    

    protected void btnUploadRow_Click(object sender, EventArgs e)
    {
        HttpFileCollection fileCollection = Request.Files;

        for (int i = 0; i < fileCollection.Count; i++)
        {
            HttpPostedFile uploadfile = fileCollection[i];
            fileName = Path.GetFileName(uploadfile.FileName);
            string ext = Path.GetExtension(uploadfile.FileName).ToLower();
            if (ext == ".sb" || ext == ".be" || ext == ".rtf" || ext == ".txt" || ext == ".doc" || ext == ".docx" || ext == ".xml" || ext == ".html" || ext == ".htm" || ext == ".xls" || ext == ".xlsx" || ext == ".pdf" || ext == ".jpg" || ext == ".jpeg" || ext == ".zip" || ext == ".rar" || ext == ".png" || ext == ".gif")
            {
                if (uploadfile.ContentLength > 0)
                {
                    if (uploadfile.ContentLength < 1048576)
                    {

                        //string file = Request["jobno"].ToString() + "~~" + fileName;
                        
                        ////string file = fileName;
                        ////string path = errorFolder + file;
                        ////jh.FLAG = "File_Exists";
                        ////jh.DESCRIPTION = errorFolder;
                        ////jh.ATTACHMENT_FILE = file;
                        ////jh.JOB_ID = "";
                        ////Upload_Flag = "UPLOAD";
                        
                        ////hdn_BROWSE_UPLOADED.Value = "1";
                        ////hdn_FILE_IMAGE_NAME.Value = fileName;
                        ////lbtnImageFileRow.Text = fileName;
                        ////lbtnImageFileRow.Visible = true;

                        if (hdn_Exp_ID.Value != "" && hdn_Exp_SubID.Value != "")
                        {
                            string file = fileName;
                            finYear = Connection.WorkingPeriod();
                            errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "Expense_Entry" + "/" + finYear + "/" + hdn_Exp_ID.Value + "/" + hdn_Exp_SubID.Value + "/");
                            string path = errorFolder;
                            if (Directory.Exists(path) == false)
                            {
                                Directory.CreateDirectory(path);
                                
                            }
                            hdn_BROWSE_UPLOADED.Value = "1";
                            hdn_FILE_IMAGE_NAME.Value = fileName;
                            lbtnImageFileRow.Text = fileName;
                            lbtnImageFileRow.Visible = true;

                            hdn_FILE_PATH.Value = path;
                            hdn_ATTACHMENT_FILE.Value = path + fileName;
                            uploadfile.SaveAs(hdn_ATTACHMENT_FILE.Value);

                            FileUpload1.Visible = false;
                            btnUploadRow.Visible = false;
                        }
                        else
                        {
                            Alert_msg(fileName + " File not Uploaded.");
                        }
                                
                        



                        //Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, jh.ATTACHMENT_FILE);

                        //if (jh.result == 1)
                        //{
                        //    Alert_msg("File already exists! Please Try another one file for upload");

                        //}
                        //else
                        //{
                        //    uploadfile.SaveAs(errorFolder + file);
                        //    //txtItem_TextChanged(sender, e);
                        //}
                    }
                    else
                    {
                    }
                }
                else
                {
                    Alert_msg("File cannot be empty");
                }
            }
            else
                Alert_msg(ext + " File format not allowed.");
        }
    }

    protected void lbtnImageFileRow_Download_Click(object sender, EventArgs e)
    {
        LinkButton lnkbtn = sender as LinkButton;
        //GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
        if (lnkbtn.Text != "" && lnkbtn.Text != "&nbsp;" && hdn_Exp_ID.Value != "" && hdn_Exp_SubID.Value != "" && hdn_ATTACHMENT_FILE.Value != "" && hdn_FILE_PATH.Value != "" && hdn_FILE_IMAGE_NAME.Value  != "")
        {
            ////System.IO.FileInfo file = new System.IO.FileInfo(errorFolder + jh.JOBNO + "~~" + lnkbtn.Text);
            ////string filePath = errorFolder + jh.JOBNO + "~~" + lnkbtn.Text;
            ////string ext = Path.GetExtension(file.Name).ToLower();

            System.IO.FileInfo file = new System.IO.FileInfo(hdn_ATTACHMENT_FILE.Value);
            string filePath = hdn_ATTACHMENT_FILE.Value;
            string ext = Path.GetExtension(file.Name).ToLower();

            Response.Clear();
            Response.ClearContent();

            if (ext == ".doc" || ext == ".docx")
            {
                Response.ContentType = "Application/msword";
            }
            else if (ext == ".pdf")
            {
                Response.ContentType = "Application/pdf";
            }
            else if (ext == ".xls" || ext == ".xlsx")
            {
                Response.ContentType = "Application/x-msexcel";
            }
            else if (ext == ".jpg" || ext == ".jpeg")
            {
                Response.ContentType = "image/jpeg";
            }
            else if (ext == ".gif")
            {
                Response.ContentType = "image/GIF";
            }
            else if (ext == ".html" || ext == ".htm")
            {
                Response.ContentType = "text/HTML";
            }
            else if (ext == ".txt" || ext == ".be" || ext == ".sb")
            {
                Response.ContentType = "text/plain";
            }
            else
            {
                Response.ContentType = MimeType(Path.GetExtension(file.Name));
            }

            Response.AddHeader("Content-Disposition", "attachment;filename=" + lnkbtn.Text);
            Response.AddHeader("Content-Length", file.Length.ToString());

            Response.TransmitFile(file.FullName);
            Response.End();
        }
        else
        {
            Alert_msg("File not download");
        }
    }


    public static string MimeType(string Extension)
    {
        string mime = "application/octetstream";
        if (string.IsNullOrEmpty(Extension))
            return mime;
        string ext = Extension.ToLower();
        Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
        if (rk != null && rk.GetValue("Content Type") != null)
        {
            if (ext == ".rtf" || ext == ".doc")
            {
                mime = "application/rtf";
            }
            else if (ext == ".sb" || ext == ".be" || ext == ".SB" || ext == ".BE")
            {
                mime = "text/plain";
            }
            else
                mime = rk.GetValue("Content Type").ToString();
        }
        return mime;
    }


    protected void btn_File_Delete_Click(object source, EventArgs e)
    {
        ////CheckBox chkAll = (CheckBox)gvdetails.HeaderRow.Cells[0].FindControl("chkAll");
        ////for (int i = 0; i < gvdetails.Rows.Count; i++)
        ////{
        ////    if (chkAll.Checked)
        ////    {
        ////        CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
        ////        if (chk.Checked)
        ////        {
        ////            jh.FLAG = "Delete_Upload_File";

        ////            jh.JOB_ID = gvdetails.Rows[i].Cells[2].Text;
        ////            Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, attach_File);
        ////        }
        ////    }
        ////    else
        ////    {
        ////        CheckBox chk = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk");
        ////        if (chk.Checked)
        ////        {
        ////            jh.FLAG = "Delete_Upload_File";
        ////            jh.JOB_ID = gvdetails.Rows[i].Cells[2].Text;
        ////            Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, attach_File);
        ////        }

        ////    }
        ////}
        ////if (jh.result == 1)
        ////    Alert_msg("File Deleted");

    }

    //protected void btn_Upload_Click(object sender, EventArgs e)
    //{
    //    HttpFileCollection fileCollection = Request.Files;

    //    for (int i = 0; i < fileCollection.Count; i++)
    //    {
    //        HttpPostedFile uploadfile = fileCollection[i];
    //        fileName = Path.GetFileName(uploadfile.FileName);
    //        string ext = Path.GetExtension(uploadfile.FileName).ToLower();
    //        if (ext == ".sb" || ext == ".be" || ext == ".rtf" || ext == ".txt" || ext == ".doc" || ext == ".docx" || ext == ".xml" || ext == ".html" || ext == ".htm" || ext == ".xls" || ext == ".xlsx" || ext == ".pdf" || ext == ".jpg" || ext == ".jpeg" || ext == ".zip" || ext == ".rar" || ext == ".png" || ext == ".gif")
    //        {
    //            if (uploadfile.ContentLength > 0)
    //            {
    //                if (uploadfile.ContentLength < 10485760)
    //                {

    //                    //string file = Request["jobno"].ToString() + "~~" + fileName;
    //                    string file = fileName;
    //                    string path = errorFolder + file;
    //                    jh.FLAG = "File_Exists";
    //                    jh.DESCRIPTION = errorFolder;
    //                    jh.ATTACHMENT_FILE = file;
    //                    jh.JOB_ID = "";
    //                    Upload_Flag = "UPLOAD";
    //                    //Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, jh.ATTACHMENT_FILE);

    //                    if (jh.result == 1)
    //                    {
    //                        Alert_msg("File already exists! Please Try another one file for upload");

    //                    }
    //                    else
    //                    {
    //                        uploadfile.SaveAs(errorFolder + file);
    //                        //txtItem_TextChanged(sender, e);
    //                    }
    //                }
    //                else
    //                {
    //                }
    //            }
    //            else
    //            {
    //                Alert_msg("File cannot be empty");
    //            }
    //        }
    //        else
    //            Alert_msg(ext + " File format not allowed.");
    //    }


    //    //**************************************************************************************
    //    //HttpFileCollection fileCollection = Request.Files;

    //    //for (int i = 0; i < fileCollection.Count; i++)
    //    //{
    //    //    HttpPostedFile uploadfile = fileCollection[i];
    //    //    fileName = Path.GetFileName(uploadfile.FileName);
    //    //    string ext = Path.GetExtension(uploadfile.FileName).ToLower();
    //    //    if (ext == ".sb" || ext == ".be" || ext == ".rtf" || ext == ".txt" || ext == ".doc" || ext == ".docx" || ext == ".xml" || ext == ".html" || ext == ".htm" || ext == ".xls" || ext == ".xlsx" || ext == ".pdf" || ext == ".jpg" || ext == ".jpeg" || ext == ".zip" || ext == ".rar" || ext == ".png" || ext == ".gif")
    //    //    {
    //    //        if (uploadfile.ContentLength > 0)
    //    //        {
    //    //            if (uploadfile.ContentLength < 10485760)
    //    //            {

    //    //                string file = Request["jobno"].ToString() + "~~" + fileName;
    //    //                string path = errorFolder + file;
    //    //                jh.FLAG = "File_Exists";
    //    //                jh.DESCRIPTION = errorFolder;
    //    //                jh.ATTACHMENT_FILE = file;
    //    //                jh.JOB_ID = "";
    //    //                Upload_Flag = "UPLOAD";
    //    //                Insert_Update(jh.FLAG, jh.JOB_ID, jh.JOB_TYPE, jh.DESCRIPTION, jh.ATTACHMENT_FILE);

    //    //                if (jh.result == 1)
    //    //                {
    //    //                    Alert_msg("File already exists! Please Try another one file for upload");

    //    //                }
    //    //                else
    //    //                {
    //    //                    uploadfile.SaveAs(errorFolder + file);
    //    //                    txtItem_TextChanged(sender, e);
    //    //                }
    //    //            }
    //    //            else
    //    //            {
    //    //            }
    //    //        }
    //    //        else
    //    //        {
    //    //            Alert_msg("File cannot be empty");
    //    //        }
    //    //    }
    //    //    else
    //    //        Alert_msg(ext + " File format not allowed.");
    //    //}


    //}


    private void FreshRow()
    {
        txtExpDetailsRow.Text = "";
        txtRefVoucherNoRow.Text = "";
        txtExpAmountRow.Text = "";
        ddlPaymentRow.Text = "Not Paid";
        ddlPaymentRow.Enabled = true;
        txtPaidOnRow.Enabled = true;
        txtPaidOnRow.Text = "";
        txtStaffNameRow.Text = "";
        txtGivenByRow.Text = "";
        txtAssigneeRow.Text = "";
        txtRemarksRow.Text = "";
        txtVendorBranch.Text = "";
        txtVendorGSTIN.Text = "";
        txtCurrency.Text = "";
        txtExrate.Text = "";
        txtTaxAmount.Text = "";
        txtForeignamt.Text = "";
        txtCgstAmount.Text = "";
        txtCgstpercentage.Text = "";
        txtSGSTAmount.Text = "";
        txtSGSTPercentage.Text = "";
        txtIGSTAmount.Text = "";
        txtIGSTPercentage.Text = "";
        Load_CRDR();
        Load_ClassifyType();
        
        lbtnImageFileRow.Text = "";        
        hdn_FILE_IMAGE_NAME.Value = "";
        hdn_FILE_PATH.Value = "";
        hdn_ATTACHMENT_FILE.Value="";
        hdn_FILE_REF_NO.Value = "";

        hdn_Exp_ID.Value = "";
        hdn_Exp_SubID.Value = "";
        hdn_BROWSE_UPLOADED.Value = "0";





        chkImageFileRow.Visible = false;
        lbtnImageFileRow.Visible = false;
        txtExpDetailsRow.Focus();

        //DataTable dt = new DataTable();
        //DataRow dr = null;
        //DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];


        //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        //dt.Columns.Add(new DataColumn("Exp_Details", typeof(string)));
        //dt.Columns.Add(new DataColumn("Ref_VoucherNo", typeof(string)));
        //dt.Columns.Add(new DataColumn("Exp_Amount", typeof(string)));

        //dt.Columns.Add(new DataColumn("PaymentMode", typeof(string)));
        //dt.Columns.Add(new DataColumn("Remarks", typeof(string)));
        //dt.Columns.Add(new DataColumn("GivenBy", typeof(string)));
        //dt.Columns.Add(new DataColumn("Assignee", typeof(string)));

        //dt.Columns.Add(new DataColumn("PAID_ON", typeof(string)));
        //dt.Columns.Add(new DataColumn("STAFF_NAME", typeof(string)));
        //dt.Columns.Add(new DataColumn("FILE_IMAGE_NAME", typeof(string)));
        //dt.Columns.Add(new DataColumn("EXP_SUBID", typeof(string)));



        //dr = dt.NewRow();

        //dr["RowNumber"] = 1;
        //dr["Exp_Details"] = string.Empty;
        //dr["Ref_VoucherNo"] = string.Empty;
        //dr["Exp_Amount"] = "0";
        //dr["PaymentMode"] = string.Empty;
        //dr["Remarks"] = string.Empty;
        //dr["GivenBy"] = string.Empty;
        //dr["Assignee"] = string.Empty;

        //dr["PAID_ON"] = string.Empty;
        //dr["STAFF_NAME"] = string.Empty;
        //dr["FILE_IMAGE_NAME"] = string.Empty;
        //dr["EXP_SUBID"] = string.Empty;



        //dt.Rows.Add(dr);

        ////Store the DataTable in ViewState
        //ViewState["CurrentTable"] = dt;

        //gv.DataSource = dt;
        //gv.DataBind();

    }


    protected void btnNewRow_Click(object sender, EventArgs e)
    {

        btnUpdate.CssClass = "updates";
        btnSaveRow.Visible = true;
        btnDeleteRow.Visible = false;
        btnUpdateRow.Visible = false;

        FileUpload1.Visible = false;
        btnUploadRow.Visible = false;

        FreshRow();

        //Other_Quotation.Checked = false;
        //Transaction trans = new Transaction();
        //trans.ResetFields(Page.Controls);
        //btnUpdate.CssClass = "updates";



        //btnSaveRow.Visible = true;
        //btnDeleteRow.Visible = false;
        //btnUpdateRow.Visible = false;

        //DataTable dt = new DataTable();
        //gv.DataSource = dt;
        //gv.DataBind();

        //SetInitialRow();


        //HDupdate_id.Value = string.Empty;


        //ddljobno.Enabled = true;

        //ddltype.Enabled = true;
        //ddlSearch.Enabled = true;

        //btnrpt.Visible = false;

        //ddlbranch_No.Enabled = true;

        //ddljobno.Items.Clear();


        //ddlbranch_No.Enabled = true;


        //WK.Visible = true;
        //txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //LoadBranch();
        //ddlbranch_No_SelectedIndexChanged(sender, e);
        //GetAutono_Receipt();

    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        //Other_Quotation.Checked = false;
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

      
 
        //btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        DataTable dt = new DataTable();
        gv.DataSource = dt;
        gv.DataBind();

        SetInitialRow();

        
        HDupdate_id.Value = string.Empty;
     
     
        ddljobno.Enabled = true;

        ddltype.Enabled = true;
        ddlSearch.Enabled = true;

        btnrpt.Visible = false;

        ddlbranch_No.Enabled=true;

        ddljobno.Items.Clear();
      
      
        ddlbranch_No.Enabled = true;
       

            WK.Visible = true;
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            LoadBranch();
            ddlbranch_No_SelectedIndexChanged(sender, e);
            GetAutono_Receipt();
        
    }

    
   
    protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
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
    
  
   
    protected void Rd_Job_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        //load_Jobno();
        LoadBranch();
        ddlbranch_No_SelectedIndexChanged(sender, e);
        //LoadddlSearch();
    }
    protected void ddlWorkingPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Imp_name();
        
    }
    protected void chkIncludeJob_OnCheckedChanged(object sender, EventArgs e)
    {
        LoadJob(); 
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
        if (ddlbranch_No.SelectedItem.Text != string.Empty)
        {
            Loadddltype();
            ddlSearch.Items.Clear();
            txtCustName.Text = "";
            txtJobInfo.Text = "";

            txtBranchSlNo.Text = "";
            txtFileRefNo.Text = "";
            txtjobno.Text = "";

        }      
      
    }

    private void GetAutono_Receipt()
    {
        DataSet ds = new DataSet();
        ObjUBO.Flag = "Generate-AutoNo";
        ObjUBO.BILL_TYPE = "Expenses-Entry";
        ds = BI.Load_DDL(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtExpVoucherNo.Text = ds.Tables[0].Rows[0][0].ToString();

        }
        ds.Dispose();
        GC.Collect();
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        JobInfoDisplay();
    }

    public void JobInfoDisplay()
    {
        DataSet dss = new DataSet();
        string jobinfo = "";

        if (ddljobno.SelectedItem.Text != "")
        {
            if (Rd_Job_Type.SelectedIndex == 0)
                ObjUBO.Flag = "Select-ImpJobInfo";
            else
                ObjUBO.Flag = "Select-ExpJobInfo";

            ObjUBO.Ref_ID = ddljobno.SelectedValue.ToString();

            dss = BI.Load_DDL(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {                
                txtCustName.Text = dss.Tables[0].Rows[0]["CustName"].ToString();

                jobinfo = "JobDate:" + dss.Tables[0].Rows[0]["JOBDATE"].ToString() + " Transport Mode: " + dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() + " BE Type:" + dss.Tables[0].Rows[0]["BE_TYPE"].ToString();
                txtJobInfo.Text = jobinfo.ToString();
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    ddlbranch_No.Items.Clear();
                    ddlbranch_No.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["BRANCHCODE"].ToString(), dss.Tables[0].Rows[0]["BRANCHCODE"].ToString()));
                    ddlbranch_No.SelectedIndex = 0;
                }

            }

            //-----------display job information-----------------

        }

        dss.Dispose();
        GC.Collect();
    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        LoadddlSearch();
    }

    protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        //JobInfoDisplay();
        SearchInfoDisplay();
    }

    public void SearchInfoDisplay()
    {
        DataSet dss = new DataSet();
        string jobinfo = "";

        if (ddlSearch.SelectedItem.Text != "")
        {
            if (Rd_Job_Type.SelectedIndex == 0)
            {
                if (ddltype.SelectedItem.Text == "File.Ref.no")
                {
                    ObjUBO.Flag = "Select-ImpJobInfo_FileRefNo";
                }
                else if (ddltype.SelectedItem.Text == "Job No")
                {
                    ObjUBO.Flag = "Select-ImpJobInfo"; 
                }
                else if (ddltype.SelectedItem.Text == "Inv No")
                {
                    ObjUBO.Flag = "Select-ImpJobInfo_InvNo"; 
                }
                else
                {
                    //ObjUBO.Flag = "Select-ImpJobInfo";
                    ObjUBO.Flag = "";
                } 

            }
            else
             //   ObjUBO.Flag = "Select-ExpJobInfo";
            {
                if (ddltype.SelectedItem.Text == "File.Ref.no")
                {
                    ObjUBO.Flag = "Select-ExpJobInfo_FileRefNo";
                }
                else if (ddltype.SelectedItem.Text == "Job No")
                {
                    ObjUBO.Flag = "Select-ExpJobInfo";  //ObjUBO.Flag = "Select-ExpJobInfo_JobNo";
                }
                else if (ddltype.SelectedItem.Text == "Inv No")
                {
                    ObjUBO.Flag = "Select-ExpJobInfo_InvNo";
                }
                else
                {
                    //ObjUBO.Flag = "Select-ExpJobInfo";
                    ObjUBO.Flag = " ";
                }
            }




            ObjUBO.BRANCH_CODE = ddlbranch_No.SelectedValue.ToString();
            ObjUBO.Ref_ID = ddlSearch.SelectedValue.ToString();

            dss = BI.Load_DDL_Accounts(ObjUBO);
            if (dss.Tables[0].Rows.Count > 0)
            {
                txtCustName.ReadOnly = true;                
                txtBranchSlNo.ReadOnly = true;
                txtFileRefNo.ReadOnly = true;
                txtjobno.ReadOnly = true;
                txtJobInfo.ReadOnly = true;  

                txtCustName.Text = dss.Tables[0].Rows[0]["CustName"].ToString();
                txtBranchSlNo.Text = dss.Tables[0].Rows[0]["BRANCH_NO"].ToString();

                txtFileRefNo.Text = dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                txtjobno.Text = dss.Tables[0].Rows[0]["JOBNO"].ToString();

                ddljobno.Items.Add(txtjobno.Text);


                if (ddltype.SelectedItem.Text == "Inv No" && Rd_Job_Type.SelectedIndex == 0)
                {
                    jobinfo = "Inv Date:" + dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString() + " Mode: " + dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() + " BE No:" + dss.Tables[0].Rows[0]["BE_NO"].ToString() + " BE Date:" + dss.Tables[0].Rows[0]["BE_DATE"].ToString() + " EXPORTER :" + dss.Tables[0].Rows[0]["SHIPPER"].ToString() + " IMPORTER :" + dss.Tables[0].Rows[0]["IMPORTER"].ToString();
                }
                else if (ddltype.SelectedItem.Text == "Inv No" && Rd_Job_Type.SelectedIndex == 1)
                {
                    jobinfo = "Inv Date:" + dss.Tables[0].Rows[0]["BILL_INV_DATE"].ToString() + " Mode: " + dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() + " SB No:" + dss.Tables[0].Rows[0]["SB_NO"].ToString() + " SB Date:" + dss.Tables[0].Rows[0]["SB_DATE"].ToString() + " EXPORTER :" + dss.Tables[0].Rows[0]["SHIPPER"].ToString() + " IMPORTER :" + dss.Tables[0].Rows[0]["IMPORTER"].ToString();
                }
                else
                {
                    jobinfo = "JobDate:" + dss.Tables[0].Rows[0]["JOBDATE"].ToString() + " Transport Mode: " + dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() + " BE Type:" + dss.Tables[0].Rows[0]["BE_TYPE"].ToString();
                }

                txtJobInfo.Text = jobinfo.ToString();
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    ddlbranch_No.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["BRANCHCODE"].ToString(), dss.Tables[0].Rows[0]["BRANCHCODE"].ToString()));
                    ddlbranch_No.SelectedIndex = 0;
                }

            }
            else
            {
                if (ddlSearch.SelectedItem.Text != "")
                {

                    txtCustName.ReadOnly = false;
                    txtCustName.Focus();
                    txtBranchSlNo.ReadOnly = false;
                    txtFileRefNo.ReadOnly = false;
                    txtjobno.ReadOnly = false;
                    txtJobInfo.ReadOnly = false;                        

                    txtCustName.Text = "";
                    txtBranchSlNo.Text = "";
                    txtFileRefNo.Text = "";
                    txtjobno.Text = "0";

                    //ddljobno.Items.Add(txtjobno.Text);
                    jobinfo = "";
                    txtJobInfo.Text ="";
                    //if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                    //{
                        //ddlbranch_No.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["BRANCHCODE"].ToString(), dss.Tables[0].Rows[0]["BRANCHCODE"].ToString()));
                        //ddlbranch_No.SelectedIndex = 0;
                    //}

                }

            }


            //-----------display job information-----------------

        }
        //else if (ddlSearch.SelectedItem.Text == "OTHERS")
        //{
            
        //    txtCustName.ReadOnly = false;
        //    txtCustName.Focus();
        //    txtBranchSlNo.ReadOnly = false;
        //    txtFileRefNo.ReadOnly = false;
        //    txtjobno.ReadOnly = false;
        //    txtJobInfo.ReadOnly = false;
        //}
        //else 
        //{
        //}



        dss.Dispose();
        GC.Collect();
    }
}