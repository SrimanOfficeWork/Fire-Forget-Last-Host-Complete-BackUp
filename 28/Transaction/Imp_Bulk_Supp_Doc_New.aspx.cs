using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Linq;
using BussinessObject;

public partial class Imp_Bulk_Supp_Doc_New : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH, Jobno, COMPANY_ID = "", currentbranch;
    SW_Support_Docs Sup_docs = new SW_Support_Docs();
    UserBO ObjUBO = new UserBO();
    DataSet ds = new DataSet();
    DataSet dgt = new DataSet();
    DataSet dss = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();
            SELECT_BRANCH = Connection.Get_Company_Type();

            COMPANY_ID = Connection.COMPANYID();
            currentbranch = Session["currentbranch"].ToString();

            if (Request.QueryString["JOBID"] != "" && Request.QueryString["JOBID"] != null)
            {
                Jobno = Request.QueryString["JOBID"].ToString();
            }
            else
            {
                Jobno = Connection.IMP_Jobno();
            }

            hdn_jobno.Value = Jobno;
            lbljobno.Text = Jobno;
            txt_CurrJobno.Text = Jobno;

            if (!Page.IsPostBack)
            {
                AutoJobNO();
                Bind_Currnt_Job_Invoice_Items();

                DataTable dtEmpty = new DataTable();
                gvdetails.DataSource = dtEmpty;
                gvdetails.DataBind();

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    protected void gvdetails_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Bulk SUPPORING DOCS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Bulk SUPPORING DOCS', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private DataTable Get_Updated_Gridview_Data()
    {
        DataTable dt_new = new DataTable();
        try
        {
            DataTable dtFull = (DataTable)ViewState["FULL_JOB_DATA"];

            dt_new.Columns.Add("SW_ID");
            dt_new.Columns.Add("INVOICE_SLNO");
            dt_new.Columns.Add("ITEM_SLNO");
            dt_new.Columns.Add("IMAGE_REF_NUMBER");
            dt_new.Columns.Add("DOC_TYPE_CODE");
            dt_new.Columns.Add("DOC_ISSUING_PARTY_NAME");
            dt_new.Columns.Add("PLACE_OF_ISSUE");
            dt_new.Columns.Add("DOC_ISSUE_DATE");
            dt_new.Columns.Add("BENEFICIARY_PARTY_NAME");
            dt_new.Columns.Add("ICEGATE_ID");
            dt_new.Columns.Add("SELECT_TYPE");
            dt_new.Columns.Add("DOC_ISSUING_PARTY_CODE");
            dt_new.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD1");
            dt_new.Columns.Add("DOC_ISSUING_PARTY_NAME_ADD2");
            dt_new.Columns.Add("DOC_ISSUING_PARTY_CITY");
            dt_new.Columns.Add("DOC_ISSUING_PARTY_PIN");
            dt_new.Columns.Add("DOC_REF_NUMBER");
            dt_new.Columns.Add("DOC_EXPIRY_DATE");
            dt_new.Columns.Add("BENEFICIARY_PARTY_CODE");
            dt_new.Columns.Add("BENEFICIARY_PARTY_ADDRESS1");
            dt_new.Columns.Add("BENEFICIARY_PARTY_ADDRESS2");
            dt_new.Columns.Add("BENEFICIARY_PARTY_CITY");
            dt_new.Columns.Add("BENEFICIARY_PARTY_PIN");
            dt_new.Columns.Add("FILE_TYPE");
            dt_new.Columns.Add("ICEGATE_DOC_FILE_NAME");


            int rowIndex = gvdetails.Rows.Count;
            DataRow drCurrentRow = null;
            int chked_cnt = 0;
            string str_issuedat = "";
            string Status = "0";

            if (gvdetails.Rows.Count > 0)
            {
                for (int i = 0; i < gvdetails.Rows.Count; i++)
                {
                    CheckBox chk_All = (CheckBox)gvdetails.Rows[i].Cells[0].FindControl("chk_All");
                    TextBox txt_SW_ID = (TextBox)gvdetails.Rows[i].Cells[0].FindControl("txt_SW_ID");
                    TextBox txt_InvSlno = (TextBox)gvdetails.Rows[i].Cells[0].FindControl("txt_InvSlno");
                    TextBox txtItemSlNo = (TextBox)gvdetails.Rows[i].Cells[1].FindControl("txtItemSlNo");
                    TextBox txtImage_RefNo = (TextBox)gvdetails.Rows[i].Cells[2].FindControl("txtImage_RefNo");
                    TextBox txtDoc_TypeCode = (TextBox)gvdetails.Rows[i].Cells[3].FindControl("txtDoc_TypeCode");
                    TextBox txtIss_PartyName = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txtIss_PartyName");
                    TextBox txtPlace_Of_Issue = (TextBox)gvdetails.Rows[i].Cells[5].FindControl("txtPlace_Of_Issue");
                    TextBox txtIssue_Date = (TextBox)gvdetails.Rows[i].Cells[6].FindControl("txtIssue_Date");
                    TextBox txtBenPartyName = (TextBox)gvdetails.Rows[i].Cells[7].FindControl("txtBenPartyName");
                    TextBox txt_IcegateID = (TextBox)gvdetails.Rows[i].Cells[8].FindControl("txt_IcegateID");
                    TextBox txtLevel = (TextBox)gvdetails.Rows[i].Cells[8].FindControl("txtLevel");
                    TextBox txt_Doc_Iss_Party_Code = (TextBox)gvdetails.Rows[i].Cells[9].FindControl("txt_Doc_Iss_Party_Code");
                    TextBox txt_Doc_Iss_Party_Add1 = (TextBox)gvdetails.Rows[i].Cells[10].FindControl("txt_Doc_Iss_Party_Add1");
                    TextBox txt_Doc_Iss_Party_Add2 = (TextBox)gvdetails.Rows[i].Cells[11].FindControl("txt_Doc_Iss_Party_Add2");
                    TextBox txt_Doc_Iss_Party_City = (TextBox)gvdetails.Rows[i].Cells[12].FindControl("txt_Doc_Iss_Party_City");
                    TextBox txt_Doc_Iss_Party_Pin = (TextBox)gvdetails.Rows[i].Cells[13].FindControl("txt_Doc_Iss_Party_Pin");
                    TextBox txt_Doc_Iss_Party_Ref_No = (TextBox)gvdetails.Rows[i].Cells[14].FindControl("txt_Doc_Iss_Party_Ref_No");
                    TextBox txt_Doc_Expiry_Date = (TextBox)gvdetails.Rows[i].Cells[15].FindControl("txt_Doc_Expiry_Date");
                    TextBox txt_Ben_party_Code = (TextBox)gvdetails.Rows[i].Cells[16].FindControl("txt_Ben_party_Code");
                    TextBox txt_Ben_party_Name = (TextBox)gvdetails.Rows[i].Cells[17].FindControl("txt_Ben_party_Name");
                    TextBox txt_Ben_party_Add1 = (TextBox)gvdetails.Rows[i].Cells[18].FindControl("txt_Ben_party_Add1");
                    TextBox txt_Ben_party_Add2 = (TextBox)gvdetails.Rows[i].Cells[19].FindControl("txt_Ben_party_Add2");
                    TextBox txt_Ben_Party_City = (TextBox)gvdetails.Rows[i].Cells[20].FindControl("txt_Ben_Party_City");
                    TextBox txt_Ben_Party_Pin = (TextBox)gvdetails.Rows[i].Cells[21].FindControl("txt_Ben_Party_Pin");
                    TextBox txt_File_type = (TextBox)gvdetails.Rows[i].Cells[22].FindControl("txt_File_type");
                    TextBox txt_IcegateFileName = (TextBox)gvdetails.Rows[i].Cells[23].FindControl("txt_IcegateFileName");



                    if (chk_All.Checked == true)
                    {
                        Status = "0";
                        dt_new.Rows.Add();

                        if (txt_InvSlno.Text != "" && txtItemSlNo.Text != "" && txtImage_RefNo.Text != "" && txtDoc_TypeCode.Text != "" && txtIss_PartyName.Text != "" && txtPlace_Of_Issue.Text != "" && txtIssue_Date.Text != "" && txtBenPartyName.Text != "" && txt_IcegateID.Text != "" && txtLevel.Text != "")
                        {
                            Status = "1";
                        }


                        if (Status == "1")
                        {
                            dt_new.Rows[chked_cnt]["SW_ID"] = txt_SW_ID.Text;
                            dt_new.Rows[chked_cnt]["INVOICE_SLNO"] = txt_InvSlno.Text;
                            dt_new.Rows[chked_cnt]["ITEM_SLNO"] = txtItemSlNo.Text;
                            dt_new.Rows[chked_cnt]["IMAGE_REF_NUMBER"] = txtImage_RefNo.Text;
                            dt_new.Rows[chked_cnt]["DOC_TYPE_CODE"] = txtDoc_TypeCode.Text;
                            dt_new.Rows[chked_cnt]["DOC_ISSUING_PARTY_NAME"] = txtIss_PartyName.Text;
                            dt_new.Rows[chked_cnt]["PLACE_OF_ISSUE"] = txtPlace_Of_Issue.Text;

                            string[] sp = txtIssue_Date.Text.Split('/');
                            str_issuedat = sp[1] + "/" + sp[0] + "/" + sp[2];

                            dt_new.Rows[chked_cnt]["DOC_ISSUE_DATE"] = str_issuedat;
                            dt_new.Rows[chked_cnt]["BENEFICIARY_PARTY_NAME"] = txtBenPartyName.Text;
                            dt_new.Rows[chked_cnt]["ICEGATE_ID"] = txt_IcegateID.Text;
                            dt_new.Rows[chked_cnt]["SELECT_TYPE"] = txtLevel.Text;

                            dt_new.Rows[chked_cnt]["DOC_ISSUING_PARTY_CODE"] = dtFull.Rows[i]["DOC_ISSUING_PARTY_CODE"];

                            dt_new.Rows[chked_cnt]["DOC_ISSUING_PARTY_NAME_ADD1"] =
                                dtFull.Rows[i]["DOC_ISSUING_PARTY_NAME_ADD1"];

                            dt_new.Rows[chked_cnt]["DOC_ISSUING_PARTY_NAME_ADD2"] =
                                dtFull.Rows[i]["DOC_ISSUING_PARTY_NAME_ADD2"];

                            dt_new.Rows[chked_cnt]["DOC_ISSUING_PARTY_CITY"] =
                                dtFull.Rows[i]["DOC_ISSUING_PARTY_CITY"];

                            dt_new.Rows[chked_cnt]["DOC_ISSUING_PARTY_PIN"] =
                                dtFull.Rows[i]["DOC_ISSUING_PARTY_PIN"];

                            dt_new.Rows[chked_cnt]["DOC_REF_NUMBER"] =
                                dtFull.Rows[i]["DOC_REF_NUMBER"];

                            dt_new.Rows[chked_cnt]["DOC_EXPIRY_DATE"] =
                                dtFull.Rows[i]["DOC_EXPIRY_DATE"];

                            dt_new.Rows[chked_cnt]["BENEFICIARY_PARTY_CODE"] =
                                dtFull.Rows[i]["BENEFICIARY_PARTY_CODE"];

                            dt_new.Rows[chked_cnt]["BENEFICIARY_PARTY_ADDRESS1"] =
                                dtFull.Rows[i]["BENEFICIARY_PARTY_ADDRESS1"];

                            dt_new.Rows[chked_cnt]["BENEFICIARY_PARTY_ADDRESS2"] =
                                dtFull.Rows[i]["BENEFICIARY_PARTY_ADDRESS2"];

                            dt_new.Rows[chked_cnt]["BENEFICIARY_PARTY_CITY"] =
                                dtFull.Rows[i]["BENEFICIARY_PARTY_CITY"];

                            dt_new.Rows[chked_cnt]["BENEFICIARY_PARTY_PIN"] =
                                dtFull.Rows[i]["BENEFICIARY_PARTY_PIN"];

                            dt_new.Rows[chked_cnt]["FILE_TYPE"] =
                                dtFull.Rows[i]["FILE_TYPE"];

                            dt_new.Rows[chked_cnt]["ICEGATE_DOC_FILE_NAME"] =
                                dtFull.Rows[i]["ICEGATE_DOC_FILE_NAME"];


                            chked_cnt = chked_cnt + 1;
                            ViewState["Mandatory_Missing"] = "1";
                        }
                        else
                        {
                            Status = "2";
                            ViewState["Mandatory_Missing"] = "2";
                            break;
                        }
                    }
                }
            }

            if (Status == "0")
            {
                ViewState["Mandatory_Missing"] = "3"; // Grid Checkbox selected count is 0.
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return dt_new;
    }

    private void Action_Save_Update_Delete(string Action_flg)
    {
        try
        {
            string Status = "0";
            DataSet dss = new DataSet();
            DataTable dt_grid = Get_Updated_Gridview_Data();

            if (ViewState["Mandatory_Missing"].ToString() == "1")
            {
                Status = "1";
            }
            else if (ViewState["Mandatory_Missing"].ToString() == "2")
            {
                Alert_msg("Mandatory Value Missing!..");
                return;
            }
            else if (ViewState["Mandatory_Missing"].ToString() == "3")
            {
                Alert_msg("Select Grid CheckBox");
                return;
            }

            if (Status != "1" || dt_grid.Rows.Count == 0)
                return;

            // ================= SET OBJECT =================
            ObjUBO.JOBNO = Jobno;
            ObjUBO.INVOICE_SLNO = ListBox_Invoice_SlNo.SelectedValue;
            ObjUBO.ITEM_SLNO = ListBox_ItemSlno.SelectedValue;
            ObjUBO.Xml_A = Common_CS.ConvertDataTableToXML(dt_grid);
            ObjUBO.SELECT_TYPE = dt_grid.Rows[0]["SELECT_TYPE"].ToString();
            ObjUBO.IMAGE_REF_NUMBER = ListBox1.SelectedValue;
            ObjUBO.Doc_Type_Code = List_Doc_Type.SelectedValue;
            ObjUBO.Ename = Action_flg;

            // ================= CALL SP =================
            dss = Sup_docs.IMP_ITEM_SUPPROTING_DOCUMENTS_INS_UPD_DEL_BULK_SELECT_NEW(ObjUBO);

            // ================= RESULT HANDLING =================

            // -------- DELETE --------

            if (Action_flg == "btn_Delete")
            {
                if (Sup_docs.result > 0)
                {
                    MP_JOB.Hide();
                    Alert_msg(Sup_docs.result + " record(s) deleted successfully");
                    Remove_Checked_Rows_From_Grid();
                }
                else
                {
                    Alert_msg("Not deleted");
                }
                return;
            }

            if (Action_flg == "btn_Update")
            {
                if (Sup_docs.result > 0)
                {
                    MP_JOB.Hide();
                    Alert_msg(Sup_docs.result + " record(s) updated successfully");
                }
                else
                {
                    Alert_msg("Not updated");
                }
                return;
            }


            if (Action_flg == "btn_Save")
            {
                if (Sup_docs.result == 1)
                {
                    MP_JOB.Hide();
                    Alert_msg("Saved successfully");
                    return;
                }

                if (Sup_docs.result == 4)
                {
                    lbl_heading.Text = "Alert !! - Duplicate Record Found!";
                }
                else if (Sup_docs.result == 2)
                {
                    lbl_heading.Text = "Alert !! - Record Already Exists!";
                }
                else if (Sup_docs.result == 3)
                {
                    lbl_heading.Text = "Alert !! - Invalid Record - Found!";
                }
                else
                {
                    Alert_msg("Not saved");
                    return;
                }
                MP_JOB.Show();

                if (dss != null && dss.Tables.Count > 1)
                {
                    gv_Inv_Item.DataSource = dss.Tables[1];
                    gv_Inv_Item.DataBind();
                }
            }

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }



    private void Remove_Checked_Rows_From_Grid()
    {
        DataTable dt = ViewState["FULL_JOB_DATA"] as DataTable;
        if (dt == null) return;

        for (int i = gvdetails.Rows.Count - 1; i >= 0; i--)
        {
            CheckBox chk = (CheckBox)gvdetails.Rows[i].FindControl("chk_All");
            if (chk != null && chk.Checked)
            {
                string swId = ((TextBox)gvdetails.Rows[i]
                                .FindControl("txt_SW_ID")).Text;

                DataRow[] rows = dt.Select("SW_ID = '" + swId + "'");
                foreach (DataRow dr in rows)
                    dr.Delete();
            }
        }

        dt.AcceptChanges();
        ViewState["FULL_JOB_DATA"] = dt;

        gvdetails.DataSource = dt;
        gvdetails.DataBind();
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {
        Action_Save_Update_Delete("btn_Save");

    }

    protected void ddl_flg_SelectedIndexChanged(object sender, EventArgs e)
    {

        ListBox_Invoice_SlNo.SelectedIndex = -1;
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();

        btnsave.Visible = true;

        Bind_General_Supplier_New();

    }


    protected void btn_Load_Data_Click(object sender, EventArgs e)
    {

        try
        {
            Bind_General_Supplier_New();

            ObjUBO.JOBNO = ddlJobNo.SelectedValue;
            string Sup_Doc_Item_slno_ListBox = "";
            foreach (ListItem item in ListBox1.Items)
            {
                if (item.Selected)
                {
                    Sup_Doc_Item_slno_ListBox += item.Value + "~";
                }
            }

            string[] sup_doc_splt = Sup_Doc_Item_slno_ListBox.Split('~');
            string invoice_list = "", item_list = "", sup_doc = "";
            for (int i = 0; i < sup_doc_splt.Length; i++)
            {
                string[] item_inv_spltv2 = sup_doc_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                    sup_doc += item_inv_spltv2[2].ToString() + "~";
                }

            }

            ObjUBO.INVOICE_SLNO = invoice_list;
            ObjUBO.ITEM_SLNO = item_list;
            ObjUBO.IMAGE_REF_NUMBER = sup_doc;

            ObjUBO.DOC_REF_NUMBER = "";

            ObjUBO.Ename = "btn_ld";

            DataSet ds = dgt = Sup_docs.Get_SW_SupportingDocs(ObjUBO);

            DataTable dtFiltered = new DataTable();
            DataRow dr;

            dtFiltered.Columns.Add(new System.Data.DataColumn("SW_ID", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("ITEM_SLNO", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("IMAGE_REF_NUMBER", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_TYPE_CODE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_REF_NUMBER", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUING_PARTY_NAME", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("PLACE_OF_ISSUE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUE_DATE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("BENEFICIARY_PARTY_NAME", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("ICEGATE_ID", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("SELECT_TYPE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUING_PARTY_CODE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUING_PARTY_NAME_ADD1", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUING_PARTY_NAME_ADD2", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUING_PARTY_CITY", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUING_PARTY_PIN", typeof(String)));

            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_EXPIRY_DATE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("BENEFICIARY_PARTY_CODE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("BENEFICIARY_PARTY_ADDRESS1", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("BENEFICIARY_PARTY_ADDRESS2", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("BENEFICIARY_PARTY_CITY", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("BENEFICIARY_PARTY_PIN", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("FILE_TYPE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("ICEGATE_DOC_FILE_NAME", typeof(String)));

            string Curr_Item_ListBox = "";
            foreach (ListItem item in ListBox_ItemSlno_CURR.Items)
            {
                if (item.Selected)
                {
                    Curr_Item_ListBox += item.Value + "~";
                }
            }

            int rowCnt = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string[] Cur_Item_splt = Curr_Item_ListBox.Split('~');
                for (int k = 0; k < Cur_Item_splt.Length; k++)
                {
                    string[] Cur_Inv_Item = Cur_Item_splt[k].Split('-');

                    if (Cur_Inv_Item[0] != "")
                    {

                        dr = dtFiltered.NewRow();
                        dr[0] = k;
                        dr[1] = Cur_Inv_Item[0];
                        dr[2] = Cur_Inv_Item[1];
                        dr[3] = ds.Tables[0].Rows[i]["IMAGE_REF_NUMBER"].ToString();
                        dr[4] = ds.Tables[0].Rows[i]["DOC_TYPE_CODE"].ToString();
                        dr[5] = ds.Tables[0].Rows[i]["DOC_REF_NUMBER"].ToString();
                        dr[6] = hdn_IssPartyName.Value;// ds.Tables[0].Rows[i]["DOC_ISSUING_PARTY_NAME"].ToString();
                        dr[7] = ds.Tables[0].Rows[i]["PLACE_OF_ISSUE"].ToString();
                        dr[8] = ds.Tables[0].Rows[i]["DOC_ISSUE_DATE"].ToString();
                        dr[9] = hdn_BenPartyName.Value;// ds.Tables[0].Rows[i]["BENEFICIARY_PARTY_NAME"].ToString();
                        dr[10] = ds.Tables[0].Rows[i]["ICEGATE_ID"].ToString();
                        dr[11] = ds.Tables[0].Rows[i]["SELECT_TYPE"].ToString();

                        dr[12] = ds.Tables[0].Rows[i]["DOC_ISSUING_PARTY_CODE"].ToString();
                        dr[13] = ds.Tables[0].Rows[i]["DOC_ISSUING_PARTY_NAME_ADD1"].ToString();
                        dr[14] = ds.Tables[0].Rows[i]["DOC_ISSUING_PARTY_NAME_ADD2"].ToString();
                        dr[15] = ds.Tables[0].Rows[i]["DOC_ISSUING_PARTY_CITY"].ToString();
                        dr[16] = ds.Tables[0].Rows[i]["DOC_ISSUING_PARTY_PIN"].ToString();
                        dr[17] = ds.Tables[0].Rows[i]["DOC_EXPIRY_DATE"].ToString();

                        dr[18] = ds.Tables[0].Rows[i]["BENEFICIARY_PARTY_CODE"].ToString();
                        dr[19] = ds.Tables[0].Rows[i]["BENEFICIARY_PARTY_ADDRESS1"].ToString();
                        dr[20] = ds.Tables[0].Rows[i]["BENEFICIARY_PARTY_ADDRESS2"].ToString();
                        dr[21] = ds.Tables[0].Rows[i]["BENEFICIARY_PARTY_CITY"].ToString();
                        dr[22] = ds.Tables[0].Rows[i]["BENEFICIARY_PARTY_PIN"].ToString();
                        dr[23] = ds.Tables[0].Rows[i]["FILE_TYPE"].ToString();
                        dr[24] = ds.Tables[0].Rows[i]["ICEGATE_DOC_FILE_NAME"].ToString();

                        dtFiltered.Rows.Add(dr);
                        rowCnt = rowCnt + 1;
                    }
                }


            }

            gvdetails.DataSource = dtFiltered;
            gvdetails.DataBind();
            lbl_Cnt.Text = Convert.ToString(rowCnt);
            btnsave.Visible = true;

            ViewState["FULL_JOB_DATA"] = dtFiltered;

            if (ds.Tables[0].Rows.Count > 0)
                gvdetails.FooterRow.Visible = true;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    private void validate_Mandatory()
    {
        try
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txt_InvSlno = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txt_InvSlno");
                        TextBox txtItemSlNo = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtItemSlNo");
                        TextBox txtImage_RefNo = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtImage_RefNo");
                        TextBox txtDoc_TypeCode = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtDoc_TypeCode");
                        TextBox txtIss_PartyName = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtIss_PartyName");
                        TextBox txtPlace_Of_Issue = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtPlace_Of_Issue");
                        TextBox txtIssue_Date = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtIssue_Date");
                        TextBox txtBenPartyName = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtBenPartyName");
                        TextBox txt_IcegateID = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txt_IcegateID");
                        TextBox txtLevel = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtLevel");
                        if (txt_InvSlno.Text == "")
                        {

                        }
                        txt_InvSlno.Text = dt.Rows[i]["INVOICE_SLNO"].ToString();
                        txtItemSlNo.Text = dt.Rows[i]["ITEM_SLNO"].ToString();
                        txtImage_RefNo.Text = dt.Rows[i]["IMAGE_REF_NUMBER"].ToString();
                        txtDoc_TypeCode.Text = dt.Rows[i]["DOC_TYPE_CODE"].ToString();
                        txtIss_PartyName.Text = dt.Rows[i]["DOC_ISSUING_PARTY_NAME"].ToString();
                        txtPlace_Of_Issue.Text = dt.Rows[i]["PLACE_OF_ISSUE"].ToString();
                        txtIssue_Date.Text = dt.Rows[i]["DOC_ISSUE_DATE"].ToString();
                        txtBenPartyName.Text = dt.Rows[i]["BENEFICIARY_PARTY_NAME"].ToString();
                        txt_IcegateID.Text = dt.Rows[i]["ICEGATE_ID"].ToString();
                        txtLevel.Text = dt.Rows[i]["SELECT_TYPE"].ToString();

                        rowIndex++;

                        txt_InvSlno.Focus();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }


    [System.Web.Services.WebMethod]
    public static string[] test(string prefix)
    {
        List<string> countries = new List<string>();

        countries.Add("INDIA");
        countries.Add("AUSTRALIA");

        return countries.ToArray();
    }

    public void Bind_General_Supplier_New()
    {
        try
        {
            SW_Support_Docs Sup_Doc = new SW_Support_Docs();
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = hdn_jobno.Value;
            ObjUBO.INVOICE_SLNO = ListBox_Invoice_SlNo.SelectedValue == "" ? "1" : ListBox_Invoice_SlNo.SelectedValue;
            ObjUBO.ITEM_SLNO = "";
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;


            ObjUBO.Ename = "IMP_SUPPORTING_DOCUMENTS_Select";

            dss = Sup_Doc.SingleWindow_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                hdn_BenPartyName.Value = dss.Tables[0].Rows[0]["IMPORTER_NAME"].ToString().Replace("&nbsp;", "").Replace("&amp;", "&").Trim();
                hdn_IssPartyName.Value = dss.Tables[0].Rows[0]["SUPPLIER_NAME"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();


                if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1240" || Connection.COMPANYID() == "2145")
                {
                    hdn_PlaceOfIssue.Value = Session["ITEM_COUNTRY_OF_ORIGIN"].ToString();
                }

            }
            // txt_IcegateID_all.Text = Connection.Get_IMP_ICEGATE_ID_New();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }


    protected void gv_RITC_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_RITC_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Inv_Item.PageIndex = e.NewPageIndex;
    }

    protected void btnok_Click(object sender, EventArgs e)
    {
        MP_JOB.Hide();
    }

    private void AutoJobNO()
    {
        try
        {
            DataSet ds = Sup_docs.Get_Job_List();

            ddlJobNo.Items.Clear();

            ddlJobNo.Items.Add(new ListItem("--Select--", ""));

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlJobNo.DataSource = ds;
                ddlJobNo.DataTextField = "JOBNO";
                ddlJobNo.DataValueField = "JOBNO";
                ddlJobNo.DataBind();
                ddlJobNo.Items.Insert(0, "Select");
            }

            ddlJobNo.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_ddlJobno();
    }

    private void Bind_Currnt_Job_Invoice_Items()
    {
        try
        {
            DataSet ds_curr = new DataSet();
            ObjUBO.JOBNO = lbljobno.Text;
            ObjUBO.INVOICE_SLNO = "";
            ObjUBO.ITEM_SLNO = "";
            ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
            ObjUBO.Ename = "select_inv_Itm_CURR_JOBNO";
            ds_curr = Sup_docs.Supp_Doc_Select(ObjUBO);

            if (ds_curr.Tables[0].Rows.Count > 0)
            {
                ListBox_Invoice_SlNo_CURR.DataSource = ds_curr.Tables[0];
                ListBox_Invoice_SlNo_CURR.DataTextField = "INVOICE_SLNO";
                ListBox_Invoice_SlNo_CURR.DataValueField = "INVOICE_SLNO";
                ListBox_Invoice_SlNo_CURR.DataBind();
                ListBox_Invoice_SlNo_CURR.Enabled = true;

            }

            if (ds_curr.Tables[1].Rows.Count > 0)
            {
                ListBox_ItemSlno_CURR.Visible = true;
                ListBox_ItemSlno_CURR.DataSource = ds_curr.Tables[1];
                ListBox_ItemSlno_CURR.DataTextField = "ITEM_SLNO";
                ListBox_ItemSlno_CURR.DataValueField = "ITEM_SLNO";
                ListBox_ItemSlno_CURR.DataBind();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

    }

    private void Bind_ddlJobno()
    {
        try
        {
            ObjUBO.JOBNO = ddlJobNo.SelectedItem.Text;
            ObjUBO.INVOICE_SLNO = "";
            ObjUBO.ITEM_SLNO = "";
            ObjUBO.DOC_REF_NUMBER = "";
            ObjUBO.IMAGE_REF_NUMBER = "";
            ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
            ObjUBO.Ename = "select_inv_Itm_no";

            DataSet ds_supp = Sup_docs.Supp_Doc_Select(ObjUBO);

            // -------- INVOICE SLNO (TABLE 0) --------
            if (ds_supp != null && ds_supp.Tables.Count > 0 && ds_supp.Tables[0].Rows.Count > 0)
            {
                ListBox_Invoice_SlNo.DataSource = ds_supp.Tables[0];
                ListBox_Invoice_SlNo.DataTextField = "INVOICE_SLNO";
                ListBox_Invoice_SlNo.DataValueField = "INVOICE_SLNO";
                ListBox_Invoice_SlNo.DataBind();
            }


            // -------- ITEM SLNO (TABLE 1) --------
            if (ds_supp != null && ds_supp.Tables.Count > 1 && ds_supp.Tables[1].Rows.Count > 0)
            {
                ListBox_ItemSlno.Visible = true;
                ListBox_ItemSlno.DataSource = ds_supp.Tables[1];
                ListBox_ItemSlno.DataTextField = "ITEM_SLNO";
                ListBox_ItemSlno.DataValueField = "ITEM_SLNO";
                ListBox_ItemSlno.DataBind();
            }
            else
            {
                ListBox_ItemSlno.Items.Clear();
                ListBox_ItemSlno.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void ListBox_Invoice_SlNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds_supp = new DataSet();
            ObjUBO.JOBNO = ddlJobNo.SelectedItem.Text;
            string Invoice_Selected_ListBox = "";
            foreach (ListItem invoice in ListBox_Invoice_SlNo.Items)
            {
                if (invoice.Selected)
                {
                    Invoice_Selected_ListBox += invoice.Value + "~";
                }
            }

            if (Invoice_Selected_ListBox != "")
            {

                ObjUBO.INVOICE_SLNO = Invoice_Selected_ListBox;

                ObjUBO.ITEM_SLNO = "";

                ObjUBO.DOC_REF_NUMBER = "";

                ObjUBO.IMAGE_REF_NUMBER = "";

                ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
                //Amnd.Ename = "select_INVOICE_Item_Slno";
                ObjUBO.Ename = "select_INVCE_Item_Slno_New";
                ds_supp = Sup_docs.Supp_Doc_Item_Doc_Ref_Select(ObjUBO);

                if (ds_supp.Tables[0].Rows.Count > 0)
                {
                    ListBox1.Visible = true;

                    ListBox_ItemSlno.Visible = true;
                    ListBox_ItemSlno.DataSource = ds_supp.Tables[0];
                    ListBox_ItemSlno.DataTextField = "ITEM_SLNO";
                    ListBox_ItemSlno.DataValueField = "ITEM_SLNO";
                    ListBox_ItemSlno.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void ListBox_ItemSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string Item_Selected_ListBox = "";

            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (item.Selected)
                {
                    Item_Selected_ListBox += item.Value + "~";
                }
            }


            if (string.IsNullOrEmpty(Item_Selected_ListBox))
            {
                ListBox1.Visible = false;
                Alert_msg("Select Item SlNo");
                return;
            }

            string[] item_inv_splt = Item_Selected_ListBox.Split('~');
            string invoice_list = "", item_list = "";
            for (int i = 0; i < item_inv_splt.Length; i++)
            {
                string[] item_inv_spltv2 = item_inv_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                }

            }
            ObjUBO.JOBNO = ddlJobNo.SelectedItem.Text;
            ObjUBO.INVOICE_SLNO = invoice_list;
            ObjUBO.ITEM_SLNO = item_list;
            ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
            ObjUBO.Ename = "select_SupDocs_IRN_NO_New";
            DataSet ds_supp = Sup_docs.Supp_Doc_Item_Doc_Ref_Select(ObjUBO);

            if (ds_supp != null &&
                ds_supp.Tables.Count > 0 &&
                ds_supp.Tables[0].Rows.Count > 0)
            {

                ListBox_ItemSlno.Visible = true;
                ListBox1.Visible = true;

                ListBox1.DataSource = ds_supp.Tables[0];
                ListBox1.DataTextField = "IMAGE_REF_NUMBER";
                ListBox1.DataValueField = "IMAGE_REF_NUMBER";
                ListBox1.DataBind();
            }
            else
            {
                ListBox1.Visible = true;
                //txt_Image_RefNO.Visible = true;
            }


            if (ds_supp != null &&
              ds_supp.Tables.Count > 1 &&
              ds_supp.Tables[1].Rows.Count > 0)
            {
                ListBox_ItemSlno.Visible = true;
                List_Doc_Type.Visible = true;

                List_Doc_Type.DataSource = ds_supp.Tables[1];
                List_Doc_Type.DataTextField = "DOC_REF_NUMBER";
                List_Doc_Type.DataValueField = "DOC_REF_NUMBER";
                List_Doc_Type.DataBind();

            }
            else
            {
                List_Doc_Type.Visible = false;
                //txt_Doc_Type_Code.Visible = true;

            }

        }
        catch (Exception ex)
        {
            Alert_msg(ex.Message);
        }
    }

    protected void ListBox_DocRef_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string Doc_Selected_ListBox = "";

            foreach (ListItem item in List_Doc_Type.Items)
            {
                if (item.Selected)
                {
                    Doc_Selected_ListBox += item.Value + "~";
                }
            }

            // If nothing selected → stop
            if (string.IsNullOrEmpty(Doc_Selected_ListBox))
            {
                //txt_Image_RefNO.Visible = false;
                List_Doc_Type.Visible = false;
                Alert_msg("Select Item SlNo");
                return;
            }


            string[] sup_doc_splt = Doc_Selected_ListBox.Split('~');
            string invoice_list = "", item_list = "", sup_doc = "";
            for (int i = 0; i < sup_doc_splt.Length; i++)
            {
                string[] item_inv_spltv2 = sup_doc_splt[i].Split('-');
                if (item_inv_spltv2[0] != "")
                {
                    invoice_list += item_inv_spltv2[0].ToString() + "~";
                    item_list += item_inv_spltv2[1].ToString() + "~";
                    sup_doc += item_inv_spltv2[2].ToString() + "~";
                }

            }


            ObjUBO.JOBNO = ddlJobNo.SelectedItem.Text;

            ObjUBO.INVOICE_SLNO = invoice_list;
            ObjUBO.ITEM_SLNO = item_list;
            ObjUBO.DOC_REF_NUMBER = sup_doc;

            ObjUBO.IMAGE_REF_NUMBER = "";
            ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
            ObjUBO.Ename = "select_SupDocs_doc_DRN";


            DataSet ds_supp = Sup_docs.Supp_Doc_IRN_Ref_Select(ObjUBO);


            if (ds_supp != null &&
                ds_supp.Tables.Count > 0 &&
                ds_supp.Tables[0].Rows.Count > 0)
            {

                ListBox_ItemSlno.Visible = true;
                ListBox1.Visible = true;

                ListBox1.DataSource = ds_supp.Tables[0];
                ListBox1.DataTextField = "IMAGE_REF_NUMBER";
                ListBox1.DataValueField = "IMAGE_REF_NUMBER";
                ListBox1.DataBind();
            }
            else
            {
                ListBox1.Visible = true;
                //txt_Image_RefNO.Visible = true;
            }

        }
        catch (Exception ex)
        {
            Alert_msg(ex.Message);
        }
    }

    protected void ListBox_Invoice_SlNo_CURR_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds_supp1 = new DataSet();
            ObjUBO.JOBNO = lbljobno.Text;
            string Invoice_Selected_ListBox = "";
            foreach (ListItem invoice in ListBox_Invoice_SlNo_CURR.Items)
            {
                if (invoice.Selected)
                {
                    Invoice_Selected_ListBox += invoice.Value + "~";
                }
            }

            if (Invoice_Selected_ListBox != "")
            {

                ObjUBO.INVOICE_SLNO = Invoice_Selected_ListBox;

                ObjUBO.ITEM_SLNO = "";

                ObjUBO.DOC_REF_NUMBER = "";

                ObjUBO.IMAGE_REF_NUMBER = "";

                ObjUBO.WORKING_PERIOD = Connection.Get_Company_Type();
                ObjUBO.Ename = "select_INVCE_Item_Slno_CURR_new";
                ds_supp1 = Sup_docs.Supp_Doc_Item_Doc_Ref_Select(ObjUBO);

                if (ds_supp1.Tables[0].Rows.Count > 0)
                {
                    ListBox_ItemSlno_CURR.Visible = true;

                    ListBox_ItemSlno_CURR.Visible = true;
                    ListBox_ItemSlno_CURR.DataSource = ds_supp1.Tables[0];
                    ListBox_ItemSlno_CURR.DataTextField = "ITEM_SLNO";
                    ListBox_ItemSlno_CURR.DataValueField = "ITEM_SLNO";
                    ListBox_ItemSlno_CURR.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

}
