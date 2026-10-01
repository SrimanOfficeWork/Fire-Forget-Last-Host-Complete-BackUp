using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Exp_Voucher : ThemeClass
{
    UserBO ObjUBO = new UserBO();
    Despatch dispatch = new Despatch();
    Voucher_creation VC = new  Voucher_creation();
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
            //btnrpt.Visible = false;
            
            if (Request.QueryString["Page"] == "New")
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                Load_Importer_name();
                SetInitialRow();
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
        }
    }
    public void Load_Importer_name()
    {
        try
        {
            ObjUBO.flag = "Load_Exporter_Name";
           ds = VC.Voucher_Creation_Select(ObjUBO);
           if (ds.Tables[0].Rows.Count > 0)
           {
               ddlCustomer_name.DataSource = ds.Tables[0];
               ddlCustomer_name.DataTextField = "EXPORTER_NAME";
               ddlCustomer_name.DataValueField = "EXPORTER_NAME";
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
                ObjUBO.Exp_Name = ddlCustomer_name.SelectedValue.ToString();
               // ObjUBO.JOBNO = "";
                ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
                ObjUBO.From_date = "";
                ObjUBO.Todate = "";

                ds = VC.Voucher_Creation_Select(ObjUBO);


                if (ds.Tables[0].Rows.Count > 0)
                {
                    //txt_JobNo.Text = ddlJobNo.SelectedValue.ToString();
                    dt_container = ds.Tables[0];
                    ViewState["dt_container"] = dt_container;
                    SetInitialRow();
                    //txt_Trans_Name.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Trans_Add1.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Trans_Add2.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Trans_Add3.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Trans_Add4.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Ass_Value.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();
                    //txt_Customs_Duty.Text = ds.Tables[0].Rows[0]["IMPORTER_NAME"].ToString();

                   /* if (ds.Tables[1].Rows.Count > 0)
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
                    }*/


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
            ds = VC.Voucher_Creation_Select(ObjUBO);

            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    //dt_cont = (DataTable)ViewState["dt_container"];
            //    ViewState["dt_container"] = ds.Tables[0];
            //}

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCustomer_name.Items.Clear();
                HD_Update_id.Value = ds.Tables[0].Rows[0]["Voucher_id"].ToString();

                //ddlCustomer_name.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["FILE_REFNO"].ToString(), ds.Tables[0].Rows[0]["JOBNO"].ToString()));
                //ddlCustomer_name.SelectedIndex = 0;

                ddlCustomer_name.Items.Insert(0, ds.Tables[0].Rows[0]["Customer_Name"].ToString());
               // txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                txt_Date.Text = ds.Tables[0].Rows[0]["Voucher_Date"].ToString();
                txt_department.Text = ds.Tables[0].Rows[0]["Department"].ToString();
            

                DataTable dt_item = new DataTable();

                DataRow dr = null;

                dt_item.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt_item.Columns.Add(new DataColumn("Jobno", typeof(string)));
                dt_item.Columns.Add(new DataColumn("Particular", typeof(string)));
                dt_item.Columns.Add(new DataColumn("Amount", typeof(string)));
                dt_item.Columns.Add(new DataColumn("Total", typeof(string)));
                //dt_item.Columns.Add(new DataColumn("TRUCKNO", typeof(string)));
                //dt_item.Columns.Add(new DataColumn("REASON", typeof(string)));
                //dt_item.Columns.Add(new DataColumn("GOODS_VALUE", typeof(string)));
                //dt_item.Columns.Add(new DataColumn("TRANSPORTER", typeof(string)));

                if (ds.Tables[0].Rows[0]["Job_no"].ToString().Contains('~'))
                {
                    string[] Job_no = ds.Tables[0].Rows[0]["Job_no"].ToString().Split('~');
                   
                    string[] Particular = ds.Tables[0].Rows[0]["Particular"].ToString().Split('~');
                    string[] Amount = ds.Tables[0].Rows[0]["Amount"].ToString().Split('~');
                    string[] Total = ds.Tables[0].Rows[0]["Total"].ToString().Split('~');
                    //string[] truckno = ds.Tables[0].Rows[0]["TRUCK_NO"].ToString().Split('~');
                    //string[] reason = ds.Tables[0].Rows[0]["REASON"].ToString().Split('~');
                    //string[] goods = ds.Tables[0].Rows[0]["GOODS_VALUE"].ToString().Split('~');
                    //string[] transporter = ds.Tables[0].Rows[0]["TRANSPORTER"].ToString().Split('~');

                    for (int k = 0; k <= Job_no.Count() - 1; k++)
                    {
                        if (Job_no[k] != "")
                        {
                            dt_item.Rows.Add(k + 1, Job_no[k], Particular[k], Amount[k], Total[k]);
                        }

                    }
                }
                else
                {
                    dt_item.Rows.Add("");
                }
                Rd_incurred.SelectedValue = ds.Tables[0].Rows[0]["Incurred"].ToString();
                Rd_Ceritified.SelectedValue=ds.Tables[0].Rows[0]["Certified"].ToString();
                Rd_Approved.SelectedValue =ds.Tables[0].Rows[0]["Approved"].ToString();
                Rd_Verified.SelectedValue = ds.Tables[0].Rows[0]["Verified"].ToString();

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
         VC.Voucher_id = HD_Update_id.Value;
         VC.Customer_Name = ddlCustomer_name.SelectedItem.Text;
         VC.Department = txt_department.Text;
         VC.Voucher_Date = txt_Date.Text;
         
       //  DL_Challan.VESSEL = txt_Vessel.Text;
         //DL_Challan.DC_NO_PS = txt_DCNo.Text;

         foreach (GridViewRow row in gvAll.Rows)
         {
             //TextBox txt_Desc = (TextBox)row.FindControl("txt_Desc");
             //TextBox txt_HSN = (TextBox)row.FindControl("txt_HSN");
             //DropDownList ddl_size = (DropDownList)row.FindControl("ddl_size");
             DropDownList ddl_JobNo = (DropDownList)row.FindControl("ddl_JobNo");
             TextBox txt_part = (TextBox)row.FindControl("txt_part");
             TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
             //TextBox txtTotal = (TextBox)FooterRow.FindControl("txtTotal");
             //gv_Details.FooterRow.FindControl("txtgrandtot") as TextBox;
             TextBox txtTotal = gvAll.FooterRow.FindControl("txtTotal") as TextBox;

             if (ddl_JobNo.SelectedValue.ToString() != "")
             {
                 VC.Job_no += ddl_JobNo.SelectedValue ;
                 VC.Particular += txt_part.Text ;
                 VC.Amount += txtAmount.Text;
                 VC.Total += txtTotal.Text;
             }
         }

         VC.Incurred = Rd_incurred.SelectedValue.ToString();
         VC.Certified = Rd_Ceritified.SelectedValue.ToString();
         VC.Approved = Rd_Approved.SelectedValue.ToString();
         VC.Verified = Rd_Verified.SelectedValue.ToString();

         VC.BRANCH_COMMON = Connection.Get_Company_Type();
         VC.flag = a1;
         VC.Voucher_Creation_insertupdate();

         i = VC.result;
         return i;
     }

    public void Clear()
    {
        txt_department.Text = "";
        txt_Date.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCustomer_name.SelectedItem.Text != string.Empty) 
            {
                Insert_Update("S");
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

                    //txt_JobNo.Attributes.Add("readonly", "readonly");
                    //txt_JobNo.Style.Add("background-color", "#F0F0F0");
                    //ddlCustomer_name.Attributes.Add("readonly", "readonly");
                    //ddlCustomer_name.Style.Add("background-color", "#F0F0F0");
                    //ddlCustomer_name.Enabled = false;

                    //btnrpt.Visible = true;
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
            //ObjUBO.JOBNO = ddl_JobNo.SelectedValue.ToString();
            ObjUBO.BRANCH_COMMON = Connection.Get_Company_Type();
            ObjUBO.From_date = "";
            ObjUBO.Todate = "";

            ds = VC.Voucher_Creation_Select(ObjUBO);

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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("ddl_JobNo");

            DropDownList1.DataSource = dt_container;
            DropDownList1.DataTextField = "JOBNO";
            DropDownList1.DataValueField = "JOBNO";
            DropDownList1.DataBind();

            //DropDownList DropDownList2 = (DropDownList)e.Row.FindControl("ddl_size");

          /*  if (dt_container.Rows.Count > 0)
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
            }*/
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
        dt.Columns.Add(new DataColumn("Jobno", typeof(string)));
        dt.Columns.Add(new DataColumn("Particular", typeof(string)));
        dt.Columns.Add(new DataColumn("Amount", typeof(string)));
        dt.Columns.Add(new DataColumn("Total", typeof(string)));
        //dt.Columns.Add(new DataColumn("REASON", typeof(string)));
        //dt.Columns.Add(new DataColumn("GOODS_VALUE", typeof(string)));
        //dt.Columns.Add(new DataColumn("TRANSPORTER", typeof(string)));
      

        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Jobno"] = "";
        dr["Particular"] = "";
        dr["Amount"] = "";
        dr["Total"] = "";
        //dr["TRUCKNO"] = "";
        //dr["REASON"] = "";
        //dr["GOODS_VALUE"] = string.Empty;
        //dr["TRANSPORTER"] = "";
       
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

                    //TextBox txt_Desc = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Desc");
                    //TextBox txt_HSN = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_HSN");
                    DropDownList ddl_JobNo = (DropDownList)gvAll.Rows[rowIndex].Cells[1].FindControl("ddl_JobNo");
                   // DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[4].FindControl("ddl_size");
                    TextBox txt_part = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_part");
                    TextBox txtAmount = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txtAmount");
                    //TextBox txtTotal = (TextBox)gvAll.Rows[rowIndex].Cells[7].FindControl("txtTotal");
                    //TextBox txt_Transporter = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_Transporter");

                    gvAll.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                    if (dt.Rows[i][1].ToString() != "")
                    {
                        //txtContainerNo.Text = dt.Rows[i][1].ToString();
                        //txt_Desc.Text = dt.Rows[i][1].ToString();
                        //txt_HSN.Text = dt.Rows[i][2].ToString();
                        ddl_JobNo.SelectedValue = dt.Rows[i][1].ToString();
                        //ddl_size.SelectedValue = dt.Rows[i][4].ToString();
                        txt_part.Text = dt.Rows[i][2].ToString();
                        txtAmount.Text = dt.Rows[i][3].ToString();
                        //txtTotal.Text = dt.Rows[i][7].ToString();
                        //txt_Transporter.Text = dt.Rows[i][8].ToString();

                        DataTable dt_cont = new DataTable();
                        dt_cont = (DataTable)ViewState["dt_container"];

                        if (dt_cont != null)
                        {
                            ddl_JobNo.DataSource = dt_cont;
                            ddl_JobNo.DataTextField = "JOBNO";
                            ddl_JobNo.DataValueField = "JOBNO";
                            ddl_JobNo.DataBind();

                            //if (dt_cont.Rows[i]["TYPE"].ToString() != "")
                            //{
                            //    ddl_size.DataSource = dt_cont;
                            //    ddl_size.DataTextField = "TYPE";
                            //    ddl_size.DataValueField = "TYPE";
                            //    ddl_size.DataBind();
                            //}
                            //else
                            //{
                            //    //ddl_size.Items.Remove(dt.Rows[i][4].ToString());
                            //    //ddl_size.Items.Insert(0, dt.Rows[i][4].ToString());
                            //}

                            ddl_JobNo.Items.Remove(dt.Rows[i][1].ToString());
                            ddl_JobNo.Items.Insert(0, dt.Rows[i][1].ToString());

                            //ddl_size.Items.Remove(dt.Rows[i][4].ToString());
                            //ddl_size.Items.Insert(0, dt.Rows[i][4].ToString());
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
                        txt_part.Text = "";
                        txtAmount.Text = "";
                        //txt_TruckNo.Text = "";
                        //txt_Reason.Text = "";
                        //txt_GoodsValue.Text = "";
                        //txt_Transporter.Text = "";

                        DataTable dt_cont = new DataTable();
                        dt_cont = (DataTable)ViewState["dt_container"];
                        ddl_JobNo.DataSource = dt_cont;
                        ddl_JobNo.DataTextField = "JOBNO";
                        ddl_JobNo.DataValueField = "JOBNO";
                        ddl_JobNo.DataBind();

                        //ddl_size.DataSource = dt_cont;
                        //ddl_size.DataTextField = "TYPE";
                        //ddl_size.DataValueField = "TYPE";
                        //ddl_size.DataBind();
                      
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


                    //TextBox txt_Desc = (TextBox)gvAll.Rows[rowIndex].Cells[1].FindControl("txt_Desc");
                    //TextBox txt_HSN = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_HSN");
                    DropDownList ddl_JobNo = (DropDownList)gvAll.Rows[rowIndex].Cells[1].FindControl("ddl_JobNo");
                   // DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[4].FindControl("ddl_size");
                    TextBox txt_part = (TextBox)gvAll.Rows[rowIndex].Cells[2].FindControl("txt_part");
                    TextBox txtAmount = (TextBox)gvAll.Rows[rowIndex].Cells[3].FindControl("txtAmount");
                    TextBox txtTotal = gvAll.FooterRow.FindControl("txtTotal") as TextBox; 
                    //TextBox txt_Transporter = (TextBox)gvAll.Rows[rowIndex].Cells[8].FindControl("txt_Transporter");

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;

                    //dtCurrentTable.Rows[i - 1]["CONTAINER_NO"] = txtContainerNo.Text;
                    //dtCurrentTable.Rows[i - 1]["SIZE"] = ddl_size.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["TYPE"] = ddl_Type.SelectedValue;

                    //dtCurrentTable.Rows[i - 1]["DESCRIPTION"] = txt_Desc.Text;
                    //dtCurrentTable.Rows[i - 1]["HSN_CODE"] = txt_HSN.Text;
                    dtCurrentTable.Rows[i - 1]["JOBNO"] = ddl_JobNo.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["SIZE"] = ddl_size.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Particular"] = txt_part.Text;
                    dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;
                    dtCurrentTable.Rows[i - 1]["Total"] = txtTotal.Text;
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
                    //TextBox txt_Desc = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Desc");
                    //TextBox txt_HSN = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_HSN");
                    DropDownList ddl_JobNo = (DropDownList)gvAll.Rows[rowIndex].Cells[0].FindControl("ddl_JobNo");
                   // DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex].Cells[3].FindControl("ddl_size");
                    TextBox txt_part = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_part");
                    TextBox txtAmount = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txtAmount");
                    //TextBox txt_GoodsValue = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_GoodsValue");
                    //TextBox txt_Transporter = (TextBox)gvAll.Rows[rowIndex].Cells[0].FindControl("txt_Transporter");


                    if (txt_part.Text == string.Empty)
                    {
                        Emptyrow = "Y";
                    }

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;
                    dtCurrentTable.Rows[i - 1]["Jobno"] = ddl_JobNo.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Particular"] = txt_part.Text;
                    dtCurrentTable.Rows[i - 1]["Amount"] = txtAmount.Text;
                    //dtCurrentTable.Rows[i - 1]["SIZE"] = ddl_size.SelectedValue;
                    //dtCurrentTable.Rows[i - 1]["TRUCKNO"] = txt_TruckNo.Text;
                    //dtCurrentTable.Rows[i - 1]["REASON"] = txt_Reason.Text;
                    //dtCurrentTable.Rows[i - 1]["GOODS_VALUE"] = txt_GoodsValue.Text;
                    //dtCurrentTable.Rows[i - 1]["TRANSPORTER"] = txt_Transporter.Text;

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



                    DropDownList ddl_JobNo = (DropDownList)gvAll.Rows[rowIndex - 1].Cells[2].FindControl("ddl_JobNo");
                   // DropDownList ddl_size = (DropDownList)gvAll.Rows[rowIndex-1].Cells[3].FindControl("ddl_size");

                    DataTable dt_cont = new DataTable();
                    dt_cont = (DataTable)ViewState["dt_container"];

                    //dtCurrentTable.Rows[rowIndex - 1]["CONTAINER_NO"] = dt_cont.Columns[0];

                    ddl_JobNo.DataSource = dt_cont;
                    ddl_JobNo.DataTextField = "JOBNO";
                    ddl_JobNo.DataValueField = "JOBNO";
                    ddl_JobNo.DataBind();

                    //ddl_size.DataSource = dt_cont;
                    //ddl_size.DataTextField = "TYPE";
                    //ddl_size.DataValueField = "TYPE";
                    //ddl_size.DataBind();

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
 