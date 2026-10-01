using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


public partial class Export_Export_Invoice_Report_Details : ThemeClass
{
    //Transaction trans = new Transaction();
    Rpt_Invoice  inv = new Rpt_Invoice();
    DataTable dt = new DataTable();  
    DataRow dr;//= dt.NewRow();
    DataSet dss = new DataSet();
    DataSet dtuser = new DataSet();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    public int i;

    public string currentuser;
    public string currentbranch;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public string FILE_REF_NO, BRANCH_NO, IEC_NO, TRANSPORT_MODE, NO_KIND_OF_PACKAGES, ITEM_QTY_CODE, INVOICE_CURRENCY, F = "";

    public int Screen_Id;
    User_Creation user_Create = new User_Creation();


    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
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
         * 
  * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            pop_text_area_transac_popup_inn_container_export1.Style.Add("display", "block");
            tab2.Style.Add("display", "none");

            txtExporter.Focus();
            gvAll.DataSource = dt;//add empty row
            gvAll.DataBind();
            Get_JobNo();
            btn_Report.Visible = false;          
        }
    }

    public void Get_JobNo()
    {
        Export_CheckList CHKLIST = new Export_CheckList();
        CHKLIST.JOBNo = "";
        CHKLIST.Ename = "select_jobno";
        CHKLIST.Workingperiod = SELECT_BRANCH;
        ddlJobNo.DataSource = CHKLIST.RetrieveAll_General_Details();
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }

    public void pageload()
    {
        DataColumn da = new DataColumn("ITEM_ID");
        DataColumn da2 = new DataColumn("JOBNO");
        //DataColumn da1 = new DataColumn("MARKS_NOS");

        DataColumn da3 = new DataColumn("MARKS_NOS");
        DataColumn da4 = new DataColumn("DESCRIPTION");

        DataColumn da5 = new DataColumn("QTY");
        DataColumn da6 = new DataColumn("RATE");
        DataColumn da7 = new DataColumn("TOTAL");
        DataColumn da8 = new DataColumn("FINAL_TOTAL");
        DataColumn da9 = new DataColumn("FREIGHT");
        DataColumn da10 = new DataColumn("DISCOUNT");
        DataColumn da11 = new DataColumn("RUPEES");
        DataColumn da12 = new DataColumn("disam");
        DataColumn da13 = new DataColumn("RECNO");
      
        DataTable dtt = new DataTable();
        dtt.Columns.Add(da);
        
        dtt.Columns.Add(da2);
        dtt.Columns.Add(da3);
        dtt.Columns.Add(da4);
        dtt.Columns.Add(da5);
        dtt.Columns.Add(da6);
        dtt.Columns.Add(da7);
        dtt.Columns.Add(da8);
        dtt.Columns.Add(da9);
        dtt.Columns.Add(da10);
        dtt.Columns.Add(da11);
        dtt.Columns.Add(da12);
        dtt.Columns.Add(da13);

        dr = dtt.NewRow();

        dr["JOBNO"] = ddlJobNo.SelectedValue;
        dr["MARKS_NOS"] = "";

        dr["DESCRIPTION"] = "";
        dr["ITEM_ID"] = "";
        dr["QTY"] = "";
        dr["RATE"] = "";
        dr["TOTAL"] = "";
        dr["FINAL_TOTAL"] = "";
        dr["FREIGHT"] = "";
        dr["DISCOUNT"] = "";
        dr["RUPEES"] = "";
        dr["disam"] = "";
        dr["RECNO"] = "";

        dtt.Rows.Add(dr);
        gvAll.DataSource = dtt;
        gvAll.DataBind();
        //gvAll.Rows[0].Visible = false;
        LinkButton btnadd = gvAll.FooterRow.FindControl("imgbtnAdd") as LinkButton;
        //btnadd.Style.Add("margin-left","-750px");

        ViewState["CurrentTable"] = dtt;
    }
   
   
    public void Delete_Grid_Items()
    {
        inv.INV_RPT_ID = "";
        inv.JOBNO = ddlJobNo.SelectedValue;
        inv.Ename = "delete_Grid_Items";
        inv.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = inv.Retrieve_All_Export_Invoice_Rpt_Select();
    }

    public void Bind_Job_Details()
    {
        inv.INV_RPT_ID = "";
        inv.JOBNO = ddlJobNo.SelectedValue;
        inv.Ename = "Search";
        inv.WORKING_PERIOD = SELECT_BRANCH;
        dtuser = inv.Retrieve_All_Export_Invoice_Rpt_Select();
        i = inv.result;
        if (dtuser.Tables[0].Rows.Count > 0)
        {
            if (i == 1)
            {
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    DataRow row;
                    row = dtuser.Tables[0].Rows[0];

                    FILE_REF_NO = row["FILE_REF_NO"].ToString();
                    txtExporters_Ref.Text = FILE_REF_NO;

                    txtExporter.Text = row["EXPORTER_NAME"].ToString();

                    if (!string.IsNullOrEmpty(row["INVOICE_DATE"].ToString()))
                    {
                        txtInvoiceNo_Date.Text = row["INVOICE_NO"].ToString() + "/" + row["INVOICE_DATE"].ToString();
                    }
                    BRANCH_NO = row["BRANCH_NO"].ToString();
                    IEC_NO = row["IEC_NO"].ToString();
                    txtAddress1.Text = row["ADDRESS1"].ToString();
                    txtAddress2.Text = row["ADDRESS2"].ToString();
                    txtAddress3.Text = row["ADDRESS3"].ToString();
                    txtAddress4.Text = row["ADDRESS4"].ToString();
                    txtAddress5.Text = row["ADDRESS5"].ToString();

                    txtConsignee.Text = row["CONSIGNEE_NAME"].ToString();
                    txtConsignee_Add1.Text = row["CONSIGNEE_ADD1"].ToString();
                    txtConsignee_Add2.Text = row["CONSIGNEE_ADD2"].ToString();
                    txtConsignee_Add3.Text = row["CONSIGNEE_ADD3"].ToString();
                    txtConsignee_Add4.Text = row["CONSIGNEE_ADD4"].ToString();
                    txtConsignee_Add5.Text = row["CONSIGNEE_ADD5"].ToString();
                    txtBuyer.Text = row["BUYER_NAME"].ToString();
                    txtBuyer_Add1.Text = row["BUYER_ADDRESS"].ToString();
                    txtBuyer_Add2.Text = row["BUYER_ADDRESS1"].ToString();
                    txtBuyer_Add3.Text = row["BUYER_ADDRESS2"].ToString();
                    txtBuyer_Add4.Text = row["BUYER_ADDRESS3"].ToString();
                    txtBuyer_Add5.Text = row["BUYER_ADDRESS4"].ToString();

                    txtPort_Of_Discharge.Text = row["PORT_DISCHARGE"].ToString();

                    TRANSPORT_MODE = row["TRANSPORT_MODE"].ToString();
                    txtPort_Of_Loading.Text = row["CUSTOMS_HOUSE"].ToString();


                    //txtPort_Of_Loading.Text = row["PORT_LOADING"].ToString();
                    txtFinal_Destination.Text = row["PORT_FINAL_DEST"].ToString();

                    txtCountry_Origin_Goods.Text = row["COUNTRY_DISCHARGE"].ToString();
                    txtCountry_Final_Destination.Text = row["COUNTRY_FINAL_DEST"].ToString();


                    txtTerms_Delivery_Payment.Text = "";
                    txtRemarks.Text = "";
                    txtQuality.Text = "";
                    txtRate.Text = "";
                    txtamount.Text = "";
                    txtFreight.Text = "";
                    txtDiscount.Text = "";
                    txtTotal.Text = "";
                    txtRupees.Text = "";

                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                    btn_Report.Visible = false;
                    //------------------------------------BIND INVOICE GRID-------------------------------------------------//

                    if (dtuser.Tables[1].Rows.Count > 0)
                    {
                        gvAll.DataSource = dtuser.Tables[1];
                        gvAll.DataBind();

                        ViewState["CurrentTable"] = null;
                        ViewState["CurrentTable"] = dtuser.Tables[1];

                    }
                    else
                    {
                        pageload();
                    }
                    //------------------------------------BIND INVOICE GRID-------------------------------------------------//
                }
            }
            else if (i == 2)
            {
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    DataRow row;
                    row = dtuser.Tables[0].Rows[0];
                    hdn_val.Value = row["INV_RPT_ID"].ToString();

                    txtInvoiceNo_Date.Text = row["INVOICE_NO_DATE"].ToString();
                    txtExporters_Ref.Text = row["EXPORTERS_REF"].ToString();
                    txtBuyerOrderNo_Date.Text = row["BUYER_ORDER_NO_DATE"].ToString();
                    txtOther_References.Text = row["OTHER_REFERENCES"].ToString();

                    txtExporter.Text = row["EXPORTER_NAME"].ToString();
                    BRANCH_NO = row["BRANCH_NO"].ToString();
                    IEC_NO = row["IEC_NO"].ToString();
                    txtAddress1.Text = row["ADDRESS1"].ToString();
                    txtAddress2.Text = row["ADDRESS2"].ToString();
                    txtAddress3.Text = row["ADDRESS3"].ToString();
                    txtAddress4.Text = row["ADDRESS4"].ToString();
                    txtAddress5.Text = row["ADDRESS5"].ToString();

                    txtConsignee.Text = row["CONSIGNEE_NAME"].ToString();
                    txtConsignee_Add1.Text = row["CONSIGNEE_ADD1"].ToString();
                    txtConsignee_Add2.Text = row["CONSIGNEE_ADD2"].ToString();
                    txtConsignee_Add3.Text = row["CONSIGNEE_ADD3"].ToString();
                    txtConsignee_Add4.Text = row["CONSIGNEE_ADD4"].ToString();
                    txtConsignee_Add5.Text = row["CONSIGNEE_ADD5"].ToString();

                    txtBuyer.Text = row["BUYER_NAME"].ToString();
                    txtBuyer_Add1.Text = row["BUYER_ADD1"].ToString();
                    txtBuyer_Add2.Text = row["BUYER_ADD2"].ToString();
                    txtBuyer_Add3.Text = row["BUYER_ADD3"].ToString();
                    txtBuyer_Add4.Text = row["BUYER_ADD4"].ToString();
                    txtBuyer_Add5.Text = row["BUYER_ADD5"].ToString();

                    txtNotify.Text = row["NOTIFY_NAME"].ToString();
                    txtNotify_Add1.Text = row["NOTIFY_ADD1"].ToString();
                    txtNotify_Add2.Text = row["NOTIFY_ADD2"].ToString();
                    txtNotify_Add3.Text = row["NOTIFY_ADD3"].ToString();
                    txtNotify_Add4.Text = row["NOTIFY_ADD4"].ToString();
                    txtNotify_Add5.Text = row["NOTIFY_ADD5"].ToString();


                    txtPre_Carriageby.Text = row["PRE_CARRIAGE_BY"].ToString();
                    txtPlace_ReceiptBy_PreCarrier.Text = row["PLACE_OF_RECEIPT"].ToString();
                    txtVessel_Flight_No.Text = row["VESSEL_FLIGHT_NO"].ToString();
                    txtPort_Of_Discharge.Text = row["PORT_OF_DISCHARGE"].ToString();
                    txtPort_Of_Loading.Text = row["PORT_OF_LOADING"].ToString();
                    txtFinal_Destination.Text = row["FINAL_DEST"].ToString();

                    txtCountry_Origin_Goods.Text = row["COUNTRY_OF_ORIGIN"].ToString();
                    txtCountry_Final_Destination.Text = row["COUNTRY_OF_FINAL_DEST"].ToString();
                    txtTerms_Delivery_Payment.Text = row["TERMS_OF_DELIVERY_PAYMENT"].ToString();
                    txtRemarks.Text = row["REMARKS"].ToString();
                    txtQuality.Text = row["QTY"].ToString();
                    txtRate.Text = row["RATE"].ToString();
                    txtamount.Text = row["TOTAL"].ToString();
                    txtFreight.Text = row["FREIGHT"].ToString();
                    txtDiscount.Text = row["DISCOUNT"].ToString();
                    txtTotal.Text = row["FINAL_TOTAL"].ToString();
                    txtRupees.Text = row["ITEM_QTY_CODE"].ToString();


                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                    btn_Report.Visible = true;
                    //------------------------------------BIND INVOICE GRID-------------------------------------------------//
                    if (dtuser.Tables[1].Rows.Count > 0)
                    {
                        gvAll.DataSource = dtuser.Tables[1];
                        gvAll.DataBind();

                        ViewState["CurrentTable"] = dtuser.Tables[1];
                    }
                    else
                    {
                        pageload();
                    }
                    //------------------------------------BIND INVOICE GRID-------------------------------------------------//

                }

            }
        }
        
    }

    public DataSet _Insert_Update(string Flag, string id)
    {

        inv.INV_RPT_ID = id;
        inv.JOBNO = ddlJobNo.SelectedValue;
        inv.EXPORTERS_REF = FILE_REF_NO;
        //inv.TO_ORDER = txtToOrder.Text;
        inv.INVOICE_NO_DATE = txtInvoiceNo_Date.Text;
        inv.EXPORTERS_REF = txtExporters_Ref.Text;
        inv.BUYER_ORDER_NO_DATE = txtBuyerOrderNo_Date.Text;
        inv.OTHER_REFERENCES = txtOther_References.Text;
     
        inv.EXPORTER_NAME = txtExporter.Text;
        inv.BRANCH_NO = BRANCH_NO;
        inv.IEC_NO = IEC_NO;
        inv.ADDRESS1 = txtAddress1.Text;
        inv.ADDRESS2 = txtAddress2.Text;
        inv.ADDRESS3 = txtAddress3.Text;
        inv.ADDRESS4 = txtAddress4.Text;
        inv.ADDRESS5 = txtAddress5.Text;


        inv.CONSIGNEE_NAME = txtConsignee.Text;
        inv.CONSIGNEE_ADD1 = txtConsignee_Add1.Text;
        inv.CONSIGNEE_ADD2 = txtConsignee_Add2.Text;
        inv.CONSIGNEE_ADD3 = txtConsignee_Add3.Text;
        inv.CONSIGNEE_ADD4 = txtConsignee_Add4.Text;
        inv.CONSIGNEE_ADD5 = txtConsignee_Add5.Text;

        inv.BUYER_NAME = txtBuyer.Text;
        inv.BUYER_ADD1 = txtBuyer_Add1.Text;
        inv.BUYER_ADD2 = txtBuyer_Add2.Text;
        inv.BUYER_ADD3 = txtBuyer_Add3.Text;
        inv.BUYER_ADD4 = txtBuyer_Add4.Text;
        inv.BUYER_ADD5 = txtBuyer_Add5.Text;


        inv.NOTIFY_NAME = txtNotify.Text;
        inv.NOTIFY_ADD1 = txtNotify_Add1.Text;
        inv.NOTIFY_ADD2 = txtNotify_Add2.Text;
        inv.NOTIFY_ADD3 = txtNotify_Add3.Text;
        inv.NOTIFY_ADD4 = txtNotify_Add4.Text;
        inv.NOTIFY_ADD5 = txtNotify_Add5.Text;

        inv.PRE_CARRIAGE_BY = txtPre_Carriageby.Text;
        inv.PLACE_OF_RECEIPT = txtPlace_ReceiptBy_PreCarrier.Text;

        inv.VESSEL_FLIGHT_NO = txtVessel_Flight_No.Text;
        inv.PORT_OF_LOADING = txtPort_Of_Loading.Text;
        inv.PORT_OF_DISCHARGE = txtPort_Of_Discharge.Text;
        inv.FINAL_DEST = txtFinal_Destination.Text;
        inv.PORT_OF_DISCHARGE = txtPort_Of_Discharge.Text;
        inv.PORT_OF_LOADING = txtPort_Of_Loading.Text;
        inv.FINAL_DEST = txtFinal_Destination.Text;

        inv.COUNTRY_OF_ORIGIN = txtCountry_Origin_Goods.Text;
        inv.COUNTRY_OF_FINAL_DEST = txtCountry_Final_Destination.Text;
        inv.TERMS_OF_DELIVERY_PAYMENT = txtTerms_Delivery_Payment.Text;
        inv.REMARKS = txtRemarks.Text;
        inv.QTY = txtQuality.Text;
        inv.RATE = txtRate.Text;
        inv.TOTAL = txtamount.Text;
        inv.FREIGHT = txtFreight.Text;
        inv.DISCOUNT = txtDiscount.Text;
        inv.FINAL_TOTAL = txtTotal.Text;
        inv.ITEM_QTY_CODE = txtRupees.Text;//rupees
       
        inv.USER_ID = currentuser;
        inv.YEAR = "";
        inv.flag = Flag;
        inv.BRANCH_CODE = currentbranch;
        inv.WORKING_PERIOD = Working_Period;
        inv.BRANCH_COMMON = SELECT_BRANCH;

        
        dss = inv.Invoice_report_details_insertupdate();
        
        i = inv.result;
       
        return dss;
    }

    public int Get_MAXID(string Flag)
    {
        DataSet dt_max = new DataSet();
        int MAX_ID = 0;

        inv.INV_RPT_ID = "";
        inv.JOBNO = ddlJobNo.SelectedValue;
        inv.Ename = Flag;
        inv.WORKING_PERIOD = SELECT_BRANCH;
        dt_max = inv.Retrieve_All_Export_Invoice_Rpt_Select();

        if (dt_max.Tables[0].Rows.Count > 0)
        {
            MAX_ID = Convert.ToInt32(dt_max.Tables[0].Rows[0]["MAXID"].ToString());
        }
       
        return MAX_ID;
    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {

            F = "S";
            _Insert_Update(F, "0");

             if (i == 1)
            {

            DataTable dtt = new DataTable();
            DataRow dr;

            dtt.Columns.Add(new System.Data.DataColumn("ITEM_ID", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("MARKS_NOS", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("DESCRIPTION", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("QTY", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("RATE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("TOTAL", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("FINAL_TOTAL", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("FREIGHT", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("DISCOUNT", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("RUPEES", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("disam", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("RECNO", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));
          

            int x = 1;
            int MAX_ID = Get_MAXID("Get_INVOICE_MAXID");
            int Max_SlNo = Get_MAXID("Get_INVOICE_GRID_MAXID");

            foreach (GridViewRow row in gvAll.Rows)
            {
                TextBox txtftrItem_marks = (TextBox)row.FindControl("txtftrItem_marks");
                TextBox txtftrItem_desc = (TextBox)row.FindControl("txtftrItem_desc");
                TextBox txtftrItem_Qty = (TextBox)row.FindControl("txtftrItem_Qty");
                TextBox txtftrItem_rate = (TextBox)row.FindControl("txtftrItem_rate");
                TextBox txtftrItem_total = (TextBox)row.FindControl("txtftrItem_total");

                if (txtftrItem_desc.Text == string.Empty)
                {
                }
                else
                {
                    dr = dtt.NewRow();

                    dr[0] = Max_SlNo;
                    dr[1] = ddlJobNo.SelectedItem.Text;
                    dr[2] = txtftrItem_marks.Text;
                    dr[3] = txtftrItem_desc.Text;
                    dr[4] = txtftrItem_Qty.Text;
                    dr[5] = txtftrItem_rate.Text;
                    dr[6] = txtftrItem_total.Text;
                    dr[7] = "";
                    dr[8] = "";
                    dr[9] = "";
                    dr[10] = "";
                    dr[11] = "";
                    dr[12] = "";
                    dr[13] = Connection.Current_Branch();

                    dtt.Rows.Add(dr);
                    x = x + 1;
                    MAX_ID = MAX_ID + 1;
                }
            }

            if (dtt.Rows.Count > 0)
            {
                AdminMasterDetails adm = new AdminMasterDetails();
                adm.SqlBulk_Upload_Product("EXPORT_INVOICE_GRID_REPORT_DETAILS", dtt, Session["currentcomp_db"].ToString());
            }

                hdn_val.Value = Convert.ToString(inv.update_id);
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btn_Report.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;

                txtExporter.Focus();

                Alert_msg("Saved Successfully", "btnSave");

            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnSave");

            }
            else
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btn_Report.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;


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

            F = "U";
            _Insert_Update(F, hdn_val.Value);


            DataTable dtt = new DataTable();
            DataRow dr;

            dtt.Columns.Add(new System.Data.DataColumn("ITEM_ID", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("MARKS_NOS", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("DESCRIPTION", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("QTY", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("RATE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("TOTAL", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("FINAL_TOTAL", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("FREIGHT", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("DISCOUNT", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("RUPEES", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("disam", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("RECNO", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));


            int x = 1;
            int MAX_ID = Get_MAXID("Get_INVOICE_MAXID");
            int Max_SlNo = Get_MAXID("Get_INVOICE_GRID_MAXID");

            foreach (GridViewRow row in gvAll.Rows)
            {
                TextBox txtftrItem_marks = (TextBox)row.FindControl("txtftrItem_marks");
                TextBox txtftrItem_desc = (TextBox)row.FindControl("txtftrItem_desc");
                TextBox txtftrItem_Qty = (TextBox)row.FindControl("txtftrItem_Qty");
                TextBox txtftrItem_rate = (TextBox)row.FindControl("txtftrItem_rate");
                TextBox txtftrItem_total = (TextBox)row.FindControl("txtftrItem_total");

                if (txtftrItem_desc.Text == string.Empty)
                {
                }
                else
                {
                    dr = dtt.NewRow();

                    dr[0] = Max_SlNo;
                    dr[1] = ddlJobNo.SelectedItem.Text;
                    dr[2] = txtftrItem_marks.Text;
                    dr[3] = txtftrItem_desc.Text;
                    dr[4] = txtftrItem_Qty.Text;
                    dr[5] = txtftrItem_rate.Text;
                    dr[6] = txtftrItem_total.Text;
                    dr[7] = "";
                    dr[8] = "";
                    dr[9] = "";
                    dr[10] = "";
                    dr[11] = "";
                    dr[12] = "";
                    dr[13] = Connection.Current_Branch();

                    dtt.Rows.Add(dr);
                    x = x + 1;
                    MAX_ID = MAX_ID + 1;
                }
            }

            if (dtt.Rows.Count > 0)
            {
                Delete_Grid_Items();
                AdminMasterDetails adm = new AdminMasterDetails();
                adm.SqlBulk_Upload_Product("EXPORT_INVOICE_GRID_REPORT_DETAILS", dtt, Session["currentcomp_db"].ToString());
            }


            if (i == 1)
            {

                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btn_Report.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;

                txtExporter.Focus();
                Alert_msg("Updated Successfully", "btnUpdate");

            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnUpdate");

            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btn_Report.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;


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
            inv.INV_RPT_ID = "";
            inv.JOBNO = ddlJobNo.SelectedValue;
            inv.Ename = "Delete";
            inv.WORKING_PERIOD = SELECT_BRANCH;
            dtuser = inv.Retrieve_All_Export_Invoice_Rpt_Select();
            i = inv.result;

            if (i == 1)
            {
                btnNew_Click(sender, e);
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
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Clear();
       
        txtExporter.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        hdn_val.Value = "";
       
        btn_Report.Visible = false;

    }

    protected void Clear()
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_changed();
        opentab1();
    }
   
    public void ddl_changed()
    {

        if (ddlJobNo.SelectedValue.ToString() != "Select")
            Bind_Job_Details();
        else
        {
            Clear();
            Alert_msg("Job No cannot be empty!..");
        }
    }
    protected void gvAll_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item_id = e.Row.Cells[0].Text;        
        }
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
   
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        //http://www.codeproject.com/Articles/30722/How-to-save-data-from-a-DataSet-into-a-T-SQL-table
        // sp_name EXP_BL_GENERATION_INS_UPD
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
                    TextBox txtftrItem_marks = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_marks");
                    TextBox txtftrItem_desc = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_desc");
                    TextBox txtftrItem_Qty = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_Qty");
                    TextBox txtftrItem_rate = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_rate");
                    TextBox txtftrItem_total = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_total");

                    if (txtftrItem_desc.Text == string.Empty)
                    {
                        Emptyrow = "Y";
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["MARKS_NOS"] = txtftrItem_marks.Text;
                    dtCurrentTable.Rows[i - 1]["DESCRIPTION"] = txtftrItem_desc.Text;
                    dtCurrentTable.Rows[i - 1]["QTY"] = txtftrItem_Qty.Text;
                    dtCurrentTable.Rows[i - 1]["RATE"] = txtftrItem_rate.Text;
                    dtCurrentTable.Rows[i - 1]["TOTAL"] = txtftrItem_total.Text;

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
        SetPreviousData();
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
                    //extract the TextBox values
                    TextBox txtftrItem_marks = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_marks");
                    TextBox txtftrItem_desc = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_desc");
                    TextBox txtftrItem_Qty = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_Qty");
                    TextBox txtftrItem_rate = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_rate");
                    TextBox txtftrItem_total = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_total");

                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["MARKS_NOS"] = txtftrItem_marks.Text;
                    dtCurrentTable.Rows[i - 1]["DESCRIPTION"] = txtftrItem_desc.Text;
                    dtCurrentTable.Rows[i - 1]["QTY"] = txtftrItem_Qty.Text;
                    dtCurrentTable.Rows[i - 1]["RATE"] = txtftrItem_rate.Text;
                    dtCurrentTable.Rows[i - 1]["TOTAL"] = txtftrItem_total.Text;
                 
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
                    TextBox txtftrItem_marks = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_marks");
                    TextBox txtftrItem_desc = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_desc");
                    TextBox txtftrItem_Qty = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_Qty");
                    TextBox txtftrItem_rate = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_rate");
                    TextBox txtftrItem_total = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtftrItem_total");
                  
                    //gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1); // set row number

                    //if (dt.Rows[i][3].ToString() != "")
                    //{
                        txtftrItem_marks.Text = dt.Rows[i][2].ToString();
                        txtftrItem_desc.Text = dt.Rows[i][3].ToString();
                        txtftrItem_Qty.Text = dt.Rows[i][4].ToString();
                        txtftrItem_rate.Text = dt.Rows[i][5].ToString();
                        txtftrItem_total.Text = dt.Rows[i][6].ToString();

                        rowIndex++;
                    //}
                    //else
                    //{
                    //    txtftrItem_marks.Text = "";
                    //    txtftrItem_desc.Text = "";
                    //    txtftrItem_Qty.Text = "";
                    //    txtftrItem_rate.Text = "";
                    //    txtftrItem_total.Text = "";                    
                    //}
                }
            }
        }
    }

  
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'INVOICE REPORT', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'INVOICE REPORT', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void opentab1()
    {
        tab2.Style.Add("display", "none");
        pop_text_area_transac_popup_inn_container_export1.Style.Add("display", "block");

        btn_next.Style.Add("display", "block");
        btn_prev.Style.Add("display", "none");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>btn_move_prev();</script>", false);

    }
   
}