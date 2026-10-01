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
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
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

        CHA_NO = Session["CHA_NO"].ToString();
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
          
            if (Request.QueryString["Page"] == "New")
            {                           
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = true;
                Get_Except_JobNo();
                Bind_EGM_Details();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    hdn_Jobno.Value = txt_JobNo.Text;
                                
                    HdnUpdate_id.Value = Request.QueryString["Page"].ToString();
                    hdn_SB_SlNo.Value = "1";
                    Bind_EGM_Details();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                }
            }           
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

    public void Get_Except_JobNo()
    {
       
        EGM.JOBNO = "";
        EGM.WORKINGPERIOD = SELECT_BRANCH;
        EGM.Ename = "Get_Except_JobNo";
        ds = EGM.EGM_Select_All();

        ddlJobNo.DataSource = ds;
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();

        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select"); 
    }

  

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
           
                DataTable dtt = new DataTable();
                DataRow dr;
                dtt.Columns.Add(new System.Data.DataColumn("EGM_CONID", typeof(int)));
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
                        dr[1] = hdn_Jobno.Value;
                        dr[2] = txt_SBNo.Text;
                        dr[3] = hdn_SB_SlNo.Value;
                        dr[4] = txtContainerNo.Text;
                        dr[5] = ddl_size.SelectedValue;
                        dr[6] = ddl_Type.SelectedValue;
                        dr[7] = Connection.Current_User();
                        dr[8] = Session["LoginDate"].ToString();
                        dr[9] = "S";
                        dr[10] = Connection.Current_Branch();
                        dr[11] = Connection.WorkingPeriod();

                        dtt.Rows.Add(dr);
                        x = x + 1;
                        MAX_ID = MAX_ID + 1;
                    }
                }

                if (dtt.Rows.Count > 0)
                {
                    Delete_Container();
                    AdminMasterDetails adm = new AdminMasterDetails();
                    adm.SqlBulk_Upload_Product("EGM_CONTAINER_DETAILS", dtt, Session["currentcomp_db"].ToString());
                }

                //DataSet dsData = new DataSet();
                //dsData.Tables.Add(dtt);

                //// Get the XML format of the data set.
                //String xmlData = ConvertDataTableToXML(dsData.Tables[0]);

                i = Insert_Update("U", "U",Convert.ToInt32(hdn_SB_SlNo.Value));

                Alert_msg("Update Successfully", "btnUpdate");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;

                Bind_EGM_Details();
            
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
            hdn_Jobno.Value = ddlJobNo.SelectedItem.Text;
            Bind_EGM_Details();
        }
        else
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
        }
    }

    public void Bind_EGM_Details()
    {
        try
        {
            DataTable dt_item = new DataTable();

            if (Request.QueryString["Page"] == "New")
            {
                //EGM.JOBNO = ddlJobNo.SelectedItem.ToString();
                EGM.JOBNO = hdn_Jobno.Value;
                EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value == string.Empty ? 0 : Convert.ToInt32(hdn_SB_SlNo.Value));
                EGM.Ename = "Select_All_Details";
            }
            else
            {
                //EGM.EGM_ID = Request.QueryString["Page"].ToString();
                EGM.EGM_ID = HdnUpdate_id.Value;
                EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value);
                EGM.Ename = "select_EGM_Details_Grid";
            }
            EGM.WORKINGPERIOD = SELECT_BRANCH;
            ds = EGM.EGM_Select_All();
            int i = EGM.result;
            HD_Type.Value = i.ToString();

           
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (i == 1)
                {
                    hdn_Jobno.Value = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                    txt_Job_Date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();

                    txt_Exporter_Name.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    //txtAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txt_ExporterAddress1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txt_ExporterAddress2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txt_ExporterAddress3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    txt_ExporterAddress4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString();

                    txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    txtConsignee_Address1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                    txtConsignee_Address2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                    txtConsignee_Address3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                    txtConsignee_Address4.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();

                    txt_SBNo.Text = ds.Tables[0].Rows[0]["SB_NO"].ToString();
                    txt_SBDate.Text = ds.Tables[0].Rows[0]["SB_DATE"].ToString();

                    //txt_Port_of_Origin.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                    txt_Destination_Port.Text = ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString();
                    txt_GatewayPort.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    txt_Port_of_Origin.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        ddl_Nature_of_Cargo.SelectedValue = ds.Tables[2].Rows[0]["ANNEX_AIR_NATURE_OF_CARGO"].ToString();
                        txt_No_of_Packages.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString();
                        txt_Quantity.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString();
                        txt_Unit.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString();
                        txt_RotationNo.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString();
                        if (ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString() != "")
                        {
                            txt_RotationDate.Text = ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString();
                        }
                    }
                    else
                    {
                        DateTime dateTime = DateTime.UtcNow.Date;
                        txt_RotationDate.Text = dateTime.ToString("dd/MM/yyyy");
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        ddl_Nature_of_Cargo.SelectedValue = ds.Tables[3].Rows[0]["ANNEX_SEA_NATURE_OF_CARGO"].ToString();
                        txt_No_of_Packages.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString();
                        txt_Unit.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString();
                        txt_Quantity.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString();
                        txt_RotationNo.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_NO"].ToString();
                        if (ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString().Replace("01/01/1900", "") != "")
                        {
                            txt_RotationDate.Text = ds.Tables[3].Rows[0]["ANNEX_SEA_ROTATION_DATE"].ToString();
                        }
                        else
                        {
                            DateTime dateTime = DateTime.UtcNow.Date;
                            txt_RotationDate.Text = dateTime.ToString("dd/MM/yyyy");
                        }
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataTable firstTable = ds.Tables[1];
                        ViewState["CurrentTable"] = firstTable;

                        gvAll.DataSource = ds.Tables[1];
                        gvAll.DataBind();
                    }
                    else
                    {
                        SetInitialRow();
                    }

                    gv_ItemDetails.DataSource = dt_item;
                    gv_ItemDetails.DataBind();

                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;

                }
                else if (i == 2)
                {
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    txt_JobNo.Visible = true;
                    //txt_FileRefNo.Visible = true;
                    ddlJobNo.Visible = false;

                    HD_Update_id.Value = ds.Tables[0].Rows[0]["EGM_ID"].ToString();
                    //ddlJobNo.SelectedValue = ds.Tables[0].Rows[0]["JOBNO"].ToString();

                    txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                    hdn_Jobno.Value = txt_JobNo.Text;
                    txt_Job_Date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
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

                    txt_Exporter_Name.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    txt_ExporterAddress1.Text = ds.Tables[0].Rows[0]["EXPORTER_ADD1"].ToString();
                    txt_ExporterAddress2.Text = ds.Tables[0].Rows[0]["EXPORTER_ADD2"].ToString();
                    txt_ExporterAddress3.Text = ds.Tables[0].Rows[0]["EXPORTER_ADD3"].ToString();
                    txt_ExporterAddress4.Text = ds.Tables[0].Rows[0]["EXPORTER_ADD4"].ToString();

                    txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();
                    txtConsignee_Address1.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString();
                    txtConsignee_Address2.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString();
                    txtConsignee_Address3.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString();
                    txtConsignee_Address4.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString();

                    hdn_SB_SlNo.Value = ds.Tables[0].Rows[0]["SB_SLNO"].ToString();
                  
                    if (EGM.Ename == "Select_All_Details")
                    {
                        DataTable SecondTable = ds.Tables[1];
                        ViewState["CurrentTable"] = SecondTable;

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            gv_ItemDetails.DataSource = ds.Tables[0];
                            gv_ItemDetails.DataBind();
                        }

                        gvAll.DataSource = ds.Tables[1];
                        gvAll.DataBind();
                        SetPreviousData();
                    }
                    else
                    {
                        EGM.JOBNO = txt_JobNo.Text;
                        EGM.Ename = "Select_All_Details";
                        EGM.WORKINGPERIOD = SELECT_BRANCH;
                        EGM.SB_SLNO = Convert.ToInt32(hdn_SB_SlNo.Value);
                        dss = EGM.EGM_Select_All();

                        DataTable SecondTable = dss.Tables[1];
                        ViewState["CurrentTable"] = SecondTable;

                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            gv_ItemDetails.DataSource = dss.Tables[0];
                            gv_ItemDetails.DataBind();
                        }

                        if (dss.Tables[1].Rows.Count > 0)
                        {
                            gvAll.DataSource = dss.Tables[1];
                            gvAll.DataBind();
                            SetPreviousData();
                        }
                        else
                        {
                            SetInitialRow();
                        }
                    }

                    //DataTable SecondTable = ds.Tables[1];
                    //ViewState["CurrentTable"] = SecondTable;

                    //if (ds.Tables[1].Rows.Count > 0)
                    //{
                    //    gvAll.DataSource = ds.Tables[1];
                    //    gvAll.DataBind();
                    //    SetPreviousData();
                    //}
                    //else
                    //{
                    //    SetInitialRow();
                    //}

                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                }
            }
            else
            {
                SetInitialRow();
                gv_ItemDetails.DataSource = dt_item;
                gv_ItemDetails.DataBind();
            }

        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog(ex.Message);
        }
    }

    public int Insert_Update(string a1, string a2,int MAX_SLNO)
    {
            //BL_Gen.JOBNO=ddlJobNo.SelectedItem.Text;

            EGM.JOBNO = txt_JobNo.Text;

            EGM.JOBNO = hdn_Jobno.Value;
            EGM.JOBDATE = txt_Job_Date.Text;
            EGM.ROTATION_NO = txt_RotationNo.Text;
            EGM.ROTATION_DATE = txt_RotationDate.Text;

            EGM.LINER_NAME = txt_LinerName.Text;
            EGM.VESSEL_NAME = txt_Vessel_Name.Text;
            EGM.IMO_NO = txt_IMO_No.Text;
            EGM.VOYAGE_NO = txt_Voyage_No.Text;

            EGM.EXPORTER_NAME = txt_Exporter_Name.Text;
            EGM.EXPORTER_ADD1 = txt_ExporterAddress1.Text;
            EGM.EXPORTER_ADD2 = txt_ExporterAddress2.Text;
            EGM.EXPORTER_ADD3 = txt_ExporterAddress3.Text;
            EGM.EXPORTER_ADD4 = txt_ExporterAddress4.Text;

            EGM.SBNO = txt_SBNo.Text;
            EGM.SB_DATE = txt_SBDate.Text;
            EGM.PORT_ORIGIN = txt_Port_of_Origin.Text;
            EGM.DESTINATION_PORT = txt_Destination_Port.Text;
            EGM.GATEWAY_PORT = txt_GatewayPort.Text;
            EGM.NATURE_OF_CARGO = ddl_Nature_of_Cargo.SelectedValue;

            EGM.CONSIGNEE_NAME = txtConsignee.Text;
            EGM.CONSIGNEE_ADD1 = txtConsignee_Address1.Text;
            EGM.CONSIGNEE_ADD2 = txtConsignee_Address2.Text;
            EGM.CONSIGNEE_ADD3 = txtConsignee_Address3.Text;
            EGM.CONSIGNEE_ADD4 = txtConsignee_Address4.Text;

            EGM.QUATITY = txt_Quantity.Text;
            EGM.UNIT_QTY = txt_Unit.Text;
            EGM.NO_OF_PKGS = txt_No_of_Packages.Text;

            EGM.flag = a2;

            EGM.USERID = currentuser;
            EGM.STATUS = a2;
            EGM.BRANCHCODE = SELECT_BRANCH;
            EGM.WORKINGPERIOD = Working_Period;
            EGM.SB_SLNO = MAX_SLNO;

            EGM.UPD_ID = HD_Update_id.Value;  
            EGM.EGM_Insert_Update();
            i = EGM.result;

        return i;      
    }

  
    protected void btnNew_Click(object sender, EventArgs e)
    {
        txt_SBNo.Text = "";
        txt_SBDate.Text = "";
        txt_GatewayPort.Text = "";
        txt_Port_of_Origin.Text = "";
        txt_Destination_Port.Text = "";
        txt_Quantity.Text = "";
        txt_Unit.Text = "";
        txt_No_of_Packages.Text = "";
        txt_Loose_Packets.Text = "";
       
        btnUpdate.Visible = false;
        btnDelete.Visible = false;

        btnSave.Visible = true;
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

                    //dtCurrentTable.Rows[i - 1]["ddl_size"] = ddl_size.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["ddl_Type"] = ddl_Type.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["no_pkg"] = txtno_pkg.Text;

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
                        //ddl_size.SelectedValue = dt.Rows[i]["SIZE"].ToString();
                        //ddl_Type.SelectedValue = dt.Rows[i]["TYPE"].ToString();

                        //ddl_size.SelectedValue = dt.Rows[i]["ddl_size"].ToString();
                        //ddl_Type.SelectedValue = dt.Rows[i]["ddl_Type"].ToString();

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
                    //dtCurrentTable.Rows[i - 1]["gross_wgt"] = txtgross_wgt.Text;

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
            //if (ddlJobNo.SelectedItem.Text != "Select")
            //{
                
                DataTable dtt = new DataTable();
                DataRow dr;
                dtt.Columns.Add(new System.Data.DataColumn("EGM_CONID", typeof(int)));
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

                int x = 1;
                int MAX_ID = Get_MAXID("Get_EGM_Container_MAXID");
                int Max_SlNo = Get_MAXID("Get_EGM_MAX_SLNO");
               
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
                        dr[1] = hdn_Jobno.Value;
                        dr[2] = txt_SBNo.Text;
                        dr[3] = Max_SlNo;
                        dr[4] = txtContainerNo.Text;
                        dr[5] = ddl_size.SelectedValue;
                        dr[6] = ddl_Type.SelectedValue;
                        dr[7] = Connection.Current_User();
                        dr[8] = Session["LoginDate"].ToString();
                        dr[9] = "S";
                        dr[10] = Connection.Current_Branch();
                        dr[11] = Connection.WorkingPeriod();
                     
                        dtt.Rows.Add(dr);
                        x = x + 1;
                        MAX_ID = MAX_ID + 1;
                    }
                }

                if (dtt.Rows.Count > 0)
                {
                    AdminMasterDetails adm = new AdminMasterDetails();
                    adm.SqlBulk_Upload_Product("EGM_CONTAINER_DETAILS", dtt, Session["currentcomp_db"].ToString());
                }

                DataSet dsData = new DataSet();
                dsData.Tables.Add(dtt);

                // Get the XML format of the data set.
                //String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
                //hdn_Jobno.Value = ddlJobNo.SelectedItem.Text;
               

                //hdn_Jobno.Value = ViewState["hdn_fileRef_Jobno"].ToString();
                //Hdn_FILEREFNO.Value = ddlJobNo.SelectedItem.Text;

                //int Max_SlNo = Get_MAXID("Get_EGM_MAX_SLNO");

                i = Insert_Update("N", "S", Max_SlNo);

                int update_id = EGM.UpdateId;

                HD_Update_id.Value = Convert.ToString(update_id);
                HdnUpdate_id.Value = Convert.ToString(update_id);
                ViewState["UPDATE_ID"] = update_id;
                hdn_SB_SlNo.Value = Convert.ToString(Max_SlNo);
                EGM.Ename = "Select_All_Details";
               
                //Check_JobNo();

                Alert_msg("Saved Successfully", "btnSave");
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                
                Bind_EGM_Details();
          
        }
        
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public int Get_MAXID(string Flag)
    {
        int MAX_ID = 0;
        DataSet dt_max = new DataSet();
        EGM.JOBNO = hdn_Jobno.Value;
        EGM.WORKINGPERIOD = SELECT_BRANCH;
        EGM.Ename = Flag;

        dt_max = EGM.EGM_Select_All();

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

    protected void BtnAddAnnex_Click(object sender, EventArgs e)
    {
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
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

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            DataSet dt_max = new DataSet();
            EGM.JOBNO = hdn_Jobno.Value;
            EGM.WORKINGPERIOD = SELECT_BRANCH;
            EGM.EGM_ID =hdn_SB_SlNo.Value;
            EGM.Ename = "delete";

            dt_max = EGM.EGM_Select_All();

            i = EGM.result;

            if (i == 1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Record Deleted', 'EGM', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
               
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

    public void Delete_Container()
    {
        DataSet dt_max = new DataSet();
        EGM.JOBNO = hdn_Jobno.Value;
        EGM.WORKINGPERIOD = SELECT_BRANCH;
        EGM.EGM_ID = hdn_SB_SlNo.Value;
        EGM.Ename = "delete_Container";

        dt_max = EGM.EGM_Select_All();
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
            string EGM_ID = Convert.ToString(this.gv_ItemDetails.SelectedDataKey.Value);
            string SB_SLNO = Convert.ToString(this.gv_ItemDetails.SelectedDataKey.Values[1]);

            HdnUpdate_id.Value = EGM_ID;
            hdn_SB_SlNo.Value = SB_SLNO;
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
}
 