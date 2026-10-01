using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Acc_Journal_Entry_Details : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Acc_Journal_Entry_cs JE = new Acc_Journal_Entry_cs();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    private string jvNo = "", JL_ID;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            if (!IsPostBack)
            {
                CreateGrid();
                LoadTaxPercentage();
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                ViewState["IMP_EXP"] = ddlImp_Exp.SelectedValue;

                txt_JV_No_F.Text = Request.QueryString["JV_F"];
                txt_JV_No_M.Text = Request.QueryString["JV_M"];
                txt_JV_No_L.Text = Request.QueryString["JV_L"];

                if (Request.QueryString["JL_ID"] != null && Request.QueryString["JL_ID"] != string.Empty)
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    LoadJournalEntryDetailsForUpdate();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    private void LoadJournalEntryDetailsForUpdate()
    {
        DataSet ds = new DataSet();
        ObjUBO.A1 = Convert.ToString(Request.QueryString["JL_ID"]);
        ObjUBO.A40 = "CP_Upd_AccLine_Details";
        ds = JE.JV_DetailsPage_GetData(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string impExp = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
            string chargeCode = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();

            //ObjUBO.A4 = (impExp == "CI") ? "CI" : "CE";
            ObjUBO.A4 = impExp;
            ObjUBO.A40 = "JV_ChargeNumber_Select";
            DataSet dsMaster = JE.JV_Header_Select(ObjUBO);

            if (dsMaster != null && dsMaster.Tables.Count > 0 && dsMaster.Tables[0].Rows.Count > 0)
            {
                ViewState["ChargeMaster"] = dsMaster.Tables[0];
                //ViewState["ImpExp"] = (impExp == "CI") ? "I" : "E";
                ViewState["ImpExp"] = impExp;

                ddl_Charge_GL.DataSource = dsMaster.Tables[0];
                ddl_Charge_GL.DataTextField = "CHARGE_NAME";
                ddl_Charge_GL.DataValueField = "CHARGE_CODE";
                ddl_Charge_GL.DataBind();
                ddl_Charge_GL.Items.Insert(0, new ListItem("Select", ""));
            }
            HDupdate_id.Value = ds.Tables[0].Rows[0]["JL_ID"].ToString();
            txt_JV_No_F.Text = ds.Tables[0].Rows[0]["JV_P"].ToString();
            txt_JV_No_M.Text = ds.Tables[0].Rows[0]["JV_NO"].ToString();
            txt_JV_No_L.Text = ds.Tables[0].Rows[0]["JV_S"].ToString();

            ddlImp_Exp.SelectedValue = impExp;
            ddl_Charge_GL.SelectedValue = chargeCode;
            txt_GL_Amount.Text = ds.Tables[0].Rows[0]["AMOUNT"].ToString();

            string debit = ds.Tables[0].Rows[0]["DEBIT"].ToString();
            ddl_Cr_Dr.SelectedValue = (debit != "" && debit != "0" && debit != "0.00") ? "D" : "C";

            ddl_linked_GL.SelectedValue = ds.Tables[0].Rows[0]["LINKED_GL"].ToString();
            ddl_Cost_Center.SelectedValue = ds.Tables[0].Rows[0]["COSTCENTER"].ToString();
            ddl_branch.SelectedValue = ds.Tables[0].Rows[0]["BRANCH"].ToString();

            ddl_tax.SelectedValue = ds.Tables[0].Rows[0]["TAX_NONTAX"].ToString();
            LoadTaxPercentage();
            ddl_tax_type.SelectedValue = ds.Tables[0].Rows[0]["TAX_AMT_PERCENT"].ToString();
            txtNarration.Text = ds.Tables[0].Rows[0]["NARRATION"].ToString();
            DataTable dtMaster = ViewState["ChargeMaster"] as DataTable;
            if (dtMaster != null && impExp != "GL")
            {
                ddl_linked_GL.Items.Clear();
                ddl_linked_GL.Items.Insert(0, new ListItem("Select", ""));

                ddl_Cost_Center.Items.Clear();
                ddl_Cost_Center.Items.Add(new ListItem("Select", ""));
                ddl_Cost_Center.Items.Add(new ListItem("Export", "E"));
                ddl_Cost_Center.Items.Add(new ListItem("Import", "I"));

                string incomeCol = (ViewState["ImpExp"].ToString() == "CI") ? "CCI_EXPENSE" : "CCE_EXPENSE";
                DataRow[] dr = dtMaster.Select("CHARGE_CODE='" + chargeCode + "'");
                if (dr.Length > 0)
                {
                    ddl_linked_GL.Items.Add(new ListItem(dr[0][incomeCol].ToString(), dr[0][incomeCol].ToString()));
                    ddl_linked_GL.SelectedIndex = 1;
                    ddl_linked_GL.Enabled = false;
                }
                string savedLinkedGL = ds.Tables[0].Rows[0]["LINKED_GL"].ToString();
                if (ddl_linked_GL.Items.FindByValue(savedLinkedGL) != null)
                    ddl_linked_GL.SelectedValue = savedLinkedGL;

                //ddl_Cost_Center.SelectedValue = (ViewState["ImpExp"].ToString() == "I") ? "I" : "E";
                ddl_Cost_Center.SelectedValue = (ViewState["ImpExp"].ToString());
                ddl_Cost_Center.Enabled = false;
            }

            if (impExp == "GL")
            {
                ddl_linked_GL.Items.Clear();
                ddl_linked_GL.Items.Insert(0, new ListItem("Select", ""));
                string savedLinkedGL = ds.Tables[0].Rows[0]["LINKED_GL"].ToString();
                if (savedLinkedGL == "N")
                    ddl_linked_GL.SelectedIndex = 0;
                ddl_linked_GL.Enabled = false;

                ddl_Cost_Center.Items.Clear();
                ddl_Cost_Center.Items.Insert(0, new ListItem("Select", ""));

                string savedCostCenter = ds.Tables[0].Rows[0]["COSTCENTER"].ToString();
                if (savedCostCenter == "N")
                    ddl_Cost_Center.SelectedIndex = 0;
                ddl_Cost_Center.Enabled = false;
            }
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            //DataTable dtGrid = CreateGridStructure();
            //foreach (DataRow r in ds.Tables[1].Rows)
            //{
            //    DataRow dr = dtGrid.NewRow();
            //    dr["CHARGE_GL"] = r["CHARGE_GL"];
            //    dr["JOB_NO"] = r["JOB_NO"];
            //    dr["ESTIMATED"] = r["ESTIMATED_AMOUNT"];
            //    dr["INVOICE_AMOUNT"] = r["INVOICE_AMOUNT"];
            //    dr["AMOUNT"] = r["AMOUNT"];
            //    dr["DR_CR"] = r["DR_CR"];
            //    dr["APPORTION_METHOD"] = r["APPORTION_METHOD"];
            //    dr["COST_CENTER"] = r["COST_CENTER"];
            //    dtGrid.Rows.Add(dr);
            //}
            //ViewState["GridData"] = dtGrid;
            //gv_details.DataSource = dtGrid;
            
            ViewState["GridData"] = ds.Tables[1];
            gv_details.DataSource = ds.Tables[1];           
            gv_details.DataBind();            
            ApplyHeaderValuesToGrid();
        }
    }

    // load charge Names values function 
    protected void ddlImp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState.Remove("JobTable_Ch");
        DataSet ds = new DataSet();
        ddl_Charge_GL.Items.Clear();
        ddl_linked_GL.Items.Clear();
        ddl_Cost_Center.Items.Clear();

        //ObjUBO.A4 = (ddlImp_Exp.SelectedValue == "CI") ? "I" : "E";
        ObjUBO.A4 = ddlImp_Exp.SelectedValue;
        ObjUBO.A40 = "JV_ChargeNumber_Select";
        ds = JE.JV_Header_Select(ObjUBO);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ViewState["ChargeMaster"] = ds.Tables[0];
            //ViewState["ImpExp"] = (ddlImp_Exp.SelectedValue == "CI") ? "I" : "E";
            ViewState["ImpExp"] = ddlImp_Exp.SelectedValue;

            ddl_Charge_GL.DataSource = ds.Tables[0];
            ddl_Charge_GL.DataTextField = "CHARGE_NAME";
            ddl_Charge_GL.DataValueField = "CHARGE_CODE";
            ddl_Charge_GL.DataBind();
            ddl_Charge_GL.Items.Insert(0, new ListItem("Select", ""));
        }
        ddl_linked_GL.Items.Insert(0, new ListItem("Select", ""));
        ddl_Cost_Center.Items.Insert(0, new ListItem("Select", ""));
        ViewState["GridData"] = null;
        CreateGrid();
        gv_details.DataSource = dt;
        gv_details.DataBind();
        //ApplyHeaderValuesToGrid();
    }

    protected void ddl_Charge_GL_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = ViewState["ChargeMaster"] as DataTable;

        if (dt == null)
        {
            return;
        }

        ddl_linked_GL.Items.Clear();
        ddl_linked_GL.Items.Insert(0, new ListItem("Select", ""));

        ddl_Cost_Center.Items.Clear();
        ddl_Cost_Center.Items.Add(new ListItem("Select", ""));
        ddl_Cost_Center.Items.Add(new ListItem("Export", "E"));
        ddl_Cost_Center.Items.Add(new ListItem("Import", "I"));

        if (ViewState["ImpExp"].ToString() == "CI")
        {
            DataRow[] dr = dt.Select("CHARGE_CODE='" + ddl_Charge_GL.SelectedValue + "'");

            if (dr.Length > 0)
            {
                ddl_linked_GL.Items.Add(
                    new ListItem(dr[0]["CCI_EXPENSE"].ToString(),
                                 dr[0]["CCI_EXPENSE"].ToString()));

                ddl_linked_GL.SelectedIndex = 1;
                ddl_linked_GL.Enabled = false;
            }
            ddl_Cost_Center.SelectedValue = "I";
            ddl_Cost_Center.Enabled = false;
        }
        else if (ViewState["ImpExp"].ToString() == "CE")
        {
            DataRow[] dr = dt.Select("CHARGE_CODE='" + ddl_Charge_GL.SelectedValue + "'");

            if (dr.Length > 0)
            {
                ddl_linked_GL.Items.Add(
                    new ListItem(dr[0]["CCE_EXPENSE"].ToString(),
                                 dr[0]["CCE_EXPENSE"].ToString()));

                ddl_linked_GL.SelectedIndex = 1;
                ddl_linked_GL.Enabled = false;
            }
            ddl_Cost_Center.SelectedValue = "E";
            ddl_Cost_Center.Enabled = false;
        }
        else if (ViewState["ImpExp"].ToString() == "GL")
        {
            ddl_linked_GL.Items.Clear();
            ddl_linked_GL.Items.Add(new ListItem("None", "N"));
            ddl_linked_GL.SelectedIndex = 0;
            ddl_linked_GL.Enabled = false;

            ddl_Cost_Center.Items.Clear();
            ddl_Cost_Center.Items.Add(new ListItem("None", "N"));
            ddl_Cost_Center.SelectedIndex = 0;
            ddl_Cost_Center.Enabled = false;
            ddl_Cost_Center_SelectedIndexChanged(ddl_Cost_Center, EventArgs.Empty);
        }
        ddl_tax.SelectedValue = "NT";      // Exempt
        ddl_Cost_Center_SelectedIndexChanged(ddl_Cost_Center, EventArgs.Empty);
        ddl_tax_SelectedIndexChanged(ddl_tax, EventArgs.Empty);

    }

    protected void ddl_tax_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadTaxPercentage();
    }

    private void LoadJobNosForAllRows()
    {
        DataSet ds = new DataSet();
        //ObjUBO.A4 = ddlImp_Exp.SelectedValue == "CI" ? "I" : "E";
        ObjUBO.A4 = ddlImp_Exp.SelectedValue;
        ObjUBO.A40 = "JV_SalesJobno_Select";
        ds = JE.JV_Header_Select(ObjUBO);
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (GridViewRow row in gv_details.Rows)
            {
                BindJobNoDropdown(row, ds.Tables[0]);
            }
        }
    }

    private void BindJobNoDropdown(GridViewRow row, DataTable dt)
    {
        DropDownList ddlJobNo = (DropDownList)row.FindControl("ddl_Jobno");

        ddlJobNo.Items.Clear();
        ddlJobNo.DataSource = dt;

        ddlJobNo.DataTextField = "JOBNO_PS";
        ddlJobNo.DataValueField = "JOBNO";
        ddlJobNo.DataBind();
    }

    protected void ddl_Cost_Center_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv_details.Rows)
        {
            DropDownList ddlCstCtr = (DropDownList)row.FindControl("ddl_Cost_center");
            ddlCstCtr.SelectedValue = ddl_Cost_Center.SelectedValue;
            ddlCstCtr.Enabled = false;
        }
    }

    private void ShowMessage(string message)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('" + message.Replace("'", "\\'") + "');", true);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (gv_details.Rows.Count == 0)
            {
                ShowMessage("Please add at least one detail record.");
                return;
            }

            if (!ValidateForm())
            {
                return;
            }

            if (!ValidateGridAmounts())
            {
                return;
            }

            decimal total = 0;
            decimal.TryParse(hdntotal.Value, out total);
            decimal glAmount = Convert.ToDecimal(txt_GL_Amount.Text);
            if (total > glAmount)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Total invoice amount cannot exceed GL Amount.');", true);
                return;
            }

            ds = Journal_En_Ins_Upd("S", HDupdate_id.Value.ToString(), "", jvNo);
            Alert_msg("Saved!");
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["JL_ID"].ToString();
                txt_JV_No_F.Text = ds.Tables[0].Rows[0]["JV_P"].ToString();
                txt_JV_No_M.Text = ds.Tables[0].Rows[0]["JV_NO"].ToString();
                txt_JV_No_L.Text = ds.Tables[0].Rows[0]["JV_S"].ToString();

                ddlImp_Exp.SelectedValue = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
                ddl_Charge_GL.SelectedValue = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();

                txt_GL_Amount.Text = ds.Tables[0].Rows[0]["AMOUNT"].ToString();

                string debit = ds.Tables[0].Rows[0]["DEBIT"].ToString();
                string credit = ds.Tables[0].Rows[0]["CREDIT"].ToString();

                ddl_Cr_Dr.SelectedValue = (debit != "" && debit != "0" && debit != "0.00") ? "D" : "C";

                ddl_linked_GL.SelectedValue = ds.Tables[0].Rows[0]["LINKED_GL"].ToString();
                ddl_Cost_Center.SelectedValue = ds.Tables[0].Rows[0]["COSTCENTER"].ToString();
                ddl_branch.SelectedValue = ds.Tables[0].Rows[0]["BRANCH"].ToString();
                ddl_tax.SelectedValue = ds.Tables[0].Rows[0]["TAX_NONTAX"].ToString();
                ddl_tax_type.SelectedValue = ds.Tables[0].Rows[0]["TAX_AMT_PERCENT"].ToString();
                txtNarration.Text = ds.Tables[0].Rows[0]["NARRATION"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                //DataTable dtGrid = CreateGridStructure();
                //foreach (DataRow r in ds.Tables[1].Rows)
                //{
                //    DataRow dr = dtGrid.NewRow();

                //    dr["CHARGE_GL"] = r["CHARGE_GL"];
                //    dr["JOB_NO"] = r["JOB_NO"];
                //    dr["ESTIMATED"] = r["ESTIMATED_AMOUNT"];
                //    dr["INVOICE_AMOUNT"] = r["INVOICE_AMOUNT"];
                //    dr["AMOUNT"] = r["AMOUNT"];
                //    dr["DR_CR"] = r["DR_CR"];
                //    dr["APPORTION_METHOD"] = r["APPORTION_METHOD"];
                //    dr["COST_CENTER"] = r["COST_CENTER"];
                //    dtGrid.Rows.Add(dr);
                //}
                ViewState["GridData"] = ds.Tables[1];
                gv_details.DataSource = ds.Tables[1];
                gv_details.DataBind();
                ApplyHeaderValuesToGrid();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public DataSet Journal_En_Ins_Upd(string flg, string Exp_id, string Ch_id, string jvNo)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();

        ObjUBO.A5 = txt_JV_No_F.Text;
        ObjUBO.A6 = txt_JV_No_M.Text;
        ObjUBO.A7 = txt_JV_No_L.Text;

        ObjUBO.A10 = ddlImp_Exp.SelectedValue.ToString();
        ObjUBO.A11 = ddl_Charge_GL.SelectedValue.ToString();
        ObjUBO.A12 = txt_GL_Amount.Text.Trim();
        ObjUBO.A13 = ddl_Cr_Dr.SelectedValue.ToString();
        ObjUBO.A14 = ddl_linked_GL.SelectedValue.ToString();
        ObjUBO.A15 = ddl_Cost_Center.SelectedValue.ToString();
        ObjUBO.A16 = ddl_branch.SelectedValue.ToString();
        ObjUBO.A17 = ddl_tax.SelectedValue.ToString();
        ObjUBO.A18 = ddl_tax_type.SelectedValue.ToString();
        ObjUBO.A19 = txtNarration.Text.Trim();
        ObjUBO.A49 = Line_details();
        ObjUBO.A50 = flg;
        return JE.JV_Line_Ins_Upd(ObjUBO);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            decimal total = 0;
            decimal.TryParse(hdntotal.Value, out total);
            decimal glAmount = Convert.ToDecimal(txt_GL_Amount.Text);
            if (total > glAmount)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Total invoice amount cannot exceed GL Amount.');", true);
                return;
            }

            ds = Journal_En_Ins_Upd("U", HDupdate_id.Value.ToString(), "", jvNo);
            Alert_msg("Record updated successfully!");
            if (ds.Tables[1].Rows.Count > 0)
            {
                //DataTable dtGrid = CreateGridStructure();
                //foreach (DataRow r in ds.Tables[1].Rows)
                //{
                //    DataRow dr = dtGrid.NewRow();
                //    dr["CHARGE_GL"] = r["CHARGE_GL"];
                //    dr["JOB_NO"] = r["JOB_NO"];
                //    dr["ESTIMATED"] = r["ESTIMATED_AMOUNT"];
                //    dr["INVOICE_AMOUNT"] = r["INVOICE_AMOUNT"];
                //    dr["AMOUNT"] = r["AMOUNT"];
                //    dr["DR_CR"] = r["DR_CR"];
                //    dr["APPORTION_METHOD"] = r["APPORTION_METHOD"];
                //    dr["COST_CENTER"] = r["COST_CENTER"];
                //    dtGrid.Rows.Add(dr);
                //}
                ddl_Job_Imp_Exp_SelectedIndexChanged(this, null);
                ViewState["GridData"] = ds.Tables[1];
                gv_details.DataSource = ds.Tables[1];
                gv_details.DataBind();


                ApplyHeaderValuesToGrid();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Journal Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private void CalculateTotal()
    {
        decimal total = 0;
        foreach (GridViewRow row in gv_details.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtInvoiceAmount = (TextBox)row.FindControl("txtInvoiceAmount");
                decimal amt;
                if (txtInvoiceAmount != null && decimal.TryParse(txtInvoiceAmount.Text, out amt))
                    total += amt;
            }
        }
        lblTotal.Text = total.ToString("N2");
    }

    protected void gv_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "AddRow")
            {
                if (string.IsNullOrEmpty(ddlImp_Exp.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(
                        this, GetType(), "msg", "alert('Please select Charge/ GL Type.');", true);
                    ddlImp_Exp.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(ddl_Charge_GL.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please select Charge/ GL Name.');", true);
                    ddl_Charge_GL.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(ddl_Cr_Dr.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please Select Credit/Debit Type.');", true);
                    ddl_Cr_Dr.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txt_GL_Amount.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please enter GL Amount.');", true);
                    txt_GL_Amount.Focus();
                    return;
                }

                // Validate previous row before adding a new one
                if (gv_details.Rows.Count > 0)
                {
                    GridViewRow lastRow = gv_details.Rows[gv_details.Rows.Count - 1];

                    DropDownList ddlJobNo = (DropDownList)lastRow.FindControl("ddl_Jobno");
                    TextBox txtAmount = (TextBox)lastRow.FindControl("txtAmount");

                    if (ddlJobNo == null || string.IsNullOrWhiteSpace(ddlJobNo.SelectedValue) || ddlJobNo.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please enter Job Number in the previous row.');", true);
                        if (ddlJobNo != null)
                            ddlJobNo.Focus();
                        return;
                    }

                    decimal amt;
                    if (txtAmount == null || string.IsNullOrWhiteSpace(txtAmount.Text) || !decimal.TryParse(txtAmount.Text, out amt) || amt <= 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please enter a valid Amount in the previous row.');", true);
                        if (txtAmount != null)
                            txtAmount.Focus();
                        return;
                    }
                }

                DataTable dt = GetGridData();
                DataRow dr = dt.NewRow();
                dr["CHARGE_GL"] = "";
                dr["JOB_NO"] = "";
                dr["ESTIMATED_AMOUNT"] = "";
                dr["INVOICE_AMOUNT"] = "";
                dr["AMOUNT"] = "";
                dr["DR_CR"] = "D";
                dr["APPORTION_METHOD"] = "";
                dr["COST_CENTER"] = "E";

                dt.Rows.Add(dr);
                ViewState["GridData"] = dt;

                gv_details.DataSource = dt;
                gv_details.DataBind();
                ApplyHeaderValuesToGrid();

                //if (ddlImp_Exp.SelectedValue != "GL")
                //{
                //    ApplyHeaderValuesToGrid();
                //}

                //if (ddlImp_Exp.SelectedValue == "GL")
                //{

                //}
                CalculateTotal();
            }
            else if (e.CommandName == "DeleteRow")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                DataTable dt = GetGridData();
                if (rowIndex >= 0 && rowIndex < dt.Rows.Count)
                {
                    dt.Rows.RemoveAt(rowIndex);
                }
                ViewState["GridData"] = dt;
                gv_details.DataSource = dt;
                gv_details.DataBind();
                ApplyHeaderValuesToGrid();
                CalculateTotal();
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    protected void ddl_Cr_Dr_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState["DrCr"] = ddl_Cr_Dr.SelectedValue;
        foreach (GridViewRow row in gv_details.Rows)
        {
            DropDownList ddlDrCr = (DropDownList)row.FindControl("txtDrCr");
            ddlDrCr.SelectedValue = ddl_Cr_Dr.SelectedValue;
            ddlDrCr.Enabled = false;
        }
    }

    protected void gv_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string Jobno_select = string.Empty;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (ViewState["JobTable_Ch"] != null || ddlImp_Exp.SelectedValue != "GL")         
            {
                TextBox txt_invamt = (e.Row.FindControl("txtInvoiceAmount") as TextBox);
                txt_invamt.Attributes.Add("readonly", "readonly");

                DropDownList ddl_Job_Imp_Exp = (e.Row.FindControl("ddl_Job_Imp_Exp") as DropDownList);
                ddl_Job_Imp_Exp.Attributes.Add("readonly", "readonly");

                Jobno_select = this.gv_details.DataKeys[e.Row.RowIndex]["JOB_NO"].ToString();
                DropDownList ddl_Jobno = (e.Row.FindControl("ddl_Jobno") as DropDownList);

                string impExpType = DataBinder.Eval(e.Row.DataItem, "CHARGE_GL").ToString();
                if (impExpType == "CI" && ViewState["JobTable_Ch"] != null && ViewState["JobTable_Ch"] != string.Empty) 
                {
                    //string impExpType =  DataBinder.Eval(e.Row.DataItem, "CHARGE_GL").ToString();
                    if (!string.IsNullOrEmpty(impExpType))
                    {
                        ObjUBO.A4 = impExpType;
                        ObjUBO.A40 = "JV_SalesJobno_Select";

                        DataSet ds = JE.JV_Header_Select(ObjUBO);

                        ddl_Jobno.DataSource = ds.Tables[0];
                        ddl_Jobno.DataTextField = "JOBNO_PS";
                        ddl_Jobno.DataValueField = "JOBNO";
                        ddl_Jobno.DataBind();
                    }
                }
                else if (impExpType == "CE" && ViewState["JobTable_Ch"] != null && ViewState["JobTable_Ch"] != string.Empty)
                {
                    //string impExpType =  DataBinder.Eval(e.Row.DataItem, "CHARGE_GL").ToString();
                    if (!string.IsNullOrEmpty(impExpType))
                    {
                        ObjUBO.A4 = impExpType;
                        ObjUBO.A40 = "JV_SalesJobno_Select";

                        DataSet ds = JE.JV_Header_Select(ObjUBO);

                        ddl_Jobno.DataSource = ds.Tables[0];
                        ddl_Jobno.DataTextField = "JOBNO_PS";
                        ddl_Jobno.DataValueField = "JOBNO";
                        ddl_Jobno.DataBind();
                    }
                }
                else
                {
                    if (ddlImp_Exp.SelectedValue != "GL")
                    {
                        DataSet ds = new DataSet();
                        ObjUBO.A4 = ddlImp_Exp.SelectedValue == "CI" ? "I" : "E";
                        ObjUBO.A4 = ddlImp_Exp.SelectedValue;
                        ObjUBO.A40 = "JV_SalesJobno_Select";
                        ds = JE.JV_Header_Select(ObjUBO);
                        ViewState["JobTable_Ch"] = ds;
                        ddl_Jobno.DataSource = ds.Tables[0];
                        ddl_Jobno.DataTextField = "JOBNO_PS";
                        ddl_Jobno.DataValueField = "JOBNO";
                        ddl_Jobno.DataBind();
                    }
                }

                ddl_Jobno.Items.Insert(0, new ListItem("", ""));
                ListItem item = ddl_Jobno.Items.FindByValue(Jobno_select);
                if (item != null)
                {
                    item.Selected = true;
                }
                else
                {
                    ddl_Jobno.SelectedIndex = 0;
                }
            }
            else if (Request.QueryString["JL_ID"] != null && ddlImp_Exp.SelectedValue == "GL")
            {
                DropDownList ddl_Jobno = (DropDownList)e.Row.FindControl("ddl_Jobno");
                DataTable dt = ViewState["GridData"] as DataTable;

                ddl_Jobno.DataSource = dt;
                ddl_Jobno.DataTextField = "JOB_REFERENCE_NO";
                ddl_Jobno.DataValueField = "JOB_NO";
                ddl_Jobno.DataBind();
                string selectedJobNo = DataBinder.Eval(e.Row.DataItem, "JOB_NO").ToString();

                if (ddl_Jobno.Items.FindByValue(selectedJobNo) != null)
                {
                    ddl_Jobno.Items.FindByValue(selectedJobNo).Selected = true;
                }
            }

            TextBox txtInvoiceAmount = (TextBox)e.Row.FindControl("txtInvoiceAmount");
            if (txtInvoiceAmount != null)
            {
                //txtInvoiceAmount.ReadOnly = true;
            }
        }
    }

    protected void ddl_Job_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlImpExp = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlImpExp.NamingContainer;

        DropDownList ddlJobno = (DropDownList)row.FindControl("ddl_Jobno");
        string selectedType = ddlImpExp.SelectedValue; // "CI" or "CE"

        ddlJobno.Items.Clear();
        TextBox txtInvoiceAmount = (TextBox)row.FindControl("txtInvoiceAmount");
        TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
        TextBox txtApportionmethod = (TextBox)row.FindControl("txtApportionmethod");
        txtInvoiceAmount.Text = "";
        txtAmount.Text = "";
        txtApportionmethod.Text = "";

        if (string.IsNullOrEmpty(selectedType))
        {
            return;
        }

        ObjUBO.A4 = selectedType;
        ObjUBO.A40 = "JV_SalesJobno_Select";
        ds = JE.JV_Header_Select(ObjUBO);
        ViewState["JobTable_Ch"] = ds;
        ddlJobno.DataSource = ds.Tables[0];
        ddlJobno.DataTextField = "JOBNO_PS";
        ddlJobno.DataValueField = "JOBNO";
        ddlJobno.DataBind();
        ddlJobno.Items.Insert(0, new ListItem("", ""));
    }

    private DataTable GetGridData()
    {
        DataTable dt = ViewState["GridData"] as DataTable;

        if (dt == null)
        {
            dt = new DataTable();

            dt.Columns.Add("CHARGE_GL");
            dt.Columns.Add("JOB_NO");
            dt.Columns.Add("ESTIMATED_AMOUNT");
            dt.Columns.Add("INVOICE_AMOUNT");
            dt.Columns.Add("AMOUNT");
            dt.Columns.Add("DR_CR");
            dt.Columns.Add("APPORTION_METHOD");
            dt.Columns.Add("COST_CENTER");

            ViewState["GridData"] = dt;
            return dt;
        }

        foreach (GridViewRow row in gv_details.Rows)
        {
            int i = row.RowIndex;

            if (i < dt.Rows.Count)
            {
                SetValue(dt, i, "CHARGE_GL", row.FindControl("ddl_Job_Imp_Exp") as DropDownList);
                SetValue(dt, i, "JOB_NO", row.FindControl("ddl_Jobno") as DropDownList);
                SetValue(dt, i, "ESTIMATED_AMOUNT", row.FindControl("ddlEstimated") as DropDownList);
                SetValue(dt, i, "INVOICE_AMOUNT", row.FindControl("txtInvoiceAmount") as TextBox);
                SetValue(dt, i, "AMOUNT", row.FindControl("txtAmount") as TextBox);
                SetValue(dt, i, "DR_CR", row.FindControl("txtDrCr") as DropDownList);
                SetValue(dt, i, "APPORTION_METHOD", row.FindControl("txtApportionmethod") as TextBox);
                SetValue(dt, i, "COST_CENTER", row.FindControl("ddl_Cost_center") as DropDownList);
            }
        }
        return dt;
    }

    private void ApplyHeaderValuesToGrid()
    {
        foreach (GridViewRow row in gv_details.Rows)
        {
            DropDownList ddlImpExp = (DropDownList)row.FindControl("ddl_Job_Imp_Exp");
            DropDownList ddlDrCr = (DropDownList)row.FindControl("txtDrCr");
            DropDownList ddlCost = (DropDownList)row.FindControl("ddl_Cost_center");
            TextBox grid_txtInvoiceAmount = (TextBox)row.FindControl("txtInvoiceAmount");

            if (ddlImp_Exp.SelectedValue != "GL")
            {
                ddlImpExp.SelectedValue = ddlImp_Exp.SelectedValue;
                ddlImpExp.Enabled = false;

                ddlDrCr.SelectedValue = ddl_Cr_Dr.SelectedValue;
                ddlDrCr.Enabled = false;

                ddlCost.SelectedValue = ddl_Cost_Center.SelectedValue;
                ddlCost.Enabled = false;
            }
            else if (ddlImp_Exp.SelectedValue == "GL")
            {
                ddlImpExp.Enabled = true;
                grid_txtInvoiceAmount.Enabled = true;
                grid_txtInvoiceAmount.ReadOnly = false;
                grid_txtInvoiceAmount.Attributes.Remove("readonly");

                ddlDrCr.SelectedValue = ddl_Cr_Dr.SelectedValue;
                ddlDrCr.Enabled = false;

                ddlCost.SelectedValue = ddl_Cost_Center.SelectedValue;
                ddlCost.Enabled = false;
            }
        }
    }


    private void LoadTaxPercentage()
    {
        ddl_tax_type.Items.Clear();
        ddl_tax_type.Items.Add(new ListItem("", ""));
        if (ddl_tax.SelectedValue == "NT")
        {
            ddl_tax_type.Items.Add(new ListItem("0 %", "0"));
            ddl_tax_type.SelectedValue = "0";
            ddl_tax_type.Enabled = false;
        }
        else if (ddl_tax.SelectedValue == "T")
        {
            ddl_tax_type.Items.Add(new ListItem("5 %", "5"));
            ddl_tax_type.Items.Add(new ListItem("12 %", "12"));
            ddl_tax_type.Items.Add(new ListItem("18 %", "18"));

            ddl_tax_type.Enabled = true;
        }
        ScriptManager.RegisterStartupScript(this, GetType(), "chosenTax", "$('#ddl_tax_type').trigger('chosen:updated');", true);
    }


    private void CreateGrid()
    {
        DataTable dt = new DataTable();

        //dt.Columns.Add("CHARGE_GL");
        //dt.Columns.Add("JOB_NO");
        //dt.Columns.Add("ESTIMATED");
        //dt.Columns.Add("INVOICE_AMOUNT");
        //dt.Columns.Add("AMOUNT");
        //dt.Columns.Add("DR_CR");
        //dt.Columns.Add("APPORTION_METHOD");
        //dt.Columns.Add("COST_CENTER");
        //ViewState["GridData"] = dt;

        gv_details.DataSource = dt;
        gv_details.DataBind();
    }

    private DataTable CreateGridStructure()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("CHARGE_GL");
        dt.Columns.Add("JOB_NO");
        dt.Columns.Add("ESTIMATED");
        dt.Columns.Add("INVOICE_AMOUNT");
        dt.Columns.Add("AMOUNT");
        dt.Columns.Add("DR_CR");
        dt.Columns.Add("APPORTION_METHOD");
        dt.Columns.Add("COST_CENTER");

        return dt;
    }
    //-----------------------------------------------------------------------------------
    private string Line_details()
    {
        DataTable dtt = new DataTable();
        DataRow dr;
        dtt.Columns.Add(new System.Data.DataColumn("JobImpExp", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("JobNo", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("ReferenceNo", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Estimated", typeof(String)));

        dtt.Columns.Add(new System.Data.DataColumn("Inv_Amt", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Amount", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("DrCr", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("Ap_Method", typeof(String)));
        dtt.Columns.Add(new System.Data.DataColumn("CostCenter", typeof(String)));

        int R = 1;
        foreach (GridViewRow row in gv_details.Rows)
        {
            DropDownList ddl_Job_Imp_Exp = (DropDownList)row.FindControl("ddl_Job_Imp_Exp");
            DropDownList ddl_Jobno = (DropDownList)row.FindControl("ddl_Jobno");
            DropDownList ddlEstimated = (DropDownList)row.FindControl("ddlEstimated");
            DropDownList txtDrCr = (DropDownList)row.FindControl("txtDrCr");
            DropDownList ddl_Cost_center = (DropDownList)row.FindControl("ddl_Cost_center");

            string invoiceKey = ((TextBox)row.FindControl("txtInvoiceAmount")).UniqueID;
            string amountKey = ((TextBox)row.FindControl("txtAmount")).UniqueID;
            string appKey = ((TextBox)row.FindControl("txtApportionmethod")).UniqueID;


            if (ddl_Job_Imp_Exp.SelectedValue.ToString() == string.Empty && ddl_Jobno.SelectedValue.ToString() == string.Empty)
            {
            }
            else
            {
                dr = dtt.NewRow();
                dr[0] = ddl_Job_Imp_Exp.SelectedValue.ToString();
                dr[1] = ddl_Jobno.SelectedValue.ToString();
                dr[2] = ddl_Jobno.SelectedItem.Text;
                //dr[3] = ddlEstimated.SelectedItem.Text;

                dr[3] = ddlEstimated.SelectedValue == "" ? "" : ddlEstimated.SelectedItem.Text;

                dr[4] = Request.Form[invoiceKey] ?? "";
                dr[5] = Request.Form[amountKey] ?? "";
                dr[6] = txtDrCr.SelectedValue.ToString();
                dr[7] = Request.Form[appKey] ?? "";
                dr[8] = ddl_Cost_center.SelectedValue.ToString();

                dtt.Rows.Add(dr);
                R = R + 1;
            }
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = Common_CS.ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
    }

    private bool ValidateForm()
    {
        decimal amount;

        if (ddl_Charge_GL.SelectedValue == "")
        {
            ShowMessage("Please Select Charge / GL Type");
            ddl_Charge_GL.Focus();
            return false;
        }

        if (txt_GL_Amount.Text.Trim() == "")
        {
            ShowMessage("Please Enter Amount");
            txt_GL_Amount.Focus();
            return false;
        }

        if (!decimal.TryParse(txt_GL_Amount.Text, out amount))
        {
            ShowMessage("Amount must be numeric");
            txt_GL_Amount.Focus();
            return false;
        }

        if (amount <= 0)
        {
            ShowMessage("Amount must be greater than zero");
            txt_GL_Amount.Focus();
            return false;
        }

        if (ddl_Cr_Dr.SelectedValue == "")
        {
            ShowMessage("Please select DR / CR");
            ddl_Cr_Dr.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(ddl_branch.SelectedValue))
        {
            ShowMessage("Please select Branch");
            ddl_branch.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(ddl_tax.SelectedValue))
        {
            ShowMessage("Please select Tax Type");
            ddl_tax.Focus();
            return false;
        }

        if (string.IsNullOrEmpty(ddl_tax_type.SelectedValue))
        {
            ShowMessage("Please select Tax Value");
            ddl_tax_type.Focus();
            return false;
        }

        /*
        if (ddl_linked_GL.SelectedIndex < 0)
        {
            ShowMessage("Please select Linked GL");
            ddl_linked_GL.Focus();
            return false;
        }

        if (ddl_Cost_Center.SelectedIndex < 0)
        {
            ShowMessage("Please select Cost Center");
            ddl_Cost_Center.Focus();
            return false;
        }

        if (ddl_tax.SelectedIndex < 0)
        {
            ShowMessage("Please select Tax");
            ddl_tax.Focus();
            return false;
        }

        if (ddl_tax_type.SelectedIndex < 0)
        {
            ShowMessage("Please select Tax Percentage");
            ddl_tax_type.Focus();
            return false;
        } */
        return true;
    }



    // Common 
    private void SetValue(DataTable dt, int rowIndex, string column, ListControl ctrl)
    {
        if (ctrl != null)
            dt.Rows[rowIndex][column] = ctrl.SelectedValue;
    }

    private void SetValue(DataTable dt, int rowIndex, string column, TextBox ctrl)
    {
        if (ctrl != null)
            dt.Rows[rowIndex][column] = ctrl.Text;
    }


    [System.Web.Services.WebMethod]
    public static string Get_Cha_Sales_InvAmt(string JobNo, string JobText, string Imp_Exp_flag, string chargeName, string chargeCode, string dctypeVal, string fullJVNo)
    {
        string jobInvAmt = "";
        DataSet ds = new DataSet();
        try
        {   
            Acc_Journal_Entry_cs JE = new Acc_Journal_Entry_cs();
            Global_variables ObjUBO = new Global_variables();
            ObjUBO.A3 = (Imp_Exp_flag == "CI") ? "I" : "E";         //import or export type
            ObjUBO.A4 = JobNo;                                      //jobno
            ObjUBO.A5 = JobText;                                    //jobpsno
            ObjUBO.A7 = dctypeVal;                                  //credit or debit type 
            ObjUBO.A8 = chargeCode;                                 //chargeCode
            ObjUBO.A9 = chargeName;                                 //chargename
            ObjUBO.A10 = fullJVNo;                                  //fulljobno
            ObjUBO.A40 = "ACC_JOB_Sales_InvAmt";                    //flag
            ds = JE.JV_Header_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                jobInvAmt = ds.Tables[0].Rows[0]["Inv_Amt"].ToString() + "~" + ds.Tables[0].Rows[0]["Bal_Amt"].ToString();
            }
            
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return jobInvAmt;
    }


    /*[System.Web.Services.WebMethod]
    public static string getCha_JobNumbers(string Imp_Exp_flag)
    {
        string jobInvAmt = "";
        DataSet ds = new DataSet();
        try
        {
            if (JobNo != string.Empty)
            {
                Acc_Journal_Entry_cs JE = new Acc_Journal_Entry_cs();
                Global_variables ObjUBO = new Global_variables();
                ObjUBO.A3 = (Imp_Exp_flag == "CI") ? "I" : "E"; ;
                ObjUBO.A4 = JobNo;
                ObjUBO.A40 = "ACC_JOB_Sales_InvAmt";
                ds = JE.JV_Header_Select(ObjUBO);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //jobInvAmt = ds.Tables[0].Rows[0]["INVOICEAMOUNT"].ToString();

                    jobInvAmt = ds.Tables[0].Rows[0]["Inv_Amt"].ToString() + "~" + ds.Tables[0].Rows[0]["Bal_Amt"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return jobInvAmt;
    }
    */

    private bool ValidateGridAmounts()
    {
        int rowNumber = 1;

        foreach (GridViewRow row in gv_details.Rows)
        {
            if (row.RowType != DataControlRowType.DataRow)
                continue;

            DropDownList ddlJobNo = (DropDownList)row.FindControl("ddl_Jobno");
            TextBox txtInvoiceAmount = (TextBox)row.FindControl("txtInvoiceAmount");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");

            if (ddlJobNo == null || txtInvoiceAmount == null || txtAmount == null)
            {
                rowNumber++;
                continue;
            }

            string jobNo = ddlJobNo.SelectedValue;
            string invoiceStr = Request.Form[txtInvoiceAmount.UniqueID] ?? txtInvoiceAmount.Text;
            string amountStr = Request.Form[txtAmount.UniqueID] ?? txtAmount.Text;

            // Completely blank row -> ignore/remove
            //if ((string.IsNullOrWhiteSpace(jobNo) || jobNo == "0") &&
            //    string.IsNullOrWhiteSpace(invoiceStr) &&
            //    string.IsNullOrWhiteSpace(amountStr))
            //{
            //    rowNumber++;
            //    continue;
            //}

            // Job No is mandatory for a non-blank row
            if (string.IsNullOrWhiteSpace(jobNo) || jobNo == "0")
            {
                ShowMessage("Row " + rowNumber + ": Please select a Job Number.");
                return false;
            }

            decimal invoiceAmt, amount;
            if (!decimal.TryParse(invoiceStr, out invoiceAmt))
            {
                ShowMessage("Row " + rowNumber + ": Invalid Invoice Amount value.");
                return false;
            }

            if (!decimal.TryParse(amountStr, out amount))
            {
                ShowMessage("Row " + rowNumber + ": Invalid Amount(INR) value.");
                return false;
            }

            if (amount > invoiceAmt)
            {
                ShowMessage("Row " + rowNumber + ": Amount(INR) [" +
                            amount.ToString("N2") +
                            "] cannot be greater than Invoice Amount [" +
                            invoiceAmt.ToString("N2") + "].");
                return false;
            }
            rowNumber++;
        }
        return true;
    }
}
