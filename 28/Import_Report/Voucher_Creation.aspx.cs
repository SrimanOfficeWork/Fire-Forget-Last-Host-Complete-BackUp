using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Globalization;
using ImapX;
public partial class Imp_Voucher : ThemeClass
{
    UserBO ObjUBO = new UserBO();
    Despatch dispatch = new Despatch();
    Voucher_creation VC = new  Voucher_creation();
    AppSession aps = new AppSession();
    DataTable dt_container = new DataTable();

    DataSet ds = new DataSet();
    public int i;
    public string VOUCHER_ID, Customer_name, JOBNO, COMPANY_ID, currentuser;
    //string Company_id = Connection.COMPANYID();
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        ds.Clear();
        COMPANY_ID = Session["COMPANY_ID"].ToString();
        currentuser = Session["currentuser"].ToString();
       // SELECT_BRANCH = HttpContext.Current.Session["currentbranch"].ToString();
        if (!IsPostBack)
        {
            //btnrpt.Visible = false;
            
            if (Request.QueryString["Page"] == "New")
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                Load_Importer_name();
                SetInitialRow();
                load_Voucher_NO();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    hdn_job_id.Value = Request.QueryString["Page"].ToString();
                    Update_Item_Load();
                    SetPreviousData();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                   
                    ddlCustomer_name.Enabled = false;
                    ddlStaff_name.Enabled = false;
                    ddl_Department.Enabled = false;
                    ddlStaff_name_SelectedIndexChanged(sender, e);
                    //txt_JobNo.Enabled = false;
                    //btnrpt.Visible = true;
                }
            }
            Rd_incurred.Items[0].Attributes.Add("style", "color:Green;");
            Rd_Ceritified.Items[0].Attributes.Add("style", "color:Green;");
            Rd_Approved.Items[0].Attributes.Add("style", "color:Green;");
            Rd_Verified.Items[0].Attributes.Add("style", "color:Green;");
            Rd_incurred.Items[1].Attributes.Add("style", "color:red;");
            Rd_Ceritified.Items[1].Attributes.Add("style", "color:red;");
            Rd_Approved.Items[1].Attributes.Add("style", "color:red;");
            Rd_Verified.Items[1].Attributes.Add("style", "color:red;");
            txt_voucherno.Attributes.Add("readonly", "readonly");
            txt_voucherno.Style.Add("background-color", "#F0F0F0");
        }
        if (COMPANY_ID == "480" && currentuser.ToUpper() == "JAFFER")
        {
            ddlStaff_name.Enabled = false;
            Lb_Certified.Visible = true;
            Rd_Ceritified.Visible = true;
            Rd_incurred.Visible = true;
            Lb_Incurred.Visible = true;
            Lb_Approved.Visible = false;
            Rd_Approved.Visible = false;
            Lb_Verified.Visible = false;
            Rd_Verified.Visible = false;

        }
        if (COMPANY_ID == "480" && (currentuser.ToUpper() == "ADMIN" || currentuser.ToUpper() == "NATRAJ"))
        {
            ddlStaff_name.Enabled = false;
            Lb_Certified.Visible = true;
            Rd_Ceritified.Visible = true;
            Rd_incurred.Visible = true;
            Lb_Incurred.Visible = true;
            Lb_Approved.Visible = true;
            Rd_Approved.Visible = true;
            Lb_Verified.Visible = true;
            Rd_Verified.Visible = true;

        }
        if (COMPANY_ID == "1176" && currentuser.ToUpper() == "RAGHU")
        {
            ddlStaff_name.Enabled = false;
            Lb_Certified.Visible = true;
            Rd_Ceritified.Visible = true;
            Rd_incurred.Visible = true;
            Lb_Incurred.Visible = true;
            Lb_Approved.Visible = false;
            Rd_Approved.Visible = false;
            Lb_Verified.Visible = false;
            Rd_Verified.Visible = false;

        }
        if (COMPANY_ID == "1176" && currentuser.ToUpper() == "ADMIN")
        {
            ddlStaff_name.Enabled = false;
            Lb_Certified.Visible = true;
            Rd_Ceritified.Visible = true;
            Rd_incurred.Visible = true;
            Lb_Incurred.Visible = true;
            Lb_Approved.Visible = true;
            Rd_Approved.Visible = true;
            Lb_Verified.Visible = true;
            Rd_Verified.Visible = true;

        }
    }
    public void Load_Importer_name()
    {
        try
        {
            ObjUBO.flag = "Load_Importer_Name";
           ds = VC.Imp_Voucher_Creation_Select(ObjUBO);
           if (ds.Tables[0].Rows.Count > 0)
           {
               ddlCustomer_name.DataSource = ds.Tables[0];
               ddlCustomer_name.DataTextField = "IMPORTER_NAME";
               ddlCustomer_name.DataValueField = "IMPORTER_NAME";
               ddlCustomer_name.DataBind();

               ddlCustomer_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlCustomer_name.SelectedIndex = 0;
           }
           else
           {
               ddlCustomer_name.Items.Clear();
               ddlCustomer_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlCustomer_name.SelectedIndex = 0;
           }

          
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    /*private void load_IMP_CHARGE_NAME()
    {
        try
        {

            VC.flag = "Load_Charge_Name";
            DataSet ds = new DataSet();

            ddl_ChargeName.Items.Clear();
            ds = VC.Voucher_Creation_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddl_ChargeName.DataSource = ds.Tables[0];
                ddl_ChargeName.DataTextField = "CHARGE_NAME";
                ddl_ChargeName.DataValueField = "CHARGE_NAME";
                ddl_ChargeName.DataBind();
            }
            ddl_ChargeName.Items.Insert(0, new ListItem("--Select--", "--Select--"));
            ddl_ChargeName.SelectedIndex = 0;
        }



        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }*/
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = Insert_Update("", "U", Job_no_details());
            //btn_DocsUpload.Visible = true;
            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                }
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnUpdate");
            }

            else
            {
                btnUpdate.Visible = true;
                btn_DocsUpload.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
                Alert_msg("Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Voucher Creation', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Voucher Creation', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddlCustomer_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCustomer_name.SelectedValue != string.Empty)
            {
                Clear();
                ObjUBO.flag = "Select_Jobno_from_Exporter";
                ObjUBO.Imp_Name = ddlCustomer_name.SelectedValue.ToString();
                ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
                ObjUBO.From_date = "";
                ObjUBO.Todate = "";

                ds = VC.Imp_Voucher_Creation_Select(ObjUBO);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    //txt_JobNo.Text = ddlJobNo.SelectedValue.ToString();
                    dt_container = ds.Tables[0];
                    ViewState["dt_container"] = dt_container;
                    SetInitialRow();
                  


                }

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Update_Item_Load()
    {
        DataTable dt_cont = new DataTable();
        try
        {
            Clear();
            ObjUBO.ITEM_ID = Request.QueryString["Page"].ToString();
           // ObjUBO.JOBNO = Request.QueryString["IMP_JOB_NO"].ToString();
            ObjUBO.flag = "Updated_Jobno_Select";
            ds = VC.Imp_Voucher_Creation_Select(ObjUBO);

            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    //dt_cont = (DataTable)ViewState["dt_container"];
            //    ViewState["dt_container"] = ds.Tables[0];
            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCustomer_name.Items.Clear();

                HD_Update_id.Value = ds.Tables[0].Rows[0]["Imp_Voucher_id"].ToString();
                txt_voucherno.Text = ds.Tables[0].Rows[0]["Imp_Voucher_no"].ToString();
                ddlCustomer_name.Items.Insert(0, ds.Tables[0].Rows[0]["Imp_Customer_Name"].ToString());
                txt_Date.Text = ds.Tables[0].Rows[0]["Imp_Voucher_Date"].ToString();
                ddl_Department.SelectedValue = ds.Tables[0].Rows[0]["Imp_Department"].ToString();
                ddlStaff_name.SelectedValue = ds.Tables[0].Rows[0]["Imp_Staff_name"].ToString();
               // txt_department.Text = ds.Tables[0].Rows[0]["Department"].ToString();
            

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
                txt_grand_total.Text = ds.Tables[0].Rows[0]["Total"].ToString();
                Rd_incurred.SelectedValue = ds.Tables[0].Rows[0]["Imp_Incurred"].ToString();
                Rd_Ceritified.SelectedValue = ds.Tables[0].Rows[0]["Imp_Certified"].ToString();
                Rd_Approved.SelectedValue = ds.Tables[0].Rows[0]["Imp_Approved"].ToString();
                Rd_Verified.SelectedValue = ds.Tables[0].Rows[0]["Imp_Verified"].ToString();
               //
                //a=ddlStaff_name_SelectedIndexChanged(sender,e);
                //gvAll.DataSource = dt_item;
                //gvAll.DataBind();

                //ViewState["CurrentTable"] = dt_item;
                //SetPreviousData();

                
                //ViewState["UPDATED_ID"] = "U";
               
                HD_Update_id.Value = Request.QueryString["Page"].ToString();
                Session["Imp_Voucher_id"] = HD_Update_id.Value;
                //JOBNO = Request.QueryString["IMP_JOB_NO"].ToString();
               Session["Imp_Customer_Name"] = ddlCustomer_name.SelectedValue;
               btn_DocsUpload.Visible = true;
              
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public int Insert_Update(string a1, string a2, String xmlData_D)
     {
         VC.Imp_Voucher_id = HD_Update_id.Value;
         VC.Voucher_SUB_ID = Hdn_SUB_ID.Value;
         VC.Imp_Customer_Name = ddlCustomer_name.SelectedItem.Text;
         //VC.Department = txt_department.Text;
         VC.Imp_Department = ddl_Department.SelectedValue.ToString();
         VC.Imp_Voucher_Date = txt_Date.Text;
         VC.Xml_D = xmlData_D;
         VC.Imp_Voucher_no = txt_voucherno.Text;
         VC.Imp_Staff_name = ddlStaff_name.SelectedValue.ToString();
         VC.Imp_Incurred = Rd_incurred.SelectedValue.ToString();
         VC.Imp_Certified = Rd_Ceritified.SelectedValue.ToString();
         VC.Imp_Approved = Rd_Approved.SelectedValue.ToString();
         VC.Imp_Verified = Rd_Verified.SelectedValue.ToString();
         VC.Total = txt_grand_total.Text;

         VC.BRANCH_COMMON = Connection.Get_Company_Type();
         VC.flag = a2;
         VC.Imp_Voucher_Creation_insertupdate();
         

         i = VC.result;
         return i;
     }
    private string Job_no_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("IMP_VOUCHER_CHECK", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("IMP_ROWNUMBER", typeof(String)));
        //dtt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dtt.Columns.Add(new DataColumn("IMP_JOB_NO", typeof(string)));
        dtt.Columns.Add(new DataColumn("IMP_CHARGE_NAME", typeof(string)));
        dtt.Columns.Add(new DataColumn("IMP_PARTICULAR", typeof(string)));
        dtt.Columns.Add(new DataColumn("IMP_AMOUNT", typeof(string)));
        //dtt.Columns.Add(new DataColumn("Total", typeof(string)));

        int R = 1;
        foreach (GridViewRow row in gvAll.Rows)
        {

            
            CheckBox IMP_VOUCHER_CHECK = (CheckBox)row.FindControl("chk_inv");
           //Label txt_RowNumber = (Label)row.FindControl("txt_RowNumber");
            DropDownList txt_JobNo = (DropDownList)row.FindControl("txt_JobNo");
            TextBox txtch_name = (TextBox)row.FindControl("txtch_name");
            TextBox txt_part = (TextBox)row.FindControl("txt_part");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            //TextBox txt_grand_total = (TextBox)row.FindControl("txt_grand_total"); 
            if (txtch_name.Text == string.Empty && txtAmount.Text == string.Empty)
            {

            }
            else
            {

                dr = dtt.NewRow();
                // dr[0] = txt_RowNumber.Text;
                dr[0] = IMP_VOUCHER_CHECK.Checked == true ? "True" : "False";
                //dr[1] = txt_RowNumber.Text;
                dr[2] = txt_JobNo.SelectedValue.ToString();
                dr[3] = txtch_name.Text;
                dr[4] = txt_part.Text;
                dr[5] = txtAmount.Text;
                //dr[5] = txt_grand_total.Text;

                dtt.Rows.Add(dr);
                R = R + 1;
            }
        }

        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;


    }

    public void Clear()
    {
       // txt_department.Text = "";
        txt_Date.Text = "";
        
    }

    protected void btnSave_Click(object sender, EventArgs e)
     {
         try
         {
             if (ddlCustomer_name.SelectedItem.Text != string.Empty) 
             {
                 Insert_Update("", "S", Job_no_details());
    
                
                 if (i == 1)
                 {
                     //-----------------------FOR USER RIGHTS--------------------------------//
                     ViewState["UPDATED_ID"] = null;

                     Alert_msg("Saved Successfully", "btnSave");
                     HD_Update_id.Value = Convert.ToString(VC.UpdateId);
                     hdn_job_id.Value = Convert.ToString(VC.UpdateId);

                     btnUpdate.CssClass = "save";
                     btnUpdate.Visible = true;
                     btnSave.Visible = false;
                     btn_DocsUpload.Visible = true;
                     HD_Update_id.Value = Request.QueryString["Page"].ToString();
                     Session["Imp_Voucher_id"] = HD_Update_id.Value;
                   //  JOBNO = Request.QueryString["Jobno"].ToString();
                     Session["Imp_Customer_Name"] = ddlCustomer_name.SelectedValue;
                 }
                 else if (i == 2)
                 {
                     Alert_msg("Job No Already Exist!", "btnSave");
                 }
                 else
                 {
                     btnUpdate.Visible = false;
                     btnDelete.Visible = false;
                     btnSave.Visible = true;
                     btnNew.Visible = true;
                     btn_DocsUpload.Visible = true;
                     Alert_msg("Not Saved", "btnSave"); 
                 }
             }
             else
             {
                 Alert_msg("Select Ur Correct File Refno.");
             }
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
     }
   
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {

            ObjUBO.flag = "D";
            ObjUBO.ITEM_ID = hdn_job_id.Value;
            //ObjUBO.JOBNO = ddl_JobNo.SelectedValue.ToString();
            ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
            ObjUBO.From_date = "";
            ObjUBO.Todate = "";

            ds = VC.Imp_Voucher_Creation_Select(ObjUBO);

            if(VC.result==1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Record Deleted', 'Voucher Creation', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                btnNew_Click1(sender, e);
                
            }
            else
            {
                Alert_msg("Record Not Deleted", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Voucher_NO()
    {
        DataSet dss = new DataSet();
        ObjUBO.flag = "Load_Voucher_NO";
        dss = VC.Imp_Voucher_Creation_Select(ObjUBO);
        //-----------end---------------------
        if (dss.Tables[0].Rows.Count > 0)
        {
            txt_voucherno.Text = dss.Tables[0].Rows[0]["Imp_Voucher_no"].ToString();
        }
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        //Clear();

        //ddlCustomer_name.Enabled = true;

        //ddlCustomer_name.Attributes.Remove("readonly");
        //ddlCustomer_name.Style.Add("background-color", "White");

        Load_Importer_name();
        //btnrpt.Visible = false;
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
        //http://www.codeproject.com/Articles/30722/How-to-save-data-from-a-DataSet-into-a-T-SQL-table
        // sp_name EXP_BL_GENERATION_INS_UPD
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

        string Jobno_select = string.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtch_name = (e.Row.FindControl("txtch_name") as TextBox);
            TextBox txt_part = (e.Row.FindControl("txt_part") as TextBox);
            TextBox txtAmount = (e.Row.FindControl("txtAmount") as TextBox);

            Jobno_select = this.gvAll.DataKeys[e.Row.RowIndex]["IMP_JOB_NO"].ToString();
            DropDownList ddl_JobNo = (e.Row.FindControl("txt_JobNo") as DropDownList);
           
            //---------------------
            
            DropDownList ddlch_name = (e.Row.FindControl("txt_JobNo") as DropDownList);
            DataSet ss = new DataSet();
           
            if (ViewState["CurrentTable_Ch"] != null && ViewState["CurrentTable_Ch"] != string.Empty)
            {
               //DataSet dtt = (DataSet)ViewState["CurrentTable_Ch"];
                //dt_container = ds.Tables[0];
               // DataSet dt_container = (DataSet)ViewState["CurrentTable_Ch"];
                dt_container = (DataTable)ViewState["dt_container"];
                ddl_JobNo.DataSource = dt_container;
                //ddl_JobNo.DataSource = dtt.Tables[0];
                ddl_JobNo.DataTextField = "JOBNO";
                ddl_JobNo.DataValueField = "JOBNO";
                ddl_JobNo.DataBind();
            }
            else
            {
               // DataSet ss = new DataSet();
                ss = load_jobno();
                ViewState["CurrentTable_Ch"] = ss;
                ddl_JobNo.DataSource = ss;
                ddl_JobNo.DataTextField = "JOBNO";
                ddl_JobNo.DataValueField = "JOBNO";
                ddl_JobNo.DataBind();
                ViewState["CurrentTable_Ch"] = "";
            }



            
            ddl_JobNo.Items.Insert(0, new ListItem(""));
            ddl_JobNo.Items.FindByValue(Jobno_select).Selected = true;
            ddl_JobNo.Attributes.Add("readonly", "readonly");
            //ddl_JobNo.Enabled = false;
            //--------------------------------------------------------------------------
        }
    }

    private DataSet load_jobno()
    {
        ObjUBO.flag = "Select_Jobno_from_Exporter";
        ObjUBO.Imp_Name = ddlCustomer_name.SelectedValue.ToString();
        ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        ObjUBO.From_date = "";
        ObjUBO.Todate = "";

        return VC.Imp_Voucher_Creation_Select(ObjUBO);
    }   
    

    protected void gvAll_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvAll.EditIndex = e.NewEditIndex;
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


    private void SetInitialRow()
    {
        DataTable dt = new DataTable();

        DataRow dr = null;
        dt.Columns.Add(new DataColumn("IMP_VOUCHER_CHECK", typeof(string)));
        dt.Columns.Add(new DataColumn("IMP_ROWNUMBER", typeof(string)));
        dt.Columns.Add(new DataColumn("IMP_JOB_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("IMP_CHARGE_NAME", typeof(string)));
        dt.Columns.Add(new DataColumn("IMP_PARTICULAR", typeof(string)));
        dt.Columns.Add(new DataColumn("IMP_AMOUNT", typeof(string)));
        dr = dt.NewRow();
        dr["IMP_VOUCHER_CHECK"] =true;
        dr["IMP_ROWNUMBER"] = 1;
        dr["IMP_JOB_NO"] = "";
        dr["IMP_CHARGE_NAME"] = "";
        dr["IMP_PARTICULAR"] = "";
        dr["IMP_AMOUNT"] = "";
       
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
                    CheckBox IMP_VOUCHER_CHECK = (CheckBox)gvAll.Rows[rowIndex].Cells[0].FindControl("chk_inv");
                    DropDownList txt_JobNo = (DropDownList)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_JobNo");
                    TextBox txtch_name = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txtch_name");
                    TextBox txt_part = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_part");
                    TextBox txtAmount = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txtAmount");

                    gvAll.Rows[i].Cells[1].Text = Convert.ToString(i + 1);

                    txt_JobNo.SelectedValue = dt.Rows[i]["IMP_JOB_NO"].ToString();
                    txtch_name.Text = dt.Rows[i]["IMP_CHARGE_NAME"].ToString();
                    txt_part.Text = dt.Rows[i]["IMP_PARTICULAR"].ToString();
                    txtAmount.Text = dt.Rows[i]["IMP_AMOUNT"].ToString();

                    rowIndex++;
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
                    CheckBox IMP_VOUCHER_CHECK = (CheckBox)gvAll.Rows[rowIndex].Cells[0].FindControl("chk_inv");
                    DropDownList txt_JobNo = (DropDownList)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_JobNo");
                    TextBox txtch_name = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txtch_name");
                    TextBox txt_part = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_part");
                    TextBox txtAmount = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txtAmount");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["IMP_ROWNUMBER"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["IMP_VOUCHER_CHECK"] = IMP_VOUCHER_CHECK.Checked == true ? "True" : "False";
                    dtCurrentTable.Rows[i - 1]["IMP_JOB_NO"] = txt_JobNo.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["IMP_CHARGE_NAME"] = txtch_name.Text;
                    dtCurrentTable.Rows[i - 1]["IMP_PARTICULAR"] = txt_part.Text;
                    dtCurrentTable.Rows[i - 1]["IMP_AMOUNT"] = txtAmount.Text;
                 
                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
            }
        }
        else
        {
           
        }
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
                  
                    CheckBox IMP_VOUCHER_CHECK = (CheckBox)gvAll.Rows[rowIndex].Cells[0].FindControl("chk_inv");
                    DropDownList txt_JobNo = (DropDownList)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_JobNo");
                    TextBox txtch_name = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txtch_name");
                    TextBox txt_part = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_part");
                    TextBox txtAmount = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txtAmount");
                
                    string Amt = string.Empty;
                    if (txtAmount.Text == string.Empty || txtAmount.Text == "0" || txtAmount.Text == "0.00")
                    {
                        Amt = string.Empty;
                    }
                    else
                    {
                        Amt = "Yes";
                    }

                    

                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["IMP_VOUCHER_CHECK"] = IMP_VOUCHER_CHECK.Checked == true ? "True" : "False";
                    drCurrentRow["IMP_ROWNUMBER"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["IMP_JOB_NO"] = txt_JobNo.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["IMP_CHARGE_NAME"] = txtch_name.Text;
                    dtCurrentTable.Rows[i - 1]["IMP_PARTICULAR"] = txt_part.Text;
                    dtCurrentTable.Rows[i - 1]["IMP_AMOUNT"] = txtAmount.Text;
                  
                   
                    rowIndex++;
                }

                if (Emptyrow != "Y")
                {
                    DropDownList txt_JobNo = (DropDownList)gvAll.Rows[rowIndex - 1].Cells[2].FindControl("txt_JobNo");

                    DataTable dt_cont = new DataTable();
                    dt_cont = (DataTable)ViewState["dt_container"];

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["IMP_VOUCHER_CHECK"] = "True";
                    drCurrentRow["IMP_ROWNUMBER"] = dtCurrentTable.Rows.Count + 1;
                   //txt_JobNo
                   
                    //ddl_JobNo.DataSource = dt_cont;
                   
                    //ddl_JobNo.DataTextField = "JOBNO";
                    //ddl_JobNo.DataValueField = "JOBNO";
                    //ddl_JobNo.DataBind();


                    drCurrentRow["IMP_CHARGE_NAME"] = string.Empty;
                    drCurrentRow["IMP_PARTICULAR"] = "";
                    drCurrentRow["IMP_AMOUNT"] = "0";
                    
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
    
    protected void ddlStaff_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (COMPANY_ID == "480")
        {

            if (ddlStaff_name.SelectedValue.ToString() == "S.BASKAR" || ddlStaff_name.SelectedValue.ToString() == "A.BALAMURUGAN" || ddlStaff_name.SelectedValue.ToString() == "M.DEVENDRAN"
            || ddlStaff_name.SelectedValue.ToString() == "GOPALAKRISHNAND" || ddlStaff_name.SelectedValue.ToString() == "D.KARTHICK" || ddlStaff_name.SelectedValue.ToString() == "N.GOKULAKRISHNAN"
                || ddlStaff_name.SelectedValue.ToString() == "MY.LAKSHATHI PRABHU" || ddlStaff_name.SelectedValue.ToString() == "A.B.MANIVANNAN"
                || ddlStaff_name.SelectedValue.ToString() == "S.SHARMIL KUMAR" || ddlStaff_name.SelectedValue.ToString() == "S.SEENUVASAN"
                || ddlStaff_name.SelectedValue.ToString() == "M.BABU" || ddlStaff_name.SelectedValue.ToString() == "N.RAGHU PRASAD(KMPT)" || ddlStaff_name.SelectedValue.ToString() == "R.MURUGESA PANIDIAN(KMPT)"
                || ddlStaff_name.SelectedValue.ToString() == "N.PARGUNAN")
        {
            Lb_Incurred.Visible = true;
            Rd_incurred.Visible = true;
            Lb_Certified.Visible = false;
            Rd_Ceritified.Visible = false;
            Lb_Approved.Visible = false;
            Rd_Approved.Visible = false;
            Lb_Verified.Visible = false;
            Rd_Verified.Visible = false;

        }
       

    }
        else if (COMPANY_ID == "1176" || COMPANY_ID == "10")
        {
            
            if (ddlStaff_name.SelectedValue.ToString() == "Murugesapandian" || ddlStaff_name.SelectedValue.ToString() == "Ravi" || ddlStaff_name.SelectedValue.ToString() == "Shirish")

            {
                Lb_Incurred.Visible = true;
                Rd_incurred.Visible = true;
                Lb_Certified.Visible = false;
                Rd_Ceritified.Visible = false;
                Lb_Approved.Visible = false;
                Rd_Approved.Visible = false;
                Lb_Verified.Visible = false;
                Rd_Verified.Visible = false;

            }
           

        }
        else
        {
            
                if (ddlStaff_name.SelectedValue.ToString() == "USER1" || ddlStaff_name.SelectedValue.ToString() == "USER2" || ddlStaff_name.SelectedValue.ToString() == "USER3"
                    || ddlStaff_name.SelectedValue.ToString() == "USER4" || ddlStaff_name.SelectedValue.ToString() == "USER5")
                {

                    Rd_incurred.Visible = true;
                    Lb_Certified.Visible = false;
                    Rd_Ceritified.Visible = false;
                    Lb_Approved.Visible = false;
                    Rd_Approved.Visible = false;
                    Lb_Verified.Visible = false;
                    Rd_Verified.Visible = false;

                }

           
        }
    }

    protected void btn_DocsUpload_Click(object sender, EventArgs e)
    {

        string val = HiddenField1.Value;
        string popupScript = "window.open('../Import_Report/Voucher_Creation_Details_Doc.aspx?Imp_Voucher_id=" + val + "', 'NewWindow','width=690,height=400')";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "NewWindow", popupScript, true);


    }

}
 