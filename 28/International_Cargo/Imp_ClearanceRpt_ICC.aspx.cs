using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessObject;

public partial class Imp_ClearanceRpt_ICC : ThemeClass
{
    UserBO ObjUBO = new UserBO();
    //Despatch dispatch = new Despatch();
    AppSession aps = new AppSession();
    ICC Icc = new ICC();

    DataSet ds = new DataSet();
    public int i;
    public string LoginDate;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginDate = Session["LoginDate"].ToString();

        aps.checkSession();
        ds.Clear();
        if (!IsPostBack)
        {
            
            if (Request.QueryString["Page"] == "New")
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                Load_JobNo();
            }
            else
            {
                if (Request.QueryString["Page"] != null && Request.QueryString["Page"] != string.Empty)
                {
                    Update_Item_Load();
                    btnDelete.Visible = true;
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;

                    ddlJobNo.Enabled = false;
                    //txt_JobNo.Enabled = false;
                  
                }
            }           
        }
    }
    public void Load_JobNo()
    {
        try
        {
           ObjUBO.flag = "Load_Jobno";

           ds = Icc.Imp_ClearanceReport_Select(ObjUBO);
           if (ds.Tables[0].Rows.Count > 0)
           {
               ddlJobNo.DataSource = ds.Tables[0];
               ddlJobNo.DataTextField = "JOBNO";
               ddlJobNo.DataValueField = "JOBNO";
               ddlJobNo.DataBind();

               ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlJobNo.SelectedIndex = 0;
           }
           else
           {
               ddlJobNo.Items.Clear();
               ddlJobNo.Items.Insert(0, new ListItem(String.Empty, String.Empty));
               ddlJobNo.SelectedIndex = 0;
           }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
   
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            i = Insert_Update("U");
            if (i == 1)
            {
                if (ViewState["UPDATED_ID"] != null)
                {
                    Alert_msg("Updated Successfully", "btnUpdate");
                }
                else
                {
                    Alert_msg("Saved Successfully", "btnUpdate");
                }
            }
            else if (i == 2)
            {
                Alert_msg("Job No Already Exist!", "btnUpdate");
            }
            else
            {
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSave.Visible = false;
                btnNew.Visible = true;
                Alert_msg("Not Saved", "btnUpdate");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public void Alert_msg(string msg)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Despatch Information', function (r) {});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    public void Alert_msg(string msg, string focus)
    {
        string prompt = "<script>$(document).ready(function(){{jAlert('" + msg + "', 'Despatch Information', function (r) {document.getElementById('" + focus + "').focus();});}});</script>";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
    }

    protected void ddlJobNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        if (ddlJobNo.SelectedValue != string.Empty)
        {
            Clear();
            ObjUBO.flag = "JOB_NEW";
            ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
            //ds = dispatch.Imp_Despatch_Select(ObjUBO);
            ds = Icc.Imp_ClearanceReport_Select(ObjUBO);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_JobNo.Text = ddlJobNo.SelectedValue.ToString();
                txt_Date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                txt_PartyRefNo.Text = ds.Tables[0].Rows[0]["PARTY_REF_NO"].ToString();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_BLNumber.Text = ds.Tables[1].Rows[0]["IGM_MAWB_MBL"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    txt_Supplier.Text = ds.Tables[2].Rows[0]["SUPPLIER_NAME"].ToString();
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    txt_Description.Text = ds.Tables[3].Rows[0]["ITEM_DESCRIPTION"].ToString();
                }
               
            }

        }
         }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    public void Update_Item_Load()
    {
        try
        {
            Clear();
            ObjUBO.ITEM_ID = Request.QueryString["Page"].ToString();
            ObjUBO.JOBNO = Request.QueryString["Jobno"].ToString();
            ObjUBO.flag = "Updated_Jobno_Select";
            //ds = dispatch.Imp_Despatch_Select(ObjUBO);
            ds = Icc.Imp_ClearanceReport_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlJobNo.Items.Clear();
                HD_Update_id.Value = ds.Tables[0].Rows[0]["ID"].ToString();

                ddlJobNo.Items.Insert(0, new ListItem(ds.Tables[0].Rows[0]["JOBNO"].ToString()));
                ddlJobNo.SelectedIndex = 0;


                txt_JobNo.Text = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                txt_Date.Text = ds.Tables[0].Rows[0]["JOBDATE"].ToString();
                txt_PartyRefNo.Text = ds.Tables[0].Rows[0]["PARTY_REF_NO"].ToString();
                txt_BLNumber.Text = ds.Tables[0].Rows[0]["BL_NO"].ToString();
                //ddlJobNo.SelectedValue = ds.Tables[0].Rows[0]["JOBNO"].ToString();
                txt_Supplier.Text = ds.Tables[0].Rows[0]["SUPPLIER"].ToString();
                txt_Vessel.Text = ds.Tables[0].Rows[0]["VESSEL"].ToString();
                txt_Description.Text = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
                txt_Normaldate.Text = ds.Tables[0].Rows[0]["NORMAL_DOC_DATE"].ToString();
                txt_Originaldate.Text = ds.Tables[0].Rows[0]["ORIGINAL_DOC_DATE"].ToString();
                txt_Finaldate.Text = ds.Tables[0].Rows[0]["FINAL_ARRVL_DATE"].ToString();
                txt_Containerdate.Text = ds.Tables[0].Rows[0]["CONTAINER_ARRVL_DATE"].ToString();
                txt_Remarks.Text = ds.Tables[0].Rows[0]["REMARKS"].ToString();
               
                    
               
                ViewState["UPDATED_ID"] = "U";
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }

    public int Insert_Update(string a1)
    {
        Icc.ID = HD_Update_id.Value;
        Icc.JOBNO = txt_JobNo.Text;
        Icc.JOBDATE = txt_Date.Text;
        Icc.PARTY_REF_NO = txt_PartyRefNo.Text;
        Icc.NORMAL_DOC_DATE = txt_Normaldate.Text;
        Icc.BL_NO = txt_BLNumber.Text;
        Icc.DESCRIPTION = txt_Description.Text;
        Icc.SUPPLIER = txt_Supplier.Text;
        Icc.VESSEL = txt_Vessel.Text;
        Icc.ORIGINAL_DOC_DATE = txt_Originaldate.Text;
        Icc.FINAL_ARRVL_DATE = txt_Finaldate.Text;
        Icc.CONTAINER_ARRVL_DATE = txt_Containerdate.Text;
        Icc.REMARKS = txt_Remarks.Text;
        Icc.USERID = Connection.Current_User();
        Icc.LOGIN_DATE = LoginDate;
        Icc.STATUS = "S";
        Icc.BRANCHCODE = Connection.Current_Branch();
        Icc.WORKINGPERIOD =Connection.WorkingPeriod();
        Icc.Branch = Connection.Get_Company_Type();
        Icc.flag = a1;

        Icc.Import_ClearaneReport_Insert_Update();

        i = Icc.result;
        return i;
    }

    public void Clear()
    {    
        //txtImporterName.Text = "";
        txt_Date.Text = "";
        //txt_Invoice.Text = "";
        //txt_MAWBNo.Text = "";
        //txt_HAWBNo.Text = "";
        //txt_CourierNo.Text = "";
        //txt_courierdate.Text = "";
        //txt_CourierName.Text = "";
        //txt_pkgs.Text = "";
        //txtunitcode.Text = "";
        //txt_CourierName.Text = "";
        //txt_GrossWeight.Text = "";
        //txtQtyCode.Text = "";
        //txtPortOrigin.Text = "";
        //txtInwardDate.Text = "";
        //txtContainerNo.Text = "";
        //txt_Description.Text = "";
        //txt_BENo.Text = "";
        //txt_BEdate.Text = "";
        //txtdesc.Text = "";
        //txt_Imp_Add.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlJobNo.SelectedItem.Text != string.Empty) 
            {
                Insert_Update("S");
                if (i == 1)
                {
                    //-----------------------FOR USER RIGHTS--------------------------------//
                    ViewState["UPDATED_ID"] = null;

                    Alert_msg("Saved Successfully", "btnSave");
                    HD_Update_id.Value = Convert.ToString(Icc.UpdateId);

                    //txt_JobNo.Attributes.Add("readonly", "readonly");
                    //txt_JobNo.Style.Add("background-color", "#F0F0F0");
                    ddlJobNo.Attributes.Add("readonly", "readonly");
                    ddlJobNo.Style.Add("background-color", "#F0F0F0");
                    ddlJobNo.Enabled = false;

                }
                else if (i == 2)
                {
                    Alert_msg("Job No Already Exist!", "btnSave");
                }
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSave.Visible = true;
                    btnNew.Visible = true;
                    Alert_msg("Not Saved", "btnSave"); 
                }
            }
            else
            {
                Alert_msg("Select Ur Correct File Refno.");
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            ObjUBO.JOBNO = ddlJobNo.SelectedValue.ToString();
            ObjUBO.flag = "Delete";
            ds = Icc.Imp_ClearanceReport_Select(ObjUBO);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Alert_msg("Record Not Deleted", "btnUpdate");
            }
            else
            {
                string prompt = "<script>$(document).ready(function(){{jAlert('Despatch Deleted', 'Despatch Information', function (r) {var i = r + 'ok';if (i == 'trueok'){RefreshParent();} else {}});}});</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", prompt, false);
                btnNew_Click1(sender, e);
            }
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }
    }
    protected void btnNew_Click1(object sender, EventArgs e)
    {
        Transaction trans = new Transaction();
        trans.ResetFields(Page.Controls);
        btnUpdate.CssClass = "updates";

        ViewState["UPDATED_ID"] = null;
        btnSave.Visible = true;
        btnDelete.Visible = false;
        btnUpdate.Visible = false;

        Clear();

        ddlJobNo.Enabled = true;

        ddlJobNo.Attributes.Remove("readonly");
        ddlJobNo.Style.Add("background-color", "White");

        Load_JobNo();
        
    }
}
 