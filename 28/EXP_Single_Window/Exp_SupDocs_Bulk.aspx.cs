using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using BussinessObject;

public partial class Exp_SupDocs_Bulk : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH, Jobno, COMPANY_ID = "", currentbranch;
    Imp_Invcopy IIC = new Imp_Invcopy();
    EXP_Supportingdoc Sup_docs = new EXP_Supportingdoc();
    UserBO ObjUBO = new UserBO();
    DataSet ds = new DataSet();
    Export_General_New Transact = new Export_General_New();
    DataSet dss = new DataSet();
    IRN_Automation IA = new IRN_Automation();
    Global_variables Obj = new Global_variables();


    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        SELECT_BRANCH = Connection.Get_Company_Type();
        COMPANY_ID = Connection.COMPANYID();
        currentbranch = Session["currentbranch"].ToString();
        /*
        if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "115" || COMPANY_ID == "128" || COMPANY_ID == "184" || COMPANY_ID == "188"
        || COMPANY_ID == "236" || COMPANY_ID == "256" || COMPANY_ID == "265" || COMPANY_ID == "286" || COMPANY_ID == "293" || COMPANY_ID == "294" || COMPANY_ID == "427"
        || COMPANY_ID == "470" || COMPANY_ID == "517" || COMPANY_ID == "579" || COMPANY_ID == "608" || COMPANY_ID == "619" || COMPANY_ID == "653"
        || COMPANY_ID == "655" || COMPANY_ID == "660" || COMPANY_ID == "705" || COMPANY_ID == "816" || COMPANY_ID == "829" || COMPANY_ID == "917"
        || COMPANY_ID == "1015" || COMPANY_ID == "1039" || COMPANY_ID == "1213" || COMPANY_ID == "1241" || COMPANY_ID == "1245" || COMPANY_ID == "1312"
        || COMPANY_ID == "1532" || COMPANY_ID == "1534" || COMPANY_ID == "1562" || COMPANY_ID == "1627" || COMPANY_ID == "1701" || COMPANY_ID == "2099"
        || COMPANY_ID == "2118" || COMPANY_ID == "2261" || COMPANY_ID == "2262" || COMPANY_ID == "2333" || COMPANY_ID == "2373" || COMPANY_ID == "2386" || COMPANY_ID == "2394" 
        || COMPANY_ID == "2457"|| COMPANY_ID == "2629" || COMPANY_ID == "2761" || COMPANY_ID == "2854" || COMPANY_ID == "2863" || COMPANY_ID == "2864" 
        || COMPANY_ID == "2935"|| COMPANY_ID == "3074" || COMPANY_ID == "3119" || COMPANY_ID == "3120" || COMPANY_ID == "3121" || COMPANY_ID == "3157" 
        || COMPANY_ID == "3172"|| COMPANY_ID == "3179" || COMPANY_ID == "3181" || COMPANY_ID == "3195" || COMPANY_ID == "3196" || COMPANY_ID == "3198"
        || COMPANY_ID == "3200" || COMPANY_ID == "3220" || COMPANY_ID == "3239" || COMPANY_ID == "3241" || COMPANY_ID == "3246" || COMPANY_ID == "3253" 
        || COMPANY_ID == "3280" || COMPANY_ID == "3282")
        {
            Div_IRN_btn.Style.Add("display", "block");
        }
        */
        if (Connection.Export_IRN()== "T")
        {
            Div_IRN_btn.Style.Add("display", "block");
        }
        if (Connection.Export_IRN_N() == "T")
        {
            Div_IRN_btn_New.Style.Add("display", "block");
        }


        /*
        if (COMPANY_ID == "1" || COMPANY_ID == "10" || COMPANY_ID == "256" || COMPANY_ID == "427" || COMPANY_ID == "608" || COMPANY_ID == "653" || COMPANY_ID == "2321" 
            || COMPANY_ID == "673"  || COMPANY_ID == "470" || COMPANY_ID == "761" || COMPANY_ID == "816" || COMPANY_ID == "917" || COMPANY_ID == "1142"
            || COMPANY_ID == "2373" || COMPANY_ID == "2394" || COMPANY_ID == "2414" || COMPANY_ID == "3246" || COMPANY_ID == "3196"
            || COMPANY_ID == "3303" || COMPANY_ID == "3304" || COMPANY_ID == "2386" || COMPANY_ID == "2333")
        {
            Div_IRN_btn_New.Style.Add("display", "block");
        }
        */


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


        ListBox_ItemSlno.EnableViewState = true;

        if (!Page.IsPostBack)
        {
            Load_Inv_Slno("Invoice");

            hdn_ICEGATE_ID_List.Value = Connection.Get_User_ICEGATE_ID_DropdownList("Load_EXP_ICEGATE_ID_dropdown");

            if (hdn_ICEGATE_ID_List.Value == "")
            {
                txt_IcegateID_all.Text = Connection.Get_EXP_ICEGATE_ID_New();
                hdn_ICEGATE_ID_List.Value = Connection.Get_EXP_ICEGATE_ID_New();
            }

            ListBox_INVSlno.Visible = false;
            ddlinvno.Visible = true;
            ListBox_ItemSlno.Visible = false;
            ddl_ItemSlno.Visible = true;

            Bind_General_Supplier_New();
           // Bind_IRN_details();//hide on 11-03-2026  by Srikanth
        }
    }

    private void Load_Inv_Slno(string Load_Type)
    {
        DataSet dss = new DataSet();

        ObjUBO.JOBNO = Jobno;
        ObjUBO.INVOICE_SLNO = ddlinvno.SelectedValue;
        ObjUBO.ITEM_SLNO = ddl_ItemSlno.SelectedValue;
        ObjUBO.SELECT_TYPE = ddl_SelectType1.SelectedValue;
        ObjUBO.UNIQUE_DOC_NUMBER = txt_Image_RefNO.Text;
        ObjUBO.Doc_Type_Code = txt_Doc_Type_Code.Text;
        ObjUBO.Doc_Reference_No = txt_DocNo.Text;
        ObjUBO.Ename = "Save_Load_INV_ITEM_SlNo";

        dss = Sup_docs.EXP_ITEM_SUPPROTING_DOCUMENTS_INS_UPD_DEL_BULK_SELECT(ObjUBO);


        if (Load_Type == "Invoice")
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlinvno.DataSource = dss.Tables[0];
                ddlinvno.DataTextField = "INVOICE_SLNO";
                ddlinvno.DataValueField = "INVOICE_SLNO";
                ddlinvno.DataBind();

                ListBox_INVSlno.DataSource = dss.Tables[0];
                ListBox_INVSlno.DataTextField = "INVOICE_SLNO";
                ListBox_INVSlno.DataValueField = "INVOICE_SLNO";
                ListBox_INVSlno.DataBind();

                if (ddl_SelectType1.SelectedValue == "JOB")
                {
                    if (dss.Tables[2].Rows.Count > 0)
                    {
                        ddl_ItemSlno.DataSource = dss.Tables[2];
                        ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                        ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                        ddl_ItemSlno.DataBind();
                    }
                }
            }
        }

        if (Load_Type == "Item")
        {
            if (dss.Tables[0].Rows.Count > 0 && dss.Tables[1].Rows.Count > 0)
            {
                ddl_ItemSlno.DataSource = dss.Tables[1];
                ddl_ItemSlno.DataTextField = "ITEM_SLNO";
                ddl_ItemSlno.DataValueField = "ITEM_SLNO";
                ddl_ItemSlno.DataBind();

                //ListBox_ItemSlno.DataSource = dss.Tables[1];
                //ListBox_ItemSlno.DataTextField = "ITEM_SLNO";
                //ListBox_ItemSlno.DataValueField = "ITEM_SLNO";
                //ListBox_ItemSlno.DataBind();

                ListBox_INVSlno.DataSource = dss.Tables[0];
                ListBox_INVSlno.DataTextField = "INVOICE_SLNO";
                ListBox_INVSlno.DataValueField = "INVOICE_SLNO";
                ListBox_INVSlno.DataBind();

                foreach (DataRow row in dss.Tables[1].Rows)
                {
                    string invoiceSlno = row["INVOICE_SLNO"].ToString(); // Assuming INVOICE_SLNO is a string
                    string itemSlno = row["ITEM_SLNO"].ToString(); // Assuming ITEM_SLNO is a string

                    string itemText = invoiceSlno + "-" + itemSlno;
                    string itemValue = invoiceSlno + "-" + itemSlno;

                    // Add item to ListBox_Item
                    ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemValue));
                }
                ViewState["Item_Details"] = dss.Tables[1];
            }
        }
    }

    protected void gv_Item_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
    }

    protected void ddlinvno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_Inv_Slno("Item");
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

        dt_new.Columns.Add("SW_ID");
        dt_new.Columns.Add("INVOICE_SLNO");
        dt_new.Columns.Add("ITEM_SLNO");
        dt_new.Columns.Add("UNIQUE_DOC_NUMBER");
        dt_new.Columns.Add("DOC_TYPE_CODE");
        dt_new.Columns.Add("DOC_ISSUING_PARTY_NAME");
        dt_new.Columns.Add("PLACE_OF_ISSUE");
        dt_new.Columns.Add("DOC_ISSUE_DATE");
        dt_new.Columns.Add("BENEFICIARY_PARTY_NAME");
        dt_new.Columns.Add("ICEGATE_ID");
        dt_new.Columns.Add("DOC_REF_NUMBER");
        dt_new.Columns.Add("SELECT_TYPE");


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
                TextBox txt_Doc_No = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txt_Doc_No");
                TextBox txtIss_PartyName = (TextBox)gvdetails.Rows[i].Cells[5].FindControl("txtIss_PartyName");
                TextBox txtPlace_Of_Issue = (TextBox)gvdetails.Rows[i].Cells[6].FindControl("txtPlace_Of_Issue");
                TextBox txtIssue_Date = (TextBox)gvdetails.Rows[i].Cells[7].FindControl("txtIssue_Date");
                TextBox txtBenPartyName = (TextBox)gvdetails.Rows[i].Cells[8].FindControl("txtBenPartyName");
                TextBox txt_IcegateID = (TextBox)gvdetails.Rows[i].Cells[9].FindControl("txt_IcegateID");
                TextBox txtLevel = (TextBox)gvdetails.Rows[i].Cells[10].FindControl("txtLevel");



                if (chk_All.Checked == true)
                {
                    Status = "0";
                    dt_new.Rows.Add();

                    if (txt_InvSlno.Text != "" && txtItemSlNo.Text != "" && txtImage_RefNo.Text != "" && txtDoc_TypeCode.Text != "" && txtIss_PartyName.Text != "" && txtPlace_Of_Issue.Text != "" && txtIssue_Date.Text != "" && txtBenPartyName.Text != "" && txt_IcegateID.Text != "" && txt_Doc_No.Text != "" && txtLevel.Text != "")
                    {
                        Status = "1";
                    }
                    else if (ddl_flg.SelectedItem.Text == "Delete")
                    {
                        Status = "1";
                    }

                    if (Status == "1")
                    {
                        dt_new.Rows[chked_cnt]["SW_ID"] = txt_SW_ID.Text;
                        dt_new.Rows[chked_cnt]["INVOICE_SLNO"] = txt_InvSlno.Text;
                        dt_new.Rows[chked_cnt]["ITEM_SLNO"] = txtItemSlNo.Text;
                        dt_new.Rows[chked_cnt]["UNIQUE_DOC_NUMBER"] = txtImage_RefNo.Text;
                        dt_new.Rows[chked_cnt]["DOC_TYPE_CODE"] = txtDoc_TypeCode.Text;
                        dt_new.Rows[chked_cnt]["DOC_REF_NUMBER"] = txt_Doc_No.Text;
                        dt_new.Rows[chked_cnt]["DOC_ISSUING_PARTY_NAME"] = txtIss_PartyName.Text;
                        dt_new.Rows[chked_cnt]["PLACE_OF_ISSUE"] = txtPlace_Of_Issue.Text;

                        string[] sp = txtIssue_Date.Text.Split('/');
                        str_issuedat = sp[1] + "/" + sp[0] + "/" + sp[2];

                        dt_new.Rows[chked_cnt]["DOC_ISSUE_DATE"] = str_issuedat;
                        dt_new.Rows[chked_cnt]["BENEFICIARY_PARTY_NAME"] = txtBenPartyName.Text;
                        dt_new.Rows[chked_cnt]["ICEGATE_ID"] = txt_IcegateID.Text;
                        dt_new.Rows[chked_cnt]["SELECT_TYPE"] = txtLevel.Text;


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

        return dt_new;
    }

    private void Action_Save_Update_Delete(string Action_flg)
    {
        string Status = "0";
        DataSet dss = new DataSet();
        DataTable dt_grid = new DataTable();
        dt_grid = Get_Updated_Gridview_Data();

        if (ViewState["Mandatory_Missing"].ToString() == "1")
        {
            Status = "1";
        }
        else if (Action_flg == "btn_Delete")
        {
            Status = "1";
        }
        else if (ViewState["Mandatory_Missing"].ToString() == "2")
        {
            Alert_msg("Mandatory Value Missing!..");
        }
        else if (ViewState["Mandatory_Missing"].ToString() == "3")
        {
            Alert_msg("Select Grid CheckBox");
        }


        if (Status == "1")
        {
            if (dt_grid.Rows.Count > 0)
            {
                ObjUBO.JOBNO = Jobno;
                ObjUBO.INVOICE_SLNO = ddlinvno.SelectedValue;
                ObjUBO.ITEM_SLNO = ddl_ItemSlno.SelectedValue;
                ObjUBO.Xml_A = ConvertDataTableToXML(dt_grid);
                ObjUBO.SELECT_TYPE = ddl_SelectType1.SelectedValue;
                ObjUBO.UNIQUE_DOC_NUMBER = txt_Image_RefNO.Text;
                ObjUBO.Doc_Type_Code = txt_Doc_Type_Code.Text;
                ObjUBO.Doc_Reference_No = txt_DocNo.Text;
                ObjUBO.ADDRESS1 = ViewState["ADDRESS1"].ToString();
                ObjUBO.ADDRESS2 = ViewState["ADDRESS2"].ToString();
                ObjUBO.ADDRESS4 = ViewState["ADDRESS4"].ToString();
                ObjUBO.ADDRESS5 = ViewState["ADDRESS5"].ToString();
                ObjUBO.CONSIGNEE_ADD_1 = ViewState["CONSIGNEE_ADD1"].ToString();
                ObjUBO.CONSIGNEE_ADD_2 = ViewState["CONSIGNEE_ADD2"].ToString();
                ObjUBO.CONSIGNEE_ADD_3 = ViewState["CONSIGNEE_ADD3"].ToString();
                ObjUBO.CONSIGNEE_ADD_4 = ViewState["CONSIGNEE_ADD5"].ToString();
                ObjUBO.Ename = Action_flg;

                dss = Sup_docs.EXP_ITEM_SUPPROTING_DOCUMENTS_INS_UPD_DEL_BULK_SELECT(ObjUBO);

                if (Sup_docs.result == 1)
                {
                    MP_JOB.Hide();
                    Alert_msg(ddl_flg.SelectedItem.Text + "d Successfully");

                    if (Connection.COMPANYID() == "10" || Connection.COMPANYID() == "2145")//Capricorn
                    {
                        Transact.Exp_Job_Logs_All_Details(Jobno, ddlinvno.SelectedValue, "Bulk", "Sup Docs", Action_flg, "Insert");
                    }
                }
                else if (Sup_docs.result == 2 || Sup_docs.result == 3 || Sup_docs.result == 4 || Sup_docs.result == 5)
                {
                    if (Sup_docs.result == 2)
                    {
                        lbl_heading.Text = "Alert !! - Record Already Exists!";
                    }
                    if (Sup_docs.result == 3)
                    {
                        lbl_heading.Text = "Alert !! - Invalid Record - Found!";
                    }
                    if (Sup_docs.result == 4)
                    {
                        lbl_heading.Text = "Alert !! - Duplicate Record Found!";
                    }
                    if (Sup_docs.result == 5)
                    {
                        lbl_heading.Text = "Alert !! - IRN No Must be in 16 Digit!";
                    }
                    MP_JOB.Show();
                    gv_Inv_Item.DataSource = dss.Tables[1];
                    gv_Inv_Item.DataBind();
                }
                else
                {
                    Alert_msg("Not Saved");
                }
            }

        }
    }




    protected void btnsave_Click(object sender, EventArgs e)
    {
        Action_Save_Update_Delete("btn_Save");
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        Action_Save_Update_Delete("btn_Update");
    }

    protected void btndelete_Click(object sender, EventArgs e)
    {
        Action_Save_Update_Delete("btn_Delete");
    }


    protected void ddl_flg_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlinvno.SelectedIndex = -1;
        DataTable dt = new DataTable();
        gvdetails.DataSource = dt;
        gvdetails.DataBind();

        if (ddl_flg.SelectedValue.ToString() == "S")
        {
            btnsave.Visible = true;
            btn_Update.Visible = false;
            btndelete.Visible = false;

            Bind_General_Supplier_New();
        }
        else if (ddl_flg.SelectedValue.ToString() == "U")
        {
            btnsave.Visible = false;
            btn_Update.Visible = true;
            btndelete.Visible = false;
        }
        else if (ddl_flg.SelectedValue.ToString() == "D")
        {
            btnsave.Visible = false;
            btn_Update.Visible = false;
            btndelete.Visible = true;
        }
        else
        {
            btnsave.Visible = false;
            btndelete.Visible = false;
            btndelete.Visible = false;

            ddl_SelectType1.Items.Remove("");
            ddl_SelectType1.Items.Insert(0, "");
            ddl_SelectType1.SelectedValue = "";

        }
    }



    protected void btn_Load_Data_Click(object sender, EventArgs e)
    {

        Bind_General_Supplier_New();

        DataTable dtLoad = new DataTable();

        ObjUBO.JOBNO = Jobno;

        if (ddl_SelectType1.SelectedValue == "JOB" || ddl_SelectType1.SelectedValue == "ITEM")
        {
            ObjUBO.INVOICE_SLNO = ddlinvno.SelectedValue;
        }
        else
        {
            string INV_Selected_ListBox = "";
            foreach (ListItem inv in ListBox_INVSlno.Items)
            {
                if (inv.Selected)
                {
                    INV_Selected_ListBox += inv.Value + "~";
                }
            }
            ObjUBO.INVOICE_SLNO = INV_Selected_ListBox.TrimEnd('~');
        }

        if (ddl_SelectType1.SelectedValue == "JOB" || ddl_SelectType1.SelectedValue == "INVOICE")
        {
            ObjUBO.ITEM_SLNO = ddl_ItemSlno.SelectedValue;
        }
        else
        {
            //ObjUBO.ITEM_SLNO = ListBox_ItemSlno.Text;

            //string Item_Selected_ListBox = "";
            //foreach (ListItem item in ListBox_ItemSlno.Items)
            //{
            //    if (item.Selected)
            //    {
            //        string[] Split_Inv_item = item.Text.Split('^');//1^1
            //        Item_Selected_ListBox += Convert.ToInt32(Split_Inv_item[1]) + "~";
            //        //Item_Selected_ListBox += item.Value + "~";
            //    }
            //}
            //ObjUBO.ITEM_SLNO = Item_Selected_ListBox.TrimEnd('~');

            string INV_Selected_ListBox = "", Item_Selected_ListBox = "";
            foreach (ListItem IVN_item in ListBox_ItemSlno.Items)
            {
                if (IVN_item.Selected)
                {
                    string[] Split_Inv_item = IVN_item.Text.Split('-');//1-1
                    INV_Selected_ListBox += Convert.ToInt32(Split_Inv_item[0]) + "~";
                    Item_Selected_ListBox += Convert.ToInt32(Split_Inv_item[1]) + "~";
                }
            }
            ObjUBO.INVOICE_SLNO = INV_Selected_ListBox.TrimEnd('~');
            ObjUBO.ITEM_SLNO = Item_Selected_ListBox.TrimEnd('~');
        }

        ObjUBO.SELECT_TYPE = ddl_SelectType1.SelectedValue;
        ObjUBO.UNIQUE_DOC_NUMBER = txt_Image_RefNO.Text;
        ObjUBO.Doc_Type_Code = txt_Doc_Type_Code.Text;
        ObjUBO.Doc_Reference_No = txt_DocNo.Text;

        ObjUBO.Upd_ImageRef = txt_ImageRefNo_all.Text;
        ObjUBO.Upd_DoctypeCode = txt_DocTypeCode_all.Text;
        ObjUBO.Upd_Iss_Party = txt_IssPartyName_all.Text;
        ObjUBO.Upd_PlaceOfIssue = txt_PlaceOfIssue_all.Text;
        ObjUBO.Upd_Issuedate = txt_IssueDate_all.Text;
        ObjUBO.Upd_BenParty = txt_BenPartyName_all.Text;
        ObjUBO.Upd_IcegateID = txt_IcegateID_all.Text;


        if (ddl_flg.SelectedValue == "S")
        {
            ObjUBO.Ename = "Save";
        }
        else
        {
            ObjUBO.Ename = "Select_Details";
        }

        ds = Sup_docs.EXP_ITEM_SUPPROTING_DOCUMENTS_INS_UPD_DEL_BULK_SELECT(ObjUBO);


        gvdetails.DataSource = ds.Tables[0];
        gvdetails.DataBind();

        ViewState["CurrentTable"] = ds.Tables[0];


        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ddl_flg.SelectedValue == "S")
            {
                gvdetails.FooterRow.Visible = true;
            }
            else
            {
                gvdetails.FooterRow.Visible = false;
            }
        }
    }

    protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (ddl_flg.SelectedValue == "V")
        {
            e.Row.Cells[0].Visible = false;
        }

        if (ddl_flg.SelectedValue == "U" || ddl_flg.SelectedValue == "D")
        {
            e.Row.Cells[2].Enabled = false;
            e.Row.Cells[3].Enabled = false;

            e.Row.Cells[2].BackColor = System.Drawing.Color.LightGray;
            e.Row.Cells[3].BackColor = System.Drawing.Color.LightGray;
        }
    }

    protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("add"))
        {
            AddNewRow();
        }
    }

    private void AddNewRow()
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
                    TextBox txt_InvSlno = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txt_InvSlno");
                    TextBox txtItemSlNo = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtItemSlNo");
                    TextBox txtImage_RefNo = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtImage_RefNo");
                    TextBox txtDoc_TypeCode = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtDoc_TypeCode");
                    TextBox txt_Doc_No = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txt_Doc_No");
                    TextBox txtIss_PartyName = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtIss_PartyName");
                    TextBox txtPlace_Of_Issue = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtPlace_Of_Issue");
                    TextBox txtIssue_Date = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtIssue_Date");
                    TextBox txtBenPartyName = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtBenPartyName");
                    TextBox txt_IcegateID = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txt_IcegateID");
                    TextBox txtLevel = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtLevel");

                    drCurrentRow = dtCurrentTable.NewRow();

                    dtCurrentTable.Rows[i - 1]["INVOICE_SLNO"] = txt_InvSlno.Text;
                    dtCurrentTable.Rows[i - 1]["ITEM_SLNO"] = txtItemSlNo.Text;
                    dtCurrentTable.Rows[i - 1]["UNIQUE_DOC_NUMBER"] = txtImage_RefNo.Text;
                    dtCurrentTable.Rows[i - 1]["DOC_TYPE_CODE"] = txtDoc_TypeCode.Text;
                    dtCurrentTable.Rows[i - 1]["DOC_REF_NUMBER"] = txt_Doc_No.Text;
                    dtCurrentTable.Rows[i - 1]["DOC_ISSUING_PARTY_NAME"] = txtIss_PartyName.Text;
                    dtCurrentTable.Rows[i - 1]["PLACE_OF_ISSUE"] = txtPlace_Of_Issue.Text;
                    dtCurrentTable.Rows[i - 1]["DOC_ISSUE_DATE"] = txtIssue_Date.Text;
                    dtCurrentTable.Rows[i - 1]["BENEFICIARY_PARTY_NAME"] = txtBenPartyName.Text;
                    dtCurrentTable.Rows[i - 1]["ICEGATE_ID"] = txt_IcegateID.Text;
                    dtCurrentTable.Rows[i - 1]["SELECT_TYPE"] = txtLevel.Text;


                    rowIndex++;

                }
                string confirmValue = confirm_value.Value;
                if (confirmValue == "Yes")
                {
                    int index = gvdetails.Rows.Count - 1;

                    TextBox txt_InvSlno1 = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txt_InvSlno");
                    TextBox txtItemSlNo = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtItemSlNo");
                    TextBox txtIss_PartyName = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtIss_PartyName");
                    TextBox txtPlace_Of_Issue = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtPlace_Of_Issue");
                    TextBox txtBenPartyName = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtBenPartyName");
                    TextBox txt_IcegateID = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txt_IcegateID");
                    TextBox txtLevel = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtLevel");


                    drCurrentRow["INVOICE_SLNO"] = txt_InvSlno1.Text;
                    drCurrentRow["ITEM_SLNO"] = txtItemSlNo.Text;
                    drCurrentRow["DOC_ISSUING_PARTY_NAME"] = txtIss_PartyName.Text;
                    drCurrentRow["PLACE_OF_ISSUE"] = txtPlace_Of_Issue.Text;
                    drCurrentRow["BENEFICIARY_PARTY_NAME"] = txtBenPartyName.Text;
                    drCurrentRow["ICEGATE_ID"] = txt_IcegateID.Text;
                    drCurrentRow["SELECT_TYPE"] = txtLevel.Text;


                }

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                gvdetails.DataSource = dtCurrentTable;
                gvdetails.DataBind();
            }
        }
        SetPreviousData();
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
                    TextBox txt_InvSlno = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txt_InvSlno");
                    TextBox txtItemSlNo = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtItemSlNo");
                    TextBox txtImage_RefNo = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtImage_RefNo");
                    TextBox txtDoc_TypeCode = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtDoc_TypeCode");
                    TextBox txt_Doc_No = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txt_Doc_No");
                    TextBox txtIss_PartyName = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtIss_PartyName");
                    TextBox txtPlace_Of_Issue = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtPlace_Of_Issue");
                    TextBox txtIssue_Date = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtIssue_Date");
                    TextBox txtBenPartyName = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtBenPartyName");
                    TextBox txt_IcegateID = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txt_IcegateID");
                    TextBox txtLevel = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtLevel");



                    txt_InvSlno.Text = dt.Rows[i]["INVOICE_SLNO"].ToString();
                    txtItemSlNo.Text = dt.Rows[i]["ITEM_SLNO"].ToString();
                    txtImage_RefNo.Text = dt.Rows[i]["UNIQUE_DOC_NUMBER"].ToString();
                    txtDoc_TypeCode.Text = dt.Rows[i]["DOC_TYPE_CODE"].ToString();
                    txt_Doc_No.Text = dt.Rows[i]["DOC_REF_NUMBER"].ToString();
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

    private void validate_Mandatory()
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
                    TextBox txt_Doc_No = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txt_Doc_No");
                    TextBox txtIss_PartyName = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtIss_PartyName");
                    TextBox txtPlace_Of_Issue = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtPlace_Of_Issue");
                    TextBox txtIssue_Date = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtIssue_Date");
                    TextBox txtBenPartyName = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtBenPartyName");
                    TextBox txt_IcegateID = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txt_IcegateID");
                    TextBox txtLevel = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtLevel");

                    if (txt_InvSlno.Text == "")
                    {

                    }
                    txt_InvSlno.Text = dt.Rows[i]["INVOICE_SLNO"].ToString();
                    txtItemSlNo.Text = dt.Rows[i]["ITEM_SLNO"].ToString();
                    txtImage_RefNo.Text = dt.Rows[i]["UNIQUE_DOC_NUMBER"].ToString();
                    txtDoc_TypeCode.Text = dt.Rows[i]["DOC_TYPE_CODE"].ToString();
                    txt_Doc_No.Text = dt.Rows[i]["DOC_REF_NUMBER"].ToString();
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

    [System.Web.Services.WebMethod]
    public static string[] test(string prefix)
    {
        List<string> countries = new List<string>();

        countries.Add("INDIA");
        countries.Add("AUSTRALIA");

        return countries.ToArray();

    }

    protected void ddl_SelectType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_SelectType1.SelectedValue == "JOB")
        {
            ListBox_INVSlno.Visible = false;
            ddlinvno.Visible = true;
            ListBox_ItemSlno.Visible = false;
            ddl_ItemSlno.Visible = true;

        }
        else if (ddl_SelectType1.SelectedValue == "INVOICE")
        {
            ListBox_INVSlno.Width = 50;
            ListBox_INVSlno.Visible = true;
            ddlinvno.Visible = false;
            ListBox_ItemSlno.Enabled = false;
            ListBox_ItemSlno.Visible = false;
            ddl_ItemSlno.Visible = true;
            ddl_ItemSlno.Enabled = false;
            Load_Inv_Slno("Invoice");
        }
        else
        {

            ListBox_INVSlno.Visible = true;
            ListBox_INVSlno.Items.Clear();
            ddlinvno.Visible = false;
            ListBox_ItemSlno.Visible = true;
            ddl_ItemSlno.Visible = false;
            Load_Inv_Slno("Item");

        }
    }
    protected void btn_bulk_Update_All_Click(object sender, EventArgs e)
    {

        int rowIndex = gvdetails.Rows.Count;

        if (gvdetails.Rows.Count > 0)
        {
            for (int i = 0; i < gvdetails.Rows.Count; i++)
            {
                if (txt_ImageRefNo_all.Text != "")
                {
                    TextBox txtImage_RefNo = (TextBox)gvdetails.Rows[i].Cells[2].FindControl("txtImage_RefNo");
                    txtImage_RefNo.Text = txt_ImageRefNo_all.Text;
                }
                if (txt_DocTypeCode_all.Text != "")
                {
                    TextBox txtDoc_TypeCode = (TextBox)gvdetails.Rows[i].Cells[3].FindControl("txtDoc_TypeCode");
                    txtDoc_TypeCode.Text = txt_DocTypeCode_all.Text;
                }
                if (txt_DocNo_all.Text != "")
                {
                    TextBox txt_Doc_No = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txt_Doc_No");
                    txt_Doc_No.Text = txt_DocNo_all.Text;
                }
                if (txt_IssPartyName_all.Text != "")
                {
                    TextBox txtIss_PartyName = (TextBox)gvdetails.Rows[i].Cells[5].FindControl("txtIss_PartyName");
                    txtIss_PartyName.Text = txt_IssPartyName_all.Text;
                }
                if (txt_PlaceOfIssue_all.Text != "")
                {
                    TextBox txtPlace_Of_Issue = (TextBox)gvdetails.Rows[i].Cells[6].FindControl("txtPlace_Of_Issue");
                    txtPlace_Of_Issue.Text = txt_PlaceOfIssue_all.Text;
                }
                if (txt_IssueDate_all.Text != "")
                {
                    TextBox txtIssue_Date = (TextBox)gvdetails.Rows[i].Cells[7].FindControl("txtIssue_Date");
                    txtIssue_Date.Text = txt_IssueDate_all.Text;
                }
                if (txt_BenPartyName_all.Text != "")
                {
                    TextBox txtBenPartyName = (TextBox)gvdetails.Rows[i].Cells[8].FindControl("txtBenPartyName");
                    txtBenPartyName.Text = txt_BenPartyName_all.Text;
                }
                if (txt_IcegateID_all.Text != "")
                {
                    TextBox txt_IcegateID = (TextBox)gvdetails.Rows[i].Cells[9].FindControl("txt_IcegateID");
                    txt_IcegateID.Text = txt_IcegateID_all.Text;
                }
                rowIndex++;
            }
        }
    }

    public void Bind_General_Supplier_New()
    {
        try
        {
            EXP_Supportingdoc Sup_Doc = new EXP_Supportingdoc();
            DataSet dss = new DataSet();
            ObjUBO.JOBNO = hdn_jobno.Value;
            ObjUBO.INVOICE_SLNO = ddlinvno.SelectedValue == "" ? "1" : ddlinvno.SelectedValue;
            ObjUBO.ITEM_SLNO = "";
            ObjUBO.BRANCH_COMMON = SELECT_BRANCH;


            ObjUBO.Ename = "EXP_SUPPORTING_DOCUMENTS_Select";

            dss = Sup_Doc.SingleWindow_Select(ObjUBO);

            if (dss.Tables[0].Rows.Count > 0)
            {
                txt_IssPartyName_all.Text = dss.Tables[0].Rows[0]["EXPORTER_NAME"].ToString().Replace("&nbsp;", "").Replace("&amp;", "&").Trim();
                txt_BenPartyName_all.Text = dss.Tables[0].Rows[0]["CONSIGNEE_NAME"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                string ADDRESS1 = dss.Tables[0].Rows[0]["ADDRESS1"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                if (ADDRESS1 != "" && ADDRESS1 != string.Empty && ADDRESS1 != null)
                {
                    ViewState["ADDRESS1"] = ADDRESS1;
                }
                else
                {
                    ViewState["ADDRESS1"] = "";
                }
                string ADDRESS2 = dss.Tables[0].Rows[0]["ADDRESS2"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                if (ADDRESS2 != "" && ADDRESS2 != string.Empty && ADDRESS2 != null)
                {
                    ViewState["ADDRESS2"] = ADDRESS2;
                }
                else
                {
                    ViewState["ADDRESS2"] = "";
                }
                string ADDRESS4 = dss.Tables[0].Rows[0]["ADDRESS4"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                if (ADDRESS4 != "" && ADDRESS4 != string.Empty && ADDRESS4 != null)
                {
                    ViewState["ADDRESS4"] = ADDRESS4;
                }
                else
                {
                    ViewState["ADDRESS4"] = "";
                }
                string ADDRESS5 = dss.Tables[0].Rows[0]["ADDRESS5"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                if (ADDRESS5 != "" && ADDRESS5 != string.Empty && ADDRESS5 != null)
                {
                    ViewState["ADDRESS5"] = ADDRESS5;
                }
                else
                {
                    ViewState["ADDRESS5"] = "";
                }
                string CONSIGNEE_ADD1 = dss.Tables[0].Rows[0]["CONSIGNEE_ADD1"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                if (CONSIGNEE_ADD1 != "" && CONSIGNEE_ADD1 != string.Empty && CONSIGNEE_ADD1 != null)
                {
                    ViewState["CONSIGNEE_ADD1"] = CONSIGNEE_ADD1;
                }
                else
                {
                    ViewState["CONSIGNEE_ADD1"] = "";
                }
                string CONSIGNEE_ADD2 = dss.Tables[0].Rows[0]["CONSIGNEE_ADD2"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                if (CONSIGNEE_ADD2 != "" && CONSIGNEE_ADD2 != string.Empty && CONSIGNEE_ADD2 != null)
                {
                    ViewState["CONSIGNEE_ADD2"] = CONSIGNEE_ADD2;
                }
                else
                {
                    ViewState["CONSIGNEE_ADD2"] = "";
                }
                string CONSIGNEE_ADD3 = dss.Tables[0].Rows[0]["CONSIGNEE_ADD3"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                if (CONSIGNEE_ADD3 != "" && CONSIGNEE_ADD3 != string.Empty && CONSIGNEE_ADD3 != null)
                {
                    ViewState["CONSIGNEE_ADD3"] = CONSIGNEE_ADD3;
                }
                else
                {
                    ViewState["CONSIGNEE_ADD3"] = "";
                }
                string CONSIGNEE_ADD5 = dss.Tables[0].Rows[0]["CONSIGNEE_ADD5"].ToString().Replace("&amp;", "&").Replace("&nbsp;", "").Trim();
                if (CONSIGNEE_ADD5 != "" && CONSIGNEE_ADD5 != string.Empty && CONSIGNEE_ADD5 != null)
                {
                    ViewState["CONSIGNEE_ADD5"] = CONSIGNEE_ADD5;
                }
                else
                {
                    ViewState["CONSIGNEE_ADD5"] = "";
                }

                if (Connection.COMPANYID() == "1" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1240" || Connection.COMPANYID() == "2145")
                {
                    txt_PlaceOfIssue_all.Text = "";
                }

            }
            txt_IcegateID_all.Text = Connection.Get_EXP_ICEGATE_ID_New();

        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btn_Refresh_Click(object sender, EventArgs e)
    {
        Transaction transact = new Transaction();
        transact.ResetFields(Page.Controls);
        ListBox_INVSlno.Items.Clear();
        ListBox_ItemSlno.Items.Clear();

        btn_Load_Data_Click(sender, e);
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
    protected void ListBox_INVSlno_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_SelectType1.SelectedValue == "ITEM")
        {
            List<int> selectedSerialNumbers = new List<int>();

            foreach (ListItem item in ListBox_INVSlno.Items)
            {
                if (item.Selected)
                {
                    selectedSerialNumbers.Add(Convert.ToInt32(item.Text));
                }
            }

            DataTable Filter_DataTable = (DataTable)ViewState["Item_Details"];
            if (Filter_DataTable.Rows.Count > 0)
            {
                DataTable filteredTable = FilterDataTableBySerialNumbers(Filter_DataTable, selectedSerialNumbers);
                ListBox_ItemSlno.Items.Clear();
                foreach (DataRow row in filteredTable.Rows)
                {
                    string invoiceSlno = row["INVOICE_SLNO"].ToString(); // Assuming INVOICE_SLNO is a string
                    string itemSlno = row["ITEM_SLNO"].ToString(); // Assuming ITEM_SLNO is a string

                    string itemText = invoiceSlno + "-" + itemSlno;
                    string itemValue = invoiceSlno + "-" + itemSlno;

                    // Add item to ListBox_Item
                    ListBox_ItemSlno.Items.Add(new ListItem(itemText, itemValue));
                }
            }
        }
    }

    private DataTable FilterDataTableBySerialNumbers(DataTable dt, List<int> serialNumbers)
    {
        DataTable filteredTable = dt.Clone();
        int index = 0; int serialNo = 1;
        foreach (DataRow row in dt.Rows)
        {
            if (dt.Rows.Count > 0 && serialNumbers.Count > 0)
            {
                serialNo = Convert.ToInt32(row["INVOICE_SLNO"]);

                if (serialNumbers.Contains(serialNo))
                {
                    filteredTable.ImportRow(row);
                }
                index++;
            }
        }
        return filteredTable;
    }

    public void Bind_IRN_details()
    {
        Obj.A2 = lbljobno.Text;
        Obj.A10 = "Export";
        Obj.A15 = "SELECT_CON_BULK";
        dss = IA.IRN_Automation_Insert_Update_BG(Obj);
        if (dss.Tables[0].Rows.Count > 0)
        {
            DataTable dt = dss.Tables[0];
            DataTable dtFiltered = new DataTable();
            DataRow dr;
            dtFiltered.Columns.Add(new System.Data.DataColumn("SW_ID", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("ITEM_SLNO", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("UNIQUE_DOC_NUMBER", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_TYPE_CODE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_REF_NUMBER", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUING_PARTY_NAME", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("PLACE_OF_ISSUE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUE_DATE", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("BENEFICIARY_PARTY_NAME", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("ICEGATE_ID", typeof(String)));
            dtFiltered.Columns.Add(new System.Data.DataColumn("SELECT_TYPE", typeof(String)));
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string Rownumber = dt.Rows[i]["ROWNUMBER"].ToString();
                    string IRN = dt.Rows[i]["IRN"].ToString();
                    string DOC_TYPE_CODE = dt.Rows[i]["DOC_TYPE"].ToString();
                    string DOC_LEVEL = dt.Rows[i]["DOC_LEVEL"].ToString();

                    dr = dtFiltered.NewRow();
                    dr[0] = Rownumber;
                    dr[1] = ddlinvno.SelectedValue.ToString();
                    dr[2] = ddl_ItemSlno.SelectedValue.ToString();
                    dr[3] = IRN;
                    dr[4] = DOC_TYPE_CODE;
                    dr[5] = "";
                    dr[6] = "";
                    dr[7] = "";
                    dr[8] = "";
                    dr[9] = "";
                    dr[10] = "";
                    dr[11] = DOC_LEVEL;
                    dtFiltered.Rows.Add(dr);
                }

                gvdetails.DataSource = dtFiltered;
                gvdetails.DataBind();

                ViewState["CurrentTable"] = Session["childIRNgrid"];

                if (ddl_flg.SelectedValue == "S")
                {
                    gvdetails.FooterRow.Visible = true;
                }
                else
                {
                    gvdetails.FooterRow.Visible = false;
                }
            }
        }


        if (dss.Tables[1].Rows.Count > 0)
        {
            string success = dss.Tables[1].Rows[0]["Success"].ToString();
            if (success == "0")
            {
                string baseFolderPath = HttpContext.Current.Server.MapPath("~/Submission/IRN_Doc_Uploads/" + COMPANY_ID + "/" + currentbranch);
                string targetFolderPath = Path.Combine(baseFolderPath, lbljobno.Text);

                if (Directory.Exists(targetFolderPath))
                {
                    Directory.Delete(targetFolderPath, true);
                }
            }
        }
    }
    protected void btn_IRN_Retrive_Click(object sender, EventArgs e)
    {
        string IRN_status = Session["IRN_STATUS"] != null ? Session["IRN_STATUS"].ToString() : string.Empty;
        if (IRN_status == "In Progress")
        {

            Div_IRN_btn.Visible = false;
            string script = @"<script>window.close();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "CloseTab", script, false);

        }

        else
        {
            string a = Session["childIRNgrid"].ToString();
            if (Session["childIRNgrid"] != null && Session["childIRNgrid"] != "")
            {
                DataTable dt = (DataTable)Session["childIRNgrid"];
                DataTable dtFiltered = new DataTable();
                DataRow dr;
                dtFiltered.Columns.Add(new System.Data.DataColumn("SW_ID", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("INVOICE_SLNO", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("ITEM_SLNO", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("UNIQUE_DOC_NUMBER", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_TYPE_CODE", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_REF_NUMBER", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUING_PARTY_NAME", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("PLACE_OF_ISSUE", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("DOC_ISSUE_DATE", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("BENEFICIARY_PARTY_NAME", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("ICEGATE_ID", typeof(String)));
                dtFiltered.Columns.Add(new System.Data.DataColumn("SELECT_TYPE", typeof(String)));
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        string Rownumber = dt.Rows[i]["ROWNUMBER"].ToString();
                        string IRN = dt.Rows[i]["IRN"].ToString();
                        string DOC_TYPE_CODE = dt.Rows[i]["DOC_TYPE"].ToString();
                        string DOC_LEVEL = dt.Rows[i]["DOC_LEVEL"].ToString();

                        dr = dtFiltered.NewRow();
                        dr[0] = Rownumber;
                        dr[1] = ddlinvno.SelectedValue.ToString();
                        dr[2] = ddl_ItemSlno.SelectedValue.ToString();
                        dr[3] = IRN;
                        dr[4] = DOC_TYPE_CODE;
                        dr[5] = "";
                        dr[6] = "";
                        dr[7] = "";
                        dr[8] = "";
                        dr[9] = "";
                        dr[10] = "";
                        dr[11] = DOC_LEVEL;
                        dtFiltered.Rows.Add(dr);
                    }

                    gvdetails.DataSource = dtFiltered;
                    gvdetails.DataBind();

                    ViewState["CurrentTable"] = Session["childIRNgrid"];

                    if (ddl_flg.SelectedValue == "S")
                    {
                        gvdetails.FooterRow.Visible = true;
                    }
                    else
                    {
                        gvdetails.FooterRow.Visible = false;
                    }
                }

            }

            else
            {
                btn_Refresh_Click(sender, e);
            }
            Session["childIRNgrid"] = "";
        }
    }
}