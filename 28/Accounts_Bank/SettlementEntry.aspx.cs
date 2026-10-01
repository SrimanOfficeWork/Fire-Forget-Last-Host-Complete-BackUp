using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BussinessObject;
using System.Text;
using System.IO;
using System.Globalization;
public partial class SettlementEntry : ThemeClass
{
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    Global_variables objUBO = new Global_variables();
    Settlement_cs Set = new Settlement_cs();
    private decimal _creditsOutstandingTotal = 0m;
    private decimal _creditsSettlementTotal, _debitsOutstandingTotal,
        _debitsSettlementTotal, _debitsBalanceTotal, _totalDebitTDS, _debitsTotalSettleAmount, _debitsTotalAmtRecd = 0m;
    string WorkingPeriod = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Group_Name();
            if (Request.QueryString["S_PF"] != null && Request.QueryString["S_NO"] != null && Request.QueryString["S_SF"] != null)
            {
                string S_PF = Request.QueryString["S_PF"].ToString();
                string S_NO = Request.QueryString["S_NO"].ToString();
                string S_SF = Request.QueryString["S_SF"].ToString();
                BindSettlementData(S_PF, S_NO, S_SF);
            }
        }
    }
    private void BindSettlementData(string S_PF, string S_NO, string S_SF)
    {
        try
        {
            objUBO.A1 = S_PF;
            objUBO.A2 = S_NO;
            objUBO.A3 = S_SF;
            ds = Set.LoadSettlementData(objUBO);
            if (ds != null && ds.Tables.Count >= 3)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtTransPrefix.Text = ds.Tables[0].Rows[0]["S_PF"].ToString();
                    txtTransNo.Text = ds.Tables[0].Rows[0]["S_NO"].ToString();
                    txtperiod.Text = ds.Tables[0].Rows[0]["S_SF"].ToString();
                    txtEntryDate.Text = ds.Tables[0].Rows[0]["ENTRY_DATE"].ToString();
                    txtPostingDate.Text = ds.Tables[0].Rows[0]["POSTINGDATE"].ToString();
                    ddlSettlementType.SelectedValue = ds.Tables[0].Rows[0]["SETTLEMENT_TYPE"].ToString();
                    txtOrgnaizationName.Text = ds.Tables[0].Rows[0]["ORGANIZATION_NAME"].ToString();
                    txtNarration.Text = ds.Tables[0].Rows[0]["NARRATION"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    gvCredits.DataSource = ds.Tables[1];
                    gvCredits.DataBind();
                    btnSave.Enabled = false;
                    btnCreditsRetrieve.Enabled = false;
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    gvDebits.DataSource = ds.Tables[2];
                    gvDebits.DataBind();
                    ColumnHide(ddlSettlementType.SelectedValue);
                    btnDebitsRetrieve.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void gvDebits_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.CssClass = "gridFooterRow";
        }
    }

    protected void gvCredits_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.CssClass = "gridFooterRow";
        }
    }


    protected void btnCreditsRetrieve_Click(object sender, EventArgs e)
    {
        RefreshCreditsGrid();
    }
    protected void btnDebitsRetrieve_Click(object sender, EventArgs e)
    {
        RefreshDebitsGrid();
    }
    protected void btnAutoSettle_Click(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        /*decimal unsettledAmount = GetUnsettledAmount();
        if (Math.Abs(unsettledAmount) > 0.004m)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "unsettledAmountError",
                "alert('Unsettled amount of " + unsettledAmount.ToString("N2", CultureInfo.InvariantCulture) +
                " remains. Please select Bank Purchase(s) totalling this amount (or reduce the Bank Payment settlement) before saving.');",
                true);
            return;
        }*/
        Insert_Update("S", BankPayment_Grid1(), BankPurChase1());
        if (ds != null)
        {
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtTransPrefix.Text = ds.Tables[0].Rows[0]["S_PF"].ToString();
                txtTransNo.Text = ds.Tables[0].Rows[0]["S_NO"].ToString();
                txtperiod.Text = ds.Tables[0].Rows[0]["S_SF"].ToString();

                ClientScript.RegisterStartupScript(this.GetType(), "Message",
                   "alert('Selected values has been saved successfully');" +
                   "if (window.opener && !window.opener.closed && typeof window.opener.RefreshSearchGrid === 'function') {" +
                   "    window.opener.RefreshSearchGrid();" +
                   "}",
                       true);
                btnSave.Enabled = false;
            }

            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                gvCredits.DataSource = ds.Tables[1];
                gvCredits.DataBind();
                btnCreditsRetrieve.Enabled = false;
            }

            if (ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                gvDebits.DataSource = ds.Tables[2];
                gvDebits.DataBind();
                ColumnHide(ddlSettlementType.SelectedValue);
                btnDebitsRetrieve.Enabled = false;
            }
        }
    }
    private void RefreshCreditsGrid()
    {
        if (string.IsNullOrEmpty(txtOrgnaizationName.Text))
        {
            return;
        }

        _creditsOutstandingTotal = 0m;
        _creditsSettlementTotal = 0m;

        objUBO.A1 = txtOrgnaizationName.Text;
        objUBO.A2 = txtCreditsRows.Text;
        objUBO.A3 = ddlSettlementType.SelectedValue;
        objUBO.A4 = txtCreditsFromDate.Text;
        objUBO.A5 = txtCreditsToDate.Text;
        ds = Set.LoadbankPayamentByVendor(objUBO);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            gvCredits.DataSource = ds.Tables[0];
            gvCredits.DataBind();
        }
        else
        {
            gvCredits.DataSource = null;
            gvCredits.DataBind();
        }
    }
    private void RefreshDebitsGrid()
    {
        if (string.IsNullOrEmpty(txtOrgnaizationName.Text))
        {
            return;
        }
        objUBO.A1 = txtOrgnaizationName.Text;
        objUBO.A2 = txtDebitsRows.Text;
        objUBO.A3 = ddlSettlementType.SelectedValue;
        objUBO.A4 = txtDebitsFromDate.Text;
        objUBO.A5 = txtDebitsToDate.Text;
        ds = Set.LoadbankPayamentByVendor(objUBO);

        if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
        {
            gvDebits.DataSource = ds.Tables[1];
            gvDebits.DataBind();
            ColumnHide(ddlSettlementType.SelectedValue);
        }
        else
        {
            gvDebits.DataSource = null;
            gvDebits.DataBind();
            ColumnHide(ddlSettlementType.SelectedValue);
        }
    }
    public void ColumnHide(string SettlementType)
    {
        if (SettlementType == "CUSTOMER")
        {
            gvDebits.Columns[6].Visible = false;
            gvDebits.Columns[7].Visible = false;
        }
        else
        {
            gvDebits.Columns[6].Visible = true;
            gvDebits.Columns[7].Visible = true;
        }
    }
    public void Insert_Update(string Flag, string XMLData1, string XMLData2)
    {
        try
        {
            string x = Connection.WorkingPeriod();
            string[] p = x.Split('-');
            WorkingPeriod = p[2].Trim().Substring(2) + "-" + p[5].Trim().Substring(2);
            objUBO.A1 = WorkingPeriod;
            objUBO.A2 = txtOrgnaizationName.Text.Trim();
            objUBO.A3 = txtEntryDate.Text;
            objUBO.A4 = txtPostingDate.Text;
            objUBO.A5 = ddlSettlementType.SelectedValue;
            objUBO.A6 = ddlTDS.SelectedValue;
            objUBO.A7 = txtNarration.Text;
            objUBO.A8 = XMLData1;
            objUBO.A9 = XMLData2;
            objUBO.A10 = Flag;
            ds = Set.Settlement_Entry_Insert_Update(objUBO);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public string BankPayment_Grid1()
    {
        string xmlData1 = "";
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Checked", typeof(Boolean)));
            dt.Columns.Add(new DataColumn("C_LOCATION", typeof(string)));
            dt.Columns.Add(new DataColumn("DOCUMENT", typeof(string)));
            dt.Columns.Add(new DataColumn("TRANSNO", typeof(string)));
            dt.Columns.Add(new DataColumn("C_DATE", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("TRANSACTIONAMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("OUTSTANDINGAMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("SETTLEMENTAMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("BALANCEAMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("BRANCH", typeof(string)));
            dt.Columns.Add(new DataColumn("NARRATION", typeof(string)));

            foreach (GridViewRow row in gvCredits.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow)
                {
                    continue;
                }
                CheckBox chk = (CheckBox)row.FindControl("chkSelectCredit");
                if (chk == null || !chk.Checked)
                {
                    continue;
                }

                Literal txtlocation = (Literal)row.FindControl("txtLocation");
                Literal txt_document = (Literal)row.FindControl("txtDocument");
                Literal txtTransNo = (Literal)row.FindControl("txtTransNo");
                Literal txtTxndate = (Literal)row.FindControl("txtTxndate");
                Literal txtTransactionAmount = (Literal)row.FindControl("txtTransactionAmount");
                TextBox txtCreditSettlement = (TextBox)row.FindControl("txtCreditSettlement");
                HiddenField hdnOutstanding = (HiddenField)row.FindControl("hdnOutstanding");
                HiddenField hdnBalance = (HiddenField)row.FindControl("hdnBalance");
                Literal txtBranch = (Literal)row.FindControl("txtBranch");
                Label txtNarration = (Label)row.FindControl("txtNarration");

                DataRow dr = dt.NewRow();
                dr["Checked"] = chk.Checked;
                dr["C_LOCATION"] = txtlocation.Text ?? "";
                dr["DOCUMENT"] = txt_document.Text ?? "";
                dr["TRANSNO"] = txtTransNo.Text ?? "";
                dr["C_DATE"] = ParseDateOrDefault(txtTxndate.Text);
                dr["TRANSACTIONAMOUNT"] = txtTransactionAmount.Text ?? "";
                dr["OUTSTANDINGAMOUNT"] = hdnBalance.Value ?? "";
                dr["SETTLEMENTAMOUNT"] = txtCreditSettlement.Text ?? "";
                dr["BALANCEAMOUNT"] = hdnBalance.Value ?? "";
                dr["BRANCH"] = txtBranch.Text ?? "";
                dr["NARRATION"] = txtNarration.Text ?? "";
                dt.Rows.Add(dr);
            }
            xmlData1 = Common_CS.ConvertDataTableToXML(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return xmlData1;
    }
    public string BankPurChase1()
    {
        string XMLData2 = "";
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Checked", typeof(Boolean)));
            dt.Columns.Add(new DataColumn("V_LOCATION", typeof(string)));
            dt.Columns.Add(new DataColumn("DOCUMENT", typeof(string)));
            dt.Columns.Add(new DataColumn("TRANSNO", typeof(string)));
            dt.Columns.Add(new DataColumn("V_DATE", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("JOBS", typeof(string)));
            dt.Columns.Add(new DataColumn("REFNO", typeof(string)));
            dt.Columns.Add(new DataColumn("REFDATE", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("TRANSACTIONAMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("OUTSTANDINGAMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("SETTLEMENT", typeof(string)));
            dt.Columns.Add(new DataColumn("BALANCEAMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("TDS", typeof(string)));
            dt.Columns.Add(new DataColumn("BRANCH", typeof(string)));
            dt.Columns.Add(new DataColumn("NARRATION", typeof(string)));
            foreach (GridViewRow row in gvDebits.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow)
                {
                    continue;
                }
                CheckBox chk = (CheckBox)row.FindControl("chkSelectDebit");
                if (chk == null || !chk.Checked)
                {
                    continue;
                }
                Literal LitLocation2 = (Literal)row.FindControl("txtLocation2");
                Literal lit_GvDebitDocument = (Literal)row.FindControl("txtGvDebitDocument");
                Literal lit_GvDebit_TransNo = (Literal)row.FindControl("txtGvDebit_TransNo");
                Literal Lit_Debit_TxnDate = (Literal)row.FindControl("txtDebit_TxnDate");
                Literal Lit_Debit_jobs = (Literal)row.FindControl("txtDebit_jobs");
                Literal Lit_RefNo = (Literal)row.FindControl("txtRefNo");
                Literal Lit_RefDate = (Literal)row.FindControl("txtRefDate");

                Literal txt_TransctionAmt = (Literal)row.FindControl("lit_GvDebit_transAmt");
                Literal lit_lDebitOutstanding = (Literal)row.FindControl("lblDebitOutstanding");
                TextBox txtDebitSettleINR = (TextBox)row.FindControl("txtDebitSettleINR");
                Literal lit_DebitBalance = (Literal)row.FindControl("lblDebitBalance");

                HiddenField hdnDebitBalance = (HiddenField)row.FindControl("hdnDebitbalanceAmount");
                TextBox txtGvDebitsTDS = (TextBox)row.FindControl("txtGvDebitsTDS");
                Literal LitGvDebitBranch = (Literal)row.FindControl("LitGvDebitBranch");
                Label LtlGvDebitNarration = (Label)row.FindControl("LtlGvDebitNarration");
                DataRow dr = dt.NewRow();

                dr["Checked"] = chk.Checked;
                dr["V_LOCATION"] = LitLocation2.Text;
                dr["DOCUMENT"] = lit_GvDebitDocument.Text;
                dr["TRANSNO"] = lit_GvDebit_TransNo.Text;
                dr["V_DATE"] = Lit_Debit_TxnDate.Text;
                dr["JOBS"] = Lit_Debit_jobs.Text;
                if (ddlSettlementType.SelectedValue == "VENDOR")
                {
                    dr["REFNO"] = Lit_RefNo.Text;
                    dr["REFDATE"] = Lit_RefDate.Text;
                }
                else
                {
                    dr["REFNO"] = string.Empty;
                    dr["REFDATE"] = DBNull.Value;
                }
                dr["TRANSACTIONAMOUNT"] = txt_TransctionAmt.Text;
                dr["OUTSTANDINGAMOUNT"] = hdnDebitBalance != null ? hdnDebitBalance.Value : lit_lDebitOutstanding.Text;
                dr["SETTLEMENT"] = txtDebitSettleINR.Text;
                dr["BALANCEAMOUNT"] = hdnDebitBalance != null ? hdnDebitBalance.Value : lit_DebitBalance.Text;
                dr["TDS"] = txtGvDebitsTDS.Text;
                dr["BRANCH"] = LitGvDebitBranch.Text;
                dr["NARRATION"] = LtlGvDebitNarration.Text;
                dt.Rows.Add(dr);
            }
            XMLData2 = Common_CS.ConvertDataTableToXML(dt);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return XMLData2;
    }

    private DateTime ParseDateOrDefault(string s)
    {
        DateTime dt;
        if (DateTime.TryParse(s, out dt))
            return dt;
        return new DateTime(1900, 1, 1);
    }

    protected void gvCredits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var dataItem = (DataRowView)e.Row.DataItem;

            decimal txnAmt = Convert.ToDecimal(dataItem["TRANSACTIONAMOUNT"]);
            decimal outstandingAmt = Convert.ToDecimal(dataItem["OUTSTANDINGAMOUNT"]); // 0 = fresh/never-settled row; >0 = has settlement history
            decimal settleAmt = Convert.ToDecimal(dataItem["SETTLEMENTAMOUNT"]);       // historical, kept only for footer total

            decimal calcBase = outstandingAmt;

            _creditsOutstandingTotal += outstandingAmt;
            _creditsSettlementTotal += settleAmt;

            // Outstanding Amount is set ONCE here and never touched again — not by JS, not by typing.
            var litOutstanding = (Literal)e.Row.FindControl("txtOutstandingAmount");
            if (litOutstanding != null) litOutstanding.Text = outstandingAmt.ToString("N2");

            var txtSettle = (TextBox)e.Row.FindControl("txtCreditSettlement");
            if (txtSettle != null)
            {
                // txtSettle.Text = "";  // always blank on load — this is a NEW settlement entry, not editing an old one
                txtSettle.Attributes["data-txn"] = txnAmt.ToString(CultureInfo.InvariantCulture);
                txtSettle.Attributes["data-outstanding"] = outstandingAmt.ToString(CultureInfo.InvariantCulture);
                txtSettle.Attributes["data-calcbase"] = calcBase.ToString(CultureInfo.InvariantCulture); // JS uses ONLY this for Balance math
            }

            // Balance starts equal to calcBase (Settlement is blank/0 at this point)
            var litBalance = (Literal)e.Row.FindControl("txtBalance");
            if (litBalance != null) litBalance.Text = calcBase.ToString("N2");

            // hdnOutstanding mirrors the displayed Outstanding Amount (audit/reference only)
            var hdnOutstanding = (HiddenField)e.Row.FindControl("hdnOutstanding");
            if (hdnOutstanding != null) hdnOutstanding.Value = outstandingAmt.ToString("N2");

            // hdnBalance is the live Balance — THIS is what gets saved as next load's Outstanding Amount
            var hdnBalance = (HiddenField)e.Row.FindControl("hdnBalance");
            if (hdnBalance != null) hdnBalance.Value = calcBase.ToString("N2");
            CheckBox chkSelectCredit = (CheckBox)e.Row.FindControl("chkSelectCredit");
            if (chkSelectCredit != null && dataItem["Checked"] != DBNull.Value)
            {
                chkSelectCredit.Checked = Convert.ToBoolean(dataItem["Checked"]);
            }

            Label lblNarration = (Label)e.Row.FindControl("txtNarration");
            string gvCreditnarration = DataBinder.Eval(e.Row.DataItem, "NARRATION").ToString();
            lblNarration.ToolTip = gvCreditnarration;
            if (gvCreditnarration.Length > 45)
            {
                lblNarration.Text = gvCreditnarration.Substring(0, 45) + "..";
            }
            else
            {
                lblNarration.Text = gvCreditnarration;
            }
        }
    }
    protected void gvCredits_DataBound(object sender, EventArgs e)
    {
        lblCreditsTotal.Text = "0.00";
    }


    protected void gvDebits_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var dataItem = (DataRowView)e.Row.DataItem;

            decimal txnAmt = dataItem["TRANSACTIONAMOUNT"] != DBNull.Value ? Convert.ToDecimal(dataItem["TRANSACTIONAMOUNT"]) : 0M;
            decimal outstandingAmt = dataItem["OUTSTANDINGAMOUNT"] != DBNull.Value ? Convert.ToDecimal(dataItem["OUTSTANDINGAMOUNT"]) : 0M; // 0 = fresh/never-settled row; >0 = has settlement history
            decimal settleAmt = dataItem["SETTLEMENT"] != DBNull.Value ? Convert.ToDecimal(dataItem["SETTLEMENT"]) : 0M;             // historical, kept only for footer total
            decimal tdsAmt = dataItem["TDS"] != DBNull.Value ? Convert.ToDecimal(dataItem["TDS"]) : 0m;


            decimal calcBase = outstandingAmt;

            _debitsOutstandingTotal += calcBase;
            _debitsSettlementTotal += settleAmt;
            _debitsBalanceTotal += calcBase;
            _totalDebitTDS += tdsAmt;

            var litOutstanding = (Literal)e.Row.FindControl("lblDebitOutstanding");
            if (litOutstanding != null) litOutstanding.Text = calcBase.ToString("N2");

            var hdnOutstanding = (HiddenField)e.Row.FindControl("hdnDebitOutstandingAmount");
            if (hdnOutstanding != null) hdnOutstanding.Value = calcBase.ToString("N2");

            var txtSettle = (TextBox)e.Row.FindControl("txtDebitSettleINR");
            if (txtSettle != null)
            {
                // txtSettle.Text = "";  // blank on load — new settlement entry; filled live by JS credit-pool allocation
                txtSettle.Attributes["data-txn"] = txnAmt.ToString(CultureInfo.InvariantCulture);
                txtSettle.Attributes["data-outstanding"] = outstandingAmt.ToString(CultureInfo.InvariantCulture);
                txtSettle.Attributes["data-calcbase"] = calcBase.ToString(CultureInfo.InvariantCulture); // JS balance math + credit-pool allocation both key off this
            }

            var litBalance = (Literal)e.Row.FindControl("lblDebitBalance");
            if (litBalance != null) litBalance.Text = calcBase.ToString("N2");

            var hdnBalance = (HiddenField)e.Row.FindControl("hdnDebitbalanceAmount");
            if (hdnBalance != null) hdnBalance.Value = calcBase.ToString("N2");

            var txtTds = (TextBox)e.Row.FindControl("txtGvDebitsTDS");
            if (txtTds != null)
            {
                txtTds.Text = tdsAmt.ToString("N2");
                txtTds.Attributes["data-tds-original"] = tdsAmt.ToString(CultureInfo.InvariantCulture);
            }
            CheckBox chkSelectDebit = (CheckBox)e.Row.FindControl("chkSelectDebit");
            if (chkSelectDebit != null && dataItem["Checked"] != DBNull.Value)
            {
                chkSelectDebit.Checked = Convert.ToBoolean(dataItem["Checked"]);
            }

            Label lblgvDebitnarration = (Label)e.Row.FindControl("LtlGvDebitNarration");
            string Debitnarration = DataBinder.Eval(e.Row.DataItem, "NARRATION").ToString();
            lblgvDebitnarration.ToolTip = Debitnarration;
            if (Debitnarration.Length > 45)
            {
                lblgvDebitnarration.Text = Debitnarration.Substring(0, 45) + "...";
            }
            else
            {
                lblgvDebitnarration.Text = Debitnarration;
            }
        }
    }

    protected void gvDebits_DataBound(object sender, EventArgs e)
    {
        if (gvDebits.FooterRow != null)
        {
            var lblOutstandingTotal = (Label)gvDebits.FooterRow.FindControl("lblDebitsOutstandingTotal");
            var lblSettlementTotal = (Label)gvDebits.FooterRow.FindControl("lblDebitsSettlementTotal");
            var lblBalanceTotal = (Label)gvDebits.FooterRow.FindControl("lblDebitsBalanceTotal");

            if (lblOutstandingTotal != null) lblOutstandingTotal.Text = _debitsOutstandingTotal.ToString("N2");
            if (lblSettlementTotal != null) lblSettlementTotal.Text = _debitsSettlementTotal.ToString("N2");
            if (lblBalanceTotal != null) lblBalanceTotal.Text = _debitsBalanceTotal.ToString("N2");
        }

    }

    private void Load_Group_Name()
    {
        ddlCreditsLocation.Items.Clear();
        if (Session["ClientGrpMst"] != null)
        {
            DataSet ds = (DataSet)Session["ClientGrpMst"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCreditsLocation.DataSource = ds.Tables[0];
                ddlCreditsLocation.DataTextField = "GROUP_NAME";
                ddlCreditsLocation.DataValueField = "GROUP_ID";
                ddlCreditsLocation.DataBind();
                //Second grid Loacation dropdown
                ddlDebitsLocation.DataSource = ds.Tables[0];
                ddlDebitsLocation.DataTextField = "GROUP_NAME";
                ddlDebitsLocation.DataValueField = "GROUP_ID";
                ddlDebitsLocation.DataBind();
            }

        }
        ddlCreditsLocation.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlCreditsLocation.SelectedIndex = 0;
        ddlDebitsLocation.Items.Insert(0, new ListItem(String.Empty, String.Empty));
        ddlDebitsLocation.SelectedIndex = 0;
    }


    [System.Web.Services.WebMethod]
    public static List<string> ClientNameAutoSearch(string Name, string ddlvalue)
    {
        List<string> ClientName = new List<string>();
        try
        {
            Settlement_cs set = new Settlement_cs();
            Global_variables objUBO = new Global_variables();
            DataSet dss = new DataSet();
            objUBO.A6 = ddlvalue;
            objUBO.A7 = Name;
            dss = set.LoadSettlementEntrySearch(objUBO);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dss.Tables[0].Rows)
                {
                    ClientName.Add(dr["IMP_EXP_NAME"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
        return ClientName;
    }
    private decimal GetUnsettledAmount()
    {
        decimal creditsTotal = 0m;
        foreach (GridViewRow row in gvCredits.Rows)
        {
            if (row.RowType != DataControlRowType.DataRow)
            {
                continue;
            }
            CheckBox chk = (CheckBox)row.FindControl("chkSelectCredit");
            if (chk == null || !chk.Checked)
            {
                continue;
            }

            TextBox txtCreditSettlement = (TextBox)row.FindControl("txtCreditSettlement");
            decimal val;
            if (txtCreditSettlement != null && decimal.TryParse(txtCreditSettlement.Text, out val))
            {
                creditsTotal += val;
            }
        }

        decimal debitsTotal = 0m;
        foreach (GridViewRow row in gvDebits.Rows)
        {
            if (row.RowType != DataControlRowType.DataRow) continue;
            CheckBox chk = (CheckBox)row.FindControl("chkSelectDebit");
            if (chk == null || !chk.Checked)
            {
                continue;
            }

            TextBox txtDebitSettleINR = (TextBox)row.FindControl("txtDebitSettleINR");
            TextBox txtGvDebitsTDS = (TextBox)row.FindControl("txtGvDebitsTDS");
            decimal settleVal, tdsVal;
            decimal.TryParse(txtDebitSettleINR.Text, out settleVal);
            decimal.TryParse(txtGvDebitsTDS.Text, out tdsVal);
            debitsTotal += settleVal + tdsVal;
        }

        return creditsTotal - debitsTotal;
    }

}