using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BussinessObject;

public partial class Import_N_Form : ThemeClass
{
    public int currentPageNumber, i;
    public double totalRows;
    public const int PAGESIZE = 0;
    public int pageno = 0;
    SqlConnection con;
    UserBO ObjUBO = new UserBO();
    User_Creation user_Create = new User_Creation();
    DataTable dt = new DataTable();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    NForm NForm = new NForm();
    AppSession aps = new AppSession();
    Date_Time date = new Date_Time();

    public string currentuser;
    public string currentbranch;
    public string currentcomp_name;
    public string comp_ConnectionStr;
    public string Working_Period;
    public string LoginDate;
    public string  SCREEN_ID, PAGE_MODIFY;
    public string SELECT_TYPE, SELECT_BRANCH;
    public int Screen_Id;
    ErrorLogs er = new ErrorLogs();
    Date_Time dta = new Date_Time();
    public string FORM_ID = "";

    public string CHAAddr1, CHAAddr2, CHAAddr3;
    public string ImpName="",ImpAdd1="",ImpAdd2="";
    public string TextBoxName1, TextBoxName2, TextBoxName3, TextBoxName4;
    public string assbl, duty;
    public int assblval = 0, dutyval = 0;
    public double assblval1, dutyval1, summ;
    public string cal_assbl, cal_duty;
    public double val_assbl, val_duty, calculate;
    string equal = "=";

    protected void Page_Load(object sender, EventArgs e)
    {

        aps.checkSession();
        con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["con"]);

        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        currentcomp_name = Session["currentcomp_name"].ToString();
        comp_ConnectionStr = Session["currentcomp_db"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        LoginDate = Session["LoginDate"].ToString();

        CHAAddr1 = HttpContext.Current.Session["CHA_NAME"].ToString();
        CHAAddr2 = HttpContext.Current.Session["CHA_ADDRESS"].ToString();
        CHAAddr3 = HttpContext.Current.Session["CHA_ADDRESS1"].ToString();

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
          * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            if (Request.QueryString["Page"] == "New")
            {
                Load_NF_JobNo();
                TxtJOBNO.Visible = false;
                ddlJobNo.Visible = true;
                btnDelete.Visible = false;
                btnSend.Visible = false;
                btnSend22.Visible = false;
            }
            else
            {
                Edit_Nform_Details();
                Get_ImporterName();
                btnDelete.Visible = true;
            }
            
            TextBoxName1 = Session["currentcomp_name"].ToString();
            TextBoxName2 = CHAAddr1;
            TextBoxName3 = CHAAddr2;
            Label25.Text = Session["currentcomp_name"].ToString();
            //btn_Report.Visible = false;
            
            
        }
        
    }

    public void Get_ImporterName()
    {
        ObjUBO.JOBNO = HiddenField1.Value;
        ObjUBO.Ename = "Get_Importer_details";
        ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
        dss.Clear();
        dss = NForm.RetrieveAll_N_FORM_Details(ObjUBO);
        if (dss.Tables[0].Rows.Count > 0)
        {
            txtimpadd1.Text = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
            txtimpadd2.Text = dss.Tables[0].Rows[0]["ADDRESS1"].ToString();
            txtimpadd3.Text = dss.Tables[0].Rows[0]["ADDRESS2"].ToString();
            TextField7.Text = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
        }
    }

    public void Edit_Nform_Details()
    {
        if (Request.QueryString["Page"] != "")
        {
            try
            {
                ObjUBO.JOBNO = Request.QueryString["Page"].ToString();
                //NForm.Ename = "Select_NForm";
                ObjUBO.Ename = "NForm_LCD_Report";
                ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
                dtuser.Clear();
                dtuser = NForm.RetrieveAll_N_FORM_Details(ObjUBO);

                int i1 = NForm.result;

                if (i1 == 1)
                {
                    if (dtuser.Tables[0].Rows.Count > 0)
                    {
                        HiddenField1.Value = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                        hdn_jobno.Value = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                        TxtJOBNO.Visible = true;
                        ddlJobNo.Visible = false;
                        TxtJOBNO.Text = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                        TextBoxName1 = dtuser.Tables[0].Rows[0]["NF_NAME1"].ToString();
                        TextBoxName2 = dtuser.Tables[0].Rows[0]["NF_NAME2"].ToString();
                        TextBoxName3 = dtuser.Tables[0].Rows[0]["NF_NAME3"].ToString();
                        TextBoxName4 = dtuser.Tables[0].Rows[0]["NF_NAME4"].ToString();
                        txt_trans_commission.Text = dtuser.Tables[0].Rows[0]["NF_TO"].ToString();
                        TextField1.Text = dtuser.Tables[0].Rows[0]["NF_FIELD1"].ToString();
                        TextField2.Text = dtuser.Tables[0].Rows[0]["NF_FIELD2"].ToString();
                        TextField3.Text = dtuser.Tables[0].Rows[0]["NF_FIELD3"].ToString();
                        TextField4.Text = dtuser.Tables[0].Rows[0]["NF_FIELD4"].ToString();
                        TextField5.Text = dtuser.Tables[0].Rows[0]["NF_FIELD5"].ToString();
                        TextField6.Text = dtuser.Tables[0].Rows[0]["NF_FIELD6"].ToString();
                        ////TextField7.Text = dtuser.Tables[0].Rows[0]["NF_FIELD7"].ToString();
                        //TextField7.Text = Addr1;
                        TextField8.Text = dtuser.Tables[0].Rows[0]["NF_FIELD8"].ToString();
                        txt_No_DateofDoc.Text = dtuser.Tables[0].Rows[0]["NF_NO_DATEOFDOC"].ToString();
                        txt_trans_pkgno.Text = dtuser.Tables[0].Rows[0]["NF_PKGNO"].ToString();
                        txt_trans_descno.Text = dtuser.Tables[0].Rows[0]["NF_DESCNO"].ToString();
                        txt_trans_desc_Articles.Text = dtuser.Tables[0].Rows[0]["NF_DESC_ARTICLES"].ToString();
                        txt_trans_Import_Marks.Text = dtuser.Tables[0].Rows[0]["NF_IMPORTMARKS"].ToString();
                        txt_WeightOrQTY.Text = dtuser.Tables[0].Rows[0]["NF_WEIGHT_QTY"].ToString();
                        txt_trans_NFormno.Text = dtuser.Tables[0].Rows[0]["NF_NFORM_NO"].ToString();
                        PkgNo.Text = dtuser.Tables[0].Rows[0]["NF_NFORM_PKGNO"].ToString();
                        txt_Octroi_Paid.Text = dtuser.Tables[0].Rows[0]["NF_OCTRAI_PAID"].ToString();
                        txt_Imp_Bill.Text = dtuser.Tables[0].Rows[0]["NF_IMP_BILL"].ToString();
                        txt_Pkg_Escorted.Text = dtuser.Tables[0].Rows[0]["NF_PKG_ESCORTED"].ToString();
                        txt_No_DateExpDoc.Text = dtuser.Tables[0].Rows[0]["NF_NO_DATEOFEXPORT"].ToString();
                        txt_ValueOfOctrai.Text = dtuser.Tables[0].Rows[0]["NF_VALUE_OCTRAI"].ToString();
                        txt_Remarks.Text = dtuser.Tables[0].Rows[0]["NF_REMARKS"].ToString();
                        txt_PlaceOfExport.Text = dtuser.Tables[0].Rows[0]["NF_PLACEOFEXPORT"].ToString();
                        txt_NameOfApplicant.Text = dtuser.Tables[0].Rows[0]["NF_NAME_APPLICANT"].ToString();
                        txt_Datee.Text = dtuser.Tables[0].Rows[0]["NF_DATEE"].ToString();
                        txtAuthorisedSign.Text = dtuser.Tables[0].Rows[0]["NF_AUTHORIZED"].ToString();
                        txtEscortFees.Text = dtuser.Tables[0].Rows[0]["NF_ESCORD_FEES"].ToString();
                        txt_DeliveredTo.Text = dtuser.Tables[0].Rows[0]["NF_DELIVED_TO"].ToString();
                        txt_octraiNo1.Text = dtuser.Tables[0].Rows[0]["NF_OCTRAI_NO"].ToString();
                        txt_octrai_date.Text = dtuser.Tables[0].Rows[0]["NF_OCTRAI_DATE"].ToString();
                        txtOctpercent.Text = dtuser.Tables[0].Rows[0]["NF_OCTRAI_PERCENT"].ToString();
                        Working_Period = dtuser.Tables[0].Rows[0]["NF_WORKINGPERIOD"].ToString();

                        btnDelete.Visible = true;
                        btnUpdate.Visible = true;
                        btnSave.Visible = false;
                        btnSend.Visible = true;
                        btnSend22.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                er.makeLog(ex.Message);
            }
        }
    }

    public void Load_NF_JobNo()
    {
        ObjUBO.JOBNO = "";
        ObjUBO.Ename = "Except_JobNo";
        ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
        dss = NForm.RetrieveAll_N_FORM_Details(ObjUBO);

        ddlJobNo.DataSource = dss.Tables[0];
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataTextField = "JOBNO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }

    public int insert_update(string a1, string a2,string a3)
    {
        ObjUBO.NFORM_ID = a1;
        ObjUBO.JOBNO = a3;
        hdn_jobno.Value = a3;
        ObjUBO.NF_NAME1 = TextBoxName1;
        ObjUBO.NF_NAME2 = TextBoxName2;
        ObjUBO.NF_NAME3 = TextBoxName3;
        ObjUBO.NF_NAME4 = TextBoxName4;
        ObjUBO.NF_TO = txt_trans_commission.Text;
        ObjUBO.NF_FIELD1 = TextField1.Text;
        ObjUBO.NF_FIELD2 = TextField2.Text;
        ObjUBO.NF_FIELD3 = TextField3.Text;
        ObjUBO.NF_FIELD4 = TextField4.Text;
        ObjUBO.NF_FIELD5 = TextField5.Text;
        ObjUBO.NF_FIELD6 = TextField6.Text;
        ObjUBO.NF_FIELD7 = TextField7.Text;
        //TextBoxName1 = TextField7.Text;
        ObjUBO.NF_FIELD8 = TextField8.Text;
        ObjUBO.NF_NO_DATEOFDOC = txt_No_DateofDoc.Text;
        ObjUBO.NF_PKGNO = txt_trans_pkgno.Text;
        ObjUBO.NF_DESCNO = txt_trans_descno.Text;
        ObjUBO.NF_DESC_ARTICLES = txt_trans_desc_Articles.Text;
        ObjUBO.NF_IMPORTMARKS = txt_trans_Import_Marks.Text;
        ObjUBO.NF_WEIGHT_QTY = txt_WeightOrQTY.Text;
        ObjUBO.NF_NFORM_NO = txt_trans_NFormno.Text;
        ObjUBO.NF_NFORM_PKGNO = PkgNo.Text;
        ObjUBO.NF_OCTRAI_PAID = txt_Octroi_Paid.Text;
        ObjUBO.NF_IMP_BILL = txt_Imp_Bill.Text;
        ObjUBO.NF_PKG_ESCORTED = txt_Pkg_Escorted.Text;
        ObjUBO.NF_NO_DATEOFEXPORT = txt_No_DateExpDoc.Text;
        ObjUBO.NF_VALUE_OCTRAI = txt_ValueOfOctrai.Text;
        ObjUBO.NF_REMARKS = txt_Remarks.Text;
        ObjUBO.NF_PLACEOFEXPORT = txt_PlaceOfExport.Text;
        ObjUBO.NF_NAME_APPLICANT = txt_NameOfApplicant.Text;
        ObjUBO.NF_DATEE = txt_Datee.Text;
        ObjUBO.NF_AUTHORIZED = txtAuthorisedSign.Text;
        ObjUBO.NF_ESCORD_FEES = txtEscortFees.Text;
        ObjUBO.NF_DELIVED_TO = txt_DeliveredTo.Text;
        ObjUBO.NF_OCTRAI_NO = txt_octraiNo1.Text;
        ObjUBO.NF_OCTRAI_DATE = txt_octrai_date.Text;
        ObjUBO.NF_OCTRAI_PERCENT = txtOctpercent.Text;
        ObjUBO.flag = a2;
        ObjUBO.YEAR = Working_Period.Substring(21, 4);
        ObjUBO.WORKING_PERIOD = Working_Period;
        ObjUBO.BRANCH_COMMON = SELECT_BRANCH;
        ObjUBO.BRANCH_CODE = Session["currentbranch"].ToString();

        i = NForm.NForm_InsertUpdate(ObjUBO);

        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField1.Value = ddlJobNo.SelectedValue.ToString();
            string a1 = HiddenField1.Value;
            string a2 = "S";
            string a3 = ddlJobNo.SelectedValue.ToString();
            i = insert_update(a1, a2, a3);
            //HiddenField1.Value = Convert.ToString(NForm.UPDATE_ID);
            ViewState["Update_ID"] = Convert.ToString(NForm.UPDATE_ID);
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
                    btnSend.Visible = true;
                    btnSend22.Visible = true;
                    btnDelete.Visible = false;
                    //btn_Report.Visible = true;
                    //hdn_Update_Consignee_Name.Value = txtName.Text;
                    //HiddenField1.Value = TxtJOBNO.Text;

                }
                //-----------------------FOR USER RIGHTS--------------------------------//
                ViewState["UPDATED_ID"] = null;
                Alert_msg("Saved Successfully", "btnSave");
            }
            else if (i == 2)
            {
                Alert_msg("Already exixts!", "btnSave");
            }
            else
            {
                Alert_msg("Not Saved", "btnNew");
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
            string a1 = "";
            string a3 = "";
            if (Request.QueryString["Page"] != "New")
            {
                a1 = Request.QueryString["Page"].ToString();
                a3 = TxtJOBNO.Text;
            }
            else
            {
                a1 = ViewState["Update_ID"].ToString();
                a3 = ddlJobNo.SelectedItem.Text;
            }
            string a2 = "U";
            
            i = insert_update(a1, a2, a3);
            if (i == 1)
            {
                    Alert_msg("Updated Successfully", "btnUpdate");
                    //btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnSend.Visible = true;
                    btnSend22.Visible = true;
                    btnDelete.Visible = true;
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
        try{

            if (Request.QueryString["Page"] != "New")
            {
                HiddenField1.Value = Request.QueryString["Page"].ToString();
            }
            else
            {
                HiddenField1.Value = ViewState["Update_ID"].ToString();
            }

            ObjUBO.JOBNO = HiddenField1.Value;
            ObjUBO.Ename = "NF_Delete";
            ObjUBO.WORKING_PERIOD = SELECT_BRANCH;

            NForm.RetrieveAll_N_FORM_Details(ObjUBO);
            int i = NForm.result;

            if (i > 0)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('N-FORM Deleted', 'Delete', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
            }
            else
            {
                Alert_msg("N-FORM Not Deleted");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    
    protected void btnNew_Click(object sender, EventArgs e)
    {
        // clear();
        // ddlHBL_NO.Items.Clear();
        //txt_trans_date.Text = dta.Today_Date();
        txt_trans_commission.Focus();
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        //btnNew.Visible = true;
        hdn_val.Value = "";
        //btn_Report.Visible = false;
        ddlJobNo.SelectedIndex = -1;

    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
        string ec = "<script>$(document).ready(function(){{return PrintGridData();}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", ec, false);
    }

    protected void txtOctpercent_TextChanged(object sender, EventArgs e)
    {
        try
        {
               cal_assbl = ViewState["assblval1"].ToString();
                 val_assbl = System.Convert.ToDouble(cal_assbl);

               cal_duty = ViewState["dutyval1"].ToString();
                 val_duty = System.Convert.ToDouble(cal_duty);

                string percent = txtOctpercent.Text;
                double percentage = System.Convert.ToDouble(percent);

                string octrai = percentage + "%Octrai on";

                double cal_sum = val_assbl + val_duty;

                calculate = cal_sum * percentage / 100;

                string lcd = Convert.ToString(Math.Round(calculate, 2).ToString());

                txt_Remarks.Text = val_assbl + "         " + val_duty +"  " + "_______ " +"  "+ cal_sum + "          " + octrai + "  " + cal_sum + "  " + equal + "  " + lcd;
            
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
    }

    protected void ddlJobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clear();
        string jobno;
        jobno = ddlJobNo.SelectedValue.ToString();
        //HiddenField1.Value = ddlJobNo.SelectedValue.ToString();
        DataTable dt1 = new DataTable();
        Get_ImporterName();
        try
        {
            ObjUBO.JOBNO = jobno;
            //NForm.Ename = "Select_NForm";
            ObjUBO.Ename = "select_Check_GeneralAndNform";
            ObjUBO.WORKING_PERIOD = SELECT_BRANCH;
            dtuser.Clear();
            dtuser = NForm.RetrieveAll_N_FORM_Details(ObjUBO);
            
            int i1 = NForm.result;

            if (i1 == 1)
            {
                string octraidate1;
                //DateTime dss = Convert.ToDateTime(octraidate1);
                string dd = dta.Today_Date();

                txt_octrai_date.Text = dta.Today_Date();
                txt_Datee.Text = dta.Today_Date();
                //txt_octrai_date.Text = DateTime.Now.ToString();

                txt_trans_commission.Text = "The Dy. ASSESSOR & COLLECTOR (OCTROI)";
                txtOctpercent.Text = "0";
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    TxtJOBNO.Text = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                    txtimpadd1.Text = dtuser.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    txtimpadd2.Text = dtuser.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txtimpadd3.Text = dtuser.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    TextField7.Text = dtuser.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();

                    if (dtuser.Tables[1].Rows.Count > 0)
                    {                    
                        txt_No_DateofDoc.Text = dtuser.Tables[1].Rows[0]["IGM_NO"].ToString() + "   " + dtuser.Tables[1].Rows[0]["IGM_DATE"].ToString();
                        txt_trans_pkgno.Text = dtuser.Tables[1].Rows[0]["IGM_NOOFPACKAGE"].ToString();
                        txt_trans_descno.Text = dtuser.Tables[1].Rows[0]["IGM_PACKAGETYPE"].ToString();
                        txt_WeightOrQTY.Text = dtuser.Tables[1].Rows[0]["IGM_GROSSWEIGHT"].ToString() + " " + dtuser.Tables[1].Rows[0]["IGM_TYPEOFWEIGHT"].ToString() + "     " + dtuser.Tables[1].Rows[0]["IGM_NETWEIGHT"].ToString() + "     " + dtuser.Tables[1].Rows[0]["IGM_NETWEIGHTTYPE"].ToString();
                        txt_trans_Import_Marks.Text = dtuser.Tables[1].Rows[0]["IGM_MARKSNOS"].ToString();

                        if (dtuser.Tables[2].Rows.Count > 0)
                        {
                            txt_trans_pkgno.Text = dtuser.Tables[2].Rows[0]["IGM_NOOFPACKAGE"].ToString();

                            if (dtuser.Tables[3].Rows.Count > 0)
                            {
                                assbl = dtuser.Tables[3].Rows[0]["ASSESSABLE_VALUE"].ToString();                             
                                 assblval1 = System.Convert.ToDouble(assbl);
                                 ViewState["assblval1"] = assblval1;

                                duty = dtuser.Tables[3].Rows[0]["DUTY_VALUE"].ToString();
                                dutyval1 = System.Convert.ToDouble(duty);
                                ViewState["dutyval1"] = dutyval1;

                                  summ = assblval1 + dutyval1;

                                  if (txtOctpercent.Text == "" || txtOctpercent.Text == null || txtOctpercent.Text == "0")
                                  {
                                      txtOctpercent.Text = "0";

                                      string percent = txtOctpercent.Text;
                                      int percentage = System.Convert.ToInt32(percent);

                                      string cal = "0.00";
                                      string oct = "0% octrai on";

                                      //txt_Remarks.Text = assblval1 + "     " + dutyval1 + "    " + "________________" + summ + "         " + cal + "          " + "octroi on%" + "" + cal;
                                      //txt_Remarks.Text = assblval1 + "     " + dutyval1 + "    " + "____________" + summ + "         " + "          " + oct + "" + summ + "" + equal + "  " + cal;
                                      txt_Remarks.Text = assblval1 + "         " + dutyval1 + "  " + "_______ " + "  " + summ + "          " + oct + "  " + summ + "  " + equal + "  " + cal;
                                  }
                            }
                        }
                    }
                }

                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                //btnNew.Visible = true;
            }
            else if (i1 == 2)
            {
                if (dtuser.Tables[0].Rows.Count > 0)
                {
                    //TxtJOBNO.Text = dtuser.Tables[0].Rows[0]["JOBNO"].ToString();
                    TextBoxName1 = dtuser.Tables[0].Rows[0]["NF_NAME1"].ToString();
                    TextBoxName2 = dtuser.Tables[0].Rows[0]["NF_NAME2"].ToString();
                    TextBoxName3 = dtuser.Tables[0].Rows[0]["NF_NAME3"].ToString();
                    TextBoxName4 = dtuser.Tables[0].Rows[0]["NF_NAME4"].ToString();
                    txt_trans_commission.Text = dtuser.Tables[0].Rows[0]["NF_TO"].ToString();
                    TextField1.Text = dtuser.Tables[0].Rows[0]["NF_FIELD1"].ToString();
                    TextField2.Text = dtuser.Tables[0].Rows[0]["NF_FIELD2"].ToString();
                    TextField3.Text = dtuser.Tables[0].Rows[0]["NF_FIELD3"].ToString();
                    TextField4.Text = dtuser.Tables[0].Rows[0]["NF_FIELD4"].ToString();
                    TextField5.Text = dtuser.Tables[0].Rows[0]["NF_FIELD5"].ToString();
                    TextField6.Text = dtuser.Tables[0].Rows[0]["NF_FIELD6"].ToString();
                    ////TextField7.Text = dtuser.Tables[0].Rows[0]["NF_FIELD7"].ToString();
                    //TextField7.Text = Addr1;
                    TextField8.Text = dtuser.Tables[0].Rows[0]["NF_FIELD8"].ToString();
                    txt_No_DateofDoc.Text = dtuser.Tables[0].Rows[0]["NF_NO_DATEOFDOC"].ToString();
                    txt_trans_pkgno.Text = dtuser.Tables[0].Rows[0]["NF_PKGNO"].ToString();
                    txt_trans_descno.Text = dtuser.Tables[0].Rows[0]["NF_DESCNO"].ToString();
                    txt_trans_desc_Articles.Text = dtuser.Tables[0].Rows[0]["NF_DESC_ARTICLES"].ToString();
                    txt_trans_Import_Marks.Text = dtuser.Tables[0].Rows[0]["NF_IMPORTMARKS"].ToString();
                    txt_WeightOrQTY.Text = dtuser.Tables[0].Rows[0]["NF_WEIGHT_QTY"].ToString();
                    txt_trans_NFormno.Text = dtuser.Tables[0].Rows[0]["NF_NFORM_NO"].ToString();
                    PkgNo.Text = dtuser.Tables[0].Rows[0]["NF_NFORM_PKGNO"].ToString();
                    txt_Octroi_Paid.Text = dtuser.Tables[0].Rows[0]["NF_OCTRAI_PAID"].ToString();
                    txt_Imp_Bill.Text = dtuser.Tables[0].Rows[0]["NF_IMP_BILL"].ToString();
                    txt_Pkg_Escorted.Text = dtuser.Tables[0].Rows[0]["NF_PKG_ESCORTED"].ToString();
                    txt_No_DateExpDoc.Text = dtuser.Tables[0].Rows[0]["NF_NO_DATEOFEXPORT"].ToString();
                    txt_ValueOfOctrai.Text = dtuser.Tables[0].Rows[0]["NF_VALUE_OCTRAI"].ToString();
                    txt_Remarks.Text = dtuser.Tables[0].Rows[0]["NF_REMARKS"].ToString();
                    txt_PlaceOfExport.Text = dtuser.Tables[0].Rows[0]["NF_PLACEOFEXPORT"].ToString();
                    txt_NameOfApplicant.Text = dtuser.Tables[0].Rows[0]["NF_NAME_APPLICANT"].ToString();
                    txt_Datee.Text = dtuser.Tables[0].Rows[0]["NF_DATEE"].ToString();
                    txtAuthorisedSign.Text = dtuser.Tables[0].Rows[0]["NF_AUTHORIZED"].ToString();
                    txtEscortFees.Text = dtuser.Tables[0].Rows[0]["NF_ESCORD_FEES"].ToString();
                    txt_DeliveredTo.Text = dtuser.Tables[0].Rows[0]["NF_DELIVED_TO"].ToString();
                    txt_octraiNo1.Text = dtuser.Tables[0].Rows[0]["NF_OCTRAI_NO"].ToString();
                    txt_octrai_date.Text = dtuser.Tables[0].Rows[0]["NF_OCTRAI_DATE"].ToString();
                  
                    txtOctpercent.Text = dtuser.Tables[0].Rows[0]["NF_OCTRAI_PERCENT"].ToString();  
 
                    Working_Period = dtuser.Tables[0].Rows[0]["NF_WORKINGPERIOD"].ToString();
           

                    //if (dtuser.Tables[1].Rows.Count > 0)
                    //{
                    //    txtimpadd1.Text = dtuser.Tables[1].Rows[0]["IMPORTER_NAME"].ToString();
                    //    txtimpadd2.Text = dtuser.Tables[1].Rows[0]["ADDRESS1"].ToString();
                    //    txtimpadd3.Text = dtuser.Tables[1].Rows[0]["ADDRESS2"].ToString();
                    //    TextField7.Text = dtuser.Tables[1].Rows[0]["IMPORTER_NAME"].ToString();

                    //    Session["ImpAdd1"] = dtuser.Tables[1].Rows[0]["IMPORTER_NAME"].ToString();
                    //}
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnSend.Visible = true;
                    btnSend22.Visible = true;
                    //btnNew.Visible = true;
                    //btn_Report.Visible = true;
                }
            }
        
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }

    }

    public void Clear()
    {
        //TxtJOBNO.Text = "";
        //TextBoxName1.Text = dtuser.Tables[0].Rows[0]["NF_NAME1"].ToString();
        //TextBoxName2.Text = "";
        //TextBoxName3.Text = "";
        TextBoxName4 = "";
        txt_trans_commission.Text = "";
        TextField1.Text = "";
        TextField2.Text = "";
        TextField3.Text = "";
        TextField4.Text = "";
        TextField5.Text = "";
        TextField6.Text = "";
        TextField7.Text = "";
        TextField8.Text = "";
        txt_No_DateofDoc.Text = "";
        txt_trans_pkgno.Text = "";
        txt_trans_descno.Text = "";
        txt_trans_desc_Articles.Text = "";
        txt_trans_Import_Marks.Text = "";
        txt_WeightOrQTY.Text = "";
        txt_trans_NFormno.Text = "";
        txt_trans_pkgno.Text = "";
        txt_Octroi_Paid.Text = "";
        txt_Imp_Bill.Text = "";
        txt_Pkg_Escorted.Text = "";
        txt_No_DateExpDoc.Text = "";
        txt_ValueOfOctrai.Text = "";
        txt_Remarks.Text = "";
        txt_PlaceOfExport.Text = "";
        txt_NameOfApplicant.Text = "";
        txt_Datee.Text = "";
        txtAuthorisedSign.Text = "";
        txtEscortFees.Text = "";
        txt_DeliveredTo.Text = "";
        txtimpadd1.Text = "";
        txtimpadd2.Text = "";
        txtimpadd3.Text = "";
        PkgNo.Text = "";
        txtOctpercent.Text = "";


    }


    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'N-FORM APP', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'N-FORM APP', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

}