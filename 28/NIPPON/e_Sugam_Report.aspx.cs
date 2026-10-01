using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
//using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

public partial class e_Sugam_Report : ThemeClass
{
    e_Sugam esm = new e_Sugam();
    Duty_Intimation duty = new Duty_Intimation();
    DataSet ds = new DataSet();
   
    Transaction Transact = new Transaction();
    CheckList CHKLIST = new CheckList();
    DataSet dtuser = new DataSet();

    AppSession aps = new AppSession();
  
    public string Update_ID = "";
    ErrorLogs er = new ErrorLogs();
    public int i;
    public string AUTO_ID;

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string FILE_REF_NO, BRANCH_NO, IEC_NO, TRANSPORT_MODE;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
  

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

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

        if (!IsPostBack)
        {
            Get_JobNo();
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            /*
            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();
            */
        }
        
    }
    public void Get_JobNo()
    {
       
        CHKLIST.JOBNo = "";
        CHKLIST.Ename = "select_jobno";
        CHKLIST.Workingperiod = SELECT_BRANCH;
        ddlJobNo.DataSource = CHKLIST.RetrieveAll_General_Details();
        dtuser = CHKLIST.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string F = "S";
            i = e_Sugam_Report_Insert_Update(F);
            if (i == 1)
            {
                Alert_msg("Saved Successfully", "btnSave");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;

                GET_DETAILS_e_Sugam();
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnSave");
            }
            else
            {
                Alert_msg("Not Saved", "btnSave");
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
            //string ID = "";
            string F = "U";
            i = e_Sugam_Report_Insert_Update(F);
            if (i == 1)
            {
                Alert_msg("Updated Successfully", "btnUpdate");

                GET_DETAILS_e_Sugam();
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnUpdate");
            }
            else
            {
                Alert_msg("Not Saved", "btnUpdate");
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
            esm.JOBNO = ddlJobNo.SelectedValue.ToString();
            esm.Ename = "Delete";

            esm.BRANCH_CODE = SELECT_BRANCH;
            DataSet ds = new DataSet();

            ds = esm.RetrieveAll_eSugam_Details();

            int result = esm.result;

            if (result == 1)
            {
                Alert_msg("Record Deleted", "btnUpdate");
                ddlJobNo_SelectedIndexChanged(sender, e);
            }
            
            else
            {
                Alert_msg("Record Not Deleted", "btnUpdate");
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
        btnNew.Visible = true;
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'e-Sugam Report', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'e-Sugam Report', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void GET_DETAILS_e_Sugam()
    {
        DataSet dss = new DataSet();
             
                esm.JOBNO = ddlJobNo.SelectedValue.ToString();
                esm.Ename = "Select_Details";

                esm.BRANCH_CODE = SELECT_BRANCH;
               

                ds = esm.RetrieveAll_eSugam_Details();
                ViewState["ds"] = ds;
                int result = esm.result;

                if (result == 1)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtImporter.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                        txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                        txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                        txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                        txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                        txtAddress5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                        ViewState["BRANCH_NO"] = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtSupplierName.Text = ds.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
                        txt_Sup_Address1.Text = ds.Tables[1].Rows[0]["SUPPLIER_ADDRESS"].ToString();
                        txt_Sup_Address2.Text = ds.Tables[1].Rows[0]["SUPPLIER_ADDRESS1"].ToString();
                        txt_Sup_Address3.Text = ds.Tables[1].Rows[0]["SUPPLIER_ADDRESS2"].ToString();
                        txt_Sup_Address4.Text = ds.Tables[1].Rows[0]["SUPPLIER_COUNTRY_NAME"].ToString() + " " + ds.Tables[1].Rows[0]["SUPPLIER_COUNTRY_PINCODE"].ToString();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txt_Commodity.Text = ds.Tables[2].Rows[0]["ITEM_DESCRIPTION"].ToString();
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txt_TotalInvoice_Value.Text = ds.Tables[3].Rows[0]["INVOICE_VALUE"].ToString();
                    }

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        txt_Quantity.Text = ds.Tables[4].Rows[0]["ITEM_QTY"].ToString();
                    }

                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnSearch.Visible = false;
                }
                else
                {
                    txtImporter.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                    txtAddress5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                    txt_Importer_PINNO.Text = ds.Tables[0].Rows[0]["IMP_TIN_NO"].ToString();
                    txtSupplierName.Text = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();
                    txt_Sup_Address1.Text = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS1"].ToString();
                    txt_Sup_Address2.Text = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS2"].ToString();
                    txt_Sup_Address3.Text = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS3"].ToString();
                    txt_Sup_Address4.Text = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS4"].ToString();
                    txt_DispatchGoods.Text = ds.Tables[0].Rows[0]["DESPATCH_GOODS"].ToString();
                    txt_Sup_TINNO.Text = ds.Tables[0].Rows[0]["SUPPLIER_TINNO"].ToString();
                    txt_DocumentType.Text = ds.Tables[0].Rows[0]["DOCUMENT_TYPE"].ToString();
                    txt_DocumentNo.Text = ds.Tables[0].Rows[0]["DOCUMENT_NO"].ToString();
                    txt_Document_Date.Text = ds.Tables[0].Rows[0]["DOCUMENT_DATE"].ToString();
                    txt_Quantity.Text = ds.Tables[0].Rows[0]["QUANTITY"].ToString();
                    txt_TotalValue.Text = ds.Tables[0].Rows[0]["TOTAL_VALUE"].ToString();
                    txt_VAT_CST.Text = ds.Tables[0].Rows[0]["VAT_CST_VALUE"].ToString();
                    txt_OtherAmount.Text = ds.Tables[0].Rows[0]["OTHER_AMOUNT"].ToString();
                    txt_TotalInvoice_Value.Text = ds.Tables[0].Rows[0]["TOTAL_INVOICE_VALUE"].ToString();
                    txt_Despatch_Date.Text = ds.Tables[0].Rows[0]["DESPATCH_DATE"].ToString();
                    txt_Nature_Transaction.Text = ds.Tables[0].Rows[0]["NATURE_TRANSACTION"].ToString();
                    txt_Commodity.Text = ds.Tables[0].Rows[0]["COMMODITY"].ToString();
                    txt_TransporterName.Text = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();
                    txt_VehicleNo.Text = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString();
                    txt_LG_GR.Text = ds.Tables[0].Rows[0]["LG_GR"].ToString();
                    txt_ReceiptDate.Text = ds.Tables[0].Rows[0]["RECEIPT_DATE"].ToString();
                    ViewState["BRANCH_NO"] = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();

                    Update_ID = ds.Tables[0].Rows[0]["ID"].ToString();

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnSearch.Visible = true;
                }
           
    }
  
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Clear();
            if (ddlJobNo.SelectedValue == "Select")
            {
                Clear();

                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = false;
            }
            else
            {
                GET_DETAILS_e_Sugam();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }
  
    public int e_Sugam_Report_Insert_Update(string Flag)
    {
      
        esm.ID="";
        esm.JOBNO = ddlJobNo.SelectedValue;
        esm.IMPORTER_NAME = txtImporter.Text;
        esm.ADDRESS1 = txtAddress1.Text;
        esm.ADDRESS2 = txtAddress2.Text;
        esm.ADDRESS3 = txtAddress3.Text;
        esm.ADDRESS4 = txtAddress4.Text;
        esm.ADDRESS5 = txtAddress5.Text;
        esm.IMP_TIN_NO = txt_Importer_PINNO.Text;
        esm.SUPPLIER_NAME = txtSupplierName.Text;
        esm.SUPPLIER_ADDRESS1 = txt_Sup_Address1.Text;
        esm.SUPPLIER_ADDRESS2 = txt_Sup_Address2.Text;
        esm.SUPPLIER_ADDRESS3 = txt_Sup_Address3.Text;
        esm.SUPPLIER_ADDRESS4 = txt_Sup_Address4.Text;
        esm.SUPPLIER_TINNO = txt_Sup_TINNO.Text;
        esm.DESPATCH_GOODS = txt_DispatchGoods.Text;
        esm.DOCUMENT_TYPE = txt_DocumentType.Text;
        esm.DOCUMENT_NO = txt_DocumentNo.Text;
        esm.DOCUMENT_DATE = txt_Document_Date.Text;
        esm.QUANTITY = txt_Quantity.Text;
        esm.TOTAL_VALUE = txt_TotalValue.Text;
        esm.VAT_CST_VALUE = txt_VAT_CST.Text;
        esm.OTHER_AMOUNT = txt_OtherAmount.Text;
        esm.TOTAL_INVOICE_VALUE = txt_TotalInvoice_Value.Text;
        esm.DESPATCH_DATE = txt_Despatch_Date.Text;
        esm.NATURE_TRANSACTION = txt_Nature_Transaction.Text;
        esm.COMMODITY = txt_Commodity.Text;
        esm.TRANSPORTER_NAME = txt_TransporterName.Text;
        esm.VEHICLE_NO = txt_VehicleNo.Text;
        esm.LG_GR = txt_LG_GR.Text;
        esm.RECEIPT_DATE = txt_ReceiptDate.Text;
        esm.USER_ID	=currentuser;
        esm.DATE_TIME=LoginDate;
        esm.BRANCH_CODE = currentbranch;
        esm.WORKING_PERIOD = Working_Period;
        esm.Ename = Flag;
        esm.BRANCH_COMMON = SELECT_BRANCH;
        esm.BRANCH_NO = ViewState["BRANCH_NO"].ToString();

        i = esm.e_Sugam_Details_insertupdate();
        return i;
    }


    private void Clear()
    {
        txtImporter.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtAddress3.Text = "";
        txtAddress4.Text = "";
        txtAddress5.Text = "";
        txt_Importer_PINNO.Text = "";
        txtSupplierName.Text = "";
        txt_Sup_Address1.Text = "";
        txt_Sup_Address2.Text = "";
        txt_Sup_Address3.Text = "";
        txt_Sup_Address4.Text = "";
        txt_DispatchGoods.Text = "";
        txt_Sup_TINNO.Text = "";
        txt_DocumentType.Text = "";
        txt_DocumentNo.Text = "";
        txt_Document_Date.Text = "";
        txt_Quantity.Text = "";
        txt_TotalValue.Text = "";
        txt_VAT_CST.Text = "";
        txt_OtherAmount.Text = "";
        txt_TotalInvoice_Value.Text = "";
        txt_Despatch_Date.Text = "";
        txt_Nature_Transaction.Text = "";
        txt_Commodity.Text = "";
        txt_TransporterName.Text = "";
        txt_VehicleNo.Text = "";
        txt_LG_GR.Text = "";
        txt_ReceiptDate.Text = "";
  
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();

        ds = (DataSet)ViewState["ds"];

        //Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

        Microsoft.Office.Interop.Excel.Application excel;
        Microsoft.Office.Interop.Excel.Workbook worKbooK;
        Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
        Microsoft.Office.Interop.Excel.Range celLrangE;

        try
        {
            excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            excel.DisplayAlerts = true;
            worKbooK = excel.Workbooks.Add(Type.Missing);

            worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
            worKsheeT.Name = "e-Sugam_Report";
            worKsheeT.Tab.Color = System.Drawing.Color.Green;
            excel.Caption = "e-Sugam_Report" + "-" + "JOBNO: " + ddlJobNo.SelectedItem.Text;

            worKsheeT.Range[worKsheeT.Cells[2, 2], worKsheeT.Cells[2, 3]].Merge();
            worKsheeT.Cells[2, 2] = "Requirement Form e-SUGAM ";
            worKsheeT.Range["B2", "C2"].Font.Size = 15;
            worKsheeT.Range["B2", "C2"].Font.Bold = true;

            worKsheeT.get_Range("B2", "C2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worKsheeT.Range["B2", "C2"].Borders.LineStyle = XlLineStyle.xlContinuous;

            //worKsheeT.get_Range("B2", "B2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            //worKsheeT.Range["B2", "B25"].Borders.LineStyle = XlLineStyle.xlContinuous;
            //worKsheeT.Range["C2", "C25"].Borders.LineStyle = XlLineStyle.xlContinuous;

            worKsheeT.get_Range("B2", "C26").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexNone, Type.Missing);

            worKsheeT.Range["B7", "B25"].Borders.LineStyle = XlLineStyle.xlContinuous;
            worKsheeT.Range["C7", "C25"].Borders.LineStyle = XlLineStyle.xlContinuous;
            worKsheeT.Range["C26"].RowHeight = 1;

            worKsheeT.Range["B2"].ColumnWidth = 60;
            worKsheeT.Range["C2"].ColumnWidth = 50;

            worKsheeT.Range[worKsheeT.Cells[3, 2], worKsheeT.Cells[3, 3]].Merge();

            worKsheeT.Cells[4, 2] = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
            worKsheeT.Range["B4", "C4"].Font.Bold = true;
            worKsheeT.Range["B4", "C4"].Font.Size = 12;

            worKsheeT.Range["B5"].RowHeight = 68;
            worKsheeT.Cells[5, 2] = "BRANCH CODE :" + ds.Tables[0].Rows[0]["BRANCH_NO"].ToString() + ", " + ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + "\n" + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + "\n" + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + "\n" + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
            worKsheeT.Range["B5", "C5"].Font.Size = 11;

            worKsheeT.Cells[6, 2] = "TIN NO : " + ds.Tables[0].Rows[0]["IMP_TIN_NO"].ToString();
            worKsheeT.Range["B6", "C6"].Font.Bold = true;

            worKsheeT.get_Range("B7", "C7").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worKsheeT.Range[worKsheeT.Cells[7, 2], worKsheeT.Cells[7, 3]].Merge();
            worKsheeT.Cells[7, 2] = "Detail of Supplier";
            worKsheeT.Range["B7", "C7"].Font.Size = 14;
            worKsheeT.Range["B7", "C7"].Font.Bold = true;

            worKsheeT.Cells[8, 2] = "Name of the Supplier ";
            worKsheeT.Range["B8"].RowHeight = 20;
            worKsheeT.Cells[8, 3] = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();

            worKsheeT.Cells[9, 2] = "Name and Address of the Supplier ";
            worKsheeT.Range["B9"].RowHeight = 55;
            worKsheeT.Cells[9, 3] = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS1"].ToString() + "\n" + ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS2"].ToString() + "\n" + ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS3"].ToString() + ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS4"].ToString();

            worKsheeT.Cells[10, 2] = "Dispatch of Goods from Place (Movement of Goods)  a) From  b) To ";
            worKsheeT.Range["B10"].RowHeight = 30;
            worKsheeT.Range["B10"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worKsheeT.Cells[10, 3] = ds.Tables[0].Rows[0]["DESPATCH_GOODS"].ToString();

            worKsheeT.Cells[11, 2] = "TIN No. of the Supplier";
            worKsheeT.Range["B11"].RowHeight = 30;
            worKsheeT.Cells[11, 3] = ds.Tables[0].Rows[0]["SUPPLIER_TINNO"].ToString();
            worKsheeT.get_Range("C11").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

            worKsheeT.get_Range("B12", "C12").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worKsheeT.Range[worKsheeT.Cells[12, 2], worKsheeT.Cells[12, 3]].Merge();
            worKsheeT.Cells[12, 2] = "Invoice Detail";
            worKsheeT.Range["B12", "C12"].Font.Size = 14;
            worKsheeT.Range["B12", "C12"].Font.Bold = true;

            worKsheeT.get_Range("C13:C25").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            worKsheeT.Cells[13, 2] = "Document Type ( Invoice/Stock Transfer/Consignment Note/Job Work Voucher/Etc)";
            worKsheeT.Range["B13"].RowHeight = 35;
            worKsheeT.Range["B13"].WrapText = true;
            worKsheeT.Cells[13, 3] = ds.Tables[0].Rows[0]["DOCUMENT_TYPE"].ToString();

            worKsheeT.Cells[14, 2] = "Document No.";
            worKsheeT.Range["B14"].RowHeight = 35;
            worKsheeT.Cells[14, 3] = ds.Tables[0].Rows[0]["DOCUMENT_NO"].ToString();

            worKsheeT.Cells[15, 2] = "Document Date";
            worKsheeT.Range["B15"].RowHeight = 35;
            worKsheeT.Cells[15, 3] = ds.Tables[0].Rows[0]["DOCUMENT_DATE"].ToString();

            worKsheeT.Cells[16, 2] = "Name of the Commodity (Please specified Item Name)";
            worKsheeT.Range["B16"].RowHeight = 35;
            worKsheeT.Cells[16, 3] = ds.Tables[0].Rows[0]["COMMODITY"].ToString();
            worKsheeT.Range["C16"].WrapText = true;

            worKsheeT.Cells[17, 2] = "Quantity (Units/KG/Ltr)";
            worKsheeT.Range["B17"].RowHeight = 35;
            worKsheeT.Cells[17, 3] = ds.Tables[0].Rows[0]["QUANTITY"].ToString();

            worKsheeT.Cells[18, 2] = "Total Invoice Value (Rs.)";
            worKsheeT.Range["B18"].RowHeight = 35;
            worKsheeT.Cells[18, 3] = ds.Tables[0].Rows[0]["TOTAL_INVOICE_VALUE"].ToString();

            worKsheeT.Cells[19, 2] = "Date of Despatch";
            worKsheeT.Range["B19"].RowHeight = 35;
            worKsheeT.Cells[19, 3] = ds.Tables[0].Rows[0]["DESPATCH_DATE"].ToString();

            worKsheeT.Cells[20, 2] = "Nature of Transaction (Sale/Job Work/Returnable/Stock Transfer etc.)";
            worKsheeT.Range["B20"].RowHeight = 35;
            worKsheeT.Range["B20"].WrapText = true;
            worKsheeT.Cells[20, 3] = ds.Tables[0].Rows[0]["NATURE_TRANSACTION"].ToString();

            worKsheeT.get_Range("B21", "C21").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worKsheeT.Range[worKsheeT.Cells[21, 2], worKsheeT.Cells[21, 3]].Merge();
            worKsheeT.Cells[21, 2] = "Transporter's Detail";
            worKsheeT.Range["B21", "C21"].Font.Size = 14;
            worKsheeT.Range["B21", "C21"].Font.Bold = true;

            worKsheeT.Cells[22, 2] = "Name of the Transporter";
            worKsheeT.Range["B22"].RowHeight = 35;
            worKsheeT.Cells[22, 3] = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();

            worKsheeT.Cells[23, 2] = "Vehicle No.";
            worKsheeT.Range["B23"].RowHeight = 35;
            worKsheeT.Cells[23, 3] = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString();

            worKsheeT.Cells[24, 2] = "LR/GR No.";
            worKsheeT.Range["B24"].RowHeight = 35;
            worKsheeT.Cells[24, 3] = ds.Tables[0].Rows[0]["LG_GR"].ToString();

            worKsheeT.Cells[25, 2] = "Probable Date of Receipt (Goods at our Place of Work)";
            worKsheeT.Range["B25"].RowHeight = 35;
            worKsheeT.Cells[25, 3] = ds.Tables[0].Rows[0]["RECEIPT_DATE"].ToString();

            //worKsheeT.PageSetup.Orientation = XlPageOrientation.xlPortrait;
            worKsheeT.PageSetup.FitToPagesTall = 1;
            worKsheeT.PageSetup.Zoom = 75;

            worKbooK.Close();
            excel.Quit();

        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.Message);

        }
        finally
        {
            worKsheeT = null;
            celLrangE = null;
            worKbooK = null;
        }
    }

    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    DataSet ds = new DataSet();

    //    ds = (DataSet)ViewState["ds"];

    //    //Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

    //    Microsoft.Office.Interop.Excel.Application excel;
    //    Microsoft.Office.Interop.Excel.Workbook worKbooK;
    //    Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
    //    Microsoft.Office.Interop.Excel.Range celLrangE;

    //    try
    //    {
    //        excel = new Microsoft.Office.Interop.Excel.Application();
    //        excel.Visible = true;
    //        excel.DisplayAlerts = true;
    //        worKbooK = excel.Workbooks.Add(Type.Missing);        

    //        worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
    //        worKsheeT.Name = "e-Sugam_Report";
    //        worKsheeT.Tab.Color = System.Drawing.Color.Green;
    //        excel.Caption = "e-Sugam_Report" + "-" + "JOBNO: " + ddlJobNo.SelectedItem.Text;

    //        worKsheeT.Range[worKsheeT.Cells[2, 2], worKsheeT.Cells[2, 3]].Merge();
    //        worKsheeT.Cells[2, 2] = "Requirement Form e-SUGAM ";
    //        worKsheeT.Range["B2", "C2"].Font.Size = 15;
    //        worKsheeT.Range["B2", "C2"].Font.Bold = true;

    //        worKsheeT.get_Range("B2", "C2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
    //        worKsheeT.Range["B2", "C2"].Borders.LineStyle = XlLineStyle.xlContinuous;

    //        //worKsheeT.get_Range("B2", "B2").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
    //        //worKsheeT.Range["B2", "B25"].Borders.LineStyle = XlLineStyle.xlContinuous;
    //        //worKsheeT.Range["C2", "C25"].Borders.LineStyle = XlLineStyle.xlContinuous;

    //        worKsheeT.get_Range("B2", "C26").BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexNone, Type.Missing);

    //        worKsheeT.Range["B7", "B25"].Borders.LineStyle = XlLineStyle.xlContinuous;
    //        worKsheeT.Range["C7", "C25"].Borders.LineStyle = XlLineStyle.xlContinuous;
    //        worKsheeT.Range["C26"].RowHeight = 1;

    //        worKsheeT.Range["B2"].ColumnWidth = 60;
    //        worKsheeT.Range["C2"].ColumnWidth = 50;

    //        worKsheeT.Range[worKsheeT.Cells[3, 2], worKsheeT.Cells[3, 3]].Merge();

    //        worKsheeT.Cells[4, 2] = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
    //        worKsheeT.Range["B4", "C4"].Font.Bold = true;
    //        worKsheeT.Range["B4", "C4"].Font.Size = 12;

    //        worKsheeT.Range["B5"].RowHeight = 68;
    //        worKsheeT.Cells[5, 2] = "BRANCH CODE :" + ds.Tables[0].Rows[0]["BRANCH_NO"].ToString() + ", " + ds.Tables[0].Rows[0]["ADDRESS1"].ToString() + "\n" + ds.Tables[0].Rows[0]["ADDRESS2"].ToString() + "\n" + ds.Tables[0].Rows[0]["ADDRESS3"].ToString() + "\n" + ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
    //        worKsheeT.Range["B5", "C5"].Font.Size = 11;

    //        worKsheeT.Cells[6, 2] = "TIN NO : " + ds.Tables[0].Rows[0]["IMP_TIN_NO"].ToString();
    //        worKsheeT.Range["B6", "C6"].Font.Bold = true;

    //        worKsheeT.get_Range("B7", "C7").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
    //        worKsheeT.Range[worKsheeT.Cells[7, 2], worKsheeT.Cells[7, 3]].Merge();
    //        worKsheeT.Cells[7, 2] = "Detail of Supplier";
    //        worKsheeT.Range["B7", "C7"].Font.Size = 14;
    //        worKsheeT.Range["B7", "C7"].Font.Bold = true;

    //        worKsheeT.Cells[8, 2] = "Name of the Supplier ";
    //        worKsheeT.Range["B8"].RowHeight = 20;
    //        worKsheeT.Cells[8, 3] = ds.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString();

    //        worKsheeT.Cells[9, 2] = "Name and Address of the Supplier ";
    //        worKsheeT.Range["B9"].RowHeight = 55;
    //        worKsheeT.Cells[9, 3] = ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS1"].ToString() + "\n" + ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS2"].ToString() + "\n" + ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS3"].ToString() + ds.Tables[0].Rows[0]["SUPPLIER_ADDRESS4"].ToString();

    //        worKsheeT.Cells[10, 2] = "Dispatch of Goods from Place (Movement of Goods)  a) From  b) To ";
    //        worKsheeT.Range["B10"].RowHeight = 30;
    //        worKsheeT.Range["B10"].Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
    //        worKsheeT.Cells[10, 3] = ds.Tables[0].Rows[0]["DESPATCH_GOODS"].ToString();

    //        worKsheeT.Cells[11, 2] = "TIN No. of the Supplier";
    //        worKsheeT.Range["B11"].RowHeight = 30;
    //        worKsheeT.Cells[11, 3] = ds.Tables[0].Rows[0]["SUPPLIER_TINNO"].ToString();
    //        worKsheeT.get_Range("C11").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

    //        worKsheeT.get_Range("B12", "C12").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
    //        worKsheeT.Range[worKsheeT.Cells[12, 2], worKsheeT.Cells[12, 3]].Merge();
    //        worKsheeT.Cells[12, 2] = "Invoice Detail";
    //        worKsheeT.Range["B12", "C12"].Font.Size = 14;
    //        worKsheeT.Range["B12", "C12"].Font.Bold = true;

    //        worKsheeT.get_Range("C13:C25").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
    //        worKsheeT.Cells[13, 2] = "Document Type ( Invoice/Stock Transfer/Consignment Note/Job Work Voucher/Etc)";
    //        worKsheeT.Range["B13"].RowHeight = 35;
    //        worKsheeT.Range["B13"].WrapText = true;
    //        worKsheeT.Cells[13, 3] = ds.Tables[0].Rows[0]["DOCUMENT_TYPE"].ToString();

    //        worKsheeT.Cells[14, 2] = "Document No.";
    //        worKsheeT.Range["B14"].RowHeight = 35;
    //        worKsheeT.Cells[14, 3] = ds.Tables[0].Rows[0]["DOCUMENT_NO"].ToString();
   
    //        worKsheeT.Cells[15, 2] = "Document Date";
    //        worKsheeT.Range["B15"].RowHeight = 35;       
    //        worKsheeT.Cells[15, 3] = ds.Tables[0].Rows[0]["DOCUMENT_DATE"].ToString();

    //        worKsheeT.Cells[16, 2] = "Name of the Commodity (Please specified Item Name)";
    //        worKsheeT.Range["B16"].RowHeight = 35;
    //        worKsheeT.Cells[16, 3] = ds.Tables[0].Rows[0]["COMMODITY"].ToString();
    //        worKsheeT.Range["C16"].WrapText = true;

    //        worKsheeT.Cells[17, 2] = "Quantity (Units/KG/Ltr)";
    //        worKsheeT.Range["B17"].RowHeight = 35;
    //        worKsheeT.Cells[17, 3] = ds.Tables[0].Rows[0]["QUANTITY"].ToString();

    //        worKsheeT.Cells[18, 2] = "Total Invoice Value (Rs.)";
    //        worKsheeT.Range["B18"].RowHeight = 35;
    //        worKsheeT.Cells[18, 3] = ds.Tables[0].Rows[0]["TOTAL_INVOICE_VALUE"].ToString();

    //        worKsheeT.Cells[19, 2] = "Date of Despatch";
    //        worKsheeT.Range["B19"].RowHeight = 35;
    //        worKsheeT.Cells[19, 3] = ds.Tables[0].Rows[0]["DESPATCH_DATE"].ToString();

    //        worKsheeT.Cells[20, 2] = "Nature of Transaction (Sale/Job Work/Returnable/Stock Transfer etc.)";
    //        worKsheeT.Range["B20"].RowHeight = 35;
    //        worKsheeT.Range["B20"].WrapText = true;
    //        worKsheeT.Cells[20, 3] = ds.Tables[0].Rows[0]["NATURE_TRANSACTION"].ToString();

    //        worKsheeT.get_Range("B21", "C21").Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
    //        worKsheeT.Range[worKsheeT.Cells[21, 2], worKsheeT.Cells[21, 3]].Merge();
    //        worKsheeT.Cells[21, 2] = "Transporter's Detail";
    //        worKsheeT.Range["B21", "C21"].Font.Size = 14;
    //        worKsheeT.Range["B21", "C21"].Font.Bold = true;

    //        worKsheeT.Cells[22, 2] = "Name of the Transporter";
    //        worKsheeT.Range["B22"].RowHeight = 35;
    //        worKsheeT.Cells[22, 3] = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();

    //        worKsheeT.Cells[23, 2] = "Vehicle No.";
    //        worKsheeT.Range["B23"].RowHeight = 35;
    //        worKsheeT.Cells[23, 3] = ds.Tables[0].Rows[0]["VEHICLE_NO"].ToString();

    //        worKsheeT.Cells[24, 2] = "LR/GR No.";
    //        worKsheeT.Range["B24"].RowHeight = 35;
    //        worKsheeT.Cells[24, 3] = ds.Tables[0].Rows[0]["LG_GR"].ToString();
     
    //        worKsheeT.Cells[25, 2] = "Probable Date of Receipt (Goods at our Place of Work)";
    //        worKsheeT.Range["B25"].RowHeight = 35;
    //        worKsheeT.Cells[25, 3] = ds.Tables[0].Rows[0]["RECEIPT_DATE"].ToString();

    //        //worKsheeT.PageSetup.Orientation = XlPageOrientation.xlPortrait;
    //        worKsheeT.PageSetup.FitToPagesTall = 1;
    //        worKsheeT.PageSetup.Zoom = 75;
           
    //        worKbooK.Close();
    //        excel.Quit();

    //    }
    //    catch (Exception ex)
    //    {
    //        //MessageBox.Show(ex.Message);

    //    }
    //    finally
    //    {
    //        worKsheeT = null;
    //        celLrangE = null;
    //        worKbooK = null;
    //    } 
    //}
}