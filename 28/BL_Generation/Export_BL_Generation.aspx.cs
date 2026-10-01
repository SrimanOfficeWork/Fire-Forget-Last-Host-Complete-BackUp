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


public partial class Export_BL_Generation : ThemeClass
{
    Certificate_Of_Origin certificate = new Certificate_Of_Origin();
    EXP_BL_Generation BL_Gen = new EXP_BL_Generation();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    DataSet ds_unit = new DataSet();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    public int i;
    
    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string SELECT_TYPE, SELECT_BRANCH, Select_Freight, chk_container, chk_Pending, chk_ddl_pkg_unit, TRANSPORT_MODE;
    string CHA_NO;
    public string Company_Lic;

    Rpt_Invoice inv = new Rpt_Invoice();
    DataSet dss = new DataSet();
    DataRow dr;
    
    protected void Page_Load(object sender, EventArgs e)
        {
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();
        TRANSPORT_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
        Company_Lic = Connection.Company_License().ToLower();


        if (Working_Period != "")
        {         
            string WP1 = Working_Period.Substring(9, 2);
            string WP2 = Working_Period.Substring(23, 2);

            Hdn_Working_Period.Value = WP1 + "-" + WP2;
        }

         CHA_NO = Session["CHA_NO"].ToString();
       
         SELECT_BRANCH = Connection.Current_Branch();


        if (!IsPostBack)
        {
            string Category_mode = "";
            if (TRANSPORT_MODE == "A")
                Category_mode = "Air";
            if (TRANSPORT_MODE == "S")
                Category_mode = "Sea";
            if (TRANSPORT_MODE == "L")
                Category_mode = "Land";

            hdfTransport_mode1.Value = Category_mode;
            string Exporter = "Exporter";
            Session["Exporter"] = Exporter;
            string Consignee = "Consignee";
            Session["Consignee"] = Consignee;
            string Notify = "Notify";
            Session["Notify"] = Notify;
            string OceanVessel = "OceanVessel";
            Session["OceanVessel"] = OceanVessel;

            //hdn_CLIENT_TYPE.Value = "Exporter";

            //txtExporter.Attributes.Add("onblur", "javascript:CallServerside_Report_Client('" + txtExporter.ClientID + "', '" + Exporter + "')");
            //txtConsignee.Attributes.Add("onblur", "javascript:CallServerside_Report_ConsigneeName('" + txtConsignee.ClientID + "', '" + Consignee + "')");
            //txtNotify.Attributes.Add("onblur", "javascript:CallServerside_Report_NotifyName('" + txtNotify.ClientID + "', '" + Notify + "')");


            txtExporter.Attributes.Add("onblur", "javascript:CallServerside_Exporter_2('" + txtExporter.ClientID + "', '" + hd_Brslno.ClientID + "','" + Exporter + "')");
            txtConsignee.Attributes.Add("onblur", "javascript:CallServerside_Consignee_2('" + txtConsignee.ClientID + "', '" + hd_Brslno.ClientID + "', '" + Consignee + "')");
            txtNotify.Attributes.Add("onblur", "javascript:CallServerside_Report_NotifyName('" + txtNotify.ClientID + "', '" + hd_Brslno.ClientID + "', '" + Notify + "')");
            txt_OceanVessel.Attributes.Add("onblur", "javascript:CallServerside_Report_NotifyName('" + txt_OceanVessel.ClientID + "', '" + OceanVessel + "')");

            // ********** call  CheckBox Javascript Function

            DB_Check.Attributes.Add("onclick", "DB_Checking();");

            txt_DBNo.Attributes.Add("readonly", "readonly");
            txt_Tot_BillAmt.Attributes.Add("readonly", "readonly");
            txt_grandtotal.Attributes.Add("readonly", "readonly");

            // ********************************

            //Get_JobNo();
            //Get_Except_JobNo();  
            Get_Pkgs_Unit();
            //GET_JOBNO_From_FILE_REF_NO();
            Get_DBN_NO();

            if (Request.QueryString["Page"] == "New")
            {               
                //Div_listbox.Visible = false;             
                Get_ExporterName_General();
                //Get_DBN_NO();
                //hdn_Jobno.Value = ddlJobNo.SelectedItem.Text;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                btnReport.Visible = false;
                btnReport_Direct.Visible = false;
                btnReport_BL_A4.Visible = false;
                btnl_Annex.Visible = false;

                Bind_All_BL_Generation_Details();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    hdn_Jobno.Value = txt_JobNo.Text;
                    Bind_All_BL_Generation_Details();
                    //Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    HdnUpdate_id.Value = Request.QueryString["Page"].ToString();
                    //btnl_Annex.Visible = true;

                }
            }           
        }

        if (!Page.IsPostBack)
        {
            //SetInitialRow();
            //Grid_Load();
        }
        Check_JobNo();
        //GET_JOBNO_From_FILE_REF_NO();
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

    public void Get_Except_JobNo()
    {
        //BL_Gen.JOBNO = "";
        //BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
        //BL_Gen.Ename = "Get_Except_JobNo";
        //ds = BL_Gen.BL_Select_All();

        //ddlJobNo.DataSource = ds;
        //ddlJobNo.DataValueField = "JOBNO";
        //ddlJobNo.DataTextField = "JOBNO";
        //ddlJobNo.DataBind();

        BL_Gen.JOBNO = "";
        BL_Gen.EXPORTER_NAME = ddl_ExporterName.SelectedItem.Text;
        BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
        BL_Gen.Ename = "Get_Except_FileRefNo";
        ds = BL_Gen.BL_Select_All();

        ddlJobNo.DataSource = ds;
        ddlJobNo.DataValueField = "FILE_REF_NO";
        ddlJobNo.DataTextField = "FILE_REF_NO";
        ddlJobNo.DataBind();

        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select"); 
    }

    public void Check_JobNo()
    {
        //GET_JOBNO_From_FILE_REF_NO();

        BL_Gen.JOBNO = hdn_Jobno.Value;
        BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
        BL_Gen.Ename = "Check_JobNo";
        ds = BL_Gen.BL_Select_All();
        i = BL_Gen.result;

        HdnFld_CheckJobNo.Value = Convert.ToString(i);
    }

    public void Get_DBN_NO()
    {
        //if (DB_Check.Checked == true)
        //{
            BL_Gen.JOBNO = "";
            BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
            BL_Gen.Ename = "Get_DbNo_ID";
            ds = BL_Gen.BL_Select_All();
            i = BL_Gen.result;

            if (ds.Tables[0].Rows.Count > 0)
            {
                //int DBN_NO = Convert.ToInt32(ds.Tables[0].Rows[0]["DBN_NO"].ToString());
                string DBN_NO = ds.Tables[0].Rows[0]["DBN_SLNO"].ToString();
                //txt_DBSlNo.Text = DBN_NO;
                hdn_DBSlNo.Value = DBN_NO;
               
            }
    }

    public void GET_JOBNO_From_FILE_REF_NO()
    {

        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            certificate.JOBNO = ddlJobNo.SelectedItem.Text;
        }
        else
        {
            //certificate.JOBNO = txt_FileRefNo.Text;
        }
        certificate.EXPORTER_NAME = ddl_ExporterName.SelectedItem.Text;
        certificate.WORKING_PERIOD = SELECT_BRANCH;
        certificate.BRANCH_CODE = SELECT_BRANCH;
        certificate.Ename = "GET_JOBNO_from_FILE_REF_NO";
        ds = certificate.COO_NORMAL_SEARCH();
        i = certificate.result;

        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            hdn_fileRef_Jobno.Value = ds.Tables[0].Rows[0]["JOBNO"].ToString();
            ViewState["hdn_fileRef_Jobno"] = hdn_fileRef_Jobno.Value;
            txt_JobNo.Text = hdn_fileRef_Jobno.Value;
        }
        else
        {
            ViewState["hdn_fileRef_Jobno"] = txt_JobNo.Text;
        }

        Bind_All_BL_Generation_Details();
        
    }

  
    public void Get_ExporterName_General()
    {
        certificate.JOBNO = "";
        certificate.BRANCH_CODE = SELECT_BRANCH;
        certificate.WORKING_PERIOD = SELECT_BRANCH;
        certificate.Ename = "GET_EXPORTERNAME_GENERAL";

        ds = certificate.COO_NORMAL_SEARCH();
        ddl_ExporterName.DataSource = ds.Tables[0];
        ddl_ExporterName.DataTextField = "EXPORTER_NAME";
        ddl_ExporterName.DataValueField = "EXPORTER_NAME";
        ddl_ExporterName.DataBind();
        ddl_ExporterName.Items.Insert(0, "Select");
    }

    public void Get_FILE_REF_NO()
    {
        certificate.JOBNO = txt_JobNo.Text;
        certificate.EXPORTER_NAME = "";
        certificate.WORKING_PERIOD = SELECT_BRANCH;
        certificate.BRANCH_CODE = SELECT_BRANCH;
        certificate.Ename = "GET_FILE_REF_NO";
        ds = certificate.COO_NORMAL_SEARCH();
        i = certificate.result;

        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_FileRefNo.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
            txt_ExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
        }
    }

    public void Get_Pkgs_Unit()
    {
        adminmaster adm = new adminmaster();

        adm.Ename = "selectAll_Unit";

        ds_unit = adm.RetrieveAll_Unit_master();

        Ddl_Pkgs_Unit.DataSource = ds_unit;
        Ddl_Pkgs_Unit.DataTextField = "UNIT_CODE";
        Ddl_Pkgs_Unit.DataValueField = "UNIT_CODE";
        Ddl_Pkgs_Unit.DataBind();
        //Ddl_Pkgs_Unit.Items.Remove("0");
        Ddl_Pkgs_Unit.Items.Insert(0, "Select");
        Ddl_Pkgs_Unit.Items.Insert(3, "BCT-BUCKETS");
        Ddl_Pkgs_Unit.Items.Insert(32, "JBG-JUMBO BAGS");
        Ddl_Pkgs_Unit.Items.Insert(69, "WBX-WOODEN BOXES");
        Ddl_Pkgs_Unit.Items.Insert(70, "WBL-WOODEN BUNDLES");
        Ddl_Pkgs_Unit.Items.Insert(71, "WCS-WOODEN CASES");
        Ddl_Pkgs_Unit.Items.Insert(72, "WCT-WOODEN CRATES");
        Ddl_Pkgs_Unit.Items.Insert(73, "WPL-WOODEN PALLETS");

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {           
            DataTable dtt = new DataTable();
            DataRow dr;
            dtt.Columns.Add(new System.Data.DataColumn("Mark_No", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("no_pkg", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("desc", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("gross_wgt", typeof(String)));

            dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
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
                    //string jobno = ViewState["hdn_fileRef_Jobno"].ToString();
                    hdn_Jobno.Value = txt_JobNo.Text;
                    dr = dtt.NewRow();

                    dr[0] = txtMark_No.Text;
                    dr[1] = txtno_pkg.Text;
                    dr[2] = txtdesc.Text;
                    dr[3] = txtgross_wgt.Text;
                    dr[4] = txt_JobNo.Text;
                    dr[5] = currentuser;
                    dr[6] = SELECT_BRANCH;
                    dr[7] = Working_Period;

                    dtt.Rows.Add(dr);
                }
            }

            DataSet dsData = new DataSet();
            dsData.Tables.Add(dtt);

            // Get the XML format of the data set.
            String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

            //hdn_Jobno.Value = txt_JobNo.Text;
            Hdn_FILEREFNO.Value = txt_FileRefNo.Text;
            //hdn_Jobno.Value = ViewState["hdn_fileRef_Jobno"].ToString();

               i = Insert_Update("U", "U", xmlData);

               //************ANNEXURE INSERT UPDATE***********

               if (txt_Marks_Nos.Text != "" || txt_Description.Text != "")
               {
                   Annexure_Insert_Update();
               }

               //***********************************************

                Alert_msg("Update Successfully", "btnUpdate");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnReport.Visible = true;
                btnReport_Direct.Visible = true;
                btnReport_BL_A4.Visible = true;
                btnl_Annex.Visible = true;
                //Shipment_Type_Calc();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
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


    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJobNo.SelectedItem.Text != "Select")
        {
            //Bind_All_BL_Generation_Details();
            GET_JOBNO_From_FILE_REF_NO();
        }
        else
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            btnReport.Visible = false;
            btnReport_Direct.Visible = false;
            btnReport_BL_A4.Visible = false;
            btnl_Annex.Visible = false;
        }
    }

    public void Bind_All_BL_Generation_Details()
    {
        try
        {
            Clear();
            
            if (Request.QueryString["Page"] == "New")
            {
                //BL_Gen.JOBNO = ddlJobNo.SelectedItem.ToString();
                BL_Gen.JOBNO = txt_JobNo.Text;
                BL_Gen.Ename = "Select_All_Details";
                txt_leg_Per_1.Text = "14";
                txt_leg_Per_2.Text = "0.5";
                txt_leg_Per_3.Text = "0.5";

            }
            else
            {
                BL_Gen.BL_ID = Request.QueryString["Page"].ToString();
                BL_Gen.Ename = "select_BL_Details_Grid";
            }             
                BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
                ds = BL_Gen.BL_Select_All();
                int i = BL_Gen.result;
                HD_Type.Value = i.ToString();

                hdn_Jobno.Value = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                //txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();

                if (i == 1)
                {
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

                        txtNotify.Text = ds.Tables[0].Rows[0]["BUYER_NAME"].ToString();
                        txtNotify_Add1.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS"].ToString();
                        txtNotify_Add2.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS1"].ToString();
                        txtNotify_Add3.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS2"].ToString();
                        txtNotify_Add4.Text = ds.Tables[0].Rows[0]["BUYER_ADDRESS3"].ToString();

                        txt_Invoice_No.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString() + " - " + ds.Tables[0].Rows[0]["INVOICE_DATE"].ToString();
                        txt_SB_No.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString() + " - " + ds.Tables[0].Rows[0]["SB_DATE"].ToString();

                        txt_IEC_No.Text = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                        txt_Jobdate.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();

                        txt_Place_Delivery.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                        txt_Portdischarge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                        //txt_PortLoading.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                        
                        //if (Company_Lic == "eri00867")
                        //{
                        //    txt_PortLoading.Text = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();

                        //}
                        //else
                        //{
                        //    txt_PortLoading.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                        //}

                        txt_PortLoading.Text = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();
                        if (txt_PortLoading.Text.Contains(','))
                        {
                            string[] p1 = txt_PortLoading.Text.Split(',');
                            txt_PortLoading.Text = p1[1].ToUpper();
                            txt_PortLoading.Text = txt_PortLoading.Text.Trim();
                        }
                        else
                        {
                            txt_PortLoading.Text = txt_PortLoading.Text.ToUpper();
                        }

                        txt_HSS_Code.Text = ds.Tables[0].Rows[0]["RITC_as_HSS_CODE_NO"].ToString();//Starcom Logistics required RITC top 1 as HSS_CODE_NO

                        ddl_Total_Volume_unit.SelectedValue = "CBM";                        
                        Ddl_Pkgs_Unit.SelectedValue = "Select";                        

                        //List of Package Codes with Name merged in Dataset as single Column, First Collect Package Code, Pass it to dataset using Rowfilter with Like operator Start -- Elaiyaa
                        adminmaster adm = new adminmaster();
                        adm.Ename = "selectAll_Unit";
                        ds_unit = adm.RetrieveAll_Unit_master();

                        string Pkgs_Unit_Code_Name = "", Pkgs_Unit_Code= "";
                       // Pkgs_Unit_Code = ds.Tables[0].Rows[0]["PKG_UNIT_CODE"].ToString();

                        ds_unit.Tables[0].DefaultView.RowFilter = "UNIT_CODE  like '" + Pkgs_Unit_Code + "%'";
                        DataView dv = ds_unit.Tables[0].DefaultView;
                        DataSet Temp_ds = new DataSet();
                        Temp_ds.Tables.Add(dv.ToTable());
                        if (Temp_ds.Tables[0].Rows.Count > 0)
                        {   
                            Pkgs_Unit_Code_Name = Temp_ds.Tables[0].Rows[0]["UNIT_CODE"].ToString();
                            Ddl_Pkgs_Unit.SelectedValue = Pkgs_Unit_Code_Name;
                        }
                        else
                        {
                            Ddl_Pkgs_Unit.SelectedValue = "Select";
                        }
                        
                        //List of Package Codes with Name merged in Dataset as single Column, First Collect Package Code, Pass it to dataset using Rowfilter with Like operator End -- Elaiyaa

                        

                        RadioButtonList_Frt_Col.SelectedValue = "FREIGHT COLLECT";
                        CheckBox1_notify.Checked = false;

                        if (ddl_ShipmentType.SelectedItem.Text == "FCL")
                        {
                            txt_TotalVolume.Enabled = false;
                            ddl_Total_Volume_unit.Enabled = false;
                        }
                        else
                        {
                            txt_TotalVolume.Enabled = true;
                            ddl_Total_Volume_unit.Enabled = true;
                        }

                        if (Connection.COMPANYID() == "1065" || Connection.COMPANYID() == "10"|| Connection.COMPANYID() == "574" || Connection.COMPANYID() == "396" )
                        {
                            txt_PortLoading.Text = "JNPT";
                            txt_no_of_Original_BL.Text = "3 (THREE)";
                        }
                        if (Connection.COMPANYID() == "867")
                        {
                            txt_no_of_Original_BL.Text = ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString();
                        }
                        
                        if(ds.Tables[1].Rows.Count>0)
                        {
                            txt_Pkgs_Words.Text = ds.Tables[1].Rows[0]["InWords"].ToString();
                            txt_Commodity.Text = ds.Tables[1].Rows[0]["desc"].ToString();
                        }

                        DataTable firstTable = ds.Tables[1];
                        ViewState["CurrentTable"] = firstTable;

                        gvAll.DataSource = ds.Tables[1];
                        gvAll.DataBind();

                    }
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnReport.Visible = false;
                    CheckBox_Pending.Checked = false;
                    btnReport_Direct.Visible = false;
                    btnReport_BL_A4.Visible = false;

                }
                else if (i == 2)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txt_JobNo.Visible = true;
                        txt_FileRefNo.Visible = true;
                        ddlJobNo.Visible = false;
                        ddl_ExporterName.Visible = false;
                        txt_ExporterName.Visible = true;

                        HD_Update_id.Value = ds.Tables[0].Rows[0]["BL_ID"].ToString();
                        //ddlJobNo.SelectedValue = ds.Tables[0].Rows[0]["JOBNO"].ToString();

                        txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
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

                        txt_BL_No.Text = ds.Tables[0].Rows[0]["BL_NUMBER"].ToString();

                       
                        txt_ShipmentRefno.Text = ds.Tables[0].Rows[0]["SHIP_REF_NO"].ToString();
                        txt_Place_Receipt.Text = ds.Tables[0].Rows[0]["PLACE_OF_RECEIPT"].ToString();
                        txt_OceanVessel.Text = ds.Tables[0].Rows[0]["OCEAN_VESSEL"].ToString();
                        txt_PortLoading.Text = ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString();

                        txt_freight_payable.Text = ds.Tables[0].Rows[0]["FREIGHT_PAYABLE"].ToString();
                        txt_place_date.Text = ds.Tables[0].Rows[0]["PLACE_DATE"].ToString();
                        txt_Date_Receipt.Text = ds.Tables[0].Rows[0]["DATE_OF_RECEIPT"].ToString();
                        txt_Place_Delivery.Text = ds.Tables[0].Rows[0]["PLACE_OF_DELIVERY"].ToString();

                        txt_Portdischarge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                        txt_no_of_Original_BL.Text = ds.Tables[0].Rows[0]["NO_OF_ORGINAL_BL"].ToString();
                        txt_AgentRefNo.Text = ds.Tables[0].Rows[0]["AGENTS_NAEE_REFNO"].ToString();
                        txt_freight_amt.Text = ds.Tables[0].Rows[0]["FREIGHT_AMT"].ToString();

                        TextNotify1_1.Text = ds.Tables[0].Rows[0]["NOTIFY_1_1"].ToString();
                        TextNotify1_2.Text = ds.Tables[0].Rows[0]["NOTIFY_1_2"].ToString();
                        TextNotify1_3.Text = ds.Tables[0].Rows[0]["NOTIFY_1_3"].ToString();
                        TextNotify1_4.Text = ds.Tables[0].Rows[0]["NOTIFY_1_4"].ToString();
                        TextNotify1_5.Text = ds.Tables[0].Rows[0]["NOTIFY_1_5"].ToString();
                        txt_Invoice_No.Text = ds.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                        txt_IEC_No.Text = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
                        txt_SB_No.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                        txt_HSS_Code.Text = ds.Tables[0].Rows[0]["HSS_CODE_NO"].ToString();
                        txt_LC_No.Text = ds.Tables[0].Rows[0]["LC_NO"].ToString();
                        txt_TotalVolume.Text = ds.Tables[0].Rows[0]["TOTALVOLUME"].ToString();
                        txt_OrderNo.Text = ds.Tables[0].Rows[0]["ORDER_NO"].ToString();
                        ddl_Total_Volume_unit.SelectedValue = ds.Tables[0].Rows[0]["TOT_VOL_UNIT"].ToString();
                        txt_Commodity.Text = ds.Tables[0].Rows[0]["COMMODITY"].ToString();
                        txt_Voyage.Text = ds.Tables[0].Rows[0]["VOYAGE"].ToString();
                        txt_Currency.Text = ds.Tables[0].Rows[0]["CURRENCY"].ToString();
                        txt_ExRate.Text = ds.Tables[0].Rows[0]["EX_RATE"].ToString();
                        txt_No_Of_Containers.Text = ds.Tables[0].Rows[0]["NO_OF_CONTAINERS"].ToString();
                        txt_Percent.Text = ds.Tables[0].Rows[0]["PERCENTAGE"].ToString();
                        txt_Tot_BillAmt.Text = ds.Tables[0].Rows[0]["TOTAL_BILLAMT"].ToString();

                        ddl_ShipmentType.SelectedValue = ds.Tables[0].Rows[0]["SHIPMENT_TYPE"].ToString();

                        if (ddl_ShipmentType.SelectedValue == "FCL")
                        {
                            txt_freight_amt.Enabled = true;
                            txt_TotalVolume.Enabled = false;
                            ddl_Total_Volume_unit.Enabled = false;
                        }
                        else
                        {
                            //txt_freight_amt.Enabled = false;
                            txt_TotalVolume.Enabled = true;
                            ddl_Total_Volume_unit.Enabled = true;
                        }

                        txt_DBNo.Text = ds.Tables[0].Rows[0]["DBN_NO"].ToString();
                        txt_DBDate.Text = ds.Tables[0].Rows[0]["DBN_DATE"].ToString();
                        txt_DBSlNo.Text = ds.Tables[0].Rows[0]["DBN_SLNO"].ToString();

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
                        
                        txt_FreightCharges.Text = ds.Tables[0].Rows[0]["FREIGHT_CHARGES"].ToString();
                        txt_Pkgs_Words.Text = ds.Tables[0].Rows[0]["PKGS_WORDS"].ToString();


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
                        
                        ddl_ReportType.SelectedValue = ds.Tables[0].Rows[0]["RPT_TYPE"].ToString();

                        string DB_YES_NO = ds.Tables[0].Rows[0]["DB_YES_NO"].ToString();

                        if (DB_YES_NO == "Y")
                        {
                            DB_Check.Checked = true;
                        }
                        else
                        {
                            DB_Check.Checked = false;
                        }

                        if ((txt_BL_No.Text != "") && (DB_Check.Checked == true) && (ddl_ReportType.SelectedItem.Text!=""))
                        {
                            btnSearch.Visible = true;
                        }
                        else
                        {
                            btnSearch.Visible = false;
                        }

                        string jobdate = ds.Tables[0].Rows[0]["JOB_DATE"].ToString();
                        if (jobdate != "01/01/1900")
                        {
                            txt_Jobdate.Text = ds.Tables[0].Rows[0]["JOB_DATE"].ToString();
                        }
                        else
                        {
                            txt_Jobdate.Text = "";
                        }

                        if (TextNotify1_1.Text != "")
                        {
                            CheckBox1_notify.Checked = true;
                        }
                        else
                        {
                            CheckBox1_notify.Checked = false;
                        }

                        RadioButtonList_Frt_Col.SelectedValue = ds.Tables[0].Rows[0]["FREIGHT_PRE_COL"].ToString();

                        chk_container = ds.Tables[0].Rows[0]["CONTAINER_Y_N"].ToString();

                        if (chk_container == "Y")
                        {
                            CheckBox_Container.Checked = true;
                        }
                        else
                        {
                            CheckBox_Container.Checked = false;
                        }

                        chk_Pending = ds.Tables[0].Rows[0]["PENDING_Y_N"].ToString();

                        if (chk_Pending == "Y")
                        {
                            CheckBox_Pending.Checked = true;
                        }
                        else
                        {
                            CheckBox_Pending.Checked = false;
                        }

                        chk_ddl_pkg_unit = ds.Tables[0].Rows[0]["TOT_PKGS_UNIT"].ToString();

                        if (chk_ddl_pkg_unit != "")
                        {
                            Ddl_Pkgs_Unit.SelectedValue = ds.Tables[0].Rows[0]["TOT_PKGS_UNIT"].ToString();
                        }
                        else
                        {
                            Ddl_Pkgs_Unit.SelectedValue = "Select";
                        }                        
                    }
                 
                   if (BL_Gen.Ename == "Select_All_Details")
                    {
                        DataTable SecondTable = ds.Tables[1];
                        ViewState["CurrentTable"] = SecondTable;

                        gvAll.DataSource = ds.Tables[1];
                        gvAll.DataBind();
                    }
                    else
                    {
                        BL_Gen.JOBNO = txt_JobNo.Text;
                        BL_Gen.Ename = "Select_All_Details";
                        BL_Gen.WORKINGPERIOD = SELECT_BRANCH;
                        dss = BL_Gen.BL_Select_All();

                        DataTable SecondTable = dss.Tables[1];
                        ViewState["CurrentTable"] = SecondTable;

                        if (dss.Tables[1].Rows.Count > 0)
                        {
                            gvAll.DataSource = dss.Tables[1];
                            gvAll.DataBind();
                        }
                        else
                        {
                            SetInitialRow();
                        }
                    }

                   Bind_Annexure_Details();

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnReport.Visible = true;
                    btnReport_Direct.Visible = true;
                    btnReport_BL_A4.Visible = true;
                }
                //Grid_DataBind();
            //}
            else
            {
                CheckBox_Container.Checked = false;
            }

                Get_FILE_REF_NO();
            //Get_ExporterName();

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Bind_Annexure_Details()
    {
        BL_Gen.JOBNO = hdn_Jobno.Value;
        BL_Gen.REPORT_TYPE = "BL Generation";
        BL_Gen.Ename = "Select_BL_Annexure";
        BL_Gen.BRANCHCODE = SELECT_BRANCH;
        ds = BL_Gen.BL_Container_Select_All();

        if (ds.Tables[1].Rows.Count > 0)
        {
            txt_Marks_Nos.Text = ds.Tables[1].Rows[1]["MARKS_NOS"].ToString();
            txt_Description.Text = ds.Tables[1].Rows[1]["GOODS_DESCRIPTION"].ToString();          
           
            btnl_Annex.Visible = true;
        }   
        else
        {
            btnl_Annex.Visible = false;
        }
    }

    public int Insert_Update(string a1, string a2, String xmlData_D)
    {
            //BL_Gen.JOBNO=ddlJobNo.SelectedItem.Text;
        
        BL_Gen.JOBNO = txt_JobNo.Text;

            //BL_Gen.JOBNO = hdn_Jobno.Value;
            //BL_Gen.JOBNO = ViewState["hdn_fileRef_Jobno"].ToString();
            BL_Gen.EXPORTER_NAME= txtExporter.Text;
            BL_Gen.ADDRESS1=txtAddress1.Text;
            BL_Gen.ADDRESS2=txtAddress2.Text;
            BL_Gen. ADDRESS3=txtAddress3.Text;
            BL_Gen. ADDRESS4=txtAddress4.Text;
            BL_Gen.ADDRESS5=txtAddress5.Text;

            BL_Gen.CONSIGNEE_NAME=txtConsignee.Text;
            BL_Gen.CONSIGNEE_ADD1=txtConsignee_Add1.Text;
            BL_Gen.CONSIGNEE_ADD2=txtConsignee_Add2.Text;
            BL_Gen.CONSIGNEE_ADD3=txtConsignee_Add3.Text;
            BL_Gen.CONSIGNEE_ADD4=txtConsignee_Add4.Text;

            BL_Gen.BUYER_NAME=txtNotify.Text;
            BL_Gen.BUYER_ADDRESS = txtNotify_Add1.Text;
            BL_Gen.BUYER_ADDRESS1 = txtNotify_Add2.Text;
            BL_Gen.BUYER_ADDRESS2 = txtNotify_Add3.Text;
            BL_Gen.BUYER_ADDRESS3 = txtNotify_Add4.Text;
            BL_Gen.BUYER_ADDRESS4 = txtNotify_Add5.Text;

            BL_Gen.BL_NUMBER=txt_BL_No.Text;

            BL_Gen.SHIP_REF_NO=txt_ShipmentRefno.Text;
            //BL_Gen.PLACE_OF_RECEIPT=txt_Place_Receipt.Text;

            if (txt_Place_Receipt.Text.Contains('-'))
            {
                string[] p1 = txt_Place_Receipt.Text.Split('-');
                BL_Gen.PLACE_OF_RECEIPT = p1[0];

            }
            else
            {
                BL_Gen.PLACE_OF_RECEIPT = txt_Place_Receipt.Text;
            }

            BL_Gen.OCEAN_VESSEL=txt_OceanVessel.Text;

            if (txt_PortLoading.Text.Contains('-'))
            {
                string[] p1 = txt_PortLoading.Text.Split('-');
                BL_Gen.PORT_OF_LOADING = p1[0];

            }
            else
            {
                BL_Gen.PORT_OF_LOADING = txt_PortLoading.Text;
            }
            
            BL_Gen.FREIGHT_PAYABLE=txt_freight_payable.Text;
            BL_Gen.PLACE_DATE=txt_place_date.Text;
            BL_Gen.DATE_OF_RECEIPT=txt_Date_Receipt.Text;
            //BL_Gen.PLACE_OF_DELIVERY=txt_Place_Delivery.Text ;
            if (txt_Place_Delivery.Text.Contains('-'))
            {
                string[] p1 = txt_Place_Delivery.Text.Split('-');
                BL_Gen.PLACE_OF_DELIVERY = p1[0];

            }
            else
            {
                BL_Gen.PLACE_OF_DELIVERY = txt_Place_Delivery.Text;
            }

            //BL_Gen.PORT_DISCHARGE=txt_Portdischarge.Text;
            if (txt_Portdischarge.Text.Contains('-'))
            {
                string[] p1 = txt_Portdischarge.Text.Split('-');
                BL_Gen.PORT_DISCHARGE = p1[0];

            }
            else
            {
                BL_Gen.PORT_DISCHARGE = txt_Portdischarge.Text;
            }
            BL_Gen.NO_OF_ORGINAL_BL=txt_no_of_Original_BL.Text;

            BL_Gen.AGENTS_NAEE_REFNO=txt_AgentRefNo.Text;
            //BL_Gen.FREIGHT_AMT=txt_freight_amt.Text;

            BL_Gen.flag = a2;

            BL_Gen.USERID=currentuser;
            BL_Gen.STATUS = a2;
            BL_Gen.BRANCHCODE=SELECT_BRANCH;
            BL_Gen.WORKINGPERIOD=Working_Period;

            BL_Gen._NOTIFY_1_1 = TextNotify1_1.Text;
            BL_Gen.NOTIFY_1_2 = TextNotify1_2.Text;
            BL_Gen.NOTIFY_1_3 = TextNotify1_3.Text;
            BL_Gen.NOTIFY_1_4 = TextNotify1_4.Text;
            BL_Gen.NOTIFY_1_5 = TextNotify1_5.Text;

            BL_Gen.INVOICE_NO = txt_Invoice_No.Text;
            BL_Gen.SB_NO = txt_SB_No.Text;

            BL_Gen.IEC_NO = txt_IEC_No.Text;
            BL_Gen.HSS_CODE_NO = txt_HSS_Code.Text;
            BL_Gen.LC_NO = txt_LC_No.Text;
            BL_Gen.TOTALVOLUME = txt_TotalVolume.Text;
            BL_Gen.ORDER_NO = txt_OrderNo.Text;
            BL_Gen.FREIGHT_PRE_COL = RadioButtonList_Frt_Col.SelectedValue;
            BL_Gen.TOT_VOL_UNIT = ddl_Total_Volume_unit.SelectedValue;
            BL_Gen.COMMODITY = txt_Commodity.Text;     

            if (txt_Jobdate.Text != "")
            {
                BL_Gen.JOB_DATE = txt_Jobdate.Text;
            }
            else
            {
                BL_Gen.JOB_DATE = "01/01/1900";
            }
                    
            if (CheckBox_Container.Checked == true)
            {
                BL_Gen.CONTAINER_Y_N = "Y";               
            }
            else
            {
                BL_Gen.CONTAINER_Y_N = "N";
            }

            if (CheckBox_Pending.Checked == true)
            {
                BL_Gen.PENDING_Y_N = "Y";
            }
            else
            {
                BL_Gen.PENDING_Y_N = "N";
            }

            if (Ddl_Pkgs_Unit.SelectedValue != "Select")
            {
                BL_Gen.TOT_PKGS_UNIT = Ddl_Pkgs_Unit.SelectedValue;
            }
            else
            {
                BL_Gen.TOT_PKGS_UNIT = "";
            }
            BL_Gen.FILE_REF_NO = Hdn_FILEREFNO.Value;
            BL_Gen.VOYAGE = txt_Voyage.Text;
            BL_Gen.CURRENCY = txt_Currency.Text;
            BL_Gen.EX_RATE = txt_ExRate.Text;
            BL_Gen.NO_OF_CONTAINERS = txt_No_Of_Containers.Text;
            BL_Gen.PERCENTAGE = txt_Percent.Text;
            BL_Gen.TOTAL_BILLAMT = txt_Tot_BillAmt.Text;
            BL_Gen.SHIPMENT_TYPE = ddl_ShipmentType.SelectedItem.Text;
            BL_Gen.FREIGHT_AMT = txt_freight_amt.Text;
            BL_Gen.DBN_NO = txt_DBNo.Text;
            //BL_Gen.DBN_DATE = txt_DBDate.Text;
            //txt_DBSlNo.Text = "115";
            //BL_Gen.DBN_SLNO = txt_DBSlNo.Text;
            BL_Gen.RPT_TYPE = ddl_ReportType.SelectedItem.Text;
            BL_Gen.HSN_CODE = txt_HSNCode.Text;
            BL_Gen.FREIGHT_CHARGES = txt_FreightCharges.Text;
            BL_Gen.PKGS_WORDS = txt_Pkgs_Words.Text;

            if (txt_DBDate.Text != "")
            {
                BL_Gen.DBN_DATE = txt_DBDate.Text;
            }
            else
            {
                BL_Gen.DBN_DATE = "01/01/1900";
            }

            if (txt_DBNo.Text != "")
            {
                BL_Gen.DBN_SLNO = txt_DBNo.Text.Substring(13, 3);
            }
            else
            {
                BL_Gen.DBN_SLNO = "";
            }

            if (DB_Check.Checked == true)
            {
                BL_Gen.DB_YES_NO = "Y";
            }
            else
            {
                BL_Gen.DB_YES_NO = "N";
            }

            if ((txt_BL_No.Text != "") && (DB_Check.Checked == true) && (ddl_ReportType.SelectedItem.Text != ""))
            {
                btnSearch.Visible = true;
            }
            else
            {
                btnSearch.Visible = false;
            }

            BL_Gen.TAX_LEDGER_1 = txt_tax_leg_1.Text;
            BL_Gen.TAX_LEDGER_2 = txt_tax_leg_2.Text;
            BL_Gen.TAX_LEDGER_3 = txt_tax_leg_3.Text;
            BL_Gen.LEDGER_1_TAX = txt_leg_Per_1.Text;
            BL_Gen.LEDGER_2_TAX = txt_leg_Per_2.Text;
            BL_Gen.LEDGER_3_TAX = txt_leg_Per_3.Text;
            BL_Gen.LEDGER_1_TAX_AMT = txt_tax_amt_1.Text;
            BL_Gen.LEDGER_2_TAX_AMT = txt_tax_amt_2.Text;
            BL_Gen.LEDGER_3_TAX_AMT = txt_tax_amt_3.Text;
            BL_Gen.GRAND_TOTAL = txt_grandtotal.Text;
           

            //BL_Gen.Xml_D = xmlData_D;
            BL_Gen.UPD_ID = HD_Update_id.Value;  
            //BL_Gen.UPD_ID = ViewState["UPDATE_ID"].ToString();

            BL_Gen.Xml_D= xmlData_D;
            BL_Gen.xml();
            i = BL_Gen.result;

        return i;
    }

    public int Annexure_Insert_Update()
    {       
            BL_Gen.JOBNO = hdn_Jobno.Value;
            BL_Gen.REPORT_TYPE = "BL Generation";
            BL_Gen.MARKS_NOS = txt_Marks_Nos.Text;
            BL_Gen.GOODS_DESCRIPTION = txt_Description.Text;
            BL_Gen.flag = "S";

            BL_Gen.USERID = currentuser;
            BL_Gen.STATUS = "S";
            BL_Gen.BRANCHCODE = SELECT_BRANCH;
            BL_Gen.WORKINGPERIOD = Working_Period;
            BL_Gen.LOGIN_DATE = LoginDate;

            BL_Gen.BL_Annexure_Insert_Update();
            i = BL_Gen.result;
        
        return i;
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

        txtNotify.Text = "";
        txtNotify_Add1.Text = "";
        txtNotify_Add2.Text = "";
        txtNotify_Add3.Text = "";
        txtNotify_Add4.Text = "";
        txtNotify_Add5.Text = "";

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
        //txt_freight_amt.Text = "";

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
        txt_Commodity.Text = "";
        txt_Marks_Nos.Text = "";
        txt_Description.Text = "";
        txt_Voyage.Text = "";
        txt_Currency.Text = "";
        txt_ExRate.Text = "";
        txt_No_Of_Containers.Text = "";
        txt_HSNCode.Text = "";
        SetInitialRow();
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

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        //http://www.codeproject.com/Articles/30722/How-to-save-data-from-a-DataSet-into-a-T-SQL-table
       // sp_name EXP_BL_GENERATION_INS_UPD

        txtfocus.Focus();
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "tab_page3();", true);

        //if (HD_Type.Value == "1")
        //{
        //    btnUpdate.Visible = false;
        //    btnDelete.Visible = false;
        //    btnSave.Visible = true;
        //}

        //else if (HD_Type.Value == "2")
        //{
        //    btnUpdate.Visible = true;
        //    btnDelete.Visible = true;
        //    btnSave.Visible = false;
        //}
        //btnReport.Visible = true;

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
                    
                    if(txtMark_No.Text==string.Empty && txtno_pkg.Text==string.Empty && txtdesc.Text==string.Empty && txtgross_wgt.Text==string.Empty)
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
            //Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetPreviousData();
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

                // for (int i = 0; i < gvAll.Rows.Count - 1; i++)
                // {
                //     gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                // }
                //SetPreviousData();
            }
        }
        txtfocus.Focus();

        if (HD_Type.Value=="1")
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
            btnReport.Visible = true;
            btnReport_Direct.Visible = true;
            btnReport_BL_A4.Visible = true;
        }
        else if (HD_Type.Value == "2")
        {
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
            btnReport.Visible = true;
            btnReport_Direct.Visible = true;
            btnReport_BL_A4.Visible = true;
        }       
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedItem.Text != "Select")
            {

                DataTable dtt = new DataTable();
                DataRow dr;
                dtt.Columns.Add(new System.Data.DataColumn("Mark_No", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("no_pkg", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("desc", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("gross_wgt", typeof(String)));

                dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("USERID", typeof(String)));

                dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));
                //dtt.Columns.Add(new System.Data.DataColumn("FILE_REF_NO", typeof(String)));

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

                        //dr[4] = ddlJobNo.SelectedItem.ToString();
                        dr[4] = ViewState["hdn_fileRef_Jobno"].ToString();
                        dr[5] = currentuser;
                        dr[6] = currentbranch;
                        dr[7] = Working_Period;
                        //dr[8] = ddlJobNo.SelectedItem.Text;

                        dtt.Rows.Add(dr);
                    }
                }

                DataSet dsData = new DataSet();
                dsData.Tables.Add(dtt);

                // Get the XML format of the data set.
                String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
                //hdn_Jobno.Value = ddlJobNo.SelectedItem.Text;

                hdn_Jobno.Value = ViewState["hdn_fileRef_Jobno"].ToString();
                Hdn_FILEREFNO.Value = ddlJobNo.SelectedItem.Text;

                i = Insert_Update("N", "S", xmlData);

                int update_id = BL_Gen.UpdateId;

                HD_Update_id.Value = Convert.ToString(update_id);

                ViewState["UPDATE_ID"] = update_id;

                //************ANNEXURE INSERT UPDATE***********

                if (txt_Marks_Nos.Text != "" || txt_Description.Text != "")
                {
                    Annexure_Insert_Update();
                }

                //***********************************************
                Check_JobNo();

                Alert_msg("Saved Successfully", "btnSave");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnReport.Visible = true;
                btnReport_Direct.Visible = true;
                btnReport_BL_A4.Visible = true;
                btnl_Annex.Visible = true;
            }
            else
            {
                Alert_msg("Select Valid JobNo");
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

    protected void BtnAddAnnex_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnReport.Visible = false;
        btnReport_Direct.Visible = false;
        btnReport_BL_A4.Visible = false;
    }

    protected void btnl_Annex_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "OnClientClicking", "tab_page4();", true);
    }

    protected void txtExporter_TextChanged(object sender, EventArgs e)
    {
        string xx = hdn_CLIENT_TYPE.Value;
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
            Rpt_Clt.CLIENT_TYPE = HttpContext.Current.Session["Exporter"].ToString();
            Rpt_Clt.CLIENT_WORKING_PERIOD = HttpContext.Current.Session["WorkingPeriod"].ToString();
            Rpt_Clt.CLIENT_BRANCH_CODE = slno;

            //Rpt_Clt.CLIENT_BRANCH_CODE = HttpContext.Current.Session["currentbranch"].ToString();

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
                //string txtTar_Unit = ds.Tables[0].Rows[0]["TAR_UNIT"].ToString();

                //custid = txtAddress1 + "~~" + txtAddress2 + "~~" + txtAddress3 + "~~" + txtAddress4 + "~~" + txtAddress5 + "~~" + txtCess_Qty + "~~" + txtTar_Unit;
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
            Rpt_Clt.CLIENT_TYPE = HttpContext.Current.Session["Consignee"].ToString();
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
                //string txtCess_Qty = ds.Tables[0].Rows[0]["CESS_QTY"].ToString();
                //string txtTar_Unit = ds.Tables[0].Rows[0]["TAR_UNIT"].ToString();

                //custid = txtAddress1 + "~~" + txtAddress2 + "~~" + txtAddress3 + "~~" + txtAddress4 + "~~" + txtAddress5 + "~~" + txtCess_Qty + "~~" + txtTar_Unit;
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
            Rpt_Clt.CLIENT_TYPE = HttpContext.Current.Session["Notify"].ToString();
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

                //string txtTar_Unit = ds.Tables[0].Rows[0]["TAR_UNIT"].ToString();

                //custid = txtAddress1 + "~~" + txtAddress2 + "~~" + txtAddress3 + "~~" + txtAddress4 + "~~" + txtAddress5 + "~~" + txtCess_Qty + "~~" + txtTar_Unit;
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

    protected void ddl_ExporterName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_Except_JobNo();
    }

    public void Shipment_Type_Calc()
    {
        if (txt_BL_No.Text != "")
        {
            //btnSearch.Visible = true;

            if (ddl_ShipmentType.SelectedItem.Text != "")
            {
                if (ddl_ShipmentType.SelectedItem.Text == "FCL")
                {
                    if (txt_freight_amt.Text != "" && txt_No_Of_Containers.Text != "" && txt_ExRate.Text != "" && txt_Percent.Text != "")
                    {
                        
                        //txt_Tot_BillAmt.Text = txt_freight_amt.Text * txt_No_Of_Containers.Text * txt_ExRate.Text;
                        //btnSearch.Visible = true;
                    }
                    else
                    {
                        //btnSearch.Visible = false;
                        Alert_msg("Enter the All Mandatory Fields!..");
                    }
                }
                else if (ddl_ShipmentType.SelectedItem.Text == "LCL")
                {
                    if (txt_TotalVolume.Text != "" && txt_No_Of_Containers.Text != "" && txt_ExRate.Text != "" && txt_Percent.Text != "")
                    {
                        //btnSearch.Visible = true;
                    }
                    else
                    {
                        //btnSearch.Visible = false;
                        Alert_msg("Enter the All Mandatory Fields!..");
                    }
                }
            }
        }
        else
        {
            btnSearch.Visible = false;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            //hdn_Jobno.Value = txt_JobNo.Text;
            //i = Insert_Update("N", "D", "");

            BL_Gen.JOBNO = txt_JobNo.Text;
            BL_Gen.BRANCHCODE = SELECT_BRANCH;
            BL_Gen.WORKINGPERIOD = Working_Period;
            BL_Gen.REPORT_TYPE = "BL Generation";
            BL_Gen.Ename = "Delete_All";

            ds = BL_Gen.BL_Container_Select_All();
            i = BL_Gen.result;

            if (i == 1)
            {
                //Alert_msg("Record Deleted", "btnUpdate");

                string prompt = "<script>$(document).ready(function(){{jAlert('BL Generation Deleted', 'BL Generation', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                Clear();
                ddlJobNo.SelectedIndex = -1;
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
}
 