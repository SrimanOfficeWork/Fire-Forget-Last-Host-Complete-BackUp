using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Billing_Others_Details : ThemeClass
{
    
    TALLY_Billing_Others bill = new TALLY_Billing_Others();
    ErrorLogs er = new ErrorLogs();

    DataSet dss = new DataSet();
    AppSession aps = new AppSession();
    public int i;
    public string IMPORT_JOBNO, flag = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            aps.checkSession();

            if (!string.IsNullOrEmpty(Session["IMPORT_JOBNO"] as string))
            {
                IMPORT_JOBNO = Session["IMPORT_JOBNO"].ToString();
                hdfTransport_mode.Value = Session["Transport_Mode_Port"].ToString();
                Hdn_STANDARD_TYPE.Value = Session["STANDARD_TYPE"].ToString();
            }
            if (!IsPostBack)
            {
                Load_Doc_UserNameList();
                Bind_Details();

            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

    public void Bind_Details()
    {
        try
        {
            lbl_Invno.Text = string.Empty;

            bill.JOBNO = IMPORT_JOBNO;
            bill.Flag = "select_con";
            dss = bill.RetrieveAll_BILLING_OTHERS_Details();
            if (dss.Tables[0].Rows.Count > 0)
            {
                ViewState["UPDATED_ID"] = dss.Tables[0].Rows[0]["ID"].ToString();

                ddl_Jobtype.SelectedValue = dss.Tables[0].Rows[0]["SPL_JOBTYPE"].ToString();

                txtCBM.Text = dss.Tables[0].Rows[0]["CBM"].ToString();
                txt_Name.Text = dss.Tables[0].Rows[0]["NAME"].ToString();
                txtAddress1.Text = dss.Tables[0].Rows[0]["ADDRESS1"].ToString();
                txtAddress2.Text = dss.Tables[0].Rows[0]["ADDRESS2"].ToString();
                txtAddress3.Text = dss.Tables[0].Rows[0]["ADDRESS3"].ToString();
                txtAddress4.Text = dss.Tables[0].Rows[0]["ADDRESS4"].ToString();

                txt_Acc_Head.Text = dss.Tables[0].Rows[0]["ACCOUNT_HEAD"].ToString();
                txt_Cleared_Date.Text = dss.Tables[0].Rows[0]["CLEARED_DATE"].ToString();
                txt_Created_Date.Text = dss.Tables[0].Rows[0]["CREATED_DATE"].ToString();
                txt_Amendment_Date.Text = dss.Tables[0].Rows[0]["AMENDMENT_DATE"].ToString();
                txt_BOE_Date.Text = dss.Tables[0].Rows[0]["BOE_DATE"].ToString();
                txt_Empty_Handover_Date.Text = dss.Tables[0].Rows[0]["EMPTY_HANDOVER_DATE"].ToString();
                txt_OOC_Date.Text = dss.Tables[0].Rows[0]["OOC_DATE"].ToString();
                txt_SalesPerson.Text = dss.Tables[0].Rows[0]["SALES_PERSON"].ToString();
                ddl_DocUser.SelectedValue = dss.Tables[0].Rows[0]["DOC_USER"].ToString();

                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnNew.Visible = false;
            }
            else
            {
                btnDelete.Visible = false;
                btnUpdate.Visible = false;
                btnSave.Visible = true;
                btnNew.Visible = true;
            }

            if (dss.Tables[1].Rows.Count > 0)
            {
                lbl_Invno.Text = dss.Tables[1].Rows[0]["Inv_No"].ToString();
            }
            else
            {
                lbl_Invno.Text = string.Empty;
            }
            txt_Name.Attributes.Add("onblur", "javascript:CallServerside_Importer_BillingOthers('" + txt_Name.ClientID + "', '" + hd_Brslno.ClientID + "')");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
        
    }

    public void Insert_update(string IMPORT_JOBNO)
    {
        try
        {
            bill.ID = ViewState["UPDATED_ID"].ToString();
            bill.JOBNO = IMPORT_JOBNO;//call session value from general details
            bill.SPL_JOBTYPE = ddl_Jobtype.SelectedValue;
            bill.CBM = txtCBM.Text;
            bill.NAME = txt_Name.Text;
            bill.ADDRESS1 = txtAddress1.Text;
            bill.ADDRESS2 = txtAddress2.Text;
            bill.ADDRESS3 = txtAddress3.Text;
            bill.ADDRESS4 = txtAddress4.Text;

            bill.ACCOUNT_HEAD = txt_Acc_Head.Text;
            bill.CLEARED_DATE = txt_Cleared_Date.Text;
            bill.CREATED_DATE = txt_Created_Date.Text;
            bill.AMENDMENT_DATE = txt_Amendment_Date.Text;
            bill.BOE_DATE = txt_BOE_Date.Text;
            bill.EMPTY_HANDOVER_DATE = txt_Empty_Handover_Date.Text;
            bill.OOC_DATE = txt_OOC_Date.Text;
            bill.SALES_PERSON = txt_SalesPerson.Text;
            bill.DOC_USER = ddl_DocUser.SelectedItem.Text;


            bill.USER_ID = Connection.Current_User();
            bill.Flag = flag;
            bill.BRANCH_CODE = Connection.Current_Branch();
            bill.WORKING_PERIOD = Connection.WorkingPeriod();
            bill.BRANCH_COMMON = Connection.Get_Company_Type();


            i = bill.Imp_BILLING_OTHERS_insertupdate();
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        try
        {
            Transaction Transact = new Transaction();
            Transact.ResetFields(Page.Controls);

            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnSave.Visible = true;
            btnNew.Visible = true;
            btnUpdate.CssClass = "updates";

            ViewState["UPDATED_ID"] = null;
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
      
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            flag = "U";

            Insert_update(IMPORT_JOBNO);

            if (i == 1)
            {
                ViewState["UPDATED_ID"] = bill.UPDATE_ID;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                Alert_msg("Updated Successfully");
            }
            else
            {
                Alert_msg("Not Updated");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
      
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            flag = "S";
            ViewState["UPDATED_ID"] = "0";
            Insert_update(IMPORT_JOBNO);

            if (i == 1)
            {
                ViewState["UPDATED_ID"] = bill.UPDATE_ID;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                Alert_msg("Saved Successfully", "btnSave");
            }
            else
            {
                Alert_msg("Not Saved", "btnSave");
            }
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }

  
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int ii = 0;
            bill.JOBNO = IMPORT_JOBNO;
            bill.ID = ViewState["UPDATED_ID"].ToString();
            bill.WORKING_PERIOD = Connection.Get_Company_Type();
            bill.BRANCH_CODE = Connection.Current_Branch();
            bill.Ename = "delete";
            dss = bill.RetrieveAll_BILLING_OTHERS_Details();

            ii = bill.result;

            if (ii > 0)
            {
                btnNew_Click(sender, e);
              
                //Elogix_Service();
                Alert_msg("Deleted");
            }
            else
            {
                Alert_msg("Not Deleted");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   
  
    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BILLING - OTHERS', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'BILLING - OTHERS', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }


    [System.Web.Services.WebMethod]
    public static string GetImporter_Billing_Others(string custid, string custid1)
    {
        try
        {
            Auto_Search Auto = new Auto_Search();
            DataSet ds = new DataSet();
            DataSet dss = new DataSet();
            string STD_Type = "";

            if (HttpContext.Current.Session["STANDARD_TYPE"] != null)
            {
                STD_Type = HttpContext.Current.Session["STANDARD_TYPE"].ToString();

                if (STD_Type == "Non_STD")
                {
                    STD_Type = STD_Type;
                }
                else
                {
                    STD_Type = "";
                }
            }

            Auto.Ename = "IMP_EXP_MASTER_IMPORTER_SEARCH_Slno";
            Auto.Enamesearch = custid;
            Auto.NSearch = custid1;
            Auto.STANDARD_TYPE = STD_Type;
            ds = Auto.ERoyalmaste_RetrieveAll_AUTOCOMPLETE_SEARCH_STD_Type();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string Name = ds.Tables[0].Rows[0]["IMP_EXP_NAME"].ToString();
                string Address1 = ds.Tables[0].Rows[0]["IMP_EXP_ADD1"].ToString();
                string Address2 = ds.Tables[0].Rows[0]["IMP_EXP_ADD2"].ToString();
                string Address3 = ds.Tables[0].Rows[0]["IMP_EXP_ADD3"].ToString();
                string Address4 = ds.Tables[0].Rows[0]["IMP_EXP_ADD4"].ToString() + " " + ds.Tables[0].Rows[0]["IMP_EXP_PIN_CODE"].ToString();

                custid = Name + "~~" + Address1 + "~~" + Address2 + "~~" + Address3 + "~~" + Address4;

            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
       
        return custid;
    }

    private void Load_Doc_UserNameList()
    {
        try
        {
            Company_Master Comp = new Company_Master();
            DataSet ds = new DataSet();
            Comp.COMPANY_ID = "";
            Comp.BRANCH = "";
            Comp.flag = "Select-Group";
            ds = Comp.RetrieveAll_Groups();

            if (ds.Tables[2].Rows.Count > 0)
            {
                ddl_DocUser.DataSource = ds.Tables[2];
                ddl_DocUser.DataTextField = "NAME";
                ddl_DocUser.DataValueField = "NAME";
                ddl_DocUser.DataBind();
            }

            ddl_DocUser.Items.Insert(0, "");
        }
        catch (Exception ex)
        {
            er.makeLog(ex.Message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('An Error has been Detected In This Process');", true);
        }
       
    }
  
}