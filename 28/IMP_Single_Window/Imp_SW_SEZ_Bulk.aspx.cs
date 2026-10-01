using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using BussinessObject;

public partial class Imp_SW_SEZ_Bulk : ThemeClass
{
    AppSession aps = new AppSession();
    public string SELECT_BRANCH, Jobno, COMPANY_ID = "", currentbranch;
    Imp_Invcopy IIC = new Imp_Invcopy();
    // SW_Support_Docs Sup_docs = new SW_Support_Docs();
    SW_INFO_TYPE SW_Info = new SW_INFO_TYPE();
    UserBO ObjUBO = new UserBO();
    DataSet ds = new DataSet();
    Transaction Transact = new Transaction();

    public string Audit_YN = "";

    protected void Page_Load(object sender, EventArgs e)
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
        hdn_YN.Value = "Y - Yes, N - No";

        ListBox_ItemSlno.EnableViewState = true;

        if (!Page.IsPostBack)
        {
            Load_Inv_Slno("Invoice");

            hdn_ICEGATE_ID_List.Value = Connection.Get_User_ICEGATE_ID_DropdownList("Load_IMP_ICEGATE_ID_dropdown");

            if (hdn_ICEGATE_ID_List.Value == "")
            {
                //txt_IcegateID_all.Text = Connection.Get_IMP_ICEGATE_ID_New();
                hdn_ICEGATE_ID_List.Value = Connection.Get_IMP_ICEGATE_ID_New();
            }

            ListBox_INVSlno.Visible = false;
            ddlinvno.Visible = true;
            ListBox_ItemSlno.Visible = false;
            ddl_ItemSlno.Visible = true;

            DataTable dt = new DataTable();
            gvdetails.DataSource = dt;
            gvdetails.DataBind();

        }

        if (Connection.Audit_Logs(COMPANY_ID) == "Y")
        {
            Audit_YN = "Y";
        }
    }

    private void Load_Inv_Slno(string Load_Type)
    {
        DataSet dss = new DataSet();

        ObjUBO.JOBNO = Jobno;
        ObjUBO.INVOICE_SLNO = ddlinvno.SelectedValue;
        ObjUBO.ITEM_SLNO = ddl_ItemSlno.SelectedValue;
        ObjUBO.SELECT_TYPE = ddl_SelectType1.SelectedValue;
        ObjUBO.IMAGE_REF_NUMBER = txt_Department.Text;
        ObjUBO.Doc_Type_Code = txt_InfoType.Text;
        ObjUBO.Ename = "Save_Load_INV_ITEM_SlNo";

        dss = SW_Info.IMP_ITEM_SW_INFO_TYPE_INS_UPD_DEL_BULK_SELECT(ObjUBO);


        if (Load_Type == "Invoice")
        {
            if (dss.Tables[0].Rows.Count > 0)
            {
                ddlinvno.DataSource = dss.Tables[0];
                ddlinvno.DataTextField = "INVOICE_SLNO";
                ddlinvno.DataValueField = "INVOICE_SLNO";
                ddlinvno.DataBind();

                //ddlinvno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                //ddlinvno.SelectedIndex = 0;


                ListBox_INVSlno.DataSource = dss.Tables[0];
                ListBox_INVSlno.DataTextField = "INVOICE_SLNO";
                ListBox_INVSlno.DataValueField = "INVOICE_SLNO";
                ListBox_INVSlno.DataBind();

                //ListBox_INVSlno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                //ListBox_INVSlno.SelectedIndex = 0;

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
            ddl_ItemSlno.DataSource = dss.Tables[1];
            ddl_ItemSlno.DataTextField = "ITEM_SLNO";
            ddl_ItemSlno.DataValueField = "ITEM_SLNO";
            ddl_ItemSlno.DataBind();

            //ddl_ItemSlno.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            //ddl_ItemSlno.SelectedIndex = 0;

            ListBox_ItemSlno.DataSource = dss.Tables[1];
            ListBox_ItemSlno.DataTextField = "ITEM_SLNO";
            ListBox_ItemSlno.DataValueField = "ITEM_SLNO";
            ListBox_ItemSlno.DataBind();
        }
    }

    protected void gv_Inv_Item_RowCreated(object sender, GridViewRowEventArgs e)
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SEZ - SW Bulk Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'SEZ - SW Bulk Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private DataTable Get_Updated_Gridview_Data()
    {
        DataTable dt_new = new DataTable();

        dt_new.Columns.Add("SW_INFO_TYPE_ID");
        dt_new.Columns.Add("INVOICE_SLNO");
        dt_new.Columns.Add("ITEM_SLNO");
        dt_new.Columns.Add("ADD_INFO_CODE");
        dt_new.Columns.Add("ADD_INFO_MSR");
        dt_new.Columns.Add("CVD_INFO_CODE");
        dt_new.Columns.Add("CVD_INFO_MSR");
        dt_new.Columns.Add("SGD_INFO_CODE");
        dt_new.Columns.Add("SGD_INFO_MSR");



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
                TextBox txt_SW_INFO_TYPE_ID = (TextBox)gvdetails.Rows[i].Cells[0].FindControl("txt_SW_INFO_TYPE_ID");
                TextBox txt_InvSlno = (TextBox)gvdetails.Rows[i].Cells[0].FindControl("txt_InvSlno");
                TextBox txtItemSlNo = (TextBox)gvdetails.Rows[i].Cells[1].FindControl("txtItemSlNo");
                TextBox txt_ADD_InfoCode = (TextBox)gvdetails.Rows[i].Cells[2].FindControl("txt_ADD_InfoCode");
                TextBox txt_ADD_INFO_MSR = (TextBox)gvdetails.Rows[i].Cells[3].FindControl("txt_ADD_INFO_MSR");
                TextBox txt_CVD_InfoCode = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txt_CVD_InfoCode");
                TextBox txt_CVD_INFO_MSR = (TextBox)gvdetails.Rows[i].Cells[5].FindControl("txt_CVD_INFO_MSR");
                TextBox txt_SGD_InfoCode = (TextBox)gvdetails.Rows[i].Cells[6].FindControl("txt_SGD_InfoCode");
                TextBox txt_SGD_INFO_MSR = (TextBox)gvdetails.Rows[i].Cells[7].FindControl("txt_SGD_INFO_MSR");



                if (chk_All.Checked == true)
                {
                    Status = "0";
                    dt_new.Rows.Add();

                    if (txt_InvSlno.Text != "" && txtItemSlNo.Text != "" && txt_ADD_InfoCode.Text != "" && txt_ADD_INFO_MSR.Text != "" && txt_CVD_InfoCode.Text != "" && txt_CVD_INFO_MSR.Text != "" && txt_SGD_InfoCode.Text != "" && txt_SGD_INFO_MSR.Text != "")
                    {
                        Status = "1";
                    }
                    else if (ddl_flg.SelectedItem.Text == "Delete")
                    {
                        Status = "1";
                    }

                    if (Status == "1")
                    {
                        dt_new.Rows[chked_cnt]["SW_INFO_TYPE_ID"] = txt_SW_INFO_TYPE_ID.Text;
                        dt_new.Rows[chked_cnt]["INVOICE_SLNO"] = txt_InvSlno.Text;
                        dt_new.Rows[chked_cnt]["ITEM_SLNO"] = txtItemSlNo.Text;
                        dt_new.Rows[chked_cnt]["ADD_INFO_CODE"] = txt_ADD_InfoCode.Text;
                        dt_new.Rows[chked_cnt]["ADD_INFO_MSR"] = txt_ADD_INFO_MSR.Text;
                        dt_new.Rows[chked_cnt]["CVD_INFO_CODE"] = txt_CVD_InfoCode.Text;
                        dt_new.Rows[chked_cnt]["CVD_INFO_MSR"] = txt_CVD_INFO_MSR.Text;
                        dt_new.Rows[chked_cnt]["SGD_INFO_CODE"] = txt_SGD_InfoCode.Text;
                        dt_new.Rows[chked_cnt]["SGD_INFO_MSR"] = txt_SGD_INFO_MSR.Text;


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

        ViewState["dt_Curr_Table"] = dt_grid.Copy();//Added By George Bush on 14-07-2026

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
                ObjUBO.DEPARTMENT = txt_Department.Text;

                string[] infoType = txt_InfoType.Text.Split('-');

                ObjUBO.INFO_TYPE = infoType[0].Trim();
                ObjUBO.Ename = Action_flg;

                dss = SW_Info.IMP_ITEM_SW_INFO_TYPE_INS_UPD_DEL_BULK_SELECT(ObjUBO);

                if (SW_Info.result == 1)
                {
                    MP_JOB.Hide();
                    Alert_msg(ddl_flg.SelectedItem.Text + "d Successfully");

                    Transact.Imp_Job_Logs_All_Details(hdn_jobno.Value, ddlinvno.SelectedValue, "Bulk", "SW InfoType", Action_flg, "Insert");

                    if (ddl_flg.SelectedValue == "U")
                    {
                        // ----Audit Modified Data -----------------------------------
                        if (Audit_YN == "Y")
                        {
                            Audit_Modified_DataTableComparer();
                        }
                        //------------------------------------------------------------
                    }

                }
                else if (SW_Info.result == 2 || SW_Info.result == 3 || SW_Info.result == 4)
                {
                    if (SW_Info.result == 2)
                    {
                        lbl_heading.Text = "Alert !! - Record Already Exists!";
                    }
                    if (SW_Info.result == 3)
                    {
                        lbl_heading.Text = "Alert !! - Invalid Record - Found!";
                    }
                    if (SW_Info.result == 4)
                    {
                        lbl_heading.Text = "Alert !! - Duplicate Record Found!";
                    }
                    MP_JOB.Show();
                    gv_Inv_Item.DataSource = dss.Tables[0];
                    gv_Inv_Item.DataBind();

                    //gvdetails.DataSource = dss.Tables[0];
                    //gvdetails.DataBind();
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

            //ddlinvno.Visible = true;
            //ListBox_INVSlno.Visible = false;

            //ddl_ItemSlno.Visible = true;
            //ListBox_ItemSlno.Visible = false;

        }
    }



    protected void btn_Load_Data_Click(object sender, EventArgs e)
    {

        DataTable dtLoad = new DataTable();

        ObjUBO.JOBNO = Jobno;

        if (ddl_SelectType1.SelectedValue == "JOB" || ddl_SelectType1.SelectedValue == "ITEM")
        {
            ObjUBO.INVOICE_SLNO = ddlinvno.SelectedValue;
        }
        else
        {
            //ObjUBO.INVOICE_SLNO = ListBox_INVSlno.Text;
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
            ObjUBO.ITEM_SLNO = ListBox_ItemSlno.Text;

            string Item_Selected_ListBox = "";
            foreach (ListItem item in ListBox_ItemSlno.Items)
            {
                if (item.Selected)
                {
                    Item_Selected_ListBox += item.Value + "~";
                }
            }
            ObjUBO.ITEM_SLNO = Item_Selected_ListBox.TrimEnd('~');
        }

        ObjUBO.SELECT_TYPE = ddl_SelectType1.SelectedValue;
        ObjUBO.DEPARTMENT = txt_Department.Text;

        string[] infoType = txt_InfoType.Text.Split('-');

        ObjUBO.INFO_TYPE = infoType[0].Trim();

        if (ddl_flg.SelectedValue == "S")
        {
            ObjUBO.Ename = "Save";
        }
        else
        {
            ObjUBO.Ename = "Select_Details";
        }

        ds = SW_Info.IMP_ITEM_SW_INFO_TYPE_INS_UPD_DEL_BULK_SELECT(ObjUBO);


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

            if (ddl_flg.SelectedValue == "U")
            {
                if (Audit_YN == "Y")
                {
                    Tbl_Filed_Modified_History(ds.Tables[0]);
                }
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
            ddl_ItemSlno.Enabled = false;
        }
        else
        {

            ListBox_INVSlno.Visible = false;
            ddlinvno.Visible = true;
            ListBox_ItemSlno.Visible = true;
            ddl_ItemSlno.Visible = false;

            Load_Inv_Slno("Item");

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


    private void Tbl_Filed_Modified_History(DataTable dt_Curr_tbl_struct)
    {
        try
        {
            ViewState["dt_Prev_Table"] = dt_Curr_tbl_struct.Copy();
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void Audit_Modified_DataTableComparer()
    {
        try
        {
            DataTable dt_Prev = (DataTable)ViewState["dt_Prev_Table"];
            DataTable dt_Cur = (DataTable)ViewState["dt_Curr_Table"];
            dt_Prev.Columns.Remove("JOBNO");
            //dt_Prev.Columns.Remove("DECLARATION_TYPE");
            DataTableComparer Dt_Change = new DataTableComparer();
            Dt_Change.GetMismatchedRowsFast(dt_Prev, dt_Cur.Copy(), "SW_INFO_TYPE_ID", "SW SEZ", Jobno, ddlinvno.SelectedValue, ddl_ItemSlno.SelectedValue, Connection.Current_User(), currentbranch);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
}