using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;



public partial class Billing_Imp_Debitnote : ThemeClass
{
    public string currentuser;
    public string currentbranch;
    public string Working_Period;

    User_Creation user_Create = new User_Creation();
    AppSession aps = new AppSession();

    GST_Imp_Invoice BI = new GST_Imp_Invoice();
    Billing_UserBO ObjUBO = new Billing_UserBO();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //CalendarExtender1.EndDate = DateTime.Now;
        DataSet ds = new DataSet();
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        if (!IsPostBack)
        {
            txtdate.Text = DateTime.Now.ToString();
            txtPartyname.Focus();
            if (Request.QueryString["DEBIT_NOTE_NO"] != null && Request.QueryString["DEBIT_NOTE_NO"] != string.Empty)
            {
                Update_Item_Load();
                
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            //ObjUBO.CREDIT_NOTE_NO = txtCreditNoteno.Text;
            //ObjUBO.PARTY_NAME = txtPartyname.Text;            
            ObjUBO.ENAME = "CRID";

            ObjUBO.WORKING_PERIOD = Working_Period;
            ds = BI.DebitNoteSelect(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtDebitNoteno.Text = "DN/" + ds.Tables[0].Rows[0][0].ToString() + "/20-21";
            }
            //    else { Alert_msg("Must set prefix sufix"); }

            //    txtInvoiceCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExrate.ClientID + "')");



            //    txtInvoiceCurrency.Text = "INR";
            //    txtExrate.Text = "1";
            //    txtVoucherdate.Text = DateTime.Now.ToShortDateString();
                //Rownum = 1;
                ViewState["RowNumber"] = 1;
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                DropDownList drp = new DropDownList();
                dt.Columns.Add(new DataColumn("SNo", typeof(string)));
                dt.Columns.Add(new DataColumn("INCOME_CHARGE_NAME", typeof(string)));
                dt.Columns.Add(new DataColumn("SAC_Code", typeof(string)));
                dt.Columns.Add(new DataColumn("Tax_Rate", typeof(string)));
                dt.Columns.Add(new DataColumn("Amount", typeof(string)));
                //dt.Columns.Add(new DataColumn("Credit", typeof(string)));
                //dt.Columns.Add(new DataColumn("Debit", typeof(string)));
                dt.Columns.Add(new DataColumn("CGST_AMT", typeof(string)));
                dt.Columns.Add(new DataColumn("SGST_AMT", typeof(string)));
                dt.Columns.Add(new DataColumn("IGST_AMT", typeof(string)));
                //dt.Columns.Add(new DataColumn("TDS", typeof(string)));
                //dt.Columns.Add(new DataColumn("TDS_Amount", typeof(string)));
                //dt.Columns.Add(new DataColumn("FileUp", typeof(string)));
                dt.Rows.Add(dr);
               
                dr["SNo"] = ViewState["RowNumber"].ToString();

                ViewState["CurrentTable"] = dt;
                gvdetails.Visible = true;
                //gvbind.Visible = false;
                gvdetails.DataSource = dt;
                gvdetails.DataBind();



            }
        }
    }
    private void AddNewRow()
    {


        int rowIndex = 0;
        decimal totalAmount = 0;
        //decimal totaldebit = 0;
        decimal totalcgst = 0;
        decimal totalsgst = 0;
        decimal totaligst = 0;
        decimal totaltds = 0;
        decimal total = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                int Slno = 1;
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //TextBox txtgSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txtgSLNo");
                    
                    TextBox txtgCharhead = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtgCharHead");
                    TextBox txtgSaccode = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtgSaccode");
                    TextBox txtgTaxrate = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtgTaxrate");
                    TextBox txtgAmount = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtgAmount");
                    //TextBox txtgDepit = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtgDebit");
                    TextBox txtgCgst = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtgCgst");
                    TextBox txtgScgst = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtgScgst");
                    TextBox txtgIgst = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtgIgst");
                    //TextBox txtgTds = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtgTds");
                    //TextBox txtgTdsamt = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgdtsamt");
                   
                    //LinkButton lnkBtn = (LinkButton)gvdetails.Rows[rowIndex].Cells[16].FindControl("LinkButton1");
                    //lnkBtn.Visible = false;
                    //file.Visible = true;

                    //byte[] bytes = null; 
                    //if (file.HasFile) 
                    //{ 
                    //    BinaryReader br = new BinaryReader(file.PostedFile.InputStream); 
                    //    bytes = br.ReadBytes((int)file.PostedFile.InputStream.Length); 
                    //    hfFile.Value = Convert.ToBase64String(bytes); 
                    //} 

                    if (txtgAmount.Text != "") { totalAmount += Convert.ToDecimal(txtgAmount.Text); }
                    if (txtgCgst.Text != "") { totalcgst += Convert.ToDecimal(txtgCgst.Text); }
                    if (txtgScgst.Text != "") { totalsgst += Convert.ToDecimal(txtgScgst.Text); }
                    if (txtgIgst.Text != "") { totaligst += Convert.ToDecimal(txtgIgst.Text); }
                    //if (txtgTdsamt.Text != "") { totaltds += Convert.ToDecimal(txtgTdsamt.Text); }
                    total = totalAmount + totalcgst + totaligst + totalsgst ;

                    drCurrentRow = dtCurrentTable.NewRow();
                    //drCurrentRow["DR_CR"] = new ListItem("DR");
                    //drCurrentRow["Imp_Exp"] = new ListItem("Imp");


                    dtCurrentTable.Rows[i - 1]["INCOME_CHARGE_NAME"] = txtgCharhead.Text;
                    dtCurrentTable.Rows[i - 1]["SAC_Code"] = txtgSaccode.Text;
                    dtCurrentTable.Rows[i - 1]["Tax_Rate"] = txtgTaxrate.Text;
                    dtCurrentTable.Rows[i - 1]["Amount"] = txtgAmount.Text;
                    //dtCurrentTable.Rows[i - 1]["Debit"] = txtgDepit.Text;
                    dtCurrentTable.Rows[i - 1]["CGST_AMT"] = txtgCgst.Text;
                    dtCurrentTable.Rows[i - 1]["SGST_AMT"] = txtgScgst.Text;
                    dtCurrentTable.Rows[i - 1]["IGST_AMT"] = txtgIgst.Text;
                    //dtCurrentTable.Rows[i - 1]["TDS"] = txtgTds.Text;
                    //dtCurrentTable.Rows[i - 1]["TDS_Amount"] = txtgTdsamt.Text;
                    //dtCurrentTable.Rows[i - 1]["FileUp"] = file.FileName;
                    //dtCurrentTable.Rows[i - 1]["FileUp"] = file.HasFile ? bytes : Convert.FromBase64String(hfFile.Value); 


                    rowIndex++;
                    Slno++;

                }


                int index = gvdetails.Rows.Count - 1;
                //TextBox txtsl = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgSLNo");

                //DropDownList drpgImpex = (DropDownList)gvdetails.Rows[index+1].Cells[5].FindControl("drpImpexp");
                //drpgImpex.Focus();
                //drCurrentRow["SNo"] = Convert.ToInt32(txtsl.Text) + 1;
                drCurrentRow["SNo"] = Slno;
                
                //ViewState["RowNumber"] = Convert.ToInt32(txtsl.Text) + 1;
                //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;

                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                gvdetails.DataSource = dtCurrentTable;
                gvdetails.DataBind();
               
                TextBox txtfAmounttotal = (TextBox)gvdetails.FooterRow.FindControl("txtAmounttotal");
                //TextBox txtfdebittotal = (TextBox)gvdetails.FooterRow.FindControl("txtdebittotal");
                TextBox txtfcgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtcgsttotal");
                TextBox txtfsgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtsgsttotal");
                TextBox txtfigsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtigsttotal");
                //TextBox txtftdstotal = (TextBox)gvdetails.FooterRow.FindControl("txttdstotal");
                txtfAmounttotal.Text = totalAmount.ToString();
                //txtfdebittotal.Text = totaldebit.ToString();
                txtfcgsttotal.Text = totalcgst.ToString();
                txtfsgsttotal.Text = totalsgst.ToString();
                txtfigsttotal.Text = totaligst.ToString();
                //txtftdstotal.Text = totaltds.ToString();

                int index1 = gvdetails.Rows.Count - 1;
                ////gvdetails.Rows[index1].Cells[1].FindControl("txtgImpSLNo").Focus();
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
                    TextBox txtgSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txtgSLNo");                    
                    TextBox txtgCharhead = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtgCharHead");
                    TextBox txtgSaccode = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtgSaccode");
                    TextBox txtgTaxrate = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtgTaxrate");
                    //TextBox txtgCredit = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgCredit");
                    TextBox txtgAmount = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtgAmount");
                    TextBox txtgCgst = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtgCgst");
                    TextBox txtgScgst = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtgScgst");
                    TextBox txtgIgst = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtgIgst");
                    //TextBox txtgTds = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtgTds");
                    //TextBox txtgTdsamt = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgdtsamt");




                    txtgSLNo.Text = Convert.ToString(i + 1);
                    txtgCharhead.Text = dt.Rows[i]["INCOME_CHARGE_NAME"].ToString();
                    txtgSaccode.Text = dt.Rows[i]["SAC_Code"].ToString();
                    txtgTaxrate.Text = dt.Rows[i]["Tax_Rate"].ToString();
                    txtgAmount.Text = dt.Rows[i]["Amount"].ToString();
                    //txtgDepit.Text = dt.Rows[i]["Debit"].ToString();
                    txtgCgst.Text = dt.Rows[i]["CGST_AMT"].ToString();
                    txtgScgst.Text = dt.Rows[i]["SGST_AMT"].ToString();
                    txtgIgst.Text = dt.Rows[i]["IGST_AMT"].ToString();
                    //txtgTds.Text = dt.Rows[i]["TDS"].ToString();
                    //txtgTdsamt.Text = dt.Rows[i]["TDS_Amount"].ToString();
                    //file.FileName = dt.Rows[i]["FileUp"].ToString();

                    //hfFile.Value = !Convert.IsDBNull(dt.Rows[i]["FileUp"]) ? Convert.ToBase64String((byte[])dt.Rows[i]["FileUp"]) : "";
                   

                    rowIndex++;
                }
            }
        }
    }
    protected void gvdetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("add"))
        {
            AddNewRow();
        }
    }
    private void SetRowData()
    {
        int rowIndex = 0;
        decimal totalAmount = 0;
        //decimal totaldebit = 0;
        decimal totalcgst = 0;
        decimal totalsgst = 0;
        decimal totaligst = 0;
        decimal totaltds = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox txtgSLNo = (TextBox)gvdetails.Rows[rowIndex].Cells[0].FindControl("txtgSLNo");                    
                    TextBox txtgCharhead = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtgCharHead");
                    TextBox txtgSaccode = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtgSaccode");
                    TextBox txtgTaxrate = (TextBox)gvdetails.Rows[rowIndex].Cells[3].FindControl("txtgTaxrate");
                    TextBox txtgAmount = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtgAmount");
                    //TextBox txtgDepit = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtgDebit");
                    TextBox txtgCgst = (TextBox)gvdetails.Rows[rowIndex].Cells[5].FindControl("txtgCgst");
                    TextBox txtgScgst = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtgScgst");
                    TextBox txtgIgst = (TextBox)gvdetails.Rows[rowIndex].Cells[7].FindControl("txtgIgst");
                    //TextBox txtgTds = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtgTds");
                    //TextBox txtgTdsamt = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgdtsamt");

                    totalAmount += Convert.ToDecimal(txtgAmount.Text);
                    if (txtgCgst.Text != "") { totalcgst += Convert.ToDecimal(txtgCgst.Text); }
                    if (txtgScgst.Text != "") { totalsgst += Convert.ToDecimal(txtgScgst.Text); }
                    if (txtgIgst.Text != "") { totaligst += Convert.ToDecimal(txtgIgst.Text); }
                    //if (txtgTdsamt.Text != "") { totaltds += Convert.ToDecimal(txtgTdsamt.Text); }
                    ViewState["Amount"] = totalAmount;
                    //ViewState["debit"] = totaldebit;
                    ViewState["cgst"] = totalcgst;
                    ViewState["sgst"] = totalsgst;
                    ViewState["igst"] = totaligst;
                    //ViewState["tdsamt"] = totaltds;

                    //TextBox txtfcredittotal = (TextBox)gvdetails.FooterRow.FindControl("txtcredittotal");
                    //TextBox txtfdebittotal = (TextBox)gvdetails.FooterRow.FindControl("txtdebittotal");
                    //TextBox txtfcgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtcgsttotal");
                    //TextBox txtfsgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtsgsttotal");
                    //TextBox txtfigsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtigsttotal");
                    //TextBox txtftdstotal = (TextBox)gvdetails.FooterRow.FindControl("txttdstotal");
                    //txtfcredittotal.Text = totalcredit.ToString();
                    //txtfdebittotal.Text = totaldebit.ToString();
                    //txtfcgsttotal.Text = totalcgst.ToString();
                    //txtfsgsttotal.Text = totalsgst.ToString();
                    //txtfigsttotal.Text = totaligst.ToString();
                    //txtftdstotal.Text = totaltds.ToString();

                    dtCurrentTable.Rows[i - 1]["SNo"] = i;
                   
                    //dtCurrentTable.Rows[i - 1]["Imp/Exp"] = txtgImpexp.Text;
                    dtCurrentTable.Rows[i - 1]["INCOME_CHARGE_NAME"] = txtgCharhead.Text;
                    dtCurrentTable.Rows[i - 1]["SAC_Code"] = txtgSaccode.Text;
                    dtCurrentTable.Rows[i - 1]["Tax_Rate"] = txtgTaxrate.Text;
                    dtCurrentTable.Rows[i - 1]["Amount"] = txtgAmount.Text;
                    //dtCurrentTable.Rows[i - 1]["Debit"] = txtgDepit.Text;
                    dtCurrentTable.Rows[i - 1]["CGST_AMT"] = txtgCgst.Text;
                    dtCurrentTable.Rows[i - 1]["SGST_AMT"] = txtgScgst.Text;
                    dtCurrentTable.Rows[i - 1]["IGST_AMT"] = txtgIgst.Text;
                    //dtCurrentTable.Rows[i - 1]["TDS"] = txtgTds.Text;
                    //dtCurrentTable.Rows[i - 1]["TDS_Amount"] = txtgTdsamt.Text;
                    rowIndex++;
                    //drCurrentRow["SNo"] = Slno;
                }

                ViewState["CurrentTable"] = dtCurrentTable;
            }
        }
    }
    protected void drpDrcr_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.NamingContainer;
        int RowIndex = Convert.ToInt32(row.RowIndex);
        //lblSelectionMessage.InnerText = RowIndex.ToString();

        foreach (GridViewRow rw in gvdetails.Rows)
        {
            if (rw.RowIndex == RowIndex)
            {
                rw.Enabled = false;
            }
        }

    }

    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.DataItem != null)
        //{
        //    TextBox txtfileref = e.Row.FindControl("txtgFileRefNo") as TextBox;
        //    TextBox txtcusname = e.Row.FindControl("txtgCusName") as TextBox;
        //    txtfileref.Attributes.Add("onblur", "javascript:CallServerside_cusname('" + txtfileref.ClientID + "', '" + txtcusname.ClientID + "')");
        //}

        //foreach (GridViewRow gv in gvdetails.Rows)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //    string customerId = e.Row.Cells[3].Text;
        //    TextBox txt_Debit = (TextBox)gv.FindControl("txtgDebit");
        //    TextBox txt_Credit = (TextBox)gv.FindControl("txtgCredit");
        //    DropDownList ddl_PaymentMethod = (DropDownList)gv.FindControl("drpDrcr");
        //    //txt_Debit.Attributes.Add("disabled", "disabled");
        //    //txt_Value.Attributes.Add("readonly", "readonly");
        //    ddl_PaymentMethod.Attributes.Add("onchange", "javascript:EnableTextbox('" + ddl_PaymentMethod.ClientID + "','" + txt_Debit.ClientID + "','" + txt_Credit.ClientID + "')");
        //    }
        //}
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //DropDownList customerId = (e.Row.FindControl("drpDrcr") as DropDownList);
            //if (customerId.Text == "CR")
            //{
            //    TextBox txtdebit = (e.Row.FindControl("txtgDebit") as TextBox);
            //    TextBox txtcredit = (e.Row.FindControl("txtgCredit") as TextBox);

            //    txtdebit.ReadOnly = true;
            //    txtcredit.ReadOnly = false;
            //}
            //else if (customerId.Text == "DR")
            //{
            //    TextBox txtdebit = (e.Row.FindControl("txtgDebit") as TextBox);
            //    TextBox txtcredit = (e.Row.FindControl("txtgCredit") as TextBox);
            //    txtdebit.ReadOnly = false;
            //    txtcredit.ReadOnly = true;
            //}
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (txtTotalamtininr.Text == txtGrandtotal.Text)
        //{
        save_update("INSERT");
            if (BI.result == 1)
            {
                //Alert_msg("Saved Successfully.");
                //Response.Write("<script>alert('Saved Successfully.');</script>");
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Saved Successfully');", true);
                string cleanMessage = "Saved Successfully".Replace("'", "\'");
                Page page = HttpContext.Current.CurrentHandler as Page;
                string script = string.Format("alert('{0}');", cleanMessage);
                if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
                }
            }
            else { Alert_msg("Not Saved"); }
        //}
        //else
        //{
        //    string cleanMessage = "Bill amount & Net amount not equal".Replace("'", "\'");
        //    Page page = HttpContext.Current.CurrentHandler as Page;
        //    string script = string.Format("alert('{0}');", cleanMessage);
        //    if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        //    {
        //        page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
        //    }
        //}
    
    }

    private void save_update(string name)
    {
        DataSet ds = new DataSet();
        ObjUBO.CREDIT_NOTE_NO = txtDebitNoteno.Text;
        ObjUBO.CREDIT_NOTE_DATE = txtdate.Text;
        ObjUBO.PARTY_NAME = txtPartyname.Text;
        ObjUBO.INV_NO = txtInvoiceno.Text;
        
        ObjUBO.USER_ID = currentuser;
        ObjUBO.BRANCH_CODE = currentbranch;
        ObjUBO.WORKING_PERIOD = Working_Period;
        //gridtodt();
        ObjUBO.XML_DETAIL = ConvertDataTableToXML(gridtodt());
        ObjUBO.ENAME = name;
        ds = BI.DebitNoteEntry(ObjUBO);
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //if (Convert.ToDecimal(txtTotalamtininr.Text) == Convert.ToDecimal(txtNetamt.Text))
        //{

            save_update("UPDATE");
            if (BI.result == 1)
            {
                //Alert_msg("Saved Successfully.");
                //Response.Write("<script>alert('Saved Successfully.');</script>");
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Saved Successfully');", true);
                string cleanMessage = "Updated Successfully".Replace("'", "\'");
                Page page = HttpContext.Current.CurrentHandler as Page;
                string script = string.Format("alert('{0}');", cleanMessage);
                if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
                {
                    page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
                }
            }
            else { Alert_msg("Not Updated"); }
        //}
        //else
        //{
        //    string cleanMessage = "Bill amount & Net amount not equal".Replace("'", "\'");
        //    Page page = HttpContext.Current.CurrentHandler as Page;
        //    string script = string.Format("alert('{0}');", cleanMessage);
        //    if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
        //    {
        //        page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
        //    }
        //}

    }
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Purchase Entry', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }
    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Purchase Entry', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
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

    private DataTable gridtodt()
    {
        DataTable dt = new DataTable();
        if (gvdetails.Rows.Count != 0)
        {
            for (int i = 0; i < gvdetails.HeaderRow.Cells.Count - 2; i++)
            {
                dt.Columns.Add(gvdetails.HeaderRow.Cells[i].Text);
            }
           


            foreach (GridViewRow row in gvdetails.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < row.Cells.Count; j++)
                {
                    if (j == 0)
                    {
                        TextBox txtgSLNo = row.FindControl("txtgSLNo") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtgSLNo.Text;
                    }
                    //else
                    //{
                    //else if (j == 1)
                    //{
                    //    DropDownList drpimexp = row.FindControl("drpImpexp") as DropDownList;
                    //    dr[gvdetails.HeaderRow.Cells[j].Text] = drpimexp.SelectedValue;

                    //}
                    //else if (j == 2)
                    //{
                    //    TextBox txtFilerefno = row.FindControl("txtgFileRefNo") as TextBox;
                    //    dr[gvdetails.HeaderRow.Cells[j].Text] = txtFilerefno.Text;
                    //}
                    //else if (j == 3)
                    //{
                    //    TextBox txtDate = row.FindControl("txtgDate") as TextBox;
                    //    dr[gvdetails.HeaderRow.Cells[j].Text] = txtDate.Text;

                    //}
                    //else if (j == 4)
                    //{
                    //    DropDownList drpcdr = row.FindControl("drpDrcr") as DropDownList;
                    //    dr[gvdetails.HeaderRow.Cells[j].Text] = drpcdr.SelectedValue;

                    //}
                    //else if (j == 5)
                    //{
                    //    TextBox txtCusname = row.FindControl("txtgCusName") as TextBox;
                    //    dr[gvdetails.HeaderRow.Cells[j].Text] = txtCusname.Text;

                    //}
                    else if (j == 1)
                    {
                        TextBox txtcharge = row.FindControl("txtgCharHead") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtcharge.Text;
                    }
                    else if (j == 2)
                    {
                        TextBox txtSaccode = row.FindControl("txtgSaccode") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtSaccode.Text;
                    }
                    else if (j == 3)
                    {
                        TextBox txtTaxrate = row.FindControl("txtgTaxrate") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtTaxrate.Text;
                    }
                    else if (j == 4)
                    {
                        TextBox txtCredit = row.FindControl("txtgAmount") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtCredit.Text;
                    }
                    //else if (j == 10)
                    //{
                    //    TextBox txtDebit = row.FindControl("txtgDebit") as TextBox;
                    //    dr[gvdetails.HeaderRow.Cells[j].Text] = txtDebit.Text;
                    //}
                    else if (j == 5)
                    {
                        TextBox txtCgst = row.FindControl("txtgCgst") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtCgst.Text;
                    }
                    else if (j == 6)
                    {
                        TextBox txtScgst = row.FindControl("txtgScgst") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtScgst.Text;
                    }
                    else if (j == 7)
                    {
                        TextBox txtIgst = row.FindControl("txtgIgst") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtIgst.Text;
                    }
                    //else if (j == 8)
                    //{
                    //    TextBox txtTds = row.FindControl("txtgTds") as TextBox;
                    //    dr[gvdetails.HeaderRow.Cells[j].Text] = txtTds.Text;
                    //}
                    //else if (j == 9)
                    //{
                    //    TextBox txtTdsamt = row.FindControl("txtgdtsamt") as TextBox;
                    //    dr[gvdetails.HeaderRow.Cells[j].Text] = txtTdsamt.Text;
                    //}
                    

                }
                dt.Rows.Add(dr);
            }

        }
        return dt;
    }
    protected void DownloadFile(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes;
        string fileName, contentType;
        ObjUBO.ENAME = "DW_SELECT";
        ObjUBO.VENDOR_BILL = Convert.ToString(id);
        //ObjUBO.VOUCHER_NO = txtVoucherno.Text;
        ds = BI.PurchaseEntry(ObjUBO);

        //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.CommandText = "select Name, Data, ContentType from tblFiles where Id=@Id";
        //        cmd.Parameters.AddWithValue("@Id", id);
        //        cmd.Connection = con;
        //        con.Open();
        //        using (SqlDataReader sdr = cmd.ExecuteReader())
        //        {
        //            sdr.Read();
        //            bytes = (byte[])sdr["Data"];
        //            contentType = sdr["ContentType"].ToString();
        //            fileName = sdr["Name"].ToString();
        //        }
        //        con.Close();
        //    }
        //}
        string f = ds.Tables[0].Rows[0]["file"].ToString();
        //contentType = System.IO.Path.GetExtension(f);
        fileName = ds.Tables[0].Rows[0]["filename"].ToString();
        contentType = System.IO.Path.GetExtension(fileName);
        switch (contentType.ToLower())
        {
            case ".doc":
                contentType = "application/vnd.ms-word";
                break;
            case ".docx":
                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                break;
            case ".xls":
                contentType = "application/vnd.ms-excel";
                break;
            case ".xlsx":
                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                break;
            case ".jpg":
                contentType = "image/jpg";
                break;
            case ".png":
                contentType = "image/png";
                break;
            case ".gif":
                contentType = "image/gif";
                break;
            case ".pdf":
                contentType = "application/pdf";
                break;
            case ".txt":
                contentType = "text/plain";
                break;
        }
        //Byte[] bytes = (Byte[])dt.Rows[0]["Data"];
        //bytes = System.Text.Encoding.ASCII.GetBytes(f);

        //bytes = (byte[])ds.Tables[0].Rows[0]["file"];
        //string byt = ds.Tables[0].Rows[0]["file"].ToString();

        //bytes = System.Text.UTF8Encoding.GetBytes(ds.Tables[0].Rows[0][0].ToString());
        //byte[] bytes;
        //BinaryFormatter bf = new BinaryFormatter();
        //MemoryStream ms = new MemoryStream();
        //bf.Serialize(ms, f);
        //bytes = ms.ToArray();
        ////System.IO.File.WriteAllBytes(fileName, bytes);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + f+"/"+fileName);
        //Response.BinaryWrite(bytes);
        //Response.Write(Encoding.UTF8.GetString(bytes)); Convert.ToBase64String(bytes)
        //Response.WriteFile(byt);
        Response.TransmitFile(Server.MapPath(f)); 
        Response.Flush();
        Response.End(); 
        //byte[] imgBytes = (byte[])row["logo"];

        //HttpContext.Current.Response.Clear();

        //HttpContext.Current.Response.Buffer = true;

        //HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));

        //HttpContext.Current.Response.Charset = "";

        //HttpContext.Current.Response.ContentType = contentType;

        //HttpContext.Current.Response.BinaryWrite(bytes);



    }  
    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate(string custid, string Inv_Curr, string Inv_Exrate)
    {
        if (custid.Length == 3)
        {
            if (custid == Inv_Curr)
            {
                custid = Inv_Exrate;
            }
            else
            {
                Auto_Search Auto = new Auto_Search();
                DataSet ds = new DataSet();
                // custid = Auto.Country_Master_FromClientSide_Calling(custid);
                Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString() + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " ";
                    custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();
                }
                else
                {
                    Auto.Ename = "NON_STD_CUR_RATE_EXPORTWISE";
                    Auto.Enamesearch = custid;
                    ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string NON_STD_RATE_EXPORT = ds.Tables[0].Rows[0]["NON_STD_RATE_EXPORT"].ToString();

                        /* hide by Chithra on 26-06-2018 - for FREIGHT EXRATE - Saved with '~' symbol
                        //string NON_STD_EFFECT_DT_EXP = ds.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString();
                        //string NON_STD_BANKNAME = ds.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                        //string NON_STD_CERTIFICATE_NO = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                        //string NON_STD_CERTIFICATE_DATE = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString();
                        //custid = NON_STD_RATE_EXPORT + "~~" + NON_STD_EFFECT_DT_EXP + "~~" + NON_STD_BANKNAME + "~~" + NON_STD_CERTIFICATE_NO + "~~" + NON_STD_CERTIFICATE_DATE;
                         */

                        custid = NON_STD_RATE_EXPORT;
                    }
                    else

                        custid = "";
                }
            }
        }
        else
        {
            custid = "";
        }
        return custid;
    }
    [System.Web.Services.WebMethod]
    public static string GetExchange_Rate_Invoice_Cur(string custid)
    {
        if (custid.Length == 3)
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            // custid = Auto.Country_Master_FromClientSide_Calling(custid);
            Auto.Ename = "EXCHANGE_MASTER_RATE_EXPORTWISE";
            Auto.Enamesearch = custid;
            ds = Auto.RetrieveAll_AUTOCOMPLETE_SEARCH();
            if (ds.Tables[0].Rows.Count > 0)
            {

                //custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString() + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " " + "~~" + " ";
                custid = ds.Tables[0].Rows[0]["EXCHANGE_RATE_EXPORT"].ToString();

            }
            else
            {
                Auto.Ename = "NON_STD_CUR_RATE_EXPORTWISE";
                Auto.Enamesearch = custid;
                ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH();
                if (ds.Tables[0].Rows.Count > 0)
                {


                    string NON_STD_RATE_EXPORT = ds.Tables[0].Rows[0]["NON_STD_RATE_EXPORT"].ToString();
                    string NON_STD_EFFECT_DT_EXP = ds.Tables[0].Rows[0]["NON_STD_EFFECT_DT_EXP"].ToString();
                    string NON_STD_BANKNAME = ds.Tables[0].Rows[0]["NON_STD_BANKNAME"].ToString();
                    string NON_STD_CERTIFICATE_NO = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_NO"].ToString();
                    string NON_STD_CERTIFICATE_DATE = ds.Tables[0].Rows[0]["NON_STD_CERTIFICATE_DATE"].ToString();

                    custid = NON_STD_RATE_EXPORT + "~~" + NON_STD_EFFECT_DT_EXP + "~~" + NON_STD_BANKNAME + "~~" + NON_STD_CERTIFICATE_NO + "~~" + NON_STD_CERTIFICATE_DATE;
                }
                else

                    custid = "";
            }
        }
        else
        {
            custid = "";
        }
        return custid;
    }
    protected void gvdetails_RowDeleting(object sender, CommandEventArgs e)
    {
        decimal totalAmount = 0;
        //decimal totaldebit = 0;
        decimal totalcgst = 0;
        decimal totalsgst = 0;
        decimal totaligst = 0;
        decimal totaltds = 0;
        //SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (dt.Rows.Count > 1)
            {
                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
               

                for (int i = 0; i < gvdetails.Rows.Count ; i++)
                {
                    gvdetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    TextBox txtgAmount = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txtgAmount");
                    //TextBox txtgDepit = (TextBox)gvdetails.Rows[i].Cells[10].FindControl("txtgDebit");
                    TextBox txtgCgst = (TextBox)gvdetails.Rows[i].Cells[5].FindControl("txtgCgst");
                    TextBox txtgScgst = (TextBox)gvdetails.Rows[i].Cells[6].FindControl("txtgScgst");
                    TextBox txtgIgst = (TextBox)gvdetails.Rows[i].Cells[7].FindControl("txtgIgst");
                    //TextBox txtgTds = (TextBox)gvdetails.Rows[i].Cells[8].FindControl("txtgTds");
                    //TextBox txtgTdsamt = (TextBox)gvdetails.Rows[i].Cells[9].FindControl("txtgdtsamt");
                    
                        //txtgAmount += Convert.ToDecimal(txtgAmount.Text);
                    if (txtgAmount.Text != "") { totalAmount += Convert.ToDecimal(txtgAmount.Text); }
                   
                    if (txtgCgst.Text != "") { totalcgst += Convert.ToDecimal(txtgCgst.Text); }
                    if (txtgScgst.Text != "") { totalsgst += Convert.ToDecimal(txtgScgst.Text); }
                    if (txtgIgst.Text != "") { totaligst += Convert.ToDecimal(txtgIgst.Text); }
                    //if (txtgTdsamt.Text != "") { totaltds += Convert.ToDecimal(txtgTdsamt.Text); }

                }
                TextBox txtfAmounttotal = (TextBox)gvdetails.FooterRow.FindControl("txtAmounttotal");
                //TextBox txtfdebittotal = (TextBox)gvdetails.FooterRow.FindControl("txtdebittotal");
                TextBox txtfcgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtcgsttotal");
                TextBox txtfsgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtsgsttotal");
                TextBox txtfigsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtigsttotal");
                //TextBox txtftdstotal = (TextBox)gvdetails.FooterRow.FindControl("txttdstotal");
                txtfAmounttotal.Text = totalAmount.ToString();
                //txtfdebittotal.Text = totaldebit.ToString();
                txtfcgsttotal.Text = totalcgst.ToString();
                txtfsgsttotal.Text = totalsgst.ToString();
                txtfigsttotal.Text = totaligst.ToString();
                //txtftdstotal.Text = totaltds.ToString();
                txtNetamt.Text = Convert.ToString(totalAmount + totalcgst + totaligst + totalsgst );
                txtGrandtotal.Text = Convert.ToString(totalAmount + totalcgst + totaligst + totalsgst); 
                //SetPreviousData();
            }
        }
    }
     [System.Web.Services.WebMethod]
    public static string Cust_Name(string ChargeName, string Imp_Name, string Mode)
    {
        string cname="";
         DataSet ds=new DataSet();
         GST_Imp_Invoice BI = new GST_Imp_Invoice();
          Billing_UserBO ObjUBO = new Billing_UserBO();
         ObjUBO.ENAME="CUST_NAME";
         ObjUBO.VENDOR_NAME = ChargeName;
         ds= BI.PurchaseEntry(ObjUBO);
         if (ds.Tables[0].Rows.Count > 0)
         {
             cname = ds.Tables[0].Rows[0][0].ToString() + "~~" + ds.Tables[0].Rows[0]["JOBDATE"].ToString();
         }
         else
         {
             cname = "";
         }

         return cname;
    }
     protected void txtgFileRefNo_TextChanged(object sender, EventArgs e)
     {
          
         DataSet ds = new DataSet();
         GridViewRow currentRow = ((GridViewRow)((TextBox)sender).NamingContainer);
         TextBox txtgFileRef = (TextBox)currentRow.FindControl("txtgFileRefNo");
         TextBox txtgCusName = (TextBox)currentRow.FindControl("txtgCusName");
         txtgFileRef.Text = "FILE/2020/12";
         txtgCusName.Text = "PARAMOUNT";
         //ObjUBO.ENAME = "CUST_NAME";
         //ObjUBO.VENDOR_NAME = Hdnfileref.Value;
         //ds = BI.PurchaseEntry(ObjUBO);
         //txtgCusName.Text = ds.Tables[0].Rows[0][0].ToString();


     }
     protected void txtgCharHead_TextChanged(object sender, EventArgs e)
     {
         GridViewRow currentRow = ((GridViewRow)((TextBox)sender).NamingContainer);
         TextBox txtgcharh = (TextBox)currentRow.FindControl("txtgCharHead");
         TextBox txtgcgst = (TextBox)currentRow.FindControl("txtgCgst");
         TextBox txtgsgst = (TextBox)currentRow.FindControl("txtgScgst");
         TextBox txtgigst = (TextBox)currentRow.FindControl("txtgIgst");
         TextBox txtgtds = (TextBox)currentRow.FindControl("txtgdtsamt");
         txtgcharh.Text = "AAI EXPENSES";
         txtgcgst.Text = "2";
         txtgsgst.Text = "3";
         txtgigst.Text = "2";
         txtgtds.Text = "";
             
         
     }
     
     [System.Web.Services.WebMethod]
     public static string Get_Cha_rate(string ChargeName, string Imp_Name, string Mode)
     {
         string Ch_Name = "";
         DataSet ds = new DataSet();
         try
         {
             GST_Charge_Master BI = new GST_Charge_Master();
             Billing_UserBO ObjUBO = new Billing_UserBO();

             ObjUBO.CHARGE_NAME = ChargeName;
             ObjUBO.Party_Ref = "";
             ObjUBO.REMARKS = "";
             ObjUBO.Flag = "Grid_Data";
             ds = BI.Charge_Master_Select(ObjUBO);

             if (ds.Tables[0].Rows.Count > 0)
             {
                 Ch_Name = ds.Tables[0].Rows[0]["CGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["SGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["IGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["SA_CODE"].ToString();
             }
             else
             {
                 Ch_Name = "";
             }
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
         return Ch_Name;
     }

     [System.Web.Services.WebMethod]
     public static string Get_Vendordetail(string VendorName, string VendorBranch, string Mode)
     {
         string Vendor_Name = "";
         DataSet ds = new DataSet();
         try
         {
             GST_Imp_Invoice BI = new GST_Imp_Invoice();
             Billing_UserBO ObjUBO = new Billing_UserBO();

             ObjUBO.VENDOR_NAME = VendorName;
             ObjUBO.VENDOR_BRANCH = VendorBranch;
             ObjUBO.Flag = "SELECT";
             ds = BI.Select_VendorDetaill(ObjUBO);

             if (ds.Tables[0].Rows.Count > 0)
             {
                 Vendor_Name = ds.Tables[0].Rows[0]["BR_STATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["BR_GSTIN_NO"].ToString() + "~~" + ds.Tables[0].Rows[0]["BR_TAX_TYPE"].ToString() + "~~" + ds.Tables[0].Rows[0]["BR_COUNTRY_NAME"].ToString() + "~~" + ds.Tables[1].Rows[0]["TAX_TYPE"].ToString();
             }
             else
             {
                 Vendor_Name = "";
             }
         }
         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
         return Vendor_Name;
     }
     private void Update_Item_Load()
     {
         decimal totalAmount = 0;
         //decimal totaldebit = 0;
         decimal totalcgst = 0;
         decimal totalsgst = 0;
         decimal totaligst = 0;
     

         try
         {

             DataSet dss = new DataSet();
             ObjUBO.DEBIT_NOTE_NO = Request.QueryString["DEBIT_NOTE_NO"].ToString();
             ObjUBO.PARTY_NAME = "";
             ObjUBO.WORKING_PERIOD = Working_Period;
             ObjUBO.ENAME = "Grid_Data";
             dss = BI.DebitNoteSelect(ObjUBO);




             if (dss.Tables[0].Rows.Count > 0)
             {
                 txtDebitNoteno.Text = dss.Tables[0].Rows[0]["DEBIT_NOTE_NO"].ToString();
                 txtdate.Text = dss.Tables[0].Rows[0]["DATE"].ToString();
                 txtPartyname.Text = dss.Tables[0].Rows[0]["PARTY_NAME"].ToString();
                 txtInvoiceno.Text = dss.Tables[0].Rows[0]["INVOICE_NO"].ToString();
                
             }
             ViewState["CurrentTable"] = dss.Tables[1];

             if (dss.Tables[1].Rows.Count > 0)
             {
                 dss.Tables[1].Columns.Add(new DataColumn("SNo", typeof(string)));
                 //gvdetails.Visible = false;

                 //gvbind.Visible = true;
                 gvdetails.DataSource = dss.Tables[1];
                 gvdetails.DataBind();

                 for (int i = 0; i < gvdetails.Rows.Count; i++)
                 {
                     gvdetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                     //LinkButton lnkBtn = (LinkButton)gvdetails.Rows[i].FindControl("LinkButton1");
                     //lnkBtn.Visible = true;
                     //FileUpload Fileupl = (FileUpload)gvdetails.Rows[i].FindControl("FileUpload1");
                     //Fileupl.Visible = false;


                     TextBox txtgAmount = (TextBox)gvdetails.Rows[i].Cells[4].FindControl("txtgAmount");
                     //TextBox txtgDepit = (TextBox)gvdetails.Rows[i].Cells[10].FindControl("txtgDebit");
                     TextBox txtgCgst = (TextBox)gvdetails.Rows[i].Cells[5].FindControl("txtgCgst");
                     TextBox txtgScgst = (TextBox)gvdetails.Rows[i].Cells[6].FindControl("txtgScgst");
                     TextBox txtgIgst = (TextBox)gvdetails.Rows[i].Cells[7].FindControl("txtgIgst");
                     //TextBox txtgTds = (TextBox)gvdetails.Rows[i].Cells[14].FindControl("txtgTds");
                     //TextBox txtgTdsamt = (TextBox)gvdetails.Rows[i].Cells[15].FindControl("txtgdtsamt");

                     if (txtgAmount.Text != "") { totalAmount += Convert.ToDecimal(txtgAmount.Text); }

                     if (txtgCgst.Text != "") { totalcgst += Convert.ToDecimal(txtgCgst.Text); }
                     if (txtgScgst.Text != "") { totalsgst += Convert.ToDecimal(txtgScgst.Text); }
                     if (txtgIgst.Text != "") { totaligst += Convert.ToDecimal(txtgIgst.Text); }
                     //if (txtgTdsamt.Text != "") { totaltds += Convert.ToDecimal(txtgTdsamt.Text); }

                 }
                 TextBox txtfAmounttotal = (TextBox)gvdetails.FooterRow.FindControl("txtAmounttotal");
                 //TextBox txtfdebittotal = (TextBox)gvdetails.FooterRow.FindControl("txtdebittotal");
                 TextBox txtfcgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtcgsttotal");
                 TextBox txtfsgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtsgsttotal");
                 TextBox txtfigsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtigsttotal");
                 //TextBox txtftdstotal = (TextBox)gvdetails.FooterRow.FindControl("txttdstotal");
                 txtfAmounttotal.Text = totalAmount.ToString();
                 //txtfdebittotal.Text = totaldebit.ToString();
                 txtfcgsttotal.Text = totalcgst.ToString();
                 txtfsgsttotal.Text = totalsgst.ToString();
                 txtfigsttotal.Text = totaligst.ToString();
                 //txtftdstotal.Text = totaltds.ToString();
                 txtNetamt.Text = Convert.ToString(totalAmount + totalcgst + totaligst + totalsgst);
                 txtGrandtotal.Text = Convert.ToString(totalAmount + totalcgst + totaligst + totalsgst);

             }





             dss.Dispose();
             GC.Collect();
         }


         catch (Exception ex)
         {
             Connection.Error_Msg(ex.Message);
         }
     }
     protected void gvbind_RowCreated(object sender, GridViewRowEventArgs e)
     {
         if (e.Row.RowType == DataControlRowType.Header)
             e.Row.CssClass = "header";
     }
     
}