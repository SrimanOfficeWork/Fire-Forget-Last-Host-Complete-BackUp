using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class Export_Export_GSP_Front_Details : ThemeClass
{
    GSP_Details GSP = new GSP_Details();
    Transaction trans = new Transaction();
    Certificate_Of_Origin certificate = new Certificate_Of_Origin();

    DataSet dtuser = new DataSet();
    Export_CheckList CHKLIST = new Export_CheckList();
    AppSession aps = new AppSession();
    DataSet ds = new DataSet();
    public string Trans_ID = "";
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
    public string EXPORT_JOBNO, INV_SLN0, ITEM_SLNO, SCHEME_CODE, RITC_NO, ITEM_DESC;
    public string USER_RIGHTS_ID, SCREEN_ID, PAGE_READ, PAGE_WRITE, PAGE_MODIFY, PAGE_DELETE, Is_Master_Id;
    public string FILE_REF_NO, BRANCH_NO, IEC_NO, TRANSPORT_MODE;
    public int Screen_Id;
    User_Creation user_Create = new User_Creation();
    public string strr, ss;
    string GSP_description,M_NOS,goods_st,description,elsedesc;

    string marksVal, DescVal;
    int Val_Marks, Val_Desc;
    string dell = "~~";
    string dell_blcnk = " ~ ";

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
         *   * */
        SELECT_BRANCH = Connection.Get_Company_Type();
        if (!IsPostBack)
        {
            //Get_JobNo();
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

            //hdn_CLIENT_TYPE.Value = "Exporter";

            txtExporter.Attributes.Add("onblur", "javascript:CallServerside_Report_Client('" + txtExporter.ClientID + "', '" + Exporter + "')");
            txtConsignee.Attributes.Add("onblur", "javascript:CallServerside_Report_ConsigneeName('" + txtConsignee.ClientID + "', '" + Consignee + "')");
           

            Get_ExporterName_General();

            if (Request.QueryString["Page"] == "New")
            {
                //hdn_Jobno.Value = ddlJobNo.SelectedItem.Text;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                btn_next.Visible = false;
                btn_prev.Visible = false;
                //BtnAddAnnex.Visible = false;
                btnSave.Visible = true;
                //txt_JobNo.Visible = false;
               
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    hdn_Jobno.Value = txt_JobNo.Text;
                    Get_DropDown_SelectedIndexChanged();
                    //Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    //BtnAddAnnex.Visible = true;
                    btnSave.Visible = false;
                 
                    //btnl_Annex.Visible = true;
                    //HdnUpdate_id.Value = Request.QueryString["Page"].ToString();
                }
            }
        }
        Check_JobNo();

        //}
       
    }
    public void Get_JobNo()
    {
       
        GSP.JOBNO = "";
        GSP.EXPORTER_NAME = ddl_ExporterName.SelectedItem.Text;
        GSP.FROM_DATE = "";
        GSP.TO_DATE = "";
        GSP.WORKING_PERIOD = "";
        GSP.BRANCH_CODE = SELECT_BRANCH;
        GSP.Ename = "Get_GSP_Except_JobNo";

        ddlJobNo.DataSource = GSP.GSP_NORMAL_SEARCH();

        ddlJobNo.DataValueField = "FILE_REF_NO";
        ddlJobNo.DataTextField = "FILE_REF_NO";
        ddlJobNo.DataBind();
        ddlJobNo.Items.Remove("0");
        ddlJobNo.Items.Insert(0, "Select");
    }

    public void Check_JobNo()
    {
        GSP.JOBNO = hdn_Jobno.Value;
        GSP.WORKING_PERIOD = SELECT_BRANCH;
        GSP.BRANCH_CODE = SELECT_BRANCH;
        GSP.Ename = "Check_JobNo";
        ds = GSP.GSP_NORMAL_SEARCH();
        i = GSP.result;

        HdnFld_CheckJobNo.Value = Convert.ToString(i);
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
            txt_File_RefNo.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
            txt_ExporterName.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
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
            hdn_Jobno.Value = ds.Tables[0].Rows[0]["JOBNO"].ToString();
            ViewState["hdn_fileRef_Jobno"] = hdn_Jobno.Value;
            txt_JobNo.Text = hdn_Jobno.Value;
        }
        else
        {
            ViewState["hdn_fileRef_Jobno"] = txt_JobNo.Text;
        }

        Get_DropDown_SelectedIndexChanged();
        //HdnFld_CheckJobNo.Value = Convert.ToString(i);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtTransport_Route.Text != "")
            {
                //string ID = "";
                FILE_REF_NO = ddlJobNo.SelectedItem.Text;
                string F = "S";
                i = Export_GSP_DETAILS_Insert_Update(F);
                if (i == 1)
                {
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnSave.Visible = false;
                    btnNew.Visible = false;
                    //btnSearch.Visible = false;
                    btn_next.Visible = true;
                    btn_prev.Visible = true;
                    //trans.ResetFields(Page.Controls);
                    //txtIECNo.Focus();
                    btnSave.Enabled = false;

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Saved Successfully')</script>", false);
                    Alert_msg("Saved Successfully", "btnSave");

                }
                else if (i == 2)
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                    Alert_msg("Job No Already Exist!", "btnSave");
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    //btnSearch.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                    btn_next.Visible = false;
                    btn_prev.Visible = false;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
                    Alert_msg("Not Saved", "btnSave");
                }          
            }
            else
            {
                Alert_msg("Means of transport and route Should Not be Empty");
            }            
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
        }
        Check_JobNo();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //string ID = "";
            FILE_REF_NO = txt_File_RefNo.Text;
            string F = "U";
            i = Export_GSP_DETAILS_Insert_Update(F);
            if (i == 1)
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                //btnSearch.Visible = false;
                btn_next.Visible = true;
                btn_prev.Visible = true;
                    
                //trans.ResetFields(Page.Controls);
                //  txtIECNo.Focus();
                btnSave.Enabled = false;

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                Alert_msg("Updated Successfully", "btnUpdate");

            }
            else if (i == 2)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Not Save, Job No Already Exist')</script>", false);
                Alert_msg("Job No Already Exist!", "btnUpdate");
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                //btnSearch.Visible = false;
                btn_next.Visible = false;
                btn_prev.Visible = false;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
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
            //string ID = "";
            //string F = "D";
            //i = Export_GSP_DETAILS_Insert_Update(F);

            CHKLIST.JOBNo = hdn_Jobno.Value;
            CHKLIST.Ename = "GSP_Front_details_Delete";
            CHKLIST.Workingperiod = SELECT_BRANCH;
            ds = CHKLIST.RetrieveAll_General_Details();

            int i = CHKLIST.result;

            if (i == 1)
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                trans.ResetFields(Page.Controls);
                //txtIECNo.Focus();
                btnSave.Enabled = false;

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Updated Successfully')</script>", false);
                Alert_msg("Record Deleted", "btnUpdate");
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = false;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Hello", "<script language='javascript'>alert('Record Not Saved')</script>", false);
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
        trans.ResetFields(Page.Controls);

        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GSP', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'GSP', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public int Export_GSP_DETAILS_Insert_Update(string Flag)
    {
        //Export.JOBID = jobid;

        GSP.GSPID = "1";
        GSP.JOBNO = hdn_Jobno.Value;
        GSP.FILE_REF_NO = FILE_REF_NO;      
        GSP.EXPORTER_NAME = txtExporter.Text;
        GSP.BRANCH_NO = BRANCH_NO;
        GSP.IEC_NO = IEC_NO;
        GSP.ADDRESS1 = txtAddress1.Text;
        GSP.ADDRESS2 = txtAddress2.Text;
        GSP.ADDRESS3 = txtAddress3.Text;
        GSP.ADDRESS4 = txtAddress4.Text;
        GSP.ADDRESS5 = txtAddress5.Text;

        GSP.CONSIGNEE_NAME = txtConsignee.Text;
        GSP.CONSIGNEE_ADD1 = txtConsignee_Add1.Text;
        GSP.CONSIGNEE_ADD2 = txtConsignee_Add2.Text;
        GSP.CONSIGNEE_ADD3 = txtConsignee_Add3.Text;
        GSP.CONSIGNEE_ADD4 = txtConsignee_Add4.Text;
        GSP.CONSIGNEE_ADD5 = txtConsignee_Add5.Text;

        if (txtCountry.Text.Contains('-'))
        {
            string[] x1 = txtCountry.Text.Split('-');
            GSP.EXPORTER_COUNTRY = x1[0];
        }
        else
        {
            GSP.EXPORTER_COUNTRY = txtCountry.Text;
        }

        if (txtImporting_Country.Text.Contains('-'))
        {
            string[] x2 = txtImporting_Country.Text.Split('-');
            GSP.IMPORTER_COUNTRY = x2[0];
        }
        else
        {
            GSP.IMPORTER_COUNTRY = txtImporting_Country.Text;
        }
        GSP.PLACE_DATE = txtPlace_Date.Text;

        GSP.ENTERED_BY = txtEntered_By.Text;
        if (txtDepature_Date.Text != "")
        {
            GSP.DEPATURE_DATE = txtDepature_Date.Text;
        }
        else
        {
            GSP.DEPATURE_DATE = "01/01/1900";
        }
        GSP.VESSEL_AIRCRAFT_NAME = txtVesselName_Aircraft.Text;

        if (txtPort_Of_Discharge.Text.Contains('-'))
        {
            string[] x3 = txtPort_Of_Discharge.Text.Split('-');
            GSP.PORT_DISCHARGE = x3[0];
        }
        else
        {
            GSP.PORT_DISCHARGE = txtPort_Of_Discharge.Text;
        }

        GSP.TRANSPORT_ROUTE = txtTransport_Route.Text;
        GSP.ITEM_NO = txtItemNo.Text;
        //GSP.MARKS_NOS = txtMarks_Packages.Text;

        //*****************************MARKS AND NOS START*******************

        //if (ddl_type.SelectedValue == "3")
        //{

            M_NOS = txtMarks_Packages.Text;

            marksVal = txt_Marks_Val.Text;

            if (marksVal != "")
            {
                Val_Marks = Convert.ToInt32(marksVal);
            }
            else
            {
                marksVal = "13";
                Val_Marks = Convert.ToInt32(marksVal);

            }

            if (M_NOS.Contains('~'))
            {
                //M_NOS = M_NOS.Trim(new char[] { '~' });
                M_NOS = txtMarks_Packages.Text.Replace("~", "");
                txtMarks_Packages.Text = M_NOS;

                //txtMarks_Packages.Text = txtMarks_Packages.Text.Replace(dell_blcnk, "~");
            }
            else
            {
                txtMarks_Packages.Text = M_NOS;
            }

            string[] M_lines = this.txtMarks_Packages.Text.Split('\n');
            int M_line_count = M_lines.Length;

            if (M_line_count >= Val_Marks)
            {

                int ii = Val_Marks;
                int x = 1;

                string lineval = M_lines[x];

                foreach (string s in M_lines)
                {
                    strr += s;

                    if (x == ii)
                    {
                        strr = strr + "~";
                        ss += strr;
                        ii = ii + Val_Marks;
                        strr = "";
                    }
                    else
                    {
                        ss += strr + "\n";
                        strr = "";

                    }
                    x++;
                }
                ss = ss.TrimEnd('\n');
                ss = ss.TrimEnd('~');


                txtMarks_Packages.Text = ss + "~";

                txtMarks_Packages.Text = txtMarks_Packages.Text.Replace(dell, "~");
                txtMarks_Packages.Text = txtMarks_Packages.Text.Replace(dell_blcnk, "~");

            }
            else
            {
                GSP.MARKS_NOS = txtMarks_Packages.Text;
            }
        //}
        //else
        //{
        //    txtMarks_Packages.Text = txtMarks_Packages.Text.Replace("~", "");
        //}

        GSP.MARKS_NOS = txtMarks_Packages.Text;

        //*****************************MARKS AND NOS END*******************

        //*****************************DESCRIPTION START*******************
        //if (ddl_type.SelectedValue == "3")
        //{

            DescVal = txt_Desc_Val.Text;

            if (DescVal != "")
            {
                Val_Desc = Convert.ToInt32(DescVal);
            }
            else
            {
                DescVal = "25";
                Val_Desc = Convert.ToInt32(DescVal);
            }

            GSP_description = txtNo_Kind_Of_Packages_Desc.Text;

            if (GSP_description.Contains('~'))
            {
                //GSP_description = GSP_description.Trim(new char[] {'~'});
                GSP_description = txtNo_Kind_Of_Packages_Desc.Text.Replace("~", "");
                txtNo_Kind_Of_Packages_Desc.Text = GSP_description;
            }
            else
            {
            }

            string[] lines = this.GSP_description.Split('\n');
            int line_count = lines.Length;

            if (line_count >= Val_Desc)
            {

                int ii = Val_Desc;
                int x = 1;

                string lineval = lines[x];

                foreach (string st in lines)
                {
                    description += st;

                    if (x == ii)
                    {
                        description = description + "~";
                        goods_st += description;
                        ii = ii + Val_Desc;
                        description = "";
                    }
                    else
                    {
                        goods_st += description + "\n";
                        description = "";

                    }
                    x++;
                }

                goods_st = goods_st.TrimEnd('\n');
                goods_st = goods_st.TrimEnd('~');

                txtNo_Kind_Of_Packages_Desc.Text = goods_st.TrimEnd() + "~";

                txtNo_Kind_Of_Packages_Desc.Text = txtNo_Kind_Of_Packages_Desc.Text.Replace(dell, "~");
                txtNo_Kind_Of_Packages_Desc.Text = txtNo_Kind_Of_Packages_Desc.Text.Replace(dell_blcnk, "~");

            }
            else
            {
                GSP.DESCRIPTION = txtNo_Kind_Of_Packages_Desc.Text;
            }
        //}
        //else
        //{
        //    txtNo_Kind_Of_Packages_Desc.Text = txtNo_Kind_Of_Packages_Desc.Text.Replace("~", "");
        //}
            GSP.DESCRIPTION = txtNo_Kind_Of_Packages_Desc.Text.Trim(); 

        //*****************************DESCRIPTION END*******************

        GSP.ORIGIN = txtOrigin_Criteria.Text;
        GSP.GROSS_WEIGHT = txtGross_Weight.Text;
        GSP.INVOICE_NO_DATE = txtInvoiceNo_Date.Text;
        GSP.DEC1 = txtDeclare_Line1.Text;
        GSP.DEC2 = txtDeclare_Line2.Text;
        GSP.DEC3 = txtDeclare_Line3.Text;

        GSP.SPE1 = txtSpecifies_Line1.Text;
        GSP.SPE2 = txtSpecifies_Line2.Text;
        GSP.SPE3 = txtSpecifies_Line3.Text;
        GSP.SPE4 = txtSpecifies_Line4.Text;
        GSP.SPE5 = txtSpecifies_Line5.Text;

        GSP.SUB1 = txtSubmit_Line1.Text;
        GSP.SUB2 = txtSubmit_Line2.Text;
        GSP.SUB3 = txtSubmit_Line3.Text;
        GSP.SUB4 = txtSubmit_Line4.Text;

        GSP.REQ1 = txtRequest1.Text;
        GSP.REQ2 = txtRequest2.Text;
        GSP.REQ3 = txtRequest3.Text;
        GSP.REQ4 = txtRequest4.Text;
        GSP.REQ5 = txtRequest5.Text;
        GSP.REQ6 = txtRequest6.Text;
      
        GSP.USER_ID = currentuser;
        GSP.YEAR = "";
        GSP.flag = Flag;
        GSP.BRANCH_CODE = currentbranch;
        GSP.WORKING_PERIOD = Working_Period;
        GSP.BRANCH_COMMON = SELECT_BRANCH;

        i = GSP.GSP_details_insertupdate();

        return i;
    }

    public void Get_DropDown_SelectedIndexChanged()
    {
        try
        {
            //Clear();
            if (Request.QueryString["Page"] == "New")
            {
                GSP.JOBNO = ViewState["hdn_fileRef_Jobno"].ToString();
                GSP.Ename = "select_GSP_Details";
                hdn_Jobno.Value = ViewState["hdn_fileRef_Jobno"].ToString();
                //txt_JobNo.Visible = false;
                ddlJobNo.Visible = true;

            }
            else
            {
                ddlJobNo.Visible = false;
                //txt_JobNo.Visible = true;
                GSP.JOBNO = Request.QueryString["Page"].ToString();
                GSP.Ename = "Bind_GSP_Details";
            }


            //if (ddlJobNo.SelectedItem.Text != "Select")
            //{
               
                //CHKLIST.JOBNo = ddlJobNo.SelectedValue.ToString();
                //CHKLIST.Ename = "select_gsp_details";
                GSP.BRANCH_CODE = SELECT_BRANCH;
                ds = GSP.GSP_NORMAL_SEARCH();

                int i = GSP.result;

                if (i == 1)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                       
                        FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                        txtExporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                        BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                        IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
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
                        txtConsignee_Add5.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();

                        txtPort_Of_Discharge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();
                        //txtFinal_Destination.Text = ds.Tables[0].Rows[0]["COUNTRY_FINAL_DEST"].ToString();

                        TRANSPORT_MODE = ds.Tables[0].Rows[0]["TRANSPORT_MODE"].ToString();
                        //cust = ds.Tables[0].Rows[0]["CUSTOMS_HOUSE"].ToString();

                        if (ds.Tables[2].Rows.Count > 0)
                        {
                            //txtInvoiceNo_Date.Text = "INVOICE NO :"+ Environment.NewLine +ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() +Environment.NewLine+ ds.Tables[2].Rows[0]["INVOICE_DATE"].ToString().Replace("01/01/1900", "");
                            txtInvoiceNo_Date.Text = "INVOICE NO :  " +  ds.Tables[2].Rows[0]["INVOICE_NO"].ToString() +"  "+ ds.Tables[2].Rows[0]["INVOICE_DATE"].ToString().Replace("01/01/1900", "");
                        }

                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            txtNo_Kind_Of_Packages_Desc.Text = ds.Tables[1].Rows[0]["ITEM_DESCRIPTION"].ToString();
                            //txtNo_Kind_Of_Packages_Desc.Text = "";
                        }

                        if (TRANSPORT_MODE == "Air")
                        {
                            if (ds.Tables[3].Rows.Count > 0)
                            {
                                txtMarks_Packages.Text = ds.Tables[3].Rows[0]["ANNEX_AIR_MARKS_NOS"].ToString();
                                //txtMarks_Packages.Text = "";

                                if (ds.Tables[3].Rows[0]["GROSS_WEIGHT"].ToString() != "")
                                {
                                    txtGross_Weight.Text = "GROSS WGT :" + Environment.NewLine + ds.Tables[3].Rows[0]["GROSS_WEIGHT"].ToString();
                                }
                                else
                                {
                                    txtGross_Weight.Text = "";
                                }
                            }
                        }
                        else if (TRANSPORT_MODE == "Sea")
                        {
                            if (ds.Tables[4].Rows.Count > 0)
                            {
                                txtMarks_Packages.Text = ds.Tables[4].Rows[0]["ANNEX_SEA_MARKS_NOS"].ToString();
                                //txtMarks_Packages.Text = "";

                                if (ds.Tables[4].Rows[0]["GROSS_WEIGHT"].ToString() != "")
                                {
                                    txtGross_Weight.Text = "GROSS WGT :" + Environment.NewLine + ds.Tables[4].Rows[0]["GROSS_WEIGHT"].ToString();
                                }
                                else
                                {
                                    txtGross_Weight.Text = "";
                                }
                            }
                        }
                        btnUpdate.Visible = false;
                        btnDelete.Visible = false;
                        //btnSearch.Visible = false;
                        btnSave.Visible = true;
                        btnNew.Visible = true;
                        btn_next.Visible = false;
                        btn_prev.Visible = false;
                        ddlJobNo.Visible = true;
                    }
                }
                else if (i == 2)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ddl_ExporterName.Visible = false;
                        txt_ExporterName.Visible = true;
                        txt_File_RefNo.Visible = true;
                        txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                        hdn_Jobno.Value = txt_JobNo.Text;

                        FILE_REF_NO = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                        txt_File_RefNo.Text = FILE_REF_NO;
                        txtExporter.Text = ds.Tables[0].Rows[0]["EXPORTER_NAME"].ToString();
                        BRANCH_NO = ds.Tables[0].Rows[0]["BRANCH_NO"].ToString();
                        IEC_NO = ds.Tables[0].Rows[0]["IEC_NO"].ToString();
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
                        txtConsignee_Add5.Text = ds.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString();

                        txtCountry.Text = ds.Tables[0].Rows[0]["EXPORTER_COUNTRY"].ToString();
                        txtImporting_Country.Text = ds.Tables[0].Rows[0]["IMPORTER_COUNTRY"].ToString();
                        txtPlace_Date.Text = ds.Tables[0].Rows[0]["PLACE_DATE"].ToString();
                        txtEntered_By.Text = ds.Tables[0].Rows[0]["ENTERED_BY"].ToString();

                        if (txtDepature_Date.Text == "01/01/1900")
                        {
                            txtDepature_Date.Text = "";
                        }
                        else
                        {
                            txtDepature_Date.Text = ds.Tables[0].Rows[0]["DEPATURE_DATE"].ToString();
                        }
                        txtVesselName_Aircraft.Text = ds.Tables[0].Rows[0]["VESSEL_AIRCRAFT_NAME"].ToString();
                        txtPort_Of_Discharge.Text = ds.Tables[0].Rows[0]["PORT_DISCHARGE"].ToString();

                        txtTransport_Route.Text = ds.Tables[0].Rows[0]["TRANSPORT_ROUTE"].ToString();
                        txtItemNo.Text = ds.Tables[0].Rows[0]["ITEM_NO"].ToString();
                        txtMarks_Packages.Text = ds.Tables[0].Rows[0]["MARKS_NOS"].ToString();

                        txtNo_Kind_Of_Packages_Desc.Text = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();

                        string[] lines = this.txtNo_Kind_Of_Packages_Desc.Text.Split('\n');
                        int line_count = lines.Length;

                        txtOrigin_Criteria.Text = ds.Tables[0].Rows[0]["ORIGIN"].ToString();
                        txtGross_Weight.Text = ds.Tables[0].Rows[0]["GROSS_WEIGHT"].ToString();
                        txtInvoiceNo_Date.Text = ds.Tables[0].Rows[0]["INVOICE_NO_DATE"].ToString();
                        txtDeclare_Line1.Text = ds.Tables[0].Rows[0]["DEC1"].ToString();
                        txtDeclare_Line2.Text = ds.Tables[0].Rows[0]["DEC2"].ToString();
                        txtDeclare_Line3.Text = ds.Tables[0].Rows[0]["DEC3"].ToString();

                        txtSpecifies_Line1.Text = ds.Tables[0].Rows[0]["SPE1"].ToString();
                        txtSpecifies_Line2.Text = ds.Tables[0].Rows[0]["SPE2"].ToString();
                        txtSpecifies_Line3.Text = ds.Tables[0].Rows[0]["SPE3"].ToString();
                        txtSpecifies_Line4.Text = ds.Tables[0].Rows[0]["SPE4"].ToString();
                        txtSpecifies_Line5.Text = ds.Tables[0].Rows[0]["SPE5"].ToString();

                        txtSubmit_Line1.Text = ds.Tables[0].Rows[0]["SUB1"].ToString();
                        txtSubmit_Line2.Text = ds.Tables[0].Rows[0]["SUB2"].ToString();
                        txtSubmit_Line3.Text = ds.Tables[0].Rows[0]["SUB3"].ToString();
                        txtSubmit_Line4.Text = ds.Tables[0].Rows[0]["SUB4"].ToString();

                        txtRequest1.Text = ds.Tables[0].Rows[0]["REQ1"].ToString();
                        txtRequest2.Text = ds.Tables[0].Rows[0]["REQ2"].ToString();
                        txtRequest3.Text = ds.Tables[0].Rows[0]["REQ3"].ToString();
                        txtRequest4.Text = ds.Tables[0].Rows[0]["REQ4"].ToString();
                        txtRequest5.Text = ds.Tables[0].Rows[0]["REQ5"].ToString();
                        txtRequest6.Text = ds.Tables[0].Rows[0]["REQ6"].ToString();

                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnSave.Visible = false;
                        btnNew.Visible = false;
                        //btnSearch.Visible = false;
                        btn_next.Visible = true;
                        btn_prev.Visible = true;
                        txt_JobNo.Visible = true;
                        ddlJobNo.Visible = false;
                    }
                }

                Get_FILE_REF_NO();
            //}
            //else
            //{
            //    trans.ResetFields(Page.Controls);
            //}
               
        }
        catch (Exception ex)
        {
            ErrorLogs er = new ErrorLogs();

            er.makeLog
                (ex.Message);
        }
    }
    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJobNo.SelectedItem.Text == "Select")
        {
            FILE_REF_NO = "";
            txtExporter.Text = "";
            BRANCH_NO = "";
            IEC_NO = "";
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
            txtConsignee_Add5.Text = "";

            txtCountry.Text = "";
            txtImporting_Country.Text = "";
            txtPlace_Date.Text = "";
            txtEntered_By.Text = "";

            txtDepature_Date.Text = "";
            txtVesselName_Aircraft.Text = "";
            txtPort_Of_Discharge.Text = "";

            txtTransport_Route.Text = "";
            txtItemNo.Text = "";
            txtMarks_Packages.Text = "";

            txtNo_Kind_Of_Packages_Desc.Text = "";
            txtOrigin_Criteria.Text = "";
            txtGross_Weight.Text = "";
            txtInvoiceNo_Date.Text = "";
            txtDeclare_Line1.Text = "";
            txtDeclare_Line2.Text = "";

            txtDeclare_Line3.Text = "";
            txtSpecifies_Line1.Text = "";
            txtSpecifies_Line2.Text = "";
            txtSpecifies_Line3.Text = "";
            txtSpecifies_Line4.Text = "";
            txtSpecifies_Line5.Text = "";

            txtSubmit_Line1.Text = "";
            txtSubmit_Line2.Text = "";
            txtSubmit_Line3.Text = "";
            txtSubmit_Line4.Text = "";
            txtRequest1.Text = "";

            txtRequest2.Text = "";
            txtRequest3.Text = "";
            txtRequest4.Text = "";
            txtRequest5.Text = "";
            txtRequest6.Text = "";

        }
        else
        {
            GET_JOBNO_From_FILE_REF_NO();
            //Get_DropDown_SelectedIndexChanged();
        }
    }

    public void Clear()
    {
        FILE_REF_NO = "";
        txtExporter.Text = "";
        BRANCH_NO = "";
        IEC_NO = "";
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
        txtConsignee_Add5.Text = "";

        txtCountry.Text = "";
        txtImporting_Country.Text = "";
        txtPlace_Date.Text = "";
        txtEntered_By.Text = "";

        txtDepature_Date.Text = "";
        txtVesselName_Aircraft.Text = "";
        txtPort_Of_Discharge.Text = "";

        txtTransport_Route.Text = "";
        txtItemNo.Text = "";
        txtMarks_Packages.Text = "";

        txtNo_Kind_Of_Packages_Desc.Text = "";
        txtOrigin_Criteria.Text = "";
        txtGross_Weight.Text = "";
        txtInvoiceNo_Date.Text = "";
        txtDeclare_Line1.Text = "";
        txtDeclare_Line2.Text = "";

        txtDeclare_Line3.Text = "";
        txtSpecifies_Line1.Text = "";
        txtSpecifies_Line2.Text = "";
        txtSpecifies_Line3.Text = "";
        txtSpecifies_Line4.Text = "";
        txtSpecifies_Line5.Text = "";

        txtSubmit_Line1.Text = "";
        txtSubmit_Line2.Text = "";
        txtSubmit_Line3.Text = "";
        txtSubmit_Line4.Text = "";
        txtRequest1.Text = "";

        txtRequest2.Text = "";
        txtRequest3.Text = "";
        txtRequest4.Text = "";
        txtRequest5.Text = "";
        txtRequest6.Text = "";
    }

    protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_DropDown_SelectedIndexChanged();
    }
    protected void ddl_ExporterName_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_JobNo();
    }

    [System.Web.Services.WebMethod]
    public static string Get_Report_Client_Details(string custid)
    {
        DataSet ds = new DataSet();
        try
        {
            Rpt_Client_Master Rpt_Clt = new Rpt_Client_Master();

            Rpt_Clt.RPT_ID = "";
            Rpt_Clt.CLIENT_NAME = custid;
            Rpt_Clt.CLIENT_TYPE = HttpContext.Current.Session["Exporter"].ToString();
            Rpt_Clt.CLIENT_WORKING_PERIOD = HttpContext.Current.Session["WorkingPeriod"].ToString();
            Rpt_Clt.CLIENT_BRANCH_CODE = HttpContext.Current.Session["currentbranch"].ToString();

            Rpt_Clt.Ename = "Bind_Report_ClientName_Type";
            ds = Rpt_Clt.RetrieveAll_Rpt_Client_Details();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string txtAddress1 = ds.Tables[0].Rows[0]["CLIENT_ADD1"].ToString();
                string txtAddress2 = ds.Tables[0].Rows[0]["CLIENT_ADD2"].ToString();
                string txtAddress3 = ds.Tables[0].Rows[0]["CLIENT_ADD3"].ToString();
                string txtAddress4 = ds.Tables[0].Rows[0]["CLIENT_ADD4"].ToString();
                string txtAddress5 = ds.Tables[0].Rows[0]["CLIENT_COUNTRY_NAME"].ToString();
                //string txtCess_Qty = ds.Tables[0].Rows[0]["CESS_QTY"].ToString();
                //string txtTar_Unit = ds.Tables[0].Rows[0]["TAR_UNIT"].ToString();

                //custid = txtAddress1 + "~~" + txtAddress2 + "~~" + txtAddress3 + "~~" + txtAddress4 + "~~" + txtAddress5 + "~~" + txtCess_Qty + "~~" + txtTar_Unit;
                custid = txtAddress1 + "~~" + txtAddress2 + "~~" + txtAddress3 + "~~" + txtAddress4 + "~~" + txtAddress5;

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
    public static string Get_Report_Consignee_Details(string custid)
    {
        DataSet ds = new DataSet();
        try
        {
            Rpt_Client_Master Rpt_Clt = new Rpt_Client_Master();

            Rpt_Clt.RPT_ID = "";
            Rpt_Clt.CLIENT_NAME = custid;
            Rpt_Clt.CLIENT_TYPE = HttpContext.Current.Session["Consignee"].ToString();
            Rpt_Clt.CLIENT_WORKING_PERIOD = HttpContext.Current.Session["WorkingPeriod"].ToString();
            Rpt_Clt.CLIENT_BRANCH_CODE = HttpContext.Current.Session["currentbranch"].ToString();

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
}