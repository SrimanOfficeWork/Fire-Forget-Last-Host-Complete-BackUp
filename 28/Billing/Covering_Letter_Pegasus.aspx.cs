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

    Covering_LTR LTR = new Covering_LTR();
    ErrorLogs er = new ErrorLogs();
    DataSet dsData = new DataSet();
    DataSet ds = new DataSet();
    AppSession aps = new AppSession();
    int i, UpdateID;
    Billing_UserBO objUBO = new Billing_UserBO();
  
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

                        //Hdn_Page_Value.Value = "Update";
                        btnDelete.Visible = true;
                        Button1.Visible = true;
                        btnUpdate.Visible = true;
                        //ButtonSave.CssClass = "updates";
                    }
                    else
                    {
                        hdnfld_Jobno.Value = "";
                        //Hdn_Page_Value.Value = "New";
                        btnDelete.Visible = false;
                        btnUpdate.Visible = false;
                        Button1.Visible = false;
                    }
                }

                if (Request.QueryString["Page"] == "New")
                {
                    Covering_No_Running();
                    hdnfld_Jobno.Value = "";
                    
                    //Hdn_Page_Value.Value = "New";
                    
                    //Get_Except_JobNo();
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    Button1.Visible = false;
                    
                }
                hdn_TYPE.Value = ddl_Type.SelectedItem.Text;          
            }
            catch (Exception ex)
            {
                ErrorLogs er = new ErrorLogs();
                er.makeLog(ex.Message);
            }

            if (Connection.COMPANYID() == "480" || Connection.COMPANYID() == "10" || Connection.COMPANYID() == "1019")
            {
                //ddl_PrintType.Enabled = true;
            }

            txt_Bill_Your_RefNo.Attributes.Add("onfocusout", "javascript:CallServerside_Bill_refno('" + txt_Bill_Your_RefNo.ClientID + "', '" + ddl_Type.ClientID + "')");

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

        objUBO.BRANCH_CODE = Connection.Get_Company_Type();
        objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
        objUBO.flag = "Select_All_NormalSearch";

        ds = LTR.RetrieveAll_Bill_Invoice_Details(objUBO);

    }

    public void Covering_No_Running()
    {
        objUBO.SW_ID = Request.QueryString["Page"].ToString();
        //objUBO.COVERING_NO = "";
        objUBO.TYPE = ddl_Type.SelectedItem.Text;
        objUBO.BRANCH_CODE = Connection.Current_Branch();
        objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
        objUBO.flag = "SELECT_MAXID";

        dsData = LTR.RetrieveAll_CoveringLetter_Details_Pegasus(objUBO);
        string Y1 = Connection.WorkingPeriod().Substring(9, 2);
        string Y2 = Connection.WorkingPeriod().Substring(23, 2);

        if (Request.QueryString["Page"] == "New")
        {
            if (dsData.Tables[0].Rows.Count > 0)
            {
                if (ddl_Type.SelectedItem.Text == "Import")
                {
                    txt_CoveringNo.Text = "IMP/" + dsData.Tables[0].Rows[0]["MAXID"].ToString() + "/" + Y1 + "-" + Y2;
                    hdn_Covering_No.Value = dsData.Tables[0].Rows[0]["MAXID"].ToString();
                }
                else
                {
                    txt_CoveringNo.Text = "EXP/" + dsData.Tables[0].Rows[0]["MAXID"].ToString() + "/" + Y1 + "-" + Y2;
                    hdn_Covering_No.Value = dsData.Tables[0].Rows[0]["MAXID"].ToString();
                }
            }

        }

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
        
     

    public int CoveringLetter_Insert_Update(string a1, string a2)
    {
        objUBO.SW_ID = hdnfld_Jobno.Value;
        objUBO.COVERING_NO = hdn_Covering_No.Value;
        objUBO.DISPATCH_DATE = txt_DispatchDate.Text == string.Empty ? "01/01/1900" : txt_DispatchDate.Text;
        objUBO.BILL_INVOICE_NO = txt_Bill_Your_RefNo.Text;
        objUBO.TYPE = ddl_Type.SelectedItem.Text;
        objUBO.IMPORTER_NAME = ddl_partyName.SelectedValue;
        objUBO.COVERING_PS = txt_CoveringNo.Text;

        objUBO.ADD1 = txt_Add1.Text;
        objUBO.ADD2 = txt_Add2.Text;
        objUBO.ADD3 = txt_Add3.Text;
        objUBO.ADD4 = txt_Add4.Text;
        objUBO.SUBJECT = txt_Subject.Text;
        objUBO.ATTACHMENT = txt_Attachement.Text;
        objUBO.Party_Ref = txt_RefNo.Text;
        
        objUBO.USER_ID = Connection.Current_User();
        objUBO.BRANCH_CODE = Connection.Current_Branch();
        objUBO.BRANCH_COMMON = Connection.Get_Company_Type();
        objUBO.WORKING_PERIOD = Connection.WorkingPeriod();
        objUBO.flag = a2;
        objUBO.TYPE = ddl_Type.SelectedItem.Text;
        objUBO.REMARKS = txt_EnteredBy.Text;
        
        LTR.Covering_LTR_INS_UPD_Pegasus(objUBO);
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

    public void Bind_Selected_IndexChanged()
    {
        if (Request.QueryString["Page"] != null)
        {
            objUBO.SW_ID = Request.QueryString["Page"].ToString();
            objUBO.COVERING_NO = "";
            objUBO.TYPE = "";
            objUBO.BRANCH_CODE = Connection.Current_Branch();
            objUBO.WORKING_PERIOD = Connection.Get_Company_Type();
            objUBO.BRANCH_COMMON = Connection.Get_Company_Type();
            objUBO.flag = "Bind_COVERING_LETTER_DETAILS";

            ds = LTR.RetrieveAll_CoveringLetter_Details_Pegasus(objUBO);

            int i = LTR.result;

            if (i == 1)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    objUBO.COVERING_NO = txt_CoveringNo.Text;
                    objUBO.DISPATCH_DATE = txt_DispatchDate.Text;
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
                    txt_Bill_Your_RefNo.Text = ds.Tables[0].Rows[0]["BILL_YOUR_REF_NO"].ToString();
                    
                    txt_Add1.Text = ds.Tables[0].Rows[0]["ADD1"].ToString();
                    txt_Add2.Text = ds.Tables[0].Rows[0]["ADD2"].ToString();
                    txt_Add3.Text = ds.Tables[0].Rows[0]["ADD3"].ToString();
                    txt_Add4.Text = ds.Tables[0].Rows[0]["ADD4"].ToString();
                    txt_Subject.Text = ds.Tables[0].Rows[0]["SUBJECT"].ToString();
                    txt_RefNo.Text = ds.Tables[0].Rows[0]["REF_NO"].ToString();
                    txt_Attachement.Text = ds.Tables[0].Rows[0]["ATTACHMENT"].ToString();
                   
                    ddl_partyName.Items.Remove(ds.Tables[0].Rows[0]["PARTY_NAME"].ToString());
                    //ddl_partyName.Items.Add("");
                    //ddl_partyName.SelectedItem.Text = ds.Tables[0].Rows[0]["PARTY_NAME"].ToString();
                    ddl_partyName.Items.Insert(0, ds.Tables[0].Rows[0]["PARTY_NAME"].ToString());
                    txt_EnteredBy.Text = ds.Tables[0].Rows[0]["ENTERED_BY"].ToString();

                  
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

            ds = LTR.RetrieveAll_CoveringLetter_Details_Pegasus(objUBO);

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
        hdn_TYPE.Value = ddl_Type.SelectedItem.Text;     
        Covering_No_Running();
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

        ds_party = LTR.RetrieveAll_CoveringLetter_Details_Pegasus(objUBO);

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
   
    [System.Web.Services.WebMethod]
    public static string Get_Bill_YourRefNo_Details_from_Billing(string custid, string custid1)
    {
        Auto_Search Auto = new Auto_Search();
        DataSet ds = new DataSet();
        
        Auto.Ename = "COVERING_BIND_container_Details_PEGASUS";
        Auto.Enamesearch = custid;
        Auto.NSearch = custid1;
        ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_BILLING_OTHERS();

        if (ds.Tables[0].Rows.Count > 0)
        {
            string Container = ds.Tables[0].Rows[0]["CONTAINER"].ToString();

            custid = Container;
        }
        else
        {
            custid = "Sub: ";
        }
        return custid;
    }
}