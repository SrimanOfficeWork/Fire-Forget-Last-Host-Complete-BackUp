using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Acc_CashWithdraw_Details : ThemeClass
{
    AppSession aps = new AppSession();
    Global_variables ObjUBO = new Global_variables();
    Payment_Entry_Cash_Withdrawal PCW = new Payment_Entry_Cash_Withdrawal();

    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public int i;
    private string BPL_ID = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        try
        {
            if (!IsPostBack)
            {
                DataTable dtt = new DataTable();                                
                btnSave.Visible = true;
                gv_details.DataSource = dtt;
                gv_details.DataBind();
                ViewState["IMP_EXP"] = ddlImp_Exp.SelectedValue;

                txt_BP_C_P.Text = Request.QueryString["BP_C_P"];
                txt_BP_C_M.Text = Request.QueryString["BP_C_NO"];
                txt_BP_C_L.Text = Request.QueryString["BP_C_S"];
                txt_GL_Amount.Text = Request.QueryString["AMT"];

                if (Request.QueryString["BPL_ID"] != null && Request.QueryString["BPL_ID"] != string.Empty)
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    Load_CashWithDraw_Details_Update();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    //1.1load charge Names values function 
    protected void ddlImp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ViewState.Remove("JobTable_Ch");
        DataSet ds = new DataSet();

        ddl_Charge_GL.Items.Clear();
        ddl_linked_GL.Items.Clear();
        //ddl_Cost_Center.Items.Clear();

        ObjUBO.A5 = ddlImp_Exp.SelectedValue;
        ObjUBO.A40 = "CW_load_ChargeName";
        ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            ViewState["ChargeMaster"] = ds.Tables[0];
            ViewState["ImpExp"] = ddlImp_Exp.SelectedValue;

            ddl_Charge_GL.DataSource = ds.Tables[0];
            ddl_Charge_GL.DataTextField = "CHARGE_NAME";
            ddl_Charge_GL.DataValueField = "CHARGE_CODE";
            ddl_Charge_GL.DataBind();
            ddl_Charge_GL.Items.Insert(0, new ListItem("Select", ""));
        }
        ddl_linked_GL.Items.Insert(0, new ListItem("NONE", "N"));
        //ddl_Cost_Center.Items.Insert(0, new ListItem("NONE", "N"));

        if (Request.QueryString["BPL_ID"] == null)
        {
            ViewState.Remove("JobTable_Ch");
            gv_details.DataSource = null;
            gv_details.DataBind();
        }
        DataTable dtt = new DataTable();
        gv_details.DataSource = dtt;
        gv_details.DataBind();
        ApplyHeaderValuesToGrid();
    }

    //2.
    protected void ddl_Charge_GL_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = ViewState["ChargeMaster"] as DataTable;
        string impExp = ddlImp_Exp.SelectedValue;

        if (dt == null)
        { return; }

        ddl_linked_GL.Items.Clear();
        ddl_linked_GL.Items.Insert(0, new ListItem("Select", ""));
        if (impExp == "CI")
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
            //ddl_Cost_Center.Items.Add(new ListItem("CC Import", "I"));
            //ddl_Cost_Center.SelectedValue = "I";
            //ddl_Cost_Center.Enabled = false;
        }
        else if (impExp == "CE")
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
            //ddl_Cost_Center.Items.Add(new ListItem("CCL Export", "E"));
            //ddl_Cost_Center.SelectedValue = "E";
            //ddl_Cost_Center.Enabled = false;
        }
        else if (impExp == "GL")
        {
            ddl_linked_GL.Items.Clear();
            ddl_linked_GL.Items.Add(new ListItem("None", "N"));
            ddl_linked_GL.SelectedIndex = 0;
            ddl_linked_GL.Enabled = false;

            //ddl_Cost_Center.Items.Clear();

            //ddl_Cost_Center.Items.Add(new ListItem("None", "N"));
            //ddl_Cost_Center.SelectedIndex = 0;
            //ddl_Cost_Center.Enabled = false;
            //ddl_Cost_Center_SelectedIndexChanged(ddl_Cost_Center, EventArgs.Empty);
        }
        ddl_Cost_Center_SelectedIndexChanged(ddl_Cost_Center, EventArgs.Empty);
    }

    //3.
    protected void ddl_Cost_Center_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv_details.Rows)
        {
            DropDownList ddlCstCtr = (DropDownList)row.FindControl("ddl_gd_Cost_center");
            ddlCstCtr.SelectedValue = ddl_Cost_Center.SelectedValue;
            ddlCstCtr.Enabled = false;
        }
    }

    protected void ddl_Job_Imp_Exp_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddlImpExp = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddlImpExp.NamingContainer;
        DropDownList ddlJobno = (DropDownList)row.FindControl("ddl_Jobno");

        if (string.IsNullOrWhiteSpace(ddlImpExp.SelectedValue))
            return;

        string selectedType = ddlImpExp.SelectedValue;

        ddlJobno.Items.Clear();
        if (ddlImp_Exp.SelectedValue == "GL")
        {
            TextBox txtInvoiceAmount = (TextBox)row.FindControl("txtInvoiceAmount");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            TextBox txtApportionmethod = (TextBox)row.FindControl("txtApportionmethod");

            decimal headerAmount = 0;
            decimal.TryParse(txt_GL_Amount.Text.Trim(), out headerAmount);

            DataTable dt = GetGridData();
            decimal usedAmount = 0;
            int currentRowIndex = row.RowIndex;
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                if (r == currentRowIndex)
                    continue;

                decimal amt;
                if (decimal.TryParse(Convert.ToString(dt.Rows[r]["AMOUNT"]), out amt))
                    usedAmount += amt;
            }

            decimal remaining = headerAmount - usedAmount;
            if (remaining < 0) remaining = 0;

            txtInvoiceAmount.Text = remaining.ToString("0.00");
            txtAmount.Text = remaining.ToString("0.00");
            txtApportionmethod.Text = "";
        }

        ObjUBO.A5 = selectedType;
        ObjUBO.A40 = "select_ChaJobnos_for_payments";
        ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);
        ViewState["JobTable_Ch"] = ds;
        ddlJobno.DataSource = ds.Tables[0];
        ddlJobno.DataTextField = "JOBNO_PS";
        ddlJobno.DataValueField = "JOBNO";
        ddlJobno.DataBind();
        ddlJobno.Items.Insert(0, new ListItem("", ""));
        ddlJobno.SelectedIndex = 0;

        ViewState["GridData"] = GetGridData();
    }

    //4.
    protected void gv_details_RowCommand(object sender, GridViewCommandEventArgs e)
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
            decimal amount = 0;
            if (string.IsNullOrWhiteSpace(txt_GL_Amount.Text) || !decimal.TryParse(txt_GL_Amount.Text.Trim(), out amount) || amount == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Please Enter Amount.');", true);
                txt_GL_Amount.Focus();
                return;
            }

            DataTable dt = GetGridData();
            decimal usedAmount = 0;
            foreach (DataRow r in dt.Rows)
            {
                decimal amt;
                if (decimal.TryParse(Convert.ToString(r["AMOUNT"]), out amt))
                    usedAmount += amt;
            }

            decimal remaining = amount - usedAmount;
            if (remaining < 0) remaining = 0;

            DataRow dr = dt.NewRow();

            dr["CHARGE_GL"] = "";
            dr["JOB_NO"] = "";
            dr["ESTIMATED_AMOUNT"] = remaining.ToString("0.00");
            dr["INVOICE_AMOUNT"] = remaining.ToString("0.00");
            dr["AMOUNT"] = remaining.ToString("0.00");
            dr["DR_CR"] = "D";
            dr["APPORTION_METHOD"] = "";
            dr["COST_CENTER"] = "N";

            dt.Rows.Add(dr);
            ViewState["GridData"] = dt;
            gv_details.DataSource = dt;
            gv_details.DataBind();

            ApplyHeaderValuesToGrid();
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

    private DataTable GetGridData()
    {
        DataTable dt = ViewState["GridData"] as DataTable;

        if (dt == null)
        {
            dt = CreateGridStructure();
            if (gv_details.Rows.Count > 0)
            {
                foreach (GridViewRow row in gv_details.Rows)
                {
                    if (row.RowType != DataControlRowType.DataRow)
                        continue;

                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    PopulateRowFromControls(dt, dt.Rows.Count - 1, row);
                }
            }
            ViewState["GridData"] = dt;
            return dt;
        }
        foreach (GridViewRow row in gv_details.Rows)
        {
            if (row.RowType != DataControlRowType.DataRow)
                continue;

            int i = row.RowIndex;
            if (i < dt.Rows.Count)
            {
                PopulateRowFromControls(dt, i, row);
            }
        }
        return dt;
    }

    private void PopulateRowFromControls(DataTable dt, int rowIndex, GridViewRow row)
    {
        SetValue(dt, rowIndex, "CHARGE_GL", row.FindControl("ddl_Job_Imp_Exp") as DropDownList);
        SetValue(dt, rowIndex, "JOB_NO", row.FindControl("ddl_Jobno") as DropDownList);
        SetValue(dt, rowIndex, "ESTIMATED_AMOUNT", row.FindControl("txtEstimated") as TextBox);
        SetValue(dt, rowIndex, "INVOICE_AMOUNT", row.FindControl("txtInvoiceAmount") as TextBox);
        SetValue(dt, rowIndex, "AMOUNT", row.FindControl("txtAmount") as TextBox);
        SetValue(dt, rowIndex, "DR_CR", row.FindControl("txtDrCr") as DropDownList);
        SetValue(dt, rowIndex, "APPORTION_METHOD", row.FindControl("txtApportionmethod") as TextBox);
        SetValue(dt, rowIndex, "COST_CENTER", row.FindControl("ddl_gd_Cost_center") as DropDownList);
    }

    //5.
    private DataTable GetGridData_old()
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
                SetValue(dt, i, "ESTIMATED_AMOUNT", row.FindControl("txtEstimated") as TextBox);
                SetValue(dt, i, "INVOICE_AMOUNT", row.FindControl("txtInvoiceAmount") as TextBox);
                SetValue(dt, i, "AMOUNT", row.FindControl("txtAmount") as TextBox);
                SetValue(dt, i, "DR_CR", row.FindControl("txtDrCr") as DropDownList);
                SetValue(dt, i, "APPORTION_METHOD", row.FindControl("txtApportionmethod") as TextBox);
                SetValue(dt, i, "COST_CENTER", row.FindControl("ddl_gd_Cost_center") as DropDownList);
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
            DropDownList ddlCost = (DropDownList)row.FindControl("ddl_gd_Cost_center");

            if (ddlImp_Exp.SelectedValue == "CI" || ddlImp_Exp.SelectedValue == "CE")
            {
                ddlImpExp.SelectedValue = ddlImp_Exp.SelectedValue;
                ddlImpExp.Enabled = false;

                if (ddlImp_Exp.SelectedValue == "CI")
                {
                    ddlCost.SelectedValue = "I";
                    ddlCost.Enabled = false;
                }
                else
                {
                    ddlCost.SelectedValue = "E";
                    ddlCost.Enabled = false;
                }
            }
            ddlDrCr.SelectedValue = ddl_Cr_Dr.SelectedValue;
            ddlDrCr.Enabled = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //if (gv_details.Rows.Count == 0)
            //{
            //    ShowMessage("Please add at least one detail record.");
            //    return;
            //}

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
            ds = cashWithDraw_Ins_Upd("S", HDupdate_id.Value.ToString(), "");
            Alert_msg("Saved!");
            btnSave.Visible = false;
            btnUpdate.Visible = true;            
            if (ds.Tables[0].Rows.Count > 0)
            {
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BPL_ID"].ToString();
                txt_BP_C_P.Text = ds.Tables[0].Rows[0]["BP_C_P"].ToString();
                txt_BP_C_M.Text = ds.Tables[0].Rows[0]["BP_C_NO"].ToString();
                txt_BP_C_L.Text = ds.Tables[0].Rows[0]["BP_C_S"].ToString();

                ddlImp_Exp.SelectedValue = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
                ddl_Charge_GL.SelectedValue = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();
                txt_GL_Amount.Text = ds.Tables[0].Rows[0]["AMOUNT"].ToString();
                ddl_Cr_Dr.SelectedValue = Convert.ToDecimal(ds.Tables[0].Rows[0]["DEBIT"]) > 0 ? "D" : "C";
                ddl_linked_GL.SelectedValue = ds.Tables[0].Rows[0]["LINKED_GL"].ToString();
                ddl_Cost_Center.SelectedValue = ds.Tables[0].Rows[0]["COSTCENTER"].ToString();
                ddl_branch.SelectedValue = ds.Tables[0].Rows[0]["BRANCH"].ToString();
                txtNarration.Text = ds.Tables[0].Rows[0]["NARRATION"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
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

    private void Load_CashWithDraw_Details_Update()
    {
        try
        {
            DataSet ds = new DataSet();
            ObjUBO.A1 = Convert.ToString(Request.QueryString["BPL_ID"]);
            ObjUBO.A40 = "cashWithdraw_select_Details_editmode";            
            ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                string impExp = ds.Tables[0].Rows[0]["IMP_EXP"].ToString();
                string chargeCode = ds.Tables[0].Rows[0]["CHARGE_NAME"].ToString();

                ObjUBO.A5 = impExp;
                ObjUBO.A40 = "CW_load_ChargeName";                
                DataSet dsMaster = PCW.Acc_CashWithdrawal_Select(ObjUBO);
                if (dsMaster != null && dsMaster.Tables.Count > 0 && dsMaster.Tables[0].Rows.Count > 0)
                {
                    ViewState["ChargeMaster"] = dsMaster.Tables[0];
                    ViewState["ImpExp"] = impExp;

                    ddl_Charge_GL.DataSource = dsMaster.Tables[0];
                    ddl_Charge_GL.DataTextField = "CHARGE_NAME";
                    ddl_Charge_GL.DataValueField = "CHARGE_CODE";
                    ddl_Charge_GL.DataBind();
                }
                HDupdate_id.Value = ds.Tables[0].Rows[0]["BPL_ID"].ToString();
                txt_BP_C_P.Text = ds.Tables[0].Rows[0]["BP_C_P"].ToString();
                txt_BP_C_M.Text = ds.Tables[0].Rows[0]["BP_C_NO"].ToString();
                txt_BP_C_L.Text = ds.Tables[0].Rows[0]["BP_C_S"].ToString();

                ddlImp_Exp.SelectedValue = impExp;
                ddl_Charge_GL.SelectedValue = chargeCode;
                txt_GL_Amount.Text = ds.Tables[0].Rows[0]["AMOUNT"].ToString();

                string debit = ds.Tables[0].Rows[0]["DEBIT"].ToString();
                ddl_Cr_Dr.SelectedValue = (debit != "" && debit != "0" && debit != "0.00") ? "D" : "C";

                ddl_linked_GL.SelectedValue = ds.Tables[0].Rows[0]["LINKED_GL"].ToString();
                ddl_Cost_Center.SelectedValue = ds.Tables[0].Rows[0]["COSTCENTER"].ToString();
                ddl_branch.SelectedValue = ds.Tables[0].Rows[0]["BRANCH"].ToString();
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
                    ddl_Cost_Center.Items.Insert(0, new ListItem("None", "N"));

                    string savedCostCenter = ds.Tables[0].Rows[0]["COSTCENTER"].ToString();
                    if (savedCostCenter == "N")
                        ddl_Cost_Center.SelectedIndex = 0;
                    ddl_Cost_Center.Enabled = false;
                }
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
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

    private DataTable CreateGridStructure()
    {
        DataTable dt = new DataTable();

        dt.Columns.Add("CHARGE_GL");
        dt.Columns.Add("JOB_NO");
        dt.Columns.Add("ESTIMATED_AMOUNT");
        dt.Columns.Add("INVOICE_AMOUNT");
        dt.Columns.Add("AMOUNT");
        dt.Columns.Add("DR_CR");
        dt.Columns.Add("APPORTION_METHOD");
        dt.Columns.Add("COST_CENTER");

        return dt;
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

    private void ShowMessage(string message)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "alert('" + message.Replace("'", "\\'") + "');", true);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //CalculateTotal();            
            ds = cashWithDraw_Ins_Upd("U", HDupdate_id.Value.ToString(), "");
            Alert_msg("Record updated successfully!");
            if (ds.Tables[1].Rows.Count > 0)
            {
                DataTable dtGrid = CreateGridStructure();
                foreach (DataRow r in ds.Tables[1].Rows)
                {
                    DataRow dr = dtGrid.NewRow();

                    dr["CHARGE_GL"] = r["CHARGE_GL"];
                    dr["JOB_NO"] = r["JOB_NO"];
                    dr["ESTIMATED"] = r["ESTIMATED_AMOUNT"];
                    dr["INVOICE_AMOUNT"] = r["INVOICE_AMOUNT"];
                    dr["AMOUNT"] = r["AMOUNT"];
                    dr["DR_CR"] = r["DR_CR"];
                    dr["APPORTION_METHOD"] = r["APPORTION_METHOD"];
                    dr["COST_CENTER"] = r["COST_CENTER"];
                    dtGrid.Rows.Add(dr);
                }
                ViewState["GridData"] = dtGrid;
                gv_details.DataSource = dtGrid;
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
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Cash WithDraw', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    private void CalculateTotal()
    {
        decimal total = 0;
        foreach (GridViewRow row in gv_details.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
                decimal amt;
                if (txtAmount != null && decimal.TryParse(txtAmount.Text, out amt))
                    total += amt;
            }
        }
        lblTotal.Text = total.ToString("N2");
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

                DropDownList ddl_Job_Imp_Exp = (e.Row.FindControl("ddl_Job_Imp_Exp") as DropDownList);
                ddl_Job_Imp_Exp.Attributes.Add("readonly", "readonly");

                Jobno_select = this.gv_details.DataKeys[e.Row.RowIndex]["JOB_NO"].ToString();
                DropDownList ddl_Jobno = (e.Row.FindControl("ddl_Jobno") as DropDownList);

                string impExpType = DataBinder.Eval(e.Row.DataItem, "CHARGE_GL").ToString();
                if (impExpType == "CI" && ViewState["JobTable_Ch"] != null && ViewState["JobTable_Ch"] != string.Empty)
                {
                    if (!string.IsNullOrEmpty(impExpType))
                    {
                        ObjUBO.A5 = impExpType;
                        ObjUBO.A40 = "select_ChaJobnos_for_payments";
                        DataSet ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);
                        ddl_Jobno.DataSource = ds.Tables[0];
                        ddl_Jobno.DataTextField = "JOBNO_PS";
                        ddl_Jobno.DataValueField = "JOBNO";
                        ddl_Jobno.DataBind();
                    }
                }
                else if (impExpType == "CE" && ViewState["JobTable_Ch"] != null && ViewState["JobTable_Ch"] != string.Empty)
                {
                    if (!string.IsNullOrEmpty(impExpType))
                    {
                        ObjUBO.A5 = impExpType;
                        ObjUBO.A40 = "select_ChaJobnos_for_payments";
                        DataSet ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);
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
                        ObjUBO.A5 = ddlImp_Exp.SelectedValue;
                        ObjUBO.A40 = "select_ChaJobnos_for_payments";
                        ds = PCW.Acc_CashWithdrawal_Select(ObjUBO);
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
            else if (Request.QueryString["BPL_ID"] != null && ddlImp_Exp.SelectedValue == "GL")
            {
                DropDownList ddl_Jobno = (DropDownList)e.Row.FindControl("ddl_Jobno");
                DataTable dt = ViewState["GridData"] as DataTable;

                ddl_Jobno.DataSource = dt;
                ddl_Jobno.DataTextField = dt.Columns.Contains("JOB_REFERENCE_NO") ? "JOB_REFERENCE_NO" : "JOB_NO";  
                ddl_Jobno.DataValueField = "JOB_NO";
                ddl_Jobno.DataBind();
                string selectedJobNo = DataBinder.Eval(e.Row.DataItem, "JOB_NO").ToString();
                ddl_Jobno.Items.FindByValue(selectedJobNo).Selected = true;
                /*
                if (ddl_Jobno.Items.FindByValue(selectedJobNo) != null)
                {
                    ddl_Jobno.Items.FindByValue(selectedJobNo).Selected = true;
                }*/
            }
            TextBox txtInvoiceAmount = (TextBox)e.Row.FindControl("txtInvoiceAmount");
            if (txtInvoiceAmount != null)
            {
                //txtInvoiceAmount.ReadOnly = true;
            }
        }
    }  
    //-----------------------------------------------------------------------------------    
    public DataSet cashWithDraw_Ins_Upd(string flg, string Exp_id, string Ch_id)
    {
        ObjUBO.A1 = HDupdate_id.Value.ToString();

        ObjUBO.A5 = txt_BP_C_P.Text;
        ObjUBO.A6 = txt_BP_C_M.Text;
        ObjUBO.A7 = txt_BP_C_L.Text;

        //header fields
        ObjUBO.A10 = ddlImp_Exp.SelectedValue.ToString();
        ObjUBO.A11 = ddl_Charge_GL.SelectedValue.ToString();
        ObjUBO.A12 = txt_GL_Amount.Text.Trim();
        ObjUBO.A13 = ddl_Cr_Dr.SelectedValue.ToString();
        ObjUBO.A14 = ddl_linked_GL.SelectedValue.ToString();
        ObjUBO.A15 = ddl_Cost_Center.SelectedValue.ToString();
        ObjUBO.A16 = ddl_branch.SelectedValue.ToString();
        ObjUBO.A19 = txtNarration.Text.Trim();
        //grid
        ObjUBO.A49 = Line_details();
        ObjUBO.A50 = flg;

        return PCW.cw_LineDetails_Ins_Upd(ObjUBO);
    }

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
            DropDownList txtDrCr = (DropDownList)row.FindControl("txtDrCr");
            DropDownList ddl_gd_Cost_center = (DropDownList)row.FindControl("ddl_gd_Cost_center");

            string txtestimate = ((TextBox)row.FindControl("txtEstimated")).UniqueID;
            string invoiceKey = ((TextBox)row.FindControl("txtInvoiceAmount")).UniqueID;
            string amountKey = ((TextBox)row.FindControl("txtAmount")).UniqueID;
            string appKey = ((TextBox)row.FindControl("txtApportionmethod")).UniqueID;

            if (ddl_Job_Imp_Exp.SelectedValue.ToString() == string.Empty && ddl_Jobno.SelectedValue.ToString() == string.Empty)
            {
            }
            else
            {
                dr = dtt.NewRow();
                dr[0] = ddl_Job_Imp_Exp.SelectedValue.ToString();                      // JobImpExp
                dr[1] = ddl_Jobno.SelectedValue.ToString();                            // JobNo
                dr[2] = ddl_Jobno.SelectedItem.Text.ToString();                        // ReferenceNo
                dr[3] = Request.Form[txtestimate] ?? "";                               // Estimated
                dr[4] = Request.Form[invoiceKey] ?? "";                                // Inv_Amt
                dr[5] = Request.Form[amountKey] ?? "";                                 // Amount
                dr[6] = txtDrCr.SelectedValue.ToString();                              // DrCr
                dr[7] = Request.Form[appKey] ?? "";                                    // Ap_Method
                dr[8] = ddl_gd_Cost_center.SelectedValue.ToString();                   // CostCenter

                dtt.Rows.Add(dr);
                R = R + 1;
            }
        }
        DataSet dsData = new DataSet();
        dsData.Tables.Add(dtt);
        String xmlData = Common_CS.ConvertDataTableToXML(dsData.Tables[0]);
        return xmlData;
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

    private bool ValidateForm()
    {
        decimal amount;

        if (ddl_Charge_GL.SelectedValue == "")
        {
            ShowMessage("Please Select Charge / GL");
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

        if (ddl_branch.SelectedIndex < 0)
        {
            ShowMessage("Please select Branch");
            ddl_branch.Focus();
            return false;
        }
        return true;
    }

    [System.Web.Services.WebMethod]
    public static string Get_Cha_Sales_InvAmt(string JobNo, string Imp_Exp_flag)
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
                    jobInvAmt = ds.Tables[0].Rows[0]["INVOICEAMOUNT"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return jobInvAmt;
    }

    private bool ValidateGridAmounts()
    {
        int rowNumber = 1;

        foreach (GridViewRow row in gv_details.Rows)
        {
            if (row.RowType != DataControlRowType.DataRow)
                continue;

            TextBox txtInvoiceAmount = (TextBox)row.FindControl("txtInvoiceAmount");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");

            if (txtInvoiceAmount == null || txtAmount == null)
            {
                rowNumber++;
                continue;
            }

            string invoiceKey = txtInvoiceAmount.UniqueID;
            string amountKey = txtAmount.UniqueID;

            string invoiceStr = Request.Form[invoiceKey] ?? txtInvoiceAmount.Text;
            string amountStr = Request.Form[amountKey] ?? txtAmount.Text;

            decimal invoiceAmt = 0, amount = 0;
            if (string.IsNullOrWhiteSpace(invoiceStr) && string.IsNullOrWhiteSpace(amountStr))
            {
                rowNumber++;
                continue;
            }

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
                ShowMessage("Row " + rowNumber + ": Amount(INR) [" + amount.ToString("N2") +
                            "] cannot be greater than Invoice Amount [" + invoiceAmt.ToString("N2") + "].");
                return false;
            }

            rowNumber++;
        }
        return true;
    }
}
