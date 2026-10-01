using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Web.UI.WebControls.WebParts;
using BussinessObject;


public partial class Export_BL_Generation_Annexure : ThemeClass
{

    public string Annex_Report_Type;
    Covering_LTR LTR = new Covering_LTR();
    DataTable dt = new DataTable();
    ErrorLogs er = new ErrorLogs();
    DataSet dsData = new DataSet();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    int i, UpdateID;
    Billing_UserBO objUBO = new Billing_UserBO();
    DataSet dss = new DataSet();
    string print_type = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();
        
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["Page"] != "New")
                {
                    if (Request.QueryString["Page"] != null)
                    {
                        Covering_No_Running();
                        Bind_Selected_IndexChanged();
                        

                        Hdn_get_type.Value = Annex_Report_Type;
                        Hdn_Page_Value.Value = "Update";
                        btnDelete.Visible = true;
                        Button1.Visible = true;
                        btnUpdate.Visible = true;
                        //ButtonSave.CssClass = "updates";
                    }
                    else
                    {
                        hdnfld_Jobno.Value = "";
                        Hdn_Page_Value.Value = "New";
                        btnDelete.Visible = false;
                        btnUpdate.Visible = false;
                        Button1.Visible = false;
                    }
                }

                if (Request.QueryString["Page"] == "New")
                {
                    Covering_No_Running();
                    hdnfld_Jobno.Value = "";
                    Hdn_get_type.Value = Annex_Report_Type;
                    Hdn_Page_Value.Value = "New";
                    txt_Subject.Text = "Kind Attention:";
                    //Get_Except_JobNo();
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    Button1.Visible = false;
                    
                }                              
            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();
                er.makeLog(ex.Message);
            }

            if (Connection.COMPANYID() == "480" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1019")
            {
                ddl_PrintType.Enabled = true;
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Grid_load();
    }

    public void Grid_load()
    {

        objUBO.SW_ID = hdnfld_Jobno.Value;
        //objUBO.COVERING_NO = "";
        objUBO.IMPORTER_NAME = ddl_partyName.SelectedItem.Text;
        objUBO.TYPE = ddl_Type.SelectedItem.Text;
        objUBO.From_date = txt_FromDate.Text;
        objUBO.Todate = txt_ToDate.Text;

        objUBO.BRANCH_CODE = Connection.Get_Company_Type();
        objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
        objUBO.flag = "Select_All_NormalSearch";

        ds = LTR.RetrieveAll_Bill_Invoice_Details(objUBO);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gv_Item.DataSource = ds.Tables[0];
            gv_Item.DataBind();
        }
        else
        {
            gv_Item.DataSource = dt;
            gv_Item.DataBind();
        }
    }

    public void Covering_No_Running()
    {
        objUBO.SW_ID = Request.QueryString["Page"].ToString();
        //objUBO.COVERING_NO = "";
        objUBO.COVERING_NO = ddl_PrintType.SelectedValue;
        objUBO.TYPE = ddl_Type.SelectedItem.Text;
        objUBO.BRANCH_CODE = Connection.Current_Branch();
        objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
        objUBO.flag = "SELECT_MAXID";

        dsData = LTR.RetrieveAll_CoveringLetter_Details(objUBO);
        string Y1 = Connection.WorkingPeriod().Substring(9, 2);
        string Y2 = Connection.WorkingPeriod().Substring(23, 2);

        if (Request.QueryString["Page"] == "New")
        {
            if (ddl_Type.SelectedItem.Text == "Import")
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    if (ddl_PrintType.SelectedValue != "BMW" && ddl_PrintType.SelectedValue != "CFS" && ddl_PrintType.SelectedValue != "GENERAL")
                    {
                        txt_CoveringNo.Text = "IMP/" + dsData.Tables[0].Rows[0]["MAXID"].ToString() + "/" + Y1 + "-" + Y2;
                        hdn_Covering_No.Value = dsData.Tables[0].Rows[0]["MAXID"].ToString();
                    }
                    else
                    {
                        txt_CoveringNo.Text = "SFD/COV/CL/" + dsData.Tables[0].Rows[0]["MAXID"].ToString();
                        hdn_Covering_No.Value = dsData.Tables[0].Rows[0]["MAXID"].ToString();
                    }
                }
            }
            else
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    if (ddl_PrintType.SelectedValue != "BMW" && ddl_PrintType.SelectedValue != "CFS" && ddl_PrintType.SelectedValue != "GENERAL")
                    {
                        txt_CoveringNo.Text = "EXP/" + dsData.Tables[0].Rows[0]["MAXID"].ToString() + "/" + Y1 + "-" + Y2;
                        hdn_Covering_No.Value = dsData.Tables[0].Rows[0]["MAXID"].ToString();
                    }
                    else
                    {
                        txt_CoveringNo.Text = "SFD/COV/CL/" + dsData.Tables[0].Rows[0]["MAXID"].ToString();
                        hdn_Covering_No.Value = dsData.Tables[0].Rows[0]["MAXID"].ToString();
                    }
                }
            }
        }
        if (print_type != "Yes")
        {
            if (ddl_Type.SelectedItem.Text == "Import")
            {
                if (dsData.Tables[1].Rows.Count > 0)
                {
                    ddl_partyName.DataSource = dsData.Tables[1];
                    ddl_partyName.DataValueField = "IMPORTER_NAME";
                    ddl_partyName.DataTextField = "IMPORTER_NAME";
                    ddl_partyName.DataBind();
                    ddl_partyName.Items.Insert(0, "");
                }
            }
            else
            {
                if (dsData.Tables[1].Rows.Count > 0)
                {
                    ddl_partyName.DataSource = dsData.Tables[1];
                    ddl_partyName.DataValueField = "EXPORTER_NAME";
                    ddl_partyName.DataTextField = "EXPORTER_NAME";
                    ddl_partyName.DataBind();
                    ddl_partyName.Items.Insert(0, "");
                }
            }
        }
    }  

    public int CoveringLetter_Insert_Update(string a1, string a2)
    {
        objUBO.SW_ID = hdnfld_Jobno.Value;
        objUBO.COVERING_NO = hdn_Covering_No.Value;
        //objUBO.DISPATCH_DATE = txt_DispatchDate.Text;
        //objUBO.From_date = txt_FromDate.Text;
        //objUBO.Todate = txt_ToDate.Text;

        objUBO.DISPATCH_DATE = txt_DispatchDate.Text == string.Empty ? "01/01/1900" : txt_DispatchDate.Text;
        objUBO.From_date = txt_FromDate.Text == string.Empty ? "01/01/1900" : txt_FromDate.Text;
        objUBO.Todate = txt_ToDate.Text == string.Empty ? "01/01/1900" : txt_ToDate.Text;

        objUBO.ADD1 = txt_Add1.Text;
        objUBO.ADD2 = txt_Add2.Text;
        objUBO.ADD3 = txt_Add3.Text;
        objUBO.ADD4 = txt_Add4.Text;
        objUBO.SUBJECT = txt_Subject.Text;
        objUBO.IMPORTER_NAME = ddl_partyName.SelectedItem.Text;
        objUBO.SCFS_BILL_NO = txt_SCFS_BillNo.Text;
        objUBO.ATTACHMENT = txt_Attachement.Text;
        objUBO.SCFS_AMOUNT = txt_SCFS_Amount.Text;
        objUBO.CFS_BILLNO = txt_CFS_BILLNO.Text;


        foreach (GridViewRow row in gv_Item.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("chk") as CheckBox);
                //CheckBox chkRow = (CheckBox)row.FindControl("chk");

                if (chkRow.Checked)
                {
                    objUBO.BILL_INVOICE_NO += row.Cells[1].Text + "*T" + "^";
                    objUBO.BILL_INVOICE_DATE += row.Cells[2].Text+ "^";
                    objUBO.BILL_REMARKS += row.Cells[3].Text  + "^";
                    objUBO.Party_Ref += row.Cells[4].Text + "^";
                    objUBO.CFS_CHARGE += row.Cells[5].Text  + "^";
                    objUBO.TOTAL += row.Cells[6].Text + "^";
                }
                else
                {
                    objUBO.BILL_INVOICE_NO += row.Cells[1].Text + "*F" + "^" ;
                    objUBO.BILL_INVOICE_DATE += row.Cells[2].Text  + "^" ;                   
                    objUBO.BILL_REMARKS += row.Cells[3].Text  + "^";
                    objUBO.Party_Ref += row.Cells[4].Text  + "^";
                    objUBO.CFS_CHARGE += row.Cells[5].Text + "^";
                    objUBO.TOTAL += row.Cells[6].Text + "^";
                }
            }
        }

        objUBO.USER_ID = Connection.Current_User();
        objUBO.BRANCH_CODE = Connection.Current_Branch();
        objUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        objUBO.WORKING_PERIOD = Connection.WorkingPeriod();
        objUBO.flag = a2;
        objUBO.TYPE = ddl_Type.SelectedItem.Text;
        objUBO.BILL_TYPE = ddl_PrintType.SelectedItem.Text;
        objUBO.COVERING_PS = txt_CoveringNo.Text;

        LTR.Covering_LTR_INS_UPD(objUBO);
        i = LTR.result;
        UpdateID = LTR.UPDATE_ID;
        return i;         
    }

    protected void ButtonSave_Click(object sender, EventArgs e)
    {
        hdnfld_Jobno.Value = "";
        i = CoveringLetter_Insert_Update("N", "S");

        if (i == 1)
        {
            Alert_msg("Saved Successfully");
            btnUpdate.Visible = true;
            ButtonSave.Visible = false;
            btnDelete.Visible = true;
            Button1.Visible = true;

            hdnfld_Jobno.Value = Convert.ToString(UpdateID);
            ViewState["UpdateID"] = hdnfld_Jobno.Value;
        }
        else
        {
            Alert_msg("Not Saved ");
            btnUpdate.Visible = false;
            ButtonSave.Visible = true;
            btnDelete.Visible = false;
            Button1.Visible = false;
        }
        
    }

    protected void gv_Item_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
            e.Row.CssClass = "header";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Normal)
            e.Row.CssClass = "normal";
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Alternate)
            e.Row.CssClass = "alternate";
    }
    protected void gv_Item_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var row = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Bill_inv = e.Row.Cells[1].Text;


            string[] result = Bill_inv.Split('*');

            if (result.Length > 1)
            {
                if (result[1] == "T")
                {
                    CheckBox chk = (e.Row.FindControl("chk") as CheckBox);
                    chk.Checked = true;
                    e.Row.Cells[1].Text = Bill_inv.Replace("*T", "").Replace("*F", "");
                    //e.Row.Cells[2].Text = Bill_inv.Replace("*T", "").Replace("*F", "");
                    //e.Row.Cells[3].Text = Bill_inv.Replace("*T", "").Replace("*F", "");
                    //e.Row.Cells[4].Text = Bill_inv.Replace("*T", "").Replace("*F", "");

                }
                else
                {
                    e.Row.Cells[1].Text = Bill_inv.Replace("*T", "").Replace("*F", "");
                    //e.Row.Cells[2].Text = Bill_inv.Replace("*T", "").Replace("*F", "");
                    //e.Row.Cells[3].Text = Bill_inv.Replace("*T", "").Replace("*F", "");
                    //e.Row.Cells[4].Text = Bill_inv.Replace("*T", "").Replace("*F", "");
                }
            }
        }
    }

    public void Bind_Selected_IndexChanged()
    {
        DataTable dt_bill = new DataTable();
        dt_bill.Columns.Add("ID");
        dt_bill.Columns.Add("BILL_INV_NO");
        dt_bill.Columns.Add("BILL_INV_DATE");
        dt_bill.Columns.Add("FILE_REF_NO");
        dt_bill.Columns.Add("TOTAL_AMT_TAX");
        dt_bill.Columns.Add("PARTY_REF");
        dt_bill.Columns.Add("CFS_CHARGE");

        if (Request.QueryString["Page"] != null)
        {
            objUBO.SW_ID = Request.QueryString["Page"].ToString();
            objUBO.COVERING_NO = "";
            objUBO.TYPE = "";
            objUBO.BRANCH_CODE = Connection.Current_Branch();
            objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
            objUBO.BRANCH_COMMON = Connection.Get_Company_Type();
            objUBO.flag = "Bind_COVERING_LETTER_DETAILS";

            ds = LTR.RetrieveAll_CoveringLetter_Details(objUBO);

            int i = LTR.result;

            if (i == 1)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objUBO.COVERING_NO = txt_CoveringNo.Text;
                    objUBO.DISPATCH_DATE = txt_DispatchDate.Text;
                    objUBO.From_date = txt_FromDate.Text;
                    objUBO.Todate = txt_ToDate.Text;
                    objUBO.ADD1 = txt_Add1.Text;
                    objUBO.ADD2 = txt_Add2.Text;
                    objUBO.ADD3 = txt_Add3.Text;
                    objUBO.ADD4 = txt_Add4.Text;
                    objUBO.SUBJECT = txt_Subject.Text;

                    hdnfld_Jobno.Value = ds.Tables[0].Rows[0]["ID"].ToString();
                    //txt_CoveringNo.Text = ds.Tables[0].Rows[0]["COVERING_NO"].ToString();
                    string Y1 = Connection.WorkingPeriod().Substring(9, 2);
                    string Y2 = Connection.WorkingPeriod().Substring(23, 2);

                    if (ds.Tables[0].Rows[0]["TYPE"].ToString() == "Import")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //txt_CoveringNo.Text = "IMP/" + ds.Tables[0].Rows[0]["COVERING_NO"].ToString() + "/" + Y1 + "-" + Y2;
                            txt_CoveringNo.Text = ds.Tables[0].Rows[0]["COVERING_PS"].ToString();
                            hdn_Covering_No.Value = ds.Tables[0].Rows[0]["COVERING_NO"].ToString();
                            
                        }
                    }
                    else
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //txt_CoveringNo.Text = "EXP/" + ds.Tables[0].Rows[0]["COVERING_NO"].ToString() + "/" + Y1 + "-" + Y2;
                            txt_CoveringNo.Text = ds.Tables[0].Rows[0]["COVERING_PS"].ToString();
                            hdn_Covering_No.Value = ds.Tables[0].Rows[0]["COVERING_NO"].ToString();
                        }
                    }
                    ddl_Type.SelectedItem.Text = ds.Tables[0].Rows[0]["TYPE"].ToString();
                    txt_DispatchDate.Text = ds.Tables[0].Rows[0]["DISPATCH_DATE"].ToString();
                    txt_FromDate.Text = ds.Tables[0].Rows[0]["FROM_DATE"].ToString().Replace("01/01/1900","");
                    txt_ToDate.Text = ds.Tables[0].Rows[0]["TO_DATE"].ToString().Replace("01/01/1900", "");
                    txt_Add1.Text = ds.Tables[0].Rows[0]["ADD1"].ToString();
                    txt_Add2.Text = ds.Tables[0].Rows[0]["ADD2"].ToString();
                    txt_Add3.Text = ds.Tables[0].Rows[0]["ADD3"].ToString();
                    txt_Add4.Text = ds.Tables[0].Rows[0]["ADD4"].ToString();
                    txt_Subject.Text = ds.Tables[0].Rows[0]["SUBJECT"].ToString();
                    txt_SCFS_BillNo.Text = ds.Tables[0].Rows[0]["SCFS_BILL_NO"].ToString();
                    txt_Attachement.Text = ds.Tables[0].Rows[0]["ATTACHMENT"].ToString();
                    txt_SCFS_Amount.Text = ds.Tables[0].Rows[0]["SCFS_AMOUNT"].ToString();
                    txt_CFS_BILLNO.Text = ds.Tables[0].Rows[0]["CFS_BILLNO"].ToString();
                  
                    //Covering_No_Running();

                    ddl_partyName.Items.Remove(ds.Tables[0].Rows[0]["PARTY_NAME"].ToString());
                    //ddl_partyName.Items.Add("");
                    //ddl_partyName.SelectedItem.Text = ds.Tables[0].Rows[0]["PARTY_NAME"].ToString();
                    ddl_partyName.Items.Insert(0, ds.Tables[0].Rows[0]["PARTY_NAME"].ToString());

                    ddl_PrintType.Items.Remove(ds.Tables[0].Rows[0]["PRINT_TYPE"].ToString());
                    //ddl_PrintType.Items.Add("");
                    //ddl_PrintType.SelectedItem.Text = ds.Tables[0].Rows[0]["PRINT_TYPE"].ToString();
                    ddl_PrintType.Items.Insert(0, ds.Tables[0].Rows[0]["PRINT_TYPE"].ToString());
                    ddl_PrintType.SelectedValue = ds.Tables[0].Rows[0]["PRINT_TYPE"].ToString();

                    if (ds.Tables[0].Rows[0]["BILL_INVOICE_NO"].ToString().Length > 0)
                    {
                        //string[] a = ds.Tables[0].Rows[0]["BILL_INVOICE_NO"].ToString().Replace("*T", "").Replace("*F", "").Trim().Split('^');
                        string[] b = ds.Tables[0].Rows[0]["BILL_INVOICE_DATE"].ToString().Replace("*T", "").Replace("*F", "").Trim().Split('^');
                        string[] c = ds.Tables[0].Rows[0]["BILL_REMARKS"].ToString().Replace("*T", "").Replace("*F", "").Replace("&nbsp;","").Trim().Split('^');
                        string[] d = ds.Tables[0].Rows[0]["TOTAL"].ToString().Trim().Replace("*T", "").Replace("*F", "").Split('^');

                        string[] a = ds.Tables[0].Rows[0]["BILL_INVOICE_NO"].ToString().Trim().Split('^');
                        string[] e = ds.Tables[0].Rows[0]["PARTY_REF_NO"].ToString().Replace("*T", "").Replace("*F", "").Replace("&nbsp;", "").Trim().Split('^');
                        string[] f = ds.Tables[0].Rows[0]["BILL_CFS_CHARGE"].ToString().Replace("*T", "").Replace("*F", "").Replace("&nbsp;", "").Trim().Split('^');


                        //string[] b = ds.Tables[0].Rows[0]["BILL_INVOICE_DATE"].ToString().Trim().Split('^');
                        //string[] c = ds.Tables[0].Rows[0]["BILL_REMARKS"].ToString().Trim().Split('^');
                        //string[] d = ds.Tables[0].Rows[0]["TOTAL"].ToString().Trim().Split('^');

                        int cnt = a.Count();

                        for (int j = 0; j <= cnt - 1; j++)
                        {
                            if (a[j] != "")
                            {
                                //CheckBox txtIGST_AMT = (e.Row.FindControl("txtIGST_AMT") as CheckBox);
                                //CheckBox txtIGST_AMT1 =(gv_Item.Rows[j].Cells[0].Text)as CheckBox);
                                //CheckBox txtIGST_AMT1 =(gv_Item.R)as CheckBox);

                                string PartyRef = "";
                                if (e.Count() == 1)// is empty or null value check
                                {
                                    PartyRef = "";
                                }
                                else
                                {
                                    PartyRef = e[j];
                                }

                                string cfscharge = "";
                                if (f.Count()==1)// is empty or null value check
                                {
                                    cfscharge = "";
                                }
                                else
                                {
                                    cfscharge = f[j];
                                }

                                dt_bill.Rows.Add(hdnfld_Jobno.Value, a[j], b[j], c[j], d[j], PartyRef, cfscharge);
                            }
                        }
                        DataSet ds_fill = new DataSet();
                        ds_fill.Tables.Add(dt_bill);
                        ViewState["ds"] = ds_fill;
                        gv_Item.DataSource = dt_bill;
                        gv_Item.DataBind();
                    }

                    btnDelete.Visible = true;
                    Button1.Visible = true;
                    btnUpdate.Visible = true;
                    ButtonSave.Visible = false;
                    //ButtonSave.CssClass = "updates";
                }
                else
                {
                    btnDelete.Visible = false;
                    Button1.Visible = false;
                    btnUpdate.Visible = false;
                    //ButtonSave.CssClass = "save";
                    ButtonSave.Visible = true;
                }
            }
        }
        else
        {
            btnDelete.Visible = false;
            Button1.Visible = false;
            btnUpdate.Visible = false;
            //ButtonSave.CssClass = "save";
            ButtonSave.Visible = true;
        }
    }
  
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Covering Letter', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Covering Letter', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        i = CoveringLetter_Insert_Update("N", "U");
        Alert_msg("Updated Successfully");
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Page"] != null)
        {
            objUBO.SW_ID = hdnfld_Jobno.Value;
            objUBO.COVERING_NO = txt_CoveringNo.Text;
            objUBO.TYPE = ddl_Type.SelectedItem.Text;
            objUBO.BRANCH_COMMON = Connection.Current_Branch();
            objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
            objUBO.flag = "delete";

            ds = LTR.RetrieveAll_CoveringLetter_Details(objUBO);

            int i = LTR.result;

            if (i == 1)
            {
                Alert_msg("Record Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
    }
    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        Covering_No_Running();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //hdnfld_Jobno.Value = ViewState["UpdateID"].ToString();
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "open_anx()", true);
    }
    protected void btnDelete_Click1(object sender, EventArgs e)
    {
        if (Request.QueryString["Page"] != null)
        {
            objUBO.SW_ID = hdnfld_Jobno.Value;
            objUBO.COVERING_NO = txt_CoveringNo.Text;
            objUBO.TYPE = ddl_Type.SelectedItem.Text;
            objUBO.BRANCH_COMMON = Connection.Current_Branch();
            objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
            objUBO.flag = "delete";

            ds = LTR.RetrieveAll_CoveringLetter_Details(objUBO);

            int i = LTR.result;

            if (i == 1)
            {
                Alert_msg("Record Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
    }
    protected void ddl_partyName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds_party = new DataSet();

        objUBO.SW_ID ="";
        objUBO.COVERING_NO = ddl_partyName.SelectedItem.Text;
        objUBO.TYPE = ddl_Type.SelectedItem.Text;
        objUBO.BRANCH_CODE = Connection.Current_Branch();
        objUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
        objUBO.flag = "SELECT_PartyName_Details";

        ds_party = LTR.RetrieveAll_CoveringLetter_Details(objUBO);

        if (ds_party.Tables[0].Rows.Count > 0)
        {
            string val = ds_party.Tables[0].Rows[0]["SHIPPER_ADDRESS"].ToString().Replace("\r\n", "^");
            string[] aa = val.Split('^');

            int cnt = aa.Length;

            //for (int x = 0; x <=cnt - 1; x++)
            //{
                if (cnt == 6 || cnt >= 6)
                {
                    txt_Add1.Text = aa[0];
                    txt_Add2.Text = aa[1];
                    txt_Add3.Text = aa[2] + " " + aa[3];
                    txt_Add4.Text = aa[4] + " " + aa[5];
                }
                else if (cnt == 5)
                {
                    txt_Add1.Text = aa[0];
                    txt_Add2.Text = aa[1];
                    txt_Add3.Text = aa[2];
                    txt_Add4.Text = aa[3] + " " + aa[4];
                }
                else if (cnt == 4)
                {
                    txt_Add1.Text = aa[0];
                    txt_Add2.Text = aa[1];
                    txt_Add3.Text = aa[2];
                    txt_Add4.Text = aa[3];
                }
                else if (cnt == 3)
                {
                    txt_Add1.Text = aa[0];
                    txt_Add2.Text = aa[1];
                    txt_Add3.Text = aa[2];
                    txt_Add4.Text = "";
                }
                else if (cnt == 2)
                {
                    txt_Add1.Text = aa[0];
                    txt_Add2.Text = aa[1];
                    txt_Add3.Text = "";
                    txt_Add4.Text = "";
                }
                else if (cnt == 1)
                {
                    txt_Add1.Text = aa[0];
                    txt_Add2.Text = "";
                    txt_Add3.Text = "";
                    txt_Add4.Text = "";
                }
                else 
                {
                    txt_Add1.Text = "";
                    txt_Add2.Text = "";
                    txt_Add3.Text = "";
                    txt_Add4.Text = "";
                }
            //}
        }
    }
    protected void ddl_PrintType_SelectedIndexChanged(object sender, EventArgs e)
    {
        print_type = "Yes";
        Covering_No_Running();
    }
}