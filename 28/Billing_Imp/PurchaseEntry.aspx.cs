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



public partial class Billing_Imp_PurchaseEntry : ThemeClass
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
        
        CalendarExtender1.EndDate = DateTime.Now;
        DataSet ds = new DataSet();
        aps.checkSession();
        currentuser = Session["currentuser"].ToString();
        currentbranch = Session["currentbranch"].ToString();
        Working_Period = Session["WorkingPeriod"].ToString();
        if (!IsPostBack)
        {
            if (Request.QueryString["voucherno"] != null && Request.QueryString["voucherno"] != string.Empty)
            {
                Update_Item_Load();
                
                btnSave.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                ObjUBO.ENAME = "VOURCHERID";
                ObjUBO.BRANCH_CODE = currentbranch;
                ObjUBO.WORKING_PERIOD = Working_Period;
                ds = BI.PurchaseEntry(ObjUBO);
                if (ds.Tables[1].Rows.Count > 0 && ds.Tables[2].Rows.Count > 0 && ds.Tables[0].Rows.Count>0)
                {
                    txtVoucherno.Text = ds.Tables[1].Rows[0][0].ToString() + ds.Tables[0].Rows[0][0].ToString() + ds.Tables[2].Rows[0][0].ToString();
                }
                else { Alert_msg("Must set prefix sufix"); }

                txtInvoiceCurrency.Attributes.Add("onblur", "javascript:Call__Inv_Currency_Excahnge_Rate('" + txtInvoiceCurrency.ClientID + "', '" + txtExrate.ClientID + "')");



                txtInvoiceCurrency.Text = "INR";
                txtExrate.Text = "1";
                txtVoucherdate.Text = DateTime.Now.ToShortDateString();
                //Rownum = 1;
                ViewState["RowNumber"] = 1;
                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();
                DropDownList drp = new DropDownList();
                dt.Columns.Add(new DataColumn("SNo", typeof(string)));
                dt.Columns.Add(new DataColumn("File_Ref_No", typeof(string)));
                dt.Columns.Add(new DataColumn("Date", typeof(string)));
                dt.Columns.Add(new DataColumn("DR_CR", typeof(string)));
                dt.Columns.Add(new DataColumn("Customer_Name", typeof(string)));
                dt.Columns.Add(new DataColumn("Imp_Exp", typeof(string)));
                dt.Columns.Add(new DataColumn("Charge_Name", typeof(string)));
                dt.Columns.Add(new DataColumn("Gst_Type", typeof(string)));
                dt.Columns.Add(new DataColumn("Tax_Rate", typeof(string)));
                dt.Columns.Add(new DataColumn("Credit", typeof(string)));
                dt.Columns.Add(new DataColumn("Debit", typeof(string)));
                dt.Columns.Add(new DataColumn("CGST", typeof(string)));
                dt.Columns.Add(new DataColumn("SCGST", typeof(string)));
                dt.Columns.Add(new DataColumn("IGST", typeof(string)));
                dt.Columns.Add(new DataColumn("TDS", typeof(string)));
                dt.Columns.Add(new DataColumn("TDS_Amount", typeof(string)));
                dt.Columns.Add(new DataColumn("FileUp", typeof(string)));
                dt.Rows.Add(dr);
                dr["DR_CR"] = new ListItem("DR");
                dr["Imp_exp"] = new ListItem("---");
                dr["SNo"] = ViewState["RowNumber"].ToString();
                dr["Gst_Type"] = new ListItem("GST_TYPE_01");

                ViewState["CurrentTable"] = dt;
                gvdetails.Visible = true;
                //gvbind.Visible = false;
                gvdetails.DataSource = dt;
                gvdetails.DataBind();
                LinkButton lnkBtn = (LinkButton)gvdetails.Rows[0].FindControl("LinkButton1"); 
                lnkBtn.Visible = false; 
                FileUpload Fileupl = (FileUpload)gvdetails.Rows[0].FindControl("FileUpload1"); 
                Fileupl.Visible = true; 


            }
        }
    }
    private void AddNewRow()
    {


        int rowIndex = 0;
        decimal totalcredit = 0;
        decimal totaldebit = 0;
        decimal totalcgst = 0;
        decimal totalsgst = 0;
        decimal totaligst = 0;
        decimal totaltds = 0;
        decimal total=0;

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
                    TextBox txtgFileRefNo = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtgFileRefNo");
                    TextBox txtgDate = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtgDate");
                    DropDownList drpgDrCr = (DropDownList)gvdetails.Rows[rowIndex].Cells[3].FindControl("drpDrcr");
                    //drpgDrCr.Items.Insert(0, new ListItem("DR", "0"));
                    //drpgDrCr.Items.Insert(0, new ListItem("CR", "0"));
                    TextBox txtgCusname = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtgCusName");
                    DropDownList drpgImpexp = (DropDownList)gvdetails.Rows[rowIndex].Cells[5].FindControl("drpImpexp");
                    //drpgImpexp.Items.Insert(0, new ListItem("Imp", "0"));
                    //drpgImpexp.Items.Insert(0, new ListItem("Exp", "0"));
                    TextBox txtgCharhead = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtgCharHead");
                    DropDownList ddlgsttype = (DropDownList)gvdetails.Rows[rowIndex].Cells[7].FindControl("ddl_Gst_type");
                    TextBox txtgTaxrate = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtgTaxrate");
                    TextBox txtgCredit = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgCredit");
                    TextBox txtgDepit = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtgDebit");
                    TextBox txtgCgst = (TextBox)gvdetails.Rows[rowIndex].Cells[11].FindControl("txtgCgst");
                    TextBox txtgScgst = (TextBox)gvdetails.Rows[rowIndex].Cells[12].FindControl("txtgScgst");
                    TextBox txtgIgst = (TextBox)gvdetails.Rows[rowIndex].Cells[13].FindControl("txtgIgst");
                    TextBox txtgTds = (TextBox)gvdetails.Rows[rowIndex].Cells[14].FindControl("txtgTds");
                    TextBox txtgTdsamt = (TextBox)gvdetails.Rows[rowIndex].Cells[15].FindControl("txtgdtsamt");
                    FileUpload file = (FileUpload)gvdetails.Rows[rowIndex].Cells[16].FindControl("FileUpload1"); 
                    HiddenField hfFile = (HiddenField)gvdetails.Rows[rowIndex].Cells[16].FindControl("hfFileByte");
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

                    if (txtgCredit.Text != "")
                    {
                        totalcredit += Convert.ToDecimal(txtgCredit.Text);
                    }
                        if (txtgDepit.Text != "")
                        {
                        totaldebit += Convert.ToDecimal(txtgDepit.Text);
                    }
                    if (txtgCgst.Text != "") { totalcgst += Convert.ToDecimal(txtgCgst.Text); }
                    if (txtgScgst.Text != "") { totalsgst += Convert.ToDecimal(txtgScgst.Text); }
                    if (txtgIgst.Text != "") { totaligst += Convert.ToDecimal(txtgIgst.Text); }
                    if (txtgTdsamt.Text != "") { totaltds += Convert.ToDecimal(txtgTdsamt.Text); }
                     total = totaldebit + totalcgst + totaligst + totalsgst - totaltds;

                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["DR_CR"] = new ListItem("DR");
                    drCurrentRow["Imp_Exp"] = new ListItem("Imp");
                    drCurrentRow["Gst_Type"] = new ListItem("GST_TYPE_01");

                    dtCurrentTable.Rows[i - 1]["SNo"] = Slno;
                    dtCurrentTable.Rows[i - 1]["File_Ref_No"] = txtgFileRefNo.Text;
                    dtCurrentTable.Rows[i - 1]["Date"] = txtgDate.Text;
                    dtCurrentTable.Rows[i - 1]["DR_CR"] = drpgDrCr.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Customer_Name"] = txtgCusname.Text;
                    dtCurrentTable.Rows[i - 1]["Imp_Exp"] = drpgImpexp.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Charge_Name"] = txtgCharhead.Text;
                    dtCurrentTable.Rows[i - 1]["Gst_Type"] = ddlgsttype.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Tax_Rate"] = txtgTaxrate.Text;
                    dtCurrentTable.Rows[i - 1]["Credit"] = txtgCredit.Text;
                    dtCurrentTable.Rows[i - 1]["Debit"] = txtgDepit.Text;
                    dtCurrentTable.Rows[i - 1]["CGST"] = txtgCgst.Text;
                    dtCurrentTable.Rows[i - 1]["SCGST"] = txtgScgst.Text;
                    dtCurrentTable.Rows[i - 1]["IGST"] = txtgIgst.Text;
                    dtCurrentTable.Rows[i - 1]["TDS"] = txtgTds.Text;
                    dtCurrentTable.Rows[i - 1]["TDS_Amount"] = txtgTdsamt.Text;
                    //dtCurrentTable.Rows[i - 1]["FileUp"] = file.FileName;
                    //dtCurrentTable.Rows[i - 1]["FileUp"] = file.HasFile ? bytes : Convert.FromBase64String(hfFile.Value); 


                    rowIndex++;
                    Slno++;
                    
                }
                

                int index = gvdetails.Rows.Count-1 ;
                //TextBox txtsl = (TextBox)gvdetails.Rows[index].Cells[1].FindControl("txtgSLNo");

                //DropDownList drpgImpex = (DropDownList)gvdetails.Rows[index+1].Cells[5].FindControl("drpImpexp");
                //drpgImpex.Focus();
                //drCurrentRow["SNo"] = Convert.ToInt32(txtsl.Text) + 1;
                drCurrentRow["SNo"] = Slno ;
                drCurrentRow["Debit"] = Convert.ToDecimal(txtTotalamtininr.Text) - total;
                //ViewState["RowNumber"] = Convert.ToInt32(txtsl.Text) + 1;
                //ViewState["RowNumber"] = Convert.ToInt32(ViewState["RowNumber"]) + 1;
                
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                gvdetails.DataSource = dtCurrentTable;
                gvdetails.DataBind();
                DropDownList drpgImpex = (DropDownList)gvdetails.Rows[index + 1].Cells[5].FindControl("drpImpexp");
                drpgImpex.Focus();
                TextBox txtfcredittotal = (TextBox)gvdetails.FooterRow.FindControl("txtcredittotal");
                TextBox txtfdebittotal = (TextBox)gvdetails.FooterRow.FindControl("txtdebittotal");
                TextBox txtfcgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtcgsttotal");
                TextBox txtfsgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtsgsttotal");
                TextBox txtfigsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtigsttotal");
                TextBox txtftdstotal = (TextBox)gvdetails.FooterRow.FindControl("txttdstotal");
                txtfcredittotal.Text = totalcredit.ToString();
                txtfdebittotal.Text = totaldebit.ToString();
                txtfcgsttotal.Text = totalcgst.ToString();
                txtfsgsttotal.Text = totalsgst.ToString();
                txtfigsttotal.Text = totaligst.ToString();
                txtftdstotal.Text = totaltds.ToString();
                
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
                    TextBox txtgFileRefNo = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtgFileRefNo");
                    TextBox txtgDate = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtgDate");
                    DropDownList drpgDrCr = (DropDownList)gvdetails.Rows[rowIndex].Cells[3].FindControl("drpDrcr");
                    //drpgDrCr.Items.Insert(0, new ListItem("DR", "0"));
                    //drpgDrCr.Items.Insert(0, new ListItem("CR", "0"));
                    TextBox txtgCusname = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtgCusName");
                    DropDownList drpgImpexp = (DropDownList)gvdetails.Rows[rowIndex].Cells[5].FindControl("drpImpexp");
                    //drpgImpexp.Items.Insert(0, new ListItem("Imp", "0"));
                    //drpgImpexp.Items.Insert(0, new ListItem("Exp", "0"));
                    TextBox txtgCharhead = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtgCharHead");
                    DropDownList ddlgsttype = (DropDownList)gvdetails.Rows[rowIndex].Cells[7].FindControl("ddl_Gst_type");
                    TextBox txtgTaxrate = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtgTaxrate");
                    TextBox txtgCredit = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgCredit");
                    TextBox txtgDepit = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtgDebit");
                    TextBox txtgCgst = (TextBox)gvdetails.Rows[rowIndex].Cells[11].FindControl("txtgCgst");
                    TextBox txtgScgst = (TextBox)gvdetails.Rows[rowIndex].Cells[12].FindControl("txtgScgst");
                    TextBox txtgIgst = (TextBox)gvdetails.Rows[rowIndex].Cells[13].FindControl("txtgIgst");
                    TextBox txtgTds = (TextBox)gvdetails.Rows[rowIndex].Cells[14].FindControl("txtgTds");
                    TextBox txtgTdsamt = (TextBox)gvdetails.Rows[rowIndex].Cells[15].FindControl("txtgdtsamt");
                    FileUpload file = (FileUpload)gvdetails.Rows[rowIndex].Cells[16].FindControl("FileUpload1"); 
                    HiddenField hfFile = (HiddenField)gvdetails.Rows[rowIndex].Cells[16].FindControl("hfFileByte"); 
                    //HiddenField hfFile = (HiddenField)Gridview1.Rows[rowIndex].Cells[4].FindControl("hfFileByte");
                    LinkButton lnkBtn = (LinkButton)gvdetails.Rows[rowIndex].Cells[16].FindControl("LinkButton1");
                    lnkBtn.Visible = false;
                    file.Visible = true;
                   

                    txtgSLNo.Text = dt.Rows[i]["SNo"].ToString();
                    txtgFileRefNo.Text = dt.Rows[i]["File_Ref_No"].ToString();
                    txtgDate.Text = dt.Rows[i]["Date"].ToString();
                    drpgDrCr.SelectedValue = dt.Rows[i]["DR_CR"].ToString();
                    txtgCusname.Text = dt.Rows[i]["Customer_Name"].ToString();
                    drpgImpexp.SelectedValue = dt.Rows[i]["Imp_Exp"].ToString();
                    txtgCharhead.Text = dt.Rows[i]["Charge_Name"].ToString();
                    ddlgsttype.SelectedValue = dt.Rows[i]["Gst_Type"].ToString();
                    txtgTaxrate.Text = dt.Rows[i]["Tax_Rate"].ToString();
                    txtgCredit.Text = dt.Rows[i]["Credit"].ToString();
                    txtgDepit.Text = dt.Rows[i]["Debit"].ToString();
                    txtgCgst.Text = dt.Rows[i]["CGST"].ToString();
                    txtgScgst.Text = dt.Rows[i]["SCGST"].ToString();
                    txtgIgst.Text = dt.Rows[i]["IGST"].ToString();
                    txtgTds.Text = dt.Rows[i]["TDS"].ToString();
                    txtgTdsamt.Text = dt.Rows[i]["TDS_Amount"].ToString();
                    //file.FileName = dt.Rows[i]["FileUp"].ToString();
                    
                    //hfFile.Value = !Convert.IsDBNull(dt.Rows[i]["FileUp"]) ? Convert.ToBase64String((byte[])dt.Rows[i]["FileUp"]) : "";
                    hfFile.Value = file.HasFile ? Path.GetFileName(file.PostedFile.FileName) : file.FileName; 
                    //file.ToString() =  hfFile.Value;

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
        decimal totalcredit = 0;
        decimal totaldebit = 0;
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
                    TextBox txtgFileRefNo = (TextBox)gvdetails.Rows[rowIndex].Cells[1].FindControl("txtgFileRefNo");
                    TextBox txtgDate = (TextBox)gvdetails.Rows[rowIndex].Cells[2].FindControl("txtgDate");
                    DropDownList drpgDrCr = (DropDownList)gvdetails.Rows[rowIndex].Cells[3].FindControl("drpDrcr");
                    //drpgDrCr.Items.Insert(0, new ListItem("DR", "0"));
                    //drpgDrCr.Items.Insert(0, new ListItem("CR", "0"));
                    TextBox txtgCusname = (TextBox)gvdetails.Rows[rowIndex].Cells[4].FindControl("txtgCusName");
                    DropDownList drpgImpexp = (DropDownList)gvdetails.Rows[rowIndex].Cells[5].FindControl("drpImpexp");
                    //drpgImpexp.Items.Insert(0, new ListItem("Imp", "0"));
                    //drpgImpexp.Items.Insert(0, new ListItem("Exp", "0"));
                    TextBox txtgCharhead = (TextBox)gvdetails.Rows[rowIndex].Cells[6].FindControl("txtgCharHead");
                    DropDownList ddlgsttype = (DropDownList)gvdetails.Rows[rowIndex].Cells[7].FindControl("ddl_Gst_type");
                    TextBox txtgTaxrate = (TextBox)gvdetails.Rows[rowIndex].Cells[8].FindControl("txtgTaxrate");
                    TextBox txtgCredit = (TextBox)gvdetails.Rows[rowIndex].Cells[9].FindControl("txtgCredit");
                    TextBox txtgDepit = (TextBox)gvdetails.Rows[rowIndex].Cells[10].FindControl("txtgDebit");
                    TextBox txtgCgst = (TextBox)gvdetails.Rows[rowIndex].Cells[11].FindControl("txtgCgst");
                    TextBox txtgScgst = (TextBox)gvdetails.Rows[rowIndex].Cells[12].FindControl("txtgScgst");
                    TextBox txtgIgst = (TextBox)gvdetails.Rows[rowIndex].Cells[13].FindControl("txtgIgst");
                    TextBox txtgTds = (TextBox)gvdetails.Rows[rowIndex].Cells[14].FindControl("txtgTds");
                    TextBox txtgTdsamt = (TextBox)gvdetails.Rows[rowIndex].Cells[15].FindControl("txtgdtsamt");

                    if (txtgCredit.Text != "")
                    {
                        totalcredit += Convert.ToDecimal(txtgCredit.Text);
                    }
                    if (txtgDepit.Text != "")
                    {
                        totaldebit += Convert.ToDecimal(txtgDepit.Text);
                    }
                    if (txtgCgst.Text != "") { totalcgst += Convert.ToDecimal(txtgCgst.Text); }
                    if (txtgScgst.Text != "") { totalsgst += Convert.ToDecimal(txtgScgst.Text); }
                    if (txtgIgst.Text != "") { totaligst += Convert.ToDecimal(txtgIgst.Text); }
                    if (txtgTdsamt.Text != "") { totaltds += Convert.ToDecimal(txtgTdsamt.Text); }
                    ViewState["credit"] = totalcredit;
                    ViewState["debit"] = totaldebit;
                    ViewState["cgst"] = totalcgst;
                    ViewState["sgst"] = totalsgst;
                    ViewState["igst"] = totaligst;
                    ViewState["tdsamt"] = totaltds;

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

                    //dtCurrentTable.Rows[i - 1]["SNo"] = i;
                    dtCurrentTable.Rows[i - 1]["File_Ref_No"] = txtgFileRefNo.Text;
                    dtCurrentTable.Rows[i - 1]["Date"] = txtgDate.Text;
                    //dtCurrentTable.Rows[i - 1]["DR/CR"] = drpgDrCr.Text;
                    dtCurrentTable.Rows[i - 1]["Customer_Name"] = txtgCusname.Text;
                    //dtCurrentTable.Rows[i - 1]["Imp/Exp"] = txtgImpexp.Text;
                    dtCurrentTable.Rows[i - 1]["Charge_Name"] = txtgCharhead.Text;
                    dtCurrentTable.Rows[i - 1]["Gst_Type"] = ddlgsttype.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Tax_Rate"] = txtgTaxrate.Text;
                    dtCurrentTable.Rows[i - 1]["Credit"] = txtgCredit.Text;
                    dtCurrentTable.Rows[i - 1]["Debit"] = txtgDepit.Text;
                    dtCurrentTable.Rows[i - 1]["CGST"] = txtgCgst.Text;
                    dtCurrentTable.Rows[i - 1]["SCGST"] = txtgScgst.Text;
                    dtCurrentTable.Rows[i - 1]["IGST"] = txtgIgst.Text;
                    dtCurrentTable.Rows[i - 1]["TDS"] = txtgTds.Text;
                    dtCurrentTable.Rows[i - 1]["TDS_Amount"] = txtgTdsamt.Text;
                    rowIndex++;
                    //drCurrentRow["SNo"] = Slno;
                }

                ViewState["CurrentTable"] = dtCurrentTable;
            }
        }
    }
    //protected void drpDrcr_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList ddl = (DropDownList)sender;
    //    GridViewRow row = (GridViewRow)ddl.NamingContainer;
    //    int RowIndex = Convert.ToInt32(row.RowIndex);
    //    //lblSelectionMessage.InnerText = RowIndex.ToString();

    //    foreach (GridViewRow rw in gvdetails.Rows)
    //    {
    //        if (rw.RowIndex == RowIndex)
    //        {
    //            rw.Enabled = false;
    //        }
    //    }
        
    //}

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
            DropDownList customerId = (e.Row.FindControl("drpDrcr") as DropDownList);
            if (customerId.Text == "CR")
            {
                TextBox txtdebit = (e.Row.FindControl("txtgDebit") as TextBox);
                TextBox txtcredit = (e.Row.FindControl("txtgCredit") as TextBox);

                txtdebit.ReadOnly = true;
                txtcredit.ReadOnly = false;
            }
            else if (customerId.Text == "DR")
            {
                TextBox txtdebit = (e.Row.FindControl("txtgDebit") as TextBox);
                TextBox txtcredit = (e.Row.FindControl("txtgCredit") as TextBox);
                txtdebit.ReadOnly = false;
                txtcredit.ReadOnly = true;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTotalamtininr.Text == txtGrandtotal.Text)
        {
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
        }
        else
        {
            string cleanMessage = "Bill amount & Grand total amount not equal".Replace("'", "\'");
            Page page = HttpContext.Current.CurrentHandler as Page;
            string script = string.Format("alert('{0}');", cleanMessage);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
            }
        }
    
    }

    private void save_update(string name)
    {
        DataSet ds = new DataSet();
        ObjUBO.VOUCHER_NO = txtVoucherno.Text;
        ObjUBO.VOUCHER_DATE = txtVoucherdate.Text;
        ObjUBO.VENDOR_NAME = txtVendorname.Text;
        ObjUBO.VENDOR_BRANCH = txtVendorbranch.Text;
        ObjUBO.VENDOR_STATE = txtVendorstate.Text;
        ObjUBO.GSTN = txtGstn.Text;
        ObjUBO.GSTN_TYPE = txtGstntype.Text;
        ObjUBO.COUNTRY = txtCountry.Text;
        ObjUBO.VENDOR_BILL = txtVendorbillno.Text;
        ObjUBO.BILL_DATE = txtBilldate.Text;
        ObjUBO.BILL_AMOUNT = txtbillamount.Text;
        ObjUBO.CURRENCY = txtInvoiceCurrency.Text;
        ObjUBO.EX_RATE = txtExrate.Text;
        ObjUBO.AMT_IN_INR = txtTotalamtininr.Text;
        ObjUBO.NARRATION = txtNarration.Text;
        ObjUBO.USER_ID = currentuser;
        ObjUBO.BRANCH_CODE = currentbranch;
        ObjUBO.WORKING_PERIOD = Working_Period;
        //gridtodt();
        ObjUBO.XML_DETAIL = ConvertDataTableToXML(gridtodt());
        ObjUBO.ENAME = name ;
        ds = BI.PurchaseEntry(ObjUBO);
        string pathFolder = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "PurchaseEntry");
        if (Directory.Exists(pathFolder) == false)
        {
            Directory.CreateDirectory(pathFolder);
        }
        foreach (GridViewRow row in gvdetails.Rows)
        {
            FileUpload file = row.FindControl("FileUpload1") as FileUpload;
            if (file.HasFile)
            {

                //file.SaveAs(Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "PurchaseEntry/") + file.FileName);
                file.SaveAs(pathFolder + "/" + file.FileName);
            }
        } 
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtTotalamtininr.Text) == Convert.ToDecimal(txtGrandtotal.Text))
        {
            
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
        }
        else
        {
            string cleanMessage = "Bill amount & Grand total amount not equal".Replace("'", "\'");
            Page page = HttpContext.Current.CurrentHandler as Page;
            string script = string.Format("alert('{0}');", cleanMessage);
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "alert", script, true /* addScriptTags */);
            }
        }
        
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
            for (int i = 0; i < gvdetails.HeaderRow.Cells.Count-2; i++)
            {
                dt.Columns.Add(gvdetails.HeaderRow.Cells[i].Text);
            }
            dt.Columns.Add("filename");


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
                    else if (j == 1)
                    {
                        DropDownList drpimexp = row.FindControl("drpImpexp") as DropDownList;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = drpimexp.SelectedValue;

                    }
                    else if (j == 2)
                    {
                        TextBox txtFilerefno = row.FindControl("txtgFileRefNo") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtFilerefno.Text;
                    }
                    else if (j == 3)
                    {
                        TextBox txtDate = row.FindControl("txtgDate") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtDate.Text;

                    }
                    else if (j == 4)
                    {
                        DropDownList drpcdr = row.FindControl("drpDrcr") as DropDownList;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = drpcdr.SelectedValue;

                    }
                    else if (j == 5)
                    {
                        TextBox txtCusname = row.FindControl("txtgCusName") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtCusname.Text;

                    }
                    else if (j == 6)
                    {
                        TextBox txtcharge = row.FindControl("txtgCharHead") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtcharge.Text;
                    }
                    else if (j == 7)
                    {
                        DropDownList ddlgsttype = row.FindControl("ddl_Gst_type") as DropDownList;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = ddlgsttype.SelectedValue;
                    }
                    else if (j == 8)
                    {
                        TextBox txtTaxrate = row.FindControl("txtgTaxrate") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtTaxrate.Text;
                    }
                    else if (j == 9)
                    {
                        TextBox txtCredit = row.FindControl("txtgCredit") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtCredit.Text;
                    }
                    else if (j == 10)
                    {
                        TextBox txtDebit = row.FindControl("txtgDebit") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtDebit.Text;
                    }
                    else if (j == 11)
                    {
                        TextBox txtCgst = row.FindControl("txtgCgst") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtCgst.Text;
                    }
                    else if (j == 12)
                    {
                        TextBox txtScgst = row.FindControl("txtgScgst") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtScgst.Text;
                    }
                    else if (j == 13)
                    {
                        TextBox txtIgst = row.FindControl("txtgIgst") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtIgst.Text;
                    }
                    else if (j == 14)
                    {
                        TextBox txtTds = row.FindControl("txtgTds") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtTds.Text;
                    }
                    else if (j == 15)
                    {
                        TextBox txtTdsamt = row.FindControl("txtgdtsamt") as TextBox;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = txtTdsamt.Text;
                    }
                    else if (j == 16)
                    {
                        FileUpload file = row.FindControl("FileUpload1") as FileUpload;

                        ////string base64String = (row.FindControl("hfFileByte") as HiddenField).Value;
                        ////HiddenField base64String = row.FindControl("hfFileByte") as HiddenField;
                        ////dr[gvdetails.HeaderRow.Cells[j].Text] = base64String.Value;

                        ////string fileName = "a";
                        ////byte[] bytes = Convert.FromBase64String(base64String);
                        //byte[] bytes;
                        ////dr[gvdetails.HeaderRow.Cells[j].Text] = bytes;
                        //BinaryReader br = new BinaryReader(file.PostedFile.InputStream);
                        //bytes = br.ReadBytes((Int32)file.PostedFile.InputStream.Length);
                        ////dr[gvdetails.HeaderRow.Cells[j].Text] = Convert.ToBase64String(bytes);
                        //dr[gvdetails.HeaderRow.Cells[j].Text] = bytes;
                        dr[gvdetails.HeaderRow.Cells[j].Text] = "~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "PurchaseEntry" + "/" + file.FileName;
                        dr["filename"] = file.FileName;
                        //dr[gvdetails.HeaderRow.Cells[j + 2].Text] = file


                        //string filePath = Server.MapPath("~/Submission/" + Session["COMPANY_ID"].ToString() + "/" + "Expense_Entry" + "/"+fileName );
                        //if ( !string.IsNullOrEmpty(fileName) && bytes != null)
                        //{
                        //    // Save the Byte Array as file in folder.
                        //    File.WriteAllBytes(filePath, bytes);
                        //    // Insert Code goes here.
                        //    // Insert record into database either with path or with binart data.
                        //}
                    }

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
        ObjUBO.VOUCHER_NO = txtVoucherno.Text;
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
        decimal totalcredit = 0;
        decimal totaldebit = 0;
        decimal totalcgst = 0;
        decimal totalsgst = 0;
        decimal totaligst = 0;
        decimal totaltds = 0;
        SetRowData();
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
                    TextBox txtgCredit = (TextBox)gvdetails.Rows[i].Cells[9].FindControl("txtgCredit");
                    TextBox txtgDepit = (TextBox)gvdetails.Rows[i].Cells[10].FindControl("txtgDebit");
                    TextBox txtgCgst = (TextBox)gvdetails.Rows[i].Cells[11].FindControl("txtgCgst");
                    TextBox txtgScgst = (TextBox)gvdetails.Rows[i].Cells[12].FindControl("txtgScgst");
                    TextBox txtgIgst = (TextBox)gvdetails.Rows[i].Cells[13].FindControl("txtgIgst");
                    TextBox txtgTds = (TextBox)gvdetails.Rows[i].Cells[14].FindControl("txtgTds");
                    TextBox txtgTdsamt = (TextBox)gvdetails.Rows[i].Cells[15].FindControl("txtgdtsamt");
                    if (txtgCredit.Text != "")
                    {
                        totalcredit += Convert.ToDecimal(txtgCredit.Text);
                    }
                    if (txtgDepit.Text != "")
                    {
                        totaldebit += Convert.ToDecimal(txtgDepit.Text);
                    }
                    if (txtgCgst.Text != "") { totalcgst += Convert.ToDecimal(txtgCgst.Text); }
                    if (txtgScgst.Text != "") { totalsgst += Convert.ToDecimal(txtgScgst.Text); }
                    if (txtgIgst.Text != "") { totaligst += Convert.ToDecimal(txtgIgst.Text); }
                    if (txtgTdsamt.Text != "") { totaltds += Convert.ToDecimal(txtgTdsamt.Text); }

                }
                TextBox txtfcredittotal = (TextBox)gvdetails.FooterRow.FindControl("txtcredittotal");
                TextBox txtfdebittotal = (TextBox)gvdetails.FooterRow.FindControl("txtdebittotal");
                TextBox txtfcgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtcgsttotal");
                TextBox txtfsgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtsgsttotal");
                TextBox txtfigsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtigsttotal");
                TextBox txtftdstotal = (TextBox)gvdetails.FooterRow.FindControl("txttdstotal");
                txtfcredittotal.Text = totalcredit.ToString();
                txtfdebittotal.Text = totaldebit.ToString();
                txtfcgsttotal.Text = totalcgst.ToString();
                txtfsgsttotal.Text = totalsgst.ToString();
                txtfigsttotal.Text = totaligst.ToString();
                txtftdstotal.Text = totaltds.ToString();
                txtNetamt.Text = Convert.ToString(totaldebit + totalcgst + totaligst + totalsgst - totaltds);
                txtGrandtotal.Text = Convert.ToString(totaldebit + totalcgst + totaligst + totalsgst ); 
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
     protected void txtVendorbranch_TextChanged(object sender, EventArgs e)
     {
         txtVendorbranch.Text = "Chennai";
         txtCountry.Text = "INDIA";
         txtVendorstate.Text = "TAMIL NADU";
         txtGstn.Text = "33PANNUMBER1C";
         txtGstntype.Text = "B2B";
         txtNarration.Focus();


     }
     [System.Web.Services.WebMethod]
     public static string Get_Cha_rate(string ChargeName, string Imp_Name, string Mode)
     {
         string Ch_Name = "";
         DataSet ds = new DataSet();
         try
         {
             GST_Imp_Invoice BI = new GST_Imp_Invoice();
             Billing_UserBO ObjUBO = new Billing_UserBO();

             ObjUBO.charge_name = ChargeName;
             ObjUBO.Flag = "select_charge";
             ds = BI.Select_Char_val(ObjUBO);

             if (ds.Tables[0].Rows.Count > 0)
             {
                 Ch_Name = ds.Tables[0].Rows[0]["CGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["SGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["IGST_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["TDS_RATE"].ToString() + "~~" + ds.Tables[0].Rows[0]["SA_CODE"].ToString();
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
         decimal totalcredit = 0;
         decimal totaldebit = 0;
         decimal totalcgst = 0;
         decimal totalsgst = 0;
         decimal totaligst = 0;
         decimal totaltds = 0;
        
         try
         {

             DataSet dss = new DataSet();
             ObjUBO.VOUCHER_NO = Request.QueryString["voucherno"].ToString();
             ObjUBO.ENAME = "SELETG";
             dss = BI.PurchaseEntry(ObjUBO);




             if (dss.Tables[0].Rows.Count > 0)
             {
                 txtVoucherno.Text = dss.Tables[0].Rows[0]["VOUCHER_NO"].ToString();
                 txtVendorname.Text = dss.Tables[0].Rows[0]["VENDOR_NAME"].ToString();
                 txtVoucherdate.Text = dss.Tables[0].Rows[0]["VOUCHER_DATE"].ToString();
                 txtVendorbranch.Text = dss.Tables[0].Rows[0]["VENDOR_BRANCH"].ToString();
                 txtVendorstate.Text = dss.Tables[0].Rows[0]["VENDOR_STATE"].ToString();
                 txtGstn.Text = dss.Tables[0].Rows[0]["GSTN"].ToString();
                 txtGstntype.Text = dss.Tables[0].Rows[0]["GSTN_TYPE"].ToString();
                 txtCountry.Text = dss.Tables[0].Rows[0]["COUNTRY"].ToString();
                 txtNarration.Text = dss.Tables[0].Rows[0]["NARRATION"].ToString();
                 txtVendorbillno.Text = dss.Tables[0].Rows[0]["VENDOR_BILL"].ToString();
                 txtBilldate.Text = dss.Tables[0].Rows[0]["BILL_DATE"].ToString();
                 txtbillamount.Text = dss.Tables[0].Rows[0]["BILL_AMOUNT"].ToString();
                 txtInvoiceCurrency.Text = dss.Tables[0].Rows[0]["CURRENCY"].ToString();
                 txtExrate.Text = dss.Tables[0].Rows[0]["EX_RATE"].ToString();
                 txtTotalamtininr.Text = dss.Tables[0].Rows[0]["AMT_IN_INR"].ToString();
             }
             ViewState["CurrentTable"] = dss.Tables[1];

             if (dss.Tables[1].Rows.Count > 0)
             {
                 //dss.Tables[1].Columns.Add(new DataColumn("SNo", typeof(string)));
                 //gvdetails.Visible = false;

                 //gvbind.Visible = true;
                 gvdetails.DataSource = dss.Tables[1];
                 gvdetails.DataBind();

                 for (int i = 0; i < gvdetails.Rows.Count; i++)
                 {
                     gvdetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                     LinkButton lnkBtn = (LinkButton)gvdetails.Rows[i].FindControl("LinkButton1"); 
                     lnkBtn.Visible = true; 
                     FileUpload Fileupl = (FileUpload)gvdetails.Rows[i].FindControl("FileUpload1"); 
                     Fileupl.Visible = false; 


                     TextBox txtgCredit = (TextBox)gvdetails.Rows[i].Cells[9].FindControl("txtgCredit");
                     TextBox txtgDepit = (TextBox)gvdetails.Rows[i].Cells[10].FindControl("txtgDebit");
                     TextBox txtgCgst = (TextBox)gvdetails.Rows[i].Cells[11].FindControl("txtgCgst");
                     TextBox txtgScgst = (TextBox)gvdetails.Rows[i].Cells[12].FindControl("txtgScgst");
                     TextBox txtgIgst = (TextBox)gvdetails.Rows[i].Cells[13].FindControl("txtgIgst");
                     TextBox txtgTds = (TextBox)gvdetails.Rows[i].Cells[14].FindControl("txtgTds");
                     TextBox txtgTdsamt = (TextBox)gvdetails.Rows[i].Cells[15].FindControl("txtgdtsamt");
                     if (txtgCredit.Text != "")
                     {
                         totalcredit += Convert.ToDecimal(txtgCredit.Text);
                     }
                     if (txtgDepit.Text != "")
                     {
                         totaldebit += Convert.ToDecimal(txtgDepit.Text);
                     }
                     if (txtgCgst.Text != "") { totalcgst += Convert.ToDecimal(txtgCgst.Text); }
                     if (txtgScgst.Text != "") { totalsgst += Convert.ToDecimal(txtgScgst.Text); }
                     if (txtgIgst.Text != "") { totaligst += Convert.ToDecimal(txtgIgst.Text); }
                     if (txtgTdsamt.Text != "") { totaltds += Convert.ToDecimal(txtgTdsamt.Text); }

                 }
                 TextBox txtfcredittotal = (TextBox)gvdetails.FooterRow.FindControl("txtcredittotal");
                 TextBox txtfdebittotal = (TextBox)gvdetails.FooterRow.FindControl("txtdebittotal");
                 TextBox txtfcgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtcgsttotal");
                 TextBox txtfsgsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtsgsttotal");
                 TextBox txtfigsttotal = (TextBox)gvdetails.FooterRow.FindControl("txtigsttotal");
                 TextBox txtftdstotal = (TextBox)gvdetails.FooterRow.FindControl("txttdstotal");
                 txtfcredittotal.Text = totalcredit.ToString();
                 txtfdebittotal.Text = totaldebit.ToString();
                 txtfcgsttotal.Text = totalcgst.ToString();
                 txtfsgsttotal.Text = totalsgst.ToString();
                 txtfigsttotal.Text = totaligst.ToString();
                 txtftdstotal.Text = totaltds.ToString();
                 txtNetamt.Text = Convert.ToString(totaldebit + totalcgst + totaligst + totalsgst - totaltds);
                 txtGrandtotal.Text = Convert.ToString(totaldebit + totalcgst + totaligst + totalsgst );

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