using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Multiple_Inv_Split_Export : ThemeClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!Page.IsPostBack)
        {
            if (Session["EXPORT_JOBNO"] != null)
            {
                Load_Inv();
            }
        }

        txtFRT_Currency.Attributes.Add("onblur","ChangeCase(this); ValidateCurr(this,'Freight'); Call_Excahnge_Rate('" + txtFRT_Currency.ClientID + "', '" + txtFRT_ExRate.ClientID + "');");
        txtIns_Currency.Attributes.Add("onblur","ChangeCase(this); ValidateCurr(this,'Insurance'); Call_Excahnge_Rate('" + txtIns_Currency.ClientID + "', '" + txtINS_ExRate.ClientID + "');");
    }

    AppSession aps = new AppSession();

    private void Load_Inv()
    {
        DataTable dt = new DataTable();

        Exp_Invcopy EI = new Exp_Invcopy();
        EI.Jobno = Session["EXPORT_JOBNO"].ToString();
        EI.Flag = "EXP_Inv_Select";

        DataSet ds = EI.Exp_Multiple_Inv_Select();

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Details.DataSource = ds.Tables[0];
            gv_Details.DataBind();

            ddl_INS_AMT_RATE.SelectedValue = "Amt";

            string firstTerms = ds.Tables[0].Rows[0]["TERMS"].ToString();
            string invCurr = ds.Tables[0].Rows[0]["INVOICE_CURRENCY"].ToString();

            // Freight currency — auto-fill from invoice currency
            txtFRT_Currency.Text = (firstTerms == "CIF" || firstTerms == "CF")
                ? invCurr : string.Empty;

            txtFRT_ExRate.Text = (firstTerms == "CIF" || firstTerms == "CF")
                ? ds.Tables[0].Rows[0]["FREIGHT_EXRATE"].ToString() : string.Empty;

            // Insurance currency — auto-fill from invoice currency
            txtIns_Currency.Text = (firstTerms == "CIF" || firstTerms == "CI")
                ? invCurr : string.Empty;

            txtINS_ExRate.Text = (firstTerms == "CIF" || firstTerms == "CI")
                ? ds.Tables[0].Rows[0]["INSURANCE_EXRATE"].ToString() : string.Empty;

            txt_tot_Freight_Chrg.Text = string.Empty;
            txt_tot_Ins_Chrg.Text = string.Empty;
        }
        else
        {
            gv_Details.DataSource = dt;
            gv_Details.DataBind();
        }

        // Table[1] = total invoice value (the read-only Tot.Inv box)
        if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            txt_tot_inv_amt.Text = ds.Tables[1].Rows[0]["INVOICE_VALUE"].ToString();
        else
            txt_tot_inv_amt.Text = string.Empty;

        txt_tot_Freight_Chrg.Focus();
    }
    
    // ----------------------------GRID EVENTS--------------------------------------
    
    protected void gv_Details_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header) e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal) e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate) e.Row.CssClass = "alternate";
    }

    protected void gv_Details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl_Inv_Terms = (DropDownList)e.Row.FindControl("ddl_Inv_Terms");
            if (ddl_Inv_Terms != null)
                ApplyTermsRule(e.Row, ddl_Inv_Terms.SelectedValue);

            HideHelperCells(e.Row);
        }
    }

    private void HideHelperCells(GridViewRow row)
    {
        int[] helperCols = { 10, 11, 12, 13 };
        foreach (int c in helperCols)
        {
            if (c < row.Cells.Count)
            {
                row.Cells[c].Attributes["style"] = "display:none;";
            }
        }
    }

    // user changed the Terms dropdown for one invoice row - re-apply the enable/disable rule live
    protected void ddl_Inv_Terms_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.NamingContainer;
        ApplyTermsRule(row, ddl.SelectedValue);
    }

    private void ApplyTermsRule(GridViewRow row, string terms)
    {
        TextBox txt_Frt_Amt = (TextBox)row.FindControl("txt_Frt_Amt");
        DropDownList ddl_Ins_A_R = (DropDownList)row.FindControl("ddl_Ins_A_R");
        TextBox txt_Ins_Rate = (TextBox)row.FindControl("txt_Ins_Rate");
        TextBox txt_Ins_Amt = (TextBox)row.FindControl("txt_Ins_Amt");

        bool frtEnabled = (terms == "CIF" || terms == "CF");
        bool insEnabled = (terms == "CIF" || terms == "CI");

        if (txt_Frt_Amt != null)
        {
            txt_Frt_Amt.Enabled = frtEnabled;
            if (!frtEnabled) txt_Frt_Amt.Text = string.Empty;
        }
        if (ddl_Ins_A_R != null) ddl_Ins_A_R.Enabled = insEnabled;
        if (txt_Ins_Rate != null)
        {
            txt_Ins_Rate.Enabled = insEnabled;
            if (!insEnabled) txt_Ins_Rate.Text = string.Empty;
        }
        if (txt_Ins_Amt != null)
        {
            txt_Ins_Amt.Enabled = insEnabled;
            if (!insEnabled) txt_Ins_Amt.Text = string.Empty;
        }
    }
    // ---------------------------------------------------------------------
    // CONVERT TO UPDATE  (the proportional split itself)
    // ---------------------------------------------------------------------
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (hdn_valid.Value != "")
        {
            Alert_msg("Please fill the Currency / Exchange rate for the amount you entered.");
            return;
        }

        if (gv_Details.Rows.Count == 0)
        {
            Alert_msg("No invoice to update.");
            return;
        }

        DataTable dtt = new DataTable();
        dtt.Columns.Add("INVOICE_SLNO", typeof(string));
        dtt.Columns.Add("BRANCH_CODE", typeof(string));
        dtt.Columns.Add("TERMS", typeof(string));
        dtt.Columns.Add("FREIGHT_CURRENCY", typeof(string));
        dtt.Columns.Add("FREIGHT_EXRATE", typeof(string));
        dtt.Columns.Add("FREIGHT_CHARGES", typeof(string));
        dtt.Columns.Add("INSURANCE_CURRENCY", typeof(string));
        dtt.Columns.Add("INSURANCE_EXRATE", typeof(string));
        dtt.Columns.Add("INSURANCE_RATE", typeof(string));
        dtt.Columns.Add("INSURANCE_CHARGES", typeof(string));

        bool frtTotalEntered = txt_tot_Freight_Chrg.Text.Trim() != string.Empty;
        bool insTotalEntered = txt_tot_Ins_Chrg.Text.Trim() != string.Empty;
        bool insRateMode = ddl_INS_AMT_RATE.SelectedItem.Text == "Rate";

        double frtExRate = Currency_Converter_NEW(txtFRT_Currency.Text, ParseDouble(txtFRT_ExRate.Text));
        double insExRate = Currency_Converter_NEW(txtIns_Currency.Text, ParseDouble(txtINS_ExRate.Text));

        double totalInvValueInFrtCurr = 0.0;
        double totalInvValueInInsCurr = 0.0;

        foreach (GridViewRow row in gv_Details.Rows)
        {
            string terms = GetTerms(row);
            double invVal = ParseDouble(row.Cells[3].Text);
            double invExRate = Currency_Converter_NEW(GetInvoiceCurrency(row), ParseDouble(row.Cells[11].Text));

            if (frtTotalEntered && (terms == "CIF" || terms == "CF"))
                totalInvValueInFrtCurr += Convert_Currency_Amount(invVal, invExRate, frtExRate);

            // only needed for Insurance "Amt" mode - "Rate" mode is computed per-row directly
            if (insTotalEntered && !insRateMode && (terms == "CIF" || terms == "CI"))
                totalInvValueInInsCurr += Convert_Currency_Amount(invVal, invExRate, insExRate);
        }

        // ---------- Pass 2: compute each invoice's individual share and write it back ----------
        foreach (GridViewRow row in gv_Details.Rows)
        {
            string slno = gv_Details.DataKeys[row.RowIndex].Value.ToString();
            string terms = GetTerms(row);
            string branchCode = CellText(row, 10);
            double invVal = ParseDouble(row.Cells[3].Text);
            string invCurr = GetInvoiceCurrency(row);
            double invExRate = Currency_Converter_NEW(invCurr, ParseDouble(row.Cells[11].Text));

            bool frtEligible = (terms == "CIF" || terms == "CF");
            bool insEligible = (terms == "CIF" || terms == "CI");

            string frtCharges = string.Empty;
            string insRate = string.Empty;
            string insCharges = string.Empty;

            if (frtEligible && frtTotalEntered && totalInvValueInFrtCurr > 0)
            {
                double thisInvInFrtCurr = Convert_Currency_Amount(invVal, invExRate, frtExRate);
                double individualFrt = ParseDouble(txt_tot_Freight_Chrg.Text) * (thisInvInFrtCurr / totalInvValueInFrtCurr);
                frtCharges = Math.Round(individualFrt, 2).ToString();
            }


            if (insEligible && insTotalEntered)
            {
                if (insRateMode)
                {

                    double ratePct = ParseDouble(txt_tot_Ins_Chrg.Text);
                    double thisInvInInsCurr = Convert_Currency_Amount(invVal, invExRate, insExRate);
                    double individualIns = thisInvInInsCurr * ratePct / 100.0;

                    insRate = ratePct.ToString();
                    insCharges = Math.Round(individualIns, 2).ToString();
                }
                else if (totalInvValueInInsCurr > 0)
                {
                    double thisInvInInsCurr = Convert_Currency_Amount(invVal, invExRate, insExRate);
                    double individualIns = ParseDouble(txt_tot_Ins_Chrg.Text) * (thisInvInInsCurr / totalInvValueInInsCurr);
                    insCharges = Math.Round(individualIns, 2).ToString();
                }
            }

            DataRow dr = dtt.NewRow();
            dr["INVOICE_SLNO"] = slno;
            dr["BRANCH_CODE"] = branchCode;
            dr["TERMS"] = terms;
            dr["FREIGHT_CURRENCY"] = frtEligible ? txtFRT_Currency.Text : string.Empty;
            dr["FREIGHT_EXRATE"] = frtEligible ? txtFRT_ExRate.Text : string.Empty;
            dr["FREIGHT_CHARGES"] = frtCharges;
            dr["INSURANCE_CURRENCY"] = insEligible ? txtIns_Currency.Text : string.Empty;
            dr["INSURANCE_EXRATE"] = insEligible ? txtINS_ExRate.Text : string.Empty;
            dr["INSURANCE_RATE"] = insRate;
            dr["INSURANCE_CHARGES"] = insCharges;
            dtt.Rows.Add(dr);

            TextBox txt_Frt_Amt = (TextBox)row.FindControl("txt_Frt_Amt");
            TextBox txt_Ins_Rate = (TextBox)row.FindControl("txt_Ins_Rate");
            TextBox txt_Ins_Amt = (TextBox)row.FindControl("txt_Ins_Amt");
            if (frtEligible && txt_Frt_Amt != null) txt_Frt_Amt.Text = frtCharges;
            if (insEligible)
            {
                if (txt_Ins_Rate != null) txt_Ins_Rate.Text = insRate;
                if (txt_Ins_Amt != null) txt_Ins_Amt.Text = insCharges;
            }
        }

        string xml = ConvertDataTableToXML(dtt);

        Exp_Invcopy EI = new Exp_Invcopy();
        EI.Jobno = Session["EXPORT_JOBNO"].ToString();
        EI.Xml_D = xml;
        EI.Flag = "EXP_Update_Multi_Inv_Update";
        EI.FRT_tot_Amt = txt_tot_Freight_Chrg.Text;
        EI.FRT_Curr = txtFRT_Currency.Text;
        EI.FRT_Exrate = txtFRT_ExRate.Text;
        EI.INS_AMT_RATE_FLAG = ddl_INS_AMT_RATE.SelectedItem.Text;
        EI.INS_tot_Amt = txt_tot_Ins_Chrg.Text;
        EI.INS_Curr = txtIns_Currency.Text;
        EI.INS_Exrate = txtINS_ExRate.Text;

        EI.Exp_Multiple_Inv_Select();

        Alert_msg("Updated Successfully.");
        Load_Inv();
    }

    private string GetTerms(GridViewRow row)
    {
        DropDownList ddl = (DropDownList)row.FindControl("ddl_Inv_Terms");
        return ddl != null ? ddl.SelectedValue : string.Empty;
    }

    private string GetInvoiceCurrency(GridViewRow row)
    {
        Label lbl = (Label)row.FindControl("lbl_Invoice_Curr");
        return lbl != null ? lbl.Text : string.Empty;
    }

    private string CellText(GridViewRow row, int cellIndex)
    {
        return row.Cells[cellIndex].Text.Replace("&nbsp;", "").Trim();
    }

    private double ParseDouble(string s)
    {
        s = (s ?? string.Empty).Replace("&nbsp;", "").Trim();
        double d;
        return double.TryParse(s, out d) ? d : 0.0;
    }

    public double Convert_Currency_Amount(double inv_val, double exRate, double target_ExRate)
    {
        double _amt = inv_val * exRate;
        return target_ExRate != 0 ? _amt / target_ExRate : 0.0;
    }

    public double Currency_Converter_NEW(string curr, double exRate)
    {
        if (curr == "JPY" || curr == "KRW") return exRate / 100.0;
        return exRate;
    }

    private static string ConvertDataTableToXML(DataTable dtData)
    {
        DataSet dsData = new DataSet();
        System.Text.StringBuilder sbSQL = new System.Text.StringBuilder();
        System.IO.StringWriter swSQL = new System.IO.StringWriter(sbSQL);

        dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
        dsData.Tables[0].TableName = "SampleDataTable";
        foreach (DataColumn col in dsData.Tables[0].Columns)
            col.ColumnMapping = MappingType.Attribute;

        dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
        return sbSQL.ToString();
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Multi Split', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    [System.Web.Services.WebMethod]

    public static string GetExchange_Rate(string custid)
    {
        if (custid.Length == 3)
        {
            Auto_Search Auto = new Auto_Search();
            Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
            Auto.Enamesearch = custid;
            DataSet ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();

            if (ds.Tables[0].Rows.Count > 0)
            {
                custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
            }
            else
            {
                Auto.Ename = "NON_STD_CUR_RATE_EXPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                custid = ds.Tables[0].Rows.Count > 0 ? ds.Tables[0].Rows[0]["NON_STD_RATE_EXPORT"].ToString() : string.Empty;
            }
        }
        else
        {
            custid = string.Empty;
        }
        return custid;
    }

} 
