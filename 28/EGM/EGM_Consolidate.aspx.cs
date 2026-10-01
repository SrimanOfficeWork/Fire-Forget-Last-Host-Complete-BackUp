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
    EGM EGM = new EGM();
    AdminMasterDetails admin = new AdminMasterDetails();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    //Export_FlatFile_Generation FlatFile = new Export_FlatFile_Generation();
    public int i, EgmJobno_maxReturn = 0;
     
    public string comp_ConnectionStr;
    public string  TRANSPORT_MODE, CUSTOMS_HOUSE;

    DataSet dss = new DataSet();
    string Bind_Type = "", errorFolder = "", Update_Grid = "";
    public string logline = "", logFileName = "", job_type = "";

    DataTable dt_main = new DataTable();
    DataTable dt_cont = new DataTable();

   
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();

        TRANSPORT_MODE = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();
        if (TRANSPORT_MODE == "A")
        {
            hdfTransport_mode.Value = "Air";
        }
        else if (TRANSPORT_MODE == "S")
        {
            hdfTransport_mode.Value = "Sea";
        }
        else if (TRANSPORT_MODE == "L")
        {
            hdfTransport_mode.Value = "Land";
        }

       
        CUSTOMS_HOUSE = Session["CUSTOMHOUSE_CODE"].ToString();

        if (!string.IsNullOrEmpty(Session["STANDARD_TYPE"] as string))
        {
            Hdn_STANDARD_TYPE.Value = HttpContext.Current.Session["STANDARD_TYPE"].ToString();
        }
        //string tm = Session["CUSTOMHOUSE_TRANSPORT_MODE"].ToString();

        //if (!string.IsNullOrEmpty(Session["JOBID"].ToString()))
        if (!string.IsNullOrEmpty(Session["EGMID_excel"] as string))
        {
            string aa = Session["EGMID_excel"].ToString();

            System.Reflection.PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection)
                                             .GetProperty("IsReadOnly", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            isreadonly.SetValue(HttpContext.Current.Request.QueryString, false, null);
            //HttpContext.Current.Request.QueryString.Clear();
            //Request.QueryString.Remove("JOBID");
            //Request.QueryString["JOBID"] = Session["EGMID_excel"].ToString();
            HdnUpdate_id.Value = Session["EGMID_excel"].ToString();
            //Session.Remove("JOBIDexcel"); // hide by chithra with Ram sir..on 04/03/2019 - this line put in  Export General Search page
            //Request["Page"] = "";
            txt_EGM_Jobno.Text = Session["EGMID_excel"].ToString();
            Bind_Type = "Rotation";
            //Request.QueryString["Page"] = "Rotation";
            job_type = "excel";
            Update_Grid = "Update_Grid";
            
        }
       

        hd_Branch.Value = Connection.Get_Company_Type();
        errorFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + Session["currentbranch"].ToString() + "/" + Session["currentuser"].ToString() + "/");

        if (!IsPostBack)
        {
            if (Request.QueryString["Page"] == "New")
            {                           
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;

                if (job_type != "excel")
                {
                    Get_EGM_JobNo_MAX();
                }

                Get_Except_JobNo();
                Bind_EGM_Details();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Bind_Type = "Rotation";
                    hdn_Jobno.Value = txt_JobNo.Text;
                                
                    //HdnUpdate_id.Value = Request.QueryString["Page"].ToString();
                    //txt_EGM_Jobno.Text = Request.QueryString["egm_id"].ToString();

                    HdnUpdate_id.Value = Request.QueryString["egm_id"].ToString();
                    txt_EGM_Jobno.Text = Request.QueryString["Page"].ToString();
                    txtAddress.Attributes.Add("readonly", "readonly");
                    txtAddress2.Attributes.Add("readonly", "readonly");
                    txtAddress3.Attributes.Add("readonly", "readonly");
                    txtAddress4.Attributes.Add("readonly", "readonly");

                    txtConsigneeAddress.Attributes.Add("readonly", "readonly");
                    txtConsigneeAddress1.Attributes.Add("readonly", "readonly");
                    txtConsigneeAddress2.Attributes.Add("readonly", "readonly");
                    txtConsigneeAddress3.Attributes.Add("readonly", "readonly");
                    

                    hdn_SB_SlNo.Value = "1";
                    gv_details_Grid_Bind();
                    Bind_EGM_Details();
                    //gv_details_Grid_Bind();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }

            //txt_JobNo.Attributes.Add("onblur", "javascript:CallServerside_jobno_EGM('" + txt_JobNo.ClientID + "', '" + hd_Branch.ClientID + "')");
            //txt_SBNo.Attributes.Add("onblur", "javascript:CallServerside_SB_No_EGM('" + txt_SBNo.ClientID + "', '" + hd_Branch.ClientID + "')");
            txt_RotationNo.Attributes.Add("onblur", "javascript:CallServerside_Get_Duplicate_Rotation_No('" + txt_RotationNo.ClientID + "', '" + hd_Branch.ClientID + "')");
            txt_Vessel_Name.Attributes.Add("onblur", "javascript:CallServerside_Vessel_IMo_code('" + txt_Vessel_Name.ClientID + "', '" + hd_Branch.ClientID + "')");
            txtConsigneeName.Attributes.Add("onblur", "javascript:CallServerside_Consignee('" + txtConsigneeName.ClientID + "', '" + txtConsigneeAddress.ClientID + "')");
            //txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer_STD('" + txtExporterName.ClientID + "', '" + hd_Branch.ClientID + "')");
            txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtExporterName.ClientID + "', '" + txtAddress.ClientID + "')");

            //txtExporterName.Attributes.Add("onblur", "javascript:CallServerside_Importer('" + txtExporterName.ClientID + "', '" + hd_Branch.ClientID + "')");
            //txtConsigneeName.Attributes.Add("onblur", "javascript:CallServerside_Consignee('" + txtConsigneeName.ClientID + "', '" + hdn_Consignee_brSlNo.ClientID + "')");
            //txtConsigneeAddress.Attributes.Add("onblur", "javascript:CallServerside_Consignee('" + txtConsigneeName.ClientID + "', '" + txtConsigneeAddress.ClientID + "')");
        }
    }

    public void gv_details_Grid_Bind()
    {
        EGM.EGM_ID = HdnUpdate_id.Value;
        EGM.EGM_JOBNO = txt_EGM_Jobno.Text;
        EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value);
        EGM.Ename = "Select_EGM_CONSOLIDATE_Rotation_Details";
        EGM.WORKINGPERIOD = Connection.Get_Company_Type();
        ds = EGM.EGM_CONSOLIDATE_Select_All();

        ViewState["ds"] = ds.Tables[0];

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_ItemDetails.DataSource = ds.Tables[0];
            gv_ItemDetails.DataBind();
        }

        if (Update_Grid != "Update_Grid")
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvAll.DataSource = ds.Tables[1];
                gvAll.DataBind();
                ViewState["CurrentTable"] = ds.Tables[1];
                SetPreviousData();
            }
        }
    }

    public void Get_Except_JobNo()
    {     
        EGM.JOBNO = "";
        EGM.WORKINGPERIOD = Connection.Get_Company_Type();
        EGM.Ename = "Get_Except_JobNo";
        ds = EGM.EGM_CONSOLIDATE_Select_All();
    }

    public void Get_EGM_JobNo_MAX()
    {
        EGM.JOBNO = "";
        EGM.EGM_JOBNO = txt_EGM_Jobno.Text;
        EGM.WORKINGPERIOD = Connection.Get_Company_Type();
        EGM.Ename = "Get_EGM_JOBNO_MAXID";
        ds = EGM.EGM_CONSOLIDATE_Select_All();

        if (ds.Tables[0].Rows.Count > 0)
        {
            txt_EGM_Jobno.Text = ds.Tables[0].Rows[0]["egm_MAXID"].ToString();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dtt = new DataTable();
            DataRow dr;
            dtt.Columns.Add(new System.Data.DataColumn("EGM_CONID", typeof(int)));
            dtt.Columns.Add(new System.Data.DataColumn("EGM_JOBNO", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("SBNO", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("SLNO", typeof(int)));
            dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_NO", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("SIZE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("TYPE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("USERID", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("LOGIN_DATE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("STATUS", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));
            dtt.Columns.Add(new System.Data.DataColumn("ROTATION_NO", typeof(String)));


            int x = 1;
            int MAX_ID = Get_MAXID("Get_EGM_Container_MAXID");

            foreach (GridViewRow row in gvAll.Rows)
            {
                TextBox txtContainerNo = (TextBox)row.FindControl("txtContainerNo");
                DropDownList ddl_size = (DropDownList)row.FindControl("ddl_size");
                DropDownList ddl_Type = (DropDownList)row.FindControl("ddl_Type");

                if (txtContainerNo.Text == string.Empty)
                {
                }
                else
                {
                    dr = dtt.NewRow();

                    dr[0] = MAX_ID;
                    dr[1] = txt_EGM_Jobno.Text;
                    dr[2] = txt_JobNo.Text;
                    dr[3] = txt_SBNo.Text;
                    dr[4] = hdn_SB_SlNo.Value;
                    dr[5] = txtContainerNo.Text;
                    dr[6] = ddl_size.SelectedValue;
                    dr[7] = ddl_Type.SelectedValue;
                    dr[8] = Connection.Current_User();
                    dr[9] = Session["LoginDate"].ToString();
                    dr[10] = "S";
                    dr[11] = Connection.Current_Branch();
                    dr[12] = Connection.WorkingPeriod();
                    dr[13] = txt_RotationNo.Text;


                    dtt.Rows.Add(dr);
                    x = x + 1;
                    MAX_ID = MAX_ID + 1;
                }
            }

            if (dtt.Rows.Count > 0)
            {
                Delete_Container(Convert.ToInt32(txt_EGM_Jobno.Text));
                AdminMasterDetails adm = new AdminMasterDetails();
                adm.SqlBulk_Upload_Product("EGM_CONSOLIDATE_CONTAINER_DETAILS", dtt, Session["currentcomp_db"].ToString());
            }

            
            i = Insert_Update("U", "U", Convert.ToInt32(hdn_SB_SlNo.Value));

            Alert_msg("Update Successfully", "btnUpdate");
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
            Update_Grid = "Update_Grid";

            Bind_EGM_Details();
            gv_details_Grid_Bind();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }
    

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EGM Consolidate', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'EGM Consolidate', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Bind_EGM_Details()
    {
        try
        {
            DataTable dt_item = new DataTable();

            //if (Request.QueryString["Page"] == "New")
            //{
            if(Bind_Type=="Rotation")
            {
                //EGM.JOBNO = ddlJobNo.SelectedItem.ToString();
                //EGM.JOBNO = hdn_Jobno.Value;
                //EGM.JOBNO = HdnUpdate_id.Value;

                EGM.EGM_ID = HdnUpdate_id.Value;
                EGM.EGM_JOBNO = txt_EGM_Jobno.Text;
                EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value == string.Empty ? 0 : Convert.ToInt32(hdn_SB_SlNo.Value));
                EGM.Ename = "Select_EGM_CONSOLIDATE_Rotation_Details";
            }
            
            else
            {
                //EGM.EGM_ID = Request.QueryString["Page"].ToString();
                //EGM.EGM_ID = Request.QueryString["egm_id"].ToString();
                EGM.EGM_ID = HdnUpdate_id.Value;
                //EGM.JOBNO = HdnUpdate_id.Value;
                EGM.EGM_JOBNO = txt_EGM_Jobno.Text;
                EGM.JOBNO = hdn_Jobno.Value;
                //EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value == string.Empty ? 0 : Convert.ToInt32(hdn_SB_SlNo.Value));
                EGM.SBNO = txt_SBNo.Text;
                EGM.Ename = "select_EGM_Details_Grid";
            }

            EGM.WORKINGPERIOD = Connection.Get_Company_Type();
            ds = EGM.EGM_CONSOLIDATE_Select_All();
            int i = EGM.result;
            HD_Type.Value = i.ToString();

           
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                    txt_JobNo.Visible = true;

                    HD_Update_id.Value = ds.Tables[0].Rows[0]["EGM_ID"].ToString();
                    //ddlJobNo.SelectedValue = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                    txt_EGM_Jobno.Text = ds.Tables[0].Rows[0]["EGM_JOBNO"].ToString();
                    txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                    hdn_Jobno.Value = txt_JobNo.Text;
                    txt_Job_Date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                    txt_stuffDate.Text = ds.Tables[0].Rows[0]["STUFFDATE"].ToString().Replace("01/01/1900", "");
                    txt_RotationNo.Text = ds.Tables[0].Rows[0]["ROTATION_NO"].ToString();
                    txt_RotationDate.Text = ds.Tables[0].Rows[0]["ROTATION_DATE"].ToString();
                    txt_LinerName.Text = ds.Tables[0].Rows[0]["LINER_NAME"].ToString();
                    txt_Vessel_Name.Text = ds.Tables[0].Rows[0]["VESSEL_NAME"].ToString();
                    txt_IMO_No.Text = ds.Tables[0].Rows[0]["IMO_NO"].ToString();

                    txt_Voyage_No.Text = ds.Tables[0].Rows[0]["VOYAGE_NO"].ToString();
                    txt_SBNo.Text = ds.Tables[0].Rows[0]["SBNO"].ToString();
                    txt_SBDate.Text = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
                    txt_GatewayPort.Text = ds.Tables[0].Rows[0]["GATEWAY_PORT"].ToString();
                    ddl_Nature_of_Cargo.SelectedValue = ds.Tables[0].Rows[0]["NATURE_OF_CARGO"].ToString();

                    txt_Port_of_Origin.Text = ds.Tables[0].Rows[0]["PORT_ORIGIN"].ToString();
                    txt_Destination_Port.Text = ds.Tables[0].Rows[0]["DESTINATION_PORT"].ToString();
                    txt_Quantity.Text = ds.Tables[0].Rows[0]["QUATITY"].ToString();
                    txt_Unit.Text = ds.Tables[0].Rows[0]["UNIT_QTY"].ToString();
                    txt_No_of_Packages.Text = ds.Tables[0].Rows[0]["NO_OF_PKGS"].ToString();
                    //txt_Loose_Packets.Text = ds.Tables[0].Rows[0]["NO_OF_PKGS"].ToString();

                    txtExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["EXPORTER_ADD1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["EXPORTER_ADD2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["EXPORTER_ADD3"].ToString();
                    txtAddress4.Text = ds.Tables[0].Rows[0]["EXPORTER_ADD4"].ToString();
                    //txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    txtConsigneeName.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    txtConsigneeAddress.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                    txtConsigneeAddress1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                    txtConsigneeAddress2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                    txtConsigneeAddress3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                    txt_Description.Text = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();


                    hdn_SB_SlNo.Value = ds.Tables[0].Rows[0]["SB_SLNO"].ToString();
   
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;

                    if (Update_Grid == "Update_Grid")
                    {
                        gv_ItemDetails.DataSource = ds.Tables[0];
                        gv_ItemDetails.DataBind();
                    }

                    //ViewState["ds"] = ds.Tables[0];

                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    gv_ItemDetails.DataSource = ds.Tables[0];
                    //    gv_ItemDetails.DataBind();
                    //}
            }
            else
            {
                SetInitialRow();
                gv_ItemDetails.DataSource = dt_item;
                gv_ItemDetails.DataBind();

                //if (txt_RotationDate.Text == "")
                //{
                //    DateTime dateTime = DateTime.UtcNow.Date;
                //    txt_RotationDate.Text = dateTime.ToString("dd/MM/yyyy");
                //}
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                gvAll.DataSource = ds.Tables[1];
                gvAll.DataBind();
                ViewState["CurrentTable"] = ds.Tables[1];
                SetPreviousData();
            }
            else
            {
                SetInitialRow();
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        //gv_details_Grid_Bind();
    }


    public void Bind_Details_New_JOBNO_SBNO(string flag, string jobno, string EGM_id, string SBNo)
    {
        try
        {
            DataTable dt_item = new DataTable();

            EGM.EGM_ID = EGM_id;
            //EGM.JOBNO = HdnUpdate_id.Value;
            EGM.JOBNO = jobno;
            //EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value == string.Empty ? 0 : Convert.ToInt32(hdn_SB_SlNo.Value));
            EGM.SBNO = SBNo;
            EGM.Ename = flag;

            EGM.WORKINGPERIOD = Connection.Get_Company_Type();
            ds = EGM.EGM_CONSOLIDATE_Select_All();
            int i = EGM.result;
            HD_Type.Value = i.ToString();


            if (ds.Tables[0].Rows.Count > 0)
            {

                if (i == 1)
                {
                    hdn_Jobno.Value = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                    txt_Job_Date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();


                    txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                    txtExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    //txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txtAddress.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txtAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txtAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    txtAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();

                    txtConsigneeName.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    txtConsigneeAddress.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                    txtConsigneeAddress1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                    txtConsigneeAddress2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                    txtConsigneeAddress3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();

                    txt_SBNo.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                    txt_SBDate.Text = ds.Tables[0].Rows[0]["SB_DATE"].ToString();

                    //txt_Port_of_Origin.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                    txt_Destination_Port.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                    //txt_GatewayPort.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();

                    //txt_Description.Text = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                    txt_Description.Text = ds.Tables[4].Rows[0]["ITEM_DESCRIPTION"].ToString();


                    if (Connection.COMPANYID() == "517")
                    {
                        txt_GatewayPort.Text = "INTUT1";
                    }
                    else
                    {
                        txt_GatewayPort.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    }
                    txt_Port_of_Origin.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        ddl_Nature_of_Cargo.SelectedValue = ds.Tables[2].Rows[0]["ANNEX_AIR_NATURE_OF_CARGO"].ToString();
                        txt_No_of_Packages.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
                        txt_Quantity.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();
                        txt_Unit.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();
                        //txt_RotationNo.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString();
                        //if (ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString() != "")
                        //{
                        //    txt_RotationDate.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString();
                        //}
                        //if (txt_RotationDate.Text == "")
                        //{
                        //    DateTime dateTime = DateTime.UtcNow.Date;
                        //    txt_RotationDate.Text = dateTime.ToString("dd/MM/yyyy");
                        //}
                    }
                    //else
                    //{
                    //    DateTime dateTime = DateTime.UtcNow.Date;
                    //    txt_RotationDate.Text = dateTime.ToString("dd/MM/yyyy");
                    //}

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        ddl_Nature_of_Cargo.SelectedValue = ds.Tables[3].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
                        txt_No_of_Packages.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
                        txt_Unit.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();
                        txt_Quantity.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();

                        //txt_RotationNo.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString();
                        //if (ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString().Replace("01/01/1900", "") != "")
                        //{
                        //    txt_RotationDate.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString();
                        //}
                        //else
                        //{
                        //if (txt_RotationDate.Text == "")
                        //{
                        //    DateTime dateTime = DateTime.UtcNow.Date;
                        //    txt_RotationDate.Text = dateTime.ToString("dd/MM/yyyy");
                        //}
                        //}
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataTable firstTable = ds.Tables[1];
                        ViewState["CurrentTable"] = firstTable;

                        gvAll.DataSource = ds.Tables[1];
                        gvAll.DataBind();
                    }
                    //else
                    //{
                    //    SetInitialRow();
                    //}

                    //gv_ItemDetails.DataSource = dt_item;
                    //gv_ItemDetails.DataBind();

                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;

                }
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
        //gv_details_Grid_Bind();
    }

    public int Insert_Update(string a1, string a2,int MAX_SLNO)
    {

            EGM.JOBNO = txt_JobNo.Text;
            EGM.EGM_JOBNO = txt_EGM_Jobno.Text;

            //EGM.JOBNO = hdn_Jobno.Value;
            EGM.JOBDATE = txt_Job_Date.Text;
            EGM.ROTATION_NO = txt_RotationNo.Text;
            EGM.ROTATION_DATE = txt_RotationDate.Text;
            //EGM.STUFFDATE = txt_stuffDate.Text;
            EGM.STUFFDATE = txt_stuffDate.Text == string.Empty ? "01/01/1900" : txt_stuffDate.Text;
            EGM.LINER_NAME = txt_LinerName.Text;
            EGM.VESSEL_NAME = txt_Vessel_Name.Text;
            EGM.IMO_NO = txt_IMO_No.Text;
            EGM.VOYAGE_NO = txt_Voyage_No.Text;

            EGM.EXPORTER_NAME = txtExporterName.Text;
            EGM.EXPORTER_ADD1 = txtAddress.Text;
            EGM.EXPORTER_ADD2 = txtAddress2.Text;
            EGM.EXPORTER_ADD3 = txtAddress3.Text;
            EGM.EXPORTER_ADD4 = txtAddress4.Text;

            EGM.SBNO = txt_SBNo.Text;
            EGM.SB_DATE = txt_SBDate.Text;
            EGM.PORT_ORIGIN = txt_Port_of_Origin.Text;
            EGM.DESTINATION_PORT = txt_Destination_Port.Text;
            EGM.GATEWAY_PORT = txt_GatewayPort.Text;
            EGM.NATURE_OF_CARGO = ddl_Nature_of_Cargo.SelectedValue;

            EGM.CONSIGNEE_NAME = txtConsigneeName.Text;
            EGM.CONSIGNEE_ADD1 = txtConsigneeAddress.Text;
            EGM.CONSIGNEE_ADD2 = txtConsigneeAddress1.Text;
            EGM.CONSIGNEE_ADD3 = txtConsigneeAddress2.Text;
            EGM.CONSIGNEE_ADD4 = txtConsigneeAddress3.Text;

            EGM.QUATITY = txt_Quantity.Text;
            EGM.UNIT_QTY = txt_Unit.Text;
            EGM.NO_OF_PKGS = txt_No_of_Packages.Text;
            EGM.DESCRIPTION = txt_Description.Text;

            EGM.flag = a2;

            EGM.USERID = Connection.Current_User();
            EGM.STATUS = a2;
            EGM.BRANCHCODE = Connection.Current_Branch();
            EGM.WORKINGPERIOD = Connection.WorkingPeriod();
            EGM.SB_SLNO = MAX_SLNO;


            EGM.UPD_ID = HD_Update_id.Value;
            EGM.EGM_CONSOLIDATE_Insert_Update();
            i = EGM.result;

        return i;      
    }

  
    protected void btnNew_Click(object sender, EventArgs e)
    {
        txt_SBNo.Text = "";
        txt_SBDate.Text = "";
        //txt_GatewayPort.Text = "";
        //txt_Port_of_Origin.Text = ""; 
        txt_Destination_Port.Text = "";
        txt_Quantity.Text = "";
        txt_Unit.Text = "";
        txt_No_of_Packages.Text = "";
        //txt_Loose_Packets.Text = "";
        txt_JobNo.Text = "";
        txt_Job_Date.Text = "";
        txt_SBNo.Text = "";
        txt_SBDate.Text = "";
        txt_Description.Text = "";

        txtExporterName.Text = "";
        txtAddress.Text = "";
        txtAddress2.Text = "";
        txtAddress3.Text = "";
        txtAddress4.Text = "";
        txtConsigneeName.Text = "";
        txtConsigneeAddress.Text = "";
        txtConsigneeAddress1.Text = "";
        txtConsigneeAddress2.Text = "";
        txtConsigneeAddress3.Text = "";
       
        btnUpdate.Visible = false;
        btnDelete.Visible = false;

        btnSave.Visible = true;
        //SetInitialRow();
        txt_JobNo.Focus();
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
                    TextBox txtContainerNo = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txtContainerNo");
                    DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[2].FindControl("ddl_size");
                    DropDownList ddl_Type = (DropDownList)gvAll.Rows[rowIndex].Cells[3].FindControl("ddl_Type");

                    if (txtContainerNo.Text == string.Empty)
                    {
                        Emptyrow = "Y";
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["CONTAINER_NO"] = txtContainerNo.Text;
                    dtCurrentTable.Rows[i - 1]["SIZE"] = ddl_size.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["TYPE"] = ddl_Type.SelectedValue;

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
        dt.Columns.Add(new DataColumn("JOBNO", typeof(string)));
        dt.Columns.Add(new DataColumn("SBNO", typeof(string)));
        dt.Columns.Add(new DataColumn("SLNO", typeof(string)));
        dt.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("SIZE", typeof(string)));
        dt.Columns.Add(new DataColumn("TYPE", typeof(string)));
        
        
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["JOBNO"] = "";
        dr["SBNO"] = "";
        dr["SLNO"] = "";
        dr["CONTAINER_NO"] = string.Empty;
        dr["SIZE"] = "20";
        dr["TYPE"] = "FR";
        
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
                    TextBox txtContainerNo = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtContainerNo");
                    DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[2].FindControl("ddl_size");
                    DropDownList ddl_Type = (DropDownList)gvAll.Rows[rowIndex].Cells[3].FindControl("ddl_Type");

                    //TextBox txtgross_wgt = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txtgross_wgt");

                    gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                    if (dt.Rows[i][4].ToString() != "")
                    {
                        //txtContainerNo.Text = dt.Rows[i][1].ToString();
                        txtContainerNo.Text = dt.Rows[i][4].ToString();
                        ddl_size.SelectedValue = dt.Rows[i][5].ToString();
                        ddl_Type.SelectedValue = dt.Rows[i][6].ToString();
                       
                         rowIndex++;
                    }
                    else
                    {
                        txtContainerNo.Text ="";
                        ddl_size.SelectedValue = "20";
                        ddl_Type.SelectedValue = "F";
                    }
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
                    TextBox txtContainerNo = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtContainerNo");
                    DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[2].FindControl("ddl_size");
                    DropDownList ddl_Type = (DropDownList)gvAll.Rows[rowIndex].Cells[3].FindControl("ddl_Type");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["CONTAINER_NO"] = txtContainerNo.Text;
                    dtCurrentTable.Rows[i - 1]["SIZE"] = ddl_size.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["TYPE"] = ddl_Type.SelectedValue;
                    
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
       
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int Max_SlNo = Get_MAXID("Get_EGM_MAX_SLNO");
            i = Insert_Update("N", "S", Max_SlNo);

            if (i == 1)
            {
                int update_id = EGM.UpdateId;
                EgmJobno_maxReturn = EGM.EGM_JOBNO_max_return;
                txt_EGM_Jobno.Text = Convert.ToString(EgmJobno_maxReturn);

                HD_Update_id.Value = Convert.ToString(update_id);
                HdnUpdate_id.Value = Convert.ToString(update_id);
                ViewState["UPDATE_ID"] = update_id;
                hdn_SB_SlNo.Value = Convert.ToString(Max_SlNo);
                Update_Grid = "Update_Grid";
                //EGM.Ename = "Select_All_Details";

                //Check_JobNo();

                //Alert_msg("Saved Successfully", "btnSave");
                //btnUpdate.Visible = true;
                //btnDelete.Visible = true;
                //btnSave.Visible = false;

                DataTable dtt = new DataTable();
                DataRow dr;
                dtt.Columns.Add(new System.Data.DataColumn("EGM_CONID", typeof(int)));
                dtt.Columns.Add(new System.Data.DataColumn("EGM_JOBNO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("SBNO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("SLNO", typeof(int)));
                dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_NO", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("SIZE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("TYPE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("USERID", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("LOGIN_DATE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("STATUS", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));
                dtt.Columns.Add(new System.Data.DataColumn("ROTATION_NO", typeof(String)));


                int x = 1;
                int MAX_ID = Get_MAXID("Get_EGM_Container_MAXID");
                //int Max_SlNo = Get_MAXID("Get_EGM_MAX_SLNO");

                foreach (GridViewRow row in gvAll.Rows)
                {
                    TextBox txtContainerNo = (TextBox)row.FindControl("txtContainerNo");
                    DropDownList ddl_size = (DropDownList)row.FindControl("ddl_size");
                    DropDownList ddl_Type = (DropDownList)row.FindControl("ddl_Type");

                    if (txtContainerNo.Text == string.Empty)
                    {
                    }
                    else
                    {
                        dr = dtt.NewRow();
                        
                        dr[0] = MAX_ID;
                        //dr[1] = txt_EGM_Jobno.Text;
                        dr[1] = EgmJobno_maxReturn;
                        dr[2] = txt_JobNo.Text;
                        dr[3] = txt_SBNo.Text;
                        dr[4] = Max_SlNo;
                        dr[5] = txtContainerNo.Text;
                        dr[6] = ddl_size.SelectedValue;
                        dr[7] = ddl_Type.SelectedValue;
                        dr[8] = Connection.Current_User();
                        dr[9] = Session["LoginDate"].ToString();
                        dr[10] = "S";
                        dr[11] = Connection.Current_Branch();
                        dr[12] = Connection.WorkingPeriod();
                        dr[13] = txt_RotationNo.Text;


                        dtt.Rows.Add(dr);
                        x = x + 1;
                        MAX_ID = MAX_ID + 1;
                    }
                }
                
                if (dtt.Rows.Count > 0)
                {
                    Delete_Container(EgmJobno_maxReturn);
                    AdminMasterDetails adm = new AdminMasterDetails();
                    adm.SqlBulk_Upload_Product("EGM_CONSOLIDATE_CONTAINER_DETAILS", dtt, Session["currentcomp_db"].ToString());
                }

                DataSet dsData = new DataSet();
                dsData.Tables.Add(dtt);

                Alert_msg("Saved Successfully", "btnSave");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;

            }
            else
            {
                Alert_msg("Record Already Exists!!!", "btnSave");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
            }

            //Bind_EGM_Details();
            HdnUpdate_id.Value = txt_RotationNo.Text;
            gv_details_Grid_Bind();
        }

        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        //if (ddlJobNo.SelectedItem.Text != "Select")
    //        //{
                
    //            DataTable dtt = new DataTable();
    //            DataRow dr;
    //            dtt.Columns.Add(new System.Data.DataColumn("EGM_CONID", typeof(int)));
    //            dtt.Columns.Add(new System.Data.DataColumn("EGM_JOBNO", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("JOBNO", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("SBNO", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("SLNO", typeof(int)));
    //            dtt.Columns.Add(new System.Data.DataColumn("CONTAINER_NO", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("SIZE", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("TYPE", typeof(String)));            
    //            dtt.Columns.Add(new System.Data.DataColumn("USERID", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("LOGIN_DATE", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("STATUS", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("BRANCHCODE", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("WORKINGPERIOD", typeof(String)));
    //            dtt.Columns.Add(new System.Data.DataColumn("ROTATION_NO", typeof(String)));


    //            int x = 1;
    //            int MAX_ID = Get_MAXID("Get_EGM_Container_MAXID");
    //            int Max_SlNo = Get_MAXID("Get_EGM_MAX_SLNO");
               
    //            foreach (GridViewRow row in gvAll.Rows)
    //            {
    //                TextBox txtContainerNo = (TextBox)row.FindControl("txtContainerNo");
    //                DropDownList ddl_size = (DropDownList)row.FindControl("ddl_size");
    //                DropDownList ddl_Type = (DropDownList)row.FindControl("ddl_Type");

    //                if (txtContainerNo.Text == string.Empty)
    //                {
    //                }
    //                else
    //                {
    //                    dr = dtt.NewRow();

    //                    dr[0] = MAX_ID;
    //                    dr[1] = txt_EGM_Jobno.Text;
    //                    dr[2] = txt_JobNo.Text;
    //                    dr[3] = txt_SBNo.Text;
    //                    dr[4] = Max_SlNo;
    //                    dr[5] = txtContainerNo.Text;
    //                    dr[6] = ddl_size.SelectedValue;
    //                    dr[7] = ddl_Type.SelectedValue;
    //                    dr[8] = Connection.Current_User();
    //                    dr[9] = Session["LoginDate"].ToString();
    //                    dr[10] = "S";
    //                    dr[11] = Connection.Current_Branch();
    //                    dr[12] = Connection.WorkingPeriod();
    //                    dr[13] = txt_RotationNo.Text;

                        
    //                    dtt.Rows.Add(dr);
    //                    x = x + 1;
    //                    MAX_ID = MAX_ID + 1;
    //                }
    //            }

    //            if (dtt.Rows.Count > 0)
    //            {
    //                Delete_Container();
    //                AdminMasterDetails adm = new AdminMasterDetails();
    //                adm.SqlBulk_Upload_Product("EGM_CONSOLIDATE_CONTAINER_DETAILS", dtt, Session["currentcomp_db"].ToString());
    //            }

    //            DataSet dsData = new DataSet();
    //            dsData.Tables.Add(dtt);


    //            //int Max_SlNo = Get_MAXID("Get_EGM_MAX_SLNO");

    //            i = Insert_Update("N", "S", Max_SlNo);

    //            if (i == 1)
    //            {
    //                int update_id = EGM.UpdateId;

    //                HD_Update_id.Value = Convert.ToString(update_id);
    //                HdnUpdate_id.Value = Convert.ToString(update_id);
    //                ViewState["UPDATE_ID"] = update_id;
    //                hdn_SB_SlNo.Value = Convert.ToString(Max_SlNo);
    //                Update_Grid = "Update_Grid";
    //                //EGM.Ename = "Select_All_Details";

    //                //Check_JobNo();

    //                Alert_msg("Saved Successfully", "btnSave");
    //                btnUpdate.Visible = true;
    //                btnDelete.Visible = true;
    //                btnSave.Visible = false;
    //            }
    //            else
    //            {
    //                Alert_msg("Record Already Exists!!!", "btnSave");
    //                btnUpdate.Visible = true;
    //                btnDelete.Visible = true;
    //                btnSave.Visible = false;
    //            }
                
    //            //Bind_EGM_Details();
    //            HdnUpdate_id.Value = txt_RotationNo.Text;
    //            gv_details_Grid_Bind();
    //    }
        
    //    catch (Exception ex)
    //    {
    //        er.makeLog(ex.Message);
    //    }
    //}

    public int Get_MAXID(string Flag)
    {
        int MAX_ID = 0;
        DataSet dt_max = new DataSet();
        EGM.EGM_JOBNO = txt_EGM_Jobno.Text;
        EGM.JOBNO = hdn_Jobno.Value;
        EGM.ROTATION_NO = txt_RotationNo.Text;
        EGM.WORKINGPERIOD = Connection.Get_Company_Type();
        EGM.Ename = Flag;

        dt_max = EGM.EGM_CONSOLIDATE_Select_All();

        if (dt_max.Tables[0].Rows.Count > 0)
        {
            MAX_ID = Convert.ToInt32(dt_max.Tables[0].Rows[0]["MAXID"].ToString());
        }

        return MAX_ID;
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in gv_ItemDetails.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk");
                if (chk.Checked)
                {

                   string JOBNO = row.Cells[2].Text;
                   string SBNO = row.Cells[4].Text;
                  
                    DataSet dt_max = new DataSet();
                    EGM.EGM_JOBNO = txt_EGM_Jobno.Text;
                    EGM.JOBNO = JOBNO;
                    EGM.WORKINGPERIOD = Connection.Get_Company_Type();
                    EGM.SBNO = SBNO;
                    EGM.Ename = "delete";

                    dt_max = EGM.EGM_CONSOLIDATE_Select_All();

                    i = EGM.result;
                }
            }

            if (i == 1)
            {
                //string prompt = "<script>$(document).ready(function(){{jAlert('Record Deleted', 'EGM', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                string prompt = "<script>$(document).ready(function(){{jAlert('Record Deleted', 'EGM', function (r) {var i = r + 'ok';if (i == 'trueok') else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

                HdnUpdate_id.Value = txt_RotationNo.Text;
                Bind_Type = "Rotation";
                Update_Grid = "Update_Grid";
                Bind_EGM_Details();

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

    protected void btn_DeleteAll_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dt_max = new DataSet();
            EGM.EGM_JOBNO = txt_EGM_Jobno.Text;
            EGM.JOBNO = txt_RotationNo.Text;
            EGM.WORKINGPERIOD = Connection.Get_Company_Type();
            //EGM.EGM_ID = txt_SBNo.Text;
            EGM.EGM_ID = "";
            EGM.Ename = "delete_Rotation_All";

            dt_max = EGM.EGM_CONSOLIDATE_Select_All();

            i = EGM.result;

            if (i == 1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Record Deleted', 'EGM', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);

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

    public void Delete_Container(int EgmJobno_max)
    {
        DataSet dt_max = new DataSet();
        //EGM.JOBNO = hdn_Jobno.Value;
        EGM.JOBNO = txt_JobNo.Text;
        //EGM.JOBNO = Convert.ToString(EgmJobno_max);
        EGM.WORKINGPERIOD = Connection.Get_Company_Type();
        //EGM.EGM_ID = hdn_SB_SlNo.Value;
        EGM.EGM_ID = txt_RotationNo.Text;

        EGM.Ename = "delete_Container";

        dt_max = EGM.EGM_CONSOLIDATE_Select_All();
    }

    protected void gv_ItemDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
            e.Row.Enabled = true;
            e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
            //e.Row.Attributes["onmouseout"] = "this.style.background='white'";
            e.Row.Attributes.Add("onclick", ClientScript.GetPostBackClientHyperlink(this.gv_ItemDetails, "Select$" + e.Row.RowIndex.ToString()));

           
            if (e.Row.Cells[8].Text.Length > 20)
            {
                e.Row.Cells[8].Text = e.Row.Cells[8].Text.Substring(0, 20) + "..";
            }
            if (e.Row.Cells[9].Text.Length > 20)
            {
                e.Row.Cells[9].Text = e.Row.Cells[9].Text.Substring(0, 20) + "..";
            }
        }
    }

    protected void gv_ItemDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gv_ItemDetails.PageIndex = e.NewPageIndex;
        //string item_slno = "0", item_id = "0", flag = "select_con";
        //Gridbind_ItemDetails(ddlInvoice_SlNo.SelectedValue.ToString(), item_slno, item_id, flag);
    }

    protected void gv_ItemDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Bind_Type = "Grid";
            string EGM_ID = Convert.ToString(this.gv_ItemDetails.SelectedDataKey.Value);
            string JOBNO = Convert.ToString(this.gv_ItemDetails.SelectedDataKey.Values[1]);

            HdnUpdate_id.Value = EGM_ID;
            //hdn_SB_SlNo.Value = JOBNO;
            hdn_Jobno.Value = JOBNO;

            Update_Grid = "excel";
            Bind_EGM_Details();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_ItemDetails_RowCreated(object sender, GridViewRowEventArgs e)
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

    //[System.Web.Services.WebMethod]
    //public static string Get_EGM_JobNo_Container()
    //{

    //    //if (HttpContext.Current != null)
    //    //{
    //    //    Page page = (Page)HttpContext.Current.Handler;
    //    //    TextBox txt_JobNo = (TextBox)page.FindControl("txt_JobNo");

    //    //    //TextBox TextBox2 = (TextBox)page.FindControl("TextBox2");
    //    //    string custid1 = txt_JobNo.Text;
    //    //}
    //    string custid = "";
       
    //    EGM EGM = new EGM();
    //    DataSet ds = new DataSet();
    //    EGM.JOBNO = "14";
    //    EGM.SB_SLNO = 0;
    //    EGM.Ename = "Select_EGM_CONSOLIDATE_DETAILS_job_Search";
    //    EGM.WORKINGPERIOD = "";
    //    ds = EGM.EGM_CONSOLIDATE_Select_All();

    //    GridView gvAll = new GridView();
    //    gvAll.DataSource = ds;
    //    gvAll.DataBind();

    //    return custid;
    //}

    [System.Web.Services.WebMethod]
    public static string Get_EGM_JobNo(string custid, string custid1)
    {

        EGM EGM = new EGM();
        DataSet ds = new DataSet();
        EGM.JOBNO = custid;
        EGM.SB_SLNO = 0;
        EGM.Ename = "Select_EGM_CONSOLIDATE_DETAILS_job_Search";
        EGM.WORKINGPERIOD = custid1;
        ds = EGM.EGM_CONSOLIDATE_Select_All();

        string JOBNO = "", JOBDATE = "", EXPORTER_NAME = "", ADDRESS1 = "", ADDRESS2 = "", ADDRESS3 = "", ADDRESS4 = "", ADDRESS5 = "", CUSTOMS_HOUSE = "", PORT_DISCHARGE = "",
            PORT_FINAL_DEST = "", CONSIGNEE_NAME = "", CONSIGNEE_ADD1 = "", CONSIGNEE_ADD2 = "", CONSIGNEE_ADD3 = "", CONSIGNEE_ADD4 = "", SB_NO = "", SB_DATE = "",
            ANNEX_AIR_NATURE_OF_CARGO = "", ANNEX_AIR_TOTAL_PACKAGES = "", ANNEX_AIR_GROSS_WEIGHT = "", ANNEX_AIR_GR_UNIT_CODE = "", ANNEX_AIR_ROTATION_NO = "", ANNEX_AIR_ROTATION_DATE = "";
           
        if (ds.Tables[0].Rows.Count > 0)
        {
             JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();
             JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
             EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
             ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
             ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
             ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
             ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
             ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
             CUSTOMS_HOUSE = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
             PORT_DISCHARGE = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
             PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
             CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
             CONSIGNEE_ADD1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
             CONSIGNEE_ADD2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
             CONSIGNEE_ADD3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
             CONSIGNEE_ADD4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
             SB_NO = ds.Tables[0].Rows[0]["SB_NO"].ToString();
             SB_DATE = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
            //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
            //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
            //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
            //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
        }
        if (ds.Tables[2].Rows.Count > 0)
        {

             ANNEX_AIR_NATURE_OF_CARGO = ds.Tables[2].Rows[0]["ANNEX_AIR_NATURE_OF_CARGO"].ToString();
             ANNEX_AIR_TOTAL_PACKAGES = ds.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
             ANNEX_AIR_GROSS_WEIGHT = ds.Tables[2].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();
             ANNEX_AIR_GR_UNIT_CODE = ds.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();
             ANNEX_AIR_ROTATION_NO = ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString();
             ANNEX_AIR_ROTATION_DATE = ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString();         
        }

        if (ds.Tables[3].Rows.Count > 0)
        {

            ANNEX_AIR_NATURE_OF_CARGO = ds.Tables[3].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
            ANNEX_AIR_TOTAL_PACKAGES = ds.Tables[3].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
            ANNEX_AIR_GROSS_WEIGHT = ds.Tables[3].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();
            ANNEX_AIR_GR_UNIT_CODE = ds.Tables[3].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();
            ANNEX_AIR_ROTATION_NO = ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString();
            ANNEX_AIR_ROTATION_DATE = ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString();
        }


        custid = JOBNO + "~~" + JOBDATE + "~~" + EXPORTER_NAME + "~~" + ADDRESS1 + "~~" + ADDRESS2 + "~~" + ADDRESS3 + "~~" + ADDRESS4 + "~~" + ADDRESS5 + "~~" +
                CUSTOMS_HOUSE + "~~" + PORT_DISCHARGE + "~~" + PORT_FINAL_DEST + "~~" + CONSIGNEE_NAME + "~~" + CONSIGNEE_ADD1 + "~~" + CONSIGNEE_ADD2 + "~~" + CONSIGNEE_ADD3 + "~~" + CONSIGNEE_ADD4 + "~~" +
               SB_NO + "~~" + SB_DATE + "~~" + ANNEX_AIR_NATURE_OF_CARGO + "~~" + ANNEX_AIR_TOTAL_PACKAGES + "~~" + ANNEX_AIR_GROSS_WEIGHT + "~~" + ANNEX_AIR_GR_UNIT_CODE + "~~" + ANNEX_AIR_ROTATION_NO + "~~" + ANNEX_AIR_ROTATION_DATE;
        return custid;
    }

    [System.Web.Services.WebMethod]
    public static string Get_SB_JobNo(string custid, string custid1)
    {
        string JOBNO = "", JOBDATE = "", EXPORTER_NAME = "", ADDRESS1 = "", ADDRESS2 = "", ADDRESS3 = "", ADDRESS4 = "", ADDRESS5 = "", CUSTOMS_HOUSE = "", PORT_DISCHARGE = "",
                PORT_FINAL_DEST = "", CONSIGNEE_NAME = "", CONSIGNEE_ADD1 = "", CONSIGNEE_ADD2 = "", CONSIGNEE_ADD3 = "", CONSIGNEE_ADD4 = "", SB_NO = "", SB_DATE = "",
                ANNEX_AIR_NATURE_OF_CARGO = "", ANNEX_AIR_TOTAL_PACKAGES = "", ANNEX_AIR_GROSS_WEIGHT = "", ANNEX_AIR_GR_UNIT_CODE = "", ANNEX_AIR_ROTATION_NO = "", ANNEX_AIR_ROTATION_DATE = "";

        if (custid != "")
        {
            EGM EGM = new EGM();
            DataSet ds = new DataSet();
            EGM.JOBNO = custid;
            EGM.SB_SLNO = 0;
            EGM.Ename = "Select_EGM_CONSOLIDATE_DETAILS_SB_Search";
            EGM.WORKINGPERIOD = custid1;
            ds = EGM.EGM_CONSOLIDATE_Select_All();

            
            if (ds.Tables[0].Rows.Count > 0)
            {
                JOBNO = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                JOBDATE = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                EXPORTER_NAME = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                ADDRESS1 = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                ADDRESS2 = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                ADDRESS3 = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                ADDRESS4 = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();
                ADDRESS5 = ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                CUSTOMS_HOUSE = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                PORT_DISCHARGE = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                CONSIGNEE_NAME = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                CONSIGNEE_ADD1 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                CONSIGNEE_ADD2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                CONSIGNEE_ADD3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                CONSIGNEE_ADD4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
                SB_NO = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                SB_DATE = ds.Tables[0].Rows[0]["SB_DATE"].ToString();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                //PORT_FINAL_DEST = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {

                ANNEX_AIR_NATURE_OF_CARGO = ds.Tables[2].Rows[0]["ANNEX_AIR_NATURE_OF_CARGO"].ToString();
                ANNEX_AIR_TOTAL_PACKAGES = ds.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
                ANNEX_AIR_GROSS_WEIGHT = ds.Tables[2].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();
                ANNEX_AIR_GR_UNIT_CODE = ds.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();
                ANNEX_AIR_ROTATION_NO = ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString();
                ANNEX_AIR_ROTATION_DATE = ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString();
            }

            if (ds.Tables[3].Rows.Count > 0)
            {

                ANNEX_AIR_NATURE_OF_CARGO = ds.Tables[3].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
                ANNEX_AIR_TOTAL_PACKAGES = ds.Tables[3].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
                ANNEX_AIR_GROSS_WEIGHT = ds.Tables[3].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();
                ANNEX_AIR_GR_UNIT_CODE = ds.Tables[3].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();
                ANNEX_AIR_ROTATION_NO = ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString();
                ANNEX_AIR_ROTATION_DATE = ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString();
            }
            custid = JOBNO + "~~" + JOBDATE + "~~" + EXPORTER_NAME + "~~" + ADDRESS1 + "~~" + ADDRESS2 + "~~" + ADDRESS3 + "~~" + ADDRESS4 + "~~" + ADDRESS5 + "~~" +
                CUSTOMS_HOUSE + "~~" + PORT_DISCHARGE + "~~" + PORT_FINAL_DEST + "~~" + CONSIGNEE_NAME + "~~" + CONSIGNEE_ADD1 + "~~" + CONSIGNEE_ADD2 + "~~" + CONSIGNEE_ADD3 + "~~" + CONSIGNEE_ADD4 + "~~" +
               SB_NO + "~~" + SB_DATE + "~~" + ANNEX_AIR_NATURE_OF_CARGO + "~~" + ANNEX_AIR_TOTAL_PACKAGES + "~~" + ANNEX_AIR_GROSS_WEIGHT + "~~" + ANNEX_AIR_GR_UNIT_CODE + "~~" + ANNEX_AIR_ROTATION_NO + "~~" + ANNEX_AIR_ROTATION_DATE;

        }
        
        return custid;
    }


    [System.Web.Services.WebMethod]
    public static string Get_Duplicate_RotationNo(string custid, string Jobno)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        string InvoiceNo = "";
        // custid = Auto.Country_Master_FromClientSide_Calling(custid);
        Auto.Ename = "EXPORT_DUPLICATE_ROTATION_NO";
        Auto.Enamesearch = custid;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["ROTATION_NO"].ToString() != "")
            {
                if (ds.Tables[0].Rows[0]["ROTATION_NO"].ToString() != Jobno)
                {
                    InvoiceNo = ds.Tables[0].Rows[0]["ROTATION_NO"].ToString() + "~~";
                }
            }
        }
        return InvoiceNo;
    }


    [System.Web.Services.WebMethod]
    public static string Get_Vessel_IMo_code(string custid, string Jobno)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        string VesselCode = "";
        Auto.Ename = "Get_Vessel_IMO_Code";
        Auto.Enamesearch = custid;
        Auto.NSearch = "Vessel";
        //ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_BILLING_OTHERS();
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["CODE"].ToString() != "")
            {
                if (ds.Tables[0].Rows[0]["CODE"].ToString() != Jobno)
                {
                    VesselCode = ds.Tables[0].Rows[0]["CODE"].ToString();
                }
            }
        }
        return VesselCode;
    }
    [System.Web.Services.WebMethod]
    public static string Get_ConsigneeName(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();      
        Auto.Ename = "CONSIGNEE_MASTER_SEARCH";
          Auto.Enamesearch = custid;
        //Auto.NSearch = Branchslno;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();

        if (ds.Tables[0].Rows.Count > 0)
        {

            string Address1 = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
            string Address3 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["CONSIGNEE_COUNTRY_NAME"].ToString();
            string CONSIGNEE_PIN_CODE = ds.Tables[0].Rows[0]["CONSIGNEE_PIN_CODE"].ToString();

            //string Address6 = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();
            //string Branchslno1 = ds.Tables[0].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString();


            //custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address6 + "~~" + Address5 + "~~" + Branchslno1;
            custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5;
        }

        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetImporter(string custid)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_ADCODE";
        Auto.Enamesearch = custid;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
        if (ds.Tables[0].Rows.Count > 0)
        {
            //string Adcode = "", Adcode_Bank_Account = "";
            string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
            string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
            string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
            string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString();
            string Address5 = ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();
         
            //custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 + "~~" + Adcode + "~~" + Adcode_Bank_Account;
            custid = Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4 + "~~" + Address5 ;
        }
        return custid;
    }
  
    protected void txt_JobNo_TextChanged(object sender, EventArgs e)
    {
        Bind_Details_New_JOBNO_SBNO("Select_EGM_CONSOLIDATE_DETAILS_job_Search", txt_JobNo.Text, "", txt_SBNo.Text);
        txt_JobNo.Focus();
    }

    protected void txt_SBNo_TextChanged(object sender, EventArgs e)
    {
        Bind_Details_New_JOBNO_SBNO("Select_EGM_CONSOLIDATE_DETAILS_SB_Search", txt_SBNo.Text, "", txt_SBNo.Text);
        txt_SBNo.Focus();
    }

    protected void btn_Rotation_Update_Click(object sender, EventArgs e)
    {
        i = Insert_Update("U", "Update_Rotation_All", Convert.ToInt32(hdn_SB_SlNo.Value));

        Alert_msg("Update Successfully", "btnUpdate");
        btnUpdate.Visible = true;
        btnDelete.Visible = true;
        btnSave.Visible = false;
        Update_Grid = "Update_Grid";
        Bind_Type = "Rotation";
        Bind_EGM_Details();
    }



    protected void btn_upload_Click(object sender, EventArgs e)
    {
        try
        {
            //txt_RotationNo.Text = "ffgfgf";
            //txt_JobNo.Text = "12";

            if (File.Exists(errorFolder + logFileName))
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                Read_Flatfile();
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(errorFolder);
                dir.Create();
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                Read_Flatfile();
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public void Read_Flatfile()
    {
        if (txt_RotationNo.Text != "" & txt_RotationDate.Text != "")
        {
            if (txt_Voyage_No.Text != "")
            {
                int counter = 0;
                int main_count = 1;

                string line;
                string lineNames = "";

                DateTime date = new DateTime();

                string path = errorFolder + "\\" + fileuploadExcel.FileName;
                int EGM_Max_ID = Get_MAXID("Get_EGM_MAXID");
                int EGM_Container_Max_ID = Get_MAXID("Get_EGM_Container_MAXID");
                int EGM_SBSLNO = Get_MAXID("Get_EGM_MAX_SLNO");


                Call_Datatable();

                if (fileuploadExcel.HasFile)
                {
                    addtoGallery1(fileuploadExcel.FileName, errorFolder, "NORMAL");
                }

                System.IO.StreamReader file = new System.IO.StreamReader(path);
                string[] sp0 = { "" };

                while ((line = file.ReadLine()) != null)
                {
                    if (line == "<TABLE>SB")
                    {
                        lineNames = "SB";
                    }
                    if (lineNames == "SB")
                    {
                        if (line != "<TABLE>SB")
                        {
                            sp0 = line.Split('');

                            if (sp0[4] != "" || txt_SBNo.Text != "")
                            {
                                if (sp0[5] != "" || txt_SBDate.Text != "")
                                {
                                    if (sp0[3].Contains('/'))
                                    {
                                    }
                                    else
                                    {
                                        string str1 = sp0[3].Substring(0, 4);
                                        string str2 = sp0[3].Substring(4, 2);
                                        string str3 = sp0[3].Substring(6, 2);

                                        sp0[3] = str3 + "/" + str2 + "/" + str1;
                                    }

                                    if (sp0[5].Contains('/'))
                                    {
                                    }
                                    else
                                    {
                                        if (sp0[5] != "")
                                        {
                                            string str1 = sp0[5].Substring(0, 4);
                                            string str2 = sp0[5].Substring(4, 2);
                                            string str3 = sp0[5].Substring(6, 2);

                                            sp0[5] = str3 + "/" + str2 + "/" + str1;
                                        }
                                        else
                                        {
                                            if (txt_SBDate.Text != "")
                                            {
                                            }
                                            else
                                            {
                                                sp0[5] = "01/01/1900";
                                            }
                                        }
                                    }
                                    /* placed to add Item desc column
                                    //dt_main.Rows.Add(EGM_Max_ID, txt_EGM_Jobno.Text, sp0[2], sp0[3] == string.Empty ? "01/01/1900" : sp0[3], txt_RotationNo.Text, txt_RotationDate.Text == string.Empty ? "01/01/1900" : txt_RotationDate.Text, txt_LinerName.Text, txt_Vessel_Name.Text, txt_IMO_No.Text, txt_Voyage_No.Text, sp0[4] == string.Empty ? txt_SBNo.Text : sp0[4], sp0[5] == string.Empty ? txt_SBDate.Text : sp0[5]
                                    //    , sp0[29], sp0[30], sp0[29], sp0[35], sp0[36], sp0[38], sp0[39], sp0[9], sp0[10], sp0[11], sp0[12], sp0[13], sp0[20], sp0[21], sp0[22], sp0[23], sp0[24]
                                    //    , Connection.Current_User(), DateTime.Now.ToString(), "S", Connection.Current_Branch(), Connection.WorkingPeriod(), EGM_SBSLNO, sp0[7], sp0[8], txt_Description.Text, txt_eMailID.Text);

                                    //admin.SqlBulk_Upload_Product("EGM_CONSOLIDATE_DETAILS", dt_main, comp_ConnectionStr);
                                    //HdnUpdate_id.Value = Convert.ToString(EGM_Max_ID);
                                     */
                                    lineNames = "";
                                }
                                else
                                {
                                    Alert_msg("Enter SB-Date - Mandatory");
                                    break;

                                }
                            }
                            else
                            {
                                Alert_msg("Enter SB-No - Mandatory");
                                break;
                            }
                        }
                    }


                    if (line == "<TABLE>ITEM")
                    {
                        lineNames = "Item";
                    }

                    if (lineNames == "Item")
                    {
                        if (line != "<TABLE>ITEM")
                        {
                            string[] sp2 = line.Split('');

                            string Item_Desc = sp2[10] + sp2[11] + sp2[12];

                            /* ITS LOCAL CODE - ADvanced work
                            dt_main.Rows.Add(EGM_Max_ID, txt_EGM_Jobno.Text, sp0[2], sp0[3] == string.Empty ? "01/01/1900" : sp0[3], txt_RotationNo.Text, txt_RotationDate.Text == string.Empty ? "01/01/1900" : txt_RotationDate.Text, txt_LinerName.Text, txt_Vessel_Name.Text, txt_IMO_No.Text, txt_Voyage_No.Text, sp0[4] == string.Empty ? txt_SBNo.Text : sp0[4], sp0[5] == string.Empty ? txt_SBDate.Text : sp0[5]
                                       , sp0[29], sp0[30], sp0[29], sp0[35], sp0[36], sp0[38], sp0[39], sp0[9], sp0[10], sp0[11], sp0[12], sp0[13], sp0[20], sp0[21], sp0[22], sp0[23], sp0[24]
                                       , Connection.Current_User(), DateTime.Now.ToString(), "S", Connection.Current_Branch(), Connection.WorkingPeriod(), EGM_SBSLNO, sp0[7], sp0[8], Item_Desc, txt_eMailID.Text);
                            */

                            dt_main.Rows.Add(EGM_Max_ID, txt_EGM_Jobno.Text, sp0[2], sp0[3] == string.Empty ? "01/01/1900" : sp0[3], txt_RotationNo.Text, txt_RotationDate.Text == string.Empty ? "01/01/1900" : txt_RotationDate.Text, txt_LinerName.Text, txt_Vessel_Name.Text, txt_IMO_No.Text, txt_Voyage_No.Text, sp0[4] == string.Empty ? txt_SBNo.Text : sp0[4], sp0[5] == string.Empty ? txt_SBDate.Text : sp0[5]
                                     , sp0[29], sp0[30], sp0[29], sp0[35], sp0[36], sp0[38], sp0[39], sp0[9], sp0[10], sp0[11], sp0[12], sp0[13], sp0[20], sp0[21], sp0[22], sp0[23], sp0[24]
                                     , Connection.Current_User(), DateTime.Now.ToString(), "S", Connection.Current_Branch(), Connection.WorkingPeriod(), EGM_SBSLNO);


                            admin.SqlBulk_Upload_Product("EGM_CONSOLIDATE_DETAILS", dt_main, comp_ConnectionStr);
                            HdnUpdate_id.Value = Convert.ToString(EGM_Max_ID);

                            lineNames = "";
                        }
                    }

                    if (line == "<TABLE>CONTAINER")
                    {
                        lineNames = "Container";
                    }
                    if (lineNames == "Container")
                    {
                        if (line != "<TABLE>CONTAINER")
                        {
                            if (line != "<TABLE>STR" && line != "<END-SB>")
                            {
                                string[] sp1 = line.Split('');

                                dt_cont.Rows.Add(EGM_Container_Max_ID, txt_EGM_Jobno.Text, sp1[2], sp0[4] == string.Empty ? txt_SBNo.Text : sp0[4], EGM_SBSLNO, sp1[4], sp1[5], "F", Connection.Current_User(), DateTime.Now.ToString(), "S", Connection.Current_Branch(), Connection.WorkingPeriod(), txt_RotationNo.Text);
                                EGM_Container_Max_ID++;
                            }
                            else
                            {
                                admin.SqlBulk_Upload_Product("EGM_CONSOLIDATE_CONTAINER_DETAILS", dt_cont, comp_ConnectionStr);
                                lineNames = "";
                                //HdnUpdate_id.Value = Convert.ToString(EGM_Max_ID);
                                //Bind_Type = "Rotation";
                                //Update_Grid = "Update_Grid";
                                //Bind_EGM_Details();
                                //Clear();
                                //break;
                            }
                        }
                    }

                    if (line == "<END-SB>")
                    {
                        HdnUpdate_id.Value = Convert.ToString(EGM_Max_ID);
                        //Bind_Type = "Rotation";
                        Bind_Type = "";
                        Update_Grid = "Update_Grid";
                        Bind_EGM_Details();
                        gv_details_Grid_Bind();
                        //Clear();
                        break;
                    }
                }
                file.Close();
            }
            else
            {
                Alert_msg("Enter Voyage No!!");
                txt_Voyage_No.Focus();
            }
        }
        else
        {
            Alert_msg("Rotation Details Missing!!");
        }
    }

    public void Call_Datatable()
    {
        dt_main.Columns.Add("EGM_ID");
        dt_main.Columns.Add("EGM_JOBNO");
        dt_main.Columns.Add("JOBNO");
        dt_main.Columns.Add("JOBDATE");
        dt_main.Columns.Add("ROTATION_NO");
        dt_main.Columns.Add("ROTATION_DATE");
        dt_main.Columns.Add("LINER_NAME");
        dt_main.Columns.Add("VESSEL_NAME");
        dt_main.Columns.Add("IMO_NO");
        dt_main.Columns.Add("VOYAGE_NO");
        dt_main.Columns.Add("SBNO");
        dt_main.Columns.Add("SB_DATE");
        dt_main.Columns.Add("PORT_ORIGIN");
        dt_main.Columns.Add("DESTINATION_PORT");
        dt_main.Columns.Add("GATEWAY_PORT");
        dt_main.Columns.Add("NATURE_OF_CARGO");
        dt_main.Columns.Add("QUATITY");
        dt_main.Columns.Add("UNIT_QTY");
        dt_main.Columns.Add("NO_OF_PKGS");
        dt_main.Columns.Add("EXPORTER_NAME");
        dt_main.Columns.Add("EXPORTER_ADD1");
        dt_main.Columns.Add("EXPORTER_ADD2");
        dt_main.Columns.Add("EXPORTER_ADD3");
        dt_main.Columns.Add("EXPORTER_ADD4");
        dt_main.Columns.Add("CONSIGNEE_NAME");
        dt_main.Columns.Add("CONSIGNEE_ADD1");
        dt_main.Columns.Add("CONSIGNEE_ADD2");
        dt_main.Columns.Add("CONSIGNEE_ADD3");
        dt_main.Columns.Add("CONSIGNEE_ADD4");
        dt_main.Columns.Add("USERID");
        dt_main.Columns.Add("LOGIN_DATE");
        dt_main.Columns.Add("STATUS");
        dt_main.Columns.Add("BRANCHCODE");
        dt_main.Columns.Add("WORKINGPERIOD");
        dt_main.Columns.Add("SB_SLNO");
        //dt_main.Columns.Add("EXPORTER_IECNO");
        //dt_main.Columns.Add("BRSL_NO");
        //dt_main.Columns.Add("DESCRIPTION");
        //dt_main.Columns.Add("EMAIL_ID");

        dt_cont.Columns.Add("EGM_CONID");
        dt_cont.Columns.Add("EGM_JOBNO");
        dt_cont.Columns.Add("JOBNO");
        dt_cont.Columns.Add("SBNO");
        dt_cont.Columns.Add("SLNO");
        dt_cont.Columns.Add("CONTAINER_NO");
        dt_cont.Columns.Add("SIZE");
        dt_cont.Columns.Add("TYPE");
        dt_cont.Columns.Add("USERID");
        dt_cont.Columns.Add("LOGIN_DATE");
        dt_cont.Columns.Add("STATUS");
        dt_cont.Columns.Add("BRANCHCODE");
        dt_cont.Columns.Add("WORKINGPERIOD");
        dt_cont.Columns.Add("ROTATION_NO");
    }

    public void addtoGallery1(string picName, string folderName, string Excel_Name)
    {
        string strFolderPath;
        string strImagePath;
        try
        {
            strFolderPath = Path.Combine(Request.PhysicalApplicationPath, folderName);
            strImagePath = Path.Combine(strFolderPath, picName);

            if (Excel_Name == "INDEV")
            {
                //fileuploadExcel1.SaveAs(strImagePath);
            }
            else
            {
                fileuploadExcel.SaveAs(strImagePath);
            }

        }
        catch
        {
        }
        finally
        {
        }
    }
}
 