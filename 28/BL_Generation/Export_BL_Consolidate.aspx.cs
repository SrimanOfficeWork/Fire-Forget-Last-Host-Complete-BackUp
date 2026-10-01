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

public partial class Export_BL_Consolidate : ThemeClass
{
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    Export_BL_Multiple EBM = new Export_BL_Multiple();
    User_Creation user_Create = new User_Creation();

    public int i;
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
       
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
                hdBranch.Value = SELECT_BRANCH;
                Session["DB_no_Branch"] = SELECT_BRANCH;
            }
            else
            {
                SELECT_BRANCH = "";
                hdBranch.Value = "";
                Session["DB_no_Branch"] = "";
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
            //SetInitialRow();
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            Page_Rights(Screen_Id);
            //----------------SETTING SCREEN PERMISSION---------------//
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;

            Tr_mode_load();
            Get_Pkgs_Unit();
            if (Request.QueryString["Page"] == "New")
            {
                Exporter_Name_Load();
                Div_listbox.Visible = false;

                HD_Showcon.Value = "NEW";
                HDupdate_id.Value = "";
                if (!IsPostBack)
                {
                    txt_DBDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {

                    Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    HDupdate_id.Value = Request.QueryString["Page"].ToString();

                    //ddltr_mode.Attributes.Add("readonly", "readonly");
                    ddltr_mode.Enabled = false;

                    HD_Showcon.Value = "SAVED"; 
                }
            }           
        }

        HDEXP_Name.Value = ddlExp_name.SelectedItem.Text;
        HDR_ID.Value=txtId.Text;


        txtExporter.Attributes.Add("onblur", "javascript:CallServerside_Exporter_2('" + txtExporter.ClientID + "', '" + hd_Brslno.ClientID + "','" +" Exporter" + "')");
        txtConsignee.Attributes.Add("onblur", "javascript:CallServerside_Consignee_2('" + txtConsignee.ClientID + "', '" + hd_Brslno.ClientID + "', '" + "Consignee" + "')");
        txtNotify.Attributes.Add("onblur", "javascript:CallServerside_Report_NotifyName('" + txtNotify.ClientID + "', '" + hd_Brslno.ClientID + "', '" + "Notify" + "')");
        txt_OceanVessel.Attributes.Add("onblur", "javascript:CallServerside_Report_NotifyName('" + txt_OceanVessel.ClientID + "', '" + "OceanVessel" + "')");

        txt_Currency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txt_Currency.ClientID + "', '" + txt_Currency.ClientID + "')");

        txt_DBNo.Attributes.Add("readonly", "readonly");
    }

    private void Update_Item_Load()
    {
        DataSet ds = new DataSet();
        EBM.Exp_name = Request.QueryString["Page"].ToString();
        EBM.Branch = SELECT_BRANCH;
        EBM.Flag = "Select_Update_Data";
        ds = EBM.Exp_Name();
        ddlExp_name.DataSource = ds.Tables[0];
        ddlExp_name.DataTextField = "MASTER_EXPORTER_NAME";
        ddlExp_name.DataValueField = "MASTER_EXPORTER_NAME";
        ddlExp_name.DataBind();

        //JOBNO

        txtId.Text = ds.Tables[0].Rows[0]["R_ID"].ToString();
        txtrefname.Text = ds.Tables[0].Rows[0]["REF_NAME"].ToString();
        txtExporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
        txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
        txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
        txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
        txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
        txtAddress5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

        txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
        txtConsignee_Add1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
        txtConsignee_Add2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
        txtConsignee_Add3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
        txtConsignee_Add4.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();

        txtNotify.Text = ds.Tables[0].Rows[0]["BUYER_NAME"].ToString();
        txtNotify_Add1.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS"].ToString();
        txtNotify_Add2.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS1"].ToString();
        txtNotify_Add3.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS2"].ToString();
        txtNotify_Add4.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS3"].ToString();
        txtNotify_Add5.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS4"].ToString();

        TextNotify1_1.Text = ds.Tables[0].Rows[0]["NOTIFY_1_1"].ToString();
        TextNotify1_2.Text = ds.Tables[0].Rows[0]["NOTIFY_1_2"].ToString();
        TextNotify1_3.Text = ds.Tables[0].Rows[0]["NOTIFY_1_3"].ToString();
        TextNotify1_4.Text = ds.Tables[0].Rows[0]["NOTIFY_1_4"].ToString();
        TextNotify1_5.Text = ds.Tables[0].Rows[0]["NOTIFY_1_5"].ToString();

        txt_BL_No.Text = ds.Tables[0].Rows[0]["BL_NUMBER"].ToString();
        txt_ShipmentRefno.Text = ds.Tables[0].Rows[0]["SHIP_REF_NO"].ToString();
        txt_Jobdate.Text = ds.Tables[0].Rows[0]["JOB_DATE"].ToString();

        txt_Place_Receipt.Text = ds.Tables[0].Rows[0]["PLACE_OF_RECEIPT"].ToString();
        txt_Date_Receipt.Text = ds.Tables[0].Rows[0]["DATE_OF_RECEIPT"].ToString();
        txt_OceanVessel.Text = ds.Tables[0].Rows[0]["OCEAN_VESSEL"].ToString();

        txt_Place_Delivery.Text = ds.Tables[0].Rows[0]["PLACE_OF_DELIVERY"].ToString();
        txt_PortLoading.Text = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
        txt_Portdischarge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();

        txt_freight_amt.Text = ds.Tables[0].Rows[0]["FREIGHT_AMT"].ToString();
        txt_freight_payable.Text = ds.Tables[0].Rows[0]["FREIGHT_PAYABLE"].ToString();
        txt_no_of_Original_BL.Text = ds.Tables[0].Rows[0]["NO_OF_ORGINAL_BL"].ToString();
        txt_AgentRefNo.Text = ds.Tables[0].Rows[0]["AGENTS_NAEE_REFNO"].ToString();

        txt_place_date.Text = ds.Tables[0].Rows[0]["PLACE_DATE"].ToString();
        txt_Invoice_No.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
        txt_IEC_No.Text = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
        txt_SB_No.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString();
        txt_HSS_Code.Text = ds.Tables[0].Rows[0]["HSS_CODE_NO"].ToString();
        txt_LC_No.Text = ds.Tables[0].Rows[0]["LC_NO"].ToString();
        txt_OrderNo.Text = ds.Tables[0].Rows[0]["ORDER_NO"].ToString();
        txt_TotalVolume.Text = ds.Tables[0].Rows[0]["TOTALVOLUME"].ToString();

        ddltr_mode.SelectedValue = ds.Tables[0].Rows[0]["MODE"].ToString();

        txt_Marks_Nos.Text = ds.Tables[0].Rows[0]["MARKS_NUMBERS"].ToString();
        txt_Description.Text = ds.Tables[0].Rows[0]["GOODS_DESC"].ToString();

        txt_Voyage.Text = ds.Tables[0].Rows[0]["VOYAGE"].ToString();
        ddl_Pkgs_Unit.SelectedValue = ds.Tables[0].Rows[0]["TOT_PKGS_UNIT"].ToString();
        txt_Commodity.Text = ds.Tables[0].Rows[0]["COMMODITY"].ToString();


        if (ds.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString() != string.Empty && ds.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString() != null)
        {
            ddl_ShipmentType.SelectedValue = ds.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString();
        }

        txt_DBNo.Text = ds.Tables[0].Rows[0]["DBN_NO"].ToString();

        if (ds.Tables[0].Rows[0]["DB_YES_NO"].ToString() != null && ds.Tables[0].Rows[0]["DB_YES_NO"].ToString() == "Y")
        {
            DB_Check.Checked = true;
        }
        else
        {
            DB_Check.Checked = false;
        }
        txt_DBDate.Text = ds.Tables[0].Rows[0]["DBN_DATE"].ToString();
        if (ds.Tables[0].Rows[0]["TOT_VOL_UNIT"].ToString() != string.Empty && ds.Tables[0].Rows[0]["TOT_VOL_UNIT"].ToString() != null)
        {
            ddl_Total_Volume_unit.SelectedValue = ds.Tables[0].Rows[0]["TOT_VOL_UNIT"].ToString();
        }
        txt_No_Of_Containers.Text = ds.Tables[0].Rows[0]["NO_OF_CONTAINERS"].ToString();
        txt_Currency.Text = ds.Tables[0].Rows[0]["CURRENCY"].ToString();
        txt_ExRate.Text = ds.Tables[0].Rows[0]["EX_RATE"].ToString();
        txt_Percent.Text = ds.Tables[0].Rows[0]["PERCENTAGE"].ToString();
        txt_Tot_BillAmt.Text = ds.Tables[0].Rows[0]["TOTAL_BILLAMT"].ToString();
        ddl_ReportType.SelectedValue = ds.Tables[0].Rows[0]["REPORT_TYPE"].ToString();

        txt_tax_leg_1.Text = ds.Tables[0].Rows[0]["TAX_LEDGER_1"].ToString();
        txt_tax_leg_2.Text = ds.Tables[0].Rows[0]["TAX_LEDGER_2"].ToString();
        txt_tax_leg_3.Text = ds.Tables[0].Rows[0]["TAX_LEDGER_3"].ToString();
        txt_leg_Per_1.Text = ds.Tables[0].Rows[0]["LEDGER_1_TAX"].ToString();
        txt_leg_Per_2.Text = ds.Tables[0].Rows[0]["LEDGER_2_TAX"].ToString();
        txt_leg_Per_3.Text = ds.Tables[0].Rows[0]["LEDGER_3_TAX"].ToString();
        txt_tax_amt_1.Text = ds.Tables[0].Rows[0]["LEDGER_1_TAX_AMT"].ToString();
        txt_tax_amt_2.Text = ds.Tables[0].Rows[0]["LEDGER_2_TAX_AMT"].ToString();
        txt_tax_amt_3.Text = ds.Tables[0].Rows[0]["LEDGER_3_TAX_AMT"].ToString();
        txt_grandtotal.Text = ds.Tables[0].Rows[0]["GRAND_TOTAL"].ToString();
        txt_HSNCode.Text = ds.Tables[0].Rows[0]["HSN_CODE"].ToString();

        if (txt_grandtotal.Text == "0.00" || txt_grandtotal.Text == "")
        {
            ddl_TAX.SelectedValue = "NonTaxable";
            txt_leg_Per_1.Text = "0.00";
            txt_leg_Per_2.Text = "0.00";
            txt_leg_Per_3.Text = "0.00";
        }
        else
        {
            ddl_TAX.SelectedValue = "Taxable";

            double tot_taxAmt = Convert.ToDouble(txt_tax_amt_1.Text) + Convert.ToDouble(txt_tax_amt_2.Text) + Convert.ToDouble(txt_tax_amt_3.Text);
            txt_tottax_amt.Text = Convert.ToString(tot_taxAmt);
        }

        if (ds.Tables[0].Rows[0]["CONTAINER_Y_N"].ToString() == "Y")
        {
            CheckBox_Container.Checked = true;
            Link_Container.Visible = true;
        }
        else
        {
            CheckBox_Container.Checked = false;
            // Link_Container.Visible = false;
        }
        if (ds.Tables[0].Rows[0]["PENDING_Y_N"].ToString() == "Y")
        {
            CheckBox_Pending.Checked = true;
        }
        else
        {
            CheckBox_Pending.Checked = false;
        }

        if (ds.Tables[0].Rows[0]["FREIGHT_PRE_COL"].ToString() == "FREIGHT COLLECT")
        {
            RadioButtonList_Frt_Col.SelectedValue = "FREIGHT COLLECT";
        }
        else
        {
            //RadioButtonList_Frt_Col.SelectedIndex = 2;
            RadioButtonList_Frt_Col.SelectedValue = "FREIGHT PREPAID";
        }

        //***************************
        gvAll.Visible = true;

        gvAll.DataSource = ds.Tables[1];
        gvAll.DataBind();

        DataTable firstTable = ds.Tables[1];
        ViewState["CurrentTable"] = firstTable;

        //----------end

        cbList.DataSource = ds.Tables[2];
        cbList.DataTextField = "FILE_REF_NO";
        cbList.DataValueField = "JOBNO";
        cbList.DataBind();

        if (ds.Tables[2].Rows.Count > 0)
        {
            for (int i = 0; i <= ds.Tables[2].Rows.Count - 1; i++)
            {
                if (ds.Tables[2].Rows[i]["FeatureStatus"].ToString() == "True")
                {
                    cbList.Items[i].Selected = true;
                }
            }
        }

        if (ds.Tables[3].Rows.Count > 0)
        {


        }
        else
        {


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
    protected void gvAll_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAll.EditIndex = e.NewEditIndex;
    }
    protected void gvAll_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Height = 20;
        }
        
    }

    protected void gvAll_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      // SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                ViewState["CurrentTable"] = dt;
                //---------------------------------------------------------------------------------------
                DataTable dtnew = new DataTable();
                DataRow drnew = null;
                dtnew.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dtnew.Columns.Add(new DataColumn("Mark_No", typeof(string)));
                dtnew.Columns.Add(new DataColumn("no_pkg", typeof(string)));
                dtnew.Columns.Add(new DataColumn("desc", typeof(string)));
                dtnew.Columns.Add(new DataColumn("gross_wgt", typeof(string)));


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    drnew = dtnew.NewRow();
                    drnew["RowNumber"] = i+1;
                    drnew["Mark_No"] = dt.Rows[i][1].ToString();
                    drnew["no_pkg"] = dt.Rows[i][2].ToString();
                    drnew["desc"] = dt.Rows[i][3].ToString();
                    drnew["gross_wgt"] = dt.Rows[i][4].ToString();
                    dtnew.Rows.Add(drnew);
                }

                //---------------------------------------------------------------------------------------
                gvAll.DataSource = dtnew;
                gvAll.DataBind();
                //SetPreviousData();

            }
            else if (dt.Rows.Count == 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                drCurrentRow = dt.NewRow();
                drCurrentRow["RowNumber"] = i + 1;

                dt.Rows.Add(drCurrentRow);

                gvAll.DataSource = dt;
                gvAll.DataBind();

            }
        }
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "tab_page3();", true);
        txtfocus.Focus();
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
                    TextBox txtMark_No = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtMark_No");
                    TextBox txtno_pkg = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txtno_pkg");
                    TextBox txtdesc = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txtdesc");
                    TextBox txtgross_wgt = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txtgross_wgt");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Mark_No"] = txtMark_No.Text;
                    dtCurrentTable.Rows[i - 1]["no_pkg"] = txtno_pkg.Text;
                    dtCurrentTable.Rows[i - 1]["desc"] = txtdesc.Text;
                    dtCurrentTable.Rows[i - 1]["gross_wgt"] = txtgross_wgt.Text;

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
                    TextBox txtMark_No = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtMark_No");
                    TextBox txtno_pkg = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txtno_pkg");
                    TextBox txtdesc = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txtdesc");
                    TextBox txtgross_wgt = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txtgross_wgt");

                    gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                    txtMark_No.Text = dt.Rows[i]["Mark_No"].ToString();
                    txtno_pkg.Text = dt.Rows[i]["no_pkg"].ToString();
                    txtdesc.Text = dt.Rows[i]["desc"].ToString();
                    txtgross_wgt.Text = dt.Rows[i]["gross_wgt"].ToString();

                    rowIndex++;
                }
            }
        }
    }
    private void Exporter_Name_Load()
    {
        
        EBM.Branch = SELECT_BRANCH;
        EBM.Flag = "Select";
        ddlExp_name.DataSource = EBM.Exp_Name();
        ddlExp_name.DataTextField = "Exporter_Name";
        ddlExp_name.DataValueField = "Exporter_Name";
        ddlExp_name.DataBind();
        ddlExp_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlExp_name.SelectedIndex = 0;

        RadioButtonList_Frt_Col.SelectedValue = "FREIGHT COLLECT";
    
    }
    protected void ddlExp_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkbox_load("S", "Select_New","");
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
            EBM.Item_Id = Ref_id;
            EBM.Exp_name = ddlExp_name.SelectedItem.Text;
            EBM.Branch = SELECT_BRANCH;
            EBM.Flag = flag;
            EBM.Mode = ddltr_mode.SelectedItem.Text;

            ds = EBM.Exp_Name();
            cbList.DataSource = ds.Tables[0];
            cbList.DataTextField = "FILE_REF_NO";
            cbList.DataValueField = "JOBNO";
            cbList.DataBind();

            if (Type == "S")
            {
                txtId.Text = ds.Tables[3].Rows[0][0].ToString();
                txtrefname.Text = ds.Tables[4].Rows[0][0].ToString();
            }

            Div_listbox.Visible = true;
        }
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        txtfocus.Focus();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "tab_page3();", true);
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
                  

                    TextBox txtMark_No = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtMark_No");
                    TextBox txtno_pkg = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txtno_pkg");
                    TextBox txtdesc = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txtdesc");
                    TextBox txtgross_wgt = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txtgross_wgt");


                    if (txtMark_No.Text == string.Empty && txtno_pkg.Text == string.Empty && txtdesc.Text == string.Empty && txtgross_wgt.Text == string.Empty)
                    {
                        Emptyrow = "Y";
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["Mark_No"] = txtMark_No.Text;
                    dtCurrentTable.Rows[i - 1]["no_pkg"] = txtno_pkg.Text;
                    dtCurrentTable.Rows[i - 1]["desc"] = txtdesc.Text;
                    dtCurrentTable.Rows[i - 1]["gross_wgt"] = txtgross_wgt.Text;

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
            
        }

        //Set Previous Data on Postbacks
        SetPreviousData();
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
                    EBM.R_Id = "";
                }
                else
                {
                    EBM.R_Id = Request.QueryString["Page"].ToString();
                }
                EBM.Jobno = values;
                EBM.Exp_name = ddlExp_name.SelectedItem.Text;
                EBM.Branch = SELECT_BRANCH;
                EBM.Mode = ddltr_mode.SelectedItem.Text;
                EBM.Flag = "Generate";

                ds = EBM.New_item_load();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtExporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                    txtAddress5.Text = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();

                    txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    txtConsignee_Add1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                    txtConsignee_Add2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                    txtConsignee_Add3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                    txtConsignee_Add4.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();

                    txt_Jobdate.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                    txt_IEC_No.Text = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                    txt_Portdischarge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtNotify.Text = ds.Tables[1].Rows[0]["BUYER_NAME"].ToString();
                    txtNotify_Add1.Text = ds.Tables[1].Rows[0]["BUYER_ADDRESS"].ToString();
                    txtNotify_Add2.Text = ds.Tables[1].Rows[0]["BUYER_ADDRESS1"].ToString();
                    txtNotify_Add3.Text = ds.Tables[1].Rows[0]["BUYER_ADDRESS2"].ToString();
                    txtNotify_Add4.Text = ds.Tables[1].Rows[0]["BUYER_ADDRESS3"].ToString();
                    txtNotify_Add5.Text = ds.Tables[1].Rows[0]["BUYER_ADDRESS4"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txt_Invoice_No.Text = ds.Tables[2].Rows[0]["Invoice_No"].ToString();
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    txt_SB_No.Text = ds.Tables[3].Rows[0]["SB_No"].ToString();
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    //----------------------Update----------------------------------------
                    if (Request.QueryString["Page"] == "New")
                    {
                        DataTable firstTable = ds.Tables[4];
                        ViewState["CurrentTable"] = firstTable;

                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            gvAll.Visible = true;
                            gvAll.DataSource = ds.Tables[4];
                            gvAll.DataBind();
                        }
                    }
                    //------------------------Update--------------------------------------
                    else
                    {
                        if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                        {

                            DataTable firstTable = ds.Tables[5];
                            ViewState["CurrentTable"] = firstTable;

                            if (ds.Tables[5].Rows.Count > 0)
                            {
                                gvAll.Visible = true;
                                gvAll.DataSource = ds.Tables[5];
                                gvAll.DataBind();
                            }

                        }
                    }
                    //--------------------------------------------------------------
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
        txtExporter.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtAddress3.Text = "";
        txtAddress4.Text = "";
        txtAddress5.Text = "";

        txtConsignee.Text = "";
        txtConsignee_Add1.Text = "";
        txtConsignee_Add2.Text = "";
        txtConsignee_Add3.Text = "";
        txtConsignee_Add4.Text = "";

        txtNotify.Text = string.Empty;
        txtNotify_Add1.Text = string.Empty;
        txtNotify_Add2.Text = string.Empty;
        txtNotify_Add3.Text = string.Empty;
        txtNotify_Add4.Text = string.Empty;
        txtNotify_Add5.Text = string.Empty;

        txt_BL_No.Text = "";
        txt_ShipmentRefno.Text = "";
        txt_Place_Receipt.Text = "";
        txt_OceanVessel.Text = "";
        txt_PortLoading.Text = "";

        txt_freight_payable.Text = "";
        txt_place_date.Text = "";
        txt_Date_Receipt.Text = "";
        txt_Place_Delivery.Text = "";
        txt_Portdischarge.Text = "";
        txt_no_of_Original_BL.Text = "";

        txt_AgentRefNo.Text = "";
        txt_freight_amt.Text = "";

        TextNotify1_1.Text = "";
        TextNotify1_2.Text = "";
        TextNotify1_3.Text = "";
        TextNotify1_4.Text = "";
        TextNotify1_5.Text = "";
        txt_Invoice_No.Text = "";
        txt_IEC_No.Text = "";
        txt_SB_No.Text = "";
        txt_HSS_Code.Text = "";
        txt_LC_No.Text = "";
        txt_TotalVolume.Text = "";
        txt_OrderNo.Text = "";
        txt_Jobdate.Text = "";

        txt_Marks_Nos.Text = "";
        txt_Description.Text = "";
        txt_HSNCode.Text = "";

        txtrefname.Text = string.Empty;
        txtId.Text = string.Empty;
        DataTable dt = new DataTable();
        gvAll.DataSource = dt;
        gvAll.DataBind();

        gvAll.Visible = false;
        //SetInitialRow();
    }

    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Mark_No", typeof(string)));
        dt.Columns.Add(new DataColumn("no_pkg", typeof(string)));
        dt.Columns.Add(new DataColumn("desc", typeof(string)));
        dt.Columns.Add(new DataColumn("gross_wgt", typeof(string)));

        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Mark_No"] = string.Empty;
        dr["no_pkg"] = string.Empty;
        dr["desc"] = string.Empty;
        dr["gross_wgt"] = string.Empty;
        dt.Rows.Add(dr);

        //Store the DataTable in ViewState
        ViewState["CurrentTable"] = dt;

        gvAll.DataSource = dt;
        gvAll.DataBind();
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

                         DataTable dtt = new DataTable();
                         DataRow dr;
                         dtt.Columns.Add(new System.Data.DataColumn("Mark_No", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("no_pkg", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("desc", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("gross_wgt", typeof(String)));

                         dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("R_ID", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("MASTER_EXPORTER_NAME", typeof(String)));
             
                         dtt.Columns.Add(new System.Data.DataColumn("USERID", typeof(String)));

                         dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));
                         dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));


                         foreach (GridViewRow row in gvAll.Rows)
                         {

                             TextBox txtMark_No = (TextBox)row.FindControl("txtMark_No");
                             TextBox txtno_pkg = (TextBox)row.FindControl("txtno_pkg");
                             TextBox txtdesc = (TextBox)row.FindControl("txtdesc");
                             TextBox txtgross_wgt = (TextBox)row.FindControl("txtgross_wgt");

                             if (txtMark_No.Text == string.Empty && txtno_pkg.Text == string.Empty && txtdesc.Text == string.Empty && txtgross_wgt.Text == string.Empty)
                             {

                             }
                             else
                             {
                                 dr = dtt.NewRow();

                                 dr[0] = txtMark_No.Text;
                                 dr[1] = txtno_pkg.Text;
                                 dr[2] = txtdesc.Text;
                                 dr[3] = txtgross_wgt.Text;

                                 dr[4] = values;
                                 dr[5] = txtId.Text;
                                 dr[6] = ddlExp_name.SelectedItem.Text;
                                 dr[7] = currentuser;
                                 dr[8] = currentbranch;
                                 dr[9] = Working_Period;

                                 dtt.Rows.Add(dr);
                             }
                         }

                         DataSet dsData = new DataSet();
                         dsData.Tables.Add(dtt);

                         // Get the XML format of the data set.
                         String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
                         i = Export_Multiple_BL_Insert_Update( "S", xmlData);
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
                             HDupdate_id.Value = Convert.ToString(EBM.UPDATE_ID);
                         }
                         else if (i == 2)
                         {
                            //Alert_msg("Job No Already Exist!", "btnSave");
                             Alert_msg("Job No Already Exist!");
                         }
                         else
                         {
                             btnUpdate.Visible = false;
                             btnDelete.Visible = false;
                             btnSave.Visible = true;
                             btnNew.Visible = true;
                             //Alert_msg("Not Saved", "btnSave");
                             Alert_msg("Not Saved");

                         }
           //---------------------------------------------------------------------------------------------
              }
                 else
                     {
                         // Alert_msg("Select Exporter Name!", "btnSave");
                         Alert_msg("Select Exporter Name!");
                         
                     }
                }
                 else
                     {
                          //Alert_msg("Select Job Number!", "btnSave");
                         Alert_msg("Select Job Number!");
                     }

         }
         catch (Exception ex)
         {
             er.makeLog(ex.Message);
         }



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

              DataTable dtt = new DataTable();
              DataRow dr;
              dtt.Columns.Add(new System.Data.DataColumn("Mark_No", typeof(String)));
              dtt.Columns.Add(new System.Data.DataColumn("no_pkg", typeof(String)));
              dtt.Columns.Add(new System.Data.DataColumn("desc", typeof(String)));
              dtt.Columns.Add(new System.Data.DataColumn("gross_wgt", typeof(String)));

              dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
              dtt.Columns.Add(new System.Data.DataColumn("R_ID", typeof(String)));
              dtt.Columns.Add(new System.Data.DataColumn("MASTER_EXPORTER_NAME", typeof(String)));

              dtt.Columns.Add(new System.Data.DataColumn("USERID", typeof(String)));

              dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));
              dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));


              foreach (GridViewRow row in gvAll.Rows)
              {

                  TextBox txtMark_No = (TextBox)row.FindControl("txtMark_No");
                  TextBox txtno_pkg = (TextBox)row.FindControl("txtno_pkg");
                  TextBox txtdesc = (TextBox)row.FindControl("txtdesc");
                  TextBox txtgross_wgt = (TextBox)row.FindControl("txtgross_wgt");

                  if (txtMark_No.Text == string.Empty && txtno_pkg.Text == string.Empty && txtdesc.Text == string.Empty && txtgross_wgt.Text == string.Empty)
                  {

                  }
                  else
                  {
                      dr = dtt.NewRow();

                      dr[0] = txtMark_No.Text;
                      dr[1] = txtno_pkg.Text;
                      dr[2] = txtdesc.Text;
                      dr[3] = txtgross_wgt.Text;

                      dr[4] = values;
                      dr[5] = txtId.Text;
                      dr[6] = ddlExp_name.SelectedItem.Text;
                      dr[7] = currentuser;
                      dr[8] = currentbranch;
                      dr[9] = Working_Period;

                      dtt.Rows.Add(dr);
                  }
              }

              DataSet dsData = new DataSet();
              dsData.Tables.Add(dtt);

              // Get the XML format of the data set.
              String xmlData = ConvertDataTableToXML(dsData.Tables[0]);


              i = Export_Multiple_BL_Insert_Update("U", xmlData);
              if (i == 1)
              {

                  if (ViewState["UPDATED_ID"] != null)
                  {
                      //Alert_msg("Updated Successfully", "btnUpdate");
                      Alert_msg("Updated Successfully");

                  }
                  else
                  {
                      //Alert_msg("Saved Successfully", "btnUpdate");
                      Alert_msg("Saved Successfully");
                      HD_Showcon.Value = "SAVED"; 
                  }
              }
              else if (i == 2)
              {
                  //Alert_msg("Job No Already Exist!", "btnUpdate");
                  Alert_msg("Job No Already Exist!");
              }
              else
              {
                  btnUpdate.Visible = true;
                  btnDelete.Visible = true;
                  btnSave.Visible = false;
                  btnNew.Visible = true;
                  //Alert_msg("Not Saved", "btnUpdate");
                  Alert_msg("Not Saved");

              }

             //----------------------------------------------------------------------------------------------
                  }
                  else
                  {
                      //Alert_msg("Select Exporter Name!", "btnSave");
                      Alert_msg("Select Exporter Name!");
                  }


              }
              else
              {
                  //Alert_msg("Select Job Number!", "btnSave");
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

              EBM.UPD_ID = HDupdate_id.Value.ToString();
              EBM.R_ID = txtId.Text;
              EBM.M_EXP_NAME = ddlExp_name.SelectedItem.Text;
              EBM.Mode = ddltr_mode.SelectedItem.Text;
              EBM.Flag = "D";

              EBM.Multiple_BL_xml_INS_UPD();
              DataTable dt = new DataTable();
              gvAll.DataSource = dt;
              gvAll.DataBind();
              gvAll.Visible = false;
              i = EBM.result;

              if (i == 1)
              {
                  btnNew_Click(sender, e);
                  Alert_msg("Deleted");
                  Exporter_Name_Load();
                  Div_listbox.Visible = false;
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

    public int Export_Multiple_BL_Insert_Update(string a1, String xmlData_D)
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

                EBM.UPD_ID = HDupdate_id.Value.ToString();
                EBM.R_ID = txtId.Text;
                EBM.M_EXP_NAME = ddlExp_name.SelectedItem.Text;
                EBM.REF_NAME = txtrefname.Text;
                EBM.JOBNO = values;
                EBM.EXPORTER_NAME = txtExporter.Text;
                EBM.ADDRESS1=txtAddress1.Text;
                EBM.ADDRESS2=txtAddress2.Text;
                EBM.ADDRESS3=txtAddress3.Text;
                EBM.ADDRESS4=txtAddress4.Text;
                EBM.ADDRESS5 = txtAddress5.Text;

                EBM.CONSIGNEE_NAME=txtConsignee.Text;
                EBM.CONSIGNEE_ADD1=txtConsignee_Add1.Text;
                EBM.CONSIGNEE_ADD2=txtConsignee_Add2.Text;
                EBM.CONSIGNEE_ADD3=txtConsignee_Add3.Text;
                EBM.CONSIGNEE_ADD4=txtConsignee_Add4.Text;

                EBM.BUYER_NAME = txtNotify.Text;
                EBM.BUYER_ADDRESS = txtNotify_Add1.Text;
                EBM.BUYER_ADDRESS1 = txtNotify_Add2.Text;
                EBM.BUYER_ADDRESS2 = txtNotify_Add3.Text;
                EBM.BUYER_ADDRESS3 = txtNotify_Add4.Text;
                EBM.BUYER_ADDRESS4 = txtNotify_Add5.Text;

                EBM.NOTIFY_1_1 = TextNotify1_1.Text;
                EBM.NOTIFY_1_2 = TextNotify1_2.Text;
                EBM.NOTIFY_1_3 = TextNotify1_3.Text;
                EBM.NOTIFY_1_4 = TextNotify1_4.Text;
                EBM.NOTIFY_1_5 = TextNotify1_5.Text;

                EBM.BL_NUMBER=txt_BL_No.Text;
                EBM.SHIP_REF_NO=txt_ShipmentRefno.Text;
                EBM.JOB_DATE=txt_Jobdate.Text;
                    
                EBM.PLACE_OF_RECEIPT=txt_Place_Receipt.Text;
                EBM.DATE_OF_RECEIPT=txt_Date_Receipt.Text;
                    

                EBM.OCEAN_VESSEL=txt_OceanVessel.Text;
                EBM.PLACE_OF_DELIVERY = txt_Place_Delivery.Text;

                EBM.PORT_OF_LOADING = txt_PortLoading.Text;
                EBM.PORT_DISCHARGE=txt_Portdischarge.Text;
                EBM.FREIGHT_AMT=txt_freight_amt.Text;

                EBM.FREIGHT_PAYABLE=txt_freight_payable.Text;
                EBM.NO_OF_ORGINAL_BL=txt_no_of_Original_BL.Text;
                EBM.AGENTS_NAEE_REFNO=txt_AgentRefNo.Text;
                EBM.PLACE_DATE=txt_place_date.Text;
              
                EBM.INVOICE_NO=txt_Invoice_No.Text;
                EBM.IEC_NO=txt_IEC_No.Text;
                EBM.SB_NO=txt_SB_No.Text;

                
                EBM.HSS_CODE_NO=txt_HSS_Code.Text;
                EBM.LC_NO=txt_LC_No.Text;
                EBM.ORDER_NO=txt_OrderNo.Text;
                EBM.TOTALVOLUME=txt_TotalVolume.Text;

                EBM.CONTAINER_Y_N = CheckBox_Container.Checked == true ? "Y" : "N";
                EBM.PENDING_Y_N = CheckBox_Pending.Checked == true ? "Y" : "N";

                //EBM.FREIGHT_PRE_COL = RadioButtonList_Frt_Col.SelectedIndex >0 ? RadioButtonList_Frt_Col.SelectedItem.Text : " ";
                EBM.FREIGHT_PRE_COL = RadioButtonList_Frt_Col.SelectedValue;

                EBM.XML_Con_data = "";

                EBM.USERID = currentuser;
                EBM.Flag = a1;

                EBM.BRANCHCODE = currentbranch;
                EBM.Mode = ddltr_mode.SelectedItem.Text;

                EBM.WORKINGPERIOD = Working_Period;
                EBM.Branch = SELECT_BRANCH;

                EBM.Mark_No = txt_Marks_Nos.Text;
                EBM.Desc = txt_Description.Text;
                EBM.FILE_REF_NO = Items;

                EBM.TOT_VOL_UNIT = ddl_Total_Volume_unit.SelectedItem.Text;
                EBM.VOYAGE = txt_Voyage.Text;
                EBM.TOT_PKGS_UNIT = ddl_Pkgs_Unit.SelectedItem.Text;
                EBM.COMMODITY = txt_Commodity.Text;
                EBM.CURRENCY = txt_Currency.Text;
                EBM.EX_RATE = txt_ExRate.Text;
                EBM.NO_OF_CONTAINERS = txt_No_Of_Containers.Text;
                EBM.PERCENTAGE = txt_Percent.Text;
                EBM.TOTAL_BILLAMT = txt_Tot_BillAmt.Text;
                EBM.SHIPMENT_TYPE = ddl_ShipmentType.SelectedItem.Text;
                EBM.DBN_NO = txt_DBNo.Text;
                EBM.DBN_DATE = txt_DBDate.Text;
                EBM.DB_YES_NO = DB_Check.Checked==true ? "Y":"N";
                EBM.REPORT_TYPE = ddl_ReportType.SelectedItem.Text;

                EBM.TAX_LEDGER_1 = txt_tax_leg_1.Text;
                EBM.TAX_LEDGER_2 = txt_tax_leg_2.Text;
                EBM.TAX_LEDGER_3 = txt_tax_leg_3.Text;
                EBM.LEDGER_1_TAX = txt_leg_Per_1.Text;
                EBM.LEDGER_2_TAX = txt_leg_Per_2.Text;
                EBM.LEDGER_3_TAX = txt_leg_Per_3.Text;
                EBM.LEDGER_1_TAX_AMT = txt_tax_amt_1.Text;
                EBM.LEDGER_2_TAX_AMT = txt_tax_amt_2.Text;
                EBM.LEDGER_3_TAX_AMT = txt_tax_amt_3.Text;
                EBM.GRAND_TOTAL = txt_grandtotal.Text;
                EBM.HSN_CODE = txt_HSNCode.Text;

                EBM.Xml_D = xmlData_D;
                EBM.Multiple_BL_xml_INS_UPD();

                i = EBM.result;
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

        DataTable dt = new DataTable();
        gvAll.DataSource = dt;
        gvAll.DataBind();

        gvAll.Visible = false;

        Div_listbox.Visible = false;
        Clear();
        HDupdate_id.Value = string.Empty;
        txt_DBDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

    }
    public void Get_Pkgs_Unit()
    {
        adminmaster adm = new adminmaster();
        DataSet ds_unit = new DataSet();
        adm.Ename = "selectAll_Unit";
        ds_unit = adm.RetrieveAll_Unit_master();

        ddl_Pkgs_Unit.DataSource = ds_unit;
        ddl_Pkgs_Unit.DataTextField = "UNIT_CODE";
        ddl_Pkgs_Unit.DataValueField = "UNIT_CODE";
        ddl_Pkgs_Unit.DataBind();
        //Ddl_Pkgs_Unit.Items.Remove("0");
        ddl_Pkgs_Unit.Items.Insert(0, " ");
        ddl_Pkgs_Unit.Items.Insert(3, "BCT-BUCKETS");
        ddl_Pkgs_Unit.Items.Insert(32, "JBG-JUMBO BAGS");
        ddl_Pkgs_Unit.Items.Insert(69, "WBX-WOODEN BOXES");
        ddl_Pkgs_Unit.Items.Insert(70, "WBL-WOODEN BUNDLES");
        ddl_Pkgs_Unit.Items.Insert(71, "WCS-WOODEN CASES");
        ddl_Pkgs_Unit.Items.Insert(72, "WCT-WOODEN CRATES");
        ddl_Pkgs_Unit.Items.Insert(73, "WPL-WOODEN PALLETS");

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
           // ddltr_mode.Items.Add(new ListItem("All", "All"));
            ddltr_mode.Items.Add(new ListItem("Air", "Air"));
            ddltr_mode.Items.Add(new ListItem("Sea", "Sea"));
            ddltr_mode.Items.Add(new ListItem("Land", "Land"));

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
      //http://www.codersbarn.com/post/2008/10/12/Bind-CheckBoxList-to-DataSet.aspx
    //http://www.codersbarn.com/post/2008/10/12/Bind-CheckBoxList-to-DataSet.aspx
    //EXPORT_MULTIPLE_BL_GENERATION accordion 
    //http://www.aspdotnet-suresh.com/2011/04/ajax-accordion-control-example-or-how.html
    protected void ddltr_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkbox_load("S", "Select_New", "");
    }





    protected void btnpdf_Click(object sender, EventArgs e)
    {
        EBM.Export_to_Pdf();
    }

    [System.Web.Services.WebMethod]
    public static string Get_Report_Client_Details(string custid, string slno)
    {
        DataSet ds = new DataSet();
        try
        {
            Rpt_Client_Master Rpt_Clt = new Rpt_Client_Master();

            Rpt_Clt.RPT_ID = "";
            Rpt_Clt.CLIENT_NAME = custid;
            Rpt_Clt.CLIENT_TYPE = "Exporter";
            Rpt_Clt.CLIENT_WORKING_PERIOD = HttpContext.Current.Session["WorkingPeriod"].ToString();
            Rpt_Clt.CLIENT_BRANCH_CODE = slno;

            Rpt_Clt.Ename = "Bind_Report_ClientName_Type";
            ds = Rpt_Clt.RetrieveAll_Rpt_Client_Details();


            if (ds.Tables[0].Rows.Count > 0)
            {
                string txtAddress1 = ds.Tables[0].Rows[0]["CLIENT_ADD1"].ToString();
                string txtAddress2 = ds.Tables[0].Rows[0]["CLIENT_ADD2"].ToString();
                string txtAddress3 = ds.Tables[0].Rows[0]["CLIENT_ADD3"].ToString();
                string txtAddress4 = ds.Tables[0].Rows[0]["CLIENT_ADD4"].ToString();
                string txtAddress5 = ds.Tables[0].Rows[0]["CLIENT_COUNTRY_NAME"].ToString();
                string txt_Pincode = ds.Tables[0].Rows[0]["CLIENT_PINCODE"].ToString();
                custid = txtAddress1 + "~~" + txtAddress2 + "~~" + txtAddress3 + "~~" + txtAddress4 + "~~" + txtAddress5 + "~~" + txt_Pincode;

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Report_Consignee_Details(string custid, string slno)
    {
        DataSet ds = new DataSet();
        try
        {
            Rpt_Client_Master Rpt_Clt = new Rpt_Client_Master();

            Rpt_Clt.RPT_ID = "";
            Rpt_Clt.CLIENT_NAME = custid;
            Rpt_Clt.CLIENT_TYPE = "Consignee";
            Rpt_Clt.CLIENT_WORKING_PERIOD = HttpContext.Current.Session["WorkingPeriod"].ToString();
            Rpt_Clt.CLIENT_BRANCH_CODE = slno;

            Rpt_Clt.Ename = "Bind_Report_ClientName_Type";
            ds = Rpt_Clt.RetrieveAll_Rpt_Client_Details();


            if (ds.Tables[0].Rows.Count > 0)
            {
                string txtConsignee_Add1 = ds.Tables[0].Rows[0]["CLIENT_ADD1"].ToString();
                string txtConsignee_Add2 = ds.Tables[0].Rows[0]["CLIENT_ADD2"].ToString();
                string txtConsignee_Add3 = ds.Tables[0].Rows[0]["CLIENT_ADD3"].ToString();
                string txtConsignee_Add4 = ds.Tables[0].Rows[0]["CLIENT_ADD4"].ToString();
                string txtConsignee_Add5 = ds.Tables[0].Rows[0]["CLIENT_COUNTRY_NAME"].ToString();
                custid = txtConsignee_Add1 + "~~" + txtConsignee_Add2 + "~~" + txtConsignee_Add3 + "~~" + txtConsignee_Add4 + "~~" + txtConsignee_Add5;

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }

        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Report_Notify_Details(string name, string slno)
    {
        DataSet ds = new DataSet();
        try
        {
            Rpt_Client_Master Rpt_Clt = new Rpt_Client_Master();

            Rpt_Clt.RPT_ID = "";
            Rpt_Clt.CLIENT_NAME = name;
            Rpt_Clt.CLIENT_TYPE = "Notify";
            Rpt_Clt.CLIENT_WORKING_PERIOD = HttpContext.Current.Session["WorkingPeriod"].ToString();
            Rpt_Clt.CLIENT_BRANCH_CODE = slno;

            Rpt_Clt.Ename = "Bind_Report_ClientName_Type";
            ds = Rpt_Clt.RetrieveAll_Rpt_Client_Details();


            if (ds.Tables[0].Rows.Count > 0)
            {
                string txtNotify_Add1 = ds.Tables[0].Rows[0]["CLIENT_ADD1"].ToString();
                string txtNotify_Add2 = ds.Tables[0].Rows[0]["CLIENT_ADD2"].ToString();
                string txtNotify_Add3 = ds.Tables[0].Rows[0]["CLIENT_ADD3"].ToString();
                string txtNotify_Add4 = ds.Tables[0].Rows[0]["CLIENT_ADD4"].ToString();
                string txtNotify_Add5 = ds.Tables[0].Rows[0]["CLIENT_COUNTRY_NAME"].ToString();
                string txt_Pincode = ds.Tables[0].Rows[0]["CLIENT_PINCODE"].ToString();

                name = txtNotify_Add1 + "~~" + txtNotify_Add2 + "~~" + txtNotify_Add3 + "~~" + txtNotify_Add4 + "~~" + txtNotify_Add5 + "~~" + txt_Pincode;

            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }

        return name;
    }


    [System.Web.Services.WebMethod]
    public static string Get_DB_NUmber(string Branch)
    {
        DataSet ds = new DataSet();
        try
        {
            //Rpt_Client_Master Rpt_Clt = new Rpt_Client_Master();
            Export_BL_Multiple EBM = new Export_BL_Multiple();

            EBM.Branch = HttpContext.Current.Session["DB_no_Branch"].ToString(); ;
            EBM.Flag="Select_DB_Number";

            ds = EBM.Exp_Name();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string Db_no = ds.Tables[0].Rows[0]["Db_no"].ToString();
                Branch = Db_no;
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }

        return Branch;
    }
  
    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate(string custid)
    {
        if (custid.Length == 3)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
            Auto.Enamesearch = custid;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();

            }
            else
            {
                Auto.Ename = "NON_STD_CUR_RATE_EXPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    custid = ds.Tables[0].Rows[0]["NON_STD_RATE_EXPORT"].ToString();
                }
                else

                    custid = "";
            }
        }
        else
        {
            custid = "";
        }
        return custid;
    }

    //EXP_BL_MULTIPLE_SELECT

}
 

            
           