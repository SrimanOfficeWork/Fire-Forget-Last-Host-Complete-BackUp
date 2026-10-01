using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;
using System.Xml;
using System.Text;

public partial class Transaction_Default2 : ThemeClass
{
    AppSession aps = new AppSession();
    CheckList chklist = new CheckList();
  
    DataSet ds = new DataSet();  
    adminmaster adm = new adminmaster();
    DataSet dt_All_Rates = new DataSet(); 
    DataTable dt_empty = new DataTable();

    public string grid_show_status = "";
    public string SELECT_BRANCH;
    public string COMPANY_ID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession_Subfolder();
        SELECT_BRANCH = Connection.Get_Company_Type();
        COMPANY_ID = Connection.COMPANYID();
        //hdn_Branch.Value = Connection.Current_Branch();
        hdn_Branch.Value = SELECT_BRANCH;
        Page_load();
    }

    public void Page_load()
    {
        try
        {
            hdn_div.Value = "hi";
           // ddlJobNo.Focus();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["jobno"]))
                {
                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("sidebar");
                    currdiv.Style.Add("display", "none");

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv1 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("innerbox_Main_Top_User");
                    currdiv1.Style.Add("display", "none");

                    System.Web.UI.HtmlControls.HtmlGenericControl currdiv2 = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("maincontent");
                    currdiv2.Style.Add("margin", "-16px 2px 0 0");
                    currdiv2.Style.Add("padding", "2px 0 0");

                    ddlJobNo.Items.Clear();
                    ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                    ddlJobNo.SelectedIndex = 0;

                    Import_Default_Entry.Post_Data(ddlJobNo.SelectedValue.ToString(), "CDRUG_Entry");
                }
                else
                {
                    
                    chklist.JOBNo = "";
                    chklist.Ename = "select_jobno";
                    chklist.Workingperiod = SELECT_BRANCH;

                    ddlJobNo.DataSource = chklist.RetrieveAll_General_Details();
                    ddlJobNo.DataValueField = "JOBNO";
                    ddlJobNo.DataTextField = "JOBNO_PS";
                    ddlJobNo.DataBind();
                    ddlJobNo.Items.Remove("0");
                    ddlJobNo.Items.Insert(0, "Select");
                }

                txtCustomHouse.Attributes.Add("readonly", "readonly");
                txtImporterName.Attributes.Add("readonly", "readonly");
                txtBE_Type.Attributes.Add("readonly", "readonly");
                txtSupplier.Attributes.Add("readonly", "readonly");
                txtNoofItems.Attributes.Add("readonly", "readonly");
                txtNoofInvoices.Attributes.Add("readonly", "readonly");

                //if (String.IsNullOrEmpty(Session["BE_No"].ToString()))
                //{
                //    //btn_Update_newRates.Enabled = true;
                //    btn_Update_newRates.Visible = true;

                //}

                /* Paramount Payment Pending - hide by Sathish
                if (COMPANY_ID == "1" || COMPANY_ID == "293")
                {
                    btn_WorkSheet.Visible = false;
                    btn_worksheet_All.Visible = true;
                }
                else
                {
                    btn_WorkSheet.Visible = true;
                    btn_worksheet_All.Visible = false;
                }
                 * */
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        dt_empty.Columns.Add("NOTN_TYPE");
        dt_empty.Columns.Add("NOTN_NO");
        dt_empty.Columns.Add("NOTN_SLNO");
        dt_empty.Columns.Add("CTH_NO");
        dt_empty.Columns.Add("SLNO");

        
        Bind_Checklist_Details();
       

        if (Session["COMPANY_ID"].ToString() == "247" || Session["COMPANY_ID"].ToString() == "268" || Session["COMPANY_ID"].ToString() == "194")
        {
            btn_WorkSheet.Visible = true;
        }
        if (Session["COMPANY_ID"].ToString() == "480" || Session["COMPANY_ID"].ToString() == "10" )
        {
            btnexcel.Visible = true;
        }
        if (Session["COMPANY_ID"].ToString() == "499" || Session["COMPANY_ID"].ToString() == "4" || Session["COMPANY_ID"].ToString() == "1")
        {
            //div_ChklistFontBased.Visible = true;
            btnChklistFontBased.Visible = true;
        }
        
        if (!IsPostBack)
        {
            try
            {
                if (ddlJobNo.SelectedItem.ToString() != "Select")
                {

                    if (Connection.e_lOGIX_CHENNAI() != string.Empty)
                    {
                       /* UserBO ObjUBO = new UserBO();
                        E_LOGIX ES = new E_LOGIX();

                        DataSet dss = new DataSet();

                        ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
                        ObjUBO.Ename = "S";
                        ObjUBO.flag = "Data_Sent_Update";
                        ObjUBO.File_Type = "I";
                        dss = ES.Select_IMP_EXP_INVO_SYS(ObjUBO);
                        if (dss.Tables.Count > 0)
                        {
                            IMPL_CHENNAI.ELogiX obj = new IMPL_CHENNAI.ELogiX();
                            DataSet E_ds = new DataSet();
                            E_ds = obj.ELogiXImportData(dss);

                            if (E_ds.Tables[0].Rows.Count > 0)
                            {
                                ObjUBO.JOBNO = E_ds.Tables[0].Rows[0]["JOBNO"].ToString();
                                ObjUBO.Ename = E_ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                                ObjUBO.flag = "File_Refno_Update";
                                ObjUBO.File_Type = "I";
                                ES.Select_IMP_EXP_INVO_SYS(ObjUBO);
                            }
                        }*/
                    }
                    else
                    {
                        Chk_Elogix_Service();
                    }
                    Connection.I_Fact(ddlJobNo.SelectedValue.ToString(), "I");
                    Connection.Ryal_Data(ddlJobNo.SelectedValue.ToString(), "I");

                    if (COMPANY_ID == "2814" || COMPANY_ID == "3082")
                    {
                        API_Post_Data ebms = new API_Post_Data();
                        ebms.CheckList_API_Post(ddlJobNo.SelectedValue.ToString(), Connection.WorkingPeriod(), "I", "JSON", Connection.Current_Branch());
                    }
                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        if (COMPANY_ID == "861" || COMPANY_ID == "880" || COMPANY_ID == "1317")
                        {
                            Div_ICode.Visible = true;
                        }
                    }
                    /*
                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        DataSet dss = new DataSet();
                        if (COMPANY_ID == "861" || COMPANY_ID == "880")
                        {
                            ICode_CS IC = new ICode_CS();
                           dss= IC.Get_ICode_Jobno_Select(ddlJobNo.SelectedValue.ToString(), "I", "Royal_Data", "", COMPANY_ID);
                           if (dss.Tables[0].Rows.Count > 0)
                           {
                               I_Code.ERoyal obj = new I_Code.ERoyal();
                               obj.ERoyal_Import(dss);

                               //DataSet I_ds = new DataSet();
                               //obj.ERoyal_Import(dss);
                               //if (I_ds.Tables[0].Rows.Count > 0)
                               //{
                               //    IC.Get_ICode_Jobno_Select(I_ds.Tables[0].Rows[0]["Jobno"].ToString(), "I", "Royal_Data_Sent_Completed", "", COMPANY_ID);
                               //}
                             
                           }

                        }
                    }
                    */
                }
            }
            catch (Exception ex)
            {
                Connection.Error_Msg(ex.Message);
            }
        }       
    }

    private void Chk_Elogix_Service()
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
            ObjUBO.File_Type = "I";
            ObjUBO.flag = "Sent_Data_Chk";

            if (E_Logix_Company_Id_Chennai != string.Empty)
            {
                E_LOGIX ES = new E_LOGIX();
                dds = ES.Select_IMP_EXP_INVO_SYS(ObjUBO);
            }
            else if (E_Logix_Company_Id_Mumbai != string.Empty)
            {
                E_LOGIX_MUMBAI ES = new E_LOGIX_MUMBAI();
                dds = ES.Select_IMP_EXP(ObjUBO);
            }
            //dds = ES.Select_IMP_EXP(ObjUBO);

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

   
    protected void gv_RITC_RowCreated(object sender, GridViewRowEventArgs e)
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

   

    protected void gv_NOTN_RowCreated(object sender, GridViewRowEventArgs e)
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

    protected void gv_NOTN_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       // gv_RITC.PageIndex = e.NewPageIndex;
    }

    
    public void Bind_Checklist_Details()
    {
        try
        {
            if (ddlJobNo.Text.ToString() != "Select")
            {
                DataSet d_s = new DataSet();
                string C_id = string.Empty;
                C_id = Connection.COMPANYID();
                //if (C_id == "293" || C_id == "4") 
                //{
                //  Imp_Checklist IC =new Imp_Checklist();
                //  d_s = IC.GetData(ddlJobNo.SelectedValue.ToString(), "", "Checklist_NOTN_Chk_Paramount");
                //  if (d_s.Tables[0].Rows.Count > 0)
                //  {
                //      lbl_Chk_Error.Visible = true;
                //      btnSearch.Visible = false;
                //      lblcnt.Text = d_s.Tables[0].Rows.Count.ToString();
                //  }
                //  else
                //  {
                //      lbl_Chk_Error.Visible = false;
                //      btnSearch.Visible = true;
                //  }
                //}

                //if (C_id == "164" || C_id == "10")
                //{
                //    Imp_Checklist IC = new Imp_Checklist();
                //    d_s=IC.GetData(ddlJobNo.SelectedValue.ToString(), "", "Checklist_NOTN_Chk_Skylift");
                //    if (d_s.Tables[0].Rows.Count > 0)
                //    {
                //        lbl_Chk_Error.Visible = true;
                //        btnSearch.Visible = false;
                //        lblcnt.Text = d_s.Tables[0].Rows.Count.ToString();
                //    }
                //    else
                //    {
                //        lbl_Chk_Error.Visible = false;
                //        btnSearch.Visible = true;
                //    }
                //}
                //else
                //{
                //    lbl_Chk_Error.Visible = false;
                //    btnSearch.Visible = true;
                //}
            }

            chklist.JOBNo = ddlJobNo.SelectedValue.ToString();
            chklist.Ename = "select_jobno_CheckList";
            chklist.Workingperiod = SELECT_BRANCH;
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtCustomHouse.Text = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();
                txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txtBE_Type.Text = ds.Tables[0].Rows[0]["BE_TYPE"].ToString();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txtSupplier.Text = ds.Tables[1].Rows[0]["SUPPLIER_NAME"].ToString();
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


                    if (ds.Tables[4].Rows.Count > 0)// Check BE_No Avail
                    {
                        hdn_BE_Y_N.Value = "Yes";
                        if (ds.Tables[7].Rows.Count > 0)// Check Amendment Avail
                        {
                            hdn_Amend_Y_N.Value = "Yes";
                        }
                        else
                        {
                            hdn_Amend_Y_N.Value = "No";
                        }
                    }
                    else
                    {
                        if (ds.Tables[5].Rows.Count > 0 && ds.Tables[6].Rows.Count > 0)//5-New job null count, 6-old job null count
                        {
                            hdn_BE_Y_N.Value = "No";
                        }
                        else if (ds.Tables[5].Rows.Count > 0 && ds.Tables[6].Rows.Count == 0)
                        {
                            hdn_BE_Y_N.Value = "Yes";
                        }
                        else
                        {
                            hdn_BE_Y_N.Value = "No";
                        }
                    }
                }
                else
                {
                    txtSupplier.Text = "";
                    txtNoofItems.Text = "";
                    txtNoofInvoices.Text = "";
                }
               
               /*
                General_Details Import_General = new General_Details();
                Import_General.Retrieve_GetGeneral(ddlJobNo.SelectedValue.ToString());
              */

              
            }
            else
            {
                txtCustomHouse.Text = "";
                txtImporterName.Text = "";
                txtBE_Type.Text = "";
                txtSupplier.Text = "";
                txtNoofItems.Text = "";
                txtNoofInvoices.Text = "";
            }
        }
        catch (Exception ex)
        {
        }
    }




    protected void btn_Elogix_Click(object sender, EventArgs e)
    {
        try
        {
            string Job_Type = string.Empty;

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
                ObjUBO.File_Type = "I";

                if (E_Logix_Company_Id_Chennai != string.Empty)
                {
                    E_LOGIX ES = new E_LOGIX();
                    //dss = ES.Select_IMP_EXP(ObjUBO);
                    dss = ES.Select_IMP_EXP_INVO_SYS(ObjUBO);
                }
                else if (E_Logix_Company_Id_Mumbai != string.Empty)
                {
                    E_LOGIX_MUMBAI ES = new E_LOGIX_MUMBAI();
                    dss = ES.Select_IMP_EXP(ObjUBO);
                }
                if (dss.Tables[0].Rows.Count > 0)
                {
                    btn_Elogix.Visible = true;
                    lbl_Msg.Text = string.Empty;

                    if (E_Logix_Company_Id_Chennai != string.Empty)
                    {
                        //-----------------------

                    }
                    else if (E_Logix_Company_Id_Mumbai != string.Empty)
                    {
                        IMPL_MUMBAI.ELOGIX_CS obj = new IMPL_MUMBAI.ELOGIX_CS();
                        obj.ImportPlanning(
                                dss.Tables[0].Rows[0]["JOBNO_PS"].ToString()
                               , dss.Tables[0].Rows[0]["JOBDATE"].ToString()
                               , dss.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString()
                               , dss.Tables[0].Rows[0]["BRANCH_NO"].ToString()
                               , dss.Tables[0].Rows[0]["IEC_NO"].ToString()
                               , dss.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_NO"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_DATE"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_MAWB_MBL"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_MAWB_MBLDATE"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_HAWB_HBLNO"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_HAWB_HBLDATE"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_NOOFPACKAGE"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_PACKAGETYPE"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_GROSSWEIGHT"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_TYPEOFWEIGHT"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_FLIGHT_VESSELDATE"].ToString()
                               , dss.Tables[0].Rows[0]["INVOICE_NO"].ToString()
                               , dss.Tables[0].Rows[0]["INVOICE_DATE"].ToString()
                               , dss.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString()
                               , dss.Tables[0].Rows[0]["INVOICE_VALUE"].ToString()
                               , E_Logix_Company_Id_Mumbai
                               , dss.Tables[0].Rows[0]["ITEM_DESCRIPTION"].ToString()
                               , ""
                               , ""
                               , dss.Tables[0].Rows[0]["WORKINGPERIOD"].ToString()
                               , Job_Type
                               , dss.Tables[0].Rows[0]["IGM_LINE_NUMBER"].ToString()
                               , dss.Tables[0].Rows[0]["Type_of_Shipment"].ToString()
                               , dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString()
                               , dss.Tables[0].Rows[0]["BE_NO"].ToString()
                               , dss.Tables[0].Rows[0]["BE_DATE"].ToString()
                               , dss.Tables[0].Rows[0]["CONTAINER_NO"].ToString()
                               , dss.Tables[0].Rows[0]["PORT_ORIGIN"].ToString()
                               , dss.Tables[0].Rows[0]["PORT_SHIPMENT"].ToString()
                               , dss.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString()

                               , dss.Tables[0].Rows[0]["COUNTRY_ORIGIN"].ToString()
                               , dss.Tables[0].Rows[0]["COUNTRY_SHIPMENT"].ToString()
                               , dss.Tables[0].Rows[0]["TERMS"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_AIRLINENAME"].ToString()

                               , dss.Tables[0].Rows[0]["IGM_FLIGHTNO_VESSELNO"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_SHIPPING_LINE_NUMBER"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_MARKSNOS"].ToString()
                               , dss.Tables[0].Rows[0]["IGM_VOYAGE"].ToString()
                               , dss.Tables[0].Rows[0]["SEAL_NO"].ToString()
                               , dss.Tables[0].Rows[0]["TYPE"].ToString()
                               , dss.Tables[0].Rows[0]["THIRDPARTY_NAME"].ToString()
                               , dss.Tables[0].Rows[0]["SCHEME_CODE"].ToString()

                               , dss.Tables[0].Rows[0]["USERID"].ToString()
                               , dss.Tables[0].Rows[0]["JOBNO"].ToString()
                               , dss.Tables[0].Rows[0]["MULTIPLE_CONTAINER_NO"].ToString()
                               , dss.Tables[0].Rows[0]["ASS_VALUE"].ToString()
                               , dss.Tables[0].Rows[0]["DUTY_VALUE"].ToString()

                               );
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

    //------------------------ FTA ---------------------------


    [System.Web.Services.WebMethod]
    public static int btn_Update_newRates_Checklist(string Jobno)
    {
        CheckList chklist = new CheckList();
        DataTable distinctValues = new DataTable();
        //chklist.JOBNo = ddlJobNo.SelectedValue.ToString();
        chklist.JOBNo = Jobno;
        chklist.Ename = "Update_CurrentRate_Checklistnew";

        //chklist.Workingperiod = SELECT_BRANCH;
        chklist.Workingperiod = HttpContext.Current.Session["currentbranch"].ToString(); 
        DataSet ds = new DataSet();
        ds = chklist.RetrieveAll_General_Details();
        int result = chklist.result;

        return result;
    }
    protected void btn_ICode_Click(object sender, EventArgs e)
    {
        DataSet dss = new DataSet();
         ICode_CS IC = new ICode_CS();
         dss= IC.Get_ICode_Jobno_Select(ddlJobNo.SelectedValue.ToString(), "I", "Royal_Data", "", COMPANY_ID);
         if (dss.Tables[0].Rows.Count > 0)
            {
                I_Code.ERoyal obj = new I_Code.ERoyal();
                obj.ERoyal_Import(dss);
            }
    }
    protected void btn_chklist_Validation_Click(object sender, EventArgs e)
    {
        //Validate_Checklist();
    }

    //private void Validate_Checklist()
    //{
    //    GET_ALL_NOTIFICATIONS_RATE();
    //    BIND_FTA_NOTN_COO_MISMATCH_DETAILS();

    //    if (Connection.COMPANYID() == "125")
    //    {
    //        BIND_IGST_NOTN_SLNO_FOR_FAIRMACS();
    //    }
    //}
}
    

