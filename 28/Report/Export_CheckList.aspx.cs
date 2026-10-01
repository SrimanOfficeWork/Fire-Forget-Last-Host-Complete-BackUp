using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Text;


public partial class Transaction_Default2 : ThemeClass
{
    public string SELECT_TYPE, SELECT_BRANCH;

    AppSession aps = new AppSession();
    Export_CheckList CHKLIST = new Export_CheckList();
    adminmaster adm = new adminmaster();
    DataSet ds_RITC = new DataSet();
    DataSet ds_jobno = new DataSet();
    ErrorLogs er = new ErrorLogs();
    string grid_status = "";
    public string COMPANY_ID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession_Subfolder();
            SELECT_BRANCH = Connection.Get_Company_Type();
            COMPANY_ID = Connection.COMPANYID();
            ddlJobNo.Focus();
            //hdn_source.Value = "";

            if (!IsPostBack)
            {
                ddlJobNo.Attributes.Add("onchange", "javascript:CallServerside_Importer('" + ddlJobNo.ClientID + "', '" + txtCustomHouse.ClientID + "')");
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {
                    /*hide for Dashboard changes - sidebar & innerbox_Main_Top_User controls removed on 24-08-2026*/
                    //System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                    //currdiv.Style.Add("display", "none");

                    //System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                    //currdiv1.Style.Add("display", "none");

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                    currdiv2.Style.Add("margin", "-16px 2px 0 0");
                    currdiv2.Style.Add("padding", "2px 0 0");

                    ddlJobNo.Items.Clear();
                    ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                    ddlJobNo.SelectedIndex = 0;

                    Export_Default_Entry.Post_Data(ddlJobNo.SelectedValue.ToString(), "RODTEP");
                    Load_INV_Item_Value_Chk();


                    string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
                   ? Session["Theme"].ToString().ToLower()
                  : "orange";

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "setTheme",
                    "var PAGE_THEME = '" + theme + "';",
                     true);

                    Check_Duplicate_Invoice_OnLoad();
                   
                }
                else
                {
                    Export_CheckList CHKLIST = new Export_CheckList();
                    CHKLIST.JOBNo = "";
                    CHKLIST.Ename = "select_jobno";
                    CHKLIST.Workingperiod = SELECT_BRANCH;
                    ddlJobNo.DataSource = CHKLIST.RetrieveAll_General_Details();
                    ddlJobNo.DataValueField = "JOBNO";
                    ddlJobNo.DataTextField = "JOBNO_PS";
                    ddlJobNo.DataBind();
                    ddlJobNo.Items.Remove("0");
                    ddlJobNo.Items.Insert(0, "Select");

                }
                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtExporterName.Attributes.Add("readonly", "readonly");
                txtScheme.Attributes.Add("readonly", "readonly");
                txtConsignee.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        //---------set IGST CALC BASED ON FOB (OR) VALUE ----------------
        /*
        if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "4" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "140" || Connection.COMPANYID() == "184" || Connection.COMPANYID() == "197" || Connection.COMPANYID() == "232" || Connection.COMPANYID() == "335" || Connection.COMPANYID() == "441" || Connection.COMPANYID() == "460" || Connection.COMPANYID() == "522" || Connection.COMPANYID() == "555" || Connection.COMPANYID() == "571" || Connection.COMPANYID() == "574" || Connection.COMPANYID() == "623" || Connection.COMPANYID() == "689" || Connection.COMPANYID() == "704" || Connection.COMPANYID() == "775" || Connection.COMPANYID() == "778" || Connection.COMPANYID() == "810" || Connection.COMPANYID() == "894" || Connection.COMPANYID() == "912" || Connection.COMPANYID() == "926" || Connection.COMPANYID() == "1135" || Connection.COMPANYID() == "1159" || Connection.COMPANYID() == "1223" || Connection.COMPANYID() == "1229" || Connection.COMPANYID() == "1268")
        {
            IGST_FOB_VALUE_Y_N.Visible = true;
            hdn_IGST_Calc.Value = "T";
        }
        else
        {
            hdn_IGST_Calc.Value = "F";
        }
        
        if (Connection.COMPANYID() == "1572" && Connection.Current_User().ToUpper() == "PRABAKAR")
        {
            IGST_FOB_VALUE_Y_N.Visible = true;
            hdn_IGST_Calc.Value = "T";
        }
        */

        if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "2145" || COMPANY_ID == "2868" || COMPANY_ID == "2935")
        {
            btnXmlChecklist.Visible = true;
        }

        if (COMPANY_ID == "576" || COMPANY_ID == "3267")
        {
            Export_CSV.Visible = true;

        }

        if (Connection.Get_User_Exp_Settings_Job_Edit("CHKLIST_IGST_BASED_ON_FOB_VALUE") == "E")
        {
            IGST_FOB_VALUE_Y_N.Visible = true;
            hdn_IGST_Calc.Value = "T";
        }
        else
        {
            hdn_IGST_Calc.Value = "F";
        }

        BIND_INVALID_RITC();
        //BIND_INVALID_DBK_SLNO();
        //  Load_INV_Item_Value_Chk();

        if (Session["Inv_Item"] != null && Session["Inv_Item"] != string.Empty)
        {
            string Inv_item = string.Empty;
            string[] arr = new string[] { };

            Inv_item = Session["Inv_Item"].ToString();
            arr = Inv_item.Split('~');

            txtCustomHouse.Text = arr[0];
            txtExporterName.Text = arr[2];
            txtScheme.Text = arr[4];
            txtConsignee.Text = arr[6];
            txtNoofItems.Text = arr[8];
            txtNoofInvoices.Text = arr[10];

            Session.Remove("Inv_Item");
        }
        if (!IsPostBack)
        {
            if (ddlJobNo.SelectedItem.ToString() != "Select")
            {
                try
                {
                    if (Connection.e_lOGIX_CHENNAI() != string.Empty)
                    {
                        /* UserBO ObjUBO = new UserBO();
                        E_LOGIX ES = new E_LOGIX();

                        DataSet dss = new DataSet();
                        ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
                        ObjUBO.Ename = "S";
                        ObjUBO.flag = "Data_Sent_Update";
                        ObjUBO.File_Type = "E";
                        dss = ES.Select_IMP_EXP_INVO_SYS(ObjUBO);
                        if (dss.Tables.Count > 0)
                        {
                            IMPL_CHENNAI.ELogiX obj = new IMPL_CHENNAI.ELogiX();
                            DataSet E_ds = new DataSet();
                            E_ds = obj.ELogiXExportData(dss);

                            if (E_ds.Tables[0].Rows.Count > 0)
                            {
                                ObjUBO.JOBNO = E_ds.Tables[0].Rows[0]["JOBNO"].ToString();
                                ObjUBO.Ename = E_ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                                ObjUBO.flag = "File_Refno_Update";
                                ObjUBO.File_Type = "E";
                                ES.Select_IMP_EXP_INVO_SYS(ObjUBO);
                            }
                        }*/
                    }
                    else
                    {
                        Chk_Elogix_Service();
                    }

                    Connection.I_Fact(ddlJobNo.SelectedValue.ToString(), "E");
                    Connection.Ryal_Data(ddlJobNo.SelectedValue.ToString(), "E");
                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        DataSet dss = new DataSet();
                        if (COMPANY_ID == "816" || COMPANY_ID == "861" || COMPANY_ID == "880" || COMPANY_ID == "1317" || COMPANY_ID == "1339" || COMPANY_ID == "3149" || COMPANY_ID == "3266")
                        {
                            Div_ICode.Visible = true;
                        }
                    }


                    var excludedCompanies = new List<string> { "861", "3149", "3266" };

                    if (!excludedCompanies.Contains(COMPANY_ID))
                    {
                        CommonAPI.CommonAPI_basedonCompanies(COMPANY_ID, ddlJobNo.SelectedValue.ToString(), "E");
                    }
                    //Common Call to all apis
                    


                    
                }
                catch (Exception ex)
                {
                    Connection.Error_Msg(ex.Message);
                }
            }
        }


    }    
    
    private void Chk_Elogix_Service()
    {
        try
        {
            string E_Logix_Company_Id_Chennai = Connection.e_lOGIX_CHENNAI();
            string E_Logix_Company_Id_Mumbai = Connection.e_lOGIX_MUMBAI();

            if (E_Logix_Company_Id_Chennai != string.Empty || E_Logix_Company_Id_Mumbai != string.Empty)
            {
                UserBO ObjUBO = new UserBO();

                DataSet dds = new DataSet();
                Div_Elogix.Visible = true;

                txt_Eogix_Job.Attributes.Add("readonly", "readonly");
                txt_Eogix_Job.Style.Add("background-color", "#F0F0F0");

                txt_Eogix_Job.Text = ddlJobNo.SelectedItem.ToString();
                ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
                ObjUBO.File_Type = "E";
                ObjUBO.flag = "Sent_Data_Chk";

                if (E_Logix_Company_Id_Chennai != string.Empty)
                {
                    /*
                    E_LOGIX ES = new E_LOGIX();
                    dds = ES.Select_IMP_EXP_INVO_SYS(ObjUBO);
                    */
                }
                else if (E_Logix_Company_Id_Mumbai != string.Empty)
                {
                    E_LOGIX_MUMBAI ES = new E_LOGIX_MUMBAI();
                    ObjUBO.ITEM_ID = E_Logix_Company_Id_Mumbai;
                    dds = ES.Select_IMP_EXP(ObjUBO);
                }
                // dds = ES.Select_IMP_EXP(ObjUBO);

                if (dds.Tables[0].Rows.Count > 0)
                {
                    if (dds.Tables[0].Rows[0][0].ToString() == "N")
                    {
                        btn_Elogix.Visible = true;
                        btn_Elogix.Text = "Move To Elogix";
                    }
                    else if (dds.Tables[0].Rows[0][0].ToString() == "U")
                    {
                        btn_Elogix.Visible = true;
                        btn_Elogix.Text = "Update To Elogix";
                    }
                    else
                    {
                        btn_Elogix.Visible = false;
                        lbl_Msg.Text = "Sent : " + dds.Tables[0].Rows[0][0].ToString();
                    }
                }
            }
            else
            {
                Div_Elogix.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
    protected void gv_RITC_RowCreated(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
                e.Row.CssClass = "header";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
                e.Row.CssClass = "normal";
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
                e.Row.CssClass = "alternate";
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
    }
    protected void gv_RITC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            gv_RITC.PageIndex = e.NewPageIndex;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    public void BIND_INVALID_RITC()
    {
        try
        {
            CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
            CHKLIST.Ename = "BIND_ALL_INVALID_RITC_FROM_JOB";
            CHKLIST.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = CHKLIST.RetrieveAll_General_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
                Check_RITCNO(ds.Tables[0].Rows[0]["RITCNO"].ToString());
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void Check_RITCNO(string RITCNO)
    {
        try
        {
            adm.ERITC_ID = "";
            adm.ERITC_CODE = "";
            adm.ERITC_DESCRIPTION = RITCNO;
            adm.Ename = "Bind_Invalid_RITCCODE";
            ds_RITC = adm.RetrieveAll_Export_RITC__Master();

            if (ds_RITC.Tables[0].Rows.Count > 0)
            {

                CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                CHKLIST.Ename = "BIND_ALL_JOB_INV_ITEM_INVALID_RITC";
                CHKLIST.TRANSPORT_MODE = ds_RITC.Tables[0].Rows[0][0].ToString();
                CHKLIST.Workingperiod = SELECT_BRANCH;
                DataSet ds_result = new DataSet();
                ds_result = CHKLIST.RetrieveAll_General_Details();

                if (ds_result.Tables[0].Rows.Count > 0)
                {
                    lbl_heading.Visible = true;
                    gv_RITC.Visible = true;
                    gv_RITC.DataSource = ds_result.Tables[0];
                    gv_RITC.DataBind();
                    grid_status = "RITCNO";
                    lbl_heading.Text = "Check RITC in Item Page";
                }
            }
            else 
            {
                CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                CHKLIST.Ename = "BIND_ALL_JOB_INV_ITEM_INVALID_RODTEP";
                if (ds_RITC.Tables[1].Rows.Count > 0)
                {
                    CHKLIST.TRANSPORT_MODE = ds_RITC.Tables[1].Rows[0][0].ToString();
                }
                else
                {
                    CHKLIST.TRANSPORT_MODE = "";
                }
                CHKLIST.Workingperiod = SELECT_BRANCH;
                DataSet ds_result = new DataSet();
                ds_result = CHKLIST.RetrieveAll_General_Details();

                if (ds_result.Tables[0].Rows.Count > 0)
                {
                    lbl_heading.Visible = true;
                    gv_RITC.Visible = true;
                    gv_RITC.DataSource = ds_result.Tables[0];
                    gv_RITC.DataBind();
                    grid_status = "RITCNO";
                    lbl_heading.Text = "Check RODTEP in Item Page";
                }
                else
                {
                    if (ds_result.Tables[1].Rows.Count > 0)
                    {
                        lbl_heading.Visible = true;
                        gv_RITC.Visible = true;
                        gv_RITC.DataSource = ds_result.Tables[1];
                        gv_RITC.DataBind();
                        grid_status = "RITCNO";
                        lbl_heading.Text = "Check DRAWBACK in Item Page";
                    }
                    else if (ds_result.Tables[2].Rows.Count > 0)//License Expired msg
                    {
                        grid_status = "LICENSE";
                        gv_RITC.Columns[0].HeaderText = "License No";
                        gv_RITC.Columns[1].HeaderText = "Lic.Imp Item no";
                        gv_RITC.Columns[2].HeaderText = "Lic. Expired Date";
                        gv_RITC.Columns[1].HeaderStyle.Width = 7;
                        gv_RITC.Columns[1].ItemStyle.Width = 7;

                        gv_RITC.Columns[2].HeaderStyle.Width = 7;
                        gv_RITC.Columns[2].ItemStyle.Width = 7;


                        lbl_heading.Visible = true;
                        gv_RITC.Visible = true;
                        gv_RITC.DataSource = ds_result.Tables[2];
                        gv_RITC.DataBind();
                        lbl_heading.Text = "Check License Expired";

                    }
                    
                }

                if (ds_result.Tables[0].Rows.Count == 0)
                {
                    BIND_INVALID_DBK_SLNO();
                }
            }
          
        }
        catch (Exception ex)
        {
        }
    }

    public void BIND_INVALID_DBK_SLNO()
    {
        try
        {
            if (grid_status != "RITCNO")
            {
                CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                CHKLIST.Ename = "BIND_ALL_INVALID_DBKSLNO_FROM_JOB";
                CHKLIST.Workingperiod = SELECT_BRANCH;
                DataSet ds = new DataSet();
                ds = CHKLIST.RetrieveAll_General_Details();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Check_DBL_SLNO(ds.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void BIND_INVALID_RODTEP()
    {
        try
        {
            if (grid_status != "RITCNO")
            {
                CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                CHKLIST.Ename = "BIND_ALL_INVALID_DBKSLNO_FROM_JOB";
                CHKLIST.Workingperiod = SELECT_BRANCH;
                DataSet ds = new DataSet();
                ds = CHKLIST.RetrieveAll_General_Details();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Check_DBL_SLNO(ds.Tables[0].Rows[0]["DRAWBACK_SLNO"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void Check_DBL_SLNO(string DRAWBACK_SLNO)
    {
        try
        {
            adm.ERITC_ID = "";
            adm.ERITC_CODE = "";
            adm.ERITC_DESCRIPTION = DRAWBACK_SLNO;
            adm.Ename = "Bind_Invalid_DBK_SLNO";
            ds_RITC = adm.RetrieveAll_Export_RITC__Master();

            if (ds_RITC.Tables[0].Rows.Count > 0)
            {
                CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                CHKLIST.TRANSPORT_MODE = ds_RITC.Tables[0].Rows[0][0].ToString();
                CHKLIST.Ename = "BIND_ALL_JOB_INV_ITEM_INVALID_DBKSLNO";
                CHKLIST.Workingperiod = SELECT_BRANCH;

                ds_jobno = CHKLIST.RetrieveAll_General_Details();

                if (ds_jobno.Tables[0].Rows.Count > 0)
                {
                  
                    lbl_heading.Text = "Check Drawback Slno";
                    lbl_heading.Visible = true;

                    grid_status = "DBK";
                    gv_RITC.Visible = true;
                    gv_RITC.DataSource = ds_jobno.Tables[0];
                    gv_RITC.DataBind();
                }
            }         
        }
        catch (Exception ex)
        {
        }
    }


    protected void gv_RITC_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (grid_status != "RITCNO" && grid_status != "" && grid_status != "LICENSE")
                {
                    e.Row.Cells[0].Text = "Drawback Slno";
                }
                else if (grid_status == "LICENSE")
                {
                    e.Row.Cells[0].Text = "License No";
                }
                else
                {
                    e.Row.Cells[0].Text = "RITC No";
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }
    
    [System.Web.Services.WebMethod]
    public static string Get_Import_Details(string custid)
    {
        string txtCustomHouse = "", txtExporterName = "", txtScheme = "",txtConsignee = "", txtNoofItems = "", txtNoofInvoices = "", Annexure_Mode = "", STR_Code = "";
        try
        {
            DataSet ds = new DataSet();

            Export_CheckList CHKLIST = new Export_CheckList();
            CHKLIST.JOBNo = custid;
            CHKLIST.Ename = "select_jobno_CheckList";
            CHKLIST.Workingperiod = Connection.Get_Company_Type();
            ds = CHKLIST.RetrieveAll_General_Details();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtExporterName = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                txtConsignee = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtScheme = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txtNoofInvoices = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";
                    }
                    else
                    {
                        txtNoofInvoices = "";
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        txtNoofItems = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";
                    }
                    else
                    {
                        txtNoofItems = "";
                    }
                }
                else
                {
                    txtScheme = "";
                    txtNoofItems = "";
                    txtNoofInvoices = "";
                }
                Rpt_General_Details Export_General = new Rpt_General_Details();
                Export_General.Retrieve_GetGeneral(custid);
                Annexure_Mode =Convert.ToString(Export_General.is_Annexure_Mode);
                STR_Code = Convert.ToString(Export_General.is_STR_Code);
    
            }
            else
            {
                txtCustomHouse = "";
                txtExporterName = "";
                txtScheme = "";
                txtConsignee = "";
                txtNoofItems = "";
                txtNoofInvoices = "";

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        custid = txtCustomHouse + "~~" + txtExporterName + "~~" + txtScheme + "~~" + txtConsignee + "~~" + txtNoofItems + "~~" + txtNoofInvoices + "~~" + Annexure_Mode + "~~" + STR_Code;
        HttpContext.Current.Session.Remove("Inv_Item");
        HttpContext.Current.Session["Inv_Item"] = custid; 
        return custid;
    }

    private void Load_INV_Item_Value_Chk()
    {
        try
        {
            if (ddlJobNo.SelectedValue != "Select")
            {
                DataSet ds = new DataSet();
                CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                CHKLIST.Ename = "Select_Inv_Item_Value_Chk";
                CHKLIST.Workingperiod = SELECT_BRANCH;
                ds = CHKLIST.RetrieveAll_General_Details();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    MP_JOB.Show();
                    gv_Inv_Item.DataSource = ds.Tables[0];
                    gv_Inv_Item.DataBind();
                }
                else
                {
                    MP_JOB.Hide();
                    DataTable dt = new DataTable();
                    gv_Inv_Item.DataSource = dt;
                    gv_Inv_Item.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }

    protected void btnok_Click(object sender, EventArgs e)
    {
        try
        {
            MP_JOB.Hide();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
      
    }
 
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {

        string  Annexure_Mode = "", STR_Code = "";
        try
        {
            if (ddlJobNo.SelectedValue.ToString() != "Select")
            {
                DataSet ds = new DataSet();

                Export_CheckList CHKLIST = new Export_CheckList();
                CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                CHKLIST.Ename = "select_jobno_CheckList";
                CHKLIST.Workingperiod = SELECT_BRANCH;
                ds = CHKLIST.RetrieveAll_General_Details();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCustomHouse.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                    txtExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                    txtConsignee.Text = ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        txtScheme.Text = ds.Tables[1].Rows[0]["ITEM_SCHEME_CODE"].ToString();
                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            txtNoofInvoices.Text = ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() + " INVOICE";

                        }
                        else
                        {
                            txtNoofInvoices.Text = "";
                        }

                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            txtNoofItems.Text = ds.Tables[3].Rows[0]["ITEM_SLNO"].ToString() + " ITEMS";
                        }
                        else
                        {
                            txtNoofItems.Text = "";
                        }
                    }
                    else
                    {
                        txtScheme.Text = "";
                        txtNoofItems.Text = "";
                        txtNoofInvoices.Text = "";
                    }
                    Rpt_General_Details Export_General = new Rpt_General_Details();
                    Export_General.Retrieve_GetGeneral(ddlJobNo.SelectedValue.ToString());
                    Annexure_Mode = Convert.ToString(Export_General.is_Annexure_Mode);
                    STR_Code = Convert.ToString(Export_General.is_STR_Code);

                    hdn_Annexure_Mode.Value = Annexure_Mode;
                    hdn_STR_Code.Value=STR_Code;
                }
                else
                {
                    txtCustomHouse.Text = "";
                    txtExporterName.Text = "";
                    txtScheme.Text = "";
                    txtConsignee.Text = "";
                    txtNoofItems.Text = "";
                    txtNoofInvoices.Text = "";
                    hdn_Annexure_Mode.Value = "";
                    hdn_STR_Code.Value = "";
                }
                Load_INV_Item_Value_Chk();
            }
            else
            {
                txtCustomHouse.Text= "";
                txtExporterName.Text = "";
                txtScheme.Text = "";
                txtConsignee.Text = "";
                txtNoofItems.Text = "";
                txtNoofInvoices.Text = "";
                hdn_Annexure_Mode.Value = "";
                hdn_STR_Code.Value = "";
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btn_Elogix_Click(object sender, EventArgs e)
    {
        try
        {
            string Job_Type = string.Empty;

            /*string E_Logix_Company_Id = Connection.E_Logix_Company_Id();
            if (E_Logix_Company_Id != string.Empty) { */
            string E_Logix_Company_Id_Chennai = Connection.e_lOGIX_CHENNAI();
            string E_Logix_Company_Id_Mumbai = Connection.e_lOGIX_MUMBAI();

            if (E_Logix_Company_Id_Chennai != string.Empty || E_Logix_Company_Id_Mumbai != string.Empty)
            {
                UserBO ObjUBO = new UserBO();
                DataSet dss = new DataSet();

                ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();

                if (btn_Elogix.Text == "Move To Elogix")
                {
                    Job_Type = "S";
                }
                else
                {
                    Job_Type = "U";
                }
                ObjUBO.Ename = Job_Type;
                ObjUBO.flag = "Data_Sent_Update";
                ObjUBO.File_Type = "E";
                

               // dss = ES.Select_IMP_EXP(ObjUBO);

                if (E_Logix_Company_Id_Chennai != string.Empty)
                {
                    /*
                    E_LOGIX ES = new E_LOGIX();
                    dss = ES.Select_IMP_EXP_INVO_SYS(ObjUBO);
                    */
                }
                else if (E_Logix_Company_Id_Mumbai != string.Empty)
                {
                    E_LOGIX_MUMBAI ES = new E_LOGIX_MUMBAI();
                    ObjUBO.ITEM_ID = E_Logix_Company_Id_Mumbai;
                    dss = ES.Select_IMP_EXP(ObjUBO);
                }

                if (dss.Tables[0].Rows.Count > 0)
                {
                    btn_Elogix.Visible = true;
                    lbl_Msg.Text = string.Empty;

                    if (E_Logix_Company_Id_Chennai != string.Empty)
                    {
                        IMPL.ELOGIX_CS obj = new IMPL.ELOGIX_CS();
                        obj.ExportPlanning(
                              dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString()
                             , dss.Tables[0].Rows[0]["JOBNO_PS"].ToString()
                             , dss.Tables[0].Rows[0]["JOBDATE"].ToString()
                             , dss.Tables[0].Rows[0]["IEC_NO"].ToString()
                             , dss.Tables[0].Rows[0]["INVOICE_NO"].ToString()
                             , dss.Tables[0].Rows[0]["INVOICE_DATE"].ToString()
                             , dss.Tables[0].Rows[0]["PACKAGES"].ToString()
                             , dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString()
                             , dss.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString()
                             , dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()
                             , dss.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString()
                             , dss.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString()
                             , dss.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString()
                             , dss.Tables[0].Rows[0]["NET_WEIGHT"].ToString()
                             , dss.Tables[0].Rows[0]["TERMS"].ToString()
                             , dss.Tables[0].Rows[0]["IEC_NO"].ToString()
                             , E_Logix_Company_Id_Chennai
                             , dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()
                             , dss.Tables[0].Rows[0]["Item_Desc"].ToString()
                             , dss.Tables[0].Rows[0]["WORKINGPERIOD"].ToString()
                             , dss.Tables[0].Rows[0]["UNIT_CODE"].ToString()
                             , dss.Tables[0].Rows[0]["INVOICE_VALUE"].ToString()
                             , Job_Type
                             , dss.Tables[0].Rows[0]["CLG_PLACE"].ToString()
                             , dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()
                             , dss.Tables[0].Rows[0]["SB_NO"].ToString()
                             , dss.Tables[0].Rows[0]["SB_DATE"].ToString()
                             , dss.Tables[0].Rows[0]["PAYMENT_METHOD"].ToString()
                             , dss.Tables[0].Rows[0]["BUYER_NAME"].ToString()
                             , dss.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString()
                             , dss.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString()
                             , dss.Tables[0].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString()
                             , dss.Tables[0].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString()
                             , dss.Tables[0].Rows[0]["NO_OF_CONTAINERS"].ToString()
                             , dss.Tables[0].Rows[0]["USERID"].ToString()
                             , dss.Tables[0].Rows[0]["JOBNO"].ToString()
                             );
                    }
                    else if (E_Logix_Company_Id_Mumbai != string.Empty)
                    {
                        IMPL_MUMBAI.ELOGIX_CS obj = new IMPL_MUMBAI.ELOGIX_CS();
                        obj.ExportPlanning(
                                  dss.Tables[9].Rows[0]["TRANSPORT_MODE"].ToString()
                                 , dss.Tables[9].Rows[0]["JOBNO_PS"].ToString()
                                 , dss.Tables[9].Rows[0]["JOBDATE"].ToString()
                                 , dss.Tables[9].Rows[0]["IEC_NO"].ToString()
                                 , dss.Tables[9].Rows[0]["INVOICE_NO"].ToString()
                                 , dss.Tables[9].Rows[0]["INVOICE_DATE"].ToString()
                                 , dss.Tables[9].Rows[0]["PACKAGES"].ToString()
                                 , dss.Tables[9].Rows[0]["CONSIGNEE_NAME"].ToString()
                                 , dss.Tables[9].Rows[0]["INVOICE_CURRENCY"].ToString()
                                 , dss.Tables[9].Rows[0]["CUSTOMS_HOUSE"].ToString()
                                 , dss.Tables[9].Rows[0]["PORT_FINAL_DEST"].ToString()
                                 , dss.Tables[9].Rows[0]["PORT_DISCHARGE"].ToString()
                                 , dss.Tables[9].Rows[0]["GROSS_WEIGHT"].ToString()
                                 , dss.Tables[9].Rows[0]["NET_WEIGHT"].ToString()
                                 , dss.Tables[9].Rows[0]["TERMS"].ToString()
                                 , dss.Tables[9].Rows[0]["IEC_NO"].ToString()
                                 , E_Logix_Company_Id_Mumbai
                                 , dss.Tables[9].Rows[0]["BRANCH_NO"].ToString()
                                 , dss.Tables[9].Rows[0]["Item_Desc"].ToString()
                                 , dss.Tables[9].Rows[0]["WORKINGPERIOD"].ToString()
                                 , dss.Tables[9].Rows[0]["UNIT_CODE"].ToString()
                                 , dss.Tables[9].Rows[0]["INVOICE_VALUE"].ToString()
                                 , Job_Type
                                 , dss.Tables[9].Rows[0]["CLG_PLACE"].ToString()
                                 , dss.Tables[9].Rows[0]["FILE_REF_NO"].ToString()
                                 , dss.Tables[9].Rows[0]["SB_NO"].ToString()
                                 , dss.Tables[9].Rows[0]["SB_DATE"].ToString()
                                 , dss.Tables[9].Rows[0]["PAYMENT_METHOD"].ToString()
                                 , dss.Tables[9].Rows[0]["BUYER_NAME"].ToString()
                                 , dss.Tables[9].Rows[0]["COUNTRY_DISCHARGE"].ToString()
                                 , dss.Tables[9].Rows[0]["COUNTRY_FINAL_DEST"].ToString()
                                 , dss.Tables[9].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString()
                                 , dss.Tables[9].Rows[0]["ANNEX_SEA_SEAL_TYPE"].ToString()
                                 , dss.Tables[9].Rows[0]["NO_OF_CONTAINERS"].ToString()
                                 , dss.Tables[9].Rows[0]["USERID"].ToString()
                                 , dss.Tables[9].Rows[0]["JOBNO"].ToString()
                                 , dss.Tables[9].Rows[0]["PACKAGE_TYPE"].ToString()
                                 ,dss.Tables[9].Rows[0]["EXPORTER_NAME"].ToString()
                                 ,dss.Tables[9].Rows[0]["ADDRESS1"].ToString()
                                 ,dss.Tables[9].Rows[0]["ADDRESS2"].ToString()
                                 ,dss.Tables[9].Rows[0]["ADDRESS3"].ToString()
                                 ,dss.Tables[9].Rows[0]["ADDRESS4"].ToString()
                                 ,dss.Tables[9].Rows[0]["ADDRESS5"].ToString()
                                 ,dss.Tables[9].Rows[0]["ADCODE"].ToString()
                                 ,dss.Tables[9].Rows[0]["GSTN_TYPE"].ToString()
                                 ,dss.Tables[9].Rows[0]["GSTN_ID"].ToString()
                                 ,dss.Tables[9].Rows[0]["STATE_OF_EXPORT"].ToString()
                                 ,dss.Tables[9].Rows[0]["CONSIGNEE_NAME"].ToString()
                                 ,dss.Tables[9].Rows[0]["CONSIGNEE_BRANCHSLNO"].ToString()
                                 ,dss.Tables[9].Rows[0]["CONSIGNEE_ADD1"].ToString()
                                 ,dss.Tables[9].Rows[0]["CONSIGNEE_ADD2"].ToString()
                                 ,dss.Tables[9].Rows[0]["CONSIGNEE_ADD3"].ToString()
                                 ,dss.Tables[9].Rows[0]["CONSIGNEE_ADD4"].ToString()
                                 ,dss.Tables[9].Rows[0]["CONSIGNEE_ADD5"].ToString()
                                 ,dss.Tables[9].Rows[0]["BUYER_ADDRESS"].ToString()
                                 ,dss.Tables[9].Rows[0]["BUYER_ADDRESS1"].ToString()
                                 ,dss.Tables[9].Rows[0]["BUYER_ADDRESS2"].ToString()
                                 ,dss.Tables[9].Rows[0]["BUYER_ADDRESS3"].ToString()
                                 ,dss.Tables[9].Rows[0]["BUYER_ADDRESS4"].ToString()

                                 , dss.Tables[9].Rows[0]["ANNEX_SEA_CON_CONTAINERNO"].ToString()
                                 , dss.Tables[9].Rows[0]["ANNEX_SEA_CON_SIZE"].ToString()
                                 , dss.Tables[9].Rows[0]["ANNEX_SEA_CON_TYPE"].ToString()
                                 , dss.Tables[9].Rows[0]["ANNEX_SEA_CON_EXCISE_SEALNO"].ToString()
                                 , dss.Tables[9].Rows[0]["ANNEX_SEA_CON_SEAL_DATE"].ToString()
                                 , dss.Tables[9].Rows[0]["ANNEX_SEA_CON_SEALTYPE_INDICATOR"].ToString()
                                 );
                            obj.Export_doc_Iteam(dss);

                    }

                    lbl_Msg.Text = "Job Sent Successfully";
                    btn_Elogix.Visible = false;
                }
                else
                {
                    btn_Elogix.Visible = false;
                    lbl_Msg.Text = string.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    protected void btn_ICode_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dss = new DataSet();
            ICode_CS IC = new ICode_CS();
            dss = IC.Get_ICode_Jobno_Select(ddlJobNo.SelectedValue.ToString(), "E", "Royal_Data", "", COMPANY_ID);
            if (dss.Tables[0].Rows.Count > 0)
            {
                I_Code.ERoyal obj = new I_Code.ERoyal();
                obj.ERoyal_Export(dss);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    protected void open_xmlchecklist(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();

            Export_CheckList CHKLIST = new Export_CheckList();
            CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
            CHKLIST.Ename = "Select_ExportDetails_XML";
            CHKLIST.Workingperiod = SELECT_BRANCH;

            ds = CHKLIST.RetrieveAll_Export_XML_Details();

            StringBuilder xmlContent = new StringBuilder();
            DateTime dateTime = DateTime.Now;
            var str = dateTime.ToString("dd-MMM-yyyy hh:mm:ss tt").ToUpper();

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    xmlContent.AppendLine("<SBDetails>");
                    xmlContent.AppendLine("<Version>" + "SBData 1.5" + "</Version>");
                    xmlContent.AppendLine("<Header>");
                    xmlContent.AppendLine("<Sender>" + "Logisys" + "</Sender>");
                    xmlContent.AppendLine("<Receiver>" + "Unknown" + "</Receiver>"); //doubt 
                    xmlContent.AppendLine("<NoOfDocuments>" + "1" + "</NoOfDocuments>");
                    xmlContent.AppendLine("<GeneratedOn>" + str + "</GeneratedOn>");
                    xmlContent.AppendLine("<Generator>" + "DataExport.cSBDataExport" + "</Generator>");
                    xmlContent.AppendLine("</Header>");
                    xmlContent.AppendLine("<SBDocuments>");
                    xmlContent.AppendLine("<SBDocument>");
                    xmlContent.AppendLine("<Doc_ID>" + ddlJobNo.SelectedItem.Text + "</Doc_ID>");
                    xmlContent.AppendLine("<Exporter>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()) ? " " : ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString()) + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ADDRESS1"].ToString()) ? " " : ds.Tables[0].Rows[0]["ADDRESS1"].ToString()) + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ADDRESS2"].ToString()) ? " " : ds.Tables[0].Rows[0]["ADDRESS2"].ToString()) + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ADDRESS3"].ToString()) ? " " : ds.Tables[0].Rows[0]["ADDRESS3"].ToString()) + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ADDRESS4"].ToString()) ? " " : ds.Tables[0].Rows[0]["ADDRESS4"].ToString()) + "</Exporter>");
                    xmlContent.AppendLine("<ExporterBranchID>" + "BRANCH CODE " + ":" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["BRANCH_NO"].ToString()) ? " " : ds.Tables[0].Rows[0]["BRANCH_NO"].ToString()) + "</ExporterBranchID>");
                    xmlContent.AppendLine("<LoadingPort>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString()) ? " " : ds.Tables[0].Rows[0]["PORT_OF_LOADING"].ToString()) + "</LoadingPort>");
                    xmlContent.AppendLine("<TransportMode>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString()) ? " " : ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString()) + "</TransportMode>");
                    xmlContent.AppendLine("<TypeOfSB>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["SB_TYPE"].ToString()) ? " " : ds.Tables[0].Rows[0]["SB_TYPE"].ToString()) + "</TypeOfSB>");
                    xmlContent.AppendLine("<SBHeading>" + " " + "</SBHeading>");
                    xmlContent.AppendLine("<Marks>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["MARKS_NO"].ToString()) ? " " : ds.Tables[0].Rows[0]["MARKS_NO"].ToString()) + "</Marks>");

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        xmlContent.AppendLine("<SBNo>" + (string.IsNullOrEmpty(ds.Tables[1].Rows[0]["SB_NO_DATE"].ToString()) ? " " : ds.Tables[1].Rows[0]["SB_NO_DATE"].ToString()) + "</SBNo>");
                        //xmlContent.AppendLine("<SBDate>" + (string.IsNullOrEmpty(ds.Tables[1].Rows[0]["SB_NO_DATE"].ToString()) ? " " : ds.Tables[1].Rows[0]["SB_NO_DATE"].ToString()) + "</SBDate>");
                        xmlContent.AppendLine("<SBDate>" + (string.IsNullOrEmpty(ds.Tables[1].Rows[0]["SB_NO_DATE"].ToString()) ? " " : ds.Tables[1].Rows[0]["SB_NO_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(ds.Tables[1].Rows[0]["SB_NO_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</SBDate>");
                    }
                    else
                    {
                        xmlContent.AppendLine("<SBNo>" + " " + "</SBNo>");
                        xmlContent.AppendLine("<SBDate>" + " " + "</SBDate>");
                    }
                    xmlContent.AppendLine("<Has_Shipment_Dtl>" + " " + "</Has_Shipment_Dtl>");
                    xmlContent.AppendLine("<Consignee>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString()) ? " " : ds.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString()) + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString()) ? " " : ds.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString()) + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString()) ? " " : ds.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString()) + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString()) ? " " : ds.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString()) + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString()) ? " " : ds.Tables[0].Rows[0]["CONSIGNEE_ADD4"].ToString()) + "</Consignee>");
                    xmlContent.AppendLine("<ConsigneeCountry>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString()) ? " " : ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString()) + "</ConsigneeCountry>");

                    if (ds.Tables[5].Rows[0]["BUYER"].ToString() == "Y")
                    {
                        xmlContent.AppendLine("<IsBuyerDifferent>" + 0 + "</IsBuyerDifferent>");
                        xmlContent.AppendLine("<Buyer>" + "" + "</Buyer>");
                    }
                    else
                    {
                        xmlContent.AppendLine("<IsBuyerDifferent>" + 1 + "</IsBuyerDifferent>");
                        xmlContent.AppendLine("<Buyer>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[0]["BUYER_ADDRESS"].ToString()) ? " " : ds.Tables[5].Rows[0]["BUYER_ADDRESS"].ToString()) + (string.IsNullOrEmpty(ds.Tables[5].Rows[0]["BUYER_ADDRESS1"].ToString()) ? " " : ds.Tables[5].Rows[0]["BUYER_ADDRESS1"].ToString())
                            + (string.IsNullOrEmpty(ds.Tables[5].Rows[0]["BUYER_ADDRESS2"].ToString()) ? " " : ds.Tables[5].Rows[0]["BUYER_ADDRESS2"].ToString()) + (string.IsNullOrEmpty(ds.Tables[5].Rows[0]["BUYER_ADDRESS3"].ToString()) ? " " : ds.Tables[5].Rows[0]["BUYER_ADDRESS3"].ToString())
                            + (string.IsNullOrEmpty(ds.Tables[5].Rows[0]["BUYER_ADDRESS4"].ToString()) ? " " : ds.Tables[5].Rows[0]["BUYER_ADDRESS4"].ToString()) + "</Buyer>");
                    }
                    xmlContent.AppendLine("<Notify>" + " " + "</Notify>");
                    xmlContent.AppendLine("<DischPort>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString()) ? " " : ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString()) + "</DischPort>");
                    xmlContent.AppendLine("<DischCountry>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString()) ? " " : ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString()) + "</DischCountry>");
                    xmlContent.AppendLine("<DestPort>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString()) ? " " : ds.Tables[0].Rows[0]["PORT_FINAL_DEST"].ToString()) + "</DestPort>");
                    xmlContent.AppendLine("<DestCountry>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString()) ? " " : ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString()) + "</DestCountry>");
                    xmlContent.AppendLine("<Carrier>" + " " + "</Carrier>");
                    xmlContent.AppendLine("<FlightNo>" + " " + "</FlightNo>");
                    xmlContent.AppendLine("<FlightDate>" + " " + "</FlightDate>");

                    if (ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() == "Air" && ds.Tables[2].Rows.Count > 0)
                    {

                        xmlContent.AppendLine("<VoyageNo>" + " " + "</VoyageNo>");
                        xmlContent.AppendLine("<MAWBNo>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_NO"].ToString()) + "</MAWBNo>");
                        // xmlContent.AppendLine("<MAWBDate>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) + "</MAWBDate>");
                        xmlContent.AppendLine("<MAWBDate>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</MAWBDate>");
                        xmlContent.AppendLine("<HAWBNo>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_HAWB_NO"].ToString()) + "</HAWBNo>");
                        // xmlContent.AppendLine("<HAWBDate>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) + "</HAWBDate>");
                        xmlContent.AppendLine("<MAWBDate>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(ds.Tables[2].Rows[0]["ANNEX_AIR_MAWB_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</MAWBDate>");
                        xmlContent.AppendLine("<RotationNo>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_NO"].ToString()) + "</RotationNo>");
                        // xmlContent.AppendLine("<RotationDate>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString()) + "</RotationDate>");
                        xmlContent.AppendLine("<RotationDate>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(ds.Tables[2].Rows[0]["ANNEX_AIR_ROTATION_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</RotationDate>");
                        xmlContent.AppendLine("<GoodsStuffedAt>" + " " + "</GoodsStuffedAt>");
                        xmlContent.AppendLine("<SampleAccompanied>" + " " + "</SampleAccompanied>");
                        xmlContent.AppendLine("<FactoryAddr>" + " " + "</FactoryAddr>");
                        xmlContent.AppendLine("<SealNo>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_SEALNO"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_SEALNO"].ToString()) + "</SealNo>");
                        xmlContent.AppendLine("<SealingAgency>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_SEAL_AGENCY"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_SEAL_AGENCY"].ToString()) + "</SealingAgency>");
                        xmlContent.AppendLine("<GrossWt>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString()) ? "0" : ds.Tables[2].Rows[0]["ANNEX_AIR_GROSS_WEIGHT"].ToString()) + "</GrossWt>");
                        xmlContent.AppendLine("<GrossWtUnit>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString()) + "</GrossWtUnit>");
                        xmlContent.AppendLine("<NetWt>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString()) ? "0" : ds.Tables[2].Rows[0]["ANNEX_AIR_NET_WEIGHT"].ToString()) + "</NetWt>");
                        xmlContent.AppendLine("<NetWtUnit>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_GR_UNIT_CODE"].ToString()) + "</NetWtUnit>");
                        xmlContent.AppendLine("<CargoType>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["NATURE_OF_CARGO"].ToString()) ? " " : ds.Tables[2].Rows[0]["NATURE_OF_CARGO"].ToString()) + "</CargoType>");
                        xmlContent.AppendLine("<NoOfPkg>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString()) ? "0" : ds.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString()) + "</NoOfPkg>");
                        xmlContent.AppendLine("<PkgUnit>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_UNIT_CODE"].ToString()) + "</PkgUnit>");
                        xmlContent.AppendLine("<LoosePkgs>" + 0 + "</LoosePkgs>");
                        xmlContent.AppendLine("<NumContainers>" + 0 + "</NumContainers>");
                        xmlContent.AppendLine("<PktsInMAWB>" + 0 + "</PktsInMAWB>");
                    }
                    else if ((ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() == "Sea" || ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() == "Land") && ds.Tables[2].Rows.Count > 0)
                    {
                        xmlContent.AppendLine("<VoyageNo>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_VOYAGENO"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_SEA_VOYAGENO"].ToString()) + "</VoyageNo>");
                        xmlContent.AppendLine("<MAWBNo>" + " " + "</MAWBNo>");
                        xmlContent.AppendLine("<MAWBDate>" + " " + "</MAWBDate>");
                        xmlContent.AppendLine("<HAWBNo>" + " " + "</HAWBNo>");
                        xmlContent.AppendLine("<HAWBDate>" + " " + "</HAWBDate>");
                        xmlContent.AppendLine("<RotationNo>" + " " + "</RotationNo>");
                        xmlContent.AppendLine("<RotationDate>" + " " + "</RotationDate>");
                        xmlContent.AppendLine("<GoodsStuffedAt>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_SEA_FAC_STUFFED"].ToString()) + "</GoodsStuffedAt>");
                        xmlContent.AppendLine("<SampleAccompanied>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_SEA_SAMPLE_ACCOM"].ToString()) + "</SampleAccompanied>");
                        xmlContent.AppendLine("<FactoryAddr>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_FACTORY_ADD"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_SEA_FACTORY_ADD"].ToString()) + "</FactoryAddr>");
                        xmlContent.AppendLine("<SealNo>" + " " + "</SealNo>");
                        xmlContent.AppendLine("<SealingAgency>" + " " + "</SealingAgency>");
                        xmlContent.AppendLine("<GrossWt>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString()) ? "0" : ds.Tables[2].Rows[0]["ANNEX_SEA_GROSS_WEIGHT"].ToString()) + "</GrossWt>");
                        xmlContent.AppendLine("<GrossWtUnit>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString()) + "</GrossWtUnit>");
                        xmlContent.AppendLine("<NetWt>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString()) ? "0" : ds.Tables[2].Rows[0]["ANNEX_SEA_NET_WEIGHT"].ToString()) + "</NetWt>");
                        xmlContent.AppendLine("<NetWtUnit>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_SEA_UNIT_MEASUREMENT"].ToString()) + "</NetWtUnit>");
                        xmlContent.AppendLine("<CargoType>" + "p" + "</CargoType>");
                        xmlContent.AppendLine("<NoOfPkg>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString()) ? "0" : ds.Tables[2].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString()) + "</NoOfPkg>");
                        xmlContent.AppendLine("<PkgUnit>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_PKG_UNIT_CODE"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_SEA_PKG_UNIT_CODE"].ToString()) + "</PkgUnit>");
                        xmlContent.AppendLine("<LoosePkgs>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString()) ? "0" : ds.Tables[2].Rows[0]["ANNEX_SEA_LOOSE_PACKETS"].ToString()) + "</LoosePkgs>");
                        xmlContent.AppendLine("<NumContainers>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString()) ? "0" : ds.Tables[2].Rows[0]["ANNEX_SEA_NO_CONTAINERS"].ToString()) + "</NumContainers>");
                        xmlContent.AppendLine("<PktsInMAWB>" + 0 + "</PktsInMAWB>");
                    }
                    else
                    {
                        xmlContent.AppendLine("<VoyageNo>" + " " + "</VoyageNo>");
                        xmlContent.AppendLine("<MAWBNo>" + " " + "</MAWBNo>");
                        xmlContent.AppendLine("<MAWBDate>" + " " + "</MAWBDate>");
                        xmlContent.AppendLine("<HAWBNo>" + " " + "</HAWBNo>");
                        xmlContent.AppendLine("<HAWBDate>" + " " + "</HAWBDate>");
                        xmlContent.AppendLine("<RotationNo>" + " " + "</RotationNo>");
                        xmlContent.AppendLine("<RotationDate>" + " " + "</RotationDate>");
                        xmlContent.AppendLine("<GoodsStuffedAt>" + " " + "</GoodsStuffedAt>");
                        xmlContent.AppendLine("<SampleAccompanied>" + " " + "</SampleAccompanied>");
                        xmlContent.AppendLine("<FactoryAddr>" + " " + "</FactoryAddr>");
                        xmlContent.AppendLine("<SealNo>" + " " + "</SealNo>");
                        xmlContent.AppendLine("<SealingAgency>" + " " + "</SealingAgency>");
                        xmlContent.AppendLine("<GrossWt>" + " " + "</GrossWt>");
                        xmlContent.AppendLine("<GrossWtUnit>" + " " + "</GrossWtUnit>");
                        xmlContent.AppendLine("<NetWt>" + " " + "</NetWt>");
                        xmlContent.AppendLine("<NetWtUnit>" + " " + "</NetWtUnit>");
                        xmlContent.AppendLine("<CargoType>" + " " + "</CargoType>");
                        xmlContent.AppendLine("<NoOfPkg>" + " " + "</NoOfPkg>");
                        xmlContent.AppendLine("<PkgUnit>" + " " + "</PkgUnit>");
                        xmlContent.AppendLine("<LoosePkgs>" + " " + "</LoosePkgs>");
                        xmlContent.AppendLine("<NumContainers>" + " " + "</NumContainers>");
                        xmlContent.AppendLine("<PktsInMAWB>" + " " + "</PktsInMAWB>");
                    }
                    xmlContent.AppendLine("<PreCarriageBy>" + "ROAD" + "</PreCarriageBy>");
                    xmlContent.AppendLine("<PlaceOfReceipt>" + "SRICITYINTAS6" + "</PlaceOfReceipt>");
                    xmlContent.AppendLine("<QCertNo>" + " " + "</QCertNo>");
                    xmlContent.AppendLine("<ExportTradeControl>" + " " + "</ExportTradeControl>");
                    xmlContent.AppendLine("<ShipmentType>" + 0 + "</ShipmentType>");
                    xmlContent.AppendLine("<ExporterType>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString()) ? " " : ds.Tables[0].Rows[0]["TYPE_OF_EXPORTER"].ToString()) + "</ExporterType>");
                    xmlContent.AppendLine("<ExportUnder>" + "Other" + "</ExportUnder>");
                    xmlContent.AppendLine("<RBIAppNo>" + " " + "</RBIAppNo>");
                    xmlContent.AppendLine("<RBIAppDate>" + " " + "</RBIAppDate>");
                    xmlContent.AppendLine("<GR_No>" + " " + "</GR_No>");
                    xmlContent.AppendLine("<GR_Date>" + " " + "</GR_Date>");
                    xmlContent.AppendLine("<RBIWaiverNo>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString()) ? " " : ds.Tables[0].Rows[0]["RBI_WAIVER_NO"].ToString()) + "</RBIWaiverNo>");
                    // xmlContent.AppendLine("<RBIWaiverDate>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString()) ? " " : ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString()) + "</RBIWaiverDate>");
                    xmlContent.AppendLine("<RBIWaiverDate>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString()) ? " " : ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(ds.Tables[0].Rows[0]["RBI_WAIVER_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</RBIWaiverDate>");
                    xmlContent.AppendLine("<StateOfOrigin>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString()) ? " " : ds.Tables[0].Rows[0]["STATE_OF_EXPORT"].ToString()) + "</StateOfOrigin>");
                    xmlContent.AppendLine("<ExporterRefNo>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) ? " " : ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString()) + "</ExporterRefNo>");
                    xmlContent.AppendLine("<ExporterRefDate>" + DateTime.Now.ToString("dd-MMM-yyyy") + "</ExporterRefDate>");
                    xmlContent.AppendLine("<BuyerOrderNo>" + " " + "</BuyerOrderNo>");
                    xmlContent.AppendLine("<BuyerOrderDate>" + " " + "</BuyerOrderDate>");
                    xmlContent.AppendLine("<OtherRef>" + " " + "</OtherRef>");
                    xmlContent.AppendLine("<TermsOfDelivery>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[0]["TERMS_PLACE"].ToString()) ? " " : ds.Tables[0].Rows[0]["TERMS_PLACE"].ToString()) + "</TermsOfDelivery>");
                    xmlContent.AppendLine("<FinalDestCountry>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString()) ? " " : ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString()) + "</FinalDestCountry>");
                    xmlContent.AppendLine("<OriginCountry>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString()) ? " " : ds.Tables[0].Rows[0]["COUNTRY_DISCHARGE"].ToString()) + "</OriginCountry>");
                    xmlContent.AppendLine("<RegistrationType>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) ? " " : ds.Tables[0].Rows[0]["GSTN_TYPE"].ToString()) + "</RegistrationType>");
                    xmlContent.AppendLine("<RegistrationNo>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["GSTN_ID"].ToString()) ? " " : ds.Tables[0].Rows[0]["GSTN_ID"].ToString()) + "</RegistrationNo>");
                    if (ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() == "Air" && ds.Tables[2].Rows.Count > 0)
                    {
                        xmlContent.AppendLine("<PackingDetails>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_AIR_TOTAL_PACKAGES"].ToString()) + "</PackingDetails>");
                    }
                    else if ((ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() == "Sea" || ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString() == "Land") && ds.Tables[2].Rows.Count > 0)
                    {
                        xmlContent.AppendLine("<PackingDetails>" + (string.IsNullOrEmpty(ds.Tables[2].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString()) ? " " : ds.Tables[2].Rows[0]["ANNEX_SEA_TOTAL_PACKAGES"].ToString()) + "</PackingDetails>");
                    }
                    else
                    {
                        xmlContent.AppendLine("<PackingDetails>" + " " + "</PackingDetails>");
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        string containerNos = "";

                        for (int inv = 0; inv < ds.Tables[3].Rows.Count; inv++)
                        {
                            string contNo = ds.Tables[3].Rows[inv]["ANNEX_SEA_CON_CONTAINERNO"].ToString();

                            if (!string.IsNullOrEmpty(contNo))
                            {
                                if (containerNos.Length > 0)
                                    containerNos += ",";

                                containerNos += contNo;
                            }
                        }

                        xmlContent.AppendLine("<ContainerDetails>" + (string.IsNullOrEmpty(containerNos) ? " " : containerNos) + "</ContainerDetails>");
                    }
                    else
                    {
                        xmlContent.AppendLine("<ContainerDetails>" + " " + "</ContainerDetails>");
                    }


                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        xmlContent.AppendLine("<InvoiceDetails>");
                        xmlContent.AppendLine("<InvoiceDetail>");

                        for (int inv = 0; inv < ds.Tables[5].Rows.Count; inv++)
                        {

                            xmlContent.AppendLine("<InvoiceNo>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["INVOICE_NO"].ToString()) ? " " : ds.Tables[5].Rows[inv]["INVOICE_NO"].ToString()) + "</InvoiceNo>");
                            // xmlContent.AppendLine("<InvoiceDate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["INVOICE_DATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["INVOICE_DATE"].ToString()) + "</InvoiceDate>");
                            xmlContent.AppendLine("<InvoiceDate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["INVOICE_DATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["INVOICE_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(ds.Tables[5].Rows[inv]["INVOICE_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</InvoiceDate>");
                            xmlContent.AppendLine("<InvoiceCurrency>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["FREIGHT_CURRENCY"].ToString()) ? " " : ds.Tables[5].Rows[inv]["FREIGHT_CURRENCY"].ToString()) + "</InvoiceCurrency>");
                            xmlContent.AppendLine("<InvoiceBank>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["NON_STD_BANKNAME"].ToString()) ? " " : ds.Tables[5].Rows[inv]["NON_STD_BANKNAME"].ToString()) + "</InvoiceBank>");
                            xmlContent.AppendLine("<InvoiceBankCert>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) ? " " : ds.Tables[5].Rows[inv]["NON_STD_CERTIFICATE_NO"].ToString()) + "</InvoiceBankCert>");
                            // xmlContent.AppendLine("<InvoiceBankCertDate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["NON_STD_CERTIFICATE_DATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["NON_STD_CERTIFICATE_DATE"].ToString()) + "</InvoiceBankCertDate>");
                            xmlContent.AppendLine("<InvoiceBankCertDate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["NON_STD_CERTIFICATE_DATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["NON_STD_CERTIFICATE_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(ds.Tables[5].Rows[inv]["NON_STD_CERTIFICATE_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</InvoiceBankCertDate>");
                            xmlContent.AppendLine("<InvoiceCurncRate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["EXCHANGE_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["EXCHANGE_RATE"].ToString()) + "</InvoiceCurncRate>");
                            xmlContent.AppendLine("<InvoiceValue>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["INVOICE_VALUE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["INVOICE_VALUE"].ToString()) + "</InvoiceValue>");
                            xmlContent.AppendLine("<ProductValue>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["INVOICE_VALUE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["INVOICE_VALUE"].ToString()) + "</ProductValue>");
                            xmlContent.AppendLine("<TermsOfInvoice>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["TERMS"].ToString()) ? " " : ds.Tables[5].Rows[inv]["WHEATHER_UNIT_PRICE"].ToString()) + "</TermsOfInvoice>");
                            xmlContent.AppendLine("<UnitPriceIncludes>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["WHEATHER_UNIT_PRICE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["WHEATHER_UNIT_PRICE"].ToString()) + "</UnitPriceIncludes>");
                            xmlContent.AppendLine("<OtherChargeCurrency>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["OTHER_DEDUCTION_CURRENCY"].ToString()) ? " " : ds.Tables[5].Rows[inv]["OTHER_DEDUCTION_CURRENCY"].ToString()) + "</OtherChargeCurrency>");
                            xmlContent.AppendLine("<FreightRate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["FREIGHT_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["FREIGHT_RATE"].ToString()) + "</FreightRate>");
                            xmlContent.AppendLine("<Freight>" + 0.00 + "</Freight>");
                            xmlContent.AppendLine("<InsuranceRate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["INSURANCE_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["INSURANCE_RATE"].ToString()) + "</InsuranceRate>");
                            xmlContent.AppendLine("<Insurance>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["INSURANCE_CHARGES"].ToString()) ? " " : ds.Tables[5].Rows[inv]["INSURANCE_CHARGES"].ToString()) + "</Insurance>");
                            xmlContent.AppendLine("<CommissionRate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["COMMISSION_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["COMMISSION_RATE"].ToString()) + "</CommissionRate>");
                            xmlContent.AppendLine("<CommissionBasis>" + " " + "</CommissionBasis>");
                            xmlContent.AppendLine("<CommissionOn>" + " " + "</CommissionOn>");
                            xmlContent.AppendLine("<CommissionCurrency>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["COMMISSION_CURRENCY"].ToString()) ? " " : ds.Tables[5].Rows[inv]["COMMISSION_CURRENCY"].ToString()) + "</CommissionCurrency>");
                            xmlContent.AppendLine("<CommissionCurncRate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["EXCHANGE_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["EXCHANGE_RATE"].ToString()) + "</CommissionCurncRate>");
                            xmlContent.AppendLine("<CommissionAmount>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["EXCHANGE_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["EXCHANGE_RATE"].ToString()) + "</CommissionAmount>");
                            xmlContent.AppendLine("<DeductCommission>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["OTHER_DEDUCTION_CHARGES"].ToString()) ? " " : ds.Tables[5].Rows[inv]["OTHER_DEDUCTION_CHARGES"].ToString()) + "</DeductCommission>");
                            xmlContent.AppendLine("<CommissionAgent>" + " " + "</CommissionAgent>");
                            xmlContent.AppendLine("<DiscountRate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["PACKMISC_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["PACKMISC_RATE"].ToString()) + "</DiscountRate>");
                            xmlContent.AppendLine("<DiscountBasis>" + " " + "</DiscountBasis>");
                            xmlContent.AppendLine("<DiscountOn>" + " " + "</DiscountOn>");
                            xmlContent.AppendLine("<DiscountCurrency>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["FOB_CURRENCY"].ToString()) ? " " : ds.Tables[5].Rows[inv]["FOB_CURRENCY"].ToString()) + "</DiscountCurrency>");
                            xmlContent.AppendLine("<DiscountCurncRate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["EXCHANGE_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["EXCHANGE_RATE"].ToString()) + "</DiscountCurncRate>");
                            xmlContent.AppendLine("<DiscountAmount>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["FOB_CHARGES"].ToString()) ? " " : ds.Tables[5].Rows[inv]["FOB_CHARGES"].ToString()) + "</DiscountAmount>");
                            xmlContent.AppendLine("<DeductDiscount>" + "N" + "</DeductDiscount>");
                            xmlContent.AppendLine("<MiscRate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["PACKMISC_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["PACKMISC_RATE"].ToString()) + "</MiscRate>");
                            xmlContent.AppendLine("<MiscBasis>" + " " + "</MiscBasis>");
                            xmlContent.AppendLine("<MiscOn>" + " " + "</MiscOn>");
                            xmlContent.AppendLine("<MiscCurrency>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["PACKMISC_CURRENCY"].ToString()) ? " " : ds.Tables[5].Rows[inv]["PACKMISC_CURRENCY"].ToString()) + "</MiscCurrency>");
                            xmlContent.AppendLine("<MiscCurncRate>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["PACKMISC_RATE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["PACKMISC_RATE"].ToString()) + "</MiscCurncRate>");
                            xmlContent.AppendLine("<MiscAmount>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["PACKMISC_CHARGES"].ToString()) ? " " : ds.Tables[5].Rows[inv]["PACKMISC_CHARGES"].ToString()) + "</MiscAmount>");
                            xmlContent.AppendLine("<PackingCharges>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["PACKMISC_CHARGES"].ToString()) ? " " : ds.Tables[5].Rows[inv]["PACKMISC_CHARGES"].ToString()) + "</PackingCharges>");
                            xmlContent.AppendLine("<ExportContractNo>" + " " + "</ExportContractNo>");
                            xmlContent.AppendLine("<ExportContractDate>" + " " + "</ExportContractDate>");
                            xmlContent.AppendLine("<PaymentType>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["PAYMENT_METHOD"].ToString()) ? " " : ds.Tables[5].Rows[inv]["PAYMENT_METHOD"].ToString()) + "</PaymentType>");
                            xmlContent.AppendLine("<PaymentPeriod>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["PERIOD_PAYMENT"].ToString()) ? " " : ds.Tables[5].Rows[inv]["PERIOD_PAYMENT"].ToString()) + "</PaymentPeriod>");
                            xmlContent.AppendLine("<ThirdParty_Name>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["THIRDPARTY_NAME"].ToString()) ? " " : ds.Tables[5].Rows[inv]["THIRDPARTY_NAME"].ToString()) + "</ThirdParty_Name>");
                            xmlContent.AppendLine("<ThirdParty_Code>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) + "</ThirdParty_Code>");
                            xmlContent.AppendLine("<ThirdParty_AddId>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["THIRDPARTY_ADD1"].ToString()) ? " " : ds.Tables[5].Rows[inv]["THIRDPARTY_ADD1"].ToString()) + "</ThirdParty_AddId>");
                            xmlContent.AppendLine("<ThirdParty_Address>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["THIRDPARTY_ADD2"].ToString()) ? " " : ds.Tables[5].Rows[inv]["THIRDPARTY_ADD2"].ToString()) + "</ThirdParty_Address>");
                            xmlContent.AppendLine("<ThirdParty_Cntry>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["T_PARTY_COUNTRY_CODE"].ToString()) + "</ThirdParty_Cntry>");
                            xmlContent.AppendLine("<ThirdParty_City>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["THIRDPARTY_CITY"].ToString()) ? " " : ds.Tables[5].Rows[inv]["THIRDPARTY_CITY"].ToString()) + "</ThirdParty_City>");
                            xmlContent.AppendLine("<ThirdParty_State>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) ? " " : ds.Tables[5].Rows[inv]["T_PARTY_COUNTRY_SUB_DIV"].ToString()) + "</ThirdParty_State>");
                            xmlContent.AppendLine("<ThirdParty_Pin>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["T_PARTY_PIN"].ToString()) ? " " : ds.Tables[5].Rows[inv]["T_PARTY_PIN"].ToString()) + "</ThirdParty_Pin>");
                            xmlContent.AppendLine("<AEO_Code>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR_CODE"].ToString()) + "</AEO_Code>");
                            xmlContent.AppendLine("<AEO_Cntry>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["A_E_O_COUNTRY"].ToString()) ? " " : ds.Tables[5].Rows[inv]["A_E_O_COUNTRY"].ToString()) + "</AEO_Cntry>");
                            xmlContent.AppendLine("<AEO_Role>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) ? " " : ds.Tables[5].Rows[inv]["AUTHORIZED_ECONOMIC_OPERATOR"].ToString()) + "</AEO_Role>");
                            xmlContent.AppendLine("<TermsPlace>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["TERMS_PLACE"].ToString()) ? " " : ds.Tables[5].Rows[inv]["TERMS_PLACE"].ToString()) + "</TermsPlace>");
                            xmlContent.AppendLine("<InvBuyer_Name>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["BUYER_NAME"].ToString()) ? " " : ds.Tables[5].Rows[inv]["BUYER_NAME"].ToString()) + "</InvBuyer_Name>");
                            xmlContent.AppendLine("<InvBuyer_Code>" + 0 + "</InvBuyer_Code>");
                            xmlContent.AppendLine("<InvBuyer_AddId>" + 0 + "</InvBuyer_AddId>");
                            xmlContent.AppendLine("<InvBuyer_Address>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["BUYER_ADDRESS"].ToString()) ? " " : ds.Tables[5].Rows[inv]["BUYER_ADDRESS"].ToString()) + "</InvBuyer_Address>");
                            xmlContent.AppendLine("<InvBuyer_Cntry>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["BUYER_ADDRESS3"].ToString()) ? " " : ds.Tables[5].Rows[inv]["BUYER_ADDRESS3"].ToString()) + "</InvBuyer_Cntry>");
                            xmlContent.AppendLine("<InvBuyer_City>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["BUYER_ADDRESS4"].ToString()) ? " " : ds.Tables[5].Rows[inv]["BUYER_ADDRESS4"].ToString()) + "</InvBuyer_City>");
                            xmlContent.AppendLine("<InvBuyer_State>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["BUYER_ADDRESS2"].ToString()) ? " " : ds.Tables[5].Rows[inv]["BUYER_ADDRESS2"].ToString()) + "</InvBuyer_State>");
                            xmlContent.AppendLine("<InvBuyer_Pin>" + (string.IsNullOrEmpty(ds.Tables[5].Rows[inv]["BUYER_ADDRESS4"].ToString()) ? " " : ds.Tables[5].Rows[inv]["BUYER_ADDRESS4"].ToString()) + "</InvBuyer_Pin>");

                            xmlContent.AppendLine("<EOUDetails>");

                            if (ds.Tables[9].Rows.Count > 0)
                            {
                                xmlContent.AppendLine("<IEC>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_IECCODE"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_IECCODE"].ToString()) + "</IEC>");
                                xmlContent.AppendLine("<BranchSNo>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_BR_SLNO"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_BR_SLNO"].ToString()) + "</BranchSNo>");
                                // xmlContent.AppendLine("<ExaminationDate>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_EXAM_DATE"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_EXAM_DATE"].ToString()) + "</ExaminationDate>");
                                xmlContent.AppendLine("<ExaminationDate>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_EXAM_DATE"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_EXAM_DATE"].ToString() == "01-01-1900" ? " " : (DateTime.Parse(ds.Tables[9].Rows[0]["ANNEX_EXAM_DATE"].ToString()).ToString("dd-MMM-yyyy"))) + "</ExaminationDate>");
                                xmlContent.AppendLine("<ExaminationOfficer>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_EXAM_OFFICER"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_EXAM_OFFICER"].ToString()) + "</ExaminationOfficer>");
                                xmlContent.AppendLine("<ExaminationOfficerDesig>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_EXAM_DESIGN"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_EXAM_DESIGN"].ToString()) + "</ExaminationOfficerDesig>");
                                xmlContent.AppendLine("<SupervisingOfficer>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_SUPER_NAME"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_SUPER_NAME"].ToString()) + "</SupervisingOfficer>");
                                xmlContent.AppendLine("<SuperivsingOfficerDesig>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_SUPER_DESIGN"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_SUPER_DESIGN"].ToString()) + "</SuperivsingOfficerDesig>");
                                xmlContent.AppendLine("<Commissionerate>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_COMMISSION_RATE"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_COMMISSION_RATE"].ToString()) + "</Commissionerate>");
                                xmlContent.AppendLine("<Division>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_DIVISION"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_DIVISION"].ToString()) + "</Division>");
                                xmlContent.AppendLine("<Range>" + (string.IsNullOrEmpty(ds.Tables[9].Rows[0]["ANNEX_RANGE"].ToString()) ? " " : ds.Tables[9].Rows[0]["ANNEX_RANGE"].ToString()) + "</Range>");
                                xmlContent.AppendLine("<ItemVerified>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString()) ? " " : ds.Tables[0].Rows[0]["ANNEX_VERIFIED_EXAM_OFFICER"].ToString()) + "</ItemVerified>");
                                xmlContent.AppendLine("<SampleForwarded>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString()) ? " " : ds.Tables[0].Rows[0]["ANNEX_SAMPLE_DRAWN"].ToString()) + "</SampleForwarded>");
                                xmlContent.AppendLine("<SealNo>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ANNEX_SEAL_NO"].ToString()) ? " " : ds.Tables[0].Rows[0]["ANNEX_SEAL_NO"].ToString()) + "</SealNo>");

                            }
                            else
                            {
                                xmlContent.AppendLine("<IEC>" + " " + "</IEC>");
                                xmlContent.AppendLine("<BranchSNo>" + " " + "</BranchSNo>");
                                xmlContent.AppendLine("<ExaminationDate>" + " " + "</ExaminationDate>");
                                xmlContent.AppendLine("<ExaminationOfficer>" + " " + "</ExaminationOfficer>");
                                xmlContent.AppendLine("<ExaminationOfficerDesig>" + " " + "</ExaminationOfficerDesig>");
                                xmlContent.AppendLine("<SupervisingOfficer>" + " " + "</SupervisingOfficer>");
                                xmlContent.AppendLine("<SuperivsingOfficerDesig>" + " " + "</SuperivsingOfficerDesig>");
                                xmlContent.AppendLine("<Commissionerate>" + " " + "</Commissionerate>");
                                xmlContent.AppendLine("<Division>" + " " + "</Division>");
                                xmlContent.AppendLine("<Range>" + " " + "</Range>");
                                xmlContent.AppendLine("<ItemVerified>" + " " + "</ItemVerified>");
                                xmlContent.AppendLine("<SampleForwarded>" + " " + "</SampleForwarded>");
                                xmlContent.AppendLine("<SealNo>" + " " + "</SealNo>");

                            }

                            xmlContent.AppendLine("</EOUDetails>");

                            DataTable Ex_item_tbl = new DataTable();
                            Ex_item_tbl = ds.Tables[7];
                            DataView Ex_Item_view = Ex_item_tbl.DefaultView;
                            string a = ds.Tables[5].Rows[inv]["INVOICE_SLNO"].ToString();
                            Ex_Item_view.RowFilter = "INVOICE_SLNO = '" + a + "'";
                            DataTable Ex_items = Ex_Item_view.ToTable();

                            if (Ex_items.Rows.Count > 0)
                            {

                                xmlContent.AppendLine("<Products>");
                                xmlContent.AppendLine("<Product>");

                                for (int itm = 0; itm < Ex_items.Rows.Count; itm++)
                                {


                                    xmlContent.AppendLine("<ProductDesc>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_DESCRIPTION"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_DESCRIPTION"].ToString()) + "</ProductDesc>");
                                    xmlContent.AppendLine("<Quantity>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_QTY"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_QTY"].ToString()) + "</Quantity>");
                                    xmlContent.AppendLine("<Unit>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_QTY_CODE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_QTY_CODE"].ToString()) + "</Unit>");
                                    xmlContent.AppendLine("<UnitPrice>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_UNIT_PRICE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_UNIT_PRICE"].ToString()) + "</UnitPrice>");
                                    xmlContent.AppendLine("<UnitOfUnitPrice>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_QTY_CODE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_QTY_CODE"].ToString()) + "</UnitOfUnitPrice>");
                                    xmlContent.AppendLine("<NoOfUnitsInUnitPrice>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_PER"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_PER"].ToString()) + "</NoOfUnitsInUnitPrice>");
                                    xmlContent.AppendLine("<Amount>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_AMOUNT"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_AMOUNT"].ToString()) + "</Amount>");
                                    xmlContent.AppendLine("<AltQuantity1>" + 0.000 + "</AltQuantity1>");
                                    xmlContent.AppendLine("<AltUnit1>" + " " + "</AltUnit1>");
                                    xmlContent.AppendLine("<RITCNumber>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["RITCNO"].ToString()) ? " " : ds.Tables[7].Rows[itm]["RITCNO"].ToString()) + "</RITCNumber>");
                                    xmlContent.AppendLine("<EXIMCode>" + 99 + "</EXIMCode>");
                                    xmlContent.AppendLine("<NFEIGoodsCatg>" + " " + "</NFEIGoodsCatg>");
                                    xmlContent.AppendLine("<PMVCurrency>" + "INR" + "</PMVCurrency>");
                                    xmlContent.AppendLine("<PMVRate>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["PMV_RATE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["PMV_RATE"].ToString()) + "</PMVRate>");
                                    xmlContent.AppendLine("<PMVAmount>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_PMVVALUE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_PMVVALUE"].ToString()) + "</PMVAmount>");
                                    xmlContent.AppendLine("<MaterialCode>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["PART_NO"].ToString()) ? " " : ds.Tables[7].Rows[itm]["PART_NO"].ToString()) + "</MaterialCode>");
                                    xmlContent.AppendLine("<Accessory>" + " " + "</Accessory>");
                                    xmlContent.AppendLine("<AccessoryStatus>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ACCESSORY_STATUS"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ACCESSORY_STATUS"].ToString()) + "</AccessoryStatus>");
                                    xmlContent.AppendLine("<IGSTPayStat>" + " " + "</IGSTPayStat>");
                                    xmlContent.AppendLine("<IGSTTaxableVal>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["TAXABLE_VALUE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["TAXABLE_VALUE"].ToString()) + "</IGSTTaxableVal>");
                                    xmlContent.AppendLine("<IGSTAmt>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["IGST_PAYMENT"].ToString()) ? " " : ds.Tables[7].Rows[itm]["IGST_PAYMENT"].ToString()) + "</IGSTAmt>");
                                    xmlContent.AppendLine("<IGSTRate>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["IGST_RATE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["IGST_RATE"].ToString()) + "</IGSTRate>");
                                    xmlContent.AppendLine("<End_Use>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ENDUSE_ITEM"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ENDUSE_ITEM"].ToString()) + "</End_Use>");
                                    xmlContent.AppendLine("<DBKDetails>" + " " + "</DBKDetails>");
                                    xmlContent.AppendLine("<AR4Dtls>" + " " + "</AR4Dtls>");
                                    xmlContent.AppendLine("<DutyDetails>" + " " + "</DutyDetails>");
                                    xmlContent.AppendLine("<ThirdPartyExport>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_EXPORTER_NAME"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_EXPORTER_NAME"].ToString()) + "</ThirdPartyExport>");
                                    xmlContent.AppendLine("<TP_IEC>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ITEM_IECCODE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ITEM_IECCODE"].ToString()) + "</TP_IEC>");
                                    xmlContent.AppendLine("<TP_BranchSNo>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["BR_SLNO"].ToString()) ? "0" : ds.Tables[7].Rows[itm]["BR_SLNO"].ToString()) + "</TP_BranchSNo>");
                                    xmlContent.AppendLine("<TP_Manufacturer>" + " " + "</TP_Manufacturer>");
                                    xmlContent.AppendLine("<TP_Address>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ADDRESS1"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ADDRESS1"].ToString()) + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ADDRESS2"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ADDRESS2"].ToString())
                                         + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ADDRESS3"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ADDRESS3"].ToString())
                                         + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ADDRESS4"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ADDRESS4"].ToString())
                                          + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["ADDRESS5"].ToString()) ? " " : ds.Tables[7].Rows[itm]["ADDRESS5"].ToString()) + "</TP_Address>");
                                    xmlContent.AppendLine("<TP_RegistrationType>" + " " + "</TP_RegistrationType>");
                                    xmlContent.AppendLine("<TP_RegistrationNo>" + " " + "</TP_RegistrationNo>");
                                    xmlContent.AppendLine("<Manufacturer>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) ? " " : ds.Tables[7].Rows[itm]["MANUFACTURER_PRODUCER"].ToString()) + "</Manufacturer>");
                                    xmlContent.AppendLine("<ManufCodeType>" + " " + "</ManufCodeType>");
                                    xmlContent.AppendLine("<ManufCode>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["M_P_GROWER_CODE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["M_P_GROWER_CODE"].ToString()) + "</ManufCode>");
                                    xmlContent.AppendLine("<ManufAdd>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["M_P_GROWER_ADD1"].ToString()) ? " " : ds.Tables[7].Rows[itm]["M_P_GROWER_ADD1"].ToString())
                                     + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["M_P_GROWER_ADD2"].ToString()) ? " " : ds.Tables[7].Rows[itm]["M_P_GROWER_ADD2"].ToString()) + "</ManufAdd>");
                                    xmlContent.AppendLine("<ManufCntry>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) ? " " : ds.Tables[7].Rows[itm]["M_P_GROWER_COUNTRY_SUBDIV"].ToString()) + "</ManufCntry>");
                                    xmlContent.AppendLine("<ManufState>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["SOURCE_STATE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["SOURCE_STATE"].ToString()) + "</ManufState>");
                                    xmlContent.AppendLine("<ManufPostalCode>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["M_P_GROWER_PIN"].ToString()) ? " " : ds.Tables[7].Rows[itm]["M_P_GROWER_PIN"].ToString()) + "</ManufPostalCode>");
                                    xmlContent.AppendLine("<SourceState>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["SOURCE_STATE"].ToString()) ? " " : ds.Tables[7].Rows[itm]["SOURCE_STATE"].ToString()) + "</SourceState>");
                                    xmlContent.AppendLine("<TransitCntry>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["TRANSIT_COUNTRY"].ToString()) ? " " : ds.Tables[7].Rows[itm]["TRANSIT_COUNTRY"].ToString()) + "</TransitCntry>");
                                    xmlContent.AppendLine("<Cenvat_CertNo>" + " " + "</Cenvat_CertNo>");
                                    xmlContent.AppendLine("<Cenvat_CertDate>" + " " + "</Cenvat_CertDate>");
                                    xmlContent.AppendLine("<Cenvat_CEXOfficeCode>" + " " + "</Cenvat_CEXOfficeCode>");
                                    xmlContent.AppendLine("<Cenvat_AssesseeCode>" + " " + "</Cenvat_AssesseeCode>");
                                    xmlContent.AppendLine("<Cenvat_CertValidUpto>" + " " + "</Cenvat_CertValidUpto>");
                                    xmlContent.AppendLine("<RewardCode>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["REWARD_POINTS"].ToString()) ? " " : ds.Tables[7].Rows[itm]["REWARD_POINTS"].ToString()) + "</RewardCode>");
                                    xmlContent.AppendLine("<RoDTEPClaim>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["RODTEP"].ToString()) ? " " : ds.Tables[7].Rows[itm]["RODTEP"].ToString()) + "</RoDTEPClaim>");
                                    xmlContent.AppendLine("<RoDTEPRate>" + " " + "</RoDTEPRate>");
                                    xmlContent.AppendLine("<RoDTEPRate_SQC>" + " " + "</RoDTEPRate_SQC>");
                                    xmlContent.AppendLine("<RoDTEPNoOfUnits>" + " " + "</RoDTEPNoOfUnits>");
                                    xmlContent.AppendLine("<RoDTEPUnit>" + " " + "</RoDTEPUnit>");
                                    xmlContent.AppendLine("<RoDTEPAmt>" + (string.IsNullOrEmpty(ds.Tables[7].Rows[itm]["RODTEP_VALUE"].ToString()) ? "0.00" : ds.Tables[7].Rows[itm]["RODTEP_VALUE"].ToString()) + "</RoDTEPAmt>");
                                    xmlContent.AppendLine("<DocDtls>" + " " + "</DocDtls>");
                                    xmlContent.AppendLine("<QuotaDtls>" + " " + "</QuotaDtls>");
                                    xmlContent.AppendLine("<ReExportDtls>" + " " + "</ReExportDtls>");
                                    xmlContent.AppendLine("<JobWorkDtls>" + " " + "</JobWorkDtls>");
                                    xmlContent.AppendLine("<EPCGDetails>" + " " + "</EPCGDetails>");
                                    xmlContent.AppendLine("<DEPBDetails>" + " " + "</DEPBDetails>");
                                    xmlContent.AppendLine("<DEECDetails>");
                                    xmlContent.AppendLine("<AppendixNo>" + " " + "</AppendixNo>");
                                    xmlContent.AppendLine("<ConditionNo>" + " " + "</ConditionNo>");
                                    xmlContent.AppendLine("</DEECDetails>");
                                    xmlContent.AppendLine("<DFRCDetails>" + " " + "</DFRCDetails>");
                                    xmlContent.AppendLine("<DFIADetails>" + " " + "</DFIADetails>");
                                    xmlContent.AppendLine("<DFIADetails_NewStyle>" + " " + "</DFIADetails_NewStyle>");
                                    xmlContent.AppendLine("<SWProdInfos>" + " " + "</SWProdInfos>");
                                    xmlContent.AppendLine("<SWProdConsts>" + " " + "</SWProdConsts>");
                                    xmlContent.AppendLine("<SWProdBatches>" + " " + "</SWProdBatches>");
                                    xmlContent.AppendLine("<SWProdControls>" + " " + "</SWProdControls>");

                                }
                                xmlContent.AppendLine("</Product>");
                                xmlContent.AppendLine("</Products>");

                            }

                        }

                        xmlContent.AppendLine("</InvoiceDetail>");
                        xmlContent.AppendLine("</InvoiceDetails>");

                    }

                    xmlContent.AppendLine("<EPZCode>" + " " + "</EPZCode>");
                    xmlContent.AppendLine("<BankNameAddr>" + " " + "</BankNameAddr>");
                    xmlContent.AppendLine("<BankAccountNo>" + " " + "</BankAccountNo>");
                    xmlContent.AppendLine("<DealerCode>" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ADCODE"].ToString()) ? " " : ds.Tables[0].Rows[0]["ADCODE"].ToString()) + "</DealerCode>");
                    xmlContent.AppendLine("<SB_Footer>" + " " + "</SB_Footer>");
                    xmlContent.AppendLine("<TotalFOBValue>" + (string.IsNullOrEmpty(ds.Tables[21].Rows[0]["FOB_VALUE"].ToString()) ? " " : ds.Tables[21].Rows[0]["FOB_VALUE"].ToString()) + "</TotalFOBValue>");
                    xmlContent.AppendLine("<TotalDBKAmt>" + "0.00" + "</TotalDBKAmt>");
                    xmlContent.AppendLine("<TotalDuty>" + "0.00" + "</TotalDuty>");


                    xmlContent.AppendLine("</SBDocument>");
                    xmlContent.AppendLine("</SBDocuments>");
                    xmlContent.AppendLine("</SBDetails>");

                }
            }
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/xml";
            //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=BEData.xml");

            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=Exp_" + ddlJobNo.SelectedValue.ToString() + ".xml");
            string xmlContentEscaped = xmlContent.ToString().Replace("&", "&amp;");
            HttpContext.Current.Response.Write(xmlContentEscaped);
            //HttpContext.Current.Response.Write(xmlContent.ToString());
            HttpContext.Current.Response.End();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        


    }

    protected void GroupA_Tally_CSV_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
            CHKLIST.Ename = "CSV";
            ds = CHKLIST.Get_Exp_Tally_Data_GropA();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                ExportToCSV(dt, "ExportCSVTemplate.csv");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No data found to export!');", true);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        
    }

    private void ExportToCSV(DataTable dt, string fileName)
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].ColumnName);
                if (i < dt.Columns.Count - 1)
                    sb.Append(",");
            }
            sb.AppendLine();

            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(row[i].ToString().Replace(",", " "));
                    if (i < dt.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();
            }

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
          Connection.Error_Msg(ex.Message);
        }
        
    }
    protected void btnSendApi_Click(object sender, EventArgs e)
    {
        string logPath = @"D:\Logs\ButtonClick.log";

        // Auto-create folder if it doesn't exist
        string logDir = Path.GetDirectoryName(logPath);
        if (!Directory.Exists(logDir))
        {
            Directory.CreateDirectory(logDir);
        }
        try
        {
            File.AppendAllText(logPath, DateTime.Now + " | btnSendApi_Click STARTED" + Environment.NewLine);

            string CID = Session["COMPANY_ID"].ToString();
            string branch = Connection.Current_Branch();
            string jobNo = Connection.EXP_Jobno();

            File.AppendAllText(logPath, DateTime.Now + " | CID=" + CID + " branch=" + branch + " jobNo=" + jobNo + Environment.NewLine);

            string errorFolder = Server.MapPath("~/Submission/" + CID + "/" + branch + "/EXP_Job_history/");
            string fileName = "ExpJob_" + jobNo + ".pdf";
            string filePath = errorFolder + fileName;

            File.AppendAllText(logPath, DateTime.Now + " | filePath=" + filePath + Environment.NewLine);

            // FIX: check actual file existence, not just string emptiness
            if (File.Exists(filePath))
            {
                File.AppendAllText(logPath, DateTime.Now + " | File exists. Calling API..." + Environment.NewLine);

                string result = Checklist_Api_Send.SendAttachmentToApi(filePath, CID, jobNo);

                File.AppendAllText(logPath, DateTime.Now + " | API result: " + result + Environment.NewLine);

                // FIX: check result before showing success message
                if (result != null && result.Contains("jobNumber"))
                {
                    // success — server returned expected JSON
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                        "alert('API Upload Completed');", true);
                }
                else
                {
                    // API call failed / returned error text
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                        "alert('API Upload Failed: " + result.Replace("'", "").Replace("\n", " ").Replace("\r", "") + "');", true);
                }
            }
            else
            {
                File.AppendAllText(logPath, DateTime.Now + " | ERROR: File does not exist at path." + Environment.NewLine);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg",
                    "alert('Checklist file not found');", true);
            }

            File.AppendAllText(logPath, DateTime.Now + " | btnSendApi_Click ENDED" + Environment.NewLine);
        }
        catch (Exception ex)
        {
            File.AppendAllText(logPath, DateTime.Now + " | EXCEPTION: " + ex.ToString() + Environment.NewLine);
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void btnSendjson_Click(object sender, EventArgs e)
    {
        try
        {
            CommonAPI.CommonAPI_basedonCompanies(COMPANY_ID, ddlJobNo.SelectedValue.ToString(), "E");
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Check_Duplicate_Invoice_OnLoad()
    {
        try
        {
            if (ddlJobNo.SelectedValue != "Select" && ddlJobNo.SelectedValue != "")
            {
                CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                CHKLIST.Ename = "Export_Duplicate_Invoice_Chk";
                CHKLIST.Workingperiod = SELECT_BRANCH;

                DataSet ds = new DataSet();
                ds = CHKLIST.RetrieveAll_General_Details();

                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return;   // no duplicate - stay silent

                // ---- flatten EXISTS_IN_JOBNO across all invoice rows into one distinct job list ----
                List<string> allJobs = new List<string>();
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    string existsIn = r["EXISTS_IN_JOBNO"].ToString().Trim();
                    if (existsIn == "") continue;

                    string[] jobArr = existsIn.Split(',');
                    foreach (string jb in jobArr)
                    {
                        string job = jb.Trim();
                        if (job != "" && !allJobs.Contains(job))
                            allJobs.Add(job);
                    }
                }

                if (allJobs.Count == 0) return;

                string jobStr = "";
                foreach (string j in allJobs)
                    jobStr += (jobStr == "" ? "" : ", ") + "'" + j + "'";

                // ---- SHORT message - matches your screenshot exactly, no "LOCKED" wording ----
                string msg = "This Invoice Number Already Exists in Job No - " +
                             "<span style='color:red;font-weight:bold;'>" + jobStr + "</span>";

                Show_duplicate_Popup("Duplicate Invoice No", msg);
            }
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog("Check_Duplicate_Invoice_OnLoad (Export): " + ex.Message);
        }
    }

    private void Show_duplicate_Popup(string title, string htmlMsg)
    {
        string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
                        ? Session["Theme"].ToString().ToLower()
                        : "orange";

        string gradTop, gradBot;
        switch (theme)
        {
            case "blue": gradTop = "#4a90e2"; gradBot = "#2b6cb0"; break;
            case "dblue": gradTop = "#2c3e60"; gradBot = "#16213a"; break;
            case "green": gradTop = "#43a047"; gradBot = "#2e7d32"; break;
            case "bluefancy": gradTop = "#5b86e5"; gradBot = "#36d1dc"; break;
            case "violetfancy": gradTop = "#8e2de2"; gradBot = "#4a00e0"; break;
            default: gradTop = "#f5a623"; gradBot = "#e08e0b"; break;
        }

        string t = (title ?? "").Replace("\\", "\\\\").Replace("'", "\\'");
        string m = (htmlMsg ?? "").Replace("\\", "\\\\").Replace("'", "\\'")
                                  .Replace("\r", "").Replace("\n", "");

        string js = @"
(function () {
    var old = document.getElementById('cstm_pop_ovl');
    if (old) old.parentNode.removeChild(old);
    var gradTop = '" + gradTop + @"'; var gradBot = '" + gradBot + @"';
    var ovl = document.createElement('div');
    ovl.id = 'cstm_pop_ovl';
    ovl.style.cssText = 'position:fixed;top:0;left:0;width:100%;height:100%;background:rgba(0,0,0,.50);z-index:999998;display:flex;align-items:center;justify-content:center;';
    var box = document.createElement('div');
    box.style.cssText = 'width:460px;max-width:94vw;background:#fff;border-radius:8px;z-index:999999;box-shadow:0 8px 32px rgba(0,0,0,.40);font-family:Segoe UI,Tahoma,Arial,sans-serif;font-size:13px;color:#2d3436;display:flex;flex-direction:column;max-height:85vh;overflow:hidden;';
    box.innerHTML =
        '<div style=""background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;font-weight:700;font-size:14px;padding:10px 16px;flex-shrink:0;"">' + '" + t + @"' + '</div>' +
        '<div style=""padding:16px 18px;line-height:1.55;overflow:auto;flex:1;"">' + '" + m + @"' + '</div>' +
        '<div style=""padding:10px 14px;text-align:center;border-top:1px solid #eee;flex-shrink:0;"">' +
            '<button type=""button"" id=""cstm_pop_ok"" style=""min-width:88px;height:30px;background:linear-gradient(' + gradTop + ',' + gradBot + ');color:#fff;border:0;border-radius:5px;font-weight:600;cursor:pointer;"">OK</button></div>';
    ovl.appendChild(box);
    document.body.appendChild(ovl);
    document.getElementById('cstm_pop_ok').onclick = function () {
        var el = document.getElementById('cstm_pop_ovl');
        if (el) el.parentNode.removeChild(el);
    };
})();";

        ScriptManager.RegisterStartupScript(this, GetType(),
            "cstmPop_" + Guid.NewGuid().ToString("N"), js, true);
   }



}