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
using ClosedXML.Excel;
using System.Data.OleDb;
using Aspose.Pdf;
using Aspose.Pdf.Devices;


public partial class Import_CheckList_JOB : ThemeClass
{
    AppSession aps = new AppSession();
    CheckList chklist = new CheckList();
    ErrorLogs er = new ErrorLogs();
    DataSet ds = new DataSet();
    adminmaster adm = new adminmaster();
    DataSet dt_All_Rates = new DataSet();
    public string SELECT_BRANCH, IMPORT_JOBNO = "", fileName;
    public string COMPANY_ID = string.Empty;
    private string _currentBENo = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            btnOutlook.Style["display"] = "none";
            aps.checkSession_Subfolder();
            SELECT_BRANCH = Connection.Get_Company_Type();
            COMPANY_ID = Connection.COMPANYID();
            IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
            hdn_Jobno.Value = IMPORT_JOBNO;
            //hdn_Branch.Value = Connection.Current_Branch();
            hdn_Branch.Value = SELECT_BRANCH;

            Page_load();
            AssableDutySetion.Style["display"] = "none";
            if (COMPANY_ID == "1" || COMPANY_ID == "293" || COMPANY_ID == "3352" || COMPANY_ID == "10")
            {
                AssableDutySetion.Style["display"] = "block ruby";
                btnOutlook.Style["display"] = "initial";
                DutyandAssesableValueChecking();

            }

        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    public void Page_load()
    {
        try
        {
            if (!IsPostBack)
            {

                ddlJobNo.Items.Clear();
                //ddlJobNo.Items.Insert(0, new ListItem(Request["jobnops"].ToString(), Request["jobno"].ToString()));
                ddlJobNo.Items.Insert(0, new ListItem(Session["JOBNO_PS"].ToString(), Session["IMPORT_JOBNO"].ToString()));
                ddlJobNo.SelectedIndex = 0;
                ddlJobNo.SelectedValue = Session["IMPORT_JOBNO"].ToString();
                //HiddenField1.Value = Session["IMPORT_JOBNO"].ToString();

                Import_Default_Entry.Post_Data(ddlJobNo.SelectedValue.ToString(), "CDRUG_Entry");
                Import_Default_Entry.Post_Data(ddlJobNo.SelectedValue.ToString(), "AQCS_Entry");
                if (COMPANY_ID == "10" || COMPANY_ID == "1" || COMPANY_ID == "293")// Added by Pandiyan on 07-09-2026
                {
                    Import_Default_Entry.Post_Data(ddlJobNo.SelectedValue.ToString(), "FTA_Certificate_Entry_In_Igm_Certificate");
                }
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        Bind_Checklist_Details();

        string theme = (Session["Theme"] != null && Session["Theme"].ToString() != "")
          ? Session["Theme"].ToString().ToLower()
          : "orange";

        ScriptManager.RegisterStartupScript(this, this.GetType(),
           "setTheme",
           "var PAGE_THEME = '" + theme + "';",
           true);

        Check_Duplicate_Invoice_OnLoad();


        if (COMPANY_ID == "10" || COMPANY_ID == "2145")
        {
            DateTime opentime = DateTime.Now;
            DateTime closingtime = opentime.AddMinutes(15);

            DataSet ds_User_st = new DataSet();
            ds_User_st = Common_CS.Get_Job_User_Lock_Status(Session["IMPORT_JOBNO"].ToString(), Connection.Current_User(), Convert.ToString(opentime), Convert.ToString(closingtime), "Insert_User_History", "Import");
        }


        if (COMPANY_ID == "480" || COMPANY_ID == "10")
        {
            btnexcel.Visible = true;
        }
        if (COMPANY_ID == "3352" || COMPANY_ID == "499" || COMPANY_ID == "4" || COMPANY_ID == "1")
        {
            //div_ChklistFontBased.Visible = true;
            btnChklistFontBased.Visible = true;
        }
        if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "2145" || COMPANY_ID == "2868" || COMPANY_ID == "2935" || COMPANY_ID == "3352")
        {
            btnXmlChecklist.Visible = true;
        }

        if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "537" || COMPANY_ID == "3352")
        {
            SDF_Type.Visible = true;
            btnSDFformat.Visible = true;
        }

        if (COMPANY_ID == "576" || COMPANY_ID == "3267")
        {
            import_CSV.Visible = true;
        }


        /*
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
                    if (Connection.Freight_Forward() != string.Empty)
                    {
                        if (COMPANY_ID == "816" || COMPANY_ID == "861" || COMPANY_ID == "880" || COMPANY_ID == "1317" || COMPANY_ID == "3149" || COMPANY_ID == "3266")
                        {
                            Div_ICode.Visible = true;
                        }
                    }


                    //common call to all Apis
                    var excludedCompanies = new List<string> { "861", "3149", "3266" };

                    if (!excludedCompanies.Contains(COMPANY_ID))
                    {
                        String JobNo = ddlJobNo.SelectedValue.ToString();
                        string IEtype = "I";
                        CommonAPI.CommonAPI_basedonCompanies(COMPANY_ID, JobNo, IEtype);
                    }

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
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
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
            er.makeLog(ex.Message);
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
        int result = 0;
        try
        {
            CheckList chklist = new CheckList();
            DataTable distinctValues = new DataTable();
            chklist.JOBNo = Jobno;
            chklist.Ename = "Update_CurrentRate_Checklistnew";
            chklist.Workingperiod = HttpContext.Current.Session["currentbranch"].ToString();
            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();
            result = chklist.result;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return result;
    }

    protected void btn_ICode_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dss = new DataSet();
            ICode_CS IC = new ICode_CS();
            dss = IC.Get_ICode_Jobno_Select(ddlJobNo.SelectedValue.ToString(), "I", "Royal_Data", "", COMPANY_ID);
            if (dss.Tables[0].Rows.Count > 0)
            {
                I_Code.ERoyal obj = new I_Code.ERoyal();
                obj.ERoyal_Import(dss);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    protected void gv_INVOICENO_RowCreated(object sender, GridViewRowEventArgs e)
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
            er.makeLog(ex.Message);
        }
    }
    protected void btnSDFformat_Click(object sender, EventArgs e)
    {
        try
        {
            string JOBNo = ddlJobNo.SelectedItem.Text;
            chklist.JOBNo = ddlJobNo.SelectedValue.ToString();
            if (ddlsdftype.SelectedValue == "BOE")
            {
                chklist.Ename = "SDF_BOE";
                fileName = "FINALBOE.sdf";
            }
            else if (ddlsdftype.SelectedValue == "CLR1")
            {
                chklist.Ename = "SDF_CLR1";
                fileName = "FINALCLR1.sdf";
            }
            else if (ddlsdftype.SelectedValue == "CLR2")
            {
                chklist.Ename = "SDF_CLR2";
                fileName = "FINALCLR2.sdf";
            }

            chklist.Workingperiod = SELECT_BRANCH;
            ds = chklist.RetrieveAll_General_Details_SDF();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExportAsSDFText(ds.Tables[0], JOBNo + fileName);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }
    //private void ExportAsSDFText(DataTable table,string fileName)
    //{
    //    Response.Clear();
    //    Response.ContentType = "text/plain";
    //    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
    //    int columnWidth = 15;
    //    using (StringWriter sw = new StringWriter())
    //    {
    //        foreach (DataRow row in table.Rows)
    //        {
    //            List<string> fields = new List<string>();
    //            foreach (var item in row.ItemArray)
    //            {
    //                string fieldValue = item == null ? "" : item.ToString().Trim();
    //                fields.Add(fieldValue.PadRight(columnWidth));
    //            }
    //            sw.WriteLine(string.Join("\t", fields));
    //        }
    //        Response.Write(sw.ToString());
    //        Response.End();
    //    }
    //}
    private void ExportAsSDFText(DataTable table, string fileName)
    {
        try
        {
            Response.Clear();
            Response.ContentType = "text/plain";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

            using (StringWriter sw = new StringWriter())
            {
                foreach (DataRow row in table.Rows)
                {
                    List<string> fields = new List<string>();

                    foreach (var item in row.ItemArray)
                    {
                        string fieldValue = item == null ? "" : item.ToString().Trim();
                        fields.Add(fieldValue);

                    }

                    sw.WriteLine(string.Join("\t", fields));
                }

                Response.Write(sw.ToString());
                Response.End();
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }


    protected void GroupA_Tally_CSV_Click(object sender, EventArgs e)
    {
        try
        {
            chklist.JOBNo = IMPORT_JOBNO;
            chklist.Ename = "CSV";
            ds = chklist.Get_Imp_Tally_Data_GropA();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                ImportToCSV(dt, "IMPORTCSVTEMPLATE.csv");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No data found to export!');", true);
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    private void ImportToCSV(DataTable dt, string fileName)
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
            er.makeLog(ex.Message);
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
            string jobNo = Connection.IMP_Jobno();

            File.AppendAllText(logPath, DateTime.Now + " | CID=" + CID + " branch=" + branch + " jobNo=" + jobNo + Environment.NewLine);

            string errorFolder = Server.MapPath("~/Submission/" + CID + "/" + branch + "/IMP_Job_history/");
            string fileName = "ImpJob_" + jobNo + ".pdf";
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
            String JobNo = ddlJobNo.SelectedValue.ToString();
            string IEtype = "I";

            string result = CommonAPI.CommonAPI_basedonCompanies(COMPANY_ID, JobNo, IEtype);

            if (!string.IsNullOrEmpty(result) && result.Contains("\"success\": true"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('JSON File Uploaded Successfully');",
                    true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('API Error');",
                    true);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void HideAllBlock()
    {
        IcegateAssBlock.Style["display"] = "none";
        IcegateDutyBlock.Style["display"] = "none";
        TotalAssValueBlock.Style["display"] = "none";
        TotalDutyValueBlock.Style["display"] = "none";
    }
    public void DutyandAssesableValueChecking()
    {
        decimal dbAssessable = 0;
        decimal dbDutyValue = 0;
        decimal ocrAssessable = 0;
        decimal ocrDuty = 0;
        decimal bondamount = 0;
        DataTable bonddetails = new DataTable();

        DataTable dt = new DataTable();
        dt.Columns.Add("BOND_NO");
        dt.Columns.Add("BOND_AMT");
        dt.Columns.Add("ICEGATE_BOND_AMT");

        try
        {
            string pdfPath = GetBE_FirstPagePdfPath();
            ViewState["pdfPath"] = pdfPath;
            if (string.IsNullOrEmpty(pdfPath))
            {
                HideAllBlock();
                return;
            }

            bool isValueFound = false;
            string Currentbranch = Connection.Current_Branch();
            DataSet cacheDs = GetCachedOCRValues(IMPORT_JOBNO, Currentbranch, _currentBENo);

            if (cacheDs != null && cacheDs.Tables.Count > 0 && cacheDs.Tables[0].Rows.Count > 0)
            {
                // Load from cache — skip OCR
                DataRow cacheRow = cacheDs.Tables[0].Rows[0];
                decimal.TryParse(cacheRow["ICEGATE_TOT_ASS_VALUE"].ToString(), out ocrAssessable);
                decimal.TryParse(cacheRow["ICEGATE_TOT_DUTY_VALUE"].ToString(), out ocrDuty);

                // Load bond details from cache into bonddetails DataTable
                bonddetails.Columns.Add("BOND_NO");
                bonddetails.Columns.Add("DEBIT_AMT");

                if (cacheDs.Tables.Count > 1)
                {
                    foreach (DataRow br in cacheDs.Tables[1].Rows)
                    {
                        bonddetails.Rows.Add(
                            br["BOND_NO"].ToString(),
                            br["ICEGATE_TOT_BOND_VALUE"].ToString()
                        );
                    }
                }

                isValueFound = true;
            }

            // ── Step B: If no cache → run OCR and save to DB ─────────────────
            if (!isValueFound)
            {
                var ocrValues = ReadTotAssVal_Dynamically();
                if (ocrValues == null) { HideAllBlock(); return; }

                ocrDuty = ocrValues.Item1;
                ocrAssessable = ocrValues.Item2;
                bondamount = ocrValues.Item3;
                bonddetails = ocrValues.Item4;

                // Save header values to DB
                InsertOCRHeader(IMPORT_JOBNO, _currentBENo, Connection.Current_Branch(), ocrAssessable.ToString(), ocrDuty.ToString());

                // Save each bond to DB
                foreach (DataRow br in bonddetails.Rows)
                {
                    InsertOCRBond(IMPORT_JOBNO, _currentBENo, Connection.Current_Branch(), br["BOND_NO"].ToString(), br["DEBIT_AMT"].ToString());
                }
            }





            if (ocrAssessable <= 0 && ocrDuty <= 0)
            {
                HideAllBlock();
                return;
            }

            Transaction Transact = new Transaction();
            Transact.JOBNO = ddlJobNo.SelectedValue.Trim();
            Transact.WORKING_PERIOD = SELECT_BRANCH;
            Transact.Ename = "select_Assable_Val";

            DataSet ds = Transact.RetrieveAll_General_Details();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                decimal.TryParse(dr["TOTAL_ASSESSABLE_VALUE"].ToString(), out dbAssessable);
                decimal.TryParse(dr["TOTAL_DUTY_VALUE"].ToString(), out dbDutyValue);
            }

            IcegateAssBlock.Style["display"] = "block";
            IcegateDutyBlock.Style["display"] = "block";
            TotalAssValueBlock.Style["display"] = "block";
            TotalDutyValueBlock.Style["display"] = "block";

            txtIcegateAssvalue.Text = ocrAssessable.ToString("0.00");   // PDF OCR
            txtIcegateDutyValue.Text = ocrDuty.ToString("0.00");         // PDF OCR
            txtTotalAssValue.Text = dbAssessable.ToString("0.00");     // DB value
            txtTotalDutyValue.Text = dbDutyValue.ToString("0.00");

            txtIcegateAssvalue.CssClass = "valueBox";
            txtIcegateDutyValue.CssClass = "valueBox";
            txtTotalAssValue.CssClass = "valueBox";
            txtTotalDutyValue.CssClass = "valueBox";

            msgWrapper.Style["display"] = "none";
            lblDutyValue1.Style["display"] = "none";
            lblAssessvalue1.Style["display"] = "none";
            Span3.Style["display"] = "none";

            if (Math.Abs(dbAssessable - ocrAssessable) < 1m)
            {
                txtIcegateAssvalue.CssClass += " greenShadow";
                txtTotalAssValue.CssClass += " greenShadow";


            }
            else
            {
                txtIcegateAssvalue.CssClass += " redShadow";
                txtTotalAssValue.CssClass += " redShadow";


            }

            msgWrapper.Style["display"] = "inline-block";  // show assess message span
            lblDutyValue1.Style["display"] = "inline-block";

            if (dbDutyValue > 0 && Math.Abs(dbDutyValue - ocrDuty) < 1m)
            {
                txtIcegateDutyValue.CssClass += " greenShadow";
                txtTotalDutyValue.CssClass += " greenShadow";


            }
            else if (dbDutyValue > 0)
            {
                txtIcegateDutyValue.CssClass += " redShadow";
                txtTotalDutyValue.CssClass += " redShadow";


            }
            else
            {

            }


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    string dbBondNo = row["BOND_NO"].ToString().Trim();
                    decimal dbBondAmt = 0;
                    decimal.TryParse(row["BOND_AMT"].ToString(), out dbBondAmt);
                    decimal ocrAmt = 0;
                    DataRow[] pdfRows = bonddetails.Select("BOND_NO='" + dbBondNo.Replace("'", "''") + "'");
                    if (pdfRows.Length > 0)
                        decimal.TryParse(pdfRows[0]["DEBIT_AMT"].ToString(), out ocrAmt);

                    dt.Rows.Add(dbBondNo, dbBondAmt.ToString("0.00"), ocrAmt.ToString("0.00"));
                }
            }
            foreach (DataRow ocr in bonddetails.Rows)
            {
                string ocrBondNo = ocr["BOND_NO"].ToString().Trim();
                decimal ocrAmt = 0;
                decimal.TryParse(ocr["DEBIT_AMT"].ToString(), out ocrAmt);

                // Skip if already added from DB loop
                DataRow[] exists = dt.Select("BOND_NO='" + ocrBondNo.Replace("'", "''") + "'");
                if (exists.Length == 0)
                    dt.Rows.Add(ocrBondNo, "0.00", ocrAmt.ToString("0.00"));
            }

            gvChecklistDetails.DataSource = dt;
            gvChecklistDetails.DataBind();
            gvChecklistDetails_grid.Style["display"] = dt.Rows.Count > 0 ? "block" : "none";
        }
        catch (Exception ex)
        {
            HideAllBlock();
            Connection.Error_Msg(ex.Message);
        }
    }

    private string GetBE_FirstPagePdfPath()
    {
        try
        {
            DataSet ds = new DataSet();
            Job_Histroy jh = new Job_Histroy();
            jh.JOBNO = hdn_Jobno.Value;
            jh.FLAG = "Select_pdf";
            jh.BRANCH_CODE = SELECT_BRANCH;
            jh.JOB_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

            ds = jh.Job_History_Details();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;

            DataRow dr = ds.Tables[0].Rows[0];

            if (!ds.Tables[0].Columns.Contains("MailSubject"))
                return null;
            if (ds.Tables[0].Columns.Contains("BE_NO"))
            {
                _currentBENo = dr["BE_NO"].ToString().Trim();
            }

            string pdfFileName = dr["MailSubject"].ToString().Trim();

            if (string.IsNullOrEmpty(pdfFileName))
                return null;
            if (!pdfFileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                pdfFileName += ".pdf";

            string financialYear = GetFinancialYear();
            string folderPath = HttpContext.Current.Server.MapPath("~/Submission/" + financialYear + "/"
                + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" + Session["GroupName"].ToString() + "/" + "Attachments/");


            if (!Directory.Exists(folderPath))
                return null;

            string fullPath = Path.Combine(folderPath, pdfFileName);

            return fullPath;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Tuple<decimal, decimal, decimal, DataTable> ReadTotAssVal_Dynamically()
    {
        string pdfPath = ViewState["pdfPath"].ToString();
        ViewState["pdfPath"] = "";
        if (string.IsNullOrEmpty(pdfPath))
            return Tuple.Create(0m, 0m, 0m, new DataTable());

        string excelPath = ConvertPDFToExcel_FromPath(pdfPath);

        return GetTotAssVal_FromExcel(excelPath);
    }
    public string GetFinancialYear()
    {
        DateTime today = DateTime.Now;
        string financialYear = today.Month >= 4 ? today.Year + "-" + (today.Year + 1).ToString().Substring(2) :
            (today.Year - 1) + "-" + (today.Year).ToString().Substring(2);
        return financialYear;
    }

    private string ConvertPDFToExcel_FromPath(string pdfPath)
    {
        string financialYear = GetFinancialYear();
        string outputFolder = HttpContext.Current.Server.MapPath(
              "~/Submission/" + financialYear + "/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" +
              Session["GroupName"].ToString() + "/" +
              "Output/");

        if (!Directory.Exists(outputFolder))
            Directory.CreateDirectory(outputFolder);
        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pdfPath);
        string excelPath = Path.Combine(
            outputFolder,
            fileNameWithoutExt + ".xlsx"
        );

        if (File.Exists(excelPath))
            File.Delete(excelPath);

        Document pdfDocument = new Document(pdfPath);

        ExcelSaveOptions options = new ExcelSaveOptions
        {
            Format = ExcelSaveOptions.ExcelFormat.XLSX
        };

        pdfDocument.Save(excelPath, options);

        return excelPath;
    }

    //Ajith modified method
    private Tuple<decimal, decimal, decimal, DataTable> GetTotAssVal_FromExcel(string excelPath)
    {
        decimal totalDuty = 0;
        decimal totalAssessableValue = 0;

        decimal totaldebitValue = 0;

        bool dutyFound = false;
        bool assessFound = false;

        bool debitFound = false;

        DataTable Bond_Details = new DataTable();
        Bond_Details.Columns.Add("BOND_NO");
        Bond_Details.Columns.Add("PORT");
        Bond_Details.Columns.Add("DEBIT_AMT");

        string connString =
            "Provider=Microsoft.ACE.OLEDB.12.0;" +
            "Data Source=" + excelPath + ";" +
            "Extended Properties=\"Excel 12.0 Xml;HDR=No;IMEX=1\"";

        using (OleDbConnection conn = new OleDbConnection(connString))
        {
            conn.Open();

            DataTable schema =
                conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string sheetName = string.Empty;
            foreach (DataRow r in schema.Rows)
            {
                string name = r["TABLE_NAME"].ToString();
                if (name.EndsWith("$") && !name.Contains("Print_Area"))
                {
                    sheetName = name;
                    break;
                }
            }

            if (string.IsNullOrEmpty(sheetName))
                return Tuple.Create(0m, 0m, 0m, new DataTable());

            DataTable dt = new DataTable();
            using (OleDbDataAdapter da =
                new OleDbDataAdapter("SELECT * FROM [" + sheetName + "]", conn))
            {
                da.Fill(dt);
            }

            for (int r = 18; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    string cellText = dt.Rows[r][c].ToString();

                    if (!dutyFound && r >= 19 && c >= 5 &&
                        cellText.Contains("14.TOTAL DUTY"))
                    {
                        if (r + 1 < dt.Rows.Count)
                        {
                            string val = dt.Rows[r + 1][c]
                                .ToString()
                                .Replace(",", "");

                            decimal.TryParse(val, out totalDuty);
                            dutyFound = true;
                        }
                    }

                    if (!assessFound && r >= 18 && c >= 10 &&
                        cellText.Contains("18.TOT.ASS VAL"))
                    {
                        if (r + 1 < dt.Rows.Count)
                        {
                            string val = dt.Rows[r + 1][c]
                                .ToString()
                                .Replace(",", "");

                            decimal.TryParse(val, out totalAssessableValue);
                            assessFound = true;
                        }
                    }

                    if (r >= 25 && c >= 0 && cellText.Contains("1.BOND NO."))
                    {
                        int startRow = r + 1;
                        for (int i = startRow; i < dt.Rows.Count; i++)
                        {
                            string stopText = dt.Rows[i][c].ToString();

                            // 🔴 Stop when WBE NO found
                            if (stopText.Contains("1.WBE NO."))
                                break;

                            string bondNo = dt.Rows[i][c].ToString().Replace(",", "");
                            string port = dt.Rows[i][c + 2].ToString().Replace(",", "");
                            string debitAmt = dt.Rows[i][c + 4].ToString().Replace(",", "");

                            if (!string.IsNullOrWhiteSpace(bondNo))
                            {
                                Bond_Details.Rows.Add(bondNo, port, debitAmt);

                                decimal amt = 0;
                                decimal.TryParse(debitAmt, out amt);
                                totaldebitValue += amt;
                            }
                        }

                        debitFound = true;
                    }

                    if (dutyFound && assessFound && debitFound)
                        break;
                }

                if (dutyFound && assessFound && debitFound)
                    break;
            }
        }

        return Tuple.Create(totalDuty, totalAssessableValue, totaldebitValue, Bond_Details);
    }

    protected void gvChecklistDetails_RowCreated(object sender, GridViewRowEventArgs e)
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

    private DataSet GetCachedOCRValues(string jobNo, string branchCode, string beNo)
    {
        try
        {
            Transaction t = new Transaction();
            t.JOBNO = jobNo;
            t.BRANCH_CODE = branchCode;
            t.BE_NO = beNo;
            return t.Get_ICEGATE_ASS_DUTYVAL();
        }
        catch { return null; }
    }

    private void InsertOCRHeader(string jobNo, string beNo, string branchCode, string assVal, string dutyVal)
    {
        try
        {
            Transaction t = new Transaction();
            t.JOBNO = jobNo;

            t.BRANCH_CODE = branchCode;
            t.BE_NO = beNo;
            t.ASSESSABLE_VALUE = assVal;
            t.DUTY_VALUE = dutyVal;
            t.BOND_NO = string.Empty;
            t.BOND_AMT = string.Empty;
            t.flag = "Ass_value_Duty_value";
            t.INSERT_ICEGATE_ASS_DUTY_BOND_VALUE();
        }
        catch { }
    }

    private void InsertOCRBond(string jobNo, string beNo, string branchCode, string bondNo, string bondAmt)
    {
        try
        {
            Transaction t = new Transaction();
            t.JOBNO = jobNo;
            t.BRANCH_CODE = branchCode;
            t.BE_NO = beNo;
            t.BOND_NO = bondNo;
            t.BOND_AMT = bondAmt;
            t.flag = "BOND";
            t.INSERT_ICEGATE_ASS_DUTY_BOND_VALUE();
        }
        catch { }
    }

    protected void btnOutlook_Click(object sender, EventArgs e)
    {
        try
        {
            List<string> filePaths = GetAttachmentPdfPaths();

            if (filePaths == null || filePaths.Count == 0)
            {
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "msg",
                    "alert('Attachment PDF not found');",
                    true);

                return;
            }

            string boundary =
                "----=_NextPart_" + Guid.NewGuid().ToString("N");

            StringBuilder eml = new StringBuilder();

            // Open as NEW draft mail
            eml.AppendLine("X-Unsent: 1");
            eml.AppendLine("MIME-Version: 1.0");
            eml.AppendLine(
                "Content-Type: multipart/mixed; boundary=\"" +
                boundary + "\"");

            eml.AppendLine();

            // Mail Body
            eml.AppendLine("--" + boundary);
            eml.AppendLine(
                "Content-Type: text/plain; charset=utf-8");

            eml.AppendLine();
            eml.AppendLine("Please find attached files.");
            eml.AppendLine();

            // Multiple Attachments
            foreach (string filePath in filePaths)
            {
                if (!File.Exists(filePath))
                    continue;

                string fileName =
                    Path.GetFileName(filePath);

                byte[] fileBytes =
                    File.ReadAllBytes(filePath);

                string base64Pdf =
                    Convert.ToBase64String(fileBytes);

                eml.AppendLine("--" + boundary);

                eml.AppendLine(
                    "Content-Type: application/pdf; name=\"" +
                    fileName + "\"");

                eml.AppendLine(
                    "Content-Transfer-Encoding: base64");

                eml.AppendLine(
                    "Content-Disposition: attachment; filename=\"" +
                    fileName + "\"");

                eml.AppendLine();
                eml.AppendLine(base64Pdf);
                eml.AppendLine();
            }


            // Temp folder
            string tempFolder =
                Server.MapPath("~/Temp/");

            if (!Directory.Exists(tempFolder))
                Directory.CreateDirectory(tempFolder);

            // Create EML file
            string emlFile =
                "Mail_" + Guid.NewGuid().ToString("N") + ".eml";

            string emlPath =
                Path.Combine(tempFolder, emlFile);

            // Save EML
            File.WriteAllText(
                emlPath,
                eml.ToString(),
                Encoding.ASCII);

            // Download EML
            Response.Clear();

            Response.ContentType = "message/rfc822";

            Response.AddHeader(
                "Content-Disposition",
                "attachment; filename=" + emlFile);

            Response.WriteFile(emlPath);

            Response.Flush();

            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "err",
                "alert('Error : " + ex.Message.Replace("'", "") + "');", true);
        }
    }

    private List<string> GetAttachmentPdfPaths()
    {
        List<string> fileList = new List<string>();

        try
        {
            DataSet ds = new DataSet();

            Job_Histroy jh = new Job_Histroy();
            jh.JOBNO = hdn_Jobno.Value;
            jh.FLAG = "File_Remarks";
            jh.BRANCH_CODE = SELECT_BRANCH;
            jh.JOB_TYPE = HttpContext.Current.Session["SELECT_TYPE"].ToString();

            ds = jh.Job_History_Details();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return fileList;

            DataTable dt = ds.Tables[0];
            string financialyear = GetFinancialYear();
            string folderPath = HttpContext.Current.Server.MapPath(
                "~/Submission/" + financialyear + "/" + HttpContext.Current.Session["COMPANY_ID"].ToString() + "/" +
                Session["GroupName"].ToString() + "/" +
                "Attachments/"
            );

            if (!Directory.Exists(folderPath))
                return fileList;

            foreach (DataRow dr in dt.Rows)
            {
                string remarks = "";

                if (dt.Columns.Contains("File_Remarks"))
                    remarks = dr["File_Remarks"].ToString().Trim();

                // Match both files
                if (remarks.Equals("OOC Copy", StringComparison.OrdinalIgnoreCase) || remarks.Equals("First Copy", StringComparison.OrdinalIgnoreCase))
                {
                    if (dt.Columns.Contains("BE_NO"))
                        _currentBENo = dr["BE_NO"].ToString().Trim();

                    string pdfFileName =
                        dr["MailSubject"].ToString().Trim();

                    if (string.IsNullOrEmpty(pdfFileName))
                        continue;

                    if (!pdfFileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                    {
                        pdfFileName += ".pdf";
                    }

                    string fullPath = Path.Combine(folderPath, pdfFileName);

                    if (File.Exists(fullPath))
                    {
                        fileList.Add(fullPath);
                    }
                }
            }

            return fileList;
        }
        catch
        {
            return fileList;
        }
    }


    private void Check_Duplicate_Invoice_OnLoad()
    {
        try
        {
            if (ddlJobNo.SelectedValue == "Select" || ddlJobNo.SelectedValue == "")
                return;

            CheckList chklist = new CheckList();
            chklist.JOBNo = ddlJobNo.SelectedValue.ToString();
            chklist.Ename = "Import_Duplicate_Invoice_Chk";
            chklist.Workingperiod = SELECT_BRANCH;

            DataSet ds = new DataSet();
            ds = chklist.RetrieveAll_General_Details();

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return;

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

            string msg = "This Invoice Number Already Exists in Job No - " +
                         "<span style='color:red;font-weight:bold;'>" + jobStr + "</span>";

            Show_duplicate_Popup("Duplicate Invoice No", msg);
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();
            er.makeLog("Check_Duplicate_Invoice_OnLoad: " + ex.Message);
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


