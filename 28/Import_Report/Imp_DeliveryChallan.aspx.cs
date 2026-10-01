using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Imp_DeliveryChallan : ThemeClass
{
    UserBO ObjUBO = new UserBO();
    Despatch dispatch = new Despatch();
    Delivery_Challan DL_Challan = new Delivery_Challan();
    AppSession aps = new AppSession();
    DataTable dt_container = new DataTable();

    DataSet ds = new DataSet();
    public int i;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        ds.Clear();
        if (!IsPostBack)
        {
            btnrpt.Visible = false;
            if (Request.QueryString["Page"] == "New")
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                Load_JobNo();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    hdn_job_id.Value = Request.QueryString["Page"].ToString();
                    Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlJobNo.Enabled = false;
                    //txt_JobNo.Enabled = false;
                    btnrpt.Visible = true;
                }
            }           
        }
    }
    public void Load_JobNo()
    {
        try
        {
           ObjUBO.flag = "Load_Jobno";
           ds = DL_Challan.Imp_DeliveryChallan_Select(ObjUBO);
           if (ds.Tables[0].Rows.Count > 0)
           {
               ddlJobNo.DataSource = ds.Tables[0];
               ddlJobNo.DataTextField = "JOBNO";
               ddlJobNo.DataValueField = "JOBNO";
               ddlJobNo.DataBind();

               ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlJobNo.SelectedIndex = 0;
           }
           else
           {
               ddlJobNo.Items.Clear();
               ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlJobNo.SelectedIndex = 0;
           }

           if (ds.Tables[1].Rows.Count > 0)
           {
               string  Working_Period = Session["WorkingPeriod"].ToString();
               string a = Working_Period.Substring(9, 2);
               string b = Working_Period.Substring(23, 2);
               lbl_DCNo.Text = ds.Tables[1].Rows[0]["DC_NO"].ToString();

               if (ds.Tables[1].Rows[0]["DC_NO"].ToString().Length == 3)
               {
                   txt_DCNo.Text = "0" + ds.Tables[1].Rows[0]["DC_NO"].ToString() + "/" + a + "-" + b;
               }
               else if (ds.Tables[1].Rows[0]["DC_NO"].ToString().Length == 2)
               {
                   txt_DCNo.Text = "00" + ds.Tables[1].Rows[0]["DC_NO"].ToString() + "/" + a + "-" + b;
               }
               else if (ds.Tables[1].Rows[0]["DC_NO"].ToString().Length == 1)
               {
                   txt_DCNo.Text = "000" + ds.Tables[1].Rows[0]["DC_NO"].ToString() + "/" + a + "-" + b;
               }
               else
               {
                   txt_DCNo.Text = ds.Tables[1].Rows[0]["DC_NO"].ToString() + "/" + a + "-" + b;
               }
           }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = Insert_Update("U");
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Delivery Challan', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Delivery Challan', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedValue != string.Empty)
            {
                Clear();
                ObjUBO.flag = "Select_Importer_from_Jobno";
                ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
                ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
                ObjUBO.From_date = "";
                ObjUBO.Todate = "";

                ds = DL_Challan.Imp_DeliveryChallan_Select(ObjUBO);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    //txt_JobNo.Text = ddlJobNo.SelectedValue.ToString();
                    txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    txt_Imp_Add1.Text = ds.Tables[0].Rows[0]["ADDRESS1"].ToString();
                    txt_Imp_Add2.Text = ds.Tables[0].Rows[0]["ADDRESS2"].ToString();
                    txt_Imp_Add3.Text = ds.Tables[0].Rows[0]["ADDRESS3"].ToString();
                    txt_Imp_Add4.Text = ds.Tables[0].Rows[0]["ADDRESS4"].ToString() + " " + ds.Tables[0].Rows[0]["ADDRESS5"].ToString();
                    //txt_Trans_Name.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Trans_Add1.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Trans_Add2.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Trans_Add3.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Trans_Add4.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    txt_BENo.Text = ds.Tables[0].Rows[0]["BE_NO"].ToString();
                    txt_BEdate.Text = ds.Tables[0].Rows[0]["BE_DATE"].ToString();
                    //txt_Ass_Value.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Customs_Duty.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        dt_container = ds.Tables[1];
                        ViewState["dt_container"] = dt_container;
                        SetInitialRow();
                    }
                    else
                    {
                        DataTable dt_container = new DataTable();
                        dt_container.Columns.Add("CONTAINER_NO");
                        dt_container.Columns.Add("TYPE");

                        dt_container.Rows.Add("", "20");
                        dt_container.Rows.Add("", "40");
                        ViewState["dt_container"] = dt_container;
                        SetInitialRow();
                    }
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        txt_Ass_Value.Text = ds.Tables[2].Rows[0]["ASSESSABLE_VALUE"].ToString();
                        txt_Customs_Duty.Text = ds.Tables[2].Rows[0]["CUSTOMS_DUTY"].ToString();
                    }
                  
                   
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
            ObjUBO.JOBNO = Request.QueryString["Jobno"].ToString();
            ObjUBO.flag = "Updated_Jobno_Select";
            ds = DL_Challan.Imp_DeliveryChallan_Select(ObjUBO);

            if (ds.Tables[1].Rows.Count > 0)
            {
                //dt_cont = (DataTable)ViewState["dt_container"];
                ViewState["dt_container"] = ds.Tables[1];
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlJobNo.Items.Clear();
                HD_Update_id.Value = ds.Tables[0].Rows[0]["ID"].ToString();

                //ddlJobNo.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["FILE_REFNO"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
                //ddlJobNo.SelectedIndex = 0;

                ddlJobNo.Items.Insert(0,ds.Tables[0].Rows[0]["JOBNO"].ToString());
                //txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                txt_Date.Text = ds.Tables[0].Rows[0]["DC_DATE"].ToString();
                txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
               
                ddlJobNo.SelectedValue=ds.Tables[0].Rows[0]["JOBNO"].ToString();
                txt_Date.Text = ds.Tables[0].Rows[0]["DC_DATE"].ToString();
                txt_DCNo.Text = ds.Tables[0].Rows[0]["DC_NO_PS"].ToString();
                lbl_DCNo.Text = ds.Tables[0].Rows[0]["DC_NO"].ToString();
                txtImporterName.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                txt_Imp_Add1.Text = ds.Tables[0].Rows[0]["IMPORTER_ADD1"].ToString();
                txt_Imp_Add2.Text = ds.Tables[0].Rows[0]["IMPORTER_ADD2"].ToString();
                txt_Imp_Add3.Text = ds.Tables[0].Rows[0]["IMPORTER_ADD3"].ToString();
                txt_Imp_Add4.Text = ds.Tables[0].Rows[0]["IMPORTER_ADD4"].ToString();
                txt_Trans_Name.Text = ds.Tables[0].Rows[0]["TRANSPORTER_NAME"].ToString();
                txt_Trans_Add1.Text = ds.Tables[0].Rows[0]["TRANSPORTER_ADD1"].ToString();
                txt_Trans_Add2.Text = ds.Tables[0].Rows[0]["TRANSPORTER_ADD2"].ToString();
                txt_Trans_Add3.Text = ds.Tables[0].Rows[0]["TRANSPORTER_ADD3"].ToString();
                txt_Trans_Add4.Text = ds.Tables[0].Rows[0]["TRANSPORTER_ADD4"].ToString();
                txt_Vessel.Text = ds.Tables[0].Rows[0]["VESSEL"].ToString();

                if (ds.Tables[0].Rows[0]["BE_NO"].ToString().Contains("~"))
                {
                    string[] xx = ds.Tables[0].Rows[0]["BE_NO"].ToString().Split('~');
                    txt_BENo.Text = xx[0];
                    txt_BEdate.Text = xx[1];
                }
                else
                {
                    txt_BENo.Text = "";
                    txt_BEdate.Text = "";
                }
                txt_Ass_Value.Text = ds.Tables[0].Rows[0]["ASSESABLE_VALUE"].ToString();
                txt_Customs_Duty.Text = ds.Tables[0].Rows[0]["CUSTOMS_DUTY"].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0]["BILL_REMARKS"].ToString();

                DataTable dt_item = new DataTable();

                DataRow dr = null;

                dt_item.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt_item.Columns.Add(new DataColumn("DESCRIPTION", typeof(string)));
                dt_item.Columns.Add(new DataColumn("HSN_CODE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
                dt_item.Columns.Add(new DataColumn("SIZE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("TRUCKNO", typeof(string)));
                dt_item.Columns.Add(new DataColumn("REASON", typeof(string)));
                dt_item.Columns.Add(new DataColumn("GOODS_VALUE", typeof(string)));
                dt_item.Columns.Add(new DataColumn("TRANSPORTER", typeof(string)));

                if (ds.Tables[0].Rows[0]["DESCRIPTION"].ToString().Contains("~"))
                {
                    string[] desc = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString().Split('~');
                    string[] hsn = ds.Tables[0].Rows[0]["HSN_CODE"].ToString().Split('~');
                    string[] container = ds.Tables[0].Rows[0]["CONTAINER_NO"].ToString().Split('~');
                    string[] size = ds.Tables[0].Rows[0]["CONTAINER_SIZE"].ToString().Split('~');
                    string[] truckno = ds.Tables[0].Rows[0]["TRUCK_NO"].ToString().Split('~');
                    string[] reason = ds.Tables[0].Rows[0]["REASON"].ToString().Split('~');
                    string[] goods = ds.Tables[0].Rows[0]["GOODS_VALUE"].ToString().Split('~');
                    string[] transporter = ds.Tables[0].Rows[0]["TRANSPORTER"].ToString().Split('~');

                    for (int k = 0; k <= desc.Count() - 1; k++)
                    {
                        if (desc[k] != "")
                        {
                            dt_item.Rows.Add(k + 1, desc[k], hsn[k], container[k], size[k], truckno[k], reason[k], goods[k], transporter[k]);
                        }

                    }
                }
                else
                {
                    dt_item.Rows.Add("");
                }

                gvAll.DataSource = dt_item;
                gvAll.DataBind();

                ViewState["CurrentTable"] = dt_item;
                SetPreviousData();

                
                ViewState["UPDATED_ID"] = "U";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public int Insert_Update(string a1)
    {
        DL_Challan.DC_ID = HD_Update_id.Value;
        DL_Challan.JOBNO = ddlJobNo.SelectedItem.Text;
        DL_Challan.DATE = txt_Date.Text;
        //DL_Challan.FILE_REF_NO = txt_DCNo.Text;
        DL_Challan.FILE_REF_NO = lbl_DCNo.Text;
        DL_Challan.IMPORTER_NAME = txtImporterName.Text;
        DL_Challan.ADDRESS1 = txt_Imp_Add1.Text;
        DL_Challan.ADDRESS2 = txt_Imp_Add2.Text;
        DL_Challan.ADDRESS3 = txt_Imp_Add3.Text;
        DL_Challan.ADDRESS4 = txt_Imp_Add4.Text;
        DL_Challan.CHA_NAME = txt_Trans_Name.Text;
        DL_Challan.CHA_ADDRESS1 = txt_Trans_Add1.Text;
        DL_Challan.CHA_ADDRESS2 = txt_Trans_Add2.Text;
        DL_Challan.CHA_ADDRESS3 = txt_Trans_Add3.Text;
        DL_Challan.CHA_ADDRESS4 = txt_Trans_Add4.Text;
        DL_Challan.BE_NO_DATE = txt_BENo.Text + "~" + txt_BEdate.Text;
        DL_Challan.ASSESABLE_VALUE = txt_Ass_Value.Text;
        DL_Challan.CUSTOMS_DUTY = txt_Customs_Duty.Text;
        DL_Challan.VESSEL = txt_Vessel.Text;
        DL_Challan.DC_NO_PS = txt_DCNo.Text;

        foreach (GridViewRow row in gvAll.Rows)
        {
            TextBox txt_Desc = (TextBox)row.FindControl("txt_Desc");
            TextBox txt_HSN = (TextBox)row.FindControl("txt_HSN");
            DropDownList ddl_size = (DropDownList)row.FindControl("ddl_size");
            DropDownList ddl_ContainerNo = (DropDownList)row.FindControl("ddl_ContainerNo");
            TextBox txt_TruckNo = (TextBox)row.FindControl("txt_TruckNo");
            TextBox txt_Reason = (TextBox)row.FindControl("txt_Reason");
            TextBox txt_GoodsValue = (TextBox)row.FindControl("txt_GoodsValue");
            TextBox txt_Transporter = (TextBox)row.FindControl("txt_Transporter");

            if (txt_Desc.Text != "")
            {
                DL_Challan.DESC_GOODS += txt_Desc.Text + "~";
                DL_Challan.HSN_CODE += txt_HSN.Text + "~";
                DL_Challan.CONTAINER_NO += ddl_ContainerNo.SelectedValue + "~";
                DL_Challan.CONTAINER_SIZE += ddl_size.SelectedValue + "~";
                DL_Challan.TRUCK_NO += txt_TruckNo.Text + "~";
                DL_Challan.REASON += txt_Reason.Text + "~";
                DL_Challan.GOODS_VALUE += txt_GoodsValue.Text + "~";
                DL_Challan.TRANSPORTER += txt_Transporter.Text + "~";
            }
        }


        DL_Challan.BILL_REMARKS = txtRemarks.Text;


        DL_Challan.BRANCH_COMMON = Connection.Get_Company_Type();
        DL_Challan.flag = a1;
        DL_Challan.Delivery_Challan_Insert_Update();

        i = DL_Challan.result;
        return i;
    }

    public void Clear()
    {    

        txt_Date.Text = "";
        //txt_DCNo.Text= "";
        txtImporterName.Text= "";
        txt_Imp_Add1.Text= "";
        txt_Imp_Add2.Text= "";
        txt_Imp_Add3.Text= "";
        txt_Imp_Add4.Text= "";
        txt_Trans_Name.Text= "";
        txt_Trans_Add1.Text= "";
        txt_Trans_Add2.Text= "";
        txt_Trans_Add3.Text= "";
        txt_Trans_Add4.Text= "";
        txt_BENo.Text= "";
        txt_BEdate.Text= "";
        txt_Ass_Value.Text= "";
        txt_Customs_Duty.Text= "";

        txt_BENo.Text = "";
        txt_BEdate.Text = "";
        //txtdesc.Text = "";
        //txt_Imp_Add.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedItem.Text != string.Empty) 
            {
                Insert_Update("S");
                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    ViewState["UPDATED_ID"] = null;

                    Alert_msg("Saved Successfully", "btnSave");
                    HD_Update_id.Value = Convert.ToString(DL_Challan.UpdateId);
                    hdn_job_id.Value = Convert.ToString(DL_Challan.UpdateId);

                    btnUpdate.CssClass = "save";
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    //txt_JobNo.Attributes.Add("readonly", "readonly");
                    //txt_JobNo.Style.Add("background-color", "#F0F0F0");
                    ddlJobNo.Attributes.Add("readonly", "readonly");
                    ddlJobNo.Style.Add("background-color", "#F0F0F0");
                    ddlJobNo.Enabled = false;

                    btnrpt.Visible = true;
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
            ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
            ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
            ObjUBO.From_date = "";
            ObjUBO.Todate = "";

            ds = DL_Challan.Imp_DeliveryChallan_Select(ObjUBO);

            if(DL_Challan.result==1)
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Record Deleted', 'Delivery Challan', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
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
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        Clear();

        ddlJobNo.Enabled = true;

        ddlJobNo.Attributes.Remove("readonly");
        ddlJobNo.Style.Add("background-color", "White");

        Load_JobNo();
        btnrpt.Visible = false;
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
        if (e.Row.RowType == DataControlRowType.DataRow)
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
        }
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

        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("DESCRIPTION", typeof(string)));
        dt.Columns.Add(new DataColumn("HSN_CODE", typeof(string)));
        dt.Columns.Add(new DataColumn("CONTAINER_NO", typeof(string)));
        dt.Columns.Add(new DataColumn("SIZE", typeof(string)));
        dt.Columns.Add(new DataColumn("TRUCKNO", typeof(string)));
        dt.Columns.Add(new DataColumn("REASON", typeof(string)));
        dt.Columns.Add(new DataColumn("GOODS_VALUE", typeof(string)));
        dt.Columns.Add(new DataColumn("TRANSPORTER", typeof(string)));
      

        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["DESCRIPTION"] = "";
        dr["HSN_CODE"] = "";
        dr["CONTAINER_NO"] = "";
        dr["SIZE"] = "20";
        dr["TRUCKNO"] = "";
        dr["REASON"] = "";
        dr["GOODS_VALUE"] = string.Empty;
        dr["TRANSPORTER"] = "";
       
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
                    //TextBox txtContainerNo = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtContainerNo");
                    //DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[2].FindControl("ddl_size");
                    //DropDownList ddl_Type = (DropDownList)gvAll.Rows[rowIndex].Cells[3].FindControl("ddl_Type");

                    TextBox txt_Desc = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Desc");
                    TextBox txt_HSN = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_HSN");
                    DropDownList ddl_ContainerNo = (DropDownList)gvAll.Rows[rowIndex].Cells[3].FindControl("ddl_ContainerNo");
                    DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[4].FindControl("ddl_size");
                    TextBox txt_TruckNo = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_TruckNo");
                    TextBox txt_Reason = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_Reason");
                    TextBox txt_GoodsValue = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_GoodsValue");
                    TextBox txt_Transporter = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_Transporter");

                    gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                    if (dt.Rows[i][1].ToString() != "")
                    {
                        //txtContainerNo.Text = dt.Rows[i][1].ToString();
                        txt_Desc.Text = dt.Rows[i][1].ToString();
                        txt_HSN.Text = dt.Rows[i][2].ToString();
                        ddl_ContainerNo.SelectedValue = dt.Rows[i][3].ToString();
                        ddl_size.SelectedValue = dt.Rows[i][4].ToString();
                        txt_TruckNo.Text = dt.Rows[i][5].ToString();
                        txt_Reason.Text = dt.Rows[i][6].ToString();
                        txt_GoodsValue.Text = dt.Rows[i][7].ToString();
                        txt_Transporter.Text = dt.Rows[i][8].ToString();

                        DataTable dt_cont = new DataTable();
                        dt_cont = (DataTable)ViewState["dt_container"];

                        if (dt_cont != null)
                        {
                            ddl_ContainerNo.DataSource = dt_cont;
                            ddl_ContainerNo.DataTextField = "CONTAINER_NO";
                            ddl_ContainerNo.DataValueField = "CONTAINER_NO";
                            ddl_ContainerNo.DataBind();

                            if (dt_cont.Rows[i]["TYPE"].ToString() != "")
                            {
                                ddl_size.DataSource = dt_cont;
                                ddl_size.DataTextField = "TYPE";
                                ddl_size.DataValueField = "TYPE";
                                ddl_size.DataBind();
                            }
                            else
                            {
                                //ddl_size.Items.Remove(dt.Rows[i][4].ToString());
                                //ddl_size.Items.Insert(0, dt.Rows[i][4].ToString());
                            }

                            ddl_ContainerNo.Items.Remove(dt.Rows[i][3].ToString());
                            ddl_ContainerNo.Items.Insert(0, dt.Rows[i][3].ToString());

                            ddl_size.Items.Remove(dt.Rows[i][4].ToString());
                            ddl_size.Items.Insert(0, dt.Rows[i][4].ToString());
                        }
                        else
                        {

                                //ddl_size.Items.Insert(0, "");
                                ddl_size.Items.Insert(0, "20");
                                ddl_size.Items.Insert(1, "40");

                                DataView view = new DataView(dt_container);
                                DataTable distinctValues = view.ToTable(true, "TYPE");


                                //ddl_size.Items.Remove(dt.Rows[i][4].ToString());
                                //ddl_size.Items.Insert(0, dt.Rows[i][4].ToString());

                                ddl_size.DataSource = distinctValues;
                                ddl_size.DataTextField = "TYPE";
                                ddl_size.DataValueField = "TYPE";
                                ddl_size.DataBind();
                        }

                        //txtContainerNo.Text = dt.Rows[i][4].ToString();
                        //ddl_size.SelectedValue = dt.Rows[i][5].ToString();
                        //ddl_Type.SelectedValue = dt.Rows[i][6].ToString();

                        rowIndex++;
                    }
                    else
                    {
                        //ddl_ContainerNo.SelectedValue = "";
                        //ddl_size.SelectedValue = "20";
                        txt_Desc.Text = "";
                        txt_HSN.Text = "";
                        txt_TruckNo.Text = "";
                        txt_Reason.Text = "";
                        txt_GoodsValue.Text = "";
                        txt_Transporter.Text = "";

                        DataTable dt_cont = new DataTable();
                        dt_cont = (DataTable)ViewState["dt_container"];
                        ddl_ContainerNo.DataSource = dt_cont;
                        ddl_ContainerNo.DataTextField = "CONTAINER_NO";
                        ddl_ContainerNo.DataValueField = "CONTAINER_NO";
                        ddl_ContainerNo.DataBind();

                        ddl_size.DataSource = dt_cont;
                        ddl_size.DataTextField = "TYPE";
                        ddl_size.DataValueField = "TYPE";
                        ddl_size.DataBind();
                      
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
                    //extract the TextBox values
                    //TextBox txtContainerNo = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txtContainerNo");
                    //DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[2].FindControl("ddl_size");
                    //DropDownList ddl_Type = (DropDownList)gvAll.Rows[rowIndex].Cells[3].FindControl("ddl_Type");


                    TextBox txt_Desc = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Desc");
                    TextBox txt_HSN = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_HSN");
                    DropDownList ddl_ContainerNo = (DropDownList)gvAll.Rows[rowIndex].Cells[3].FindControl("ddl_ContainerNo");
                    DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[4].FindControl("ddl_size");
                    TextBox txt_TruckNo = (TextBox)gvAll.Rows[rowIndex].Cells[5].FindControl("txt_TruckNo");
                    TextBox txt_Reason = (TextBox)gvAll.Rows[rowIndex].Cells[6].FindControl("txt_Reason");
                    TextBox txt_GoodsValue = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txt_GoodsValue");
                    TextBox txt_Transporter = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_Transporter");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    //dtCurrentTable.Rows[i - 1]["CONTAINER_NO"] = txtContainerNo.Text;
                    //dtCurrentTable.Rows[i - 1]["SIZE"] = ddl_size.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["TYPE"] = ddl_Type.SelectedValue;

                    dtCurrentTable.Rows[i - 1]["DESCRIPTION"] = txt_Desc.Text;
                    dtCurrentTable.Rows[i - 1]["HSN_CODE"] = txt_HSN.Text;
                    dtCurrentTable.Rows[i - 1]["CONTAINER_NO"] = ddl_ContainerNo.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["SIZE"] = ddl_size.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["TRUCKNO"] = txt_TruckNo.Text;
                    dtCurrentTable.Rows[i - 1]["REASON"] = txt_Reason.Text;
                    dtCurrentTable.Rows[i - 1]["GOODS_VALUE"] = txt_GoodsValue.Text;
                    dtCurrentTable.Rows[i - 1]["TRANSPORTER"] = txt_Transporter.Text;

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
                    //extract the TextBox values
                    TextBox txt_Desc = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Desc");
                    TextBox txt_HSN = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_HSN");
                    DropDownList ddl_ContainerNo = (DropDownList)gvAll.Rows[rowIndex].Cells[2].FindControl("ddl_ContainerNo");
                    DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[3].FindControl("ddl_size");
                    TextBox txt_TruckNo = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_TruckNo");
                    TextBox txt_Reason = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Reason");
                    TextBox txt_GoodsValue = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_GoodsValue");
                    TextBox txt_Transporter = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Transporter");


                    if (txt_Desc.Text == string.Empty)
                    {
                        Emptyrow = "Y";
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    dtCurrentTable.Rows[i - 1]["DESCRIPTION"] = txt_Desc.Text;
                    dtCurrentTable.Rows[i - 1]["HSN_CODE"] = txt_HSN.Text;
                    dtCurrentTable.Rows[i - 1]["CONTAINER_NO"] = ddl_ContainerNo.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["SIZE"] = ddl_size.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["TRUCKNO"] = txt_TruckNo.Text;
                    dtCurrentTable.Rows[i - 1]["REASON"] = txt_Reason.Text;
                    dtCurrentTable.Rows[i - 1]["GOODS_VALUE"] = txt_GoodsValue.Text;
                    dtCurrentTable.Rows[i - 1]["TRANSPORTER"] = txt_Transporter.Text;

                    //DataTable dt_cont = new DataTable();
                    //dt_cont = (DataTable)ViewState["dt_container"];

                    //ddl_ContainerNo.DataSource = dt_cont;
                    //ddl_ContainerNo.DataTextField = "CONTAINER_NO";
                    //ddl_ContainerNo.DataValueField = "CONTAINER_NO";
                    //ddl_ContainerNo.DataBind();

                    //ddl_size.DataSource = dt_cont;
                    //ddl_size.DataTextField = "TYPE";
                    //ddl_size.DataValueField = "TYPE";
                    //ddl_size.DataBind();
                   
                    rowIndex++;
                }

                if (Emptyrow != "Y")
                {
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                 

                    DropDownList ddl_ContainerNo = (DropDownList)gvAll.Rows[rowIndex-1].Cells[2].FindControl("ddl_ContainerNo");
                    DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex-1].Cells[3].FindControl("ddl_size");

                    DataTable dt_cont = new DataTable();
                    dt_cont = (DataTable)ViewState["dt_container"];

                    //dtCurrentTable.Rows[rowIndex - 1]["CONTAINER_NO"] = dt_cont.Columns[0];

                    ddl_ContainerNo.DataSource = dt_cont;
                    ddl_ContainerNo.DataTextField = "CONTAINER_NO";
                    ddl_ContainerNo.DataValueField = "CONTAINER_NO";
                    ddl_ContainerNo.DataBind();

                    ddl_size.DataSource = dt_cont;
                    ddl_size.DataTextField = "TYPE";
                    ddl_size.DataValueField = "TYPE";
                    ddl_size.DataBind();

                    //dtCurrentTable.Rows[rowIndex - 1]["CONTAINER_NO"] = ddl_ContainerNo.SelectedValue;
                    //dtCurrentTable.Rows[rowIndex - 1]["SIZE"] = ddl_size.SelectedValue;

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
}
 