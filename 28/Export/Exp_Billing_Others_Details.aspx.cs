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

public partial class Exp_Billing_Others_Details : ThemeClass
{
  
    Transaction Transact = new Transaction();
    TALLY_Billing_Others bill = new TALLY_Billing_Others();
    DataSet dtuser = new DataSet();
    DataSet dss = new DataSet();
    AppSession aps = new AppSession();
    ErrorLogs er = new ErrorLogs();
    public int i;
   
    public string EXPORT_JOBNO, flag = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        aps.checkSession();

        if (!string.IsNullOrEmpty(Session["EXPORT_JOBNO"] as string))
        {
            EXPORT_JOBNO = Session["EXPORT_JOBNO"].ToString();
        }
        if (!IsPostBack)
        {
            Load_Doc_UserNameList();
            Bind_Details();
        }
    }

    public void Bind_Details()
    {
        lbl_Invno.Text = string.Empty;
        bill.JOBNO = EXPORT_JOBNO;
        bill.Flag = "select_con";
        dss = bill.RetrieveAll_export_BILLING_OTHERS_Details();
        if (dss.Tables[0].Rows.Count > 0)
        {
            ViewState["UPDATED_ID"] = dss.Tables[0].Rows[0]["ID"].ToString();

            ddl_FCL.Items.Remove(dss.Tables[0].Rows[0]["FCL_LCL"].ToString());
            ddl_FCL.Items.Insert(0, dss.Tables[0].Rows[0]["FCL_LCL"].ToString());
            ddl_FCL.SelectedIndex = -1;

            txt_Voyage.Text = dss.Tables[0].Rows[0]["VOYAGE"].ToString();
            txt_Vessel.Text = dss.Tables[0].Rows[0]["VESSEL"].ToString();
            txtMBLNo.Text = dss.Tables[0].Rows[0]["MBL_NO"].ToString();
            txtMBLDate.Text = dss.Tables[0].Rows[0]["MBL_DATE"].ToString();
            txtHBLNo.Text = dss.Tables[0].Rows[0]["HBL_NO"].ToString();
            txtHBLDate.Text = dss.Tables[0].Rows[0]["HBL_DATE"].ToString();

            ddl_Jobtype.SelectedValue = dss.Tables[0].Rows[0]["SPL_JOBTYPE"].ToString();

            txtCBM.Text = dss.Tables[0].Rows[0]["CBM"].ToString();

            txt_Acc_Head.Text = dss.Tables[0].Rows[0]["ACCOUNT_HEAD"].ToString();
            txt_Cleared_Date.Text = dss.Tables[0].Rows[0]["CLEARED_DATE"].ToString();
            txt_Created_Date.Text = dss.Tables[0].Rows[0]["CREATED_DATE"].ToString();
            txt_Amendment_Date.Text = dss.Tables[0].Rows[0]["AMENDMENT_DATE"].ToString();
            txt_SB_Date.Text = dss.Tables[0].Rows[0]["SB_DATE"].ToString();
            txt_Empty_Handover_Date.Text = dss.Tables[0].Rows[0]["EMPTY_HANDOVER_DATE"].ToString();
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
    }

    public void Insert_update(string IMPORT_JOBNO)
    {
        bill.ID = ViewState["UPDATED_ID"].ToString();
        bill.JOBNO = EXPORT_JOBNO;//call session value from general details
        bill.FCL_LCL = ddl_FCL.SelectedItem.Text;
        bill.VOYAGE = txt_Voyage.Text;
        bill.VESSEL = txt_Vessel.Text;
        bill.MBL_NO = txtMBLNo.Text;
        bill.MBL_DATE = txtMBLDate.Text;
        bill.HBL_NO = txtHBLNo.Text;
        bill.HBL_DATE = txtHBLDate.Text;

        bill.SPL_JOBTYPE = ddl_Jobtype.SelectedValue;
        bill.CBM = txtCBM.Text;
        bill.ACCOUNT_HEAD = txt_Acc_Head.Text;
        bill.CLEARED_DATE = txt_Cleared_Date.Text;
        bill.CREATED_DATE = txt_Created_Date.Text;
        bill.AMENDMENT_DATE = txt_Amendment_Date.Text;
        bill.BOE_DATE = txt_SB_Date.Text;
        bill.EMPTY_HANDOVER_DATE = txt_Empty_Handover_Date.Text;
        bill.SALES_PERSON = txt_SalesPerson.Text;
        bill.DOC_USER = ddl_DocUser.SelectedItem.Text;

        bill.USER_ID = Connection.Current_User();
        bill.Flag = flag;
        bill.BRANCH_CODE = Connection.Current_Branch();
        bill.WORKING_PERIOD = Connection.WorkingPeriod();
        bill.BRANCH_COMMON = Connection.Get_Company_Type();

        i = bill.Exp_BILLING_OTHERS_insertupdate();
       
    }


    protected void btnNew_Click(object sender, EventArgs e)
    {
        Transact.ResetFields(Page.Controls);
       
        btnDelete.Visible = false;
        btnUpdate.Visible = false;
        btnSave.Visible = true;
        btnNew.Visible = true;
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
     
    }

   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        flag = "U";

        Insert_update(EXPORT_JOBNO);

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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        flag = "S";
        ViewState["UPDATED_ID"] = "0";
        Insert_update(EXPORT_JOBNO);

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

  

  
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int ii = 0;
            bill.JOBNO = EXPORT_JOBNO;
            bill.ID = ViewState["UPDATED_ID"].ToString();
            bill.WORKING_PERIOD = Connection.Get_Company_Type();
            bill.BRANCH_CODE = Connection.Current_Branch();
            bill.Ename = "delete";
            dss = bill.RetrieveAll_export_BILLING_OTHERS_Details();

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
            er.makeLog(ex.Message);
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


    private void Load_Doc_UserNameList()
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
  
}