using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Linq;

public partial class AAI_entry : ThemeClass
{
    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    DO_Entry DO = new DO_Entry();
    Global_variables ObjUBO = new Global_variables();

    public int i,Screen_Id;
    public string SCREEN_ID, PAGE_MODIFY, PAGE_DELETE,COMPANY_LICENSE;

    string Imp_name = string.Empty, J_no = string.Empty, Ch_type = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        COMPANY_LICENSE = Connection.Company_License().ToLower();

        if (!Page.IsPostBack)
        {
            //----------------SETTING SCREEN PERMISSION---------------//
            Screen_Id = 11;
            //----------------SETTING SCREEN PERMISSION---------------//

            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            //btnrpt.Visible = false;
            T.Visible = false;


            if (Request.QueryString["Page"] == null)
            {
               load_Cus_Name();
               HDupdate_id.Value = "";
               load_Ref_Id();
               SetInitialRow();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                    //SetInitialRow();
                    //SetPreviousData();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlCus_name.Enabled = false;
                    ddljobno.Enabled = false;
                   
                    HD_Showcon.Value = "SAVED";
                    ViewState["UPDATED_ID"] = null;
                }
            }
            

            txt_Ref_Id.Attributes.Add("readonly", "readonly");
            txt_Ref_Id.Style.Add("background-color", "#F0F0F0");
            //ddl_entry_type_SelectedIndexChanged(sender, e);
        }

    }

    private void Update_Item_Load()
    {
        DataSet dss = new DataSet();
        ObjUBO.A1 = Request.QueryString["Jobno"].ToString();
        ObjUBO.A2 = Request.QueryString["Page"].ToString();
        ObjUBO.A4 = "Update_Job_Values";
        dss = DO.AAI_ENTRY_SELECT(ObjUBO);

        if (dss.Tables[0].Rows.Count > 0)
        {

            //-----------------------------------------------------
            HDupdate_id.Value = dss.Tables[0].Rows[0]["AAI_ID"].ToString();
            txt_Ref_Id.Text = dss.Tables[0].Rows[0]["REF_ID"].ToString();
            ddlCus_name.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString(), dss.Tables[0].Rows[0]["CUSTOMER_NAME"].ToString()));
            ddlCus_name.SelectedIndex = 0;
            ddljobno.Items.Insert(0, new ListItem(dss.Tables[0].Rows[0]["JOBNO"].ToString()));
            ddljobno.SelectedIndex = 0;
            txt_Manual_Jobno.Text = dss.Tables[0].Rows[0]["MANUAL_JOBNO"].ToString();
            txt_Cha_Ref_Num.Text = dss.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
            txt_no_pkgs.Text = dss.Tables[0].Rows[0]["NO_OF_PKG"].ToString();
            txt_gros_wght.Text = dss.Tables[0].Rows[0]["GROSS_WGT"].ToString();
            txt_Chrg_wght.Text = dss.Tables[0].Rows[0]["CHARGABLE_WEIGHT"].ToString();
            
                DataTable dt_item = new DataTable();
                DataRow dr = null;

                dt_item.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_TAX_INVOICE_NO", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_TAX_INVOICE_DATE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_CHARGES", typeof(string)));
                dt_item.Columns.Add(new DataColumn("DEMMURAGES_CHARGES", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_CBM", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_OOC_DATE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_CLEARANCE_DATE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_CLEARANCE_STAFF_NAME", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_TRANSPORTER_NAME", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_VEHICLE_TYPE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("AAI_VEHICLE_NO", typeof(string)));


                if (dss.Tables[0].Rows[0]["AAI_TAX_INVOICE_NO"].ToString().Contains("~"))
                {
                    string[] aaitax = dss.Tables[0].Rows[0]["AAI_TAX_INVOICE_NO"].ToString().Split('~');
                    string[] aaitaxinv = dss.Tables[0].Rows[0]["AAI_TAX_INVOICE_DATE"].ToString().Split('~');
                    string[] aaicharges = dss.Tables[0].Rows[0]["AAI_CHARGES"].ToString().Split('~');
                    string[] demchg = dss.Tables[0].Rows[0]["DEMMURAGES_CHARGES"].ToString().Split('~');
                    string[] cbm = dss.Tables[0].Rows[0]["AAI_CBM"].ToString().Split('~');
                    string[] aaioocdate = dss.Tables[0].Rows[0]["AAI_OOC_DATE"].ToString().Split('~');
                    string[] clrdate = dss.Tables[0].Rows[0]["AAI_CLEARANCE_DATE"].ToString().Split('~');
                    string[] clrstaffname = dss.Tables[0].Rows[0]["AAI_CLEARANCE_STAFF_NAME"].ToString().Split('~');
                    string[] transname = dss.Tables[0].Rows[0]["AAI_TRANSPORTER_NAME"].ToString().Split('~');
                    string[] Vehtype = dss.Tables[0].Rows[0]["AAI_VEHICLE_TYPE"].ToString().Split('~');
                    string[] vehno = dss.Tables[0].Rows[0]["AAI_VEHICLE_NO"].ToString().Split('~');

                    for (int k = 0; k <= aaitax.Count() - 1; k++)
                    {
                        if (aaitax[k] != "")
                        {
                            dt_item.Rows.Add(k + 1, aaitax[k], aaitaxinv[k], aaicharges[k], demchg[k], cbm[k], aaioocdate[k], clrdate[k], clrstaffname[k], transname[k],
                               Vehtype[k], vehno[k]);
                        }

                    }

                    gvAll.DataSource = dt_item;
                    gvAll.DataBind();
                    ViewState["CurrentTable"] = dt_item;
                    SetPreviousData();
                    ViewState["UPDATED_ID"] = "U";
                    //DataTable firstTable = dss.Tables[1];
                    //ViewState["CurrentTable"] = firstTable;
                }

                else
                {
                    dt_item.Rows.Add("");
                    //SetInitialRow();
                }




            
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Billing Invoice', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

          i = AAI_Jobno_Insert_Update(Imp_name, "S");
        
                                if (i == 1)
                                {
                                    //-----------------------FOR USER RIGHTS--------------------------------//
                                    user_Create.RetrieveAll_User_Screen_Rights_Details(Screen_Id);
                                    PAGE_MODIFY = user_Create.PAGE_MODIFY;
                                    //---------------SAVE ONLY------------------//

                                    if (PAGE_MODIFY == "False")
                                    {
                                        btnNew_Click1(sender, e);
                                    }
                                    else
                                    {
                                        btnUpdate.CssClass = "save";
                                        btnUpdate.Visible = true;
                                        btnSave.Visible = false;
                                        btnSave.Focus();
                                    }
                                    //-----------------------FOR USER RIGHTS--------------------------------//

                                    ViewState["UPDATED_ID"] = null;
                                    HD_Showcon.Value = "SAVED";
                                    Alert_msg("Saved Successfully", "btnSave");
                                    HDupdate_id.Value = Convert.ToString(DO.UPDATE_ID);

                                    //btnrpt.Visible = true;
                                  
                                    F.Visible = false;
                                    T.Visible = true;

                                    ddlCus_name.Attributes.Add("readonly", "readonly");
                                    ddlCus_name.Style.Add("background-color", "#F0F0F0");

                                    ddljobno.Attributes.Add("readonly", "readonly");
                                    ddljobno.Style.Add("background-color", "#F0F0F0");

                                    ddlCus_name.Enabled = false;
                                    ddljobno.Enabled = false;

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
                                    Alert_msg("Not Saved", "btnSave");
                                }
                                //-------------------------------------------------------------
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = AAI_Jobno_Insert_Update(Imp_name, "U");
                    if (i == 1)
                    {
                        if (ViewState["UPDATED_ID"] != null)
                        {
                            Alert_msg("Updated Successfully", "btnUpdate");
                        }
                        else
                        {
                            Alert_msg("Saved Successfully", "btnUpdate");
                            HD_Showcon.Value = "SAVED";
                        }
                    }
                    else if (i == 2)
                    {
                        Alert_msg("Job No Already Exist!", "btnUpdate");
                    }
                    else
                    {
                        btnUpdate.Visible = true;
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
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            i = AAI_Jobno_Insert_Update("", "D");
            if (i == 1)
            {
                btnNew_Click1(sender, e);
                Alert_msg("Deleted");
               // btnrpt.Visible = false;
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

public int AAI_Jobno_Insert_Update(string I_Name, string Flag)
{
    ObjUBO.A1 = HDupdate_id.Value.ToString();

    ObjUBO.A2 = ddlCus_name.SelectedItem.ToString();
    ObjUBO.A3 = ddljobno.SelectedValue.ToString();
    //ObjUBO.A28 = ddl_entry_type.SelectedValue.ToString();
    ObjUBO.A4 = txt_Manual_Jobno.Text;
    ObjUBO.A6 = txt_Cha_Ref_Num.Text;
    ObjUBO.A7 = txt_no_pkgs.Text;
    ObjUBO.A11 = txt_gros_wght.Text;
    ObjUBO.A12 = txt_Chrg_wght.Text;
    ObjUBO.A25 = Flag;
    ObjUBO.A26 = txt_Ref_Id.Text;
    //ObjUBO.A27 = txt_Consigee_Name.Text;
    foreach (GridViewRow row in gvAll.Rows)
    {
        TextBox txt_inv_no = (TextBox)row.FindControl("txt_inv_no");
        TextBox txt_tx_inv_dt = (TextBox)row.FindControl("txt_tx_inv_dt");
        TextBox txt_aai_chrges = (TextBox)row.FindControl("txt_aai_chrges");
        TextBox txt_dmg_chrges = (TextBox)row.FindControl("txt_dmg_chrges");
        TextBox txt_aai_cbm = (TextBox)row.FindControl("txt_aai_cbm");
        TextBox txt_ooc_date = (TextBox)row.FindControl("txt_ooc_date");
        TextBox txt_clr_dat = (TextBox)row.FindControl("txt_clr_dat");
        TextBox txt_clr_name = (TextBox)row.FindControl("txt_clr_name");
        TextBox txt_transport_name = (TextBox)row.FindControl("txt_transport_name");
       // TextBox txt_clear_staff_name = (TextBox)row.FindControl("txt_clear_staff_name");
        TextBox txt_vehi_type = (TextBox)row.FindControl("txt_vehi_type");
        TextBox txt_vehi_no = (TextBox)row.FindControl("txt_vehi_no");
       
        if (txt_inv_no.Text != "")
        {
            //ObjUBO.A13 += Convert.ToDecimal(txt_tax_inv_no.Text == "" ? "0.00" : txt_tax_inv_no.Text) +"~";
            ObjUBO.A13 += txt_inv_no.Text + "~";
            ObjUBO.A29 += txt_tx_inv_dt.Text + "~";
            ObjUBO.A14 += txt_aai_chrges.Text + "~";
            ObjUBO.A15 += txt_dmg_chrges.Text + "~";
            ObjUBO.A16 += txt_aai_cbm.Text + "~";
            ObjUBO.A17 += txt_ooc_date.Text + "~";
            ObjUBO.A18 += txt_clr_dat.Text + "~";
            ObjUBO.A19 += txt_clr_name.Text + "~";
            ObjUBO.A20 += txt_transport_name.Text + "~";
            //ObjUBO.A21 += txt_clear_staff_name.Text + "~";
            ObjUBO.A21 += txt_vehi_type.Text + "~";
            ObjUBO.A22 += txt_vehi_no.Text + "~";
           
            //ObjUBO.A15 += Convert.ToDecimal(txt_Console_chg.Text == "" ? "0.00" : txt_Console_chg.Text);
            //ObjUBO.A16 += Convert.ToDecimal(txt_port_Str_amt.Text == "" ? "0.00" : txt_port_Str_amt.Text);
            //ObjUBO.A17 += Convert.ToDecimal(txt_Detent_Amt.Text  == "" ? "0.00" : txt_Detent_Amt.Text );
            //ObjUBO.A18 += Convert.ToDecimal(txt_dam_chg.Text == "" ? "0.00" :txt_dam_chg.Text);
            //ObjUBO.A21 += Convert.ToDecimal(txt_UTR_Amt.Text == "" ? "0.00" : txt_UTR_Amt.Text);

        }
    }
    DO.AAI_INS_UPD(ObjUBO);
    i = DO.result;
    return i;
}
private void load_Cus_Name()
    {
        try
        {
            ddlCus_name.Items.Clear();
            ddljobno.Items.Clear();
           
                DataSet dss = new DataSet();
                ObjUBO.A4 = "Imp_Name_Select";
                dss = DO.DO_ENTRY_SELECT(ObjUBO);

                if (dss.Tables[0].Rows.Count > 0)
                {
                    ddlCus_name.DataSource = dss.Tables[0];
                    ddlCus_name.DataTextField = "Cus_Name";
                    ddlCus_name.DataValueField = "Cus_Name";
                    ddlCus_name.DataBind();
                }
                ddlCus_name.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddlCus_name.SelectedIndex = 0;

                ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddljobno.SelectedIndex = 0;
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Jobno()
    {
        ddljobno.Items.Clear();
        try
        {
          
                if (ddlCus_name.SelectedValue.ToString() != string.Empty)
                {
                    DataSet dss = new DataSet();
                    ObjUBO.A3 = ddlCus_name.SelectedValue.ToString();
                    ObjUBO.A4 = "Jobno_Select";
                    dss = DO.AAI_ENTRY_SELECT(ObjUBO);
                    //-----------end---------------------
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        ddljobno.DataSource = dss.Tables[0];
                        ddljobno.DataTextField = "JOBNO";
                        ddljobno.DataValueField = "JOBNO";
                        ddljobno.DataBind();
                    }
                }

                ddljobno.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                ddljobno.SelectedIndex = 0;
            }
        
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    private void load_Ref_Id()
    {
        
            DataSet dss = new DataSet();
            ObjUBO.A4 = "Load_Ref_Id";
            dss = DO.AAI_ENTRY_SELECT(ObjUBO);
            //-----------end---------------------
            if (dss.Tables[0].Rows.Count > 0)
            {
                txt_Ref_Id.Text = dss.Tables[0].Rows[0]["REF_ID"].ToString();
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

        HDupdate_id.Value = string.Empty;

        ddlCus_name.Enabled = true;
        ddljobno.Enabled = true;
        //btnrpt.Visible = false;

        load_Cus_Name();

        ddlCus_name.Style.Add("background-color", "white");
        ddljobno.Style.Add("background-color", "white");

        load_Ref_Id();
    }
    protected void ddljobno_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_data();
    }
    protected void ddlCus_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_Jobno();
    }
    private void Load_data()
    {
        DataSet ds = new DataSet();
       
           
            if (ddljobno.SelectedValue.ToString() != string.Empty)
            {
                ObjUBO.A1 = ddljobno.SelectedValue.ToString();
                ObjUBO.A3 = ddlCus_name.SelectedValue.ToString();
                ObjUBO.A4 = "IMP_Job_Data";
                ds = DO.AAI_ENTRY_SELECT(ObjUBO);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    txt_Cha_Ref_Num.Text = ds.Tables[0].Rows[0]["FILE_REF_NO"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_no_pkgs.Text = ds.Tables[1].Rows[0]["NO_OF_PKG"].ToString();
                    txt_gros_wght.Text = ds.Tables[1].Rows[0]["GROSS_WGT"].ToString();
                    //txt_Gross_wght.Text = ds.Tables[1].Rows[0]["GROSS_WGT"].ToString();
                }

                //if (ds.Tables[2].Rows.Count > 0)
                //{

                //    ddl_Mode_Type.SelectedValue = ds.Tables[2].Rows[0]["FCL_OR_LCL"].ToString();
                //    txt_20_F.Text = ds.Tables[2].Rows[0]["T20w_Ft"].ToString();
                //    txt_40_F.Text = ds.Tables[2].Rows[0]["F40_Ft"].ToString();
                //    //txt_twenty_cont.Text = ds.Tables[2].Rows[0]["T20w_Ft"].ToString();
                //    //txt_forty_Cont.Text = ds.Tables[2].Rows[0]["F40_Ft"].ToString();
                //    //txt_LCL.Text = ds.Tables[2].Rows[0]["FCL_OR_LCL"].ToString();
                //    //txt_FCL.Text = ds.Tables[2].Rows[0]["FCL_OR_LCL"].ToString();
                //}

            }
        }
    
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();

        DataRow dr = null;
       
        
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_TAX_INVOICE_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_TAX_INVOICE_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_CHARGES", typeof(string)));
            dt.Columns.Add(new DataColumn("DEMMURAGES_CHARGES", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_CBM", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_OOC_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_CLEARANCE_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_CLEARANCE_STAFF_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_TRANSPORTER_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_VEHICLE_TYPE", typeof(string)));
            dt.Columns.Add(new DataColumn("AAI_VEHICLE_NO", typeof(string)));
            


            dr = dt.NewRow();

            dr["RowNumber"] = 1;
            dr["AAI_TAX_INVOICE_NO"] = "";
            dr["AAI_TAX_INVOICE_DATE"] = "";
            dr["AAI_CHARGES"] = "";
            dr["DEMMURAGES_CHARGES"] = "";
            dr["AAI_CBM"] = "";
            dr["AAI_OOC_DATE"] = "";
            dr["AAI_CLEARANCE_DATE"] = "";
            dr["AAI_CLEARANCE_STAFF_NAME"] = "";
            dr["AAI_TRANSPORTER_NAME"] = "";
            dr["AAI_VEHICLE_TYPE"] = "";
            dr["AAI_VEHICLE_NO"] = "";
            

            dt.Rows.Add(dr);

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            gvAll.DataSource = dt;
            gvAll.DataBind();
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
        /*if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("ddl_ContainerNo");

            DropDownList1.DataSource = dt_container;
            DropDownList1.DataTextField = "CONTAINER_NO";
            DropDownList1.DataValueField = "CONTAINER_NO";
            DropDownList1.DataBind();

            DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("ddl_size");

            if (dt_container.Rows.Count > 0)
            {
                if (dt_container.Rows[0]["TYPE"].ToString() != "")
                {
                    DropDownList2.DataSource = dt_container;
                    DropDownList2.DataTextField = "TYPE";
                    DropDownList2.DataValueField = "TYPE";
                    DropDownList2.DataBind();
                }
                else
                {
                    //DataTable dt_container = new DataTable();
                    //dt_container.Columns.Add("CONTAINER_NO");
                    //dt_container.Columns.Add("TYPE");
                    dt_container.Rows.Add("", "");
                    dt_container.Rows.Add("", "20");
                    dt_container.Rows.Add("", "40");
                    //ViewState["dt_container"] = dt_container;

                    DataView view = new DataView(dt_container);
                    DataTable distinctValues = view.ToTable(true, "TYPE");

                    DropDownList2.DataSource = distinctValues;
                    DropDownList2.DataTextField = "TYPE";
                    DropDownList2.DataValueField = "TYPE";
                    DropDownList2.DataBind();
                }
            }
            else
            {
                //DataTable dt_container = new DataTable();
                dt_container.Columns.Add("CONTAINER_NO");
                dt_container.Columns.Add("TYPE");

                dt_container.Rows.Add("", "");
                dt_container.Rows.Add("", "20");
                dt_container.Rows.Add("", "40");
                //ViewState["dt_container"] = dt_container;

                DataView view = new DataView(dt_container);
                DataTable distinctValues = view.ToTable(true, "TYPE");

                DropDownList2.DataSource = dt_container;
                DropDownList2.DataTextField = "TYPE";
                DropDownList2.DataValueField = "TYPE";
                DropDownList2.DataBind();
            }
        }*/
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
    private void AddNewRowToGrid()
    {
         int rowIndex = 0;
         string Emptyrow = string.Empty;

         if (ViewState["CurrentTable"] != null)
         {
             DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
             DataRow drCurrentRow = null;
            
                 dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                 drCurrentRow = null;
                 if (dtCurrentTable.Rows.Count > 0)
                 {
                     for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                     {
                         //extract the TextBox values
                         TextBox txt_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_inv_no");
                         TextBox txt_tx_inv_dt = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_tx_inv_dt");
                         TextBox txt_aai_chrges = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_aai_chrges");
                         TextBox txt_dmg_chrges = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_dmg_chrges");
                         TextBox txt_aai_cbm = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_aai_cbm");
                         TextBox txt_ooc_date = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_ooc_date");
                         TextBox txt_clr_dat = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_clr_dat");
                         TextBox txt_clr_name = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_clr_name");
                         TextBox txt_transport_name = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_transport_name");
                         TextBox txt_vehi_type = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_vehi_type");
                         TextBox txt_vehi_no = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_vehi_no");
                         
                         if (txt_inv_no.Text == string.Empty)
                         {
                             Emptyrow = "Y";
                         }

                         drCurrentRow = dtCurrentTable.NewRow();
                         drCurrentRow["RowNumber"] = i + 1;
                         dtCurrentTable.Rows[i - 1]["AAI_TAX_INVOICE_NO"] = txt_inv_no.Text;
                         dtCurrentTable.Rows[i - 1]["AAI_TAX_INVOICE_DATE"] = txt_tx_inv_dt.Text;
                         dtCurrentTable.Rows[i - 1]["AAI_CHARGES"] = txt_aai_chrges.Text;
                         dtCurrentTable.Rows[i - 1]["DEMMURAGES_CHARGES"] = txt_dmg_chrges.Text;
                         dtCurrentTable.Rows[i - 1]["AAI_CBM"] = txt_aai_cbm.Text;
                         dtCurrentTable.Rows[i - 1]["AAI_OOC_DATE"] = txt_ooc_date.Text;
                         dtCurrentTable.Rows[i - 1]["AAI_CLEARANCE_DATE"] = txt_clr_dat.Text;
                         dtCurrentTable.Rows[i - 1]["AAI_CLEARANCE_STAFF_NAME"] = txt_clr_name.Text;
                         dtCurrentTable.Rows[i - 1]["AAI_TRANSPORTER_NAME"] = txt_transport_name.Text;
                         dtCurrentTable.Rows[i - 1]["AAI_VEHICLE_TYPE"] = txt_vehi_type.Text;
                         dtCurrentTable.Rows[i - 1]["AAI_VEHICLE_NO"] = txt_vehi_no.Text;
                         
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
        // SetPreviousData();
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
                        TextBox txt_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_inv_no");
                        TextBox txt_tx_inv_dt = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_tx_inv_dt");
                        TextBox txt_aai_chrges = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_aai_chrges");
                        TextBox txt_dmg_chrges = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_dmg_chrges");
                        TextBox txt_aai_cbm = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_aai_cbm");
                        TextBox txt_ooc_date = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_ooc_date");
                        TextBox txt_clr_dat = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_clr_dat");
                        TextBox txt_clr_name = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_clr_name");
                        TextBox txt_transport_name = (TextBox)gvAll.Rows[rowIndex].Cells[9].FindControl("txt_transport_name");
                        TextBox txt_vehi_type = (TextBox)gvAll.Rows[rowIndex].Cells[10].FindControl("txt_vehi_type");
                        TextBox txt_vehi_no = (TextBox)gvAll.Rows[rowIndex].Cells[11].FindControl("txt_vehi_no");
                     

                        gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                        if (dt.Rows[i][1].ToString() != "")
                        {
                            //txtContainerNo.Text = dt.Rows[i][1].ToString();
                            txt_inv_no.Text = dt.Rows[i][1].ToString();
                            txt_tx_inv_dt.Text = dt.Rows[i][2].ToString();
                            txt_aai_chrges.Text = dt.Rows[i][3].ToString();
                            txt_dmg_chrges.Text = dt.Rows[i][4].ToString();
                            txt_aai_cbm.Text = dt.Rows[i][5].ToString();
                            txt_ooc_date.Text = dt.Rows[i][6].ToString();
                            txt_clr_dat.Text = dt.Rows[i][7].ToString();
                            txt_clr_name.Text = dt.Rows[i][8].ToString();
                            txt_transport_name.Text = dt.Rows[i][9].ToString();
                            txt_vehi_type.Text = dt.Rows[i][10].ToString();
                            txt_vehi_no.Text = dt.Rows[i][11].ToString();
                            
                            //dt_cont = (DataTable)ViewState["dt_container"];



                            rowIndex++;
                        }
                        else
                        {
                            txt_inv_no.Text = "";
                            txt_tx_inv_dt.Text = "";
                            txt_aai_chrges.Text = "";
                            txt_dmg_chrges.Text = "";
                            txt_aai_cbm.Text = "";
                            txt_ooc_date.Text = "";
                            txt_clr_dat.Text = "";
                            txt_clr_name.Text = "";
                            txt_transport_name.Text ="";
                            txt_vehi_type.Text = "";
                            txt_vehi_no.Text = "";
                            //txt_tax_inv_no.Text = "";
                            //txt_Tax_Inv_date.Text = "";
                            //txt_tax_inv_amt.Text = "";
                            //txt_Hold_chq.Text = "";
                            //txt_Hold_chq_date.Text = "";
                            //txt_Hold_amt.Text = "";
                            //txt_UTR_No.Text = "";
                            //txt_UTR_date.Text = "";
                            //txt_UTR_Amt.Text = "";
                            //txt_Hold_chq_return_date.Text = "";
                            //txt_hold_rec_date.Text = "";

                            DataTable dt_cont = new DataTable();
                            dt_cont = (DataTable)ViewState["dt_container"];


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
                        TextBox txt_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_inv_no");
                        TextBox txt_tx_inv_dt = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_tx_inv_dt");
                        TextBox txt_aai_chrges = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_aai_chrges");
                        TextBox txt_dmg_chrges = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_dmg_chrges");
                        TextBox txt_aai_cbm = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_aai_cbm");
                        TextBox txt_ooc_date = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_ooc_date");
                        TextBox txt_clr_dat = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_clr_dat");
                        TextBox txt_clr_name = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_clr_name");
                        TextBox txt_transport_name = (TextBox)gvAll.Rows[rowIndex].Cells[9].FindControl("txt_transport_name");
                        TextBox txt_vehi_type = (TextBox)gvAll.Rows[rowIndex].Cells[10].FindControl("txt_vehi_type");
                        TextBox txt_vehi_no = (TextBox)gvAll.Rows[rowIndex].Cells[11].FindControl("txt_vehi_no");
                        


                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["AAI_TAX_INVOICE_NO"] = txt_inv_no.Text;
                        dtCurrentTable.Rows[i - 1]["AAI_TAX_INVOICE_DATE"] = txt_tx_inv_dt.Text;
                        dtCurrentTable.Rows[i - 1]["AAI_CHARGES"] = txt_tx_inv_dt.Text;
                        dtCurrentTable.Rows[i - 1]["DEMMURAGES_CHARGES"] = txt_dmg_chrges.Text;
                        dtCurrentTable.Rows[i - 1]["AAI_CBM"] = txt_aai_cbm.Text;
                        dtCurrentTable.Rows[i - 1]["AAI_OOC_DATE"] = txt_ooc_date.Text;
                        dtCurrentTable.Rows[i - 1]["AAI_CLEARANCE_DATE"] = txt_clr_dat.Text;
                        dtCurrentTable.Rows[i - 1]["AAI_CLEARANCE_STAFF_NAME"] = txt_clr_name.Text;
                        dtCurrentTable.Rows[i - 1]["AAI_TRANSPORTER_NAME"] = txt_transport_name.Text;
                        dtCurrentTable.Rows[i - 1]["AAI_VEHICLE_TYPE"] = txt_vehi_type.Text;
                        dtCurrentTable.Rows[i - 1]["AAI_VEHICLE_NO"] = txt_vehi_no.Text;
                       

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
    
   /* protected void ddl_entry_type_SelectedIndexChanged_Test(object sender, EventArgs e)
    {
        if (ddl_entry_type.SelectedItem.Text == "DO")
        {
           // this.gvAll.Columns[1].HeaderText = "DO-1";
            gvAll.HeaderRow.Cells[1].Text = "DO-1";
        }
        else if (ddl_entry_type.SelectedItem.Text == "CFS")
        {
            gvAll.HeaderRow.Cells[1].Text = "CFS-1";
        }
        else if (ddl_entry_type.SelectedItem.Text == "AAI")
        {
            gvAll.HeaderRow.Cells[1].Text = "AAI-1";
        }
    }*/
//protected void ddl_entry_type_SelectedIndexChanged(object sender, EventArgs e)
//    {
//         DataSet dss = new DataSet();
//         int rowIndex = 0;
//         if (ddl_entry_type.SelectedItem.Text == "DO")
//         {
//             load_Ref_Id();
//             load_Jobno();
//             Load_data();
//             //SetInitialRow();
//             //AddNewRowToGrid();
//             Lb_name.Text = "Consignee Name";
//             Lb_mbl.Text = "MBL No";
//             Lb_hbl.Text = "HBL No";
//             Lb_pkg.Text = "Packages";
//             Lb_type.Text = "Mode Type";
//             Lb_cnt1.Text = "20'F";
//             Lb_cnt.Text = "40'F";
//             Lb_grwght.Text = "Gross Weight";
//             Lb_netwght.Text = "Net Wgt";
//             Lb_rem.Text = "Remarks";
//             txt_Consigee_Name.Visible = true;
//             txt_MBL_No.Visible = true;
//             txt_HBL_No.Visible = true;
//             txt_Pkg.Visible = true;
//             ddl_Mode_Type.Visible = true;
//             txt_20_F.Visible = true;
//             txt_40_F.Visible = true;
//             txt_Gross_Wgt.Visible = true;
//             txt_Net_Wgt.Visible = true;
//             Txt_remarks.Visible = true;
//             txt_CHA_Ref_No.Visible = false;
//             txt_twenty_cont.Visible = false;
//             txt_forty_Cont.Visible = false;
//             txt_LCL.Visible = false;
//             txt_FCL.Visible = false;
//             txt_Gross_wght.Visible = false;
//             txt_BB.Visible = false;
//             txt_Cha_Ref_Num.Visible = false;
//             txt_no_pkgs.Visible = false;
//             txt_gros_wght.Visible = false;
//             txt_Chrg_wght.Visible = false;
//             //txt_CFS_Name.Visible = false;
//             //txt_Staff_Name.Visible = false;
//             gvAll.HeaderRow.Cells[1].Text = "Liner Name";
//             gvAll.HeaderRow.Cells[2].Text = "Consol Name";
//             gvAll.HeaderRow.Cells[3].Text = "Consol Charge";
//             gvAll.HeaderRow.Cells[4].Text = "Liner Charge";
//             gvAll.HeaderRow.Cells[5].Text = "DO Free Days";
//             gvAll.HeaderRow.Cells[6].Text = "Port Storage Amt";
//             gvAll.HeaderRow.Cells[7].Text = "Port D/O Revalid";
//             gvAll.HeaderRow.Cells[8].Text = "Detention Amt";
//             gvAll.HeaderRow.Cells[9].Text = "Deten D/O Revalid";
//             gvAll.HeaderRow.Cells[10].Text = "Damage Charges";
//             gvAll.HeaderRow.Cells[11].Text = "Late Do Fee";
//             gvAll.HeaderRow.Cells[12].Text = "Tax Invoice No";
//             gvAll.HeaderRow.Cells[13].Text = "Tax Invoice Date";
//             gvAll.HeaderRow.Cells[14].Text = "Tax Invoice Amount";
//             gvAll.HeaderRow.Cells[15].Text = "Holding Chq No";
//             gvAll.HeaderRow.Cells[16].Text = "Holding Chq Date";
//             gvAll.HeaderRow.Cells[17].Text = "Holding Amt";
//             gvAll.HeaderRow.Cells[18].Text = "UTR NO";
//             gvAll.HeaderRow.Cells[19].Text = "UTR Date";
//             gvAll.HeaderRow.Cells[20].Text = "UTR Amount";
//             gvAll.HeaderRow.Cells[21].Text = "Holding Return Date";
//             gvAll.HeaderRow.Cells[22].Text = "Holding Received Date";
            
//             //if (dss.Tables[0].Rows.Count > 0)
//             //{
//             //    gvAll.HeaderRow.Cells[1].Text = "Tax Invoice No";


//             //}
//         }
//         else if (ddl_entry_type.SelectedItem.Text == "CFS")
//        {
           
//           // AddNewRowToGrid();
//            DataTable dt = new DataTable();
//            load_Ref_Id();
//            load_Jobno();
//            Load_data();
//            SetInitialRow();
//            AddNewRowToGrid();
//            //SetRowData();
//            //SetPreviousData();
//            Lb_name.Text = "Importer Ref";
//            Lb_mbl.Text = "20'";
//            Lb_hbl.Text = "40'";
//            Lb_pkg.Text = "LCL";
//            Lb_type.Text = "FCL";
//            Lb_cnt1.Text = "BB";
//            Lb_cnt.Text = "Gross Weight";
//            Lb_grwght.Text = "";
//            Lb_netwght.Text = "";
//            Lb_rem.Text = "";
//            txt_CHA_Ref_No.Visible = true;
//            txt_twenty_cont.Visible = true;
//            txt_forty_Cont.Visible = true;
//            txt_LCL.Visible = true;
//            txt_FCL.Visible = true;
//            txt_Gross_wght.Visible = true;
//            txt_BB.Visible = true;
//            //txt_CFS_Name.Visible = true;
//            //txt_Staff_Name.Visible = true;
//            txt_Consigee_Name.Visible = false;
//            txt_MBL_No.Visible = false;
//            txt_HBL_No.Visible = false;
//            txt_Pkg.Visible = false;
//            ddl_Mode_Type.Visible = false;
//            txt_20_F.Visible = false;
//            txt_40_F.Visible = false;
//            txt_Gross_Wgt.Visible = false;
//            txt_Net_Wgt.Visible = false;
//            Txt_remarks.Visible = false;
//            txt_Cha_Ref_Num.Visible = false;
//            txt_no_pkgs.Visible = false;
//            txt_gros_wght.Visible = false;
//            txt_Chrg_wght.Visible = false;
//            gvAll.HeaderRow.Cells[1].Text = "CFS Name";
//            gvAll.HeaderRow.Cells[2].Text = "Tax Invoice No";
//            gvAll.HeaderRow.Cells[3].Text = "Tax Invoice Date";
//            gvAll.HeaderRow.Cells[4].Text = "Tax Invoice Amount";
//            gvAll.HeaderRow.Cells[5].Text = "Storage";
//            gvAll.HeaderRow.Cells[6].Text = "OOC Date";
//            gvAll.HeaderRow.Cells[7].Text = "Clearance Date";
//            gvAll.HeaderRow.Cells[8].Text = "CBM";
//            gvAll.HeaderRow.Cells[9].Text = "Clearance Staff Name";
//            gvAll.HeaderRow.Cells[10].Text = "Transporter Name";
//            gvAll.HeaderRow.Cells[11].Text = "Vehicle Type";
//            gvAll.HeaderRow.Cells[12].Text = "Vehicle No";
//            this.gvAll.HeaderRow.Cells[13].Visible = false;
//            this.gvAll.HeaderRow.Cells[14].Visible = false;
//            this.gvAll.HeaderRow.Cells[15].Visible = false;
//            this.gvAll.HeaderRow.Cells[16].Visible = false;
//            this.gvAll.HeaderRow.Cells[17].Visible = false;
//            this.gvAll.HeaderRow.Cells[18].Visible = false;
//            this.gvAll.HeaderRow.Cells[19].Visible = false;
//            this.gvAll.HeaderRow.Cells[20].Visible = false;
//            this.gvAll.HeaderRow.Cells[21].Visible = false;
//            this.gvAll.HeaderRow.Cells[22].Visible = false;
//            //ViewState["CurrentTable"] = dt;
//            TextBox txt_Cfs_name = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Cfs_name");
//            TextBox txt_txn_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_txn_inv_no");
//            TextBox txt_inv_dt = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_inv_dt");
//            TextBox txt_txv_inv_amt = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_txv_inv_amt");
//            TextBox txt_strg = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_strg");
//            TextBox txt_ooc_dt = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_ooc_dt");
//            TextBox txt_clr_dt = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_clr_dt");
//            TextBox txt_cbm = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_cbm");
//            TextBox txt_Clear_name = (TextBox)gvAll.Rows[rowIndex].Cells[9].FindControl("txt_Clear_name");
//            TextBox txt_trans_name = (TextBox)gvAll.Rows[rowIndex].Cells[10].FindControl("txt_trans_name");
//            TextBox txt_veh_type = (TextBox)gvAll.Rows[rowIndex].Cells[11].FindControl("txt_veh_type");
//            TextBox txt_veh_no = (TextBox)gvAll.Rows[rowIndex].Cells[12].FindControl("txt_veh_no");
//            TextBox txt_Line_Name = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Line_Name");
//            TextBox txt_Console_Name = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_Console_Name");
//            TextBox txt_Console_chg = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_Console_chg");
//            TextBox txt_Line_Chg = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_Line_Chg");
//            TextBox txt_do_free_days = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_do_free_days");
//            TextBox txt_port_Str_amt = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_port_Str_amt");
//            TextBox txt_port_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_port_revalidation");
//            TextBox txt_Detent_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_Detent_Amt");
//            TextBox txt_detention_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[9].FindControl("txt_detention_revalidation");
//            TextBox txt_dam_chg = (TextBox)gvAll.Rows[rowIndex].Cells[10].FindControl("txt_dam_chg");
//            TextBox txt_do_fee = (TextBox)gvAll.Rows[rowIndex].Cells[11].FindControl("txt_do_fee");
//            TextBox txt_tax_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[12].FindControl("txt_tax_inv_no");
//            TextBox txt_Tax_Inv_date = (TextBox)gvAll.Rows[rowIndex].Cells[13].FindControl("txt_Tax_Inv_date");
//            TextBox txt_tax_inv_amt = (TextBox)gvAll.Rows[rowIndex].Cells[14].FindControl("txt_tax_inv_amt");
//            TextBox txt_Hold_chq = (TextBox)gvAll.Rows[rowIndex].Cells[15].FindControl("txt_Hold_chq");
//            TextBox txt_Hold_chq_date = (TextBox)gvAll.Rows[rowIndex].Cells[16].FindControl("txt_Hold_chq_date");
//            TextBox txt_Hold_amt = (TextBox)gvAll.Rows[rowIndex].Cells[17].FindControl("txt_Hold_amt");
//            TextBox txt_UTR_No = (TextBox)gvAll.Rows[rowIndex].Cells[18].FindControl("txt_UTR_No");
//            TextBox txt_UTR_date = (TextBox)gvAll.Rows[rowIndex].Cells[19].FindControl("txt_UTR_date");
//            TextBox txt_UTR_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[20].FindControl("txt_UTR_Amt");
//            TextBox txt_Hold_chq_return_date = (TextBox)gvAll.Rows[rowIndex].Cells[21].FindControl("txt_Hold_chq_return_date");
//            TextBox txt_hold_rec_date = (TextBox)gvAll.Rows[rowIndex].Cells[22].FindControl("txt_hold_rec_date");
//            txt_Cfs_name.Visible = true;
//            txt_txn_inv_no.Visible = true;
//            txt_inv_dt.Visible = true;
//            txt_txv_inv_amt.Visible = true;
//            txt_strg.Visible = true;
//            txt_ooc_dt.Visible = true;
//            txt_clr_dt.Visible = true;
//            txt_cbm.Visible = true;
//            txt_Clear_name.Visible = true;
//            txt_trans_name.Visible = true;
//            txt_veh_type.Visible = true;
//            txt_veh_no.Visible = true;
//            txt_Line_Name.Visible = false;
//            txt_Console_Name.Visible = false;
//            txt_Console_chg.Visible = false;
//            txt_Line_Chg.Visible = false;
//            txt_do_free_days.Visible = false;
//            txt_port_Str_amt.Visible = false;
//            txt_port_revalidation.Visible = false;
//            txt_Detent_Amt.Visible = false;
//            txt_detention_revalidation.Visible = false;
//            txt_dam_chg.Visible = false;
//            txt_do_fee.Visible = false;
//            txt_tax_inv_no.Visible = false;
//            txt_Tax_Inv_date.Visible = false;
//            txt_tax_inv_amt.Visible = false;
//            txt_Hold_chq.Visible = false;
//            txt_Hold_chq_date.Visible = false;
//            txt_Hold_amt.Visible = false;
//            txt_UTR_No.Visible = false;
//            txt_UTR_date.Visible = false;
//            txt_UTR_Amt.Visible = false;
//            txt_Hold_chq_return_date.Visible = false;
//            txt_hold_rec_date.Visible = false;
//        }
//         else if (ddl_entry_type.SelectedItem.Text == "AAI")
//         {
             
//             load_Ref_Id();
//             load_Jobno();
//             Load_data();
//             SetInitialRow();
//             AddNewRowToGrid();
//             SetRowData();
//             //SetPreviousData();

//             Lb_name.Text = "Importer Ref No";
//             Lb_mbl.Text = "No of PKG";
//             Lb_hbl.Text = "Gross Weight";
//             Lb_pkg.Text = "Chargable Weight";
//             txt_Cha_Ref_Num.Visible = true;
//             txt_no_pkgs.Visible = true;
//             txt_gros_wght.Visible = true;
//             txt_Chrg_wght.Visible = true;
//             Lb_type.Visible = false;
//             Lb_cnt1.Visible = false;
//             Lb_cnt.Visible = false;
//             Lb_grwght.Visible = false;
//             Lb_netwght.Visible = false;
//             Lb_rem.Visible = false;
//             txt_CHA_Ref_No.Visible = false;
//             txt_twenty_cont.Visible = false;
//             txt_forty_Cont.Visible = false;
//             txt_LCL.Visible = false;
//             txt_FCL.Visible = false;
//             txt_Gross_wght.Visible = false;
//             txt_BB.Visible = false;
//             //txt_CFS_Name.Visible = true;
//             //txt_Staff_Name.Visible = true;
//             txt_Consigee_Name.Visible = false;
//             txt_MBL_No.Visible = false;
//             txt_HBL_No.Visible = false;
//             txt_Pkg.Visible = false;
//             ddl_Mode_Type.Visible = false;
//             txt_20_F.Visible = false;
//             txt_40_F.Visible = false;
//             txt_Gross_Wgt.Visible = false;
//             txt_Net_Wgt.Visible = false;
//             Txt_remarks.Visible = false;
//             gvAll.HeaderRow.Cells[1].Text = "Tax Invoice No";
//             gvAll.HeaderRow.Cells[2].Text = "Tax Invoice Date";
//             gvAll.HeaderRow.Cells[3].Text = "AAI Charges";
//             gvAll.HeaderRow.Cells[4].Text = "DemurageChrgs";
//             gvAll.HeaderRow.Cells[5].Text = "CBM";
//             gvAll.HeaderRow.Cells[6].Text = "OOC Date";
//             gvAll.HeaderRow.Cells[7].Text = "Clearance Date";
//             gvAll.HeaderRow.Cells[8].Text = "Clearance Staff Name";
//             gvAll.HeaderRow.Cells[9].Text = "Transporter Name";
//             gvAll.HeaderRow.Cells[11].Text = "Vehicle Type";
//             gvAll.HeaderRow.Cells[12].Text = "Vehicle No";
//             this.gvAll.HeaderRow.Cells[13].Visible = false;
//             this.gvAll.HeaderRow.Cells[14].Visible = false;
//             this.gvAll.HeaderRow.Cells[15].Visible = false;
//             this.gvAll.HeaderRow.Cells[16].Visible = false;
//             this.gvAll.HeaderRow.Cells[17].Visible = false;
//             this.gvAll.HeaderRow.Cells[18].Visible = false;
//             this.gvAll.HeaderRow.Cells[19].Visible = false;
//             this.gvAll.HeaderRow.Cells[20].Visible = false;
//             this.gvAll.HeaderRow.Cells[21].Visible = false;
//             this.gvAll.HeaderRow.Cells[22].Visible = false;
//             TextBox txt_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_inv_no");
//             TextBox txt_tx_inv_dt = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_tx_inv_dt");
//             TextBox txt_aai_chrges = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_aai_chrges");
//             TextBox txt_dmg_chrges = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_dmg_chrges");
//             TextBox txt_aai_cbm = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_aai_cbm");
//             TextBox txt_ooc_date = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_ooc_date");
//             TextBox txt_clr_dat = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_clr_dat");
//             TextBox txt_clr_name = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_clr_name");
//             TextBox txt_transport_name = (TextBox)gvAll.Rows[rowIndex].Cells[9].FindControl("txt_transport_name");
//             TextBox txt_vehi_type = (TextBox)gvAll.Rows[rowIndex].Cells[10].FindControl("txt_vehi_type");
//             TextBox txt_vehi_no = (TextBox)gvAll.Rows[rowIndex].Cells[11].FindControl("txt_vehi_no");
//             TextBox txt_Cfs_name = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Cfs_name");
//             TextBox txt_txn_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_txn_inv_no");
//             TextBox txt_inv_dt = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_inv_dt");
//             TextBox txt_txv_inv_amt = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_txv_inv_amt");
//             TextBox txt_strg = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_strg");
//             TextBox txt_ooc_dt = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_ooc_dt");
//             TextBox txt_clr_dt = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_clr_dt");
//             TextBox txt_cbm = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_cbm");
//             TextBox txt_Clear_name = (TextBox)gvAll.Rows[rowIndex].Cells[9].FindControl("txt_Clear_name");
//             TextBox txt_trans_name = (TextBox)gvAll.Rows[rowIndex].Cells[10].FindControl("txt_trans_name");
//             TextBox txt_veh_type = (TextBox)gvAll.Rows[rowIndex].Cells[11].FindControl("txt_veh_type");
//             TextBox txt_veh_no = (TextBox)gvAll.Rows[rowIndex].Cells[12].FindControl("txt_veh_no");
//             TextBox txt_Line_Name = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Line_Name");
//             TextBox txt_Console_Name = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_Console_Name");
//             TextBox txt_Console_chg = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txt_Console_chg");
//             TextBox txt_Line_Chg = (TextBox)gvAll.Rows[rowIndex].Cells[4].FindControl("txt_Line_Chg");
//             TextBox txt_do_free_days = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_do_free_days");
//             TextBox txt_port_Str_amt = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_port_Str_amt");
//             TextBox txt_port_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_port_revalidation");
//             TextBox txt_Detent_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_Detent_Amt");
//             TextBox txt_detention_revalidation = (TextBox)gvAll.Rows[rowIndex].Cells[9].FindControl("txt_detention_revalidation");
//             TextBox txt_dam_chg = (TextBox)gvAll.Rows[rowIndex].Cells[10].FindControl("txt_dam_chg");
//             TextBox txt_do_fee = (TextBox)gvAll.Rows[rowIndex].Cells[11].FindControl("txt_do_fee");
//             TextBox txt_tax_inv_no = (TextBox)gvAll.Rows[rowIndex].Cells[12].FindControl("txt_tax_inv_no");
//             TextBox txt_Tax_Inv_date = (TextBox)gvAll.Rows[rowIndex].Cells[13].FindControl("txt_Tax_Inv_date");
//             TextBox txt_tax_inv_amt = (TextBox)gvAll.Rows[rowIndex].Cells[14].FindControl("txt_tax_inv_amt");
//             TextBox txt_Hold_chq = (TextBox)gvAll.Rows[rowIndex].Cells[15].FindControl("txt_Hold_chq");
//             TextBox txt_Hold_chq_date = (TextBox)gvAll.Rows[rowIndex].Cells[16].FindControl("txt_Hold_chq_date");
//             TextBox txt_Hold_amt = (TextBox)gvAll.Rows[rowIndex].Cells[17].FindControl("txt_Hold_amt");
//             TextBox txt_UTR_No = (TextBox)gvAll.Rows[rowIndex].Cells[18].FindControl("txt_UTR_No");
//             TextBox txt_UTR_date = (TextBox)gvAll.Rows[rowIndex].Cells[19].FindControl("txt_UTR_date");
//             TextBox txt_UTR_Amt = (TextBox)gvAll.Rows[rowIndex].Cells[20].FindControl("txt_UTR_Amt");
//             TextBox txt_Hold_chq_return_date = (TextBox)gvAll.Rows[rowIndex].Cells[21].FindControl("txt_Hold_chq_return_date");
//             TextBox txt_hold_rec_date = (TextBox)gvAll.Rows[rowIndex].Cells[22].FindControl("txt_hold_rec_date");
//             txt_inv_no.Visible = true;
//             txt_tx_inv_dt.Visible = true;
//             txt_aai_chrges.Visible = true;
//             txt_dmg_chrges.Visible = true;
//             txt_aai_cbm.Visible = true;
//             txt_ooc_date.Visible = true;
//             txt_clr_dat.Visible = true;
//             txt_clr_name.Visible = true;
//             txt_transport_name.Visible = true;
//             txt_vehi_type.Visible = true;
//             txt_vehi_no.Visible = true;
//             txt_Cfs_name.Visible = false;
//             txt_txn_inv_no.Visible = false;
//             txt_inv_dt.Visible = false;
//             txt_txv_inv_amt.Visible = false;
//             txt_strg.Visible = false;
//             txt_ooc_dt.Visible = false;
//             txt_clr_dt.Visible = false;
//             txt_cbm.Visible = false;
//             txt_Clear_name.Visible = false;
//             txt_trans_name.Visible = false;
//             txt_veh_type.Visible = false;
//             txt_veh_no.Visible = false;
//             txt_Line_Name.Visible = false;
//             txt_Console_Name.Visible = false;
//             txt_Console_chg.Visible = false;
//             txt_Line_Chg.Visible = false;
//             txt_do_free_days.Visible = false;
//             txt_port_Str_amt.Visible = false;
//             txt_port_revalidation.Visible = false;
//             txt_Detent_Amt.Visible = false;
//             txt_detention_revalidation.Visible = false;
//             txt_dam_chg.Visible = false;
//             txt_do_fee.Visible = false;
//             txt_tax_inv_no.Visible = false;
//             txt_Tax_Inv_date.Visible = false;
//             txt_tax_inv_amt.Visible = false;
//             txt_Hold_chq.Visible = false;
//             txt_Hold_chq_date.Visible = false;
//             txt_Hold_amt.Visible = false;
//             txt_UTR_No.Visible = false;
//             txt_UTR_date.Visible = false;
//             txt_UTR_Amt.Visible = false;
//             txt_Hold_chq_return_date.Visible = false;
//             txt_hold_rec_date.Visible = false;
//             //if (dss.Tables[0].Rows.Count > 0)
//             //{
//             //    gvAll.HeaderRow.Cells[1].Text = "Trasporter name";


//             //}
//         }
//    }
}